using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A0C RID: 6668
[NullableContext(1)]
[Nullable(0)]
public class CommonResultButton : UiPanelBase
{
	// Token: 0x0600BF18 RID: 48920 RVA: 0x00329025 File Offset: 0x00327225
	public CommonResultButton(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600BF19 RID: 48921 RVA: 0x0032903C File Offset: 0x0032723C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick))
		};
	}

	// Token: 0x0600BF1A RID: 48922 RVA: 0x003290FB File Offset: 0x003272FB
	private void ButtonClick()
	{
		if (this.BtnFunction != null)
		{
			this.BtnFunction();
		}
		this.DoClickCallBack();
	}

	// Token: 0x0600BF1B RID: 48923 RVA: 0x00329116 File Offset: 0x00327316
	protected override void OnBeforeDestroy()
	{
		this.ClearBtnTimer();
		this.BtnFunction = null;
	}

	// Token: 0x0600BF1C RID: 48924 RVA: 0x00329125 File Offset: 0x00327325
	public void ResetData()
	{
		this.CommonResultButtonData = null;
	}

	// Token: 0x0600BF1D RID: 48925 RVA: 0x0032912E File Offset: 0x0032732E
	public void SetData(CommonResultButtonData data)
	{
		this.CommonResultButtonData = data;
	}

	// Token: 0x0600BF1E RID: 48926 RVA: 0x00329137 File Offset: 0x00327337
	public void DoClickCallBack()
	{
		CommonResultButtonData commonResultButtonData = this.CommonResultButtonData;
		if (commonResultButtonData == null)
		{
			return;
		}
		Action buttonClickCallBack = commonResultButtonData.GetButtonClickCallBack();
		if (buttonClickCallBack == null)
		{
			return;
		}
		buttonClickCallBack();
	}

	// Token: 0x0600BF1F RID: 48927 RVA: 0x00329153 File Offset: 0x00327353
	public void DoTimerCallBack(int hasRunTime)
	{
		CommonResultButtonData commonResultButtonData = this.CommonResultButtonData;
		if (commonResultButtonData == null)
		{
			return;
		}
		Action<int, CommonResultButton> buttonTimerCallBack = commonResultButtonData.GetButtonTimerCallBack();
		if (buttonTimerCallBack == null)
		{
			return;
		}
		buttonTimerCallBack(hasRunTime, this);
	}

	// Token: 0x0600BF20 RID: 48928 RVA: 0x00329171 File Offset: 0x00327371
	public void DoRefreshCallBack()
	{
		CommonResultButtonData commonResultButtonData = this.CommonResultButtonData;
		if (commonResultButtonData == null)
		{
			return;
		}
		Action<CommonResultButton> buttonRefreshCallBack = commonResultButtonData.GetButtonRefreshCallBack();
		if (buttonRefreshCallBack == null)
		{
			return;
		}
		buttonRefreshCallBack(this);
	}

	// Token: 0x0600BF21 RID: 48929 RVA: 0x0032918E File Offset: 0x0032738E
	public void SetBtnFunction(Action btnFunction)
	{
		this.BtnFunction = btnFunction;
	}

	// Token: 0x0600BF22 RID: 48930 RVA: 0x00329198 File Offset: 0x00327398
	public void SetBtnCanClick(bool canClick)
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button.GetSelfInteractive() != canClick)
		{
			button.SetSelfInteractive(canClick);
		}
	}

	// Token: 0x0600BF23 RID: 48931 RVA: 0x003291BD File Offset: 0x003273BD
	public void SetBtnText(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), textId, args);
	}

	// Token: 0x0600BF24 RID: 48932 RVA: 0x003291D2 File Offset: 0x003273D2
	public UUIText GetBtnText()
	{
		return base.GetText(1);
	}

	// Token: 0x0600BF25 RID: 48933 RVA: 0x003291DC File Offset: 0x003273DC
	[NullableContext(2)]
	public void SetTipsItem(int itemId, string countText = null)
	{
		string newText = "×" + ((countText != null) ? int.Parse(countText) : ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemId, 0)).ToString();
		base.GetText(4).SetText(newText, true);
		base.SetItemIcon(base.GetTexture(3), itemId, null, null);
		base.GetItem(5).SetUIActive(true);
	}

	// Token: 0x0600BF26 RID: 48934 RVA: 0x00329246 File Offset: 0x00327446
	public void SetTipsItemTextColor(FColor color)
	{
		base.GetText(4).SetColor(color);
	}

	// Token: 0x0600BF27 RID: 48935 RVA: 0x00329255 File Offset: 0x00327455
	public void SetFloatText(string textId, params object[] args)
	{
		base.GetText(2).SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), textId, args);
	}

	// Token: 0x0600BF28 RID: 48936 RVA: 0x00329277 File Offset: 0x00327477
	public UUIText GetBtnFloatText()
	{
		base.GetText(2).SetUIActive(true);
		return base.GetText(2);
	}

	// Token: 0x0600BF29 RID: 48937 RVA: 0x00329290 File Offset: 0x00327490
	public void SetFloatTextWithTimer(int delayTime, bool canClickDuringTimer, string textId)
	{
		this.ClearBtnTimer();
		if (!canClickDuringTimer)
		{
			this.SetBtnCanClick(canClickDuringTimer);
		}
		this.DelayTime = delayTime;
		this.TimerId = TimerSystem.GameplayTimeInstance.Loop(delegate(float _)
		{
			if (this.DelayTime > 0)
			{
				LguiUtil instance = Singleton<LguiUtil>.Instance;
				UUIText text = this.GetText(2);
				string textId2 = textId;
				CommonResultButton <>4__this = this;
				int delayTime2 = this.DelayTime;
				<>4__this.DelayTime = delayTime2 - 1;
				instance.SetLocalText(text, textId2, new <>z__ReadOnlySingleElementList<object>(delayTime2));
				return;
			}
			if (!canClickDuringTimer)
			{
				this.SetBtnCanClick(true);
				return;
			}
			this.ButtonClick();
		}, 1000f, delayTime + 1, 1f, null, null, true);
		base.GetText(2).SetUIActive(true);
	}

	// Token: 0x0600BF2A RID: 48938 RVA: 0x00329312 File Offset: 0x00327512
	protected void ClearBtnTimer()
	{
		if (this.TimerId != null && TimerSystem.GameplayTimeInstance.Has(this.TimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
		}
		this.TimerId = null;
	}

	// Token: 0x040059D3 RID: 22995
	[Nullable(2)]
	private TimerHandle TimerId;

	// Token: 0x040059D4 RID: 22996
	private int DelayTime;

	// Token: 0x040059D5 RID: 22997
	[Nullable(2)]
	private Action BtnFunction;

	// Token: 0x040059D6 RID: 22998
	[Nullable(2)]
	private CommonResultButtonData CommonResultButtonData;

	// Token: 0x02007CED RID: 31981
	[NullableContext(0)]
	private enum ECommonResultButton
	{
		// Token: 0x0402A9DD RID: 174557
		Button,
		// Token: 0x0402A9DE RID: 174558
		ButtonText,
		// Token: 0x0402A9DF RID: 174559
		FloatText,
		// Token: 0x0402A9E0 RID: 174560
		TipsIcon,
		// Token: 0x0402A9E1 RID: 174561
		TipsCount,
		// Token: 0x0402A9E2 RID: 174562
		TipsItem
	}
}
