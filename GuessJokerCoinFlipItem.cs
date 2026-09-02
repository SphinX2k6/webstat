using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200112C RID: 4396
public class GuessJokerCoinFlipItem : UiPanelBase
{
	// Token: 0x06007312 RID: 29458 RVA: 0x001E1598 File Offset: 0x001DF798
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnMaskButtonClick))
		};
	}

	// Token: 0x06007313 RID: 29459 RVA: 0x001E1644 File Offset: 0x001DF844
	public void Refresh()
	{
		EGuessJokerPlayerType firstPlayerTurn = ModelBase<GuessJokerGamePlayModel>.Instance.FirstPlayerTurn;
		int levelId = ModelBase<GuessJokerGamePlayModel>.Instance.GetLevelId();
		GuessJokerLevel? jokerLevelById = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelById(levelId);
		if (jokerLevelById == null)
		{
			return;
		}
		string coinIconPath = jokerLevelById.Value.CoinIconPath;
		string resourceId = (ModelBase<WorldLevelModel>.Instance.Sex == 1) ? "T_GhostCardFlipCoin_Boy" : "T_GhostCardFlipCoin_Girl";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		if (firstPlayerTurn == EGuessJokerPlayerType.Ai)
		{
			base.SetTextureByPath(coinIconPath, base.GetTexture(1), null, null);
			base.SetTextureByPath(coinIconPath, base.GetTexture(4), null, null);
			base.SetTextureByPath(resourcePath, base.GetTexture(3), null, null);
		}
		else
		{
			base.SetTextureByPath(resourcePath, base.GetTexture(1), null, null);
			base.SetTextureByPath(resourcePath, base.GetTexture(4), null, null);
			base.SetTextureByPath(coinIconPath, base.GetTexture(3), null, null);
		}
		string playerNameByType = ModelBase<GuessJokerGamePlayModel>.Instance.GetPlayerNameByType(firstPlayerTurn);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "GuessJoker_FirstPlayerText", new <>z__ReadOnlySingleElementList<object>(playerNameByType));
	}

	// Token: 0x06007314 RID: 29460 RVA: 0x001E1780 File Offset: 0x001DF980
	[NullableContext(1)]
	public void SetClickCallback(Action callback)
	{
		this.ClickCallback = callback;
	}

	// Token: 0x06007315 RID: 29461 RVA: 0x001E1789 File Offset: 0x001DF989
	public void SetClickEnable(bool enable)
	{
		this.ClickEnable = enable;
	}

	// Token: 0x06007316 RID: 29462 RVA: 0x001E1792 File Offset: 0x001DF992
	private void OnMaskButtonClick()
	{
		if (!this.ClickEnable)
		{
			return;
		}
		Action clickCallback = this.ClickCallback;
		if (clickCallback == null)
		{
			return;
		}
		clickCallback();
	}

	// Token: 0x0400378F RID: 14223
	[Nullable(2)]
	private Action ClickCallback;

	// Token: 0x04003790 RID: 14224
	private bool ClickEnable;

	// Token: 0x020074B6 RID: 29878
	private static class EComponentDefine
	{
		// Token: 0x040284E3 RID: 165091
		public const int MaskButton = 0;

		// Token: 0x040284E4 RID: 165092
		public const int CoinTexture = 1;

		// Token: 0x040284E5 RID: 165093
		public const int ResultText = 2;

		// Token: 0x040284E6 RID: 165094
		public const int BackCoinTexture = 3;

		// Token: 0x040284E7 RID: 165095
		public const int FrontCoinTexture = 4;
	}
}
