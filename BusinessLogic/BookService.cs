//bookservices هي اصلا لادارة جميع العمليات الخاصة بالكتب
using LibraryManagement.DataAccess;
/* الهدف منها الوصول لل داتا الموجودة وين؟
بال Data Access*/
using System.Collections.Generic;//بستخدمها  لاعمل لست قوائم يعني زي قائمة الكتب وهيك

namespace LibraryManagement.BusinessLogic//مكتبة فيها مجموعة من الكلاسات للعمليات الحسابية
{
    public class BookService //كلاس لتنفيذ العمليات الخاصة بالكتب من اضافة حذف تحديث واسترجاع
    {
        private readonly BookRepository _repository; //هو اوبجيكت من الكلاس بوك سيرفيس للتعامل مع البيانات تاعة هاد الكلاس لهي تاعة الكتب

        public BookService()
        {
            _repository = new BookRepository(); //يتم انشاء كاين جديد لتوفير امكانية الوصول للبيانات
        }

        public List<Book> GetBooks()//دالة استرجاع الكتب 
        {//هي دالة بترجع قائمة من الكتب
            return _repository.GetAllBooks();
            //استدعاء الدالة GetAllBooks من BookRepository لجلب جميع الكتب من ملفات JSON.
        }

        public void AddBook(Book book)//دالة اضافة كتاب
        {
            var books = _repository.GetAllBooks();//الحصول على جميع الكتب المخزنة حاليا
            books.Add(book);//اضافة كتاب جديد الى هذه القائمة
            _repository.SaveBooks(books);//حفظ القائمة المحدثة الى ملف جيسون ب استخدام  سيف بوك
            //الى json
            //باستخدام SaveBooks
        }
        public void UpdateBook(Book updatedBook)//دالة تحديث كتاب موجود
        {
            var books = _repository.GetAllBooks();//الحصول على جميع الكتب المخزنة حاليا
            var book = books.Find(b => b.Id == updatedBook.Id);//البحث عن الكتاب المراد تحديثه بناءا على ال #id
            if (book != null)//لاتاكد انه الكتاب موجود
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Genre = updatedBook.Genre;
                book.ISBN = updatedBook.ISBN;
                book.Quantity = updatedBook.Quantity;//كل هدول انه تحديث للاشياء الجديدة تاعة الكتاب هاد يعني الي حدثتها
                _repository.SaveBooks(books);//حفظ القائمة المحدثة
            }
        }

        public void DeleteBook(int id)//دالة لحذف كتاب
        {
            var books = _repository.GetAllBooks();//استرجاع القائمة الحالية من الكتب
            books.RemoveAll(b => b.Id == id);//ازالة كل الكتب الي بتحتوي هاد ال #id
            _repository.SaveBooks(books);//حفظ القائمة المحدثة
        }
    }
}
