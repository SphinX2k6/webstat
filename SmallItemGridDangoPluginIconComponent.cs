using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02001A1D RID: 6685
public class SmallItemGridDangoPluginIconComponent : SmallItemGridComponent
{
	// Token: 0x0600BFE0 RID: 49120 RVA: 0x0032BFE0 File Offset: 0x0032A1E0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BFE1 RID: 49121 RVA: 0x0032C049 File Offset: 0x0032A249
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.UnderText;
	}

	// Token: 0x0600BFE2 RID: 49122 RVA: 0x0032C04C File Offset: 0x0032A24C
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemChipIcon";
	}

	// Token: 0x0600BFE3 RID: 49123 RVA: 0x0032C053 File Offset: 0x0032A253
	[NullableContext(1)]
	public void RefreshByInfo(IDangoPluginIconInfo dangoPluginIconInfo)
	{
		this.OnRefresh(dangoPluginIconInfo);
	}

	// Token: 0x0600BFE4 RID: 49124 RVA: 0x0032C05C File Offset: 0x0032A25C
	[NullableContext(2)]
	protected override void OnRefresh(object tempData)
	{
		int pluginItemId = ((IDangoPluginIconInfo)tempData).PluginItemId;
		AbyssItem? dangoItemById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoItemById(pluginItemId);
		string pluginItemQualityIcon = ModelBase<DangoAbyssModel>.Instance.GetPluginItemQualityIcon(pluginItemId);
		if (dangoItemById == null || pluginItemQualityIcon == "")
		{
			this.SetActive(false);
			return;
		}
		int slotType = dangoItemById.Value.SlotType;
		UUITexture texture = base.GetTexture(1);
		int num;
		if (DangoAbyssDefine.iconSizeBySlotType.TryGetValue((DangoAbyssDefine.ESlotType)slotType, out num))
		{
			texture.SetWidth((float)num);
			texture.SetHeight((float)num);
		}
		base.SetTextureByPath(pluginItemQualityIcon, base.GetTexture(0), null, null);
		base.SetTextureByPath(dangoItemById.Value.IconMiddle, texture, null, null);
		this.SetActive(true);
	}

	// Token: 0x02007CF8 RID: 31992
	private enum EChildType
	{
		// Token: 0x0402AA0D RID: 174605
		TextureQuality,
		// Token: 0x0402AA0E RID: 174606
		TextureMain
	}
}
