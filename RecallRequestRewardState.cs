using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001553 RID: 5459
[NullableContext(1)]
[Nullable(0)]
public class RecallRequestRewardState : IRegressTransitionState
{
	// Token: 0x17000D1A RID: 3354
	// (get) Token: 0x0600993A RID: 39226 RVA: 0x00281EF6 File Offset: 0x002800F6
	public Action<IRegressTransitionState> EndCallBack { get; }

	// Token: 0x0600993B RID: 39227 RVA: 0x00281EFE File Offset: 0x002800FE
	public RecallRequestRewardState(Action<IRegressTransitionState> endCallBack)
	{
		this.EndCallBack = endCallBack;
	}

	// Token: 0x0600993C RID: 39228 RVA: 0x00281F0D File Offset: 0x0028010D
	public void Transition(UiViewBase view)
	{
	}

	// Token: 0x0600993D RID: 39229 RVA: 0x00281F0F File Offset: 0x0028010F
	public EActivityRecallTransitionStatus GetNextStatus()
	{
		return EActivityRecallTransitionStatus.ReqRewardAndJumpActivity;
	}

	// Token: 0x0600993E RID: 39230 RVA: 0x00281F12 File Offset: 0x00280112
	public void End()
	{
		this.EndCallBack(this);
	}
}
