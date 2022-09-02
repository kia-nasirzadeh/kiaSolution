//var bufferHeight = Console.BufferHeight;
//var bufferWidth = Console.BufferWidth;
//Console.WriteLine(bufferHeight);
//Console.WriteLine(bufferWidth);

//Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);




//Console.scr
using UIAutomationClient;
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Threading;
using System.Windows;
//using Terminal.Gui;
//using System.Windows.rect

class Demo
{
    static bool ProcessExists(int id)
    {
        return Process.GetProcesses().Any(x => x.Id == id);
    }
    static void Main()
    {


        var p = Process.GetCurrentProcess();
        var pid = Process.GetCurrentProcess().Id;
        pid = 6204;

        CUIAutomation cui = new();
        var condition = cui.CreatePropertyCondition(UIA_PropertyIds.UIA_ProcessIdPropertyId, pid);
        var mainWindow = cui.GetRootElement();
        var main2 = mainWindow.FindFirst(TreeScope.TreeScope_Children, condition);
        if (main2 != null)
            Console.WriteLine("good");
        else
            Console.WriteLine("damn");

        var winPat = mainWindow.GetCurrentPattern(UIA_PatternIds.UIA_WindowPatternId) as IUIAutomationWindowPattern;

        if (winPat != null)
            winPat.SetWindowVisualState(WindowVisualState.WindowVisualState_Maximized);
        else
            Console.WriteLine("damn");
        //Thread.Sleep(1000);

        //if (ProcessExists(pid)) Console.WriteLine("yes we have");
        //else Console.WriteLine("no we don't have");


        //var mainWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ProcessIdProperty, pid));
        //if (mainWindow == null) { Console.WriteLine("it is null"); }
        //else { var winPat = mainWindow.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern; }


        //if (ProcessExists(pid)) Console.WriteLine("yes we have");
        //else Console.WriteLine("no we don't have");

        //Console.ReadLine();



        //winPat.SetWindowVisualState(WindowVisualState.Maximized);

        //foreach (AutomationElement element in winCollection)
        //    Console.WriteLine(element.Current.Name);
        //Application.Init();
        //// making start up windows:
        //var win = new Window("kia solution")
        //{
        //    X = 0,
        //    Y = 0,
        //    Width = Dim.Fill(),
        //    Height = Dim.Fill(),
        //};
        //win.ColorScheme = new ColorScheme()
        //{
        //    Normal = new Terminal.Gui.Attribute(Color.White, Color.Black),
        //    HotNormal = new Terminal.Gui.Attribute(Color.White, Color.Black),
        //    Focus = new Terminal.Gui.Attribute(Color.White, Color.Black),
        //    HotFocus = new Terminal.Gui.Attribute(Color.White, Color.Black),
        //    Disabled = new Terminal.Gui.Attribute(Color.White, Color.Black),
        //};

        //// making kia solution Logo:
        //StringBuilder sbuilder = new StringBuilder();
        //sbuilder.AppendLine(@"_     _ _____ _______                     _______  _____         _     _ _______ _____  _____  __   _");
        //sbuilder.AppendLine(@"|____/    |   |_____|                     |______ |     | |      |     |    |      |   |     | | \  |");
        //sbuilder.AppendLine(@"|    \_ __|__ |     |                     ______| |_____| |_____ |_____|    |    __|__ |_____| |  \_|");
        //Label kiaSolutionLabel = new(sbuilder.ToString())
        //{
        //    X = Pos.Center(),
        //    Y = Pos.Center(),
        //    Width = 101,
        //    Height = 3,
        //};
        //// button:
        //var btn = new Button("he")
        //{
        //    X = 10,
        //    Y = 10,
        //    Width = 10,
        //    Height = 10,
        //};
        //btn.Clicked += () =>
        //{
        //    var a = Console.BufferWidth;
        //    var newLabel = new Label(a.ToString())
        //    {
        //        X = 20,
        //        Y = 20,
        //        Width = 20,
        //        Height = 20,
        //    };            
        //    var b = Console.LargestWindowWidth;
        //    var newLabel2 = new Label(b.ToString())
        //    {
        //        X = 27,
        //        Y = 27,
        //        Width = 27,
        //        Height = 27,
        //    };
        //    win.Add(newLabel, newLabel2);
        //};
        //win.Add(btn);
        //win.Add(kiaSolutionLabel);
        //Application.Top.Add(win);
        //Application.Run();
        //Application.Shutdown();
    }
}