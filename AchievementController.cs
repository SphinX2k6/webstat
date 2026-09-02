using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02000FCB RID: 4043
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class AchievementController : ControllerBase<AchievementController>
{
	// Token: 0x060067D5 RID: 26581 RVA: 0x001B1244 File Offset: 0x001AF444
	protected override bool OnInit()
	{
		this.OnAddEvents();
		this.OnRegisterNetEvent();
		return true;
	}

	// Token: 0x060067D6 RID: 26582 RVA: 0x001B1253 File Offset: 0x001AF453
	protected override bool OnClear()
	{
		this.OnRemoveEvents();
		this.OnUnRegisterNetEvent();
		return true;
	}

	// Token: 0x060067D7 RID: 26583 RVA: 0x001B1264 File Offset: 0x001AF464
	protected void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Add(EEventName.BattleViewActiveSequenceFinish, new Action(this.OnBattleViewShow));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>, IReadOnlyList<int>, IReadOnlyList<int>, int, int>(EEventName.TsSyncAchievementFinish, new Action<IReadOnlyList<int>, IReadOnlyList<int>, IReadOnlyList<int>, int, int>(this.TsSyncAchievementFinish));
	}

	// Token: 0x060067D8 RID: 26584 RVA: 0x001B12C8 File Offset: 0x001AF4C8
	protected void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.BattleViewActiveSequenceFinish, new Action(this.OnBattleViewShow));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncAchievementFinish, new Action<IReadOnlyList<int>, IReadOnlyList<int>, IReadOnlyList<int>, int, int>(this.TsSyncAchievementFinish));
	}

	// Token: 0x060067D9 RID: 26585 RVA: 0x001B132C File Offset: 0x001AF52C
	protected void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<AchievementProgressNotify>(ENotifyMessageId.AchievementProgressNotify, new Action<AchievementProgressNotify, Net.CallbackStatus>(this.OnAchievementProgressNotify));
		Singleton<Net>.Instance.Register<AchievementGroupProgressNotify>(ENotifyMessageId.AchievementGroupProgressNotify, new Action<AchievementGroupProgressNotify, Net.CallbackStatus>(this.OnAchievementGroupProgressNotify));
		Singleton<Net>.Instance.Register<AchievementListProgressNotify>(ENotifyMessageId.AchievementListProgressNotify, new Action<AchievementListProgressNotify, Net.CallbackStatus>(this.OnAchievementListProgressNotify));
		Singleton<Net>.Instance.Register<AchievementCountChangeNotify>(ENotifyMessageId.AchievementCountChangeNotify, new Action<AchievementCountChangeNotify, Net.CallbackStatus>(this.OnAchievementCountChangeNotify));
	}

	// Token: 0x060067DA RID: 26586 RVA: 0x001B13AC File Offset: 0x001AF5AC
	protected void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AchievementProgressNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AchievementGroupProgressNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AchievementListProgressNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AchievementCountChangeNotify);
	}

	// Token: 0x060067DB RID: 26587 RVA: 0x001B13F9 File Offset: 0x001AF5F9
	public void OpenAchievementMainView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AchievementMainView, null, null);
	}

	// Token: 0x060067DC RID: 26588 RVA: 0x001B140C File Offset: 0x001AF60C
	public void ChangeAchievementPopViewShowState()
	{
		this.AchievementPopViewShowState = !this.AchievementPopViewShowState;
	}

	// Token: 0x060067DD RID: 26589 RVA: 0x001B1420 File Offset: 0x001AF620
	public void OpenAchievementDetailView(int categoryId, int? groupId, int achievementId = -1)
	{
		AchievementGroupData achievementGroupData = ModelBase<AchievementModel>.Instance.GetAchievementGroupData(groupId);
		AchievementCategoryData category = ModelBase<AchievementModel>.Instance.GetCategory(categoryId);
		ModelBase<AchievementModel>.Instance.CurrentSelectCategory = category;
		ModelBase<AchievementModel>.Instance.CurrentSelectGroup = achievementGroupData;
		ModelBase<AchievementModel>.Instance.AchievementSearchState = false;
		ModelBase<AchievementModel>.Instance.CurrentSelectAchievementId = achievementId;
		ModelBase<AchievementModel>.Instance.CurrentSearchText = "";
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AchievementDetailView, null, null);
	}

	// Token: 0x060067DE RID: 26590 RVA: 0x001B1491 File Offset: 0x001AF691
	private void OnLoadingNetDataDone()
	{
		this.RequestAchievementBasicInfo();
	}

	// Token: 0x060067DF RID: 26591 RVA: 0x001B149C File Offset: 0x001AF69C
	private UniTask RequestAchievementBasicInfo()
	{
		AchievementController.<RequestAchievementBasicInfo>d__11 <RequestAchievementBasicInfo>d__;
		<RequestAchievementBasicInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestAchievementBasicInfo>d__.<>1__state = -1;
		<RequestAchievementBasicInfo>d__.<>t__builder.Start<AchievementController.<RequestAchievementBasicInfo>d__11>(ref <RequestAchievementBasicInfo>d__);
		return <RequestAchievementBasicInfo>d__.<>t__builder.Task;
	}

	// Token: 0x060067E0 RID: 26592 RVA: 0x001B14D8 File Offset: 0x001AF6D8
	public UniTask RequestUpdateAchievementInfo()
	{
		AchievementController.<RequestUpdateAchievementInfo>d__12 <RequestUpdateAchievementInfo>d__;
		<RequestUpdateAchievementInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestUpdateAchievementInfo>d__.<>1__state = -1;
		<RequestUpdateAchievementInfo>d__.<>t__builder.Start<AchievementController.<RequestUpdateAchievementInfo>d__12>(ref <RequestUpdateAchievementInfo>d__);
		return <RequestUpdateAchievementInfo>d__.<>t__builder.Task;
	}

	// Token: 0x060067E1 RID: 26593 RVA: 0x001B1514 File Offset: 0x001AF714
	public void RequestGetAchievementReward(bool isGroup, int id)
	{
		AchievementReceiveRequest achievementReceiveRequest = AchievementReceiveRequest.Create();
		achievementReceiveRequest.Id = id;
		achievementReceiveRequest.IsGroupId = isGroup;
		Singleton<Net>.Instance.Call<AchievementReceiveResponse>(ERequestMessageId.AchievementReceiveRequest, achievementReceiveRequest, delegate(AchievementReceiveResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24135, null, true, true);
			}
		}, 0);
	}

	// Token: 0x060067E2 RID: 26594 RVA: 0x001B1568 File Offset: 0x001AF768
	public void RequestGetMultiAchievementReward(int[] ids, int[] groupIds)
	{
		MulAchievementReceiveRequest mulAchievementReceiveRequest = MulAchievementReceiveRequest.Create();
		mulAchievementReceiveRequest.AchievementIds.AddRange(ids);
		mulAchievementReceiveRequest.AchievementGroupIds.AddRange(groupIds);
		Singleton<Net>.Instance.Call<MulAchievementReceiveResponse>(ERequestMessageId.MulAchievementReceiveRequest, mulAchievementReceiveRequest, delegate(MulAchievementReceiveResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17544, null, true, true);
			}
		}, 0);
	}

	// Token: 0x060067E3 RID: 26595 RVA: 0x001B15C4 File Offset: 0x001AF7C4
	public void RequestAchievementFinish(int id)
	{
		AchievementFinishRequest achievementFinishRequest = AchievementFinishRequest.Create();
		achievementFinishRequest.Id = id;
		Singleton<Net>.Instance.Call<AchievementFinishResponse>(ERequestMessageId.AchievementFinishRequest, achievementFinishRequest, delegate(AchievementFinishResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26894, null, true, true);
			}
		}, 0);
	}

	// Token: 0x060067E4 RID: 26596 RVA: 0x001B160E File Offset: 0x001AF80E
	private void OnAchievementProgressNotify(AchievementProgressNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		this.UpdateAchievement(message.AchievementEntry);
	}

	// Token: 0x060067E5 RID: 26597 RVA: 0x001B161C File Offset: 0x001AF81C
	[NullableContext(2)]
	private void UpdateAchievement(AchievementEntry data)
	{
		EAchievementStateEnum finishState = ModelBase<AchievementModel>.Instance.GetAchievementData(data.Id).GetFinishState();
		ModelBase<AchievementModel>.Instance.OnAchievementProgressNotify(data);
		EAchievementStateEnum finishState2 = ModelBase<AchievementModel>.Instance.GetAchievementData(data.Id).GetFinishState();
		if (finishState != finishState2 && finishState2 != EAchievementStateEnum.HaveGetReward && finishState2 != EAchievementStateEnum.UnFinished)
		{
			AchievementData achievementData = ModelBase<AchievementModel>.Instance.GetAchievementData(data.Id);
			if (!ModelBase<AchievementModel>.Instance.IsHideAchievementGroup(achievementData.GetGroupId()))
			{
				ModelBase<AchievementModel>.Instance.CurrentFinishAchievementArray.Add(data.Id);
				this.TryOpenAchievementFinishView();
			}
		}
	}

	// Token: 0x060067E6 RID: 26598 RVA: 0x001B16A7 File Offset: 0x001AF8A7
	private void OnBattleViewShow()
	{
		this.TryOpenAchievementFinishView();
	}

	// Token: 0x060067E7 RID: 26599 RVA: 0x001B16B0 File Offset: 0x001AF8B0
	private void TryOpenAchievementFinishView()
	{
		if (!this.AchievementPopViewShowState)
		{
			return;
		}
		List<int> currentFinishAchievementArray = ModelBase<AchievementModel>.Instance.CurrentFinishAchievementArray;
		while (currentFinishAchievementArray.Count > 0)
		{
			int id = currentFinishAchievementArray[0];
			currentFinishAchievementArray.RemoveAt(0);
			AchievementData achievementData = ModelBase<AchievementModel>.Instance.GetAchievementData(id);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.AchievementCompleteTipsView, achievementData, null);
		}
	}

	// Token: 0x060067E8 RID: 26600 RVA: 0x001B1708 File Offset: 0x001AF908
	private void OnAchievementListProgressNotify(AchievementListProgressNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		int count = message.AchievementEntryList.Count;
		for (int i = 0; i < count; i++)
		{
			this.UpdateAchievement(message.AchievementEntryList[i]);
		}
	}

	// Token: 0x060067E9 RID: 26601 RVA: 0x001B173F File Offset: 0x001AF93F
	private void OnAchievementCountChangeNotify(AchievementCountChangeNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<AchievementModel>.Instance.OnAchievementCountChangeNotify(message);
	}

	// Token: 0x060067EA RID: 26602 RVA: 0x001B174C File Offset: 0x001AF94C
	private void OnAchievementGroupProgressNotify(AchievementGroupProgressNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<AchievementModel>.Instance.OnAchievementGroupProgressNotify(message);
	}

	// Token: 0x060067EB RID: 26603 RVA: 0x001B1759 File Offset: 0x001AF959
	private void TsSyncAchievementFinish(IReadOnlyList<int> categoryIds, IReadOnlyList<int> groupIds, IReadOnlyList<int> achievementIds, int startCount, int finishCount)
	{
		ModelBase<AchievementModel>.Instance.OnTsDataReady(categoryIds, groupIds, achievementIds, startCount, finishCount);
	}

	// Token: 0x04003183 RID: 12675
	private bool AchievementPopViewShowState = true;
}
