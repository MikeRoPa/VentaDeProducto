/*
 * Creado por SharpDevelop.
 * Usuario: Propietario
 * Fecha: 18/01/2020
 * Hora: 01:21 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace ControlDeVenta
{
	/// <summary>
	/// Description of Venta.
	/// </summary>
	public class Venta
	{
		// Atributos
		
		private string _producto;
		private int _cantidad;
		
		// metodos GET y SET
		
		public string producto
		{
			get { return _producto; }
			set { _producto = value; }
		}
		
		public int cantidad
		{
			get { return _cantidad; }
			set { _cantidad = value; }
		}

		//Metodo: Asignando el precio a los productos
		public double asignaPrecio()
		{
			switch (producto) {
				case "Mouse":
					return 20;
				case "Teclado":
					return 35;
				case "Impresora":
					return 350;
				case "Monitor":
					return 550;
				case "Parlantes":
					return 50;
			}
			return 0;
		}
		
		// Metodo: Calculando el subtotal
		public double calculaSubtotal()
		{
			return asignaPrecio() * cantidad;
		}
		
		// Metodo: Calculando el descuento
		public double calculaDescuento()
		{
			double subtotal = calculaSubtotal();
			if (subtotal <= 300)
				return 5.0 / 100 * subtotal;
			else if (subtotal > 300 && subtotal <= 500)
				return 10.0 / 100 * subtotal;
			else
				return 12.5 / 100 * subtotal;
		}
		
		// Metodo: Calculando en neto
		public double calculaNeto()
		{
			return calculaSubtotal() - calculaDescuento();
		}
	}
	
}
