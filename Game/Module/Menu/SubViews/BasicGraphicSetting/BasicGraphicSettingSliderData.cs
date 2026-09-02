using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu.SubViews.BasicGraphicSetting
{
	// Token: 0x020057B3 RID: 22451
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class BasicGraphicSettingSliderData
	{
		// Token: 0x06039153 RID: 233811 RVA: 0x00E77A14 File Offset: 0x00E75C14
		public BasicGraphicSettingSliderData(MenuData metaData)
		{
			this.FunctionId = new EFunction?(metaData.FunctionId);
			this.MinValueInternal = metaData.SliderRange[0];
			this.MaxValueInternal = metaData.SliderRange[1];
			int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(metaData.FunctionId, true, true);
			this.CurValueInternal = ((currentValue != null) ? ((float)currentValue.GetValueOrDefault()) : metaData.SliderDefault);
			this.DefaultValueInternal = metaData.SliderDefault;
			this.TitleInternal = metaData.FunctionName;
			this.MetaData = metaData;
		}

		// Token: 0x170091AB RID: 37291
		// (get) Token: 0x06039154 RID: 233812 RVA: 0x00E77AD5 File Offset: 0x00E75CD5
		public MenuData MenuData
		{
			get
			{
				return this.MetaData;
			}
		}

		// Token: 0x170091AC RID: 37292
		// (get) Token: 0x06039155 RID: 233813 RVA: 0x00E77ADD File Offset: 0x00E75CDD
		public float MinValue
		{
			get
			{
				return this.MinValueInternal;
			}
		}

		// Token: 0x170091AD RID: 37293
		// (get) Token: 0x06039156 RID: 233814 RVA: 0x00E77AE5 File Offset: 0x00E75CE5
		public float MaxValue
		{
			get
			{
				return this.MaxValueInternal;
			}
		}

		// Token: 0x170091AE RID: 37294
		// (get) Token: 0x06039157 RID: 233815 RVA: 0x00E77AED File Offset: 0x00E75CED
		public float CurValue
		{
			get
			{
				return this.CurValueInternal;
			}
		}

		// Token: 0x170091AF RID: 37295
		// (get) Token: 0x06039158 RID: 233816 RVA: 0x00E77AF5 File Offset: 0x00E75CF5
		public float DefaultCurValue
		{
			get
			{
				return this.DefaultValueInternal;
			}
		}

		// Token: 0x170091B0 RID: 37296
		// (get) Token: 0x06039159 RID: 233817 RVA: 0x00E77AFD File Offset: 0x00E75CFD
		public string Title
		{
			get
			{
				return this.TitleInternal;
			}
		}

		// Token: 0x0603915A RID: 233818 RVA: 0x00E77B05 File Offset: 0x00E75D05
		public void OnApplyValue()
		{
			Singleton<GameSettingsManager>.Instance.HandleValueChange(this.FunctionId.Value, (int)this.CurValueInternal, EGameSettingsApplyReason.WhenUi);
		}

		// Token: 0x040207EB RID: 133099
		protected float MinValueInternal;

		// Token: 0x040207EC RID: 133100
		protected float MaxValueInternal;

		// Token: 0x040207ED RID: 133101
		protected float CurValueInternal;

		// Token: 0x040207EE RID: 133102
		protected float DefaultValueInternal;

		// Token: 0x040207EF RID: 133103
		protected string TitleInternal = "";

		// Token: 0x040207F0 RID: 133104
		protected EFunction? FunctionId;

		// Token: 0x040207F1 RID: 133105
		[Nullable(2)]
		protected MenuData MetaData;

		// Token: 0x040207F2 RID: 133106
		public Action<float> OnChangeValue = delegate(float value)
		{
		};
	}
}
