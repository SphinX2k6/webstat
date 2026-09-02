using System;
using System.Collections.Generic;
using UnrealEngine;

// Token: 0x020025CB RID: 9675
public class FightPhotoSliderItem : FightPhotoSetupBase
{
	// Token: 0x06012E9D RID: 77469 RVA: 0x0053B9A4 File Offset: 0x00539BA4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickRefresh))
		};
	}

	// Token: 0x06012E9E RID: 77470 RVA: 0x0053BA63 File Offset: 0x00539C63
	protected override void OnStart()
	{
		base.GetSlider(0).OnValueChangeCb.Bind(new Action<float>(this.OnValueChanged));
	}

	// Token: 0x06012E9F RID: 77471 RVA: 0x0053BA84 File Offset: 0x00539C84
	public override void Refresh()
	{
		if (this.SetupConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), this.SetupConfig.Value.Name, Array.Empty<object>());
		float num = this.SetupConfig.Value.ValueRange(0);
		float num2 = this.SetupConfig.Value.ValueRange(1);
		float num3 = this.SetupConfig.Value.ValueRange(2);
		UUISliderComponent slider = base.GetSlider(0);
		slider.SetMinValue(num, false, false);
		slider.SetMaxValue(num2, false, false);
		int? fightPhotoSetupOption = ModelBase<FightPhotoModel>.Instance.GetFightPhotoSetupOption((EFightPhotoSetupOptionType)this.SetupConfig.Value.Id);
		float num4 = (fightPhotoSetupOption != null) ? ((float)fightPhotoSetupOption.GetValueOrDefault()) : num3;
		float inValue = this.SetupConfig.Value.IsReverseSet ? Singleton<MathUtils>.Instance.RangeClamp(num4, num, num2, num2, num) : num4;
		slider.SetValue(inValue, false);
		base.GetText(2).SetUIActive(this.SetupConfig.Value.IsShowText);
		this.SetNumText(num4);
	}

	// Token: 0x06012EA0 RID: 77472 RVA: 0x0053BBB4 File Offset: 0x00539DB4
	private void SetNumText(float value)
	{
		base.GetText(2).SetText(Singleton<MathUtils>.Instance.GetFloatPointFloorString((double)value, this.SetupConfig.Value.Digits) + this.SetupConfig.Value.Unit, true);
	}

	// Token: 0x06012EA1 RID: 77473 RVA: 0x0053BC05 File Offset: 0x00539E05
	protected override void OnBeforeDestroy()
	{
		base.GetSlider(0).OnValueChangeCb.Unbind();
	}

	// Token: 0x06012EA2 RID: 77474 RVA: 0x0053BC18 File Offset: 0x00539E18
	private void OnValueChanged(float value)
	{
		float num = this.SetupConfig.Value.ValueRange(0);
		float num2 = this.SetupConfig.Value.ValueRange(1);
		float num3 = this.SetupConfig.Value.IsReverseSet ? Singleton<MathUtils>.Instance.RangeClamp(value, num, num2, num2, num) : value;
		float floatPointFloor = Singleton<MathUtils>.Instance.GetFloatPointFloor(num3, this.SetupConfig.Value.Digits);
		this.SetNumText(num3);
		base.OnSetupValueChange((int)floatPointFloor);
	}

	// Token: 0x06012EA3 RID: 77475 RVA: 0x0053BCAC File Offset: 0x00539EAC
	private void OnClickRefresh()
	{
		if (this.SetupConfig == null)
		{
			return;
		}
		float num = this.SetupConfig.Value.ValueRange(0);
		float num2 = this.SetupConfig.Value.ValueRange(1);
		float num3 = this.SetupConfig.Value.ValueRange(2);
		float inValue = this.SetupConfig.Value.IsReverseSet ? Singleton<MathUtils>.Instance.RangeClamp(num3, num, num2, num2, num) : num3;
		base.GetSlider(0).SetValue(inValue, true);
	}

	// Token: 0x02008936 RID: 35126
	private enum EChildType
	{
		// Token: 0x0402E4C8 RID: 189640
		ValueSlider,
		// Token: 0x0402E4C9 RID: 189641
		SpriteHandle,
		// Token: 0x0402E4CA RID: 189642
		TxtNum,
		// Token: 0x0402E4CB RID: 189643
		ItemRedDot,
		// Token: 0x0402E4CC RID: 189644
		BtnRefresh,
		// Token: 0x0402E4CD RID: 189645
		TxtTitle
	}
}
