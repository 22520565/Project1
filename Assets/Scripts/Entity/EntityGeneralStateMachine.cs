#nullable enable

namespace Game;

using UnityEngine;

[DisallowMultipleComponent]
public abstract class EntityGeneralStateMachine : MonoBehaviour
{
    private IEntityState currentState = null!;
    private IEntityState? stateToChangeTo = null;
    private IEntityState lastState = null!;

    public abstract EntityController EntityController { get; }

    public abstract IEntityState InitialState { get; }

    public string LastAnimationBoolName => this.lastState.AnimationBoolName;

    public bool HasStateToChangeTo()
    {
        return this.stateToChangeTo != null;
    }

    public void SetStateToChangeTo(IEntityState newState)
    {
        this.stateToChangeTo = newState;
    }

    public void SetStateToLastState()
    {
        this.stateToChangeTo = this.lastState;
    }

    public void CancelChangingState()
    {
        this.stateToChangeTo = null;
    }

    public void AnimationFinishTrigger() => this.currentState.AnimationFinishTrigger();

    protected void Awake()
    {
        this.lastState = this.InitialState;
        this.currentState = this.InitialState;
        this.currentState.Enter();
    }

    protected void Update()
    {
        if (this.stateToChangeTo == null)
        {
            this.currentState.Update();
        }

        while (this.stateToChangeTo != null)
        {
            this.currentState.Exit();
            this.currentState = this.stateToChangeTo;
            this.stateToChangeTo = null;
            this.currentState.Enter();

            // TODO: should we update state right after changing?
            // this.currentState.Update();
        }
    }
}
