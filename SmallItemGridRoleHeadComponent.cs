using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Skin;
using UnrealEngine;

// Token: 0x02001A39 RID: 6713
public class SmallItemGridRoleHeadComponent : SmallItemGridComponent
{
	// Token: 0x0600C041 RID: 49217 RVA: 0x0032CB0C File Offset: 0x0032AD0C
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

	// Token: 0x0600C042 RID: 49218 RVA: 0x0032CB96 File Offset: 0x0032AD96
	protected override void OnStart()
	{
		this.RefreshSpriteBg();
		this.RefreshLightBg();
	}

	// Token: 0x0600C043 RID: 49219 RVA: 0x0032CBA4 File Offset: 0x0032ADA4
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemRoleS";
	}

	// Token: 0x0600C044 RID: 49220 RVA: 0x0032CBAC File Offset: 0x0032ADAC
	[NullableContext(2)]
	protected override void OnRefresh(object roleSkinId)
	{
		if (roleSkinId == null)
		{
			this.SetActive(false);
			return;
		}
		int num = (int)roleSkinId;
		UUITexture roleHeadTexture = base.GetTexture(0);
		RoleSkin? roleSkin;
		string text = (ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(num) != null) ? roleSkin.GetValueOrDefault().Card : null;
		if (string.IsNullOrEmpty(text))
		{
			this.SetActive(false);
			return;
		}
		roleHeadTexture.SetUIActive(false);
		base.SetRoleSkinIcon(text, roleHeadTexture, num, null, delegate(bool _)
		{
			roleHeadTexture.SetUIActive(true);
		});
		this.SetActive(true);
	}

	// Token: 0x0600C045 RID: 49221 RVA: 0x0032CC50 File Offset: 0x0032AE50
	private void RefreshSpriteBg()
	{
		UUISprite sprite = base.GetSprite(2);
		sprite.SetUIActive(true);
		string visionHeadSprBgA = ConfigBase<PhantomBattleConfig>.Instance.GetVisionHeadSprBgA();
		this.SetSpriteByPath(visionHeadSprBgA, sprite, false, null, null);
	}

	// Token: 0x0600C046 RID: 49222 RVA: 0x0032CC8C File Offset: 0x0032AE8C
	private void RefreshLightBg()
	{
		UUISprite sprite = base.GetSprite(1);
		sprite.SetUIActive(true);
		string visionHeadLightBgA = ConfigBase<PhantomBattleConfig>.Instance.GetVisionHeadLightBgA();
		this.SetSpriteByPath(visionHeadLightBgA, sprite, false, null, null);
	}

	// Token: 0x02007D03 RID: 32003
	private class EChildType
	{
		// Token: 0x0402AA20 RID: 174624
		public const int RoleHeadTexture = 0;

		// Token: 0x0402AA21 RID: 174625
		public const int LightSprite = 1;

		// Token: 0x0402AA22 RID: 174626
		public const int SpriteBg = 2;
	}
}
