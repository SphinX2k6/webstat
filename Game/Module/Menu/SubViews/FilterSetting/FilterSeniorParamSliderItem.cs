using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.FilterSetting
{
	// Token: 0x020057A4 RID: 22436
	public class FilterSeniorParamSliderItem : GridProxyAbstract<FilterSeniorSetting>
	{
		// Token: 0x060390BD RID: 233661 RVA: 0x00E74BEC File Offset: 0x00E72DEC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText))
			};
		}

		// Token: 0x060390BE RID: 233662 RVA: 0x00E74C88 File Offset: 0x00E72E88
		protected override void OnStart()
		{
			base.GetSlider(1).OnValueChangeCb.Bind(new Action<float>(this.OnSliderValueChanged));
		}

		// Token: 0x060390BF RID: 233663 RVA: 0x00E74CA8 File Offset: 0x00E72EA8
		public override void Refresh(FilterSeniorSetting data, bool isSelected, int gridIndex)
		{
			this.FilterSeniorSetting = data;
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				sprite.SetUIActive(data.IsNeedSpecialBg);
			}
			UUISprite sprite2 = base.GetSprite(3);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(!data.IsNeedSpecialBg);
			}
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(!data.IsNeedSpecialBg);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), data.Name, Array.Empty<object>());
			int filterSettingIdCache = ModelBase<MenuModel>.Instance.FilterSettingIdCache;
			float[] array;
			if (!ModelBase<MenuModel>.Instance.FilterSettingValuesCache.TryGetValue(filterSettingIdCache, out array))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GameSettings;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "全局滤镜高级参数未找到默认值";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("param", this.FilterSeniorSetting.ParamIndex);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			double num = Math.Round((double)(array[this.FilterSeniorSetting.ParamIndex] * (float)this.FilterSeniorSetting.Ratio));
			if (num == 0.0)
			{
				num = 0.0;
			}
			UUIText text = base.GetText(0);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted<double>(num);
			defaultInterpolatedStringHandler.AppendFormatted(this.FilterSeniorSetting.Unit);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			double num2 = Singleton<MathUtils>.Instance.RangeClamp(num, (double)this.FilterSeniorSetting.RangeMin, (double)this.FilterSeniorSetting.RangeMax, 0.0, 1.0);
			UUISliderComponent slider = base.GetSlider(1);
			if (slider == null)
			{
				return;
			}
			slider.SetValue((float)num2, false);
		}

		// Token: 0x060390C0 RID: 233664 RVA: 0x00E74E40 File Offset: 0x00E73040
		private void OnSliderValueChanged(float value)
		{
			FilterSettingViewModel parentViewModel = this.ParentViewModel;
			if (parentViewModel != null && parentViewModel.IsPropertyDirty(512))
			{
				return;
			}
			float num = Singleton<MathUtils>.Instance.RangeClamp(value, 0f, 1f, this.FilterSeniorSetting.RangeMin, this.FilterSeniorSetting.RangeMax);
			float arg = num / (float)this.FilterSeniorSetting.Ratio;
			FilterSettingViewModel parentViewModel2 = this.ParentViewModel;
			if (parentViewModel2 != null)
			{
				Action<EFilterSettingValueIndex, float> onSeniorSliderChanged = parentViewModel2.OnSeniorSliderChanged;
				if (onSeniorSliderChanged != null)
				{
					onSeniorSliderChanged((EFilterSettingValueIndex)this.FilterSeniorSetting.ParamIndex, arg);
				}
			}
			double num2 = Math.Round((double)num);
			if (num2 == 0.0)
			{
				num2 = 0.0;
			}
			UUIText text = base.GetText(0);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted<double>(num2);
			defaultInterpolatedStringHandler.AppendFormatted(this.FilterSeniorSetting.Unit);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x040207A5 RID: 133029
		[Nullable(2)]
		public FilterSettingViewModel ParentViewModel;

		// Token: 0x040207A6 RID: 133030
		private FilterSeniorSetting FilterSeniorSetting;

		// Token: 0x0200B829 RID: 47145
		public class EComponent
		{
			// Token: 0x04038F56 RID: 233302
			public const int TextValue = 0;

			// Token: 0x04038F57 RID: 233303
			public const int SliderValue = 1;

			// Token: 0x04038F58 RID: 233304
			public const int SpriteHandle = 2;

			// Token: 0x04038F59 RID: 233305
			public const int SpriteNormalBg = 3;

			// Token: 0x04038F5A RID: 233306
			public const int SpriteTempBg = 4;

			// Token: 0x04038F5B RID: 233307
			public const int ItemFillArea = 5;

			// Token: 0x04038F5C RID: 233308
			public const int ToggleRoot = 6;

			// Token: 0x04038F5D RID: 233309
			public const int TextName = 7;
		}
	}
}
