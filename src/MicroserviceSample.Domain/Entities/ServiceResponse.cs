namespace MicroserviceSample.Domain.Entities
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; } = null;
    }
}