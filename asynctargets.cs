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

    public async Task<int> GetBitmapWidth(string path)
    {
        using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            var fileId = new byte[2];
            var read = await file.ReadAsync(fileId, 0, 2);
            if (read != 2 || fileId[0] != 'B' || fileId[1] != 'M')
            throw new Exception("Not a BMP file");
            
            file.Seek(18, SeekOrigin.Begin);
            var widthBuffer = new byte[4];
            read = await file.ReadAsync(widthBuffer, 0, 4);
            if(read != 4) throw new Exception("Not a BMP file");
            return BitConverter.ToInt32(widthBuffer, 0);
        }
    }
}