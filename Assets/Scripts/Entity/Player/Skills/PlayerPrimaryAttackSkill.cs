#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerPrimaryAttackSkill : PlayerSkill
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        private PlayerSkillManager playerSkillManager = null!;

        public override PlayerSkillManager PlayerSkillManager => this.playerSkillManager;

        protected override void CastLogic()
        {
            var playerGeneralStateMachine = this.PlayerGeneralStateMachine;
            playerGeneralStateMachine.SetStateToChangeTo(playerGeneralStateMachine.PrimaryAttackState);
        }
    }
}
