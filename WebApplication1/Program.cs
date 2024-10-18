var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", async context =>
{
    var html = @"
    <!DOCTYPE html>
    <html lang='en'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>Lottery Game</title>
        <link rel='stylesheet' href='/css/style.css'> <!-- Link to your external CSS file -->
    </head>
    <body>
        <div class='container'>
            <h1>Team 8 presents the lottery game</h1>
            <p>Presentation</p>
            <p>Please choose a number between 1 and 10 and try your luck!</p>
            <form method='post' action='/lottery'>
                <input type='number' id='guess' name='guess' min='1' max='10' required>
                <br>
                <button type='submit'>Submit</button>
            </form>
        </div>
    </body>
    </html>";

    await context.Response.WriteAsync(html);
});

app.MapPost("/lottery", async context =>
{
    var form = await context.Request.ReadFormAsync();
    int userGuess = int.Parse(form["guess"]);

    // Generate a random number between 1 and 10
    Random random = new Random();
    int winningNumber = random.Next(1, 11);

    // Determine if the user's guess matches the winning number
    string result = userGuess == winningNumber ? "You won!" : $"You lose! The winning number was {winningNumber}.";

    // Create the response HTML with the result
    var responseHtml = $@"
    <!DOCTYPE html>
    <html lang='en'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>Lottery Result</title>
        <link rel='stylesheet' href='/css/style.css'> <!-- Link to your external CSS file -->
    </head>
    <body>
        <div class='container'>
            <h1>{result}</h1>
            <a href='/'>Play Again</a>
        </div>
    </body>
    </html>";

    await context.Response.WriteAsync(responseHtml);
});

// Start the application
app.Run();
