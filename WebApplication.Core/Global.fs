namespace WebApplication.Core

open System
open System.Collections.Generic
open System.Linq
open System.Web
open System.Web.Mvc
open System.Web.Routing

// F# record type that can be used for creating route information
type Route = { 
  controller : string
  action : string
  id : UrlParameter }

// Represents the application and registers routes
type Global() =
  inherit System.Web.HttpApplication() 

  static member RegisterRoutes(routes:RouteCollection) =
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
    routes.MapRoute(
        "Default", // Route name
        "{controller}/{action}/{id}", // URL with parameters
        { controller = "Home"; action = "Index"; id = UrlParameter.Optional } // Parameter defaults
      )

  member x.Start() =
    AreaRegistration.RegisterAllAreas()
    Global.RegisterRoutes(RouteTable.Routes)