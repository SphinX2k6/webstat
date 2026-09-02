using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001B33 RID: 6963
[NullableContext(1)]
[Nullable(0)]
public class UiTabSequence : UiTabViewBehavior
{
	// Token: 0x0600C8DB RID: 51419 RVA: 0x003537F1 File Offset: 0x003519F1
	public void SetRootItem(UiTabViewBase tabView)
	{
		this.TabView = tabView;
	}

	// Token: 0x0600C8DC RID: 51420 RVA: 0x003537FA File Offset: 0x003519FA
	public override void Init()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.TabView.GetRootItem());
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.FinishSequenceEvent), false);
	}

	// Token: 0x0600C8DD RID: 51421 RVA: 0x0035382C File Offset: 0x00351A2C
	public override void Begin()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0600C8DE RID: 51422 RVA: 0x00353854 File Offset: 0x00351A54
	public override void ShowFromToggle()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("Sle", false, null, false);
	}

	// Token: 0x0600C8DF RID: 51423 RVA: 0x0035387C File Offset: 0x00351A7C
	public override void ShowFromView()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("ShowView", false, null, false);
	}

	// Token: 0x0600C8E0 RID: 51424 RVA: 0x003538A4 File Offset: 0x00351AA4
	public override void Hide()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.StopCurrentSequence(false, false);
	}

	// Token: 0x0600C8E1 RID: 51425 RVA: 0x003538B8 File Offset: 0x00351AB8
	public override void Destroy()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		Dictionary<string, HashSet<Action>> sequenceFinishEvent = this.SequenceFinishEvent;
		if (sequenceFinishEvent == null)
		{
			return;
		}
		sequenceFinishEvent.Clear();
	}

	// Token: 0x0600C8E2 RID: 51426 RVA: 0x003538E4 File Offset: 0x00351AE4
	public void PlaySequence(string sequenceName)
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
	}

	// Token: 0x0600C8E3 RID: 51427 RVA: 0x00353910 File Offset: 0x00351B10
	public void AddSequenceFinishEvent(string sequenceName, Action finishEvent, bool clear = false)
	{
		if (this.SequenceFinishEvent == null)
		{
			this.SequenceFinishEvent = new Dictionary<string, HashSet<Action>>();
		}
		HashSet<Action> hashSet;
		if (!this.SequenceFinishEvent.TryGetValue(sequenceName, out hashSet))
		{
			hashSet = new HashSet<Action>();
			this.SequenceFinishEvent[sequenceName] = hashSet;
		}
		else if (clear)
		{
			hashSet.Clear();
		}
		hashSet.Add(finishEvent);
	}

	// Token: 0x0600C8E4 RID: 51428 RVA: 0x00353966 File Offset: 0x00351B66
	[NullableContext(2)]
	public LevelSequencePlayer GetLevelSequencePlayer()
	{
		return this.LevelSequencePlayer;
	}

	// Token: 0x0600C8E5 RID: 51429 RVA: 0x00353970 File Offset: 0x00351B70
	private void FinishSequenceEvent(string sequenceName)
	{
		Dictionary<string, HashSet<Action>> sequenceFinishEvent = this.SequenceFinishEvent;
		HashSet<Action> hashSet;
		if (sequenceFinishEvent == null || !sequenceFinishEvent.TryGetValue(sequenceName, out hashSet))
		{
			return;
		}
		foreach (Action action in hashSet)
		{
			if (action != null)
			{
				action();
			}
		}
	}

	// Token: 0x0400604A RID: 24650
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400604B RID: 24651
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<string, HashSet<Action>> SequenceFinishEvent;

	// Token: 0x0400604C RID: 24652
	[Nullable(2)]
	private UiTabViewBase TabView;
}
