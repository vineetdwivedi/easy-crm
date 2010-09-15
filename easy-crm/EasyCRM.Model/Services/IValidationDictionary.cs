using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCRM.Model.Services
{
    public interface IValidationDictionary
    {
        void AddError(string key, string errorMessage);
        bool IsValid { get; }

    }
}
