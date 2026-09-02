using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020025E1 RID: 9697
public class PhotographValueSetup : PhotographSetupBase
{
	// Token: 0x06012F80 RID: 77696 RVA: 0x0053EF7C File Offset: 0x0053D17C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06012F81 RID: 77697 RVA: 0x0053EFD6 File Offset: 0x0053D1D6
	protected override void OnStart()
	{
		base.GetSlider(1).OnValueChangeCb.Bind(new Action<float>(this.OnValueChanged));
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06012F82 RID: 77698 RVA: 0x0053F006 File Offset: 0x0053D206
	protected override void OnBeforeDestroy()
	{
		base.GetSlider(1).OnValueChangeCb.Unbind();
		this.LevelSequencePlayer = null;
	}

	// Token: 0x06012F83 RID: 77699 RVA: 0x0053F020 File Offset: 0x0053D220
	protected override void OnBeforeShow()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName("Start01", false, null, false);
	}

	// Token: 0x06012F84 RID: 77700 RVA: 0x0053F050 File Offset: 0x0053D250
	private void OnValueChanged(float value)
	{
		if (this.SetupConfig.Value.IsReverseSet)
		{
			float[] array = this.SetupConfig.Value.ValueRange();
			float value2 = Singleton<MathUtils>.Instance.RangeClamp(value, array[0], array[1], array[1], array[0]);
			ControllerBase<PhotographController>.Instance.SetPhotographOption((EPhotoSetupValueType)this.SetupConfig.Value.ValueType, value2, false);
			return;
		}
		ControllerBase<PhotographController>.Instance.SetPhotographOption((EPhotoSetupValueType)this.SetupConfig.Value.ValueType, value, false);
	}

	// Token: 0x06012F85 RID: 77701 RVA: 0x0053F0DD File Offset: 0x0053D2DD
	public override void Initialize(EPhotoSetupValueType setupValueType)
	{
		this.SetupValueType = setupValueType;
		this.Refresh();
	}

	// Token: 0x06012F86 RID: 77702 RVA: 0x0053F0EC File Offset: 0x0053D2EC
	public override void Refresh()
	{
		this.SetupConfig = ConfigBase<PhotographConfig>.Instance.GetPhotoSetupConfig(this.SetupValueType);
		if (this.SetupConfig.Value.Type == 0)
		{
			return;
		}
		string name = this.SetupConfig.Value.Name;
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, name, Array.Empty<object>());
		UUISliderComponent slider = base.GetSlider(1);
		float[] array = this.SetupConfig.Value.ValueRange();
		slider.SetMinValue(array[0], false, false);
		slider.SetMaxValue(array[1], false, false);
		float num = ModelBase<PhotographModel>.Instance.GetPhotographOption(this.SetupValueType) ?? array[2];
		if (this.SetupConfig.Value.IsReverseSet)
		{
			num = Singleton<MathUtils>.Instance.RangeClamp(num, array[0], array[1], array[1], array[0]);
		}
		slider.SetValue(num, false);
	}

	// Token: 0x04009407 RID: 37895
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008955 RID: 35157
	private enum EChildType
	{
		// Token: 0x0402E56B RID: 189803
		OptionNameText,
		// Token: 0x0402E56C RID: 189804
		ValueSlider,
		// Token: 0x0402E56D RID: 189805
		SpriteHandle
	}
}
