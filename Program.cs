using Microsoft.EntityFrameworkCore;
using razorweb.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Đọc đối tượng của dịch vị thông qua Services
builder.Services.AddDbContext<MyBlogContext>(options => {
    string connectString = builder.Configuration.GetConnectionString("MyBlogContext");
    options.UseSqlServer(connectString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

/*
    CREATE, READ, UPDATE, DELETE (CRUD)
    Trong .NEt có hỗ trợ lệnh tạo: 
        - m:        theo Model nào                  VD: razorweb.models.Article      --> Nó thuộc namespace nào
        - dc:       DatabaseContext                 VD: razorweb.models.MyBlogContext 
        - outDir    Thư mục lưu trữ file tạo ra     VD: Pages/Blog
        - Tham số mặc định: -udl -referenceScriptLibraries

        dotnet aspnet-codegenerator razorpage -m razorweb.models.Article -dc razorweb.models.MyBlogContext -outDir Pages/Blog -udl --referenceScriptLibraries



    Mỗi lần clone từ git về ta phải cài các package
    Để làm việc với EF, hãy thêm các công cụ vào dotnet cũng như tích hợp các Package cần thiết, thực hiện các lệnh sau:
        dotnet tool install --global dotnet-ef
        dotnet tool install --global dotnet-aspnet-codegenerator --version 6.0.0            
        dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 6.0.0
        dotnet add package Microsoft.EntityFrameworkCore.Design
        dotnet add package Microsoft.EntityFrameworkCore.SqlServer

        - Xoá Database: dotnet ef database drop -f

*/
