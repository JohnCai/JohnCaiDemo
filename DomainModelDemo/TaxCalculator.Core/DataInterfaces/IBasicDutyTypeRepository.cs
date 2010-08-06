using System.Collections.Generic;

namespace TaxCalculator.Core.DataInterfaces
{
    public interface IBasicDutyTypeRepository
    {
        IList<BasicDutyType> GetAllBasicTaxTypes();
    }
}