using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x02001104 RID: 4356
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GuessJokerController : UiControllerBase<GuessJokerController>
{
	// Token: 0x06007163 RID: 29027 RVA: 0x001DA420 File Offset: 0x001D8620
	public void RequestJokerGuessStartNew(int levelId, Action sucCallback = null)
	{
		JokerGuessStartNewRequest jokerGuessStartNewRequest = JokerGuessStartNewRequest.Create();
		jokerGuessStartNewRequest.LevelId = levelId;
		string serverTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp().ToString();
		jokerGuessStartNewRequest.TraceId = serverTime;
		Singleton<Net>.Instance.Call<JokerGuessStartNewResponse>(ERequestMessageId.JokerGuessStartNewRequest, jokerGuessStartNewRequest, delegate(JokerGuessStartNewResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19103, null, true, true);
				return;
			}
			ModelBase<GuessJokerGamePlayModel>.Instance.EnterGame(response.InitData, levelId, serverTime);
			ModelBase<GuessJokerGamePlayModel>.Instance.UpdateTaskData(response.Cmd);
			Action sucCallback2 = sucCallback;
			if (sucCallback2 == null)
			{
				return;
			}
			sucCallback2();
		}, 0);
	}

	// Token: 0x06007164 RID: 29028 RVA: 0x001DA494 File Offset: 0x001D8694
	public void RequestJokerGuessRematch(int levelId, Action sucCallback = null)
	{
		GuessJokerController.<>c__DisplayClass1_0 CS$<>8__locals1 = new GuessJokerController.<>c__DisplayClass1_0();
		CS$<>8__locals1.levelId = levelId;
		CS$<>8__locals1.sucCallback = sucCallback;
		JokerGuessStartNewRequest jokerGuessStartNewRequest = JokerGuessStartNewRequest.Create();
		jokerGuessStartNewRequest.LevelId = CS$<>8__locals1.levelId;
		CS$<>8__locals1.serverTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp().ToString();
		jokerGuessStartNewRequest.TraceId = CS$<>8__locals1.serverTime;
		Singleton<Net>.Instance.Call<JokerGuessStartNewResponse>(ERequestMessageId.JokerGuessStartNewRequest, jokerGuessStartNewRequest, delegate(JokerGuessStartNewResponse response, Net.CallbackStatus _)
		{
			GuessJokerController.<>c__DisplayClass1_1 CS$<>8__locals2 = new GuessJokerController.<>c__DisplayClass1_1();
			CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
			CS$<>8__locals2.response = response;
			if (CS$<>8__locals2.response == null)
			{
				return;
			}
			if (CS$<>8__locals2.response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(CS$<>8__locals2.response.ErrorCode, 19103, null, true, true);
				return;
			}
			CS$<>8__locals2.<RequestJokerGuessRematch>g__DoRematch|1().Forget();
		}, 0);
	}

	// Token: 0x06007165 RID: 29029 RVA: 0x001DA508 File Offset: 0x001D8708
	[NullableContext(1)]
	public void RequestJokerGuessPlayCard(IEnumerable<int> cardIdList, [Nullable(2)] Action callback = null)
	{
		JokerGuessPlayCardRequest jokerGuessPlayCardRequest = JokerGuessPlayCardRequest.Create();
		JokerGuessCard jokerGuessCard = new JokerGuessCard();
		jokerGuessCard.CardIds.AddRange(cardIdList);
		jokerGuessPlayCardRequest.PlayCard = jokerGuessCard;
		Singleton<Net>.Instance.Call<JokerGuessPlayCardResponse>(ERequestMessageId.JokerGuessPlayCardRequest, jokerGuessPlayCardRequest, delegate(JokerGuessPlayCardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16965, null, true, true);
				return;
			}
			ModelBase<GuessJokerGamePlayModel>.Instance.UpdateTaskData(response.Cmd);
			Action callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2();
		}, 0);
	}

	// Token: 0x06007166 RID: 29030 RVA: 0x001DA560 File Offset: 0x001D8760
	public void RequestJokerGuessDrawCard(int cardId, Action<int> callback = null)
	{
		JokerGuessDrawCardRequest jokerGuessDrawCardRequest = JokerGuessDrawCardRequest.Create();
		jokerGuessDrawCardRequest.TargetCardId = cardId;
		Singleton<Net>.Instance.Call<JokerGuessDrawCardResponse>(ERequestMessageId.JokerGuessDrawCardRequest, jokerGuessDrawCardRequest, delegate(JokerGuessDrawCardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29317, null, true, true);
				return;
			}
			ModelBase<GuessJokerGamePlayModel>.Instance.UpdateTaskData(response.Cmd);
			int drawCardResult = response.DrawCardResult;
			Action<int> callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2(drawCardResult);
		}, 0);
	}

	// Token: 0x06007167 RID: 29031 RVA: 0x001DA5A4 File Offset: 0x001D87A4
	public void JokerGuessUseSkillRequest(int skillId, bool isUse, Action callback = null)
	{
		JokerGuessUseSkillRequest jokerGuessUseSkillRequest = Aki.Protocol.JokerGuessUseSkillRequest.Create();
		jokerGuessUseSkillRequest.SkillId = skillId;
		jokerGuessUseSkillRequest.Op = ((!isUse) ? JokerGuessSkillOp.GiveUp : JokerGuessSkillOp.Use);
		Singleton<Net>.Instance.Call<JokerGuessUseSkillResponse>(ERequestMessageId.JokerGuessUseSkillRequest, jokerGuessUseSkillRequest, delegate(JokerGuessUseSkillResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23175, null, true, true);
				return;
			}
			ModelBase<GuessJokerGamePlayModel>.Instance.UpdateTaskData(response.Cmd);
			Action callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2();
		}, 0);
	}

	// Token: 0x06007168 RID: 29032 RVA: 0x001DA5F4 File Offset: 0x001D87F4
	public void JokerGuessRewardRequest(int levelId, Action callback = null)
	{
		JokerGuessRewardRequest jokerGuessRewardRequest = Aki.Protocol.JokerGuessRewardRequest.Create();
		jokerGuessRewardRequest.LevelId = levelId;
		Singleton<Net>.Instance.Call<JokerGuessRewardResponse>(ERequestMessageId.JokerGuessRewardRequest, jokerGuessRewardRequest, delegate(JokerGuessRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27046, null, true, true);
				return;
			}
			SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			activityData.UpdateLevelGetReward(levelId);
			Action callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2();
		}, 0);
	}

	// Token: 0x06007169 RID: 29033 RVA: 0x001DA644 File Offset: 0x001D8844
	[NullableContext(1)]
	public void OpenGuessJokerFloatTipsView(string textId, [Nullable(new byte[]
	{
		2,
		1
	})] string[] textParam = null)
	{
		GuessJokerTipsData param = new GuessJokerTipsData
		{
			TextId = textId,
			TextParam = textParam
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GuessJokerFloatTipsView, param, null);
	}
}
