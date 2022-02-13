
namespace PrototypeExample
{
    public class Program
    {
        public static void Main()
        {
            var order = new Order(1, new DateTime(2022, 02, 15), new GoodsSaleHistory[]
            {
                new GoodsSaleHistory("000123", "Товар1", new GoodsSale[]
                {
                    new GoodsSale(new DateTime(2022, 02, 01), 4, true),
                    new GoodsSale(new DateTime(2022, 02, 02), 5, true),
                    new GoodsSale(new DateTime(2022, 02, 03), 0, false),
                    new GoodsSale(new DateTime(2022, 02, 04), 1, false)
                })
            });

            var orderCopy = Copy(order);
            Console.WriteLine(CheckCopyOrders(order, orderCopy));

            var orderClone = Clone(order);
            Console.WriteLine(CheckCopyOrders(order, (Order)orderClone));

            Console.ReadLine();
        }

        private static T Copy<T>(IMyCloneable<T> obj) 
            => obj.Copy();

        private static object Clone(ICloneable obj)
            => obj.Clone();

        /// <summary>
        /// Проверка глубокого копирования заказа
        /// </summary>
        private static bool CheckCopyOrders(Order o1, Order o2)
        {
            // Должны быть физически разные объекты
            if (object.ReferenceEquals(o1, o2))
                return false;

            // Совпадающие значения полей значимых типов
            if (o1.Id != o2.Id || o1.DateDelivery != o2.DateDelivery)
                return false;

            // Должны быть физически разные объекты-массивы
            if (object.ReferenceEquals(o1.ListGoods, o2.ListGoods))
                return false;

            // Совпадает количество товаров
            if (o1.ListGoods?.Length != o2.ListGoods?.Length)
                return false;

            // Проверяем на глубокую копию все товары
            for (int i = 0; i < o1.ListGoods.Length; i++)
                if (!CheckCopyGoodsSaleHistory(o1.ListGoods[i], o2.ListGoods[i]))
                    return false;

            return true;
        }

        /// <summary>
        /// Проверка глубокого копирования товара с историей
        /// </summary>
        private static bool CheckCopyGoodsSaleHistory(GoodsSaleHistory g1, GoodsSaleHistory g2)
        {
            // Должны быть физически разные объекты
            if (object.ReferenceEquals(g1, g2))
                return false;

            // Совпадающие значения полей значимых типов
            if (g1.Code != g2.Code || g1.Name != g2.Name)
                return false;

            // Должны быть физически разные объекты-массивы
            if (object.ReferenceEquals(g1.Sales, g2.Sales))
                return false;

            // Совпадает количество дней продаж
            if (g1.Sales?.Length != g2.Sales?.Length)
                return false;

            // Проверяем равенство дней продаж
            for (int i = 0; i < g1.Sales.Length; i++)
                if (g1.Sales[i].Date != g2.Sales[i].Date
                    || g1.Sales[i].Amount != g2.Sales[i].Amount
                    || g1.Sales[i].IsPromo != g2.Sales[i].IsPromo)
                    return false;

            return true;
        }
    }
}