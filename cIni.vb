Public Class cIni
    Private config As New Dictionary(Of String, Dictionary(Of String, String))

    Private _CurrentSection As String = String.Empty
    Public ReadOnly Property CurrentSection As String
        Get
            Return _CurrentSection
        End Get
    End Property

    Public Property ErrorLevel As eErrorLevel = eErrorLevel.none

    Public Function GetSections() As List(Of String)
        Return config.Keys.ToList
    End Function

    Public Function GetKeysFromSection() As List(Of String)
        If Not String.IsNullOrWhiteSpace(_CurrentSection) Then
            If config.Keys.Contains(_CurrentSection, comp) Then
                Return config(comp.LastResult).Keys.ToList()
            Else
                Return New List(Of String)
            End If
        Else
            Throw New Exception("No section loaded!")
        End If
    End Function

    Public Function GetKeys(ByVal SectionName As String) As List(Of String)
        Dim tmp As String = _CurrentSection
        Dim retval As New List(Of String)
        Try
            _CurrentSection = SectionName
            retval = GetKeysFromSection()
        Catch ex As Exception
            Throw ex
        Finally
            _CurrentSection = tmp
        End Try
        Return retval
    End Function

    Public Function LoadSection(ByVal SectionName As String) As Boolean
        Dim tmp As String = comp.LastResult
        If config.Keys.Contains(SectionName, comp) Then
            _CurrentSection = comp.LastResult
            Return True
        Else
            comp.LastResult = tmp
            Return False
        End If
    End Function

    Public Sub WriteSection(ByVal SectionName As String, Optional ByVal Overwrite As Boolean = False)
        If config.Keys.Contains(SectionName, comp) Then
            _CurrentSection = comp.LastResult
            If Overwrite Then
                config.Remove(_CurrentSection)
                config.Add(_CurrentSection, New Dictionary(Of String, String))
            End If
        Else
            _CurrentSection = SectionName
            config.Add(_CurrentSection, New Dictionary(Of String, String))
        End If
    End Sub

    Public Sub WriteValueToSection(ByVal Key As String, ByVal Value As String)
        If Not String.IsNullOrWhiteSpace(_CurrentSection) Then
            If config.Keys.Contains(_CurrentSection, comp) Then
                _CurrentSection = comp.LastResult
                If config(_CurrentSection).Keys.Contains(Key, comp) Then
                    config(_CurrentSection)(comp.LastResult) = Value
                Else
                    config(_CurrentSection).Add(comp.LastResult, Value)
                End If
            Else
                config.Add(_CurrentSection, New Dictionary(Of String, String) From {{Key, Value}})
            End If
        Else
            Throw New Exception("No section loaded!")
        End If
    End Sub

    Public Function GetValueFromSection(ByVal Key As String) As String
        If Not String.IsNullOrWhiteSpace(_CurrentSection) Then
            config.Keys.Contains(_CurrentSection, comp)
            _CurrentSection = comp.LastResult
            config(_CurrentSection).Keys.Contains(Key, comp)
            Return config(_CurrentSection)(comp.LastResult)
        Else
            Throw New Exception("No section loaded!")
        End If
    End Function



    Public Shadows Function TryGetValueFromSection(ByVal Key As String, Optional ByVal DefaultValue As String = "") As String
        If Not String.IsNullOrWhiteSpace(_CurrentSection) Then
            If config.Keys.Contains(_CurrentSection, comp) Then
                _CurrentSection = comp.LastResult
                If config(_CurrentSection).Keys.Contains(Key, comp) Then
                    Return config(_CurrentSection)(comp.LastResult)
                Else
                    Select Case ErrorLevel
                        Case cIni.eErrorLevel.exception
                            Throw New Exception("Key not found in [" & _CurrentSection & "].")
                        Case cIni.eErrorLevel.debug
                            WriteValue(_CurrentSection, comp.LastResult, DefaultValue)
                            Debug.Print("------------------------------------------------")
                            Debug.Print("Key not found in [" & _CurrentSection & "].")
                            Debug.Print("Created new Key " & Chr(34) & Key & Chr(34))
                            Debug.Print("with Default Value " & Chr(34) & DefaultValue & Chr(34) & " instead.")
                            Debug.Print("------------------------------------------------")
                        Case Else
                            WriteValue(_CurrentSection, comp.LastResult, DefaultValue)
                    End Select
                    Return DefaultValue
                End If
            Else
                Select Case ErrorLevel
                    Case cIni.eErrorLevel.exception
                        Throw New Exception("[" & _CurrentSection & "] not found.")
                    Case cIni.eErrorLevel.debug
                        WriteValue(_CurrentSection, Key, DefaultValue)
                        Debug.Print("------------------------------------------------")
                        Debug.Print("[" & _CurrentSection & "] not found.")
                        Debug.Print("Created new _CurrentSection " & Chr(34) & _CurrentSection & Chr(34))
                        Debug.Print("Created new Key " & Chr(34) & Key & Chr(34))
                        Debug.Print("with Default Value " & Chr(34) & DefaultValue & Chr(34) & " instead.")
                        Debug.Print("------------------------------------------------")
                    Case Else
                        WriteValue(_CurrentSection, Key, DefaultValue)
                End Select
                Return DefaultValue
            End If
        Else
            Throw New Exception("No section loaded!")
        End If
    End Function

    Private comp As New KeyComparer

    Private Class KeyComparer
        Implements IEqualityComparer(Of String)
        Public Property LastResult As String
        Public Shadows Function Equals(x As String, y As String) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of String).Equals
            If x.ToLower = y.ToLower Then
                LastResult = x
                Return True
            Else
                LastResult = y
                Return False
            End If
        End Function

        Public Function GetHashCode1(obj As String) As Integer Implements System.Collections.Generic.IEqualityComparer(Of String).GetHashCode
            Return obj.GetHashCode
        End Function
    End Class

    Public Sub WriteValue(ByVal SectionName As String, ByVal Key As String, ByVal Value As String)
        Dim tmp As String = _CurrentSection
        Try
            _CurrentSection = SectionName
            WriteValueToSection(Key, Value)
        Catch ex As Exception
            Throw ex
        Finally
            _CurrentSection = tmp
        End Try
    End Sub

    Public Function GetValue(ByVal SectionName As String, ByVal Key As String) As String
        Dim tmp As String = _CurrentSection
        Dim retval As String = String.Empty
        Try
            _CurrentSection = SectionName
            retval = GetValueFromSection(Key)
        Catch ex As Exception
            Throw ex
        Finally
            _CurrentSection = tmp
        End Try
        Return retval
    End Function

    Public Enum eErrorLevel
        none
        debug
        exception
    End Enum

    Public Shadows Function TryGetValue(ByVal SectionName As String, ByVal Key As String, Optional ByVal DefaultValue As String = "") As String
        Dim tmp As String = _CurrentSection
        Dim retval As String = String.Empty
        Try
            _CurrentSection = SectionName
            retval = TryGetValueFromSection(Key, DefaultValue)
        Catch ex As Exception
            Throw ex
        Finally
            _CurrentSection = tmp
        End Try
        Return retval
    End Function

    Public Sub Load(ByVal path As String)
        Dim reg As New System.Text.RegularExpressions.Regex("\[.*\]")
        Using sw As New IO.StreamReader(path, System.Text.Encoding.Default)
            Dim tmp As String = String.Empty
            Dim SectionName As String = String.Empty
            Do Until sw.EndOfStream
                tmp = sw.ReadLine
                If reg.Matches(tmp).Count > 0 Then
                    SectionName = tmp.Replace("[", "").Replace("]", "")
                ElseIf Not String.IsNullOrWhiteSpace(tmp) Then
                    WriteValue(SectionName, tmp.Split("="c)(0), tmp.Split("="c)(1))
                End If
            Loop
        End Using
    End Sub

    Public Sub Save(ByVal path As String)
        Using sw As New IO.StreamWriter(path, False, System.Text.Encoding.Default)
            For Each kv As KeyValuePair(Of String, Dictionary(Of String, String)) In config
                sw.WriteLine("[" & kv.Key & "]")
                For Each ikv As KeyValuePair(Of String, String) In kv.Value
                    sw.WriteLine(ikv.Key & "=" & ikv.Value)
                Next
            Next
        End Using
    End Sub

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal ErrorLevel As eErrorLevel)
        MyBase.New()
        Me.ErrorLevel = ErrorLevel
    End Sub

    Public Sub New(ByVal path As String, ByVal ErrorLevel As eErrorLevel)
        MyBase.New()
        Load(path)
        Me.ErrorLevel = ErrorLevel
    End Sub

    Public Sub New(ByVal path As String)
        MyBase.New()
        Load(path)
    End Sub
End Class