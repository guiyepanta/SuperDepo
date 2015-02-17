using System;
using System.Collections.Generic;
using System.Text;
using SuperDepo_CMM;
using SuperDepo_DB;
using SuperDepo_SL;

namespace SuperDepo_BL
{
    public class userManager
    {
        #region Singleton UserManager       
        
        private userManager()
        { 
        }

        static userManager instance = null;

        public static userManager getInstance() 
        {
            if (instance == null)
                instance = new userManager();

            return instance;
        }
        #endregion

        #region Metodos Publicos

        public User validaLogin(User login)
        {
            try
            {
                return dbUser.getInstance().validaLogin(login);
            }
            catch (Exception ex)
            {                
                throw ex;
            }            
        }

        public Users GetUsers()
        {
            Users list = new Users();
            try
            {
                list = dbUser.getInstance().getUsers();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return list;
        }

        public int GuardarDatos(User usr)
        {
            try
            {
                usr.dh = SecurityManager.getInstance().DigitoHorizontalUsuario(usr);
                return dbUser.getInstance().GuardarDatos(usr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
                
        #endregion       
    
    
        public List<Modulo> getAccesosAsignados(int idUser)
        {
            try
            {
                return dbUser.getInstance().getAccesosAsignados(idUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Modulo> getModulos()
        {
            try
            {
                return dbUser.getInstance().getModulos();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void grabarDigitoHorizontal(int idUser, int dh)
        {
            try
            {
                dbUser.getInstance().grabarDigitoHorizontal(idUser, dh);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void grabarDigitoVerticalUsuarios(int DV)
        {
            try
            {
                dbUser.getInstance().grabarDigitoVerticalUsuarios(DV);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int getDigitoVertical()
        {
            try
            {
                return dbUser.getInstance().getDigitoVertical();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

/*
        Public Function getUsuario(ByVal login As Usuario) As Usuario

            Try

                BIZ.Globals.userLogin = DAL.dbUsuario.getInstance.getUsuario(login)

            Catch ex As ExcepcionesDAL
                SL.GestorExcepcionesBLL.TratarExcepcion(ex)
            End Try

        End Function

        Public Function validaPatentes(ByVal UserLogin As Usuario) As List(Of Patente)

            Dim listaPatentes As New List(Of Patente)

            For Each Familia As Familia In UserLogin.Familia
                For Each Patente As Patente In Familia.Patente
                    Dim p1 As New Patente
                    p1.idPatente = Patente.idPatente
                    p1.Nombre = Patente.Nombre
                    p1.Descripcion = Patente.Descripcion

                    listaPatentes.Add(p1)

                Next
            Next

            Return listaPatentes

        End Function

        'Valida el objeto Usuario con las reglas de negocio
        Public Function ValidarDatosUsuario(ByVal NuevoUsuario As Usuario) As String

            Dim CamposErroneos As String = "Los siguientes campos son incorrectos:" & vbCrLf & vbCrLf
            Dim compare As String = "Los siguientes campos son incorrectos:" & vbCrLf & vbCrLf

            If NuevoUsuario.Nombre = Nothing Or IsNumeric(NuevoUsuario.Nombre) Then
                CamposErroneos = CamposErroneos & "Nombre:" & " Valores válidos (A-Z)" & vbCrLf
            End If

            If NuevoUsuario.Apellido = Nothing Or IsNumeric(NuevoUsuario.Apellido) Then
                CamposErroneos = CamposErroneos & "Apellido:" & " Valores válidos (A-Z)" & vbCrLf
            End If

            If Not IsNumeric(NuevoUsuario.DNI) Then
                CamposErroneos = CamposErroneos & "DNI:" & " Valores válidos (0-9)" & vbCrLf
            End If

            If NuevoUsuario.UserName = Nothing Then
                CamposErroneos = CamposErroneos & "UserName:" & " Valores válidos (A-Z), (0-9)" & vbCrLf
            End If

            Dim MyInt As Integer = CamposErroneos.CompareTo(compare)
            If MyInt = 1 Then
                Return CamposErroneos
                'MsgBox(CamposErroneos, MsgBoxStyle.Critical)
            End If

        End Function

        Public Function AltaUsuario(ByVal NuevoUsuario As Usuario) As Boolean

            Try
                'Chequeo que el userName no exista en el sistema
                If DAL.dbUsuario.getInstance.buscarUserName(NuevoUsuario.UserName) = True Then
                    Return True
                    Exit Function
                End If

                If DAL.dbUsuario.getInstance.InsertUsuario(NuevoUsuario) = True Then
                    'Actualizo los digitos
                    SL.GestorSeguridad.getInstance.ActualizarDigito()
                    Return False
                End If
            Catch ex As ExcepcionesDAL
                SL.GestorExcepcionesBLL.TratarExcepcion(ex)
            End Try

        End Function

        Public Function UpdateUsuario(ByVal nuevousuario As Usuario) As Boolean

            Try
                DAL.dbUsuario.getInstance.updateUsuario(nuevousuario)
                'Actualizo los digitos
                SL.GestorSeguridad.getInstance.ActualizarDigito()
            Catch ex As ExcepcionesDAL
                SL.GestorExcepcionesBLL.TratarExcepcion(ex)
            End Try

        End Function

        Public Function borrarUsuario(ByVal ID_Usuario As Integer) As Boolean

            Try
                'Borro el usuario
                DAL.dbUsuario.getInstance.borrarUsuario(ID_Usuario)
                'Actualizo los digitos
                SL.GestorSeguridad.getInstance.ActualizarDigito()
            Catch ex As ExcepcionesDAL
                SL.GestorExcepcionesBLL.TratarExcepcion(ex)
            End Try

        End Function

        Public Function ListarUsuarios() As List(Of Usuario)

            Dim listaDeUsuarios As New List(Of Usuario)
            Try
                listaDeUsuarios = DAL.dbUsuario.getInstance.ListarUsuarios
            Catch ex As ExcepcionesDAL
                SL.GestorExcepcionesBLL.TratarExcepcion(ex)
            End Try

            Return listaDeUsuarios

        End Function

    End Class
 
    */
}
