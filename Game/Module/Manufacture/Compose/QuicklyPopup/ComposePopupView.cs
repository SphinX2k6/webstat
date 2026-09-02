using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup
{
	// Token: 0x020059D9 RID: 23001
	[NullableContext(1)]
	[Nullable(0)]
	public class ComposePopupView : UiViewBase
	{
		// Token: 0x0603A45D RID: 238685 RVA: 0x00EC624F File Offset: 0x00EC444F
		public ComposePopupView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A45E RID: 238686 RVA: 0x00EC6258 File Offset: 0x00EC4458
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A45F RID: 238687 RVA: 0x00EC63E6 File Offset: 0x00EC45E6
		private void OnToggleClick(EToggleState state)
		{
			this.CachedUseGift = (state == EToggleState.ETT_Checked);
			this.RefreshView();
		}

		// Token: 0x0603A460 RID: 238688 RVA: 0x00EC63F8 File Offset: 0x00EC45F8
		protected override UniTask OnBeforeStartAsync()
		{
			ComposePopupView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ComposePopupView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A461 RID: 238689 RVA: 0x00EC643C File Offset: 0x00EC463C
		protected override void OnStart()
		{
			this.ItemScrollView = new GenericScrollViewNew<ComposePopupGridItem, IComposePopupGridItemData>(base.GetScrollViewWithScrollbar(2), new Func<ComposePopupGridItem>(this.InitRewardItem), null, false, null);
			ButtonItem cancelButton = this.CancelButton;
			if (cancelButton != null)
			{
				cancelButton.SetFunction(new Action<int>(this.OnClickCancel));
			}
			ButtonItem confirmButton = this.ConfirmButton;
			if (confirmButton != null)
			{
				confirmButton.SetFunction(new Action<int>(this.OnClickConfirm));
			}
			IComposePopupViewData composePopupViewData = this.OpenParam as IComposePopupViewData;
			if (composePopupViewData == null)
			{
				return;
			}
			List<ISelectedData> selectedDataList = ModelBase<ComposePopupModel>.Instance.MergeDuplicateSelectedData(composePopupViewData.SelectedItemList);
			this.CachedSelectedItemList = this.SortSelectedDataList(selectedDataList);
			this.ClickConfirm = composePopupViewData.ClickConfirm;
			this.BeforeCompose = composePopupViewData.BeforeCompose;
			this.CachedBelongView = composePopupViewData.BelongView;
			ValueTuple<EDefaultCheckResult, List<IComposePopupGridItemData>> valueTuple = this.CheckDefaultComposeResult(this.CachedSelectedItemList);
			this.CachedUseGift = (valueTuple.Item1 > EDefaultCheckResult.OnlyMaterial);
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.ShowTextNew((valueTuple.Item1 == EDefaultCheckResult.OnlyMaterial) ? "AutoSynthesis_MaterialEnough_Title" : "AutoSynthesis_MaterialMissing_Title");
			}
			base.GetExtendToggle(5).SetToggleStateForce(this.CachedUseGift ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603A462 RID: 238690 RVA: 0x00EC6553 File Offset: 0x00EC4753
		protected override void OnBeforeShow()
		{
			this.RefreshView();
		}

		// Token: 0x0603A463 RID: 238691 RVA: 0x00EC655C File Offset: 0x00EC475C
		protected override void OnAfterHide()
		{
			GenericScrollViewNew<ComposePopupGridItem, IComposePopupGridItemData> itemScrollView = this.ItemScrollView;
			List<ComposePopupGridItem> list = (itemScrollView != null) ? itemScrollView.GetScrollItemList() : null;
			if (list != null)
			{
				foreach (ComposePopupGridItem composePopupGridItem in list)
				{
					composePopupGridItem.StopNiagara();
				}
			}
		}

		// Token: 0x0603A464 RID: 238692 RVA: 0x00EC65C0 File Offset: 0x00EC47C0
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnItemCountChanged));
		}

		// Token: 0x0603A465 RID: 238693 RVA: 0x00EC65DE File Offset: 0x00EC47DE
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnItemCountChanged));
		}

		// Token: 0x0603A466 RID: 238694 RVA: 0x00EC65FC File Offset: 0x00EC47FC
		private void OnItemCountChanged(int i, int i1)
		{
			if (this.IgnoreEvent)
			{
				return;
			}
			this.RefreshView();
		}

		// Token: 0x0603A467 RID: 238695 RVA: 0x00EC6610 File Offset: 0x00EC4810
		private void RefreshView()
		{
			foreach (ISelectedData selectedData in this.CachedSelectedItemList)
			{
				selectedData.SelectedCount = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(selectedData.ItemId, 0);
			}
			ValueTuple<EComposeCheckResult, List<IComposePopupGridItemData>> valueTuple = ModelBase<ComposePopupModel>.Instance.CheckComposeResult(this.CachedSelectedItemList, this.CachedUseGift, false);
			this.RefreshScrollView(valueTuple.Item2);
			this.RefreshConfirmButton(valueTuple.Item1 == EComposeCheckResult.CanComposeAll);
			this.RefreshGiftToggleVisible();
		}

		// Token: 0x0603A468 RID: 238696 RVA: 0x00EC66AC File Offset: 0x00EC48AC
		private void RefreshScrollView(List<IComposePopupGridItemData> gridDataList)
		{
			List<IComposePopupGridItemData> list = this.SortGridDataList(gridDataList);
			this.CachedGridDataList = list;
			GenericScrollViewNew<ComposePopupGridItem, IComposePopupGridItemData> itemScrollView = this.ItemScrollView;
			if (itemScrollView == null)
			{
				return;
			}
			itemScrollView.RefreshByData(list, null, false);
		}

		// Token: 0x0603A469 RID: 238697 RVA: 0x00EC66DB File Offset: 0x00EC48DB
		private void RefreshConfirmButton(bool isEnough)
		{
			ButtonItem confirmButton = this.ConfirmButton;
			if (confirmButton != null)
			{
				confirmButton.SetEnableClick(isEnough);
			}
			ButtonItem confirmButton2 = this.ConfirmButton;
			if (confirmButton2 == null)
			{
				return;
			}
			confirmButton2.SetShowText(isEnough ? "AutoSynthesis_LevelUpBtn_Text" : "AutoSynthesis_MaterialMissingBtn_Text");
		}

		// Token: 0x0603A46A RID: 238698 RVA: 0x00EC6710 File Offset: 0x00EC4910
		private void RefreshGiftToggleVisible()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(5);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.RootUIComp.Get().SetUIActive(ModelBase<ComposePopupModel>.Instance.IsComposeGiftShouldShow(this.CachedSelectedItemList));
		}

		// Token: 0x0603A46B RID: 238699 RVA: 0x00EC674B File Offset: 0x00EC494B
		private ComposePopupGridItem InitRewardItem()
		{
			return new ComposePopupGridItem
			{
				BelongView = this.CachedBelongView
			};
		}

		// Token: 0x0603A46C RID: 238700 RVA: 0x00EC6760 File Offset: 0x00EC4960
		private void OnClickConfirm(int _)
		{
			if (this.CachedGridDataList == null)
			{
				return;
			}
			int num = 0;
			foreach (IComposePopupGridItemData composePopupGridItemData in this.CachedGridDataList)
			{
				if (composePopupGridItemData.Item.ItemId == 2)
				{
					int num2 = composePopupGridItemData.Item.Count - composePopupGridItemData.Item.SelectedCount;
					if (num2 <= 0)
					{
						break;
					}
					int num3 = 0;
					if (composePopupGridItemData.ComposeList != null)
					{
						foreach (ISelectedData selectedData in composePopupGridItemData.ComposeList)
						{
							int giftInnerCount = ModelBase<ComposePopupModel>.Instance.GetGiftInnerCount(selectedData.ItemId, 2);
							num3 += giftInnerCount * selectedData.Count;
						}
					}
					num = num3 - num2;
					break;
				}
			}
			if (num > 0)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.AutoSynthesisOverFlowPop);
				confirmBoxDataNew.ItemIdMap = new Dictionary<int, int>
				{
					{
						2,
						num
					}
				};
				confirmBoxDataNew.FunctionMap[2] = new Action(this.SynthesisItemBatchRequest);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			this.SynthesisItemBatchRequest();
		}

		// Token: 0x0603A46D RID: 238701 RVA: 0x00EC68B4 File Offset: 0x00EC4AB4
		private void SynthesisItemBatchRequest()
		{
			ButtonItem confirmButton = this.ConfirmButton;
			if (confirmButton != null)
			{
				confirmButton.SetEnableClick(false);
			}
			Action beforeCompose = this.BeforeCompose;
			if (beforeCompose != null)
			{
				beforeCompose();
			}
			this.SynthesisItemBatchRequestAsync().Forget();
		}

		// Token: 0x0603A46E RID: 238702 RVA: 0x00EC68E4 File Offset: 0x00EC4AE4
		private UniTask SynthesisItemBatchRequestAsync()
		{
			ComposePopupView.<SynthesisItemBatchRequestAsync>d__28 <SynthesisItemBatchRequestAsync>d__;
			<SynthesisItemBatchRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SynthesisItemBatchRequestAsync>d__.<>4__this = this;
			<SynthesisItemBatchRequestAsync>d__.<>1__state = -1;
			<SynthesisItemBatchRequestAsync>d__.<>t__builder.Start<ComposePopupView.<SynthesisItemBatchRequestAsync>d__28>(ref <SynthesisItemBatchRequestAsync>d__);
			return <SynthesisItemBatchRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A46F RID: 238703 RVA: 0x00EC6927 File Offset: 0x00EC4B27
		private void OnClickCancel(int _)
		{
			base.CloseMe(null);
		}

		// Token: 0x0603A470 RID: 238704 RVA: 0x00EC6930 File Offset: 0x00EC4B30
		[return: TupleElementNames(new string[]
		{
			"Result",
			"GridDataList"
		})]
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private ValueTuple<EDefaultCheckResult, List<IComposePopupGridItemData>> CheckDefaultComposeResult(List<ISelectedData> selectedDataList)
		{
			ValueTuple<EComposeCheckResult, List<IComposePopupGridItemData>> valueTuple = ModelBase<ComposePopupModel>.Instance.CheckComposeResult(selectedDataList, false, false);
			if (valueTuple.Item1 == EComposeCheckResult.CanComposeAll)
			{
				return new ValueTuple<EDefaultCheckResult, List<IComposePopupGridItemData>>(EDefaultCheckResult.OnlyMaterial, valueTuple.Item2);
			}
			ValueTuple<EComposeCheckResult, List<IComposePopupGridItemData>> valueTuple2 = ModelBase<ComposePopupModel>.Instance.CheckComposeResult(selectedDataList, true, false);
			if (valueTuple2.Item1 == EComposeCheckResult.CanComposeAll)
			{
				return new ValueTuple<EDefaultCheckResult, List<IComposePopupGridItemData>>(EDefaultCheckResult.MaterialAndGift, valueTuple2.Item2);
			}
			return new ValueTuple<EDefaultCheckResult, List<IComposePopupGridItemData>>(EDefaultCheckResult.CannotComposeAll, valueTuple2.Item2);
		}

		// Token: 0x0603A471 RID: 238705 RVA: 0x00EC698F File Offset: 0x00EC4B8F
		private List<ISelectedData> SortSelectedDataList(List<ISelectedData> selectedDataList)
		{
			selectedDataList.Sort(delegate(ISelectedData a, ISelectedData b)
			{
				bool flag = a.SelectedCount - a.Count >= 0;
				bool flag2 = b.SelectedCount - b.Count >= 0;
				if (flag && !flag2)
				{
					return 1;
				}
				if (!flag && flag2)
				{
					return -1;
				}
				return 0;
			});
			return selectedDataList;
		}

		// Token: 0x0603A472 RID: 238706 RVA: 0x00EC69B8 File Offset: 0x00EC4BB8
		private List<IComposePopupGridItemData> SortGridDataList(List<IComposePopupGridItemData> gridDataList)
		{
			List<IComposePopupGridItemData> list = new List<IComposePopupGridItemData>();
			List<IComposePopupGridItemData> list2 = new List<IComposePopupGridItemData>();
			foreach (IComposePopupGridItemData composePopupGridItemData in gridDataList)
			{
				if (composePopupGridItemData.State == EGridState.Exchange)
				{
					list.Add(composePopupGridItemData);
				}
				else
				{
					list2.Add(composePopupGridItemData);
				}
			}
			list.Sort(delegate(IComposePopupGridItemData a, IComposePopupGridItemData b)
			{
				InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
				int? num3;
				if (instance == null)
				{
					num3 = null;
				}
				else
				{
					ItemConfig itemConfigData = instance.GetItemConfigData(a.Item.ItemId);
					num3 = ((itemConfigData != null) ? new int?(itemConfigData.QualityId) : null);
				}
				int? num4 = num3;
				int valueOrDefault = num4.GetValueOrDefault();
				InventoryConfig instance2 = ConfigBase<InventoryConfig>.Instance;
				int? num5;
				if (instance2 == null)
				{
					num5 = null;
				}
				else
				{
					ItemConfig itemConfigData2 = instance2.GetItemConfigData(b.Item.ItemId);
					num5 = ((itemConfigData2 != null) ? new int?(itemConfigData2.QualityId) : null);
				}
				num4 = num5;
				return num4.GetValueOrDefault() - valueOrDefault;
			});
			List<IComposePopupGridItemData> list3 = list;
			List<IComposePopupGridItemData> list4 = list2;
			int num = list3.Count + list4.Count;
			List<IComposePopupGridItemData> list5 = new List<IComposePopupGridItemData>(num);
			CollectionsMarshal.SetCount<IComposePopupGridItemData>(list5, num);
			Span<IComposePopupGridItemData> span = CollectionsMarshal.AsSpan<IComposePopupGridItemData>(list5);
			int num2 = 0;
			Span<IComposePopupGridItemData> span2 = CollectionsMarshal.AsSpan<IComposePopupGridItemData>(list3);
			span2.CopyTo(span.Slice(num2, span2.Length));
			num2 += span2.Length;
			Span<IComposePopupGridItemData> span3 = CollectionsMarshal.AsSpan<IComposePopupGridItemData>(list4);
			span3.CopyTo(span.Slice(num2, span3.Length));
			num2 += span3.Length;
			return list5;
		}

		// Token: 0x04021059 RID: 135257
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<ComposePopupGridItem, IComposePopupGridItemData> ItemScrollView;

		// Token: 0x0402105A RID: 135258
		[Nullable(2)]
		private ButtonItem CancelButton;

		// Token: 0x0402105B RID: 135259
		[Nullable(2)]
		private ButtonItem ConfirmButton;

		// Token: 0x0402105C RID: 135260
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ISelectedData> CachedSelectedItemList;

		// Token: 0x0402105D RID: 135261
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IComposePopupGridItemData> CachedGridDataList;

		// Token: 0x0402105E RID: 135262
		private bool CachedUseGift;

		// Token: 0x0402105F RID: 135263
		[Nullable(2)]
		private Action ClickConfirm;

		// Token: 0x04021060 RID: 135264
		[Nullable(2)]
		private Action BeforeCompose;

		// Token: 0x04021061 RID: 135265
		private EUiViewName? CachedBelongView;

		// Token: 0x04021062 RID: 135266
		private bool IgnoreEvent;

		// Token: 0x0200B9AD RID: 47533
		[NullableContext(0)]
		public class EComp
		{
			// Token: 0x040395FC RID: 235004
			public const int TxtTitle = 0;

			// Token: 0x040395FD RID: 235005
			public const int TxtTips = 1;

			// Token: 0x040395FE RID: 235006
			public const int ItemScroll = 2;

			// Token: 0x040395FF RID: 235007
			public const int Content = 3;

			// Token: 0x04039600 RID: 235008
			public const int SynthesisItem = 4;

			// Token: 0x04039601 RID: 235009
			public const int TogConsent = 5;

			// Token: 0x04039602 RID: 235010
			public const int TxtConsent = 6;

			// Token: 0x04039603 RID: 235011
			public const int BtnConfirmL = 7;

			// Token: 0x04039604 RID: 235012
			public const int BtnConfirmR = 8;
		}
	}
}
