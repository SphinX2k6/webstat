using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x020025E2 RID: 9698
public class PhotographValueWithoutTitleSetup : PhotographSetupBase
{
	// Token: 0x06012F88 RID: 77704 RVA: 0x0053F1EC File Offset: 0x0053D3EC
	protected unsafe override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(0, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent))
		};
		int num = 1;
		List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
		Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickReset));
		this.BtnBindInfo = list;
	}

	// Token: 0x06012F89 RID: 77705 RVA: 0x0053F2B0 File Offset: 0x0053D4B0
	protected override void OnStart()
	{
		base.GetSlider(0).OnValueChangeCb.Bind(new Action<float>(this.OnValueChanged));
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		Singleton<EventSystem>.Instance.Add(EEventName.OnResetPhotographCamera, new Action(this.OnResetPhotographCamera));
	}

	// Token: 0x06012F8A RID: 77706 RVA: 0x0053F307 File Offset: 0x0053D507
	protected override void OnBeforeDestroy()
	{
		base.GetSlider(0).OnValueChangeCb.Unbind();
		this.LevelSequencePlayer = null;
		Singleton<EventSystem>.Instance.Remove(EEventName.OnResetPhotographCamera, new Action(this.OnResetPhotographCamera));
	}

	// Token: 0x06012F8B RID: 77707 RVA: 0x0053F340 File Offset: 0x0053D540
	protected override void OnBeforeShow()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName("Start01", false, null, false);
	}

	// Token: 0x06012F8C RID: 77708 RVA: 0x0053F370 File Offset: 0x0053D570
	private unsafe void OnValueChanged(float value)
	{
		float num = value;
		if (this.SetupConfig.Value.IsReverseSet)
		{
			Span<float> valueRangeBytes = this.SetupConfig.Value.GetValueRangeBytes();
			num = Singleton<MathUtils>.Instance.RangeClamp(value, *valueRangeBytes[0], *valueRangeBytes[1], *valueRangeBytes[1], *valueRangeBytes[0]);
		}
		ControllerBase<PhotographController>.Instance.SetPhotographOption((EPhotoSetupValueType)this.SetupConfig.Value.ValueType, Singleton<MathUtils>.Instance.GetFloatPointFloor(num, this.SetupConfig.Value.Digits), false);
		this.SetNumText(num);
	}

	// Token: 0x06012F8D RID: 77709 RVA: 0x0053F41C File Offset: 0x0053D61C
	private void SetNumText(float value)
	{
		base.GetText(2).SetText(Singleton<MathUtils>.Instance.GetFloatPointFloorString((double)value, this.SetupConfig.Value.Digits) + this.SetupConfig.Value.Unit, true);
	}

	// Token: 0x06012F8E RID: 77710 RVA: 0x0053F470 File Offset: 0x0053D670
	public unsafe override void Refresh()
	{
		this.SetupConfig = ConfigBase<PhotographConfig>.Instance.GetPhotoSetupConfig(this.SetupValueType);
		if (this.SetupConfig.Value.Type != 3)
		{
			return;
		}
		UUISliderComponent slider = base.GetSlider(0);
		Span<float> valueRangeBytes = this.SetupConfig.Value.GetValueRangeBytes();
		slider.SetMinValue(*valueRangeBytes[0], false, false);
		slider.SetMaxValue(*valueRangeBytes[1], false, false);
		float? photographOption = ModelBase<PhotographModel>.Instance.GetPhotographOption(this.SetupValueType);
		if (this.SetupConfig.Value.IsReverseSet)
		{
			photographOption = new float?(Singleton<MathUtils>.Instance.RangeClamp(photographOption ?? (*valueRangeBytes[2]), *valueRangeBytes[0], *valueRangeBytes[1], *valueRangeBytes[1], *valueRangeBytes[0]));
		}
		float num = photographOption ?? (*valueRangeBytes[2]);
		slider.SetValue(num, false);
		this.SetNumText(num);
	}

	// Token: 0x06012F8F RID: 77711 RVA: 0x0053F590 File Offset: 0x0053D790
	private unsafe void OnClickReset()
	{
		Span<float> valueRangeBytes = this.SetupConfig.Value.GetValueRangeBytes();
		float num = *valueRangeBytes[2];
		float inValue = num;
		if (this.SetupConfig.Value.IsReverseSet)
		{
			inValue = Singleton<MathUtils>.Instance.RangeClamp(num, *valueRangeBytes[0], *valueRangeBytes[1], *valueRangeBytes[1], *valueRangeBytes[0]);
		}
		base.GetSlider(0).SetValue(inValue, true);
	}

	// Token: 0x06012F90 RID: 77712 RVA: 0x0053F610 File Offset: 0x0053D810
	private void OnResetPhotographCamera()
	{
		if (this.SetupConfig == null)
		{
			return;
		}
		this.Refresh();
	}

	// Token: 0x04009408 RID: 37896
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008956 RID: 35158
	private enum EChildType
	{
		// Token: 0x0402E56F RID: 189807
		ValueSlider,
		// Token: 0x0402E570 RID: 189808
		SpriteHandle,
		// Token: 0x0402E571 RID: 189809
		TextNum,
		// Token: 0x0402E572 RID: 189810
		ItemRedDot,
		// Token: 0x0402E573 RID: 189811
		BtnReset
	}
}
