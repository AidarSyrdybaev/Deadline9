using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadline9.Models
{
    public class PointModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            ILoggerFactory loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
            IModelBinder binder = new PointBinderModel(new SimpleTypeModelBinder(typeof(int), loggerFactory));
            return context.Metadata.ModelType == typeof(int) ? binder : null;
        }
    }
}
