using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace SistemaCotizaciones.Model
{
    public class XDecimalBinderProvider : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext
                .ValueProvider
                .GetValue(bindingContext.ModelName);

            var cultureInfo = new CultureInfo("es-CL");
            cultureInfo.NumberFormat.NumberDecimalSeparator = ",";
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = ",";

            decimal.TryParse(
                valueProviderResult.FirstValue,
                NumberStyles.AllowDecimalPoint,
                cultureInfo,
                out var model);

            bindingContext
                .ModelState
                .SetModelValue(bindingContext.ModelName, valueProviderResult);

            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
