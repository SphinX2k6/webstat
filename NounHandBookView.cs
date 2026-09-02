using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001EA5 RID: 7845
[NullableContext(1)]
[Nullable(0)]
public class NounHandBookView : UiViewBase
{
	// Token: 0x0600E7DE RID: 59358 RVA: 0x003EA4FC File Offset: 0x003E86FC
	public NounHandBookView(UiViewInfo viewInfo) : base(viewInfo)
	{
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		this.NounHandBookItemList = new List<NounHandBookItem>();
	}

	// Token: 0x0600E7DF RID: 59359 RVA: 0x003EA55C File Offset: 0x003E875C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIDynScrollViewComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIText)),
			new ValueTuple<int, Type>(22, typeof(UUIItem))
		};
	}

	// Token: 0x0600E7E0 RID: 59360 RVA: 0x003EA77C File Offset: 0x003E897C
	protected override void OnStart()
	{
		base.GetText(11).SetUIActive(false);
		base.GetText(10).SetUIActive(false);
		base.GetButton(13).RootUIComp.Get().SetUIActive(false);
		base.GetButton(14).RootUIComp.Get().SetUIActive(false);
		base.GetButton(12).RootUIComp.Get().SetUIActive(false);
		this.InitCommonTabTitle();
		this.Refresh();
		this.RefreshLockText();
	}

	// Token: 0x0600E7E1 RID: 59361 RVA: 0x003EA808 File Offset: 0x003E8A08
	private void OnHandBookDataUpdate(EHandBookTabType eHandBookTabType, int i)
	{
		this.Refresh();
	}

	// Token: 0x0600E7E2 RID: 59362 RVA: 0x003EA810 File Offset: 0x003E8A10
	protected void Refresh()
	{
		this.InitScrollView();
		this.RefreshCollectText();
	}

	// Token: 0x0600E7E3 RID: 59363 RVA: 0x003EA820 File Offset: 0x003E8A20
	protected void OnHandBookRead(EHandBookTabType type, int id)
	{
		if (type != EHandBookTabType.Noun)
		{
			return;
		}
		int count = this.NounHandBookItemList.Count;
		for (int i = 0; i < count; i++)
		{
			this.NounHandBookItemList[i].RefreshNewState();
		}
	}

	// Token: 0x0600E7E4 RID: 59364 RVA: 0x003EA85C File Offset: 0x003E8A5C
	protected void RefreshLockState(bool isLock)
	{
		base.GetText(4).SetUIActive(!isLock);
		base.GetText(5).SetUIActive(!isLock);
		base.GetText(6).SetUIActive(!isLock);
		base.GetTexture(7).SetUIActive(!isLock);
		base.GetText(8).SetUIActive(!isLock);
		base.GetText(9).SetUIActive(!isLock);
		base.GetText(15).SetUIActive(isLock);
		base.GetItem(22).SetUIActive(isLock);
		base.GetItem(19).SetUIActive(!isLock);
		base.GetItem(20).SetUIActive(!isLock);
	}

	// Token: 0x0600E7E5 RID: 59365 RVA: 0x003EA908 File Offset: 0x003E8B08
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Add<EHandBookTabType, int>(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E7E6 RID: 59366 RVA: 0x003EA96C File Offset: 0x003E8B6C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E7E7 RID: 59367 RVA: 0x003EA9D0 File Offset: 0x003E8BD0
	protected override UniTask OnBeforeStartAsync()
	{
		NounHandBookView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<NounHandBookView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E7E8 RID: 59368 RVA: 0x003EAA14 File Offset: 0x003E8C14
	public void InitScrollView()
	{
		List<NounType> list = ConfigCommon.ToList<NounType>(ConfigBase<HandBookConfig>.Instance.GetNounTypeConfigList());
		list.Sort(new Comparison<NounType>(this.SortIndex));
		int count = list.Count;
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		for (int i = 0; i < count; i++)
		{
			NounType nounType = list[i];
			HandBookCommonItemData handBookCommonItemData = new HandBookCommonItemData();
			HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Noun, nounType.Id);
			bool isLock = handBookInfo == null;
			bool isNew = handBookInfo != null && !handBookInfo.IsRead;
			handBookCommonItemData.Icon = nounType.Icon;
			handBookCommonItemData.Title = (ConfigMultiTextLang.GetLocalTextNew(nounType.TypeDescription, null) ?? "");
			handBookCommonItemData.Config = nounType;
			handBookCommonItemData.IsLock = isLock;
			handBookCommonItemData.IsNew = isNew;
			this.HandBookCommonItemDataList.Add(handBookCommonItemData);
		}
		HandBookNounDynamicData[] data = this.BuildContentData();
		DynamicScrollView<NounHandBookItem, HandBootNounDynamicItem, HandBookNounDynamicData> contentGenericLayout = this.ContentGenericLayout;
		if (contentGenericLayout == null)
		{
			return;
		}
		contentGenericLayout.RefreshByData(data, false, false);
	}

	// Token: 0x0600E7E9 RID: 59369 RVA: 0x003EAB18 File Offset: 0x003E8D18
	private NounHandBookItem InitNounItem(object data, UUIItem uiItem, int index)
	{
		NounHandBookItem nounHandBookItem = new NounHandBookItem();
		nounHandBookItem.BindToggleCallback(new TNounToggleFunction(this.NounToggleFunction));
		nounHandBookItem.BindChildToggleCallback(new TChildNounToggleFunction(this.ChildNounToggleFunction));
		this.NounHandBookItemList.Add(nounHandBookItem);
		return nounHandBookItem;
	}

	// Token: 0x0600E7EA RID: 59370 RVA: 0x003EAB5C File Offset: 0x003E8D5C
	private void NounToggleFunction(int selectId)
	{
		this.CurrentSelectNoun = selectId;
		HandBookNounDynamicData[] data = this.BuildContentData();
		DynamicScrollView<NounHandBookItem, HandBootNounDynamicItem, HandBookNounDynamicData> contentGenericLayout = this.ContentGenericLayout;
		if (contentGenericLayout != null)
		{
			contentGenericLayout.RefreshByData(data, true, false);
		}
		DynamicScrollView<NounHandBookItem, HandBootNounDynamicItem, HandBookNounDynamicData> contentGenericLayout2 = this.ContentGenericLayout;
		if (contentGenericLayout2 == null)
		{
			return;
		}
		contentGenericLayout2.BindLateUpdate(delegate(float _)
		{
			DynamicScrollView<NounHandBookItem, HandBootNounDynamicItem, HandBookNounDynamicData> contentGenericLayout3 = this.ContentGenericLayout;
			if (contentGenericLayout3 != null)
			{
				contentGenericLayout3.ScrollToItemIndex(this.ScrollToIndex, true, false);
			}
			DynamicScrollView<NounHandBookItem, HandBootNounDynamicItem, HandBookNounDynamicData> contentGenericLayout4 = this.ContentGenericLayout;
			if (contentGenericLayout4 == null)
			{
				return;
			}
			contentGenericLayout4.UnBindLateUpdate();
		});
	}

	// Token: 0x0600E7EB RID: 59371 RVA: 0x003EABA8 File Offset: 0x003E8DA8
	private void ChildNounToggleFunction(NounHandBook nounHandBook, UUIExtendToggle toggle)
	{
		this.CurSelectConfig = new NounHandBook?(nounHandBook);
		if (this.CurrentToggle != toggle)
		{
			UUIExtendToggle currentToggle = this.CurrentToggle;
			if (currentToggle != null)
			{
				currentToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.CurrentToggle = toggle;
		}
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Noun, this.CurSelectConfig.Value.Id);
		bool flag = handBookInfo == null;
		this.RefreshLockState(flag);
		if (flag)
		{
			return;
		}
		string infoDisplayTitle = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayTitle(this.CurSelectConfig.Value.Id);
		base.GetText(4).SetText(infoDisplayTitle, true);
		NounType? nounTypeConfig = ConfigBase<HandBookConfig>.Instance.GetNounTypeConfig(nounHandBook.Type);
		base.GetText(5).ShowTextNew(nounTypeConfig.Value.TypeDescription);
		string[] infoDisplayPictures = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayPictures(this.CurSelectConfig.Value.Id);
		bool flag2 = infoDisplayPictures.Length != 0;
		UUIItem item = base.GetItem(17);
		if (flag2)
		{
			item.SetUIActive(true);
			base.SetTextureByPath(infoDisplayPictures[0], base.GetTexture(7), null, null);
		}
		else
		{
			item.SetUIActive(false);
		}
		int num = 1;
		int num2 = infoDisplayPictures.Length;
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(8), "RoleExp", new <>z__ReadOnlyArray<object>(new object[]
		{
			num,
			num2
		}));
		bool uiactive = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayAudio(this.CurSelectConfig.Value.Id).Length > 0;
		base.GetItem(16).SetUIActive(uiactive);
		string infoDisplayDesc = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayDesc(this.CurSelectConfig.Value.Id);
		bool uiactive2 = infoDisplayDesc != null && infoDisplayDesc.Length > 0;
		base.GetItem(20).SetUIActive(uiactive2);
		base.GetText(21).SetText(infoDisplayDesc, true);
		base.GetItem(18).SetUIActive(false);
		if (handBookInfo != null && !handBookInfo.IsRead)
		{
			ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest(EHandBookTabType.Noun, this.CurSelectConfig.Value.Id);
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(6), "DateOfAcquisition", new <>z__ReadOnlySingleElementList<object>(flag ? "" : handBookInfo.CreateTime));
	}

	// Token: 0x0600E7EC RID: 59372 RVA: 0x003EAE04 File Offset: 0x003E9004
	protected void RefreshLockText()
	{
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("ChipHandBookLock");
		base.GetText(15).SetText(textById, true);
	}

	// Token: 0x0600E7ED RID: 59373 RVA: 0x003EAE30 File Offset: 0x003E9030
	private int SortIndex(NounType a, NounType b)
	{
		return a.Id - b.Id;
	}

	// Token: 0x0600E7EE RID: 59374 RVA: 0x003EAE44 File Offset: 0x003E9044
	protected void InitCommonTabTitle()
	{
		HandBookEntrance? handBookEntranceConfig = ConfigBase<HandBookConfig>.Instance.GetHandBookEntranceConfig(EHandBookTabType.Noun);
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(this.OnClickCloseButton);
		this.CaptionItem.SetTitleLocalText(handBookEntranceConfig.Value.Name);
		this.CaptionItem.SetTitleIcon(handBookEntranceConfig.Value.TitleIcon);
	}

	// Token: 0x0600E7EF RID: 59375 RVA: 0x003EAEB8 File Offset: 0x003E90B8
	protected void RefreshCollectText()
	{
		int[] collectProgress = ControllerBase<HandBookController>.Instance.GetCollectProgress(EHandBookTabType.Noun);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "RoleExp", new <>z__ReadOnlyArray<object>(new object[]
		{
			collectProgress[0],
			collectProgress[1]
		}));
	}

	// Token: 0x0600E7F0 RID: 59376 RVA: 0x003EAF09 File Offset: 0x003E9109
	protected override void OnBeforeDestroy()
	{
		if (this.ContentGenericLayout != null)
		{
			this.ContentGenericLayout.ClearChildren();
			this.ContentGenericLayout = null;
		}
		this.NounHandBookItemList = new List<NounHandBookItem>();
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		this.CurSelectConfig = null;
	}

	// Token: 0x0600E7F1 RID: 59377 RVA: 0x003EAF48 File Offset: 0x003E9148
	private HandBookNounDynamicData[] BuildContentData()
	{
		if (this.CurrentSelectNoun == -1)
		{
			this.CurrentSelectNoun = ((NounType)this.HandBookCommonItemDataList[0].Config).Id;
		}
		List<HandBookNounDynamicData> list = new List<HandBookNounDynamicData>();
		foreach (HandBookCommonItemData handBookCommonItemData in this.HandBookCommonItemDataList)
		{
			NounType nounType = (NounType)handBookCommonItemData.Config;
			bool flag = this.CurrentSelectNoun == nounType.Id;
			list.Add(new HandBookNounDynamicData
			{
				HandBookCommonItemData = handBookCommonItemData,
				IsShowContent = flag
			});
			if (flag)
			{
				this.ScrollToIndex = this.HandBookCommonItemDataList.IndexOf(handBookCommonItemData);
				IEnumerable<NounHandBook> nounHandBookConfigList = ConfigBase<HandBookConfig>.Instance.GetNounHandBookConfigList(nounType.Id);
				bool isShowContent = true;
				foreach (NounHandBook nounHandBook in nounHandBookConfigList)
				{
					list.Add(new HandBookNounDynamicData
					{
						HandBookNounConfigId = new int?(nounHandBook.Id),
						IsShowContent = isShowContent
					});
					isShowContent = false;
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x04006FCE RID: 28622
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<NounHandBookItem, HandBootNounDynamicItem, HandBookNounDynamicData> ContentGenericLayout;

	// Token: 0x04006FCF RID: 28623
	[Nullable(2)]
	private HandBootNounDynamicItem HandBootNounDynamicItem;

	// Token: 0x04006FD0 RID: 28624
	private int CurrentSelectNoun = -1;

	// Token: 0x04006FD1 RID: 28625
	private int ScrollToIndex = -1;

	// Token: 0x04006FD2 RID: 28626
	protected List<HandBookCommonItemData> HandBookCommonItemDataList;

	// Token: 0x04006FD3 RID: 28627
	private NounHandBook? CurSelectConfig;

	// Token: 0x04006FD4 RID: 28628
	private List<NounHandBookItem> NounHandBookItemList;

	// Token: 0x04006FD5 RID: 28629
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04006FD6 RID: 28630
	[Nullable(2)]
	private UUIExtendToggle CurrentToggle;

	// Token: 0x04006FD7 RID: 28631
	private readonly Action OnClickCloseButton = delegate()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.NounHandBookView, null);
	};

	// Token: 0x020081E5 RID: 33253
	[NullableContext(0)]
	private class ENounHandBookViewDefine
	{
		// Token: 0x0402C116 RID: 180502
		public const int TitleItem = 0;

		// Token: 0x0402C117 RID: 180503
		public const int CollectCountText = 1;

		// Token: 0x0402C118 RID: 180504
		public const int Layout = 2;

		// Token: 0x0402C119 RID: 180505
		public const int NounItem = 3;

		// Token: 0x0402C11A RID: 180506
		public const int NameText = 4;

		// Token: 0x0402C11B RID: 180507
		public const int TypeText = 5;

		// Token: 0x0402C11C RID: 180508
		public const int DateText = 6;

		// Token: 0x0402C11D RID: 180509
		public const int Texture = 7;

		// Token: 0x0402C11E RID: 180510
		public const int ProgressText = 8;

		// Token: 0x0402C11F RID: 180511
		public const int DescriptionText = 9;

		// Token: 0x0402C120 RID: 180512
		public const int VoiceProgressText = 10;

		// Token: 0x0402C121 RID: 180513
		public const int VoiceText = 11;

		// Token: 0x0402C122 RID: 180514
		public const int StopButton = 12;

		// Token: 0x0402C123 RID: 180515
		public const int PlayButton = 13;

		// Token: 0x0402C124 RID: 180516
		public const int TextureButton = 14;

		// Token: 0x0402C125 RID: 180517
		public const int LockText = 15;

		// Token: 0x0402C126 RID: 180518
		public const int SoundItem = 16;

		// Token: 0x0402C127 RID: 180519
		public const int PhotoItem = 17;

		// Token: 0x0402C128 RID: 180520
		public const int WordItem = 18;

		// Token: 0x0402C129 RID: 180521
		public const int NounTitleItem = 19;

		// Token: 0x0402C12A RID: 180522
		public const int BigWordItem = 20;

		// Token: 0x0402C12B RID: 180523
		public const int BigWordText = 21;

		// Token: 0x0402C12C RID: 180524
		public const int UnlockItem = 22;
	}
}
