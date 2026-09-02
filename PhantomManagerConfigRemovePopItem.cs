using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002486 RID: 9350
public class PhantomManagerConfigRemovePopItem : UiViewBase
{
	// Token: 0x0601224D RID: 74317 RVA: 0x004FCFD7 File Offset: 0x004FB1D7
	[NullableContext(1)]
	public PhantomManagerConfigRemovePopItem(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601224E RID: 74318 RVA: 0x004FCFEC File Offset: 0x004FB1EC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickedToggleL));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickedToggleR));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickedClose));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickedConfirm));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601224F RID: 74319 RVA: 0x004FD208 File Offset: 0x004FB408
	protected override void OnStart()
	{
		this.CurData = ((this.OpenParam as IPhantomManagerApplySettingDetailInfo) ?? new PhantomManagerApplySettingDetailInfo());
		this.LoopScrollView = new LoopScrollView<PhantomConfigRemoveItemGrid, PhantomItemData>(base.GetLoopScrollViewComponent(5), base.GetItem(6).GetOwner() as AUIBaseActor, new Func<PhantomConfigRemoveItemGrid>(this.OnCreateItem), false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "PhantomProject_Reorganize_Des_1", new <>z__ReadOnlySingleElementList<object>(this.CurData.DiscardList.Count));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "PhantomProject_Reorganize_Des_2", new <>z__ReadOnlySingleElementList<object>(this.CurData.LockList.Count));
		if (this.CurData.DiscardList.Count != 0)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
			this.OnClickedToggleL(EToggleState.ETT_Checked);
			return;
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(2);
		if (extendToggle2 != null)
		{
			extendToggle2.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}
		this.OnClickedToggleR(EToggleState.ETT_Checked);
	}

	// Token: 0x06012250 RID: 74320 RVA: 0x004FD310 File Offset: 0x004FB510
	private void OnClickedToggleL(EToggleState state)
	{
		if (this.CurrentSelected == PhantomManagerConfigRemovePopItem.EPhantomRemovePopState.Left)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "PhantomProject_Reorganize_Des_3", new <>z__ReadOnlySingleElementList<object>(this.CurData.DiscardList.Count));
		this.CurrentSelected = PhantomManagerConfigRemovePopItem.EPhantomRemovePopState.Left;
		this.LoopScrollView.RefreshByData(this.CurData.DiscardList, false, null, true);
		UUIExtendToggle extendToggle = base.GetExtendToggle(2);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		UUIItem item = base.GetItem(9);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.CurData.DiscardList.Count == 0);
	}

	// Token: 0x06012251 RID: 74321 RVA: 0x004FD3B4 File Offset: 0x004FB5B4
	private void OnClickedToggleR(EToggleState state)
	{
		if (this.CurrentSelected == PhantomManagerConfigRemovePopItem.EPhantomRemovePopState.Right)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "PhantomProject_Reorganize_Des_4", new <>z__ReadOnlySingleElementList<object>(this.CurData.LockList.Count));
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelected = PhantomManagerConfigRemovePopItem.EPhantomRemovePopState.Right;
		this.LoopScrollView.RefreshByData(this.CurData.LockList, false, null, true);
		UUIItem item = base.GetItem(9);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.CurData.LockList.Count == 0);
	}

	// Token: 0x06012252 RID: 74322 RVA: 0x004FD457 File Offset: 0x004FB657
	private void OnClickedClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x06012253 RID: 74323 RVA: 0x004FD460 File Offset: 0x004FB660
	private void OnClickedConfirm()
	{
		ModelBase<PhantomBattleModel>.Instance.GetPhantomConfigData().DoApplyOpera(this.CurData).ContinueWith(delegate(bool value)
		{
			if (value)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_Reorganize_Des_6", Array.Empty<object>());
				base.CloseMe(null);
			}
		}).Forget();
	}

	// Token: 0x06012254 RID: 74324 RVA: 0x004FD48D File Offset: 0x004FB68D
	[NullableContext(1)]
	private PhantomConfigRemoveItemGrid OnCreateItem()
	{
		return new PhantomConfigRemoveItemGrid();
	}

	// Token: 0x04008D96 RID: 36246
	private PhantomManagerConfigRemovePopItem.EPhantomRemovePopState CurrentSelected;

	// Token: 0x04008D97 RID: 36247
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<PhantomConfigRemoveItemGrid, PhantomItemData> LoopScrollView;

	// Token: 0x04008D98 RID: 36248
	[Nullable(1)]
	private IPhantomManagerApplySettingDetailInfo CurData = new PhantomManagerApplySettingDetailInfo();

	// Token: 0x0200879F RID: 34719
	private enum EDefine
	{
		// Token: 0x0402DD91 RID: 187793
		ToggleTopLeft,
		// Token: 0x0402DD92 RID: 187794
		TxtToggleLeft,
		// Token: 0x0402DD93 RID: 187795
		ToggleTopRight,
		// Token: 0x0402DD94 RID: 187796
		TxtToggleRight,
		// Token: 0x0402DD95 RID: 187797
		TxtEchoNumber,
		// Token: 0x0402DD96 RID: 187798
		ScrollEcho,
		// Token: 0x0402DD97 RID: 187799
		ItemBase,
		// Token: 0x0402DD98 RID: 187800
		BtnLeft,
		// Token: 0x0402DD99 RID: 187801
		BtnRight,
		// Token: 0x0402DD9A RID: 187802
		PanelEmpty
	}

	// Token: 0x020087A0 RID: 34720
	private enum EPhantomRemovePopState
	{
		// Token: 0x0402DD9C RID: 187804
		Default,
		// Token: 0x0402DD9D RID: 187805
		Left = -1,
		// Token: 0x0402DD9E RID: 187806
		Right = 1
	}
}
