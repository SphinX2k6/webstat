using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.GameSettings;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.EyeProtect
{
	// Token: 0x020057AD RID: 22445
	[NullableContext(1)]
	[Nullable(0)]
	public class EyeProtectSliderData
	{
		// Token: 0x0603910B RID: 233739 RVA: 0x00E765A0 File Offset: 0x00E747A0
		public EyeProtectSliderData(MenuData metaData, EyeProtectViewModel viewModel, EModeValue modeValue)
		{
			this.FunctionIdInternal = new EFunction?(metaData.FunctionId);
			this.MinValueInternal = metaData.SliderRange[0];
			this.MaxValueInternal = metaData.SliderRange[1];
			this.ViewModel = viewModel;
			if (modeValue == EModeValue.Custom)
			{
				this.CurValueInternal = (Singleton<GameSettingsManager>.Instance.GetCurrentValueFloat(metaData.FunctionId, true) ?? metaData.SliderDefault);
			}
			else
			{
				this.CurValueInternal = metaData.SliderDefault;
				UKuroScreenBlueLightFilterParameter ukuroScreenBlueLightFilterParameter = null;
				if (modeValue == EModeValue.Strong)
				{
					EyeProtectViewModel viewModel2 = this.ViewModel;
					ukuroScreenBlueLightFilterParameter = ((viewModel2 != null) ? viewModel2.ParamStrong : null);
				}
				else if (modeValue == EModeValue.Weak)
				{
					EyeProtectViewModel viewModel3 = this.ViewModel;
					ukuroScreenBlueLightFilterParameter = ((viewModel3 != null) ? viewModel3.ParamWeak : null);
				}
				if (ukuroScreenBlueLightFilterParameter != null)
				{
					EFunction? functionIdInternal = this.FunctionIdInternal;
					if (functionIdInternal != null)
					{
						switch (functionIdInternal.GetValueOrDefault())
						{
						case EFunction.EyeProtectionTemp:
							this.CurValueInternal = ukuroScreenBlueLightFilterParameter.ScreenBlueLightFilterTemperature;
							break;
						case EFunction.EyeProtectionStrength:
							this.CurValueInternal = ukuroScreenBlueLightFilterParameter.ScreenBlueLightFilterStrength;
							break;
						case EFunction.EyeProtectionBrightness:
							this.CurValueInternal = ukuroScreenBlueLightFilterParameter.ScreenBrightnessClampMax;
							break;
						case EFunction.EyeProtectionTexture:
							this.CurValueInternal = ukuroScreenBlueLightFilterParameter.ScreenBlueLightFilterTextureIntensity;
							break;
						}
					}
				}
			}
			this.DefaultValueInternal = metaData.SliderDefault;
			this.TitleInternal = metaData.FunctionName;
			this.MetaData = metaData;
			this.ViewModel = viewModel;
			this.ModeValue = new EModeValue?(modeValue);
			this.OnChangeValue = new Action<float>(this.OnChangeValueImpl);
			this.OnApplyValue = new Action(this.OnApplyValueImpl);
		}

		// Token: 0x170091A3 RID: 37283
		// (get) Token: 0x0603910C RID: 233740 RVA: 0x00E7672D File Offset: 0x00E7492D
		public MenuData MenuData
		{
			get
			{
				return this.MetaData;
			}
		}

		// Token: 0x170091A4 RID: 37284
		// (get) Token: 0x0603910D RID: 233741 RVA: 0x00E76735 File Offset: 0x00E74935
		public float MinValue
		{
			get
			{
				return this.MinValueInternal;
			}
		}

		// Token: 0x170091A5 RID: 37285
		// (get) Token: 0x0603910E RID: 233742 RVA: 0x00E7673D File Offset: 0x00E7493D
		public float MaxValue
		{
			get
			{
				return this.MaxValueInternal;
			}
		}

		// Token: 0x170091A6 RID: 37286
		// (get) Token: 0x0603910F RID: 233743 RVA: 0x00E76745 File Offset: 0x00E74945
		public float CurValue
		{
			get
			{
				return this.CurValueInternal;
			}
		}

		// Token: 0x170091A7 RID: 37287
		// (get) Token: 0x06039110 RID: 233744 RVA: 0x00E7674D File Offset: 0x00E7494D
		public float DefaultCurValue
		{
			get
			{
				return this.DefaultValueInternal;
			}
		}

		// Token: 0x170091A8 RID: 37288
		// (get) Token: 0x06039111 RID: 233745 RVA: 0x00E76755 File Offset: 0x00E74955
		public string Title
		{
			get
			{
				return this.TitleInternal;
			}
		}

		// Token: 0x170091A9 RID: 37289
		// (get) Token: 0x06039112 RID: 233746 RVA: 0x00E7675D File Offset: 0x00E7495D
		public EFunction? FunctionId
		{
			get
			{
				return this.FunctionIdInternal;
			}
		}

		// Token: 0x06039113 RID: 233747 RVA: 0x00E76765 File Offset: 0x00E74965
		public EModeValue? GetModeValue()
		{
			return this.ModeValue;
		}

		// Token: 0x06039114 RID: 233748 RVA: 0x00E76770 File Offset: 0x00E74970
		private void OnChangeValueImpl(float value)
		{
			if (this.GetModeValue().GetValueOrDefault() != EModeValue.Custom)
			{
				return;
			}
			if (this.ViewModel != null)
			{
				this.ViewModel.IsSliderDirty = true;
				Action onSliderValueChange = this.ViewModel.OnSliderValueChange;
				if (onSliderValueChange != null)
				{
					onSliderValueChange();
				}
				this.CurValueInternal = value;
				EFunction? functionId = this.FunctionId;
				if (functionId != null)
				{
					switch (functionId.GetValueOrDefault())
					{
					case EFunction.EyeProtectionTemp:
						GameSettingsUtils.ApplyEyeProtectionTemp(value, (int)this.ModeValue.Value);
						return;
					case EFunction.EyeProtectionStrength:
						GameSettingsUtils.ApplyEyeProtectionStrength(value, (int)this.ModeValue.Value);
						return;
					case EFunction.EyeProtectionBrightness:
						GameSettingsUtils.ApplyEyeProtectionBrightness(value, (int)this.ModeValue.Value);
						return;
					case EFunction.EyeProtectionTexture:
						GameSettingsUtils.ApplyEyeProtectionTexture(value, (int)this.ModeValue.Value);
						break;
					default:
						return;
					}
				}
			}
		}

		// Token: 0x06039115 RID: 233749 RVA: 0x00E76844 File Offset: 0x00E74A44
		public void OnSetValue()
		{
			EFunction? functionId = this.FunctionId;
			if (functionId != null)
			{
				switch (functionId.GetValueOrDefault())
				{
				case EFunction.EyeProtectionTemp:
					GameSettingsUtils.ApplyEyeProtectionTemp(this.CurValueInternal, (int)this.ModeValue.Value);
					return;
				case EFunction.EyeProtectionStrength:
					GameSettingsUtils.ApplyEyeProtectionStrength(this.CurValueInternal, (int)this.ModeValue.Value);
					return;
				case EFunction.EyeProtectionBrightness:
					GameSettingsUtils.ApplyEyeProtectionBrightness(this.CurValueInternal, (int)this.ModeValue.Value);
					return;
				case EFunction.EyeProtectionTexture:
					GameSettingsUtils.ApplyEyeProtectionTexture(this.CurValueInternal, (int)this.ModeValue.Value);
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x06039116 RID: 233750 RVA: 0x00E768E8 File Offset: 0x00E74AE8
		private void OnApplyValueImpl()
		{
			if (this.GetModeValue().GetValueOrDefault() != EModeValue.Custom)
			{
				return;
			}
			Singleton<GameSettingsManager>.Instance.HandleValueChangeFloat(this.FunctionId.Value, this.CurValueInternal, EGameSettingsApplyReason.WhenUi);
		}

		// Token: 0x040207C5 RID: 133061
		protected float MinValueInternal;

		// Token: 0x040207C6 RID: 133062
		protected float MaxValueInternal;

		// Token: 0x040207C7 RID: 133063
		protected float CurValueInternal;

		// Token: 0x040207C8 RID: 133064
		protected float DefaultValueInternal;

		// Token: 0x040207C9 RID: 133065
		protected string TitleInternal = "";

		// Token: 0x040207CA RID: 133066
		[Nullable(2)]
		protected EyeProtectViewModel ViewModel;

		// Token: 0x040207CB RID: 133067
		protected EFunction? FunctionIdInternal;

		// Token: 0x040207CC RID: 133068
		[Nullable(2)]
		protected MenuData MetaData;

		// Token: 0x040207CD RID: 133069
		protected EModeValue? ModeValue;

		// Token: 0x040207CE RID: 133070
		public Action<float> OnChangeValue;

		// Token: 0x040207CF RID: 133071
		public Action OnApplyValue;
	}
}
