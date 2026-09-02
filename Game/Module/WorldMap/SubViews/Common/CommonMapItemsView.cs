using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Common
{
	// Token: 0x02004BC8 RID: 19400
	[NullableContext(2)]
	[Nullable(0)]
	public class CommonMapItemsView : UiPanelBase
	{
		// Token: 0x06032A29 RID: 207401 RVA: 0x00CAF2F8 File Offset: 0x00CAD4F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBtnMapChange));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnBtnSwitch));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032A2A RID: 207402 RVA: 0x00CAF424 File Offset: 0x00CAD624
		protected override void OnStart()
		{
			this.InitZoomButton();
			this.SetMapChangeButtonActive(false);
			this.SetSwitchButtonActive(false);
			this.SetScaleSliderActive(false);
		}

		// Token: 0x06032A2B RID: 207403 RVA: 0x00CAF444 File Offset: 0x00CAD644
		private void InitZoomButton()
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				this.ZoomInButton = new LongPressButton(button, delegate(float _)
				{
					this.OnZoomIn();
				}, 100);
			}
			UUIButtonComponent button2 = base.GetButton(1);
			if (button2 != null)
			{
				this.ZoomOutButton = new LongPressButton(button2, delegate(float _)
				{
					this.OnZoomOut();
				}, 100);
			}
		}

		// Token: 0x06032A2C RID: 207404 RVA: 0x00CAF49B File Offset: 0x00CAD69B
		private void OnZoomOut()
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_com_slider_tick");
			Singleton<EventSystem>.Instance.Emit<float, EMapScaleSetType>(EEventName.WorldMapZoomBtnInput, -0.1f, EMapScaleSetType.ZoomButton);
		}

		// Token: 0x06032A2D RID: 207405 RVA: 0x00CAF4C3 File Offset: 0x00CAD6C3
		private void OnZoomIn()
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_com_slider_tick");
			Singleton<EventSystem>.Instance.Emit<float, EMapScaleSetType>(EEventName.WorldMapZoomBtnInput, 0.1f, EMapScaleSetType.ZoomButton);
		}

		// Token: 0x06032A2E RID: 207406 RVA: 0x00CAF4EB File Offset: 0x00CAD6EB
		public UUISliderComponent GetScaleSlider()
		{
			return base.GetSlider(2);
		}

		// Token: 0x06032A2F RID: 207407 RVA: 0x00CAF4F4 File Offset: 0x00CAD6F4
		public void SetMapChangeButtonActive(bool active)
		{
			UUIButtonComponent button = base.GetButton(3);
			if (button == null)
			{
				return;
			}
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(active);
		}

		// Token: 0x06032A30 RID: 207408 RVA: 0x00CAF528 File Offset: 0x00CAD728
		public void SetSwitchButtonActive(bool active)
		{
			UUIButtonComponent button = base.GetButton(4);
			if (button == null)
			{
				return;
			}
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(active);
		}

		// Token: 0x06032A31 RID: 207409 RVA: 0x00CAF55C File Offset: 0x00CAD75C
		public void SetScaleSliderActive(bool active)
		{
			UUISliderComponent slider = base.GetSlider(2);
			if (slider != null)
			{
				UUIItem uuiitem = slider.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(active);
				}
			}
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				UUIItem uuiitem2 = button.RootUIComp.Get();
				if (uuiitem2 != null)
				{
					uuiitem2.SetUIActive(active);
				}
			}
			UUIButtonComponent button2 = base.GetButton(1);
			if (button2 == null)
			{
				return;
			}
			UUIItem uuiitem3 = button2.RootUIComp.Get();
			if (uuiitem3 == null)
			{
				return;
			}
			uuiitem3.SetUIActive(active);
		}

		// Token: 0x06032A32 RID: 207410 RVA: 0x00CAF5D9 File Offset: 0x00CAD7D9
		[NullableContext(1)]
		public void SetBtnMapChangeFunction(Action callback)
		{
			this.BtnMapChangeFunction = callback;
		}

		// Token: 0x06032A33 RID: 207411 RVA: 0x00CAF5E2 File Offset: 0x00CAD7E2
		[NullableContext(1)]
		public void SetBtnSwitchFunction(Action callback)
		{
			this.BtnSwitchFunction = callback;
		}

		// Token: 0x06032A34 RID: 207412 RVA: 0x00CAF5EB File Offset: 0x00CAD7EB
		private void OnBtnMapChange()
		{
			Action btnMapChangeFunction = this.BtnMapChangeFunction;
			if (btnMapChangeFunction == null)
			{
				return;
			}
			btnMapChangeFunction();
		}

		// Token: 0x06032A35 RID: 207413 RVA: 0x00CAF5FD File Offset: 0x00CAD7FD
		private void OnBtnSwitch()
		{
			Action btnSwitchFunction = this.BtnSwitchFunction;
			if (btnSwitchFunction == null)
			{
				return;
			}
			btnSwitchFunction();
		}

		// Token: 0x06032A36 RID: 207414 RVA: 0x00CAF610 File Offset: 0x00CAD810
		[NullableContext(1)]
		public UniTask CreateThenShow(UUIItem parent)
		{
			CommonMapItemsView.<CreateThenShow>d__18 <CreateThenShow>d__;
			<CreateThenShow>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateThenShow>d__.<>4__this = this;
			<CreateThenShow>d__.parent = parent;
			<CreateThenShow>d__.<>1__state = -1;
			<CreateThenShow>d__.<>t__builder.Start<CommonMapItemsView.<CreateThenShow>d__18>(ref <CreateThenShow>d__);
			return <CreateThenShow>d__.<>t__builder.Task;
		}

		// Token: 0x06032A37 RID: 207415 RVA: 0x00CAF65B File Offset: 0x00CAD85B
		protected override void OnBeforeDestroyImplement()
		{
			LongPressButton zoomInButton = this.ZoomInButton;
			if (zoomInButton != null)
			{
				zoomInButton.OnDestroy();
			}
			LongPressButton zoomOutButton = this.ZoomOutButton;
			if (zoomOutButton == null)
			{
				return;
			}
			zoomOutButton.OnDestroy();
		}

		// Token: 0x0401D802 RID: 120834
		private LongPressButton ZoomInButton;

		// Token: 0x0401D803 RID: 120835
		private LongPressButton ZoomOutButton;

		// Token: 0x0401D804 RID: 120836
		private Action BtnMapChangeFunction;

		// Token: 0x0401D805 RID: 120837
		private Action BtnSwitchFunction;

		// Token: 0x0200ACAE RID: 44206
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x04035A55 RID: 219733
			public const int ZoomIn = 0;

			// Token: 0x04035A56 RID: 219734
			public const int ZoomOut = 1;

			// Token: 0x04035A57 RID: 219735
			public const int VerticalSlider = 2;

			// Token: 0x04035A58 RID: 219736
			public const int BtnMapChange = 3;

			// Token: 0x04035A59 RID: 219737
			public const int BtnSwitch = 4;
		}
	}
}
