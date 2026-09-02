using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029B4 RID: 10676
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerDescView : UiViewBase
{
	// Token: 0x06015496 RID: 87190 RVA: 0x005E6285 File Offset: 0x005E4485
	public ShipTowerDescView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x17001BD8 RID: 7128
	// (get) Token: 0x06015497 RID: 87191 RVA: 0x005E628E File Offset: 0x005E448E
	// (set) Token: 0x06015498 RID: 87192 RVA: 0x005E629A File Offset: 0x005E449A
	private bool IsShowTeamPanel
	{
		get
		{
			return ModelBase<ShipTowerModel>.Instance.IsShowLeftTeamPanel;
		}
		set
		{
			ModelBase<ShipTowerModel>.Instance.IsShowLeftTeamPanel = value;
		}
	}

	// Token: 0x06015499 RID: 87193 RVA: 0x005E62A8 File Offset: 0x005E44A8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(14, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnBtnMaskClick)),
			new ValueTuple<int, Delegate>(10, new Action(this.OnBtnMaskClick)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnBtnTeamRecommendClick)),
			new ValueTuple<int, Delegate>(13, new Action(this.OnExchangeTeamClick)),
			new ValueTuple<int, Delegate>(14, new Action(this.OnBtnSkillBranchClick))
		};
	}

	// Token: 0x0601549A RID: 87194 RVA: 0x005E6498 File Offset: 0x005E4698
	private void InitDataParam()
	{
		ShipTowerDescViewParams shipTowerDescViewParams = this.OpenParam as ShipTowerDescViewParams;
		this.StageData = ModelBase<ShipTowerModel>.Instance.GetStageDataById(shipTowerDescViewParams.StageId);
		if (shipTowerDescViewParams.ApplyTeamEditStageId != null && shipTowerDescViewParams.ApplyTeamEditStageId.Value != 0)
		{
			this.StageData.CopyTeamRoleToEdit(shipTowerDescViewParams.ApplyTeamEditStageId.Value);
		}
		else if (!shipTowerDescViewParams.IsOpenCover.GetValueOrDefault())
		{
			this.StageData.UpdateToEdit();
		}
		this.IsShowTeamPanel = false;
	}

	// Token: 0x0601549B RID: 87195 RVA: 0x005E6518 File Offset: 0x005E4718
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerDescView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerDescView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601549C RID: 87196 RVA: 0x005E655C File Offset: 0x005E475C
	protected override void OnStart()
	{
		this.CheckInitDataParam();
		ModelBase<RoleModel>.Instance.StartGamePlayRoleEdit(ESkillBranchCacheType.ShipTower);
		foreach (ShipTowerTeamData shipTowerTeamData in this.StageData.TeamDataList)
		{
			foreach (ShipTowerRoleData shipTowerRoleData in shipTowerTeamData.RoleList)
			{
				ModelBase<RoleModel>.Instance.SetRoleSkillBranchGamePlayCache(shipTowerRoleData.RoleId, shipTowerRoleData.SkillBranchId, ESkillBranchCacheType.ShipTower);
			}
		}
	}

	// Token: 0x0601549D RID: 87197 RVA: 0x005E6610 File Offset: 0x005E4810
	private void CheckInitDataParam()
	{
		ShipTowerDescViewParams shipTowerDescViewParams = this.OpenParam as ShipTowerDescViewParams;
		if (((shipTowerDescViewParams != null) ? shipTowerDescViewParams.IsOpenCover : null).GetValueOrDefault())
		{
			ModelBase<ShipTowerModel>.Instance.OpenViewCover(new ShipTowerCoverViewParams
			{
				StageData = this.StageData
			});
		}
	}

	// Token: 0x0601549E RID: 87198 RVA: 0x005E6664 File Offset: 0x005E4864
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ShipTowerStageUpdate, new Action<int>(this.CheckUpdateStageData));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ShipTowerSureResetStage, new Action<int>(this.CheckUpdateStageData));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ShipTowerSureCoverChallenge, new Action<int>(this.CheckUpdateStageData));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ShipTowerTeamRecommendApplyFinish, new Action<int>(this.EventShipTowerTeamRecommendApplyFinish));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnRoleSkillBranchChanged));
	}

	// Token: 0x0601549F RID: 87199 RVA: 0x005E6700 File Offset: 0x005E4900
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ShipTowerStageUpdate, new Action<int>(this.CheckUpdateStageData));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShipTowerSureResetStage, new Action<int>(this.CheckUpdateStageData));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShipTowerSureCoverChallenge, new Action<int>(this.CheckUpdateStageData));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShipTowerTeamRecommendApplyFinish, new Action<int>(this.EventShipTowerTeamRecommendApplyFinish));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnRoleSkillBranchChanged));
	}

	// Token: 0x060154A0 RID: 87200 RVA: 0x005E679C File Offset: 0x005E499C
	protected override void OnBeforeShow()
	{
		if (this.RoleDetailMainRoleId != null)
		{
			int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
			int value = this.RoleDetailMainRoleId.Value;
			if (!(curSelectMainRoleId.GetValueOrDefault() == value & curSelectMainRoleId != null))
			{
				this.RoleDetailMainRoleId = null;
				this.StageData.UpdateMainRoleToEdit();
				this.SelectTeamDataRoleUpdate();
				ShipTowerTeamPanel teamPanel = this.TeamPanel;
				if (teamPanel != null)
				{
					teamPanel.UpdateRoleListByMainRoleChange();
				}
			}
		}
		this.UpdateData();
		if (!this.StageData.ProtoIsPassed)
		{
			base.PlaySequence("Tips", null, false);
		}
	}

	// Token: 0x060154A1 RID: 87201 RVA: 0x005E682F File Offset: 0x005E4A2F
	protected override void OnBeforeDestroy()
	{
		if (ModelBase<ShipTowerModel>.Instance.ChallengeStageData != this.StageData)
		{
			ShipTowerStageData stageData = this.StageData;
			if (stageData == null)
			{
				return;
			}
			stageData.UpdateToEdit();
		}
	}

	// Token: 0x060154A2 RID: 87202 RVA: 0x005E6854 File Offset: 0x005E4A54
	private void UpdateData()
	{
		this.UpdateChallengeType();
		GenericScrollViewNew<ShipTowerDescTeamItem, ShipTowerTeamData> descTeamScroll = this.DescTeamScroll;
		if (descTeamScroll != null)
		{
			descTeamScroll.RefreshByData(this.StageData.TeamDataList, null, true);
		}
		if (this.IsShowTeamPanel)
		{
			this.ShowTeamPanel();
		}
		else
		{
			this.ShowLeftPanel();
		}
		this.UpdateSkillBranchBtn();
	}

	// Token: 0x060154A3 RID: 87203 RVA: 0x005E68A4 File Offset: 0x005E4AA4
	private void UpdateChallengeType()
	{
		this.ChallengeBtnType = (this.StageData.CanReset() ? EShipTowerDescBtnType.AgainChallenge : EShipTowerDescBtnType.StartChallenge);
	}

	// Token: 0x060154A4 RID: 87204 RVA: 0x005E68CA File Offset: 0x005E4ACA
	private void OnBtnMaskClick()
	{
		this.ShowLeftPanel();
	}

	// Token: 0x060154A5 RID: 87205 RVA: 0x005E68D2 File Offset: 0x005E4AD2
	private void OnBtnResetClick()
	{
		ModelBase<ShipTowerModel>.Instance.OpenViewReset(new ShipTowerResetViewParams
		{
			StageData = this.StageData
		});
	}

	// Token: 0x060154A6 RID: 87206 RVA: 0x005E68EF File Offset: 0x005E4AEF
	private void OnBtnChallengeClick()
	{
		this.StageData.StartChallenge();
	}

	// Token: 0x060154A7 RID: 87207 RVA: 0x005E6900 File Offset: 0x005E4B00
	private void OnBtnRoleDetailClick()
	{
		ShipTowerTeamPanel teamPanel = this.TeamPanel;
		if (teamPanel != null)
		{
			teamPanel.UpdateRoleListFilter();
		}
		ShipTowerTeamPanel teamPanel2 = this.TeamPanel;
		List<int> list = (teamPanel2 != null) ? teamPanel2.GetRoleIdList() : null;
		if (list == null || list.Count == 0)
		{
			return;
		}
		int? roleDetailMainRoleId = null;
		foreach (int num in list)
		{
			if (ModelBase<RoleModel>.Instance.IsMainRole(num))
			{
				roleDetailMainRoleId = new int?(num);
				break;
			}
		}
		this.RoleDetailMainRoleId = roleDetailMainRoleId;
		ControllerBase<RoleController>.Instance.OpenRoleMainViewByParam(new OpenRoleMainViewData
		{
			AgentType = ERoleAgentType.Normal,
			RoleIdList = list,
			TeamPositionType = new ETeamPositionType?(ETeamPositionType.EditFormation)
		});
	}

	// Token: 0x060154A8 RID: 87208 RVA: 0x005E69C8 File Offset: 0x005E4BC8
	private void OnBtnAgainChallengeClick()
	{
		this.StageData.StartChallenge();
	}

	// Token: 0x060154A9 RID: 87209 RVA: 0x005E69D6 File Offset: 0x005E4BD6
	private void OnBtnTeamRecommendClick()
	{
		this.StageData.OpenViewTeamRecommend();
	}

	// Token: 0x060154AA RID: 87210 RVA: 0x005E69E4 File Offset: 0x005E4BE4
	private void OnExchangeTeamClick()
	{
		this.StageData.ExchangeTeamData();
		this.UpdateData();
		int id = this.StageData.Id;
		HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.ShipTowerExchangeInstId, null);
		if (hashSet != null && hashSet.Contains(id))
		{
			return;
		}
		if (hashSet != null)
		{
			hashSet.Add(id);
		}
		else
		{
			hashSet = new HashSet<int>
			{
				id
			};
		}
		LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.ShipTowerExchangeInstId, hashSet);
		ShipTowerSwitch shipTowerSwitch = new ShipTowerSwitch();
		shipTowerSwitch.i_inst_id = id;
		ControllerBase<LogReportController>.Instance.LogReport(shipTowerSwitch);
	}

	// Token: 0x060154AB RID: 87211 RVA: 0x005E6A60 File Offset: 0x005E4C60
	private void ShowTeamPanel()
	{
		if (!this.IsShowTeamPanel)
		{
			base.PlaySequence("Team", null, false);
		}
		this.IsShowTeamPanel = true;
		ShipTowerDescLeftPanel descLeftPanel = this.DescLeftPanel;
		if (descLeftPanel != null)
		{
			descLeftPanel.SetActive(false);
		}
		ShipTowerTeamPanel teamPanel = this.TeamPanel;
		if (teamPanel != null)
		{
			teamPanel.UpdateViewAndShow(this.SelectedTeamData);
		}
		this.UpdateRoleDetailBtn();
		this.UpdateBtnInfo(this.BtnB, this.ChallengeBtnType, this.StageData.IsUnLocked());
		this.SetBtnMaskActive(true);
	}

	// Token: 0x060154AC RID: 87212 RVA: 0x005E6ADC File Offset: 0x005E4CDC
	private void UpdateRoleDetailBtn()
	{
		ShipTowerTeamPanel teamPanel = this.TeamPanel;
		List<int> list = (teamPanel != null) ? teamPanel.GetRoleIdList() : null;
		this.UpdateBtnInfo(this.BtnA, EShipTowerDescBtnType.RoleDetail, list != null && list.Count > 0);
	}

	// Token: 0x060154AD RID: 87213 RVA: 0x005E6B18 File Offset: 0x005E4D18
	private void ShowLeftPanel()
	{
		this.IsShowTeamPanel = false;
		ShipTowerTeamPanel teamPanel = this.TeamPanel;
		if (teamPanel != null)
		{
			teamPanel.SetActive(false);
		}
		ShipTowerDescLeftPanel descLeftPanel = this.DescLeftPanel;
		if (descLeftPanel != null)
		{
			descLeftPanel.UpdateViewAndShow(this.StageData);
		}
		this.UpdateBtnInfo(this.BtnA, EShipTowerDescBtnType.Reset, this.StageData.CanReset());
		this.UpdateBtnInfo(this.BtnB, this.ChallengeBtnType, this.StageData.IsUnLocked());
		this.SetBtnMaskActive(false);
		UUIItem teamEmptyItem = this.GetTeamEmptyItem();
		if (teamEmptyItem == null)
		{
			return;
		}
		teamEmptyItem.SetUIActive(false);
	}

	// Token: 0x060154AE RID: 87214 RVA: 0x005E6BA4 File Offset: 0x005E4DA4
	private void SetBtnMaskActive(bool active)
	{
		UUIItem item = base.GetItem(8);
		if (item != null)
		{
			item.SetUIActive(active);
		}
		UUIItem item2 = base.GetItem(9);
		if (item2 != null)
		{
			item2.SetUIActive(active);
		}
		if (this.SelectedTeamData == null)
		{
			return;
		}
		if (active)
		{
			this.NormalOtherTeam();
			return;
		}
		ShipTowerDescTeamItem selectDescTeamItem = this.GetSelectDescTeamItem();
		if (selectDescTeamItem == null)
		{
			return;
		}
		selectDescTeamItem.SetTeamToggleIsSelect(false);
	}

	// Token: 0x060154AF RID: 87215 RVA: 0x005E6BFC File Offset: 0x005E4DFC
	[NullableContext(2)]
	private UUIItem GetTeamEmptyItem()
	{
		return base.GetItem(12);
	}

	// Token: 0x060154B0 RID: 87216 RVA: 0x005E6C08 File Offset: 0x005E4E08
	private void NormalOtherTeam()
	{
		for (int i = 0; i < this.StageData.TeamDataList.Count; i++)
		{
			int num = i;
			ShipTowerTeamData selectedTeamData = this.SelectedTeamData;
			int? num2 = (selectedTeamData != null) ? new int?(selectedTeamData.Index) : null;
			if (!(num == num2.GetValueOrDefault() & num2 != null))
			{
				GenericScrollViewNew<ShipTowerDescTeamItem, ShipTowerTeamData> descTeamScroll = this.DescTeamScroll;
				ShipTowerDescTeamItem shipTowerDescTeamItem = (descTeamScroll != null) ? descTeamScroll.GetScrollItemByIndex(i) : null;
				if (shipTowerDescTeamItem != null)
				{
					shipTowerDescTeamItem.SetTeamToggleIsSelect(false);
				}
			}
		}
	}

	// Token: 0x060154B1 RID: 87217 RVA: 0x005E6C84 File Offset: 0x005E4E84
	[NullableContext(2)]
	private ShipTowerDescTeamItem GetSelectDescTeamItem()
	{
		if (this.SelectedTeamData == null)
		{
			return null;
		}
		int index = this.SelectedTeamData.Index;
		GenericScrollViewNew<ShipTowerDescTeamItem, ShipTowerTeamData> descTeamScroll = this.DescTeamScroll;
		if (descTeamScroll == null)
		{
			return null;
		}
		return descTeamScroll.GetScrollItemByIndex(index);
	}

	// Token: 0x060154B2 RID: 87218 RVA: 0x005E6CB9 File Offset: 0x005E4EB9
	private ShipTowerDescTeamItem CreateDescTeamItem()
	{
		return new ShipTowerDescTeamItem
		{
			RoleClickCallBack = new Action<ShipTowerTeamData>(this.OnRoleClick),
			BuffClickCallBack = new Action<ShipTowerTeamData>(this.OnBuffClick),
			MechanismClickCallBack = new Action<ShipTowerTeamData>(this.OnMechanismClick)
		};
	}

	// Token: 0x060154B3 RID: 87219 RVA: 0x005E6CF8 File Offset: 0x005E4EF8
	public void OnRoleClick(ShipTowerTeamData data)
	{
		ShipTowerTeamData selectedTeamData = this.SelectedTeamData;
		int? num = (selectedTeamData != null) ? new int?(selectedTeamData.Index) : null;
		int index = data.Index;
		if (!(num.GetValueOrDefault() == index & num != null))
		{
			this.SelectedTeamData = data;
			this.SelectTeamDataRoleUpdate();
		}
		this.ShowTeamPanel();
	}

	// Token: 0x060154B4 RID: 87220 RVA: 0x005E6D54 File Offset: 0x005E4F54
	private void SelectTeamDataRoleUpdate()
	{
		if (this.SelectedTeamData == null)
		{
			return;
		}
		this.SelectedTeamData.UpdateRoleListToRoleSelectModel();
		this.StageData.UpdateCurSelectTeamIndex(this.SelectedTeamData.Index);
		this.StageData.UpdateOtherTeamRoleToModel(this.SelectedTeamData.Index);
		this.StageData.UpdateAllTeamRoleToModel();
	}

	// Token: 0x060154B5 RID: 87221 RVA: 0x005E6DAC File Offset: 0x005E4FAC
	private void OnBuffClick(ShipTowerTeamData teamData)
	{
		ShipTowerModel instance = ModelBase<ShipTowerModel>.Instance;
		ShipTowerBuffViewParams shipTowerBuffViewParams = new ShipTowerBuffViewParams();
		ShipTowerBuffData buffDataEdit = teamData.BuffDataEdit;
		shipTowerBuffViewParams.BuffId = ((buffDataEdit != null) ? new int?(buffDataEdit.Id) : null);
		shipTowerBuffViewParams.StageId = new int?(this.StageData.Id);
		shipTowerBuffViewParams.OperationType = new EShipTowerBuffOperationType?(EShipTowerBuffOperationType.Use);
		shipTowerBuffViewParams.TeamData = teamData;
		shipTowerBuffViewParams.OnUseBuff = new Action<ShipTowerBuffData, ShipTowerTeamData>(this.OnUseBuff);
		instance.OpenViewBuff(shipTowerBuffViewParams);
	}

	// Token: 0x060154B6 RID: 87222 RVA: 0x005E6E28 File Offset: 0x005E5028
	private void OnMechanismClick(ShipTowerTeamData teamData)
	{
		this.StageData.OpenViewMonsterDesc(new int?(teamData.InstId));
	}

	// Token: 0x060154B7 RID: 87223 RVA: 0x005E6E40 File Offset: 0x005E5040
	private void OnUseBuff(ShipTowerBuffData buffData, [Nullable(2)] ShipTowerTeamData teamData)
	{
		if (teamData != null)
		{
			teamData.UseBuff(buffData);
		}
		int index = (teamData != null) ? teamData.Index : -1;
		GenericScrollViewNew<ShipTowerDescTeamItem, ShipTowerTeamData> descTeamScroll = this.DescTeamScroll;
		if (descTeamScroll != null)
		{
			ShipTowerDescTeamItem scrollItemByIndex = descTeamScroll.GetScrollItemByIndex(index);
			if (scrollItemByIndex != null)
			{
				scrollItemByIndex.UpdateBuff();
			}
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ShipTowerBuffView, null);
	}

	// Token: 0x060154B8 RID: 87224 RVA: 0x005E6E94 File Offset: 0x005E5094
	private void UpdateBtnInfo(ButtonItem btn, EShipTowerDescBtnType btnType, bool isShow = true)
	{
		btn.SetActive(isShow);
		if (!isShow)
		{
			return;
		}
		switch (btnType)
		{
		case EShipTowerDescBtnType.StartChallenge:
			this.SetBtnText(btn, "GhostShipBtn_Text2");
			btn.SetFunction(delegate(int _)
			{
				this.OnBtnChallengeClick();
			});
			return;
		case EShipTowerDescBtnType.AgainChallenge:
			this.SetBtnText(btn, "GhostShipBtn_Text4");
			btn.SetFunction(delegate(int _)
			{
				this.OnBtnAgainChallengeClick();
			});
			return;
		case EShipTowerDescBtnType.Reset:
			this.SetBtnText(btn, "GhostShipBtn_Text3");
			btn.SetFunction(delegate(int _)
			{
				this.OnBtnResetClick();
			});
			return;
		case EShipTowerDescBtnType.RoleDetail:
			this.SetBtnText(btn, "GhostShipBtn_Text1");
			btn.SetFunction(delegate(int _)
			{
				this.OnBtnRoleDetailClick();
			});
			return;
		default:
			return;
		}
	}

	// Token: 0x060154B9 RID: 87225 RVA: 0x005E6F40 File Offset: 0x005E5140
	private void SetBtnText(ButtonItem btn, string textKey)
	{
		string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(textKey, textKey);
		btn.SetText(multiTextByKey);
	}

	// Token: 0x060154BA RID: 87226 RVA: 0x005E6F64 File Offset: 0x005E5164
	private void OnRoleSelect(RoleDataBase roleData)
	{
		this.SelectedLeftRoleData = roleData;
		if (this.SelectedTeamData == null)
		{
			return;
		}
		int index = this.SelectedTeamData.Index;
		int dataId = roleData.GetDataId();
		bool flag = ModelBase<ShipTowerModel>.Instance.IsOtherTeamRoleData(dataId);
		this.SelectedTeamData.UpdateRoleListByModel();
		if (flag)
		{
			this.StageData.UpdateOtherTeamRoleRepeat(index, new int?(dataId));
		}
		this.StageData.UpdateAllTeamRoleToModel();
		GenericScrollViewNew<ShipTowerDescTeamItem, ShipTowerTeamData> descTeamScroll = this.DescTeamScroll;
		if (descTeamScroll != null)
		{
			descTeamScroll.RefreshByData(this.StageData.TeamDataList, null, false);
		}
		this.UpdateSkillBranchBtn();
	}

	// Token: 0x060154BB RID: 87227 RVA: 0x005E6FF0 File Offset: 0x005E51F0
	private void OnRoleTeamSelect(EditFormationData formationData)
	{
		if (this.SelectedTeamData == null)
		{
			return;
		}
		int index = this.SelectedTeamData.Index;
		ShipTowerTeamData shipTowerTeamData = this.StageData.TeamDataList[index];
		foreach (ShipTowerRoleData shipTowerRoleData in shipTowerTeamData.RoleList)
		{
			if (ModelBase<RoleModel>.Instance.IsRoleHasBranch(shipTowerRoleData.RoleIdEdit))
			{
				int roleCurrentBranchId = ModelBase<RoleModel>.Instance.GetRoleCurrentBranchId(shipTowerRoleData.RoleIdEdit);
				ModelBase<RoleModel>.Instance.SetRoleSkillBranchGamePlayCache(shipTowerRoleData.RoleIdEdit, roleCurrentBranchId, ESkillBranchCacheType.ShipTower);
			}
		}
		shipTowerTeamData.UpdateRoleListByFormationData(formationData);
		this.StageData.UpdateOtherTeamRoleRepeat(index, null);
		this.StageData.UpdateAllTeamRoleToModel();
		ShipTowerTeamPanel teamPanel = this.TeamPanel;
		if (teamPanel != null)
		{
			teamPanel.OnlyUpdateTeamList();
		}
		GenericScrollViewNew<ShipTowerDescTeamItem, ShipTowerTeamData> descTeamScroll = this.DescTeamScroll;
		if (descTeamScroll != null)
		{
			descTeamScroll.RefreshByData(this.StageData.TeamDataList, null, false);
		}
		this.UpdateSkillBranchBtn();
	}

	// Token: 0x060154BC RID: 87228 RVA: 0x005E70F8 File Offset: 0x005E52F8
	private void OnRoleListUpdate()
	{
		if (!this.IsShowTeamPanel)
		{
			return;
		}
		this.UpdateRoleDetailBtn();
	}

	// Token: 0x060154BD RID: 87229 RVA: 0x005E7109 File Offset: 0x005E5309
	private void CheckUpdateStageData(int id)
	{
		if (this.StageData.Id != id)
		{
			return;
		}
		if (this.SelectedTeamData != null)
		{
			this.SelectTeamDataRoleUpdate();
		}
		this.UpdateData();
	}

	// Token: 0x060154BE RID: 87230 RVA: 0x005E7130 File Offset: 0x005E5330
	private void EventShipTowerTeamRecommendApplyFinish(int id)
	{
		if (this.StageData.Id != id)
		{
			return;
		}
		if (this.IsShowTeamPanel && this.SelectedTeamData != null)
		{
			this.SelectedTeamData.UpdateRoleListToRoleSelectModel();
			this.StageData.UpdateOtherTeamRoleToModel(this.SelectedTeamData.Index);
			this.StageData.UpdateAllTeamRoleToModel();
		}
		this.UpdateData();
	}

	// Token: 0x060154BF RID: 87231 RVA: 0x005E7190 File Offset: 0x005E5390
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		string a = configParams[0];
		if (!(a == "TabCompRight"))
		{
			if (!(a == "Desc") && !(a == "Item") && !(a == "TeamAndItem") && !(a == "TeamAndItemOuter"))
			{
				return null;
			}
			int index;
			if (configParams.Length != 2 || !int.TryParse(configParams[1], out index))
			{
				return null;
			}
			GenericScrollViewNew<ShipTowerDescTeamItem, ShipTowerTeamData> descTeamScroll = this.DescTeamScroll;
			ShipTowerDescTeamItem shipTowerDescTeamItem = (descTeamScroll != null) ? descTeamScroll.GetScrollItemByIndex(index) : null;
			if (shipTowerDescTeamItem == null)
			{
				return null;
			}
			return shipTowerDescTeamItem.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
		else
		{
			ShipTowerTeamPanel teamPanel = this.TeamPanel;
			if (teamPanel == null)
			{
				return null;
			}
			return teamPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
	}

	// Token: 0x060154C0 RID: 87232 RVA: 0x005E722C File Offset: 0x005E542C
	private void OnBtnSkillBranchClick()
	{
		RoleSkillBranchPopViewParams roleSkillBranchPopViewParams = this.BuildSkillBranchPopViewParams();
		RoleSkillBranchPopViewParams roleSkillBranchPopViewParams2 = roleSkillBranchPopViewParams;
		ShipTowerTeamData selectedTeamData = this.SelectedTeamData;
		roleSkillBranchPopViewParams2.PreferredTabIndex = ((selectedTeamData != null) ? new int?(selectedTeamData.Index) : null);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleSkillBranchPopView, roleSkillBranchPopViewParams, null);
	}

	// Token: 0x060154C1 RID: 87233 RVA: 0x005E7278 File Offset: 0x005E5478
	private RoleSkillBranchPopViewParams BuildSkillBranchPopViewParams()
	{
		RoleSkillBranchPopViewParams roleSkillBranchPopViewParams = new RoleSkillBranchPopViewParams();
		List<List<int>> list = new List<List<int>>();
		foreach (ShipTowerTeamData shipTowerTeamData in this.StageData.TeamDataList)
		{
			List<int> list2 = new List<int>();
			foreach (ShipTowerRoleData shipTowerRoleData in shipTowerTeamData.GetUseRoleList())
			{
				list2.Add(shipTowerRoleData.RoleIdEdit);
			}
			list.Add(list2);
		}
		int[][] array = new int[list.Count][];
		for (int i = 0; i < list.Count; i++)
		{
			array[i] = list[i].ToArray();
		}
		roleSkillBranchPopViewParams.Load(array);
		return roleSkillBranchPopViewParams;
	}

	// Token: 0x060154C2 RID: 87234 RVA: 0x005E7368 File Offset: 0x005E5568
	private bool CheckHasSkillBranchInRoleEdit()
	{
		foreach (ShipTowerTeamData shipTowerTeamData in this.StageData.TeamDataList)
		{
			foreach (ShipTowerRoleData shipTowerRoleData in shipTowerTeamData.GetUseRoleList())
			{
				if (shipTowerRoleData.RoleIdEdit > 0 && ModelBase<RoleModel>.Instance.IsRoleHasBranch(shipTowerRoleData.RoleIdEdit))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060154C3 RID: 87235 RVA: 0x005E7414 File Offset: 0x005E5614
	private void UpdateSkillBranchBtn()
	{
		bool uiactive = this.CheckHasSkillBranchInRoleEdit();
		UUIButtonComponent button = base.GetButton(14);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x060154C4 RID: 87236 RVA: 0x005E7448 File Offset: 0x005E5648
	private void OnRoleSkillBranchChanged(int roleId)
	{
		ShipTowerTeamPanel teamPanel = this.TeamPanel;
		if (teamPanel != null)
		{
			teamPanel.RefreshRole(roleId);
		}
		GenericScrollViewNew<ShipTowerDescTeamItem, ShipTowerTeamData> descTeamScroll = this.DescTeamScroll;
		if (descTeamScroll == null)
		{
			return;
		}
		descTeamScroll.RefreshByData(this.StageData.TeamDataList, null, false);
	}

	// Token: 0x0400A420 RID: 42016
	private ShipTowerStageData StageData;

	// Token: 0x0400A421 RID: 42017
	[Nullable(2)]
	private ShipTowerTeamPanel TeamPanel;

	// Token: 0x0400A422 RID: 42018
	[Nullable(2)]
	private PopupCaptionItem PopupCaption;

	// Token: 0x0400A423 RID: 42019
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ShipTowerDescTeamItem, ShipTowerTeamData> DescTeamScroll;

	// Token: 0x0400A424 RID: 42020
	[Nullable(2)]
	private ShipTowerDescLeftPanel DescLeftPanel;

	// Token: 0x0400A425 RID: 42021
	private ButtonItem BtnA;

	// Token: 0x0400A426 RID: 42022
	private ButtonItem BtnB;

	// Token: 0x0400A427 RID: 42023
	[Nullable(2)]
	private ShipTowerTeamData SelectedTeamData;

	// Token: 0x0400A428 RID: 42024
	[Nullable(2)]
	public RoleDataBase SelectedLeftRoleData;

	// Token: 0x0400A429 RID: 42025
	private EShipTowerDescBtnType ChallengeBtnType;

	// Token: 0x0400A42A RID: 42026
	private int? RoleDetailMainRoleId;

	// Token: 0x02008D0A RID: 36106
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F716 RID: 194326
		public const int ItemCaption = 0;

		// Token: 0x0402F717 RID: 194327
		public const int ItemRootLeft = 1;

		// Token: 0x0402F718 RID: 194328
		public const int ScrollBarRight = 2;

		// Token: 0x0402F719 RID: 194329
		public const int BtnMask = 3;

		// Token: 0x0402F71A RID: 194330
		public const int BtnReset = 4;

		// Token: 0x0402F71B RID: 194331
		public const int BtnChallenge = 5;

		// Token: 0x0402F71C RID: 194332
		public const int BtnTeamRecommend = 6;

		// Token: 0x0402F71D RID: 194333
		public const int ItemRootTeam = 7;

		// Token: 0x0402F71E RID: 194334
		public const int ItemMaskSet = 8;

		// Token: 0x0402F71F RID: 194335
		public const int ItemMaskTeam = 9;

		// Token: 0x0402F720 RID: 194336
		public const int BtnMask2 = 10;

		// Token: 0x0402F721 RID: 194337
		public const int ItemTeam = 11;

		// Token: 0x0402F722 RID: 194338
		public const int ItemTeamNull = 12;

		// Token: 0x0402F723 RID: 194339
		public const int ExchangeTeamButton = 13;

		// Token: 0x0402F724 RID: 194340
		public const int BtnSkillBranch = 14;
	}
}
