using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200163A RID: 5690
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WheelTowerBossHandBookBuffItem : GridProxyAbstract<IWheelTowerBossHandBookBuffData>
{
	// Token: 0x0600A02A RID: 41002 RVA: 0x0029E288 File Offset: 0x0029C488
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A02B RID: 41003 RVA: 0x0029E312 File Offset: 0x0029C512
	protected override void OnStart()
	{
		this.DescLayout = new GenericLayout<WheelTowerBossHandBookDescItem, IWheelTowerBossHandBookBuffDescData>(base.GetVerticalLayout(1), () => new WheelTowerBossHandBookDescItem(), null, false, true);
	}

	// Token: 0x0600A02C RID: 41004 RVA: 0x0029E348 File Offset: 0x0029C548
	public override void Refresh(IWheelTowerBossHandBookBuffData data, bool isSelected, int gridIndex)
	{
		string format = ConfigMultiTextLang.GetLocalTextNew("WheelTower_BossHandBook_BossRound", null) ?? string.Empty;
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(string.Format(format, data.Round), true);
		}
		List<IWheelTowerBossHandBookBuffDescData> list = new List<IWheelTowerBossHandBookBuffDescData>();
		foreach (int buffId in data.BuffIdList)
		{
			list.Add(new WheelTowerBossHandBookBuffDescData
			{
				BuffId = buffId,
				IsActivate = data.IsActivate
			});
		}
		GenericLayout<WheelTowerBossHandBookDescItem, IWheelTowerBossHandBookBuffDescData> descLayout = this.DescLayout;
		if (descLayout == null)
		{
			return;
		}
		descLayout.RefreshByData(list, null, false);
	}

	// Token: 0x040049A5 RID: 18853
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerBossHandBookDescItem, IWheelTowerBossHandBookBuffDescData> DescLayout;
}
