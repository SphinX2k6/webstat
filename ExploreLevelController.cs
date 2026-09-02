using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001B5F RID: 7007
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ExploreLevelController : UiControllerBase<ExploreLevelController>
{
	// Token: 0x0600CAE5 RID: 51941 RVA: 0x00361912 File Offset: 0x0035FB12
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ExploreLevelNotify>(ENotifyMessageId.ExploreLevelNotify, new Action<ExploreLevelNotify, Net.CallbackStatus>(this.ExploreLevelNotify));
	}

	// Token: 0x0600CAE6 RID: 51942 RVA: 0x00361930 File Offset: 0x0035FB30
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ExploreLevelNotify);
	}

	// Token: 0x0600CAE7 RID: 51943 RVA: 0x00361944 File Offset: 0x0035FB44
	private void ExploreLevelNotify(ExploreLevelNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.ExploreLevel;
		ELogAuthor author = ELogAuthor.LRX;
		string message = "服务端通知探索等级 ExploreLevelNotify";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("notify", notify);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ExploreLevelModel instance2 = ModelBase<ExploreLevelModel>.Instance;
		foreach (CountryExploreLevel countryExploreLevel in notify.CountryExploreLevel)
		{
			instance2.SetCountryExploreLevel(countryExploreLevel.CountryId, countryExploreLevel.ExploreLevel);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnExploreLevelNotify);
	}

	// Token: 0x0600CAE8 RID: 51944 RVA: 0x003619DC File Offset: 0x0035FBDC
	public void MultiExploreScoreRewardRequest(Dictionary<int, int> areaIdToProgress)
	{
		MulExploreScoreRewardRequest mulExploreScoreRewardRequest = MulExploreScoreRewardRequest.Create();
		foreach (KeyValuePair<int, int> keyValuePair in areaIdToProgress)
		{
			mulExploreScoreRewardRequest.Rewards[keyValuePair.Key] = keyValuePair.Value;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.ExploreLevel;
		ELogAuthor author = ELogAuthor.LRX;
		string message = "客户端请求请求探索进度评分奖励 ExploreScoreRewardRequest";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("request", mulExploreScoreRewardRequest);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<Net>.Instance.Call<MulExploreScoreRewardResponse>(ERequestMessageId.MulExploreScoreRewardRequest, mulExploreScoreRewardRequest, new Action<MulExploreScoreRewardResponse, Net.CallbackStatus>(this.MultiExploreScoreRewardResponse), 0);
	}

	// Token: 0x0600CAE9 RID: 51945 RVA: 0x00361A8C File Offset: 0x0035FC8C
	private void MultiExploreScoreRewardResponse(MulExploreScoreRewardResponse response, [Nullable(2)] Net.CallbackStatus _)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.ExploreLevel;
		ELogAuthor author = ELogAuthor.LRX;
		string message = "服务端返回探索评分奖励 ExploreScoreRewardResponse";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("response", response);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (response.ErrorCode != ErrorCode.Success)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnExploreScoreRewardResponse);
	}

	// Token: 0x0600CAEA RID: 51946 RVA: 0x00361ADC File Offset: 0x0035FCDC
	[NullableContext(2)]
	public void CountryExploreScoreInfoRequest(int countryId, Action onResponse = null)
	{
		ExploreLevelController.<>c__DisplayClass5_0 CS$<>8__locals1 = new ExploreLevelController.<>c__DisplayClass5_0();
		CS$<>8__locals1.onResponse = onResponse;
		CS$<>8__locals1.countryId = countryId;
		CountryExploreScoreInfoRequest countryExploreScoreInfoRequest = Aki.Protocol.CountryExploreScoreInfoRequest.Create();
		countryExploreScoreInfoRequest.CountryId = CS$<>8__locals1.countryId;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.ExploreLevel;
		ELogAuthor author = ELogAuthor.LRX;
		string message = "客户端请求国家探索评分信息 CountryExploreScoreInfoRequest";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("request", countryExploreScoreInfoRequest);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<Net>.Instance.Call<CountryExploreScoreInfoResponse>(ERequestMessageId.CountryExploreScoreInfoRequest, countryExploreScoreInfoRequest, new Action<CountryExploreScoreInfoResponse, Net.CallbackStatus>(CS$<>8__locals1.<CountryExploreScoreInfoRequest>g__CountryExploreScoreInfoResponse|0), 0);
	}

	// Token: 0x0600CAEB RID: 51947 RVA: 0x00361B58 File Offset: 0x0035FD58
	public UniTask CountryExploreScoreInfoAsyncRequest(int countryId)
	{
		ExploreLevelController.<CountryExploreScoreInfoAsyncRequest>d__6 <CountryExploreScoreInfoAsyncRequest>d__;
		<CountryExploreScoreInfoAsyncRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CountryExploreScoreInfoAsyncRequest>d__.countryId = countryId;
		<CountryExploreScoreInfoAsyncRequest>d__.<>1__state = -1;
		<CountryExploreScoreInfoAsyncRequest>d__.<>t__builder.Start<ExploreLevelController.<CountryExploreScoreInfoAsyncRequest>d__6>(ref <CountryExploreScoreInfoAsyncRequest>d__);
		return <CountryExploreScoreInfoAsyncRequest>d__.<>t__builder.Task;
	}
}
