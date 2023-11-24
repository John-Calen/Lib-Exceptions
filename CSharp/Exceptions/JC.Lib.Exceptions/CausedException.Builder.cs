namespace JC.Lib.Exceptions
{
    public partial class CausedException
    {
        public class Builder: ABuilder<Builder, CausedException>
        {
            public override CausedException Build()
            {
                return new(this);
            }
        }
    }
}
