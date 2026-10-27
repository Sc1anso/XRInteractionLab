using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;
using UnityEngine.Events;

public sealed class PowerCellTaskManager : MonoBehaviour
{
    public enum TaskState { NotStarted, InProgress, Completed }

    [SerializeField] private GrabInteractable grabInteractable;
    [SerializeField] private HandGrabInteractable handGrabInteractable;
    [SerializeField] private SnapInteractor snapInteractor;
    [SerializeField] private SnapInteractable batteryDock;
    [SerializeField] private UnityEvent onInProgress = new UnityEvent();
    [SerializeField] private UnityEvent onCompleted = new UnityEvent();

    public TaskState CurrentState { get; private set; } = TaskState.NotStarted;
    public UnityEvent OnInProgress => onInProgress;
    public UnityEvent OnCompleted => onCompleted;

    public void Configure(GrabInteractable grab, HandGrabInteractable handGrab,
        SnapInteractor snap, SnapInteractable dock)
    {
        grabInteractable = grab;
        handGrabInteractable = handGrab;
        snapInteractor = snap;
        batteryDock = dock;
    }

private void OnEnable()
    {
        if (grabInteractable != null)
            grabInteractable.WhenSelectingInteractorAdded.Action += HandleGrabStarted;
        if (handGrabInteractable != null)
            handGrabInteractable.WhenSelectingInteractorAdded.Action += HandleHandGrabStarted;
        if (snapInteractor != null)
            snapInteractor.WhenInteractableUnselected.Action += HandleSnapCompleted;
    }

private void OnDisable()
    {
        if (grabInteractable != null)
            grabInteractable.WhenSelectingInteractorAdded.Action -= HandleGrabStarted;
        if (handGrabInteractable != null)
            handGrabInteractable.WhenSelectingInteractorAdded.Action -= HandleHandGrabStarted;
        if (snapInteractor != null)
            snapInteractor.WhenInteractableUnselected.Action -= HandleSnapCompleted;
    }

    private void HandleGrabStarted(GrabInteractor interactor) => BeginTask();
    private void HandleHandGrabStarted(HandGrabInteractor interactor) => BeginTask();

    private void BeginTask()
    {
        if (CurrentState != TaskState.NotStarted) return;
        CurrentState = TaskState.InProgress;
        onInProgress.Invoke();
    }

private void HandleSnapCompleted(SnapInteractable interactable)
    {
        if (interactable != batteryDock || CurrentState == TaskState.Completed) return;
        if (CurrentState == TaskState.NotStarted) BeginTask();
        CurrentState = TaskState.Completed;
        onCompleted.Invoke();
    }
}
