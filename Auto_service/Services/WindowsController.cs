using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Auto_service.Services
{
    public class WindowsController
    {
        Dictionary<Type, Type> vmToWindowMapping = new Dictionary<Type, Type>();

        public void RegisterWindowType<VM, Win>() where Win : Window, new() where VM : class
        {
            var vmType = typeof(VM);
            if (vmType.IsInterface)
                throw new ArgumentException("Не удалось зарегистрировать интерфейсы");
            if (vmToWindowMapping.ContainsKey(vmType))
                throw new InvalidOperationException(
                    $"Тип {vmType.FullName} уже зарегистрирован");
            vmToWindowMapping[vmType] = typeof(Win);
        }

        public void UnregisterWindowType<VM>()
        {
            var vmType = typeof(VM);
            if (vmType.IsInterface)
                throw new ArgumentException("Не удалось зарегистрировать интерфейсы");
            if (!vmToWindowMapping.ContainsKey(vmType))
                throw new InvalidOperationException(
                    $"Тип {vmType.FullName} не зарегистрирован");
            vmToWindowMapping.Remove(vmType);
        }

        public Window CreateWindowInstanceWithVM(object vm)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");
            Type windowType = null;

            var vmType = vm.GetType();
            while (vmType != null && !vmToWindowMapping.TryGetValue(vmType, out windowType))
                vmType = vmType.BaseType;

            if (windowType == null)
                throw new ArgumentException(
                    $"Нет зарегистрированной формы типа {vm.GetType().FullName}");

            var window = (Window)Activator.CreateInstance(windowType);
            window.DataContext = vm;
            return window;
        }


        public Dictionary<object, Window> openWindows = new Dictionary<object, Window>();
        public Dictionary<object, Window> OpenWindows
        {
            get
            {
                return openWindows;
            }
        }
        public void ShowPresentation(object vm)
        {

            if (vm == null)
                throw new ArgumentNullException("vm");
            if (openWindows.ContainsKey(vm))
                throw new InvalidOperationException("UI для этой ViewModel уже отображн");
            var window = CreateWindowInstanceWithVM(vm);
            window.Show();
            openWindows[vm] = window;
        }


        public void HidePresentation(object vm)
        {
            Window window;
            //foreach (var windpw in openWindows)
            //{
            //    MessageBox.Show(windpw.Key.ToString());
            //}

            if (!openWindows.TryGetValue(vm, out window))
                throw new InvalidOperationException("UI для этой ViewModel ещё не отображён");
            window.Close();
            openWindows.Remove(vm);
        }

        public async Task ShowModalPresentation(object vm)
        {
            var window = CreateWindowInstanceWithVM(vm);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            await window.Dispatcher.InvokeAsync(() => window.ShowDialog());

        }

    }
}
