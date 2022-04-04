using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketWithTagCheck : XRSocketInteractor
{
    public MeshRenderer text;


    XRSocketInteractor socket;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    public string targetTag = string.Empty;

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && MatchUsingTag(interactable);
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && MatchUsingTag(interactable);
    }

    private bool MatchUsingTag(XRBaseInteractable interactable)
    {
        Debug.Log("");
        return interactable.CompareTag(targetTag);
    }

    public void socketChecking()
    {

        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();

        Debug.Log(objName.transform.name + " in socket of " + transform.name);
    }
}
