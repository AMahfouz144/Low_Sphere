using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Common.Base
{
    public abstract class BaseModel
    {
        [JsonIgnore]
        protected ModelState modelState;

        protected virtual void Validate()
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
