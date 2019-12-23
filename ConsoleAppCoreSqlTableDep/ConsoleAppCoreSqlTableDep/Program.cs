using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TableDependency.SqlClient.Base.Enums;


namespace ConsoleAppCoreSqlTableDep
{
    class Program
    {
        public static void SerializeToXml<T>(T obj, string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            //Create a FileStream object connected to the target file   
            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fileStream, obj);
            fileStream.Close();
        }

        public static T DeserializeFromXml<T>(string xml)
        {
            T result;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (TextReader tr = new StringReader(xml))
            {
                result = (T)ser.Deserialize(tr);
            }
            return result;
        }

        static void Main(string[] args)
        {
            string connectionString =
                @"Data Source =LSTK231300\SQLEXPRESS; Initial Catalog = SQLTableDependency; Integrated Security = true; ";
            //este monitorea solo 1 tabla a la vez
            using (TableDependency.SqlClient.SqlTableDependency<Cliente> dep =
                new TableDependency.SqlClient.SqlTableDependency<Cliente>(connectionString))
            {
                dep.OnChanged += Dep_OnChanged;
                dep.Start();

                Console.WriteLine("Presione <enter> para salir");
                Console.ReadLine();
                dep.Stop();


            }
        }

        private static void Dep_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Cliente> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                Console.WriteLine("DML operation: " + e.ChangeType);
                Console.WriteLine(e.Entity.Id);
                Console.WriteLine(e.Entity.Documento);
                Console.WriteLine(e.Entity.Nombres);
                Console.WriteLine(e.Entity.Apellidos);
                
                Console.WriteLine(e.Entity.Hijos);
                Console.WriteLine(e.Entity.Sueldo);
                Console.WriteLine(Environment.NewLine);

                if (e.ChangeType == ChangeType.Insert)
                {
                    List<Cliente> listaCliente = new List<Cliente>();
                    if (File.Exists(@"C:\Users\Curso\Documents\academia\ClienteSqlDep.xml"))
                    {
                        XmlDocument Doc = new XmlDocument();
                        Doc.Load(@"C:\Users\Curso\Documents\academia\ClienteSqlDep.xml");
                        listaCliente.AddRange(DeserializeFromXml<List<Cliente>>(Doc.OuterXml));
                    }
                    Cliente infoCliente = new Cliente();
                    infoCliente.Id = e.Entity.Id;
                    infoCliente.Documento = e.Entity.Documento;
                    infoCliente.Nombres = e.Entity.Nombres;
                    infoCliente.Apellidos = e.Entity.Apellidos;
                
                    infoCliente.Hijos = e.Entity.Hijos;
                    infoCliente.Sueldo = e.Entity.Sueldo;

                    listaCliente.Add(infoCliente);

                    SerializeToXml<List<Cliente>>(listaCliente, @"C:\Users\Curso\Documents\academia\ClienteSqlDep.xml");
                    Console.WriteLine(Environment.NewLine);

                }
                if (e.ChangeType == ChangeType.Delete)
                {
                    XElement Doc = XElement.Load(@"C:\Users\Curso\Documents\academia\ClienteSqlDep.xml");
                    foreach (XNode item in Doc.Nodes())
                    {
                        var idAttribute = ((XElement)item).Attributes("Id").FirstOrDefault().Value;
                        if (idAttribute == e.Entity.Id.ToString())
                        {
                            item.Remove();
                            Doc.Save(@"C:\Users\Curso\Documents\academia\ClienteSqlDep.xml");
                        }
                    }
                }
                if (e.ChangeType == ChangeType.Update)
                {
                    XElement Doc = XElement.Load(@"C:\Users\Curso\Documents\academia\ClienteSqlDep.xml");
                    foreach (XElement item in Doc.Nodes())
                    {
                        var idAttribute = item.Attributes("Id").FirstOrDefault().Value;
                        if (idAttribute == e.Entity.Id.ToString())
                        {
                            item.SetElementValue("Documento", e.Entity.Documento.ToString());
                            item.SetElementValue("Nombres", e.Entity.Nombres.ToString());
                            item.SetElementValue("Apellidos", e.Entity.Apellidos.ToString());
                    
                            item.SetElementValue("Hijos", e.Entity.Hijos.ToString());
                            item.SetElementValue("Sueldo", e.Entity.Sueldo.ToString());
                            Doc.Save(@"C:\Users\Curso\Documents\academia\ClienteSqlDep.xml");

                        }
                    }
                }


                //if (e.ChangeType != ChangeType.Delete)
                //{

                //    XmlDocument Doc = new XmlDocument();
                //    Doc.Load(@"C:\Users\Curso\Documents\academia\ClienteSqlDep.xml");
                //    XmlNode cliente = Doc.DocumentElement;
                //    XmlNodeList listaClientes = Doc.SelectNodes("Cliente");
                //    foreach (XmlNode item in listaClientes)
                //    {
                //        if (item.SelectSingleNode("Id").InnerText == id_borrar)
                //        {
                //            XmlNode nodoOld = item;
                //            cliente.RemoveChild(nodoOld);
                //        }
                //    }


                //}

            }
        }
    }
}
