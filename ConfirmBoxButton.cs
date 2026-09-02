using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A86 RID: 6790
[NullableContext(1)]
[Nullable(0)]
public class ConfirmBoxButton : UiPanelBase
{
	// Token: 0x0600C23D RID: 49725 RVA: 0x00332C44 File Offset: 0x00330E44
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C23E RID: 49726 RVA: 0x00332CEA File Offset: 0x00330EEA
	private void ButtonClick()
	{
		this.CloseView();
	}

	// Token: 0x0600C23F RID: 49727 RVA: 0x00332CF2 File Offset: 0x00330EF2
	protected void CloseView()
	{
		if (this.ClickFunction != null)
		{
			this.ClickFunction();
		}
	}

	// Token: 0x0600C240 RID: 49728 RVA: 0x00332D07 File Offset: 0x00330F07
	public void SetTextById(string textId)
	{
		base.GetText(1).SetText(ConfigBase<ConfirmBoxConfig>.Instance.GetButtonText(textId), true);
	}

	// Token: 0x0600C241 RID: 49729 RVA: 0x00332D21 File Offset: 0x00330F21
	public void SetText(string text)
	{
		base.GetText(1).SetText(text, true);
	}

	// Token: 0x0600C242 RID: 49730 RVA: 0x00332D34 File Offset: 0x00330F34
	public void SetBtnCanClick(bool value)
	{
		UUIInteractionGroup uuiinteractionGroup = this.RootActor.GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup;
		if (uuiinteractionGroup != null)
		{
			uuiinteractionGroup.SetInteractable(value);
		}
	}

	// Token: 0x0600C243 RID: 49731 RVA: 0x00332D68 File Offset: 0x00330F68
	public void SetTimer(string textId, int delayTime, bool canClickDuringTimer)
	{
		if (!canClickDuringTimer)
		{
			this.SetBtnCanClick(canClickDuringTimer);
		}
		this.DelayTime = delayTime;
		this.SetTimerText(textId);
		this.Timer = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.DelayTime--;
			this.SetTimerText(textId);
			if (this.DelayTime <= 0)
			{
				if (canClickDuringTimer)
				{
					this.CloseView();
					return;
				}
				this.SetBtnCanClick(true);
			}
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x0600C244 RID: 49732 RVA: 0x00332DE0 File Offset: 0x00330FE0
	private void SetTimerText(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, new <>z__ReadOnlySingleElementList<object>((this.DelayTime > 0) ? this.DelayTime.ToString() : ""));
	}

	// Token: 0x0600C245 RID: 49733 RVA: 0x00332E14 File Offset: 0x00331014
	public void SetClickFunction(Action clickFunction)
	{
		this.ClickFunction = clickFunction;
	}

	// Token: 0x0600C246 RID: 49734 RVA: 0x00332E1D File Offset: 0x0033101D
	protected override void OnBeforeDestroy()
	{
		if (this.Timer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.Timer);
			this.Timer = null;
		}
	}

	// Token: 0x04005D22 RID: 23842
	[Nullable(2)]
	protected TimerHandle Timer;

	// Token: 0x04005D23 RID: 23843
	protected int DelayTime;

	// Token: 0x04005D24 RID: 23844
	[Nullable(2)]
	protected Action ClickFunction;

	// Token: 0x02007D32 RID: 32050
	[NullableContext(0)]
	private class EConfirmBoxButtonDefine
	{
		// Token: 0x0402AAD6 RID: 174806
		public const int Button = 0;

		// Token: 0x0402AAD7 RID: 174807
		public const int ButtonText = 1;
	}
}
