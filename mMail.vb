Imports System.IO
Imports System.Text
Imports System.Net.Sockets
Imports OpenPop.Pop3
Imports System.Net.Mail
Imports ImapX

Module Mmail

    Public curState As String
    Public stream As NetworkStream
    Public sr As StreamReader
    Public errorOcc As Boolean = False

    Public Class email
        Public subject As String
        Public text As String
        Public by As String
        Public toG As String
        Public dateSent As String
        Public attachments As New ArrayList
    End Class
    Public Function checkIMAPconnection(ByVal imap3server As String, ByVal imap3port As Integer, ByVal useSSL As Boolean, ByVal username As String, ByVal password As String) As Integer

        Dim imap As New ImapClient(imap3server, imap3port, useSSL)
        Try

            If imap.Connection Then
                If imap.LogIn(username, password) Then
                    Return 2
                Else : Return 1
                End If
            Else
                Return 1
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function checkPOP3Connection(ByVal pop3server As String, ByVal pop3port As Integer, ByVal useSSL As Boolean, ByVal username As String, ByVal password As String) As Integer
        If checkIfConnectedWithInternetM("Das Hinzufügen eines neuen Kontos") = True Then
            Dim pop As New Pop3Client
            Try
                pop.Connect(pop3server, pop3port, useSSL)
            Catch ex As OpenPOP.Pop3.Exceptions.PopServerNotFoundException
                Return 0
            End Try
            Try
                pop.Authenticate(username, password)
                pop.Disconnect()
                Return 2
            Catch ex As Exception
                Return 1
            End Try
        Else
            Return 3
        End If
    End Function

    Public Function sendWelcomeMailCHECKSMTP(ByVal showname As String, ByVal smtpserver As String, ByVal smtpport As Integer, ByVal useSSL As Boolean, ByVal username As String, ByVal password As String, ByVal persName As String) As Boolean
        Dim mail As New MailMessage
        Dim credentials As New System.Net.NetworkCredential

        mail.From = New System.Net.Mail.MailAddress(username, showname)
        mail.To.Add(username)
        mail.Subject = "Willkommen bei justMail"
        mail.IsBodyHtml = True
        'MESSAGE!!!!!
        mail.Body = frmAddEmailPersonal.rtbHtmlWelcome.Text
        '-----------

        Dim smtp As New SmtpClient(smtpserver)
        smtp.Port = smtpport
        smtp.EnableSsl = useSSL
        smtp.Credentials = New System.Net.NetworkCredential(username, password)
        Try
            smtp.Send(mail)
            Return True
        Catch ex As Exception
            If checkIfConnectedWithInternetM("Das Hinzufügen eines neuen Kontos") = True Then
            End If
            Return False
        End Try
    End Function

    Public Function sendEmail(ByVal displayName As String, ByVal smtpserver As String, ByVal smtpport As Integer, ByVal usessl As Boolean, ByVal username As String, ByVal password As String, ByVal sendTo As String, ByVal subject As String, ByVal text As String, ByVal isHtml As Boolean, ByVal attachments As List(Of String)) As String
        If checkIfConnectedWithInternetM("Das Senden der E-Mail") = True Then
            Dim mail As New MailMessage
            Dim credentials As New System.Net.NetworkCredential
            Dim sendToM As New List(Of String)
            sendToM.AddRange(Split(sendTo, ";"))
            mail.From = New System.Net.Mail.MailAddress(username, displayName)

            For Each s As String In sendToM
                mail.To.Add(s.Replace(" ", ""))
            Next
            For Each s As String In attachments
                mail.Attachments.Add(New System.Net.Mail.Attachment(s))
            Next
            mail.Subject = subject
            mail.IsBodyHtml = isHtml
            'MESSAGE!!!!!
            mail.Body = text
            '-----------
            Dim smtp As New SmtpClient(smtpserver)
            smtp.Port = smtpport
            smtp.EnableSsl = usessl
            Try
                smtp.Credentials = New System.Net.NetworkCredential(username, password)
                smtp.Send(mail)
                Return "0"
            Catch ex As Exception
                Return ex.Message
            End Try
        Else
            Return "2"
        End If
    End Function

    Public Function getEmailCountPOP3(ByVal pop3srv As String, ByVal pop3prt As Integer, ByVal usessl As Boolean, ByVal username As String, ByVal password As String) As Integer
        Dim i As Integer
        Try
            Dim pop As New Pop3Client
            pop.Connect(pop3srv, pop3prt, usessl)
            pop.Authenticate(username, password)
            i = pop.GetMessageCount
            pop.Disconnect()
            errorOcc = False
            Return i
        Catch ex As OpenPOP.Pop3.Exceptions.PopServerException
            errorOcc = True
            Dim ERRSPLIT As New List(Of String)
            ERRSPLIT.AddRange(Split(ex.Message, """"))
            MsgBox("Fehler beim Abrufen neuer Nachrichten aufgetreten:" + vbCrLf + ERRSPLIT(1), MsgBoxStyle.Exclamation, "Fehler beim Abrufen neuer Nachrichten von " + username)
            Return 457895487
        End Try
    End Function

    

    Public Function getEmailsPOP3(ByVal pop3srv As String, ByVal pop3prt As Integer, ByVal usessl As Boolean, ByVal username As String, ByVal password As String) As List(Of email)
        Dim emaillist As New List(Of email)
        Dim pop As New Pop3Client
        Dim count As Integer = 0
        pop.Connect(pop3srv, pop3prt, usessl)
        pop.Authenticate(username, password)
        count = pop.GetMessageCount
        For i As Integer = 1 To count
            MsgBox("oK")
            emaillist.Add(New email With {.subject = pop.GetMessage(i).ToMailMessage.Subject, .text = pop.GetMessage(i).ToMailMessage.Body, .by = pop.GetMessage(i).ToMailMessage.From.ToString, .toG = pop.GetMessage(i).ToMailMessage.To.ToString, .dateSent = pop.GetMessage(i).Headers.DateSent.ToString})
        Next
        Return emaillist

        ' Catch ex As Exception
        ' MsgBox(ex.Message)
        'End Try
    End Function


End Module
