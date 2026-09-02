using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x020019BB RID: 6587
public class MediumItemGridDangoPluginIconComponent : MediumItemGridComponent
{
	// Token: 0x0600BD29 RID: 48425 RVA: 0x00323608 File Offset: 0x00321808
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

	// Token: 0x0600BD2A RID: 48426 RVA: 0x00323671 File Offset: 0x00321871
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.UnderText;
	}

	// Token: 0x0600BD2B RID: 48427 RVA: 0x00323674 File Offset: 0x00321874
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemChipIcon";
	}

	// Token: 0x0600BD2C RID: 48428 RVA: 0x0032367B File Offset: 0x0032187B
	[NullableContext(1)]
	public void RefreshByInfo(IDangoPluginIconInfo dangoPluginIconInfo)
	{
		this.OnRefresh(dangoPluginIconInfo);
	}

	// Token: 0x0600BD2D RID: 48429 RVA: 0x00323684 File Offset: 0x00321884
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		IDangoPluginIconInfo dangoPluginIconInfo = data as IDangoPluginIconInfo;
		if (dangoPluginIconInfo == null)
		{
			return;
		}
		int pluginItemId = dangoPluginIconInfo.PluginItemId;
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
			if (texture != null)
			{
				texture.SetWidth((float)num);
			}
			if (texture != null)
			{
				texture.SetHeight((float)num);
			}
		}
		base.SetTextureByPath(pluginItemQualityIcon, base.GetTexture(0), null, null);
		base.SetTextureByPath(dangoItemById.Value.IconMiddle, texture, null, null);
		this.SetActive(true);
	}

	// Token: 0x02007CBC RID: 31932
	private class EChildType
	{
		// Token: 0x0402A960 RID: 174432
		public const int TextureQuality = 0;

		// Token: 0x0402A961 RID: 174433
		public const int TextureMain = 1;
	}
}
