#nullable enable

namespace Game
{
    public sealed class PlayerFx : EntityFx
    {
        [field: UnityEngine.SerializeReference]
        [field: ResolveComponentInParent]
        public PlayerController PlayerController { get; private set; } = null!;

        public override EntityController EntityController => this.PlayerController;
    }
}
