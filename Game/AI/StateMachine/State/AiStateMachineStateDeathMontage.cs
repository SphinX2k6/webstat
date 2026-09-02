using System;
using System.Runtime.CompilerServices;
using System.Text;
using AkiClient.Game.Aki.Character.BaseCharacter.StateMachine;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070E8 RID: 28904
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineStateDeathMontage : AiStateMachineState
	{
		// Token: 0x0604612E RID: 287022 RVA: 0x01267B8D File Offset: 0x01265D8D
		public AiStateMachineStateDeathMontage(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x0604612F RID: 287023 RVA: 0x01267BAC File Offset: 0x01265DAC
		[NullableContext(2)]
		public override void OnActivate(AiStateMachineBase lastState = null, long? contextId = null)
		{
			BaseDeathComponent deathComponent = this.Node.DeathComponent;
			if (deathComponent == null)
			{
				return;
			}
			switch (this.DeathType)
			{
			case EMonsterDeathType.水中死亡:
				this.Handle = deathComponent.ReplaceDeathMontage(ECharacterDeathMontageType.DieInWater, this.MontageName);
				return;
			case EMonsterDeathType.空中死亡:
				this.Handle = deathComponent.ReplaceDeathMontage(ECharacterDeathMontageType.DieInAir, this.MontageName);
				return;
			}
			this.Handle = deathComponent.ReplaceDeathMontage(ECharacterDeathMontageType.Die, this.MontageName);
		}

		// Token: 0x06046130 RID: 287024 RVA: 0x01267C1F File Offset: 0x01265E1F
		[NullableContext(2)]
		public override void OnDeactivate(AiStateMachineBase nextState = null, long? contextId = null)
		{
			BaseDeathComponent deathComponent = this.Node.DeathComponent;
			if (deathComponent != null)
			{
				deathComponent.ResetDeathMontage(this.Handle);
			}
			this.Handle = -1;
		}

		// Token: 0x06046131 RID: 287025 RVA: 0x01267C44 File Offset: 0x01265E44
		protected override bool OnInit(CombatStateMachineDefine.Fsm.State state)
		{
			this.DeathType = (EMonsterDeathType)state.BindDeathMontage.DeathType;
			this.MontageName = state.BindDeathMontage.MontageName;
			return true;
		}

		// Token: 0x06046132 RID: 287026 RVA: 0x01267C6A File Offset: 0x01265E6A
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x04027500 RID: 161024
		public EMonsterDeathType DeathType;

		// Token: 0x04027501 RID: 161025
		public string MontageName = "";

		// Token: 0x04027502 RID: 161026
		public int Handle = -1;
	}
}
