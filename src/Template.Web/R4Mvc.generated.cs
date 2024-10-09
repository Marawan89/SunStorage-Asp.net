// <auto-generated />
// This file was generated by R4Mvc.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the r4mvc.json file (i.e. the settings file), save it and run the generator tool again.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo.Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
#pragma warning disable 1591, 3008, 3009, 0108
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using R4Mvc;

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
public static partial class MVC
{
    static readonly R4Mvc.AdminAreaClass s_Admin = new R4Mvc.AdminAreaClass();
    public static R4Mvc.AdminAreaClass Admin => s_Admin;
    static readonly R4Mvc.ExampleAreaClass s_Example = new R4Mvc.ExampleAreaClass();
    public static R4Mvc.ExampleAreaClass Example => s_Example;
    public static readonly Template.Web.Areas.AuthenticatedBaseController AuthenticatedBase = new Template.Web.Areas.R4MVC_AuthenticatedBaseController();
    public static readonly Template.Web.Features.Home.HomeController Home = new Template.Web.Features.Home.R4MVC_HomeController();
    public static readonly Template.Web.Features.Login.LoginController Login = new Template.Web.Features.Login.R4MVC_LoginController();
    public static readonly Template.Web.Areas.AdminFull.Users.UsersController Users = new Template.Web.Areas.AdminFull.Users.R4MVC_UsersController();
    public static readonly R4Mvc.SharedController Shared = new R4Mvc.SharedController();
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
public static partial class MVCPages
{
}

namespace R4Mvc
{
    [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy()
        {
        }

        public static Dummy Instance = new Dummy();
    }

    [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
    public partial class SharedController
    {
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames => s_ViewNames;
            public class _ViewNamesClass
            {
                public readonly string _Layout = "_Layout";
                public readonly string _LayoutHtml = "_LayoutHtml";
                public readonly string _PagingPartial = "_PagingPartial";
                public readonly string _PagingPartialFilter = "_PagingPartialFilter";
            }

            public readonly string _Layout = "~/Views/Shared/_Layout.cshtml";
            public readonly string _LayoutHtml = "~/Views/Shared/_LayoutHtml.cshtml";
            public readonly string _PagingPartial = "~/Views/Shared/_PagingPartial.cshtml";
            public readonly string _PagingPartialFilter = "~/Views/Shared/_PagingPartialFilter.cshtml";
        }

        static readonly ViewsClass s_Views = new ViewsClass();
        public ViewsClass Views => s_Views;
    }

    [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
    public partial class AdminAreaClass
    {
        public readonly string Name = "Admin";
        public readonly Template.Web.Areas.Admin.Users.UsersController Users = new Template.Web.Areas.Admin.Users.R4MVC_UsersController();
    }

    [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
    public partial class ExampleAreaClass
    {
        public readonly string Name = "Example";
        public readonly Template.Web.Areas.Example.Users.UsersController Users = new Template.Web.Areas.Example.Users.R4MVC_UsersController();
    }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
public static partial class Links
{
    public const string UrlPath = "~";
    public static string Url() => R4MvcHelpers.ProcessVirtualPath(UrlPath);
    public static string Url(string fileName) => R4MvcHelpers.ProcessVirtualPath(UrlPath + "/" + fileName);
    public static partial class css
    {
        public const string UrlPath = "~/css";
        public static string Url() => R4MvcHelpers.ProcessVirtualPath(UrlPath);
        public static string Url(string fileName) => R4MvcHelpers.ProcessVirtualPath(UrlPath + "/" + fileName);
        public static readonly string bundle_global_css = Url("bundle-global.css");
        public static readonly string bundle_global_min_css = Url("bundle-global.min.css");
        public static readonly string bundle_vue_multiselect_css = Url("bundle-vue-multiselect.css");
        public static readonly string bundle_vue_multiselect_min_css = Url("bundle-vue-multiselect.min.css");
        public static readonly string global_css = Url("global.css");
        public static readonly string login_css = Url("login.css");
        public static readonly string site_css = Url("site.css");
        public static readonly string site_layout_scss = Url("site.layout.scss");
        public static readonly string site_min_css = Url("site.min.css");
        public static readonly string site_variables_scss = Url("site.variables.scss");
    }

    public static partial class images
    {
        public const string UrlPath = "~/images";
        public static string Url() => R4MvcHelpers.ProcessVirtualPath(UrlPath);
        public static string Url(string fileName) => R4MvcHelpers.ProcessVirtualPath(UrlPath + "/" + fileName);
        public static readonly string sunStorage_png = Url("sunStorage.png");
        public static readonly string sunStorageLogo_png = Url("sunStorageLogo.png");
    }

    public static partial class js
    {
        public const string UrlPath = "~/js";
        public static string Url() => R4MvcHelpers.ProcessVirtualPath(UrlPath);
        public static string Url(string fileName) => R4MvcHelpers.ProcessVirtualPath(UrlPath + "/" + fileName);
        public static partial class devices
        {
            public const string UrlPath = "~/js/devices";
            public static string Url() => R4MvcHelpers.ProcessVirtualPath(UrlPath);
            public static string Url(string fileName) => R4MvcHelpers.ProcessVirtualPath(UrlPath + "/" + fileName);
            public static readonly string add_device_js = Url("add-device.js");
            public static readonly string add_device_js_map = Url("add-device.js.map");
            public static readonly string add_device_ts = Url("add-device.ts");
            public static readonly string assign_device_js = Url("assign-device.js");
            public static readonly string assign_device_js_map = Url("assign-device.js.map");
            public static readonly string assign_device_ts = Url("assign-device.ts");
            public static readonly string edit_device_js = Url("edit-device.js");
            public static readonly string edit_device_js_map = Url("edit-device.js.map");
            public static readonly string edit_device_ts = Url("edit-device.ts");
        }

        public static readonly string bundle_global_js = Url("bundle-global.js");
        public static readonly string bundle_global_min_js = Url("bundle-global.min.js");
        public static readonly string bundle_global_min_js_map = Url("bundle-global.min.js.map");
        public static readonly string bundle_signalr_js = Url("bundle-signalr.js");
        public static readonly string bundle_vue_multiselect_js = Url("bundle-vue-multiselect.js");
        public static readonly string bundle_vue_multiselect_min_js = Url("bundle-vue-multiselect.min.js");
        public static readonly string bundle_vue_multiselect_min_js_map = Url("bundle-vue-multiselect.min.js.map");
        public static readonly string bundle_vue_js = Url("bundle-vue.js");
        public static readonly string bundle_vue_min_js = Url("bundle-vue.min.js");
        public static readonly string bundle_vue_min_js_map = Url("bundle-vue.min.js.map");
        public static readonly string signalRConnectionManager_d_ts = Url("signalRConnectionManager.d.ts");
        public static readonly string signalRConnectionManager_js = Url("signalRConnectionManager.js");
        public static readonly string signalRConnectionManager_js_map = Url("signalRConnectionManager.js.map");
        public static readonly string signalRConnectionManager_ts = Url("signalRConnectionManager.ts");
        public static readonly string site_d_ts = Url("site.d.ts");
        public static readonly string site_js = Url("site.js");
        public static readonly string site_js_map = Url("site.js.map");
        public static readonly string site_ts = Url("site.ts");
    }

    public static readonly string favicon_ico = Url("favicon.ico");
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal static class R4MvcHelpers
{
    private static string ProcessVirtualPathDefault(string virtualPath) => virtualPath;
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult : ActionResult, IR4MvcActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(string area, string controller, string action, string protocol = null)
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }

    public string Controller { get; set; }

    public string Action { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_JsonResult : JsonResult, IR4MvcActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_JsonResult(string area, string controller, string action, string protocol = null): base(null)
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }

    public string Controller { get; set; }

    public string Action { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_ContentResult : ContentResult, IR4MvcActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_ContentResult(string area, string controller, string action, string protocol = null)
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }

    public string Controller { get; set; }

    public string Action { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_FileResult : FileResult, IR4MvcActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_FileResult(string area, string controller, string action, string protocol = null): base(null)
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }

    public string Controller { get; set; }

    public string Action { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_RedirectResult : RedirectResult, IR4MvcActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_RedirectResult(string area, string controller, string action, string protocol = null): base(" ")
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }

    public string Controller { get; set; }

    public string Action { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_RedirectToActionResult : RedirectToActionResult, IR4MvcActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_RedirectToActionResult(string area, string controller, string action, string protocol = null): base(" ", " ", " ")
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }

    public string Controller { get; set; }

    public string Action { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_RedirectToRouteResult : RedirectToRouteResult, IR4MvcActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_RedirectToRouteResult(string area, string controller, string action, string protocol = null): base(null)
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }

    public string Controller { get; set; }

    public string Action { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_ActionResult : ActionResult, IR4PageActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_ActionResult(string pageName, string pageHandler, string protocol = null)
    {
        this.InitMVCT4Result(pageName, pageHandler, protocol);
    }

    public string PageName { get; set; }

    public string PageHandler { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_JsonResult : JsonResult, IR4PageActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_JsonResult(string pageName, string pageHandler, string protocol = null): base(null)
    {
        this.InitMVCT4Result(pageName, pageHandler, protocol);
    }

    public string PageName { get; set; }

    public string PageHandler { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_ContentResult : ContentResult, IR4MvcActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_ContentResult(string area, string controller, string action, string protocol = null)
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }

    public string Controller { get; set; }

    public string Action { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_FileResult : FileResult, IR4PageActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_FileResult(string pageName, string pageHandler, string protocol = null): base(null)
    {
        this.InitMVCT4Result(pageName, pageHandler, protocol);
    }

    public string PageName { get; set; }

    public string PageHandler { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_RedirectResult : RedirectResult, IR4PageActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_RedirectResult(string pageName, string pageHandler, string protocol = null): base(" ")
    {
        this.InitMVCT4Result(pageName, pageHandler, protocol);
    }

    public string PageName { get; set; }

    public string PageHandler { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_RedirectToActionResult : RedirectToActionResult, IR4PageActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_RedirectToActionResult(string pageName, string pageHandler, string protocol = null): base(" ", " ", " ")
    {
        this.InitMVCT4Result(pageName, pageHandler, protocol);
    }

    public string PageName { get; set; }

    public string PageHandler { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}

[GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
internal partial class R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_RedirectToRouteResult : RedirectToRouteResult, IR4PageActionResult
{
    public R4Mvc_Microsoft_AspNetCore_Mvc_RazorPages_RedirectToRouteResult(string pageName, string pageHandler, string protocol = null): base(null)
    {
        this.InitMVCT4Result(pageName, pageHandler, protocol);
    }

    public string PageName { get; set; }

    public string PageHandler { get; set; }

    public string Protocol { get; set; }

    public RouteValueDictionary RouteValueDictionary { get; set; }
}
#pragma warning restore 1591, 3008, 3009, 0108
