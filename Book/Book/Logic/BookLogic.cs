using System;
using System.Collections.Generic;
using System.Linq;
using Book.Models;


namespace Book.Logic
{
    public class BookLogic
    {
        public List<Books> GetBooks(string permition)
        {
            using (var context = new CommonDBContext())
            {
                List<Books> books = new List<Books>();
                var res = context.Books.ToList();
                if (res.Count == 0 || res == null) return null;
                foreach (var book in res)
                {
                    books.Add(book);
                }
                if (!string.IsNullOrWhiteSpace(permition) && permition == "admin")
                {
                    return books;
                }

                return books.Where(o => o.IsEable == 1).ToList();
            }
        }

        public Books GetBookDetail(int? id)
        {
            if (id == null)
                return null;

            using (var context = new CommonDBContext())
            {
                var res = context.Books.FirstOrDefault(o => o.ID == id);
                if (res == null) return null;
                return res;
            }
        }

        public Books CreateBook(Books book)
        {
            if (book == null)
                return null;

            using (var context = new CommonDBContext())
            {
                var res = context.Books.Add(book);
                if (res == null) return null;
                res.Created = DateTimeOffset.Now;
                context.SaveChanges();
                return res;
            }
        }

        public bool EditBook(Books book)
        {
            if (book == null)
                return false;

            using (var context = new CommonDBContext())
            {
                var res = context.Books.FirstOrDefault(o => o.ID == book.ID);
                if (res == null) return false;
                res.BookName = book.BookName;
                res.BookPrice = book.BookPrice;
                res.BookType = book.BookType;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteBook(int? id)
        {
            if (id == null)
                return false;

            using (var context = new CommonDBContext())
            {
                var res = context.Books.FirstOrDefault(o => o.ID == id);
                if (res == null) return false;
                context.Books.Remove(res);
                context.SaveChanges();
                return true;
            }
        }
    }
}