using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Weather;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002D1F RID: 11551
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WeatherToggleItem : GridProxyAbstract<IWeatherToggleData>
{
	// Token: 0x0601750C RID: 95500 RVA: 0x00676EE4 File Offset: 0x006750E4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggleSpriteTransition));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601750D RID: 95501 RVA: 0x00677094 File Offset: 0x00675294
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.CanExecuteChange.Bind(() => !this.IsEmptySlot && (this.CanExecuteChange == null || this.CanExecuteChange(base.GridIndex)));
	}

	// Token: 0x0601750E RID: 95502 RVA: 0x006770B8 File Offset: 0x006752B8
	private void OnClickToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback();
		}
	}

	// Token: 0x0601750F RID: 95503 RVA: 0x006770CE File Offset: 0x006752CE
	public void SetToggleClickCallback(Action callback)
	{
		this.ClickCallback = callback;
	}

	// Token: 0x06017510 RID: 95504 RVA: 0x006770D7 File Offset: 0x006752D7
	public void SetCanExecuteChange(Func<int, bool> callback)
	{
		this.CanExecuteChange = callback;
	}

	// Token: 0x06017511 RID: 95505 RVA: 0x006770E0 File Offset: 0x006752E0
	public EToggleState GetToggleState()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return EToggleState.ETT_UnChecked;
		}
		return extendToggle.GetToggleState();
	}

	// Token: 0x06017512 RID: 95506 RVA: 0x006770F4 File Offset: 0x006752F4
	public UUIItem GetToggleItem()
	{
		return base.GetExtendToggle(0).GetRootComponent();
	}

	// Token: 0x06017513 RID: 95507 RVA: 0x00677102 File Offset: 0x00675302
	public void SetToggleStateForce(bool @checked, bool fireEvent, bool skipAnim)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(@checked ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, skipAnim, skipAnim);
	}

	// Token: 0x06017514 RID: 95508 RVA: 0x00677120 File Offset: 0x00675320
	public override void Refresh(IWeatherToggleData data, bool isSelected, int gridIndex)
	{
		int configId = this.ConfigId;
		int? configId2 = data.ConfigId;
		bool flag = configId == configId2.GetValueOrDefault() & configId2 != null;
		this.IsEmptySlot = (data.ConfigId == null);
		this.ConfigId = data.ConfigId.GetValueOrDefault();
		if (!flag)
		{
			this.RefreshMainPerformance();
			this.RefreshToggleState();
		}
		if (data.ConfigId != null)
		{
			this.RefreshCurrentTimeState();
			this.RefreshCurrentTips();
			this.RefreshRedDot();
		}
	}

	// Token: 0x06017515 RID: 95509 RVA: 0x006771A8 File Offset: 0x006753A8
	private void RefreshToggleState()
	{
		<WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState <WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState = <WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState.None;
		if (this.ConfigId != 0)
		{
			<WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState = (ModelBase<WeatherModel>.Instance.IsWeatherSwitchConfigUnlocked(this.ConfigId) ? <WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState.Normal : <WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState.Lock);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetSelfInteractive(<WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState > <WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState.None);
		}
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(<WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState == <WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState.None);
		}
		UUIItem item2 = base.GetItem(6);
		if (item2 != null)
		{
			item2.SetUIActive(<WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState == <WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState.Lock);
		}
		UUIItem item3 = base.GetItem(5);
		if (item3 != null)
		{
			item3.SetUIActive(<WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState == <WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState.Normal);
		}
		UUIItem item4 = base.GetItem(3);
		if (item4 != null)
		{
			item4.SetUIActive(<WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState == <WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState.Normal);
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetUIActive(<WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState == <WeatherCentralMainView>F95068A11C15258925C59ADA20EC087115DDDE5F9560D96C5F1CFD0A35BC980A2__EToggleState.Normal);
		}
		UUIItem item5 = base.GetItem(8);
		if (item5 == null)
		{
			return;
		}
		item5.SetUIActive(false);
	}

	// Token: 0x06017516 RID: 95510 RVA: 0x0067726C File Offset: 0x0067546C
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06017517 RID: 95511 RVA: 0x00677284 File Offset: 0x00675484
	public void RefreshMainPerformance()
	{
		if (this.ConfigId == 0)
		{
			return;
		}
		WeatherSwitch? weatherSwitchConfig = ConfigBase<WeatherModuleConfig>.Instance.GetWeatherSwitchConfig(this.ConfigId);
		if (weatherSwitchConfig == null)
		{
			return;
		}
		base.SetTextureShowUntilLoaded(weatherSwitchConfig.Value.Background, base.GetTexture(1), null);
		base.SetExtendToggleSpriteTransitionByPath(weatherSwitchConfig.Value.Icon, base.GetUiExtendToggleSpriteTransition(4), null).Forget();
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew(weatherSwitchConfig.Value.Name);
	}

	// Token: 0x06017518 RID: 95512 RVA: 0x0067731C File Offset: 0x0067551C
	public void RefreshCurrentTimeState()
	{
		bool flag = ModelBase<WeatherModel>.Instance.IsCurrentTimeInValidTime(this.ConfigId);
		bool flag2 = ModelBase<WeatherModel>.Instance.IsWeatherSwitchConfigUnlocked(this.ConfigId);
		UUIItem item = base.GetItem(9);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(!flag && flag2);
	}

	// Token: 0x06017519 RID: 95513 RVA: 0x00677364 File Offset: 0x00675564
	public void RefreshCurrentTips()
	{
		WeatherModel instance = ModelBase<WeatherModel>.Instance;
		int? num = (instance != null) ? new int?(instance.GetCurrentWeatherSwitchConfigId()) : null;
		int configId = this.ConfigId;
		bool flag = num.GetValueOrDefault() == configId & num != null;
		bool flag2 = ModelBase<WeatherModel>.Instance.IsWeatherSwitchConfigUnlocked(this.ConfigId);
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(flag2 && flag);
	}

	// Token: 0x0601751A RID: 95514 RVA: 0x006773D0 File Offset: 0x006755D0
	public void RefreshRedDot()
	{
		bool flag = ModelBase<WeatherModel>.Instance.IsWeatherSwitchConfigUnlocked(this.ConfigId);
		bool flag2 = ModelBase<WeatherModel>.Instance.IsWeatherClicked(this.ConfigId);
		UUIItem item = base.GetItem(8);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(flag && !flag2);
	}

	// Token: 0x0400B324 RID: 45860
	public int ConfigId;

	// Token: 0x0400B325 RID: 45861
	[Nullable(2)]
	private Action ClickCallback;

	// Token: 0x0400B326 RID: 45862
	[Nullable(2)]
	private Func<int, bool> CanExecuteChange;

	// Token: 0x0400B327 RID: 45863
	private bool IsEmptySlot;
}
