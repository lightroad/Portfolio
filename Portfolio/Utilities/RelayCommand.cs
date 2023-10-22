﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Portfolio.Utilities
{
	//class RelayCommand : ICommand
	//{
	//	private readonly Action<object> _execute;
	//	private readonly Func<object, bool> _canExecute;

	//	public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
	//	{
	//		_execute = execute;
	//		_canExecute = canExecute;
	//	}

	//	public event EventHandler CanExecuteChanged
	//	{
	//		add => CommandManager.RequerySuggested += value;
	//		remove => CommandManager.RequerySuggested -= value;
	//	}

	//	public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

	//	public void Execute(object parameter) => _execute?.Invoke(parameter);
	//}

	class RelayCommand<T> : ICommand
	{
		private readonly Action<T> _execute;
		private readonly Predicate<T> _canExecute;

		public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		public bool CanExecute(object parameter) => _canExecute?.Invoke((T)parameter) ?? true;

		public void Execute(object parameter) => _execute?.Invoke((T)parameter);
	}
}
