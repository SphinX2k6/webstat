using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002427 RID: 9255
[NullableContext(1)]
[Nullable(0)]
public class PersonalCardView : UiViewBase
{
	// Token: 0x06011E61 RID: 73313 RVA: 0x004EC45A File Offset: 0x004EA65A
	public PersonalCardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011E62 RID: 73314 RVA: 0x004EC464 File Offset: 0x004EA664
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIInteractionGroup))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickCardPreviewBtn))
		};
	}

	// Token: 0x06011E63 RID: 73315 RVA: 0x004EC594 File Offset: 0x004EA794
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(7));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnClickCloseBtn));
		this.PersonalInfoData = (this.OpenParam as PersonalInfoData);
		if (this.PersonalInfoData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Personal, ELogAuthor.BB, "PersonalCardView Invalid OpenParam", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.ConfirmBtn = new ButtonItem(base.GetButton(9).RootUIComp.Get());
		this.ScrollView = new LoopScrollView<PersonalCardBaseItem, PersonalCardData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<PersonalCardBaseItem>(this.CreateCardItem), false);
		PersonalCardData[] sortedList = this.GetSortedList();
		base.GetItem(6).SetUIActive(sortedList.Length != 0);
		this.ScrollView.RefreshByData(sortedList.ToList<PersonalCardData>(), false, null, false);
		if (sortedList.Length != 0)
		{
			this.ScrollView.SelectGridProxy(0, false);
			this.CurSelectCardData = sortedList[0];
			this.RefreshCardInfo(this.CurSelectCardData);
		}
		if (this.PersonalInfoData.IsOtherData)
		{
			this.ConfirmBtn.SetUiActive(false);
			return;
		}
		this.ConfirmBtn.SetUiActive(true);
		this.RefreshConfirmBtnByCurSelectData(this.CurSelectCardData);
		this.ConfirmBtn.SetFunction(new Action<int>(this.OnClickConfirm));
	}

	// Token: 0x06011E64 RID: 73316 RVA: 0x004EC6EB File Offset: 0x004EA8EB
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnCardChange, new Action(this.OnCardChange));
	}

	// Token: 0x06011E65 RID: 73317 RVA: 0x004EC709 File Offset: 0x004EA909
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCardChange, new Action(this.OnCardChange));
	}

	// Token: 0x06011E66 RID: 73318 RVA: 0x004EC728 File Offset: 0x004EA928
	private void OnCardChange()
	{
		PersonalCardData[] sortedList = this.GetSortedList();
		this.ScrollView.RefreshByData(sortedList.ToList<PersonalCardData>(), false, null, false);
		this.ScrollView.SelectGridProxy(0, false);
		this.ScrollView.ScrollToGridIndex(0, true);
		this.RefreshConfirmBtnByCurSelectData(this.CurSelectCardData);
		ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.ScrollView.GetGridByDisplayIndex(0), true, false, false);
	}

	// Token: 0x06011E67 RID: 73319 RVA: 0x004EC790 File Offset: 0x004EA990
	private void OnClickConfirm(int _)
	{
		ControllerBase<PersonalController>.Instance.SendChangeCardRequest(this.CurSelectCardData.CardId);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.PersonalEditView, null);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.PersonalOptionView, null);
	}

	// Token: 0x06011E68 RID: 73320 RVA: 0x004EC7C7 File Offset: 0x004EA9C7
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06011E69 RID: 73321 RVA: 0x004EC7D0 File Offset: 0x004EA9D0
	private void OnClickCardPreviewBtn()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.CurSelectCardData.CardId, true, null);
	}

	// Token: 0x06011E6A RID: 73322 RVA: 0x004EC7E9 File Offset: 0x004EA9E9
	private PersonalCardItem CreateCardItem()
	{
		PersonalCardItem personalCardItem = new PersonalCardItem();
		personalCardItem.SetToggleCallBack(new Action<int, PersonalCardData>(this.OnCardItemToggleClick));
		personalCardItem.SetNeedShowRedDot(false);
		PersonalInfoData personalInfoData = this.PersonalInfoData;
		personalCardItem.SetIsOtherCardItem(personalInfoData != null && personalInfoData.IsOtherData);
		return personalCardItem;
	}

	// Token: 0x06011E6B RID: 73323 RVA: 0x004EC824 File Offset: 0x004EAA24
	private void OnCardItemToggleClick(int gridIndex, PersonalCardData cardData)
	{
		this.CurSelectCardData = cardData;
		List<PersonalCardData> cardDataList = this.PersonalInfoData.CardDataList;
		int count = cardDataList.Count;
		for (int i = 0; i < count; i++)
		{
			PersonalCardData personalCardData = cardDataList[i];
			if (personalCardData.CardId == this.CurSelectCardData.CardId && personalCardData.IsUnLock && !personalCardData.IsRead)
			{
				ControllerBase<PersonalController>.Instance.SendReadCardRequest(this.CurSelectCardData.CardId);
				break;
			}
		}
		this.ScrollView.SelectGridProxy(gridIndex, false);
		this.RefreshCardInfo(this.CurSelectCardData);
		this.RefreshConfirmBtnByCurSelectData(this.CurSelectCardData);
	}

	// Token: 0x06011E6C RID: 73324 RVA: 0x004EC8C0 File Offset: 0x004EAAC0
	protected void RefreshCardInfo(PersonalCardData cardData)
	{
		BackgroundCard value = ConfigBackgroundCardById.GetConfig(cardData.CardId, true).Value;
		base.SetTextureByPath(value.CardPath, base.GetTexture(2), null, null);
		base.GetText(3).ShowTextNew(value.Title);
		base.GetText(4).ShowTextNew(value.AttributesDescription);
		base.GetText(5).ShowTextNew(value.Tips);
	}

	// Token: 0x06011E6D RID: 73325 RVA: 0x004EC93C File Offset: 0x004EAB3C
	private void RefreshConfirmBtnByCurSelectData(PersonalCardData curSelectCardData)
	{
		int cardId = curSelectCardData.CardId;
		int? curCardId = this.PersonalInfoData.CurCardId;
		bool flag = cardId == curCardId.GetValueOrDefault() & curCardId != null;
		bool flag2 = curSelectCardData.IsUnLock && !flag;
		this.ConfirmBtn.SetEnableClick(flag2);
		base.GetInteractionGroup(10).SetInteractable(flag2);
		string textId = flag ? "Text_InUse_Text" : "ConfirmBox_173_ButtonText_1";
		this.ConfirmBtn.SetLocalTextNew(textId, Array.Empty<object>());
	}

	// Token: 0x06011E6E RID: 73326 RVA: 0x004EC9B8 File Offset: 0x004EABB8
	private PersonalCardData[] GetSortedList()
	{
		List<PersonalCardData> list = new List<PersonalCardData>(this.PersonalInfoData.GetCardList(true));
		int num = list.FindIndex(delegate(PersonalCardData data)
		{
			int cardId = data.CardId;
			int? curCardId = this.PersonalInfoData.CurCardId;
			return cardId == curCardId.GetValueOrDefault() & curCardId != null;
		});
		if (num <= 0 || num >= list.Count)
		{
			return list.ToArray();
		}
		PersonalCardData value = list[num];
		for (int i = num; i > 0; i--)
		{
			list[i] = list[i - 1];
		}
		list[0] = value;
		return list.ToArray();
	}

	// Token: 0x06011E6F RID: 73327 RVA: 0x004ECA30 File Offset: 0x004EAC30
	protected override void OnBeforeDestroy()
	{
		if (this.ScrollView != null)
		{
			this.ScrollView.ClearGridProxies();
			this.ScrollView = null;
		}
	}

	// Token: 0x04008C27 RID: 35879
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<PersonalCardBaseItem, PersonalCardData> ScrollView;

	// Token: 0x04008C28 RID: 35880
	[Nullable(2)]
	private ButtonItem ConfirmBtn;

	// Token: 0x04008C29 RID: 35881
	[Nullable(2)]
	private PersonalCardData CurSelectCardData;

	// Token: 0x04008C2A RID: 35882
	[Nullable(2)]
	private PersonalInfoData PersonalInfoData;

	// Token: 0x04008C2B RID: 35883
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;
}
