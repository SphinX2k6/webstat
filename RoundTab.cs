using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

// Token: 0x020016F0 RID: 5872
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class RoundTab : AutoAttachItem<RoundTabData>
{
	// Token: 0x17000D90 RID: 3472
	// (get) Token: 0x0600A2DF RID: 41695 RVA: 0x002AFD8F File Offset: 0x002ADF8F
	// (set) Token: 0x0600A2E0 RID: 41696 RVA: 0x002AFD97 File Offset: 0x002ADF97
	public Action<int> OnClickCallback { get; set; }

	// Token: 0x0600A2E1 RID: 41697 RVA: 0x002AFDA0 File Offset: 0x002ADFA0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A2E2 RID: 41698 RVA: 0x002AFE88 File Offset: 0x002AE088
	public override void OnSelect()
	{
		Action<int> onClickCallback = this.OnClickCallback;
		if (onClickCallback != null)
		{
			onClickCallback(this.Round);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x0600A2E3 RID: 41699 RVA: 0x002AFEB6 File Offset: 0x002AE0B6
	protected override void OnUnSelect()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600A2E4 RID: 41700 RVA: 0x002AFECD File Offset: 0x002AE0CD
	protected override void OnMoveItem()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600A2E5 RID: 41701 RVA: 0x002AFEE4 File Offset: 0x002AE0E4
	protected override void OnRefreshItem(RoundTabData data)
	{
		if (data == null)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetSelfInteractive(false);
			}
			int currentShowItemIndex = base.GetCurrentShowItemIndex();
			int maxChallengeRound = ModelBase<WheelTowerModel>.Instance.GetMaxChallengeRound(null);
			if (currentShowItemIndex < 0)
			{
				UUIItem rootItem = this.RootItem;
				if (rootItem == null)
				{
					return;
				}
				rootItem.SetAlpha(0f);
				return;
			}
			else if (ModelBase<WheelTowerModel>.Instance.IsLastRound(maxChallengeRound, null) || currentShowItemIndex > maxChallengeRound + 1)
			{
				UUIItem rootItem2 = this.RootItem;
				if (rootItem2 == null)
				{
					return;
				}
				rootItem2.SetAlpha(0f);
				return;
			}
			else
			{
				UUIItem rootItem3 = this.RootItem;
				if (rootItem3 != null)
				{
					rootItem3.SetAlpha(1f);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "WheelTower_RoundSelectTab", new <>z__ReadOnlySingleElementList<object>(currentShowItemIndex + 1));
				UUIItem item = base.GetItem(3);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(true);
				return;
			}
		}
		else
		{
			this.Round = data.Round;
			UUIItem rootItem4 = this.RootItem;
			if (rootItem4 != null)
			{
				rootItem4.SetAlpha(1f);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "WheelTower_RoundSelectTab", new <>z__ReadOnlySingleElementList<object>(this.Round + 1));
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(data.IsLock);
			}
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
			if (extendToggle2 == null)
			{
				return;
			}
			extendToggle2.SetSelfInteractive(!data.IsLock);
			return;
		}
	}

	// Token: 0x0600A2E6 RID: 41702 RVA: 0x002B0039 File Offset: 0x002AE239
	private void OnClickToggle(EToggleState state)
	{
		this.OnSelect();
	}

	// Token: 0x0600A2E7 RID: 41703 RVA: 0x002B0041 File Offset: 0x002AE241
	public RoundTab() : base(null)
	{
	}

	// Token: 0x04004D50 RID: 19792
	private int Round = -1;
}
