using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.BasicGraphicSetting
{
	// Token: 0x020057B9 RID: 22457
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BasicGraphicSettingSliderItem : GridProxyAbstract<BasicGraphicSettingSliderData>
	{
		// Token: 0x06039169 RID: 233833 RVA: 0x00E77E90 File Offset: 0x00E76090
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText))
			};
		}

		// Token: 0x0603916A RID: 233834 RVA: 0x00E77F18 File Offset: 0x00E76118
		protected override void OnStart()
		{
			this.LongPressAdd = new LongPressButtonItem(new OneOf<UUIButtonComponent, UUIExtendToggle>?(base.GetButton(1)), new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), new Action<bool>(this.OnAdd));
			this.LongPressReduce = new LongPressButtonItem(new OneOf<UUIButtonComponent, UUIExtendToggle>?(base.GetButton(0)), new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), new Action<bool>(this.OnReduce));
			this.LongPressAdd.ShouldPlayLongPressSound = true;
			this.LongPressReduce.ShouldPlayLongPressSound = true;
			this.Slider = base.GetSlider(2);
			this.Slider.OnValueChangeCb.Bind(new Action<float>(this.OnValueChange));
		}

		// Token: 0x0603916B RID: 233835 RVA: 0x00E77FC2 File Offset: 0x00E761C2
		protected override void OnBeforeDestroy()
		{
			this.LongPressAdd.ShouldPlayLongPressSound = false;
			this.LongPressReduce.ShouldPlayLongPressSound = false;
			this.LongPressAdd.Clear();
			this.LongPressReduce.Clear();
			this.LongPressAdd = null;
			this.LongPressReduce = null;
		}

		// Token: 0x0603916C RID: 233836 RVA: 0x00E78000 File Offset: 0x00E76200
		[NullableContext(1)]
		public override void Refresh(BasicGraphicSettingSliderData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(4), data.Title, Array.Empty<object>());
			UUISliderComponent slider = base.GetSlider(2);
			slider.SetMaxValue(data.MaxValue, true, false);
			slider.SetMinValue(data.MinValue, true, false);
			slider.SetValue(data.CurValue, true);
			float sliderDisplayValue = FunctionItemViewTool.GetSliderDisplayValue(data.MenuData, data.CurValue);
			base.GetText(3).SetText(sliderDisplayValue.ToString(), true);
		}

		// Token: 0x0603916D RID: 233837 RVA: 0x00E78088 File Offset: 0x00E76288
		private void OnReduce(bool _)
		{
			if (this.Data == null)
			{
				return;
			}
			float actualSliderStep = FunctionItemViewTool.GetActualSliderStep(this.Data.MenuData, 1f);
			float inValue = Math.Max(this.Data.CurValue - actualSliderStep, this.Data.MinValue);
			this.Slider.SetValue(inValue, true);
		}

		// Token: 0x0603916E RID: 233838 RVA: 0x00E780E0 File Offset: 0x00E762E0
		private void OnAdd(bool _)
		{
			if (this.Data == null)
			{
				return;
			}
			float actualSliderStep = FunctionItemViewTool.GetActualSliderStep(this.Data.MenuData, 1f);
			float inValue = Math.Min(this.Data.CurValue + actualSliderStep, this.Data.MaxValue);
			this.Slider.SetValue(inValue, true);
		}

		// Token: 0x0603916F RID: 233839 RVA: 0x00E78138 File Offset: 0x00E76338
		private void OnValueChange(float value)
		{
			if (this.Data == null)
			{
				return;
			}
			this.Data.OnChangeValue(value);
			float sliderDisplayValue = FunctionItemViewTool.GetSliderDisplayValue(this.Data.MenuData, value);
			base.GetText(3).SetText(sliderDisplayValue.ToString(), true);
		}

		// Token: 0x040207FA RID: 133114
		private BasicGraphicSettingSliderData Data;

		// Token: 0x040207FB RID: 133115
		private LongPressButtonItem LongPressAdd;

		// Token: 0x040207FC RID: 133116
		private LongPressButtonItem LongPressReduce;

		// Token: 0x040207FD RID: 133117
		private UUISliderComponent Slider;
	}
}
