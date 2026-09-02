using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using FilterDefine;
using UnrealEngine;

// Token: 0x02002021 RID: 8225
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhantomManageSettingTitleItem : GridProxyAbstract<InventoryDefine.IManageConfigTitleItemData>, IStaticVariableResetter
{
	// Token: 0x0600F9F6 RID: 63990 RVA: 0x00447019 File Offset: 0x00445219
	static PhantomManageSettingTitleItem()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PhantomManageSettingTitleItem.CreateStaticDefaultValue), new Action(PhantomManageSettingTitleItem.ResetStaticDefaultValue));
	}

	// Token: 0x0600F9F7 RID: 63991 RVA: 0x00447038 File Offset: 0x00445238
	public static void CreateStaticDefaultValue()
	{
		PhantomManageSettingTitleItem.ViewModel = null;
	}

	// Token: 0x0600F9F8 RID: 63992 RVA: 0x00447040 File Offset: 0x00445240
	public static void ResetStaticDefaultValue()
	{
		PhantomManageSettingTitleItem.ViewModel = null;
	}

	// Token: 0x0600F9F9 RID: 63993 RVA: 0x00447048 File Offset: 0x00445248
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F9FA RID: 63994 RVA: 0x004470B1 File Offset: 0x004452B1
	protected override void OnStart()
	{
		PhantomManageSettingTitleItem.ViewModel.Bind(new Action<EPhantomManageConfigViewData>(this.OnViewModelUpdate));
	}

	// Token: 0x0600F9FB RID: 63995 RVA: 0x004470C9 File Offset: 0x004452C9
	protected override void OnBeforeDestroy()
	{
		PhantomManageSettingTitleItem.ViewModel.UnBind(new Action<EPhantomManageConfigViewData>(this.OnViewModelUpdate));
	}

	// Token: 0x0600F9FC RID: 63996 RVA: 0x004470E1 File Offset: 0x004452E1
	private void OnViewModelUpdate(EPhantomManageConfigViewData data)
	{
		if (data == EPhantomManageConfigViewData.SelectConfig)
		{
			this.RefreshByViewModelAsync().Forget();
			return;
		}
		if (data == EPhantomManageConfigViewData.EditState)
		{
			this.RefreshByViewModelAsync().Forget();
			return;
		}
		if (data == EPhantomManageConfigViewData.EditData)
		{
			this.RefreshByViewModelAsync().Forget();
		}
	}

	// Token: 0x0600F9FD RID: 63997 RVA: 0x00447114 File Offset: 0x00445314
	public override UniTask RefreshAsync(InventoryDefine.IManageConfigTitleItemData data, bool isSelected, int gridIndex)
	{
		PhantomManageSettingTitleItem.<RefreshAsync>d__12 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<PhantomManageSettingTitleItem.<RefreshAsync>d__12>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F9FE RID: 63998 RVA: 0x00447160 File Offset: 0x00445360
	public UniTask RefreshByViewModelAsync()
	{
		PhantomManageSettingTitleItem.<RefreshByViewModelAsync>d__13 <RefreshByViewModelAsync>d__;
		<RefreshByViewModelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshByViewModelAsync>d__.<>4__this = this;
		<RefreshByViewModelAsync>d__.<>1__state = -1;
		<RefreshByViewModelAsync>d__.<>t__builder.Start<PhantomManageSettingTitleItem.<RefreshByViewModelAsync>d__13>(ref <RefreshByViewModelAsync>d__);
		return <RefreshByViewModelAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F9FF RID: 63999 RVA: 0x004471A4 File Offset: 0x004453A4
	public override void Refresh(InventoryDefine.IManageConfigTitleItemData data, bool isSelected, int gridIndex)
	{
		PhantomManageSettingTitleItem.<>c__DisplayClass14_0 CS$<>8__locals1 = new PhantomManageSettingTitleItem.<>c__DisplayClass14_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.data = data;
		CS$<>8__locals1.isSelected = isSelected;
		CS$<>8__locals1.gridIndex = gridIndex;
		UiAsyncTask task = new UiAsyncTask("RefreshAsync", delegate()
		{
			PhantomManageSettingTitleItem.<>c__DisplayClass14_0.<<Refresh>b__0>d <<Refresh>b__0>d;
			<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
			<<Refresh>b__0>d.<>1__state = -1;
			<<Refresh>b__0>d.<>t__builder.Start<PhantomManageSettingTitleItem.<>c__DisplayClass14_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
			return <<Refresh>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task).Forget();
	}

	// Token: 0x0600FA00 RID: 64000 RVA: 0x004471F8 File Offset: 0x004453F8
	private void RrefreshTitle()
	{
		FilterRule? filterRuleConfig = ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(this.Data.FilterRuleId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), filterRuleConfig.Value.Title, Array.Empty<object>());
	}

	// Token: 0x0600FA01 RID: 64001 RVA: 0x00447240 File Offset: 0x00445440
	public void RefreshByView()
	{
		this.RefreshByViewModelAsync().Forget();
	}

	// Token: 0x0600FA02 RID: 64002 RVA: 0x0044724D File Offset: 0x0044544D
	public override object GetKey(InventoryDefine.IManageConfigTitleItemData data, int displayIndex)
	{
		return data.FilterRuleId;
	}

	// Token: 0x0600FA03 RID: 64003 RVA: 0x0044725C File Offset: 0x0044545C
	private UniTask InitLayoutAsync(int ruleId)
	{
		PhantomManageSettingTitleItem.<InitLayoutAsync>d__18 <InitLayoutAsync>d__;
		<InitLayoutAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitLayoutAsync>d__.<>4__this = this;
		<InitLayoutAsync>d__.ruleId = ruleId;
		<InitLayoutAsync>d__.<>1__state = -1;
		<InitLayoutAsync>d__.<>t__builder.Start<PhantomManageSettingTitleItem.<InitLayoutAsync>d__18>(ref <InitLayoutAsync>d__);
		return <InitLayoutAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FA04 RID: 64004 RVA: 0x004472A8 File Offset: 0x004454A8
	private void OnClickedGrid(InventoryDefine.IManageConfigSettingGridData data, bool isAdd)
	{
		if (this.GridType == InventoryDefine.ESettingGridType.Small)
		{
			PhantomManageSettingTitleItem.ViewModel.SetEditDataById(data.RuleId, data.Value, isAdd, false);
			return;
		}
		if (isAdd)
		{
			InventoryDefine.ISelectViewData selectViewData = this.GetSelectViewData(data);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomManageConfigSelectView, selectViewData, null);
			return;
		}
		PhantomManageSettingTitleItem.ViewModel.SetEditDataById(data.RuleId, data.Value, false, false);
	}

	// Token: 0x0600FA05 RID: 64005 RVA: 0x0044730C File Offset: 0x0044550C
	private void OnSelectViewConfirm(Dictionary<int, int[]> selection)
	{
		foreach (KeyValuePair<int, int[]> keyValuePair in selection)
		{
			PhantomManageSettingTitleItem.ViewModel.SetEditDataByIdList(keyValuePair.Key, keyValuePair.Value, false);
		}
	}

	// Token: 0x0600FA06 RID: 64006 RVA: 0x0044736C File Offset: 0x0044556C
	private InventoryDefine.ISelectViewData GetSelectViewData(InventoryDefine.IManageConfigSettingGridData data)
	{
		Dictionary<int, int[]> editDataByRuleId = PhantomManageSettingTitleItem.ViewModel.GetEditDataByRuleId(data.RuleId);
		Filter? filterConfig = ConfigBase<FilterConfig>.Instance.GetFilterConfig(this.Data.FilterId);
		return new InventoryDefine.SelectViewData
		{
			GridType = filterConfig.Value.GridType,
			FilterId = this.Data.FilterId,
			RuleIdList = new int[]
			{
				data.RuleId
			},
			ValueMap = editDataByRuleId,
			CallbackConfirm = new Action<Dictionary<int, int[]>>(this.OnSelectViewConfirm)
		};
	}

	// Token: 0x0600FA07 RID: 64007 RVA: 0x004473FC File Offset: 0x004455FC
	private InventoryDefine.IManageConfigSettingGridData[] GetGridData()
	{
		int filterRuleId = this.Data.FilterRuleId;
		PhantomManageConfigData selectConfig = PhantomManageSettingTitleItem.ViewModel.GetSelectConfig();
		FilterRule? filterRuleConfig = ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(filterRuleId);
		int[] array = filterRuleConfig.Value.IdList();
		bool editState = PhantomManageSettingTitleItem.ViewModel.GetEditState();
		int[] array2 = Array.Empty<int>();
		Dictionary<int, int[]> editDataByRuleId = PhantomManageSettingTitleItem.ViewModel.GetEditDataByRuleId(filterRuleId);
		int[] array3;
		if (editDataByRuleId == null || !editState)
		{
			array2 = selectConfig.GetValueListByRuleId(filterRuleId).ToArray<int>();
		}
		else if (editDataByRuleId.TryGetValue(filterRuleId, out array3))
		{
			array2 = array3;
		}
		bool flag = array2.Length == 0;
		int filterType = filterRuleConfig.Value.FilterType;
		int num = (int)InventoryDefine.recFilterRuleToGirdType[(FilterDefine.EFilterType)filterType];
		List<InventoryDefine.IManageConfigSettingGridData> list = new List<InventoryDefine.IManageConfigSettingGridData>();
		bool isEmpty = !editState && flag;
		bool isAdd = num == 2 && editState;
		InventoryDefine.ManageConfigSettingGridData item = new InventoryDefine.ManageConfigSettingGridData
		{
			IsFirst = true,
			IsEmpty = isEmpty,
			IsAdd = isAdd,
			IsSelect = false,
			IsEditing = editState,
			RuleId = filterRuleId,
			Value = 0
		};
		list.Add(item);
		foreach (int value in array)
		{
			bool isSelect = Array.IndexOf<int>(array2, value) >= 0;
			InventoryDefine.ManageConfigSettingGridData item2 = new InventoryDefine.ManageConfigSettingGridData
			{
				IsFirst = false,
				IsEmpty = false,
				IsAdd = false,
				IsSelect = isSelect,
				IsEditing = editState,
				RuleId = filterRuleId,
				Value = value
			};
			list.Add(item2);
		}
		return list.ToArray();
	}

	// Token: 0x0400781B RID: 30747
	[Nullable(2)]
	private InventoryDefine.IManageConfigTitleItemData Data;

	// Token: 0x0400781C RID: 30748
	[Nullable(2)]
	public static PhantomManageConfigViewModel ViewModel;

	// Token: 0x0400781D RID: 30749
	private InventoryDefine.ESettingGridType GridType = InventoryDefine.ESettingGridType.Small;

	// Token: 0x0400781E RID: 30750
	[Nullable(2)]
	private SettingGridLayout ItemLayout;

	// Token: 0x020083BE RID: 33726
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402CAB6 RID: 182966
		TextName,
		// Token: 0x0402CAB7 RID: 182967
		LayoutGrid
	}
}
