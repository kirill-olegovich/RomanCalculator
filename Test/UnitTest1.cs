using Avalonia.Controls;
using Avalonia.VisualTree;

namespace Test
{
	public class UnitTest1
	{
		[Fact]
		public async void Test1()
		{
			var app = AvaloniaApp.GetApp();
			var mainWindow = AvaloniaApp.GetMainWindow();
			string t;
                        string test1 = "I";
			string test2 = "V";
			string test3 = "X";
			string test4 = "XX";
			string test5 = "V";

                        var text = mainWindow.GetVisualDescendants().OfType<TextBox>().First();
                        var buttonClear = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Clear");
                        var buttonCalc = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Calc");
                        var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Add");
                        var buttonDiv = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Div");
                        var button1 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "I");
                        var button2 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "V");
                        var button3 = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "X");

                        // Check < I > character
                        button1.Command.Execute(button1.CommandParameter);
			t = text.Text;
			Assert.True(t.Equals(test1));
                        buttonClear.Command.Execute(buttonClear.CommandParameter);

                        // Check < V > character
                        button2.Command.Execute(button2.CommandParameter);
                        t = text.Text;
                        Assert.True(t.Equals(test2));
                        buttonClear.Command.Execute(buttonClear.CommandParameter);

                        // Check < X > character
                        button3.Command.Execute(button3.CommandParameter);
                        t = text.Text;
                        Assert.True(t.Equals(test3));
                        buttonClear.Command.Execute(buttonClear.CommandParameter);

                        // Check < X + X = XX >
                        button3.Command.Execute(button3.CommandParameter);
                        buttonAdd.Command.Execute(buttonAdd.CommandParameter);
                        button3.Command.Execute(button3.CommandParameter);
                        buttonCalc.Command.Execute(buttonCalc.CommandParameter);
                        t = text.Text;
                        Assert.True(t.Equals(test4));
                        buttonClear.Command.Execute(buttonClear.CommandParameter);

                        // Check < X / II = V >
                        button3.Command.Execute(button3.CommandParameter);
                        buttonDiv.Command.Execute(buttonDiv.CommandParameter);
                        button1.Command.Execute(button1.CommandParameter);
                        button1.Command.Execute(button1.CommandParameter);
                        buttonCalc.Command.Execute(buttonCalc.CommandParameter);
                        t = text.Text;
                        Assert.True(t.Equals(test5));
                        buttonClear.Command.Execute(buttonClear.CommandParameter);
                }
        }
}