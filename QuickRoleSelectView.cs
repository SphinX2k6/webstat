using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002798 RID: 10136
[NullableContext(1)]
[Nullable(0)]
public class QuickRoleSelectView : UiViewBase
{
	// Token: 0x06014017 RID: 81943 RVA: 0x005939F9 File Offset: 0x00591BF9
	public QuickRoleSelectView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06014018 RID: 81944 RVA: 0x00593A04 File Offset: 0x00591C04
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIInteractionGroup)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.ConfirmClick)),
			new ValueTuple<int, Delegate>(4, new Action(this.BackClick)),
			new ValueTuple<int, Delegate>(12, new Action(this.OnDetailClick))
		};
	}

	// Token: 0x06014019 RID: 81945 RVA: 0x00593BDC File Offset: 0x00591DDC
	private void ConfirmClick()
	{
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		List<int> list = new List<int>();
		for (int i = 1; i <= 3; i++)
		{
			RoleDataBase roleDataBase;
			if (roleIndexMap.TryGetValue(i, out roleDataBase))
			{
				list.Add(roleDataBase.GetDataId());
			}
		}
		QuickRoleSelectViewData data = this.Data;
		Func<int[], bool> func = (data != null) ? data.CanConfirm : null;
		if (func != null && !func(list.ToArray()))
		{
			return;
		}
		QuickRoleSelectViewData data2 = this.Data;
		if (((data2 != null) ? data2.OnWaitLoadingConfirm : null) == null)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.TowerDefenseBeforeConfirmQuickRoleSelect);
			QuickRoleSelectViewData data3 = this.Data;
			if (data3 != null)
			{
				Action<int[]> onConfirm = data3.OnConfirm;
				if (onConfirm != null)
				{
					onConfirm(list.ToArray());
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.TowerDefenseBeforeConfirmQuickRoleSelect);
			Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
			return;
		}
		this.ShowLoading();
		QuickRoleSelectViewData data4 = this.Data;
		if (data4 == null)
		{
			return;
		}
		data4.OnWaitLoadingConfirm(list).ContinueWith(delegate()
		{
			base.CloseMe(null);
		});
	}

	// Token: 0x0601401A RID: 81946 RVA: 0x00593CE0 File Offset: 0x00591EE0
	private void ShowLoading()
	{
		if (this.DelayLoadingTimer == null)
		{
			base.GetItem(14).SetUIActive(true);
			this.DelayLoadingTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				UUIButtonComponent button = base.GetButton(4);
				if (button != null)
				{
					button.RootUIComp.Get().SetUIActive(false);
				}
				UUIItem item = base.GetItem(13);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UiSequencePlayer loadingSequencePlayer = this.LoadingSequencePlayer;
				if (loadingSequencePlayer == null)
				{
					return;
				}
				loadingSequencePlayer.PlaySequence("Progressing", false, null);
			}, 500f, null, null, true, 1f);
		}
		if (this.AutoCloseTimer == null)
		{
			this.AutoCloseTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				Singleton<UiManager>.Instance.ResetToBattleView(null);
			}, 30000f, null, null, true, 1f);
		}
	}

	// Token: 0x0601401B RID: 81947 RVA: 0x00593D70 File Offset: 0x00591F70
	private void BackClick()
	{
		QuickRoleSelectViewData data = this.Data;
		if (data != null)
		{
			Action onBack = data.OnBack;
			if (onBack != null)
			{
				onBack();
			}
		}
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
	}

	// Token: 0x0601401C RID: 81948 RVA: 0x00593DA4 File Offset: 0x00591FA4
	private unsafe void OnDetailClick()
	{
		int num = this.LastAddFormationRoleId;
		List<int> list = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.ToList<int>();
		if (list.Count > 0 && num == 0)
		{
			List<int> list2 = list;
			num = list2[list2.Count - 1];
		}
		List<int> list3;
		if (num < 100000)
		{
			list3 = ModelBase<RoleModel>.Instance.GetRoleIdList();
		}
		else
		{
			int num2 = 1;
			List<int> list4 = new List<int>(num2);
			CollectionsMarshal.SetCount<int>(list4, num2);
			list3 = list4;
			Span<int> span = CollectionsMarshal.AsSpan<int>(list4);
			int index = 0;
			*span[index] = num;
		}
		List<int> roleIdList = list3;
		ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, num, roleIdList, null, delegate(bool success, int _)
		{
			if (success)
			{
				Singleton<EventSystem>.Instance.Add(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
				Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
				ModelBase<RoleModel>.Instance.StartRecordRoleSkillBranchChangeRequest();
			}
		});
	}

	// Token: 0x0601401D RID: 81949 RVA: 0x00593E40 File Offset: 0x00592040
	private void OnCloseView(EUiViewName viewName, int i)
	{
		if (viewName == EUiViewName.RoleRootView)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
			List<int> list = ModelBase<RoleModel>.Instance.StopRecordRoleSkillBranchChangeRequest();
			if (list.Count > 0 && this.RoleScrollView != null && this.RoleList != null)
			{
				for (int j = 0; j < list.Count; j++)
				{
					int num = list[j];
					for (int k = 0; k < this.RoleList.Count; k++)
					{
						if (this.RoleList[k].GetDataId() == num)
						{
							this.RoleScrollView.RefreshGridProxy(k);
							break;
						}
					}
				}
			}
		}
	}

	// Token: 0x0601401E RID: 81950 RVA: 0x00593F07 File Offset: 0x00592107
	private void OnRoleChangeEnd()
	{
		base.CloseMe(null);
	}

	// Token: 0x0601401F RID: 81951 RVA: 0x00593F10 File Offset: 0x00592110
	protected override void OnStart()
	{
		this.Data = (this.OpenParam as QuickRoleSelectViewData);
		this.RoleScrollView = new LoopScrollView<TeamRoleGrid, RoleDataBase>(base.GetLoopScrollViewComponent(1), base.GetItem(10).GetOwner() as AUIBaseActor, new Func<TeamRoleGrid>(this.OnGridProxyCreate), false);
		this.LoadingSequencePlayer = new UiSequencePlayer(base.GetItem(13));
		UUIText text = base.GetText(15);
		if (text != null)
		{
			text.SetUIActive(ModelBase<MowingTowerModel>.Instance.CurrentOptionArea != -1);
		}
		int[] addLevel = ModelBase<MowingTowerModel>.Instance.AddLevel;
		if (addLevel != null && addLevel.Length != 0)
		{
			int num = addLevel[0];
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "MowTower_LevelTips", new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				num
			}));
		}
		bool flag = this.Data != null && !string.IsNullOrEmpty(this.Data.YellowTipText);
		base.GetButton(12).RootUIComp.Get().SetUIActive(this.Data.ShowDetailButton && !flag);
		UUIItem item = base.GetItem(16);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		if (this.Data != null && !string.IsNullOrEmpty(this.Data.YellowTipText))
		{
			UUIText text2 = base.GetText(17);
			if (text2 != null)
			{
				text2.SetText(this.Data.YellowTipText, true);
			}
		}
		this.RefreshRoleList();
	}

	// Token: 0x06014020 RID: 81952 RVA: 0x00594080 File Offset: 0x00592280
	protected void RefreshRoleList()
	{
		QuickRoleSelectViewData data = this.Data;
		this.RoleList = ((data != null) ? data.RoleList : null);
		QuickRoleSelectViewData data2 = this.Data;
		int[] array = (data2 != null) ? data2.SelectedRoleList : null;
		ModelBase<RoleSelectModel>.Instance.ClearData();
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		HashSet<int> selectedRoleSet = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet;
		if (array != null && this.RoleList != null)
		{
			int num = 1;
			while (num <= 3 && num <= array.Length)
			{
				int num2 = array[num - 1];
				foreach (RoleDataBase roleDataBase in this.RoleList)
				{
					if (roleDataBase.GetDataId() == num2)
					{
						roleIndexMap[num] = roleDataBase;
						selectedRoleSet.Add(roleDataBase.GetDataId());
						break;
					}
				}
				num++;
			}
		}
		if (this.Data == null || this.Data.UseWay == null || this.RoleList == null)
		{
			return;
		}
		UUIItem item = base.GetItem(8);
		this.FilterSortEntrance = new FilterSortEntrance<RoleDataBase>(item, new TUpdateDataListFunction<RoleDataBase>(this.UpdateRoleList));
		this.RoleList.Sort((RoleDataBase a, RoleDataBase b) => b.GetRoleConfig().Priority - a.GetRoleConfig().Priority);
		this.FilterSortEntrance.UpdateData(this.Data.UseWay.Value, this.RoleList, Array.Empty<object>());
		base.GetItem(5).SetUIActive(false);
		base.GetText(9).SetUIActive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "FastFormation_Finish", Array.Empty<object>());
		this.RefreshConfirmBtn();
	}

	// Token: 0x06014021 RID: 81953 RVA: 0x00594238 File Offset: 0x00592438
	protected override void OnBeforeDestroy()
	{
		QuickRoleSelectViewData data = this.Data;
		if (data != null)
		{
			Action onHideFinish = data.OnHideFinish;
			if (onHideFinish != null)
			{
				onHideFinish();
			}
		}
		this.Data = null;
		FilterSortEntrance<RoleDataBase> filterSortEntrance = this.FilterSortEntrance;
		if (filterSortEntrance != null)
		{
			filterSortEntrance.Destroy(null);
		}
		this.FilterSortEntrance = null;
		LoopScrollView<TeamRoleGrid, RoleDataBase> roleScrollView = this.RoleScrollView;
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
		if (this.DelayLoadingTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.DelayLoadingTimer);
			this.DelayLoadingTimer = null;
		}
		if (this.AutoCloseTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AutoCloseTimer);
			this.AutoCloseTimer = null;
		}
	}

	// Token: 0x06014022 RID: 81954 RVA: 0x005942F1 File Offset: 0x005924F1
	private TeamRoleGrid OnGridProxyCreate()
	{
		TeamRoleGrid teamRoleGrid = new TeamRoleGrid();
		teamRoleGrid.IsShowGray = new Func<int, bool>(this.IsShowGray);
		teamRoleGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.ToggleFunction));
		teamRoleGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChange));
		return teamRoleGrid;
	}

	// Token: 0x06014023 RID: 81955 RVA: 0x0059432F File Offset: 0x0059252F
	protected bool IsShowGray(int roleId)
	{
		QuickRoleSelectViewData data = this.Data;
		return data == null || !data.CanUseSpecialTrialRole || !RoleUtils.IsSpecialTrialRole(roleId);
	}

	// Token: 0x06014024 RID: 81956 RVA: 0x00594350 File Offset: 0x00592550
	protected void ToggleFunction(MediumItemGridExtendCallback @params)
	{
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		HashSet<int> selectedRoleSet = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet;
		RoleDataBase roleDataBase = @params.Data as RoleDataBase;
		if (roleDataBase == null)
		{
			return;
		}
		if (@params.State == EToggleState.ETT_UnChecked)
		{
			using (List<KeyValuePair<int, RoleDataBase>>.Enumerator enumerator = roleIndexMap.ToList<KeyValuePair<int, RoleDataBase>>().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, RoleDataBase> keyValuePair = enumerator.Current;
					if (keyValuePair.Value == roleDataBase)
					{
						roleIndexMap.Remove(keyValuePair.Key);
						selectedRoleSet.Remove(roleDataBase.GetDataId());
						this.LastAddFormationRoleId = 0;
						break;
					}
				}
				goto IL_D4;
			}
		}
		if (@params.State == EToggleState.ETT_Checked)
		{
			for (int i = 1; i <= 3; i++)
			{
				if (!roleIndexMap.ContainsKey(i))
				{
					roleIndexMap[i] = roleDataBase;
					selectedRoleSet.Add(roleDataBase.GetDataId());
					this.LastAddFormationRoleId = roleDataBase.GetDataId();
					break;
				}
			}
		}
		IL_D4:
		if (this.RoleList == null || this.RoleScrollView == null)
		{
			return;
		}
		int gridIndex = this.RoleList.IndexOf(roleDataBase);
		this.RoleScrollView.RefreshGridProxy(gridIndex);
		this.RefreshConfirmBtn();
	}

	// Token: 0x06014025 RID: 81957 RVA: 0x00594474 File Offset: 0x00592674
	private void RefreshConfirmBtn()
	{
		if (this.Data == null || !this.Data.IsNeedChangeBtnState || this.Data.CanConfirm == null)
		{
			return;
		}
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		List<int> list = new List<int>();
		for (int i = 1; i <= 3; i++)
		{
			RoleDataBase roleDataBase;
			if (roleIndexMap.TryGetValue(i, out roleDataBase))
			{
				list.Add(roleDataBase.GetDataId());
			}
		}
		UUIButtonComponent button = base.GetButton(3);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(this.Data.CanConfirm(list.ToArray()));
	}

	// Token: 0x06014026 RID: 81958 RVA: 0x00594500 File Offset: 0x00592700
	protected virtual bool CanExecuteChange(object data, bool isForceSelected, EToggleState state)
	{
		if (state != EToggleState.ETT_UnChecked)
		{
			return true;
		}
		RoleDataBase roleDataBase = data as RoleDataBase;
		if (roleDataBase == null)
		{
			return false;
		}
		int roleId = roleDataBase.GetRoleId();
		List<int> otherHalfAreaRoleList = ModelBase<MowingTowerModel>.Instance.OtherHalfAreaRoleList;
		if (otherHalfAreaRoleList != null && otherHalfAreaRoleList.Contains(roleId))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("EditBattleTeamCannotSwitchOtherArea", Array.Empty<object>());
			return false;
		}
		if (ModelBase<RoleSelectModel>.Instance.RoleIndexMap.Count >= 3)
		{
			QuickRoleSelectViewData data2 = this.Data;
			if (((data2 != null) ? data2.OnRoleSelectFull : null) != null)
			{
				QuickRoleSelectViewData data3 = this.Data;
				if (data3 != null)
				{
					data3.OnRoleSelectFull();
				}
			}
			else
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamRoleFull", Array.Empty<object>());
			}
			return false;
		}
		QuickRoleSelectViewData data4 = this.Data;
		if ((data4 == null || !data4.CanUseSpecialTrialRole) && RoleUtils.IsSpecialTrialRole(roleDataBase.GetDataId()))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PrefabTextItem_1024721374_Text", Array.Empty<object>());
			return false;
		}
		QuickRoleSelectViewData data5 = this.Data;
		Func<int, int[], bool> func = (data5 != null) ? data5.CanSelectRole : null;
		if (func != null)
		{
			int[] arg = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.ToArray<int>();
			if (!func(roleDataBase.GetDataId(), arg))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06014027 RID: 81959 RVA: 0x0059461C File Offset: 0x0059281C
	private void UpdateRoleList(List<RoleDataBase> list, bool isShowText, EFilterSortType type)
	{
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		List<RoleDataBase> list2 = new List<RoleDataBase>();
		for (int i = 1; i <= 3; i++)
		{
			RoleDataBase item;
			if (roleIndexMap.TryGetValue(i, out item))
			{
				list2.Add(item);
			}
		}
		foreach (RoleDataBase item2 in list)
		{
			if (!list2.Contains(item2))
			{
				list2.Add(item2);
			}
		}
		bool flag = list2.Count > 0;
		base.GetItem(11).SetUIActive(!flag);
		base.GetButton(3).RootUIComp.Get().SetUIActive(flag);
		bool flag2 = this.Data != null && !string.IsNullOrEmpty(this.Data.YellowTipText);
		base.GetItem(16).SetUIActive(flag2 && flag);
		base.GetButton(12).RootUIComp.Get().SetUIActive(this.Data.ShowDetailButton && !flag2 && flag);
		base.GetLoopScrollViewComponent(1).RootUIComp.Get().SetUIActive(flag);
		if (!flag)
		{
			return;
		}
		if (this.RoleScrollView == null || this.RoleList == null)
		{
			return;
		}
		this.RoleScrollView.RefreshByData(list2, false, null, false);
		foreach (RoleDataBase roleDataBase in roleIndexMap.Values)
		{
			int num = this.RoleList.IndexOf(roleDataBase);
			int num2 = list2.IndexOf(roleDataBase);
			if (this.RoleScrollView.StartGridIndex >= 0 && num != num2 && num < this.RoleScrollView.GetDisplayGridEndIndex())
			{
				ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Remove(roleDataBase.GetDataId());
				TeamRoleGrid teamRoleGrid = this.RoleScrollView.UnsafeGetGridProxy(num, false);
				if (teamRoleGrid != null)
				{
					teamRoleGrid.OnDeselected(false);
				}
			}
		}
		foreach (RoleDataBase roleDataBase2 in roleIndexMap.Values)
		{
			int gridIndex = list2.IndexOf(roleDataBase2);
			ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Add(roleDataBase2.GetDataId());
			TeamRoleGrid teamRoleGrid2 = this.RoleScrollView.UnsafeGetGridProxy(gridIndex, false);
			if (teamRoleGrid2 != null)
			{
				teamRoleGrid2.OnForceSelected();
			}
		}
		this.RoleList = list2;
	}

	// Token: 0x04009BDD RID: 39901
	[Nullable(2)]
	protected QuickRoleSelectViewData Data;

	// Token: 0x04009BDE RID: 39902
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected FilterSortEntrance<RoleDataBase> FilterSortEntrance;

	// Token: 0x04009BDF RID: 39903
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<TeamRoleGrid, RoleDataBase> RoleScrollView;

	// Token: 0x04009BE0 RID: 39904
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected List<RoleDataBase> RoleList;

	// Token: 0x04009BE1 RID: 39905
	[Nullable(2)]
	protected TimerHandle DelayLoadingTimer;

	// Token: 0x04009BE2 RID: 39906
	[Nullable(2)]
	protected TimerHandle AutoCloseTimer;

	// Token: 0x04009BE3 RID: 39907
	[Nullable(2)]
	protected UiSequencePlayer LoadingSequencePlayer;

	// Token: 0x04009BE4 RID: 39908
	private int LastAddFormationRoleId;

	// Token: 0x02008B4F RID: 35663
	[NullableContext(0)]
	public enum EComponentType
	{
		// Token: 0x0402EF54 RID: 192340
		ConfirmButtonInteractionGroup,
		// Token: 0x0402EF55 RID: 192341
		RoleScroll,
		// Token: 0x0402EF56 RID: 192342
		ConfirmText,
		// Token: 0x0402EF57 RID: 192343
		ConfirmButton,
		// Token: 0x0402EF58 RID: 192344
		CloseButton,
		// Token: 0x0402EF59 RID: 192345
		BottomGroup,
		// Token: 0x0402EF5A RID: 192346
		TeamRoleOne,
		// Token: 0x0402EF5B RID: 192347
		TeamRoleTwo,
		// Token: 0x0402EF5C RID: 192348
		FilterSortEntrance,
		// Token: 0x0402EF5D RID: 192349
		TipsText,
		// Token: 0x0402EF5E RID: 192350
		RoleItem,
		// Token: 0x0402EF5F RID: 192351
		NoneRoleTips,
		// Token: 0x0402EF60 RID: 192352
		DetailButton,
		// Token: 0x0402EF61 RID: 192353
		LoadingItem,
		// Token: 0x0402EF62 RID: 192354
		DisableClickMask,
		// Token: 0x0402EF63 RID: 192355
		BottomTipsText,
		// Token: 0x0402EF64 RID: 192356
		ItemYellowTipPanel,
		// Token: 0x0402EF65 RID: 192357
		TextYellowTip
	}
}
