namespace deepdiver.Application.Factories.Dtos {
    public class GenericFactoryResponseDto<T> {
        public String? Reason { get; set; }
        public Boolean Success { get; set; } = true;
        public T? Data { get; set; }
    }
}