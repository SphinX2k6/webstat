using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020012E0 RID: 4832
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoMonopolyBuffStateItem : GridProxyAbstract<IDangoMonopolyRoundBuffData>
{
	// Token: 0x06008300 RID: 33536 RVA: 0x0022A9B4 File Offset: 0x00228BB4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUITexture))
		};
	}

	// Token: 0x06008301 RID: 33537 RVA: 0x0022AA50 File Offset: 0x00228C50
	public override void Refresh(IDangoMonopolyRoundBuffData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(this.ItemData.IsActive);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetUIActive(!this.ItemData.IsActive);
		}
		UUISprite sprite = base.GetSprite(2);
		if (sprite != null)
		{
			sprite.SetUIActive(this.ItemData.IsActive);
		}
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.ShowTextNew(this.ItemData.PropertyDesc);
		}
		UUIText text2 = base.GetText(4);
		if (text2 != null)
		{
			text2.ShowTextNew(this.ItemData.PropertyDesc);
		}
		base.SetTextureByPath(this.ItemData.DangoIcon, base.GetTexture(5), null, null);
	}

	// Token: 0x04003E1D RID: 15901
	private IDangoMonopolyRoundBuffData ItemData;

	// Token: 0x04003E1E RID: 15902
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<IDangoMonopolyRoundBuffData> ClickCallBack;

	// Token: 0x02007667 RID: 30311
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028CD2 RID: 167122
		ItemFinish,
		// Token: 0x04028CD3 RID: 167123
		ItemUnFinish,
		// Token: 0x04028CD4 RID: 167124
		SpriteActive,
		// Token: 0x04028CD5 RID: 167125
		TxtNameActive,
		// Token: 0x04028CD6 RID: 167126
		TxtNameUnActive,
		// Token: 0x04028CD7 RID: 167127
		TextureIcon
	}
}
