/*
 * Creado por SharpDevelop.
 * Usuario: Propietario
 * Fecha: 18/01/2020
 * Hora: 01:18 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace ControlDeVenta
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		//Inicialización del arreglo de productos
		static string[] productos = { "Teclado", "Impresora","Monitor", "Mouse","Parlantes" };
		
		//Creando el objeto de la clase ArrayList
		ArrayList aProductos = new ArrayList(productos);
		
		//Objeto de la clase venta
		Venta objV = new Venta();
		
		//Acumulador de totales
		double total;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			limpiaControles();
			llenaProductos();
			muestraFecha();
			muestraHora();
			
			lvVenta.View = View.Details;
			lvVenta.GridLines = true;
						
			lvVenta.Columns.Add("PRECIO", 200, HorizontalAlignment.Left);
			lvVenta.Columns.Add("CANT.", 83, HorizontalAlignment.Left);
			lvVenta.Columns.Add("PRECIO", 150, HorizontalAlignment.Left);
			lvVenta.Columns.Add("SUBTOTAL", 150, HorizontalAlignment.Left);
			lvVenta.Columns.Add("DESCUENTO", 150, HorizontalAlignment.Left);
			lvVenta.Columns.Add("NETO", 150, HorizontalAlignment.Left);

		}
		
		//Método que limpia los controles del formulario
		void limpiaControles()
		{
			txtCliente.Clear();
			cboProducto.Text = "(Seleccione un producto)";
			txtCantidad.Clear();
			lblPrecio.Text = "";
			lblTotal.Text = "";
			txtCliente.Focus();
		}
		
		//Llenando los productos en el cuadro combinado
		void llenaProductos()
		{
			foreach(string p in aProductos)
			{
				cboProducto.Items.Add(p);
			}
		}
		
		//Método que muestra la fecha actual
		void muestraFecha()
		{
			lblFecha.Text = DateTime.Now.ToShortDateString();
		}
		
		//Método que muestra la hora actual
		void muestraHora()
		{
			lblHora.Text = DateTime.Now.ToShortTimeString();
		}
		
		void CboProductoSelectedIndexChanged(object sender, EventArgs e)
		{
			objV.producto = cboProducto.Text;
			lblPrecio.Text = objV.asignaPrecio().ToString("C");
		}

		void BtnRegistrarClick(object sender, EventArgs e)
		{
			//Enviando los valores a la clase
			objV.producto = cboProducto.Text;
			objV.cantidad = int.Parse(txtCantidad.Text);
			
			
			
//			string[] detalleVenta = { objV.producto, objV.cantidad.ToString(),
//				                      objV.asignaPrecio().ToString("C"),
//		  	 	                      objV.calculaSubtotal().ToString("C"),
//			             	          objV.calculaDescuento().ToString("C"),
//				                      objV.calculaNeto().ToString("C")
//			                        };
//			
//			ListViewItem fila= new ListViewItem(detalleVenta);
//			lvVenta.Items.Add(fila);
			
			
			
			
			//Imprimiendo las respuestas
			ListViewItem fila = new ListViewItem(objV.producto);
			fila.SubItems.Add(objV.cantidad.ToString());
			fila.SubItems.Add(objV.asignaPrecio().ToString("C"));
			fila.SubItems.Add(objV.calculaSubtotal().ToString("C"));
			fila.SubItems.Add(objV.calculaDescuento().ToString("C"));
			fila.SubItems.Add(objV.calculaNeto().ToString("C"));
			lvVenta.Items.Add(fila);

		
			//Calculando el total de netos
			total = total + objV.calculaNeto();
			lblTotal.Text = total.ToString("C");
			
			
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			limpiaControles();
		}
	}
}
