using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020020B3 RID: 8371
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class LevelPlayReportController : UiControllerBase<LevelPlayReportController>
{
	// Token: 0x0600FF9E RID: 65438 RVA: 0x004629AE File Offset: 0x00460BAE
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<LevelPlayGainRewardInfoNotify>(ENotifyMessageId.LevelPlayGainRewardInfoNotify, new Action<LevelPlayGainRewardInfoNotify, Net.CallbackStatus>(this.OnLevelPlayGainRewardInfoNotify));
	}

	// Token: 0x0600FF9F RID: 65439 RVA: 0x004629CC File Offset: 0x00460BCC
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LevelPlayGainRewardInfoNotify);
	}

	// Token: 0x0600FFA0 RID: 65440 RVA: 0x004629E0 File Offset: 0x00460BE0
	[NullableContext(0)]
	public UniTask<bool> RequestSimpleTrackReportAsync()
	{
		LevelPlayReportController.<RequestSimpleTrackReportAsync>d__2 <RequestSimpleTrackReportAsync>d__;
		<RequestSimpleTrackReportAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestSimpleTrackReportAsync>d__.<>1__state = -1;
		<RequestSimpleTrackReportAsync>d__.<>t__builder.Start<LevelPlayReportController.<RequestSimpleTrackReportAsync>d__2>(ref <RequestSimpleTrackReportAsync>d__);
		return <RequestSimpleTrackReportAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FFA1 RID: 65441 RVA: 0x00462A1C File Offset: 0x00460C1C
	public UniTask CheckAndRequestLevelPlayVarAsync(int instId, int levelPlayId)
	{
		LevelPlayReportController.<CheckAndRequestLevelPlayVarAsync>d__3 <CheckAndRequestLevelPlayVarAsync>d__;
		<CheckAndRequestLevelPlayVarAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckAndRequestLevelPlayVarAsync>d__.<>4__this = this;
		<CheckAndRequestLevelPlayVarAsync>d__.instId = instId;
		<CheckAndRequestLevelPlayVarAsync>d__.levelPlayId = levelPlayId;
		<CheckAndRequestLevelPlayVarAsync>d__.<>1__state = -1;
		<CheckAndRequestLevelPlayVarAsync>d__.<>t__builder.Start<LevelPlayReportController.<CheckAndRequestLevelPlayVarAsync>d__3>(ref <CheckAndRequestLevelPlayVarAsync>d__);
		return <CheckAndRequestLevelPlayVarAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FFA2 RID: 65442 RVA: 0x00462A70 File Offset: 0x00460C70
	public UniTask RequestLevelPlayVarAsync(int instId, int levelPlayId)
	{
		LevelPlayReportController.<RequestLevelPlayVarAsync>d__4 <RequestLevelPlayVarAsync>d__;
		<RequestLevelPlayVarAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestLevelPlayVarAsync>d__.instId = instId;
		<RequestLevelPlayVarAsync>d__.levelPlayId = levelPlayId;
		<RequestLevelPlayVarAsync>d__.<>1__state = -1;
		<RequestLevelPlayVarAsync>d__.<>t__builder.Start<LevelPlayReportController.<RequestLevelPlayVarAsync>d__4>(ref <RequestLevelPlayVarAsync>d__);
		return <RequestLevelPlayVarAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FFA3 RID: 65443 RVA: 0x00462ABC File Offset: 0x00460CBC
	public UniTask RequestPlayPointStateAsync(int areaId, int sceneId)
	{
		LevelPlayReportController.<RequestPlayPointStateAsync>d__5 <RequestPlayPointStateAsync>d__;
		<RequestPlayPointStateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestPlayPointStateAsync>d__.areaId = areaId;
		<RequestPlayPointStateAsync>d__.sceneId = sceneId;
		<RequestPlayPointStateAsync>d__.<>1__state = -1;
		<RequestPlayPointStateAsync>d__.<>t__builder.Start<LevelPlayReportController.<RequestPlayPointStateAsync>d__5>(ref <RequestPlayPointStateAsync>d__);
		return <RequestPlayPointStateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FFA4 RID: 65444 RVA: 0x00462B08 File Offset: 0x00460D08
	public UniTask RequestSingleLevelPlayStateListAsync(int instId, int levelPlayId)
	{
		LevelPlayReportController.<RequestSingleLevelPlayStateListAsync>d__6 <RequestSingleLevelPlayStateListAsync>d__;
		<RequestSingleLevelPlayStateListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestSingleLevelPlayStateListAsync>d__.<>4__this = this;
		<RequestSingleLevelPlayStateListAsync>d__.instId = instId;
		<RequestSingleLevelPlayStateListAsync>d__.levelPlayId = levelPlayId;
		<RequestSingleLevelPlayStateListAsync>d__.<>1__state = -1;
		<RequestSingleLevelPlayStateListAsync>d__.<>t__builder.Start<LevelPlayReportController.<RequestSingleLevelPlayStateListAsync>d__6>(ref <RequestSingleLevelPlayStateListAsync>d__);
		return <RequestSingleLevelPlayStateListAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FFA5 RID: 65445 RVA: 0x00462B5C File Offset: 0x00460D5C
	public UniTask RequestLevelPlayStateListAsync(List<InstLevelPlayStateReq> requestList)
	{
		LevelPlayReportController.<RequestLevelPlayStateListAsync>d__7 <RequestLevelPlayStateListAsync>d__;
		<RequestLevelPlayStateListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestLevelPlayStateListAsync>d__.requestList = requestList;
		<RequestLevelPlayStateListAsync>d__.<>1__state = -1;
		<RequestLevelPlayStateListAsync>d__.<>t__builder.Start<LevelPlayReportController.<RequestLevelPlayStateListAsync>d__7>(ref <RequestLevelPlayStateListAsync>d__);
		return <RequestLevelPlayStateListAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FFA6 RID: 65446 RVA: 0x00462BA0 File Offset: 0x00460DA0
	public UniTask RequestLevelPlayRewardsAsync(int instId, int levelPlayId)
	{
		LevelPlayReportController.<RequestLevelPlayRewardsAsync>d__8 <RequestLevelPlayRewardsAsync>d__;
		<RequestLevelPlayRewardsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestLevelPlayRewardsAsync>d__.instId = instId;
		<RequestLevelPlayRewardsAsync>d__.levelPlayId = levelPlayId;
		<RequestLevelPlayRewardsAsync>d__.<>1__state = -1;
		<RequestLevelPlayRewardsAsync>d__.<>t__builder.Start<LevelPlayReportController.<RequestLevelPlayRewardsAsync>d__8>(ref <RequestLevelPlayRewardsAsync>d__);
		return <RequestLevelPlayRewardsAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FFA7 RID: 65447 RVA: 0x00462BEB File Offset: 0x00460DEB
	private void OnLevelPlayGainRewardInfoNotify(LevelPlayGainRewardInfoNotify data, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<LevelPlayReportModel>.Instance.UpdateLevelPlayRewardMsgByNotify(data);
	}
}
