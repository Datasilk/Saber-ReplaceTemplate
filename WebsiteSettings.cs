using Saber.Core;
using Saber.Vendor;

namespace Saber.Vendors.ReplaceTemplate
{
    public class WebsiteSettings : IVendorWebsiteSettings
    {
        public string Name { get; set; } = "Replace Template";
        public string Render(IRequest request)
        {
            var settingsView = new View("/Vendors/ReplaceTemplate/replacetemplate.html");
            request.AddScript("/editor/js/vendors/replacetemplate/replacetemplate.js");
            return settingsView.Render();
        }
    }
}
