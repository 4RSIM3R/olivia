namespace Olivia.DTOs;

public record ResponseBase<TData>(string Message, TData Data);
