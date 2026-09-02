using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.FloroRanch;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C47 RID: 7239
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchTechnologyView : UiViewBase
{
	// Token: 0x0600D31D RID: 54045 RVA: 0x00383B5C File Offset: 0x00381D5C
	public FloroRanchTechnologyView(UiViewInfo info) : base(info)
	{
		this.TechnologyCoinData = new FloroRanchCurrencyData(ECurrencyType.TechnologyCoin);
	}

	// Token: 0x0600D31E RID: 54046 RVA: 0x00383B7C File Offset: 0x00381D7C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnCloseClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D31F RID: 54047 RVA: 0x00383D0C File Offset: 0x00381F0C
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchTechnologyView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchTechnologyView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D320 RID: 54048 RVA: 0x00383D50 File Offset: 0x00381F50
	private void RefreshCurrencyNum()
	{
		int technologyCoinNum = this.ActivityData.GetTechnologyCoinNum();
		this.TechnologyCoinData.SetAmount(technologyCoinNum);
		FloroRanchCurrencyItem costItem = this.CostItem;
		if (costItem == null)
		{
			return;
		}
		costItem.SetCurrencyData(this.TechnologyCoinData);
	}

	// Token: 0x0600D321 RID: 54049 RVA: 0x00383D8B File Offset: 0x00381F8B
	private void UnlockSuccessCallback(string textId)
	{
		FloroRanchUnlockSuccessPanel unlockSuccessPanel = this.UnlockSuccessPanel;
		if (unlockSuccessPanel != null)
		{
			unlockSuccessPanel.RefreshPanel(textId);
		}
		GenericScrollViewNew<FloroRanchTechGridPanel, List<FloroRanchTechnologyData>> scrollView = this.ScrollView;
		if (scrollView != null)
		{
			scrollView.RefreshByData(this.TechnologyTreeList, null, false);
		}
		this.RefreshCurrencyNum();
	}

	// Token: 0x0600D322 RID: 54050 RVA: 0x00383DBE File Offset: 0x00381FBE
	public void TrySelectTechNode(FloroRanchTechNodeItem technologyNode)
	{
		if (this.CurSelectNode == null)
		{
			this.CurSelectNode = technologyNode;
			this.OnSelectTechNode(technologyNode);
		}
	}

	// Token: 0x0600D323 RID: 54051 RVA: 0x00383DD8 File Offset: 0x00381FD8
	private void OnSelectTechNode(FloroRanchTechNodeItem technologyNode)
	{
		if (this.CurSelectNode != null)
		{
			this.CurSelectNode.SetToggleState(EToggleState.ETT_UnChecked);
		}
		this.CurSelectNode = technologyNode;
		this.CurSelectNode.SetToggleState(EToggleState.ETT_Checked);
		this.TechDetailPanel.Refresh(technologyNode.Data);
		this.TechDetailPanel.SetUiActive(true);
		UUIItem item = base.GetItem(7);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(true);
	}

	// Token: 0x0600D324 RID: 54052 RVA: 0x00383E3B File Offset: 0x0038203B
	private void OnBtnCloseClick()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.FloroRanchDataRedDot);
		base.CloseMe(null);
	}

	// Token: 0x0600D325 RID: 54053 RVA: 0x00383E54 File Offset: 0x00382054
	private FloroRanchTechGridPanel CreateGridPanel()
	{
		return new FloroRanchTechGridPanel
		{
			OnSelectTechNode = new Action<FloroRanchTechNodeItem>(this.OnSelectTechNode)
		};
	}

	// Token: 0x04006490 RID: 25744
	[Nullable(2)]
	private FloroRanchActivityData ActivityData;

	// Token: 0x04006491 RID: 25745
	private List<List<FloroRanchTechnologyData>> TechnologyTreeList = new List<List<FloroRanchTechnologyData>>();

	// Token: 0x04006492 RID: 25746
	[Nullable(2)]
	public FloroRanchTechNodeItem CurSelectNode;

	// Token: 0x04006493 RID: 25747
	[Nullable(2)]
	public FloroRanchTechDetailPanel TechDetailPanel;

	// Token: 0x04006494 RID: 25748
	[Nullable(2)]
	public FloroRanchUnlockSuccessPanel UnlockSuccessPanel;

	// Token: 0x04006495 RID: 25749
	public FloroRanchCurrencyData TechnologyCoinData;

	// Token: 0x04006496 RID: 25750
	[Nullable(2)]
	private FloroRanchCurrencyItem CostItem;

	// Token: 0x04006497 RID: 25751
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public GenericScrollViewNew<FloroRanchTechGridPanel, List<FloroRanchTechnologyData>> ScrollView;

	// Token: 0x02007F55 RID: 32597
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B57A RID: 177530
		public const int BtnClose = 0;

		// Token: 0x0402B57B RID: 177531
		public const int ItemCost = 1;

		// Token: 0x0402B57C RID: 177532
		public const int ItemTechDetailPanel = 2;

		// Token: 0x0402B57D RID: 177533
		public const int LoopScrollView = 3;

		// Token: 0x0402B57E RID: 177534
		public const int LayoutTechGrid = 4;

		// Token: 0x0402B57F RID: 177535
		public const int ItemTechGrid = 5;

		// Token: 0x0402B580 RID: 177536
		public const int BtnMask = 6;

		// Token: 0x0402B581 RID: 177537
		public const int ItemMask = 7;

		// Token: 0x0402B582 RID: 177538
		public const int ItemUnlockSuccessPanel = 8;
	}
}
