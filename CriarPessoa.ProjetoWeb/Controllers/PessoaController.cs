﻿using System;
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
    public class PessoaController : Controller
    {
        private IPessoaService service = new PessoaService(new PessoaRepository());

        // GET: /Blog/
        public ActionResult Index()
        {
            return View(service.RetrieveAll());
        }

        // GET: /Pessoa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Pessoa pessoa = service.Retrieve(id.Value);

            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: /Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataNascimento,Cpf,Profissao")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                service.Create(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: /Pessoa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int i = (int)id;

            Pessoa pessoa = service.Retrieve(i);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: /Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataNascimento,Cpf,Profissao")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                service.Update(pessoa);
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        // GET: /Pessoa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int i = (int)id;

            Pessoa pessoa = service.Retrieve(i);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: /Pessoa/Delete/5
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
