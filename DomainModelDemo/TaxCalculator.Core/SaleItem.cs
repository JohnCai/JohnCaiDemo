using Mavis.Core;

namespace TaxCalculator.Core
{
    public class SaleItem: Entity, ISaleItem
    {
        public SaleItem(Product product): this(product, product.Units[0])
        {
        }

        public SaleItem(Product product, Unit unit)
        {
            Product = product;
            Unit = unit;

            AddRule(new SimpleRule("Price", "The Price can not be negative.", () => Price < 0m));
            AddRule(new SimpleRule("BasicDutyType", "The BasicDutyType should not be null!", () => BasicDutyType == null));
        }

        public Unit Unit { get; set; }

        public Product Product { get; set; }

        private ITaxPriceService _taxPriceService;
        public ITaxPriceService TaxPriceService
        {
            get
            {
                if (_taxPriceService == null)
                    _taxPriceService = new TaxPriceService();
                return _taxPriceService;
            }
            set { _taxPriceService = value; }
        }


        public BasicDutyType BasicDutyType { get; set; }
        public bool IsImported { get; set; }
        public decimal Price { get; set; }

        public string GetPrintingDesc()
        {
            if (IsImported)
                return string.Format("Imported {0}", Product.Name);
            return Product.Name;
        }


        public decimal GetAfterTaxPrice()
        {
            return TaxPriceService.CalculateAfterTaxPrice(this);
        }

        public decimal GetTax()
        {
            return TaxPriceService.CalculateTax(this);
        }
    }
}