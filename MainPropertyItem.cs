using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001911 RID: 6417
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MainPropertyItem : GridProxyAbstract<FilterItemData>
{
	// Token: 0x0600B85D RID: 47197 RVA: 0x0030FED4 File Offset: 0x0030E0D4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickDelete));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B85E RID: 47198 RVA: 0x0030FF9B File Offset: 0x0030E19B
	private void OnClickDelete()
	{
		if (this.Data != null && this.OnDeleteCallback != null)
		{
			this.OnDeleteCallback(this.Data.FilterId);
		}
	}

	// Token: 0x0600B85F RID: 47199 RVA: 0x0030FFC4 File Offset: 0x0030E1C4
	public override void Refresh(FilterItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetText(data.Content ?? "", true);
		}
		UUIText text2 = base.GetText(1);
		if (text2 != null)
		{
			IReadOnlyList<int> costByMainMainProp = ConfigBase<FilterConfig>.Instance.GetCostByMainMainProp(data.FilterId);
			if (costByMainMainProp.Count > 1)
			{
				text2.SetText("-", true);
				return;
			}
			switch (costByMainMainProp[0])
			{
			case 1:
				text2.ShowTextNew("Cost1");
				return;
			case 2:
				break;
			case 3:
				text2.ShowTextNew("Cost3");
				return;
			case 4:
				text2.ShowTextNew("Cost4");
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x0600B860 RID: 47200 RVA: 0x0031006F File Offset: 0x0030E26F
	public void SetDeleteCallback(Action<int> callback)
	{
		this.OnDeleteCallback = callback;
	}

	// Token: 0x040056D7 RID: 22231
	[Nullable(2)]
	public FilterItemData Data;

	// Token: 0x040056D8 RID: 22232
	[Nullable(2)]
	public Action<int> OnDeleteCallback;

	// Token: 0x02007C5E RID: 31838
	[NullableContext(0)]
	private class EMainPropertyItemDefine
	{
		// Token: 0x0402A7A6 RID: 173990
		public const int Item = 0;

		// Token: 0x0402A7A7 RID: 173991
		public const int TxtCost = 1;

		// Token: 0x0402A7A8 RID: 173992
		public const int TxtPropertyName = 2;

		// Token: 0x0402A7A9 RID: 173993
		public const int BtnDelete = 3;
	}
}
