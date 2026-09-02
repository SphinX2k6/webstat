using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001EFE RID: 7934
[Nullable(new byte[]
{
	0,
	1
})]
public class HonamiStoryAttrItem : GridProxyAbstract<IHonamiStoryAttrData>
{
	// Token: 0x0600ECDD RID: 60637 RVA: 0x00408530 File Offset: 0x00406730
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x0600ECDE RID: 60638 RVA: 0x004085CC File Offset: 0x004067CC
	[NullableContext(1)]
	public override void Refresh(IHonamiStoryAttrData data, bool isSelected, int gridIndex)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Name, Array.Empty<object>());
		base.SetTextureByPath(data.IconPath, base.GetTexture(0), null, null);
		bool flag = data.NewValue != data.OldValue;
		string newText = data.OldValue.ToString();
		string newText2 = data.NewValue.ToString();
		if (data.IsPercent)
		{
			int value = (data.OldValue != 0) ? 1 : 0;
			double num = (double)data.OldValue / 100.0;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("F");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			newText = num.ToString(defaultInterpolatedStringHandler.ToStringAndClear()) + "%";
			value = ((data.NewValue != 0) ? 1 : 0);
			num = (double)data.NewValue / 100.0;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("F");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			newText2 = num.ToString(defaultInterpolatedStringHandler.ToStringAndClear()) + "%";
		}
		base.GetText(2).SetText(newText, true);
		UUIText text = base.GetText(4);
		text.SetText(newText2, true);
		if (this.OriginColor == null)
		{
			this.OriginColor = new FColor?(text.Color);
		}
		if (flag)
		{
			FColor? fcolor = (data.NewValue < data.OldValue) ? new FColor?(text.changeColor) : this.OriginColor;
			text.SetColor(fcolor ?? FColor.FromHex("#ffffff"));
			return;
		}
		text.SetColor(FColor.FromHex("#ffffff"));
	}

	// Token: 0x040071D4 RID: 29140
	private FColor? OriginColor;

	// Token: 0x02008255 RID: 33365
	private enum EDefine
	{
		// Token: 0x0402C348 RID: 181064
		TexIcon,
		// Token: 0x0402C349 RID: 181065
		TxtName,
		// Token: 0x0402C34A RID: 181066
		TxtOldValue,
		// Token: 0x0402C34B RID: 181067
		PnlNew,
		// Token: 0x0402C34C RID: 181068
		TxtNewValue,
		// Token: 0x0402C34D RID: 181069
		SprLine
	}
}
