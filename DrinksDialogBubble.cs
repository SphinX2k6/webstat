using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001016 RID: 4118
public class DrinksDialogBubble : UiPanelBase
{
	// Token: 0x06006B1E RID: 27422 RVA: 0x001C0290 File Offset: 0x001BE490
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06006B1F RID: 27423 RVA: 0x001C02EC File Offset: 0x001BE4EC
	protected override void OnStart()
	{
		this.LevelSequence = new LevelSequencePlayer(this.RootItem);
		this.LevelSequence.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceStop), false);
		int roleId = ModelBase<DrinksModel>.Instance.GetRoleId();
		base.SetRoleIcon("", base.GetTexture(0), roleId, null, null);
		base.SetUiActive(false);
	}

	// Token: 0x06006B20 RID: 27424 RVA: 0x001C0354 File Offset: 0x001BE554
	[NullableContext(1)]
	public void ActivateBubble(string configId, bool isLike)
	{
		base.SetUiActive(true);
		if (this.LevelSequence.IsPlayingSequence("Close"))
		{
			LevelSequencePlayer levelSequence = this.LevelSequence;
			if (levelSequence != null)
			{
				levelSequence.StopSequenceByKey("Close", false, false);
			}
		}
		LevelSequencePlayer levelSequence2 = this.LevelSequence;
		if (levelSequence2 != null)
		{
			levelSequence2.PlayOrReplaySequenceByName("Start", false, null);
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(isLike);
		}
		DrinksDialog? dialog = ConfigBase<DrinksConfig>.Instance.GetDialog(configId);
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.ShowTextNew(configId);
		}
		if (this.EventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.EventHandle, EAudioActionType.Stop, null);
		}
		this.EventHandle = Singleton<AudioSystem>.Instance.PostEvent(dialog.Value.AudioEvent);
		if (this.TimerDelay != null)
		{
			TimerSystem.Instance.Remove(this.TimerDelay);
		}
		this.TimerDelay = TimerSystem.Instance.Delay(delegate(float _)
		{
			if (this.LevelSequence.IsPlayingSequence("Start"))
			{
				LevelSequencePlayer levelSequence3 = this.LevelSequence;
				if (levelSequence3 != null)
				{
					levelSequence3.StopSequenceByKey("Start", false, false);
				}
			}
			LevelSequencePlayer levelSequence4 = this.LevelSequence;
			if (levelSequence4 != null)
			{
				levelSequence4.PlayOrReplaySequenceByName("Close", false, null);
			}
			this.TimerDelay = null;
		}, (float)dialog.Value.Delay, null, null, true, 1f);
	}

	// Token: 0x06006B21 RID: 27425 RVA: 0x001C0474 File Offset: 0x001BE674
	public void DeactivateBubble(bool force = false)
	{
		if (this.EventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.EventHandle, EAudioActionType.Stop, null);
		}
		this.EventHandle = 0;
		if (this.TimerDelay != null)
		{
			TimerSystem.Instance.Remove(this.TimerDelay);
			this.TimerDelay = null;
		}
		if (!base.IsUiActiveInHierarchy())
		{
			return;
		}
		if (this.LevelSequence.IsPlayingSequence("Start"))
		{
			LevelSequencePlayer levelSequence = this.LevelSequence;
			if (levelSequence != null)
			{
				levelSequence.StopSequenceByKey("Start", false, false);
			}
		}
		if (this.LevelSequence.IsPlayingSequence("Close"))
		{
			LevelSequencePlayer levelSequence2 = this.LevelSequence;
			if (levelSequence2 != null)
			{
				levelSequence2.StopSequenceByKey("Close", false, false);
			}
		}
		base.SetUiActive(false);
	}

	// Token: 0x06006B22 RID: 27426 RVA: 0x001C052E File Offset: 0x001BE72E
	[NullableContext(1)]
	private void OnSequenceStop(string sequenceName)
	{
		if (sequenceName == "Close")
		{
			base.SetUiActive(false);
		}
	}

	// Token: 0x040032E7 RID: 13031
	protected int EventHandle;

	// Token: 0x040032E8 RID: 13032
	[Nullable(2)]
	protected TimerHandle TimerDelay;

	// Token: 0x040032E9 RID: 13033
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequence;

	// Token: 0x020073F8 RID: 29688
	private static class EItem
	{
		// Token: 0x040281D4 RID: 164308
		public const int TexIcon = 0;

		// Token: 0x040281D5 RID: 164309
		public const int Txt = 1;

		// Token: 0x040281D6 RID: 164310
		public const int PanelGood = 2;
	}
}
