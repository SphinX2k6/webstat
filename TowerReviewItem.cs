using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002BFF RID: 11263
public class TowerReviewItem : GridProxyAbstract<int>
{
	// Token: 0x0601679B RID: 92059 RVA: 0x0063F37C File Offset: 0x0063D57C
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

	// Token: 0x0601679C RID: 92060 RVA: 0x0063F3E8 File Offset: 0x0063D5E8
	public override void Refresh(int towerId, bool isSelected, int gridIndex)
	{
		TowerConfig value = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(towerId).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), value.AreaName, Array.Empty<object>());
		int areaStars = ModelBase<TowerModel>.Instance.GetAreaStars(value.Difficulty, value.AreaNum, true);
		base.GetText(1).SetText(areaStars.ToString(), true);
	}

	// Token: 0x02008EF9 RID: 36601
	private enum EChildType
	{
		// Token: 0x04030083 RID: 196739
		TowerNameText,
		// Token: 0x04030084 RID: 196740
		StarNumberText
	}
}
