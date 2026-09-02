using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Render;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.BasicGraphicSetting
{
	// Token: 0x020057B5 RID: 22453
	public class BasicGraphicSettingSliderBrightnessData : BasicGraphicSettingSliderData
	{
		// Token: 0x06039161 RID: 233825 RVA: 0x00E77C10 File Offset: 0x00E75E10
		[NullableContext(1)]
		public BasicGraphicSettingSliderBrightnessData(MenuData metaData) : base(metaData)
		{
			this.Scalar = 100f;
			int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(metaData.FunctionId, true, true);
			if (currentValue != null)
			{
				this.CurValueInternal = (float)currentValue.Value;
				return;
			}
			this.CurValueInternal = metaData.SliderDefault;
		}

		// Token: 0x06039162 RID: 233826 RVA: 0x00E77C68 File Offset: 0x00E75E68
		public new void OnChangeValue(float value)
		{
			float parameterValue = 2.2f;
			if (value <= 0f)
			{
				parameterValue = Singleton<MathUtils>.Instance.Lerp(1.5f, 2.2f, (value + this.Scalar) / this.Scalar);
			}
			if (value > 0f)
			{
				parameterValue = Singleton<MathUtils>.Instance.Lerp(2.2f, 3.5f, value / this.Scalar);
			}
			UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, Singleton<RenderDataManager>.Instance.GetUiShowColorSettingMaterialParameterCollection(), RenderConfig.UIShowBrightness, parameterValue);
			this.CurValueInternal = value;
		}

		// Token: 0x06039163 RID: 233827 RVA: 0x00E77CF0 File Offset: 0x00E75EF0
		public new void OnApplyValue()
		{
			float num = Singleton<MathUtils>.Instance.Lerp(-1f, 1f, (this.CurValueInternal + this.Scalar) / (this.Scalar * 2f));
			Singleton<GameSettingsManager>.Instance.HandleValueChange(this.FunctionId.Value, (int)MathF.Round(num * 100f), EGameSettingsApplyReason.WhenUi);
		}

		// Token: 0x040207F4 RID: 133108
		private readonly float Scalar;
	}
}
