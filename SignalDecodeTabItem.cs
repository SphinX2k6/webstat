using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A1F RID: 10783
public class SignalDecodeTabItem : UiPanelBase
{
	// Token: 0x0601585F RID: 88159 RVA: 0x005F7B08 File Offset: 0x005F5D08
	[NullableContext(1)]
	public SignalDecodeTabItem(int tabIndex, int waveformId, UUIItem item)
	{
		this.TabIndex = tabIndex;
		this.WaveformId = waveformId;
		base.CreateThenShowByActor(item.GetOwner(), null);
	}

	// Token: 0x06015860 RID: 88160 RVA: 0x005F7B2C File Offset: 0x005F5D2C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x06015861 RID: 88161 RVA: 0x005F7B9C File Offset: 0x005F5D9C
	protected override void OnStart()
	{
		base.GetText(3).SetText(this.TabIndex.ToString(), true);
	}

	// Token: 0x06015862 RID: 88162 RVA: 0x005F7BB8 File Offset: 0x005F5DB8
	public void OnProcess(int processIndex)
	{
		bool flag = this.TabIndex == processIndex;
		UUISprite sprite = base.GetSprite(0);
		UUIItem sprite2 = base.GetSprite(1);
		sprite.SetUIActive(!flag);
		sprite2.SetUIActive(flag);
		UUIText text = base.GetText(3);
		if (flag)
		{
			text.SetColor(FColor.FromHex("#000000FF"));
			text.SetAnchorOffsetY(30f);
			return;
		}
		text.SetAnchorOffsetY(0f);
	}

	// Token: 0x06015863 RID: 88163 RVA: 0x005F7C20 File Offset: 0x005F5E20
	public void UpdateColor(SignalDecodeTabColor tabColorConfig)
	{
		base.GetSprite(0).SetColor(FColor.FromHex(tabColorConfig.ActiveColor ?? ""));
		base.GetText(3).SetColor(FColor.FromHex(tabColorConfig.ActiveColor ?? ""));
		base.GetSprite(1).SetColor(FColor.FromHex(tabColorConfig.ActiveColor ?? ""));
		base.GetSprite(2).SetColor(FColor.FromHex(tabColorConfig.ActiveColor ?? ""));
	}

	// Token: 0x06015864 RID: 88164 RVA: 0x005F7CB1 File Offset: 0x005F5EB1
	public void SetComplete()
	{
		base.GetSprite(2).SetUIActive(true);
	}

	// Token: 0x0400A5BC RID: 42428
	[Nullable(1)]
	private const string BLACK_COLOR = "#000000FF";

	// Token: 0x0400A5BD RID: 42429
	public readonly int TabIndex;

	// Token: 0x0400A5BE RID: 42430
	public readonly int WaveformId;

	// Token: 0x02008DA3 RID: 36259
	private static class EChildComponent
	{
		// Token: 0x0402F9FF RID: 195071
		public const int Border = 0;

		// Token: 0x0402FA00 RID: 195072
		public const int SelectSprite = 1;

		// Token: 0x0402FA01 RID: 195073
		public const int FinishedSprite = 2;

		// Token: 0x0402FA02 RID: 195074
		public const int TabIndex = 3;
	}
}
