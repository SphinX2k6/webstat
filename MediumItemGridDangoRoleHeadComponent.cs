using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x020019BC RID: 6588
public class MediumItemGridDangoRoleHeadComponent : MediumItemGridComponent
{
	// Token: 0x0600BD2F RID: 48431 RVA: 0x0032376C File Offset: 0x0032196C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BD30 RID: 48432 RVA: 0x003237F6 File Offset: 0x003219F6
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemRole";
	}

	// Token: 0x0600BD31 RID: 48433 RVA: 0x00323800 File Offset: 0x00321A00
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		DangoRoleHeadInfo dangoRoleHeadInfo = data as DangoRoleHeadInfo;
		if (dangoRoleHeadInfo == null)
		{
			return;
		}
		int? dangoConfigId = dangoRoleHeadInfo.DangoConfigId;
		if (dangoConfigId != null)
		{
			int? num = dangoConfigId;
			int num2 = 0;
			if (!(num.GetValueOrDefault() <= num2 & num != null))
			{
				AbyssLittleRole? dangoRoleById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoRoleById(dangoConfigId.Value);
				if (dangoRoleById == null)
				{
					base.SetUiActive(false);
					return;
				}
				UUITexture texture = base.GetTexture(0);
				base.SetTextureByPath(dangoRoleById.Value.Icon, texture, null, null);
				UUISprite sprite = base.GetSprite(1);
				if (sprite != null)
				{
					sprite.SetUIActive(false);
				}
				base.SetUiActive(true);
				return;
			}
		}
		base.SetUiActive(false);
	}

	// Token: 0x02007CBD RID: 31933
	private class EChildType
	{
		// Token: 0x0402A962 RID: 174434
		public const int HeadTexture = 0;

		// Token: 0x0402A963 RID: 174435
		public const int LightSprite = 1;

		// Token: 0x0402A964 RID: 174436
		public const int SpriteBg = 2;
	}
}
