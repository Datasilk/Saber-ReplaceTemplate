namespace Saber.Vendor.ReplaceTemplate
{
    [ViewPath("/Views/AppSettings/appsettings.html")]
    public class ViewRenderer : IVendorViewRenderer
    {
        public string Render(Request request, View view)
        {
            var settingsView = new View("/Vendor/ReplaceTemplate/replacetemplate.html");
            request.AddScript("/editor/js/vendor/replacetemplate/replacetemplate.js");
            return settingsView.Render();
        }
    }
}
