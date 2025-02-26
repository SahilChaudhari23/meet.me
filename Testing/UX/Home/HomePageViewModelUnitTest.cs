﻿/// <author>P S Harikrishnan</author>
/// <created>26/11/2021</created>

using System.ComponentModel;
using Client.ViewModel;
using Dashboard;
using NUnit.Framework;
using static Testing.UX.Home.HomeUtils;

namespace Testing.UX.Home
{
    [TestFixture]
    internal class HomePageViewModelUnitTest
    {
        [SetUp]
        public void SetUp()
        {
            _homePageViewModel = new HomePageViewModel(new DummyClientSessionManager());
        }

        private HomePageViewModel _homePageViewModel;

        [Test]
        public void OnClientSessionChanged_UsersCountIsChanged()
        {
            // Arrange
            var sampleSession = new SessionData();
            var sampleUser1 = new UserData("User1", 1);
            var sampleUser2 = new UserData("User2", 2);
            sampleSession.AddUser(sampleUser1);
            sampleSession.AddUser(sampleUser2);

            // Act
            _homePageViewModel.OnClientSessionChanged(sampleSession);

            // Assert
            // Without calling DispatcherUtil.DoEvents() the test will fail
            DispatcherUtil.DoEvents();
            Assert.AreEqual(_homePageViewModel.users.Count, 2);
        }

        [Test]
        public void OnLeaveClient()
        {
            _homePageViewModel.LeftClient();
        }

        [Test]
        public void OnPropertyChanged_EventShouldBeRaised()
        {
            var samplePropertyName = "";
            _homePageViewModel.UsersListChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                samplePropertyName = e.PropertyName;
            };

            _homePageViewModel.OnPropertyChanged("testing");
            Assert.IsNotNull(samplePropertyName);
            Assert.AreEqual("testing", samplePropertyName);
        }
    }
}