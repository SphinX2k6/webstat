using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200279F RID: 10143
[NullableContext(1)]
[Nullable(0)]
public class TeamRoleSelectView : UiViewBase
{
	// Token: 0x06014050 RID: 82000 RVA: 0x0059545F File Offset: 0x0059365F
	public TeamRoleSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06014051 RID: 82001 RVA: 0x00595468 File Offset: 0x00593668
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIInteractionGroup)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUIMultiTemplateLayout)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIText)),
			new ValueTuple<int, Type>(22, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIText)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUIItem)),
			new ValueTuple<int, Type>(28, typeof(UUIItem)),
			new ValueTuple<int, Type>(29, typeof(UUIItem)),
			new ValueTuple<int, Type>(30, typeof(UUIItem)),
			new ValueTuple<int, Type>(31, typeof(UUIItem)),
			new ValueTuple<int, Type>(32, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.ConfirmClick)),
			new ValueTuple<int, Delegate>(4, new Action(this.BackClick)),
			new ValueTuple<int, Delegate>(9, new Action(this.OnDetailClick)),
			new ValueTuple<int, Delegate>(22, new Action<EToggleState>(this.OnSkillModeToggleClick))
		};
	}

	// Token: 0x06014052 RID: 82002 RVA: 0x005957DC File Offset: 0x005939DC
	protected override UniTask OnBeforeStartAsync()
	{
		TeamRoleSelectView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TeamRoleSelectView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014053 RID: 82003 RVA: 0x00595820 File Offset: 0x00593A20
	protected override void OnStart()
	{
		if (this.Data == null)
		{
			return;
		}
		this.RoleScrollView = new LoopScrollView<TeamRoleGridBase, RoleDataBase>(base.GetLoopScrollViewComponent(1), base.GetItem(7).GetOwner() as AUIBaseActor, new Func<TeamRoleGridBase>(this.OnGridProxyCreate), false);
		UUIItem item = base.GetItem(20);
		this.TeamRoleOne = new TeamPlayerSelectionComponent(item);
		UUIItem item2 = base.GetItem(21);
		this.TeamRoleTwo = new TeamPlayerSelectionComponent(item2);
		this.RefreshSkillModeToggle();
		this.SkillLayout = new GenericLayout<TeamRoleSkillItem, TeamRoleSkillData>(base.GetHorizontalLayout(13), new Func<TeamRoleSkillItem>(this.InitSkillItem), null, false, true);
		this.RoleTagLayout = new GenericLayout<RoleTagMediumIconItem, int>(base.GetMultiTemplateLayout(16), () => new RoleTagMediumIconItem(), null, false, true);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.RoleList = this.Data.RoleList;
		int? num = new int?(this.Data.CurrentRoleId);
		int[] formationRoleList = this.Data.FormationRoleList;
		ModelBase<RoleSelectModel>.Instance.ClearData();
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		if (formationRoleList != null && this.RoleList != null)
		{
			int num2 = 1;
			while (num2 <= 3 && num2 <= formationRoleList.Length)
			{
				int num3 = formationRoleList[num2 - 1];
				foreach (RoleDataBase roleDataBase in this.RoleList)
				{
					if (roleDataBase.GetDataId() == num3)
					{
						roleIndexMap[num2] = roleDataBase;
						break;
					}
				}
				num2++;
			}
		}
		UUIItem item3 = base.GetItem(5);
		this.FilterSortEntrance = new FilterSortEntrance<RoleDataBase>(item3, new TUpdateDataListFunction<RoleDataBase>(this.UpdateRoleList));
		if (this.RoleList != null)
		{
			foreach (RoleDataBase roleDataBase2 in this.RoleList)
			{
				int dataId = roleDataBase2.GetDataId();
				int? num4 = num;
				if (dataId == num4.GetValueOrDefault() & num4 != null)
				{
					this.CurSelectRole = roleDataBase2;
					break;
				}
			}
		}
		this.RefreshTeamItem(this.Data.EditBattleRoleSlotDataList);
		if (this.RoleList != null)
		{
			this.RoleList.Sort((RoleDataBase a, RoleDataBase b) => b.GetRoleConfig().Priority - a.GetRoleConfig().Priority);
		}
		if (this.Data.UseWay != null && this.RoleList != null)
		{
			FilterSortEntrance<RoleDataBase> filterSortEntrance = this.FilterSortEntrance;
			if (filterSortEntrance == null)
			{
				return;
			}
			filterSortEntrance.UpdateData(this.Data.UseWay.Value, this.RoleList, Array.Empty<object>());
		}
	}

	// Token: 0x06014054 RID: 82004 RVA: 0x00595ADC File Offset: 0x00593CDC
	protected override void OnBeforeShow()
	{
		if (this.IsNeedRefreshTeamList)
		{
			this.RefreshRoleListAfterChangeRole();
			this.IsNeedRefreshTeamList = false;
		}
	}

	// Token: 0x06014055 RID: 82005 RVA: 0x00595AF4 File Offset: 0x00593CF4
	private void RefreshSkillModeToggle()
	{
		this.SkillDescType = ModelBase<RoleModel>.Instance.GetRoleSkillDescType();
		UUIExtendToggle extendToggle = base.GetExtendToggle(22);
		if (extendToggle == null)
		{
			return;
		}
		if (this.SkillDescType == ERoleSkillDescType.MultiDesc)
		{
			EToggleState state = ModelBase<RoleModel>.Instance.IsShowMultiSkillDesc ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			extendToggle.SetToggleState(state, false, false, false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(25), "MultiplayerSkillDescription_text", Array.Empty<object>());
			return;
		}
		EToggleState state2 = ModelBase<RoleModel>.Instance.IsShowSkillResume ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		extendToggle.SetToggleState(state2, false, false, false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(25), "SkillBriefDescription_text", Array.Empty<object>());
	}

	// Token: 0x06014056 RID: 82006 RVA: 0x00595B98 File Offset: 0x00593D98
	private UniTask InitHonamiStoryInfoAsync()
	{
		TeamRoleSelectView.<InitHonamiStoryInfoAsync>d__24 <InitHonamiStoryInfoAsync>d__;
		<InitHonamiStoryInfoAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitHonamiStoryInfoAsync>d__.<>4__this = this;
		<InitHonamiStoryInfoAsync>d__.<>1__state = -1;
		<InitHonamiStoryInfoAsync>d__.<>t__builder.Start<TeamRoleSelectView.<InitHonamiStoryInfoAsync>d__24>(ref <InitHonamiStoryInfoAsync>d__);
		return <InitHonamiStoryInfoAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014057 RID: 82007 RVA: 0x00595BDC File Offset: 0x00593DDC
	protected override void OnBeforeDestroy()
	{
		TeamRoleSelectViewData data = this.Data;
		if (data != null)
		{
			Action onHideFinishCallBack = data.OnHideFinishCallBack;
			if (onHideFinishCallBack != null)
			{
				onHideFinishCallBack();
			}
		}
		FilterSortEntrance<RoleDataBase> filterSortEntrance = this.FilterSortEntrance;
		if (filterSortEntrance != null)
		{
			filterSortEntrance.Destroy(null);
		}
		this.Data = null;
		this.CurSelectRole = null;
		FilterSortEntrance<RoleDataBase> filterSortEntrance2 = this.FilterSortEntrance;
		if (filterSortEntrance2 != null)
		{
			filterSortEntrance2.Destroy(null);
		}
		this.FilterSortEntrance = null;
		LoopScrollView<TeamRoleGridBase, RoleDataBase> roleScrollView = this.RoleScrollView;
		if (roleScrollView != null)
		{
			roleScrollView.ClearGridProxies();
		}
		this.RoleScrollView = null;
		List<RoleDataBase> roleList = this.RoleList;
		if (roleList != null)
		{
			roleList.Clear();
		}
		this.RoleList = null;
		TeamPlayerSelectionComponent teamRoleOne = this.TeamRoleOne;
		if (teamRoleOne != null)
		{
			teamRoleOne.Destroy(null);
		}
		this.TeamRoleOne = null;
		TeamPlayerSelectionComponent teamRoleTwo = this.TeamRoleTwo;
		if (teamRoleTwo != null)
		{
			teamRoleTwo.Destroy(null);
		}
		this.TeamRoleTwo = null;
		GenericLayout<TeamRoleSkillItem, TeamRoleSkillData> skillLayout = this.SkillLayout;
		if (skillLayout != null)
		{
			skillLayout.ClearChildren();
		}
		this.SkillLayout = null;
		List<TeamRoleSkillData> skillDataList = this.SkillDataList;
		if (skillDataList != null)
		{
			skillDataList.Clear();
		}
		this.SkillDataList = null;
		GenericLayout<RoleTagMediumIconItem, int> roleTagLayout = this.RoleTagLayout;
		if (roleTagLayout != null)
		{
			roleTagLayout.ClearChildren();
		}
		this.RoleTagLayout = null;
	}

	// Token: 0x06014058 RID: 82008 RVA: 0x00595CE8 File Offset: 0x00593EE8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshEditBattleRoleSlotData, new Action<ERefreshEditBattleRoleSlotDataReason>(this.OnRefreshEditBattleRoleSlotData));
		Singleton<EventSystem>.Instance.Add<IReadOnlyDictionary<int, int>, IReadOnlyDictionary<int, int>>(EEventName.RoleRefreshAttribute, new Action<IReadOnlyDictionary<int, int>, IReadOnlyDictionary<int, int>>(this.OnRoleRefreshAttribute));
		Singleton<EventSystem>.Instance.Add<Entity>(EEventName.OnRevive, new Action<Entity>(this.OnRevive));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleSkillBranchChanged, new Action<int>(this.OnRoleSkillBranchChanged));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnRoleSkillBranchChanged));
		float valueOrDefault = ConfigCommonParamById.GetFloatConfig("TermExplanationViewOffsetOnTeamView").GetValueOrDefault();
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlink(base.GetText(18), ETermExplanationViewType.Side, ETermExplanationReportType.Team, ETermExplanationViewAttachDirection.Left, null, null, new ValueTuple<float, float>?(new ValueTuple<float, float>(valueOrDefault, 0f)), ETermExplanationGroup.Default, 0, ETermExplanationViewStyle.Default);
	}

	// Token: 0x06014059 RID: 82009 RVA: 0x00595DC0 File Offset: 0x00593FC0
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshEditBattleRoleSlotData, new Action<ERefreshEditBattleRoleSlotDataReason>(this.OnRefreshEditBattleRoleSlotData));
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleRefreshAttribute, new Action<IReadOnlyDictionary<int, int>, IReadOnlyDictionary<int, int>>(this.OnRoleRefreshAttribute));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRevive, new Action<Entity>(this.OnRevive));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleSkillBranchChanged, new Action<int>(this.OnRoleSkillBranchChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnRoleSkillBranchChanged));
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(18));
	}

	// Token: 0x0601405A RID: 82010 RVA: 0x00595E6C File Offset: 0x0059406C
	private void UpdateRoleList(List<RoleDataBase> list, bool isOutSideChange, EFilterSortType type)
	{
		if (this.Data == null)
		{
			return;
		}
		this.RoleList = list;
		bool flag = this.RoleList.Count > 0;
		base.GetItem(8).SetUIActive(!flag);
		base.GetLoopScrollViewComponent(1).RootUIComp.Get().SetUIActive(flag);
		base.GetItem(24).SetUIActive(flag);
		base.GetItem(10).SetUIActive(flag);
		if (!flag || this.RoleScrollView == null)
		{
			base.GetButton(3).RootUIComp.Get().SetUIActive(false);
			base.GetButton(9).RootUIComp.Get().SetUIActive(false);
			return;
		}
		RoleDataBase curSelectRole = this.CurSelectRole;
		int? num = (curSelectRole != null) ? new int?(curSelectRole.GetDataId()) : null;
		if (num != null)
		{
			ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Remove(num.Value);
		}
		this.RoleScrollView.DeselectCurrentGridProxy(false);
		this.RoleScrollView.RefreshByData(this.RoleList, false, null, false);
		if (this.CurSelectRole == null)
		{
			foreach (RoleDataBase roleDataBase in this.RoleList)
			{
				this.CurSelectRole = roleDataBase;
				Func<int, bool> canJoinTeam = this.Data.CanJoinTeam;
				if (canJoinTeam != null && canJoinTeam(roleDataBase.GetDataId()))
				{
					break;
				}
			}
			this.SelectCurrentRole();
			return;
		}
		if (type == EFilterSortType.Sort && !isOutSideChange)
		{
			this.CurSelectRole = this.RoleList[0];
			this.SelectCurrentRole();
			return;
		}
		bool flag2 = false;
		foreach (RoleDataBase roleDataBase2 in this.RoleList)
		{
			int dataId = roleDataBase2.GetDataId();
			RoleDataBase curSelectRole2 = this.CurSelectRole;
			int? num2 = (curSelectRole2 != null) ? new int?(curSelectRole2.GetDataId()) : null;
			if (dataId == num2.GetValueOrDefault() & num2 != null)
			{
				flag2 = true;
				break;
			}
		}
		if (!flag2)
		{
			this.CurSelectRole = this.RoleList[0];
		}
		this.SelectCurrentRole();
	}

	// Token: 0x0601405B RID: 82011 RVA: 0x005960B0 File Offset: 0x005942B0
	private void SelectCurrentRole()
	{
		if (this.CurSelectRole == null || this.RoleList == null || this.RoleScrollView == null)
		{
			return;
		}
		this.CheckCurRoleIsDead();
		int gridIndex = this.RoleList.IndexOf(this.CurSelectRole);
		this.RoleScrollView.SelectGridProxy(gridIndex, false);
		int dataId = this.CurSelectRole.GetDataId();
		ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Add(dataId);
		this.RefreshConfirmText(dataId);
		this.RefreshConfirmButtonEnable(dataId);
		this.RefreshRoleInfo(dataId);
	}

	// Token: 0x0601405C RID: 82012 RVA: 0x00596130 File Offset: 0x00594330
	private TeamRoleGridBase OnGridProxyCreate()
	{
		TeamRoleSelectViewData data = this.Data;
		TeamRoleGridBase teamRoleGridBase;
		if (((data != null) ? data.OverrideGridProxyCreate : null) != null)
		{
			teamRoleGridBase = this.Data.OverrideGridProxyCreate();
		}
		else
		{
			teamRoleGridBase = new TeamRoleGrid();
		}
		teamRoleGridBase.IsHighlightIndex = new Func<int, bool>(this.IsHighlightIndex);
		teamRoleGridBase.IsShowGray = new Func<int, bool>(this.IsShowGray);
		teamRoleGridBase.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.ToggleFunction));
		teamRoleGridBase.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChangeFunction));
		return teamRoleGridBase;
	}

	// Token: 0x0601405D RID: 82013 RVA: 0x005961B8 File Offset: 0x005943B8
	protected bool IsHighlightIndex(int position)
	{
		TeamRoleSelectViewData data = this.Data;
		return position == ((data != null) ? data.Position : null).GetValueOrDefault(-1);
	}

	// Token: 0x0601405E RID: 82014 RVA: 0x005961EB File Offset: 0x005943EB
	protected bool IsShowGray(int roleId)
	{
		TeamRoleSelectViewData data = this.Data;
		return data == null || !data.CanUseSpecialTrialRole || !RoleUtils.IsSpecialTrialRole(roleId);
	}

	// Token: 0x0601405F RID: 82015 RVA: 0x0059620C File Offset: 0x0059440C
	protected void ToggleFunction(MediumItemGridExtendCallback @params)
	{
		if (@params.State != EToggleState.ETT_Checked)
		{
			return;
		}
		RoleDataBase curSelectRole = this.CurSelectRole;
		int? num = (curSelectRole != null) ? new int?(curSelectRole.GetDataId()) : null;
		if (num != null)
		{
			ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Remove(num.Value);
		}
		RoleDataBase roleDataBase = @params.Data as RoleDataBase;
		if (roleDataBase == null)
		{
			return;
		}
		this.CurSelectRole = roleDataBase;
		this.CheckCurRoleIsDead();
		if (this.RoleList == null || this.RoleScrollView == null)
		{
			return;
		}
		int gridIndex = this.RoleList.IndexOf(roleDataBase);
		this.RoleScrollView.SelectGridProxy(gridIndex, false);
		int dataId = this.CurSelectRole.GetDataId();
		ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Add(dataId);
		this.RefreshConfirmText(dataId);
		this.RefreshConfirmButtonEnable(dataId);
		this.RefreshRoleInfo(dataId);
		TeamRoleSelectViewData data = this.Data;
		if (data == null)
		{
			return;
		}
		Action<int> onRoleSelect = data.OnRoleSelect;
		if (onRoleSelect == null)
		{
			return;
		}
		onRoleSelect(dataId);
	}

	// Token: 0x06014060 RID: 82016 RVA: 0x005962FC File Offset: 0x005944FC
	protected bool CanExecuteChangeFunction(object data, bool isForceSelected, EToggleState state)
	{
		TeamRoleSelectViewData data2 = this.Data;
		if (data2 == null || !data2.CanUseSpecialTrialRole)
		{
			RoleDataBase roleDataBase = data as RoleDataBase;
			if (roleDataBase == null)
			{
				return false;
			}
			int dataId = roleDataBase.GetDataId();
			if (RoleUtils.IsSpecialTrialRole(dataId))
			{
				TeamRoleSelectViewData data3 = this.Data;
				bool flag;
				if (data3 == null)
				{
					flag = true;
				}
				else
				{
					int[] formationRoleList = data3.FormationRoleList;
					flag = !((formationRoleList != null) ? new bool?(formationRoleList.Contains(dataId)) : null).GetValueOrDefault();
				}
				if (flag)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PrefabTextItem_1024721374_Text", Array.Empty<object>());
					return false;
				}
			}
		}
		if (state == EToggleState.ETT_Checked)
		{
			RoleDataBase roleDataBase2 = data as RoleDataBase;
			if (roleDataBase2 != null)
			{
				return this.CurSelectRole != roleDataBase2;
			}
		}
		return true;
	}

	// Token: 0x06014061 RID: 82017 RVA: 0x005963A8 File Offset: 0x005945A8
	public void RefreshTeamItem([Nullable(new byte[]
	{
		2,
		1
	})] List<EditBattleRoleSlotData> dataList)
	{
		if (this.TeamRoleOne == null || this.TeamRoleTwo == null)
		{
			return;
		}
		if (dataList == null)
		{
			this.TeamRoleOne.SetActive(false);
			this.TeamRoleTwo.SetActive(false);
			return;
		}
		this.TeamRoleOne.SetActive(true);
		this.TeamRoleTwo.SetActive(true);
		this.TeamRoleOne.IsSet = false;
		this.TeamRoleTwo.IsSet = false;
		for (int i = 1; i <= 4; i++)
		{
			if (i <= dataList.Count)
			{
				EditBattleRoleSlotData editBattleRoleSlotData = dataList[i - 1];
				if (editBattleRoleSlotData != null && editBattleRoleSlotData.HasRole)
				{
					EditBattleRoleData getRoleData = editBattleRoleSlotData.GetRoleData;
					if (getRoleData == null || !getRoleData.IsSelf)
					{
						if (!this.TeamRoleOne.IsSet)
						{
							this.TeamRoleOne.SetRoleId(editBattleRoleSlotData.GetRoleData.ConfigId);
							this.TeamRoleOne.SetTeamNumber(editBattleRoleSlotData.GetRoleData.OnlineIndex.GetValueOrDefault());
							this.TeamRoleOne.RefreshItem();
						}
						else if (!this.TeamRoleTwo.IsSet)
						{
							this.TeamRoleTwo.SetRoleId(editBattleRoleSlotData.GetRoleData.ConfigId);
							this.TeamRoleTwo.SetTeamNumber(editBattleRoleSlotData.GetRoleData.OnlineIndex.GetValueOrDefault());
							this.TeamRoleTwo.RefreshItem();
						}
					}
				}
			}
		}
		this.TeamRoleOne.SetActive(this.TeamRoleOne.IsSet);
		this.TeamRoleTwo.SetActive(this.TeamRoleTwo.IsSet);
	}

	// Token: 0x06014062 RID: 82018 RVA: 0x00596528 File Offset: 0x00594728
	private void RefreshConfirmText(int roleId)
	{
		TeamRoleSelectViewData data = this.Data;
		string text;
		if (data == null)
		{
			text = null;
		}
		else
		{
			Func<int, string> getConfirmButtonTextCallBack = data.GetConfirmButtonTextCallBack;
			text = ((getConfirmButtonTextCallBack != null) ? getConfirmButtonTextCallBack(roleId) : null);
		}
		string text2 = text;
		if (text2 != null && !string.IsNullOrEmpty(text2))
		{
			string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById(text2);
			if (textContentIdById != null)
			{
				base.GetText(2).ShowTextNew(textContentIdById);
			}
		}
	}

	// Token: 0x06014063 RID: 82019 RVA: 0x0059657C File Offset: 0x0059477C
	private void RefreshConfirmButtonVisible()
	{
		TeamRoleSelectViewData data = this.Data;
		if (data != null && data.ForFunction == ETeamRoleUseFunction.HonamiStory)
		{
			bool flag = HonamiStoryUtil.CheckInHonamiStoryDungeon();
			bool flag2 = ModelBase<FunctionModel>.Instance.IsOpen(10111);
			base.GetButton(3).RootUIComp.Get().SetUIActive(!flag && flag2);
			return;
		}
		base.GetButton(3).RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x06014064 RID: 82020 RVA: 0x005965F0 File Offset: 0x005947F0
	private void RefreshDetailButtonVisible()
	{
		bool flag = false;
		TeamRoleSelectViewData data = this.Data;
		if (data != null && data.ForFunction == ETeamRoleUseFunction.HonamiStory)
		{
			flag = true;
		}
		if (flag)
		{
			base.GetButton(9).RootUIComp.Get().SetUIActive(false);
			return;
		}
		RoleDataBase curSelectRole = this.CurSelectRole;
		int? num = (curSelectRole != null) ? new int?(curSelectRole.GetDataId()) : null;
		TeamRoleSelectViewData data2 = this.Data;
		Func<int, bool> func = (data2 != null) ? data2.GetDetailButtonVisible : null;
		if (func != null)
		{
			base.GetButton(9).RootUIComp.Get().SetUIActive(func(num.Value));
			return;
		}
		base.GetButton(9).RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x06014065 RID: 82021 RVA: 0x005966B4 File Offset: 0x005948B4
	private void RefreshLockPanel()
	{
		if (this.CurSelectRole == null || this.PanelLock == null)
		{
			return;
		}
		TeamRoleSelectViewData data = this.Data;
		bool? flag;
		if (data == null)
		{
			flag = null;
		}
		else
		{
			Func<int, bool> showLockPanel = data.ShowLockPanel;
			flag = ((showLockPanel != null) ? new bool?(showLockPanel(this.CurSelectRole.GetDataId())) : null);
		}
		bool? flag2 = flag;
		bool valueOrDefault = flag2.GetValueOrDefault();
		this.PanelLock.SetActive(valueOrDefault);
		if (valueOrDefault)
		{
			TeamRoleSelectViewData data2 = this.Data;
			string text;
			if (data2 == null)
			{
				text = null;
			}
			else
			{
				Func<int, string> getLockTextCallBack = data2.GetLockTextCallBack;
				text = ((getLockTextCallBack != null) ? getLockTextCallBack(this.CurSelectRole.GetDataId()) : null);
			}
			string textId = text ?? "";
			this.PanelLock.SetTextByTextId(textId, Array.Empty<string>());
		}
	}

	// Token: 0x06014066 RID: 82022 RVA: 0x0059676C File Offset: 0x0059496C
	private void RefreshSkillBranch()
	{
		if (this.CurSelectRole == null)
		{
			return;
		}
		int dataId = this.CurSelectRole.GetDataId();
		if (!ModelBase<RoleModel>.Instance.IsRoleHasBranch(dataId))
		{
			TeamRoleSelectSkillBranchItem skillBranchSwitchItem = this.SkillBranchSwitchItem;
			if (skillBranchSwitchItem != null)
			{
				skillBranchSwitchItem.SetUiActive(false);
			}
			base.GetItem(31).SetUIActive(false);
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.EditBattleTeamView) || Singleton<UiManager>.Instance.IsViewHide(EUiViewName.EditBattleTeamView))
		{
			InstanceDungeon? instanceDungeon;
			int? num = (ModelBase<EditBattleTeamModel>.Instance.GetCurrentDungeonConfig != null) ? new int?(instanceDungeon.GetValueOrDefault().InstSubType) : null;
			if (num != null && ModelBase<RoleModel>.Instance.IsInHideSkillBranchInstSubTypeList(num.Value))
			{
				TeamRoleSelectSkillBranchItem skillBranchSwitchItem2 = this.SkillBranchSwitchItem;
				if (skillBranchSwitchItem2 != null)
				{
					skillBranchSwitchItem2.SetUiActive(false);
				}
				base.GetItem(31).SetUIActive(false);
				return;
			}
		}
		TeamRoleSelectSkillBranchItem skillBranchSwitchItem3 = this.SkillBranchSwitchItem;
		if (skillBranchSwitchItem3 != null)
		{
			skillBranchSwitchItem3.SetUiActive(true);
		}
		base.GetItem(31).SetUIActive(true);
		TeamRoleSelectSkillBranchItem skillBranchSwitchItem4 = this.SkillBranchSwitchItem;
		if (skillBranchSwitchItem4 != null)
		{
			skillBranchSwitchItem4.SetActiveBranchIndex(ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInCurrentGamePlay(dataId));
		}
		TeamRoleSelectSkillBranchItem skillBranchSwitchItem5 = this.SkillBranchSwitchItem;
		if (skillBranchSwitchItem5 == null)
		{
			return;
		}
		skillBranchSwitchItem5.RefreshIcon(delegate(int index)
		{
			int dataId2 = this.CurSelectRole.GetDataId();
			int roleBranchIdByIndex = ModelBase<RoleModel>.Instance.GetRoleBranchIdByIndex(dataId2, index);
			SkillBranch? skillBranchConfigById = ConfigBase<RoleConfig>.Instance.GetSkillBranchConfigById(roleBranchIdByIndex);
			if (skillBranchConfigById != null)
			{
				return skillBranchConfigById.Value.Icon;
			}
			return string.Empty;
		});
	}

	// Token: 0x06014067 RID: 82023 RVA: 0x005968B0 File Offset: 0x00594AB0
	private void SwitchSkillBranchHandler(int skillBranch)
	{
		int roleBranchIdByIndex = ModelBase<RoleModel>.Instance.GetRoleBranchIdByIndex(this.CurSelectRole.GetDataId(), skillBranch);
		if (ModelBase<RoleModel>.Instance.IsInGamePlayRoleEdit)
		{
			ControllerBase<RoleController>.Instance.ModifyRoleSkillBranchInCurrentGamePlay(this.CurSelectRole.GetDataId(), roleBranchIdByIndex, true);
			return;
		}
		ControllerBase<RoleController>.Instance.RequestRoleSkillBranchModify(this.CurSelectRole.GetDataId(), roleBranchIdByIndex);
	}

	// Token: 0x06014068 RID: 82024 RVA: 0x00596910 File Offset: 0x00594B10
	private void OnRoleSkillBranchChanged(int roleId)
	{
		int num = this.RoleList.FindIndex((RoleDataBase role) => role.GetDataId() == roleId);
		if (num < 0)
		{
			return;
		}
		this.RoleScrollView.RefreshGridProxy(num);
	}

	// Token: 0x06014069 RID: 82025 RVA: 0x00596954 File Offset: 0x00594B54
	private void RefreshConfirmButtonEnable(int roleId)
	{
		TeamRoleSelectViewData data = this.Data;
		if (((data != null) ? data.GetConfirmButtonEnableCallBack : null) == null)
		{
			return;
		}
		bool interactable = this.Data.GetConfirmButtonEnableCallBack(roleId);
		UUIInteractionGroup interactionGroup = base.GetInteractionGroup(0);
		if (interactionGroup == null)
		{
			return;
		}
		interactionGroup.SetInteractable(interactable);
	}

	// Token: 0x0601406A RID: 82026 RVA: 0x0059699C File Offset: 0x00594B9C
	private void RefreshRoleInfo(int roleId)
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (((levelSequencePlayer != null) ? levelSequencePlayer.GetCurrentSequence() : null) == "Switch")
		{
			this.LevelSequencePlayer.ReplaySequenceByKey("Switch");
		}
		else
		{
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlayLevelSequenceByName("Switch", false, null, false);
			}
		}
		RoleSkinData roleSkinDataByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataByRoleId(roleId);
		if (roleSkinDataByRoleId != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), roleSkinDataByRoleId.GetName(), Array.Empty<object>());
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		if (roleConfig == null)
		{
			return;
		}
		TeamRoleSelectViewData data = this.Data;
		if (data != null && data.ForFunction == ETeamRoleUseFunction.HonamiStory && this.HonamiStoryPanel != null)
		{
			this.HonamiStoryPanel.SetData(roleConfig.Value.Id);
		}
		if (this.CurSelectRole != null && this.CurSelectRole.IsTrialRole())
		{
			RoleRobotData roleRobotData = this.CurSelectRole as RoleRobotData;
			if (roleRobotData != null)
			{
				int? num = new int?(roleRobotData.GetTrialRoleId());
				if (num != null)
				{
					this.RefreshTrialRoleExtension(num.Value);
				}
			}
		}
		else
		{
			RoleTrialLabelItem trialLabelItem = this.TrialLabelItem;
			if (trialLabelItem != null)
			{
				trialLabelItem.SetUiActive(false);
			}
		}
		IReadOnlyList<Aki.Config.Skill> skillList = ConfigBase<RoleSkillConfig>.Instance.GetSkillList(roleConfig.Value.SkillId);
		if (skillList == null || skillList.Count == 0)
		{
			return;
		}
		IReadOnlyList<Aki.Config.Skill> readOnlyList = null;
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		if (roleDataById != null)
		{
			RoleSkillData skillData = roleDataById.GetSkillData();
			if (skillData != null && skillData.HasAnySkillUpgrade())
			{
				readOnlyList = new List<Aki.Config.Skill>(skillList);
				for (int i = 0; i < readOnlyList.Count; i++)
				{
					int id = readOnlyList[i].Id;
					int skillIdAfterUpgrade = skillData.GetSkillIdAfterUpgrade(id);
					if (skillIdAfterUpgrade > 0)
					{
						Aki.Config.Skill? skillConfigById = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillIdAfterUpgrade);
						if (skillConfigById != null)
						{
							((List<Aki.Config.Skill>)readOnlyList)[i] = skillConfigById.Value;
						}
					}
				}
			}
		}
		if (readOnlyList == null)
		{
			readOnlyList = skillList;
		}
		List<TeamRoleSkillData> skillDataList = new List<TeamRoleSkillData>();
		TeamRoleSelectViewData data2 = this.Data;
		if (((data2 != null) ? data2.GetCustomSkillShowData : null) != null && this.CurSelectRole != null)
		{
			skillDataList.AddRange(this.Data.GetCustomSkillShowData(this.CurSelectRole.GetRoleId()));
		}
		else
		{
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("DisplaySkillTypes");
			if (intArrayConfig != null)
			{
				foreach (int num2 in intArrayConfig)
				{
					foreach (Aki.Config.Skill skill in readOnlyList)
					{
						if (skill.SkillType == num2)
						{
							TeamRoleSkillData teamRoleSkillData = new TeamRoleSkillData();
							teamRoleSkillData.SkillIcon = skill.Icon;
							teamRoleSkillData.SkillType = num2;
							teamRoleSkillData.SkillName = skill.SkillName;
							int[] array = skill.SkillTagList();
							if (array != null)
							{
								teamRoleSkillData.SkillTagList = array.ToArray<int>();
							}
							teamRoleSkillData.SkillDesc = skill.SkillDescribe;
							string[] array2 = skill.SkillDetailNum();
							if (array2 != null)
							{
								teamRoleSkillData.SkillDescNum = array2.ToArray<string>();
							}
							teamRoleSkillData.MultiSkillDesc = skill.MultiSkillDescribe;
							string[] array3 = skill.MultiSkillDetailNum();
							if (array3 != null)
							{
								teamRoleSkillData.MultiSkillDescNum = array3.ToArray<string>();
							}
							teamRoleSkillData.SkillResume = skill.SkillResume;
							string[] array4 = skill.SkillResumeNum();
							if (array4 != null)
							{
								teamRoleSkillData.SkillResumeNum = array4.ToArray<string>();
							}
							skillDataList.Add(teamRoleSkillData);
							break;
						}
					}
				}
			}
		}
		if (skillDataList.Count <= 0 || this.SkillLayout == null)
		{
			return;
		}
		this.SkillDataList = skillDataList;
		this.SkillLayout.DeselectCurrentGridProxy();
		this.SkillLayout.RefreshByData(skillDataList, delegate
		{
			this.SkillLayout.SelectGridProxy(0, false);
			this.OnSkillItemStateChanged(EToggleState.ETT_Checked, skillDataList[0]);
		}, false);
		int[] roleTagByRoleInfo = ModelBase<RoleModel>.Instance.GetRoleTagByRoleInfo(roleConfig.Value);
		bool flag = roleTagByRoleInfo != null && roleTagByRoleInfo.Length != 0;
		base.GetMultiTemplateLayout(16).RootUIComp.Get().SetUIActive(flag);
		if (flag && roleTagByRoleInfo != null)
		{
			GenericLayout<RoleTagMediumIconItem, int> roleTagLayout = this.RoleTagLayout;
			if (roleTagLayout != null)
			{
				roleTagLayout.RefreshByData(roleTagByRoleInfo.ToList<int>(), null, false);
			}
		}
		this.RefreshConfirmButtonVisible();
		this.RefreshDetailButtonVisible();
		this.RefreshLockPanel();
		this.RefreshSkillBranch();
	}

	// Token: 0x0601406B RID: 82027 RVA: 0x00596E4C File Offset: 0x0059504C
	private TeamRoleSkillItem InitSkillItem()
	{
		TeamRoleSkillItem teamRoleSkillItem = new TeamRoleSkillItem();
		teamRoleSkillItem.BindOnSkillStateChange(new Action<EToggleState, TeamRoleSkillData>(this.OnSkillItemStateChanged));
		return teamRoleSkillItem;
	}

	// Token: 0x0601406C RID: 82028 RVA: 0x00596E68 File Offset: 0x00595068
	private void OnSkillItemStateChanged(EToggleState state, TeamRoleSkillData data)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		if (this.SkillDataList == null || this.SkillLayout == null)
		{
			return;
		}
		int gridIndex = this.SkillDataList.IndexOf(data);
		this.SkillLayout.SelectGridProxy(gridIndex, false);
		this.RefreshSkillInfo(data);
	}

	// Token: 0x0601406D RID: 82029 RVA: 0x00596EAC File Offset: 0x005950AC
	private void RefreshSkillInfo(TeamRoleSkillData data)
	{
		if (this.Data == null)
		{
			return;
		}
		string[] array = new string[0];
		string text;
		if (this.SkillDescType == ERoleSkillDescType.MultiDesc)
		{
			if (ModelBase<RoleModel>.Instance.IsShowMultiSkillDesc && !StringUtils.IsEmpty(data.MultiSkillDesc))
			{
				text = data.MultiSkillDesc;
				array = (data.MultiSkillDescNum ?? new string[0]);
			}
			else
			{
				text = data.SkillDesc;
				array = (data.SkillDescNum ?? new string[0]);
			}
		}
		else if (ModelBase<RoleModel>.Instance.IsShowSkillResume && !StringUtils.IsEmpty(data.SkillResume))
		{
			text = data.SkillResume;
			array = (data.SkillResumeNum ?? new string[0]);
		}
		else
		{
			text = data.SkillDesc;
			array = (data.SkillDescNum ?? new string[0]);
		}
		string text2 = "";
		if (StringUtils.IsEmpty(data.SkillTypeText))
		{
			string skillTypeNameLocalText = ConfigBase<RoleSkillConfig>.Instance.GetSkillTypeNameLocalText(data.SkillType);
			if (skillTypeNameLocalText != null && !string.IsNullOrEmpty(skillTypeNameLocalText))
			{
				text2 = skillTypeNameLocalText;
			}
		}
		else
		{
			text2 = data.SkillTypeText;
		}
		if (this.Data.ForFunction == ETeamRoleUseFunction.HonamiStory && this.HonamiStoryPanel != null)
		{
			this.HonamiStoryPanel.RefreshSkillInfo(data.SkillName, text, text2, array);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), data.SkillName, Array.Empty<object>());
		if (array.Length != 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(18), text, array);
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(18), text, Array.Empty<object>());
		}
		base.GetText(12).SetText(text2, true);
	}

	// Token: 0x0601406E RID: 82030 RVA: 0x00597038 File Offset: 0x00595238
	private void CheckCurRoleIsDead()
	{
		UUIText text = base.GetText(6);
		if (ModelBase<TowerModel>.Instance.IsOpenFloorFormation() || ControllerBase<LordGymController>.Instance.IsInLordGymDungeon())
		{
			text.SetUIActive(false);
			return;
		}
		if (this.CurSelectRole == null || this.RoleList == null || this.RoleScrollView == null)
		{
			return;
		}
		int dataId = this.CurSelectRole.GetDataId();
		int gridIndex = this.RoleList.IndexOf(this.CurSelectRole);
		this.RoleScrollView.RefreshGridProxy(gridIndex);
		TeamRoleSelectViewData data = this.Data;
		bool flag;
		if (data == null)
		{
			flag = false;
		}
		else
		{
			Func<int, bool> isNeedRevive = data.IsNeedRevive;
			flag = ((isNeedRevive != null) ? new bool?(isNeedRevive(dataId)) : null).GetValueOrDefault();
		}
		if (flag)
		{
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(text, "EditBattleTeamNeedRevive", Array.Empty<object>());
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x0601406F RID: 82031 RVA: 0x0059710A File Offset: 0x0059530A
	private void OnRoleRefreshAttribute(IReadOnlyDictionary<int, int> baseAttr, IReadOnlyDictionary<int, int> addAttr)
	{
		this.OnRoleRefresh();
	}

	// Token: 0x06014070 RID: 82032 RVA: 0x00597112 File Offset: 0x00595312
	private void OnRevive(Entity _)
	{
		this.OnRoleRefresh();
	}

	// Token: 0x06014071 RID: 82033 RVA: 0x0059711A File Offset: 0x0059531A
	private void OnRoleRefresh()
	{
		if (this.CurSelectRole != null)
		{
			this.CheckCurRoleIsDead();
			this.RefreshConfirmText(this.CurSelectRole.GetDataId());
		}
	}

	// Token: 0x06014072 RID: 82034 RVA: 0x0059713B File Offset: 0x0059533B
	private void OnRoleChangeEnd()
	{
		this.IsNeedRefreshTeamList = true;
	}

	// Token: 0x06014073 RID: 82035 RVA: 0x00597144 File Offset: 0x00595344
	private void RefreshRoleListAfterChangeRole()
	{
		if (this.Data == null || this.RoleList == null)
		{
			return;
		}
		RoleSelectModel instance = ModelBase<RoleSelectModel>.Instance;
		bool flag = false;
		using (List<RoleDataBase>.Enumerator enumerator = this.RoleList.ToList<RoleDataBase>().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				RoleDataBase roleData = enumerator.Current;
				bool flag2 = this.CurSelectRole == roleData;
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleData.GetDataId(), true);
				if (roleDataById != null && roleDataById != roleData)
				{
					flag = true;
					List<RoleDataBase> roleList = this.Data.RoleList;
					int num = (roleList != null) ? roleList.FindIndex((RoleDataBase data) => data == roleData) : -1;
					if (num > -1 && this.Data.RoleList != null)
					{
						this.Data.RoleList[num] = roleDataById;
					}
					int roleIndex = instance.GetRoleIndex(roleData.GetDataId());
					if (roleIndex > 0)
					{
						instance.RoleIndexMap[roleIndex] = roleDataById;
					}
					if (flag2)
					{
						this.CurSelectRole = roleDataById;
					}
				}
			}
		}
		if (flag && this.Data.RoleList != null)
		{
			this.RoleList = this.Data.RoleList;
			this.RoleList.Sort((RoleDataBase a, RoleDataBase b) => b.GetRoleConfig().Priority - a.GetRoleConfig().Priority);
			if (this.Data.UseWay != null)
			{
				FilterSortEntrance<RoleDataBase> filterSortEntrance = this.FilterSortEntrance;
				if (filterSortEntrance == null)
				{
					return;
				}
				filterSortEntrance.UpdateData(this.Data.UseWay.Value, this.RoleList, Array.Empty<object>());
			}
		}
	}

	// Token: 0x06014074 RID: 82036 RVA: 0x00597308 File Offset: 0x00595508
	private void OnRefreshEditBattleRoleSlotData(ERefreshEditBattleRoleSlotDataReason reason)
	{
		TeamRoleSelectViewData data = this.Data;
		if (((data != null) ? data.EditBattleRoleSlotDataList : null) == null)
		{
			return;
		}
		EditBattleRoleSlotData roleSlotData = ModelBase<EditBattleTeamModel>.Instance.GetRoleSlotData(this.Data.Position.GetValueOrDefault());
		if (roleSlotData != null)
		{
			EditBattleRoleData getRoleData = roleSlotData.GetRoleData;
			int? num = (getRoleData != null) ? new int?(getRoleData.PlayerId) : null;
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			if (num.GetValueOrDefault() == id.GetValueOrDefault() & num != null == (id != null))
			{
				EditBattleRoleSlotData[] getAllRoleSlotData = ModelBase<EditBattleTeamModel>.Instance.GetAllRoleSlotData;
				if (getAllRoleSlotData != null)
				{
					this.Data.SetOtherTeamSlotData(getAllRoleSlotData.ToList<EditBattleRoleSlotData>());
				}
				TeamRoleSelectViewData data2 = this.Data;
				this.RefreshTeamItem((data2 != null) ? data2.EditBattleRoleSlotDataList : null);
				return;
			}
		}
		TeamRoleSelectViewData data3 = this.Data;
		if (data3 != null)
		{
			Action backCallBack = data3.BackCallBack;
			if (backCallBack != null)
			{
				backCallBack();
			}
		}
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
	}

	// Token: 0x06014075 RID: 82037 RVA: 0x00597404 File Offset: 0x00595604
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
		string a = configParams[0];
		if (!(a == "Dream"))
		{
			if (a == "Trial")
			{
				if (configParams.Length < 2)
				{
					return null;
				}
				int num;
				if (!int.TryParse(configParams[1], out num))
				{
					return null;
				}
				int? num2 = null;
				if (this.RoleList != null)
				{
					for (int i = 0; i < this.RoleList.Count; i++)
					{
						RoleDataBase roleDataBase = this.RoleList[i];
						if (roleDataBase.IsTrialRole())
						{
							TrialRoleInfo? trialRoleConfig = ConfigBase<TrialRoleConfig>.Instance.GetTrialRoleConfig(roleDataBase.GetRoleId());
							if (trialRoleConfig != null && trialRoleConfig.GetValueOrDefault().GroupId == num)
							{
								num2 = new int?(i);
								break;
							}
						}
					}
				}
				if (num2 != null && num2.Value >= 0)
				{
					LoopScrollView<TeamRoleGridBase, RoleDataBase> roleScrollView = this.RoleScrollView;
					UUIItem uuiitem = (roleScrollView != null) ? roleScrollView.GetGrid(num2.Value) : null;
					if (uuiitem == null)
					{
						return null;
					}
					return new UUIItem[]
					{
						uuiitem,
						uuiitem
					};
				}
			}
			int num3;
			if (configParams.Length != 0 && int.TryParse(configParams[0], out num3) && num3 != 0)
			{
				UUIItem scrollItemByRoleId = this.GetScrollItemByRoleId(num3);
				if (scrollItemByRoleId != null)
				{
					return new UUIItem[]
					{
						scrollItemByRoleId,
						scrollItemByRoleId
					};
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.JT;
			string message = "聚焦引导extraParam项配置有误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		if (this.SkillLayout == null || this.SkillDataList == null)
		{
			return null;
		}
		UUIItem itemByIndex = this.SkillLayout.GetItemByIndex(this.SkillDataList.Count - 1);
		if (itemByIndex == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			itemByIndex,
			itemByIndex
		};
	}

	// Token: 0x06014076 RID: 82038 RVA: 0x005975B0 File Offset: 0x005957B0
	[NullableContext(2)]
	private UUIItem GetScrollItemByRoleId(int roleId)
	{
		int index = 0;
		UUIItem result = null;
		if (this.RoleList != null)
		{
			foreach (RoleDataBase roleDataBase in this.RoleList)
			{
				if (roleDataBase.GetRoleId() == roleId)
				{
					index = this.RoleList.IndexOf(roleDataBase);
					LoopScrollView<TeamRoleGridBase, RoleDataBase> roleScrollView = this.RoleScrollView;
					result = ((roleScrollView != null) ? roleScrollView.GetGrid(index) : null);
					break;
				}
			}
		}
		TimerSystem.GameplayTimeInstance.Next(delegate(float _)
		{
			LoopScrollView<TeamRoleGridBase, RoleDataBase> roleScrollView2 = this.RoleScrollView;
			if (roleScrollView2 == null)
			{
				return;
			}
			roleScrollView2.ScrollToGridIndex(index, false);
		}, null, null);
		return result;
	}

	// Token: 0x06014077 RID: 82039 RVA: 0x0059766C File Offset: 0x0059586C
	private UniTask InitTrialRoleExtension()
	{
		TeamRoleSelectView.<InitTrialRoleExtension>d__57 <InitTrialRoleExtension>d__;
		<InitTrialRoleExtension>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTrialRoleExtension>d__.<>4__this = this;
		<InitTrialRoleExtension>d__.<>1__state = -1;
		<InitTrialRoleExtension>d__.<>t__builder.Start<TeamRoleSelectView.<InitTrialRoleExtension>d__57>(ref <InitTrialRoleExtension>d__);
		return <InitTrialRoleExtension>d__.<>t__builder.Task;
	}

	// Token: 0x06014078 RID: 82040 RVA: 0x005976B0 File Offset: 0x005958B0
	private void RefreshTrialRoleExtension(int roleId)
	{
		if (!RoleUtils.IsTrialRole(roleId))
		{
			RoleTrialLabelItem trialLabelItem = this.TrialLabelItem;
			if (trialLabelItem == null)
			{
				return;
			}
			trialLabelItem.SetUiActive(false);
			return;
		}
		else if (RoleUtils.GetTrialRoleType(roleId) == ETrialRoleType.None)
		{
			RoleTrialLabelItem trialLabelItem2 = this.TrialLabelItem;
			if (trialLabelItem2 == null)
			{
				return;
			}
			trialLabelItem2.SetUiActive(false);
			return;
		}
		else
		{
			RoleTrialLabelItem trialLabelItem3 = this.TrialLabelItem;
			if (trialLabelItem3 != null)
			{
				trialLabelItem3.SetUiActive(true);
			}
			RoleTrialLabelItem trialLabelItem4 = this.TrialLabelItem;
			if (trialLabelItem4 == null)
			{
				return;
			}
			trialLabelItem4.Refresh(roleId);
			return;
		}
	}

	// Token: 0x06014079 RID: 82041 RVA: 0x00597714 File Offset: 0x00595914
	private void ConfirmClick()
	{
		RoleDataBase curSelectRole = this.CurSelectRole;
		int? num = (curSelectRole != null) ? new int?(curSelectRole.GetDataId()) : null;
		if (num == null)
		{
			return;
		}
		TeamRoleSelectViewData data = this.Data;
		Func<int, bool> func = (data != null) ? data.CanConfirmFunc : null;
		if (func != null && !func(num.Value))
		{
			return;
		}
		TeamRoleSelectViewData data2 = this.Data;
		if (data2 != null)
		{
			Action<int> confirmCallBack = data2.ConfirmCallBack;
			if (confirmCallBack != null)
			{
				confirmCallBack(num.Value);
			}
		}
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
	}

	// Token: 0x0601407A RID: 82042 RVA: 0x005977AA File Offset: 0x005959AA
	private void BackClick()
	{
		TeamRoleSelectViewData data = this.Data;
		if (data != null)
		{
			Action backCallBack = data.BackCallBack;
			if (backCallBack != null)
			{
				backCallBack();
			}
		}
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
	}

	// Token: 0x0601407B RID: 82043 RVA: 0x005977E0 File Offset: 0x005959E0
	private unsafe void OnDetailClick()
	{
		if (this.CurSelectRole == null)
		{
			return;
		}
		TeamRoleSelectViewData data = this.Data;
		if (((data != null) ? data.DetailCallback : null) != null)
		{
			this.Data.DetailCallback(this.CurSelectRole.GetDataId());
			return;
		}
		int dataId = this.CurSelectRole.GetDataId();
		List<int> list;
		if (dataId < 100000)
		{
			list = new List<int>();
		}
		else
		{
			int num = 1;
			List<int> list2 = new List<int>(num);
			CollectionsMarshal.SetCount<int>(list2, num);
			list = list2;
			Span<int> span = CollectionsMarshal.AsSpan<int>(list2);
			int index = 0;
			*span[index] = dataId;
		}
		List<int> roleIdList = list;
		ModelBase<RoleModel>.Instance.StartRecordRoleSkillBranchChangeRequest();
		ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, dataId, roleIdList, null, null);
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0601407C RID: 82044 RVA: 0x005978C0 File Offset: 0x00595AC0
	private void OnCloseView(EUiViewName viewName, int i)
	{
		if (viewName == EUiViewName.RoleRootView)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			List<int> list = ModelBase<RoleModel>.Instance.StopRecordRoleSkillBranchChangeRequest();
			if (list.Count > 0)
			{
				this.RefreshSkillBranch();
				foreach (int roleId in list)
				{
					this.OnRoleSkillBranchChanged(roleId);
				}
			}
		}
	}

	// Token: 0x0601407D RID: 82045 RVA: 0x00597970 File Offset: 0x00595B70
	private void OnSkillModeToggleClick(EToggleState toggleState)
	{
		if (this.SkillDescType == ERoleSkillDescType.MultiDesc)
		{
			ModelBase<RoleModel>.Instance.IsShowMultiSkillDesc = (toggleState == EToggleState.ETT_Checked);
		}
		else
		{
			ModelBase<RoleModel>.Instance.IsShowSkillResume = (toggleState == EToggleState.ETT_Checked);
		}
		if (this.SkillLayout == null || this.SkillDataList == null)
		{
			return;
		}
		int selectedGridIndex = this.SkillLayout.GetSelectedGridIndex();
		if (selectedGridIndex < 0 || selectedGridIndex >= this.SkillDataList.Count)
		{
			return;
		}
		this.RefreshSkillInfo(this.SkillDataList[selectedGridIndex]);
	}

	// Token: 0x04009C05 RID: 39941
	[Nullable(2)]
	private TeamRoleSelectViewData Data;

	// Token: 0x04009C06 RID: 39942
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<RoleDataBase> FilterSortEntrance;

	// Token: 0x04009C07 RID: 39943
	[Nullable(2)]
	protected RoleDataBase CurSelectRole;

	// Token: 0x04009C08 RID: 39944
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<TeamRoleGridBase, RoleDataBase> RoleScrollView;

	// Token: 0x04009C09 RID: 39945
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<RoleDataBase> RoleList;

	// Token: 0x04009C0A RID: 39946
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<TeamRoleSkillItem, TeamRoleSkillData> SkillLayout;

	// Token: 0x04009C0B RID: 39947
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<TeamRoleSkillData> SkillDataList;

	// Token: 0x04009C0C RID: 39948
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<RoleTagMediumIconItem, int> RoleTagLayout;

	// Token: 0x04009C0D RID: 39949
	[Nullable(2)]
	private TeamPlayerSelectionComponent TeamRoleOne;

	// Token: 0x04009C0E RID: 39950
	[Nullable(2)]
	private TeamPlayerSelectionComponent TeamRoleTwo;

	// Token: 0x04009C0F RID: 39951
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04009C10 RID: 39952
	private ERoleSkillDescType SkillDescType;

	// Token: 0x04009C11 RID: 39953
	public bool IsNeedRefreshTeamList;

	// Token: 0x04009C12 RID: 39954
	[Nullable(2)]
	private HonamiStoryRoleInfoPanel HonamiStoryPanel;

	// Token: 0x04009C13 RID: 39955
	[Nullable(2)]
	private FunctionalPanelConditionLock PanelLock;

	// Token: 0x04009C14 RID: 39956
	[Nullable(2)]
	private RoleTrialLabelItem TrialLabelItem;

	// Token: 0x04009C15 RID: 39957
	[Nullable(2)]
	private TeamRoleSelectSkillBranchItem SkillBranchSwitchItem;

	// Token: 0x02008B52 RID: 35666
	[NullableContext(0)]
	private enum EComponentType
	{
		// Token: 0x0402EF71 RID: 192369
		ConfirmButtonInteractionGroup,
		// Token: 0x0402EF72 RID: 192370
		RoleScroll,
		// Token: 0x0402EF73 RID: 192371
		ConfirmText,
		// Token: 0x0402EF74 RID: 192372
		ConfirmButton,
		// Token: 0x0402EF75 RID: 192373
		CloseButton,
		// Token: 0x0402EF76 RID: 192374
		FilterSortEntrance,
		// Token: 0x0402EF77 RID: 192375
		TipsText,
		// Token: 0x0402EF78 RID: 192376
		RoleItem,
		// Token: 0x0402EF79 RID: 192377
		NoneRoleTips,
		// Token: 0x0402EF7A RID: 192378
		DetailButton,
		// Token: 0x0402EF7B RID: 192379
		RoleInfoContent,
		// Token: 0x0402EF7C RID: 192380
		RoleNameText,
		// Token: 0x0402EF7D RID: 192381
		SkillTypeNameText,
		// Token: 0x0402EF7E RID: 192382
		SkillContent,
		// Token: 0x0402EF7F RID: 192383
		SkillItem,
		// Token: 0x0402EF80 RID: 192384
		SkillNameText,
		// Token: 0x0402EF81 RID: 192385
		RoleTagContent,
		// Token: 0x0402EF82 RID: 192386
		SkillTagItem,
		// Token: 0x0402EF83 RID: 192387
		SkillInfoText,
		// Token: 0x0402EF84 RID: 192388
		TeamGroup,
		// Token: 0x0402EF85 RID: 192389
		TeamRoleOne,
		// Token: 0x0402EF86 RID: 192390
		TeamRoleTwo,
		// Token: 0x0402EF87 RID: 192391
		SkillModeToggle,
		// Token: 0x0402EF88 RID: 192392
		SkillModeItem,
		// Token: 0x0402EF89 RID: 192393
		TopItem,
		// Token: 0x0402EF8A RID: 192394
		SkillModeText,
		// Token: 0x0402EF8B RID: 192395
		HonamiStoryEffectNode,
		// Token: 0x0402EF8C RID: 192396
		NormalPanelNode,
		// Token: 0x0402EF8D RID: 192397
		HonamiStoryPanelNode,
		// Token: 0x0402EF8E RID: 192398
		LockPanel,
		// Token: 0x0402EF8F RID: 192399
		TrialRoleItem,
		// Token: 0x0402EF90 RID: 192400
		SkillBranchRootItem,
		// Token: 0x0402EF91 RID: 192401
		SkillBranchSwitchItem
	}
}
