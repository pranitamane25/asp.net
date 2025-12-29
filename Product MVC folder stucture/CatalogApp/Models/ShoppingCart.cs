namespace CatalogApp.Models;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
using System.Text.Json.Nodes;


public class ShoppingCart
{
    public int Index{get;set;}

    public string Add{get;set;}

    public string Summary{get;set;}
}