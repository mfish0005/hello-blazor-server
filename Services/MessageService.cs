using HelloBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HelloBlazor.Data
{
    public class MessageService
    {
        AppDbContext _context;

        public MessageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Message> InsertMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return message;
        }

        public async Task<Message> GetMessageByIdAsync(string id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public List<Message> GetAllMessages()
        {
            try
            {
                return _context.Messages.AsNoTracking().ToList();
            }
            catch
            {
                throw;
            }
        }

        public Task<List<Message>> GetMessageList()
        {
            Debug.WriteLine("ALERT: GetAllMessages is returning: ", Task.FromResult(GetAllMessages()));
            return Task.FromResult(GetAllMessages());
        }
    }
}
