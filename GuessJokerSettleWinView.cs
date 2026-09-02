using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Ui;

// Token: 0x02001127 RID: 4391
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerSettleWinView : GuessJokerSettleViewBase
{
	// Token: 0x060072C5 RID: 29381 RVA: 0x001DFD6B File Offset: 0x001DDF6B
	public GuessJokerSettleWinView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060072C6 RID: 29382 RVA: 0x001DFD74 File Offset: 0x001DDF74
	protected override string GetWinnerName()
	{
		return ModelBase<GuessJokerGamePlayModel>.Instance.GetPlayerNameByType(EGuessJokerPlayerType.Me);
	}

	// Token: 0x060072C7 RID: 29383 RVA: 0x001DFD81 File Offset: 0x001DDF81
	protected override EPokerStateType GetNpcPokerState()
	{
		return EPokerStateType.Lose;
	}

	// Token: 0x060072C8 RID: 29384 RVA: 0x001DFD88 File Offset: 0x001DDF88
	protected override string GetEmojiTexturePath()
	{
		int levelId = ModelBase<GuessJokerGamePlayModel>.Instance.GetLevelId();
		GuessJokerLevel? jokerLevelById = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelById(levelId);
		if (jokerLevelById == null)
		{
			return "";
		}
		int j = (ModelBase<WorldLevelModel>.Instance.Sex == 0) ? 1 : 0;
		string text = jokerLevelById.Value.WinEmojiPath(j);
		if (text == null)
		{
			return "";
		}
		return text;
	}

	// Token: 0x060072C9 RID: 29385 RVA: 0x001DFDE8 File Offset: 0x001DDFE8
	protected override string GetDescText()
	{
		int levelId = ModelBase<GuessJokerGamePlayModel>.Instance.GetLevelId();
		GuessJokerLevel? jokerLevelById = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelById(levelId);
		if (jokerLevelById == null)
		{
			return "";
		}
		Dictionary<int, string> dictionary = jokerLevelById.Value.WinText();
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

	// Token: 0x060072CA RID: 29386 RVA: 0x001DFEC4 File Offset: 0x001DE0C4
	protected override EUiViewName GetViewName()
	{
		return EUiViewName.GuessJokerSettleWinView;
	}
}
