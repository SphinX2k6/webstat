using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020011B2 RID: 4530
public class ArtemisQteClickTipsItem : UiPanelBase
{
	// Token: 0x06007752 RID: 30546 RVA: 0x001F39D9 File Offset: 0x001F1BD9
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x06007753 RID: 30547 RVA: 0x001F39FC File Offset: 0x001F1BFC
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
	}

	// Token: 0x06007754 RID: 30548 RVA: 0x001F3A27 File Offset: 0x001F1C27
	protected override void OnBeforeHide()
	{
		this.InProgressType = EArtemisTipsType.None;
	}

	// Token: 0x06007755 RID: 30549 RVA: 0x001F3A30 File Offset: 0x001F1C30
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x06007756 RID: 30550 RVA: 0x001F3A4C File Offset: 0x001F1C4C
	[NullableContext(1)]
	private void OnSequenceClose(string sequenceName)
	{
		EArtemisTipsType eartemisTipsType = EArtemisTipsType.None;
		if (!(sequenceName == "Fail"))
		{
			if (!(sequenceName == "QteSuccess"))
			{
				if (sequenceName == "Success")
				{
					eartemisTipsType = EArtemisTipsType.None;
				}
			}
			else
			{
				eartemisTipsType = EArtemisTipsType.Perfect;
			}
		}
		else
		{
			eartemisTipsType = EArtemisTipsType.Miss;
		}
		if (eartemisTipsType == this.InProgressType)
		{
			this.SetActive(false);
		}
	}

	// Token: 0x06007757 RID: 30551 RVA: 0x001F3AA0 File Offset: 0x001F1CA0
	[NullableContext(1)]
	private void PlayAnim(string sequenceName)
	{
		if (this.LevelSequencePlayer.GetCurrentSequence() == sequenceName)
		{
			this.LevelSequencePlayer.ReplaySequenceByKey(sequenceName);
		}
		else
		{
			this.LevelSequencePlayer.StopPlayingSequence(false, true);
			this.LevelSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
		}
		this.SetActive(true);
	}

	// Token: 0x06007758 RID: 30552 RVA: 0x001F3AFC File Offset: 0x001F1CFC
	public void ShowTip(EArtemisTipsType tipsType)
	{
		string sequenceName = "Success";
		switch (tipsType)
		{
		case EArtemisTipsType.None:
			return;
		case EArtemisTipsType.Miss:
			this.SetTipMiss();
			sequenceName = "Fail";
			break;
		case EArtemisTipsType.Perfect:
			this.SetTipSuccess();
			sequenceName = "QteSuccess";
			break;
		}
		this.InProgressType = tipsType;
		this.PlayAnim(sequenceName);
	}

	// Token: 0x06007759 RID: 30553 RVA: 0x001F3B4C File Offset: 0x001F1D4C
	private void SetTipMiss()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Activity_ArtemisChatFixTips_Miss", Array.Empty<object>());
	}

	// Token: 0x0600775A RID: 30554 RVA: 0x001F3B69 File Offset: 0x001F1D69
	private void SetTipSuccess()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Activity_ArtemisChatFixTips_Perfect", Array.Empty<object>());
	}

	// Token: 0x0400399E RID: 14750
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400399F RID: 14751
	protected EArtemisTipsType InProgressType;

	// Token: 0x0200750F RID: 29967
	private class EComponents
	{
		// Token: 0x040286A5 RID: 165541
		public const int Tips = 0;
	}
}
