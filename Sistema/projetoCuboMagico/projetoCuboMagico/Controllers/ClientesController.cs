using projetoCuboMagico.Models;
using projetoCuboMagico.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoCuboMagico.Controllers
{
    public class ClientesController : Controller
    {
        ClientesRepository clientesRepository = new ClientesRepository();
        UsuariosRepository usuariosRepository = new UsuariosRepository();
        // GET: Clientes
        public ActionResult Index() 
        {
            List<Cliente> cliente = clientesRepository.listarTodos().ToList();
            return View(cliente);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View(clientesRepository.consultaPorID(id));
        }
        [HttpGet]
        public ActionResult Create3()
        {
            return View();
        }

        // GET: Clientes/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (usuariosRepository.incluirUsuario(cliente.Usuario))
                    {
                        clientesRepository.incluirCliente(cliente);
                    }
                    
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
            }
            return RedirectToAction("Create2", "Clientes");
        }

        [HttpGet]
        public ActionResult Create2()
        {
            return View();
        }



        // GET: Clientes/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(clientesRepository.consultaPorID(id));
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                if (usuariosRepository.alterarUsuario(cliente.Usuario))
                {
                    clientesRepository.alterarCliente(cliente);
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(clientesRepository.consultaPorID(id));
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cliente cliente)
        {
            try
            {
                clientesRepository.deletarCliente(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
