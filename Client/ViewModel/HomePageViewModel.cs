﻿using System;
using System.Windows;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Dashboard;
using Dashboard.Client.SessionManagement;
using Client;

namespace Client.ViewModel
{

    class HomePageViewModel : IClientSessionNotifications
    {
        private IUXClientSessionManager _model;

        public List<UserViewData> users
        {
            get; private set;
        }
        public HomePageViewModel()
        {
            _model = SessionManagerFactory.GetClientSessionManager();
            _model.SubscribeSession(this);
            users = new List<UserViewData>();
        }

        public void OnClientSessionChanged(SessionData session)
        {
            if (users != null)
            {
                users.Clear();
            }
            _ = this.ApplicationMainThreadDispatcher.BeginInvoke(
                        DispatcherPriority.Normal,
                        new Action<List<UserViewData>>((users) =>
                        {
                            lock (this)
                            {
                                foreach (UserData user in session.users)
                                {
                                    UserViewData usernew = new UserViewData();
                                    usernew.username = user.username;
                                    if(user.userID == ChatViewModel.UserId)
                                    {
                                        usernew.username += " (You)";
                                    }
                                    usernew.shortname = user.username.Substring(0,2);
                                    users.Add(usernew);
                                }
                                this.OnPropertyChanged("ListChanged");
                            }
                        }),
                        users);
        }

        public void LeftClient()
        {
            _model.RemoveClient();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Handles the property changed event raised on a component.
        /// </summary>
        /// <param name="property">The name of the property.</param>
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        private Dispatcher ApplicationMainThreadDispatcher =>
            (Application.Current?.Dispatcher != null) ?
                    Application.Current.Dispatcher :
                    Dispatcher.CurrentDispatcher;
    }
}
