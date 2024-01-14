namespace NewNexum.Core.Communication
{
    public class Error : IEquatable<Error>
    {
        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
        public static readonly Error NullValue = new("Error.NullValue", "Null value was provided", ErrorType.Failure);

        public string Code { get; }
        public string Description { get; }
        public ErrorType Type { get; }


        protected Error(string code, string description, ErrorType errorType)
        {
            Code = code;
            Description = description;
            Type = errorType;
        }

        public static Error NotFound(string code, string description) 
                => new(code, description, ErrorType.NotFound);

        public static Error Validation(string code, string description)
           => new(code, description, ErrorType.Validation);

        public static Error Failure(string code, string description)
           => new(code, description, ErrorType.Failure);

        public static Error Conflict(string code, string description)
           => new(code, description, ErrorType.Conflict);

        public bool Equals(Error? other)
        {
            if(other is null) return false;

            return Code == other.Code && Description == other.Description && Type == other.Type;
        }
    }
}
