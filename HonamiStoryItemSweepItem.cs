using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F0C RID: 7948
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryItemSweepItem : UiPanelBase
{
	// Token: 0x0600ED36 RID: 60726 RVA: 0x0040ACD4 File Offset: 0x00408ED4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x0600ED37 RID: 60727 RVA: 0x0040AD2E File Offset: 0x00408F2E
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSeqEnd), false);
	}

	// Token: 0x0600ED38 RID: 60728 RVA: 0x0040AD59 File Offset: 0x00408F59
	private void OnSeqEnd(string seqName)
	{
		Action<string> seqEndCb = this.SeqEndCb;
		if (seqEndCb != null)
		{
			seqEndCb(seqName);
		}
		this.SetSweepTextureActive(false);
	}

	// Token: 0x0600ED39 RID: 60729 RVA: 0x0040AD74 File Offset: 0x00408F74
	public void BindSeqEndCb(Action<string> cb)
	{
		this.SeqEndCb = cb;
	}

	// Token: 0x0600ED3A RID: 60730 RVA: 0x0040AD80 File Offset: 0x00408F80
	[NullableContext(2)]
	public void SetData(HonamiStoryItemDataBase data, EHonamiStoryBackpackType backpackType)
	{
		if (data != null)
		{
			HonamiStoryModel instance = ModelBase<HonamiStoryModel>.Instance;
			bool isCross = data.GetIsCross();
			int baseGridWidth = data.GetBaseGridWidth(isCross);
			int baseGridHeight = data.GetBaseGridHeight(isCross);
			int num;
			int num2;
			if (backpackType != EHonamiStoryBackpackType.Player)
			{
				EHonamiStoryBackpack backpackId = Singleton<HonamiStoryDefine>.Instance.HonamiBackpackTypeMap[backpackType];
				HonamiStoryBackpackData backPackData = instance.GetBackPackData((int)backpackId, false);
				num = backPackData.GetCellWidth() * baseGridWidth + (baseGridWidth - 1) * backPackData.GetCellHorizontalInterval();
				num2 = backPackData.GetCellHeight() * baseGridHeight + (baseGridHeight - 1) * backPackData.GetCellVerticalInterval();
			}
			else
			{
				HonamiStoryPlayerBackpackData playerBackpackData = instance.GetPlayerBackpackData();
				num = playerBackpackData.GetCellWidth() * baseGridWidth + (baseGridWidth - 1) * playerBackpackData.GetCellHorizontalInterval();
				num2 = playerBackpackData.GetCellHeight() * baseGridHeight + (baseGridHeight - 1) * playerBackpackData.GetCellVerticalInterval();
			}
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetWidth((float)num);
			}
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 == null)
			{
				return;
			}
			rootItem2.SetHeight((float)num2);
		}
	}

	// Token: 0x0600ED3B RID: 60731 RVA: 0x0040AE64 File Offset: 0x00409064
	public void PlaySequenceByNamePurely(string sequenceName)
	{
		this.SetSweepTextureActive(true);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
	}

	// Token: 0x0600ED3C RID: 60732 RVA: 0x0040AE96 File Offset: 0x00409096
	public void ClearSequence()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, true);
		}
		this.SetSweepTextureActive(false);
		this.SetActivateTextureActive(false);
	}

	// Token: 0x0600ED3D RID: 60733 RVA: 0x0040AEB9 File Offset: 0x004090B9
	private void SetSweepTextureActive(bool isActive)
	{
		UUITexture texture = base.GetTexture(0);
		if (texture != null)
		{
			texture.SetUIActive(isActive);
		}
		UUITexture texture2 = base.GetTexture(1);
		if (texture2 == null)
		{
			return;
		}
		texture2.SetUIActive(isActive);
	}

	// Token: 0x0600ED3E RID: 60734 RVA: 0x0040AEE0 File Offset: 0x004090E0
	private void SetActivateTextureActive(bool isActive)
	{
		UUITexture texture = base.GetTexture(2);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(isActive);
	}

	// Token: 0x0600ED3F RID: 60735 RVA: 0x0040AEF4 File Offset: 0x004090F4
	protected override void OnBeforeShow()
	{
		this.SetSweepTextureActive(false);
	}

	// Token: 0x0600ED40 RID: 60736 RVA: 0x0040AEFD File Offset: 0x004090FD
	protected override void OnBeforeHide()
	{
		this.SetSweepTextureActive(false);
	}

	// Token: 0x040071EF RID: 29167
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040071F0 RID: 29168
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<string> SeqEndCb;

	// Token: 0x02008264 RID: 33380
	[NullableContext(0)]
	private enum ESweepComponent
	{
		// Token: 0x0402C38E RID: 181134
		SweepInTexture,
		// Token: 0x0402C38F RID: 181135
		SweepTipsTexture,
		// Token: 0x0402C390 RID: 181136
		ActivateTexture
	}
}
