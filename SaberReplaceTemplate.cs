using System;
using System.Linq;
using System.IO;
using System.Threading;
using Saber.Core;
using Saber.Vendor;

namespace Saber.Vendors.ReplaceTemplate
{
    public class SaberReplaceTemplate : Controller, IVendorController
    {
        public override string Render(string body = "")
        {
            if (!CheckSecurity()) { return AccessDenied(); }
            try
            {
                //first, delete the temp folder (keep README.md)
                File.Move(App.MapPath("/Content/temp/README.md"), App.MapPath("/Content/README.md"));
                var dir = new DirectoryInfo(App.MapPath("/Content/temp"));
                dir.Delete(true);

                Thread.Sleep(1000);
                Directory.CreateDirectory(App.MapPath("Content/temp"));
                Directory.CreateDirectory(App.MapPath("Content/temp/app-css"));
                Directory.CreateDirectory(App.MapPath("Content/temp/pages"));
                Directory.CreateDirectory(App.MapPath("Content/temp/partials"));
                Directory.CreateDirectory(App.MapPath("Content/temp/scripts"));
                Thread.Sleep(1000);


                File.Move(App.MapPath("/Content/README.md"), App.MapPath("/Content/temp/README.md"));

                //copy all required files into the temp folder
                var files = Website.AllFiles();
                foreach(var file in files)
                {
                    var f = file.ToLower().Replace("/", "\\");
                    var filename = file.Replace("/", "\\").Split("\\")[^1];
                    if (f.Contains("\\content\\pages\\"))
                    {
                        //copy all files from /Content/pages/
                        File.Copy(file, App.MapPath("/Content/temp/pages/" + filename), true);
                    }
                    else if (f.Contains("\\content\\partials\\"))
                    {
                        //copy all files from /Content/partials/
                        File.Copy(file, App.MapPath("/Content/temp/partials/" + filename), true);
                    }
                    else if (f.Contains("\\css\\website.less"))
                    {
                        //copy all files from /CSS
                        File.Copy(file, App.MapPath("/Content/temp/app-css/" + filename), true);
                    }
                    else if (f.Contains("\\wwwroot\\"))
                    {
                        //copy all files from wwwroot
                        var newdir = string.Join('\\', file.Replace("/", "\\")
                            .Replace("\\wwwroot\\", "\\Content\\temp\\")
                            .Split("\\").SkipLast(1).ToArray());
                        if (!Directory.Exists(newdir))
                        {
                            Directory.CreateDirectory(newdir);
                        }
                        File.Copy(file, newdir + "\\" + filename);
                    }
                }
            }
            catch (Exception ex)
            {
                return Error(ex.Message + "\n" + ex.StackTrace);
            }
            return "{}";
        }

        
    }
}
