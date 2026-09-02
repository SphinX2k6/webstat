using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Weather;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002D18 RID: 11544
[NullableContext(1)]
[Nullable(0)]
public class WeatherCentralBottomItem : UiPanelBase
{
	// Token: 0x060174E6 RID: 95462 RVA: 0x00675EC4 File Offset: 0x006740C4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirm));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickSkip));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060174E7 RID: 95463 RVA: 0x00676075 File Offset: 0x00674275
	private void OnCooldownTimer(int remainTime)
	{
		if (remainTime <= 0)
		{
			this.RefreshButtonState();
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "WeatherControl_Cooldown", new <>z__ReadOnlySingleElementList<object>(remainTime));
	}

	// Token: 0x060174E8 RID: 95464 RVA: 0x006760A3 File Offset: 0x006742A3
	private void OnClickConfirm()
	{
		Action clickConfirmCallback = this.ClickConfirmCallback;
		if (clickConfirmCallback == null)
		{
			return;
		}
		clickConfirmCallback();
	}

	// Token: 0x060174E9 RID: 95465 RVA: 0x006760B8 File Offset: 0x006742B8
	private void OnClickSkip()
	{
		SkipTaskManager.Run(ESkipName.SkipToQuest, new object[]
		{
			ConfigBase<WeatherModuleConfig>.Instance.GetWeatherSwitchConfig(this.SelectedConfigId).Value.QuestId
		});
	}

	// Token: 0x060174EA RID: 95466 RVA: 0x006760F9 File Offset: 0x006742F9
	public void SetClickConfirmCallback(Action callback)
	{
		this.ClickConfirmCallback = callback;
	}

	// Token: 0x060174EB RID: 95467 RVA: 0x00676102 File Offset: 0x00674302
	public void RefreshByConfigId(int configId)
	{
		this.SelectedConfigId = configId;
		this.RefreshTime();
		this.RefreshButtonState();
		this.RefreshLockText();
	}

	// Token: 0x060174EC RID: 95468 RVA: 0x00676120 File Offset: 0x00674320
	private void RefreshLockText()
	{
		WeatherSwitch? weatherSwitchConfig = ConfigBase<WeatherModuleConfig>.Instance.GetWeatherSwitchConfig(this.SelectedConfigId);
		if (weatherSwitchConfig == null || weatherSwitchConfig.Value.UnlockCondition == 0)
		{
			return;
		}
		ConditionGroup? conditionGroup;
		string key = ((ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(weatherSwitchConfig.Value.UnlockCondition) != null) ? conditionGroup.GetValueOrDefault().HintText : null) ?? "";
		UUIText text = base.GetText(5);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew(key);
	}

	// Token: 0x060174ED RID: 95469 RVA: 0x006761AC File Offset: 0x006743AC
	private void RefreshButtonState()
	{
		bool flag = ModelBase<WeatherModel>.Instance.IsWeatherSwitchConfigUnlocked(this.SelectedConfigId);
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(!flag);
		}
		UUIButtonComponent button = base.GetButton(3);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag);
		}
		if (flag)
		{
			bool flag2 = ModelBase<WeatherModel>.Instance.GetCurrentWeatherSwitchConfigId() == this.SelectedConfigId;
			int remainCoolDownTime = ModelBase<WeatherModel>.Instance.GetRemainCoolDownTime();
			if (button != null)
			{
				button.SetSelfInteractive(!flag2 && remainCoolDownTime <= 0);
			}
			if (remainCoolDownTime > 0)
			{
				this.OnCooldownTimer(remainCoolDownTime);
				return;
			}
			UUIText text = base.GetText(8);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew("WeatherControl_Confirm");
		}
	}

	// Token: 0x060174EE RID: 95470 RVA: 0x0067625C File Offset: 0x0067445C
	private void RefreshTime()
	{
		bool flag = ModelBase<WeatherModel>.Instance.IsCurrentTimeInValidTime(this.SelectedConfigId);
		UUIArtText artText = base.GetArtText(1);
		UUIArtText artText2 = base.GetArtText(2);
		if (!flag)
		{
			if (artText != null)
			{
				artText.SetText(this.GetCurrentTimeText());
			}
			if (artText2 != null)
			{
				artText2.SetText(this.GetTargetTimeText());
			}
		}
		else if (artText2 != null)
		{
			artText2.SetText(this.GetCurrentTimeText());
		}
		if (artText != null)
		{
			artText.SetUIActive(!flag);
		}
		UUIItem item = base.GetItem(7);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(!flag);
	}

	// Token: 0x060174EF RID: 95471 RVA: 0x006762DE File Offset: 0x006744DE
	private string GetCurrentTimeText()
	{
		return ModelBase<TimeOfDayModel>.Instance.GameTime.HourMinuteString;
	}

	// Token: 0x060174F0 RID: 95472 RVA: 0x006762F0 File Offset: 0x006744F0
	private string GetTargetTimeText()
	{
		string text = "0" + this.GetTargetTimeByConfigId(this.SelectedConfigId).ToString();
		int startIndex = Math.Max(0, text.Length - 2);
		return text.Substring(startIndex) + ":00";
	}

	// Token: 0x060174F1 RID: 95473 RVA: 0x0067633C File Offset: 0x0067453C
	private int GetTargetTimeByConfigId(int configId)
	{
		return ConfigBase<WeatherModuleConfig>.Instance.GetWeatherSwitchConfig(configId).Value.ValidTime()[0];
	}

	// Token: 0x0400B300 RID: 45824
	private int SelectedConfigId;

	// Token: 0x0400B301 RID: 45825
	[Nullable(2)]
	private Action ClickConfirmCallback;
}
