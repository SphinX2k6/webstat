using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.DeadRevive
{
	// Token: 0x02005DCB RID: 24011
	[NullableContext(1)]
	[Nullable(0)]
	public class ReviveItemView : UiViewBase
	{
		// Token: 0x0603C71C RID: 247580 RVA: 0x00F594C1 File Offset: 0x00F576C1
		public ReviveItemView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C71D RID: 247581 RVA: 0x00F594D8 File Offset: 0x00F576D8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.ButtonOnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C71E RID: 247582 RVA: 0x00F5959F File Offset: 0x00F5779F
		private void OnClose()
		{
			this.ConfirmBoxButtonClick();
		}

		// Token: 0x0603C71F RID: 247583 RVA: 0x00F595A8 File Offset: 0x00F577A8
		protected override void OnStart()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				childPopView.PopItem.OverrideBackBtnCallBack(new Action(this.OnClose));
			}
			ReviveItemData reviveItemData = this.OpenParam as ReviveItemData;
			this.RoleId = reviveItemData.PlayerId;
			this.SelectedItemId = reviveItemData.ChoseId;
			this.ItemIdMap = new Dictionary<int, int>();
			foreach (int num in reviveItemData.ItemIdList)
			{
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(num, 0);
				if (itemCountByConfigId > 0)
				{
					this.ItemIdMap.Add(num, itemCountByConfigId);
				}
			}
			this.PropScrollView = new GenericScrollView<ReviveSmallItemGrid>(base.GetScrollViewWithScrollbar(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<ReviveSmallItemGrid>(this.CreatePropItem), null);
			this.InitPropItem();
		}

		// Token: 0x0603C720 RID: 247584 RVA: 0x00F59684 File Offset: 0x00F57884
		protected void InitPropItem()
		{
			ULGUIBehaviour scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(2);
			int count = this.ItemIdMap.Count;
			scrollViewWithScrollbar.RootUIComp.Get().SetUIActive(count > 0);
			if (count == 0)
			{
				return;
			}
			List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
			int index = 0;
			foreach (KeyValuePair<int, int> keyValuePair in this.ItemIdMap)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				list.Add(new ValueTuple<int, int>(key, value));
				if (this.SelectedItemId == key)
				{
					index = list.Count - 1;
				}
			}
			this.PropScrollView.RefreshByData<ValueTuple<int, int>>(list, null);
			ReviveSmallItemGrid reviveSmallItemGrid = this.PropScrollView.GetScrollItemList()[index];
			reviveSmallItemGrid.SetSelected(true, false);
			this.SetSelectedItemGrid(reviveSmallItemGrid);
		}

		// Token: 0x0603C721 RID: 247585 RVA: 0x00F59774 File Offset: 0x00F57974
		private ILayoutItem<ReviveSmallItemGrid> CreatePropItem(object tempData, UUIItem uiItem, int index)
		{
			ValueTuple<int, int>? valueTuple = tempData as ValueTuple<int, int>?;
			ReviveSmallItemGrid reviveSmallItemGrid = new ReviveSmallItemGrid();
			reviveSmallItemGrid.Initialize(uiItem.GetOwner());
			reviveSmallItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnItemExtendToggleStateChanged));
			reviveSmallItemGrid.Refresh(valueTuple.Value.Item1, valueTuple.Value.Item2);
			return new LayoutItem<ReviveSmallItemGrid>
			{
				Key = index,
				Value = reviveSmallItemGrid
			};
		}

		// Token: 0x0603C722 RID: 247586 RVA: 0x00F597E7 File Offset: 0x00F579E7
		protected override void OnBeforeDestroy()
		{
			if (this.ItemIdMap != null)
			{
				this.ItemIdMap.Clear();
			}
			this.SelectedItemId = -1;
			this.RoleId = -1;
			this.PropScrollView.ClearChildren();
		}

		// Token: 0x0603C723 RID: 247587 RVA: 0x00F59815 File Offset: 0x00F57A15
		protected void ConfirmBoxButtonClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603C724 RID: 247588 RVA: 0x00F59820 File Offset: 0x00F57A20
		private void OnItemExtendToggleStateChanged(MediumItemGridExtendCallback callbackParameter)
		{
			ReviveSmallItemGrid selectedItemGrid = callbackParameter.MediumItemGrid as ReviveSmallItemGrid;
			this.SetSelectedItemGrid(selectedItemGrid);
		}

		// Token: 0x0603C725 RID: 247589 RVA: 0x00F59840 File Offset: 0x00F57A40
		private void SetSelectedItemGrid(ReviveSmallItemGrid itemGrid)
		{
			if (itemGrid == null)
			{
				return;
			}
			ReviveSmallItemGrid selectedItemGrid = this.SelectedItemGrid;
			if (selectedItemGrid != null)
			{
				selectedItemGrid.SetSelected(false, false);
			}
			this.SelectedItemGrid = itemGrid;
			this.SelectedItemId = itemGrid.ItemId.Value;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.SelectedItemId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), itemConfigData.AttributesDescription, Array.Empty<object>());
		}

		// Token: 0x0603C726 RID: 247590 RVA: 0x00F598A9 File Offset: 0x00F57AA9
		private void ButtonOnClick()
		{
			if (this.SelectedItemId == -1)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ReviveItemNotClick", Array.Empty<object>());
				return;
			}
			ControllerBase<BuffItemControl>.Instance.RequestUseBuffItem(this.SelectedItemId, 1, this.RoleId);
			base.CloseMe(null);
		}

		// Token: 0x04021FBC RID: 139196
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected GenericScrollView<ReviveSmallItemGrid> PropScrollView;

		// Token: 0x04021FBD RID: 139197
		[Nullable(2)]
		protected Dictionary<int, int> ItemIdMap;

		// Token: 0x04021FBE RID: 139198
		protected int SelectedItemId = -1;

		// Token: 0x04021FBF RID: 139199
		private int RoleId = -1;

		// Token: 0x04021FC0 RID: 139200
		[Nullable(2)]
		private ReviveSmallItemGrid SelectedItemGrid;

		// Token: 0x0200BE19 RID: 48665
		[NullableContext(0)]
		private class EConfirmBoxViewDefine
		{
			// Token: 0x0403A86E RID: 239726
			public const int SecondaryContentText = 0;

			// Token: 0x0403A86F RID: 239727
			public const int ConfirmButton = 1;

			// Token: 0x0403A870 RID: 239728
			public const int PropScrollView = 2;
		}
	}
}
