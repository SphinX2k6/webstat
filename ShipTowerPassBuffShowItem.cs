using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020029C5 RID: 10693
public class ShipTowerPassBuffShowItem : GridProxyAbstract<TItem>
{
	// Token: 0x0601552D RID: 87341 RVA: 0x005E8C00 File Offset: 0x005E6E00
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0601552E RID: 87342 RVA: 0x005E8C5A File Offset: 0x005E6E5A
	public override void Refresh(TItem data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x0601552F RID: 87343 RVA: 0x005E8C64 File Offset: 0x005E6E64
	public void Refresh(TItem data)
	{
		this.ItemData = data;
		ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(this.ItemData.ItemData.ItemId);
		if (config == null)
		{
			return;
		}
		ItemInfo value = config.Value;
		QualityInfo? qualityConfig = ConfigBase<ItemConfig>.Instance.GetQualityConfig(value.QualityId);
		if (qualityConfig == null)
		{
			return;
		}
		QualityInfo value2 = qualityConfig.Value;
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.ShowTextNew(value.Name);
			text.SetColor(FColor.FromHex(value2.DropColor ?? ""));
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.ShowTextNew(value.AttributesDescription);
		}
		base.SetTextureByPath(value.Icon ?? "", base.GetTexture(0), null, null);
	}

	// Token: 0x0400A44D RID: 42061
	private TItem ItemData;

	// Token: 0x02008D22 RID: 36130
	private static class EChildType
	{
		// Token: 0x0402F787 RID: 194439
		public const int TextureIcon = 0;

		// Token: 0x0402F788 RID: 194440
		public const int TxtName = 1;

		// Token: 0x0402F789 RID: 194441
		public const int TxtDesc = 2;
	}
}
