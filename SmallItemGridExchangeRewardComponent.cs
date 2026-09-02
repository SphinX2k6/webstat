using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001A24 RID: 6692
public class SmallItemGridExchangeRewardComponent : SmallItemGridVisibleComponent
{
	// Token: 0x0600BFFE RID: 49150 RVA: 0x0032C487 File Offset: 0x0032A687
	[NullableContext(2)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBFirstReward";
	}

	// Token: 0x0600BFFF RID: 49151 RVA: 0x0032C490 File Offset: 0x0032A690
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C000 RID: 49152 RVA: 0x0032C4F9 File Offset: 0x0032A6F9
	protected override void OnStart()
	{
		base.GetSprite(1).SetColor(FColor.FromHex("#468fba"));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "InstanceDungeon_ExchangeReward", Array.Empty<object>());
	}

	// Token: 0x02007CFC RID: 31996
	private enum EComponents
	{
		// Token: 0x0402AA15 RID: 174613
		TxtContent,
		// Token: 0x0402AA16 RID: 174614
		SpriteBg
	}
}
