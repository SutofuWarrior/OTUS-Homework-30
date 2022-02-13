
namespace PrototypeExample
{
    /// <summary>
    /// Информация о продажах за день
    /// </summary>
    public struct GoodsSale
    {
        public DateTime Date;
        public decimal Amount;
        public bool IsPromo;

        public GoodsSale(DateTime date, decimal amount, bool isPromo)
        {
            Date = date;
            Amount = amount;
            IsPromo = isPromo;
        }
    }
}