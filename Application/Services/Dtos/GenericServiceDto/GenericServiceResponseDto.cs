namespace deepdiver.Application.Services.Dtos.GenericServiceResponseDto {
    public class GenericServiceResponseDto<T> {
        public Boolean Success { get; set; } = true;
        public T? Data { get; set; }
    }
}