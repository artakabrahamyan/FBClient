using FBClient.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBClient.ViewModels
{
    public class FBAppInfoViewModel : ViewModelBase
    {
        private IDialogService _dialogService;
        private IFBClientDispatcher _fbClientDispatcher;

        public FBAppInfoViewModel(IDialogService dialogService, IFBClientDispatcher fblientDispatcher)
        {
            _dialogService = dialogService;
            _fbClientDispatcher = fblientDispatcher;
        }

        // ------------------------------------------------
        private string _appId;

        public string AppId
        {
            get { return _appId; }
            set { Set(ref _appId, value); }
        }

        private string _appSecretKey;

        public string AppSecretKey
        {
            get { return _appSecretKey; }
            set { Set(ref _appSecretKey, value); }
        }

        private string _pageId;

        public string PageId
        {
            get { return _pageId; }
            set { Set(ref _pageId, value); }
        }

        private string _topicFilter;

        public string TopicFilter
        {
            get { return _topicFilter; }
            set { Set(ref _topicFilter, value); }
        }

        // ------------------------------------------------
        private RelayCommand _sendCommand;

        /// <summary>
        /// Gets the SendCommand.
        /// </summary>
        public RelayCommand SendCommand
        {
            get
            {
                return _sendCommand
                    ?? (_sendCommand = new RelayCommand(
                        async () =>
                        {
                            if(await _dialogService.ShowMessage("Are you sure to continue the WebAPI calling?", "Question", "YES", "NO", (p)=> { }))
                            {
                                var result = await _fbClientDispatcher.CallFBWebAPI_CommentsAndSaveInXML_Method(AppId, AppSecretKey, PageId, TopicFilter);

                                await _dialogService.ShowMessage(result.Message, result.Success ? "Information" : "Error");
                            }                           
                        }));
            }
        }
    }
}
