# MVVM-LTE
MVVM LTE is a lightweight .Net Standard library for MVVM.

This library provides basic classes for developing your application in MVVM architecture.

You can download the latest MVVM LTE package from  [here](http://mvvmlight.codeplex.com/releases "MVVM LTE download").

MVVM LTE comes with one DLL with no dependencies.

 - MVVM.LTE.dll
 
## Main classes in MVVM.LTE.dll are:

1.  CustomObservableCollection- Extension class for ObservableCollection. It provides two methods: `Refresh()`  and `Refresh(T item)` for updating the UI when a model property is modified.
2.  ViewModelBase - Base class for ViewModel classes. It provides different implementations for NotifyPropertyChanged
3.  SimpleCommand - A command that implements the ICommand interface. More about commands  [here](https://docs.microsoft.com/en-us/dotnet/api/system.windows.input.icommand?view=net-5.0 "ICommand Interface").
4.  SimpleIOC - An  [IOC](http://en.wikipedia.org/wiki/Inversion_of_control "Inversion of Control")  container for registering and resolving instances.

## 👋Want to contribute to MVVM.LTE?

If you have a bug or an idea, browse the open issues before opening a new one. You can also take a look at [How to Contribute on GitHub](https://www.dataschool.io/how-to-contribute-on-github/ "How to contribute on GitHub")

