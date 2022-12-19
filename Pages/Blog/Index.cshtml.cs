using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorweb.models;

namespace Tich_hop_EntityWork_Vao_ASPNet_Connect_Sql.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly razorweb.models.MyBlogContext _context;
        public const int ITEMS_PER_PAGE = 5;   // Hiển thị 10 bài viết trên một trang
        [BindProperty(SupportsGet =true, Name = "p")]   
        public int currentPage {get; set;}      // Là truy vấn trang thứ mấy trên url để chạy đến trang đó 
        public int countPages {get; set;}

        public IndexModel(razorweb.models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync(string SeachString)
        {
            int totalArticle = await _context.articles.CountAsync();
            // Lấy ra số trang để truy cập   
            countPages = (int)Math.Ceiling((double)totalArticle/ITEMS_PER_PAGE);
            if(currentPage < 1)
            {
                currentPage = 1;
            }
            if(currentPage > countPages)
            {
                currentPage = countPages;
            }

            var qr = (from a in _context.articles 
                    orderby a.Created descending
                    select a).Skip((currentPage - 1) * ITEMS_PER_PAGE ).Take(ITEMS_PER_PAGE);

            if(!String.IsNullOrEmpty(SeachString))
            {
                Article =await qr.Where(a => a.Title.Contains(SeachString)).ToListAsync();
            }
            else
            {
                Article = await qr.ToListAsync();
            }
        }
    }
}
