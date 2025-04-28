using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Models
{
    public class ModelState
    {
        [IgnoreDataMember]
        public bool IsValid { set; get; }
        
        [IgnoreDataMember]
        public List<ValidationResult> ValidationResults { set; get; }

        public string ValidationResultsToString()
        {
            string res = null;

            ValidationResults.ForEach(obj => res += obj.ErrorMessage + Environment.NewLine);

            return res;
        }

        public ModelState()
        {
            ValidationResults = new List<ValidationResult>();
        }
    }

}
