using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002796 RID: 10134
[NullableContext(1)]
[Nullable(0)]
public class MultiTeamRoleSelectView : UiViewBase
{
	// Token: 0x06013FEF RID: 81903 RVA: 0x005924BB File Offset: 0x005906BB
	public MultiTeamRoleSelectView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06013FF0 RID: 81904 RVA: 0x005924E8 File Offset: 0x005906E8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIMultiTemplateLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(15, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(19, typeof(UUIText)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(25, typeof(UUIText)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUIItem)),
			new ValueTuple<int, Type>(28, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(14, new Action(this.ConfirmClick)),
			new ValueTuple<int, Delegate>(15, new Action(this.OnDetailClick)),
			new ValueTuple<int, Delegate>(18, new Action<EToggleState>(this.OnSkillModeToggleClick)),
			new ValueTuple<int, Delegate>(24, new Action(this.OnClickUnRecommendRoleBtn))
		};
	}

	// Token: 0x06013FF1 RID: 81905 RVA: 0x005927EC File Offset: 0x005909EC
	protected override UniTask OnBeforeStartAsync()
	{
		MultiTeamRoleSelectView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MultiTeamRoleSelectView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013FF2 RID: 81906 RVA: 0x00592830 File Offset: 0x00590A30
	protected override void OnStart()
	{
		this.DisplaySkillTypes = ConfigCommonParamById.GetIntArrayConfig("DisplaySkillTypes");
		MultiTeamRoleSelectData data = this.Data;
		if (((data != null) ? data.Tips : null) != null && !string.IsNullOrEmpty(this.Data.Tips))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(25), this.Data.Tips, Array.Empty<object>());
		}
	}

	// Token: 0x06013FF3 RID: 81907 RVA: 0x00592895 File Offset: 0x00590A95
	private MultiTeamRoleGrid InitRoleGrid()
	{
		return new MultiTeamRoleGrid();
	}

	// Token: 0x06013FF4 RID: 81908 RVA: 0x0059289C File Offset: 0x00590A9C
	private TeamRoleSkillItem InitSkillItem()
	{
		TeamRoleSkillItem teamRoleSkillItem = new TeamRoleSkillItem();
		teamRoleSkillItem.BindOnSkillStateChange(new Action<EToggleState, TeamRoleSkillData>(this.OnSkillItemStateChanged));
		return teamRoleSkillItem;
	}

	// Token: 0x06013FF5 RID: 81909 RVA: 0x005928B8 File Offset: 0x00590AB8
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

	// Token: 0x06013FF6 RID: 81910 RVA: 0x00592930 File Offset: 0x00590B30
	private void OnClickUnRecommendRoleBtn()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BabelTowerTeamTipsConfirm);
		confirmBoxDataNew.FunctionMap.Add(0, delegate
		{
			ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
	}

	// Token: 0x06013FF7 RID: 81911 RVA: 0x00592980 File Offset: 0x00590B80
	private void RefreshSkillModeToggle()
	{
		this.SkillDescType = ModelBase<RoleModel>.Instance.GetRoleSkillDescType();
		UUIExtendToggle extendToggle = base.GetExtendToggle(18);
		if (extendToggle == null)
		{
			return;
		}
		if (this.SkillDescType == ERoleSkillDescType.MultiDesc)
		{
			EToggleState state = ModelBase<RoleModel>.Instance.IsShowMultiSkillDesc ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			extendToggle.SetToggleState(state, false, false, false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(19), "MultiplayerSkillDescription_text", Array.Empty<object>());
			return;
		}
		EToggleState state2 = ModelBase<RoleModel>.Instance.IsShowSkillResume ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		extendToggle.SetToggleState(state2, false, false, false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(19), "SkillBriefDescription_text", Array.Empty<object>());
	}

	// Token: 0x06013FF8 RID: 81912 RVA: 0x00592A24 File Offset: 0x00590C24
	private void ConfirmClick()
	{
		MultiTeamRoleSelectData data = this.Data;
		Func<int[], bool> func = (data != null) ? data.CanConfirmFunc : null;
		if (func != null && !func(this.CurrentSelectRoleList.ToArray()))
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (int num in this.CurrentSelectRoleList.ToArray())
		{
			int? valueOrNull = this.CurrentSelectTagMap.GetValueOrNull(num);
			if (valueOrNull != null)
			{
				list.Add(valueOrNull.Value);
			}
			else if (ModelBase<RoleModel>.Instance.IsRoleHasBranch(num))
			{
				list.Add(ModelBase<RoleModel>.Instance.GetRoleSkillBranchIdInCurrentGamePlay(num));
			}
			else
			{
				list.Add(0);
			}
		}
		MultiTeamRoleSelectData data2 = this.Data;
		if (data2 != null)
		{
			Action<int[], int[]> confirmCallBack = data2.ConfirmCallBack;
			if (confirmCallBack != null)
			{
				confirmCallBack(this.CurrentSelectRoleList.ToArray(), list.ToArray());
			}
		}
		base.CloseMe(null);
	}

	// Token: 0x06013FF9 RID: 81913 RVA: 0x00592B04 File Offset: 0x00590D04
	protected void BackClick()
	{
		MultiTeamRoleSelectData data = this.Data;
		if (data != null)
		{
			Action backCallBack = data.BackCallBack;
			if (backCallBack != null)
			{
				backCallBack();
			}
		}
		base.CloseMe(null);
	}

	// Token: 0x06013FFA RID: 81914 RVA: 0x00592B2C File Offset: 0x00590D2C
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

	// Token: 0x06013FFB RID: 81915 RVA: 0x00592B70 File Offset: 0x00590D70
	private unsafe void OnDetailClick()
	{
		int clickSelectRoleId = this.ClickSelectRoleId;
		List<int> list;
		if (clickSelectRoleId < 100000)
		{
			list = ModelBase<RoleModel>.Instance.GetRoleIdList();
		}
		else
		{
			int num = 1;
			List<int> list2 = new List<int>(num);
			CollectionsMarshal.SetCount<int>(list2, num);
			list = list2;
			Span<int> span = CollectionsMarshal.AsSpan<int>(list2);
			int index = 0;
			*span[index] = clickSelectRoleId;
		}
		List<int> roleIdList = list;
		ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, clickSelectRoleId, roleIdList, null, delegate(bool success, int _)
		{
			if (success)
			{
				Singleton<EventSystem>.Instance.Add(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
				Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
				Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnRoleSwitchTagChange));
			}
		});
	}

	// Token: 0x06013FFC RID: 81916 RVA: 0x00592BE0 File Offset: 0x00590DE0
	private void OnCloseView(EUiViewName viewName, int i)
	{
		if (viewName == EUiViewName.RoleRootView)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnRoleSwitchTagChange));
			this.RefreshTagSwitchItem(this.ClickSelectRoleId);
			this.RefreshRoleLayout();
		}
	}

	// Token: 0x06013FFD RID: 81917 RVA: 0x00592C5D File Offset: 0x00590E5D
	private void OnRoleChangeEnd()
	{
		base.CloseMe(null);
	}

	// Token: 0x06013FFE RID: 81918 RVA: 0x00592C68 File Offset: 0x00590E68
	private void OnRoleSwitchTagChange(int roleId)
	{
		if (this.CurrentSelectTagMap.GetValueOrNull(roleId) != null)
		{
			this.CurrentSelectTagMap.Add(roleId, ModelBase<RoleModel>.Instance.GetRoleSkillBranchIdInCurrentGamePlay(roleId));
		}
	}

	// Token: 0x06013FFF RID: 81919 RVA: 0x00592CA4 File Offset: 0x00590EA4
	private void UpdateRoleList(List<RoleDataBase> list, bool isOutSideChange, EFilterSortType type)
	{
		if (this.Data == null)
		{
			return;
		}
		List<MultiTeamRoleData> multiTeamRoleDataList = this.Data.GetMultiTeamRoleDataList();
		this.CurrentFilterRoleList = list;
		foreach (MultiTeamRoleData multiTeamRoleData in multiTeamRoleDataList)
		{
			multiTeamRoleData.SetSortedRoleList(this.CurrentFilterRoleList);
		}
		this.RefreshNoneRoleTips();
		this.RefreshScrollViewItem();
		this.RefreshCurrentRoleInfo();
		this.RefreshRoleLayout();
	}

	// Token: 0x06014000 RID: 81920 RVA: 0x00592D28 File Offset: 0x00590F28
	private void RefreshRoleLayout()
	{
		if (this.Data == null || this.RoleLayout == null)
		{
			return;
		}
		List<MultiTeamRoleData> multiTeamRoleDataList = this.Data.GetMultiTeamRoleDataList();
		List<MultiTeamRoleGridContentData> list = new List<MultiTeamRoleGridContentData>();
		foreach (MultiTeamRoleData multiTeamRoleData in multiTeamRoleDataList)
		{
			if (multiTeamRoleData.GetShowMultiTeamRoleGridDataList().Count != 0)
			{
				list.Add(new MultiTeamRoleGridContentData
				{
					Data = multiTeamRoleData,
					CurrentSelectedRoleList = this.CurrentSelectRoleList.ToArray(),
					CurrentSelectTagMap = this.CurrentSelectTagMap,
					OnToggleCallBack = new Action<MediumItemGridExtendCallback>(this.OnRoleGridToggle),
					CanExecuteChangeCallBack = new Func<object, bool, EToggleState, bool>(this.CanExecuteChangeCallBack),
					ShowGridAnimation = this.NeedGridAnimation
				});
			}
		}
		this.RoleLayout.RefreshByData(list, null, false);
		this.NeedGridAnimation = false;
	}

	// Token: 0x06014001 RID: 81921 RVA: 0x00592E14 File Offset: 0x00591014
	private void OnRoleGridToggle(MediumItemGridExtendCallback data)
	{
		MultiTeamRoleGridData multiTeamRoleGridData = data.Data as MultiTeamRoleGridData;
		if (multiTeamRoleGridData == null || multiTeamRoleGridData.GetRole() == null)
		{
			return;
		}
		int dataId = multiTeamRoleGridData.GetRole().GetDataId();
		int num = this.CurrentSelectRoleList.IndexOf(dataId);
		this.ClickSelectRoleId = dataId;
		if (this.CurrentSelectRoleList.Contains(dataId))
		{
			this.CurrentSelectRoleList[num] = 0;
			if (num > 0)
			{
				this.CurrentSelectRoleId = this.CurrentSelectRoleList[num - 1];
			}
			else
			{
				this.CurrentSelectRoleId = 0;
			}
		}
		else
		{
			for (int i = 0; i < this.CurrentSelectRoleList.Count; i++)
			{
				if (this.CurrentSelectRoleList[i] == 0)
				{
					this.CurrentSelectRoleList[i] = dataId;
					break;
				}
			}
			this.CurrentSelectRoleId = dataId;
		}
		this.RefreshCurrentRoleInfo();
		this.RefreshRoleLayout();
	}

	// Token: 0x06014002 RID: 81922 RVA: 0x00592EE0 File Offset: 0x005910E0
	private bool CanExecuteChangeCallBack(object data, bool isForceSelected, EToggleState state)
	{
		if (this.Data == null)
		{
			return false;
		}
		MultiTeamRoleGridData multiTeamRoleGridData = data as MultiTeamRoleGridData;
		if (multiTeamRoleGridData == null || multiTeamRoleGridData.GetRole() == null)
		{
			return false;
		}
		int dataId = multiTeamRoleGridData.GetRole().GetDataId();
		Func<int, int[], bool> ifCanSelectCheck = this.Data.IfCanSelectCheck;
		if (ifCanSelectCheck != null && !ifCanSelectCheck(dataId, this.CurrentSelectRoleList.ToArray()))
		{
			return false;
		}
		if (this.CurrentSelectRoleList.Contains(dataId))
		{
			return true;
		}
		if (this.CurrentSelectRoleList.Count((int value) => value != 0) >= this.Data.TeamLength)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BossRushMaxLength", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x06014003 RID: 81923 RVA: 0x00592F9C File Offset: 0x0059119C
	protected override void OnBeforeShow()
	{
		if (this.Data == null || this.FilterSortEntrance == null)
		{
			return;
		}
		this.NeedGridAnimation = true;
		this.FilterSortEntrance.UpdateData(this.Data.UseWay.Value, this.Data.GetSourceRoleList(), Array.Empty<object>());
	}

	// Token: 0x06014004 RID: 81924 RVA: 0x00592FEC File Offset: 0x005911EC
	private void RefreshCurrentRoleInfo()
	{
		int roleId = 0;
		if (this.CurrentFilterRoleList.Count != 0)
		{
			roleId = this.ClickSelectRoleId;
		}
		this.CheckCurRoleIsDead(roleId);
		this.RefreshRoleInfo(roleId);
		this.RefreshTopItem(roleId);
		this.RefreshRoleInfoContent(roleId);
		this.RefreshDetailButton(roleId);
		this.RefreshEmptySelectItem(roleId);
		this.RefreshTabItem(roleId);
		this.RefreshTagSwitchItem(roleId);
	}

	// Token: 0x06014005 RID: 81925 RVA: 0x00593048 File Offset: 0x00591248
	private void RefreshTopItem(int roleId)
	{
		bool uiactive = roleId != 0;
		base.GetItem(3).SetUIActive(uiactive);
	}

	// Token: 0x06014006 RID: 81926 RVA: 0x00593068 File Offset: 0x00591268
	private void RefreshDetailButton(int roleId)
	{
		bool uiactive = roleId != 0;
		base.GetButton(15).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x06014007 RID: 81927 RVA: 0x00593098 File Offset: 0x00591298
	private void RefreshRoleInfoContent(int roleId)
	{
		bool uiactive = roleId != 0;
		base.GetItem(9).SetUIActive(uiactive);
	}

	// Token: 0x06014008 RID: 81928 RVA: 0x005930B8 File Offset: 0x005912B8
	private void RefreshNoneRoleTips()
	{
		bool uiactive = this.CurrentFilterRoleList.Count == 0;
		base.GetItem(17).SetUIActive(uiactive);
	}

	// Token: 0x06014009 RID: 81929 RVA: 0x005930E4 File Offset: 0x005912E4
	private void RefreshScrollViewItem()
	{
		bool uiactive = this.CurrentFilterRoleList.Count > 0;
		base.GetItem(20).SetUIActive(uiactive);
	}

	// Token: 0x0601400A RID: 81930 RVA: 0x00593110 File Offset: 0x00591310
	private void RefreshEmptySelectItem(int roleId)
	{
		bool uiactive = this.CurrentFilterRoleList.Count > 0 && roleId == 0;
		base.GetItem(21).SetUIActive(uiactive);
	}

	// Token: 0x0601400B RID: 81931 RVA: 0x00593144 File Offset: 0x00591344
	private void RefreshTabItem(int roleId)
	{
		bool uiactive = roleId != 0;
		base.GetItem(22).SetUIActive(uiactive);
	}

	// Token: 0x0601400C RID: 81932 RVA: 0x00593164 File Offset: 0x00591364
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
		this.RefreshRoleName(roleId);
		this.RefreshRoleSkillInfo(roleId);
		this.RefreshRoleTagLayout(roleId);
		this.RefreshRoleUnRecommendLayout(roleId);
	}

	// Token: 0x0601400D RID: 81933 RVA: 0x005931E0 File Offset: 0x005913E0
	private void RefreshRoleName(int roleId)
	{
		if (roleId == 0)
		{
			return;
		}
		RoleSkinData roleSkinDataByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataByRoleId(roleId);
		if (roleSkinDataByRoleId != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), roleSkinDataByRoleId.GetName(), Array.Empty<object>());
		}
	}

	// Token: 0x0601400E RID: 81934 RVA: 0x0059321C File Offset: 0x0059141C
	private void RefreshRoleSkillInfo(int roleId)
	{
		if (roleId == 0)
		{
			return;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		if (roleConfig == null)
		{
			return;
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
		foreach (int num in this.DisplaySkillTypes)
		{
			foreach (Aki.Config.Skill skill in readOnlyList)
			{
				if (skill.SkillType == num)
				{
					TeamRoleSkillData teamRoleSkillData = new TeamRoleSkillData();
					teamRoleSkillData.SkillIcon = skill.Icon;
					teamRoleSkillData.SkillType = num;
					teamRoleSkillData.SkillName = skill.SkillName;
					teamRoleSkillData.SkillTagList = skill.SkillTagList();
					if (teamRoleSkillData.SkillTagList != null)
					{
						teamRoleSkillData.SkillTagList = teamRoleSkillData.SkillTagList.ToArray<int>();
					}
					teamRoleSkillData.SkillDesc = skill.SkillDescribe;
					string[] array = skill.SkillDetailNum();
					if (array != null)
					{
						teamRoleSkillData.SkillDescNum = array.ToArray<string>();
					}
					teamRoleSkillData.MultiSkillDesc = skill.MultiSkillDescribe;
					string[] array2 = skill.MultiSkillDetailNum();
					if (array2 != null)
					{
						teamRoleSkillData.MultiSkillDescNum = array2.ToArray<string>();
					}
					teamRoleSkillData.SkillResume = skill.SkillResume;
					string[] array3 = skill.SkillResumeNum();
					if (array3 != null)
					{
						teamRoleSkillData.SkillResumeNum = array3.ToArray<string>();
					}
					skillDataList.Add(teamRoleSkillData);
					break;
				}
			}
		}
		if (skillDataList.Count <= 0)
		{
			return;
		}
		this.SkillDataList = skillDataList;
		if (this.SkillLayout == null)
		{
			return;
		}
		this.SkillLayout.DeselectCurrentGridProxy();
		this.SkillLayout.RefreshByData(skillDataList, delegate
		{
			this.SkillLayout.SelectGridProxy(0, false);
			this.OnSkillItemStateChanged(EToggleState.ETT_Checked, skillDataList[0]);
		}, false);
	}

	// Token: 0x0601400F RID: 81935 RVA: 0x005934F4 File Offset: 0x005916F4
	private void RefreshRoleTagLayout(int roleId)
	{
		if (roleId == 0 || this.RoleTagLayout == null)
		{
			return;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		if (roleConfig == null)
		{
			return;
		}
		int[] roleTagByRoleInfo = ModelBase<RoleModel>.Instance.GetRoleTagByRoleInfo(roleConfig.Value);
		bool flag = roleTagByRoleInfo != null && roleTagByRoleInfo.Length != 0;
		base.GetMultiTemplateLayout(5).RootUIComp.Get().SetUIActive(flag);
		if (flag && roleTagByRoleInfo != null)
		{
			this.RoleTagLayout.RefreshByData(roleTagByRoleInfo.ToList<int>(), null, false);
		}
	}

	// Token: 0x06014010 RID: 81936 RVA: 0x00593574 File Offset: 0x00591774
	private void RefreshRoleUnRecommendLayout(int roleId)
	{
		if (roleId == 0 || this.Data == null)
		{
			return;
		}
		base.GetItem(23).SetUIActive(this.Data.UnRecommendRole.Contains(roleId));
	}

	// Token: 0x06014011 RID: 81937 RVA: 0x005935A0 File Offset: 0x005917A0
	private void CheckCurRoleIsDead(int roleId)
	{
		UUIText text = base.GetText(16);
		if (ModelBase<TowerModel>.Instance.IsOpenFloorFormation())
		{
			text.SetUIActive(false);
			return;
		}
		MultiTeamRoleSelectData data = this.Data;
		bool flag;
		if (data == null)
		{
			flag = false;
		}
		else
		{
			Func<int, bool> isNeedRevive = data.IsNeedRevive;
			flag = ((isNeedRevive != null) ? new bool?(isNeedRevive(roleId)) : null).GetValueOrDefault();
		}
		if (flag)
		{
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(text, "EditBattleTeamNeedRevive", Array.Empty<object>());
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x06014012 RID: 81938 RVA: 0x00593624 File Offset: 0x00591824
	private void RefreshSkillInfo(TeamRoleSkillData data)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), data.SkillName, Array.Empty<object>());
		UUIText text = base.GetText(12);
		if (text == null)
		{
			return;
		}
		if (this.SkillDescType == ERoleSkillDescType.MultiDesc)
		{
			if (ModelBase<RoleModel>.Instance.IsShowMultiSkillDesc && !StringUtils.IsEmpty(data.MultiSkillDesc))
			{
				if (data.MultiSkillDescNum != null && data.MultiSkillDescNum.Length != 0)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.MultiSkillDesc, data.MultiSkillDescNum);
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.MultiSkillDesc, Array.Empty<object>());
				}
			}
			else if (data.SkillDescNum != null && data.SkillDescNum.Length != 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.SkillDesc, data.SkillDescNum);
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.SkillDesc, Array.Empty<object>());
			}
		}
		else if (ModelBase<RoleModel>.Instance.IsShowSkillResume && !StringUtils.IsEmpty(data.SkillResume))
		{
			if (data.SkillResumeNum != null && data.SkillResumeNum.Length != 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.SkillResume, data.SkillResumeNum);
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.SkillResume, Array.Empty<object>());
			}
		}
		else if (data.SkillDescNum != null && data.SkillDescNum.Length != 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.SkillDesc, data.SkillDescNum);
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.SkillDesc, Array.Empty<object>());
		}
		if (StringUtils.IsEmpty(data.SkillTypeText))
		{
			string skillTypeNameLocalText = ConfigBase<RoleSkillConfig>.Instance.GetSkillTypeNameLocalText(data.SkillType);
			if (skillTypeNameLocalText != null && !string.IsNullOrEmpty(skillTypeNameLocalText))
			{
				base.GetText(11).SetText(skillTypeNameLocalText, true);
				return;
			}
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), data.SkillTypeText, Array.Empty<object>());
		}
	}

	// Token: 0x06014013 RID: 81939 RVA: 0x00593804 File Offset: 0x00591A04
	private void RefreshTagSwitchItem(int roleId)
	{
		if (roleId == 0 || !this.Data.NeedShowTag)
		{
			base.GetItem(27).SetUIActive(false);
			return;
		}
		if (!ModelBase<RoleModel>.Instance.IsRoleHasBranch(roleId))
		{
			base.GetItem(27).SetUIActive(false);
			return;
		}
		base.GetItem(27).SetUIActive(true);
		int skillBranchId;
		if (this.CurrentSelectTagMap.GetValueOrNull(roleId) != null)
		{
			skillBranchId = this.CurrentSelectTagMap.GetValueOrNull(roleId).Value;
		}
		else
		{
			skillBranchId = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIdInCurrentGamePlay(roleId);
		}
		TeamRoleSelectSkillBranchItem skillBranchSwitchItem = this.SkillBranchSwitchItem;
		if (skillBranchSwitchItem != null)
		{
			skillBranchSwitchItem.SetActiveBranchIndex(ModelBase<RoleModel>.Instance.GetRoleBranchIndexById(roleId, skillBranchId));
		}
		TeamRoleSelectSkillBranchItem skillBranchSwitchItem2 = this.SkillBranchSwitchItem;
		if (skillBranchSwitchItem2 == null)
		{
			return;
		}
		skillBranchSwitchItem2.RefreshIcon(delegate(int index)
		{
			int roleBranchIdByIndex = ModelBase<RoleModel>.Instance.GetRoleBranchIdByIndex(roleId, index);
			SkillBranch? skillBranchConfigById = ConfigBase<RoleConfig>.Instance.GetSkillBranchConfigById(roleBranchIdByIndex);
			if (skillBranchConfigById != null)
			{
				return skillBranchConfigById.Value.Icon;
			}
			return "";
		});
	}

	// Token: 0x06014014 RID: 81940 RVA: 0x005938FC File Offset: 0x00591AFC
	private void SwitchSkillBranchHandler(int skillBranch)
	{
		int roleBranchIdByIndex = ModelBase<RoleModel>.Instance.GetRoleBranchIdByIndex(this.ClickSelectRoleId, skillBranch);
		this.CurrentSelectTagMap.Add(this.ClickSelectRoleId, roleBranchIdByIndex);
		this.RefreshRoleLayout();
		if (ModelBase<RoleModel>.Instance.IsInGamePlayRoleEdit)
		{
			ControllerBase<RoleController>.Instance.ModifyRoleSkillBranchInCurrentGamePlay(this.ClickSelectRoleId, roleBranchIdByIndex, true);
			return;
		}
		ControllerBase<RoleController>.Instance.RequestRoleSkillBranchModify(this.ClickSelectRoleId, roleBranchIdByIndex);
	}

	// Token: 0x04009BBE RID: 39870
	private IReadOnlyList<int> DisplaySkillTypes;

	// Token: 0x04009BBF RID: 39871
	private Dictionary<int, int> CurrentSelectTagMap = new Dictionary<int, int>();

	// Token: 0x04009BC0 RID: 39872
	protected int CurrentSelectRoleId;

	// Token: 0x04009BC1 RID: 39873
	private int ClickSelectRoleId;

	// Token: 0x04009BC2 RID: 39874
	private readonly List<int> CurrentSelectRoleList = new List<int>();

	// Token: 0x04009BC3 RID: 39875
	[Nullable(2)]
	private MultiTeamRoleSelectData Data;

	// Token: 0x04009BC4 RID: 39876
	[Nullable(2)]
	protected PopupCaptionItem CaptionItem;

	// Token: 0x04009BC5 RID: 39877
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<RoleTagMediumIconItem, int> RoleTagLayout;

	// Token: 0x04009BC6 RID: 39878
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<TeamRoleSkillItem, TeamRoleSkillData> SkillLayout;

	// Token: 0x04009BC7 RID: 39879
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MultiTeamRoleGrid, MultiTeamRoleGridContentData> RoleLayout;

	// Token: 0x04009BC8 RID: 39880
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<RoleDataBase> FilterSortEntrance;

	// Token: 0x04009BC9 RID: 39881
	[Nullable(2)]
	private TeamRoleSelectSkillBranchItem SkillBranchSwitchItem;

	// Token: 0x04009BCA RID: 39882
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<TeamRoleSkillData> SkillDataList;

	// Token: 0x04009BCB RID: 39883
	private ERoleSkillDescType SkillDescType;

	// Token: 0x04009BCC RID: 39884
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04009BCD RID: 39885
	private List<RoleDataBase> CurrentFilterRoleList = new List<RoleDataBase>();

	// Token: 0x04009BCE RID: 39886
	private bool NeedGridAnimation;

	// Token: 0x02008B4A RID: 35658
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402EF2B RID: 192299
		CaptionItem,
		// Token: 0x0402EF2C RID: 192300
		SelectRoleVerticalLayout,
		// Token: 0x0402EF2D RID: 192301
		LayoutItem,
		// Token: 0x0402EF2E RID: 192302
		TopItem,
		// Token: 0x0402EF2F RID: 192303
		RoleNameText,
		// Token: 0x0402EF30 RID: 192304
		RoleTagContent,
		// Token: 0x0402EF31 RID: 192305
		SkillTagItem,
		// Token: 0x0402EF32 RID: 192306
		SkillContent,
		// Token: 0x0402EF33 RID: 192307
		SkillItem,
		// Token: 0x0402EF34 RID: 192308
		RoleInfoContent,
		// Token: 0x0402EF35 RID: 192309
		SkillNameText,
		// Token: 0x0402EF36 RID: 192310
		SkillTypeNameText,
		// Token: 0x0402EF37 RID: 192311
		SkillInfoText,
		// Token: 0x0402EF38 RID: 192312
		FilterSortEntrance,
		// Token: 0x0402EF39 RID: 192313
		ConfirmButton,
		// Token: 0x0402EF3A RID: 192314
		DetailButton,
		// Token: 0x0402EF3B RID: 192315
		TipsText,
		// Token: 0x0402EF3C RID: 192316
		NoneRoleTips,
		// Token: 0x0402EF3D RID: 192317
		SkillModeToggle,
		// Token: 0x0402EF3E RID: 192318
		SkillModeText,
		// Token: 0x0402EF3F RID: 192319
		ScrollViewItem,
		// Token: 0x0402EF40 RID: 192320
		EmptySelectItem,
		// Token: 0x0402EF41 RID: 192321
		TabItem,
		// Token: 0x0402EF42 RID: 192322
		UnRecommendRoleItem,
		// Token: 0x0402EF43 RID: 192323
		UnRecommendRoleBtn,
		// Token: 0x0402EF44 RID: 192324
		UnRecommendRoleText,
		// Token: 0x0402EF45 RID: 192325
		TrailRoleItem,
		// Token: 0x0402EF46 RID: 192326
		PanelTagSwitchItem,
		// Token: 0x0402EF47 RID: 192327
		TagSwitchItem
	}
}
