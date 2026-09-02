using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x02005507 RID: 21767
	public class DeckBuilderSortFilterEntrance : UiPanelBase
	{
		// Token: 0x060377C6 RID: 227270 RVA: 0x00E11D59 File Offset: 0x00E0FF59
		public DeckBuilderSortFilterEntrance(bool isFilterOrSort)
		{
			this.IsFilterOrSort = isFilterOrSort;
		}

		// Token: 0x060377C7 RID: 227271 RVA: 0x00E11D80 File Offset: 0x00E0FF80
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.HandleSortShow)),
				new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnSortToggleClick))
			};
		}

		// Token: 0x060377C8 RID: 227272 RVA: 0x00E11E44 File Offset: 0x00E10044
		protected override UniTask OnBeforeStartAsync()
		{
			DeckBuilderSortFilterEntrance.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DeckBuilderSortFilterEntrance.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060377C9 RID: 227273 RVA: 0x00E11E87 File Offset: 0x00E10087
		[NullableContext(1)]
		public void UpdateDataList(IDeckBuilderSortFilterItemData[] dataList)
		{
			this.DataList = dataList;
			GenericScrollViewNew<DeckBuilderSortFilterItem, IDeckBuilderSortFilterItemData> scroll = this.Scroll;
			if (scroll == null)
			{
				return;
			}
			scroll.RefreshByData(this.DataList.ToList<IDeckBuilderSortFilterItemData>(), null, false);
		}

		// Token: 0x060377CA RID: 227274 RVA: 0x00E11EB0 File Offset: 0x00E100B0
		private void HandleSortShow(EToggleState toggleState)
		{
			bool bIsUIActive = base.GetScrollViewWithScrollbar(3).RootUIComp.Get().bIsUIActive;
			this.ChangeScrollActive(!bIsUIActive);
		}

		// Token: 0x060377CB RID: 227275 RVA: 0x00E11EE4 File Offset: 0x00E100E4
		public void SelectItemByIndex(int gridIndex, bool bTriggerCallBack)
		{
			if (this.DataList == null || this.DataList.Length == 0 || gridIndex < 0 || gridIndex >= this.DataList.Length || this.DataList[gridIndex] == null)
			{
				return;
			}
			this.SelectedGridIndex = gridIndex;
			IDeckBuilderSortFilterItemData deckBuilderSortFilterItemData = this.DataList[gridIndex];
			this.ChangeScrollActive(false);
			GenericScrollViewNew<DeckBuilderSortFilterItem, IDeckBuilderSortFilterItemData> scroll = this.Scroll;
			if (scroll != null)
			{
				scroll.SelectGridProxy(gridIndex, false);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), deckBuilderSortFilterItemData.Name, Array.Empty<object>());
			if (bTriggerCallBack)
			{
				Action<int, bool> onResultCallBack = this.OnResultCallBack;
				if (onResultCallBack == null)
				{
					return;
				}
				onResultCallBack(deckBuilderSortFilterItemData.ConfigId, this.IsAscending);
			}
		}

		// Token: 0x060377CC RID: 227276 RVA: 0x00E11F81 File Offset: 0x00E10181
		private void ChangeScrollActive(bool value)
		{
			this.Scroll.SetActive(value);
			if (value)
			{
				this.ShowMaskButton();
				return;
			}
			this.HideMaskButton();
		}

		// Token: 0x060377CD RID: 227277 RVA: 0x00E11F9F File Offset: 0x00E1019F
		private void ShowMaskButton()
		{
			this.MaskButton.SetAttachChildItem(this.RootItem);
			this.MaskButton.SetActive(true);
		}

		// Token: 0x060377CE RID: 227278 RVA: 0x00E11FBE File Offset: 0x00E101BE
		private void HideMaskButton()
		{
			this.MaskButton.ResetItemParent();
			this.MaskButton.SetActive(false);
		}

		// Token: 0x060377CF RID: 227279 RVA: 0x00E11FD7 File Offset: 0x00E101D7
		[NullableContext(1)]
		private DeckBuilderSortFilterItem InitItem()
		{
			return new DeckBuilderSortFilterItem
			{
				OnToggleSelect = new Action<int>(this.OnItemClick)
			};
		}

		// Token: 0x060377D0 RID: 227280 RVA: 0x00E11FF0 File Offset: 0x00E101F0
		private void OnItemClick(int gridIndex)
		{
			this.SelectItemByIndex(gridIndex, true);
		}

		// Token: 0x060377D1 RID: 227281 RVA: 0x00E11FFC File Offset: 0x00E101FC
		private void OnSortToggleClick(EToggleState toggleState)
		{
			bool isAscending = base.GetExtendToggle(2).GetToggleState() == EToggleState.ETT_Checked;
			this.ChangeSortAscending(isAscending, false, true);
		}

		// Token: 0x060377D2 RID: 227282 RVA: 0x00E12022 File Offset: 0x00E10222
		private void HideScroll()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
		}

		// Token: 0x060377D3 RID: 227283 RVA: 0x00E12038 File Offset: 0x00E10238
		public void ChangeSortAscending(bool isAscending, bool bRefreshToggle, bool bTriggerCallBack)
		{
			this.IsAscending = isAscending;
			if (bRefreshToggle)
			{
				base.GetExtendToggle(2).SetToggleState(isAscending ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			if (!bTriggerCallBack)
			{
				return;
			}
			if (this.DataList == null || this.DataList.Length == 0)
			{
				return;
			}
			IDeckBuilderSortFilterItemData deckBuilderSortFilterItemData = this.DataList[this.SelectedGridIndex];
			if (deckBuilderSortFilterItemData != null)
			{
				Action<int, bool> onResultCallBack = this.OnResultCallBack;
				if (onResultCallBack == null)
				{
					return;
				}
				onResultCallBack(deckBuilderSortFilterItemData.ConfigId, this.IsAscending);
			}
		}

		// Token: 0x060377D4 RID: 227284 RVA: 0x00E120A9 File Offset: 0x00E102A9
		protected override void OnBeforeDestroy()
		{
			DynamicMaskButton maskButton = this.MaskButton;
			if (maskButton == null)
			{
				return;
			}
			maskButton.Destroy(null);
		}

		// Token: 0x0401FD60 RID: 130400
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private IDeckBuilderSortFilterItemData[] DataList;

		// Token: 0x0401FD61 RID: 130401
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<DeckBuilderSortFilterItem, IDeckBuilderSortFilterItemData> Scroll;

		// Token: 0x0401FD62 RID: 130402
		[Nullable(2)]
		private DynamicMaskButton MaskButton;

		// Token: 0x0401FD63 RID: 130403
		public bool IsFilterOrSort = true;

		// Token: 0x0401FD64 RID: 130404
		private bool IsAscending = true;

		// Token: 0x0401FD65 RID: 130405
		private int SelectedGridIndex = -1;

		// Token: 0x0401FD66 RID: 130406
		[Nullable(2)]
		public Action<int, bool> OnResultCallBack;

		// Token: 0x0200B47F RID: 46207
		private static class EComponents
		{
			// Token: 0x04037E03 RID: 228867
			public const int Toggle = 0;

			// Token: 0x04037E04 RID: 228868
			public const int Name = 1;

			// Token: 0x04037E05 RID: 228869
			public const int SortToggle = 2;

			// Token: 0x04037E06 RID: 228870
			public const int ItemScroll = 3;

			// Token: 0x04037E07 RID: 228871
			public const int TemplateItem = 4;
		}
	}
}
