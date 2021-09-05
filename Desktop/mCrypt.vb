Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Module mCrypt
    Public Class crypt
        Public Shared Function dÜLdBG78A9(ByVal a0äßn As String, ByVal b1ö7K As String, ByVal c2üOk As String, ByVal d3Qx09 As String, ByVal e4JxI0269 As Integer, ByVal f58xNoHD As String, ByVal g69dXjdZT As Integer) As String
            Dim initVectorBytes As Byte() : initVectorBytes = Encoding.ASCII.GetBytes(f58xNoHD) : Dim saltValueBytes As Byte() : saltValueBytes = Encoding.ASCII.GetBytes(c2üOk) : Dim plainTextBytes As Byte() : plainTextBytes = Encoding.UTF8.GetBytes(a0äßn) : Dim password As PasswordDeriveBytes : password = New PasswordDeriveBytes(b1ö7K, saltValueBytes, d3Qx09, e4JxI0269) : Dim keyBytes As Byte() : keyBytes = password.GetBytes(CByte(g69dXjdZT / 8)) : Dim symmetricKey As RijndaelManaged : symmetricKey = New RijndaelManaged() : symmetricKey.Mode = CipherMode.CBC : Dim encryptor As ICryptoTransform : encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes) : Dim memoryStream As MemoryStream : memoryStream = New MemoryStream() : Dim cryptoStream As CryptoStream : cryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write) : cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length) : cryptoStream.FlushFinalBlock() : Dim cipherTextBytes As Byte() : cipherTextBytes = memoryStream.ToArray() : memoryStream.Close() : cryptoStream.Close() : Dim cipherText As String : cipherText = Convert.ToBase64String(cipherTextBytes) : dÜLdBG78A9 = cipherText
        End Function

        Public Shared Function fÜÖfNH89S0(ByVal a0äßn As String, ByVal b1ö7K As String, ByVal c2üOk As String, ByVal d3Qx09 As String, ByVal e4JxI0269 As Integer, ByVal f58xNoHD As String, ByVal g69dXjdZT As Integer) As String
            Dim initVectorBytes As Byte() : initVectorBytes = Encoding.ASCII.GetBytes(f58xNoHD) : Dim saltValueBytes As Byte() : saltValueBytes = Encoding.ASCII.GetBytes(c2üOk) : Dim cipherTextBytes As Byte() : cipherTextBytes = Convert.FromBase64String(a0äßn) : Dim password As PasswordDeriveBytes : password = New PasswordDeriveBytes(b1ö7K, saltValueBytes, d3Qx09, e4JxI0269) : Dim keyBytes As Byte() : keyBytes = password.GetBytes(CByte(g69dXjdZT / 8)) : Dim symmetricKey As RijndaelManaged : symmetricKey = New RijndaelManaged() : symmetricKey.Mode = CipherMode.CBC : Dim decryptor As ICryptoTransform : decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes) : Dim memoryStream As MemoryStream : memoryStream = New MemoryStream(cipherTextBytes) : Dim cryptoStream As CryptoStream : cryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read) : Dim plainTextBytes As Byte() : ReDim plainTextBytes(cipherTextBytes.Length) : Dim decryptedByteCount As Integer : decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length) : memoryStream.Close() : cryptoStream.Close() : Dim plainText As String : plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount) : fÜÖfNH89S0 = plainText
        End Function
    End Class

    Public Function cc(ByVal u47ÜhgBHX7 As String) As String
        Return crypt.dÜLdBG78A9(u47ÜhgBHX7, crypt.fÜÖfNH89S0("CuSZEVZ6SGkPsz2aWVrhExrMnu0Xp0s4Hh5rdv+w5jw=", "érjfdjLÖHD'ääfszefl'äe737809&)&$(%&", "§/(snXNyd,#Äjsd", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256), "§/(snXNyd,#Äjsd", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256)
    End Function

    Public Function cdc(ByVal i58ÜjhNJC8 As String) As String
        Return crypt.fÜÖfNH89S0(i58ÜjhNJC8, crypt.fÜÖfNH89S0("CuSZEVZ6SGkPsz2aWVrhExrMnu0Xp0s4Hh5rdv+w5jw=", "érjfdjLÖHD'ääfszefl'äe737809&)&$(%&", "§/(snXNyd,#Äjsd", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256), "§/(snXNyd,#Äjsd", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256)
    End Function
End Module