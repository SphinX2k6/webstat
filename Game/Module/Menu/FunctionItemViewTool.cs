using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005769 RID: 22377
	[NullableContext(1)]
	[Nullable(0)]
	public class FunctionItemViewTool
	{
		// Token: 0x06038EFE RID: 233214 RVA: 0x00E6C9D8 File Offset: 0x00E6ABD8
		public static float GetSliderPosition(float[] rangeList, float value, int digit = 0)
		{
			float min = rangeList[0];
			float num = rangeList[1];
			float rangePct = Singleton<MathUtils>.Instance.GetRangePct(min, num, value);
			return Singleton<MathUtils>.Instance.GetFloatPointFloor(rangePct * num, digit);
		}

		// Token: 0x06038EFF RID: 233215 RVA: 0x00E6CA0C File Offset: 0x00E6AC0C
		public static float GetSliderDisplayValue(MenuData data, float actualValue)
		{
			float[] sliderRange = data.SliderRange;
			float inRangeA = sliderRange[0];
			float inRangeB = sliderRange[1];
			float[] sliderRangeDisplay = data.SliderRangeDisplay;
			float outRangeA = sliderRangeDisplay[0];
			float outRangeB = sliderRangeDisplay[1];
			float num = Singleton<MathUtils>.Instance.RangeClamp(actualValue, inRangeA, inRangeB, outRangeA, outRangeB);
			return (float)Singleton<MathUtils>.Instance.GetRoundToNDecimalPlaces((double)num, data.SliderDigits);
		}

		// Token: 0x06038F00 RID: 233216 RVA: 0x00E6CA58 File Offset: 0x00E6AC58
		public static float GetActualSliderStep(MenuData data, float displayStep)
		{
			float[] sliderRange = data.SliderRange;
			float num = sliderRange[0];
			float num2 = sliderRange[1];
			float[] sliderRangeDisplay = data.SliderRangeDisplay;
			float num3 = sliderRangeDisplay[0];
			float num4 = sliderRangeDisplay[1];
			return displayStep / (num4 - num3) * (num2 - num);
		}
	}
}
