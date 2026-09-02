using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020015B8 RID: 5560
public class ActivitySubViewShipTowerRewardProgress : UiPanelBase
{
	// Token: 0x06009CB2 RID: 40114 RVA: 0x00290B3C File Offset: 0x0028ED3C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009CB3 RID: 40115 RVA: 0x00290BA8 File Offset: 0x0028EDA8
	[NullableContext(1)]
	public void SetData(ShipTowerAreaItemData data)
	{
		int num = 0;
		using (List<ShipTowerRewardItemData>.Enumerator enumerator = data.RewardList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsCompleted)
				{
					num++;
				}
			}
		}
		int count = data.RewardList.Count;
		UUIText text = base.GetText(1);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(51, 2);
		defaultInterpolatedStringHandler.AppendLiteral("<color=#fff7a8ff>");
		defaultInterpolatedStringHandler.AppendFormatted<int>(num);
		defaultInterpolatedStringHandler.AppendLiteral("</color>/<color=#ece5d8ff>");
		defaultInterpolatedStringHandler.AppendFormatted<int>(count);
		defaultInterpolatedStringHandler.AppendLiteral("</color>");
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0200797E RID: 31102
	private enum EChildTypeRewardProgress
	{
		// Token: 0x04029BB1 RID: 170929
		TxtRewardName,
		// Token: 0x04029BB2 RID: 170930
		TxtRewardProgress
	}
}
