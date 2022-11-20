﻿using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Windows;

namespace DownKyi.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        protected readonly IEventAggregator eventAggregator;
        protected IDialogService dialogService;
        protected string ParentView = string.Empty;

        public BaseViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public BaseViewModel(IEventAggregator eventAggregator, IDialogService dialogService)
        {
            this.eventAggregator = eventAggregator;
            this.dialogService = dialogService;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            string viewName = navigationContext.Parameters.GetValue<string>("Parent");
            if (viewName != null)
            {
                ParentView = viewName;
            }
        }


        /// <summary>
        /// 异步修改绑定到UI的属性
        /// </summary>
        /// <param name="callback"></param>
        protected void PropertyChangeAsync(Action callback)
        {
            if (Application.Current == null) { return; }

            Application.Current.Dispatcher.Invoke(callback);
        }

    }
}
