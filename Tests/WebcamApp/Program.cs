using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WebcamCaptureConsole;

class Program
{
    static void Main(string[] args)
    {
        // Установка кодировки консоли на UTF-8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Получение списка доступных видеоустройств
        FilterInfoCollection videoDevices = new(FilterCategory.VideoInputDevice);

        if (videoDevices.Count == 0)
        {
            Console.WriteLine("Видеоустройства не найдены.");
            return;
        }

        // Выбор первого доступного устройства
        VideoCaptureDevice videoSource = new(videoDevices[0].MonikerString);
        videoSource.NewFrame += new NewFrameEventHandler(Video_NewFrame);
        videoSource.Start();

        Console.WriteLine("Нажмите любую клавишу для завершения...");
        Console.ReadKey();

        // Остановка захвата видео
        videoSource.SignalToStop();
        videoSource.WaitForStop();
    }

    private static void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        // Получение текущего кадра
        using (Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone())
        {
            // Сохранение кадра в файл
            string fileName = Path.Combine(Directory.GetCurrentDirectory(), "frame.jpg");
            bitmap.Save(fileName, ImageFormat.Jpeg);
            Console.WriteLine($"Кадр сохранен: {fileName}");
        }
    }
}


// dotnet add package AForge.Video
// dotnet add package AForge.Video.DirectShow
// dotnet add package System.Drawing.Common
// dotnet build
// dotnet run