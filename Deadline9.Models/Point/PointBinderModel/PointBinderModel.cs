using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Deadline9.Models
{
    public class PointBinderModel : IModelBinder
    {
        private readonly IModelBinder fallbackBinder;

        public PointBinderModel(IModelBinder fallbackBinder)
        {
            this.fallbackBinder = fallbackBinder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var SemesterValues = bindingContext.ValueProvider.GetValue("Semester");

            if (SemesterValues == ValueProviderResult.None)
                return fallbackBinder.BindModelAsync(bindingContext);

            string Semester = SemesterValues.FirstValue;
            int.TryParse(Semester, out int SemesterParsed);

            bindingContext.Result = ModelBindingResult.Success(Semester);


            return Task.CompletedTask;
        }
    }
}
