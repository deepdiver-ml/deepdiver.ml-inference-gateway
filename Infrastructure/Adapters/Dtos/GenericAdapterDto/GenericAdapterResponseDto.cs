namespace deepdiver.Infrastructure.Adapters.Dtos.GenericAdapterDto {
    public class GenericAdapterResponseDto<T> {
        public String? Reason { get; set; }
        public Boolean Success { get; set; } = true;
        public T? Data { get; set; }
    }
}