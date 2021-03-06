﻿using System;
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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            
            UsuarioDesktop usuarioDesktop = new UsuarioDesktop(AplicationForm.ModoForm.Alta);
            usuarioDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows != null)
            {                
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop usuarioDesktop = new UsuarioDesktop(ID, AplicationForm.ModoForm.Modificacion);
                usuarioDesktop.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una Fila", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop usuarioDesktop = new UsuarioDesktop(ID, AplicationForm.ModoForm.Baja);
            usuarioDesktop.ShowDialog();
            this.Listar();
        }
    }
}
