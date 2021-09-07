namespace PosTerminal.Console.Attributes
{
    public interface IValidationAttribute
    {
        public string ErrorMessage { get; }
        
        public bool IsValid(object? value);
    }
}