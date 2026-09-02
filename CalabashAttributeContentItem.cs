using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020017FE RID: 6142
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class CalabashAttributeContentItem : GridProxyAbstract<CalabashAttributeContentData>
{
	// Token: 0x0600AE71 RID: 44657 RVA: 0x002E6986 File Offset: 0x002E4B86
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600AE72 RID: 44658 RVA: 0x002E69C0 File Offset: 0x002E4BC0
	public override void Refresh(CalabashAttributeContentData data, bool isSelected, int gridIndex)
	{
		if (data.Type == ECalabashLevelSubShowType.UpgradeTarget)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), data.StringKey, Array.Empty<object>());
			if (data.StringValue != null)
			{
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), data.StringValue.TextKey, data.StringValue.Params);
				return;
			}
		}
		else if (data.Type == ECalabashLevelSubShowType.UpgradeQuality)
		{
			int key = data.Key;
			int value = data.Value;
			QualityInfo? qualityConfig = ConfigBase<ItemConfig>.Instance.GetQualityConfig(key);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), (qualityConfig != null) ? qualityConfig.GetValueOrDefault().Name : null, Array.Empty<object>());
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetColor(FColor.FromHex(qualityConfig.Value.DropColor));
			}
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.SetText(StringUtils.Format("{0}%", new string[]
				{
					value.ToString()
				}), true);
			}
			UUIText text3 = base.GetText(1);
			if (text3 == null)
			{
				return;
			}
			text3.SetColor(FColor.FromHex(qualityConfig.Value.DropColor));
		}
	}
}
