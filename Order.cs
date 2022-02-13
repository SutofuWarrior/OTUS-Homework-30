
namespace PrototypeExample
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order : IMyCloneable<Order>, ICloneable
    {
        public int Id;
        public DateTime DateDelivery;
        public GoodsSaleHistory[] ListGoods;

        public Order(int id, DateTime dateDelivery, GoodsSaleHistory[] listGoods)
        {
            Id = id;
            DateDelivery = dateDelivery;
            ListGoods = listGoods;
        }

        public object Clone() 
            => Copy();

        public virtual Order Copy()
        {
            var copyGoods = ListGoods.Select(g => g.Copy()).ToArray();
            return new Order(Id, DateDelivery, copyGoods);
        }
    }
}