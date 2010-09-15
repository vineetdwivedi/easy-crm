using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCRM.Model.Services.Impl
{
    public class SimpleModelStateWrapper : IValidationDictionary
    {
        private Dictionary<String, String> _modelState;

        public SimpleModelStateWrapper(Dictionary<string, string> modelState)
        {
            _modelState = modelState;
        }

        #region IValidationDictionary Members

        public void AddError(string key, string errorMessage)
        {
            _modelState.Add(key, errorMessage);
        }

        public bool IsValid
        {
            get { return _modelState.Count == 0; }
        }

        #endregion
    }
}
