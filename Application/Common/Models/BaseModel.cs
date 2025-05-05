using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Common.Models;

namespace Common.Model
{
    public abstract class BaseModel
    {
        [JsonIgnore]
        protected ModelState modelState;

        public virtual void Validate()
        {
            modelState = new ModelState();
            ValidationContext context = new ValidationContext(this);
            modelState.IsValid = Validator.TryValidateObject(this, context, modelState.ValidationResults, true);
        }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ModelState ValidationState
        {
            get
            {
                Validate();

                return modelState;
            }
        }

    }
}
