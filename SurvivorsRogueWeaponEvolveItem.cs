using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002B75 RID: 11125
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsRogueWeaponEvolveItem : GridProxyAbstract<IWeaponEvolveData>
{
	// Token: 0x06016278 RID: 90744 RVA: 0x00625960 File Offset: 0x00623B60
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x06016279 RID: 90745 RVA: 0x006259E6 File Offset: 0x00623BE6
	protected override void OnStart()
	{
	}

	// Token: 0x0601627A RID: 90746 RVA: 0x006259E8 File Offset: 0x00623BE8
	public override void Refresh(IWeaponEvolveData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		bool isUnlock = data.IsUnlock;
		base.GetItem(2).SetUIActive(isUnlock);
		base.GetItem(4).SetUIActive(data.ShowLine);
		base.GetItem(5).SetUIActive(data.ShowLine);
		SurvivorsWeaponEvolve? survivorsWeaponEvolve = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeaponEvolve(data.EvolveId);
		if (survivorsWeaponEvolve == null)
		{
			return;
		}
		SurvivorsQuality? qualityConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetQualityConfig(survivorsWeaponEvolve.Value.Quality);
		if (qualityConfig == null)
		{
			return;
		}
		UUISprite sprite = base.GetSprite(1);
		UUISprite sprite2 = base.GetSprite(3);
		if (isUnlock)
		{
			sprite2.SetColor(FColor.FromHex(qualityConfig.Value.EvolveColor));
			sprite.SetUIActive(false);
			sprite2.SetUIActive(true);
			return;
		}
		sprite.SetColor(FColor.FromHex(qualityConfig.Value.EvolveColor));
		sprite.SetUIActive(true);
		sprite2.SetUIActive(false);
	}

	// Token: 0x0400AB4C RID: 43852
	public IWeaponEvolveData Data;
}
