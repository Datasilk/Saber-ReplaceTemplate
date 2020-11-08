using Saber.Core;

namespace Saber.Vendor.ReplaceTemplate
{
    [ViewPath("/Views/AppSettings/appsettings.html")]
    public class ViewRenderer : IVendorViewRenderer
    {
        public string Render(IRequest request, View view)
        {
            var settingsView = new View("/Vendors/ReplaceTemplate/replacetemplate.html");
            request.AddScript("/editor/js/vendors/replacetemplate/replacetemplate.js");
            return settingsView.Render();
        }
    }
}
