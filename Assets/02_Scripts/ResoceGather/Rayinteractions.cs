using Photon.Pun;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class RayInteractorMaterialChange : MonoBehaviourPunCallbacks
{
    public NearFarInteractor nearFarInteractor;  // XRRay Interactor (Ray를 쏘는 역할)

    public void BBeep()
    {
        EditorApplication.Beep();
    }

    // Ray가 물체를 가리키고 있는지 체크하는 함수
    public override void OnJoinedRoom()
    {
        nearFarInteractor = App.Instance.rightnearFarInteractor;
        nearFarInteractor.selectEntered.AddListener((param1) =>
        {
            foreach (var item in param1.interactableObject.colliders)
            {
                if (item.CompareTag("Tree"))
                {
                    item.gameObject.GetComponent<MakeTree>()?.Doit(1);
                }
                if (item.CompareTag("Rock"))
                {
                    item.gameObject.GetComponent<MakeRock>()?.Doit(1);
                }
                if (item.CompareTag("Lever"))
                {
                    item.gameObject.GetComponent<trainRod>()?.Doit();
                }
            }
        });


    }

}
