using AccesoDatos;
using Entidades;
using LógicaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace CálculoFinancierodePréstamos.Clientes
{
    public partial class FrmActualizarCliente : Form
    {
        public FrmActualizarCliente()
        {
            InitializeComponent();
        }

        private void FrmActualizarCliente_Load(object sender, EventArgs e)
        {

        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Clientes cliente = new Entidades.Clientes()
                {
                    IdCliente = int.Parse(txtIdCliente.Text),
                    NombreCompleto = txtNombre.Text,
                    Correo = txtCorreo.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    SueldoMensual = Convert.ToDecimal(txtSueldo.Text)
                };

                LógicaNegocio_ActualizarCliente logica = new LógicaNegocio_ActualizarCliente();

                int resultado = logica.ActualizarAlCliente(cliente);

                if (resultado > 0)
                {
                    MessageBox.Show("Cliente actualizado correctamente");
                    int id = int.Parse(txtIdCliente.Text);
                    RefrescarGridPorId(id);


                }
                else
                {
                    MessageBox.Show("No se actualizó ningún registro");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifica los campos numéricos (ID o sueldo)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridViewCliente.Rows[e.RowIndex];

                txtIdCliente.Text = fila.Cells["IdCliente"].Value.ToString();
                txtNombre.Text = fila.Cells["NombreCompleto"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtSueldo.Text = fila.Cells["SueldoMensual"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIdCliente.Text, out int id))
                {
                    MessageBox.Show("Ingrese un ID válido");
                    return;
                }

                LogicaNegocio_Cliente logica = new LogicaNegocio_Cliente();

              
                dataGridViewCliente.DataSource = new List<Entidades.Clientes>
       
                {
                    logica.ObtenerClientePorId(id)
                };

            
                Entidades.Clientes cliente = logica.ObtenerClientePorId(id);

                if (cliente != null)
                {
                    txtNombre.Text = cliente.NombreCompleto;
                    txtCorreo.Text = cliente.Correo;
                    txtDireccion.Text = cliente.Direccion;
                    txtTelefono.Text = cliente.Telefono;
                    txtSueldo.Text = cliente.SueldoMensual.ToString();
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefrescarGridPorId(int idCliente)
        {
            try
            {
                VerClientes datos = new VerClientes();

                Entidades.Clientes cliente = datos.ObtenerClientePorId(idCliente);

                if (cliente != null)
                {
                    dataGridViewCliente.DataSource = null;
                    dataGridViewCliente.DataSource = new List<Entidades.Clientes> { cliente };
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Reporte2_Click(object sender, EventArgs e)
        {
            
            // Validar ID
            if (!int.TryParse(txtIdCliente.Text, out int idCliente))
            {
                MessageBox.Show("Ingrese un ID válido");
                return;
            }

            // Opcional pero recomendado: validar que exista el cliente
            VerClientes datos = new VerClientes();
            var cliente = datos.ObtenerClientePorId(idCliente);

            if (cliente == null)
            {
                MessageBox.Show("Cliente no encontrado");
                return;
            }

            // Abrir el reporte
            FrmReporteInfoCliente reporte = new FrmReporteInfoCliente();

            // 🔥 AQUÍ SE PASA EL ID
            reporte.IdClienteRecibido = idCliente;

            reporte.ShowDialog();
        }
    
    }

 }       
