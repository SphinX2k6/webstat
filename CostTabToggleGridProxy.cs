using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001917 RID: 6423
public class CostTabToggleGridProxy : GridProxyAbstract<int>
{
	// Token: 0x0600B8A4 RID: 47268 RVA: 0x003112F4 File Offset: 0x0030F4F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleChanged));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B8A5 RID: 47269 RVA: 0x003113BB File Offset: 0x0030F5BB
	private void OnToggleChanged(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked && this.ToggleFunction != null)
		{
			this.ToggleFunction(this.Cost);
		}
	}

	// Token: 0x0600B8A6 RID: 47270 RVA: 0x003113DC File Offset: 0x0030F5DC
	public override void Refresh(int cost, bool isSelected, int gridIndex)
	{
		this.Cost = cost;
		UUIText text = base.GetText(1);
		string key;
		if (text != null && this.visionRefineCostTextIdRecord.TryGetValue(cost, out key))
		{
			text.ShowTextNew(key);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x0600B8A7 RID: 47271 RVA: 0x0031142E File Offset: 0x0030F62E
	[NullableContext(1)]
	public void SetToggleFunction(TCostTabToggleFunction func)
	{
		this.ToggleFunction = func;
	}

	// Token: 0x0600B8A8 RID: 47272 RVA: 0x00311438 File Offset: 0x0030F638
	public void SetSelectedState(bool isSelected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x0600B8A9 RID: 47273 RVA: 0x00311464 File Offset: 0x0030F664
	public void SetMarkVisible(bool visible)
	{
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(visible);
		}
	}

	// Token: 0x040056EB RID: 22251
	[Nullable(1)]
	public Dictionary<int, string> visionRefineCostTextIdRecord = new Dictionary<int, string>
	{
		{
			1,
			"Cost1"
		},
		{
			3,
			"Cost3"
		},
		{
			4,
			"Cost4"
		}
	};

	// Token: 0x040056EC RID: 22252
	[Nullable(2)]
	private TCostTabToggleFunction ToggleFunction;

	// Token: 0x040056ED RID: 22253
	public int Cost;

	// Token: 0x02007C68 RID: 31848
	private class ECostTabToggleDefine
	{
		// Token: 0x0402A7D4 RID: 174036
		public const int Toggle = 0;

		// Token: 0x0402A7D5 RID: 174037
		public const int TabText = 1;

		// Token: 0x0402A7D6 RID: 174038
		public const int ItemChecked = 2;
	}
}
