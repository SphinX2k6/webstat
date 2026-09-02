using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002211 RID: 8721
public class LordGymUnLockItem : UiPanelBase
{
	// Token: 0x06010779 RID: 67449 RVA: 0x0047F445 File Offset: 0x0047D645
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x0601077A RID: 67450 RVA: 0x0047F468 File Offset: 0x0047D668
	protected override void OnStart()
	{
		this.LevelSequence = new LevelSequencePlayer(this.RootItem);
		this.LevelSequence.BindSequenceCloseEvent(new TSequenceEndEvent(this.SequenceFinishEvent), false);
	}

	// Token: 0x0601077B RID: 67451 RVA: 0x0047F494 File Offset: 0x0047D694
	public void RefreshLord(int lordId)
	{
		LordGym? lordGymConfig = ConfigBase<LordGymConfig>.Instance.GetLordGymConfig(lordId);
		if (lordGymConfig == null)
		{
			return;
		}
		LordGym value = lordGymConfig.Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "LordGymUnLock", new <>z__ReadOnlySingleElementList<object>(value.GymTitle));
		this.LevelSequence.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0601077C RID: 67452 RVA: 0x0047F4FC File Offset: 0x0047D6FC
	[NullableContext(1)]
	private void SequenceFinishEvent(string sequenceName)
	{
		if (sequenceName == "Start")
		{
			this.LevelSequence.PlayLevelSequenceByName("Close", false, null, false);
		}
		if (sequenceName == "Close")
		{
			this.SetActive(false);
		}
	}

	// Token: 0x04008190 RID: 33168
	[Nullable(2)]
	private LevelSequencePlayer LevelSequence;

	// Token: 0x020084F3 RID: 34035
	private class EChildType
	{
		// Token: 0x0402D06A RID: 184426
		public const int UnLockText = 0;
	}
}
