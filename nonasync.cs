class nonasync{
    public int GetBitmapWidth(string path)
    {
        using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            var fileId = new byte[2];                
            var read = file.Read(fileId, 0, 2);      
            if (read != 2 || fileId[0] != 'B' || fileId[1] != 'M'){
                Console.WriteLine("Not a BMP file");
                throw new Exception("Not a BMP file");
            }
            
            file.Seek(18, SeekOrigin.Begin);      
            var widthBuffer = new byte[4];        
            read = file.Read(widthBuffer, 0, 4);  
            if(read != 4){
                 Console.WriteLine($"Not a BMP file.");
                 throw new Exception("Not a BMP file");
            }
            var width = BitConverter.ToInt32(widthBuffer, 0);
            Console.WriteLine($"The image is {width} pixels wide.");
            return width;
        }
    }
}