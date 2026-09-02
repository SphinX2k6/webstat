using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B50 RID: 6992
[NullableContext(2)]
[Nullable(0)]
public class UiPanelFormationRolePhantomExtension : UiPanelBase
{
	// Token: 0x0600CA2D RID: 51757 RVA: 0x0035BDA0 File Offset: 0x00359FA0
	[NullableContext(1)]
	public UiPanelFormationRolePhantomExtension(UUIItem attachedItem)
	{
		this.AttachedUiItem = attachedItem;
	}

	// Token: 0x0600CA2E RID: 51758 RVA: 0x0035BDB0 File Offset: 0x00359FB0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(20, new Action(this.OnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CA2F RID: 51759 RVA: 0x0035BEE4 File Offset: 0x0035A0E4
	protected override void OnBeforeDestroy()
	{
		this.PlayerId = 0;
		this.RoleCfgId = 0;
		LevelSequencePlayer loopSeqPlayer = this.LoopSeqPlayer;
		if (loopSeqPlayer != null)
		{
			loopSeqPlayer.StopCurrentSequence(false, false);
		}
		this.LoopSeqPlayer = null;
		this.IsLoopPlaying = false;
		LevelSequencePlayer iconSeqPlayer = this.IconSeqPlayer;
		if (iconSeqPlayer != null)
		{
			iconSeqPlayer.StopCurrentSequence(false, false);
		}
		this.IconSeqPlayer = null;
		this.LastIconPath = null;
	}

	// Token: 0x0600CA30 RID: 51760 RVA: 0x0035BF41 File Offset: 0x0035A141
	protected override void OnStart()
	{
		this.LoopSeqPlayer = new LevelSequencePlayer(base.GetItem(19));
		this.IconSeqPlayer = new LevelSequencePlayer(this.AttachedUiItem);
	}

	// Token: 0x0600CA31 RID: 51761 RVA: 0x0035BF68 File Offset: 0x0035A168
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		UUIButtonComponent button = base.GetButton(20);
		UUIItem uuiitem = (button != null) ? button.GetRootComponent() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x0600CA32 RID: 51762 RVA: 0x0035BF9D File Offset: 0x0035A19D
	private void OnClick()
	{
		ControllerBase<TowerDefenseController>.Instance.TryOpenPhantomViewByPlayerIdAndRoleId(this.PlayerId, this.RoleCfgId);
	}

	// Token: 0x0600CA33 RID: 51763 RVA: 0x0035BFB5 File Offset: 0x0035A1B5
	public void SetRedDotActive(bool value)
	{
		base.GetItem(21).SetUIActive(value);
	}

	// Token: 0x0600CA34 RID: 51764 RVA: 0x0035BFC8 File Offset: 0x0035A1C8
	public void SetIcon(string path = null, bool isSelf = true)
	{
		UUISprite sprite = base.GetSprite(22);
		UUISprite sprite2 = base.GetSprite(23);
		UUITexture texture = base.GetTexture(24);
		base.GetButton(20).IsSelfInteractive = isSelf;
		bool flag = path != this.LastIconPath;
		this.LastIconPath = path;
		if (path != null)
		{
			sprite.SetUIActive(false);
			sprite2.SetUIActive(false);
			texture.SetUIActive(true);
			base.SetTextureByPath(path, base.GetTexture(24), null, null);
			if (flag)
			{
				if (!isSelf)
				{
					this.LoopSeqPlayer.StopCurrentSequence(false, false);
					this.IsLoopPlaying = false;
				}
				this.IconSeqPlayer.PlayLevelSequenceByName("VisionIn", false, null, false);
				return;
			}
		}
		else
		{
			sprite.SetUIActive(isSelf);
			sprite2.SetUIActive(!isSelf);
			texture.SetUIActive(false);
			if (isSelf)
			{
				if (flag)
				{
					this.IconSeqPlayer.PlayLevelSequenceByName("VisionOut", false, null, false);
					return;
				}
			}
			else if (!this.IsLoopPlaying)
			{
				this.IsLoopPlaying = true;
				this.LoopSeqPlayer.PlayLevelSequenceByName("Loop", false, null, false);
			}
		}
	}

	// Token: 0x0600CA35 RID: 51765 RVA: 0x0035C0E4 File Offset: 0x0035A2E4
	public void SetRelativeUiActive(bool active)
	{
		base.GetItem(19).SetUIActive(active);
	}

	// Token: 0x040060C1 RID: 24769
	public int PlayerId;

	// Token: 0x040060C2 RID: 24770
	public int RoleCfgId;

	// Token: 0x040060C3 RID: 24771
	private readonly UUIItem AttachedUiItem;

	// Token: 0x040060C4 RID: 24772
	private LevelSequencePlayer LoopSeqPlayer;

	// Token: 0x040060C5 RID: 24773
	private LevelSequencePlayer IconSeqPlayer;

	// Token: 0x040060C6 RID: 24774
	private string LastIconPath;

	// Token: 0x040060C7 RID: 24775
	private bool IsLoopPlaying;

	// Token: 0x02007E33 RID: 32307
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402AFB2 RID: 176050
		VisionPanel = 19,
		// Token: 0x0402AFB3 RID: 176051
		VisionButton,
		// Token: 0x0402AFB4 RID: 176052
		RedDotItem,
		// Token: 0x0402AFB5 RID: 176053
		AddSprite,
		// Token: 0x0402AFB6 RID: 176054
		WaitingSprite,
		// Token: 0x0402AFB7 RID: 176055
		IconTexture
	}
}
