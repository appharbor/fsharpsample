namespace WebApplication.Core.Controllers

open System
open System.Web.Mvc
open System.Reflection

[<HandleError>]
type HomeController() =
  inherit Controller()

  member x.Index() =
    // Demonstrates how to pass data to the view - 
    // We get the version of the FSharp.Core assembly as part of the message
    let version = typeof<int * int>.Assembly.GetName().Version
    let msg = sprintf "This web page is running using F# version %s." (version.ToString(4))
    x.ViewData.["Message"] <- msg      
    x.View()

  member x.About() =
    x.View()
