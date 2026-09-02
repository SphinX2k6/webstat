using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CommonH5
{
	// Token: 0x020069B1 RID: 27057
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CommonH5Controller : ActivityControllerBase<CommonH5Controller>
	{
		// Token: 0x0604317B RID: 274811 RVA: 0x0113B7E1 File Offset: 0x011399E1
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x0604317C RID: 274812 RVA: 0x0113B7E3 File Offset: 0x011399E3
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_H5Main";
		}

		// Token: 0x0604317D RID: 274813 RVA: 0x0113B7EA File Offset: 0x011399EA
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.ActivityId = data.Id;
			return new CommonH5Data();
		}

		// Token: 0x0604317E RID: 274814 RVA: 0x0113B7FD File Offset: 0x011399FD
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0604317F RID: 274815 RVA: 0x0113B800 File Offset: 0x01139A00
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new CommonH5SubView();
		}

		// Token: 0x06043180 RID: 274816 RVA: 0x0113B807 File Offset: 0x01139A07
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<H5ViewActivityDataNotify>(ENotifyMessageId.H5ViewActivityDataNotify, new Action<H5ViewActivityDataNotify, Net.CallbackStatus>(this.HandleActivityDataNotify));
		}

		// Token: 0x06043181 RID: 274817 RVA: 0x0113B825 File Offset: 0x01139A25
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.H5ViewActivityDataNotify);
		}

		// Token: 0x06043182 RID: 274818 RVA: 0x0113B837 File Offset: 0x01139A37
		private void HandleActivityDataNotify(H5ViewActivityDataNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<CommonH5Model>.Instance.OnActivityDataNotify(notify);
		}

		// Token: 0x06043183 RID: 274819 RVA: 0x0113B844 File Offset: 0x01139A44
		private void RequestSaveReadState()
		{
			H5ViewActivityReadRequest message = H5ViewActivityReadRequest.Create();
			Singleton<Net>.Instance.Call<H5ViewActivityReadResponse>(ERequestMessageId.H5ViewActivityReadRequest, message, delegate(H5ViewActivityReadResponse response, Net.CallbackStatus _)
			{
			}, 0);
		}

		// Token: 0x06043184 RID: 274820 RVA: 0x0113B887 File Offset: 0x01139A87
		[NullableContext(2)]
		public void HandleOnEnterClick(CommonH5Data activityData)
		{
			if (activityData != null)
			{
				activityData.SetCurrentLoginClickState(true);
			}
			this.OpenUrl(activityData);
		}

		// Token: 0x06043185 RID: 274821 RVA: 0x0113B89C File Offset: 0x01139A9C
		[NullableContext(2)]
		private void OpenUrl(CommonH5Data data)
		{
			if (data == null)
			{
				return;
			}
			string text = data.GetRootUrl();
			if (text == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "无法获取根链接", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			text = Singleton<PublicUtil>.Instance.GetExternalUrl(text, PublicUtil.EExternalUrlReason.CommonH5);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "打开外部链接";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("url", text);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (text != null)
			{
				ModelBase<CommonH5Model>.Instance.SaveClickRedDotState();
				this.RequestSaveReadState();
				Singleton<EventSystem>.Instance.Emit(EEventName.RefreshCommonH5ActivityRedDot);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, data.Id);
				if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
				{
					text = Singleton<PublicUtil>.Instance.GetExtendExternalUrl(text, true);
					ControllerBase<KuroSdkController>.Instance.OpenWebView("", text, true, true, true, "Default");
					return;
				}
				text = Singleton<PublicUtil>.Instance.GetExtendExternalUrl(text, false);
				ControllerBase<KuroSdkController>.Instance.OpenExternalUrl(text);
			}
		}

		// Token: 0x04025644 RID: 153156
		public int ActivityId;
	}
}
