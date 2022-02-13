
namespace PrototypeExample
{
    /// <summary>
    /// Дозаказ к родительскому заказу
    /// </summary>
    public class SecondOrder : Order
    {
        public Order FirstOrder;

        public SecondOrder(int id, DateTime dateDelivery, GoodsSaleHistory[] listGoods, Order firstOrder)
            : base(id, dateDelivery, listGoods)
        {
            FirstOrder = firstOrder;
        }

        public override SecondOrder Copy()
        {
            // Копируем родительский заказ
            var firstCopy = FirstOrder.Copy();
            // Копируем свои товары
            var copyGoods = ListGoods.Select(g => g.Copy()).ToArray();
            // Создаём копию
            return new SecondOrder(Id, DateDelivery, copyGoods, firstCopy);
        }
    }
}