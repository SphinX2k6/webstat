using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002421 RID: 9249
[NullableContext(1)]
[Nullable(0)]
public class PersonalCardComponent : UiPanelBase
{
	// Token: 0x06011E40 RID: 73280 RVA: 0x004EBB55 File Offset: 0x004E9D55
	public PersonalCardComponent([Nullable(2)] UUIItem uiItem, bool isPreview, PersonalInfoData personalInfoData)
	{
		this.IsPreview = isPreview;
		this.PersonalInfoData = personalInfoData;
		if (uiItem != null)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}
	}

	// Token: 0x06011E41 RID: 73281 RVA: 0x004EBB7C File Offset: 0x004E9D7C
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
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent))
		};
		if (!this.IsPreview)
		{
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickCardPreviewBtn))
			};
		}
	}

	// Token: 0x06011E42 RID: 73282 RVA: 0x004EBC6F File Offset: 0x004E9E6F
	protected override void OnStart()
	{
		this.ScrollView = new LoopScrollView<PersonalCardBaseItem, PersonalCardData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<PersonalCardBaseItem>(this.CreateCardItem), false);
		this.AddEventListener();
	}

	// Token: 0x06011E43 RID: 73283 RVA: 0x004EBCA8 File Offset: 0x004E9EA8
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		PersonalCardComponent.<OnBeforeShowAsyncImplement>d__9 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<PersonalCardComponent.<OnBeforeShowAsyncImplement>d__9>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06011E44 RID: 73284 RVA: 0x004EBCEB File Offset: 0x004E9EEB
	protected void OnShowUiTabViewFromToggle()
	{
	}

	// Token: 0x06011E45 RID: 73285 RVA: 0x004EBCF0 File Offset: 0x004E9EF0
	private List<PersonalCardData> GetSortedList()
	{
		List<PersonalCardData> list = this.PersonalInfoData.GetCardList(true).ToList<PersonalCardData>();
		int num = list.FindIndex(delegate(PersonalCardData data)
		{
			int cardId = data.CardId;
			int? curCardId = this.PersonalInfoData.CurCardId;
			return cardId == curCardId.GetValueOrDefault() & curCardId != null;
		});
		if (num <= 0 || num >= list.Count)
		{
			return list;
		}
		PersonalCardData value = list[num];
		for (int i = num; i > 0; i--)
		{
			list[i] = list[i - 1];
		}
		list[0] = value;
		return list;
	}

	// Token: 0x06011E46 RID: 73286 RVA: 0x004EBD5E File Offset: 0x004E9F5E
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnCardChange, new Action(this.OnCardChange));
	}

	// Token: 0x06011E47 RID: 73287 RVA: 0x004EBD7C File Offset: 0x004E9F7C
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCardChange, new Action(this.OnCardChange));
	}

	// Token: 0x06011E48 RID: 73288 RVA: 0x004EBD9A File Offset: 0x004E9F9A
	public void SetRefreshConfirmBtn(Action<bool, bool> refreshConfirmBtn)
	{
		this.RefreshConfirmBtn = refreshConfirmBtn;
	}

	// Token: 0x06011E49 RID: 73289 RVA: 0x004EBDA4 File Offset: 0x004E9FA4
	private void OnCardChange()
	{
		if (this.IsPreview)
		{
			return;
		}
		this.RefreshConfirmBtnState(this.CurPersonalCardData);
		List<PersonalCardData> sortedList = this.GetSortedList();
		this.ScrollView.RefreshByData(sortedList, false, null, false);
		this.ScrollView.SelectGridProxy(0, false);
		this.ScrollView.ScrollToGridIndex(0, true);
		ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.ScrollView.GetGridByDisplayIndex(0), true, false, false);
	}

	// Token: 0x06011E4A RID: 73290 RVA: 0x004EBE10 File Offset: 0x004EA010
	public void OnClickConfirm(int _)
	{
		ControllerBase<PersonalController>.Instance.SendChangeCardRequest(this.CurPersonalCardData.CardId);
	}

	// Token: 0x06011E4B RID: 73291 RVA: 0x004EBE27 File Offset: 0x004EA027
	private void OnClickCardPreviewBtn()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.CurPersonalCardData.CardId, true, null);
	}

	// Token: 0x06011E4C RID: 73292 RVA: 0x004EBE40 File Offset: 0x004EA040
	private PersonalCardItem CreateCardItem()
	{
		PersonalCardItem personalCardItem = new PersonalCardItem();
		personalCardItem.SetToggleCallBack(new Action<int, PersonalCardData>(this.CardItemToggleClick));
		return personalCardItem;
	}

	// Token: 0x06011E4D RID: 73293 RVA: 0x004EBE5C File Offset: 0x004EA05C
	private void CardItemToggleClick(int gridIndex, PersonalCardData cardData)
	{
		this.CurPersonalCardData = cardData;
		List<PersonalCardData> cardDataList = this.PersonalInfoData.CardDataList;
		int count = cardDataList.Count;
		for (int i = 0; i < count; i++)
		{
			PersonalCardData personalCardData = cardDataList[i];
			if (personalCardData.CardId == cardData.CardId && personalCardData.IsUnLock && !personalCardData.IsRead)
			{
				ControllerBase<PersonalController>.Instance.SendReadCardRequest(cardData.CardId);
				break;
			}
		}
		if (!this.IsPreview)
		{
			this.RefreshConfirmBtnState(cardData);
		}
		this.RefreshCardInfo(cardData);
		this.ScrollView.SelectGridProxy(gridIndex, false);
	}

	// Token: 0x06011E4E RID: 73294 RVA: 0x004EBEEC File Offset: 0x004EA0EC
	protected void RefreshCardInfo(PersonalCardData cardData)
	{
		BackgroundCard? config = ConfigBackgroundCardById.GetConfig(cardData.CardId, true);
		base.SetTextureByPath(config.Value.CardPath, base.GetTexture(2), null, null);
		base.GetText(3).ShowTextNew(config.Value.Title);
		base.GetText(4).ShowTextNew(config.Value.AttributesDescription);
		base.GetText(5).ShowTextNew(config.Value.Tips);
	}

	// Token: 0x06011E4F RID: 73295 RVA: 0x004EBF80 File Offset: 0x004EA180
	private void RefreshConfirmBtnState(PersonalCardData cardData)
	{
		int? curCardId = this.PersonalInfoData.CurCardId;
		bool isUnLock = cardData.IsUnLock;
		int? num = curCardId;
		int cardId = cardData.CardId;
		bool flag = !(num.GetValueOrDefault() == cardId & num != null) && isUnLock;
		if (this.RefreshConfirmBtn != null)
		{
			Action<bool, bool> refreshConfirmBtn = this.RefreshConfirmBtn;
			bool arg = flag;
			num = curCardId;
			cardId = cardData.CardId;
			refreshConfirmBtn(arg, num.GetValueOrDefault() == cardId & num != null);
		}
	}

	// Token: 0x06011E50 RID: 73296 RVA: 0x004EBFF4 File Offset: 0x004EA1F4
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
	}

	// Token: 0x04008C0F RID: 35855
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<PersonalCardBaseItem, PersonalCardData> ScrollView;

	// Token: 0x04008C10 RID: 35856
	private readonly bool IsPreview;

	// Token: 0x04008C11 RID: 35857
	[Nullable(2)]
	private PersonalCardData CurPersonalCardData;

	// Token: 0x04008C12 RID: 35858
	private readonly PersonalInfoData PersonalInfoData;

	// Token: 0x04008C13 RID: 35859
	[Nullable(2)]
	private Action<bool, bool> RefreshConfirmBtn;

	// Token: 0x0200875C RID: 34652
	[NullableContext(0)]
	public enum EPersonalCardComponentDefine
	{
		// Token: 0x0402DC4B RID: 187467
		ScrollView,
		// Token: 0x0402DC4C RID: 187468
		PersonalCardItem,
		// Token: 0x0402DC4D RID: 187469
		Texture,
		// Token: 0x0402DC4E RID: 187470
		TitleText,
		// Token: 0x0402DC4F RID: 187471
		DescText,
		// Token: 0x0402DC50 RID: 187472
		TipsText,
		// Token: 0x0402DC51 RID: 187473
		RightItem,
		// Token: 0x0402DC52 RID: 187474
		CardPreviewBtn
	}
}
