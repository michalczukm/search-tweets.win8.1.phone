﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ShowTweets.DataAccess;
using ShowTweets.Navigation;
using ShowTweets.Services;

namespace ShowTweets.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ItemViewModel Item
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ItemViewModel>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                RegisterDesignImplementations();
            }
            else
            {
                RegisterProductionImplementations();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ItemViewModel>();
        }

        private static void RegisterProductionImplementations()
        {
            SimpleIoc.Default.Register<ITwitterCredentialStoreProvider, TwitterCredentialStoreProvider>();
            SimpleIoc.Default.Register<ITwitterFeedService, TwitterFeedService>();
            SimpleIoc.Default.Register<INavigationService>(() => new NavigationService());
            SimpleIoc.Default.Register<ITweetsDataContextFactory, TweetsDataContextFactory>();
            SimpleIoc.Default.Register<ICommentsService, CommentsService>();
        }

        private static void RegisterDesignImplementations()
        {
            SimpleIoc.Default.Register<ITwitterFeedService, DesignTwitterFeedService>();
            SimpleIoc.Default.Register<INavigationService, DesignNavigationService>();
            SimpleIoc.Default.Register<ITweetsDataContextFactory, DesignTweetsDataContextFactory>();
            SimpleIoc.Default.Register<ICommentsService, DesignCommentsService>();
        }
    }
}