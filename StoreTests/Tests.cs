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
}