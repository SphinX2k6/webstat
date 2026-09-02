using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FC2 RID: 8130
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleAutoMovingItem : UiPanelBase
{
	// Token: 0x0600F50B RID: 62731 RVA: 0x004315BC File Offset: 0x0042F7BC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F50C RID: 62732 RVA: 0x004316CA File Offset: 0x0042F8CA
	protected override void OnStart()
	{
		this.InitTweenAnim(6);
		this.InitTweenAnim(4);
		this.InitTweenAnim(5);
		this.NitrogenIconSprite = base.GetSprite(3);
		this.AcceleratorIconSprite = base.GetSprite(1);
	}

	// Token: 0x0600F50D RID: 62733 RVA: 0x004316FB File Offset: 0x0042F8FB
	protected override void OnBeforeDestroy()
	{
		this.DestroyCloseAnimTimer();
		base.OnBeforeDestroy();
	}

	// Token: 0x0600F50E RID: 62734 RVA: 0x00431709 File Offset: 0x0042F909
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
			this.StopTweenAnim(5);
			this.PlayTweenAnim(6);
			return;
		}
		this.PlayCloseAnim();
	}

	// Token: 0x0600F50F RID: 62735 RVA: 0x0043173C File Offset: 0x0042F93C
	private void PlayCloseAnim()
	{
		this.StopTweenAnim(6);
		this.PlayTweenAnim(5);
		this.DestroyCloseAnimTimer();
		this.CloseAnimTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.CloseAnimTimer = null;
			if (!this.TargetVisible)
			{
				this.SetActive(false);
			}
		}, 300f, MotorcycleAutoMovingItem.CloseAnimTimerStat, null, true, 1f);
	}

	// Token: 0x0600F510 RID: 62736 RVA: 0x0043178A File Offset: 0x0042F98A
	private void DestroyCloseAnimTimer()
	{
		if (this.CloseAnimTimer != null)
		{
			TimerSystem.Instance.Remove(this.CloseAnimTimer);
			this.CloseAnimTimer = null;
		}
	}

	// Token: 0x0600F511 RID: 62737 RVA: 0x004317AC File Offset: 0x0042F9AC
	public void SetPercentNitrogen(float percent)
	{
		if (percent == this.LastPercentNitrogen)
		{
			return;
		}
		this.NitrogenIconSprite.SetFillAmount(percent);
		if (percent == 1f)
		{
			this.SetChangeColorNitrogen(true);
			this.PlayTweenAnim(4);
		}
		else if (this.LastPercentNitrogen == 1f)
		{
			this.SetChangeColorNitrogen(false);
		}
		this.LastPercentNitrogen = percent;
	}

	// Token: 0x0600F512 RID: 62738 RVA: 0x00431804 File Offset: 0x0042FA04
	public void SetPercentAccelerator(float percent)
	{
		if (percent == this.LastPercentAccelerator)
		{
			return;
		}
		this.AcceleratorIconSprite.SetFillAmount(percent);
		if (percent == 1f)
		{
			this.SetChangeColorAccelerator(true);
			this.PlayTweenAnim(4);
		}
		else if (this.LastPercentAccelerator == 1f)
		{
			this.SetChangeColorAccelerator(false);
		}
		this.LastPercentAccelerator = percent;
	}

	// Token: 0x0600F513 RID: 62739 RVA: 0x0043185C File Offset: 0x0042FA5C
	public void SetChangeColorNitrogen(bool changeColor)
	{
		if (this.ChangeColorNitrogen == changeColor)
		{
			return;
		}
		this.ChangeColorNitrogen = changeColor;
		UUIItem nitrogenIconSprite = this.NitrogenIconSprite;
		FColor? fcolor = new FColor?(this.NitrogenIconSprite.changeColor);
		nitrogenIconSprite.SetChangeColor(changeColor, fcolor);
	}

	// Token: 0x0600F514 RID: 62740 RVA: 0x0043189C File Offset: 0x0042FA9C
	public void SetChangeColorAccelerator(bool changeColor)
	{
		if (this.ChangeColorAccelerator == changeColor)
		{
			return;
		}
		this.ChangeColorAccelerator = changeColor;
		UUIItem acceleratorIconSprite = this.AcceleratorIconSprite;
		FColor? fcolor = new FColor?(this.AcceleratorIconSprite.changeColor);
		acceleratorIconSprite.SetChangeColor(changeColor, fcolor);
	}

	// Token: 0x0600F515 RID: 62741 RVA: 0x004318D9 File Offset: 0x0042FAD9
	public void SetNitrogen(bool isNitrogen)
	{
		if (this.IsNitrogen == isNitrogen)
		{
			return;
		}
		this.IsNitrogen = isNitrogen;
		base.GetItem(0).SetUIActive(!isNitrogen);
		base.GetItem(2).SetUIActive(isNitrogen);
	}

	// Token: 0x0600F516 RID: 62742 RVA: 0x00431909 File Offset: 0x0042FB09
	public bool GetTargetVisible()
	{
		return this.TargetVisible;
	}

	// Token: 0x0600F517 RID: 62743 RVA: 0x00431911 File Offset: 0x0042FB11
	protected void InitTweenAnim(int componentType)
	{
		this.TweenAnimPlayer.InitTweenAnim(componentType, base.GetItem(componentType), false);
	}

	// Token: 0x0600F518 RID: 62744 RVA: 0x00431927 File Offset: 0x0042FB27
	protected void PlayTweenAnim(int componentType)
	{
		this.TweenAnimPlayer.PlayTweenAnim(componentType);
	}

	// Token: 0x0600F519 RID: 62745 RVA: 0x00431935 File Offset: 0x0042FB35
	protected void StopTweenAnim(int componentType)
	{
		this.TweenAnimPlayer.StopTweenAnim(componentType);
	}

	// Token: 0x04007651 RID: 30289
	private const int CLOSE_ANIM_TIME = 300;

	// Token: 0x04007652 RID: 30290
	private TimerHandle CloseAnimTimer;

	// Token: 0x04007653 RID: 30291
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Stat CloseAnimTimerStat = Stat.Create("MotorcycleAutoMovingItemCloseAnim", "", "");

	// Token: 0x04007654 RID: 30292
	private float LastPercentNitrogen = -1f;

	// Token: 0x04007655 RID: 30293
	private float LastPercentAccelerator = -1f;

	// Token: 0x04007656 RID: 30294
	private bool TargetVisible;

	// Token: 0x04007657 RID: 30295
	private bool ChangeColorNitrogen;

	// Token: 0x04007658 RID: 30296
	private bool ChangeColorAccelerator;

	// Token: 0x04007659 RID: 30297
	private UUISprite NitrogenIconSprite;

	// Token: 0x0400765A RID: 30298
	private UUISprite AcceleratorIconSprite;

	// Token: 0x0400765B RID: 30299
	private bool IsNitrogen;

	// Token: 0x0400765C RID: 30300
	[Nullable(1)]
	protected BattleUiTweenAnimPlayer TweenAnimPlayer = new BattleUiTweenAnimPlayer();
}
