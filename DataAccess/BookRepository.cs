//نيجي هون لمستودع الكتب
using System.Collections.Generic;//هاي المكتبة للتعامل مع المجموعات يعني مجموعات الكتب وهيك
using System.IO;//للتعامل مع الملفات قراءة كتابة على الملفات
using System.Text.Json;//هي مكتبة تستخدم لتحويل البيانات بين جيسون وال سي شارب
//زي تحويل قائمة من الكتب لل JSON

namespace LibraryManagement.DataAccess//هون بتحتوي الكود المسؤول عن الوصول للداتا للبيانات
{
    public class BookRepository//هاد الكلاس البوك ريبوستوري بحتوي الاوامر المتعلقة بقراءة وكتابة بيانات الكتب
    {
        private const string FilePath = "Data/books.json";
        //const تعني ان القيمة ثابته ولا يمكن تغيرها
        //FilePath: بحتوي المسار الي بدي اخزن فيه بيانات الكتب في الجيسون
        public List<Book> GetAllBooks()
        {
            if (!File.Exists(FilePath))
                return new List<Book>();//بتاكد هل الملف بوك دون جيسون موجود ولا لا ازا لا برجعلي شو؟قائمة فااضية

            var json = File.ReadAllText(FilePath);//ازا كان الملف موجود هاد السطر يقوم يقوم بقراءة محتويات الملف وتحويله الى نص جيسون
            return JsonSerializer.Deserialize<List<Book>>(json);
            //ب استخدام JsonSerializer:يتم قراءة النص جيسون من الملف وتحويله الى سي شارب
        }

        public void SaveBooks(List<Book> books)
        {
            var json = JsonSerializer.Serialize(books);
            //هذه السطر يقوم بتحويل قائمة الكتب 
            //(List<Book>)
            //    JSON  إلى نص
            //باستخدام JsonSerializer.Serialize.
            File.WriteAllText(FilePath, json);
            //يتم بعد ذلك كتابة النص JSON الذي تم إنشاؤه إلى
            //الملف books.json
            //باستخدام File.WriteAllText.

        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
    }
}
