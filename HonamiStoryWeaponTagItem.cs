using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001F6F RID: 8047
public class HonamiStoryWeaponTagItem : GridProxyAbstract<int>
{
	// Token: 0x0600F106 RID: 61702 RVA: 0x0041DF90 File Offset: 0x0041C190
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600F107 RID: 61703 RVA: 0x0041DFCC File Offset: 0x0041C1CC
	public override void Refresh(int pluginId, bool isSelected, int gridIndex)
	{
		HonamiStoryPluginTag? pluginTag = ConfigBase<HonamiStoryConfig>.Instance.GetPluginTag(pluginId);
		if (pluginTag == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), pluginTag.Value.Name, Array.Empty<object>());
		base.GetSprite(0).SetColor(FColor.FromHex(pluginTag.Value.Color));
	}

	// Token: 0x0200830C RID: 33548
	private enum EHonamiStoryWeaponTagItemComponent
	{
		// Token: 0x0402C6E8 RID: 181992
		BgSprite,
		// Token: 0x0402C6E9 RID: 181993
		DescText
	}
}
