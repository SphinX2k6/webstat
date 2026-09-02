using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200477C RID: 18300
	public class PostProcessTriggerStateInsideToOutside : PostProcessTriggerStateBase
	{
		// Token: 0x0602F770 RID: 194416 RVA: 0x00B483F7 File Offset: 0x00B465F7
		[NullableContext(1)]
		public PostProcessTriggerStateInsideToOutside(PostProcessTrigger owner, EPostProcessTriggerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<PostProcessTrigger, EPostProcessTriggerState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0602F771 RID: 194417 RVA: 0x00B48404 File Offset: 0x00B46604
		protected override void OnEnter(EPostProcessTriggerState? lastState)
		{
			this.Timer = 0.0;
			double targetDefaultValue = base.GetTargetDefaultValue();
			this.Owner.GetPostProcessComponent().BlendWeight = (float)targetDefaultValue;
		}

		// Token: 0x0602F772 RID: 194418 RVA: 0x00B4843C File Offset: 0x00B4663C
		protected override void OnUpdate(float delta)
		{
			if (this.Timer > this.Owner.TransitionTime)
			{
				this.StateMachine.Switch(EPostProcessTriggerState.Outside);
				return;
			}
			this.Timer += (double)delta / 1000.0;
			double num = Singleton<MathUtils>.Instance.Clamp(this.Timer / this.Owner.TransitionTime, 0.0, 1.0);
			double targetDefaultValue = base.GetTargetDefaultValue();
			this.Owner.GetPostProcessComponent().BlendWeight = (float)Singleton<MathUtils>.Instance.Clamp(1.0 - num, 0.0, targetDefaultValue);
		}

		// Token: 0x0401B1DF RID: 111071
		protected double Timer;
	}
}
