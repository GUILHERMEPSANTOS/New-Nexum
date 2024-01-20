
using NewNexum.Core.Communication;
using NewNexum.Core.DomainObjects;

namespace NewNexum.Core.ValueObjects
{
    public class Url : ValueObject
    {
        private Url(string value)
        {
            Value = value;
        }

        private string Value {  get; }

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


        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value; 
        }
    }
}
