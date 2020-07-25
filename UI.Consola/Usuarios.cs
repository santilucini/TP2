using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }
        public UsuarioLogic UsuarioNegocio { get; set; }

        public void Menu()
        {

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("1) Listado General");
                Console.WriteLine("2) Consulta");
                Console.WriteLine("3) Agregar");
                Console.WriteLine("4) Modificar");
                Console.WriteLine("5) Eliminar");
                Console.WriteLine("6) Salir");
                Console.Write("Ingrese Opcion Deseada: ");

                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        {
                            ListadoGeneral();
                            break;
                        }
                    case 2:
                        {
                            Consultar();
                            break;
                        }
                    case 3:
                        {
                            Agregar();
                            break;
                        }
                    case 4:
                        {
                            Modificar();
                            break;
                        }
                    case 5:
                        {
                            Eliminar();
                            break;
                        }
                    case 6:
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Oopcion no Valida");
                            Console.ReadLine();
                            break;
                        }


                }
            } while (opcion != 6);
        }
        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
            Console.WriteLine("Presione alguna tecla para continuar...");
            Console.ReadLine();
        }
        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tMail: {0}", usr.EMail);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID de Usuario a Consultar: ");
                int id = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(id));
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Presione alguna tecla para continuar...");
                Console.ReadLine();
            }
        }       

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID de Usuario a Modificar: ");
                int id = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(id);
                Console.WriteLine("Ingrese Nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese Email: ");
                usuario.EMail = Console.ReadLine();
                Console.WriteLine("Ingrese Habilitado (1 = SI / otro = NO): ");
                usuario.Habilitado = (Console.ReadLine()=="1");
                usuario.State = BusinessEntity.States.Modified;
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Presione alguna tecla para continuar...");
                Console.ReadLine();
            }
        }

        public void Agregar()
        {
            Console.Clear();
            Usuario usuario = new Usuario();
            Console.WriteLine("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese Clave: ");
            usuario.Clave = Console.ReadLine();
            Console.WriteLine("Ingrese Email: ");
            usuario.EMail = Console.ReadLine();
            Console.WriteLine("Ingrese Habilitado (1 = SI / otro = NO): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
            Console.WriteLine();
            Console.WriteLine("Presione alguna tecla para continuar...");
            Console.ReadLine();
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID de Usuario a Eliminar: ");
                int id = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(id);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Presione alguna tecla para continuar...");
                Console.ReadLine();
            }

        }

    } 
}
