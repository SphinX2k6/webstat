using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002983 RID: 10627
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ShipTowerController : UiControllerBase<ShipTowerController>
{
	// Token: 0x060152E5 RID: 86757 RVA: 0x005DD52C File Offset: 0x005DB72C
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<SlashAndTowerResultNotify>(ENotifyMessageId.SlashAndTowerResultNotify, new Action<SlashAndTowerResultNotify, Net.CallbackStatus>(this.HandleSlashAndTowerResultNotify));
		Singleton<Net>.Instance.Register<SlashAndTowerLevelPlayNotify>(ENotifyMessageId.SlashAndTowerLevelPlayNotify, new Action<SlashAndTowerLevelPlayNotify, Net.CallbackStatus>(this.HandleSlashAndTowerLevelPlayNotify));
		Singleton<Net>.Instance.Register<SlashAndTowerOverNotify>(ENotifyMessageId.SlashAndTowerOverNotify, new Action<SlashAndTowerOverNotify, Net.CallbackStatus>(this.HandleSlashAndTowerOverNotify));
	}

	// Token: 0x060152E6 RID: 86758 RVA: 0x005DD58D File Offset: 0x005DB78D
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SlashAndTowerResultNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SlashAndTowerLevelPlayNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SlashAndTowerOverNotify);
	}

	// Token: 0x060152E7 RID: 86759 RVA: 0x005DD5C0 File Offset: 0x005DB7C0
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.EventWorldDone));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.EventOnAddCommonItemList));
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.EventFunctionOpen));
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(this.EventCrossDay));
	}

	// Token: 0x060152E8 RID: 86760 RVA: 0x005DD640 File Offset: 0x005DB840
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.EventWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.EventOnAddCommonItemList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.EventFunctionOpen));
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(this.EventCrossDay));
	}

	// Token: 0x060152E9 RID: 86761 RVA: 0x005DD6BD File Offset: 0x005DB8BD
	private void HandleSlashAndTowerResultNotify(SlashAndTowerResultNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("ShipTower");
		ModelBase<ShipTowerModel>.Instance.UpdateResultNotify(response);
	}

	// Token: 0x060152EA RID: 86762 RVA: 0x005DD6D9 File Offset: 0x005DB8D9
	private void HandleSlashAndTowerLevelPlayNotify(SlashAndTowerLevelPlayNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<ShipTowerModel>.Instance.UpdateLevelPlayNotify(response);
	}

	// Token: 0x060152EB RID: 86763 RVA: 0x005DD6E6 File Offset: 0x005DB8E6
	private void HandleSlashAndTowerOverNotify(SlashAndTowerOverNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<ShipTowerModel>.Instance.UpdateSeasonNotify(response);
	}

	// Token: 0x060152EC RID: 86764 RVA: 0x005DD6F3 File Offset: 0x005DB8F3
	private void EventWorldDone()
	{
		if (ModelBase<ShipTowerModel>.Instance.CheckInBattleShipTower())
		{
			Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("ShipTower");
		}
		ModelBase<ShipTowerModel>.Instance.CheckInitProto(true).Forget<bool>();
	}

	// Token: 0x060152ED RID: 86765 RVA: 0x005DD720 File Offset: 0x005DB920
	private void EventCrossDay()
	{
		ModelBase<ShipTowerModel>.Instance.CheckInitProto(true).Forget<bool>();
	}

	// Token: 0x060152EE RID: 86766 RVA: 0x005DD734 File Offset: 0x005DB934
	private void EventOnAddCommonItemList(IReadOnlyList<IProto_NormalItem> commonItemList)
	{
		foreach (IProto_NormalItem proto_NormalItem in commonItemList)
		{
			ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(proto_NormalItem.Id);
			if (config != null && config.GetValueOrDefault().ItemType == 60005)
			{
				IReadOnlyList<SlashBuffToItem> buffCfgByItemIdList = ConfigBase<ShipTowerConfig>.Instance.GetBuffCfgByItemIdList(config.Value.Id);
				SlashBuffToItem? slashBuffToItem = null;
				if (buffCfgByItemIdList != null)
				{
					foreach (SlashBuffToItem value in buffCfgByItemIdList)
					{
						if (!ModelBase<ShipTowerModel>.Instance.IsOldSeason(value.Season))
						{
							slashBuffToItem = new SlashBuffToItem?(value);
							break;
						}
					}
				}
				if (slashBuffToItem != null)
				{
					ModelBase<ShipTowerModel>.Instance.AddShowBuffId(slashBuffToItem.Value.Id, slashBuffToItem.Value.Tips == 1);
				}
			}
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ShipTowerView))
		{
			ModelBase<ShipTowerModel>.Instance.CheckShowGetBuff().Forget<bool>();
		}
	}

	// Token: 0x060152EF RID: 86767 RVA: 0x005DD888 File Offset: 0x005DBA88
	private void EventFunctionOpen(EFunctionType id, bool isOpen)
	{
		if (!isOpen || id != EFunctionType.ShipTower)
		{
			return;
		}
		ModelBase<ShipTowerModel>.Instance.CheckInitProto(true).Forget<bool>();
	}

	// Token: 0x060152F0 RID: 86768 RVA: 0x005DD8A8 File Offset: 0x005DBAA8
	public void RequestChallenge(ShipTowerStageData stageData, bool isFromLast = false, bool isAgain = false)
	{
		ShipTowerTeamData shipTowerTeamData = stageData.TeamDataList[0];
		ShipTowerTeamData shipTowerTeamData2 = stageData.TeamDataList[1];
		SlashAndTowerCtx slashAndTowerCtx = SlashAndTowerCtx.Create();
		slashAndTowerCtx.LevelsId = stageData.Id;
		slashAndTowerCtx.SelectBuff.AddRange(stageData.GetAllTeamBuffIdList());
		slashAndTowerCtx.SecondRoles.AddRange(shipTowerTeamData2.GetRoleIdListEdit());
		slashAndTowerCtx.SkillBranchIds.AddRange(ShipTowerController.CollectSkillBranchIdList(stageData));
		slashAndTowerCtx.ReChallenge = isAgain;
		ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.SlashAndTowerCtx = slashAndTowerCtx;
		List<int> roleIds = isFromLast ? shipTowerTeamData2.GetRoleIdListEdit() : shipTowerTeamData.GetRoleIdListEdit();
		int instanceId = isFromLast ? shipTowerTeamData2.InstId : shipTowerTeamData.InstId;
		ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(instanceId, roleIds, 0, 0, null, null).Forget<bool>();
	}

	// Token: 0x060152F1 RID: 86769 RVA: 0x005DD968 File Offset: 0x005DBB68
	private static List<int> CollectSkillBranchIdList(ShipTowerStageData stageData)
	{
		List<int> list = new List<int>();
		foreach (ShipTowerTeamData shipTowerTeamData in stageData.TeamDataList)
		{
			foreach (ShipTowerRoleData shipTowerRoleData in shipTowerTeamData.RoleList)
			{
				int roleIdEdit = shipTowerRoleData.RoleIdEdit;
				int roleSkillBranchIdInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIdInCurrentGamePlay(roleIdEdit);
				list.Add(roleSkillBranchIdInCurrentGamePlay);
			}
		}
		return list;
	}

	// Token: 0x060152F2 RID: 86770 RVA: 0x005DDA10 File Offset: 0x005DBC10
	public UniTask SlashAndTowerInfoRequest()
	{
		ShipTowerController.<SlashAndTowerInfoRequest>d__13 <SlashAndTowerInfoRequest>d__;
		<SlashAndTowerInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SlashAndTowerInfoRequest>d__.<>1__state = -1;
		<SlashAndTowerInfoRequest>d__.<>t__builder.Start<ShipTowerController.<SlashAndTowerInfoRequest>d__13>(ref <SlashAndTowerInfoRequest>d__);
		return <SlashAndTowerInfoRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060152F3 RID: 86771 RVA: 0x005DDA4C File Offset: 0x005DBC4C
	public UniTask SlashAndTowerScoreRewardRequest(int id, int[] ids)
	{
		ShipTowerController.<SlashAndTowerScoreRewardRequest>d__14 <SlashAndTowerScoreRewardRequest>d__;
		<SlashAndTowerScoreRewardRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SlashAndTowerScoreRewardRequest>d__.id = id;
		<SlashAndTowerScoreRewardRequest>d__.ids = ids;
		<SlashAndTowerScoreRewardRequest>d__.<>1__state = -1;
		<SlashAndTowerScoreRewardRequest>d__.<>t__builder.Start<ShipTowerController.<SlashAndTowerScoreRewardRequest>d__14>(ref <SlashAndTowerScoreRewardRequest>d__);
		return <SlashAndTowerScoreRewardRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060152F4 RID: 86772 RVA: 0x005DDA98 File Offset: 0x005DBC98
	public UniTask EndLessHistoryRequest()
	{
		ShipTowerController.<EndLessHistoryRequest>d__15 <EndLessHistoryRequest>d__;
		<EndLessHistoryRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<EndLessHistoryRequest>d__.<>1__state = -1;
		<EndLessHistoryRequest>d__.<>t__builder.Start<ShipTowerController.<EndLessHistoryRequest>d__15>(ref <EndLessHistoryRequest>d__);
		return <EndLessHistoryRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060152F5 RID: 86773 RVA: 0x005DDAD4 File Offset: 0x005DBCD4
	public UniTask SlashAndTowerSaveRecordRequest(int id)
	{
		ShipTowerController.<SlashAndTowerSaveRecordRequest>d__16 <SlashAndTowerSaveRecordRequest>d__;
		<SlashAndTowerSaveRecordRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SlashAndTowerSaveRecordRequest>d__.id = id;
		<SlashAndTowerSaveRecordRequest>d__.<>1__state = -1;
		<SlashAndTowerSaveRecordRequest>d__.<>t__builder.Start<ShipTowerController.<SlashAndTowerSaveRecordRequest>d__16>(ref <SlashAndTowerSaveRecordRequest>d__);
		return <SlashAndTowerSaveRecordRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060152F6 RID: 86774 RVA: 0x005DDB18 File Offset: 0x005DBD18
	public UniTask SlashAndTowerResetRequest(int id)
	{
		ShipTowerController.<SlashAndTowerResetRequest>d__17 <SlashAndTowerResetRequest>d__;
		<SlashAndTowerResetRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SlashAndTowerResetRequest>d__.id = id;
		<SlashAndTowerResetRequest>d__.<>1__state = -1;
		<SlashAndTowerResetRequest>d__.<>t__builder.Start<ShipTowerController.<SlashAndTowerResetRequest>d__17>(ref <SlashAndTowerResetRequest>d__);
		return <SlashAndTowerResetRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060152F7 RID: 86775 RVA: 0x005DDB5C File Offset: 0x005DBD5C
	public UniTask SlashAndTowerRecommendRequest(int id)
	{
		ShipTowerController.<SlashAndTowerRecommendRequest>d__18 <SlashAndTowerRecommendRequest>d__;
		<SlashAndTowerRecommendRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SlashAndTowerRecommendRequest>d__.id = id;
		<SlashAndTowerRecommendRequest>d__.<>1__state = -1;
		<SlashAndTowerRecommendRequest>d__.<>t__builder.Start<ShipTowerController.<SlashAndTowerRecommendRequest>d__18>(ref <SlashAndTowerRecommendRequest>d__);
		return <SlashAndTowerRecommendRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060152F8 RID: 86776 RVA: 0x005DDBA0 File Offset: 0x005DBDA0
	public UniTask SlashAndTowerReviewRequest()
	{
		ShipTowerController.<SlashAndTowerReviewRequest>d__19 <SlashAndTowerReviewRequest>d__;
		<SlashAndTowerReviewRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SlashAndTowerReviewRequest>d__.<>1__state = -1;
		<SlashAndTowerReviewRequest>d__.<>t__builder.Start<ShipTowerController.<SlashAndTowerReviewRequest>d__19>(ref <SlashAndTowerReviewRequest>d__);
		return <SlashAndTowerReviewRequest>d__.<>t__builder.Task;
	}
}
