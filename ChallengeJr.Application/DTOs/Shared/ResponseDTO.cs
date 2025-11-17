namespace ChallengeJr.Application.DTOs.Shared;

public class ResponseDTO<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public List<string> Errors { get; set; } = new();

    public ResponseDTO()
    {
        Success = true;
    }

    public ResponseDTO(T data)
    {
        Success = true;
        Data = data;
    }

    public ResponseDTO(string error)
    {
        Success = false;
        Message = error;
        Errors.Add(error);
    }

    public ResponseDTO(List<string> errors)
    {
        Success = false;
        Errors = errors;
        Message = string.Join(", ", errors);
    }

    // Métodos estáticos para facilitar o uso
    public static ResponseDTO<T> CreateSuccess(T data) => new(data);
    public static ResponseDTO<T> CreateFailure(string error) => new(error);
    public static ResponseDTO<T> CreateFailure(List<string> errors) => new(errors);
}
