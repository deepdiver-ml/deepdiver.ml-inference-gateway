namespace deepdiver.Application.Services.Dtos.GenericServiceResponseDto {
    public class GenericServiceResponseDto<T> {
        public String? Reason { get; set; }
        public Boolean Success { get; set; } = true;
        public T? Data { get; set; }
    }
}