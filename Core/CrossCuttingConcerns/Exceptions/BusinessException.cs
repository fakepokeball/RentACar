namespace Core.CrossCuttingConcerns.Exeptions;

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message)
    {
    }
}
