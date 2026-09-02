using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.EyeProtect
{
	// Token: 0x020057AF RID: 22447
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class EyeProtectSliderItem : GridProxyAbstract<EyeProtectSliderData>
	{
		// Token: 0x06039121 RID: 233761 RVA: 0x00E76BD4 File Offset: 0x00E74DD4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x06039122 RID: 233762 RVA: 0x00E76C5A File Offset: 0x00E74E5A
		protected override void OnStart()
		{
			base.GetSlider(1).OnValueChangeCb.Bind(new Action<float>(this.OnSliderValueChange));
		}

		// Token: 0x06039123 RID: 233763 RVA: 0x00E76C7C File Offset: 0x00E74E7C
		public override void Refresh(EyeProtectSliderData data, bool isSelected, int gridIndex)
		{
			UUISliderComponent slider = base.GetSlider(1);
			slider.SetMaxValue(data.MaxValue, true, false);
			slider.SetMinValue(data.MinValue, true, false);
			slider.SetValue(data.CurValue, true);
			this.IsTemp = (data.FunctionId.GetValueOrDefault() == EFunction.EyeProtectionTemp);
			this.Init(data);
			this.Data = data;
			float sliderDisplayValue = FunctionItemViewTool.GetSliderDisplayValue(data.MenuData, data.CurValue);
			string str = this.IsTemp ? "k" : "";
			base.GetText(0).SetText(sliderDisplayValue.ToString() + str, true);
		}

		// Token: 0x06039124 RID: 233764 RVA: 0x00E76D24 File Offset: 0x00E74F24
		private void Init(EyeProtectSliderData data)
		{
			if (this.Data != null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), data.Title, Array.Empty<object>());
			if (this.IsTemp)
			{
				base.GetItem(3).SetUIActive(true);
				base.GetItem(4).SetUIActive(false);
			}
		}

		// Token: 0x06039125 RID: 233765 RVA: 0x00E76D78 File Offset: 0x00E74F78
		private void OnSliderValueChange(float value)
		{
			if (this.Data == null)
			{
				return;
			}
			this.Data.OnChangeValue(value);
			float sliderDisplayValue = FunctionItemViewTool.GetSliderDisplayValue(this.Data.MenuData, value);
			string str = this.IsTemp ? "k" : "";
			base.GetText(0).SetText(sliderDisplayValue.ToString() + str, true);
		}

		// Token: 0x040207D4 RID: 133076
		[Nullable(2)]
		protected EyeProtectSliderData Data;

		// Token: 0x040207D5 RID: 133077
		protected bool IsTemp;

		// Token: 0x0200B833 RID: 47155
		[NullableContext(0)]
		public class ESliderComponent
		{
			// Token: 0x04038F9C RID: 233372
			public const int NumText = 0;

			// Token: 0x04038F9D RID: 233373
			public const int Slider = 1;

			// Token: 0x04038F9E RID: 233374
			public const int TitleText = 2;

			// Token: 0x04038F9F RID: 233375
			public const int TemperatureBg = 3;

			// Token: 0x04038FA0 RID: 233376
			public const int FillArea = 4;
		}
	}
}
