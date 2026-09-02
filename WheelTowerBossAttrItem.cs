using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001638 RID: 5688
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerBossAttrItem : UiPanelBase
{
	// Token: 0x0600A025 RID: 40997 RVA: 0x0029E0E8 File Offset: 0x0029C2E8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A026 RID: 40998 RVA: 0x0029E193 File Offset: 0x0029C393
	protected override void OnStart()
	{
		this.TagLayout = new GenericLayout<WheelTowerBossTagItem, int>(base.GetHorizontalLayout(2), new Func<WheelTowerBossTagItem>(this.CreateTagItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0600A027 RID: 40999 RVA: 0x0029E1C8 File Offset: 0x0029C3C8
	public void Refresh(IWheelTowerBossAttrData attrData)
	{
		string text = ConfigMultiTextLang.GetLocalTextNew(attrData.AttrName, null) ?? string.Empty;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "WheelTower_BossAttr_Level", new <>z__ReadOnlyArray<object>(new object[]
		{
			attrData.AttrLevel,
			text
		}));
		ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(attrData.ElementId);
		if (elementConfig != null)
		{
			base.SetTextureByPath(elementConfig.Value.Icon, base.GetTexture(0), null, null);
		}
		GenericLayout<WheelTowerBossTagItem, int> tagLayout = this.TagLayout;
		if (tagLayout == null)
		{
			return;
		}
		tagLayout.RefreshByData(attrData.TagIdList, null, false);
	}

	// Token: 0x0600A028 RID: 41000 RVA: 0x0029E276 File Offset: 0x0029C476
	private WheelTowerBossTagItem CreateTagItem()
	{
		return new WheelTowerBossTagItem();
	}

	// Token: 0x040049A0 RID: 18848
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<WheelTowerBossTagItem, int> TagLayout;
}
