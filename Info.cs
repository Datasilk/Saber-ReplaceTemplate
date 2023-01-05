using Saber.Vendor;

namespace Saber.Vendors.ReplaceTemplate
{
    public class Info : IVendorInfo
    {
        public string Key { get; set; } = "ReplaceTemplate";
        public string Name { get; set; } = "Replace Template";
        public string Description { get; set; } = "Allows administrators to replace the default template website with the current website. This can be useful for deploying custom Saber releases with a special template website installed.";
        public string Icon { get; set; }
        public Vendor.Version Version { get; set; } = "1.0.0.0";
    }
}
