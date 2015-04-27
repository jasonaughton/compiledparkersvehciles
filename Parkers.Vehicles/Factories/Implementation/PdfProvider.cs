namespace Parkers.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Web;

    /// <summary>
    /// Tracks which derivatives have PDF reports available, and provides URLs for those reports
    /// </summary>
    internal static class PdfProvider
    {
        /// <summary>
        /// Pdf file suffix
        /// </summary>
        private const string PdfSuffix = ".pdf";

        /// <summary>
        /// Key to pdf url config entry
        /// </summary>
        private const string PdfUrlConfigKey = "Parkers.Vehicles.PdfUrl";

        /// <summary>
        /// Static list of Ids for derivs that have info packs
        /// </summary>
        private static readonly List<int> derivsIdsWithInfoPacks;

        /// <summary>
        /// Initializes the <see cref="PdfProvider"/> class.
        /// </summary>
        static PdfProvider()
        {
            derivsIdsWithInfoPacks = new List<int>();

            BuildDerivativePdfList();
        }

        /// <summary>
        /// Does the given derivative have a PDF available?
        /// </summary>
        /// <param name="deriv">The derivative</param>
        /// <returns></returns>
        public static bool HasPdfReport(IDerivative deriv)
        {
            bool result = false;

            if (deriv is ICarDerivative)
            {
                result = derivsIdsWithInfoPacks.Contains(deriv.Id);
            }

            return result;
        }

        /// <summary>
        /// The URL of the PDF for a given derivative, or null if none exists
        /// </summary>
        /// <param name="deriv">The derivative </param>
        /// <returns></returns>
        public static string DownloadUrl(IDerivative deriv)
        {
            if (!(deriv is ICarDerivative))
            {
                return null;
            }

            string path = ConfigurationManager.AppSettings[PdfUrlConfigKey];

            if (path != null)
            {
                return Path.Combine(path, String.Concat(deriv.Id.ToString(), PdfSuffix));
            }

            return null;
        }

        /// <summary>
        /// Builds the derivative PDF list.
        /// </summary>
        private static void BuildDerivativePdfList()
        {
            string pdfFolder = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[PdfUrlConfigKey]);

            if (Directory.Exists(pdfFolder))
            {
                string[] files = Directory.GetFiles(pdfFolder);

                foreach (string file in files)
                {
                    int fileNameStartPoint = file.LastIndexOf('\\') + 1;

                    if (fileNameStartPoint > -1)
                    {
                        string fileName = file.Substring(fileNameStartPoint, file.Length - fileNameStartPoint);
                        int derivId = 0;

                        if (Int32.TryParse(fileName.Replace(PdfSuffix, String.Empty), out derivId))
                        {
                            derivsIdsWithInfoPacks.Add(derivId);
                        }
                    }
                }
            }
        }
    }
}
