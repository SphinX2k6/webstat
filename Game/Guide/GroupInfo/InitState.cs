using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Guide.StepInfo;

namespace CSharpScript.Game.Guide.GroupInfo
{
	// Token: 0x02004A7C RID: 19068
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InitState : StateBase<GuideGroupInfo, EGuideGroupState>
	{
		// Token: 0x06031C48 RID: 203848 RVA: 0x00C766BF File Offset: 0x00C748BF
		public InitState(GuideGroupInfo owner, EGuideGroupState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<GuideGroupInfo, EGuideGroupState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06031C49 RID: 203849 RVA: 0x00C766CC File Offset: 0x00C748CC
		protected override void OnStart()
		{
			this.Owner.BreakExcludeStepIdSet = ConfigBase<GuideConfig>.Instance.GetBreakExcludeStepIdSetOfGroup(this.Owner.Id);
			this.Owner.StepInfoList.Clear();
			foreach (int stepId in ConfigBase<GuideConfig>.Instance.GetOrderedStepIdsOfGroup(this.Owner.Id, Singleton<Info>.Instance.InputControllerMainType))
			{
				this.Owner.StepInfoList.Add(new GuideStepInfo(stepId, this.Owner));
			}
			this.Owner.CurrentStepIndex = -1;
			this.Owner.IsFake = false;
			if (this.Owner.FinishPromise != null)
			{
				this.Owner.FinishPromise.SetResult();
				this.Owner.FinishPromise = null;
			}
		}

		// Token: 0x06031C4A RID: 203850 RVA: 0x00C76798 File Offset: 0x00C74998
		protected override void OnEnter(EGuideGroupState? lastState)
		{
			this.Owner.CurrentStepIndex = -1;
			this.Owner.IsFake = false;
		}
	}
}
