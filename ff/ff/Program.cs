// <copyright file="Program.cs" company="Bauer Consumer Media">
//     Copyright (c) 2015 Bauer Consumer Media. All rights reserved.
// </copyright>

namespace ff
{
    using System;
    using System.Linq;
    using System.Reflection;
    using CompiledVehicles.Templates;
    using Fasterflect;

    /// <summary>
    /// Class Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            
            ICompiledModel model = GetById<ICompiledModel>(1121);
            var s = model.Name;

            ICompiledMake make = GetMake(model);
            var r = make.Name;

            ICompiledMake makeById = GetById<ICompiledMake>(25545);
            var t = makeById.Name;

        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        private static T GetById<T>(int id) where T : class
        {
            Assembly ass = Assembly.Load("Parkers.Vehicles.Compiled");
            var types = ass.TypesImplementing<T>();
            var match = types.SingleOrDefault(x =>
            {
                return HasId(x, id);
            });

            return match == null ? null : (T)match.CreateInstance();
        }

        /// <summary>
        /// Gets the make.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ICompiledMake.</returns>
        private static ICompiledMake GetMake(ICompiledModel model)
        {
            ICompiledMake result = null;

            MakeAttribute attrib = model.GetType().Attributes<MakeAttribute>().FirstOrDefault();

            if (attrib != null)
            {
                result = (ICompiledMake)attrib.Make.CreateInstance();
            }

            return result;
        }

        /// <summary>
        /// Determines whether the specified x has identifier.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if the specified x has identifier; otherwise, <c>false</c>.</returns>
        private static bool HasId(Type x, int id)
        {
            bool result = false;

            result = x.HasAttribute<IdAttribute>();

            if (result)
            {
                result = x.Attribute<IdAttribute>().Id == id;
            }
            else
            {
                var idProp = x.Properties().SingleOrDefault(p => p.Name == "Id");

                if (idProp != null)
                {
                    var idVal = Int32.MinValue;

                    result = int.TryParse(idProp.GetValue(x.CreateInstance()).ToString(), out idVal) && idVal == id;
                }
            }

            return result;
        }
    }
}
