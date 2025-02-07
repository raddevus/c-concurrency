// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

if (args.Length < 1){
    Console.WriteLine("Please provide valid parameter(s).");
    return;
}
// Test non-async
nonasync na = new();
na.GetBitmapWidth(args[0]);

asynctargets at = new();
at.ReadBytesGetCount(args[0]);


var readCompleted = at.GetBitmapWidth("test.bmp"); 
readCompleted.ContinueWith(t => 
    { 
        if (t.IsCompletedSuccessfully) 
        { 
            Console.WriteLine($"I'm done.{DateTime.Now} - width is: {readCompleted.Result}"); 
            return; 
        } 
        Console.WriteLine("got here..."); 
    });
