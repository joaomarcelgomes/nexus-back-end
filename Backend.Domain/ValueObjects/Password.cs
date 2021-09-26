using System.Text.RegularExpressions;
using Backend.Domain.Shared.ValueObjects;
using FluentValidator.Validation;

namespace Backend.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        public Password(string address)
        {
            Address = address;

            AddNotifications(
                new ValidationContract()
                    .Requires()
                    .IsTrue(Validate(address), "Address", "Password invalid")
            );
        }

        public string Address { get; private set; }

        private bool Validate(string address)
        {
            var rgx = new Regex(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8,40})");

            return rgx.IsMatch(address);
        }
    }
}