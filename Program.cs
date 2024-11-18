
using library_sys.Repos.AuthorRepos;
using library_sys.Repos.BookRepos;
using Microsoft.EntityFrameworkCore;

namespace library_sys
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DataContext>(x=> x.UseSqlServer(builder.Configuration.GetConnectionString("Def")));
            builder.Services.AddScoped<IAuthorRepo,AuthorRepo>();
            builder.Services.AddScoped<IBookRepo,BookRepo>();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
