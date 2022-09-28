using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISevice.Models; 
namespace WebAPISevice.Controllers
{
    public class VehiculoController : ApiController
    {
        [HttpGet]
        public List<VehiculoCLS> GetListCliente()
        {
            List<VehiculoCLS> listVehiculo = new List<VehiculoCLS>();
            using (CDAColombiaDBEntities db = new CDAColombiaDBEntities())
            {
                listVehiculo = (from vehiculo in db.Vehiculo
                               join cliente in db.Cliente
                               on vehiculo.IDCLIENTE equals cliente.IDCLIENTE
                               select new VehiculoCLS
                               {
                                   IdVehiculo = vehiculo.IDVEHICULO,
                                   Modelo = vehiculo.MODELO,
                                   Color = vehiculo.COLOR,
                                   Año = vehiculo.AÑO,
                                   Placa = vehiculo.PLACA,
                                   IdCliente = cliente.IDCLIENTE,
                               }).ToList();
            }
            return listVehiculo;
        }

        //Obtener Id /api/Vehiculo/{id}
        [HttpGet]
        public IHttpActionResult GetVehiculoId(int id)
        {
            VehiculoCLS vehiculoId = new VehiculoCLS();
            using (CDAColombiaDBEntities db = new CDAColombiaDBEntities())
            {
                Vehiculo vehiculo = db.Vehiculo.Find(id);
                vehiculoId.IdVehiculo = vehiculo.IDVEHICULO;
                vehiculoId.Modelo = vehiculo.MODELO;
                vehiculoId.Color = vehiculo.COLOR;
                vehiculoId.Año = vehiculo.AÑO;
                vehiculoId.Placa = vehiculo.PLACA;
                vehiculoId.IdCliente = vehiculo.IDCLIENTE;
                db.SaveChanges();
            }
            return Ok(vehiculoId);
        }

        //Insertar informacion /api/Vehiculo
        [HttpPost]
        public IHttpActionResult CrearVehiculo(VehiculoCLS vehiculo)
        {
            if (!ModelState.IsValid)
            {
                return Ok(vehiculo);
            }
            int IdVehiculo = vehiculo.IdVehiculo ;                                                                                                                                         
            using (CDAColombiaDBEntities db = new CDAColombiaDBEntities())
            {
                var model = new Vehiculo();
                model.MODELO = vehiculo.Modelo;
                model.COLOR = vehiculo.Color;
                model.AÑO = vehiculo.Año;
                model.PLACA = vehiculo.Placa;
                model.IDCLIENTE = vehiculo.IdCliente;
                db.Vehiculo.Add(model);
                db.SaveChanges();
            }
            return Ok("Usuario creado");
        }

        //Actualizar informacion /api/Vehiculo/{id}
        [HttpPut]
        public IHttpActionResult EditarVehiculo(VehiculoCLS vehiculo, int id)
        {
            var Id = id;
            using (CDAColombiaDBEntities db = new CDAColombiaDBEntities())
            {
                Vehiculo oVehiculo = db.Vehiculo.Where(p=>p.IDVEHICULO.Equals(Id)).First();
                //oVehiculo.IDVEHICULO  = vehiculo.IdVehiculo;
                oVehiculo.MODELO = vehiculo.Modelo;
                oVehiculo.COLOR = vehiculo.Color;
                oVehiculo.AÑO = vehiculo.Año;
                oVehiculo.PLACA = vehiculo.Placa;
                oVehiculo.IDCLIENTE = vehiculo.IdCliente;
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
