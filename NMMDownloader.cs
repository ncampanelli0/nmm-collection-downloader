using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys.send?view=windowsdesktop-8.0&redirectedfrom=MSDN#System_Windows_Forms_SendKeys_Send_System_String_

public class NMMDownloader
{
    MKBController controller = new MKBController();

    int exitButtonX = 1900;
    int exitButtonY = 20;

    int downloadButtonX = 1238;
    int downloadButtonY = 526;

    int slowDownloadButtonX = 1037;
    int slowDownloadButtonY = 799;

    int openVortexX = 1085;
    int openVortexY = 265;
    public static void Main(string[] args)
    {

        NMMDownloader downloader = new NMMDownloader();
        Console.WriteLine("Instructions to setup, read before using: \n\n");

        Console.WriteLine("setup a virtual desktop (windows key + tab)");
        Console.WriteLine("top left: new desktop");
        Console.WriteLine("you can move programs between desktops by clicking and dragging them after pressing windows key + tab \n\n");

        Console.WriteLine("Make sure the only things open on your virtual desktop are: \n");
        Console.WriteLine("your default browser");
        Console.WriteLine("vortex mod manager opened on the first download of the collection");
        Console.WriteLine("maximized window size for both");
        Console.WriteLine("start with vortex visible on your screen \n\n");
        Console.WriteLine("After entering in the following 2 numbers, switch to your virtual desktop \n\n");

        Console.WriteLine("Enter the number of mods (numerical values only): ");
        int modCount = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the delay (Minimum should be 10, numerical values only)");
        int programDelay = Convert.ToInt32(Console.ReadLine());
        programDelay *= 1000;

        Console.WriteLine("Program will begin downloading in 10 seconds");

        Thread.Sleep(10000);

        for (int i = 0; i < modCount; i++)
        {
            downloader.pressDownload();
            Thread.Sleep(programDelay);
            downloader.altTab();
            Thread.Sleep(programDelay);
            downloader.pressSlowDownload();
            Thread.Sleep(programDelay);
            downloader.pressOpenVortex();
            Thread.Sleep(programDelay);
            downloader.altTab();
            Thread.Sleep(programDelay);
        }

    }

    public void pressDownload()
    {
        controller.moveMouse(downloadButtonX, downloadButtonY);
        controller.LeftMouseClick();
    }

    public void altTab()
    {
        controller.KeyType("%{Tab}");
    }

    public void pressSlowDownload()
    {
        controller.moveMouse(slowDownloadButtonX, slowDownloadButtonY);
        controller.LeftMouseClick();
    }

    public void pressOpenVortex()
    {
        controller.moveMouse(openVortexX, openVortexY);
        controller.LeftMouseClick();
    }

    public void exitWindow()
    {
        controller.moveMouse(exitButtonX, exitButtonY);
        controller.LeftMouseClick();
    }



}