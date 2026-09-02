using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Battle;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200477A RID: 18298
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PostProcessTriggerStateBase : StateBase<PostProcessTrigger, EPostProcessTriggerState>
	{
		// Token: 0x0602F768 RID: 194408 RVA: 0x00B481C8 File Offset: 0x00B463C8
		public PostProcessTriggerStateBase(PostProcessTrigger owner, EPostProcessTriggerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<PostProcessTrigger, EPostProcessTriggerState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0602F769 RID: 194409 RVA: 0x00B481D3 File Offset: 0x00B463D3
		protected override void OnEnter(EPostProcessTriggerState? lastState)
		{
		}

		// Token: 0x0602F76A RID: 194410 RVA: 0x00B481D5 File Offset: 0x00B463D5
		protected override void OnUpdate(float delta)
		{
		}

		// Token: 0x0602F76B RID: 194411 RVA: 0x00B481D7 File Offset: 0x00B463D7
		protected override void OnExit(EPostProcessTriggerState nextState)
		{
		}

		// Token: 0x0602F76C RID: 194412 RVA: 0x00B481DC File Offset: 0x00B463DC
		public double GetTargetDefaultValue()
		{
			EWuYinQuState? wuYinQuBattleState = this.Owner.GetWuYinQuBattleState();
			string wuYinQuBattleKey = this.Owner.GetWuYinQuBattleKey();
			EWuYinQuState? ewuYinQuState = wuYinQuBattleState;
			EWuYinQuState ewuYinQuState2 = EWuYinQuState.StateIdle;
			if (!(ewuYinQuState.GetValueOrDefault() == ewuYinQuState2 & ewuYinQuState != null))
			{
				ewuYinQuState = wuYinQuBattleState;
				ewuYinQuState2 = EWuYinQuState.Nothing;
				if (!(ewuYinQuState.GetValueOrDefault() == ewuYinQuState2 & ewuYinQuState != null))
				{
					ewuYinQuState = wuYinQuBattleState;
					ewuYinQuState2 = EWuYinQuState.StateFighting1;
					if (!(ewuYinQuState.GetValueOrDefault() == ewuYinQuState2 & ewuYinQuState != null))
					{
						ewuYinQuState = wuYinQuBattleState;
						ewuYinQuState2 = EWuYinQuState.StateFighting2;
						if (!(ewuYinQuState.GetValueOrDefault() == ewuYinQuState2 & ewuYinQuState != null))
						{
							ewuYinQuState = wuYinQuBattleState;
							ewuYinQuState2 = EWuYinQuState.StateFighting3;
							if (!(ewuYinQuState.GetValueOrDefault() == ewuYinQuState2 & ewuYinQuState != null))
							{
								return 0.0;
							}
						}
					}
					EWuYinQuState currentKeyState = ControllerBase<RenderModuleController>.Instance.GetCurrentKeyState(wuYinQuBattleKey);
					ewuYinQuState = wuYinQuBattleState;
					ewuYinQuState2 = currentKeyState;
					if (ewuYinQuState.GetValueOrDefault() == ewuYinQuState2 & ewuYinQuState != null)
					{
						return 1.0;
					}
					return 0.0;
				}
			}
			return !ControllerBase<RenderModuleController>.Instance.GetIdleClearAtmosphere(this.Owner.GetWuYinQuBattleKey());
		}
	}
}
