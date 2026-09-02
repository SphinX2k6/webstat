using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002403 RID: 9219
[Nullable(new byte[]
{
	0,
	1
})]
public class WeekCardRewardGrid : GridProxyAbstract<IWeekRewardData>
{
	// Token: 0x06011D5B RID: 73051 RVA: 0x004E7B98 File Offset: 0x004E5D98
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickReward));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011D5C RID: 73052 RVA: 0x004E7C60 File Offset: 0x004E5E60
	[NullableContext(1)]
	public void Refresh(IWeekRewardData rewardData)
	{
		this.ItemId = rewardData.ItemId;
		base.SetItemIcon(base.GetTexture(1), rewardData.ItemId, null, null);
		base.GetText(2).SetText(rewardData.Count.ToString(), true);
	}

	// Token: 0x06011D5D RID: 73053 RVA: 0x004E7CB1 File Offset: 0x004E5EB1
	[NullableContext(2)]
	public override void Refresh(IWeekRewardData data, bool isSelected, int gridIndex)
	{
		if (data != null)
		{
			this.Refresh(data);
		}
	}

	// Token: 0x06011D5E RID: 73054 RVA: 0x004E7CBD File Offset: 0x004E5EBD
	private void OnClickReward()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemId, true, null);
	}

	// Token: 0x04008B84 RID: 35716
	private int ItemId;

	// Token: 0x02008736 RID: 34614
	private class EComponent
	{
		// Token: 0x0402DBC0 RID: 187328
		public const int BtnReward = 0;

		// Token: 0x0402DBC1 RID: 187329
		public const int TextureReward = 1;

		// Token: 0x0402DBC2 RID: 187330
		public const int TextCount = 2;
	}
}
