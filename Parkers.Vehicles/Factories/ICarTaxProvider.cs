// <copyright file="ICarTaxProvider.cs" company="Bauer Consumer Media Limited">
//   Copyright 2011 Bauer Consumer Media Limited
// </copyright>

namespace Parkers.Vehicles
{
    #region Usings

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Car Tax provider interface
    /// </summary>
    public interface ICarTaxProvider
    {
        /// <summary>
        /// Gets the band G date.
        /// </summary>
        DateTime BandGDate
        {
            get;
        }

        /// <summary>
        /// Gets the changeover date.
        /// </summary>
        DateTime ChangeoverDate
        {
            get;
        }

        /// <summary>
        /// Gets the company car tax.
        /// </summary>
        /// <param name="derivativeId">The derivative id.</param>
        /// <param name="taxYear">The tax year.</param>
        /// <param name="taxRate">The tax rate.</param>
        /// <param name="overrideValueP11D">The override value P11 D.</param>
        /// <param name="plateId">The plate id.</param>
        /// <returns>
        /// Company car tax results
        /// </returns>
        ICompanyCarTaxResults GetCompanyCarTax(int derivativeId, int taxYear, int taxRate, int overrideValueP11D, int plateId);
        
        /// <summary>
        /// Gets the VED details by derivative id.
        /// </summary>
        /// <param name="derivativeId">The derivative id.</param>
        /// <returns>List of VED details</returns>
        List<IVEDDetailsSet> GetVEDDetailsByDerivId(int derivativeId);

        /// <summary>
        /// Gets the manufacturer ids with car tax data.
        /// </summary>
        /// <returns>A list of manufacturer ids</returns>
        List<int> GetManufacturerIdsWithCarTaxData();

        /// <summary>
        /// Gets the model ids with car tax data.
        /// </summary>
        /// <param name="manufacturerId">The manufacturer id.</param>
        /// <returns>A list of model ids</returns>
        List<int> GetModelIdsWithCarTaxData(int manufacturerId);
        
        /// <summary>
        /// Gets the derivative ids with car tax data.
        /// </summary>
        /// <param name="modelId">The model id.</param>
        /// <returns>A list of derivative ids</returns>
        List<int> GetDerivativeIdsWithCarTaxData(int modelId);

        /// <summary>
        /// Gets the tax years.
        /// </summary>
        /// <returns>Returns a list of tax years</returns>
        IEnumerable<ITaxYear> GetTaxYears();
        
        /// <summary>
        /// Gets the tax year text.
        /// </summary>
        /// <param name="year">The calendar year for display.</param>
        /// <returns>Tax year in form y1/y2</returns>
        string GetTaxYearText(int year);
    }
}
