using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002BE8 RID: 11240
public class TowerBuffShowItem : GridProxyAbstract<long>
{
	// Token: 0x060166EE RID: 91886 RVA: 0x0063B344 File Offset: 0x00639544
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060166EF RID: 91887 RVA: 0x0063B3AD File Offset: 0x006395AD
	public override void Refresh(long data, bool isSelected, int gridIndex)
	{
		this.CurrentBuffId = data;
		this.RefreshView();
	}

	// Token: 0x060166F0 RID: 91888 RVA: 0x0063B3BC File Offset: 0x006395BC
	private void RefreshView()
	{
		string towerBuffDesc = ConfigBase<TowerClimbConfig>.Instance.GetTowerBuffDesc(this.CurrentBuffId);
		base.GetText(1).SetText(towerBuffDesc, true);
		string towerBuffIcon = ConfigBase<TowerClimbConfig>.Instance.GetTowerBuffIcon(this.CurrentBuffId);
		base.SetTextureByPath(towerBuffIcon, base.GetTexture(0), null, null);
		UUITexture texture = base.GetTexture(0);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(true);
	}

	// Token: 0x0400ADB9 RID: 44473
	private long CurrentBuffId;

	// Token: 0x02008EDE RID: 36574
	private enum EChildType
	{
		// Token: 0x0402FFED RID: 196589
		Icon,
		// Token: 0x0402FFEE RID: 196590
		Desc
	}
}
