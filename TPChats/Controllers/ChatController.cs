using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPChats.Models;

namespace TPChats.Controllers
{
    public class ChatController : Controller
    {
        private static List<Chat> meute=Chat.GetMeuteDeChats();
        // GET: ChatController
        public ActionResult Index()
        {
            return View(meute);
        }

        // GET: ChatController/Details/5
        public ActionResult Details(int id)
        {
            Chat? chat=meute.FirstOrDefault(c => c.Id == id);
            if (chat == null) return NotFound();
            return View(chat);
        }


        // GET: ChatController/Delete/5
        public ActionResult Delete(int id)
        {
            Chat? chat = meute.FirstOrDefault(c => c.Id == id);
            if (chat == null) return NotFound();
            return View(chat);
        }

        // POST: ChatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Chat? chat = meute.FirstOrDefault(c => c.Id == id);
                if (chat == null) return NotFound();
                meute.Remove(chat);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
