using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200477B RID: 18299
	public class PostProcessTriggerStateInside : PostProcessTriggerStateBase
	{
		// Token: 0x0602F76D RID: 194413 RVA: 0x00B482D2 File Offset: 0x00B464D2
		[NullableContext(1)]
		public PostProcessTriggerStateInside(PostProcessTrigger owner, EPostProcessTriggerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<PostProcessTrigger, EPostProcessTriggerState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0602F76E RID: 194414 RVA: 0x00B482E0 File Offset: 0x00B464E0
		protected override void OnEnter(EPostProcessTriggerState? lastState)
		{
			double targetDefaultValue = base.GetTargetDefaultValue();
			this.Owner.GetPostProcessComponent().BlendWeight = (float)targetDefaultValue;
			this.LastInnerValue = targetDefaultValue;
			this.IsTickingState = false;
			this.Timer = 0.0;
		}

		// Token: 0x0602F76F RID: 194415 RVA: 0x00B48324 File Offset: 0x00B46524
		protected override void OnUpdate(float delta)
		{
			double targetDefaultValue = base.GetTargetDefaultValue();
			if (this.IsTickingState)
			{
				this.Timer += (double)delta / 1000.0;
				double num = Singleton<MathUtils>.Instance.Clamp(this.Timer / this.Owner.TransitionTime, 0.0, 1.0);
				this.Owner.GetPostProcessComponent().BlendWeight = (float)Singleton<MathUtils>.Instance.Lerp(this.LastInnerValue, targetDefaultValue, num);
				if (num >= 1.0)
				{
					this.IsTickingState = false;
					this.Timer = 0.0;
					this.LastInnerValue = targetDefaultValue;
					return;
				}
			}
			else if (this.LastInnerValue != targetDefaultValue)
			{
				this.IsTickingState = true;
				this.Timer = 0.0;
			}
		}

		// Token: 0x0401B1DC RID: 111068
		private double LastInnerValue;

		// Token: 0x0401B1DD RID: 111069
		private bool IsTickingState;

		// Token: 0x0401B1DE RID: 111070
		private double Timer;
	}
}
