using UnityEngine;
using UnityEngine.EventSystems;

namespace ClusterGameplayLogic.ClusterLogic.ContainerLogic
{
    public abstract class ClusterContainerView : MonoBehaviour, IDropHandler
    {
        protected abstract ClusterContainerViewModel GetClusterContainerViewModel();
        
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.TryGetComponent<ClusterView>(out ClusterView clusterView) &&
                GetClusterContainerViewModel().IsCanAddCluster(clusterView.ViewModel))
            {
                clusterView.ViewModel.SetClusterContainer(GetClusterContainerViewModel());
            }
        }
    }
}