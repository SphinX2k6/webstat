using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.ItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E26 RID: 24102
	public class CookSuccessView : UiViewBase
	{
		// Token: 0x0603CA72 RID: 248434 RVA: 0x00F675D8 File Offset: 0x00F657D8
		[NullableContext(1)]
		public CookSuccessView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603CA73 RID: 248435 RVA: 0x00F675E4 File Offset: 0x00F657E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(delegate()
			{
				this.OnClose();
			}));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(delegate()
			{
				this.OnConfirm();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CA74 RID: 248436 RVA: 0x00F67754 File Offset: 0x00F65954
		protected override void OnStart()
		{
			CookRewardPopData cookRewardPopData = this.OpenParam as CookRewardPopData;
			this.Type = cookRewardPopData.CookRewardPopType;
			this.CookPopScroll = new GenericScrollView<CommonItemSimpleGrid>(base.GetScrollViewWithScrollbar(3), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CommonItemSimpleGrid>(this.CreatePropItem), null);
			base.GetButton(5).GetRootComponent().SetUIActive(false);
			this.ExpSliderItem = new ExpSliderItem(base.GetItem(4));
		}

		// Token: 0x0603CA75 RID: 248437 RVA: 0x00F677BC File Offset: 0x00F659BC
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FixSuccess, new Action(this.OnClose));
		}

		// Token: 0x0603CA76 RID: 248438 RVA: 0x00F677DA File Offset: 0x00F659DA
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FixSuccess, new Action(this.OnClose));
		}

		// Token: 0x0603CA77 RID: 248439 RVA: 0x00F677F8 File Offset: 0x00F659F8
		private void OnConfirm()
		{
			this.OnClose();
		}

		// Token: 0x0603CA78 RID: 248440 RVA: 0x00F67800 File Offset: 0x00F65A00
		private void OnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603CA79 RID: 248441 RVA: 0x00F6780C File Offset: 0x00F65A0C
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private ILayoutItem<CommonItemSimpleGrid> CreatePropItem([Nullable(2)] object data, UUIItem uiItem, int index)
		{
			if (data is TItem)
			{
				TItem titem = (TItem)data;
				CommonItemSimpleGrid commonItemSimpleGrid = new CommonItemSimpleGrid(uiItem.GetOwner());
				commonItemSimpleGrid.RefreshItem(titem.ItemData.ItemId, titem.Count);
				return new LayoutItem<CommonItemSimpleGrid>
				{
					Key = index,
					Value = commonItemSimpleGrid
				};
			}
			return null;
		}

		// Token: 0x0603CA7A RID: 248442 RVA: 0x00F67867 File Offset: 0x00F65A67
		protected override void OnAfterShow()
		{
			this.RefreshTitle();
			this.RefreshScroller();
			this.RefreshSlider();
		}

		// Token: 0x0603CA7B RID: 248443 RVA: 0x00F6787C File Offset: 0x00F65A7C
		private void RefreshTitle()
		{
			ECookPopType type = this.Type;
			if (type == ECookPopType.Cook)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "GetItem", Array.Empty<object>());
				return;
			}
			if (type != ECookPopType.Machining)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "GetItem", Array.Empty<object>());
		}

		// Token: 0x0603CA7C RID: 248444 RVA: 0x00F678D0 File Offset: 0x00F65AD0
		private void RefreshScroller()
		{
			List<TItem> list = new List<TItem>();
			foreach (ICookPopItem cookPopItem in ModelBase<CookModel>.Instance.GetCookItemList())
			{
				TItem item = new TItem(new InventoryDefine.GetItemData(cookPopItem.ItemId, 0), cookPopItem.ItemNum);
				list.Add(item);
			}
			this.CookPopScroll.RefreshByData<TItem>(list, null);
		}

		// Token: 0x0603CA7D RID: 248445 RVA: 0x00F6795C File Offset: 0x00F65B5C
		private void RefreshSlider()
		{
			ECookPopType type = this.Type;
			if (type == ECookPopType.Cook)
			{
				this.ExpSliderItem.SetActive(true);
				this.ExpSliderItem.Update();
				return;
			}
			if (type != ECookPopType.Machining)
			{
				return;
			}
			this.ExpSliderItem.SetActive(false);
		}

		// Token: 0x0603CA7E RID: 248446 RVA: 0x00F6799D File Offset: 0x00F65B9D
		protected override void OnBeforeDestroy()
		{
			this.CookPopScroll.ClearChildren();
		}

		// Token: 0x0402211F RID: 139551
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollView<CommonItemSimpleGrid> CookPopScroll;

		// Token: 0x04022120 RID: 139552
		private ECookPopType Type;

		// Token: 0x04022121 RID: 139553
		[Nullable(2)]
		private ExpSliderItem ExpSliderItem;

		// Token: 0x0200BE61 RID: 48737
		public enum ECookPopDefine
		{
			// Token: 0x0403A9D2 RID: 240082
			Title,
			// Token: 0x0403A9D3 RID: 240083
			Desc,
			// Token: 0x0403A9D4 RID: 240084
			BtnItem,
			// Token: 0x0403A9D5 RID: 240085
			ItemScroller,
			// Token: 0x0403A9D6 RID: 240086
			ExpItem,
			// Token: 0x0403A9D7 RID: 240087
			CancelBtn,
			// Token: 0x0403A9D8 RID: 240088
			ConfirmBtn
		}
	}
}
