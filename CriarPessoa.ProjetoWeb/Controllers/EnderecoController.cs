using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CriarPessoa.Dominio;
using CriarPessoa.Infra.Data;
using CriarPessoa.Aplicacao;

namespace CriarPessoa.ProjetoWeb.Controllers
{
    public class EnderecoController : Controller
    {
        private IEnderecoService service = new EnderecoService(new EnderecoRepository());
        private IPessoaService pessoaService = new PessoaService(new PessoaRepository());

        // GET: /Dependente/
        public ActionResult Index()
        {
            return View(service.RetrieveAll());
        }

        // GET: /Endereco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int i = (int)id;
            Endereco endereco = service.Retrieve(i);

            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: /Endereco/Create
        public ActionResult Create()
        {
            ViewData["PessoaId"] = GetPessoas();

            return View();
        }
        private SelectList GetPessoas()
        {
            var xpto = pessoaService.RetrieveAll();
            return new SelectList(xpto, "Id", "Nome");
        }

        // POST: /Endereco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rua,Numero,Cep,Bairro,Cidade, PessoaId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                service.Create(endereco);
                return RedirectToAction("Index");
            }

            return View(endereco);
        }



        // GET: /Endereco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int i = (int)id;

            Endereco endereco = service.Retrieve(i);
            if (endereco == null)
            {
                return HttpNotFound();
            }

            ViewData["PessoaId"] = GetPessoas();
            return View(endereco);
        }

        // POST: /Endereco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Rua,Numero,Cep,Bairro,Cidade, PessoaId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                service.Update(endereco);
                return RedirectToAction("Index");
            }
           
            return View(endereco);
        }

        // GET: /Endereco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int i = (int)id;

            Endereco endereco = service.Retrieve(i);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: /Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
