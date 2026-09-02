using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02001105 RID: 4357
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerDefine : IStaticVariableResetter
{
	// Token: 0x0600716B RID: 29035 RVA: 0x001DA67E File Offset: 0x001D887E
	static GuessJokerDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GuessJokerDefine.CreateStaticDefaultValue), new Action(GuessJokerDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600716C RID: 29036 RVA: 0x001DA6A0 File Offset: 0x001D88A0
	public static void CreateStaticDefaultValue()
	{
		GuessJokerDefine.GuessJokerCardStageTransitionMap = new Dictionary<EGuessJokerCardStateType, EGuessJokerCardStateType[]>
		{
			{
				EGuessJokerCardStateType.None,
				new EGuessJokerCardStateType[]
				{
					EGuessJokerCardStateType.GameStart
				}
			},
			{
				EGuessJokerCardStateType.GameStart,
				new EGuessJokerCardStateType[]
				{
					EGuessJokerCardStateType.DealCards,
					EGuessJokerCardStateType.GameExit
				}
			},
			{
				EGuessJokerCardStateType.DealCards,
				new EGuessJokerCardStateType[]
				{
					EGuessJokerCardStateType.FlipCoin,
					EGuessJokerCardStateType.GameExit
				}
			},
			{
				EGuessJokerCardStateType.FlipCoin,
				new EGuessJokerCardStateType[]
				{
					EGuessJokerCardStateType.RoundPlay,
					EGuessJokerCardStateType.GameExit
				}
			},
			{
				EGuessJokerCardStateType.RoundPlay,
				new EGuessJokerCardStateType[]
				{
					EGuessJokerCardStateType.SettleStage,
					EGuessJokerCardStateType.GameExit
				}
			},
			{
				EGuessJokerCardStateType.SettleStage,
				new EGuessJokerCardStateType[]
				{
					EGuessJokerCardStateType.GameStart,
					EGuessJokerCardStateType.GameExit
				}
			},
			{
				EGuessJokerCardStateType.GameExit,
				Array.Empty<EGuessJokerCardStateType>()
			}
		};
		GuessJokerDefine.GuessJokerCardPositionConfig = new Dictionary<ECardPositionType, ICardPositionConfig>
		{
			{
				ECardPositionType.Middle,
				new CardPositionConfig
				{
					PositionRate = -18f,
					Spacing = 4f,
					Size = new float?(0.8f)
				}
			},
			{
				ECardPositionType.PlayerBeDrawCard,
				new CardPositionConfig
				{
					PositionRate = -37f,
					Spacing = -50f,
					Size = new float?(0.75f)
				}
			},
			{
				ECardPositionType.PlayerHand,
				new CardPositionConfig
				{
					PositionRate = -50f,
					Spacing = -50f,
					Size = new float?(0.75f)
				}
			},
			{
				ECardPositionType.PlayerPlay,
				new CardPositionConfig
				{
					PositionRate = -50f,
					Spacing = -50f,
					Size = new float?(0.75f)
				}
			},
			{
				ECardPositionType.PlayerInitial,
				new CardPositionConfig
				{
					PositionRate = -42f,
					Spacing = -50f,
					Size = new float?(0.75f)
				}
			},
			{
				ECardPositionType.AiHand,
				new CardPositionConfig
				{
					PositionRate = -12.5f,
					Spacing = 4f,
					Size = new float?(0.42f),
					Alpha = new float?(0.45f)
				}
			},
			{
				ECardPositionType.AiBeDrawCard,
				new CardPositionConfig
				{
					PositionRate = -16f,
					Spacing = 8f,
					Size = new float?(0.71f),
					Alpha = new float?(1f)
				}
			},
			{
				ECardPositionType.AiInitial,
				new CardPositionConfig
				{
					PositionRate = -12.5f,
					Spacing = 4f,
					Size = new float?(0.42f),
					Alpha = new float?(0.45f)
				}
			}
		};
	}

	// Token: 0x0600716D RID: 29037 RVA: 0x001DA909 File Offset: 0x001D8B09
	public static void ResetStaticDefaultValue()
	{
		GuessJokerDefine.GuessJokerCardStageTransitionMap = null;
		GuessJokerDefine.GuessJokerCardPositionConfig = null;
	}

	// Token: 0x0600716E RID: 29038 RVA: 0x001DA917 File Offset: 0x001D8B17
	public static IReadOnlyDictionary<EGuessJokerCardStateType, EGuessJokerCardStateType[]> GetGuessJokerCardStageTransitionMap()
	{
		return GuessJokerDefine.GuessJokerCardStageTransitionMap;
	}

	// Token: 0x0600716F RID: 29039 RVA: 0x001DA920 File Offset: 0x001D8B20
	public static ICardPositionConfig GetCardPositionConfig(ECardPositionType cardPositionType)
	{
		ICardPositionConfig cardPositionConfig = GuessJokerDefine.GuessJokerCardPositionConfig[cardPositionType];
		return new CardPositionConfig
		{
			PositionRate = cardPositionConfig.PositionRate,
			Spacing = cardPositionConfig.Spacing,
			UpOffset = new float?(cardPositionConfig.UpOffset.GetValueOrDefault(70f)),
			Size = new float?(cardPositionConfig.Size.GetValueOrDefault(1f)),
			Alpha = new float?(cardPositionConfig.Alpha.GetValueOrDefault(1f))
		};
	}

	// Token: 0x06007170 RID: 29040 RVA: 0x001DA9B0 File Offset: 0x001D8BB0
	public static float CalculateCardScaleByIndex(int index, int totalCount)
	{
		if (totalCount <= 1)
		{
			return 1f;
		}
		bool flag = totalCount % 2 == 0;
		float num = (float)(totalCount - 1) / 2f;
		if (flag)
		{
			int num2 = (int)Math.Floor((double)num);
			int num3 = (int)Math.Ceiling((double)num);
			return (float)1;
		}
		int num4 = (int)Math.Floor((double)num);
		Math.Abs(index - num4);
		return (float)1;
	}

	// Token: 0x06007171 RID: 29041 RVA: 0x001DAA08 File Offset: 0x001D8C08
	public static float CalculateCardRotation(int index, int totalCount)
	{
		if (totalCount <= 1)
		{
			return 0f;
		}
		bool flag = totalCount % 2 == 0;
		float num = (float)(totalCount - 1) / 2f;
		if (flag)
		{
			int num2 = (int)Math.Floor((double)num);
			int num3 = (int)Math.Ceiling((double)num);
			return 0f;
		}
		int num4 = (int)Math.Floor((double)num);
		int num5 = index - num4;
		return (float)0;
	}

	// Token: 0x06007172 RID: 29042 RVA: 0x001DAA60 File Offset: 0x001D8C60
	public static string GetPokerStateName(EPokerStateType state)
	{
		Dictionary<EPokerStateType, string> dictionary = new Dictionary<EPokerStateType, string>
		{
			{
				EPokerStateType.Idel,
				"Idle"
			},
			{
				EPokerStateType.BeChosenCardStrong,
				"BeChosenCardStrong"
			},
			{
				EPokerStateType.BeChosenCardWeak,
				"BeChosenCardWeak"
			},
			{
				EPokerStateType.BeDrawnCardHappy,
				"BeDrawnCardHappy"
			},
			{
				EPokerStateType.BeDrawnCardSad,
				"BeDrawnCardSad"
			},
			{
				EPokerStateType.DrawCardNormal,
				"DrawCardNormal"
			},
			{
				EPokerStateType.DrawCardThinking,
				"DrawCardThinking"
			},
			{
				EPokerStateType.GetCardHappy,
				"GetCardHappy"
			},
			{
				EPokerStateType.GetCardSad,
				"GetCardSad"
			},
			{
				EPokerStateType.Win,
				"Win"
			},
			{
				EPokerStateType.Lose,
				"Lose"
			},
			{
				EPokerStateType.IdelPerformance,
				"IdelPerformance"
			},
			{
				EPokerStateType.EPokerStateType_MAX,
				"Unknown"
			}
		};
		string result;
		if (!dictionary.TryGetValue(state, out result))
		{
			return dictionary[EPokerStateType.EPokerStateType_MAX];
		}
		return result;
	}

	// Token: 0x06007173 RID: 29043 RVA: 0x001DAB28 File Offset: 0x001D8D28
	public static string GetPokerIdleStateName(EPokerIdleState state)
	{
		Dictionary<EPokerIdleState, string> dictionary = new Dictionary<EPokerIdleState, string>
		{
			{
				EPokerIdleState.Normal,
				"Idle_Normal"
			},
			{
				EPokerIdleState.Disadvantage,
				"Idle_Disadvantage"
			},
			{
				EPokerIdleState.Advantage,
				"Idle_Advantage"
			},
			{
				EPokerIdleState.EPokerIdleState_MAX,
				"Idle_Unknown"
			}
		};
		string result;
		if (!dictionary.TryGetValue(state, out result))
		{
			return dictionary[EPokerIdleState.EPokerIdleState_MAX];
		}
		return result;
	}

	// Token: 0x04003677 RID: 13943
	public const int GUESS_JOKER_LUHESI_SKILL_ID = 151001;

	// Token: 0x04003678 RID: 13944
	public const int GUESS_JOKER_JIABEI_SKILL_ID = 120801;

	// Token: 0x04003679 RID: 13945
	public const int GUESS_JOKER_JINXI_SKILL_ID = 130401;

	// Token: 0x0400367A RID: 13946
	public const int GUESS_JOKER_PLAYER_SKILL_ID = 100001;

	// Token: 0x0400367B RID: 13947
	public const int GUESS_JOKER_JINXI_LEVEL_ID = 1010;

	// Token: 0x0400367C RID: 13948
	public const int GUESS_JOKER_AI_CHECK_CARD_MAX_LENGTH = 3;

	// Token: 0x0400367D RID: 13949
	public const int GUESS_JOKER_AI_CHECK_CARD_MIN_LENGTH = 1;

	// Token: 0x0400367E RID: 13950
	public const int GUESS_JOKER_CARD_CHECK_ITEM_UP_OFFSET = 200;

	// Token: 0x0400367F RID: 13951
	public const float GUESS_JOKER_CARD_DISABLE_ALPHA = 0.3f;

	// Token: 0x04003680 RID: 13952
	public const int GUESS_JOKER_AI_BECHOOSE_CARD_EMOTION_COUNT = 2;

	// Token: 0x04003681 RID: 13953
	public const float GUESS_JOKER_SKILL_PROGRESS_THRESHOLD = 0.3f;

	// Token: 0x04003682 RID: 13954
	public const int GUESS_JOKER_START_CARD_SIZE = 1;

	// Token: 0x04003683 RID: 13955
	public const int GUESS_JOKER_START_CARD_SCALE_RANGE = 0;

	// Token: 0x04003684 RID: 13956
	public const int GUESS_JOKER_START_CARD_ROTATION = 0;

	// Token: 0x04003685 RID: 13957
	public const int GUESS_JOKER_START_CARD_ROTATION_RANGE = 0;

	// Token: 0x04003686 RID: 13958
	public const int GUESS_JOKER_CARD_AI_CARDS_COUNT_LIMIT = 3;

	// Token: 0x04003687 RID: 13959
	public const int GUESS_JOKER_CARD_PLAYER_CARDS_COUNT_LIMIT_ADVANTAGE = 4;

	// Token: 0x04003688 RID: 13960
	public const int GUESS_JOKER_CARD_AI_CARDS_COUNT_LIMIT_ADVANTAGE = 4;

	// Token: 0x04003689 RID: 13961
	public const int GUESS_JOKER_CARD_SHOW_TIME = 1000;

	// Token: 0x0400368A RID: 13962
	public const int GUESS_JOKER_CARD_SKILL_EXECUTE_TIME = 1500;

	// Token: 0x0400368B RID: 13963
	public const int GUESS_JOKER_CARD_WIDTH = 240;

	// Token: 0x0400368C RID: 13964
	private static Dictionary<EGuessJokerCardStateType, EGuessJokerCardStateType[]> GuessJokerCardStageTransitionMap;

	// Token: 0x0400368D RID: 13965
	private static Dictionary<ECardPositionType, ICardPositionConfig> GuessJokerCardPositionConfig;
}
