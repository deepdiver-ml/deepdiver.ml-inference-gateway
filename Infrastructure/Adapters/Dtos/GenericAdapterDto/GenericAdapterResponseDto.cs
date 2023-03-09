namespace deepdiver.Infrastructure.Adapters.Dtos.GenericAdapterDto {
    public class GenericAdapterResponseDto<T> {
        public Boolean Success { get; set; } = true;
        public T? Data { get; set; }
    }
}