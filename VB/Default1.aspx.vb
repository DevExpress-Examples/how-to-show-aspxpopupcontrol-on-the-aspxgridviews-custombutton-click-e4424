﻿Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxPopupControl

Partial Public Class Default1
    Inherits System.Web.UI.Page

    Private image() As Byte
    Private note As Object

    Protected Sub popup_WindowCallback(ByVal source As Object, ByVal e As PopupWindowCallbackArgs)
        GetData(e.Parameter)
        edBinaryImage.Value = image
        litText.Text = note.ToString()
    End Sub

    Private Sub GetData(ByVal id As String)
        Dim ds As New AccessDataSource()
        ds.DataFile = ads.DataFile
        ds.SelectCommand = String.Format("Select Photo, Notes FROM [Employees] WHERE EmployeeID = {0}", id)
        Dim view As DataView = DirectCast(ds.Select(DataSourceSelectArguments.Empty), DataView)
        If view.Count > 0 Then
            image = TryCast(view(0)(0), Byte())
            note = view(0)(1)
        End If
    End Sub
End Class