using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace VMS.ModelBinding
{
  public class QueryArgumentsModelBinder : IModelBinder
  {

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
      var query = bindingContext.ActionContext.HttpContext.Request.Query;
      var model = new QueryArguments(query);
      bindingContext.Result = ModelBindingResult.Success(model);
      return Task.CompletedTask;
    }
  }
}