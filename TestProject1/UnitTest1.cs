using System.Diagnostics.Metrics;
using AngleSharp.Dom;
using Bunit;
using MauiApp1.Components.Pages;
using Xunit;

namespace TestProject1;

public class CounterTest : BunitContext
{
    [Fact]
    public void Test1()
    {
        //Arrange
        var cut = Render<Counter>();
        var btn = cut.Find("button[data-testid='ctnbtn']");
        var cnt = cut.Find("p[data-testid='count']");

        Assert.Equal("Current count: 0", cnt.TextContent.Trim());

        //Consideration:  I know I can use [Theory] for this, but want to keep it simple
        //                as focused on CI really rather than a whole test suite!
        int i = 0;
        do
        {
            //Act
            btn.Click();

            //Assert
            Assert.Equal($"Current count: {i + 1}", cnt.TextContent.Trim());

            ++i;
        }
        while (i < 3);
    }
}
