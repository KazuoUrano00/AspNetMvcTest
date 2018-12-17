Imports System.Web.Mvc

Namespace Controllers
    Public Class HelloController
        Inherits Controller

        ' GET: Hello
        Function Index() As ActionResult
            ViewData("Message") = "ASP.NET MVC へようこそ"
            Return View()
        End Function
    End Class
End Namespace