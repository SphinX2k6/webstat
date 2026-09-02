using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053DC RID: 21468
	public class VideoPromptView : UiViewBase
	{
		// Token: 0x06036CCA RID: 224458 RVA: 0x00DE68C1 File Offset: 0x00DE4AC1
		[NullableContext(1)]
		public VideoPromptView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036CCB RID: 224459 RVA: 0x00DE68CC File Offset: 0x00DE4ACC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036CCC RID: 224460 RVA: 0x00DE6914 File Offset: 0x00DE4B14
		protected override UniTask OnBeforeStartAsync()
		{
			VideoPromptView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VideoPromptView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036CCD RID: 224461 RVA: 0x00DE6957 File Offset: 0x00DE4B57
		protected override void OnStart()
		{
			this.OnVideoViewShow();
			Singleton<EventSystem>.Instance.Add(EEventName.VideoViewShow, new Action(this.OnVideoViewShow));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.VideoViewHide, new Action<bool>(this.OnVideoViewHide));
		}

		// Token: 0x06036CCE RID: 224462 RVA: 0x00DE6998 File Offset: 0x00DE4B98
		protected override void OnAfterShow()
		{
			VideoPromptParam videoPromptParam = this.OpenParam as VideoPromptParam;
			if (videoPromptParam != null && videoPromptParam.AutoCloseTime != null)
			{
				TimerSystem.Instance.Delay(delegate(float _)
				{
					base.CloseMe(null);
				}, videoPromptParam.AutoCloseTime.Value * 1000f, null, null, true, 1f);
			}
		}

		// Token: 0x06036CCF RID: 224463 RVA: 0x00DE69F8 File Offset: 0x00DE4BF8
		protected override void OnAfterHide()
		{
			this.OnVideoViewHide(false);
			Singleton<EventSystem>.Instance.Remove(EEventName.VideoViewShow, new Action(this.OnVideoViewShow));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.VideoViewHide, new Action<bool>(this.OnVideoViewHide));
		}

		// Token: 0x06036CD0 RID: 224464 RVA: 0x00DE6A44 File Offset: 0x00DE4C44
		private void OnVideoViewShow()
		{
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.VideoView);
			if (!this.HasAttachVideoView && viewByName != null)
			{
				UUIItem rootItem = viewByName.GetRootItem();
				UUIItem originalItem = this.GetOriginalItem();
				if (originalItem != null)
				{
					originalItem.SetUIParent(rootItem, false);
				}
				this.HasAttachVideoView = true;
			}
		}

		// Token: 0x06036CD1 RID: 224465 RVA: 0x00DE6A8D File Offset: 0x00DE4C8D
		private void OnVideoViewHide(bool _)
		{
			if (this.HasAttachVideoView)
			{
				UUIItem originalItem = this.GetOriginalItem();
				if (originalItem != null)
				{
					originalItem.SetUIParent(Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Float), false);
				}
				this.HasAttachVideoView = false;
			}
		}

		// Token: 0x0401F8EB RID: 129259
		private bool HasAttachVideoView;

		// Token: 0x0200B386 RID: 45958
		private enum EChildComp
		{
			// Token: 0x0403799D RID: 227741
			Texture
		}
	}
}
