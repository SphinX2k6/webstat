using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200163E RID: 5694
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WheelTowerBossHandBookDescItem : GridProxyAbstract<IWheelTowerBossHandBookBuffDescData>
{
	// Token: 0x0600A033 RID: 41011 RVA: 0x0029E5A8 File Offset: 0x0029C7A8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A034 RID: 41012 RVA: 0x0029E698 File Offset: 0x0029C898
	public override void Refresh(IWheelTowerBossHandBookBuffDescData data, bool isSelected, int gridIndex)
	{
		NewTowerBossBuff? bossBuffConfigById = ConfigBase<WheelTowerConfig>.Instance.GetBossBuffConfigById(data.BuffId);
		if (bossBuffConfigById == null)
		{
			return;
		}
		base.SetTextureByPath(bossBuffConfigById.Value.SkillBgQuality, base.GetTexture(0), null, null);
		base.SetTextureByPath(bossBuffConfigById.Value.SkillIconBgQuality, base.GetTexture(1), null, null);
		base.SetTextureByPath(bossBuffConfigById.Value.SkillIcon, base.GetTexture(2), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), bossBuffConfigById.Value.SkillTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), bossBuffConfigById.Value.SkillDesc, Array.Empty<object>());
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(data.IsActivate);
	}
}
