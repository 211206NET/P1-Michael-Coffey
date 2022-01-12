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
        testInventory.StoreId = storeid;
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
        DateTime orderdate = new DateTime();
        string customername = "Dr_R_Akagi";
        string storename = "AMC Chicago";
        decimal total = 0;
        int lineitemid = 11;
        testOrder.OrderNumber = orderid;
        testOrder.OrderDate = orderdate;
        testOrder.CustomerName = customername;
        testOrder.StoreName = storename;
        testOrder.Total = total;
        testOrder.LineItemID = lineitemid;
        Assert.Equal(orderid, testOrder.OrderNumber);
        Assert.Equal(orderdate.ToString(), testOrder.OrderDate.ToString());
        Assert.Equal(customername, testOrder.CustomerName);
        Assert.Equal(storename, testOrder.StoreName);
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
        decimal price = 20;
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
    [Theory]
    [InlineData("#$%^@#$%#@")]
    [InlineData("     ")]
    [InlineData(null)]
    [InlineData("")]
    public void CustomerShouldNotSetInvalidName(string input){
        Customer testCustomer = new Customer();
        Assert.Throws<InputInvalidException>(() => testCustomer.UserName = input);
    }
    [Theory]
    [InlineData("#$%^@#$%#@")]
    [InlineData("     ")]
    [InlineData(null)]
    [InlineData("")]
    public void ProductShouldNotSetInvalidName(string input){
        Product testProduct = new Product();
        Assert.Throws<InputInvalidException>(() => testProduct.ProductName = input);
    }
    [Theory]
    [InlineData("#$%^@#$%#@")]
    [InlineData("     ")]
    [InlineData(null)]
    [InlineData("")]
    public void StorefrontShouldNotSetInvalidName(string input){
        Storefront testStorefront = new Storefront();
        Assert.Throws<InputInvalidException>(() => testStorefront.Name = input);
    }
    [Fact]
    public void CustomerShouldHaveCustomToStringMethod(){
        Customer testCustomer = new Customer{
            Id = 13,
            UserName = "MKats",
            Password = "pen2Kaji",
            Email = "misato_katsuragi@wille.com"
        };
        string expectedOutput = "ID: 13 \nUsername: MKats \nPassword: pen2Kaji \nEmail: misato_katsuragi@wille.com";
        Assert.Equal(expectedOutput, testCustomer.ToString());
    }
    [Fact]
    public void InventoryShouldHaveCustomToStringMethod(){
        Inventory testInventory = new Inventory{
            StoreId = 10,
            ItemID = 10,
            Quantity = 15
        };
        string expectedOutput = "InventoryID: 10 \nStock: 15 \n10";
        Assert.Equal(expectedOutput, testInventory.ToString());
    }
    [Fact]
    public void LineItemShouldHaveCustomToStringMethod(){
        LineItem testLineItem = new LineItem{
            ItemID = 7,
            OrderId = 12,
            Quantity = 3

        };
        string expectedOutput = "LineItemID: 12 \nQuantity: 3 \n7";
        Assert.Equal(expectedOutput, testLineItem.ToString());
    }
    [Fact]
    public void OrderShouldHaveCustomToStringMethod(){
        Order testOrder = new Order{
            OrderNumber = 10,
            OrderDate = new DateTime(),
            CustomerName = "RKaji",
            StoreName = "Regal Los Angeles",
            Total = 0,
            LineItemID = 12
        };
        string expectedOutput = $"Date: {new DateTime()} \nCustomer: RKaji \nOrder ID: 10 \nStore: Regal Los Angeles \nTotal Cost: 0";
        Assert.Equal(expectedOutput, testOrder.ToString());
    }
    [Fact]
    public void ProductShouldHaveCustomToStringMethod(){
        Product testProduct = new Product{
            InventoryID = 16,
            ProductName = "The Matrix Resurrections",
            Director = "Lana Wachowski",
            MPARating = "R",
            ReleaseYearID = 2021,
            Price = 20
        };
        string expectedOutput = "Inventory ID: 16 \nTitle: The Matrix Resurrections \nDir.: Lana Wachowski \nRating: R \nYear: 2021 \nCost: 20";
        Assert.Equal(expectedOutput, testProduct.ToString());
    }
    [Fact]
    public void StorefrontShouldHaveCustomToStringMethod(){
        Storefront testStorefront = new Storefront{
            ID = 9,
            Address = "6360 Sunset Blvd., Los Angeles, CA",
            Name = "The Dome Entertainment Centre",
            InventoryID = 10,
            OrderID = 9
        };
        string expectedOutput = "Name: The Dome Entertainment Centre \nAddress: 6360 Sunset Blvd., Los Angeles, CA";
        Assert.Equal(expectedOutput, testStorefront.ToString());
    }
}