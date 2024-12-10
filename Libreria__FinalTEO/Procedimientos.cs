using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Libreria__FinalTEO
{
    public class Procedimientos
    {
        
        public static int[] codigoProducto = new int[1];  //Arreglo publico estatico que servirá para almacenar los códigos de productos ingresados
        public static int[] contadorProVendidos = new int[10000];//contador que servirá para saber y almacenear la cantidad de veces que se está vendiendo cada producto
        public static int[] stockProducto = new int[1];//Arreglo público que servirá para almacenar el stock que se ingrese a cada producto
        public static int CantidadDeProdutosExistentes = 0;//Contador que nos ayudará a saber la cantidad de diferentes productos que se han registrado
        public static double[] precioProducto = new double[1]; //Arreglo publico para almacenar el precio de cada producto
        public static string[] descripcion = new string[1]; //Arreglo publico donde se almacenará el nombre de cada producto


        public static int[] codigoCliente = new int[1];//Arreglo público que servirá para almancenar los códigos de clientes
        public static int CantidadDeClientesExistentes = 0;//Contador que nos ayudará a saber la cantidad de diferentes clientes que se han registrado
        public static string[] nombreCliente = new string[1];//Arreglo público que servirá para almancenar los nombres de clientes
        public static string[] direccionCliente = new string[1];//Arreglo público que servirá para almancenar las direcciones de los clientes
        public static string[] correoCliente = new string[1];//Arreglo público que servirá para almancenar los correos de clientes

        public static int CantidadVentas = 0; //entero que nos servirá para ubicar posición en las filas dentro de nuestra matriz

        public static double[] pagoFinalxCliente = new double[10000];//Arreglo publico que nos servirá pasar almacenar el monto que el usuario está pagando al final de cada compra
        public static string[,] ventas = new string[CantidadVentas,6];//matriz donde se almancenará las ventas con las respectivas especificaciones como cliente, producto, precio y total por compra
        public static DateTime Fecha = DateTime.Now;//variable de tiempo que representa el día


        public static void Consola()//Procedimiento consola, reemplaza el programm inicial, de modo que no se nos robe ni una linea de código
        {

            int opc = 0; //creamos la variable opc 
            opc = Metodos.MenúInicial(); //se retorna un valor entero, el cual se le asiga a opc ocacionando que se ejecute el switch y con el nuestro programa

            while (opc != 5) //Se valida que sea diferente de 5 para que pueda iniciarse el programa, en caso contrario el programa terminará
            {
             
                switch (opc) //se condiciona opc
                {
                    case 1:

                        ProductosEjecución(); //Causa la ejecución de la lógica para la opción productos

                        break;

                    case 2:

                        ClientesEjecucion(); //Causa la ejecución de la lógica para la opción clientes

                        break;

                    case 3:

                        VentasEjecucion(); //Causa la ejecución de la lógica para la opción ventas

                        break;

                    case 4:

                        ReportesEjecucion();  //Causa la ejecución de la lógica para la opción reportes

                        break;

                }
                
                Console.Clear(); //limpiamos consola cada vez que el usuario retorne al menú inicial
                opc = Metodos.MenúInicial(); // se muestra el menú inicial, permitiendo al usuario elegir otras opciones iniciales
            }
        }


        //**************************************************************************************************************************************
        //                                                       Productos
        //**************************************************************************************************************************************
       
        public static void ProductosEjecución() //Ejecución de toda la lógica para la opción productos
        {
            char opc = ' '; //se crea la variable opc de tipo char
            opc = Metodos.MenuProductos(); //se retorna un tipo char, asignando dicho valor a la variable opc

            while (opc != 'd')//se condiciona la variable opc, ocasionando el uso de los diferentes casos dentro del switch o saliendo de esta parte del programa
            {
                switch (opc)
                {
                    case 'a':
                        ListarProductos(); //se da el listamiento de productos
                        break;
                    case 'b': 
                        RegistrarProducto(); //se da el registramiento de productos
                        break;
                    case 'c':
                        ModificarProducto(); // se da la modificación de productos
                        break;
                }
                Console.ReadLine(); //hacemos una pausa
                Console.Clear(); //limpiamos consola para dar paso nuevamente al menú
                opc = Metodos.MenuProductos(); //mostramos menú y que el usuario pueda elegir nuevamente su opción
            }
        }
       
        public static void ListarProductos() //procedimiento para ordenar los productos registrados
        {
            Console.Clear(); //limpiamnos consola

            Console.WriteLine("======================== Lista de productos ===========================");//titulo de nuestro cuadro
            Console.WriteLine("=======================================================================");


            Console.Write("{0}", "Código de Producto".PadRight(25, ' '));
            Console.Write("{0}", "|Descripción".PadRight(25, ' '));                             //Imprimimos las cabeceras de nuestro cuadro
            Console.Write("{0}", "|Precio".PadRight(15, ' '));
            Console.Write("{0}", "|Stock".PadRight(10, ' '));
            Console.Write("\n");
            Console.Write("=======================================================================");

            for (int i = 0; i < codigoProducto.Length - 1; i++) //se inicia un for, donde se use i es menor a la longitud del codigo de producto, pues cada codigo creado 
            {                                                   //suma 1 en longitud al arreglo codigoProducto, en cierto modo, nos permite conocer la cantidad de productos registrados
            

                Console.Write("\n");
                Console.Write("\n");
                Console.Write("{0}", codigoProducto[i].ToString().PadRight(25, ' '));
                Console.Write("{0}", "|" + descripcion[i].PadRight(24, ' '));                    //Imprimos los productos, sus descripciones, sus precios y los stocks por cada posición 
                Console.Write("{0}", "|" + precioProducto[i].ToString().PadRight(14, ' '));
                Console.Write("{0}", "|" + stockProducto[i].ToString().PadRight(9, ' '));

            }
            Console.Write("\n=======================================================================");
        }

        public static void RegistrarProducto() //procemiento para registrar productos
        {
            Console.Clear(); //limpiamos consola
            Console.WriteLine("========= Registrar Productos ========="); //titulo
            Console.WriteLine("=======================================");
            do
            {
                Console.Write("\nIngrese el código del producto: "); //pedimos que se ingrese el codigo del producto, este deberá ser un entero

            } while (!int.TryParse(Console.ReadLine(), out codigoProducto[codigoProducto.Length - 1]));//validación de entero y almacenamiento desde la posición 0, 1,...

            Console.Write("Ingrese descripción           : "); //pedimos que se ingrese la descripción del producto, no hay que validar, es un string
            descripcion[descripcion.Length - 1] = Console.ReadLine(); //se almacena en el arreglo descripción 

            do
            {

                Console.Write("Ingrese precio                : ");//pedimos que se ingrese el precio, este será double, en caso sea .00 se tomará como entero, no hay problema

            } while (!double.TryParse(Console.ReadLine(), out precioProducto[precioProducto.Length - 1])); //validacion de que sea double, se almacena en el arreglo precio

            do
            {

                Console.Write("Ingrese stock                 : ");//pedimos que se ingrese el stock del producto, debe ser un entero

            } while (!int.TryParse(Console.ReadLine(), out stockProducto[stockProducto.Length - 1])); //validamos que sea un entero, se almacena dentro del arreglo stock

            Console.WriteLine("\n====== El producto {0} fue registrado con exito!", descripcion[descripcion.Length - 1]); //se alerta al usuario que el producto fue registrado con exito

            CantidadDeProdutosExistentes++; //aumentamos en 1 la cantidad de productos existentes
            Array.Resize(ref descripcion, descripcion.Length + 1); //aumentamos la longitud del arreglo con el metodo array.resize
            Array.Resize(ref codigoProducto, codigoProducto.Length + 1);//aumentamos la longitud del arreglo con el metodo array.resize
            Array.Resize(ref stockProducto, stockProducto.Length + 1);  //aumentamos la longitud del arreglo con el metodo array.resize
            Array.Resize(ref precioProducto, precioProducto.Length + 1);//aumentamos la longitud del arreglo con el metodo array.resize
           
        }

        public static void ModificarProducto() //procedimiento para modificar algún valor del producto
        {
            int indice = -1; //creamos la variable indice y la inicializamos en -1
            int opc = 0;
            while (indice == -1) //si indice es igual a -1, significa que el codigo está mal digitado o no existe. Se crea un bucle hasta que se ingrese el codigo correcto
            {
                indice = Metodos.BuscarCodigoProducto(codigoProducto); //se retorna un entero, se le asigna a indice, donde ese entero será la posición del producto
                if (indice == -2) break; //en caso se retorne -2, significa que el usuario aún no ha ingresado nigun producto y por ende no existe ningun codigo registrado
                else if (indice == -1) Console.WriteLine("\nUp Algo salio mal...."); //advertencia de que el código está mal digitado
                
            }
            if (indice != -2) //en caso el cliente no haya ingresado -2 y si exista algún código sucederá lo siguiente:
            {
                opc = Metodos.MenuModificarProducto(descripcion[indice]); //se retorna un valor entero del menú para ingresar que se desea modificar del producto
                switch (opc) //se condiciona opc
                {
                    case 1: //cambiar descripcion

                        modificarDescripcion(indice); //se manda indice del producto para poder modificarlo en aquella posición

                        break;

                    case 2: //cambiar precio

                        modificarPrecio(indice);//se manda indice del producto para poder modificarlo en aquella posición

                        break;

                    case 3://cambiar stock

                        modificarStock(indice);//se manda indice del producto para poder modificarlo en aquella posición

                        break;

                }
                Console.WriteLine("\nModificación exitosa!"); // Se notifica que la modificación fue exitosa
            }
        }
        public static void modificarDescripcion(int i) //procedimiento para modificar la descripción del producto en la posición i
        {
            Console.Clear(); //limpiamos consola

            string nuevaDescripcion = ""; //creamos la variable para la nueva descripción

            Console.WriteLine("========= Modificando la descripción del producto {0}", descripcion[i] + " ========="); //titulo
            Console.WriteLine("===================================================================================");

            Console.Write("Ingrese la nueva descripción del producto : ");

            nuevaDescripcion = Console.ReadLine(); 
            descripcion[i] = nuevaDescripcion; // se le asigna la nueva descripción al producto en la posición i;
        }
        public static void modificarPrecio(int i) //procedimiento para modificar el precio del producto en la posición i
        {
            Console.Clear(); //limpiamos consola
            double nuevoPrecio = 0.0; //creamos la variable para el nuevo precio
            Console.WriteLine("========= Modificando el precio del producto {0}", descripcion[i] + " ========="); //titulo
            Console.WriteLine("===================================================================================");
            do
            {

                Console.Write("Ingrese el nuevo precio del producto : "); //pedimos que se ingrese el nuevo precio

            } while (!double.TryParse(Console.ReadLine(), out nuevoPrecio));

            precioProducto[i] = nuevoPrecio; //asignamos el valor del nuevo a precio al producto en la posición i

        }
        public static void modificarStock(int i) //procedimiento para modificar el stock 
        {
            Console.Clear(); //limpiamos consola
            int nuevoStock = 0; //creamos variable para almacenar el nuevo stock
            Console.WriteLine("========= Modificando el stock del producto {0}", descripcion[i] + " =========");
            Console.WriteLine("==================================================================================");

            do
            {

                Console.Write("Ingrese el nuevo stock del producto : ");

            }
            while (!int.TryParse(Console.ReadLine(), out nuevoStock)); //validamos que sea un entero
            stockProducto[i] = nuevoStock; //asignamos el nuevo stock al producto en la posición i
        }

        //**************************************************************************************************************************************
        //                                                     Clientes
        //**************************************************************************************************************************************

   
        public static void ClientesEjecucion() //se inicia toda la lógica para la ejecución de la opción clientes
        {
            char opc = ' ';
            opc = Metodos.MenuCliente(); //se llama al metodo MenuCliente que retorna un char, el cual será la opción que usuario ha ingresado
            while (opc != 'd') //si es d, se vuelve al menu inicial
            {
                switch (opc) // Se hace un switch para ejecutar la opción que el cliente haya escogido
                {
                    case 'a':
                        ListarClientes(); //se lista los clientes
                        break;
                    case 'b':
                        RegistrarClientes(); //se registran clientes
                        break;
                    case 'c':
                        ModificarCliente(); //se modifican clientes
                        break;
                } 
                Console.ReadLine(); //para para leer
                Console.Clear(); // limpiamos consola
                opc = Metodos.MenuCliente(); //se muestra nuevamente menu de clientes para que el usuario pueda elegir otra opción
            }
        }

        public static void ListarClientes() //procedimiento para listar clientes
        {

            Console.Clear(); //limpiamos consola para dar paso a la lista de clientes

            Console.WriteLine("==================================== Lista de clientes =======================================");
            Console.WriteLine("=============================================================================================="); //titulo


            Console.Write("{0}", "Código del cliente".PadRight(25, ' '));
            Console.Write("{0}", "|Nombre".PadRight(25, ' '));
            Console.Write("{0}", "|Dirección".PadRight(30, ' '));                   //encabezados de nuestra tabla
            Console.Write("{0}", "|Correo".PadRight(30, ' '));
            Console.Write("\n");
            Console.Write("==============================================================================================");
            Console.Write("\n");
            Console.Write("\n");

            for (int i = 0; i < codigoCliente.Length - 1; i++)
            {
              
               
                Console.Write("{0}", codigoCliente[i].ToString().PadRight(25, ' '));
                Console.Write("{0}", "|" + nombreCliente[i].PadRight(24, ' '));                 //imprimimos los clientes con las respectivas variables, nombre, dirección, codigo y correo
                Console.Write("{0}", "|" + direccionCliente[i].ToString().PadRight(29, ' '));
                Console.Write("{0}", "|" + correoCliente[i].ToString().PadRight(29, ' '));
                Console.Write("\n");
                Console.Write("----------------------------------------------------------------------------------------------");
                Console.Write("\n");
            }
            Console.Write("==============================================================================================");
        }

        public static void RegistrarClientes()  //procedimiento para resgistrar clientes
        {
            Console.Clear(); //limpiamos consola
            Console.WriteLine("========= Registrar Clientes =========");//titulo
            Console.WriteLine("=======================================");
            do
            {
                Console.Write("\nIngrese el código del cliente: "); //se ingresa el codigo de tipo entero

            } while (!int.TryParse(Console.ReadLine(), out codigoCliente[codigoCliente.Length - 1])); // se valida que sea entero y se almacena en codigoCliente en la pos 0,1,2...
            do
            {
                Console.Write("Ingrese el nombre del cliente: "); //pedimos que se ingrese el nombre del cliente
                nombreCliente[nombreCliente.Length - 1] = Console.ReadLine(); 
            } while (nombreCliente[nombreCliente.Length - 1] == " ");//validamos que el nombre no sea un simple espacio 
            do
            {
                Console.Write("Ingrese dirección del cliente: ");//pedimos que se ingrese la direccion del cliente
                direccionCliente[direccionCliente.Length - 1] = Console.ReadLine();
            } while (nombreCliente[direccionCliente.Length - 1] == " ");//validamos que el nombre no sea un simple espacio 

            do
            {
                Console.Write("Ingrese correo del cliente   : ");//pedimos que se ingrese el correo del cliente
                correoCliente[correoCliente.Length - 1] = Console.ReadLine();
            } while (correoCliente[correoCliente.Length - 1] == " "); //validamos que el nombre no sea un simple espacio 


            Console.WriteLine("\nEl cliente {0} fue registrado con exito!", nombreCliente[nombreCliente.Length - 1]);


            CantidadDeClientesExistentes++; //aumentamos en 1 la cantidad de clientes que existen 
            Array.Resize(ref nombreCliente, nombreCliente.Length + 1); //aumentamos la longitud en 1 de cada arreglo para clientes
            Array.Resize(ref codigoCliente, codigoCliente.Length + 1); //aumentamos la longitud en 1 de cada arreglo para clientes
            Array.Resize(ref direccionCliente, direccionCliente.Length + 1);    //aumentamos la longitud en 1 de cada arreglo para clientes
            Array.Resize(ref correoCliente, correoCliente.Length + 1); //aumentamos la longitud en 1 de cada arreglo para clientes
        }
        public static void ModificarCliente() //procedimiento para modificar algún campo de los clientes
        {
            int indice = -1; //creamos la variable indice de tipo int, la cual nos servirá para saber la pos del arreglo
            int opc = 0; //creamos la variable tipo int
            while (indice == -1)
            {

                indice = Metodos.BuscarCodigoCliente(codigoCliente); //si indice retorna -1 el bucle se repite hasta encontrar un codigo que exista y la pos de este
                if (indice == -2) break; //en caso retorne -2, se ocasiona un break
               else  if (indice == -1) Console.WriteLine("\nUps! Algo salio mal...."); //se alarte que el codigo de existe para -1

            }
            if (indice != -2) //si indice no es -2 se ejectura lo siguiente, en caso sea -2 retorna al menu anterior
            {
                opc = Metodos.MenuModificarClientes(nombreCliente[indice]); // retorna un valor de int, de modo que este sea la opción que usuario ha elegido dentro del menu

                switch (opc) //se condiciona opc
                {
                    case 1: //cambiar descripcion

                        modificarNombreCliente(indice);     

                        break;

                    case 2: //cambiar precio

                        modificarDirecciónCliente(indice);

                        break;

                    case 3://cambiar stock

                        modificarCorreoCliente(indice);

                        break;

                }
                Console.WriteLine("\nModificación exitosa!"); //se notifica que la modificación fue un exito
            }
        }

        public static void modificarNombreCliente(int i) //procemiento para modificar el nombre de un cliente, en obtiene como parametro la pos del arreglo
        {
            Console.Clear(); //limpiamos consola
            string nuevoNombre = ""; //nueva variable para el nuevo nombre
            Console.WriteLine("========= Modificando el nombre del cliente {0}", nombreCliente[i] + " =========");
            Console.WriteLine("===================================================================================");
            Console.Write("Ingrese el nuevo nombre del cliente: "); //se pide ingresar el nuevo nombre
            nuevoNombre = Console.ReadLine(); 
            nombreCliente[i] = nuevoNombre; // se asigna el nuevo nombre al cliente en la pos i;
        }

        public static void modificarDirecciónCliente(int i)
        {
            Console.Clear();
            string nuevaDireccion = "";
            Console.WriteLine("========= Modificando la dirección del cliente {0}", nombreCliente[i] + " =========");
            Console.WriteLine("===================================================================================");
            Console.Write("Ingrese la nueva dirección del cliente: "); //se pide ingresar la nueva dirección
            nuevaDireccion = Console.ReadLine();
            direccionCliente[i] = nuevaDireccion;// se asigna la nueva dirección al cliente en la pos i;
        }
        public static void modificarCorreoCliente(int i)
        {
            Console.Clear();
            string nuevoCorreo = "";
            Console.WriteLine("========= Modificando el correo del cliente {0}", nombreCliente[i] + " =========");
            Console.WriteLine("===================================================================================");
            Console.Write("Ingrese el nuevo correo del cliente: "); // se pide ingresar el nuevo correo
            nuevoCorreo = Console.ReadLine();
            correoCliente[i] = nuevoCorreo;// se asigna el nuevo correo al cliente en la pos i;
        }

        //*******************************************************************************************************************************
        //                                                          Ventas 
        //*******************************************************************************************************************************

        public static void VentasEjecucion() //ejecuta toda la logica para ventas
        {
            int indice = -1; //se crea la variable indice
            int NumeroProd, CantidadProd; // se crean variables, para el número del producto que el cliente desea ingresar y otro para la cantidad que comprará
            double acumuladorPagoTotalxProd = 0; //se crea una variable que acumulará lo que debe pagar cada cliente en todas las iteraciones de la compra
            double pagoTotalxProd = 0; //variable que representa lo que cada cliente debe pagar para cada iteración, más no acumula
            string respuesta = "SI"; //respuesta a seguir comprando o no

            while (indice == -1)
            {
                indice = Metodos.BuscarCodigoCliente(codigoCliente); //se busca el indice del cliente
                if (indice == -2) break; //en caso sea -2 se le envia al menu previo
                else if (indice == -1) Console.WriteLine("\nUps! Algo salio mal....");
            }
            if (indice != -2) // si indice es diferente a -2 secederá lo siguiente:
            {
                do
                {
                    Console.Clear();

                    Console.WriteLine("\n...Bienvenido(a) cliente {0}", nombreCliente[indice]);
                    Console.WriteLine("\nPor favor, ingrese el producto y la cantidad que desea llevar!\n");

                    ListaProParaVenta();
                    do
                    {
                        Console.Write("\n\nIngrese el N° del producto que comprará: "); //se pide el numero del producto que desea llevar y se valida que este no sea mayor a la cantidad de productos existentes

                    } while (!int.TryParse(Console.ReadLine(), out NumeroProd) || (NumeroProd < 0 || NumeroProd > CantidadDeProdutosExistentes)); 
                    do
                    {

                        Console.Write("\nIngrese cantidad de productos que comprará: "); //se pide la cantidad que llevará y se valida que esta cantidad no sea mayor al stock

                    } while (!int.TryParse(Console.ReadLine(), out CantidadProd) || (CantidadProd<0 || CantidadProd> stockProducto[NumeroProd-1]));


                    NumeroProd--; //se le resta 1 para poder usarlo como indice

                    //se acumula la cantiadad de unidades se ha comprado por cada producto
                    contadorProVendidos[NumeroProd]+=CantidadProd; //se acumula las unidades vendidas de cada producto en su posicón

                    //cuanto se va a pagar por cada compra que se haga, teniendo el cuenta la cantidad y el costo unitario del producto
                    pagoTotalxProd = CantidadProd * precioProducto[NumeroProd]; //el pago que hará el cliente para esta compra

                    //acumla el total que sale por cada producto y la cantidad comprada de este
                    acumuladorPagoTotalxProd += pagoTotalxProd;//se acumula el pago que hará cada cliente en su respectiva posición por cada compra que haga

                    //pago que realizará el cliente al finalizar su compra hasta que ingresa "NO"
                    //se usa para imprimir la lista de ventar de reportes
                    pagoFinalxCliente[indice] += pagoTotalxProd; //se le atribuye el pago que hará el cliente para esta compra 

                    ventas[CantidadVentas, 0] = Fecha.ToString(); //se le asigna la fecha en la posicion de la matriz

                    ventas[CantidadVentas, 1] = nombreCliente[indice].ToString(); //se le asigna el nombre del cliente en la posicion de la matriz

                    ventas[CantidadVentas, 2] = descripcion[NumeroProd].ToString(); //se le asigna la descripción en la posicion de la matriz

                    ventas[CantidadVentas, 3] = CantidadProd.ToString(); //se le asigna la cantidad de producto en la posicion de la matriz

                    ventas[CantidadVentas, 4] = precioProducto[NumeroProd].ToString(); //se le asigna el precio en la posicion de la matriz

                    ventas[CantidadVentas, 5] = pagoTotalxProd.ToString(); //se le asigna el pago total por producto en esta compra en la posicion de la matriz

                    stockProducto[NumeroProd] = stockProducto[NumeroProd] - CantidadProd; //se le asigna el stock en la posicion de la matriz

                    do
                    {
                        Console.Write("\n¿Desea continua? (si/no): "); // se consulta si desea continua con otra compra o no

                        respuesta = Console.ReadLine();
                        respuesta = respuesta.ToUpper();

                        if (respuesta == "NO") break; //en caso sea no, se ocasiona un break

                    } while (respuesta != "NO" && respuesta != "SI");

                    CantidadVentas++;

                } while (respuesta == "SI");

                Console.WriteLine("\n=============== El total a pagar es de: " + acumuladorPagoTotalxProd); //se muestra el total a pagar por las compras que se dieron mientras que usuario ingreso si
                Console.ReadLine();
            }
        }
      
        public static void ListaProParaVenta() //procedimiento para mostrar la lista de producto para las ventas
        {

            Console.Write("\n");
            Console.WriteLine("======================== Lista de productos ===========================");
            Console.WriteLine("=======================================================================");
            Console.Write("{0}", "N°  ".PadRight(5, ' ')); 
            Console.Write("{0}", "|Descripción".PadRight(25, ' ')); //s muestran las cabeceras de nuestra tabla
            Console.Write("{0}", "|Precio".PadRight(15, ' '));
            Console.Write("{0}", "|Stock".PadRight(10, ' '));
            Console.Write("\n");
            Console.Write("=======================================================================");
            Console.Write("\n");
            Console.Write("\n");

            for (int i = 0; i < codigoProducto.Length - 1; i++)
            {

               
                Console.Write("{0}", (i + 1).ToString().PadRight(5, ' '));
                Console.Write("{0}", "|" + descripcion[i].PadRight(24, ' '));
                Console.Write("{0}", "|" + precioProducto[i].ToString().PadRight(14, ' ')); //se muestran los productos con sus respectivos componenentes
                Console.Write("{0}", "|" + stockProducto[i].ToString().PadRight(9, ' '));
                Console.Write("\n");
                Console.Write("---------------------------------------------------------------------");
                Console.Write("\n");

            }
            Console.Write("\n=======================================================================");

        }

        //**************************************************************************************************************************************
        //                                                     Reportes
        //**************************************************************************************************************************************

        public static void ReportesEjecucion() //se ejecuta toda la logica para la opcion reportes 
        {
            Console.Clear(); //limpiamos consola
            int opc;
            opc = Metodos.MenuReportes(); //se le asigna un valor entero a opc

            while (opc != 4) //se condiciona opc
            {
                switch (opc)
                {
                    case 1:
                        TopClientes(); //ejecuta top clientes
                        break;
                    case 2:
                        TopVentas(); //ejecuta top ventas
                        break;
                    case 3:
                        ImprimirVentas(); //ejecuta imprimir las ventas hechas en el día
                        break;

                }
                Console.ReadLine();
                Console.Clear();
                opc = Metodos.MenuReportes();
            }
            Console.ReadLine();
        }
        public static void ImprimirVentas() //procemiento para imprimir las ventas
        {
            Console.Clear();
            Console.WriteLine("===================================================================== Ventas =====================================================================================");
            Console.WriteLine("==================================================================================================================================================================");

            Console.Write("{0}", "|Fecha".PadRight(31, ' '));
            Console.Write("{0}", "|Cliente".PadRight(31, ' '));
            Console.Write("{0}", "|Producto".PadRight(31, ' '));
            Console.Write("{0}", "|Cantidad".PadRight(31, ' '));  //cabeceras para nuestra tabla
            Console.Write("{0}", "|Precio".PadRight(31, ' '));
            Console.Write("{0}", "|Total".PadRight(31, ' '));
            Console.Write("\n");
            Console.Write("==================================================================================================================================================================");



            for (int i = 0; i < CantidadVentas; i++)
            {
                Console.Write("\n");

                for (int j = 0; j < ventas.GetLength(1); j++)
                {

                    Console.Write("|" + ventas[i, j].PadRight(30, ' ')); // se imprime la matriz, que contiene cada componene correspondiente a los productos y a las matrices

                }
            }


        }
        public static void TopClientes() //procedemiento para top clientes sobre quien gasto más y menos
        {
            int N;
            
            //+****método burbuja

            for (int i = 0; i<CantidadDeClientesExistentes-1; i++)  //hacemos for con la cantidad de clientes existentes
            {
                for (int j = i+1; j < CantidadDeClientesExistentes; j++) 
                {
                    if (pagoFinalxCliente[i] < pagoFinalxCliente[j])//ordenamos todo cuando lo gastado en la pos i, sea menor a lo gastado en la pos i+1
                    {
                        double auxVent = pagoFinalxCliente[j];
                        pagoFinalxCliente[j] = pagoFinalxCliente[i]; //de este modo se ordena todo junto, haciendo que sigan correspondiendo al mismo cliente, pero en otra posición
                        pagoFinalxCliente[i] = auxVent;

                        string auxNom = nombreCliente[j];
                        nombreCliente[j] = nombreCliente[i];
                        nombreCliente[i] = auxNom;

                        int auxCod = codigoCliente[j];
                        codigoCliente[j] = codigoCliente[i];
                        codigoCliente[i] = auxCod;

                        string auxDirec = direccionCliente[j];
                        direccionCliente[j] = direccionCliente[i];
                        direccionCliente[i] = auxDirec;

                        string auxCorr = correoCliente[j];
                        correoCliente[j] = correoCliente[i];
                        correoCliente[i] = auxCorr;
                    }
                }
            }
         
            Console.Clear(); //limpiamos consola
            Console.WriteLine("\n**ADVERTENCIA** La longitud de la lista no puede superar la cantidad de clientes existentes."); 
            Console.WriteLine("=============== La cantidad de clientes existentes es : " + CantidadDeClientesExistentes); // se le avisa al usario el que top no puede ser mayor a la cantidad de clientes existentes
            do
            {
                
                Console.Write("\nIngrese el tamaño de lista top de clientes: "); //se pide ingresar el tamaño del top

            } while (!int.TryParse(Console.ReadLine(), out N) || N<1 || N>CantidadDeClientesExistentes); // se valida que el tamaño del for no sea mayor a la cantidad de clientes existentes


            Console.Write("\n");
            Console.WriteLine("======================== Top {0} Clientes ===========================", N); //cabecera para el top clientes
            Console.WriteLine("==================================================================="); 
            Console.Write("{0}", "   Cliente  ".PadRight(30, ' '));
            Console.Write("{0}", "   |Cantidad de dinero invertido".PadRight(25, ' '));
            Console.Write("\n"); 

            Console.Write("===================================================================");

            for (int i = 0; i<N; i++) //se inicia un for que imprima el top de clientes
            {
               
                Console.Write("\n");
                Console.Write("{0}", (i+1) + " | " + nombreCliente[i].PadRight(30, ' ')); //se imprime el nombre 
                Console.Write("{0}", "|" + pagoFinalxCliente[i].ToString().PadRight(24, ' ')); //se imprime la cantidad que gasto

            }

        }
        public static void TopVentas()
        {
            //+****método burbuja
            int N;
            for (int i = 0; i < CantidadDeProdutosExistentes-1; i++)  //hacemos for con la cantidad de productos existentes
            {
                for (int j = i + 1; j < CantidadDeProdutosExistentes; j++)
                {
                    if (contadorProVendidos[i] < contadorProVendidos[j])//ordenamos todo cuando lo gastado en la pos i, sea menor a lo gastado en la pos i+1
                    {

                        int auxVent = contadorProVendidos[j];
                        contadorProVendidos[j] = contadorProVendidos[i]; //de este modo se ordena todo junto, haciendo que sigan correspondiendo al mismo producto, pero en otra posición
                        contadorProVendidos[i] = auxVent;

                        string auxDes = descripcion[j];
                        descripcion[j] = descripcion[i];
                        descripcion[i] = auxDes;

                        int axucod = codigoProducto[j];
                        codigoProducto[j] = codigoProducto[i];
                        codigoProducto[i] = axucod;

                        double axuPrec = precioProducto[j];
                        precioProducto[j] = precioProducto[i];
                        precioProducto[i] = axuPrec;

                        int auxstock = stockProducto[j];
                        stockProducto[j] = stockProducto[i]; //hola profe :D
                        stockProducto[i] = auxstock;
                    }
                }
            }

            Console.Clear();

            Console.WriteLine("\n**ADVERTENCIA** La longitud de la lista no puede superar la cantidad de productos existentes.");
            Console.WriteLine("=============== La cantidad de productos existentes es : " + CantidadDeProdutosExistentes); // se le avisa al usario el que top no puede ser mayor a la cantidad de productoss existentes
            do
            {

                Console.Write("\nIngrese el tamaño de lista top de ventas: ");//se pide ingresar el tamaño del top

            } while (!int.TryParse(Console.ReadLine(), out N) || N < 1 || N > CantidadDeProdutosExistentes); // se valida que el tamaño del for no sea mayor a la cantidad de productos existentes

            Console.Write("\n");
            Console.WriteLine("=========================== Top {0} productos ===========================", N);//cabecera para el top productos
            Console.WriteLine("=======================================================================");
            Console.Write("{0}", "   Producto  ".PadRight(30, ' '));
            Console.Write("{0}", "    |Cantidad vendidos".PadRight(25, ' '));
            Console.Write("\n");

            Console.Write("=======================================================================");
            for (int i = 0; i < N; i++)
            {
                Console.Write("\n");
                Console.Write("{0}", (i+1)+ " |"+ descripcion[i].PadRight(30, ' ')); //se imprime el nombre del producto
                Console.Write("{0}", "|" + contadorProVendidos[i].ToString().PadRight(24, ' ')); //se imprime cuantas unidades de este se imprimió 
            }

        }
    }
}
