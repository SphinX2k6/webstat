using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Render;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.BasicGraphicSetting
{
	// Token: 0x020057B6 RID: 22454
	public class BasicGraphicSettingSliderSaturationData : BasicGraphicSettingSliderData
	{
		// Token: 0x06039164 RID: 233828 RVA: 0x00E77D4F File Offset: 0x00E75F4F
		[NullableContext(1)]
		public BasicGraphicSettingSliderSaturationData(MenuData metaData) : base(metaData)
		{
		}

		// Token: 0x06039165 RID: 233829 RVA: 0x00E77D58 File Offset: 0x00E75F58
		public new void OnChangeValue(float value)
		{
			float from = 0f;
			float to = 2f;
			float parameterValue = 1f;
			if (value <= 50f)
			{
				parameterValue = Singleton<MathUtils>.Instance.Lerp(from, 1f, value * 2f / 100f);
			}
			if (value > 50f)
			{
				parameterValue = Singleton<MathUtils>.Instance.Lerp(1f, to, (value - 50f) * 2f / 100f);
			}
			UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, Singleton<RenderDataManager>.Instance.GetUiShowColorSettingMaterialParameterCollection(), RenderConfig.UIShowSaturation, parameterValue);
			this.CurValueInternal = value;
		}
	}
}
