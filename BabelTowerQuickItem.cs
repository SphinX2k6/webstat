using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001212 RID: 4626
public class BabelTowerQuickItem : UiPanelBase
{
	// Token: 0x06007AA6 RID: 31398 RVA: 0x00200800 File Offset: 0x001FEA00
	public int GetSelectedQuickIndex()
	{
		return this.SelectedQuickIndex;
	}

	// Token: 0x06007AA7 RID: 31399 RVA: 0x00200808 File Offset: 0x001FEA08
	public int GetPrevSelectedQuickIndex()
	{
		return this.PrevSelectedQuickIndex;
	}

	// Token: 0x06007AA8 RID: 31400 RVA: 0x00200810 File Offset: 0x001FEA10
	[NullableContext(2)]
	public UUIItem GetFirstQuickItem()
	{
		if (this.QuickLoopScroll == null)
		{
			return null;
		}
		QuickOptionItem quickOptionItem = this.QuickLoopScroll.UnsafeGetGridProxy(0, true);
		if (quickOptionItem == null)
		{
			return null;
		}
		return quickOptionItem.GetRootItem();
	}

	// Token: 0x06007AA9 RID: 31401 RVA: 0x00200834 File Offset: 0x001FEA34
	[NullableContext(1)]
	public void BindLateUpdate(Action<float> callBack)
	{
		LoopScrollView<QuickOptionItem, BabelTowerQuick> quickLoopScroll = this.QuickLoopScroll;
		if (quickLoopScroll == null)
		{
			return;
		}
		quickLoopScroll.BindLateUpdate(callBack);
	}

	// Token: 0x06007AAA RID: 31402 RVA: 0x00200847 File Offset: 0x001FEA47
	public void UnBindLateUpdate()
	{
		LoopScrollView<QuickOptionItem, BabelTowerQuick> quickLoopScroll = this.QuickLoopScroll;
		if (quickLoopScroll == null)
		{
			return;
		}
		quickLoopScroll.UnBindLateUpdate();
	}

	// Token: 0x06007AAB RID: 31403 RVA: 0x0020085C File Offset: 0x001FEA5C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007AAC RID: 31404 RVA: 0x00200928 File Offset: 0x001FEB28
	protected override void OnStart()
	{
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(1);
		UUIItem item = base.GetItem(2);
		if (loopScrollViewComponent == null || item == null)
		{
			return;
		}
		AUIBaseActor auibaseActor = item.GetOwner() as AUIBaseActor;
		if (auibaseActor == null)
		{
			return;
		}
		this.QuickLoopScroll = new LoopScrollView<QuickOptionItem, BabelTowerQuick>(loopScrollViewComponent, auibaseActor, new Func<QuickOptionItem>(this.InitQuickOptionItem), false);
	}

	// Token: 0x06007AAD RID: 31405 RVA: 0x00200978 File Offset: 0x001FEB78
	public void SetLevelId(int levelId)
	{
		this.InstId = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(levelId).InstId;
		this.RefreshQuickList();
	}

	// Token: 0x06007AAE RID: 31406 RVA: 0x002009A4 File Offset: 0x001FEBA4
	[NullableContext(1)]
	private QuickOptionItem InitQuickOptionItem()
	{
		return new QuickOptionItem
		{
			OnQuickOptionClickWithIndex = new Action<BabelTowerQuick, int>(this.OnQuickOptionClickHandlerWithIndex)
		};
	}

	// Token: 0x06007AAF RID: 31407 RVA: 0x002009C0 File Offset: 0x001FEBC0
	private void OnQuickOptionClickHandlerWithIndex(BabelTowerQuick quickConfig, int index)
	{
		if (this.SelectedQuickIndex >= 0 && this.SelectedQuickIndex != index)
		{
			LoopScrollView<QuickOptionItem, BabelTowerQuick> quickLoopScroll = this.QuickLoopScroll;
			QuickOptionItem quickOptionItem = (quickLoopScroll != null) ? quickLoopScroll.UnsafeGetGridProxy(this.SelectedQuickIndex, false) : null;
			UUIExtendToggle uuiextendToggle = (quickOptionItem != null) ? quickOptionItem.GetQuickToggle() : null;
			if (uuiextendToggle != null)
			{
				uuiextendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			}
		}
		this.PrevSelectedQuickIndex = this.SelectedQuickIndex;
		this.SelectedQuickIndex = index;
		ModelBase<BabelTowerModel>.Instance.CurrentQuickIndex = index;
		Action<BabelTowerQuick> onQuickSelectApplied = this.OnQuickSelectApplied;
		if (onQuickSelectApplied == null)
		{
			return;
		}
		onQuickSelectApplied(quickConfig);
	}

	// Token: 0x06007AB0 RID: 31408 RVA: 0x00200A44 File Offset: 0x001FEC44
	public void RefreshQuickList()
	{
		IReadOnlyList<BabelTowerQuick> babelTowerQuickByInstId = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerQuickByInstId(this.InstId);
		if (babelTowerQuickByInstId == null || babelTowerQuickByInstId.Count == 0)
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			LoopScrollView<QuickOptionItem, BabelTowerQuick> quickLoopScroll = this.QuickLoopScroll;
			if (quickLoopScroll == null)
			{
				return;
			}
			quickLoopScroll.RefreshByData(new List<BabelTowerQuick>(), false, null, false);
			return;
		}
		else
		{
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			LoopScrollView<QuickOptionItem, BabelTowerQuick> quickLoopScroll2 = this.QuickLoopScroll;
			if (quickLoopScroll2 == null)
			{
				return;
			}
			quickLoopScroll2.RefreshByData(new List<BabelTowerQuick>(babelTowerQuickByInstId), false, null, false);
			return;
		}
	}

	// Token: 0x06007AB1 RID: 31409 RVA: 0x00200AC8 File Offset: 0x001FECC8
	public void RefreshQuickListWithSelection()
	{
		if (this.SelectedQuickIndex < 0)
		{
			return;
		}
		LoopScrollView<QuickOptionItem, BabelTowerQuick> quickLoopScroll = this.QuickLoopScroll;
		QuickOptionItem quickOptionItem = (quickLoopScroll != null) ? quickLoopScroll.UnsafeGetGridProxy(this.SelectedQuickIndex, false) : null;
		BabelTowerQuick? babelTowerQuick = (quickOptionItem != null) ? quickOptionItem.GetCurrentData() : null;
		if (quickOptionItem != null && babelTowerQuick != null)
		{
			quickOptionItem.Refresh(babelTowerQuick.Value, true, this.SelectedQuickIndex);
		}
	}

	// Token: 0x06007AB2 RID: 31410 RVA: 0x00200B30 File Offset: 0x001FED30
	public void ClearSelection()
	{
		if (this.SelectedQuickIndex >= 0)
		{
			LoopScrollView<QuickOptionItem, BabelTowerQuick> quickLoopScroll = this.QuickLoopScroll;
			QuickOptionItem quickOptionItem = (quickLoopScroll != null) ? quickLoopScroll.UnsafeGetGridProxy(this.SelectedQuickIndex, false) : null;
			UUIExtendToggle uuiextendToggle = (quickOptionItem != null) ? quickOptionItem.GetQuickToggle() : null;
			if (uuiextendToggle != null)
			{
				uuiextendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			}
		}
		this.PrevSelectedQuickIndex = this.SelectedQuickIndex;
		this.SelectedQuickIndex = -1;
		ModelBase<BabelTowerModel>.Instance.CurrentQuickIndex = -1;
		Action onQuickSelectCleared = this.OnQuickSelectCleared;
		if (onQuickSelectCleared == null)
		{
			return;
		}
		onQuickSelectCleared();
	}

	// Token: 0x06007AB3 RID: 31411 RVA: 0x00200BA8 File Offset: 0x001FEDA8
	public void ClearSelectionWithoutCallback()
	{
		if (this.SelectedQuickIndex >= 0)
		{
			LoopScrollView<QuickOptionItem, BabelTowerQuick> quickLoopScroll = this.QuickLoopScroll;
			QuickOptionItem quickOptionItem = (quickLoopScroll != null) ? quickLoopScroll.UnsafeGetGridProxy(this.SelectedQuickIndex, false) : null;
			UUIExtendToggle uuiextendToggle = (quickOptionItem != null) ? quickOptionItem.GetQuickToggle() : null;
			if (uuiextendToggle != null)
			{
				uuiextendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			}
		}
		this.PrevSelectedQuickIndex = this.SelectedQuickIndex;
		this.SelectedQuickIndex = -1;
	}

	// Token: 0x06007AB4 RID: 31412 RVA: 0x00200C04 File Offset: 0x001FEE04
	public void PlayContentAnimController()
	{
		LoopScrollView<QuickOptionItem, BabelTowerQuick> quickLoopScroll = this.QuickLoopScroll;
		if (quickLoopScroll == null)
		{
			return;
		}
		quickLoopScroll.ResetGridController();
	}

	// Token: 0x04003AD6 RID: 15062
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<QuickOptionItem, BabelTowerQuick> QuickLoopScroll;

	// Token: 0x04003AD7 RID: 15063
	private int InstId;

	// Token: 0x04003AD8 RID: 15064
	private int SelectedQuickIndex = -1;

	// Token: 0x04003AD9 RID: 15065
	private int PrevSelectedQuickIndex = -1;

	// Token: 0x04003ADA RID: 15066
	[Nullable(2)]
	public Action<BabelTowerQuick> OnQuickSelectApplied;

	// Token: 0x04003ADB RID: 15067
	[Nullable(2)]
	public Action OnQuickSelectCleared;

	// Token: 0x02007564 RID: 30052
	private class EComponentDefine
	{
		// Token: 0x04028814 RID: 165908
		public const int TopTextColor = 0;

		// Token: 0x04028815 RID: 165909
		public const int BuffScroll = 1;

		// Token: 0x04028816 RID: 165910
		public const int BuffItem = 2;

		// Token: 0x04028817 RID: 165911
		public const int BuffTips = 3;

		// Token: 0x04028818 RID: 165912
		public const int TitleName = 4;
	}

	// Token: 0x02007565 RID: 30053
	private class EBuffItemSubComponent
	{
		// Token: 0x04028819 RID: 165913
		public const int QuickItem = 0;

		// Token: 0x0402881A RID: 165914
		public const int ColorSprite = 1;

		// Token: 0x0402881B RID: 165915
		public const int TitleText = 2;

		// Token: 0x0402881C RID: 165916
		public const int DescText = 3;

		// Token: 0x0402881D RID: 165917
		public const int DeLevelArt = 4;

		// Token: 0x0402881E RID: 165918
		public const int LockItem = 5;
	}
}
