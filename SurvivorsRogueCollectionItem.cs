using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D7F RID: 7551
public class SurvivorsRogueCollectionItem : UiPanelBase
{
	// Token: 0x0600DE2F RID: 56879 RVA: 0x003BC07B File Offset: 0x003BA27B
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUISprite))
		};
	}

	// Token: 0x0600DE30 RID: 56880 RVA: 0x003BC0B4 File Offset: 0x003BA2B4
	protected override void OnStart()
	{
		this.CollectionNumText = base.GetText(0);
		this.CollectionEfficiencyTipsSprite = base.GetSprite(1);
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0600DE31 RID: 56881 RVA: 0x003BC0E4 File Offset: 0x003BA2E4
	protected override void OnBeforeShow()
	{
		this.SequencePlayer.StopPlayingSequence(false, true);
		this.SequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0600DE32 RID: 56882 RVA: 0x003BC11C File Offset: 0x003BA31C
	public void Refresh(int collectionNum, bool efficiencyEnhance, bool playSequence)
	{
		if (playSequence)
		{
			this.SequencePlayer.PlayOrReplaySequenceByName(efficiencyEnhance ? "BuffAdd" : "Add", false, null);
		}
		this.CollectionNumText.SetText(collectionNum.ToString(), true);
	}

	// Token: 0x04006AAC RID: 27308
	[Nullable(2)]
	protected UUIText CollectionNumText;

	// Token: 0x04006AAD RID: 27309
	[Nullable(2)]
	protected UUISprite CollectionEfficiencyTipsSprite;

	// Token: 0x04006AAE RID: 27310
	[Nullable(1)]
	protected LevelSequencePlayer SequencePlayer;

	// Token: 0x02008105 RID: 33029
	private static class EComponentDefine
	{
		// Token: 0x0402BDDB RID: 179675
		public const int CollectionNum = 0;

		// Token: 0x0402BDDC RID: 179676
		public const int CollectionEfficiencyTips = 1;
	}
}
