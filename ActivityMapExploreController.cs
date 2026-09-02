using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001376 RID: 4982
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityMapExploreController : ActivityControllerBase<ActivityMapExploreController>
{
	// Token: 0x0600888A RID: 34954 RVA: 0x00240150 File Offset: 0x0023E350
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x0600888B RID: 34955 RVA: 0x00240153 File Offset: 0x0023E353
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x0600888C RID: 34956 RVA: 0x00240155 File Offset: 0x0023E355
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_MapExplorationMain";
	}

	// Token: 0x0600888D RID: 34957 RVA: 0x0024015C File Offset: 0x0023E35C
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewMapExplore();
	}

	// Token: 0x0600888E RID: 34958 RVA: 0x00240163 File Offset: 0x0023E363
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.Data = new ActivityMapExploreData();
		return this.Data;
	}

	// Token: 0x0600888F RID: 34959 RVA: 0x00240176 File Offset: 0x0023E376
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ExploreActivityTaskInfoNotify>(ENotifyMessageId.ExploreActivityTaskInfoNotify, delegate(ExploreActivityTaskInfoNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			this.Data.UpdateTaskState(response.ActivityTasks);
			this.EmitActivityRedDot();
		});
	}

	// Token: 0x06008890 RID: 34960 RVA: 0x00240194 File Offset: 0x0023E394
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ExploreActivityTaskInfoNotify);
	}

	// Token: 0x06008891 RID: 34961 RVA: 0x002401A8 File Offset: 0x0023E3A8
	public UniTask RequestGetReward(int taskId)
	{
		ActivityMapExploreController.<RequestGetReward>d__9 <RequestGetReward>d__;
		<RequestGetReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestGetReward>d__.<>4__this = this;
		<RequestGetReward>d__.taskId = taskId;
		<RequestGetReward>d__.<>1__state = -1;
		<RequestGetReward>d__.<>t__builder.Start<ActivityMapExploreController.<RequestGetReward>d__9>(ref <RequestGetReward>d__);
		return <RequestGetReward>d__.<>t__builder.Task;
	}

	// Token: 0x06008892 RID: 34962 RVA: 0x002401F3 File Offset: 0x0023E3F3
	private void EmitActivityRedDot()
	{
		if (this.Data != null && this.Data.Id != 0)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.Data.Id);
		}
	}

	// Token: 0x0400402A RID: 16426
	[Nullable(2)]
	public ActivityMapExploreData Data;

	// Token: 0x0400402B RID: 16427
	private bool IsRequesting;
}
