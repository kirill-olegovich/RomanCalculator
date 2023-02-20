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
            string testI = "I";
            string testV = "V";
            string testX = "X";
            string testL = "L";
            string testC = "C";
            string testD = "D";
            string testM = "M";
            string test1 = "XX";
            string test2 = "V";

            var text = mainWindow.GetVisualDescendants().OfType<TextBox>().First();
            var buttonClear = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Clear");
            var buttonCalc = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Calc");
            var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Add");
            var buttonSub = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Sub");
            var buttonMul = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Mul");
            var buttonDiv = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Div");
            var buttonI = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "I");
            var buttonV = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "V");
            var buttonX = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "X");
            var buttonL = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "L");
            var buttonC = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "C");
            var buttonD = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "D");
            var buttonM = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "M");

            buttonI.Command.Execute(buttonI.CommandParameter);
            t = text.Text;
            Assert.True(t.Equals(testI));
            buttonClear.Command.Execute(buttonClear.CommandParameter);

            buttonV.Command.Execute(buttonV.CommandParameter);
            t = text.Text;
            Assert.True(t.Equals(testV));
            buttonClear.Command.Execute(buttonClear.CommandParameter);

            buttonX.Command.Execute(buttonX.CommandParameter);
            t = text.Text;
            Assert.True(t.Equals(testX));
            buttonClear.Command.Execute(buttonClear.CommandParameter);

            buttonL.Command.Execute(buttonL.CommandParameter);
            t = text.Text;
            Assert.True(t.Equals(testL));
            buttonClear.Command.Execute(buttonClear.CommandParameter);

            buttonC.Command.Execute(buttonC.CommandParameter);
            t = text.Text;
            Assert.True(t.Equals(testC));
            buttonClear.Command.Execute(buttonClear.CommandParameter);

            buttonD.Command.Execute(buttonD.CommandParameter);
            t = text.Text;
            Assert.True(t.Equals(testD));
            buttonClear.Command.Execute(buttonClear.CommandParameter);

            buttonM.Command.Execute(buttonM.CommandParameter);
            t = text.Text;
            Assert.True(t.Equals(testM));
            buttonClear.Command.Execute(buttonClear.CommandParameter);

            // Check < X + X = XX >
            buttonX.Command.Execute(buttonX.CommandParameter);
            buttonAdd.Command.Execute(buttonAdd.CommandParameter);
            buttonX.Command.Execute(buttonX.CommandParameter);
            buttonCalc.Command.Execute(buttonCalc.CommandParameter);
            t = text.Text;
            Assert.True(t.Equals(test1));
            buttonClear.Command.Execute(buttonClear.CommandParameter);

            // Check < X / II = V >
            buttonX.Command.Execute(buttonX.CommandParameter);
            buttonDiv.Command.Execute(buttonDiv.CommandParameter);
            buttonI.Command.Execute(buttonI.CommandParameter);
            buttonI.Command.Execute(buttonI.CommandParameter);
            buttonCalc.Command.Execute(buttonCalc.CommandParameter);
            t = text.Text;
            Assert.True(t.Equals(test2));
            buttonClear.Command.Execute(buttonClear.CommandParameter);
        }
    }
}