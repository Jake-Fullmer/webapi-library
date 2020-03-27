
using System;
using vending_machine.Models;
using webapi_library.Models;
using webapi_library.Services;

namespace webapi_library.Controllers
{
  class MainController
  {
    private bool _running { get; set; } = true;
    private MainService _ls { get; set; } = new MainService();
    public void Run()
    {
      while (_running)
      {
        GetUserInput();
        Print();
      }
    }
    private void GetUserInput()
    {
      System.Console.WriteLine("Please press (v)iew books, (c)heckout book, or (q)uit");
      string input = Console.ReadLine().Trim().ToLower();
      switch (input)
      {
        case "q":
        case "quit":
        case "exit":
          _running = false;
          break;
        case "v":
        case "view":
          _ls.AddItemToMessages();
          break;
        case "c":
        case "checkout":
          _ls.Checkout();
          break;
        default:
          _ls.AddItemToMessages();
          break;
      }
      Console.Clear();
    }
    private void Print()
    {
      Console.Clear();
      _ls.Messages.Insert(0, new Message(Utils.Logo, ConsoleColor.White));
      foreach (Message message in _ls.Messages)
      {
        Console.ForegroundColor = message.Color;
        Console.WriteLine(message.Body);
      }
      Console.ForegroundColor = ConsoleColor.White;
      _ls.Messages.Clear();
    }
  }
}