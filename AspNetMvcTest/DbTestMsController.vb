Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace AspNetMvcTest
    Public Class DbTestMsController
        Inherits System.Web.Mvc.Controller

        Private db As New SqlServerM

        ' GET: DbTestMs
        Function Index() As ActionResult
            Return View(db.DbtestM.ToList())
        End Function

        ' GET: DbTestMs/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim dbTestM As DbTestM = db.DbtestM.Find(id)
            If IsNothing(dbTestM) Then
                Return HttpNotFound()
            End If
            Return View(dbTestM)
        End Function

        ' GET: DbTestMs/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: DbTestMs/Create
        '過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        '詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Name")> ByVal dbTestM As DbTestM) As ActionResult
            If ModelState.IsValid Then
                db.DbtestM.Add(dbTestM)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(dbTestM)
        End Function

        ' GET: DbTestMs/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim dbTestM As DbTestM = db.DbtestM.Find(id)
            If IsNothing(dbTestM) Then
                Return HttpNotFound()
            End If
            Return View(dbTestM)
        End Function

        ' POST: DbTestMs/Edit/5
        '過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        '詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Name")> ByVal dbTestM As DbTestM) As ActionResult
            If ModelState.IsValid Then
                db.Entry(dbTestM).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(dbTestM)
        End Function

        ' GET: DbTestMs/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim dbTestM As DbTestM = db.DbtestM.Find(id)
            If IsNothing(dbTestM) Then
                Return HttpNotFound()
            End If
            Return View(dbTestM)
        End Function

        ' POST: DbTestMs/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim dbTestM As DbTestM = db.DbtestM.Find(id)
            db.DbtestM.Remove(dbTestM)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
