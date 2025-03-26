namespace ProductApi.dto
{
    public class ResponseDto<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static ResponseDto<T> SuccessResponse(T data, string message = "") =>
            new ResponseDto<T> { Success = true, Data = data, Message = message };

        public static ResponseDto<T> FailResponse(string message) =>
            new ResponseDto<T> { Success = false, Message = message };
    }
}
