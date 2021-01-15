using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        Entities context;
        public BookController()
        {
            context = new Entities();
        }
        // GET: Book
        public ActionResult Index()
        {
            var books = context.tbl_books; 
            
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = context.tbl_books.Where(b => b.book_id == id).FirstOrDefault();
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
           var li = context.tbl_user.ToList();
            ViewBag.UsersList = new SelectList(li, "user_id", "user_name");
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(tbl_books collection)
        {
            try
            {
                // TODO: Add insert logic here
                var li = context.tbl_user.ToList();
                ViewBag.UsersList = new SelectList(li, "user_id", "user_name");
                tbl_books book = new tbl_books
                {
                    book_author = collection.book_author,
                    book_edition = collection.book_edition,
                    book_name = collection.book_name,
                    user_id = collection.user_id,
                    book_price = collection.book_price,
                    book_qunatity = collection.book_qunatity
                };
                context.tbl_books.Add(book);
                
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = context.tbl_books.Where(b => b.book_id == id).FirstOrDefault();

            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tbl_books bookModel)
        {
            try
            {
                // TODO: Add update logic here
                var book = context.tbl_books.Where(b => b.book_id == id).FirstOrDefault();
                book.book_author = bookModel.book_author;
                book.book_edition = bookModel.book_edition;
                book.book_name = bookModel.book_name;
                book.book_price = bookModel.book_price;
                book.book_qunatity = bookModel.book_qunatity;
                book.user_id = bookModel.user_id;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var book = context.tbl_books.Where(b => b.book_id == id).FirstOrDefault();
            context.SaveChanges();
            return View();
        }

        // POST: Book/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
