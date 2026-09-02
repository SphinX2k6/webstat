using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001FA7 RID: 8103
public class AimUnit : HudUnitBase
{
	// Token: 0x0600F3AB RID: 62379 RVA: 0x0042A904 File Offset: 0x00428B04
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F3AC RID: 62380 RVA: 0x0042AAE0 File Offset: 0x00428CE0
	protected override void OnStart()
	{
		this.ColorSpriteList = new UUISprite[]
		{
			base.GetSprite(1),
			base.GetSprite(2),
			base.GetSprite(3),
			base.GetSprite(4),
			base.GetSprite(5),
			base.GetSprite(6),
			base.GetSprite(7),
			base.GetSprite(8),
			base.GetSprite(9),
			base.GetSprite(10),
			base.GetSprite(11)
		};
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600F3AD RID: 62381 RVA: 0x0042AB7E File Offset: 0x00428D7E
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		this.ClearCloserTimer();
	}

	// Token: 0x0600F3AE RID: 62382 RVA: 0x0042ABA0 File Offset: 0x00428DA0
	public void SetTargetVisible(bool visible, bool immediately)
	{
		this.TargetVisible = visible;
		this.ClearCloserTimer();
		if (!immediately && !visible && base.GetActive() && this.AimStatus != EAimStatus.None)
		{
			this.SetAimStatus(EAimStatus.None);
			return;
		}
		if (visible)
		{
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
			base.GetItem(0).SetAlpha(1f);
		}
		base.SetVisible(visible, 0);
	}

	// Token: 0x0600F3AF RID: 62383 RVA: 0x0042AC01 File Offset: 0x00428E01
	public bool GetTargetVisible()
	{
		return this.TargetVisible;
	}

	// Token: 0x0600F3B0 RID: 62384 RVA: 0x0042AC0C File Offset: 0x00428E0C
	public void SetAimStatus(EAimStatus status)
	{
		if (this.AimStatus == status)
		{
			return;
		}
		switch (status)
		{
		case EAimStatus.None:
			this.SetCloseAim();
			break;
		case EAimStatus.NoTarget:
			this.SetNormalAim();
			break;
		case EAimStatus.Target:
			this.SetTargetAim();
			break;
		case EAimStatus.Weakness:
			this.SetWeaknessAim();
			break;
		}
		this.AimStatus = status;
	}

	// Token: 0x0600F3B1 RID: 62385 RVA: 0x0042AC60 File Offset: 0x00428E60
	private void SetNormalAim()
	{
		this.SetRedColor(false);
		this.SetArrowVisible(false);
		if (this.AimStatus == EAimStatus.Weakness)
		{
			this.PlayAnim("Change", true);
			return;
		}
		if (this.AimStatus == EAimStatus.None)
		{
			this.PlayAnim("Start1", false);
		}
	}

	// Token: 0x0600F3B2 RID: 62386 RVA: 0x0042AC9A File Offset: 0x00428E9A
	private void SetTargetAim()
	{
		this.SetRedColor(true);
		this.SetArrowVisible(false);
		if (this.AimStatus == EAimStatus.Weakness)
		{
			this.PlayAnim("Change", true);
			return;
		}
		if (this.AimStatus == EAimStatus.None)
		{
			this.PlayAnim("Start1", false);
		}
	}

	// Token: 0x0600F3B3 RID: 62387 RVA: 0x0042ACD4 File Offset: 0x00428ED4
	private void SetWeaknessAim()
	{
		this.SetRedColor(true);
		this.SetArrowVisible(true);
		if (this.AimStatus == EAimStatus.Target || this.AimStatus == EAimStatus.NoTarget)
		{
			this.PlayAnim("Change", false);
			return;
		}
		if (this.AimStatus == EAimStatus.None)
		{
			this.PlayAnim("Start2", false);
		}
	}

	// Token: 0x0600F3B4 RID: 62388 RVA: 0x0042AD22 File Offset: 0x00428F22
	private void SetCloseAim()
	{
		this.PlayAnim("close", false);
		this.StartCloseTimer();
	}

	// Token: 0x0600F3B5 RID: 62389 RVA: 0x0042AD38 File Offset: 0x00428F38
	[NullableContext(1)]
	private void PlayAnim(string sequenceName, bool playReverse = false)
	{
		this.ClearCloserTimer();
		this.LevelSequencePlayer.StopCurrentSequence(false, false);
		this.LevelSequencePlayer.PlaySequencePurely(sequenceName, false, playReverse, null, null, false);
	}

	// Token: 0x0600F3B6 RID: 62390 RVA: 0x0042AD71 File Offset: 0x00428F71
	public override void SetActive(bool visibility)
	{
		if (visibility && !this.TargetVisible)
		{
			return;
		}
		base.SetActive(visibility);
	}

	// Token: 0x0600F3B7 RID: 62391 RVA: 0x0042AD86 File Offset: 0x00428F86
	private void StartCloseTimer()
	{
		this.CloseTimerId = TimerSystem.Instance.Delay(delegate(float id)
		{
			this.SetActive(false);
			this.CloseTimerId = null;
		}, 200f, null, null, true, 1f);
	}

	// Token: 0x0600F3B8 RID: 62392 RVA: 0x0042ADB1 File Offset: 0x00428FB1
	private void ClearCloserTimer()
	{
		if (this.CloseTimerId != null)
		{
			TimerSystem.Instance.Remove(this.CloseTimerId);
			this.CloseTimerId = null;
		}
	}

	// Token: 0x0600F3B9 RID: 62393 RVA: 0x0042ADD4 File Offset: 0x00428FD4
	private void SetRedColor(bool isRedColor)
	{
		if (this.IsRedColor == isRedColor)
		{
			return;
		}
		this.IsRedColor = isRedColor;
		FColor color = this.IsRedColor ? AimUnit.ColorRed : AimUnit.ColorWhite;
		UUISprite[] colorSpriteList = this.ColorSpriteList;
		for (int i = 0; i < colorSpriteList.Length; i++)
		{
			colorSpriteList[i].SetColor(color);
		}
	}

	// Token: 0x0600F3BA RID: 62394 RVA: 0x0042AE28 File Offset: 0x00429028
	private void SetArrowVisible(bool visible)
	{
		base.GetSprite(6).SetAlpha(!visible);
		base.GetSprite(7).SetAlpha(!visible);
		base.GetSprite(8).SetAlpha(visible > false);
		base.GetSprite(9).SetAlpha(visible > false);
	}

	// Token: 0x0600F3BB RID: 62395 RVA: 0x0042AE7A File Offset: 0x0042907A
	public void SetArrowLineVisible(bool visible)
	{
		UUIItem item = base.GetItem(12);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(visible);
	}

	// Token: 0x0400753B RID: 30011
	private const int CloseAnimTime = 200;

	// Token: 0x0400753C RID: 30012
	private const int MaxByte = 255;

	// Token: 0x0400753D RID: 30013
	private static readonly FColor ColorWhite = new FColor(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	// Token: 0x0400753E RID: 30014
	private static readonly FColor ColorRed = new FColor(byte.MaxValue, 0, 0, byte.MaxValue);

	// Token: 0x0400753F RID: 30015
	private EAimStatus AimStatus;

	// Token: 0x04007540 RID: 30016
	private bool TargetVisible;

	// Token: 0x04007541 RID: 30017
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private UUISprite[] ColorSpriteList;

	// Token: 0x04007542 RID: 30018
	private bool IsRedColor;

	// Token: 0x04007543 RID: 30019
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04007544 RID: 30020
	[Nullable(2)]
	private TimerHandle CloseTimerId;

	// Token: 0x0200832A RID: 33578
	private enum EChildType
	{
		// Token: 0x0402C7BF RID: 182207
		AnimNode,
		// Token: 0x0402C7C0 RID: 182208
		RingUpL,
		// Token: 0x0402C7C1 RID: 182209
		RingDownL,
		// Token: 0x0402C7C2 RID: 182210
		RingUpR,
		// Token: 0x0402C7C3 RID: 182211
		RingDownR,
		// Token: 0x0402C7C4 RID: 182212
		Dot,
		// Token: 0x0402C7C5 RID: 182213
		LineUp,
		// Token: 0x0402C7C6 RID: 182214
		LineDown,
		// Token: 0x0402C7C7 RID: 182215
		ArrowUp,
		// Token: 0x0402C7C8 RID: 182216
		ArrowDown,
		// Token: 0x0402C7C9 RID: 182217
		LineL,
		// Token: 0x0402C7CA RID: 182218
		LineR,
		// Token: 0x0402C7CB RID: 182219
		LineNode
	}
}
