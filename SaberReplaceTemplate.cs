using System;
using System.Linq;
using System.IO;
using System.Threading;

namespace Saber.Vendor.ReplaceTemplate
{
    public class SaberReplaceTemplate : Controller, IVendorController
    {
        public override string Render(string body = "")
        {
            if (!CheckSecurity()) { return AccessDenied<Controllers.Login>(); }
            try
            {
                //first, delete the temp folder (keep README.md)
                File.Move(Server.MapPath("/Content/temp/README.md"), Server.MapPath("/Content/README.md"));
                var dir = new DirectoryInfo(Server.MapPath("/Content/temp"));
                dir.Delete(true);

                Thread.Sleep(1000);
                Directory.CreateDirectory(Server.MapPath("Content/temp"));
                Directory.CreateDirectory(Server.MapPath("Content/temp/app-css"));
                Directory.CreateDirectory(Server.MapPath("Content/temp/pages"));
                Directory.CreateDirectory(Server.MapPath("Content/temp/partials"));
                Directory.CreateDirectory(Server.MapPath("Content/temp/scripts"));
                Thread.Sleep(1000);


                File.Move(Server.MapPath("/Content/README.md"), Server.MapPath("/Content/temp/README.md"));

                //copy all required files into the temp folder
                var files = Common.Platform.Website.AllFiles();
                foreach(var file in files)
                {
                    var f = file.ToLower().Replace("/", "\\");
                    var filename = file.Replace("/", "\\").Split("\\")[^1];
                    if (f.IndexOf("\\content\\pages\\") >= 0)
                    {
                        //copy all files from /Content/pages/
                        File.Copy(file, Server.MapPath("/Content/temp/pages/" + filename), true);
                    }
                    else if (f.IndexOf("\\content\\partials\\") >= 0)
                    {
                        //copy all files from /Content/partials/
                        File.Copy(file, Server.MapPath("/Content/temp/partials/" + filename), true);
                    }
                    else if (f.IndexOf("\\css\\website.less") >= 0)
                    {
                        //copy all files from /CSS
                        File.Copy(file, Server.MapPath("/Content/temp/app-css/" + filename), true);
                    }
                    else if (f.IndexOf("\\wwwroot\\") >= 0)
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
