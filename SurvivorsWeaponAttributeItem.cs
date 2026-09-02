using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002B14 RID: 11028
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsWeaponAttributeItem : GridProxyAbstract<ISurvivorsWeaponAttributeData>
{
	// Token: 0x06016083 RID: 90243 RVA: 0x0061CFEC File Offset: 0x0061B1EC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06016084 RID: 90244 RVA: 0x0061D048 File Offset: 0x0061B248
	[NullableContext(1)]
	public override void Refresh(ISurvivorsWeaponAttributeData data, bool isSelected, int gridIndex)
	{
		SurvivorsWeaponLv? survivorsWeaponLv = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeaponLv(data.WeaponLvId);
		SurvivorsProperty? propertyConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetPropertyConfig(data.AttrId);
		if (propertyConfig == null || survivorsWeaponLv == null)
		{
			return;
		}
		base.SetTextureShowUntilLoaded(propertyConfig.Value.Icon, base.GetTexture(0), null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), survivorsWeaponLv.Value.Describe, Array.Empty<object>());
		base.GetItem(2).SetUIActive(gridIndex % 2 == 0);
	}

	// Token: 0x02008E5B RID: 36443
	private static class EAttributeComponents
	{
		// Token: 0x0402FDFC RID: 196092
		public const int TexIcon = 0;

		// Token: 0x0402FDFD RID: 196093
		public const int TxtDesc = 1;

		// Token: 0x0402FDFE RID: 196094
		public const int BgItem = 2;
	}
}
