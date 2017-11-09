namespace Redmanmale.WcfOverRabbitMq.Common
{
    public class Response : BaseMessage
    {
        public int Result { get; set; }

        public override string ToString() => $"{Message} with result {Result}";
    }
}
