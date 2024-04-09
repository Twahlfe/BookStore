using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using a1_bookstore_ict715.Data;
using a1_bookstore_ict715.Models;
using Microsoft.Identity.Client;
using a1_bookstore_ict715.Tools;
using MathNet.Numerics;
using NPOI.SS.Formula.Functions;

namespace a1_bookstore_ict715.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("[controller]s/sort-{sortOrder}/page{pageNum}")]
        [Route("[controller]s/page{pageNum}")]
        [Route("[controller]s/sort-{sortOrder}")]
        [Route("[controller]s")]

        // GET: Book
        public async Task<ActionResult> Index(string? sortOrder, string? filterBy, int? pageNum)
        {
            const int pageSize = 5;
            if (pageNum == null) { pageNum = 1; }

            BookstoreSession mySession = new BookstoreSession() { Session = HttpContext.Session };
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = mySession.GetSort();
            }
            else
            {
                mySession.SetSort(sortOrder);
            }
            if (string.IsNullOrEmpty(filterBy))
            {
                filterBy = mySession.GetFilter();
            }
            else
            {
                mySession.SetFilter(filterBy);
            }

            // Fav courses            
            ViewBag.FavBooks = mySession.GetUserBookIds();
            
            // This enables the Genre Name to be displayed
            var bookQuery = _context.Book.Include(c => c.Genre).AsQueryable();

            // Check to see if there is a sorting parameter (sortOrder) and apply it
            if (!String.IsNullOrEmpty(filterBy) && filterBy != "reset") bookQuery = bookQuery.Where(c => c.GenreName == filterBy);
            ViewData["Genre"] = new SelectList(_context.Genre, "GenreName", "GenreName", filterBy);
            // This enables the select list to filter by Genre
            //ViewData["Genre"] = new SelectList(_context.Genre, "GenreName", "GenreName");

            // sorting by either name or publishdate, default is publishdate descending
            switch (sortOrder)
            {
                case "name":
                    bookQuery = bookQuery.OrderBy(book => book.Name);
                    break;
                case "name_desc":
                    bookQuery = bookQuery.OrderByDescending(book => book.Name);
                    break;
                case "date":
                    bookQuery = bookQuery.OrderBy(book => book.PublishDate);
                    break;
                default:
                    bookQuery = bookQuery.OrderByDescending(book => book.PublishDate);
                    break;
            }

            //var pageCount = await bookQuery.CountAsync();
            //var currentPage = bookQuery.Skip(pageSize * (pageNum.Value - 1)).Take(pageSize);
            if (pageNum != null) { bookQuery = bookQuery.Skip(pageSize * (pageNum.Value - 1)).Take(pageSize); }
            ViewBag.CurrentPage = pageNum;
                        
            return View(await bookQuery.ToListAsync());
        }

        // GET: Book/AddRemoveFav/5
        [Route("[Controller]s/[action]/{id}")]
        public IActionResult AddRemoveFav(int id)
        {
            BookstoreCookies myResponseCook = new BookstoreCookies(Response.Cookies);
            BookstoreSession mySession = new BookstoreSession() { Session = HttpContext.Session };

            List<int> bookIds = mySession.GetUserBookIds();
            if(bookIds.Contains(id)) bookIds.Remove(id);    // Remove the course ID if it already exists
            else bookIds.Add(id);   // Add the book id if it doesn't exist

            mySession.SetUserBookIds(bookIds);  // Store book Ids in the session
            myResponseCook.SetUserBookIds(bookIds);  // Store book Ids in a cookie

            if (Request.Headers["Referer"].Count > 0)
                return Redirect(Request.Headers["Referer"]);
            return RedirectToAction("Index");
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var bookModel = await _context.Book
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookModel == null)
            {
                return NotFound();
            }

            return View(bookModel);
        }

        //// GET: Book/Create
        //public IActionResult Create()
        //{
        //    ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId");
        //    return View();
        //}

        //// POST: Book/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("BookId,Name,GenreId,Description,Authors,Price,PublishDate")] BookModel bookModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(bookModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId", bookModel.GenreId);
        //    return View(bookModel);
        //}

        //// GET: Book/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Book == null)
        //    {
        //        return NotFound();
        //    }

        //    var bookModel = await _context.Book.FindAsync(id);
        //    if (bookModel == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId", bookModel.GenreId);
        //    return View(bookModel);
        //}

        //// POST: Book/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("BookId,Name,GenreId,Description,Authors,Price,PublishDate")] BookModel bookModel)
        //{
        //    if (id != bookModel.BookId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(bookModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BookModelExists(bookModel.BookId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId", bookModel.GenreId);
        //    return View(bookModel);
        //}

        //// GET: Book/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Book == null)
        //    {
        //        return NotFound();
        //    }

        //    var bookModel = await _context.Book
        //        .Include(b => b.Genre)
        //        .FirstOrDefaultAsync(m => m.BookId == id);
        //    if (bookModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(bookModel);
        //}

        //// POST: Book/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Book == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Book'  is null.");
        //    }
        //    var bookModel = await _context.Book.FindAsync(id);
        //    if (bookModel != null)
        //    {
        //        _context.Book.Remove(bookModel);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BookModelExists(int id)
        //{
        //  return (_context.Book?.Any(e => e.BookId == id)).GetValueOrDefault();
        //}
    }
}
