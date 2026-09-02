using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200235E RID: 9054
[NullableContext(1)]
[Nullable(0)]
public class QteAnimItem
{
	// Token: 0x06011509 RID: 70921 RVA: 0x004C3936 File Offset: 0x004C1B36
	public void Init(UUIItem item)
	{
		this.Item = item;
		this.LevelSequencePlayer = new LevelSequencePlayer(this.Item);
	}

	// Token: 0x0601150A RID: 70922 RVA: 0x004C3950 File Offset: 0x004C1B50
	public void StartAnim(float delay = 0f)
	{
		this.StopDelayTimer();
		if (delay > 20f)
		{
			this.DelayTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.DelayTimer = null;
				this.StartAnim(0f);
			}, delay, null, null, true, 1f);
			return;
		}
		this.CurAnimName = "Start";
		this.PlayAnim(this.CurAnimName);
		this.DelayTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.DelayTimer = null;
			this.CurAnimName = "Loop";
			this.PlayAnim(this.CurAnimName);
		}, 400f, null, null, true, 1f);
	}

	// Token: 0x0601150B RID: 70923 RVA: 0x004C39D2 File Offset: 0x004C1BD2
	public void StopAnim()
	{
		this.StopDelayTimer();
		if (this.CurAnimName != null)
		{
			this.LevelSequencePlayer.StopSequenceByKey(this.CurAnimName, false, false);
		}
		this.CurAnimName = null;
		this.PlayAnim("Close");
	}

	// Token: 0x0601150C RID: 70924 RVA: 0x004C3A07 File Offset: 0x004C1C07
	public void PressAnim()
	{
		this.PlayAnim("Press");
	}

	// Token: 0x0601150D RID: 70925 RVA: 0x004C3A14 File Offset: 0x004C1C14
	private void PlayAnim(string animName)
	{
		this.LevelSequencePlayer.PlaySequencePurely(animName, false, false, null, null, false);
	}

	// Token: 0x0601150E RID: 70926 RVA: 0x004C3A3A File Offset: 0x004C1C3A
	private void StopDelayTimer()
	{
		if (this.DelayTimer != null)
		{
			TimerSystem.Instance.Remove(this.DelayTimer);
			this.DelayTimer = null;
		}
	}

	// Token: 0x0601150F RID: 70927 RVA: 0x004C3A5C File Offset: 0x004C1C5C
	public void Clear()
	{
		this.StopDelayTimer();
	}

	// Token: 0x04008803 RID: 34819
	[Nullable(2)]
	private UUIItem Item;

	// Token: 0x04008804 RID: 34820
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04008805 RID: 34821
	[Nullable(2)]
	private TimerHandle DelayTimer;

	// Token: 0x04008806 RID: 34822
	[Nullable(2)]
	private string CurAnimName;

	// Token: 0x04008807 RID: 34823
	private const int START_ANIM_TIME = 400;

	// Token: 0x04008808 RID: 34824
	private const string ANIM_START = "Start";

	// Token: 0x04008809 RID: 34825
	private const string ANIM_LOOP = "Loop";

	// Token: 0x0400880A RID: 34826
	private const string ANIM_CLOSE = "Close";

	// Token: 0x0400880B RID: 34827
	private const string ANIM_PRESS = "Press";
}
