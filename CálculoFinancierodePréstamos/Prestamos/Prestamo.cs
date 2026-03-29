using Entidades;
using LógicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CálculoFinancierodePréstamos.Prestamos
{
    public partial class Prestamo : Form
    {
        LogicaNegocios_Prestamos guardar = new LogicaNegocios_Prestamos();
        
        public Prestamo()
        {
            InitializeComponent();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
                if (dgv_Cuotas.DataSource == null) return;

                int TiempoEntrada = int.Parse(cmb_tiempoA.Text);
                int MesesFinales = (cmb_TipoDeTiempo.Text == "Años") ? TiempoEntrada * 12 : TiempoEntrada;

                Préstamos Prestamo = new Préstamos
                {
                    IdCliente = int.Parse(txt_id.Text),
                    IdUsuario = 1,
                    MontoCapital = decimal.Parse(txt_MontoDeseado.Text),
                    PlazoMeses = MesesFinales,
                    TasaInteresAplicada = decimal.Parse(txt_tea.Text),
                    MontoTotal = decimal.Parse(txt_MontoDeseado.Text),
                    Garantia = txt_garantia.Text,
                    Fecha = DateTime.Now
                };
                List<Cuotas> Lista = (List<Cuotas>)dgv_Cuotas.DataSource;
                if (guardar.GuardarPrestamoCompleto(Prestamo, Lista))
                {
                    MessageBox.Show("Préstamo registrado exitosamente y fondos actualizados.", "Éxito");
                    LimpiarPantalla();
                    ActualizarFondoBanco();
                }
        }

        private void ActualizarFondoBanco()
        {
            decimal fondo = guardar.ConsultarFondoBanco();
            txt_MontoBanco.Text = fondo.ToString("N2");
            txt_MontoBanco.ForeColor = (fondo < 1000000000) ? Color.Red : Color.Black;
            txt_MontoBanco.Enabled = false;
        }

        private void cmb_nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_nombre.SelectedItem != null && cmb_nombre.SelectedItem is Entidades.Clientes)
            {
                var cliente = (Entidades.Clientes)cmb_nombre.SelectedItem;

                txt_id.Text = cliente.IdCliente.ToString();
                txt_sueldo.Text = cliente.SueldoMensual.ToString("N2");

                decimal fondoBanco = guardar.ConsultarFondoBanco();
                decimal limitePorSueldo = cliente.SueldoMensual * 4;
                decimal limiteRealFinal = Math.Min(limitePorSueldo, fondoBanco);

                txt_LimitePrestamo.Text = limiteRealFinal.ToString("N2");
                txt_LimitePrestamo.Enabled = false;

                int CantidadMoras = guardar.ObtenerCantidadMoras(cliente.IdCliente);
                txt_moras.Text = CantidadMoras.ToString();
                txt_moras.Enabled = false;

                txt_tea.Enabled = false;
                lbl_id.Visible = false;
                txt_id.Visible = false;
                txt_sueldo.Enabled = false;

                txt_garantia.Clear();
                dgv_Cuotas.DataSource = null;
                btn_guardar.Enabled = false;
            }
        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
            try
            {
                decimal MontoDeseado = decimal.Parse(txt_MontoBanco.Text);
                decimal sueldo = decimal.Parse(txt_sueldo.Text);
                int moras = int.Parse(txt_moras.Text);
                int TiempoEntrada = int.Parse(cmb_tiempoA.Text);
                decimal FondoActual = guardar.ConsultarFondoBanco();


                int MesesFinales = (cmb_TipoDeTiempo.Text == "Años") ? TiempoEntrada * 12 : TiempoEntrada;
                string ResultadoValidacion = guardar.ValidarReglas(sueldo, MontoDeseado, FondoActual, moras);

                if (ResultadoValidacion == "OK")
                {
                    decimal tea = guardar.ObtenerTasaTEA(MesesFinales);
                    txt_tea.Enabled = false;
                    txt_tea.Text = tea.ToString();

                    var ListaCuotas = guardar.GenerarCuotas(MontoDeseado, (double)tea, MesesFinales);
                    dgv_Cuotas.DataSource = null;
                    dgv_Cuotas.DataSource = ListaCuotas;

                    if (ListaCuotas.Count > 0)
                        txt_CuotasCalculadas.Text = ListaCuotas[0].MontoCuota.ToString("N2");

                    btn_guardar.Enabled = true;
                }
                else
                {
                    MessageBox.Show(ResultadoValidacion, "Préstamo Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgv_Cuotas.DataSource = null;
                    btn_guardar.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Verifique que los campos numéricos estén correctos. " + ex.Message);
            }
        }
        private void LimpiarPantalla()
        {
            txt_MontoDeseado.Clear();
            txt_garantia.Clear();
            txt_CuotasCalculadas.Clear();
            dgv_Cuotas.DataSource = null;
            btn_guardar.Enabled = false;
        }

        private void Prestamo_Load(object sender, EventArgs e)
        {
            ActualizarFondoBanco();
            cmb_nombre.DataSource = guardar.ObtenerTodosLosClientes();
            cmb_nombre.DisplayMember = "NombreCompleto";    
            cmb_nombre.ValueMember = "IdCliente";   

            cmb_nombre.SelectedIndex = -1;
            cmb_TipoDeTiempo.Items.Clear();
            cmb_TipoDeTiempo.Items.Add("Meses");
            cmb_TipoDeTiempo.Items.Add("Años");
            cmb_TipoDeTiempo.SelectedIndex = 0; 

         
            cmb_tiempoA.Items.Clear();
            for (int i = 6; i <= 36; i += 6) 
            {
                cmb_tiempoA.Items.Add(i);
            }
            cmb_tiempoA.SelectedIndex = 1; 
        }
    }
    
}
