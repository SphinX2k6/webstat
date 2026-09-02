using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001554 RID: 5460
[NullableContext(1)]
[Nullable(0)]
public class RecallFinishState : IRegressTransitionState
{
	// Token: 0x17000D1B RID: 3355
	// (get) Token: 0x0600993F RID: 39231 RVA: 0x00281F20 File Offset: 0x00280120
	public Action<IRegressTransitionState> EndCallBack { get; }

	// Token: 0x06009940 RID: 39232 RVA: 0x00281F28 File Offset: 0x00280128
	public RecallFinishState(Action<IRegressTransitionState> endCallBack)
	{
		this.EndCallBack = endCallBack;
	}

	// Token: 0x06009941 RID: 39233 RVA: 0x00281F37 File Offset: 0x00280137
	public void Transition(UiViewBase view)
	{
		((ActivityRegressStartupView)view).GotoActivityViewAndCloseSelf();
		this.End();
	}

	// Token: 0x06009942 RID: 39234 RVA: 0x00281F4A File Offset: 0x0028014A
	public EActivityRecallTransitionStatus GetNextStatus()
	{
		return EActivityRecallTransitionStatus.Finish;
	}

	// Token: 0x06009943 RID: 39235 RVA: 0x00281F4D File Offset: 0x0028014D
	public void End()
	{
		this.EndCallBack(this);
	}
}
