Imports System.Net.Mail
Imports QRCoder
Imports System.IO
Imports System.Drawing
Imports System.Web
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Net

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSendEmail_Click(sender As Object, e As EventArgs) Handles btnSendEmail.Click
        'Create QR and Save to File
        GenerateQR(QrCodeData.Value)

        'Upload Image
        Dim folderPath As String = Server.MapPath("~/file/")

        'Check whether Directory (Folder) exists.
        If Not Directory.Exists(folderPath) Then
            'If Directory (Folder) does not exists Create it.
            Directory.CreateDirectory(folderPath)
        End If

        'Save the File to the Directory (Folder).
        File.SaveAs(folderPath & Path.GetFileName(File.FileName))
        Dim FN As String = File.FileName
        'Generate PDF 
        CreatePDF(folderPath, FN)
        Dim PathFile As String
        PathFile = folderPath & "sample.pdf"
        'Send email

        sendEmail([To].Text, "", "Ticket Information", Body.Text, PathFile)
    End Sub
    Private Sub CreatePDF(Path As String, FN As String)
        'Dim doc As New Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)
        'Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(Path & "sample.pdf", FileMode.Create))
        'doc.Open()


        'Dim para As New Paragraph("This is my first paragraph")
        'Dim pharse As New Phrase("This is my first phrase")
        'Dim chunk_ As New Chunk("This is my first chunk")

        'doc.Add(para)
        'doc.Add(pharse)
        'doc.Add(chunk_)
        'doc.Add(iTextSharp.text.Image.GetInstance(Path & FN))
        'doc.Add(iTextSharp.text.Image.GetInstance(Path & "test.png"))
        'doc.Close()
        Dim pdfTemplate As String = Path & "master/master.pdf"
        Dim newFile As String = Path & "sample.pdf"
        Dim reader As PdfReader = New PdfReader(pdfTemplate)
        Dim Size As iTextSharp.text.Rectangle = reader.GetPageSizeWithRotation(1)
        Dim Document As Document = New Document(Size)
        Dim fs As FileStream = New FileStream(newFile, FileMode.Create, FileAccess.Write)
        Dim writer As PdfWriter = PdfWriter.GetInstance(Document, fs)
        Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Path & FN)
        img.SetAbsolutePosition(420.0F, 550.0F)
        img.ScaleAbsolute(100.0F, 150.0F)
        'img.ScalePercent(0.1F * 100)
        Dim img2 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Path & "Test.png")
        img2.SetAbsolutePosition(420.0F, 450.0F)
        img2.ScaleAbsolute(100.0F, 100.0F)
        Document.Open()
        'the pdf content
        Dim cb As PdfContentByte = writer.DirectContent
        Document.Add(img)
        Document.Add(img2)
        'select the font properties
        Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
        cb.SetColorFill(BaseColor.DARK_GRAY)
        cb.SetFontAndSize(bf, 11)

        'write the text in the pdf content
        cb.BeginText()
        Dim Text As String = "Order #" & OrderID.Value
        ' put the alignment And coordinates here
        cb.ShowTextAligned(1, Text, 490, 710, 0)
        cb.EndText()
        cb.BeginText()
        Text = "Tittle" & Title.Text
        ' put the alignment And coordinates here
        cb.ShowTextAligned(0, Text, 100, 680, 0)
        cb.EndText()
        cb.BeginText()
        Text = "General Admision"
        ' put the alignment And coordinates here
        cb.ShowTextAligned(0, Text, 100, 610, 0)
        cb.EndText()
        cb.BeginText()
        Text = Address.Value
        ' put the alignment And coordinates here
        cb.ShowTextAligned(0, Text, 100, 600, 0)
        cb.EndText()
        cb.BeginText()
        Text = [Date].Text
        ' put the alignment And coordinates here
        cb.ShowTextAligned(0, Text, 100, 590, 0)
        cb.EndText()
        cb.BeginText()
        Text = "Order Information"
        ' put the alignment And coordinates here
        cb.ShowTextAligned(0, Text, 100, 570, 0)
        cb.EndText()
        cb.BeginText()
        Text = "Order #" & OrderID.Value
        ' put the alignment And coordinates here
        cb.ShowTextAligned(0, Text, 100, 560, 0)
        cb.EndText()
        cb.BeginText()
        Text = "Order by" & FullName.Value
        ' put the alignment And coordinates here
        cb.ShowTextAligned(0, Text, 100, 550, 0)
        cb.EndText()
        cb.BeginText()
        Text = OrderDate.Text
        ' put the alignment And coordinates here
        cb.ShowTextAligned(0, Text, 100, 540, 0)
        cb.EndText()


        Dim Page As PdfImportedPage = writer.GetImportedPage(reader, 1)
        cb.AddTemplate(Page, 0, 0)


        Document.Close()
        fs.Close()
        writer.Close()
        reader.Close()
    End Sub
    Private Sub sendEmail(emailto As String, cc As String, Subject As String, Body As String, PathFile As String)
        Dim at As Attachment
        Dim Mail As MailMessage
        Dim smtp As SmtpClient
        Mail = New MailMessage
        Mail.To.Add(emailto)
        If cc <> "" Then
            Mail.CC.Add(New MailAddress(cc))
        End If
        Mail.From = New MailAddress("test@test.com.ng")
        Mail.Subject = Subject

        Mail.Body = Body
        at = New Attachment(PathFile)
        Mail.Attachments.Add(at)

        'mail.IsBodyHtml = true
        smtp = New SmtpClient()
        smtp.Credentials = New NetworkCredential("your email", "your password")
        smtp.Host = "smtp.gmail.com"
        smtp.Port = 587 '25
        smtp.EnableSsl = True
        smtp.Send(Mail)
        'If  Then
        at.Dispose()
        'End If
    End Sub
    Private Sub GenerateQR(Data As String)
        Dim code As String = Data
        Dim qrGenerator As New QRCodeGenerator()
        Dim qrCode As QRCodeGenerator.QRCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q)
        Dim imgBarCode As New System.Web.UI.WebControls.Image()
        imgBarCode.Height = 150
        imgBarCode.Width = 150
        Dim file_name As String = HttpContext.Current.Server.MapPath("~")
        file_name = file_name & "\file\" & "\test.png"
        Using bitMap As Bitmap = qrCode.GetGraphic(20)
            bitMap.Save(file_name, System.Drawing.Imaging.ImageFormat.Png)
            'Using ms As New MemoryStream()
            '   bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            '    Dim byteImage As Byte() = ms.ToArray()
            '    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage)
            'End Using
            'plBarCode.Controls.Add(imgBarCode)
        End Using
    End Sub
End Class