using System.Collections.ObjectModel;
using System.Globalization;
using Shared;

namespace MauiApp2;

public partial class MainPage : ContentPage
{

  // properties
  public Phase Phase { get; set; } = new();

  public MainPage()
  {

    // initialize
    InitializeComponent();

    // build phase
    for (int g = 1; g <= 3; g++)
    {
      Goal goal = new Goal($"Goal {g}");
      for (int a = 1; a <= 5; a++)
      {
        Activity activity = new Activity($"Activity {a}");
        goal.Activities.Add(activity);
      }
      Phase.Goals.Add(goal);
    }

    // set context
    BindingContext = this;

  }

  private void SwitchDeclutter_Toggled(object sender, ToggledEventArgs e)
  {

    Switch s = (Switch)sender;
    foreach (var goal in Phase.Goals)
      goal.Activities[0].IsFiltered = s.IsToggled;

  }

  private void ButtonReset_Clicked(object sender, EventArgs e)
  {
    BindingContext = null;
    SwitchDeclutter.IsToggled = false;
    BindingContext = this;
  }

}

public class Activity : ViewModelBase
{

  // fields
  private string name = "";
  private string details = "";
  private bool isFiltered;

  // properties
  public string Name { get { return name; } set { name = value; NotifyPropertyChanged(); } }
  public string Details { get { return details; } set { details = value; NotifyPropertyChanged(); } }

  public bool IsFiltered { get { return isFiltered; } set { isFiltered = value; NotifyPropertyChanged(); } }

  // constructors
  public Activity() { }
  public Activity(string name)
  {
    Name = name;
  }

}

public class Goal : ViewModelBase
{

  // fields
  private ObservableCollection<Activity> activities = new();
  private string name = "";

  // properties
  public ObservableCollection<Activity> Activities { get { return activities; } set { activities = value; NotifyPropertyChanged(); } }
  public string Name { get { return name; } set { name = value; NotifyPropertyChanged(); } }

  // constructors
  public Goal() { }
  public Goal(string name)
  {
    Name = name;
  }

}

public class Phase : ViewModelBase
{

  // fields
  private ObservableCollection<Goal> goals = new();
  private string name = "";

  // properties
  public ObservableCollection<Goal> Goals { get { return goals; } set { goals = value; NotifyPropertyChanged(); } }
  public string Name { get { return name; } set { name = value; NotifyPropertyChanged(); } }

  // constructors
  public Phase() { }
  public Phase(string name)
  {
    Name = name;
  }

}

public class BooleanTrueToVisibilityFalseConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    return (bool?)value == true ? false : true;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
