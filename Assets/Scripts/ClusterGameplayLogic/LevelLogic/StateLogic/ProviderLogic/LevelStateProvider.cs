using System.Collections.Generic;
using ClusterGameplayLogic.ClusterLogic.GeneratorLogic;
using ClusterGameplayLogic.ClusterLogic.ListLogic;
using ClusterGameplayLogic.InputFieldLogic;
using ClusterGameplayLogic.InputFieldLogic.ListLogic;
using ClusterGameplayLogic.ValidatorLogic;
using Infrastructure.DataProviderLogic;
using Zenject;
using UniRx;

namespace ClusterGameplayLogic.LevelLogic.StateLogic.ProviderLogic
{
    public class LevelStateProvider : ILevelStateProvider
    {
        private string _dataFileName = "LevelStateData.json;";

        private LevelStateData _data;
        private LevelStateModel _model;
        private IClustersGenerator _generator;
        private ClustersListModel _clustersListModel;
        private InputFieldsListModel _inputFieldsModel;
        private IDataProvider _dataProvider;
        private IGameValidator _gameValidator;
        
        public LevelStateProvider(DiContainer container)
        {
            _model = container.Resolve<LevelStateModel>();
            _generator = container.Resolve<IClustersGenerator>();
            _clustersListModel = container.Resolve<ClustersListModel>();
            _inputFieldsModel = container.Resolve<InputFieldsListModel>();
            _dataProvider = container.Resolve<IDataProvider>();
            _gameValidator = container.Resolve<IGameValidator>();
            
            //_gameValidator.OnResultValidated.Subscribe((value) => ClearAndSaveState());
        }

        public void Provide()
        {
            // if (_data == null)
            //     _data = _dataProvider.LoadData<LevelStateData>(_dataFileName);
            //
            // if (_data.ClustersList == null || _data.ClustersList.Count == 0)
            // {
            //     _data.Setup(_generator.GenerateRandomClusters(), new List<InputFieldModel>());
            // }
            //
            // _model.Setup(_data.ClustersList, _data.InputFields);
             _model.Setup(_generator.GenerateRandomClusters(), new List<InputFieldModel>());
        }

        private void ClearAndSaveState()
        {
            _data.Remove();
            _dataProvider.SaveData(_dataFileName, _data);
        }

        private void SaveState()
        {
            _data.Setup(_clustersListModel.Clusters, _inputFieldsModel.InputFields);
            _dataProvider.SaveData(_dataFileName, _data);
        }
    }
}