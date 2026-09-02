using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002B11 RID: 11025
public class SurvivorsWeaponAttributeIconItem : GridProxyAbstract<int>
{
	// Token: 0x0601607B RID: 90235 RVA: 0x0061CE80 File Offset: 0x0061B080
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture))
		};
	}

	// Token: 0x0601607C RID: 90236 RVA: 0x0061CEA4 File Offset: 0x0061B0A4
	public override void Refresh(int attributeId, bool isSelected, int gridIndex)
	{
		SurvivorsProperty? propertyConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetPropertyConfig(attributeId);
		if (propertyConfig == null)
		{
			return;
		}
		base.SetTextureShowUntilLoaded(propertyConfig.Value.Icon, base.GetTexture(0), null);
	}

	// Token: 0x02008E5A RID: 36442
	private static class EComponents
	{
		// Token: 0x0402FDFB RID: 196091
		public const int TexAttribute = 0;
	}
}
