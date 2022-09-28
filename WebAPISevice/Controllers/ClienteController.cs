using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebAPISevice.Models;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace WebAPISevice.Controllers
{
    public class ClienteController : ApiController
    {
        //Get lista /api/cliente
        [HttpGet]
        public List<ClienteCLS> GetListCliente()
        {
            List<ClienteCLS> clienteList = new List<ClienteCLS>();
            using (CDAColombiaDBEntities db = new CDAColombiaDBEntities())
            {
                clienteList = (from C in db.Cliente
                               select new ClienteCLS
                               {
                                   IdCliente = C.IDCLIENTE,
                                   Nombre = C.NOMBRE,
                                   Apellido = C.APELLIDO,
                                   Cedula = C.CEDULA,
                                   Telefono = C.TELEFONO,
                                   Ciudad = C.CIUDAD
                               }).ToList();
            }
            return clienteList;
        }

        //Obtener Id /api/cliente/{id}
        [HttpGet]
        public IHttpActionResult GetClienteId(int id)
        {
            ClienteCLS clienteid = new ClienteCLS();
            using (CDAColombiaDBEntities db = new CDAColombiaDBEntities())
            {
                Cliente oCliente = db.Cliente.Find(id);
                clienteid.IdCliente = oCliente.IDCLIENTE;
                clienteid.Nombre = oCliente.NOMBRE;
                clienteid.Apellido = oCliente.APELLIDO;
                clienteid.Cedula = oCliente.CEDULA;
                clienteid.Telefono = oCliente.TELEFONO;
                clienteid.Ciudad = oCliente.CIUDAD;
                db.SaveChanges();
            }
            return Ok (clienteid);
        }

        //Insertar informacion /api/cliente
        [HttpPost]
        public IHttpActionResult CrearCliente(ClienteCLS cliente)
        {
            if (!ModelState.IsValid)
            {
                return Ok (cliente);
            }
            int IdCliente = cliente.IdCliente;
            using (CDAColombiaDBEntities db = new CDAColombiaDBEntities())
            {
                var model = new Cliente();
                model.NOMBRE = cliente.Nombre;
                model.APELLIDO = cliente.Apellido;
                model.CEDULA = cliente.Cedula;
                model.TELEFONO = cliente.Telefono;
                model.CIUDAD = cliente.Ciudad;
                db.Cliente.Add(model);
                db.SaveChanges();
            }
            return Ok (cliente);
        }

        //Actualizar informacion /api/cliente/{id}
        [HttpPut]
        public string EditarCliente(ClienteCLS UpCliente)
        {
            int idCliente = UpCliente.IdCliente;
            using (CDAColombiaDBEntities db = new CDAColombiaDBEntities())
            {
                Cliente oCliente = db.Cliente.Where(p => p.IDCLIENTE.Equals(idCliente)).First();
                oCliente.IDCLIENTE = UpCliente.IdCliente;
                oCliente.NOMBRE = UpCliente.Nombre;
                oCliente.APELLIDO = UpCliente.Apellido;
                oCliente.CEDULA = UpCliente.Cedula;
                oCliente.TELEFONO = UpCliente.Telefono;
                oCliente.CIUDAD = UpCliente.Ciudad;
                db.SaveChanges();
            }
            return "Cliente actualizado";
        }

        //Delete id  /api/cliente/{id}
        [HttpDelete]
        public IHttpActionResult Eliminar(int id)
        {
            using (CDAColombiaDBEntities db = new CDAColombiaDBEntities())
            {
                var model = db.Cliente.Find(id);
                db.Cliente.Remove(model);
                db.SaveChanges();
            }
            return Ok("Elemento eliminado");
        }
    }
}
