using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053D5 RID: 21461
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotWordArtCaptionView : UiViewBase
	{
		// Token: 0x06036C9D RID: 224413 RVA: 0x00DE5E19 File Offset: 0x00DE4019
		[NullableContext(1)]
		public PlotWordArtCaptionView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036C9E RID: 224414 RVA: 0x00DE5E24 File Offset: 0x00DE4024
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036C9F RID: 224415 RVA: 0x00DE5EB0 File Offset: 0x00DE40B0
		protected override void OnStart()
		{
			PlotWordArtCaptionViewParams plotWordArtCaptionViewParams = this.OpenParam as PlotWordArtCaptionViewParams;
			if (plotWordArtCaptionViewParams != null && !string.IsNullOrEmpty(plotWordArtCaptionViewParams.TidSubtitleText))
			{
				UUIText text = base.GetText(0);
				if (text != null)
				{
					text.ShowTextNew(plotWordArtCaptionViewParams.TidSubtitleText);
				}
			}
			else
			{
				UUIText text2 = base.GetText(0);
				if (text2 != null)
				{
					text2.SetUIActive(false);
				}
			}
			this.TweenStartComp = (base.GetItem(2).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			ULGUIPlayTweenComponent tweenStartComp = this.TweenStartComp;
			if (tweenStartComp != null)
			{
				tweenStartComp.Stop();
			}
			this.TweenCloseComp = (base.GetItem(1).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			if (this.TweenCloseComp != null)
			{
				this.TweenCloseComp.Stop();
				this.TweenCloseEndDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPlayTweenCompleteDynamicDelegate>(new Action(this.OnTweenCloseEnd));
				this.TweenCloseEndDelegateWrapper = this.TweenCloseComp.GetPlayTween().RegisterOnComplete(this.TweenCloseEndDelegate);
			}
		}

		// Token: 0x06036CA0 RID: 224416 RVA: 0x00DE5FA9 File Offset: 0x00DE41A9
		protected override void OnAfterShow()
		{
			ULGUIPlayTweenComponent tweenStartComp = this.TweenStartComp;
			if (tweenStartComp == null)
			{
				return;
			}
			tweenStartComp.Play();
		}

		// Token: 0x06036CA1 RID: 224417 RVA: 0x00DE5FBC File Offset: 0x00DE41BC
		protected override UniTask OnBeforeHideAsync()
		{
			PlotWordArtCaptionView.<OnBeforeHideAsync>d__10 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<PlotWordArtCaptionView.<OnBeforeHideAsync>d__10>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036CA2 RID: 224418 RVA: 0x00DE6000 File Offset: 0x00DE4200
		protected override void OnBeforeDestroy()
		{
			if (this.TweenCloseEndDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnTweenCloseEnd));
				this.TweenCloseEndDelegate = null;
			}
			if (this.TweenCloseEndDelegateWrapper != null)
			{
				this.TweenCloseComp.GetPlayTween().UnregisterOnComplete(this.TweenCloseEndDelegateWrapper);
				this.TweenCloseEndDelegateWrapper = null;
			}
		}

		// Token: 0x06036CA3 RID: 224419 RVA: 0x00DE6058 File Offset: 0x00DE4258
		private void OnTweenCloseEnd()
		{
			CustomPromise<bool> tweenClosePromise = this.TweenClosePromise;
			if (tweenClosePromise != null)
			{
				tweenClosePromise.SetResult(true);
			}
			this.TweenClosePromise = null;
		}

		// Token: 0x0401F8D4 RID: 129236
		private ULGUIPlayTweenComponent TweenStartComp;

		// Token: 0x0401F8D5 RID: 129237
		private ULGUIPlayTweenComponent TweenCloseComp;

		// Token: 0x0401F8D6 RID: 129238
		private FLGUIPlayTweenCompleteDynamicDelegate TweenCloseEndDelegate;

		// Token: 0x0401F8D7 RID: 129239
		private FLGUIDelegateHandleWrapper TweenCloseEndDelegateWrapper;

		// Token: 0x0401F8D8 RID: 129240
		private CustomPromise<bool> TweenClosePromise;

		// Token: 0x0200B37F RID: 45951
		[NullableContext(0)]
		private enum EComponentDefine
		{
			// Token: 0x0403798A RID: 227722
			Text,
			// Token: 0x0403798B RID: 227723
			TweenClose,
			// Token: 0x0403798C RID: 227724
			TweenStart
		}
	}
}
