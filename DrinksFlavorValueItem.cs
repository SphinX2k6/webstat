using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001015 RID: 4117
public class DrinksFlavorValueItem : UiPanelBase
{
	// Token: 0x06006B18 RID: 27416 RVA: 0x001C0030 File Offset: 0x001BE230
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
	}

	// Token: 0x06006B19 RID: 27417 RVA: 0x001C00CC File Offset: 0x001BE2CC
	protected override void OnStart()
	{
		this.LevelSequence = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06006B1A RID: 27418 RVA: 0x001C00DF File Offset: 0x001BE2DF
	[NullableContext(1)]
	public void RefreshState(bool isActive, string[] value, bool needAlpha)
	{
		this.RefreshAnim(isActive);
		this.RefreshTxt(value, needAlpha);
	}

	// Token: 0x06006B1B RID: 27419 RVA: 0x001C00F0 File Offset: 0x001BE2F0
	[NullableContext(1)]
	private void RefreshTxt(string[] value, bool needAlpha)
	{
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetUIActive(value.Length == 1);
		}
		UUIText text2 = base.GetText(4);
		if (text2 != null)
		{
			text2.SetUIActive(value.Length > 1);
		}
		UUIText text3 = base.GetText(5);
		if (text3 != null)
		{
			text3.SetUIActive(value.Length > 1);
		}
		if (value.Length == 1)
		{
			UUIText text4 = base.GetText(2);
			if (text4 != null)
			{
				text4.SetText(value[0], true);
			}
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetAlpha(needAlpha ? 0.5f : 1f);
			return;
		}
		else
		{
			UUIText text5 = base.GetText(4);
			if (text5 != null)
			{
				text5.SetText(value[0], true);
			}
			UUIText text6 = base.GetText(5);
			if (text6 != null)
			{
				text6.SetText(value[1], true);
			}
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 == null)
			{
				return;
			}
			rootItem2.SetAlpha(1f);
			return;
		}
	}

	// Token: 0x06006B1C RID: 27420 RVA: 0x001C01C4 File Offset: 0x001BE3C4
	private void RefreshAnim(bool isActive)
	{
		if (isActive != this.OldActive || isActive)
		{
			this.OldActive = isActive;
			if (isActive)
			{
				LevelSequencePlayer levelSequence = this.LevelSequence;
				if (levelSequence != null && levelSequence.IsPlayingSequence("Close"))
				{
					LevelSequencePlayer levelSequence2 = this.LevelSequence;
					if (levelSequence2 != null)
					{
						levelSequence2.StopCurrentSequence(false, true);
					}
				}
				LevelSequencePlayer levelSequence3 = this.LevelSequence;
				if (levelSequence3 == null)
				{
					return;
				}
				levelSequence3.PlayLevelSequenceByName("Start", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer levelSequence4 = this.LevelSequence;
				if (levelSequence4 != null && levelSequence4.IsPlayingSequence("Start"))
				{
					LevelSequencePlayer levelSequence5 = this.LevelSequence;
					if (levelSequence5 != null)
					{
						levelSequence5.StopCurrentSequence(false, true);
					}
				}
				LevelSequencePlayer levelSequence6 = this.LevelSequence;
				if (levelSequence6 == null)
				{
					return;
				}
				levelSequence6.PlayLevelSequenceByName("Close", false, null, false);
			}
		}
	}

	// Token: 0x040032E5 RID: 13029
	protected bool OldActive;

	// Token: 0x040032E6 RID: 13030
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequence;

	// Token: 0x020073F7 RID: 29687
	private class EValue
	{
		// Token: 0x040281CE RID: 164302
		public const int PanelOffset = 0;

		// Token: 0x040281CF RID: 164303
		public const int TexIcon = 1;

		// Token: 0x040281D0 RID: 164304
		public const int TxtValue = 2;

		// Token: 0x040281D1 RID: 164305
		public const int PanelActive = 3;

		// Token: 0x040281D2 RID: 164306
		public const int TxtActive1 = 4;

		// Token: 0x040281D3 RID: 164307
		public const int TxtActive2 = 5;
	}
}
