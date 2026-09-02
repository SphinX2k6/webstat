using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.UiNavigation;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200195E RID: 6494
[NullableContext(2)]
[Nullable(0)]
public class InputKeyItem : UiPanelBase
{
	// Token: 0x0600BA22 RID: 47650 RVA: 0x00318F8F File Offset: 0x0031718F
	public InputKeyItem(string uniqueId = null)
	{
		this.UniqueId = uniqueId;
	}

	// Token: 0x0600BA23 RID: 47651 RVA: 0x00318FA0 File Offset: 0x003171A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BA24 RID: 47652 RVA: 0x003190D0 File Offset: 0x003172D0
	protected override UniTask OnBeforeStartAsync()
	{
		InputKeyItem.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<InputKeyItem.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600BA25 RID: 47653 RVA: 0x00319113 File Offset: 0x00317313
	protected override void OnBeforeShow()
	{
		if (!Singleton<EventSystem>.Instance.Has(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey)))
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
		}
	}

	// Token: 0x0600BA26 RID: 47654 RVA: 0x0031914E File Offset: 0x0031734E
	protected override void OnAfterHide()
	{
		if (Singleton<EventSystem>.Instance.Has(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
		}
	}

	// Token: 0x0600BA27 RID: 47655 RVA: 0x00319189 File Offset: 0x00317389
	protected override void OnBeforeDestroy()
	{
		this.LongPressProgressBar = null;
		this.DeactivateLongPress();
	}

	// Token: 0x0600BA28 RID: 47656 RVA: 0x00319198 File Offset: 0x00317398
	[NullableContext(1)]
	private void OnInputAnyKey(bool bPress, FKey key)
	{
		if (this.IsLongPressDisable)
		{
			return;
		}
		if (this.LongPressTime != null)
		{
			float? num = this.LongPressTime;
			float num2 = 0f;
			if (!(num.GetValueOrDefault() <= num2 & num != null))
			{
				if (string.IsNullOrEmpty(this.KeyName))
				{
					return;
				}
				string b = key.KeyName.ToString();
				if (this.KeyName != b)
				{
					return;
				}
				if (bPress)
				{
					if (this.DelayLongPressTime != null)
					{
						num = this.DelayLongPressTime;
						num2 = 0f;
						if (num.GetValueOrDefault() > num2 & num != null)
						{
							this.DelayPressTimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
							{
								this.Press();
							}, this.DelayLongPressTime.Value, null, null, true, 1f);
							return;
						}
					}
					this.Press();
					return;
				}
				this.Release();
				return;
			}
		}
	}

	// Token: 0x0600BA29 RID: 47657 RVA: 0x00319280 File Offset: 0x00317480
	private void Press()
	{
		if (this.IsShowLongPressWhenPress)
		{
			this.ActivateLongPress();
		}
		this.SetLongPressProgressVisible(this.IsShowLongPressWhenPress);
		this.SetTextArrowVisible(this.IsShowTextArrowWhenPress);
	}

	// Token: 0x0600BA2A RID: 47658 RVA: 0x003192A8 File Offset: 0x003174A8
	private void Release()
	{
		this.DeactivateLongPress();
		this.SetLongPressProgressVisible(this.IsShowLongPressWhenRelease);
		this.SetTextArrowVisible(this.IsShowTextArrowWhenRelease);
	}

	// Token: 0x0600BA2B RID: 47659 RVA: 0x003192C8 File Offset: 0x003174C8
	private void RemoveDelayPressTimer()
	{
		if (this.DelayPressTimerHandle != null && TimerSystem.GameplayTimeInstance.Has(this.DelayPressTimerHandle))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.DelayPressTimerHandle);
		}
	}

	// Token: 0x0600BA2C RID: 47660 RVA: 0x003192F8 File Offset: 0x003174F8
	[NullableContext(1)]
	public void Refresh(InputKeyItemData data)
	{
		this.KeyName = data.KeyName;
		this.IsLongPressDisable = data.IsLongPressDisable.GetValueOrDefault();
		this.LongPressTime = data.LongPressTime;
		this.DelayLongPressTime = data.DelayPressTime;
		this.IsShowLongPressWhenPress = data.IsShowLongPressWhenPress.GetValueOrDefault();
		this.IsShowLongPressWhenRelease = data.IsShowLongPressWhenRelease.GetValueOrDefault();
		this.IsShowTextArrowWhenPress = data.IsShowTextArrowWhenPress.GetValueOrDefault();
		this.IsShowTextArrowWhenRelease = data.IsShowTextArrowWhenRelease.GetValueOrDefault();
		bool valueOrDefault = data.IsLongPressProcessVisible.GetValueOrDefault();
		bool valueOrDefault2 = data.IsTextArrowVisible.GetValueOrDefault();
		bool valueOrDefault3 = data.IsUpArrowVisible.GetValueOrDefault();
		bool valueOrDefault4 = data.IsDownArrowVisible.GetValueOrDefault();
		string descriptionId = data.DescriptionId;
		this.SetKeyTexture(this.KeyName);
		this.SetTextArrowVisible(valueOrDefault2);
		this.SetUpArrowVisible(valueOrDefault3);
		this.SetDownArrowVisible(valueOrDefault4);
		this.SetDescription(descriptionId);
		this.DeactivateLongPress();
		this.SetLongPressProgressVisible(valueOrDefault);
		if (valueOrDefault)
		{
			this.SetLongPressPercent(0f);
		}
	}

	// Token: 0x0600BA2D RID: 47661 RVA: 0x003193FA File Offset: 0x003175FA
	public void SetLongPressDisable(bool bDisable)
	{
		this.IsLongPressDisable = bDisable;
	}

	// Token: 0x0600BA2E RID: 47662 RVA: 0x00319404 File Offset: 0x00317604
	[NullableContext(1)]
	public void SetKeyTexture(string keyName)
	{
		string keyIconPath = Singleton<InputSettings>.Instance.GetKeyIconPath(keyName);
		if (this.CurrentDisplayKeyName == keyName && this.CurrentKeyIconPath == keyIconPath)
		{
			return;
		}
		this.CurrentDisplayKeyName = keyName;
		this.CurrentKeyIconPath = keyIconPath;
		UUITexture keyTexture = base.GetTexture(0);
		if (!string.IsNullOrEmpty(keyIconPath))
		{
			base.SetTextureByPath(keyIconPath, keyTexture, null, delegate(bool _)
			{
				UUITexture keyTexture2 = keyTexture;
				if (keyTexture2 != null)
				{
					keyTexture2.SetSizeFromTexture();
				}
				UUITexture keyTexture3 = keyTexture;
				if (keyTexture3 == null)
				{
					return;
				}
				keyTexture3.SetUIActive(true);
			});
			return;
		}
		UUITexture keyTexture4 = keyTexture;
		if (keyTexture4 == null)
		{
			return;
		}
		keyTexture4.SetUIActive(false);
	}

	// Token: 0x0600BA2F RID: 47663 RVA: 0x00319497 File Offset: 0x00317697
	public void SetLongPressTime(float time)
	{
		this.LongPressTime = new float?(time);
	}

	// Token: 0x0600BA30 RID: 47664 RVA: 0x003194A5 File Offset: 0x003176A5
	public void SetLongPressPercent(float percent)
	{
		PcAndGamepadProgressBar longPressProgressBar = this.LongPressProgressBar;
		if (longPressProgressBar == null)
		{
			return;
		}
		longPressProgressBar.SetPercent(Math.Min(percent, 1f));
	}

	// Token: 0x0600BA31 RID: 47665 RVA: 0x003194C2 File Offset: 0x003176C2
	public void SetLongPressProgressVisible(bool bVisible)
	{
		PcAndGamepadProgressBar longPressProgressBar = this.LongPressProgressBar;
		if (longPressProgressBar == null)
		{
			return;
		}
		longPressProgressBar.SetProgressVisible(bVisible);
	}

	// Token: 0x0600BA32 RID: 47666 RVA: 0x003194D5 File Offset: 0x003176D5
	public void SetTextArrowVisible(bool bVisible)
	{
		UUITexture texture = base.GetTexture(5);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(bVisible);
	}

	// Token: 0x0600BA33 RID: 47667 RVA: 0x003194E9 File Offset: 0x003176E9
	public void SetUpArrowVisible(bool bVisible)
	{
		UUITexture texture = base.GetTexture(6);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(bVisible);
	}

	// Token: 0x0600BA34 RID: 47668 RVA: 0x003194FD File Offset: 0x003176FD
	public void SetDownArrowVisible(bool bVisible)
	{
		UUITexture texture = base.GetTexture(7);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(bVisible);
	}

	// Token: 0x0600BA35 RID: 47669 RVA: 0x00319514 File Offset: 0x00317714
	public void SetDescription(string descriptionId)
	{
		UUIText text = base.GetText(4);
		if (!string.IsNullOrEmpty(descriptionId))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, descriptionId, Array.Empty<object>());
			if (text != null)
			{
				text.SetUIActive(true);
				return;
			}
		}
		else if (text != null)
		{
			text.SetUIActive(false);
		}
	}

	// Token: 0x0600BA36 RID: 47670 RVA: 0x00319557 File Offset: 0x00317757
	private void ActivateLongPress()
	{
		this.CurrentPressTime = 0f;
		this.LongPressTimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnLongPressRefresh), 20f, 1f, null, null, true);
	}

	// Token: 0x0600BA37 RID: 47671 RVA: 0x00319590 File Offset: 0x00317790
	public void DeactivateLongPress()
	{
		if (this.LongPressTimerId != null && TimerSystem.GameplayTimeInstance.Has(this.LongPressTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.LongPressTimerId);
			this.LongPressTimerId = null;
		}
		this.CurrentPressTime = 0f;
		this.RemoveDelayPressTimer();
	}

	// Token: 0x0600BA38 RID: 47672 RVA: 0x003195E0 File Offset: 0x003177E0
	public void ResetLongPress()
	{
		this.DeactivateLongPress();
		this.SetLongPressPercent(0f);
		this.SetLongPressProgressVisible(false);
	}

	// Token: 0x0600BA39 RID: 47673 RVA: 0x003195FC File Offset: 0x003177FC
	private void OnLongPressRefresh(float _)
	{
		if (this.LongPressTime != null)
		{
			float? longPressTime = this.LongPressTime;
			float num = 0f;
			if (!(longPressTime.GetValueOrDefault() <= num & longPressTime != null))
			{
				float longPressPercent = this.CurrentPressTime / this.LongPressTime.Value;
				this.SetLongPressPercent(longPressPercent);
				this.CurrentPressTime += 20f;
				return;
			}
		}
	}

	// Token: 0x0600BA3A RID: 47674 RVA: 0x00319667 File Offset: 0x00317867
	public void SetEnable(bool bEnable, bool bForce = false)
	{
		if (this.IsEnable == bEnable && !bForce)
		{
			return;
		}
		if (bEnable)
		{
			this.RootItem.SetAlpha(1f);
		}
		else
		{
			this.RootItem.SetAlpha(0.2f);
		}
		this.IsEnable = bEnable;
	}

	// Token: 0x0600BA3B RID: 47675 RVA: 0x003196A2 File Offset: 0x003178A2
	public string GetKeyName()
	{
		return this.KeyName;
	}

	// Token: 0x0400580F RID: 22543
	private string KeyName;

	// Token: 0x04005810 RID: 22544
	private string CurrentDisplayKeyName;

	// Token: 0x04005811 RID: 22545
	private string CurrentKeyIconPath;

	// Token: 0x04005812 RID: 22546
	private float? LongPressTime;

	// Token: 0x04005813 RID: 22547
	private float? DelayLongPressTime;

	// Token: 0x04005814 RID: 22548
	private bool IsShowLongPressWhenPress;

	// Token: 0x04005815 RID: 22549
	private bool IsShowLongPressWhenRelease;

	// Token: 0x04005816 RID: 22550
	private bool IsShowTextArrowWhenPress;

	// Token: 0x04005817 RID: 22551
	private bool IsShowTextArrowWhenRelease;

	// Token: 0x04005818 RID: 22552
	private PcAndGamepadProgressBar LongPressProgressBar;

	// Token: 0x04005819 RID: 22553
	private TimerHandle LongPressTimerId;

	// Token: 0x0400581A RID: 22554
	private float CurrentPressTime;

	// Token: 0x0400581B RID: 22555
	private bool IsEnable;

	// Token: 0x0400581C RID: 22556
	private TimerHandle DelayPressTimerHandle;

	// Token: 0x0400581D RID: 22557
	private bool IsLongPressDisable;

	// Token: 0x0400581E RID: 22558
	public readonly string UniqueId;

	// Token: 0x02007C78 RID: 31864
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A81E RID: 174110
		public const int KeyTexture = 0;

		// Token: 0x0402A81F RID: 174111
		public const int LongPressItem = 1;

		// Token: 0x0402A820 RID: 174112
		public const int CircleLongPressItem = 2;

		// Token: 0x0402A821 RID: 174113
		public const int SquareLongPressItem = 3;

		// Token: 0x0402A822 RID: 174114
		public const int DescriptionText = 4;

		// Token: 0x0402A823 RID: 174115
		public const int TextArrowTexture = 5;

		// Token: 0x0402A824 RID: 174116
		public const int UpArrowTexture = 6;

		// Token: 0x0402A825 RID: 174117
		public const int DownArrowTexture = 7;
	}
}
