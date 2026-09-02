using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FBB RID: 8123
[NullableContext(1)]
[Nullable(0)]
public class AutoMovingItem : UiPanelBase
{
	// Token: 0x0600F4B7 RID: 62647 RVA: 0x0042FC74 File Offset: 0x0042DE74
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F4B8 RID: 62648 RVA: 0x0042FD1F File Offset: 0x0042DF1F
	protected override void OnStart()
	{
		this.InitTweenAnim(3);
		this.InitTweenAnim(1);
		this.InitTweenAnim(2);
	}

	// Token: 0x0600F4B9 RID: 62649 RVA: 0x0042FD36 File Offset: 0x0042DF36
	protected override void OnBeforeDestroy()
	{
		this.DestroyCloseAnimTimer();
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F4BA RID: 62650 RVA: 0x0042FD44 File Offset: 0x0042DF44
	public void SetVisible(bool bVisible)
	{
		if (this.TargetVisible == bVisible)
		{
			return;
		}
		this.TargetVisible = bVisible;
		if (bVisible)
		{
			this.SetActive(true);
			this.StopTweenAnim(2);
			this.PlayTweenAnim(3);
			return;
		}
		this.PlayCloseAnim();
	}

	// Token: 0x0600F4BB RID: 62651 RVA: 0x0042FD78 File Offset: 0x0042DF78
	private void PlayCloseAnim()
	{
		this.StopTweenAnim(3);
		this.PlayTweenAnim(2);
		this.DestroyCloseAnimTimer();
		this.CloseAnimTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.CloseAnimTimer = null;
			if (!this.TargetVisible)
			{
				this.SetActive(false);
			}
		}, 300f, AutoMovingItem.CloseAnimTimerStat, null, true, 1f);
	}

	// Token: 0x0600F4BC RID: 62652 RVA: 0x0042FDC6 File Offset: 0x0042DFC6
	private void DestroyCloseAnimTimer()
	{
		if (this.CloseAnimTimer != null)
		{
			TimerSystem.Instance.Remove(this.CloseAnimTimer);
			this.CloseAnimTimer = null;
		}
	}

	// Token: 0x0600F4BD RID: 62653 RVA: 0x0042FDE8 File Offset: 0x0042DFE8
	public void SetPercent(float percent)
	{
		if (percent == this.LastPercent)
		{
			return;
		}
		base.GetSprite(0).SetFillAmount(percent);
		if (percent == 1f)
		{
			this.SetChangeColor(true);
			this.PlayTweenAnim(1);
		}
		else if (this.LastPercent == 1f)
		{
			this.SetChangeColor(false);
		}
		this.LastPercent = percent;
	}

	// Token: 0x0600F4BE RID: 62654 RVA: 0x0042FE40 File Offset: 0x0042E040
	public void SetChangeColor(bool changeColor)
	{
		UUISprite sprite = base.GetSprite(0);
		UUIItem uuiitem = sprite;
		FColor? fcolor = new FColor?(sprite.changeColor);
		uuiitem.SetChangeColor(changeColor, fcolor);
	}

	// Token: 0x0600F4BF RID: 62655 RVA: 0x0042FE6A File Offset: 0x0042E06A
	protected void InitTweenAnim(int componentType)
	{
		this.TweenAnimPlayer.InitTweenAnim(componentType, base.GetItem(componentType), false);
	}

	// Token: 0x0600F4C0 RID: 62656 RVA: 0x0042FE80 File Offset: 0x0042E080
	protected void PlayTweenAnim(int componentType)
	{
		this.TweenAnimPlayer.PlayTweenAnim(componentType);
	}

	// Token: 0x0600F4C1 RID: 62657 RVA: 0x0042FE8E File Offset: 0x0042E08E
	protected void StopTweenAnim(int componentType)
	{
		this.TweenAnimPlayer.StopTweenAnim(componentType);
	}

	// Token: 0x04007603 RID: 30211
	private const int CLOSE_ANIM_TIME = 300;

	// Token: 0x04007604 RID: 30212
	[Nullable(2)]
	private TimerHandle CloseAnimTimer;

	// Token: 0x04007605 RID: 30213
	[StaticVariableRuleIgnore]
	private static readonly Stat CloseAnimTimerStat = Stat.Create("AutoMovingItemCloseAnim", "", "");

	// Token: 0x04007606 RID: 30214
	private float LastPercent = -1f;

	// Token: 0x04007607 RID: 30215
	private bool TargetVisible;

	// Token: 0x04007608 RID: 30216
	protected BattleUiTweenAnimPlayer TweenAnimPlayer = new BattleUiTweenAnimPlayer();
}
