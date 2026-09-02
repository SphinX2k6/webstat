using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001552 RID: 5458
[NullableContext(1)]
[Nullable(0)]
public class RecallShowRewardState : IRegressTransitionState
{
	// Token: 0x17000D19 RID: 3353
	// (get) Token: 0x06009935 RID: 39221 RVA: 0x00281ECC File Offset: 0x002800CC
	public Action<IRegressTransitionState> EndCallBack { get; }

	// Token: 0x06009936 RID: 39222 RVA: 0x00281ED4 File Offset: 0x002800D4
	public RecallShowRewardState(Action<IRegressTransitionState> endCallBack)
	{
		this.EndCallBack = endCallBack;
	}

	// Token: 0x06009937 RID: 39223 RVA: 0x00281EE3 File Offset: 0x002800E3
	public void Transition(UiViewBase view)
	{
	}

	// Token: 0x06009938 RID: 39224 RVA: 0x00281EE5 File Offset: 0x002800E5
	public EActivityRecallTransitionStatus GetNextStatus()
	{
		return EActivityRecallTransitionStatus.WaitToGetReward;
	}

	// Token: 0x06009939 RID: 39225 RVA: 0x00281EE8 File Offset: 0x002800E8
	public void End()
	{
		this.EndCallBack(this);
	}
}
