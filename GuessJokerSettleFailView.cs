using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Ui;

// Token: 0x02001124 RID: 4388
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerSettleFailView : GuessJokerSettleViewBase
{
	// Token: 0x060072AA RID: 29354 RVA: 0x001DF7BF File Offset: 0x001DD9BF
	public GuessJokerSettleFailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060072AB RID: 29355 RVA: 0x001DF7C8 File Offset: 0x001DD9C8
	protected override string GetWinnerName()
	{
		return ModelBase<GuessJokerGamePlayModel>.Instance.GetPlayerNameByType(EGuessJokerPlayerType.Ai);
	}

	// Token: 0x060072AC RID: 29356 RVA: 0x001DF7D5 File Offset: 0x001DD9D5
	protected override EPokerStateType GetNpcPokerState()
	{
		return EPokerStateType.Win;
	}

	// Token: 0x060072AD RID: 29357 RVA: 0x001DF7DC File Offset: 0x001DD9DC
	protected override string GetEmojiTexturePath()
	{
		int levelId = ModelBase<GuessJokerGamePlayModel>.Instance.GetLevelId();
		GuessJokerLevel? jokerLevelById = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelById(levelId);
		if (jokerLevelById == null)
		{
			return "";
		}
		int j = (ModelBase<WorldLevelModel>.Instance.Sex == 0) ? 1 : 0;
		string text = jokerLevelById.Value.FailEmojiPath(j);
		if (text == null)
		{
			return "";
		}
		return text;
	}

	// Token: 0x060072AE RID: 29358 RVA: 0x001DF83C File Offset: 0x001DDA3C
	protected override string GetDescText()
	{
		int levelId = ModelBase<GuessJokerGamePlayModel>.Instance.GetLevelId();
		GuessJokerLevel? jokerLevelById = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelById(levelId);
		if (jokerLevelById == null)
		{
			return "";
		}
		Dictionary<int, string> dictionary = jokerLevelById.Value.FailText();
		int roundNumber = ModelBase<GuessJokerGamePlayModel>.Instance.RoundNumber;
		int num = 0;
		string result = "";
		foreach (KeyValuePair<int, string> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			string value = keyValuePair.Value;
			if (key >= roundNumber && (num == 0 || key < num))
			{
				num = key;
				result = value;
			}
		}
		if (num == 0)
		{
			string text;
			dictionary.TryGetValue(0, out text);
			return text ?? "";
		}
		return result;
	}

	// Token: 0x060072AF RID: 29359 RVA: 0x001DF918 File Offset: 0x001DDB18
	protected override EUiViewName GetViewName()
	{
		return EUiViewName.GuessJokerSettleFailView;
	}
}
