class asynctargets{
 
    int byteCount;
    public void ReadBytesGetCount(string targetBmp)
    {
        var readCompleted = File.ReadAllBytesAsync(targetBmp); 
        Console.WriteLine($"Starting work!: {DateTime.Now}");
        readCompleted.ContinueWith(t => 
            {                                  
                if (t.IsCompletedSuccessfully) 
                {                            
                    byteCount += t.Result.Length;       
                    Console.WriteLine($"I'm done.{DateTime.Now} Image file is {byteCount} bytes."); 
                    return; 
                }                                                                  
                Console.WriteLine($"I couldn't do that. {t.Exception.InnerExceptions[0].Message}"); 
            }); 
    }
}