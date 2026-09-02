using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;

// Token: 0x02001B39 RID: 6969
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EditBattleTeamController : UiControllerBase<EditBattleTeamController>
{
	// Token: 0x0600C901 RID: 51457 RVA: 0x00353C81 File Offset: 0x00351E81
	protected override bool OnInit()
	{
		ModelBase<EditBattleTeamModel>.Instance.CreateAllRoleSlotData();
		return true;
	}

	// Token: 0x0600C902 RID: 51458 RVA: 0x00353C8E File Offset: 0x00351E8E
	protected override bool OnClear()
	{
		ModelBase<EditBattleTeamModel>.Instance.ResetAllRoleSlotData();
		return true;
	}

	// Token: 0x0600C903 RID: 51459 RVA: 0x00353C9C File Offset: 0x00351E9C
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PrewarFormationChanged, new Action(this.OnPrewarFormationChanged));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.PrewarReadyChanged, new Action<int, bool>(this.OnPrewarReadyChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.DissolvePrewar, new Action(this.OnDissolvePrewar));
		Singleton<EventSystem>.Instance.Add<int, int, int>(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleSkinChange, new Action<int>(this.OnRoleSkinChanged));
	}

	// Token: 0x0600C904 RID: 51460 RVA: 0x00353D38 File Offset: 0x00351F38
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PrewarFormationChanged, new Action(this.OnPrewarFormationChanged));
		Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.PrewarReadyChanged, new Action<int, bool>(this.OnPrewarReadyChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.DissolvePrewar, new Action(this.OnDissolvePrewar));
		Singleton<EventSystem>.Instance.Remove<int, int, int>(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRoleSkinChange, new Action<int>(this.OnRoleSkinChanged));
	}

	// Token: 0x0600C905 RID: 51461 RVA: 0x00353DD1 File Offset: 0x00351FD1
	private void OnPrewarFormationChanged()
	{
		ModelBase<EditBattleTeamModel>.Instance.RefreshAllMultiRoleData();
	}

	// Token: 0x0600C906 RID: 51462 RVA: 0x00353DE0 File Offset: 0x00351FE0
	private unsafe void OnPrewarReadyChanged(int playerId, bool ready)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Formation;
		ELogAuthor author = ELogAuthor.LYY;
		string message = "[EditBattleTeam]玩家{PlayerId} 返回准备游戏,是否准备:{IsReady}";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("{PlayerId}", playerId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("{IsReady}", ready);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		ModelBase<EditBattleTeamModel>.Instance.SetPlayerReady(playerId, ready);
	}

	// Token: 0x0600C907 RID: 51463 RVA: 0x00353E56 File Offset: 0x00352056
	private void OnDissolvePrewar()
	{
		this.CloseEditBattleTeamView();
	}

	// Token: 0x0600C908 RID: 51464 RVA: 0x00353E60 File Offset: 0x00352060
	private void OnRoleLevelUp(int configId, int exp, int level)
	{
		EditBattleRoleSlotData[] getAllRoleSlotData = ModelBase<EditBattleTeamModel>.Instance.GetAllRoleSlotData;
		for (int i = 0; i < getAllRoleSlotData.Length; i++)
		{
			EditBattleRoleData getRoleData = getAllRoleSlotData[i].GetRoleData;
			bool? flag = (getRoleData != null) ? new bool?(getRoleData.IsSelf) : null;
			if (getRoleData != null && flag.GetValueOrDefault() && getRoleData.ConfigId == configId)
			{
				getRoleData.Level = level;
				if (ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon)
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.MatchChangeRoleRequest(ModelBase<EditBattleTeamModel>.Instance.GetOwnRoleConfigIdList.Item1);
				}
			}
		}
		Singleton<EventSystem>.Instance.Emit<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, ERefreshEditBattleRoleSlotDataReason.LevelUp);
	}

	// Token: 0x0600C909 RID: 51465 RVA: 0x00353F00 File Offset: 0x00352100
	private void OnRoleSkinChanged(int configId)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(configId, true);
		EditBattleRoleSlotData[] getAllRoleSlotData = ModelBase<EditBattleTeamModel>.Instance.GetAllRoleSlotData;
		for (int i = 0; i < getAllRoleSlotData.Length; i++)
		{
			EditBattleRoleData getRoleData = getAllRoleSlotData[i].GetRoleData;
			bool? flag = (getRoleData != null) ? new bool?(getRoleData.IsSelf) : null;
			if (getRoleData != null && flag.GetValueOrDefault() && getRoleData.ConfigId == configId)
			{
				getRoleData.SkinId = roleDataById.GetRoleSkinId();
				Singleton<EventSystem>.Instance.Emit<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, ERefreshEditBattleRoleSlotDataReason.SkinChange);
				if (ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon)
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.MatchChangeRoleRequest(ModelBase<EditBattleTeamModel>.Instance.GetOwnRoleConfigIdList.Item1);
				}
			}
		}
	}

	// Token: 0x0600C90A RID: 51466 RVA: 0x00353FB8 File Offset: 0x003521B8
	public void PlayerOpenEditBattleTeamView(int instanceDungeonId, bool isMulti = false, bool isNeedEntrance = true, bool isHideTitle = false, bool? canUseSpecialTrailRole = null)
	{
		if (!isMulti)
		{
			ModelBase<EditBattleTeamModel>.Instance.NeedEntrance = isNeedEntrance;
		}
		if (canUseSpecialTrailRole == null)
		{
			canUseSpecialTrailRole = new bool?(ModelBase<RoleModel>.Instance.CanUseSpecialTrialRole(new int?(instanceDungeonId)));
		}
		this.OpenEditBattleTeamView(instanceDungeonId, isMulti, isHideTitle, canUseSpecialTrailRole.Value);
	}

	// Token: 0x0600C90B RID: 51467 RVA: 0x00354004 File Offset: 0x00352204
	public void OpenEditBattleTeamView(int instanceDungeonId, bool isMulti = false, bool isHideTitle = false, bool canUseSpecialTrailRole = false)
	{
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		if (ConfigInstanceDungeonById.GetConfig(instanceDungeonId, true) == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LYY, "[EditBattleTeam]找不到副本数据，不能打开战前编队", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		instance.SetInstanceDungeonId(new int?(instanceDungeonId));
		if (ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon && ModelBase<InstanceDungeonModel>.Instance.MatchingPlayerCount() <= 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "打开战前编队时，数据已经被清理，操作中止", default(ReadOnlySpan<ValueTuple<string, object>>));
			instance.SetInstanceDungeonId(null);
			return;
		}
		EditBattleTeamViewParam param = new EditBattleTeamViewParam
		{
			IsHideTitle = isHideTitle,
			CanUseSpecialTrailRole = canUseSpecialTrailRole
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.EditBattleTeamView, param, null);
	}

	// Token: 0x0600C90C RID: 51468 RVA: 0x003540BC File Offset: 0x003522BC
	public void CloseEditBattleTeamView()
	{
		ModelBase<EditBattleTeamModel>.Instance.ResetAllRoleSlotData();
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.EditBattleTeamView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.EditBattleTeamView, null);
		}
	}

	// Token: 0x0600C90D RID: 51469 RVA: 0x003540EC File Offset: 0x003522EC
	public void ExitEditBattleTeam(bool bRequest = true)
	{
		EditBattleTeamModel instance = ModelBase<EditBattleTeamModel>.Instance;
		if (instance.IsMultiInstanceDungeon && bRequest)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Formation;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "[EditBattleTeam]离开{DungeonId} 副本的战前编队";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("{DungeonId}", instance.GetInstanceDungeonId);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveMatchTeamRequest();
		}
		instance.SetInstanceDungeonId(null);
		instance.SetLeaderPlayerId(null);
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ChatView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ChatView, delegate(bool _)
			{
				this.CloseEditBattleTeamView();
			});
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.TeamRoleSelectView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.TeamRoleSelectView, delegate(bool _)
			{
				this.CloseEditBattleTeamView();
			});
			return;
		}
		this.CloseEditBattleTeamView();
	}

	// Token: 0x0600C90E RID: 51470 RVA: 0x003541C4 File Offset: 0x003523C4
	public void ResetSlotDataThenSetEditBattleTeamByRoleId(int[] roleIdArray)
	{
		ModelBase<EditBattleTeamModel>.Instance.ResetAllRoleSlotData();
		EditBattleRoleSlotData[] getAllRoleSlotData = ModelBase<EditBattleTeamModel>.Instance.GetAllRoleSlotData;
		for (int i = 0; i < roleIdArray.Length; i++)
		{
			int num = roleIdArray[i];
			EditBattleRoleSlotData editBattleRoleSlotData = getAllRoleSlotData[i];
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num, true);
			RoleLevelData levelData = roleDataById.GetLevelData();
			EditBattleRoleData editBattleRoleData = editBattleRoleSlotData.GetRoleData;
			if (editBattleRoleData == null)
			{
				editBattleRoleData = ModelBase<EditBattleTeamModel>.Instance.CreateRoleDataFromRoleInstance(roleDataById);
			}
			editBattleRoleData.ConfigId = num;
			editBattleRoleData.Level = levelData.GetLevel();
			editBattleRoleSlotData.SetRoleData(editBattleRoleData);
		}
		Singleton<EventSystem>.Instance.Emit<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, ERefreshEditBattleRoleSlotDataReason.SetTeamByRoleId);
	}

	// Token: 0x0600C90F RID: 51471 RVA: 0x00354258 File Offset: 0x00352458
	public void SetEditBattleTeamByRoleId(int[] roleIdArray)
	{
		EditBattleRoleSlotData[] getAllRoleSlotData = ModelBase<EditBattleTeamModel>.Instance.GetAllRoleSlotData;
		for (int i = 0; i < roleIdArray.Length; i++)
		{
			int num = roleIdArray[i];
			EditBattleRoleSlotData editBattleRoleSlotData = getAllRoleSlotData[i];
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num, true);
			RoleLevelData levelData = roleDataById.GetLevelData();
			EditBattleRoleData editBattleRoleData = editBattleRoleSlotData.GetRoleData;
			if (editBattleRoleData == null)
			{
				editBattleRoleData = ModelBase<EditBattleTeamModel>.Instance.CreateRoleDataFromRoleInstance(roleDataById);
			}
			editBattleRoleData.ConfigId = num;
			editBattleRoleData.Level = levelData.GetLevel();
			editBattleRoleSlotData.SetRoleData(editBattleRoleData);
		}
		Singleton<EventSystem>.Instance.Emit<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, ERefreshEditBattleRoleSlotDataReason.SetTeamByRoleId);
	}

	// Token: 0x0600C910 RID: 51472 RVA: 0x003542E1 File Offset: 0x003524E1
	public void RefreshMainRoleInfo()
	{
		ModelBase<EditBattleTeamModel>.Instance.ChangeMainRoleData();
	}
}
