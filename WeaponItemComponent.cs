using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B49 RID: 11081
internal class WeaponItemComponent : GridProxyAbstract<int>
{
	// Token: 0x06016189 RID: 90505 RVA: 0x00621C6C File Offset: 0x0061FE6C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton))
		};
	}

	// Token: 0x0601618A RID: 90506 RVA: 0x00621D00 File Offset: 0x0061FF00
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.CachedSurvivorWeaponId = data;
		SurvivorsWeapon value = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(data).Value;
		SurvivorsWeaponEvolve value2 = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeaponDefaultEvolve(data).Value;
		SurvivorsQuality value3 = ConfigBase<SurvivorsRogueConfig>.Instance.GetQualityConfig(value2.Quality).Value;
		base.SetTextureByPath(value.Icon, base.GetTexture(2), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.Name, Array.Empty<object>());
		base.GetSprite(3).SetColor(FColor.FromHex(value3.WeaponColor));
	}

	// Token: 0x0601618B RID: 90507 RVA: 0x00621DAC File Offset: 0x0061FFAC
	private void OnClickButton()
	{
		SurvivorsRogueWeaponCard param = SurvivorsRogueCardDataFactory.CreateGeneralWeapon(this.CachedSurvivorWeaponId);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsCardTips, param, null);
	}

	// Token: 0x0601618C RID: 90508 RVA: 0x00621DD6 File Offset: 0x0061FFD6
	[NullableContext(1)]
	public override object GetKey(int data, int displayIndex)
	{
		return data;
	}

	// Token: 0x0400AA59 RID: 43609
	private int CachedSurvivorWeaponId = -1;
}
