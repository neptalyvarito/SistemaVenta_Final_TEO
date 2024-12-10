using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Libreria__FinalTEO
{
    public class Metodos
    {
        public static int MenúInicial()//metodo de tipo entero que muestra el menu inicial 
        { 
            int opc;
            Console.WriteLine("===== Menú Principal =====");
            Console.WriteLine("[1]. Productos");
            Console.WriteLine("[2]. Clientes");
            Console.WriteLine("[3]. Ventas");
            Console.WriteLine("[4]. Reportes");
            Console.WriteLine("[5]. Salir");
            Console.WriteLine("==========================");
            do // se valida que la opción sea un entero en el rango de 1 a 5
            {
                Console.Write("Ingrese una opción: ");

            } while (!int.TryParse(Console.ReadLine(), out opc) || (opc < 0 || opc > 6));
            Console.WriteLine(" ");
            return opc; //se retorna como entero la opcion que el usuario ha escogido
        }

        //***********************************************************************************

        public static char MenuProductos() //metodo de tipo char que muestra menú productos
        {
            Console.Clear(); 
            char opc;
            Console.WriteLine("===== Menú Productos ====="); 
            Console.WriteLine("[a]. Listado");
            Console.WriteLine("[b]. Registro");
            Console.WriteLine("[c]. Modificar");
            Console.WriteLine("[d]. Salir");
            Console.WriteLine("==========================");
            do
            { 
                do {  

                Console.Write("Ingrese opción: ");
                
                 } while (!char.TryParse(Console.ReadLine(), out opc));

                 opc = char.ToLower(opc);

            } while (opc != 'a' && opc != 'b' && opc != 'c' && opc != 'd'); // se valida que la opcion ingresada sea un char y no sea diferente de a,b, c ,d

            return opc; //se retorna un char como opcion del menu
        }

        public static int MenuModificarProducto(string i) //metodo de tipo int para el menu de modificacion del producto
        {
            Console.Clear();
            int opc = 0;
            Console.WriteLine("================ Modificando producto ==================");
            Console.WriteLine("Ingrese el campo que desea modificar del producto {0}", i);
            Console.WriteLine("========================================================");
            Console.WriteLine("[1]. Descripción");
            Console.WriteLine("[2]. Precio");
            Console.WriteLine("[3]. Stock");
            do
            {

                Console.Write("Ingrese una opción: ");

            } while (!int.TryParse(Console.ReadLine(), out opc) || (opc < 0 || opc > 4)); //se valida que la opcion sea un entero en el rango de 1 a 3

            return opc; //retornamos opc

        }

        public static int BuscarCodigoProducto(int[] codigoProducto) // metodo de tipo int que busca el código del producto y retorna la pos en la que se encuentra
        {
            Console.Clear();
            Procedimientos.ListarProductos(); //Se muestra el listado de productos para que el cliente se guie si se olvidó el código del producto

            int indice = -1;
            int codigoBuscar;

            Console.WriteLine("\n\n================================ Buscando Producto ===================================");
            Console.WriteLine("\nEn caso aún no haya algún producto registrado ingrese el número \"(-2)\""); //se le advierte al cliente que si aun no ha ingresado algun producto, puede regresar al menu ingresando -2
            Console.WriteLine("para volver\n");
            do
            {
                Console.Write("Ingrese código del producto: ");

            } while (!int.TryParse(Console.ReadLine(), out codigoBuscar)); // se verifica que el codigo a buscar sea un entero

            for (int i = 0; i < codigoProducto.Length; i++)
            {
                if (codigoBuscar == -2)  //si indice es igual a -2, el cliente regresa al menú previo
                {
                    indice = -2; break; 
                }
                else if (codigoProducto[i] == codigoBuscar) //si se encuentra el codigo, el indice se retornará como la pos del arreglo
                { 
                indice = i;
                }
            }
            return indice;
        }

        //*****************************************************************

        public static char MenuCliente() //metodo de tipo char que muestra el menu de clientes
        {
            Console.Clear();
            char opc;
            Console.WriteLine("===== Menú Clientes =====");
            Console.WriteLine("[a]. Listado");
            Console.WriteLine("[b]. Registro");
            Console.WriteLine("[c]. Modificar");
            Console.WriteLine("[d]. Salir");
            Console.WriteLine("==========================");
            do
            {
                do
                {
                    Console.Write("Ingrese opción: ");
                } while (!char.TryParse(Console.ReadLine(), out opc));
                opc = char.ToLower(opc);
            } while (opc != 'a' && opc != 'b' && opc != 'c' && opc != 'd'); //se valida que opc sea un char y no sea diferente de a, b, c o d
            return opc; // se retorna opc
        }
        public static int MenuModificarClientes(string i) //metodo de tipo int que muestra el menu para modificar clientes
        {
            Console.Clear();
            int opc = 0;
            Console.WriteLine("================ Modificando cliente ==================");
            Console.WriteLine("Ingrese el campo que desea modificar del cliente {0}", i);
            Console.WriteLine("========================================================");
            Console.WriteLine("[1]. Nombre");
            Console.WriteLine("[2]. Dirección");
            Console.WriteLine("[3]. Correo");
            do
            {
                Console.Write("Ingrese una opción: ");

            } while (!int.TryParse(Console.ReadLine(), out opc) || (opc < 0 || opc > 4)); //se valida que opc sea un entero y este en el rango de 1 a 3;

            return opc; //se retorna opc

        }
        public static int BuscarCodigoCliente(int[] codigoCliente) // metodo de tipo int que busca el código del cliente y retorna la pos en la que se encuentra
        {
            Console.Clear(); 

            Procedimientos.ListarClientes(); //Se muestra el listado de clientes para que el cliente se guie si se olvidó el código del producto

            int indice = -1;
            int codigoBuscar;
            Console.WriteLine("\n\n================================= Buscando Cliente ====================");
            Console.WriteLine("\nEn caso aún no haya algún cliente registrado ingrese el número \"(-2)\"");//se le advierte al cliente que si aun no ha ingresado algun cliente, puede regresar al menu ingresando -2
            Console.WriteLine("para volver\n");
            do
            {

                Console.Write("Ingrese código del cliente: ");

            } while (!int.TryParse(Console.ReadLine(), out codigoBuscar)); // se valida que el codigo a buscar sea un entero

            for (int i = 0; i < codigoCliente.Length; i++)
            {
                if (codigoBuscar == -2) //en caso ingrese  -2 se le enviara al menu previo
                {
                    indice = -2;
                    break;
                }
                else if (codigoCliente[i] == codigoBuscar) //en caso encuentre el codigo, el indice se retornará
                {
                    indice = i;
                }
            }
            return indice; //se retorna indice
        }

        //*************************************************************************************************************
        public static int MenuReportes() //metodo de tipo entero que muestra el menu para reportes
        {
            int opc;

            Console.WriteLine("======== Menú Reportes ========");
            Console.WriteLine("[1] Top clientes más vendidos");
            Console.WriteLine("[2] Top productos más vendidos");
            Console.WriteLine("[3] Ventas");
            Console.WriteLine("[4] Volver");
            Console.WriteLine("===============================");
            do
            {

                Console.Write("Ingrese opción: ");

            }while(!int.TryParse(Console.ReadLine(), out opc)|| (opc>4 || opc<0)); // se valida que opc sea un entero dentro del ragno de 1 a 4


            return opc; // se retorna opc
        }


    }

}
