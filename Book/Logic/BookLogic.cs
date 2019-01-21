using System;
using System.Collections.Generic;
using System.Linq;
using Book.Models;


namespace Book.Logic
{
    public class BookLogic
    {
        public List<BookModel> GetBooks()
        {
            using (var context = new CommonDBContext())
            {
                List<BookModel> books = new List<BookModel>();
                var res = context.Books.ToList();
                if (res == null || res.Count == 0) return null;
                foreach (var book in res)
                {
                    books.Add(book);
                }
                //if (!string.IsNullOrWhiteSpace(permition) && permition == "admin")
                //{
                //    return books;
                //}

                //return books.Where(o => o.IsEable == 1).ToList();
                return books;
            }
        }

        public BookModel GetBookDetail(int? id)
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

        public BookModel CreateBook(BookModel book)
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

        public bool EditBook(BookModel book)
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

        /// <summary>
        /// テスト用
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int? GetAlgorithm(string a, string b)
        {
            if (a == null || b == null)
            {
                return null;
            }

            int tmp_a;
            int tmp_b;
            if (!int.TryParse(a, out tmp_a) || !int.TryParse(b, out tmp_b))
            {
                return null;
            }
            if (tmp_a > tmp_b)
            {
                return tmp_a - tmp_b;
            }

            if (tmp_a == tmp_b)
            {
                return tmp_a * tmp_b;
            }

            return tmp_a + tmp_b;
        }
    }
}