using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Render;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.BasicGraphicSetting
{
	// Token: 0x020057B7 RID: 22455
	public class BasicGraphicSettingSliderContrastData : BasicGraphicSettingSliderData
	{
		// Token: 0x06039166 RID: 233830 RVA: 0x00E77DEA File Offset: 0x00E75FEA
		[NullableContext(1)]
		public BasicGraphicSettingSliderContrastData(MenuData metaData) : base(metaData)
		{
		}

		// Token: 0x06039167 RID: 233831 RVA: 0x00E77DF4 File Offset: 0x00E75FF4
		public new void OnChangeValue(float value)
		{
			float from = 0.5f;
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
			UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, Singleton<RenderDataManager>.Instance.GetUiShowColorSettingMaterialParameterCollection(), RenderConfig.UIShowContrast, parameterValue);
			this.CurValueInternal = value;
		}
	}
}
