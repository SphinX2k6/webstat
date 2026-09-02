using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001131 RID: 4401
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerPositionPanelBase
{
	// Token: 0x06007337 RID: 29495 RVA: 0x001E21F5 File Offset: 0x001E03F5
	public GuessJokerPositionPanelBase(ECardPositionType position, GuessJokerGamePlayView gamePlayView)
	{
		this.Position = position;
		this.GamePlayView = gamePlayView;
	}

	// Token: 0x06007338 RID: 29496 RVA: 0x001E2224 File Offset: 0x001E0424
	private void AddCardByItem(GuessJokerCardItem cardItem)
	{
		if (this.CheckCardExist(cardItem.Data.Id))
		{
			return;
		}
		cardItem.SetPositionType(this.Position);
		this.CardItemList.Add(cardItem);
		this.CardIdMap[cardItem.Data.Id] = cardItem;
	}

	// Token: 0x06007339 RID: 29497 RVA: 0x001E2274 File Offset: 0x001E0474
	[NullableContext(2)]
	public GuessJokerCardItem GetCardItemByCardId(int cardId)
	{
		GuessJokerCardItem result;
		if (!this.CardIdMap.TryGetValue(cardId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600733A RID: 29498 RVA: 0x001E2294 File Offset: 0x001E0494
	public bool CheckCardExist(int cardId)
	{
		return this.CardIdMap.ContainsKey(cardId);
	}

	// Token: 0x0600733B RID: 29499 RVA: 0x001E22A4 File Offset: 0x001E04A4
	public void InitCardByItemList(List<GuessJokerCardItem> cardList)
	{
		for (int i = 0; i < cardList.Count; i++)
		{
			GuessJokerCardItem cardItem = cardList[i];
			this.AddCardByItem(cardItem);
		}
		this.UpdateCardItemsPosition();
		this.UpdateCardItemsIndexInPanel();
		for (int j = 0; j < cardList.Count; j++)
		{
			cardList[j].Show(null);
		}
	}

	// Token: 0x0600733C RID: 29500 RVA: 0x001E22FC File Offset: 0x001E04FC
	public void AddCardByItemList(List<GuessJokerCardItem> cardList)
	{
		for (int i = 0; i < cardList.Count; i++)
		{
			this.AddCardByItem(cardList[i]);
		}
		this.UpdateCardItemsIndexInPanel();
	}

	// Token: 0x0600733D RID: 29501 RVA: 0x001E2330 File Offset: 0x001E0530
	[NullableContext(2)]
	public GuessJokerCardItem RemoveCardByCardId(int cardId)
	{
		GuessJokerCardItem cardItemByCardId = this.GetCardItemByCardId(cardId);
		if (cardItemByCardId != null)
		{
			int index = this.CardItemList.IndexOf(cardItemByCardId);
			this.CardItemList.RemoveAt(index);
			this.CardIdMap.Remove(cardId);
			return cardItemByCardId;
		}
		return null;
	}

	// Token: 0x0600733E RID: 29502 RVA: 0x001E2374 File Offset: 0x001E0574
	public void DealCards(List<GuessJokerCardItem> cardList, Action finishCallback, int dealInterval = 150)
	{
		GuessJokerPositionPanelBase.<>c__DisplayClass11_0 CS$<>8__locals1 = new GuessJokerPositionPanelBase.<>c__DisplayClass11_0();
		CS$<>8__locals1.finishCallback = finishCallback;
		CS$<>8__locals1.cardList = cardList;
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.dealInterval = dealInterval;
		if (CS$<>8__locals1.cardList.Count == 0)
		{
			CS$<>8__locals1.finishCallback();
			return;
		}
		CS$<>8__locals1.currentIndex = 0;
		CS$<>8__locals1.pendingAnimations = 0;
		CS$<>8__locals1.allDealt = false;
		CS$<>8__locals1.<DealCards>g__DealNext|1();
	}

	// Token: 0x0600733F RID: 29503 RVA: 0x001E23D8 File Offset: 0x001E05D8
	[NullableContext(2)]
	public void AnimateCardsToPosition(Action onComplete = null)
	{
		List<GuessJokerCardItem> cardItemList = this.CardItemList;
		if (cardItemList.Count != 0)
		{
			ICardLayoutInfo[] array = GuessJokerUtils.CalculateCardLayoutInfo(cardItemList.Count, this.Position);
			bool[] completedFlags = new bool[cardItemList.Count];
			for (int i = 0; i < cardItemList.Count; i++)
			{
				completedFlags[i] = false;
			}
			for (int j = 0; j < cardItemList.Count; j++)
			{
				GuessJokerCardItem guessJokerCardItem = cardItemList[j];
				ICardLayoutInfo cardLayoutInfo = array[j];
				Vector2D targetPosition = new Vector2D((double)cardLayoutInfo.X, (double)cardLayoutInfo.Y);
				int index = j;
				guessJokerCardItem.SmoothMoveTo(targetPosition, delegate
				{
					completedFlags[index] = true;
					bool flag = true;
					for (int k = 0; k < completedFlags.Length; k++)
					{
						if (!completedFlags[k])
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						Action onComplete3 = onComplete;
						if (onComplete3 == null)
						{
							return;
						}
						onComplete3();
					}
				}, new float?(cardLayoutInfo.Scale), new float?(cardLayoutInfo.Rotation), -1f);
			}
			return;
		}
		Action onComplete2 = onComplete;
		if (onComplete2 == null)
		{
			return;
		}
		onComplete2();
	}

	// Token: 0x06007340 RID: 29504 RVA: 0x001E24D4 File Offset: 0x001E06D4
	public void ShuffleCards()
	{
		Random random = new Random();
		for (int i = this.CardItemList.Count - 1; i > 0; i--)
		{
			int index = random.Next(i + 1);
			GuessJokerCardItem value = this.CardItemList[i];
			this.CardItemList[i] = this.CardItemList[index];
			this.CardItemList[index] = value;
		}
		this.UpdateCardItemsIndexInPanel();
	}

	// Token: 0x06007341 RID: 29505 RVA: 0x001E2544 File Offset: 0x001E0744
	public void ShuffleCardsWithAnimation(Action finishCallback)
	{
		GuessJokerPositionPanelBase.<>c__DisplayClass14_0 CS$<>8__locals1 = new GuessJokerPositionPanelBase.<>c__DisplayClass14_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.finishCallback = finishCallback;
		if (this.CardItemList.Count <= 1)
		{
			CS$<>8__locals1.finishCallback();
			return;
		}
		ICardPositionConfig cardPositionConfig = GuessJokerDefine.GetCardPositionConfig(this.Position);
		float height = Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
		float num = cardPositionConfig.PositionRate * height / 100f;
		Vector2D targetPosition = new Vector2D(0.0, (double)num);
		GuessJokerCardItem guessJokerCardItem = this.CardItemList[0];
		GuessJokerPositionPanelBase.<>c__DisplayClass14_0 CS$<>8__locals2 = CS$<>8__locals1;
		GuessJokerCardData data = guessJokerCardItem.Data;
		bool isPlayerWash;
		if (data == null)
		{
			isPlayerWash = false;
		}
		else
		{
			EGuessJokerPlayerType? belongPlayerType = data.GetBelongPlayerType();
			EGuessJokerPlayerType eguessJokerPlayerType = EGuessJokerPlayerType.Me;
			isPlayerWash = (belongPlayerType.GetValueOrDefault() == eguessJokerPlayerType & belongPlayerType != null);
		}
		CS$<>8__locals2.isPlayerWash = isPlayerWash;
		CS$<>8__locals1.gatherCompleted = 0;
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_springfestival_ghostcard_card_shuffle");
		for (int i = 0; i < this.CardItemList.Count; i++)
		{
			GuessJokerCardItem guessJokerCardItem2 = this.CardItemList[i];
			if (CS$<>8__locals1.isPlayerWash)
			{
				guessJokerCardItem2.CardFlip(false, true);
			}
			guessJokerCardItem2.SmoothMoveTo(targetPosition, new Action(CS$<>8__locals1.<ShuffleCardsWithAnimation>g__OnGatherComplete|0), new float?(cardPositionConfig.Size.GetValueOrDefault(1f)), null, -1f);
		}
	}

	// Token: 0x06007342 RID: 29506 RVA: 0x001E268C File Offset: 0x001E088C
	public void ShowCardPairNotice(Action finishCallback)
	{
		GuessJokerPositionPanelBase.<>c__DisplayClass15_0 CS$<>8__locals1 = new GuessJokerPositionPanelBase.<>c__DisplayClass15_0();
		CS$<>8__locals1.finishCallback = finishCallback;
		CS$<>8__locals1.totalCount = this.CardItemList.Count;
		if (CS$<>8__locals1.totalCount != 0)
		{
			CS$<>8__locals1.done = 0;
			for (int i = 0; i < this.CardItemList.Count; i++)
			{
				this.CardItemList[i].PlayCardSequence("PairNotice", new Action(CS$<>8__locals1.<ShowCardPairNotice>g__TryFinish|0));
			}
			return;
		}
		Action finishCallback2 = CS$<>8__locals1.finishCallback;
		if (finishCallback2 == null)
		{
			return;
		}
		finishCallback2();
	}

	// Token: 0x06007343 RID: 29507 RVA: 0x001E2710 File Offset: 0x001E0910
	public void RemoveCards(Action finishCallback)
	{
		GuessJokerPositionPanelBase.<>c__DisplayClass16_0 CS$<>8__locals1 = new GuessJokerPositionPanelBase.<>c__DisplayClass16_0();
		CS$<>8__locals1.finishCallback = finishCallback;
		CS$<>8__locals1.totalCount = this.CardItemList.Count;
		if (CS$<>8__locals1.totalCount != 0)
		{
			CS$<>8__locals1.done = 0;
			List<int> list = new List<int>();
			for (int i = 0; i < this.CardItemList.Count; i++)
			{
				list.Add(this.CardItemList[i].Data.Id);
			}
			for (int j = 0; j < this.CardItemList.Count; j++)
			{
				GuessJokerCardItem card = this.CardItemList[j];
				card.PlayCardSequence("Dissolve", delegate
				{
					CS$<>8__locals1.<RemoveCards>g__TryFinish|0();
					card.Destroy(null);
				});
			}
			ModelBase<GuessJokerGamePlayModel>.Instance.RemoveCardData(list.ToArray());
			this.CardItemList.Clear();
			return;
		}
		Action finishCallback2 = CS$<>8__locals1.finishCallback;
		if (finishCallback2 == null)
		{
			return;
		}
		finishCallback2();
	}

	// Token: 0x06007344 RID: 29508 RVA: 0x001E2804 File Offset: 0x001E0A04
	public List<int> GetCardIdList()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < this.CardItemList.Count; i++)
		{
			list.Add(this.CardItemList[i].Data.Id);
		}
		return list;
	}

	// Token: 0x06007345 RID: 29509 RVA: 0x001E284C File Offset: 0x001E0A4C
	public void UpdateCardItemsPosition()
	{
		ICardLayoutInfo[] array = GuessJokerUtils.CalculateCardLayoutInfo(this.CardItemList.Count, this.Position);
		for (int i = 0; i < this.CardItemList.Count; i++)
		{
			GuessJokerCardItem guessJokerCardItem = this.CardItemList[i];
			ICardLayoutInfo cardLayoutInfo = array[i];
			guessJokerCardItem.SetAlpha(cardLayoutInfo.Alpha);
			Vector2D position = new Vector2D((double)cardLayoutInfo.X, (double)cardLayoutInfo.Y);
			guessJokerCardItem.SetPosition(position);
			guessJokerCardItem.SetSize(cardLayoutInfo.Scale);
			guessJokerCardItem.SetRotation(cardLayoutInfo.Rotation);
		}
	}

	// Token: 0x06007346 RID: 29510 RVA: 0x001E28D4 File Offset: 0x001E0AD4
	public void UpdateCardItemsIndexInPanel()
	{
		for (int i = 0; i < this.CardItemList.Count; i++)
		{
			this.CardItemList[i].SetIndexInPanel(i);
		}
	}

	// Token: 0x06007347 RID: 29511 RVA: 0x001E290C File Offset: 0x001E0B0C
	public void SetCardsClickableExcept(bool isClickable, int excludeCardId = 0)
	{
		for (int i = 0; i < this.CardItemList.Count; i++)
		{
			GuessJokerCardItem guessJokerCardItem = this.CardItemList[i];
			GuessJokerCardData data = guessJokerCardItem.Data;
			if (data == null || data.Id != excludeCardId)
			{
				guessJokerCardItem.SetClickEnable(isClickable);
			}
		}
		if (isClickable)
		{
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
		}
	}

	// Token: 0x06007348 RID: 29512 RVA: 0x001E296C File Offset: 0x001E0B6C
	public void SetCardsDarkExcept(bool isDark, List<int> excludeCardIdList = null)
	{
		if (excludeCardIdList == null)
		{
			excludeCardIdList = new List<int>();
		}
		for (int i = 0; i < this.CardItemList.Count; i++)
		{
			GuessJokerCardItem guessJokerCardItem = this.CardItemList[i];
			if (!excludeCardIdList.Contains(guessJokerCardItem.Data.Id))
			{
				guessJokerCardItem.SetDark(isDark);
			}
		}
	}

	// Token: 0x06007349 RID: 29513 RVA: 0x001E29C0 File Offset: 0x001E0BC0
	public void SwapCardPositionsSilently(int cardId1, int cardId2)
	{
		GuessJokerCardItem cardItemByCardId = this.GetCardItemByCardId(cardId1);
		GuessJokerCardItem cardItemByCardId2 = this.GetCardItemByCardId(cardId2);
		if (cardItemByCardId == null || cardItemByCardId2 == null)
		{
			return;
		}
		GuessJokerCardData cardDataById = ModelBase<GuessJokerGamePlayModel>.Instance.GetCardDataById(cardId2);
		GuessJokerCardData cardDataById2 = ModelBase<GuessJokerGamePlayModel>.Instance.GetCardDataById(cardId1);
		if (cardDataById == null || cardDataById2 == null)
		{
			return;
		}
		cardItemByCardId.UpdateCardData(cardDataById);
		cardItemByCardId2.UpdateCardData(cardDataById2);
		this.CardIdMap[cardId2] = cardItemByCardId;
		this.CardIdMap[cardId1] = cardItemByCardId2;
		this.GamePlayView.SwapCardItemMap(cardId1, cardId2);
		cardItemByCardId.RefreshCardItem();
		cardItemByCardId2.RefreshCardItem();
	}

	// Token: 0x040037A4 RID: 14244
	public readonly List<GuessJokerCardItem> CardItemList = new List<GuessJokerCardItem>();

	// Token: 0x040037A5 RID: 14245
	private readonly Dictionary<int, GuessJokerCardItem> CardIdMap = new Dictionary<int, GuessJokerCardItem>();

	// Token: 0x040037A6 RID: 14246
	public readonly ECardPositionType Position;

	// Token: 0x040037A7 RID: 14247
	private readonly GuessJokerGamePlayView GamePlayView;
}
