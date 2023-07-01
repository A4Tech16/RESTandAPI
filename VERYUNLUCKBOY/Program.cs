using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using VERYUNLUCKBOY;


var courses = new List<Course>
{
new Course { Name = "Course 1",b Instructor = "Instructor 1" },
new Course { Name = "Course 2", Instructor = "Instructor 2" },
new Course { Name = "Course 3", Instructor = "Instructor 3" },
new Course { Name = "Course 4", Instructor = "Instructor 4" },
new Course { Name = "Course 5", Instructor = "Instructor 5" },
};
var jsonString = JsonSerializer.Serialize(courses);
File.WriteAllText("KekW.json", jsonString);



var builder = WebApplication.CreateBuilder(args);

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
