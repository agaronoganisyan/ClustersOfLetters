using UnityEngine;
using UnityEngine.EventSystems;

namespace ClusterGameplayLogic.ClusterLogic.ContainerLogic
{
    public abstract class ClusterContainerView : MonoBehaviour, IDropHandler
    {
        public abstract ClusterContainerViewModel GetClusterContainerViewModel();
        
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.TryGetComponent<ClusterView>(out ClusterView clusterView) &&
                GetClusterContainerViewModel().TryToAddCluster(clusterView.ViewModel))
            {
                clusterView.ViewModel.SetClusterContainer(GetClusterContainerViewModel());
            }
        }
    }
}