
using NewNexum.Core.Communication;
using NewNexum.Core.DomainObjects;

namespace NewNexum.Core.ValueObjects
{
    
    public class Url : ValueObject
    {
        public string Value { get; private set; }
        
        private Url(string value)
        {
            Value = value;
        }

        public static Result<Url> Create(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return Result.Failure<Url>(DomainErrors.UrlErrors.Empty);
            }
      
            if(!Uri.TryCreate(url, UriKind.Absolute, out _))
            {
                return Result.Failure<Url>(DomainErrors.UrlErrors.InvalidFormat);
            }

            return new Url(url);
        }
      
        public static implicit operator string(Url url) => url.Value;

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value; 
        }
    }
}
