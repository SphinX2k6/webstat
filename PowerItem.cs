using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002607 RID: 9735
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PowerItem : GridProxyAbstract<PowerItemInfo>
{
	// Token: 0x06013153 RID: 78163 RVA: 0x0054A834 File Offset: 0x00548A34
	public PowerItem(UUIItem uiItem)
	{
		this.CreateThenShowByActor(uiItem.GetOwner());
	}

	// Token: 0x06013154 RID: 78164 RVA: 0x0054A848 File Offset: 0x00548A48
	public override void Refresh(PowerItemInfo data, bool isSelected, int gridIndex)
	{
		this.ItemInfo = data;
		base.GetText(10).text = data.StackValue.ToString();
		if (data.CostValue > data.StackValue)
		{
			base.GetText(10).SetColor(PowerItem.CoinNotEnoughColor);
		}
		base.GetSprite(7).SetActive(false, false);
		base.GetItem(9).SetActive(false, false);
		base.GetItem(5).SetActive(false, false);
		base.SetItemIcon(base.GetTexture(3), data.ItemId, null, null);
	}

	// Token: 0x06013155 RID: 78165 RVA: 0x0054A8DC File Offset: 0x00548ADC
	public void SetClickCallback(Action<PowerItemInfo> toggleFunction)
	{
		this.ClickCallback = toggleFunction;
	}

	// Token: 0x06013156 RID: 78166 RVA: 0x0054A8E8 File Offset: 0x00548AE8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013157 RID: 78167 RVA: 0x0054AABA File Offset: 0x00548CBA
	private void ToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<PowerItemInfo> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(this.ItemInfo);
		}
	}

	// Token: 0x06013158 RID: 78168 RVA: 0x0054AAD6 File Offset: 0x00548CD6
	public void SetIntoToggleGroup(UUIItem group)
	{
		base.GetExtendToggle(0).SetToggleGroup(group.GetOwner());
	}

	// Token: 0x040094EB RID: 38123
	[StaticVariableRuleIgnore]
	private static readonly FColor CoinNotEnoughColor = FColor.FromHex("9D2437FF");

	// Token: 0x040094EC RID: 38124
	private PowerItemInfo ItemInfo;

	// Token: 0x040094ED RID: 38125
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<PowerItemInfo> ClickCallback;

	// Token: 0x02008993 RID: 35219
	[NullableContext(0)]
	private enum EPowerItem
	{
		// Token: 0x0402E6AE RID: 190126
		Item1,
		// Token: 0x0402E6AF RID: 190127
		Item2,
		// Token: 0x0402E6B0 RID: 190128
		Item3,
		// Token: 0x0402E6B1 RID: 190129
		ImageIcon,
		// Token: 0x0402E6B2 RID: 190130
		ImageQuality,
		// Token: 0x0402E6B3 RID: 190131
		Lock,
		// Token: 0x0402E6B4 RID: 190132
		IconRole,
		// Token: 0x0402E6B5 RID: 190133
		ImageRoleBg,
		// Token: 0x0402E6B6 RID: 190134
		TextLevel,
		// Token: 0x0402E6B7 RID: 190135
		Stage,
		// Token: 0x0402E6B8 RID: 190136
		TextNumber
	}
}
