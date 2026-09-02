using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BattleUi;
using UnrealEngine;

// Token: 0x02001FAD RID: 8109
public class LockCursorUnit : HudUnitBase
{
	// Token: 0x0600F3E8 RID: 62440 RVA: 0x0042BAC4 File Offset: 0x00429CC4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F3E9 RID: 62441 RVA: 0x0042BBB4 File Offset: 0x00429DB4
	protected override void OnStart()
	{
		this.RootItem.SetAnchorAlign(UIAnchorHorizontalAlign.Center, UIAnchorVerticalAlign.Middle);
		base.GetItem(1).SetUIActive(true);
		base.GetItem(2).SetUIActive(false);
		base.GetItem(5).SetUIActive(false);
		this.SetBarPercent(1f);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600F3EA RID: 62442 RVA: 0x0042BC14 File Offset: 0x00429E14
	public override void Tick(float delta)
	{
		if (this.UnlockTimeDown < 0f)
		{
			return;
		}
		if (this.CurrentTime > this.UnlockTimeDown)
		{
			this.SetBarPercent(1f);
			return;
		}
		float barPercent = this.CurrentTime / this.UnlockTimeDown;
		this.SetBarPercent(barPercent);
		this.CurrentTime += delta;
	}

	// Token: 0x0600F3EB RID: 62443 RVA: 0x0042BC6C File Offset: 0x00429E6C
	protected override void OnBeforeDestroy()
	{
		this.LevelSequencePlayer.Clear();
		this.LevelSequencePlayer = null;
	}

	// Token: 0x0600F3EC RID: 62444 RVA: 0x0042BC80 File Offset: 0x00429E80
	public void Activate()
	{
		base.SetVisible(true, 0);
	}

	// Token: 0x0600F3ED RID: 62445 RVA: 0x0042BC8A File Offset: 0x00429E8A
	public void Deactivate()
	{
		this.SetLockState(LockCursorUnit.ELockState.None);
		base.SetVisible(false, 0);
	}

	// Token: 0x0600F3EE RID: 62446 RVA: 0x0042BC9C File Offset: 0x00429E9C
	public override void SetActive(bool visibility)
	{
		if (!visibility)
		{
			this.DeactivateUnlockTimeDown();
		}
		this.SetBarSpriteVisible(!this.HasHiddenTag);
		base.GetItem(1).SetUIActive(!this.HasHiddenTag);
		base.GetSprite(4).SetUIActive(!this.HasHiddenTag);
		base.SetActive(visibility);
	}

	// Token: 0x0600F3EF RID: 62447 RVA: 0x0042BCF2 File Offset: 0x00429EF2
	public bool IsForceLockState()
	{
		return this.LockState == LockCursorUnit.ELockState.ForceLock;
	}

	// Token: 0x0600F3F0 RID: 62448 RVA: 0x0042BCFD File Offset: 0x00429EFD
	public void ActivateUnlockTimeDown(float time)
	{
		this.UnlockTimeDown = time;
		this.CurrentTime = 0f;
	}

	// Token: 0x0600F3F1 RID: 62449 RVA: 0x0042BD11 File Offset: 0x00429F11
	public void DeactivateUnlockTimeDown()
	{
		this.UnlockTimeDown = -1f;
		this.CurrentTime = 0f;
		this.SetBarPercent(1f);
	}

	// Token: 0x0600F3F2 RID: 62450 RVA: 0x0042BD34 File Offset: 0x00429F34
	[NullableContext(2)]
	public void Refresh(EntityHandle lockTarget, EntityHandle selfEntity, bool isPlayerLock)
	{
		int? num;
		if (lockTarget == null)
		{
			num = null;
		}
		else
		{
			WorldEntity entity = lockTarget.Entity;
			num = ((entity != null) ? new int?(entity.Id) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		this.LockEntityId = valueOrDefault;
		BaseTagComponent baseTagComponent;
		if (lockTarget == null)
		{
			baseTagComponent = null;
		}
		else
		{
			WorldEntity entity2 = lockTarget.Entity;
			baseTagComponent = ((entity2 != null) ? entity2.GetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		this.HasHiddenTag = (baseTagComponent2 != null && (baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.隐身.隐藏锁定UI"]) || baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏界面功能.隐藏锁定UI"])));
		base.SetVisible(!this.HasHiddenTag, 2);
		LockCursorUnit.ELockState lockState = this.RefreshLockState(selfEntity, isPlayerLock);
		this.RefreshLockAudio(lockState);
		this.SetLockState(lockState);
	}

	// Token: 0x0600F3F3 RID: 62451 RVA: 0x0042BDFC File Offset: 0x00429FFC
	[NullableContext(2)]
	private LockCursorUnit.ELockState RefreshLockState(EntityHandle selfEntity, bool isPlayerLock)
	{
		if (this.HasHiddenTag)
		{
			return LockCursorUnit.ELockState.None;
		}
		if (!isPlayerLock)
		{
			return LockCursorUnit.ELockState.NormalLock;
		}
		if (selfEntity == null || !selfEntity.Valid)
		{
			return LockCursorUnit.ELockState.None;
		}
		BaseTagComponent component = selfEntity.Entity.GetComponent<BaseTagComponent>();
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.方向状态.注视方向"]))
		{
			return LockCursorUnit.ELockState.ForceLock;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.方向状态.看向方向"]))
		{
			return LockCursorUnit.ELockState.LookAt;
		}
		return LockCursorUnit.ELockState.NormalLock;
	}

	// Token: 0x0600F3F4 RID: 62452 RVA: 0x0042BE6C File Offset: 0x0042A06C
	private void RefreshLockAudio(LockCursorUnit.ELockState lockState)
	{
		if (lockState != LockCursorUnit.ELockState.ForceLock)
		{
			return;
		}
		if (lockState != this.LockState)
		{
			this.PlayForceLockAudio();
			this.LockAudioEntityId = this.LockEntityId;
			return;
		}
		if (this.LockAudioEntityId != this.LockEntityId)
		{
			this.LockAudioEntityId = this.LockEntityId;
			this.PlaySwitchForceLockAudio();
		}
	}

	// Token: 0x0600F3F5 RID: 62453 RVA: 0x0042BEBC File Offset: 0x0042A0BC
	private void SetLockState(LockCursorUnit.ELockState lockState)
	{
		if (lockState != this.LockState)
		{
			if (this.LockState == LockCursorUnit.ELockState.None)
			{
				this.PlayStartSequence();
			}
			else if (this.LockState == LockCursorUnit.ELockState.LookAt)
			{
				this.PlayLookAtUnlockSequence();
			}
			if (lockState == LockCursorUnit.ELockState.LookAt)
			{
				this.PlayLookAtLockSequence();
			}
			this.LockState = lockState;
			UUIItem item = base.GetItem(2);
			UUIItem item2 = base.GetItem(5);
			if (lockState == LockCursorUnit.ELockState.ForceLock)
			{
				item.SetUIActive(true);
				item2.SetUIActive(false);
				return;
			}
			if (lockState == LockCursorUnit.ELockState.LookAt)
			{
				item.SetUIActive(false);
				item2.SetUIActive(true);
				return;
			}
			item.SetUIActive(false);
			item2.SetUIActive(false);
		}
	}

	// Token: 0x0600F3F6 RID: 62454 RVA: 0x0042BF48 File Offset: 0x0042A148
	private void SetBarSpriteVisible(bool bVisible)
	{
		UUISprite sprite = base.GetSprite(3);
		if (sprite.IsUIActiveSelf() == bVisible)
		{
			return;
		}
		sprite.SetUIActive(bVisible);
	}

	// Token: 0x0600F3F7 RID: 62455 RVA: 0x0042BF6E File Offset: 0x0042A16E
	public void SetBarPercent(float percent)
	{
		base.GetSprite(3).SetFillAmount(percent);
	}

	// Token: 0x0600F3F8 RID: 62456 RVA: 0x0042BF80 File Offset: 0x0042A180
	private void PlayStartSequence()
	{
		this.LevelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x0600F3F9 RID: 62457 RVA: 0x0042BFAC File Offset: 0x0042A1AC
	private void PlayLookAtLockSequence()
	{
		this.LevelSequencePlayer.PlaySequencePurely("Lock", false, false, null, null, false);
	}

	// Token: 0x0600F3FA RID: 62458 RVA: 0x0042BFD8 File Offset: 0x0042A1D8
	private void PlayLookAtUnlockSequence()
	{
		this.LevelSequencePlayer.PlaySequencePurely("Unlock", false, false, null, null, false);
	}

	// Token: 0x0600F3FB RID: 62459 RVA: 0x0042C002 File Offset: 0x0042A202
	private void PlayForceLockAudio()
	{
		BattleUiAudioData audioData = ModelBase<BattleUiModel>.Instance.AudioData;
		if (audioData == null)
		{
			return;
		}
		audioData.PlayAudio(EBattleUiAudioType.ForceLock, EBattleUiChild.BattleHud);
	}

	// Token: 0x0600F3FC RID: 62460 RVA: 0x0042C01B File Offset: 0x0042A21B
	private void PlaySwitchForceLockAudio()
	{
		BattleUiAudioData audioData = ModelBase<BattleUiModel>.Instance.AudioData;
		if (audioData == null)
		{
			return;
		}
		audioData.PlayAudio(EBattleUiAudioType.SwitchForceLock, EBattleUiChild.BattleHud);
	}

	// Token: 0x0400755B RID: 30043
	private float UnlockTimeDown = -1f;

	// Token: 0x0400755C RID: 30044
	private float CurrentTime;

	// Token: 0x0400755D RID: 30045
	private LockCursorUnit.ELockState LockState;

	// Token: 0x0400755E RID: 30046
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400755F RID: 30047
	private bool HasHiddenTag;

	// Token: 0x04007560 RID: 30048
	private int LockEntityId;

	// Token: 0x04007561 RID: 30049
	private int LockAudioEntityId;

	// Token: 0x02008333 RID: 33587
	private enum EChildType
	{
		// Token: 0x0402C7F9 RID: 182265
		Item1,
		// Token: 0x0402C7FA RID: 182266
		Item2,
		// Token: 0x0402C7FB RID: 182267
		Item3,
		// Token: 0x0402C7FC RID: 182268
		BarSprite,
		// Token: 0x0402C7FD RID: 182269
		AnimSprite,
		// Token: 0x0402C7FE RID: 182270
		Item4
	}

	// Token: 0x02008334 RID: 33588
	private enum ELockState
	{
		// Token: 0x0402C800 RID: 182272
		None,
		// Token: 0x0402C801 RID: 182273
		ForceLock,
		// Token: 0x0402C802 RID: 182274
		LookAt,
		// Token: 0x0402C803 RID: 182275
		NormalLock
	}

	// Token: 0x02008335 RID: 33589
	private enum EVisibleReason
	{
		// Token: 0x0402C805 RID: 182277
		Default,
		// Token: 0x0402C806 RID: 182278
		Tag = 2
	}
}
