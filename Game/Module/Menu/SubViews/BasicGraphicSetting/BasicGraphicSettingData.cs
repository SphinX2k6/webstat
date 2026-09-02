using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Menu.SubViews.BasicGraphicSetting
{
	// Token: 0x020057B4 RID: 22452
	public class BasicGraphicSettingData : IStaticVariableResetter
	{
		// Token: 0x0603915B RID: 233819 RVA: 0x00E77B24 File Offset: 0x00E75D24
		static BasicGraphicSettingData()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(BasicGraphicSettingData.CreateStaticDefaultValue), new Action(BasicGraphicSettingData.ResetStaticDefaultValue));
		}

		// Token: 0x0603915C RID: 233820 RVA: 0x00E77B43 File Offset: 0x00E75D43
		public static void CreateStaticDefaultValue()
		{
			BasicGraphicSettingData.BasicGraphicFunctionIds = new EFunction[]
			{
				EFunction.BRIGHTNESS,
				EFunction.Saturation,
				EFunction.Contrast
			};
		}

		// Token: 0x0603915D RID: 233821 RVA: 0x00E77B5B File Offset: 0x00E75D5B
		public static void ResetStaticDefaultValue()
		{
			BasicGraphicSettingData.BasicGraphicFunctionIds = null;
		}

		// Token: 0x0603915E RID: 233822 RVA: 0x00E77B64 File Offset: 0x00E75D64
		[NullableContext(1)]
		[return: Nullable(2)]
		private static BasicGraphicSettingSliderData CreateBasicGraphicSettingSliderData(MenuData metaData)
		{
			EFunction functionId = metaData.FunctionId;
			if (functionId == EFunction.BRIGHTNESS)
			{
				return new BasicGraphicSettingSliderBrightnessData(metaData);
			}
			if (functionId == EFunction.Saturation)
			{
				return new BasicGraphicSettingSliderSaturationData(metaData);
			}
			if (functionId != EFunction.Contrast)
			{
				return null;
			}
			return new BasicGraphicSettingSliderContrastData(metaData);
		}

		// Token: 0x0603915F RID: 233823 RVA: 0x00E77BA4 File Offset: 0x00E75DA4
		[NullableContext(1)]
		public static List<BasicGraphicSettingSliderData> GetBasicGraphicSettingSliderDataList()
		{
			List<BasicGraphicSettingSliderData> list = new List<BasicGraphicSettingSliderData>();
			foreach (EFunction key in BasicGraphicSettingData.BasicGraphicFunctionIds)
			{
				MenuConfig metaConfig;
				if (Singleton<GameSettingsManager>.Instance.ValidApplyConfigMap.TryGetValue(key, out metaConfig))
				{
					MenuData menuData = new MenuData(metaConfig);
					if (menuData != null)
					{
						BasicGraphicSettingSliderData basicGraphicSettingSliderData = BasicGraphicSettingData.CreateBasicGraphicSettingSliderData(menuData);
						if (basicGraphicSettingSliderData != null)
						{
							list.Add(basicGraphicSettingSliderData);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x040207F3 RID: 133107
		[Nullable(2)]
		private static EFunction[] BasicGraphicFunctionIds;
	}
}
