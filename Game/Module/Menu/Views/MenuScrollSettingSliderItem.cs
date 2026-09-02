using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.Views
{
	// Token: 0x02005773 RID: 22387
	public class MenuScrollSettingSliderItem : MenuScrollSettingBaseItem
	{
		// Token: 0x06038FA0 RID: 233376 RVA: 0x00E6FDD4 File Offset: 0x00E6DFD4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUIExtendToggleSpriteTransition))
			};
		}

		// Token: 0x06038FA1 RID: 233377 RVA: 0x00E6FE86 File Offset: 0x00E6E086
		protected override void OnStart()
		{
			base.GetSlider(1).SetCanClickWhenDisable(true);
			this.AddSliderEvent();
		}

		// Token: 0x06038FA2 RID: 233378 RVA: 0x00E6FE9B File Offset: 0x00E6E09B
		protected override void OnClear()
		{
			FLGUISliderDynamicDelegate onValueChangeCb = base.GetSlider(1).OnValueChangeCb;
			if (onValueChangeCb != null)
			{
				onValueChangeCb.Unbind();
			}
			FLGUISliderEndDragDelegate onEndDragCb = base.GetSlider(1).OnEndDragCb;
			if (onEndDragCb != null)
			{
				onEndDragCb.Unbind();
			}
			if (this.Data != null)
			{
				this.Data = null;
			}
		}

		// Token: 0x06038FA3 RID: 233379 RVA: 0x00E6FEDA File Offset: 0x00E6E0DA
		[NullableContext(1)]
		public override void Update(MenuData data, bool bGameSettingsUpdate)
		{
			this.Data = data;
			this.RefreshTitle();
			if (!bGameSettingsUpdate)
			{
				this.RefreshSlider();
			}
			this.RefreshDetailText();
			this.RefreshDetailSpriteVisible();
			this.RefreshDetailSprite().Forget();
		}

		// Token: 0x06038FA4 RID: 233380 RVA: 0x00E6FF09 File Offset: 0x00E6E109
		private void RefreshTitle()
		{
			base.GetText(0).ShowTextNew(this.Data.FunctionName ?? "");
		}

		// Token: 0x06038FA5 RID: 233381 RVA: 0x00E6FF2C File Offset: 0x00E6E12C
		private void RefreshSlider()
		{
			float[] sliderRange = this.Data.SliderRange;
			float num = sliderRange[0];
			float num2 = sliderRange[1];
			MenuModel instance = ModelBase<MenuModel>.Instance;
			int? num3 = (instance != null) ? instance.GetDataCacheOrCurValue(this.Data.FunctionId) : null;
			float floatPointFloor = Singleton<MathUtils>.Instance.GetFloatPointFloor((float)num3.Value, this.Data.SliderDigits);
			UUISliderComponent slider = base.GetSlider(1);
			UUIItem rootComponent = slider.GetRootComponent();
			if (rootComponent != null)
			{
				rootComponent.SetUIActive(true);
			}
			slider.SetMaxValue(num2, true, false);
			slider.SetMinValue(num, true, false);
			this.SetSlider(Singleton<MathUtils>.Instance.Clamp(floatPointFloor, num, num2), false);
		}

		// Token: 0x06038FA6 RID: 233382 RVA: 0x00E6FFD0 File Offset: 0x00E6E1D0
		private void AddSliderEvent()
		{
			UUISliderComponent slider = base.GetSlider(1);
			if (slider != null)
			{
				slider.OnValueChangeCb.Bind(new Action<float>(this.OnSliderChangeCallback));
			}
			UUISliderComponent slider2 = base.GetSlider(1);
			if (slider2 == null)
			{
				return;
			}
			slider2.OnEndDragCb.Bind(new Action(this.OnSliderEndDragCallback));
		}

		// Token: 0x06038FA7 RID: 233383 RVA: 0x00E70022 File Offset: 0x00E6E222
		private void OnSliderChangeCallback(float position)
		{
			this.OnSliderChangeCallback(position, true);
		}

		// Token: 0x06038FA8 RID: 233384 RVA: 0x00E7002C File Offset: 0x00E6E22C
		private void OnSliderChangeCallback(float position, bool fire = true)
		{
			if (base.GetItemClickLimit(base.GetSlider(1)))
			{
				this.SetSlider(this.DisableValue, fire);
				return;
			}
			this.SetSliderText(position, fire);
		}

		// Token: 0x06038FA9 RID: 233385 RVA: 0x00E70053 File Offset: 0x00E6E253
		private void OnSliderEndDragCallback()
		{
			if (base.GetItemClickLimit(base.GetSlider(1)))
			{
				return;
			}
			this.OnSliderEnd();
		}

		// Token: 0x06038FAA RID: 233386 RVA: 0x00E7006B File Offset: 0x00E6E26B
		private void SetSlider(float position, bool fire = true)
		{
			base.GetSlider(1).SetValue(position, fire);
			this.SetSliderText(position, fire);
		}

		// Token: 0x06038FAB RID: 233387 RVA: 0x00E70084 File Offset: 0x00E6E284
		private void SetSliderText(float position, bool fire = true)
		{
			float sliderDisplayValue = FunctionItemViewTool.GetSliderDisplayValue(this.Data, position);
			base.GetText(2).SetText(sliderDisplayValue.ToString(), true);
			if (fire)
			{
				this.FireSaveMenuChange((int)sliderDisplayValue);
			}
		}

		// Token: 0x06038FAC RID: 233388 RVA: 0x00E700C2 File Offset: 0x00E6E2C2
		private void OnSliderEnd()
		{
			ModelBase<MenuModel>.Instance.IsEdited = true;
			this.PlaySequenceByName("Flashing".ToString());
		}

		// Token: 0x06038FAD RID: 233389 RVA: 0x00E700E4 File Offset: 0x00E6E2E4
		public override void SetInteractionActive(bool val)
		{
			base.GetSlider(1).SetSelfInteractive(val);
			if (!val)
			{
				this.DisableValue = base.GetSlider(1).GetValue();
			}
		}

		// Token: 0x06038FAE RID: 233390 RVA: 0x00E70108 File Offset: 0x00E6E308
		protected override void OnSetDetailVisible(bool bVisible)
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(bVisible);
			}
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.CanClickWhenDisable && !this.Data.GetEnable())
			{
				FColor color = bVisible ? FColor.FromHex("FFF7B6FF") : FColor.FromHex("FFFFFFFF");
				base.GetSprite(5).SetColor(color);
				base.GetUiExtendToggleSpriteTransition(6).TransitionState.UnDetermineUnHoverState.Color = color;
				base.GetUiExtendToggleSpriteTransition(6).TransitionState.UnDetermineHoverState.Color = color;
				base.GetUiExtendToggleSpriteTransition(6).TransitionState.UnDeterminePressedState.Color = color;
			}
		}

		// Token: 0x06038FAF RID: 233391 RVA: 0x00E701B8 File Offset: 0x00E6E3B8
		private void RefreshDetailText()
		{
			if (this.Data == null)
			{
				return;
			}
			if (!this.Data.HasDetailText())
			{
				return;
			}
			UUIText text = base.GetText(4);
			string detailTextId = this.Data.GetDetailTextId();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, detailTextId, Array.Empty<object>());
		}

		// Token: 0x06038FB0 RID: 233392 RVA: 0x00E70201 File Offset: 0x00E6E401
		private void RefreshDetailSpriteVisible()
		{
			if (this.Data == null)
			{
				return;
			}
			UUISprite sprite = base.GetSprite(5);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(this.Data.ShowHelpBtn());
		}

		// Token: 0x06038FB1 RID: 233393 RVA: 0x00E70228 File Offset: 0x00E6E428
		public UniTask RefreshDetailSprite()
		{
			MenuScrollSettingSliderItem.<RefreshDetailSprite>d__19 <RefreshDetailSprite>d__;
			<RefreshDetailSprite>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshDetailSprite>d__.<>4__this = this;
			<RefreshDetailSprite>d__.<>1__state = -1;
			<RefreshDetailSprite>d__.<>t__builder.Start<MenuScrollSettingSliderItem.<RefreshDetailSprite>d__19>(ref <RefreshDetailSprite>d__);
			return <RefreshDetailSprite>d__.<>t__builder.Task;
		}

		// Token: 0x04020700 RID: 132864
		private float DisableValue;

		// Token: 0x0200B812 RID: 47122
		private class EComponents
		{
			// Token: 0x04038F01 RID: 233217
			public const int Title = 0;

			// Token: 0x04038F02 RID: 233218
			public const int Slider = 1;

			// Token: 0x04038F03 RID: 233219
			public const int SliderText = 2;

			// Token: 0x04038F04 RID: 233220
			public const int DetailItem = 3;

			// Token: 0x04038F05 RID: 233221
			public const int DetailText = 4;

			// Token: 0x04038F06 RID: 233222
			public const int DetailSprite = 5;

			// Token: 0x04038F07 RID: 233223
			public const int DetailToggleTransition = 6;
		}
	}
}
