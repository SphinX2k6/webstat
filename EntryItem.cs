using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002B19 RID: 11033
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EntryItem : GridProxyAbstract<IEntryItemData>
{
	// Token: 0x0601609A RID: 90266 RVA: 0x0061D684 File Offset: 0x0061B884
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0601609B RID: 90267 RVA: 0x0061D6E0 File Offset: 0x0061B8E0
	protected override void OnStart()
	{
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(2),
			ViewType = ETermExplanationViewType.Center,
			ReportType = ETermExplanationReportType.SurvivorsRogue
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0601609C RID: 90268 RVA: 0x0061D71B File Offset: 0x0061B91B
	public override void Refresh(IEntryItemData data, bool isSelected, int gridIndex)
	{
		this.SetTextById(data.Text, data.Args);
		this.SetColorFromHex(data.Color);
	}

	// Token: 0x0601609D RID: 90269 RVA: 0x0061D73C File Offset: 0x0061B93C
	public void SetTextById(string text, string[] args)
	{
		List<object> list = new List<object>();
		foreach (string item in args)
		{
			list.Add(item);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), text, list.ToArray());
	}

	// Token: 0x0601609E RID: 90270 RVA: 0x0061D784 File Offset: 0x0061B984
	public void SetColorFromHex(string hex)
	{
		FColor color = FColor.FromHex(hex);
		UUITexture texture = base.GetTexture(0);
		if (texture != null)
		{
			texture.SetColor(color);
		}
		UUISprite sprite = base.GetSprite(1);
		if (sprite != null)
		{
			sprite.SetColor(color);
		}
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetColor(color);
	}

	// Token: 0x02008E5C RID: 36444
	[NullableContext(0)]
	private static class EEntry
	{
		// Token: 0x0402FDFF RID: 196095
		public const int SprBg = 0;

		// Token: 0x0402FE00 RID: 196096
		public const int SprPoint = 1;

		// Token: 0x0402FE01 RID: 196097
		public const int TxtContent = 2;
	}
}
