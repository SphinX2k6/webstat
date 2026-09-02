using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001B6B RID: 7019
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ExploreProgressController : UiControllerBase<ExploreProgressController>
{
	// Token: 0x0600CBD4 RID: 52180 RVA: 0x003662A9 File Offset: 0x003644A9
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ExploreProgressRewardIdsNotify>(ENotifyMessageId.ExploreProgressRewardIdsNotify, new Action<ExploreProgressRewardIdsNotify, Net.CallbackStatus>(this.HandleExploreProgressRewardIdsNotify));
	}

	// Token: 0x0600CBD5 RID: 52181 RVA: 0x003662C7 File Offset: 0x003644C7
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ExploreProgressRewardIdsNotify);
	}

	// Token: 0x0600CBD6 RID: 52182 RVA: 0x003662D9 File Offset: 0x003644D9
	protected override void OnAddEvents()
	{
		base.OnAddEvents();
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
	}

	// Token: 0x0600CBD7 RID: 52183 RVA: 0x003662FD File Offset: 0x003644FD
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
		base.OnRemoveEvents();
	}

	// Token: 0x0600CBD8 RID: 52184 RVA: 0x00366321 File Offset: 0x00364521
	private void HandleExploreProgressRewardIdsNotify(ExploreProgressRewardIdsNotify response, Net.CallbackStatus status)
	{
		ModelBase<ExploreProgressModel>.Instance.UpdateAreaStageRewardDataList(response.RewardIds.ToArray<int>());
	}

	// Token: 0x0600CBD9 RID: 52185 RVA: 0x00366338 File Offset: 0x00364538
	private void OnWorldDone()
	{
		this.AllExploreProgressAsyncRequest(0);
	}

	// Token: 0x0600CBDA RID: 52186 RVA: 0x00366344 File Offset: 0x00364544
	[NullableContext(0)]
	public UniTask<bool> AllExploreProgressAsyncRequest(int timeoutMs = 0)
	{
		ExploreProgressController.<AllExploreProgressAsyncRequest>d__6 <AllExploreProgressAsyncRequest>d__;
		<AllExploreProgressAsyncRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<AllExploreProgressAsyncRequest>d__.<>4__this = this;
		<AllExploreProgressAsyncRequest>d__.timeoutMs = timeoutMs;
		<AllExploreProgressAsyncRequest>d__.<>1__state = -1;
		<AllExploreProgressAsyncRequest>d__.<>t__builder.Start<ExploreProgressController.<AllExploreProgressAsyncRequest>d__6>(ref <AllExploreProgressAsyncRequest>d__);
		return <AllExploreProgressAsyncRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600CBDB RID: 52187 RVA: 0x00366390 File Offset: 0x00364590
	private void ExploreProgressResponseHandle(ExploreProgressResponse response)
	{
		ExploreProgressModel instance = ModelBase<ExploreProgressModel>.Instance;
		foreach (AreaExploreInfo areaExploreInfo in response.AreaProgress)
		{
			instance.RefreshExploreAreaData(areaExploreInfo);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnExploreProgressResponse);
	}

	// Token: 0x0600CBDC RID: 52188 RVA: 0x003663F4 File Offset: 0x003645F4
	[NullableContext(1)]
	public UniTask ReceiveAreaStageRewardAsyncRequest(int[] rewardIds)
	{
		ExploreProgressController.<ReceiveAreaStageRewardAsyncRequest>d__8 <ReceiveAreaStageRewardAsyncRequest>d__;
		<ReceiveAreaStageRewardAsyncRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ReceiveAreaStageRewardAsyncRequest>d__.<>4__this = this;
		<ReceiveAreaStageRewardAsyncRequest>d__.rewardIds = rewardIds;
		<ReceiveAreaStageRewardAsyncRequest>d__.<>1__state = -1;
		<ReceiveAreaStageRewardAsyncRequest>d__.<>t__builder.Start<ExploreProgressController.<ReceiveAreaStageRewardAsyncRequest>d__8>(ref <ReceiveAreaStageRewardAsyncRequest>d__);
		return <ReceiveAreaStageRewardAsyncRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600CBDD RID: 52189 RVA: 0x00366440 File Offset: 0x00364640
	private void ReceiveAreaStageRewardResponseHandle(ExploreProgressRewardResponse response)
	{
		if (((response != null) ? response.RewardIds : null) != null && response.RewardIds.Count > 0)
		{
			ModelBase<ExploreProgressModel>.Instance.UpdateAreaStageRewardDataList(response.RewardIds);
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.OnReceiveAreaStageRewardResponse, response.RewardIds);
		}
	}

	// Token: 0x0600CBDE RID: 52190 RVA: 0x00366490 File Offset: 0x00364690
	public UniTask QueryOnlinePlayersAreaAsyncRequest()
	{
		ExploreProgressController.<QueryOnlinePlayersAreaAsyncRequest>d__10 <QueryOnlinePlayersAreaAsyncRequest>d__;
		<QueryOnlinePlayersAreaAsyncRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<QueryOnlinePlayersAreaAsyncRequest>d__.<>4__this = this;
		<QueryOnlinePlayersAreaAsyncRequest>d__.<>1__state = -1;
		<QueryOnlinePlayersAreaAsyncRequest>d__.<>t__builder.Start<ExploreProgressController.<QueryOnlinePlayersAreaAsyncRequest>d__10>(ref <QueryOnlinePlayersAreaAsyncRequest>d__);
		return <QueryOnlinePlayersAreaAsyncRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600CBDF RID: 52191 RVA: 0x003664D3 File Offset: 0x003646D3
	private void QueryOnlinePlayersAreaResponseHandle(QueryOnlinePlayersAreaResponse response)
	{
		if (response.ErrorCode != ErrorCode.Success)
		{
			ConfigBase<ErrorCodeConfig>.Instance.GetTextByErrorId(response.ErrorCode);
			return;
		}
		ModelBase<ExploreProgressModel>.Instance.UpdateOnlinePlayersArea(response.AreaDict.ToDictionary<int, int>());
	}

	// Token: 0x0600CBE0 RID: 52192 RVA: 0x00366504 File Offset: 0x00364704
	public UniTask ExploreEntityTraceRequest(int exploratoryDegree, int areaId)
	{
		ExploreProgressController.<ExploreEntityTraceRequest>d__12 <ExploreEntityTraceRequest>d__;
		<ExploreEntityTraceRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExploreEntityTraceRequest>d__.exploratoryDegree = exploratoryDegree;
		<ExploreEntityTraceRequest>d__.areaId = areaId;
		<ExploreEntityTraceRequest>d__.<>1__state = -1;
		<ExploreEntityTraceRequest>d__.<>t__builder.Start<ExploreProgressController.<ExploreEntityTraceRequest>d__12>(ref <ExploreEntityTraceRequest>d__);
		return <ExploreEntityTraceRequest>d__.<>t__builder.Task;
	}
}
