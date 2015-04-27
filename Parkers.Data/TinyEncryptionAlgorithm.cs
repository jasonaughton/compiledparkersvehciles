// <copyright file="TinyEncryptionAlgorithm.cs" company="Bauer Consumer Media Limited">
//     Copyright 2010 Bauer Consumer Media Limited
// </copyright>
// <author>Kalpesh Mistry</author>

namespace Parkers.Data
{
    #region usings

    using System;
    using System.Text;

    #endregion

    /// <summary>
    /// Experian VRM process
    /// </summary>
    public static class TinyEncryptionAlgorithm
    {
        #region contants

        /// <summary>
        /// Maximum number plate length
        /// </summary>
        private const int VrmMaxLength = 7;
        
        /// <summary>
        /// Minimun number plate length
        /// </summary>
        private const int VrmMinLength = 2;

        /// <summary>
        /// Maximum encryption key length
        /// </summary>
        private const int MaxKeyLength = 16;

        /// <summary>
        /// Encryption block size
        /// </summary>
        private const int BlockSize = 8;

        #endregion

        #region public methods

        /// <summary>
        /// Encrypts the string.
        /// </summary>
        /// <param name="numberPlate">The number plate string</param>
        /// <param name="encryptionKey">The encryption key</param>
        /// <returns>The encrypted number plate</returns>
        public static string EncryptString(string numberPlate, string encryptionKey)
        {
            if (numberPlate.Length < VrmMinLength || numberPlate.Length > VrmMaxLength)
            {   
                throw new ArgumentOutOfRangeException("Number plate must be between 2 and 7 characters in length.");
            }

            uint[] formattedKey = FormatKey(encryptionKey);

            while (numberPlate.Length % BlockSize != 0)
            {
                numberPlate += '\0';
            }

            byte[] dataBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(numberPlate);

            StringBuilder encryptedString = new StringBuilder();
            uint[] numberPlateSegment = new uint[2];

            for (int index = 0; index < dataBytes.Length; index += BlockSize)
            {
                numberPlateSegment[0] = (uint)dataBytes[index] | (uint)dataBytes[index + 1] << 8 | (uint)dataBytes[index + 2] << 16 | (uint)dataBytes[index + 3] << 24;
                numberPlateSegment[1] = (uint)dataBytes[index + 4] | (uint)dataBytes[index + 5] << 8 | (uint)dataBytes[index + 6] << 16 | (uint)dataBytes[index + 7] << 24;
                Encode(numberPlateSegment, formattedKey);
                encryptedString.AppendFormat("{0:X8}{1:X8}", numberPlateSegment[0], numberPlateSegment[1]);
            }

            return encryptedString.ToString();
        }

        #endregion

        #region private methods

        /// <summary>
        /// Formats the key.
        /// </summary>
        /// <param name="key">The encryption key.</param>
        /// <returns>Formatted key</returns>
        private static uint[] FormatKey(string key)
        {
            if (key.Length <= 0 || key.Length > MaxKeyLength)
            {
                throw new ArgumentOutOfRangeException("Key must be between 0 and 16 characters in length");
            }

            key = key.PadRight(MaxKeyLength, ' ').Substring(0, MaxKeyLength);
            uint[] formatEncryptionKey = new uint[4];

            int keyBlocks = 0;

            for (int keyBlockCount = 0; keyBlockCount < key.Length; keyBlockCount += 4)
            {
                formatEncryptionKey[keyBlocks++] = ConvertStringToUInt(key.Substring(keyBlockCount, 4));
            }

            return formatEncryptionKey;
        }

        /// <summary>
        /// Codes the specified number plate segment.
        /// </summary>
        /// <param name="numberPlateSegments">The temperary data</param>
        /// <param name="keyValue">The formatted key</param>
        private static void Encode(uint[] numberPlateSegments, uint[] keyValue)
        {
            uint firstSegment = numberPlateSegments[0];
            uint secondSegment = numberPlateSegments[1];
            uint sum = 0;
            uint delta = 0x9e3779b9;
            uint counter = 32;

            while (counter-- > 0)
            {
                firstSegment += (secondSegment << 4 ^ secondSegment >> 5) + secondSegment ^ sum + keyValue[sum & 3];
                sum += delta;
                secondSegment += (firstSegment << 4 ^ firstSegment >> 5) + firstSegment ^ sum + keyValue[sum >> 11 & 3];
            }

            numberPlateSegments[0] = firstSegment;
            numberPlateSegments[1] = secondSegment;
        }

        /// <summary>
        /// Converts the string to U int.
        /// </summary>
        /// <param name="formattedKeyString">The encryption key</param>
        /// <returns>Uint encryption key</returns>
        private static uint ConvertStringToUInt(string formattedKeyString)
        {
            uint formattedKeyUInt;

            formattedKeyUInt = (uint)formattedKeyString[0];
            formattedKeyUInt += (uint)formattedKeyString[1] << 8;
            formattedKeyUInt += (uint)formattedKeyString[2] << 16;
            formattedKeyUInt += (uint)formattedKeyString[3] << 24;

            return formattedKeyUInt;
        }

        #endregion
    }
}