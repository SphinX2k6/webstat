using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x02001A43 RID: 6723
public class SmallItemGridVisionRoleHeadComponent : SmallItemGridComponent
{
	// Token: 0x0600C073 RID: 49267 RVA: 0x0032D248 File Offset: 0x0032B448
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

	// Token: 0x0600C074 RID: 49268 RVA: 0x0032D2D2 File Offset: 0x0032B4D2
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemRoleS";
	}

	// Token: 0x0600C075 RID: 49269 RVA: 0x0032D2DC File Offset: 0x0032B4DC
	[NullableContext(2)]
	protected override void OnRefresh(object roleHeadInfo)
	{
		if (roleHeadInfo == null)
		{
			this.SetActive(false);
			return;
		}
		int num = (int)roleHeadInfo;
		if (num == 0)
		{
			this.SetActive(false);
			return;
		}
		UUITexture roleHeadTexture = base.GetTexture(0);
		RoleInfo? roleInfo;
		string text = (ConfigBase<RoleConfig>.Instance.GetRoleConfig(num) != null) ? roleInfo.GetValueOrDefault().Card : null;
		if (string.IsNullOrEmpty(text))
		{
			this.SetActive(false);
			return;
		}
		roleHeadTexture.SetUIActive(false);
		base.SetRoleIcon(text, roleHeadTexture, num, null, delegate(bool _)
		{
			roleHeadTexture.SetUIActive(true);
		});
		this.RefreshSpriteBg(num);
		this.RefreshLightBg(num);
		this.SetActive(true);
	}

	// Token: 0x0600C076 RID: 49270 RVA: 0x0032D397 File Offset: 0x0032B597
	private void RefreshSpriteBg(int roleHeadInfo)
	{
		base.GetSprite(2).SetUIActive(false);
	}

	// Token: 0x0600C077 RID: 49271 RVA: 0x0032D3A6 File Offset: 0x0032B5A6
	private void RefreshLightBg(int roleHeadInfo)
	{
		base.GetSprite(1).SetUIActive(true);
	}

	// Token: 0x02007D08 RID: 32008
	private class EChildType
	{
		// Token: 0x0402AA31 RID: 174641
		public const int RoleHeadTexture = 0;

		// Token: 0x0402AA32 RID: 174642
		public const int LightSprite = 1;

		// Token: 0x0402AA33 RID: 174643
		public const int SpriteBg = 2;
	}
}
