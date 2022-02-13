
namespace PrototypeExample
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Goods : IMyCloneable<Goods>, ICloneable
    {
        public string Code;
        public string Name;

        public Goods(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public object Clone() 
            => Copy();

        public virtual Goods Copy() 
            => new Goods(Code, Name);
    }
}