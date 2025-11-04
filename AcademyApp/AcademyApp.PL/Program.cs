// See https://aka.ms/new-console-template for more information
using AcademyApp.BLL.Dtos.Groups;
using AcademyApp.BLL.Interfaces;
using AcademyApp.BLL.Services;
using AcademyApp.Core.Models;
using AcademyApp.DLL.Data;
using Microsoft.Extensions.DependencyInjection;

//Console.WriteLine("Hello, World!");

//AppDbContext appDbContext = new AppDbContext();
//GroupServices groupServices = new GroupServices(appDbContext);

//DI

var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped<AppDbContext>();
serviceCollection.AddTransient<IGroupServices, GroupServices>();
var serviceProvider = serviceCollection.BuildServiceProvider();
var groupService = serviceProvider.GetRequiredService<IGroupServices>();

//foreach (var groups in groupService.GetAllGroups())
//{
//    Console.WriteLine(groups);
//}

//foreach (var item in groupService.GetGroupsByLimit(18))
//{
//    Console.WriteLine(item);
//}

//foreach (var item in groupService.GetSearchByName("bac"))
//{
//    Console.WriteLine(item);
//}

//foreach (var item in groupService.LimitByGroups(16,22))
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine("salam");

//groupService.AddGroup(new GroupCreateDto()
//{
//    Name = "Name",
//    Description = "Description",
//    Limit = 100,
//});

var groupReturnDto = groupService.GetGroupById(1);
Console.WriteLine(groupReturnDto);



