using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F06 RID: 7942
public class HonamiStorySlotLockStateItem : UiPanelBase
{
	// Token: 0x0600ED1D RID: 60701 RVA: 0x0040A6D4 File Offset: 0x004088D4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUINiagara))
		};
	}

	// Token: 0x0600ED1E RID: 60702 RVA: 0x0040A70D File Offset: 0x0040890D
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSeqEnd), false);
	}

	// Token: 0x0600ED1F RID: 60703 RVA: 0x0040A738 File Offset: 0x00408938
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnLevelSeq));
	}

	// Token: 0x0600ED20 RID: 60704 RVA: 0x0040A756 File Offset: 0x00408956
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnLevelSeq));
	}

	// Token: 0x0600ED21 RID: 60705 RVA: 0x0040A774 File Offset: 0x00408974
	public void RefreshState(bool isLock, bool isFirstLock, bool canUpdate)
	{
		if (isLock)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetUIActive(isLock);
			}
			bool flag;
			if (canUpdate)
			{
				bool? canUpdate2 = this.CanUpdate;
				flag = !(canUpdate == canUpdate2.GetValueOrDefault() & canUpdate2 != null);
			}
			else
			{
				flag = false;
			}
			if (flag && isFirstLock)
			{
				if (this.IsFirstLock != null && !this.IsFirstLock.Value)
				{
					this.NeedCanUpdateAnim = true;
				}
				else if (!this.LevelSequencePlayer.IsPlayingSequence("Tips_Square"))
				{
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer != null)
					{
						levelSequencePlayer.PlayLevelSequenceByName("Tips_Square", false, null, false);
					}
				}
			}
			else if (!canUpdate)
			{
				UUINiagara uiNiagara = base.GetUiNiagara(1);
				if (uiNiagara != null)
				{
					uiNiagara.SetUIActive(false);
				}
			}
			this.CanUpdate = new bool?(canUpdate && isFirstLock);
		}
		if (!isLock && this.IsLock.GetValueOrDefault())
		{
			UUINiagara uiNiagara2 = base.GetUiNiagara(1);
			if (uiNiagara2 != null)
			{
				uiNiagara2.SetUIActive(false);
			}
			if (!this.LevelSequencePlayer.IsPlayingSequence("Hide"))
			{
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.PlayLevelSequenceByName("Hide", false, null, false);
				}
			}
		}
		else
		{
			this.RefreshUnlockState(isFirstLock);
		}
		this.IsLock = new bool?(isLock);
	}

	// Token: 0x0600ED22 RID: 60706 RVA: 0x0040A8A8 File Offset: 0x00408AA8
	public void RefreshUnlockState(bool isFirstLock = false)
	{
		if (this.IsFirstLock != null && !this.IsFirstLock.Value && isFirstLock)
		{
			if (!this.LevelSequencePlayer.IsPlayingSequence("Show"))
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlayLevelSequenceByName("Show", false, null, false);
				}
			}
		}
		else
		{
			string resourceId = isFirstLock ? "SP_GridIconAdd" : "SP_GridIconLock";
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			string text = (instance != null) ? instance.GetResourcePath(resourceId) : null;
			this.SetSpriteByPath(text ?? string.Empty, base.GetSprite(0), false, null, null);
		}
		this.IsFirstLock = new bool?(isFirstLock);
	}

	// Token: 0x0600ED23 RID: 60707 RVA: 0x0040A960 File Offset: 0x00408B60
	[NullableContext(1)]
	private void OnSeqEnd(string seqName)
	{
		if (seqName == "Hide")
		{
			base.SetUiActive(false);
			return;
		}
		if (seqName == "Show" && this.NeedCanUpdateAnim)
		{
			this.NeedCanUpdateAnim = false;
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Tips_Square", false, null, false);
		}
	}

	// Token: 0x0600ED24 RID: 60708 RVA: 0x0040A9C0 File Offset: 0x00408BC0
	[NullableContext(1)]
	private void OnLevelSeq(string param)
	{
		if (param != "EmptyGridUnlock" || !this.LevelSequencePlayer.IsPlayingSequence("Show"))
		{
			return;
		}
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		string text = (instance != null) ? instance.GetResourcePath("SP_GridIconAdd") : null;
		this.SetSpriteByPath(text ?? string.Empty, base.GetSprite(0), false, null, null);
	}

	// Token: 0x040071E9 RID: 29161
	private bool? IsLock;

	// Token: 0x040071EA RID: 29162
	private bool? IsFirstLock;

	// Token: 0x040071EB RID: 29163
	private bool? CanUpdate;

	// Token: 0x040071EC RID: 29164
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040071ED RID: 29165
	private bool NeedCanUpdateAnim;

	// Token: 0x0200825F RID: 33375
	private enum ESlotLock
	{
		// Token: 0x0402C381 RID: 181121
		Sprite,
		// Token: 0x0402C382 RID: 181122
		Niagara
	}
}
