namespace Reflection.OverProtective
{
    public class SomeClass : SomeBase
    {
        private string _connectionString;
        private string Str { get; set; }
        internal int Int { get; set; }

        public SomeClass()
        {
            Str = "initial value";
            Int = 0;
        }
    }
}
