using Entidades;
using LógicaNegocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
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
        private User_Login _usuarioLogueado;

        public Prestamo(User_Login usuarioQueEntro)
        {
            InitializeComponent();
            _usuarioLogueado = usuarioQueEntro;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            btn_guardar.Enabled = true;
            if (dgv_Cuotas.DataSource == null) return;

                int TiempoEntrada = int.Parse(cmb_tiempoA.Text);
                int MesesFinales = (cmb_TipoDeTiempo.Text == "Años") ? TiempoEntrada * 12 : TiempoEntrada;
                List<Cuotas> Lista = (List<Cuotas>)dgv_Cuotas.DataSource;

                Préstamos Prestamo = new Préstamos
                {
                    IdCliente = int.Parse(txt_id.Text),
                    IdUsuario = _usuarioLogueado.IdUsuario,
                    MontoCapital = decimal.Parse(txt_MontoDeseado.Text),
                    PlazoMeses = MesesFinales,
                    TasaInteresAplicada = decimal.Parse(txt_tea.Text),
                    MontoTotal = Lista.Sum(x => x.MontoCuota),
                    Garantia = txt_garantia.Text,
                    Fecha = DateTime.Now
                };
               
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

                LimpiarPantalla();
                ActualizarTEAAutomaticamente();
            }
        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_MontoBanco.Text) || string.IsNullOrEmpty(txt_sueldo.Text))
                {
                    MessageBox.Show("Por favor, llene el monto y el sueldo.");
                    return;
                }
                
                string montoLimpio = txt_MontoDeseado.Text.Replace(",", "").Replace("$", "").Trim();
                string sueldoLimpio = txt_sueldo.Text.Replace(",", "").Replace("$", "").Trim();

                
                decimal MontoDeseado = decimal.Parse(montoLimpio, System.Globalization.CultureInfo.InvariantCulture);
                decimal sueldo = decimal.Parse(sueldoLimpio, System.Globalization.CultureInfo.InvariantCulture);


                decimal FondoActual = guardar.ConsultarFondoBanco();

                int moras = int.Parse(txt_moras.Text);


                int TiempoEntrada = int.Parse(cmb_tiempoA.Text);
                int MesesFinales = (cmb_TipoDeTiempo.Text == "Años") ? TiempoEntrada * 12 : TiempoEntrada;
                
                DateTime FechaInicio = dtp_FechaPrimerPago.Value;


                string ResultadoValidacion = guardar.ValidarReglas(sueldo, MontoDeseado, FondoActual, moras);

                if (ResultadoValidacion == "OK")
                {
                    decimal tea = guardar.ObtenerTasaTEA(MesesFinales);
                    txt_tea.Enabled = false;
                    txt_tea.Text = tea.ToString();
                    txt_TiempoM.Text = MesesFinales.ToString();
                    double tem = guardar.CalcularTEM((double)tea);
                    txt_tem.Text = (tem * 100).ToString("N2") + "%";


                    var ListaCuotas = guardar.GenerarCuotas(MontoDeseado, (double)tea, MesesFinales,FechaInicio);
                    dgv_Cuotas.DataSource = null;
                    dgv_Cuotas.DataSource = ListaCuotas;

                    if (dgv_Cuotas.Columns["FechaVencimiento"] != null)
                    {
                        dgv_Cuotas.Columns["FechaVencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dgv_Cuotas.Columns["FechaVencimiento"].HeaderText = "F. Vencimiento";
                    }

                    // Alinear montos a la derecha
                    dgv_Cuotas.Columns["MontoCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    txt_CuotasCalculadas.Text = ListaCuotas.Sum(c => c.MontoCuota).ToString("N2");

                    btn_guardar.Enabled = true;
                    txt_tem.Enabled = false;
                    txt_TiempoM.Enabled = false;
                    txt_CuotasCalculadas.Enabled = false;
                }
                else
                {
                    MessageBox.Show(ResultadoValidacion, "Cliente no apto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgv_Cuotas.DataSource = null;
                    btn_guardar.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error real: " + ex.Message);
                MessageBox.Show("Error: Verifique que los campos numéricos estén correctos. Detalles: " + ex.Message,
                "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void ActualizarTEAAutomaticamente()
        {
            if (cmb_tiempoA.SelectedItem != null && cmb_TipoDeTiempo.SelectedItem != null)
            {
                int valorTiempo = int.Parse(cmb_tiempoA.SelectedItem.ToString());

               
                int mesesFinales = (cmb_TipoDeTiempo.Text == "Años") ? valorTiempo * 12 : valorTiempo;

                
                decimal tea = guardar.ObtenerTasaTEA(mesesFinales);

                txt_tea.Text = tea.ToString("N2") + "%";
                txt_tea.Enabled = false;
            }
        }

        private void Prestamo_Load(object sender, EventArgs e)
        {
            dtp_FechaPrimerPago.MinDate = DateTime.Today;
            dtp_FechaPrimerPago.Value = DateTime.Today.AddMonths(1);

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

        private void cmb_TipoDeTiempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_tiempoA.SelectedIndexChanged -= cmb_tiempoA_SelectedIndexChanged;

            cmb_tiempoA.Items.Clear();

            if (cmb_TipoDeTiempo.Text == "Meses")
            {
                for (int i = 6; i <= 36; i += 6) cmb_tiempoA.Items.Add(i);
            }
            else // Años
            {
                for (int i = 1; i <= 5; i++) cmb_tiempoA.Items.Add(i);
            }

            cmb_tiempoA.SelectedIndex = 0;

           
            cmb_tiempoA.SelectedIndexChanged += cmb_tiempoA_SelectedIndexChanged;
            ActualizarTEAAutomaticamente();
        }

        private void cmb_tiempoA_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTEAAutomaticamente();
        }
    }
    
}
