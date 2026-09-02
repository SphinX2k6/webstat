using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.MailBind
{
	// Token: 0x020059F9 RID: 23033
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class MailBindController : UiControllerBase<MailBindController>
	{
		// Token: 0x0603A59A RID: 239002 RVA: 0x00ECB912 File Offset: 0x00EC9B12
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(this.OnCrossDay));
		}

		// Token: 0x0603A59B RID: 239003 RVA: 0x00ECB94C File Offset: 0x00EC9B4C
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(this.OnCrossDay));
		}

		// Token: 0x0603A59C RID: 239004 RVA: 0x00ECB986 File Offset: 0x00EC9B86
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<MailBindInfoNotify>(ENotifyMessageId.MailBindInfoNotify, new Action<MailBindInfoNotify, Net.CallbackStatus>(this.OnMailBindInfoNotify));
		}

		// Token: 0x0603A59D RID: 239005 RVA: 0x00ECB9A4 File Offset: 0x00EC9BA4
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MailBindInfoNotify);
		}

		// Token: 0x0603A59E RID: 239006 RVA: 0x00ECB9B6 File Offset: 0x00EC9BB6
		public void MainBindInfoRequest()
		{
			this.MailBindInfoRequestAsync().ContinueWith(delegate(bool result)
			{
				if (!result)
				{
					Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.LZK, "请求邮箱绑定信息出错", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			});
		}

		// Token: 0x0603A59F RID: 239007 RVA: 0x00ECB9E4 File Offset: 0x00EC9BE4
		public UniTask<bool> MailBindInfoRequestAsync()
		{
			MailBindController.<MailBindInfoRequestAsync>d__5 <MailBindInfoRequestAsync>d__;
			<MailBindInfoRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<MailBindInfoRequestAsync>d__.<>1__state = -1;
			<MailBindInfoRequestAsync>d__.<>t__builder.Start<MailBindController.<MailBindInfoRequestAsync>d__5>(ref <MailBindInfoRequestAsync>d__);
			return <MailBindInfoRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A5A0 RID: 239008 RVA: 0x00ECBA20 File Offset: 0x00EC9C20
		public void MailBindRequest()
		{
			MailBindRequest message = Aki.Protocol.MailBindRequest.Create();
			Singleton<Net>.Instance.Call<MailBindResponse>(ERequestMessageId.MailBindRequest, message, delegate(MailBindResponse response, [Nullable(2)] Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.OnMailBindResponse);
			}, 0);
		}

		// Token: 0x0603A5A1 RID: 239009 RVA: 0x00ECBA64 File Offset: 0x00EC9C64
		public void MailBindRewardRequest()
		{
			MailBindRewardRequest message = Aki.Protocol.MailBindRewardRequest.Create();
			Singleton<Net>.Instance.Call<MailBindRewardResponse>(ERequestMessageId.MailBindRewardRequest, message, delegate(MailBindRewardResponse response, [Nullable(2)] Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16966, null, true, true);
					return;
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.OnMailBindRewardResponse);
			}, 0);
		}

		// Token: 0x0603A5A2 RID: 239010 RVA: 0x00ECBAA8 File Offset: 0x00EC9CA8
		[NullableContext(1)]
		private void OnMailBindInfoNotify(MailBindInfoNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			MailBindInfo mailBindInfo = message.MailBindInfo;
			if (mailBindInfo == null)
			{
				return;
			}
			ModelBase<MailBindModel>.Instance.UpdateByProtoMailBindInfo(mailBindInfo);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnMailBindInfoNotify);
		}

		// Token: 0x0603A5A3 RID: 239011 RVA: 0x00ECBADB File Offset: 0x00EC9CDB
		private void OnWorldDone()
		{
			this.MainBindInfoRequest();
		}

		// Token: 0x0603A5A4 RID: 239012 RVA: 0x00ECBAE3 File Offset: 0x00EC9CE3
		private void OnCrossDay()
		{
			if (!ModelBase<MailBindModel>.Instance.GetIsBind())
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.RefreshMailBindRedDot);
			}
		}

		// Token: 0x0603A5A5 RID: 239013 RVA: 0x00ECBB04 File Offset: 0x00EC9D04
		public void RecordMailBindNextShowRedDotTime()
		{
			double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			long? nextShowRedDotTime = ModelBase<MailBindModel>.Instance.GetNextShowRedDotTime();
			if (nextShowRedDotTime != null && serverTimeStamp < (double)nextShowRedDotTime.Value)
			{
				return;
			}
			DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)serverTimeStamp).DateTime;
			dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 4, 0, 0, DateTimeKind.Utc);
			int dayOfWeek = (int)dateTime.DayOfWeek;
			int num = (dayOfWeek < 1) ? (1 - dayOfWeek) : (7 - (dayOfWeek - 1));
			DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, TimeSpan.Zero);
			long nextShowRedDotTime2 = dateTimeOffset.ToUnixTimeMilliseconds() + (long)(num * 86400 * 1000);
			ModelBase<MailBindModel>.Instance.SetNextShowRedDotTime(nextShowRedDotTime2);
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshMailBindRedDot);
		}

		// Token: 0x0603A5A6 RID: 239014 RVA: 0x00ECBBCC File Offset: 0x00EC9DCC
		public void RecordMailBindClick()
		{
			MailBindClickEvent mailBindClickEvent = new MailBindClickEvent();
			mailBindClickEvent.i_language = Singleton<LanguageSystem>.Instance.GetLanguageDefineByCode(Singleton<LanguageSystem>.Instance.PackageLanguage).LanguageType;
			mailBindClickEvent.i_if_binded = ((ModelBase<MailBindModel>.Instance.GetIsBind() > false) ? 1 : 0);
			ControllerBase<LogReportController>.Instance.LogReport(mailBindClickEvent);
		}

		// Token: 0x0603A5A7 RID: 239015 RVA: 0x00ECBC1C File Offset: 0x00EC9E1C
		public void RecordMailBindJumpToWebView()
		{
			MailBindJumpToWebViewEvent mailBindJumpToWebViewEvent = new MailBindJumpToWebViewEvent();
			mailBindJumpToWebViewEvent.i_language = Singleton<LanguageSystem>.Instance.GetLanguageDefineByCode(Singleton<LanguageSystem>.Instance.PackageLanguage).LanguageType;
			ControllerBase<LogReportController>.Instance.LogReport(mailBindJumpToWebViewEvent);
		}
	}
}
