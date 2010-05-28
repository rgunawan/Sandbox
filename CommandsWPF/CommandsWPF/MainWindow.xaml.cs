using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommandsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            button1.Command = MyTestCommand();

            

            var copyCommandBinding = new CommandBinding(MyTestCommand());
            copyCommandBinding.Executed += OnCopyExecuted;
            
            this.CommandBindings.Add(copyCommandBinding);

            var inputBinding = new InputBinding(MyTestCommand(),
                                                new KeyGesture(Key.R, ModifierKeys.Control));
            this.InputBindings.Add(inputBinding);
            
        }

        private void OnCopyExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Copy done.");
        }

        private static readonly ICommand MyTestCommandInternal = new TestCommand();

        public static ICommand MyTestCommand()
        {
            return MyTestCommandInternal;
        }
    }

    class TestCommand:RoutedCommand
    {

        public new void Execute(object parameter, System.Windows.IInputElement target)
        {
            base.Execute(parameter, target);

            MessageBox.Show("execute");
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        //public event EventHandler CanExecuteChanged;
    }
}
