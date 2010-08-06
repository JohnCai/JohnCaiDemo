namespace TaxCalculator.Core.DataInterfaces
{
    public interface ITaxRounder
    {
        decimal Round(decimal tax);
    }
}