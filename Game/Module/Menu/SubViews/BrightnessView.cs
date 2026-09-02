using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Render;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005778 RID: 22392
	[NullableContext(2)]
	[Nullable(0)]
	public class BrightnessView : UiViewBase
	{
		// Token: 0x06038FD8 RID: 233432 RVA: 0x00E70A08 File Offset: 0x00E6EC08
		[NullableContext(1)]
		public BrightnessView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038FD9 RID: 233433 RVA: 0x00E70A14 File Offset: 0x00E6EC14
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnYes)),
				new ValueTuple<int, Delegate>(1, new Action(this.OnReset)),
				new ValueTuple<int, Delegate>(2, new Action<float>(this.OnSlide))
			};
		}

		// Token: 0x06038FDA RID: 233434 RVA: 0x00E70B30 File Offset: 0x00E6ED30
		private void OnSub(bool _)
		{
			float newVal = base.GetSlider(2).GetValue() - 5f;
			this.ChangeSlider(newVal, true);
		}

		// Token: 0x06038FDB RID: 233435 RVA: 0x00E70B58 File Offset: 0x00E6ED58
		private void OnAdd(bool _)
		{
			float newVal = base.GetSlider(2).GetValue() + 5f;
			this.ChangeSlider(newVal, true);
		}

		// Token: 0x06038FDC RID: 233436 RVA: 0x00E70B80 File Offset: 0x00E6ED80
		private void ChangeSlider(float newVal, bool isFire = true)
		{
			if (newVal >= 100f)
			{
				base.GetButton(7).SetSelfInteractive(false);
			}
			else if (newVal <= 0f)
			{
				base.GetButton(6).SetSelfInteractive(false);
			}
			else
			{
				base.GetButton(6).SetSelfInteractive(true);
				base.GetButton(7).SetSelfInteractive(true);
			}
			base.GetSlider(2).SetValue(Singleton<MathUtils>.Instance.Clamp(newVal, 0f, 100f), isFire);
		}

		// Token: 0x06038FDD RID: 233437 RVA: 0x00E70BF8 File Offset: 0x00E6EDF8
		protected override void OnStart()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				childPopView.PopItem.OverrideBackBtnCallBack(new Action(this.OnClose));
			}
			this.MenuSettingParam = (this.OpenParam as IReadOnlyList<object>);
			this.MenuDataIns = ((this.MenuSettingParam != null && this.MenuSettingParam.Count > 0) ? (this.MenuSettingParam[0] as MenuData) : null);
			if (this.MenuSettingParam != null && this.MenuSettingParam.Count > 1)
			{
				this.MenuSettingCallback = (this.MenuSettingParam[1] as Action<int, float>);
			}
			float num = this.MenuDataIns.SliderRange[0];
			float num2 = this.MenuDataIns.SliderRange[1];
			this.Scalar = Math.Abs(num2 - num) * 0.5f;
			this.LastData = (float)ControllerBase<MenuController>.Instance.GetTargetConfig(this.MenuDataIns.FunctionId) * this.Scalar;
			this.MenuSettingCallback((int)this.MenuDataIns.FunctionId, this.LastData / this.Scalar);
			float inValue = Singleton<MathUtils>.Instance.RangeClamp(this.LastData, num, num2, 0f, 100f);
			UUISliderComponent slider = base.GetSlider(2);
			slider.SetMaxValue(100f, true, false);
			slider.SetMinValue(0f, true, false);
			slider.SetValue(inValue, true);
			this.AddLongPress = new LongPressButtonItem(new OneOf<UUIButtonComponent, UUIExtendToggle>?(base.GetButton(7)), new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), new Action<bool>(this.OnAdd));
			this.RemoveLongPress = new LongPressButtonItem(new OneOf<UUIButtonComponent, UUIExtendToggle>?(base.GetButton(6)), new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), new Action<bool>(this.OnSub));
		}

		// Token: 0x06038FDE RID: 233438 RVA: 0x00E70DAE File Offset: 0x00E6EFAE
		private void OnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038FDF RID: 233439 RVA: 0x00E70DB8 File Offset: 0x00E6EFB8
		protected override void OnBeforeDestroy()
		{
			float outRangeA = this.MenuDataIns.SliderRange[0];
			float outRangeB = this.MenuDataIns.SliderRange[1];
			float value = base.GetSlider(2).GetValue();
			float num = Singleton<MathUtils>.Instance.RangeClamp(value, 0f, 100f, outRangeA, outRangeB);
			if (this.IsConfirm && this.LastData != num)
			{
				this.MenuSettingCallback((int)this.MenuDataIns.FunctionId, num / this.Scalar);
				this.IsConfirm = false;
			}
			else
			{
				this.MenuSettingCallback((int)this.MenuDataIns.FunctionId, this.LastData / this.Scalar);
			}
			LongPressButtonItem addLongPress = this.AddLongPress;
			if (addLongPress != null)
			{
				addLongPress.Clear();
			}
			LongPressButtonItem removeLongPress = this.RemoveLongPress;
			if (removeLongPress != null)
			{
				removeLongPress.Clear();
			}
			this.AddLongPress = null;
			this.RemoveLongPress = null;
		}

		// Token: 0x06038FE0 RID: 233440 RVA: 0x00E70E91 File Offset: 0x00E6F091
		private void OnYes()
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("AdjustBrighness", Array.Empty<object>());
			this.IsConfirm = true;
			this.OnClose();
		}

		// Token: 0x06038FE1 RID: 233441 RVA: 0x00E70EB4 File Offset: 0x00E6F0B4
		private void OnSlide(float value)
		{
			float num = this.Scalar / 2f;
			float parameterValue;
			if (value < num)
			{
				parameterValue = Singleton<MathUtils>.Instance.Lerp(1.5f, 2.2f, value / num);
			}
			else
			{
				parameterValue = Singleton<MathUtils>.Instance.Lerp(2.2f, 3.5f, (value - num) / num);
			}
			UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, Singleton<RenderDataManager>.Instance.GetUiShowBrightnessMaterialParameterCollection(), RenderConfig.UIShowBrightness, parameterValue);
			this.ChangeSlider(value, false);
		}

		// Token: 0x06038FE2 RID: 233442 RVA: 0x00E70F30 File Offset: 0x00E6F130
		private void OnReset()
		{
			float sliderDefault = this.MenuDataIns.SliderDefault;
			float sliderPosition = FunctionItemViewTool.GetSliderPosition(this.MenuDataIns.SliderRange, sliderDefault * this.Scalar, this.MenuDataIns.SliderDigits);
			base.GetSlider(2).SetValue(sliderPosition, true);
		}

		// Token: 0x0402070A RID: 132874
		private const int STEP = 5;

		// Token: 0x0402070B RID: 132875
		private const float SLIDER_MIN_VALUE = 0f;

		// Token: 0x0402070C RID: 132876
		private const float SLIDER_MAX_VALUE = 100f;

		// Token: 0x0402070D RID: 132877
		protected MenuData MenuDataIns;

		// Token: 0x0402070E RID: 132878
		protected bool IsConfirm;

		// Token: 0x0402070F RID: 132879
		private float Scalar;

		// Token: 0x04020710 RID: 132880
		private float LastData;

		// Token: 0x04020711 RID: 132881
		private IReadOnlyList<object> MenuSettingParam;

		// Token: 0x04020712 RID: 132882
		private Action<int, float> MenuSettingCallback;

		// Token: 0x04020713 RID: 132883
		private LongPressButtonItem AddLongPress;

		// Token: 0x04020714 RID: 132884
		private LongPressButtonItem RemoveLongPress;
	}
}
