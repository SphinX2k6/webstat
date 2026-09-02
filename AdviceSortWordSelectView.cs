using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200178C RID: 6028
[NullableContext(1)]
[Nullable(0)]
public class AdviceSortWordSelectView : UiViewBase
{
	// Token: 0x0600AA15 RID: 43541 RVA: 0x002D5D3C File Offset: 0x002D3F3C
	public AdviceSortWordSelectView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600AA16 RID: 43542 RVA: 0x002D5D48 File Offset: 0x002D3F48
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIScrollbarComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickCancelBtn)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickConfirmBtn))
		};
	}

	// Token: 0x0600AA17 RID: 43543 RVA: 0x002D5E4C File Offset: 0x002D404C
	protected override void OnStart()
	{
		this.AdviceWordTypeScroller = new GenericScrollView<AdviceWordTypeItem>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<AdviceWordTypeItem>(this.CreateSortItem), null);
		this.AdviceWordScroller = new GenericScrollView<AdviceWordItem>(base.GetScrollViewWithScrollbar(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<AdviceWordItem>(this.CreateWordItem), null);
		UUIItem tempOriginalItem = this.AdviceWordScroller.TempOriginalItem;
		if (tempOriginalItem != null)
		{
			AActor owner = tempOriginalItem.GetOwner();
			if (owner != null)
			{
				UUIButtonComponent uuibuttonComponent = owner.GetComponentByClass(UUIButtonComponent.StaticClass()) as UUIButtonComponent;
				if (uuibuttonComponent != null)
				{
					owner.K2_DestroyComponent(uuibuttonComponent);
				}
			}
		}
		ModelBase<AdviceModel>.Instance.PreSelectSortTypeId = ModelBase<AdviceModel>.Instance.CurrentSelectSortTypeId;
		ModelBase<AdviceModel>.Instance.PreSelectSortWordId = ModelBase<AdviceModel>.Instance.CurrentSelectSortWordId;
		this.RefreshAdviceSort();
		this.RefreshTitle();
	}

	// Token: 0x0600AA18 RID: 43544 RVA: 0x002D5F04 File Offset: 0x002D4104
	private ILayoutItem<AdviceWordTypeItem> CreateSortItem(object data, UUIItem uiItem, int index)
	{
		AdviceWordTypeItem adviceWordTypeItem = new AdviceWordTypeItem(uiItem);
		adviceWordTypeItem.UpdateItem((int)data);
		return new LayoutItem<AdviceWordTypeItem>
		{
			Key = index,
			Value = adviceWordTypeItem
		};
	}

	// Token: 0x0600AA19 RID: 43545 RVA: 0x002D5F3C File Offset: 0x002D413C
	private ILayoutItem<AdviceWordItem> CreateWordItem(object data, UUIItem uiItem, int index)
	{
		AdviceWordItem adviceWordItem = new AdviceWordItem(uiItem);
		adviceWordItem.UpdateItem((int)data);
		return new LayoutItem<AdviceWordItem>
		{
			Key = index,
			Value = adviceWordItem
		};
	}

	// Token: 0x0600AA1A RID: 43546 RVA: 0x002D5F74 File Offset: 0x002D4174
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnClickAdviceSort, new Action(this.RefreshAdviceSortWord));
	}

	// Token: 0x0600AA1B RID: 43547 RVA: 0x002D5F92 File Offset: 0x002D4192
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickAdviceSort, new Action(this.RefreshAdviceSortWord));
	}

	// Token: 0x0600AA1C RID: 43548 RVA: 0x002D5FB0 File Offset: 0x002D41B0
	private void OnClickConfirmBtn()
	{
		AdviceModel instance = ModelBase<AdviceModel>.Instance;
		instance.CurrentWordMap[instance.CurrentSelectWordIndex] = instance.PreSelectSortWordId;
		base.CloseMe(null);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectAdviceWord);
	}

	// Token: 0x0600AA1D RID: 43549 RVA: 0x002D5FF1 File Offset: 0x002D41F1
	private void OnClickCancelBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600AA1E RID: 43550 RVA: 0x002D5FFA File Offset: 0x002D41FA
	private void RefreshTitle()
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(7), "AdviceSelectWord", Array.Empty<object>());
	}

	// Token: 0x0600AA1F RID: 43551 RVA: 0x002D6018 File Offset: 0x002D4218
	private void RefreshAdviceSort()
	{
		IReadOnlyList<AdviceWordType> adviceWordTypeConfigs = ConfigBase<AdviceConfig>.Instance.GetAdviceWordTypeConfigs();
		List<int> list = new List<int>();
		if (adviceWordTypeConfigs != null)
		{
			foreach (AdviceWordType adviceWordType in adviceWordTypeConfigs)
			{
				list.Add(adviceWordType.Id);
			}
		}
		this.AdviceWordTypeScroller.RefreshByData<int>(list, null);
		this.RefreshAdviceSortWord();
		this.AdviceWordTypeFlag = 0;
		this.AdviceWordTypeScroller.UnBindLateUpdate();
		this.AdviceWordTypeScrollerScrollToDirty = true;
		this.AdviceWordTypeScroller.BindLateUpdate(new Action<float>(this.AdviceWordTypeScrollerLateUpdate));
	}

	// Token: 0x0600AA20 RID: 43552 RVA: 0x002D60C8 File Offset: 0x002D42C8
	private void AdviceWordTypeScrollerLateUpdate(float deltaTime)
	{
		if (this.AdviceWordTypeScrollerScrollToDirty && this.AdviceWordTypeFlag >= 1)
		{
			this.AdviceWordTypeScrollerScrollToDirty = false;
			float wordTypeProgress = this.GetWordTypeProgress();
			base.GetScrollViewWithScrollbar(0).SetScrollProgress(wordTypeProgress);
			this.AdviceWordTypeScroller.UnBindLateUpdate();
		}
		this.AdviceWordTypeFlag++;
	}

	// Token: 0x0600AA21 RID: 43553 RVA: 0x002D611C File Offset: 0x002D431C
	private float GetWordTypeProgress()
	{
		IReadOnlyList<AdviceWordType> adviceWordTypeConfigs = ConfigBase<AdviceConfig>.Instance.GetAdviceWordTypeConfigs();
		int num = 0;
		if (adviceWordTypeConfigs == null)
		{
			return 0f;
		}
		for (int i = 0; i < adviceWordTypeConfigs.Count; i++)
		{
			if (adviceWordTypeConfigs[i].Id == ModelBase<AdviceModel>.Instance.PreSelectSortTypeId)
			{
				num = i;
				break;
			}
		}
		if (adviceWordTypeConfigs.Count > 1)
		{
			return (float)num / (float)(adviceWordTypeConfigs.Count - 1);
		}
		return 0f;
	}

	// Token: 0x0600AA22 RID: 43554 RVA: 0x002D618C File Offset: 0x002D438C
	private void RefreshAdviceSortWord()
	{
		int preSelectSortTypeId = ModelBase<AdviceModel>.Instance.PreSelectSortTypeId;
		IReadOnlyList<AdviceWord> adviceWordConfigsByType = ConfigBase<AdviceConfig>.Instance.GetAdviceWordConfigsByType(preSelectSortTypeId);
		List<int> list = new List<int>();
		if (adviceWordConfigsByType != null)
		{
			foreach (AdviceWord adviceWord in adviceWordConfigsByType)
			{
				list.Add(adviceWord.Id);
			}
		}
		this.AdviceWordScroller.RefreshByData<int>(list, null);
		this.AdviceWordFlag = 0;
		this.AdviceWordScroller.UnBindLateUpdate();
		this.AdviceWordScrollerScrollToDirty = true;
		this.AdviceWordScroller.BindLateUpdate(new Action<float>(this.AdviceWordScrollerLateUpdate));
	}

	// Token: 0x0600AA23 RID: 43555 RVA: 0x002D6244 File Offset: 0x002D4444
	private void AdviceWordScrollerLateUpdate(float deltaTime)
	{
		if (this.AdviceWordScrollerScrollToDirty && this.AdviceWordFlag >= 1)
		{
			this.AdviceWordScrollerScrollToDirty = false;
			float wordProgress = this.GetWordProgress();
			base.GetScrollViewWithScrollbar(2).SetScrollProgress(wordProgress);
		}
		if (this.AdviceWordFlag >= 2)
		{
			float wordProgress2 = this.GetWordProgress();
			UUIScrollbarComponent scrollScrollbar = base.GetScrollScrollbar(6);
			if (scrollScrollbar != null)
			{
				scrollScrollbar.SetValue(wordProgress2, true);
			}
			this.AdviceWordScroller.UnBindLateUpdate();
		}
		this.AdviceWordFlag++;
	}

	// Token: 0x0600AA24 RID: 43556 RVA: 0x002D62BC File Offset: 0x002D44BC
	private float GetWordProgress()
	{
		int preSelectSortTypeId = ModelBase<AdviceModel>.Instance.PreSelectSortTypeId;
		IReadOnlyList<AdviceWord> adviceWordConfigsByType = ConfigBase<AdviceConfig>.Instance.GetAdviceWordConfigsByType(preSelectSortTypeId);
		int num = 0;
		if (adviceWordConfigsByType == null)
		{
			return 0f;
		}
		for (int i = 0; i < adviceWordConfigsByType.Count; i++)
		{
			if (adviceWordConfigsByType[i].Id == ModelBase<AdviceModel>.Instance.PreSelectSortWordId)
			{
				num = i;
				break;
			}
		}
		if (adviceWordConfigsByType.Count > 1)
		{
			return (float)num / (float)(adviceWordConfigsByType.Count - 1);
		}
		return 0f;
	}

	// Token: 0x0600AA25 RID: 43557 RVA: 0x002D6337 File Offset: 0x002D4537
	protected override void OnBeforeDestroy()
	{
		GenericScrollView<AdviceWordTypeItem> adviceWordTypeScroller = this.AdviceWordTypeScroller;
		if (adviceWordTypeScroller != null)
		{
			adviceWordTypeScroller.ClearChildren();
		}
		this.AdviceWordTypeScroller = null;
		GenericScrollView<AdviceWordItem> adviceWordScroller = this.AdviceWordScroller;
		if (adviceWordScroller != null)
		{
			adviceWordScroller.ClearChildren();
		}
		this.AdviceWordScroller = null;
	}

	// Token: 0x04004FFA RID: 20474
	private const int WAITUPDATECOUNT = 1;

	// Token: 0x04004FFB RID: 20475
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<AdviceWordTypeItem> AdviceWordTypeScroller;

	// Token: 0x04004FFC RID: 20476
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<AdviceWordItem> AdviceWordScroller;

	// Token: 0x04004FFD RID: 20477
	private bool AdviceWordScrollerScrollToDirty;

	// Token: 0x04004FFE RID: 20478
	private int AdviceWordFlag;

	// Token: 0x04004FFF RID: 20479
	private bool AdviceWordTypeScrollerScrollToDirty;

	// Token: 0x04005000 RID: 20480
	private int AdviceWordTypeFlag;

	// Token: 0x02007AEE RID: 31470
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x0402A189 RID: 172425
		public const int SortScroller = 0;

		// Token: 0x0402A18A RID: 172426
		public const int SortItem = 1;

		// Token: 0x0402A18B RID: 172427
		public const int WordScroller = 2;

		// Token: 0x0402A18C RID: 172428
		public const int WordItem = 3;

		// Token: 0x0402A18D RID: 172429
		public const int CancelBtn = 4;

		// Token: 0x0402A18E RID: 172430
		public const int ConfirmBtn = 5;

		// Token: 0x0402A18F RID: 172431
		public const int ScrollerBar = 6;

		// Token: 0x0402A190 RID: 172432
		public const int TitleText = 7;
	}
}
