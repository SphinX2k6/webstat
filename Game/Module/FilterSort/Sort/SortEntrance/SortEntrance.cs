using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using FilterDefine;
using UnrealEngine;

namespace CSharpScript.Game.Module.FilterSort.Sort.SortEntrance
{
	// Token: 0x02005E36 RID: 24118
	[NullableContext(1)]
	[Nullable(0)]
	public class SortEntrance<[Nullable(2)] T> : UiPanelBase
	{
		// Token: 0x0603CB0D RID: 248589 RVA: 0x00F69DE8 File Offset: 0x00F67FE8
		public SortEntrance(UUIItem uiItem, TUpdateDataListFunction<T> updateDataListFunction)
		{
			this.UpdateDataListFunction = updateDataListFunction;
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CB0E RID: 248590 RVA: 0x00F69E50 File Offset: 0x00F68050
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.HandleSortShow));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.SortData));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CB0F RID: 248591 RVA: 0x00F69F7C File Offset: 0x00F6817C
		private void HandleSortShow(EToggleState toggleState)
		{
			if (this.IsMultipleSelect)
			{
				base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				SortViewData viewData = new SortViewData(this.ResultData.UniqueId, new Action(this.ConfirmFunction));
				ControllerBase<FilterSortController>.Instance.OpenSortView(viewData);
				return;
			}
			bool bIsUIActive = base.GetScrollViewWithScrollbar(3).RootUIComp.Get().bIsUIActive;
			this.ChangeScrollActive(!bIsUIActive);
		}

		// Token: 0x0603CB10 RID: 248592 RVA: 0x00F69FEF File Offset: 0x00F681EF
		private void ConfirmFunction()
		{
			this.SetButtonName();
			this.UpdateDataList(false);
		}

		// Token: 0x0603CB11 RID: 248593 RVA: 0x00F69FFE File Offset: 0x00F681FE
		private void SortData(EToggleState state)
		{
			this.ResultData.SetIsAscending(state == EToggleState.ETT_Checked);
			this.UpdateDataList(false);
		}

		// Token: 0x0603CB12 RID: 248594 RVA: 0x00F6A016 File Offset: 0x00F68216
		private void HideScroll()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
		}

		// Token: 0x0603CB13 RID: 248595 RVA: 0x00F6A02C File Offset: 0x00F6822C
		protected override void OnStart()
		{
			this.Scroll = new GenericScrollViewNew<SortItem, ISortData>(base.GetScrollViewWithScrollbar(3), new Func<SortItem>(this.InitSortItem), base.GetItem(4).GetOwner() as AUIBaseActor, false, null);
			base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603CB14 RID: 248596 RVA: 0x00F6A07A File Offset: 0x00F6827A
		private SortItem InitSortItem()
		{
			SortItem sortItem = new SortItem();
			sortItem.SetToggleFunction(new TSortItemToggleEvent(this.SortItemToggleEvent));
			sortItem.SetCanExecuteChange(new TCanExecuteChange(this.CanExecuteChange));
			return sortItem;
		}

		// Token: 0x0603CB15 RID: 248597 RVA: 0x00F6A0A5 File Offset: 0x00F682A5
		private void SortItemToggleEvent(int ruleId, string name)
		{
			this.ResetLastSelect();
			new KeyValuePair<int, string>(ruleId, name);
			this.ResultData.SetSelectBaseSort(new SortViewBaseSort(ruleId, name));
			this.SetButtonName();
			this.UpdateDataList(false);
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
		}

		// Token: 0x0603CB16 RID: 248598 RVA: 0x00F6A0E5 File Offset: 0x00F682E5
		private bool CanExecuteChange(int ruleId)
		{
			SortViewBaseSort selectBaseSort = this.ResultData.GetSelectBaseSort();
			return selectBaseSort == null || selectBaseSort.RuleId != ruleId;
		}

		// Token: 0x0603CB17 RID: 248599 RVA: 0x00F6A104 File Offset: 0x00F68304
		protected override void OnBeforeDestroy()
		{
			DynamicMaskButton maskButton = this.MaskButton;
			if (maskButton != null)
			{
				maskButton.Destroy(null);
			}
			this.SaveStorage();
			foreach (int uniqueId in this.UniqueIdMap.Values)
			{
				ModelBase<SortModel>.Instance.DeleteSortResultData(uniqueId);
			}
			this.UniqueIdMap.Clear();
		}

		// Token: 0x0603CB18 RID: 248600 RVA: 0x00F6A184 File Offset: 0x00F68384
		private void SaveStorage()
		{
			if (this.SaveConfigId != null && this.GroupId != EFilterSortGroupId.None)
			{
				SortStorageData data = this.ResultData.ConvertToStorageData();
				ModelBase<SortModel>.Instance.SetSortConfigData(this.SaveConfigId.Value, (int)this.GroupId, data, this.SaveConfigExtraParam);
			}
		}

		// Token: 0x0603CB19 RID: 248601 RVA: 0x00F6A1D4 File Offset: 0x00F683D4
		[NullableContext(2)]
		private void InitConfigId(EFilterSortGroupId groupId, EFilterSortConfigId? saveConfigId = null, string saveConfigExtraParam = null)
		{
			this.GroupId = groupId;
			this.ConfigId = ConfigBase<SortConfig>.Instance.GetSortId(groupId);
			this.SaveConfigId = saveConfigId;
			this.SaveConfigExtraParam = (saveConfigExtraParam ?? "");
		}

		// Token: 0x0603CB1A RID: 248602 RVA: 0x00F6A208 File Offset: 0x00F68408
		private void InitIsMultipleSelect()
		{
			this.IsMultipleSelect = (ConfigBase<SortConfig>.Instance.GetSortConfig(this.ConfigId).Value.AttributeSortListLength > 0);
		}

		// Token: 0x0603CB1B RID: 248603 RVA: 0x00F6A240 File Offset: 0x00F68440
		private void InitDataType()
		{
			this.DataType = (ESortDataType)ConfigBase<SortConfig>.Instance.GetSortConfig(this.ConfigId).Value.DataId;
		}

		// Token: 0x0603CB1C RID: 248604 RVA: 0x00F6A274 File Offset: 0x00F68474
		[NullableContext(2)]
		private void InitResultData(SortStorageData storageData = null)
		{
			int uniqueIdByGroupId = this.GetUniqueIdByGroupId(this.GroupId);
			this.ResultData = ModelBase<SortModel>.Instance.GetSortResultData(uniqueIdByGroupId);
			if (this.ResultData != null && !this.IsResultDataDirty)
			{
				return;
			}
			if (this.ResultData == null)
			{
				Sort? sortConfig = ConfigBase<SortConfig>.Instance.GetSortConfig(this.ConfigId);
				int ruleId = ((storageData != null) ? storageData.SelectBaseSort : null) ?? sortConfig.Value.GetBaseSortListArray()[0];
				string sortRuleName = ConfigBase<SortConfig>.Instance.GetSortRuleName(ruleId, this.DataType);
				this.ResultData = new SortResultData();
				this.ResultData.SetConfigId(this.ConfigId);
				this.ResultData.SetSelectBaseSort(new SortViewBaseSort(ruleId, sortRuleName));
				UUIExtendToggle extendToggle = base.GetExtendToggle(2);
				if (storageData != null)
				{
					bool isAscending = storageData.IsAscending;
					this.ResultData.SetIsAscending(storageData.IsAscending);
				}
				else
				{
					this.ResultData.SetIsAscending(extendToggle.GetToggleState() == EToggleState.ETT_Checked);
				}
				if (((storageData != null) ? storageData.SelectAttributeSort : null) != null && storageData.SelectAttributeSort.Count > 0)
				{
					Dictionary<int, string> dictionary = new Dictionary<int, string>();
					foreach (int num in storageData.SelectAttributeSort)
					{
						string sortRuleName2 = ConfigBase<SortConfig>.Instance.GetSortRuleName(num, this.DataType);
						dictionary.Add(num, sortRuleName2);
					}
					this.ResultData.SetSelectAttributeSort(dictionary);
				}
				ModelBase<SortModel>.Instance.SetSortResultData(this.ResultData);
				this.UniqueIdMap.Add((int)this.GroupId, this.ResultData.UniqueId);
			}
			if (this.IsResultDataDirty)
			{
				SortViewBaseSort selectBaseSort = this.ResultData.GetSelectBaseSort();
				if (selectBaseSort != null)
				{
					string sortRuleName3 = ConfigBase<SortConfig>.Instance.GetSortRuleName(selectBaseSort.RuleId, this.DataType);
					selectBaseSort.RuleName = sortRuleName3;
				}
				this.IsResultDataDirty = false;
			}
		}

		// Token: 0x0603CB1D RID: 248605 RVA: 0x00F6A484 File Offset: 0x00F68684
		private void ChangeScrollActive(bool value)
		{
			this.Scroll.SetActive(value);
			if (value)
			{
				this.ShowMaskButton().Forget();
				return;
			}
			this.HideMaskButton();
		}

		// Token: 0x0603CB1E RID: 248606 RVA: 0x00F6A4A8 File Offset: 0x00F686A8
		private void InitSort()
		{
			this.ChangeScrollActive(false);
			if (this.IsMultipleSelect)
			{
				return;
			}
			Sort? sortConfig = ConfigBase<SortConfig>.Instance.GetSortConfig(this.ConfigId);
			List<ISortData> list = new List<ISortData>();
			int ruleId = this.ResultData.GetSelectBaseSort().RuleId;
			foreach (int ruleId2 in sortConfig.Value.GetBaseSortListArray())
			{
				list.Add(new SortData
				{
					RuleId = ruleId2,
					DataType = this.DataType,
					SelectedRule = ruleId
				});
			}
			this.Scroll.RefreshByData(list, null, false);
		}

		// Token: 0x0603CB1F RID: 248607 RVA: 0x00F6A54C File Offset: 0x00F6874C
		private void InitSortToggle()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			EToggleState state = this.ResultData.GetIsAscending() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			extendToggle.SetToggleState(state, false, false, false);
		}

		// Token: 0x0603CB20 RID: 248608 RVA: 0x00F6A57C File Offset: 0x00F6877C
		private void ResetLastSelect()
		{
			SortViewBaseSort selectBaseSort = this.ResultData.GetSelectBaseSort();
			this.Scroll.GetScrollItemByKey(selectBaseSort.RuleId).SetToggleStateForce(false);
		}

		// Token: 0x0603CB21 RID: 248609 RVA: 0x00F6A5B4 File Offset: 0x00F687B4
		private void SetButtonName()
		{
			string newText = this.ResultData.ShowAllSortContent();
			base.GetText(1).SetText(newText, true);
		}

		// Token: 0x0603CB22 RID: 248610 RVA: 0x00F6A5DC File Offset: 0x00F687DC
		private void UpdateDataList(bool isOutSideChange)
		{
			List<T> dataList = this.DataList;
			FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.FilterUniqueId);
			if (filterResultData != null)
			{
				int filterId = ConfigBase<FilterConfig>.Instance.GetFilterId(this.GroupId);
				Dictionary<FilterDefine.EFilterType, Dictionary<int, string>> selectRuleData = filterResultData.GetSelectRuleData();
				dataList = ModelBase<FilterModel>.Instance.GetFilterList<T>(dataList, filterId, selectRuleData);
			}
			ModelBase<SortModel>.Instance.SortDataList<T>(dataList, this.ConfigId, this.ResultData, this.ExtraParams.ToArray());
			TUpdateDataListFunction<T> updateDataListFunction = this.UpdateDataListFunction;
			if (updateDataListFunction == null)
			{
				return;
			}
			updateDataListFunction(dataList, isOutSideChange, EFilterSortType.Sort);
		}

		// Token: 0x0603CB23 RID: 248611 RVA: 0x00F6A660 File Offset: 0x00F68860
		private UniTask ShowMaskButton()
		{
			SortEntrance<T>.<ShowMaskButton>d__38 <ShowMaskButton>d__;
			<ShowMaskButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowMaskButton>d__.<>4__this = this;
			<ShowMaskButton>d__.<>1__state = -1;
			<ShowMaskButton>d__.<>t__builder.Start<SortEntrance<T>.<ShowMaskButton>d__38>(ref <ShowMaskButton>d__);
			return <ShowMaskButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603CB24 RID: 248612 RVA: 0x00F6A6A3 File Offset: 0x00F688A3
		private void HideMaskButton()
		{
			if (this.MaskButton == null)
			{
				return;
			}
			this.MaskButton.ResetItemParent();
			this.MaskButton.SetActive(false);
		}

		// Token: 0x0603CB25 RID: 248613 RVA: 0x00F6A6C5 File Offset: 0x00F688C5
		private void HandleSortActive()
		{
			this.SetActive(this.ConfigId > 0);
		}

		// Token: 0x0603CB26 RID: 248614 RVA: 0x00F6A6D8 File Offset: 0x00F688D8
		public void UpdateData(EFilterSortGroupId groupId, List<T> dataList, params object[] parameters)
		{
			this.InitConfigId(groupId, null, null);
			this.HandleSortActive();
			if (this.ConfigId <= 0)
			{
				return;
			}
			this.DataList = dataList;
			this.ExtraParams = new List<object>(parameters);
			this.InitIsMultipleSelect();
			this.InitDataType();
			this.InitResultData(null);
			this.InitSort();
			this.InitSortToggle();
			this.SetButtonName();
			this.UpdateDataList(true);
		}

		// Token: 0x0603CB27 RID: 248615 RVA: 0x00F6A748 File Offset: 0x00F68948
		public void UpdateDataWithConfig(EFilterSortGroupId groupId, EFilterSortConfigId saveConfigId, List<T> dataList, string saveConfigExtraParam = "", params object[] parameters)
		{
			FilterSortConfig sortFilterConfig = ConfigBase<SortConfig>.Instance.GetSortFilterConfig(saveConfigId);
			if (sortFilterConfig.SaveMode == 2 || sortFilterConfig.SaveMode == 3)
			{
				this.UpdateData(groupId, dataList, parameters);
				return;
			}
			this.SaveStorage();
			this.InitConfigId(groupId, new EFilterSortConfigId?(saveConfigId), saveConfigExtraParam);
			this.HandleSortActive();
			if (this.ConfigId <= 0)
			{
				return;
			}
			this.DataList = dataList;
			this.ExtraParams = new List<object>(parameters);
			this.InitIsMultipleSelect();
			this.InitDataType();
			SortStorageData sortConfigData = ModelBase<SortModel>.Instance.GetSortConfigData(saveConfigId, (int)this.GroupId, saveConfigExtraParam);
			this.InitResultData(sortConfigData);
			this.InitSort();
			this.InitSortToggle();
			this.SetButtonName();
			this.UpdateDataList(true);
		}

		// Token: 0x0603CB28 RID: 248616 RVA: 0x00F6A7F9 File Offset: 0x00F689F9
		public void SetResultDataDirty()
		{
			this.IsResultDataDirty = true;
		}

		// Token: 0x0603CB29 RID: 248617 RVA: 0x00F6A804 File Offset: 0x00F68A04
		public void SetSortToggleState(bool isAscending)
		{
			EToggleState state = isAscending ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(2).SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x0603CB2A RID: 248618 RVA: 0x00F6A82C File Offset: 0x00F68A2C
		public int GetUniqueIdByGroupId(EFilterSortGroupId groupId)
		{
			int result;
			if (this.UniqueIdMap.TryGetValue((int)groupId, out result))
			{
				return result;
			}
			return -1;
		}

		// Token: 0x0603CB2B RID: 248619 RVA: 0x00F6A84C File Offset: 0x00F68A4C
		public void DeleteUniqueIdByGroupId(EFilterSortGroupId groupId)
		{
			int uniqueId;
			if (this.UniqueIdMap.TryGetValue((int)groupId, out uniqueId))
			{
				ModelBase<SortModel>.Instance.DeleteSortResultData(uniqueId);
				this.UniqueIdMap.Remove((int)groupId);
			}
		}

		// Token: 0x0603CB2C RID: 248620 RVA: 0x00F6A881 File Offset: 0x00F68A81
		public void SetFilterUniqueId(int uniqueId)
		{
			this.FilterUniqueId = uniqueId;
		}

		// Token: 0x0402214F RID: 139599
		private readonly Dictionary<int, int> UniqueIdMap = new Dictionary<int, int>();

		// Token: 0x04022150 RID: 139600
		private int FilterUniqueId = -1;

		// Token: 0x04022151 RID: 139601
		[Nullable(2)]
		private SortResultData ResultData;

		// Token: 0x04022152 RID: 139602
		private bool IsResultDataDirty;

		// Token: 0x04022153 RID: 139603
		private EFilterSortGroupId GroupId = EFilterSortGroupId.Role;

		// Token: 0x04022154 RID: 139604
		private int ConfigId;

		// Token: 0x04022155 RID: 139605
		private EFilterSortConfigId? SaveConfigId;

		// Token: 0x04022156 RID: 139606
		private string SaveConfigExtraParam = "";

		// Token: 0x04022157 RID: 139607
		private ESortDataType DataType = ESortDataType.Role;

		// Token: 0x04022158 RID: 139608
		private List<T> DataList = new List<T>();

		// Token: 0x04022159 RID: 139609
		private List<object> ExtraParams = new List<object>();

		// Token: 0x0402215A RID: 139610
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<SortItem, ISortData> Scroll;

		// Token: 0x0402215B RID: 139611
		private bool IsMultipleSelect;

		// Token: 0x0402215C RID: 139612
		[Nullable(2)]
		private DynamicMaskButton MaskButton;

		// Token: 0x0402215D RID: 139613
		protected TUpdateDataListFunction<T> UpdateDataListFunction;

		// Token: 0x0200BE69 RID: 48745
		[NullableContext(0)]
		private enum ECompDefine
		{
			// Token: 0x0403AA0E RID: 240142
			Toggle,
			// Token: 0x0403AA0F RID: 240143
			Name,
			// Token: 0x0403AA10 RID: 240144
			SortToggle,
			// Token: 0x0403AA11 RID: 240145
			SortScroll,
			// Token: 0x0403AA12 RID: 240146
			SortItem
		}
	}
}
