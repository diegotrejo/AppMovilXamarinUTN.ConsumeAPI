using AppMovilXamarinUTN.ConsumeAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMovilXamarinUTN.ConsumeAPI
{
    public partial class MainPage : ContentPage
    {
        private string ApiUrl = "https://cloudcomputingapi2.azurewebsites.net/api/Clasificaciones";

        public MainPage()
        {
            InitializeComponent();
        }

        private void cmdCreate_Clicked(object sender, EventArgs e)
        {
            var resultado = APIConsumer.CrudCrud<Clasificacion>.Create(ApiUrl, new Clasificacion { 
                Id = 0,
                Descripcion = txtClasificacion.Text
            });

            if (resultado != null) {
                txtId.Text = resultado.Id.ToString();
            }
        }

        private void cmdRead_Clicked(object sender, EventArgs e)
        {
            var resultado = APIConsumer.CrudCrud<Clasificacion>.Read_ById(ApiUrl, int.Parse(txtId.Text));
            if (resultado != null)
            {
                txtId.Text = resultado.Id.ToString();
                txtClasificacion.Text = resultado.Descripcion;
            }
        }

        private void cmdUpdate_Clicked(object sender, EventArgs e)
        {
            APIConsumer.CrudCrud<Clasificacion>.Update(ApiUrl, int.Parse(txtId.Text), new Clasificacion {
                Id = int.Parse(txtId.Text),
                Descripcion = txtClasificacion.Text
            });
        }

        private void cmdDelete_Clicked(object sender, EventArgs e)
        {
            APIConsumer.CrudCrud<Clasificacion>.Delete(ApiUrl, int.Parse(txtId.Text));
            txtClasificacion.Text = "";
            txtId.Text = "";
        }

        private string ApiUrlProd = "https://cloudcomputingapi2.azurewebsites.net/api/Productos";

        private void cmdDeleteProd_Clicked(object sender, EventArgs e)
        {
            APIConsumer.CrudCrud<Producto>.Delete(ApiUrlProd, int.Parse(txtIdProducto.Text));
            txtIdProducto.Text = "";
            txtIdProducto.Text = "";
            txtNombreProducto.Text = "";
            txtExistencia.Text = "";
            txtPrecioUnitario.Text = "";
            txtIVA.Text = "";
            txtClasificacionId.Text = "";
        }

        private void cmdUpdateProd_Clicked(object sender, EventArgs e)
        {
            APIConsumer.CrudCrud<Producto>.Update(ApiUrlProd, int.Parse(txtIdProducto.Text), new Producto
            {
                Id = int.Parse(txtIdProducto.Text),
                Nombre = txtNombreProducto.Text,
                Existencia = double.Parse(txtExistencia.Text),
                PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
                IVA = double.Parse(txtIVA.Text),
                ClasificacionId = int.Parse(txtClasificacionId.Text)
            });
        }

        private void cmdReadProd_Clicked(object sender, EventArgs e)
        {
            var prod = APIConsumer.CrudCrud<Producto>.Read_ById(ApiUrlProd, int.Parse(txtIdProducto.Text));
            if (prod != null)
            {
                txtIdProducto.Text = prod.Id.ToString();
                txtNombreProducto.Text = prod.Nombre;
                txtExistencia.Text = prod.Existencia.ToString();
                txtPrecioUnitario.Text = prod.PrecioUnitario.ToString();
                txtIVA.Text = prod.IVA.ToString();
                txtClasificacionId.Text = prod.ClasificacionId.ToString();
            }
        }

        private void cmdCreateProd_Clicked(object sender, EventArgs e)
        {
            var prod = APIConsumer.CrudCrud<Producto>.Create(ApiUrlProd, new Producto
            {
                Id = 0,
                Nombre = txtNombreProducto.Text,
                Existencia = double.Parse(txtExistencia.Text),
                PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
                IVA = double.Parse(txtIVA.Text),
                ClasificacionId = int.Parse(txtClasificacionId.Text)
            });

            if (prod != null) {
                txtIdProducto.Text = prod.Id.ToString();
            }
        }
    }
}
