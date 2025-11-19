using Newton_VideoGames_Catalogue.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/*  add DbContext */
builder.Services.AddDbContext<VGameDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();

/* add CORS  */
builder.Services.AddCors(options =>
{
    options.AddPolicy("ng",
        p => p.WithOrigins("http://localhost:4200") // frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod());
});


 builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen();

var app = builder.Build();

/*  apply migration automaticall    */
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<VGameDbContext>();
    db.Database.Migrate();
    VGameProvider.Provide(db);
}

/*  TODO: middleware   */
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("ng");
app.MapControllers();
app.Run();
