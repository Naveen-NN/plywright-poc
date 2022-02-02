using Microsoft.Playwright;
using System.Threading.Tasks;
using System.Collections.Generic;  
using System;  
using System.IO;  
using System.Text.Json;

class Program
{
    public static async Task Main()
    {
        UsersContext context = new UsersContext();
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions{
            Headless = false, 
            SlowMo = 2000
        });
        var page = await browser.NewPageAsync();
        
        var url  =  "http://localhost:4200/";
        
        string usersUrl  =  "https://jsonplaceholder.typicode.com/**";

        await page.RouteAsync(usersUrl,async route => {
            
            if(route.Request.Method.ToUpperInvariant() == "GET"){
                await route.FulfillAsync(new RouteFulfillOptions { 
                    Status = 200
                    , ContentType = "application/json"
                    , Headers = new List<KeyValuePair<string, string>>{ 
                            new KeyValuePair<string, string>("Access-Control-Allow-Credentials", "true" ),  
                            new KeyValuePair<string, string>("Access-Control-Allow-Origin", "*" ),  
                        }
                    , Body = context.Data });
            }
            else if(route.Request.Method.ToUpperInvariant() == "PUT"){
             
                context.UpdateUser(route.Request.PostData);
                
                await route.FulfillAsync(new RouteFulfillOptions { 
                    Status = 200
                    , ContentType = "application/json"
                    , Headers = new List<KeyValuePair<string, string>>{ 
                            new KeyValuePair<string, string>("Access-Control-Allow-Credentials", "true" ),  
                            new KeyValuePair<string, string>("Access-Control-Allow-Origin", "*" ),  
                        }
                    , Body = route.Request.PostData });
            }
            else{
                await route.ContinueAsync();
            }
         });

        await page.GotoAsync(url);
        
        await page.Locator("text=Leanne Graham").ClickAsync();;

        var number = new Random().Next(0, 1000000).ToString("D6");

        await page.FillAsync("input[aria-label=name]", $"Leanne Graham {number}");
        await page.FillAsync("input[aria-label=username]", $"Bret {number}");
        await page.FillAsync("input[aria-label=email]", $"Sincere{number}@april.biz");

        await page.Locator("button[aria-label=btn-save]").ClickAsync();;

        //This line is just to put wait on the browser
        await page.Locator("button[aria-label=btn-none]").ClickAsync();;

        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot.png" });

        await browser.CloseAsync();
    }
}

