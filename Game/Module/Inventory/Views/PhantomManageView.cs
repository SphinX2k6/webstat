using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using FilterDefine;
using UnrealEngine;

namespace CSharpScript.Game.Module.Inventory.Views
{
	// Token: 0x02005B91 RID: 23441
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomManageView : UiViewBase
	{
		// Token: 0x0603B457 RID: 242775 RVA: 0x00F016A6 File Offset: 0x00EFF8A6
		public PhantomManageView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603B458 RID: 242776 RVA: 0x00F016BC File Offset: 0x00EFF8BC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 20;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 7;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickedBtnClose));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action<EToggleState>(this.OnClickedBtnSelectAll));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnClickedBtnClearSelect));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickedBtnConfig));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(17, new Action(this.OnClickedBtnSmartDiscard));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(18, new Action(this.OnClickedBtnManage));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(19, new Action<EToggleState>(this.OnToggleShowStrengthened));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B459 RID: 242777 RVA: 0x00F01A9C File Offset: 0x00EFFC9C
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomManageView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomManageView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B45A RID: 242778 RVA: 0x00F01AE0 File Offset: 0x00EFFCE0
		protected override void OnStart()
		{
			this.ViewModel = new PhantomManageViewModel();
			this.ViewModel.Bind(new Action<EPhantomManageViewData>(this.OnViewModelUpdate));
			this.ItemScroll = new LoopScrollView<PhantomManageMediumItemGrid, PhantomItemData>(base.GetLoopScrollViewComponent(4), base.GetItem(5).GetOwner() as AUIBaseActor, new Func<PhantomManageMediumItemGrid>(this.InitItem), false);
			PhantomManageMediumItemGrid.CallbackCheckTips = new Func<PhantomItemData, bool>(this.CheckItemTips);
			PhantomManageMediumItemGrid.CallbackCheckSelect = new Func<PhantomItemData, bool>(this.CheckItemSelect);
			PhantomManageMediumItemGrid.CallbackListenerFocus = new Action<PhantomItemData>(this.OnListenerFocus);
			this.FilterEntrance = new FilterEntrance<PhantomItemData>(base.GetItem(8), new TUpdateDataListFunction<PhantomItemData>(this.OnFilterSortRefresh));
			this.CaptionItem = new PopupCaptionItem(base.GetItem(1));
			this.CaptionItem.SetHelpBtnActive(false);
			this.CaptionItem.SetCloseBtnShowState(false);
		}

		// Token: 0x0603B45B RID: 242779 RVA: 0x00F01BBC File Offset: 0x00EFFDBC
		protected override void OnBeforeShow()
		{
			this.OpenParamId = (this.OpenParam as int?).GetValueOrDefault();
			if (((this.OpenParamId > 0) ? ModelBase<InventoryModel>.Instance.GetPhantomItemData(this.OpenParamId) : null) != null)
			{
				this.SelectId = this.OpenParamId;
			}
			else
			{
				this.SelectId = 0;
			}
			base.SetButtonUiActive(11, false);
			this.RefreshCapacity();
			this.ClearInvalidSelectItems();
			this.RefreshList();
			this.RefreshBtn();
		}

		// Token: 0x0603B45C RID: 242780 RVA: 0x00F01C3C File Offset: 0x00EFFE3C
		private void ClearInvalidSelectItems()
		{
			foreach (int uniqueId in this.ViewModel.GetSelectSet().ToList<int>())
			{
				if (ModelBase<InventoryModel>.Instance.GetPhantomItemData(uniqueId) == null)
				{
					this.ViewModel.GetSelectSet().Clear();
					break;
				}
			}
		}

		// Token: 0x0603B45D RID: 242781 RVA: 0x00F01CB4 File Offset: 0x00EFFEB4
		protected override void OnBeforeDestroy()
		{
			this.ViewModel.UnBind(new Action<EPhantomManageViewData>(this.OnViewModelUpdate));
			this.ViewModel.ClearSelectSet();
			this.ClearFilterData();
		}

		// Token: 0x0603B45E RID: 242782 RVA: 0x00F01CE0 File Offset: 0x00EFFEE0
		private void RefreshCapacity()
		{
			ItemMainType? itemMainTypeConfig = ConfigBase<InventoryConfig>.Instance.GetItemMainTypeConfig(3);
			if (itemMainTypeConfig == null)
			{
				return;
			}
			int packageId = itemMainTypeConfig.Value.PackageId;
			PackageCapacity? packageConfig = ConfigBase<InventoryConfig>.Instance.GetPackageConfig(packageId);
			int count = ModelBase<InventoryModel>.Instance.GetItemDataBaseByMainType(InventoryDefine.EItemMainTypeId.Phantom).Count;
			int num = 0;
			if (packageConfig != null)
			{
				num = packageConfig.Value.Capacity;
			}
			UUIText text = base.GetText(2);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (count >= num)
			{
				UUIText uuitext = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=red>");
				defaultInterpolatedStringHandler.AppendFormatted<int>(count);
				defaultInterpolatedStringHandler.AppendLiteral("</color>/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				return;
			}
			UUIText uuitext2 = text;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(count);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			uuitext2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603B45F RID: 242783 RVA: 0x00F01DD8 File Offset: 0x00EFFFD8
		private void RefreshList()
		{
			IEnumerable<PhantomItemData> enumerable = ModelBase<InventoryModel>.Instance.GetItemDataBaseByMainType(InventoryDefine.EItemMainTypeId.Phantom).Cast<PhantomItemData>();
			List<PhantomItemData> list = new List<PhantomItemData>();
			foreach (PhantomItemData phantomItemData in enumerable)
			{
				PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(phantomItemData.GetUniqueId());
				if (phantomBattleData != null && (this.ShowStrengthened || phantomBattleData.GetPhantomLevel() <= 0))
				{
					list.Add(phantomItemData);
				}
			}
			this.FilterEntrance.UpdateDataWithConfig(EFilterSortGroupId.PhantomManage, EFilterSortConfigId.PhantomManage, list, "", Array.Empty<object>());
		}

		// Token: 0x0603B460 RID: 242784 RVA: 0x00F01E74 File Offset: 0x00F00074
		private void RefreshItem(PhantomItemData itemData)
		{
			this.RefreshTips(itemData);
			this.RefreshRedDot(itemData);
			this.RefreshNew(itemData);
			this.RefreshSelect(itemData);
		}

		// Token: 0x0603B461 RID: 242785 RVA: 0x00F01E94 File Offset: 0x00F00094
		private void RefreshTips(PhantomItemData itemData)
		{
			int configId = itemData.GetConfigId();
			int uniqueId = itemData.GetUniqueId();
			ItemTipsData tipsDataById = ItemTipsComponentUtilTool.GetTipsDataById(configId, new int?(uniqueId), null);
			if (tipsDataById != null)
			{
				this.ItemTipsComponent.RefreshTips(tipsDataById);
				this.ItemTipsComponent.SetVisible(true);
			}
			else
			{
				this.ItemTipsComponent.SetVisible(false);
			}
			this.ItemTipsComponent.SetTipsComponentLockButton(false);
		}

		// Token: 0x0603B462 RID: 242786 RVA: 0x00F01EF0 File Offset: 0x00F000F0
		private void RefreshRedDot(PhantomItemData itemData)
		{
			InventoryModel instance = ModelBase<InventoryModel>.Instance;
			int configId = itemData.GetConfigId();
			int uniqueId = itemData.GetUniqueId();
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(configId);
			if (itemConfigData != null && itemConfigData.RedDotDisableRule == InventoryDefine.ERedDotDisableRule.AfterSelect)
			{
				instance.RemoveRedDotAttributeItem(uniqueId);
			}
			instance.SaveNewAttributeItemUniqueIdList();
			instance.SaveRedDotAttributeItemUniqueIdList();
		}

		// Token: 0x0603B463 RID: 242787 RVA: 0x00F01F3F File Offset: 0x00F0013F
		private void RefreshNew(PhantomItemData itemData)
		{
			ModelBase<InventoryModel>.Instance.RemoveNewAttributeItem(itemData.GetUniqueId());
		}

		// Token: 0x0603B464 RID: 242788 RVA: 0x00F01F54 File Offset: 0x00F00154
		private void RefreshSelect(PhantomItemData itemData)
		{
			int gridIndex = this.AllData.IndexOf(itemData);
			if (this.ItemScroll.IsGridDisplaying(gridIndex))
			{
				this.ItemScroll.RefreshGridProxy(gridIndex);
			}
		}

		// Token: 0x0603B465 RID: 242789 RVA: 0x00F01F88 File Offset: 0x00F00188
		private void RefreshBtn()
		{
			InventoryDefine.EItemDataFunctionValue? allSameState = this.CheckSelectStateSame();
			this.AllSameState = allSameState;
			string textId = (this.AllSameState.GetValueOrDefault() == InventoryDefine.EItemDataFunctionValue.Lock) ? "PhantomManage_UnLock" : "PhantomManage_Lock";
			this.BtnLock.SetLocalTextNew(textId, Array.Empty<object>());
			string textId2 = (this.AllSameState.GetValueOrDefault() == InventoryDefine.EItemDataFunctionValue.Deprecate) ? "PhantomManage_Reset" : "PhantomManage_Discard";
			this.BtnDispose.SetLocalTextNew(textId2, Array.Empty<object>());
		}

		// Token: 0x0603B466 RID: 242790 RVA: 0x00F01FFB File Offset: 0x00F001FB
		private void OnViewModelUpdate(EPhantomManageViewData data)
		{
			if (data == EPhantomManageViewData.SelectSet)
			{
				this.RefreshBtn();
			}
		}

		// Token: 0x0603B467 RID: 242791 RVA: 0x00F02008 File Offset: 0x00F00208
		protected int SortViewDataSelectOn(PhantomItemData dataA, PhantomItemData dataB)
		{
			int num = (this.CheckItemSelect(dataA) > false) ? 1 : 0;
			return ((this.CheckItemSelect(dataB) > false) ? 1 : 0) - num;
		}

		// Token: 0x0603B468 RID: 242792 RVA: 0x00F0202C File Offset: 0x00F0022C
		private void OnFilterSortRefresh(List<PhantomItemData> list, bool isOutSideChange, EFilterSortType operationType)
		{
			HashSet<int> selectSet = this.ViewModel.GetSelectSet();
			if (selectSet != null && selectSet.Count > 0)
			{
				list.Sort(new Comparison<PhantomItemData>(this.SortViewDataSelectOn));
			}
			this.AllData = list;
			this.ItemScroll.RefreshByData(list, false, null, false);
			this.ItemTipsComponent.SetVisible(this.AllData.Count > 0);
			base.GetItem(16).SetUIActive(this.AllData.Count <= 0);
			if (this.AllData.Count <= 0)
			{
				return;
			}
			if (this.OpenParamId > 0)
			{
				this.RefreshOpenParamItem();
				return;
			}
			PhantomItemData phantomItemData = this.AllData[0];
			this.RefreshTipsGrid(phantomItemData.GetUniqueId());
			this.RefreshTips(phantomItemData);
		}

		// Token: 0x0603B469 RID: 242793 RVA: 0x00F020F4 File Offset: 0x00F002F4
		private void RefreshOpenParamItem()
		{
			for (int i = 0; i < this.AllData.Count; i++)
			{
				PhantomItemData phantomItemData = this.AllData[i];
				if (phantomItemData.GetUniqueId() == this.OpenParamId)
				{
					this.ItemScroll.RefreshGridProxy(i);
					this.RefreshItem(phantomItemData);
					this.ItemScroll.ScrollToGridIndex(i, true);
					break;
				}
			}
			this.OpenParamId = 0;
		}

		// Token: 0x0603B46A RID: 242794 RVA: 0x00F0215C File Offset: 0x00F0035C
		private void RefreshTipsGrid(int newUniqueId)
		{
			int selectId = this.SelectId;
			this.SelectId = newUniqueId;
			for (int i = 0; i < this.AllData.Count; i++)
			{
				int uniqueId = this.AllData[i].GetUniqueId();
				if (selectId == uniqueId || this.SelectId == uniqueId)
				{
					this.ItemScroll.RefreshGridProxy(i);
				}
			}
		}

		// Token: 0x0603B46B RID: 242795 RVA: 0x00F021B8 File Offset: 0x00F003B8
		private void OnItemFuncValueChange(int changeId)
		{
			this.RefreshBtn();
			for (int i = 0; i < this.AllData.Count; i++)
			{
				int uniqueId = this.AllData[i].GetUniqueId();
				if (changeId == uniqueId)
				{
					this.ItemScroll.RefreshGridProxy(i);
					return;
				}
			}
		}

		// Token: 0x0603B46C RID: 242796 RVA: 0x00F02204 File Offset: 0x00F00404
		private void OnItemFuncValueBatchChange(IReadOnlyList<int> uniqueIdList)
		{
			for (int i = 0; i < this.AllData.Count; i++)
			{
				int uniqueId = this.AllData[i].GetUniqueId();
				bool flag = false;
				using (IEnumerator<int> enumerator = uniqueIdList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current == uniqueId)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					this.ItemScroll.RefreshGridProxy(i);
				}
			}
			this.RefreshBtn();
		}

		// Token: 0x0603B46D RID: 242797 RVA: 0x00F0228C File Offset: 0x00F0048C
		private void OnListenerFocus(PhantomItemData data)
		{
			this.RefreshTipsGrid(data.GetUniqueId());
			this.RefreshTips(data);
		}

		// Token: 0x0603B46E RID: 242798 RVA: 0x00F022A1 File Offset: 0x00F004A1
		private bool CheckItemSelect(PhantomItemData data)
		{
			return this.ViewModel.GetSelectSet().Contains(data.GetUniqueId());
		}

		// Token: 0x0603B46F RID: 242799 RVA: 0x00F022B9 File Offset: 0x00F004B9
		private bool CheckItemTips(PhantomItemData data)
		{
			return data.GetUniqueId() == this.SelectId;
		}

		// Token: 0x0603B470 RID: 242800 RVA: 0x00F022CC File Offset: 0x00F004CC
		private InventoryDefine.EItemDataFunctionValue? CheckSelectStateSame()
		{
			HashSet<int> selectSet = this.ViewModel.GetSelectSet();
			if (selectSet.Count == 0)
			{
				InventoryDefine.EItemDataFunctionValue? result = null;
				return result;
			}
			InventoryDefine.EItemDataFunctionValue? eitemDataFunctionValue = null;
			foreach (int uniqueId in selectSet)
			{
				InventoryDefine.EItemDataFunctionValue functionValueType = ModelBase<InventoryModel>.Instance.GetPhantomItemData(uniqueId).GetFunctionValueType();
				if (eitemDataFunctionValue == null)
				{
					eitemDataFunctionValue = new InventoryDefine.EItemDataFunctionValue?(functionValueType);
				}
				else
				{
					InventoryDefine.EItemDataFunctionValue eitemDataFunctionValue2 = functionValueType;
					InventoryDefine.EItemDataFunctionValue? result = eitemDataFunctionValue;
					if (!(eitemDataFunctionValue2 == result.GetValueOrDefault() & result != null))
					{
						result = null;
						return result;
					}
				}
			}
			return eitemDataFunctionValue;
		}

		// Token: 0x0603B471 RID: 242801 RVA: 0x00F02388 File Offset: 0x00F00588
		private bool CheckSelectHasLock(HashSet<int> uniqueIdSet)
		{
			if (uniqueIdSet.Count == 0)
			{
				return false;
			}
			foreach (int uniqueId in uniqueIdSet)
			{
				if (ModelBase<InventoryModel>.Instance.GetPhantomItemData(uniqueId).GetFunctionValueType() == InventoryDefine.EItemDataFunctionValue.Lock)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603B472 RID: 242802 RVA: 0x00F023F4 File Offset: 0x00F005F4
		private bool OnItemCanExecuteChange(object data, bool isForceSelected, EToggleState state)
		{
			return isForceSelected;
		}

		// Token: 0x0603B473 RID: 242803 RVA: 0x00F023F8 File Offset: 0x00F005F8
		private void OnClickedItem(MediumItemGridExtendCallback callbackData)
		{
			PhantomItemData phantomItemData = callbackData.Data as PhantomItemData;
			this.ViewModel.SwitchSelectState(phantomItemData.GetUniqueId(), false);
			this.RefreshTipsGrid(phantomItemData.GetUniqueId());
			this.RefreshItem(phantomItemData);
		}

		// Token: 0x0603B474 RID: 242804 RVA: 0x00F02436 File Offset: 0x00F00636
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnItemFuncValueBatchChange, new Action<IReadOnlyList<int>>(this.OnItemFuncValueBatchChange));
		}

		// Token: 0x0603B475 RID: 242805 RVA: 0x00F02470 File Offset: 0x00F00670
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueBatchChange, new Action<IReadOnlyList<int>>(this.OnItemFuncValueBatchChange));
		}

		// Token: 0x0603B476 RID: 242806 RVA: 0x00F024AA File Offset: 0x00F006AA
		private PhantomManageMediumItemGrid InitItem()
		{
			PhantomManageMediumItemGrid phantomManageMediumItemGrid = new PhantomManageMediumItemGrid();
			phantomManageMediumItemGrid.SetUseFixedAsync(true);
			phantomManageMediumItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnClickedItem));
			phantomManageMediumItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OnItemCanExecuteChange));
			return phantomManageMediumItemGrid;
		}

		// Token: 0x0603B477 RID: 242807 RVA: 0x00F024DC File Offset: 0x00F006DC
		private void ClearFilterData()
		{
			int filterIdConst = ModelBase<InventoryModel>.Instance.GetFilterIdConst();
			FilterStorageData data = new FilterStorageData
			{
				ConfigId = filterIdConst,
				SelectRuleMap = new Dictionary<FilterDefine.EFilterType, List<int>>()
			};
			ModelBase<FilterModel>.Instance.SetFilterConfigData(EFilterSortConfigId.PhantomManage, 43, data, "");
		}

		// Token: 0x0603B478 RID: 242808 RVA: 0x00F0251F File Offset: 0x00F0071F
		private void OnClickedBtnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603B479 RID: 242809 RVA: 0x00F02528 File Offset: 0x00F00728
		private void OnClickedBtnSelectAll(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				foreach (PhantomItemData phantomItemData in this.AllData)
				{
					this.ViewModel.SetSelectState(phantomItemData.GetUniqueId(), true, false);
				}
				this.ItemScroll.RefreshAllGridProxies();
				return;
			}
			this.OnClickedBtnClearSelect();
		}

		// Token: 0x0603B47A RID: 242810 RVA: 0x00F025A0 File Offset: 0x00F007A0
		private void OnClickedBtnClearSelect()
		{
			foreach (int uniqueId in this.ViewModel.GetSelectSet())
			{
				this.ViewModel.SetSelectState(uniqueId, false, false);
			}
			this.ItemScroll.RefreshAllGridProxies();
			base.GetExtendToggle(12).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603B47B RID: 242811 RVA: 0x00F0261C File Offset: 0x00F0081C
		private void OnClickedBtnLock(int __)
		{
			if (this.CheckSelectStateSame().GetValueOrDefault() != InventoryDefine.EItemDataFunctionValue.Lock)
			{
				this.OnLockConfirm();
				return;
			}
			this.OnResetConfirm(true);
		}

		// Token: 0x0603B47C RID: 242812 RVA: 0x00F0264C File Offset: 0x00F0084C
		private void OnClickedBtnDispose(int __)
		{
			if (this.CheckSelectStateSame().GetValueOrDefault() != InventoryDefine.EItemDataFunctionValue.Deprecate)
			{
				this.ShowDisposeConfirm();
				return;
			}
			this.OnResetConfirm(false);
		}

		// Token: 0x0603B47D RID: 242813 RVA: 0x00F0267C File Offset: 0x00F0087C
		private void ShowDisposeConfirm()
		{
			HashSet<int> selectSet = this.ViewModel.GetSelectSet();
			if (selectSet.Count <= 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomManage_Tips01", Array.Empty<object>());
				return;
			}
			if (this.CheckSelectHasLock(selectSet))
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomManageBatchDisposeConfirm);
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					this.OnDisposeConfirm();
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			this.OnDisposeConfirm();
		}

		// Token: 0x0603B47E RID: 242814 RVA: 0x00F026F4 File Offset: 0x00F008F4
		private UniTask OnDisposeConfirm()
		{
			PhantomManageView.<OnDisposeConfirm>d__51 <OnDisposeConfirm>d__;
			<OnDisposeConfirm>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnDisposeConfirm>d__.<>4__this = this;
			<OnDisposeConfirm>d__.<>1__state = -1;
			<OnDisposeConfirm>d__.<>t__builder.Start<PhantomManageView.<OnDisposeConfirm>d__51>(ref <OnDisposeConfirm>d__);
			return <OnDisposeConfirm>d__.<>t__builder.Task;
		}

		// Token: 0x0603B47F RID: 242815 RVA: 0x00F02738 File Offset: 0x00F00938
		private UniTask OnLockConfirm()
		{
			PhantomManageView.<OnLockConfirm>d__52 <OnLockConfirm>d__;
			<OnLockConfirm>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnLockConfirm>d__.<>4__this = this;
			<OnLockConfirm>d__.<>1__state = -1;
			<OnLockConfirm>d__.<>t__builder.Start<PhantomManageView.<OnLockConfirm>d__52>(ref <OnLockConfirm>d__);
			return <OnLockConfirm>d__.<>t__builder.Task;
		}

		// Token: 0x0603B480 RID: 242816 RVA: 0x00F0277C File Offset: 0x00F0097C
		private UniTask OnResetConfirm(bool fromLock)
		{
			PhantomManageView.<OnResetConfirm>d__53 <OnResetConfirm>d__;
			<OnResetConfirm>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnResetConfirm>d__.<>4__this = this;
			<OnResetConfirm>d__.fromLock = fromLock;
			<OnResetConfirm>d__.<>1__state = -1;
			<OnResetConfirm>d__.<>t__builder.Start<PhantomManageView.<OnResetConfirm>d__53>(ref <OnResetConfirm>d__);
			return <OnResetConfirm>d__.<>t__builder.Task;
		}

		// Token: 0x0603B481 RID: 242817 RVA: 0x00F027C8 File Offset: 0x00F009C8
		private void OnClickedBtnConfig()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomManageConfigView) || Singleton<UiManager>.Instance.IsViewHide(EUiViewName.PhantomManageConfigView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.PhantomManageConfigView, new Action<bool>(this.OnCloseManageConfigView));
				return;
			}
			this.OnCloseManageConfigView(true);
		}

		// Token: 0x0603B482 RID: 242818 RVA: 0x00F0281A File Offset: 0x00F00A1A
		private void OnCloseManageConfigView(bool success)
		{
			if (success)
			{
				ControllerBase<InventoryController>.Instance.OpenManageConfigView();
			}
		}

		// Token: 0x0603B483 RID: 242819 RVA: 0x00F02829 File Offset: 0x00F00A29
		private void OnClickedBtnManage()
		{
			ControllerBase<CalabashController>.Instance.JumpToCalabashRootView(EUiTabViewName.VisionRecoveryTabView, null);
		}

		// Token: 0x0603B484 RID: 242820 RVA: 0x00F0283B File Offset: 0x00F00A3B
		private void OnClickedBtnSmartDiscard()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomSmartDiscardPopupView, null, delegate(bool success, int viewId)
			{
				UiViewBase uiViewBase = null;
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomManageView))
				{
					uiViewBase = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PhantomManageView);
				}
				else if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InventoryView))
				{
					uiViewBase = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.InventoryView);
				}
				if (uiViewBase != null)
				{
					uiViewBase.AddChildViewById(viewId);
				}
			});
		}

		// Token: 0x0603B485 RID: 242821 RVA: 0x00F0286C File Offset: 0x00F00A6C
		private void OnToggleShowStrengthened(EToggleState state)
		{
			this.ShowStrengthened = (state == EToggleState.ETT_Checked);
			this.RefreshList();
			this.RefreshBtn();
		}

		// Token: 0x040216A0 RID: 136864
		private int OpenParamId;

		// Token: 0x040216A1 RID: 136865
		private int SelectId;

		// Token: 0x040216A2 RID: 136866
		private InventoryDefine.EItemDataFunctionValue? AllSameState;

		// Token: 0x040216A3 RID: 136867
		private List<PhantomItemData> AllData = new List<PhantomItemData>();

		// Token: 0x040216A4 RID: 136868
		[Nullable(2)]
		private PhantomManageViewModel ViewModel;

		// Token: 0x040216A5 RID: 136869
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<PhantomManageMediumItemGrid, PhantomItemData> ItemScroll;

		// Token: 0x040216A6 RID: 136870
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private FilterEntrance<PhantomItemData> FilterEntrance;

		// Token: 0x040216A7 RID: 136871
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040216A8 RID: 136872
		[Nullable(2)]
		private ItemTipsWithButtonComponent ItemTipsComponent;

		// Token: 0x040216A9 RID: 136873
		[Nullable(2)]
		private ButtonItem BtnLock;

		// Token: 0x040216AA RID: 136874
		[Nullable(2)]
		private ButtonItem BtnDispose;

		// Token: 0x040216AB RID: 136875
		private bool ShowStrengthened;
	}
}
