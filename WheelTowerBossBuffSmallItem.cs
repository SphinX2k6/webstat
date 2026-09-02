using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001669 RID: 5737
public class WheelTowerBossBuffSmallItem : GridProxyAbstract<int>
{
	// Token: 0x0600A099 RID: 41113 RVA: 0x002A0C6C File Offset: 0x0029EE6C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A09A RID: 41114 RVA: 0x002A0D54 File Offset: 0x0029EF54
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.BuffId = data;
		NewTowerBossBuff? bossBuffConfig = ConfigBase<WheelTowerConfig>.Instance.GetBossBuffConfig(data);
		if (bossBuffConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), bossBuffConfig.Value.SkillTitle, Array.Empty<object>());
		base.SetTextureByPath(bossBuffConfig.Value.SmallIcon, base.GetTexture(2), null, null);
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		sprite.SetColor(FColor.FromHex(bossBuffConfig.Value.BuffColor));
	}

	// Token: 0x0600A09B RID: 41115 RVA: 0x002A0DF0 File Offset: 0x0029EFF0
	private void OnButtonClick()
	{
		WheelTowerBossBuffData param = new WheelTowerBossBuffData
		{
			Round = 0,
			BuffId = this.BuffId,
			IsActivate = true
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerBossBuffTip, param, null);
	}

	// Token: 0x04004A3D RID: 19005
	private int BuffId;
}
