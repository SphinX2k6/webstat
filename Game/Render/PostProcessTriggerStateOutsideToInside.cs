using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200477E RID: 18302
	public class PostProcessTriggerStateOutsideToInside : PostProcessTriggerStateBase
	{
		// Token: 0x0602F775 RID: 194421 RVA: 0x00B4850B File Offset: 0x00B4670B
		[NullableContext(1)]
		public PostProcessTriggerStateOutsideToInside(PostProcessTrigger owner, EPostProcessTriggerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<PostProcessTrigger, EPostProcessTriggerState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0602F776 RID: 194422 RVA: 0x00B48516 File Offset: 0x00B46716
		protected override void OnEnter(EPostProcessTriggerState? lastState)
		{
			this.Timer = 0.0;
			this.Owner.GetPostProcessComponent().BlendWeight = 0f;
		}

		// Token: 0x0602F777 RID: 194423 RVA: 0x00B4853C File Offset: 0x00B4673C
		protected override void OnUpdate(float delta)
		{
			if (this.Timer > this.Owner.TransitionTime)
			{
				this.StateMachine.Switch(EPostProcessTriggerState.Inside);
				return;
			}
			this.Timer += (double)delta / 1000.0;
			double num = Singleton<MathUtils>.Instance.Clamp(this.Timer / this.Owner.TransitionTime, 0.0, base.GetTargetDefaultValue());
			this.Owner.GetPostProcessComponent().BlendWeight = (float)num;
		}

		// Token: 0x0401B1E0 RID: 111072
		protected double Timer;
	}
}
