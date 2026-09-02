using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002B82 RID: 11138
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueSettleView : SurvivorsRogueSettleBaseView, ISurvivorsRogueCommandView
{
	// Token: 0x060162D1 RID: 90833 RVA: 0x006274C9 File Offset: 0x006256C9
	public SurvivorsRogueSettleView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x17001CE2 RID: 7394
	// (get) Token: 0x060162D2 RID: 90834 RVA: 0x006274D2 File Offset: 0x006256D2
	int ISurvivorsRogueCommandView.CommandIncId
	{
		get
		{
			return this.CommandIncId;
		}
	}

	// Token: 0x17001CE3 RID: 7395
	// (get) Token: 0x060162D3 RID: 90835 RVA: 0x006274DA File Offset: 0x006256DA
	SurvivorsRogueCommandBase ISurvivorsRogueCommandView.Command
	{
		get
		{
			return this.Command;
		}
	}

	// Token: 0x060162D4 RID: 90836 RVA: 0x006274E2 File Offset: 0x006256E2
	public void CloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x060162D5 RID: 90837 RVA: 0x006274EB File Offset: 0x006256EB
	protected override void OnClickBtnReturn()
	{
		ModelBase<SurvivorsRogueModel>.Instance.HasNewSettle = false;
		ControllerBase<SurvivorsRogueController>.Instance.LeaveRogueInstance();
	}

	// Token: 0x060162D6 RID: 90838 RVA: 0x00627502 File Offset: 0x00625702
	protected override void OnClickBtnReturnMain()
	{
		ModelBase<SurvivorsRogueModel>.Instance.HasNewSettle = true;
		ControllerBase<SurvivorsRogueController>.Instance.LeaveRogueInstance();
	}

	// Token: 0x060162D7 RID: 90839 RVA: 0x0062751C File Offset: 0x0062571C
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueSettleView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueSettleView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060162D8 RID: 90840 RVA: 0x0062755F File Offset: 0x0062575F
	[NullableContext(2)]
	protected override ResultView GetViewInfo()
	{
		return this.Command.GetViewInfo();
	}

	// Token: 0x060162D9 RID: 90841 RVA: 0x0062756C File Offset: 0x0062576C
	protected override void OnBeforeDestroy()
	{
		SurvivorsRogueCommandResultSettle command = this.Command;
		if (command == null)
		{
			return;
		}
		command.BindView(null);
	}

	// Token: 0x060162DA RID: 90842 RVA: 0x00627580 File Offset: 0x00625780
	public void Refresh()
	{
		UiAsyncTask task = new UiAsyncTask("SurvivorsRogueSettleView.Refresh", delegate()
		{
			SurvivorsRogueSettleView.<<Refresh>b__13_0>d <<Refresh>b__13_0>d;
			<<Refresh>b__13_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<Refresh>b__13_0>d.<>4__this = this;
			<<Refresh>b__13_0>d.<>1__state = -1;
			<<Refresh>b__13_0>d.<>t__builder.Start<SurvivorsRogueSettleView.<<Refresh>b__13_0>d>(ref <<Refresh>b__13_0>d);
			return <<Refresh>b__13_0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x0400ABA6 RID: 43942
	public int CommandIncId;

	// Token: 0x0400ABA7 RID: 43943
	public SurvivorsRogueCommandResultSettle Command;
}
