using api_dotnet_um.Data;
using api_dotnet_um.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_dotnet_um.Repositories
{
    public class ContatoRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<Contato> ListarTodos()
        {
            return _context.contatos.ToList();
        }

        public void Salvar(Contato contato)
        {
            if (contato.Id == 0)
            {
                // Mude de _context.Contatos para _context.contatos
                _context.contatos.Add(contato);
            }
            else
            {
                _context.Entry(contato).State = System.Data.Entity.EntityState.Modified;
            }

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var contato = _context.contatos.FirstOrDefault(c => c.Id == id);

            if (contato != null)
            {
                _context.contatos.Remove(contato);
                _context.SaveChanges();
            }
        }

    }
}