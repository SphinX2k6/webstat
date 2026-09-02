using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.FilterSetting
{
	// Token: 0x020057A8 RID: 22440
	[NullableContext(2)]
	[Nullable(0)]
	public class FilterSettingSliderItem : UiPanelBase
	{
		// Token: 0x170091A2 RID: 37282
		// (get) Token: 0x060390E7 RID: 233703 RVA: 0x00E76058 File Offset: 0x00E74258
		private FilterSettingViewModel ParentViewModel
		{
			get
			{
				if (this.OpenParam == null)
				{
					return null;
				}
				return this.OpenParam as FilterSettingViewModel;
			}
		}

		// Token: 0x060390E9 RID: 233705 RVA: 0x00E76078 File Offset: 0x00E74278
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(2, typeof(UUISprite))
			};
		}

		// Token: 0x060390EA RID: 233706 RVA: 0x00E760D4 File Offset: 0x00E742D4
		protected override UniTask OnBeforeStartAsync()
		{
			FilterSettingSliderItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FilterSettingSliderItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060390EB RID: 233707 RVA: 0x00E76117 File Offset: 0x00E74317
		protected override void OnBeforeDestroy()
		{
			UUISliderComponent slider = base.GetSlider(1);
			if (slider == null)
			{
				return;
			}
			slider.OnValueChangeCb.Unbind();
		}

		// Token: 0x060390EC RID: 233708 RVA: 0x00E7612F File Offset: 0x00E7432F
		private void OnSliderValueChanged(float value)
		{
			if (this.ParentViewModel != null && !this.ParentViewModel.IsPropertyDirty(2))
			{
				this.ParentViewModel.IntensityNormalized = value;
				Action onSliderChanged = this.ParentViewModel.OnSliderChanged;
				if (onSliderChanged == null)
				{
					return;
				}
				onSliderChanged();
			}
		}

		// Token: 0x060390ED RID: 233709 RVA: 0x00E76168 File Offset: 0x00E74368
		[NullableContext(1)]
		public void SetTitleText(string text)
		{
			UUIText text2 = base.GetText(0);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(text, true);
		}

		// Token: 0x060390EE RID: 233710 RVA: 0x00E7617D File Offset: 0x00E7437D
		public void SetSliderValue(float value)
		{
			UUISliderComponent slider = base.GetSlider(1);
			if (slider == null)
			{
				return;
			}
			slider.SetValue(value, false);
		}
	}
}
