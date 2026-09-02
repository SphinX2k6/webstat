using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D4F RID: 11599
[NullableContext(1)]
[Nullable(0)]
public class WeeklyRogueRoleSelectView : UiViewBase
{
	// Token: 0x06017662 RID: 95842 RVA: 0x0067CD20 File Offset: 0x0067AF20
	public WeeklyRogueRoleSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06017663 RID: 95843 RVA: 0x0067CD34 File Offset: 0x0067AF34
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIDynScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUISprite)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem))
		};
	}

	// Token: 0x06017664 RID: 95844 RVA: 0x0067CE9C File Offset: 0x0067B09C
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyRogueRoleSelectView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyRogueRoleSelectView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06017665 RID: 95845 RVA: 0x0067CEE0 File Offset: 0x0067B0E0
	protected override void OnStart()
	{
		WeeklyRogueData activityDataNew = ModelBase<WeeklyRogueModel>.Instance.ActivityDataNew;
		RogueWeeklyCycle value = activityDataNew.GetCycleConfig().Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), value.BuffDesc, value.BuffDescParam());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "WeRougeFormationMonsterLevel", new <>z__ReadOnlySingleElementList<object>(activityDataNew.GetLvInfo()));
		this.FilterSortEntrance.UpdateData(EFilterSortGroupId.WeeklyRogueEditFormation, this.RoleList, Array.Empty<object>());
	}

	// Token: 0x06017666 RID: 95846 RVA: 0x0067CF64 File Offset: 0x0067B164
	protected override void OnBeforeDestroy()
	{
		if (Singleton<EventSystem>.Instance.Has<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView)))
		{
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		}
		ModelBase<WeeklyRogueModel>.Instance.SelectRoleIdList.Clear();
		FilterSortEntrance<RoleDataBase> filterSortEntrance = this.FilterSortEntrance;
		if (filterSortEntrance != null)
		{
			filterSortEntrance.Destroy(null);
		}
		this.FilterSortEntrance = null;
	}

	// Token: 0x06017667 RID: 95847 RVA: 0x0067CFCC File Offset: 0x0067B1CC
	private void OnClickConfirm(int _)
	{
		List<int> currentSelectRoleList = this.GetCurrentSelectRoleList();
		if (currentSelectRoleList.Count == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NoRole", Array.Empty<object>());
			return;
		}
		ModelBase<WeeklyRogueModel>.Instance.SelectRoleIdList = currentSelectRoleList;
		Singleton<UiLayer>.Instance.SetShowMaskLayer("WeeklyRogueRoleSelectView.RogueWeeklyArtifactSelectStart", true);
		ControllerBase<WeeklyRogueController>.Instance.RogueWeeklyArtifactSelectStartRequest().ContinueWith(delegate()
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("WeeklyRogueRoleSelectView.RogueWeeklyArtifactSelectStart", false);
		}).Forget();
	}

	// Token: 0x06017668 RID: 95848 RVA: 0x0067D04C File Offset: 0x0067B24C
	private void OnClickRoleDetail(int _)
	{
		if (this.CurSelectRole == null)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("CharacterDetailsTip", Array.Empty<object>());
			return;
		}
		bool flag = this.CurSelectRole.IsTrialRole();
		int dataId = this.CurSelectRole.GetDataId();
		List<int> currentSelectRoleList = this.GetCurrentSelectRoleList();
		List<int> list = new List<int>
		{
			dataId
		};
		if (!flag)
		{
			list = new List<int>(currentSelectRoleList);
			foreach (RoleDataBase roleDataBase in this.RoleList)
			{
				if (!roleDataBase.IsTrialRole() && !currentSelectRoleList.Contains(roleDataBase.GetDataId()))
				{
					list.Add(roleDataBase.GetDataId());
				}
			}
		}
		OpenRoleMainViewData param = new OpenRoleMainViewData
		{
			AgentType = ERoleAgentType.Normal,
			SelectRoleId = new int?(dataId),
			RoleIdList = list,
			TeamPositionType = new ETeamPositionType?(ETeamPositionType.RoleSelect)
		};
		ControllerBase<RoleController>.Instance.OpenRoleMainViewByParam(param);
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		ModelBase<RoleModel>.Instance.StartRecordRoleSkillBranchChangeRequest();
	}

	// Token: 0x06017669 RID: 95849 RVA: 0x0067D16C File Offset: 0x0067B36C
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName != EUiViewName.RoleRootView)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		List<int> list = ModelBase<RoleModel>.Instance.StopRecordRoleSkillBranchChangeRequest();
		if (list.Count <= 0)
		{
			return;
		}
		foreach (int roleId in list)
		{
			DynamicScrollView<WeeklyRogueRoleDynamicContainer, WeeklyRogueRoleDynamicItem, IWeeklyRogueRoleGroupInfo> dynamicRoleGroupLayout = this.DynamicRoleGroupLayout;
			WeeklyRogueRoleDynamicContainer[] array = ((dynamicRoleGroupLayout != null) ? dynamicRoleGroupLayout.GetScrollItemItems() : null) ?? Array.Empty<WeeklyRogueRoleDynamicContainer>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RefreshRoleByRoleId(roleId);
			}
		}
		this.RefreshTeamSelect();
	}

	// Token: 0x0601766A RID: 95850 RVA: 0x0067D230 File Offset: 0x0067B430
	private void OnBtnHelpBtn()
	{
		WeeklyRogueData activityDataNew = ModelBase<WeeklyRogueModel>.Instance.ActivityDataNew;
		RogueWeeklyCycle? rogueWeeklyCycle = (activityDataNew != null) ? activityDataNew.GetCycleConfig() : null;
		ControllerBase<HelpController>.Instance.OpenHelpById(rogueWeeklyCycle.Value.HelpId);
	}

	// Token: 0x0601766B RID: 95851 RVA: 0x0067D278 File Offset: 0x0067B478
	private UniTask InitRoleGroupLayout()
	{
		WeeklyRogueRoleSelectView.<InitRoleGroupLayout>d__18 <InitRoleGroupLayout>d__;
		<InitRoleGroupLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleGroupLayout>d__.<>4__this = this;
		<InitRoleGroupLayout>d__.<>1__state = -1;
		<InitRoleGroupLayout>d__.<>t__builder.Start<WeeklyRogueRoleSelectView.<InitRoleGroupLayout>d__18>(ref <InitRoleGroupLayout>d__);
		return <InitRoleGroupLayout>d__.<>t__builder.Task;
	}

	// Token: 0x0601766C RID: 95852 RVA: 0x0067D2BC File Offset: 0x0067B4BC
	private List<IWeeklyRogueRoleGroupInfo> GenerateAllRoleGroupInfo([Nullable(new byte[]
	{
		2,
		1
	})] List<RoleDataBase> roleList = null)
	{
		List<RoleDataBase> wholeRoleList = roleList ?? this.RoleList;
		List<IWeeklyRogueRoleGroupInfo> list = new List<IWeeklyRogueRoleGroupInfo>();
		List<RoleDataBase> classifiedRoleList = this.GetClassifiedRoleList(wholeRoleList, true);
		bool flag = classifiedRoleList.Count == 0;
		WeeklyRogueRoleGroupTitleInfo weeklyRogueRoleGroupTitleInfo = new WeeklyRogueRoleGroupTitleInfo();
		weeklyRogueRoleGroupTitleInfo.TitleId = "WeRougeFormationRecommendedRole";
		weeklyRogueRoleGroupTitleInfo.IsUp = true;
		WeeklyRogueData activityDataNew = ModelBase<WeeklyRogueModel>.Instance.ActivityDataNew;
		weeklyRogueRoleGroupTitleInfo.ScoreRate = ((activityDataNew != null) ? new int?(activityDataNew.GetScoreRate()) : null);
		weeklyRogueRoleGroupTitleInfo.IsEmpty = (classifiedRoleList.Count == 0);
		WeeklyRogueRoleGroupTitleInfo titleInfo = weeklyRogueRoleGroupTitleInfo;
		WeeklyRogueRoleGroupInfo item = new WeeklyRogueRoleGroupInfo
		{
			IsTitleType = true,
			TitleInfo = titleInfo
		};
		list.Add(item);
		if (!flag)
		{
			WeeklyRogueRoleGroupInfo item2 = new WeeklyRogueRoleGroupInfo
			{
				IsTitleType = false,
				DataList = classifiedRoleList
			};
			list.Add(item2);
		}
		List<RoleDataBase> classifiedRoleList2 = this.GetClassifiedRoleList(wholeRoleList, false);
		bool flag2 = classifiedRoleList2.Count == 0;
		WeeklyRogueRoleGroupTitleInfo titleInfo2 = new WeeklyRogueRoleGroupTitleInfo
		{
			TitleId = "WeRougeFormationOtherRole",
			IsUp = false,
			IsEmpty = flag2
		};
		WeeklyRogueRoleGroupInfo item3 = new WeeklyRogueRoleGroupInfo
		{
			IsTitleType = true,
			TitleInfo = titleInfo2
		};
		list.Add(item3);
		if (!flag2)
		{
			WeeklyRogueRoleGroupInfo item4 = new WeeklyRogueRoleGroupInfo
			{
				IsTitleType = false,
				DataList = classifiedRoleList2
			};
			list.Add(item4);
		}
		return list;
	}

	// Token: 0x0601766D RID: 95853 RVA: 0x0067D3F4 File Offset: 0x0067B5F4
	private List<RoleDataBase> GetClassifiedRoleList(List<RoleDataBase> wholeRoleList, bool needRecommend)
	{
		List<RoleDataBase> list = new List<RoleDataBase>();
		foreach (RoleDataBase roleDataBase in wholeRoleList)
		{
			bool flag = ModelBase<WeeklyRogueModel>.Instance.CheckIsRecommendRole(roleDataBase.GetDataId());
			if (needRecommend == flag)
			{
				list.Add(roleDataBase);
			}
		}
		List<ValueTuple<RoleDataBase, int>> list2 = new List<ValueTuple<RoleDataBase, int>>();
		for (int i = 0; i < list.Count; i++)
		{
			list2.Add(new ValueTuple<RoleDataBase, int>(list[i], i));
		}
		list2.Sort(delegate([TupleElementNames(new string[]
		{
			"Role",
			"Index"
		})] [Nullable(new byte[]
		{
			0,
			1
		})] ValueTuple<RoleDataBase, int> a, [TupleElementNames(new string[]
		{
			"Role",
			"Index"
		})] [Nullable(new byte[]
		{
			0,
			1
		})] ValueTuple<RoleDataBase, int> b)
		{
			int num = (a.Item1.IsTrialRole() > false) ? 1 : 0;
			int num2 = (b.Item1.IsTrialRole() > false) ? 1 : 0;
			int num3 = num - num2;
			if (num3 == 0)
			{
				return a.Item2 - b.Item2;
			}
			return num3;
		});
		list.Clear();
		foreach (ValueTuple<RoleDataBase, int> valueTuple in list2)
		{
			list.Add(valueTuple.Item1);
		}
		return list;
	}

	// Token: 0x0601766E RID: 95854 RVA: 0x0067D500 File Offset: 0x0067B700
	private void UpdateRoleList(List<RoleDataBase> list, bool _1, EFilterSortType _2)
	{
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		List<RoleDataBase> list2 = new List<RoleDataBase>();
		for (int i = 1; i <= 3; i++)
		{
			if (roleIndexMap.ContainsKey(i))
			{
				list2.Add(roleIndexMap[i]);
			}
		}
		foreach (RoleDataBase roleDataBase in list)
		{
			if (roleDataBase != null && !list2.Contains(roleDataBase))
			{
				list2.Add(roleDataBase);
			}
		}
		this.DynamicRoleGroupLayout.RefreshByData(this.GenerateAllRoleGroupInfo(list2).ToArray(), false, false);
	}

	// Token: 0x0601766F RID: 95855 RVA: 0x0067D5AC File Offset: 0x0067B7AC
	private WeeklyRogueRoleDynamicContainer OnCreateRoleGroup(IWeeklyRogueRoleGroupInfo _1, UUIItem _2, int _3)
	{
		return new WeeklyRogueRoleDynamicContainer
		{
			RefreshRole = new Action<RoleDataBase>(this.RefreshRoleSelect)
		};
	}

	// Token: 0x06017670 RID: 95856 RVA: 0x0067D5C5 File Offset: 0x0067B7C5
	private void RefreshRoleSelect(RoleDataBase roleData)
	{
		this.CurSelectRole = roleData;
		this.RefreshTeamSelect();
	}

	// Token: 0x06017671 RID: 95857 RVA: 0x0067D5D4 File Offset: 0x0067B7D4
	private WeeklyRogueRolePosItem OnCreatePos()
	{
		return new WeeklyRogueRolePosItem
		{
			OnBtnClickFunc = new Action<RoleDataBase>(this.OnBtnRolePosClick)
		};
	}

	// Token: 0x06017672 RID: 95858 RVA: 0x0067D5F0 File Offset: 0x0067B7F0
	[NullableContext(2)]
	private void OnBtnRolePosClick(RoleDataBase data)
	{
		if (data == null)
		{
			return;
		}
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		HashSet<int> selectedRoleSet = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet;
		foreach (KeyValuePair<int, RoleDataBase> keyValuePair in new Dictionary<int, RoleDataBase>(roleIndexMap))
		{
			if (keyValuePair.Value == data)
			{
				roleIndexMap.Remove(keyValuePair.Key);
				selectedRoleSet.Remove(data.GetDataId());
				break;
			}
		}
		WeeklyRogueRoleDynamicContainer[] scrollItemItems = this.DynamicRoleGroupLayout.GetScrollItemItems();
		for (int i = 0; i < scrollItemItems.Length; i++)
		{
			scrollItemItems[i].Refresh();
		}
		this.RefreshTeamSelect();
	}

	// Token: 0x06017673 RID: 95859 RVA: 0x0067D6B0 File Offset: 0x0067B8B0
	private List<int> GetCurrentSelectRoleList()
	{
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		List<int> list = new List<int>();
		for (int i = 1; i <= 3; i++)
		{
			RoleDataBase roleDataBase;
			if (roleIndexMap.TryGetValue(i, out roleDataBase))
			{
				int dataId = roleDataBase.GetDataId();
				list.Add(dataId);
			}
		}
		return list;
	}

	// Token: 0x06017674 RID: 95860 RVA: 0x0067D6F8 File Offset: 0x0067B8F8
	private void RefreshTeamSelect()
	{
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		bool flag = false;
		List<IWeeklyRogueRolePosInfo> list = new List<IWeeklyRogueRolePosInfo>();
		for (int i = 1; i <= 3; i++)
		{
			WeeklyRogueRolePosInfo weeklyRogueRolePosInfo = new WeeklyRogueRolePosInfo();
			RoleDataBase data;
			if (roleIndexMap.TryGetValue(i, out data))
			{
				weeklyRogueRolePosInfo.Data = data;
				weeklyRogueRolePosInfo.IsRecommend = new bool?(ModelBase<WeeklyRogueModel>.Instance.CheckIsRecommendRole(weeklyRogueRolePosInfo.Data.GetDataId()));
				if (!flag && weeklyRogueRolePosInfo.IsRecommend.GetValueOrDefault())
				{
					flag = true;
				}
			}
			list.Add(weeklyRogueRolePosInfo);
		}
		this.TeamPosLayout.RefreshByData(list, null, false);
		this.SetUpState(flag);
	}

	// Token: 0x06017675 RID: 95861 RVA: 0x0067D798 File Offset: 0x0067B998
	private void SetUpState(bool bUp)
	{
		WeeklyRogueData activityDataNew = ModelBase<WeeklyRogueModel>.Instance.ActivityDataNew;
		if (activityDataNew == null)
		{
			return;
		}
		RogueWeeklyCycle? cycleConfig = activityDataNew.GetCycleConfig();
		if (cycleConfig == null)
		{
			return;
		}
		int scoreRate = activityDataNew.GetScoreRate();
		int num = bUp ? cycleConfig.Value.MaxScore : cycleConfig.Value.BaseScore;
		base.GetItem(9).SetUIActive(true);
		UUISprite sprite = base.GetSprite(10);
		UUIItem uuiitem = sprite;
		FColor? fcolor = new FColor?(sprite.changeColor);
		uuiitem.SetChangeColor(bUp, fcolor);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "WeRougeFormationIntegralMultiplier", new <>z__ReadOnlySingleElementList<object>(scoreRate));
		UUIText text = base.GetText(3);
		text.SetText(num.ToString(), true);
		UUIItem uuiitem2 = text;
		fcolor = new FColor?(text.changeColor);
		uuiitem2.SetChangeColor(bUp, fcolor);
		base.GetItem(4).SetUIActive(bUp);
	}

	// Token: 0x0400B394 RID: 45972
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400B395 RID: 45973
	[Nullable(2)]
	private ButtonItem ButtonConfirm;

	// Token: 0x0400B396 RID: 45974
	[Nullable(2)]
	private ButtonItem ButtonRoleDetail;

	// Token: 0x0400B397 RID: 45975
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	protected DynamicScrollView<WeeklyRogueRoleDynamicContainer, WeeklyRogueRoleDynamicItem, IWeeklyRogueRoleGroupInfo> DynamicRoleGroupLayout;

	// Token: 0x0400B398 RID: 45976
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WeeklyRogueRolePosItem, IWeeklyRogueRolePosInfo> TeamPosLayout;

	// Token: 0x0400B399 RID: 45977
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<RoleDataBase> FilterSortEntrance;

	// Token: 0x0400B39A RID: 45978
	private List<RoleDataBase> RoleList = new List<RoleDataBase>();

	// Token: 0x0400B39B RID: 45979
	[Nullable(2)]
	private RoleDataBase CurSelectRole;

	// Token: 0x0200901A RID: 36890
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0403058A RID: 198026
		CaptionItem,
		// Token: 0x0403058B RID: 198027
		DynamicGroupLayout,
		// Token: 0x0403058C RID: 198028
		DynamicGroupItem,
		// Token: 0x0403058D RID: 198029
		TxtScore,
		// Token: 0x0403058E RID: 198030
		ScoreUpItem,
		// Token: 0x0403058F RID: 198031
		TxtEnvironmentLv,
		// Token: 0x04030590 RID: 198032
		TxtEnvironment,
		// Token: 0x04030591 RID: 198033
		RoleLayout,
		// Token: 0x04030592 RID: 198034
		RolePosItem,
		// Token: 0x04030593 RID: 198035
		PanelTag,
		// Token: 0x04030594 RID: 198036
		SpriteTag,
		// Token: 0x04030595 RID: 198037
		TxtTag,
		// Token: 0x04030596 RID: 198038
		BtnDetail,
		// Token: 0x04030597 RID: 198039
		BtnConfirm,
		// Token: 0x04030598 RID: 198040
		FilterSortItem
	}
}
