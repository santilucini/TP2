using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;


namespace UI.Desktop
{
    public partial class UsuarioDesktop : AplicationForm
    {
        #region Constructores
        public UsuarioDesktop()
        {
            InitializeComponent();

        }
        public UsuarioDesktop(ModoForm modo):this()
        {
            this.Modo = modo;
            if (this.Modo.Equals(AplicationForm.ModoForm.Alta))
            {
                this.btnAceptar.Text = "Guardar";                
            }
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            if (this.Modo.Equals(AplicationForm.ModoForm.Modificacion))
            {
                this.btnAceptar.Text = "Guardar";
            }
            if (this.Modo.Equals(AplicationForm.ModoForm.Baja))
            {
                this.btnAceptar.Text = "Eliminar";
            }
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            MapearDeDatos();
        }
        #endregion

        #region Propiedades
        public Usuario UsuarioActual { get; set; }
        #endregion

        #region Metodos
        public override void MapearDeDatos() 
        {  
            this.txbId.Text = this.UsuarioActual.ID.ToString(); 
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado; 
            this.txbNombre.Text = this.UsuarioActual.Nombre;
            this.txbApellido.Text = this.UsuarioActual.Apellido;
            this.txbEmail.Text = this.UsuarioActual.EMail;
            this.txbUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txbClave.Text = this.UsuarioActual.Clave;            
        }
        public override void MapearADatos() 
        {            
            if (this.Modo.Equals(AplicationForm.ModoForm.Alta))
            {                
                Usuario usu = new Usuario();
                UsuarioActual = usu;
            }
            if (this.Modo.Equals(AplicationForm.ModoForm.Alta) || this.Modo.Equals(AplicationForm.ModoForm.Modificacion))
            { 
                if (this.Modo.Equals(AplicationForm.ModoForm.Modificacion))
                {
                    UsuarioActual.ID = Convert.ToInt32(txbId.Text);
                }
                UsuarioActual.Nombre = txbNombre.Text;
                UsuarioActual.Apellido = txbApellido.Text;
                UsuarioActual.EMail = txbEmail.Text;
                UsuarioActual.Habilitado = chkHabilitado.Checked;
                UsuarioActual.NombreUsuario = txbUsuario.Text;
                UsuarioActual.Clave = txbClave.Text;
                if (this.Modo.Equals(AplicationForm.ModoForm.Modificacion))
                {
                    UsuarioActual.State = BusinessEntity.States.Modified;
                }
                if (this.Modo.Equals(AplicationForm.ModoForm.Alta))
                {
                    UsuarioActual.State = BusinessEntity.States.New;
                }

            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            usuarioLogic.Save(UsuarioActual);
        }
        public override bool Validar() 
        {
            bool error = true;
            string errores = "Hay Errores en: \n";
            if (!(IsValidString(txbNombre.Text))) 
            {
                errores += "Nombre ";                
                error = false;                
            }            
            if (!(IsValidString(txbApellido.Text)))
            {
                errores += "Apellido ";
                error = false;
            }
            if (!(IsValidString(txbUsuario.Text)))
            {
                errores += "Usuario ";
                error = false;
            }
            if (!(IsValidEmail(txbEmail.Text)))
            {
                errores += "Email ";
                error = false;
            }
            if (!(IsValidPass(txbClave.Text)))
            {
                errores += "Clave ";
                error = false;
            }
            if (!(txbClave.Text.Equals(txbConfirmarClave.Text)))
            {
                errores += "Confirmar Clave";
                error = false;
            }
            
            if (!error)
            {                
                MessageBox.Show(errores, "Error", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("no error");
            }

            return error;
        }
        bool IsValidPass(string str)
        {
            try
            {
                if (str.Length >= 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        bool IsValidString(string str)
        {
            try
            {
                if (String.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Modo.Equals(AplicationForm.ModoForm.Modificacion)||this.Modo.Equals(AplicationForm.ModoForm.Alta))
            {
                if (Validar())
                {
                    GuardarCambios();
                }
            }
            if (this.Modo.Equals(AplicationForm.ModoForm.Baja))
            {
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                usuarioLogic.Delete(Convert.ToInt32(txbId.Text));
            }
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
