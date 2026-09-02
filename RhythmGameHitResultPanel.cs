using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001142 RID: 4418
[NullableContext(2)]
[Nullable(0)]
public class RhythmGameHitResultPanel : UiPanelBase
{
	// Token: 0x0600745C RID: 29788 RVA: 0x001E7688 File Offset: 0x001E5888
	protected override void OnBeforeCreate()
	{
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIActive(false);
		}
		UUIItem rootItem2 = this.RootItem;
		object obj;
		if (rootItem2 == null)
		{
			obj = null;
		}
		else
		{
			AActor owner = rootItem2.GetOwner();
			obj = ((owner != null) ? owner.GetComponentByClass(UUITexture.StaticClass()) : null);
		}
		this.IconHitResult = (obj as UUITexture);
	}

	// Token: 0x0600745D RID: 29789 RVA: 0x001E76EC File Offset: 0x001E58EC
	public void SetHitResult(EKuroRhythmGameRating result)
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIActive(true);
		}
		UiResource? uiResource;
		base.SetTextureByPath(((ConfigUiResourceById.GetConfig(RhythmGameModelDefine.RhythmGameHitResultTexture[result], true) != null) ? uiResource.GetValueOrDefault().Path : null) ?? "", this.IconHitResult, null, null);
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.StopPlayingSequence(false, true);
		}
		LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
		if (sequencePlayer2 == null)
		{
			return;
		}
		sequencePlayer2.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x04003809 RID: 14345
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x0400380A RID: 14346
	private UUITexture IconHitResult;
}
