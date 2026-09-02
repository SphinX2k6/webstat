using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200166D RID: 5741
internal class BossTagItem : GridProxyAbstract<int>
{
	// Token: 0x0600A0AC RID: 41132 RVA: 0x002A147C File Offset: 0x0029F67C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A0AD RID: 41133 RVA: 0x002A1506 File Offset: 0x0029F706
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.RefreshByData(data);
	}

	// Token: 0x0600A0AE RID: 41134 RVA: 0x002A1510 File Offset: 0x0029F710
	public void RefreshByData(int data)
	{
		NewTowerTag? tagConfigByTagId = ConfigBase<WheelTowerConfig>.Instance.GetTagConfigByTagId(data);
		if (tagConfigByTagId == null)
		{
			return;
		}
		base.GetText(1).ShowTextNew(tagConfigByTagId.Value.Name);
		base.GetSprite(0).SetColor(FColor.FromHex(tagConfigByTagId.Value.Color));
		this.SetSpriteByPath(tagConfigByTagId.Value.Path, base.GetSprite(2), false, null, null);
	}
}
