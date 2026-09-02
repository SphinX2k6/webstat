using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200477D RID: 18301
	public class PostProcessTriggerStateOutside : PostProcessTriggerStateBase
	{
		// Token: 0x0602F773 RID: 194419 RVA: 0x00B484E9 File Offset: 0x00B466E9
		[NullableContext(1)]
		public PostProcessTriggerStateOutside(PostProcessTrigger owner, EPostProcessTriggerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<PostProcessTrigger, EPostProcessTriggerState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0602F774 RID: 194420 RVA: 0x00B484F4 File Offset: 0x00B466F4
		protected override void OnEnter(EPostProcessTriggerState? lastState)
		{
			this.Owner.GetPostProcessComponent().BlendWeight = 0f;
		}
	}
}
