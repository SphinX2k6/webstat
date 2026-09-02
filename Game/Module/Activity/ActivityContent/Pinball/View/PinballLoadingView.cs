using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View
{
	// Token: 0x02006596 RID: 26006
	public class PinballLoadingView : LoadingViewBase
	{
		// Token: 0x06040FC2 RID: 266178 RVA: 0x010ACBDF File Offset: 0x010AADDF
		[NullableContext(1)]
		public PinballLoadingView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040FC3 RID: 266179 RVA: 0x010ACBE8 File Offset: 0x010AADE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040FC4 RID: 266180 RVA: 0x010ACCB4 File Offset: 0x010AAEB4
		protected override UniTask OnBeforeStartAsync()
		{
			PinballLoadingView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballLoadingView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040FC5 RID: 266181 RVA: 0x010ACCF8 File Offset: 0x010AAEF8
		private UniTask InitLoopAutoScrollViewAsync()
		{
			PinballLoadingView.<InitLoopAutoScrollViewAsync>d__5 <InitLoopAutoScrollViewAsync>d__;
			<InitLoopAutoScrollViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLoopAutoScrollViewAsync>d__.<>4__this = this;
			<InitLoopAutoScrollViewAsync>d__.<>1__state = -1;
			<InitLoopAutoScrollViewAsync>d__.<>t__builder.Start<PinballLoadingView.<InitLoopAutoScrollViewAsync>d__5>(ref <InitLoopAutoScrollViewAsync>d__);
			return <InitLoopAutoScrollViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040FC6 RID: 266182 RVA: 0x010ACD3B File Offset: 0x010AAF3B
		[NullableContext(1)]
		private PinballLoadingTexView CreateGrid()
		{
			return new PinballLoadingTexView();
		}

		// Token: 0x06040FC7 RID: 266183 RVA: 0x010ACD42 File Offset: 0x010AAF42
		protected override void UpdateProgressRate(float rate)
		{
			UUISliderComponent slider = base.GetSlider(0);
			if (slider == null)
			{
				return;
			}
			slider.SetValue(rate, true);
		}

		// Token: 0x06040FC8 RID: 266184 RVA: 0x010ACD57 File Offset: 0x010AAF57
		protected override void UpdateProgressValue(float value)
		{
			this.SetTextProgressValue(1, value, "%");
		}

		// Token: 0x06040FC9 RID: 266185 RVA: 0x010ACD68 File Offset: 0x010AAF68
		private void SetDecorationTexture()
		{
			IReadOnlyList<string> stringArrayConfig = ConfigCommonParamById.GetStringArrayConfig("PinballLoadingDecorationTex");
			List<string> list = new List<string>();
			if (stringArrayConfig != null)
			{
				foreach (string item in stringArrayConfig)
				{
					list.Add(item);
				}
			}
			string randomItem = Singleton<MathUtils>.Instance.GetRandomItem<string>(list);
			base.TrySetTextureByPath(randomItem, base.GetTexture(4), new EUiViewName?(EUiViewName.PinballLoadingView), null);
		}

		// Token: 0x06040FCA RID: 266186 RVA: 0x010ACDEC File Offset: 0x010AAFEC
		protected override void OnBeforeDestroy()
		{
			LoopAutoScrollView<PinballLoadingTexView, string> loopAutoScrollView = this.LoopAutoScrollView;
			if (loopAutoScrollView != null)
			{
				loopAutoScrollView.StopAutoScroll();
			}
			this.LoopAutoScrollView = null;
		}

		// Token: 0x04024717 RID: 149271
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopAutoScrollView<PinballLoadingTexView, string> LoopAutoScrollView;

		// Token: 0x0200C588 RID: 50568
		private enum EComponent
		{
			// Token: 0x0403CCB5 RID: 249013
			Slider,
			// Token: 0x0403CCB6 RID: 249014
			TextProgress,
			// Token: 0x0403CCB7 RID: 249015
			Scroll,
			// Token: 0x0403CCB8 RID: 249016
			ScrollItem,
			// Token: 0x0403CCB9 RID: 249017
			TexDecoration
		}
	}
}
