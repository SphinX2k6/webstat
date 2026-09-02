using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F15 RID: 7957
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryRoleEquipItem : UiPanelBase
{
	// Token: 0x0600EDD5 RID: 60885 RVA: 0x0040EB89 File Offset: 0x0040CD89
	public HonamiStoryRoleEquipItem(HonamiStoryRoleEquipData roleEquipData)
	{
		this.RoleEquipData = roleEquipData;
	}

	// Token: 0x0600EDD6 RID: 60886 RVA: 0x0040EBA3 File Offset: 0x0040CDA3
	public void RegisterPanel(HonamiStoryBackpackPanelBase panel)
	{
		this.Panel = panel;
	}

	// Token: 0x0600EDD7 RID: 60887 RVA: 0x0040EBAC File Offset: 0x0040CDAC
	public HonamiStoryRoleEquipData GetRoleEquipData()
	{
		return this.RoleEquipData;
	}

	// Token: 0x0600EDD8 RID: 60888 RVA: 0x0040EBB4 File Offset: 0x0040CDB4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnRoleItemClicked)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickedMore))
		};
	}

	// Token: 0x0600EDD9 RID: 60889 RVA: 0x0040EC8C File Offset: 0x0040CE8C
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryRoleEquipItem.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryRoleEquipItem.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EDDA RID: 60890 RVA: 0x0040ECCF File Offset: 0x0040CECF
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStoryBackpackClickWeapon, new Action(this.OnAfterClickedWeaponItem));
	}

	// Token: 0x0600EDDB RID: 60891 RVA: 0x0040ECED File Offset: 0x0040CEED
	protected override void OnBeforeShow()
	{
		this.RefreshRoleItem();
		this.RefreshWeaponItem();
		this.RefreshBtnMoreVisible();
	}

	// Token: 0x0600EDDC RID: 60892 RVA: 0x0040ED01 File Offset: 0x0040CF01
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryBackpackClickWeapon, new Action(this.OnAfterClickedWeaponItem));
	}

	// Token: 0x0600EDDD RID: 60893 RVA: 0x0040ED20 File Offset: 0x0040CF20
	private void RefreshRoleItem()
	{
		int roleId = this.RoleEquipData.GetRoleId();
		UUISprite sprite = base.GetSprite(1);
		if (sprite != null)
		{
			sprite.SetUIActive(roleId <= 0);
		}
		UUITexture texture = base.GetTexture(2);
		if (texture != null)
		{
			texture.SetUIActive(roleId > 0);
		}
		if (roleId <= 0)
		{
			return;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		if (roleConfig == null)
		{
			return;
		}
		RoleSkinData roleSkinDataByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataByRoleId(roleId);
		string path = (roleSkinDataByRoleId != null) ? roleSkinDataByRoleId.GetRoleSkinConfig().RoleHeadIconLarge : roleConfig.Value.RoleHeadIconLarge;
		base.SetRoleIconByRoleIdOrSkinId(path, base.GetTexture(2), roleId, new int?(roleConfig.Value.SkinId), null, null);
	}

	// Token: 0x0600EDDE RID: 60894 RVA: 0x0040EDE4 File Offset: 0x0040CFE4
	private UniTask InitRolePluginItemList()
	{
		HonamiStoryRoleEquipItem.<InitRolePluginItemList>d__20 <InitRolePluginItemList>d__;
		<InitRolePluginItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRolePluginItemList>d__.<>4__this = this;
		<InitRolePluginItemList>d__.<>1__state = -1;
		<InitRolePluginItemList>d__.<>t__builder.Start<HonamiStoryRoleEquipItem.<InitRolePluginItemList>d__20>(ref <InitRolePluginItemList>d__);
		return <InitRolePluginItemList>d__.<>t__builder.Task;
	}

	// Token: 0x0600EDDF RID: 60895 RVA: 0x0040EE28 File Offset: 0x0040D028
	private UniTask InitRolePluginItem(int index)
	{
		HonamiStoryRoleEquipItem.<InitRolePluginItem>d__21 <InitRolePluginItem>d__;
		<InitRolePluginItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRolePluginItem>d__.<>4__this = this;
		<InitRolePluginItem>d__.index = index;
		<InitRolePluginItem>d__.<>1__state = -1;
		<InitRolePluginItem>d__.<>t__builder.Start<HonamiStoryRoleEquipItem.<InitRolePluginItem>d__21>(ref <InitRolePluginItem>d__);
		return <InitRolePluginItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EDE0 RID: 60896 RVA: 0x0040EE74 File Offset: 0x0040D074
	public UniTask RefreshUiAsync(HonamiStoryRoleEquipData equipData)
	{
		HonamiStoryRoleEquipItem.<RefreshUiAsync>d__22 <RefreshUiAsync>d__;
		<RefreshUiAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshUiAsync>d__.<>4__this = this;
		<RefreshUiAsync>d__.equipData = equipData;
		<RefreshUiAsync>d__.<>1__state = -1;
		<RefreshUiAsync>d__.<>t__builder.Start<HonamiStoryRoleEquipItem.<RefreshUiAsync>d__22>(ref <RefreshUiAsync>d__);
		return <RefreshUiAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EDE1 RID: 60897 RVA: 0x0040EEC0 File Offset: 0x0040D0C0
	private UniTask RefreshPluginItemList()
	{
		HonamiStoryRoleEquipItem.<RefreshPluginItemList>d__23 <RefreshPluginItemList>d__;
		<RefreshPluginItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshPluginItemList>d__.<>4__this = this;
		<RefreshPluginItemList>d__.<>1__state = -1;
		<RefreshPluginItemList>d__.<>t__builder.Start<HonamiStoryRoleEquipItem.<RefreshPluginItemList>d__23>(ref <RefreshPluginItemList>d__);
		return <RefreshPluginItemList>d__.<>t__builder.Task;
	}

	// Token: 0x0600EDE2 RID: 60898 RVA: 0x0040EF04 File Offset: 0x0040D104
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<HonamiStoryEquipGridItem> CreateRolePluginItem()
	{
		HonamiStoryRoleEquipItem.<CreateRolePluginItem>d__24 <CreateRolePluginItem>d__;
		<CreateRolePluginItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<HonamiStoryEquipGridItem>.Create();
		<CreateRolePluginItem>d__.<>4__this = this;
		<CreateRolePluginItem>d__.<>1__state = -1;
		<CreateRolePluginItem>d__.<>t__builder.Start<HonamiStoryRoleEquipItem.<CreateRolePluginItem>d__24>(ref <CreateRolePluginItem>d__);
		return <CreateRolePluginItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EDE3 RID: 60899 RVA: 0x0040EF48 File Offset: 0x0040D148
	[return: Nullable(2)]
	public HonamiStoryEquipGridItem GetEquipItemByEventData(ULGUIPointerEventData eventData)
	{
		foreach (HonamiStoryEquipGridItem honamiStoryEquipGridItem in this.RolePluginItemList)
		{
			if (HonamiStoryUtil.CheckEventDataInItemViewport(eventData, honamiStoryEquipGridItem.GetRootItem(), true))
			{
				return honamiStoryEquipGridItem;
			}
		}
		return null;
	}

	// Token: 0x0600EDE4 RID: 60900 RVA: 0x0040EFAC File Offset: 0x0040D1AC
	public List<HonamiStoryEquipGridItem> GetPluginItemList()
	{
		return this.RolePluginItemList;
	}

	// Token: 0x0600EDE5 RID: 60901 RVA: 0x0040EFB4 File Offset: 0x0040D1B4
	public void SetRoleTipOpenState(bool isOpen)
	{
		bool btnMoreShowVisible = this.GetBtnMoreShowVisible();
		this.IsRoleTipsOpen = isOpen;
		UUIButtonComponent button = base.GetButton(5);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(btnMoreShowVisible && !isOpen);
	}

	// Token: 0x0600EDE6 RID: 60902 RVA: 0x0040EFF8 File Offset: 0x0040D1F8
	private void RefreshBtnMoreVisible()
	{
		bool btnMoreShowVisible = this.GetBtnMoreShowVisible();
		UUIButtonComponent button = base.GetButton(5);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(btnMoreShowVisible && !this.IsRoleTipsOpen);
	}

	// Token: 0x0600EDE7 RID: 60903 RVA: 0x0040F03C File Offset: 0x0040D23C
	private bool GetBtnMoreShowVisible()
	{
		if (!ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().IsBackpackView() && HonamiStoryUtil.IsMobileView())
		{
			return false;
		}
		bool flag = this.RoleEquipData.GetWeaponId() <= 0;
		bool flag2 = this.RoleEquipData.GetEquipItemDataList().Count == 0;
		return !flag || !flag2;
	}

	// Token: 0x0600EDE8 RID: 60904 RVA: 0x0040F090 File Offset: 0x0040D290
	[NullableContext(2)]
	private void OnEnterGrid(HonamiStoryItemGridItem item)
	{
		Action<HonamiStoryItemGridItem> onEnterGridCb = this.OnEnterGridCb;
		if (onEnterGridCb == null)
		{
			return;
		}
		onEnterGridCb(item);
	}

	// Token: 0x0600EDE9 RID: 60905 RVA: 0x0040F0A3 File Offset: 0x0040D2A3
	private void OnExitGrid()
	{
		Action onExitGridCb = this.OnExitGridCb;
		if (onExitGridCb == null)
		{
			return;
		}
		onExitGridCb();
	}

	// Token: 0x0600EDEA RID: 60906 RVA: 0x0040F0B5 File Offset: 0x0040D2B5
	private void OnDownGrid()
	{
		Action onDownGridCb = this.OnDownGridCb;
		if (onDownGridCb == null)
		{
			return;
		}
		onDownGridCb();
	}

	// Token: 0x0600EDEB RID: 60907 RVA: 0x0040F0C7 File Offset: 0x0040D2C7
	private void OnClickedGrid([Nullable(2)] HonamiStoryItemGridItem item, Vector2D loc, Vector2D size)
	{
		Action<HonamiStoryItemGridItem, Vector2D, Vector2D> onClickedGridCb = this.OnClickedGridCb;
		if (onClickedGridCb == null)
		{
			return;
		}
		onClickedGridCb(item, loc, size);
	}

	// Token: 0x0600EDEC RID: 60908 RVA: 0x0040F0DC File Offset: 0x0040D2DC
	public void SetEnableState(EHonamiStoryBackpackLogicState state)
	{
		bool flag = state == EHonamiStoryBackpackLogicState.Normal;
		bool flag2 = state == EHonamiStoryBackpackLogicState.Dragging || state == EHonamiStoryBackpackLogicState.DraggingPlugins;
		float alpha = (flag || flag2) ? 1f : 0.4f;
		UUIButtonComponent button = base.GetButton(0);
		if (button != null)
		{
			button.RootUIComp.Get().SetAlpha(alpha);
		}
		UUIButtonComponent button2 = base.GetButton(0);
		if (button2 != null)
		{
			button2.RootUIComp.Get().SetRaycastTarget(flag);
		}
		HonamiStoryWeaponToggleItem weaponItem = this.WeaponItem;
		if (weaponItem != null)
		{
			weaponItem.SetIsEnable(flag);
		}
		UUIButtonComponent button3 = base.GetButton(5);
		if (button3 != null)
		{
			button3.RootUIComp.Get().SetAlpha(alpha);
		}
		UUIButtonComponent button4 = base.GetButton(5);
		if (button4 != null)
		{
			button4.RootUIComp.Get().SetRaycastTarget(flag);
		}
		bool flag3 = flag2 || flag || state == EHonamiStoryBackpackLogicState.Instead;
		float alpha2 = flag3 ? 1f : 0.4f;
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetAlpha(alpha2);
		}
		foreach (HonamiStoryEquipGridItem honamiStoryEquipGridItem in this.RolePluginItemList)
		{
			honamiStoryEquipGridItem.SetIsEnable(flag3);
		}
	}

	// Token: 0x0600EDED RID: 60909 RVA: 0x0040F21C File Offset: 0x0040D41C
	public void RefreshState(EHonamiStoryBackpackLogicState state)
	{
		foreach (HonamiStoryEquipGridItem honamiStoryEquipGridItem in this.RolePluginItemList)
		{
			honamiStoryEquipGridItem.Refresh(honamiStoryEquipGridItem.GetData(), -1);
		}
	}

	// Token: 0x0600EDEE RID: 60910 RVA: 0x0040F274 File Offset: 0x0040D474
	private void OnClickedMore()
	{
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		if (backpackLogicState == EHonamiStoryBackpackLogicState.Normal)
		{
			if (this.OnMoreClickedCb != null)
			{
				this.OnMoreClickedCb(this);
				return;
			}
		}
		else if (backpackLogicState == EHonamiStoryBackpackLogicState.Tips || backpackLogicState == EHonamiStoryBackpackLogicState.TipsWithPlugins)
		{
			HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
			if (backpackLogic == null)
			{
				return;
			}
			backpackLogic.CloseTips();
		}
	}

	// Token: 0x0600EDEF RID: 60911 RVA: 0x0040F2C0 File Offset: 0x0040D4C0
	private void OnRoleItemClicked()
	{
		bool flag = this.CheckChangeRoleFunctionOpen();
		bool flag2 = HonamiStoryUtil.CheckInHonamiStoryDungeon();
		ModelBase<HonamiStoryModel>.Instance.AddLevel = new int[]
		{
			90,
			90
		};
		if (flag2 || !flag)
		{
			this.HandleSpecialRoleSelected();
			return;
		}
		this.HandleNormalRoleSelected();
	}

	// Token: 0x0600EDF0 RID: 60912 RVA: 0x0040F308 File Offset: 0x0040D508
	private void ConfirmCallback(int targetRoleId)
	{
		ModelBase<HonamiStoryModel>.Instance.AddLevel = new int[]
		{
			-1,
			-1
		};
		int[] allRoleIdList = ModelBase<HonamiStoryModel>.Instance.GetAllRoleIdList();
		int roleId = this.RoleEquipData.GetRoleId();
		if (roleId == targetRoleId)
		{
			int num = allRoleIdList.IndexOf(roleId);
			if (num != -1)
			{
				allRoleIdList[num] = 0;
			}
		}
		else
		{
			bool roleEquipDataByRoleId = ModelBase<HonamiStoryModel>.Instance.GetRoleEquipDataByRoleId(targetRoleId) != null;
			int num2 = allRoleIdList.IndexOf(targetRoleId);
			int num3 = allRoleIdList.IndexOf(roleId);
			if (roleEquipDataByRoleId)
			{
				allRoleIdList[num2] = roleId;
			}
			allRoleIdList[num3] = targetRoleId;
		}
		ControllerBase<HonamiStoryController>.Instance.RequestHonamiStoryEquipRole(allRoleIdList.ToList<int>());
	}

	// Token: 0x0600EDF1 RID: 60913 RVA: 0x0040F394 File Offset: 0x0040D594
	[NullableContext(2)]
	private string GetConfirmButtonTextFunction(int roleConfigId)
	{
		if (roleConfigId == 0)
		{
			return null;
		}
		int roleId = this.RoleEquipData.GetRoleId();
		if (roleId == 0)
		{
			return "JoinText";
		}
		if (roleId == roleConfigId)
		{
			return "GoDownText";
		}
		return "ChangeText";
	}

	// Token: 0x0600EDF2 RID: 60914 RVA: 0x0040F3CA File Offset: 0x0040D5CA
	private bool IsNeedRevive(int roleConfigId)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleConfigId, true);
		return (roleDataById == null || !roleDataById.IsTrialRole()) && ModelBase<EditFormationModel>.Instance.IsRoleDead(roleConfigId);
	}

	// Token: 0x0600EDF3 RID: 60915 RVA: 0x0040F3F8 File Offset: 0x0040D5F8
	private bool CanJoinTeam(int roleId)
	{
		int num = this.CheckChangeRoleFunctionOpen() ? 1 : 0;
		bool flag = HonamiStoryUtil.CheckInHonamiStoryDungeon();
		if (num == 0 || flag)
		{
			return false;
		}
		int roleId2 = this.RoleEquipData.GetRoleId();
		if (roleId == roleId2)
		{
			return true;
		}
		RoleModel instance = ModelBase<RoleModel>.Instance;
		RoleDataBase roleDataBase = (instance != null) ? instance.GetRoleDataById(roleId, true) : null;
		if (ModelBase<EditFormationModel>.Instance.IsRoleDead(roleId) && (roleDataBase == null || !roleDataBase.IsTrialRole()))
		{
			return false;
		}
		for (int i = 0; i < 3; i++)
		{
			HonamiStoryRoleEquipData roleEquipDataByPosition = ModelBase<HonamiStoryModel>.Instance.GetRoleEquipDataByPosition(i);
			int num2 = (roleEquipDataByPosition != null) ? roleEquipDataByPosition.GetRoleId() : 0;
			RoleModel instance2 = ModelBase<RoleModel>.Instance;
			RoleDataBase roleDataBase2 = (instance2 != null) ? instance2.GetRoleDataById(num2, true) : null;
			if (roleDataBase2 != null && roleDataBase2.IsTrialRole())
			{
				RoleConfig instance3 = ConfigBase<RoleConfig>.Instance;
				TrialRoleInfo? trialRoleInfo = (instance3 != null) ? instance3.GetTrialRoleConfig(num2) : null;
				if (trialRoleInfo != null && trialRoleInfo.Value.ParentId == roleId)
				{
					return false;
				}
			}
			if (roleDataBase != null && roleDataBase.IsTrialRole())
			{
				RoleConfig instance4 = ConfigBase<RoleConfig>.Instance;
				TrialRoleInfo? trialRoleInfo2 = (instance4 != null) ? instance4.GetTrialRoleConfig(roleId) : null;
				if (trialRoleInfo2 != null && num2 == trialRoleInfo2.Value.ParentId)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0600EDF4 RID: 60916 RVA: 0x0040F534 File Offset: 0x0040D734
	private void OnBackCallback()
	{
		int[] allRoleIdList = ModelBase<HonamiStoryModel>.Instance.GetAllRoleIdList();
		for (int i = 0; i < allRoleIdList.Length; i++)
		{
			RoleModel instance = ModelBase<RoleModel>.Instance;
			RoleDataBase roleDataBase = (instance != null) ? instance.GetRoleDataById(allRoleIdList[i], true) : null;
			if (roleDataBase == null || !roleDataBase.IsTrialRole())
			{
				RoleModel instance2 = ModelBase<RoleModel>.Instance;
				if (((instance2 != null) ? instance2.GetRoleInstanceById(allRoleIdList[i]) : null) == null)
				{
					ModelBase<HonamiStoryModel>.Instance.UpdateRoleByPosition(0, i);
				}
			}
		}
		this.RefreshRoleItem();
		ModelBase<HonamiStoryModel>.Instance.AddLevel = new int[]
		{
			-1,
			-1
		};
	}

	// Token: 0x0600EDF5 RID: 60917 RVA: 0x0040F5C0 File Offset: 0x0040D7C0
	private bool CheckChangeRoleFunctionOpen()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10111);
	}

	// Token: 0x0600EDF6 RID: 60918 RVA: 0x0040F5D4 File Offset: 0x0040D7D4
	private void HandleSpecialRoleSelected()
	{
		bool isInDungeon = HonamiStoryUtil.CheckInHonamiStoryDungeon();
		int roleId2 = this.RoleEquipData.GetRoleId();
		int position = this.RoleEquipData.GetPosition();
		int[] allRoleIdList = ModelBase<HonamiStoryModel>.Instance.GetAllRoleIdList();
		List<RoleDataBase> list = new List<RoleDataBase>();
		foreach (int id in allRoleIdList)
		{
			RoleModel instance = ModelBase<RoleModel>.Instance;
			RoleDataBase roleDataBase = (instance != null) ? instance.GetRoleDataById(id, true) : null;
			if (roleDataBase != null)
			{
				list.Add(roleDataBase);
			}
		}
		TeamRoleSelectViewData teamRoleSelectViewData = new TeamRoleSelectViewData(EFilterSortGroupId.EditFormation, roleId2, list, null, null, new int?(position + 1), null);
		teamRoleSelectViewData.FormationRoleList = allRoleIdList;
		teamRoleSelectViewData.IsNeedRevive = new Func<int, bool>(this.IsNeedRevive);
		teamRoleSelectViewData.BackCallBack = new Action(this.OnBackCallback);
		teamRoleSelectViewData.ForFunction = ETeamRoleUseFunction.HonamiStory;
		teamRoleSelectViewData.ShowLockPanel = ((int roleId) => true);
		teamRoleSelectViewData.GetLockTextCallBack = delegate(int roleId)
		{
			if (isInDungeon)
			{
				return "HonamiStory_UnableSwitch1";
			}
			return "HonamiStory_UnableSwitch2";
		};
		ControllerBase<RoleController>.Instance.OpenTeamRoleSelectView(teamRoleSelectViewData);
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_honamistory_roleselect_page_start");
	}

	// Token: 0x0600EDF7 RID: 60919 RVA: 0x0040F708 File Offset: 0x0040D908
	private unsafe void HandleNormalRoleSelected()
	{
		int roleId = this.RoleEquipData.GetRoleId();
		int position = this.RoleEquipData.GetPosition();
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(false);
		if (activityData == null)
		{
			return;
		}
		InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
		InstanceDungeon? instanceDungeon = (instance != null) ? instance.GetConfig(activityData.AreaInstId) : null;
		if (instanceDungeon == null)
		{
			return;
		}
		EditBattleTeamConfig instance2 = ConfigBase<EditBattleTeamConfig>.Instance;
		FightFormation? fightFormation = (instance2 != null) ? instance2.GetFightFormationConfig(instanceDungeon.Value.FightFormationId) : null;
		if (fightFormation == null)
		{
			return;
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module = ELogModule.HonamiStory;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "OnRoleItemClicked 编队配置信息";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("dungeonId", activityData.AreaInstId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("formationId", instanceDungeon.Value.FightFormationId);
		instance3.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		int[] array = fightFormation.Value.TrialRole();
		int[] array2 = fightFormation.Value.LimitRole();
		List<int> list = new List<int>();
		List<RoleDataBase> list2 = new List<RoleDataBase>();
		foreach (int num in array2)
		{
			RoleModel instance4 = ModelBase<RoleModel>.Instance;
			RoleInstance roleInstance = (instance4 != null) ? instance4.GetRoleInstanceById(num) : null;
			if (roleInstance != null)
			{
				list.Add(num);
				list2.Add(roleInstance);
			}
		}
		foreach (int id in array)
		{
			RoleConfig instance5 = ConfigBase<RoleConfig>.Instance;
			TrialRoleInfo? trialRoleInfo = (instance5 != null) ? instance5.GetTrialRoleConfigByGroupId(id) : null;
			if (trialRoleInfo != null)
			{
				int parentId = trialRoleInfo.Value.ParentId;
				if (!list.Contains(parentId))
				{
					RoleModel instance6 = ModelBase<RoleModel>.Instance;
					RoleDataBase roleDataBase = (instance6 != null) ? instance6.GetRoleDataById(trialRoleInfo.Value.Id, true) : null;
					if (roleDataBase != null)
					{
						list2.Add(roleDataBase);
					}
				}
			}
		}
		list2.Sort(delegate(RoleDataBase a, RoleDataBase b)
		{
			if (!a.IsTrialRole())
			{
				return -1;
			}
			return 1;
		});
		TeamRoleSelectViewData teamRoleSelectViewData = new TeamRoleSelectViewData(EFilterSortGroupId.EditFormation, roleId, list2, new Action<int>(this.ConfirmCallback), null, new int?(position + 1), null);
		teamRoleSelectViewData.FormationRoleList = ModelBase<HonamiStoryModel>.Instance.GetAllRoleIdList();
		teamRoleSelectViewData.IsNeedRevive = new Func<int, bool>(this.IsNeedRevive);
		teamRoleSelectViewData.GetConfirmButtonTextCallBack = new Func<int, string>(this.GetConfirmButtonTextFunction);
		teamRoleSelectViewData.GetConfirmButtonEnableCallBack = new Func<int, bool>(this.CanJoinTeam);
		teamRoleSelectViewData.CanJoinTeam = new Func<int, bool>(this.CanJoinTeam);
		teamRoleSelectViewData.BackCallBack = new Action(this.OnBackCallback);
		teamRoleSelectViewData.ForFunction = ETeamRoleUseFunction.HonamiStory;
		ControllerBase<RoleController>.Instance.OpenTeamRoleSelectView(teamRoleSelectViewData);
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_honamistory_roleselect_page_start");
	}

	// Token: 0x0600EDF8 RID: 60920 RVA: 0x0040FA08 File Offset: 0x0040DC08
	private void OnClickedWeaponItem(HonamiStoryWeaponToggleItem selectedWeaponItem)
	{
		int weaponId = this.RoleEquipData.GetWeaponId();
		bool flag = HonamiStoryUtil.CheckInHonamiStoryDungeon();
		if (weaponId <= 0 && flag)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_NoWeaponEquip", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryWeaponSelectView, this.RoleEquipData, null);
		HonamiStoryWeaponToggleItem weaponItem = this.WeaponItem;
		if (weaponItem == null)
		{
			return;
		}
		weaponItem.ResetToggleState();
	}

	// Token: 0x0600EDF9 RID: 60921 RVA: 0x0040FA6B File Offset: 0x0040DC6B
	private void OnAfterClickedWeaponItem()
	{
		HonamiStoryWeaponToggleItem weaponItem = this.WeaponItem;
		if (weaponItem == null)
		{
			return;
		}
		weaponItem.SetNewItemShow(false);
	}

	// Token: 0x0600EDFA RID: 60922 RVA: 0x0040FA80 File Offset: 0x0040DC80
	private void RefreshWeaponItem()
	{
		int weaponId = this.RoleEquipData.GetWeaponId();
		HonamiStoryWeaponToggleItemData data = new HonamiStoryWeaponToggleItemData
		{
			WeaponId = weaponId,
			EquipData = this.RoleEquipData,
			UseWay = EHonamiStoryWeaponUseWay.Equip
		};
		HonamiStoryWeaponToggleItem weaponItem = this.WeaponItem;
		if (weaponItem == null)
		{
			return;
		}
		weaponItem.Refresh(data, false, 0);
	}

	// Token: 0x0600EDFB RID: 60923 RVA: 0x0040FACC File Offset: 0x0040DCCC
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public ValueTuple<UUIItem, UUIItem>? GuideFindPluginItemWithId(int id)
	{
		foreach (HonamiStoryEquipGridItem honamiStoryEquipGridItem in this.RolePluginItemList)
		{
			HonamiStoryItemDataBase data = honamiStoryEquipGridItem.GetData();
			if (data != null && data.GetItemId() == id)
			{
				HonamiStoryItemGridItem itemGridItem = honamiStoryEquipGridItem.GetItemGridItem();
				UUIItem uuiitem = (itemGridItem != null) ? itemGridItem.GetRootItem() : null;
				if (uuiitem == null)
				{
					return null;
				}
				return new ValueTuple<UUIItem, UUIItem>?(new ValueTuple<UUIItem, UUIItem>(uuiitem, uuiitem));
			}
		}
		return null;
	}

	// Token: 0x0600EDFC RID: 60924 RVA: 0x0040FB6C File Offset: 0x0040DD6C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		if (configParams[0] == "AddBtn")
		{
			foreach (HonamiStoryEquipGridItem honamiStoryEquipGridItem in this.RolePluginItemList)
			{
				UUIItem[] guideUiItemAndUiItemForShowEx = honamiStoryEquipGridItem.GetGuideUiItemAndUiItemForShowEx(configParams);
				if (guideUiItemAndUiItemForShowEx != null && guideUiItemAndUiItemForShowEx.Length != 0)
				{
					return guideUiItemAndUiItemForShowEx;
				}
			}
		}
		return null;
	}

	// Token: 0x0400723F RID: 29247
	[Nullable(2)]
	public Action<HonamiStoryItemGridItem> OnEnterGridCb;

	// Token: 0x04007240 RID: 29248
	[Nullable(2)]
	public Action OnExitGridCb;

	// Token: 0x04007241 RID: 29249
	[Nullable(2)]
	public Action OnDownGridCb;

	// Token: 0x04007242 RID: 29250
	[Nullable(new byte[]
	{
		2,
		2,
		1,
		1
	})]
	public Action<HonamiStoryItemGridItem, Vector2D, Vector2D> OnClickedGridCb;

	// Token: 0x04007243 RID: 29251
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<HonamiStoryRoleEquipItem> OnMoreClickedCb;

	// Token: 0x04007244 RID: 29252
	private HonamiStoryBackpackPanelBase Panel;

	// Token: 0x04007245 RID: 29253
	private readonly List<HonamiStoryEquipGridItem> RolePluginItemList = new List<HonamiStoryEquipGridItem>();

	// Token: 0x04007246 RID: 29254
	[Nullable(2)]
	private HonamiStoryWeaponToggleItem WeaponItem;

	// Token: 0x04007247 RID: 29255
	private bool IsRoleTipsOpen;

	// Token: 0x04007248 RID: 29256
	private HonamiStoryRoleEquipData RoleEquipData;

	// Token: 0x0200827A RID: 33402
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C416 RID: 181270
		BtnHead,
		// Token: 0x0402C417 RID: 181271
		SpriteRoleEmpty,
		// Token: 0x0402C418 RID: 181272
		TexRole,
		// Token: 0x0402C419 RID: 181273
		WeaponItem,
		// Token: 0x0402C41A RID: 181274
		PluginRoot,
		// Token: 0x0402C41B RID: 181275
		BtnMore
	}
}
