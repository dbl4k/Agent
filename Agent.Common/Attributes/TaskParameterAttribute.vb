Public Class TaskParameterAttribute : Inherits Attribute

    Private m_requirement As Requirement = Nothing
    Private m_default As Object = Nothing

    Public Sub New(requirement As Requirement)
        m_requirement = requirement
    End Sub

    Public Sub New(requirement As Requirement, [default] As String)
        m_requirement = requirement
        m_default = [default]
    End Sub

    Public Sub New(requirement As Requirement, [default] As Boolean)
        m_requirement = requirement
        m_default = [default]
    End Sub

    Public Sub New(requirement As Requirement, [default] As Integer)
        m_requirement = requirement
        m_default = [default]
    End Sub

    Public Sub New(requirement As Requirement, [default] As Decimal)
        m_requirement = requirement
        m_default = [default]
    End Sub

    Public Sub New(requirement As Requirement, [default] As Date)
        m_requirement = requirement
        m_default = [default]
    End Sub

End Class
