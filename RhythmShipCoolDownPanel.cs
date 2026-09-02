using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001148 RID: 4424
[NullableContext(2)]
[Nullable(0)]
public class RhythmShipCoolDownPanel : UiPanelBase
{
	// Token: 0x06007497 RID: 29847 RVA: 0x001E90E4 File Offset: 0x001E72E4
	protected override void OnBeforeCreate()
	{
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetUIActive(false);
	}

	// Token: 0x06007498 RID: 29848 RVA: 0x001E9108 File Offset: 0x001E7308
	public void PlayCoolDownSequence(TTimerAction callback)
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIActive(true);
		}
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
		if (callback != null)
		{
			this.Callback = callback;
			this.CallbackHandle = TimerSystem.Instance.Delay(this.Callback, 3000f, null, null, true, 1f);
		}
	}

	// Token: 0x06007499 RID: 29849 RVA: 0x001E9178 File Offset: 0x001E7378
	public void StopCoolDownSequence()
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.StopPlayingSequence(false, true);
		}
		if (this.CallbackHandle != null && TimerSystem.Instance.Has(this.CallbackHandle))
		{
			TimerSystem.Instance.Remove(this.CallbackHandle);
			this.CallbackHandle = null;
		}
		this.Callback = null;
	}

	// Token: 0x0400383F RID: 14399
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x04003840 RID: 14400
	private TTimerAction Callback;

	// Token: 0x04003841 RID: 14401
	private TimerHandle CallbackHandle;
}
