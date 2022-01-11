namespace Tests;

using Xunit;
using Models;
using CustomExceptions;
using System.Collections.Generic;

public class ModelTests{
    [Fact]
    public void CustomerShouldCreate(){
        Customer testCustomer = new Customer();
        Assert.NotNull(testCustomer);
    }
    [Fact]
    public void InventoryShouldCreate(){
        Inventory testInvnetory = new Inventory();
        Assert.NotNull(testInvnetory);
    }
    [Fact]
    public void LineItemShouldCreate(){
        LineItem testLineItem = new LineItem();
        Assert.NotNull(testLineItem);
    }
    [Fact]
    public void OrderShouldCreate(){
        Order testOrder = new Order();
        Assert.NotNull(testOrder);
    }
    [Fact]
    public void ProductShouldCreate(){
        Product testProduct = new Product();
        Assert.NotNull(testProduct);
    }
    [Fact]
    public void StorefrontShouldCreate(){
        Storefront testStorefront = new Storefront();
        Assert.NotNull(testStorefront);
    }
    [Fact]
    public void CustomerShouldSetValidData(){
        Customer testCustomer = new Customer();
        int id = 12;
        string name = "seleDirectorGendo";
        string password = "YuiDesign9";
        string email = "gendoikari@sele.com";
        testCustomer.Id = id;
        testCustomer.UserName = name;
        testCustomer.Password = password;
        testCustomer.Email = email;
        Assert.Equal(id, testCustomer.Id);
        Assert.Equal(name, testCustomer.UserName);
        Assert.Equal(password, testCustomer.Password);
        Assert.Equal(email, testCustomer.Email);

    }
    [Fact]
    public void InventoryShouldSetValidData(){
        Inventory testInventory = new Inventory();
        int storeid = 9;
        int itemid = 9;
        int quantity = 8;
        testInvnetory.StoreId = storeid;
        testInventory.ItemID = itemid;
        testInventory.Quantity = quantity;
        Assert.Equal(storeid, testInventory.StoreId);
        Assert.Equal(itemid, testInventory.ItemID);
        Assert.Equal(quantity, testInventory.Quantity);
    }
    [Fact]
    public void LineItemShouldSetValidData(){
        LineItem testLineItem = new LineItem();
        int orderid = 11;
        int itemid = 6;
        int quantity = 3;
        testLineItem.OrderId = orderid;
        testLineItem.ItemID = itemid;
        testLineItem.Quantity = quantity;
        Assert.Equal(orderid, testLineItem.OrderId);
        Assert.Equal(itemid, testLineItem.ItemID);
        Assert.Equal(quantity, testLineItem.Quantity);
    }
    [Fact]
    public void OrderShouldSetValidData(){
        Order testOrder = new Order();
        int orderid = 8;
        int orderdate = new DateTime();
        int customerid = 12;
        int storeid = 9;
        int total = 0.0;
        int lineitemid = 11;
        testOrder.OrderNumber = orderid;
        testOrder.OrderDate = orderdate;
        testOrder.CustomerId = customerid;
        testOrder.StoreID = storeid;
        testOrder.Total = total;
        testOrder.LineItemID = lineitemid;
        Assert.Equal(orderid, testOrder.OrderNumber);
        Assert.Equal(orderdate, testOrder.OrderDate);
        Assert.Equal(customerid, testOrder.CustomerId);
        Assert.Equal(storeid, testOrder.StoreID);
        Assert.Equal(total, testOrder.Total);
        Assert.Equal(lineitemid, testOrder.LineItemID);
    }
    [Fact]
    public void ProductShouldSetValidData(){
        Product testProduct = new Product();
        string productname = "The Blood on Satan's Claw";
        int directorid = 194;
        int ratingid = 4;
        int yearid = 51;
        decimal price = 19.99;
        testProduct.ProductName = productname;
        testProduct.DirectorID = directorid;
        testProduct.MPARatingID = ratingid;
        testProduct.ReleaseYearID = yearid;
        testProduct.Price = price;
        Assert.Equal(productname, testProduct.ProductName);
        Assert.Equal(directorid, testProduct.DirectorID);
        Assert.Equal(ratingid, testProduct.MPARatingID);
        Assert.Equal(yearid, testProduct.ReleaseYearID);
        Assert.Equal(price, testProduct.Price);
    }
    [Fact]
    public void StorefrontShouldSetValidData(){
        Storefront testStorefront = new Storefront();
        int id = 8;
        string name = "Regal Webster Place";
        string address = "1471 W. Webster Ave., Chicago, IL";
        int inventoryid = 9;
        int orderid = 8;
        testStorefront.ID = id;
        testStorefront.Name = name;
        testStorefront.Address = address;
        testStorefront.InventoryID = inventoryid;
        testStorefront.OrderID = orderid;
        Assert.Equal(id, testStorefront.ID);
        Assert.Equal(name, testStorefront.Name);
        Assert.Equal(address, testStorefront.Address);
        Assert.Equal(inventoryid, testStorefront.InventoryID);
        Assert.Equal(orderid, testStorefront.OrderID);
    }
}