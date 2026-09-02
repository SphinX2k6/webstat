using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200143C RID: 5180
[NullableContext(1)]
[Nullable(0)]
internal class TeamListItem : UiPanelBase
{
	// Token: 0x06009025 RID: 36901 RVA: 0x0025E198 File Offset: 0x0025C398
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton))
		};
	}

	// Token: 0x06009026 RID: 36902 RVA: 0x0025E270 File Offset: 0x0025C470
	private void OnClickButton()
	{
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.QuickRoleSelectView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuickRoleSelectView, this.GetRoleSelectViewData(), delegate(bool isSuccess, int viewId)
			{
				if (isSuccess)
				{
					UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.MowingTowerMainView);
					if (viewByName == null)
					{
						return;
					}
					viewByName.AddChildViewById(viewId);
				}
			});
		}
	}

	// Token: 0x06009027 RID: 36903 RVA: 0x0025E2C4 File Offset: 0x0025C4C4
	private QuickRoleSelectViewData GetRoleSelectViewData()
	{
		MowingTowerLevelDetailInfo levelInfo = this.CurrentTeamInfo.LevelInfo;
		InstanceDungeon? instanceDungeon = (levelInfo != null) ? levelInfo.GetInstanceDungeonConfig(this.BelongTo) : null;
		int fightFormationId = (instanceDungeon != null) ? instanceDungeon.GetValueOrDefault().FightFormationId : 0;
		FightFormation? fightFormationConfig = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(fightFormationId);
		List<RoleDataBase> list = new List<RoleDataBase>();
		foreach (RoleInstance roleInstance in ModelBase<RoleModel>.Instance.GetRoleList())
		{
			if (roleInstance.GetRoleId() != 0)
			{
				list.Add(roleInstance);
			}
		}
		foreach (int id in fightFormationConfig.Value.GetTrialRoleArray())
		{
			TrialRoleInfo? trialRoleConfigByGroupId = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfigByGroupId(id);
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(trialRoleConfigByGroupId.Value.Id, true);
			list.Add(roleDataById);
		}
		ValueTuple<List<int>, List<int>> currentTeamMembers = this.CurrentTeamInfo.GetCurrentTeamMembers();
		List<int> list2 = (this.BelongTo == ETeamBelong.FirstPart) ? currentTeamMembers.Item1 : currentTeamMembers.Item2;
		QuickRoleSelectViewData quickRoleSelectViewData = new QuickRoleSelectViewData(EFilterSortGroupId.EditFormation, list2.ToArray(), list);
		ModelBase<MowingTowerModel>.Instance.CurrentOptionArea = (int)this.BelongTo;
		ModelBase<MowingTowerModel>.Instance.OtherHalfAreaRoleList = ((this.BelongTo == ETeamBelong.FirstPart) ? currentTeamMembers.Item2 : currentTeamMembers.Item1);
		MowingTowerLevelDetailInfo levelInfo2 = this.CurrentTeamInfo.LevelInfo;
		MowTowerLevelsRe? mowTowerLevelsRe = (levelInfo2 != null) ? levelInfo2.GetConfig() : null;
		MowingTowerModel instance = ModelBase<MowingTowerModel>.Instance;
		int[] addLevel;
		if (mowTowerLevelsRe == null)
		{
			int[] array = new int[2];
			array[0] = -1;
			addLevel = array;
			array[1] = -1;
		}
		else
		{
			addLevel = mowTowerLevelsRe.Value.GetMowTowerLevelArray();
		}
		instance.AddLevel = addLevel;
		quickRoleSelectViewData.OnHideFinish = delegate()
		{
			ModelBase<MowingTowerModel>.Instance.CurrentOptionArea = -1;
			ModelBase<MowingTowerModel>.Instance.OtherHalfAreaRoleList = new List<int>();
			ModelBase<MowingTowerModel>.Instance.AddLevel = new int[]
			{
				-1,
				-1
			};
		};
		quickRoleSelectViewData.OnConfirm = new Action<int[]>(this.OnEnsureFormation);
		List<int> list3 = list2;
		List<int> list4 = new List<int>();
		for (int k = 0; k < list3.Count; k++)
		{
			int num = list3[k];
			if (num != 0)
			{
				list4.Add(num);
			}
		}
		quickRoleSelectViewData.SelectedRoleList = list4.ToArray();
		MowingTowerLevelDetailInfo levelInfo3 = this.CurrentTeamInfo.LevelInfo;
		InstanceDungeon? instanceDungeon2 = (levelInfo3 != null) ? levelInfo3.GetInstanceDungeonConfig(this.BelongTo) : null;
		ModelBase<EditBattleTeamModel>.Instance.SetInstanceDungeonId(new int?((instanceDungeon2 != null) ? instanceDungeon2.GetValueOrDefault().Id : 0));
		return quickRoleSelectViewData;
	}

	// Token: 0x06009028 RID: 36904 RVA: 0x0025E550 File Offset: 0x0025C750
	private void OnEnsureFormation(int[] roleIdList)
	{
		for (int i = 0; i < TeamListItem.ROLE_TEAM_SIZE; i++)
		{
			this.CurrentTeamInfo.SetIndexTeamMembers(this.BelongTo, i, 0);
		}
		for (int j = 0; j < roleIdList.Length; j++)
		{
			int roleId = roleIdList[j];
			this.CurrentTeamInfo.SetIndexTeamMembers(this.BelongTo, j, roleId);
		}
		this.CurrentTeamInfo.ReSortTeamMembers(this.BelongTo);
		this.OnSelectTeamRole();
	}

	// Token: 0x06009029 RID: 36905 RVA: 0x0025E5BC File Offset: 0x0025C7BC
	protected override UniTask OnBeforeStartAsync()
	{
		TeamListItem.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TeamListItem.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600902A RID: 36906 RVA: 0x0025E5FF File Offset: 0x0025C7FF
	private TeamRoleItem CreateTeamRoleItem()
	{
		return new TeamRoleItem();
	}

	// Token: 0x0600902B RID: 36907 RVA: 0x0025E608 File Offset: 0x0025C808
	public void RefreshTeamRole(MowingTowerTeamInfo teamInfo, ETeamBelong belongTo)
	{
		this.CurrentTeamInfo = teamInfo;
		this.BelongTo = belongTo;
		ValueTuple<List<int>, List<int>> currentTeamMembers = teamInfo.GetCurrentTeamMembers();
		List<int> list = (belongTo == ETeamBelong.FirstPart) ? currentTeamMembers.Item1 : currentTeamMembers.Item2;
		int num = 3;
		List<TeamData> list2 = new List<TeamData>();
		for (int i = 0; i < list.Count; i++)
		{
			int roleId = list[i];
			list2.Add(new TeamData
			{
				RoleId = roleId,
				TeamInfo = teamInfo,
				BelongTo = belongTo,
				OnSelectRole = new Action(this.OnSelectTeamRole)
			});
		}
		while (list2.Count < num)
		{
			list2.Add(new TeamData
			{
				RoleId = 0,
				TeamInfo = teamInfo,
				BelongTo = belongTo,
				OnSelectRole = new Action(this.OnSelectTeamRole)
			});
		}
		this.TeamLayout.RefreshByData(list2, null, false);
		this.RefreshElementItem();
		this.RefreshLevelText();
	}

	// Token: 0x0600902C RID: 36908 RVA: 0x0025E6F0 File Offset: 0x0025C8F0
	private void RefreshElementItem()
	{
		for (int i = 0; i < this.ElementItemArray.Count; i++)
		{
			this.ElementItemArray[i].SetActive(false);
		}
		int[] recommendElementIdArray = this.CurrentTeamInfo.GetCurrentSelectLevel().GetRecommendElementIdArray(this.BelongTo);
		for (int j = 0; j < recommendElementIdArray.Length; j++)
		{
			if (recommendElementIdArray[j] != 0)
			{
				this.ElementItemArray[j].SetActive(true);
				this.ElementItemArray[j].Refresh(recommendElementIdArray[j], false, j);
			}
		}
		string textStringId = (recommendElementIdArray.Length != 0) ? "BossRushRecommendElement" : "BossRushRecommendElementNone";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textStringId, Array.Empty<object>());
	}

	// Token: 0x0600902D RID: 36909 RVA: 0x0025E7A0 File Offset: 0x0025C9A0
	private void RefreshLevelText()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "BossRushRecommendLevel", new <>z__ReadOnlySingleElementList<object>(this.CurrentTeamInfo.GetRecommendLevel().ToString()));
	}

	// Token: 0x0600902E RID: 36910 RVA: 0x0025E7DB File Offset: 0x0025C9DB
	private void OnSelectTeamRole()
	{
		Action refreshLowLevelTips = this.RefreshLowLevelTips;
		if (refreshLowLevelTips != null)
		{
			refreshLowLevelTips();
		}
		this.RefreshTeamRole(this.CurrentTeamInfo, this.BelongTo);
	}

	// Token: 0x0600902F RID: 36911 RVA: 0x0025E800 File Offset: 0x0025CA00
	public void BindRefreshLowLevelTips(Action func)
	{
		this.RefreshLowLevelTips = func;
	}

	// Token: 0x040042DE RID: 17118
	[Nullable(2)]
	private MowingTowerTeamInfo CurrentTeamInfo;

	// Token: 0x040042DF RID: 17119
	private ETeamBelong BelongTo;

	// Token: 0x040042E0 RID: 17120
	[Nullable(2)]
	private CommonElementItem ElementItem1;

	// Token: 0x040042E1 RID: 17121
	[Nullable(2)]
	private CommonElementItem ElementItem2;

	// Token: 0x040042E2 RID: 17122
	private readonly List<CommonElementItem> ElementItemArray = new List<CommonElementItem>();

	// Token: 0x040042E3 RID: 17123
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<TeamRoleItem, TeamData> TeamLayout;

	// Token: 0x040042E4 RID: 17124
	[Nullable(2)]
	private Action RefreshLowLevelTips;

	// Token: 0x040042E5 RID: 17125
	[StaticVariableRuleIgnore]
	private static int ROLE_TEAM_SIZE = 3;
}
