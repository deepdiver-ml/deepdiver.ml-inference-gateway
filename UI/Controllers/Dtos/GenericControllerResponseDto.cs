namespace deepdiver.UI.Controllers.Dtos {
    public class GenericControllerResponseDto<T> {
        public Boolean Success { get; set; } = true;
        public T? Data { get; set; }
    }
}