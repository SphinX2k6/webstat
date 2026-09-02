using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001018 RID: 4120
public class DrinksFlavorBubble : UiPanelBase
{
	// Token: 0x06006B2C RID: 27436 RVA: 0x001C0913 File Offset: 0x001BEB13
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06006B2D RID: 27437 RVA: 0x001C094C File Offset: 0x001BEB4C
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText("+0", true);
	}

	// Token: 0x06006B2E RID: 27438 RVA: 0x001C0978 File Offset: 0x001BEB78
	public void Refresh(EDrinksFlavorType type, int value, float locX, float locZ)
	{
		base.SetTextureByPath(ConfigBase<DrinksConfig>.Instance.GetFlavorType(type).Value.Icon, base.GetTexture(0), null, null);
		UUIText text = base.GetText(1);
		if (text != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("+");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		this.Location.X = (double)locX;
		this.Location.Z = (double)locZ;
		UUIItem rootItem = this.RootItem;
		FVector fvector = this.Location.ToUeVectorOld();
		rootItem.SetUIWorldLocation(fvector);
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x040032EE RID: 13038
	[Nullable(1)]
	protected Vector Location = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x040032EF RID: 13039
	[Nullable(2)]
	protected LevelSequencePlayer SequencePlayer;

	// Token: 0x020073FB RID: 29691
	private class EBubble
	{
		// Token: 0x040281DD RID: 164317
		public const int TexIcon = 0;

		// Token: 0x040281DE RID: 164318
		public const int TxtValue = 1;
	}
}
