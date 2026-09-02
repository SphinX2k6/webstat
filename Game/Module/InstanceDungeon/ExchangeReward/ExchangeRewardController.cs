using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.ExchangeReward
{
	// Token: 0x02005BFE RID: 23550
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ExchangeRewardController : ControllerBase<ExchangeRewardController>
	{
		// Token: 0x0603B962 RID: 244066 RVA: 0x00F1AFEC File Offset: 0x00F191EC
		protected override bool OnInit()
		{
			this.OnAddEvents();
			this.OnRegisterNetEvent();
			return true;
		}

		// Token: 0x0603B963 RID: 244067 RVA: 0x00F1AFFB File Offset: 0x00F191FB
		protected override bool OnClear()
		{
			this.OnRemoveEvents();
			this.OnUnRegisterNetEvent();
			return true;
		}

		// Token: 0x0603B964 RID: 244068 RVA: 0x00F1B00A File Offset: 0x00F1920A
		protected void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		}

		// Token: 0x0603B965 RID: 244069 RVA: 0x00F1B028 File Offset: 0x00F19228
		protected void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		}

		// Token: 0x0603B966 RID: 244070 RVA: 0x00F1B046 File Offset: 0x00F19246
		protected void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<ExchangeRewardInfoNotify>(ENotifyMessageId.ExchangeRewardInfoNotify, new Action<ExchangeRewardInfoNotify, Net.CallbackStatus>(this.OnExchangeRewardInfoNotify));
			Singleton<Net>.Instance.Register<ExchangeSharedInfoNotify>(ENotifyMessageId.ExchangeSharedInfoNotify, new Action<ExchangeSharedInfoNotify, Net.CallbackStatus>(this.OnExchangeSharedInfoNotify));
		}

		// Token: 0x0603B967 RID: 244071 RVA: 0x00F1B080 File Offset: 0x00F19280
		protected void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ExchangeRewardInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ExchangeSharedInfoNotify);
		}

		// Token: 0x0603B968 RID: 244072 RVA: 0x00F1B0A2 File Offset: 0x00F192A2
		private void OnExchangeRewardInfoNotify(ExchangeRewardInfoNotify message, Net.CallbackStatus callbackStatus)
		{
			ModelBase<ExchangeRewardModel>.Instance.OnExchangeRewardNotify(message);
		}

		// Token: 0x0603B969 RID: 244073 RVA: 0x00F1B0AF File Offset: 0x00F192AF
		private void OnExchangeSharedInfoNotify(ExchangeSharedInfoNotify message, Net.CallbackStatus callbackStatus)
		{
			ModelBase<ExchangeRewardModel>.Instance.OnShareInfoNotify(message);
		}

		// Token: 0x0603B96A RID: 244074 RVA: 0x00F1B0BC File Offset: 0x00F192BC
		private void OnLoadingNetDataDone()
		{
			this.RequestExchangeData().Forget();
		}

		// Token: 0x0603B96B RID: 244075 RVA: 0x00F1B0CC File Offset: 0x00F192CC
		public UniTask RequestExchangeData()
		{
			ExchangeRewardController.<RequestExchangeData>d__9 <RequestExchangeData>d__;
			<RequestExchangeData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestExchangeData>d__.<>1__state = -1;
			<RequestExchangeData>d__.<>t__builder.Start<ExchangeRewardController.<RequestExchangeData>d__9>(ref <RequestExchangeData>d__);
			return <RequestExchangeData>d__.<>t__builder.Task;
		}
	}
}
