using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001F1A RID: 7962
[Nullable(new byte[]
{
	0,
	1
})]
public class HonamiStoryTipsPropertyItem : GridProxyAbstract<IHonamiStoryTipsPropertyData>
{
	// Token: 0x0600EE1F RID: 60959 RVA: 0x004106EC File Offset: 0x0040E8EC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x0600EE20 RID: 60960 RVA: 0x0041075C File Offset: 0x0040E95C
	[NullableContext(1)]
	public override void Refresh(IHonamiStoryTipsPropertyData data, bool isSelected, int gridIndex)
	{
		int propId = data.PropId;
		HonamiStoryProp? honamiStoryProp = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryProp(propId);
		if (honamiStoryProp == null)
		{
			return;
		}
		PropertyIndexConfig instance = ConfigBase<PropertyIndexConfig>.Instance;
		string text = (instance != null) ? instance.GetPropertyIndexName(honamiStoryProp.Value.PropId) : null;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), text ?? string.Empty, Array.Empty<object>());
		PropertyIndexConfig instance2 = ConfigBase<PropertyIndexConfig>.Instance;
		string text2 = (instance2 != null) ? instance2.GetPropertyIndexIcon(honamiStoryProp.Value.PropId) : null;
		base.SetTextureByPath(text2 ?? string.Empty, base.GetTexture(1), null, null);
		int num = data.PropertyNumber ?? honamiStoryProp.Value.StandardProperty;
		string newText = string.Empty;
		if (honamiStoryProp.Value.ShowPercent)
		{
			newText = ((double)num / 100.0).ToString("F1") + "%";
		}
		else
		{
			newText = num.ToString();
		}
		UUIText text3 = base.GetText(3);
		if (text3 == null)
		{
			return;
		}
		text3.SetText(newText, true);
	}

	// Token: 0x02008286 RID: 33414
	private enum EDefine
	{
		// Token: 0x0402C45A RID: 181338
		SpriteBg,
		// Token: 0x0402C45B RID: 181339
		TexIcon,
		// Token: 0x0402C45C RID: 181340
		TxtName,
		// Token: 0x0402C45D RID: 181341
		TxtNum
	}
}
