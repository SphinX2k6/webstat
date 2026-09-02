using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Module.UiCameraAnimation;
using CSharpScript.Game.Ui;

// Token: 0x0200111C RID: 4380
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerUtils
{
	// Token: 0x06007226 RID: 29222 RVA: 0x001DCBB7 File Offset: 0x001DADB7
	public static EGuessJokerPlayerType ServerPlayerTransToClient(JokerGuessActor playerType)
	{
		if (playerType != JokerGuessActor.Who)
		{
			return EGuessJokerPlayerType.Ai;
		}
		return EGuessJokerPlayerType.Me;
	}

	// Token: 0x06007227 RID: 29223 RVA: 0x001DCBBF File Offset: 0x001DADBF
	public static bool ServerUseSkillTransToClient(JokerGuessSkillOp useSkill)
	{
		return useSkill == JokerGuessSkillOp.Use;
	}

	// Token: 0x06007228 RID: 29224 RVA: 0x001DCBC8 File Offset: 0x001DADC8
	public static void LogCardsGlobalIndex(GuessJokerCardItem[] cardItems, string logType = "")
	{
		List<int> list = new List<int>();
		for (int i = 0; i < cardItems.Length; i++)
		{
			list.Add(cardItems[i].GetGlobalIndex());
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GuessJokerCard;
		ELogAuthor author = ELogAuthor.LRC;
		string message = string.Format("{0}: cards index", logType);
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("globalIndexList", string.Join<int>(",", list));
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06007229 RID: 29225 RVA: 0x001DCC34 File Offset: 0x001DAE34
	public static void LogCardsIdList(GuessJokerCardItem[] cardItems, string logType = "")
	{
		List<int> list = new List<int>();
		for (int i = 0; i < cardItems.Length; i++)
		{
			list.Add(cardItems[i].Data.Id);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GuessJokerCard;
		ELogAuthor author = ELogAuthor.LRC;
		string message = string.Format("{0}: cards ids", logType);
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("idList", string.Join<int>(",", list));
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600722A RID: 29226 RVA: 0x001DCCA4 File Offset: 0x001DAEA4
	public static ICardLayoutInfo[] CalculateCardLayoutInfo(int cardCount, ECardPositionType postionType)
	{
		ICardPositionConfig cardPositionConfig = GuessJokerDefine.GetCardPositionConfig(postionType);
		float spacing = cardPositionConfig.Spacing;
		float valueOrDefault = cardPositionConfig.Size.GetValueOrDefault(1f);
		float valueOrDefault2 = cardPositionConfig.Alpha.GetValueOrDefault(1f);
		float height = Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
		float y = cardPositionConfig.PositionRate * height / 100f;
		List<CardLayoutInfo> list = new List<CardLayoutInfo>();
		List<float> list2 = new List<float>();
		List<float> list3 = new List<float>();
		float num = 0f;
		for (int i = 0; i < cardCount; i++)
		{
			float num2 = GuessJokerDefine.CalculateCardScaleByIndex(i, cardCount);
			float num3 = valueOrDefault * num2;
			list2.Add(num3);
			float item = GuessJokerDefine.CalculateCardRotation(i, cardCount);
			list3.Add(item);
			float num4 = 240f * num3;
			if (i == 0)
			{
				num += num4;
			}
			else
			{
				num += spacing + num4;
			}
		}
		float num5 = -num / 2f;
		for (int j = 0; j < cardCount; j++)
		{
			float num6 = 240f * list2[j];
			if (j == 0)
			{
				num5 += num6 / 2f;
			}
			else
			{
				num5 += spacing + num6 / 2f;
			}
			list.Add(new CardLayoutInfo
			{
				X = num5,
				Y = y,
				Scale = list2[j],
				Rotation = list3[j],
				Alpha = valueOrDefault2
			});
			num5 += num6 / 2f;
		}
		return list.ToArray();
	}

	// Token: 0x0600722B RID: 29227 RVA: 0x001DCE2C File Offset: 0x001DB02C
	public static GuessJokerPlotConfig? GetPlotConfig(EGuessJokerPlayerType playerType, EGuessJokerPlotTiming timing, int? extraParam = null)
	{
		GuessJokerAIPlotConfig? jokerAiPlotConfig = ConfigBase<GuessJokerConfig>.Instance.GetJokerAiPlotConfig(playerType, timing, extraParam.GetValueOrDefault());
		if (jokerAiPlotConfig == null)
		{
			return null;
		}
		int[] plotIdListArray = jokerAiPlotConfig.Value.GetPlotIdListArray();
		List<int> list = new List<int>();
		foreach (int item in plotIdListArray)
		{
			list.Add(item);
		}
		if (list.Count == 0)
		{
			return null;
		}
		int id = jokerAiPlotConfig.Value.Id;
		int? lastUsedPlotId = ModelBase<GuessJokerGamePlayModel>.Instance.GetLastUsedPlotId(id);
		List<int> list2 = list;
		if (lastUsedPlotId != null && list.Count > 1)
		{
			List<int> list3 = new List<int>();
			for (int j = 0; j < list.Count; j++)
			{
				int num = list[j];
				if (num != lastUsedPlotId.Value)
				{
					list3.Add(num);
				}
			}
			list2 = list3;
		}
		if (list2.Count == 0)
		{
			list2 = list;
		}
		int index = new Random().Next(list2.Count);
		int plotId = list2[index];
		return ConfigBase<GuessJokerConfig>.Instance.GetJokerPlotConfig(plotId);
	}

	// Token: 0x0600722C RID: 29228 RVA: 0x001DCF54 File Offset: 0x001DB154
	public static EPokerStateType CalculateNpcState(ENpcPokerChangeTimingType changeTiming, int relatedCardId = 0)
	{
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		if (instance == null)
		{
			return EPokerStateType.Idel;
		}
		List<GuessJokerCardData> handCardsByPlayer = instance.GetHandCardsByPlayer(EGuessJokerPlayerType.Ai);
		int count = handCardsByPlayer.Count;
		int count2 = instance.GetHandCardsByPlayer(EGuessJokerPlayerType.Me).Count;
		bool flag = false;
		for (int i = 0; i < handCardsByPlayer.Count; i++)
		{
			if (handCardsByPlayer[i].Type == EGuessJokerCardType.Joker)
			{
				flag = true;
				break;
			}
		}
		bool flag2 = false;
		if (relatedCardId > 0)
		{
			GuessJokerCardData cardDataById = instance.GetCardDataById(relatedCardId);
			if (cardDataById != null)
			{
				flag2 = (cardDataById.Type == EGuessJokerCardType.Joker);
			}
		}
		EPokerStateType result;
		switch (changeTiming)
		{
		case ENpcPokerChangeTimingType.BeChooseCard:
			if (count > GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerBeChooseAiCardCount.ToString()))
			{
				result = EPokerStateType.BeChosenCardWeak;
			}
			else
			{
				result = EPokerStateType.BeChosenCardStrong;
			}
			break;
		case ENpcPokerChangeTimingType.BeDrawCard:
			if (count == 0)
			{
				result = EPokerStateType.BeDrawnCardHappy;
			}
			else if (flag2)
			{
				result = EPokerStateType.BeDrawnCardHappy;
			}
			else if (count <= GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerBeDrawAiCardCount.ToString()))
			{
				if (flag)
				{
					result = EPokerStateType.BeDrawnCardSad;
				}
				else
				{
					result = EPokerStateType.Idel;
				}
			}
			else
			{
				result = EPokerStateType.Idel;
			}
			break;
		case ENpcPokerChangeTimingType.ChooseCard:
			if (count > GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerDrawAiCardCount.ToString()))
			{
				result = EPokerStateType.DrawCardNormal;
			}
			else
			{
				result = EPokerStateType.DrawCardThinking;
			}
			break;
		case ENpcPokerChangeTimingType.DrawCard:
			if (count2 == 0)
			{
				result = EPokerStateType.GetCardSad;
			}
			else if (flag2)
			{
				result = EPokerStateType.GetCardSad;
			}
			else if (count2 <= GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerDrawAiCardCount.ToString()))
			{
				result = EPokerStateType.GetCardHappy;
			}
			else
			{
				result = EPokerStateType.Idel;
			}
			break;
		default:
			result = EPokerStateType.Idel;
			break;
		}
		return result;
	}

	// Token: 0x0600722D RID: 29229 RVA: 0x001DD0BC File Offset: 0x001DB2BC
	public static EGuessJokerPlotTiming GetPlayerGetCardState(int relatedCardId)
	{
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		if (instance == null)
		{
			return EGuessJokerPlotTiming.GetCardNormal;
		}
		int count = instance.GetHandCardsByPlayer(EGuessJokerPlayerType.Me).Count;
		bool count2 = instance.GetHandCardsByPlayer(EGuessJokerPlayerType.Ai).Count != 0;
		bool flag = false;
		if (relatedCardId > 0)
		{
			GuessJokerCardData cardDataById = instance.GetCardDataById(relatedCardId);
			if (cardDataById != null)
			{
				flag = (cardDataById.Type == EGuessJokerCardType.Joker);
			}
		}
		if (!count2)
		{
			return EGuessJokerPlotTiming.GetCardSad;
		}
		if (flag)
		{
			return EGuessJokerPlotTiming.GetCardSad;
		}
		if (count <= GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerBeDrawPlayerCardCount.ToString()))
		{
			return EGuessJokerPlotTiming.GetCardHappy;
		}
		return EGuessJokerPlotTiming.GetCardNormal;
	}

	// Token: 0x0600722E RID: 29230 RVA: 0x001DD133 File Offset: 0x001DB333
	public static EGuessJokerPlayerType GetOtherPlayerType(EGuessJokerPlayerType playerType)
	{
		if (playerType != EGuessJokerPlayerType.Ai)
		{
			return EGuessJokerPlayerType.Ai;
		}
		return EGuessJokerPlayerType.Me;
	}

	// Token: 0x0600722F RID: 29231 RVA: 0x001DD13C File Offset: 0x001DB33C
	[NullableContext(2)]
	public static string GetCameraNameByCameraId(int cameraId)
	{
		UiCameraMapping? uiCameraMappingConfigById = ConfigBase<UiCameraAnimationConfig>.Instance.GetUiCameraMappingConfigById(cameraId);
		if (uiCameraMappingConfigById == null)
		{
			return null;
		}
		return uiCameraMappingConfigById.Value.ViewName;
	}

	// Token: 0x06007230 RID: 29232 RVA: 0x001DD170 File Offset: 0x001DB370
	[NullableContext(2)]
	public static string GetCameraSettingNameByCameraId(int cameraId)
	{
		UiCameraMapping? uiCameraMappingConfigById = ConfigBase<UiCameraAnimationConfig>.Instance.GetUiCameraMappingConfigById(cameraId);
		if (uiCameraMappingConfigById == null)
		{
			return null;
		}
		return uiCameraMappingConfigById.Value.DefaultUiCameraSettingsName;
	}

	// Token: 0x06007231 RID: 29233 RVA: 0x001DD1A4 File Offset: 0x001DB3A4
	public static int GetJokerParamConfig(string key)
	{
		GuessJokerParam? jokerParam = ConfigBase<GuessJokerConfig>.Instance.GetJokerParam(key);
		if (jokerParam == null)
		{
			return 0;
		}
		return jokerParam.Value.Value;
	}
}
