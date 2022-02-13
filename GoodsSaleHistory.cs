
namespace PrototypeExample
{
    /// <summary>
    /// Товар с историей продаж
    /// </summary>
    public class GoodsSaleHistory : Goods
    {
        public GoodsSale[] Sales;

        public GoodsSaleHistory(string code, string name)
            : base(code, name)
        { }

        public GoodsSaleHistory(string code, string name, GoodsSale[] sales)
            : this(code, name)
        {
            Sales = sales;
        }

        public override GoodsSaleHistory Copy()
        {
            var copy = new GoodsSaleHistory(Code, Name);

            copy.Sales = new GoodsSale[Sales.Length];
            Sales.CopyTo(copy.Sales, 0);
            return copy;
        }
    }
}