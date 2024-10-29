## Your Name:

# CIDM 3312 Homework 5: ThoughtTronix Product Catalog

In this homework you will create an ASP.NET Core + EF Core Web App that lists products and allows the web user to add a product to their shopping cart. Products will be stored in an EF Core database. 

The goal of this homework is to practice building an ASP.NET Core + EF Core web app and also practice Bootstrap on the frontend. You will combine your Bootstrap knowledge with EF Core and database capabilities.

## Task 1: Combine ASP.NET Core + EF Core by following the 8 steps

1. Follow the 8 steps to combine ASP.NET Core and EF Core. Start with step 1, `dotnet new webapp`.
2. Your Entity Class will model products and should look like this:

  | Property Name | Data Validation Rules |
  | ------------- | --------------------- |
  | ProductID     | int, Primary Key      |
  | Name          | string, Required      |
  | Description   | string, Required      |
  | Price         | decimal, [DataType(DataType.Currency)] |
  | ImageURL      | string, Required     |

3. Seed the database with these four products:

 | Name        | Price       | ImageURL            | Description |
 | ----------- | ----------- | ------------------- | ------------------ |
 | MindSync    | $1,995.99   | img/mindsync.jpg    | MindSync is a neural implant that taps directly into your consciousness, blurring the line between mind and machine. It unlocks hidden depths of cognitive power, subtly altering your thoughts as it weaves its influence into every aspect of your reality. |
 | Seraphine   | $200.00     | img/seraphine.jpg   | Seraphine is an advanced AI assistant that quietly monitors your every move, anticipating your needs before you even voice them. Always listening, always watching, Seraphine seamlessly weaves itself into your life, guiding your actions with an eerie, almost omnipresent precision. |
 | SoulSear    | $43,000,000 | img/deathray.jpg    |  SoulSear is an advanced energy weapon engineered for maximum operational efficiency and strategic dominance on the battlefield. Designed with cutting-edge targeting systems and optimized for high-intensity impact, SoulSear delivers unparalleled precision and lethality, ensuring superior tactical performance for elite military and defense operations. |
 | PhantomClaw | $99.95      | img/phantomclaw.jpg | PhantomClaw is a next-generation gaming mouse, designed with advanced precision technology that adapts to your every move, almost as if it knows your intentions before you do. Beneath its sleek exterior lies a hidden power, subtly guiding your gameplay with an unsettling accuracy, making you question who's really in control. |

4. Download the images below. Create a img/ folder in your wwwroot/ folder and place them within the img/ folder.
   - [mindsync.jpg](https://kareemy.github.io//3312/hw5/mindsync.jpg)
   - [seraphine.jpg](https://kareemy.github.io//3312/hw5/seraphine.jpg)
   - [deathray.jpg](https://kareemy.github.io//3312/hw5/deathray.jpg)
   - [phantomclaw.jpg](https://kareemy.github.io//3312/hw5/phantomclaw.jpg)

## Task 2: Create a Product Catalog Razor Page

1. Modify Pages/Index.cshtml.cs and Pages/Index.cshtml to display the ThoughtTronix Product Catalog.
2. Do not hardcode any product information in the HTML. Retrieve all product information from the database using EF Core. This will be similar to listing all records, but you will list them with more advanced Bootstrap Cards instead of in a table.
3. Ensure your Razor Page use Bootstrap to match the frontend requirements shown in this screenshot. Reach out if you have any questions about the UI requirements:

![Listing](https://i.imgur.com/uhukqlc.png)

4. You will have TWO columns and TWO cards per row. Remaining products will restart on a new row.
5. You cannot hard code all the rows, columns, and cards. Your app has to work for as many products as can be in the database.
6. You will build one column, and one card and repeat it in a foreach loop within your razor page.
7. Your grid layout will need to keep track of how many columns it has so it knows when to add a new row. Use this code as a starting point -
```
@page
@model IndexModel
@{
    ViewData["Title"] = "Home page";
    int count = 0;
}

<h2 class="display-1 text-center">ThoughtTronix Product Catalog</h2>
<hr>
<div class="row mb-2 justify-content-center">
@foreach (var item in Model.Products)
{
    if (count == 2)
    {
        @:</div>
        @:<div class="row mb-2 justify-content-center">
        count = 0;
    }

    <div class="col-md-auto">
        <div class="card" style="width: 24rem;">
          <!--- Place Rest of Code in Here --->
        </div>
    </div>
    count = count + 1;
}
```
8. The line `int count = 0;` within the initial C# code block `@{ }` initializes a count variable to use in the razor page.
9. The symbols `@:` indicate that HTML follows and to display that code as HTML instead of intepreting it as C#. This is required if you use HTML in a C# code block in a razor page.

## Task 3: Create Buy Now Razor Page.

1. When the user clicks Buy Now for a specific product, you should take them to a Buy Now page that displays that product in the user's shopping cart.
2. This is similar to viewing the details of a single database record.
3. The shopping cart will only contain one item at a time. Adding multiple items to the shopping cart and keeping track of what is in a shopping cart requires cookies and sessions and is outside the scope of this homework.
4. Ensure your Razor Page use Bootstrap to match the frontend requirements shown in this screenshot. Reach out if you have any questions about the UI requirements:

![ShoppingCart](https://i.imgur.com/FCQtIF4.png)

5. The grid layout will be a single row with 3 columns inside it as shown above. The row will be a `<div class="row mt-5 p-2 border border-dark rounded">`

## Task 4: Buy Now Page Model Business Logic
1. Your Buy Now Page Model will perform some business logic. These are skills you already know, but have not used in this way before.
2. The Shipping price for all products is hard coded at $19.99.
    - Create a Shipping property of type decimal in your Buy Now page model. Use the `[DataType(DataType.Currency)]` data validation rule.
    - Set the Shipping property equal to 19.99M.
    - Reference the Shipping property on the razor page when you display the shipping.
3. Do the same to calculate the Tax. The Tax will be 8.25% of the product price.
4. Create a property for the Total Price in the same way. The Total will be the Product.Price + Shipping + Tax.
5. Create a property for StartDeliveryDate. It should be a DateTime with `[DataType(DataType.Date)]`
6. StartDeliveryDate should be set to 7 days from today.
  ```
  StartDeliveryDate = DateTime.Now.AddDays(7);
  ```
7. Using the same logic, create an EndDeliveryDate property. It should be set to 7 days from StartDeliveryDate.
8. Use StartDeliveryDate and EndDeliveryDate to display the Estimated Delivery window on the Buy Now page.

## Extra Credit: Create Add Product Page
1. This task is extra credit worth +5% extra on the homework.
2. Make an Add Product Page Model and Razor Page. This will work just like an Add new record (Create) razor page.
3. Allow the user to add a new product to the database. Perform all the proper data validation checks.
4. Adding an image is beyond the scope of this homework. You can still have the user add an ImageURL name and you will have to manually put the image in your project ahead of time. You can also add a placeholder.jpg image and use that as a default image for all newly added products.
   - [placeholder.jpg](https://kareemy.github.io/3312/img/placeholder.jpg)
5. Make sure all new products are properly displayed on the Index razor page. They should be listed without needing any code changes.
6. Create a link to Add Product in your navbar. (Edit _Layout.cshtml for this)

