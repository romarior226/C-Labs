using System.Windows;


namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private List<double> _mylist = new List<double>();
  
    public MainWindow()
    {
        InitializeComponent();
    }
    /// <summary>
    /// функція яка викликається коли хтось натискає на конпку AddNumbers
    /// спочатку читаємо рядок з лейбла розділяючи через Split а далі перевіряємо всі елементи в стрінгу і записуємо в масив а також на лейбл
    /// </summary>
    private void AddNumbers(object sender, RoutedEventArgs e)
    {
        if(!double.TryParse(TextBoxForCount.Text, out double count))
        {
            MessageBox.Show("Please enter a number");
            return;
        }
        string[] s = TextBoxForNumbers.Text.Split();
        foreach (var item in s)
        {
            if (_mylist.Count >= count)
            {
                RewriteListBox(SwichNumbersFromList());
                return;
            }
            
            if (!double.TryParse(item, out double number))
            {
                MessageBox.Show("Please enter a number");
                return;
            }
            _mylist.Add(number);
            Result.Items.Add("[ " + number + " ]");
        }
        
        TextBoxForNumbers.Clear();
    }
    /// <summary>
    /// фукнція яка перезаписує текстове поле щоб поміняти місцями 2 елемента
    /// вона приймає список switchedList і додає всі елементи на лейбл перед тим очистивши 
    /// </summary>
    void RewriteListBox(List<Double> switchedList)
    {
        MessageBox.Show("You Entered all numbers!");
        Result.Items.Clear();
        foreach (var item in switchedList)
        {
            Result.Items.Add("[" + item + " ]");
        }
    }
    /// <summary>
    /// фукнція яка повертає змінений масив де міняються два елементи
    /// </summary>
    List<Double> SwichNumbersFromList()
    {
        int maxNegIndex = -1;
        int minPosIndex = -1;
        double maxNeg = double.MinValue;
        double minPos = double.MaxValue;

        for (int i = 0; i < _mylist.Count; i++)
        {
            if (_mylist[i] < 0 && _mylist[i] > maxNeg)
            {
                maxNeg = _mylist[i];
                maxNegIndex = i;
            }

            if (_mylist[i] > 0 && _mylist[i] < minPos)
            {
                minPos = _mylist[i];
                minPosIndex = i;
            }
        }

        if (maxNegIndex == -1 && minPosIndex == -1) MessageBox.Show("No numbers found!");

        else if (maxNegIndex == -1) MessageBox.Show("No negative numbers found!");

        else if (minPosIndex == -1) MessageBox.Show("No odd numbers found!");

        else
        {
            List<double> switchedList = new List<double>(_mylist);

            switchedList[minPosIndex] = maxNeg;

            switchedList[maxNegIndex] = minPos;

            return switchedList;
        }
        return  _mylist;
    }
    /// <summary>
    /// фукнція викликається при натискані на кнопку Clear і очищає всі поля 
    /// </summary>
    private void Clear(object sender, RoutedEventArgs e)
    {
        _mylist.Clear();
        Result.Items.Clear();
        TextBoxForCount.Clear();
        TextBoxForNumbers.Clear();
    }
}