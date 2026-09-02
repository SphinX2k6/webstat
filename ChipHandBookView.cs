using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E3F RID: 7743
[NullableContext(1)]
[Nullable(0)]
public class ChipHandBookView : UiViewBase
{
	// Token: 0x0600E526 RID: 58662 RVA: 0x003DE15C File Offset: 0x003DC35C
	public ChipHandBookView(UiViewInfo viewInfo) : base(viewInfo)
	{
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		this.ChipHandBookItemList = new List<ChipHandBookItem>();
	}

	// Token: 0x0600E527 RID: 58663 RVA: 0x003DE1CC File Offset: 0x003DC3CC
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
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(12, new Action(this.OnClickStopButton)),
			new ValueTuple<int, Delegate>(13, new Action(this.OnClickPlayButton)),
			new ValueTuple<int, Delegate>(14, new Action(this.OnClickTextureButton))
		};
	}

	// Token: 0x0600E528 RID: 58664 RVA: 0x003DE442 File Offset: 0x003DC642
	protected override void OnStart()
	{
		this.InitCommonTabTitle();
		this.Refresh();
		this.RefreshLockText();
		this.VoiceProgressText = base.GetText(10);
	}

	// Token: 0x0600E529 RID: 58665 RVA: 0x003DE464 File Offset: 0x003DC664
	private void OnHandBookDataUpdate(EHandBookTabType eHandBookTabType, int i)
	{
		this.Refresh();
	}

	// Token: 0x0600E52A RID: 58666 RVA: 0x003DE46C File Offset: 0x003DC66C
	protected void Refresh()
	{
		this.InitScrollView();
		this.RefreshCollectText();
	}

	// Token: 0x0600E52B RID: 58667 RVA: 0x003DE47C File Offset: 0x003DC67C
	protected void OnHandBookRead(EHandBookTabType type, int id)
	{
		if (type != EHandBookTabType.Chip)
		{
			return;
		}
		int count = this.ChipHandBookItemList.Count;
		for (int i = 0; i < count; i++)
		{
			this.ChipHandBookItemList[i].RefreshNewState();
		}
	}

	// Token: 0x0600E52C RID: 58668 RVA: 0x003DE4B8 File Offset: 0x003DC6B8
	protected void RefreshLockState(bool isLock)
	{
		base.GetText(4).SetUIActive(!isLock);
		base.GetText(5).SetUIActive(!isLock);
		base.GetText(6).SetUIActive(!isLock);
		base.GetTexture(7).SetUIActive(!isLock);
		base.GetText(8).SetUIActive(!isLock);
		base.GetText(9).SetUIActive(!isLock);
		base.GetText(10).SetUIActive(!isLock);
		base.GetText(11).SetUIActive(!isLock);
		base.GetButton(12).RootUIComp.Get().SetUIActive(false);
		base.GetButton(13).RootUIComp.Get().SetUIActive(!isLock);
		base.GetButton(14).RootUIComp.Get().SetUIActive(!isLock);
		base.GetText(15).SetUIActive(isLock);
		base.GetItem(22).SetUIActive(isLock);
		base.GetItem(19).SetUIActive(!isLock);
		base.GetItem(20).SetUIActive(!isLock);
	}

	// Token: 0x0600E52D RID: 58669 RVA: 0x003DE5E0 File Offset: 0x003DC7E0
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Add<EHandBookTabType, int>(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E52E RID: 58670 RVA: 0x003DE644 File Offset: 0x003DC844
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E52F RID: 58671 RVA: 0x003DE6A8 File Offset: 0x003DC8A8
	protected override UniTask OnBeforeStartAsync()
	{
		ChipHandBookView.<OnBeforeStartAsync>d__29 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ChipHandBookView.<OnBeforeStartAsync>d__29>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E530 RID: 58672 RVA: 0x003DE6EC File Offset: 0x003DC8EC
	public void InitScrollView()
	{
		List<ChipType> list = ConfigCommon.ToList<ChipType>(ConfigBase<HandBookConfig>.Instance.GetChipTypeConfigList());
		list.Sort(new Comparison<ChipType>(this.SortIndex));
		int count = list.Count;
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		for (int i = 0; i < count; i++)
		{
			ChipType chipType = list[i];
			HandBookCommonItemData handBookCommonItemData = new HandBookCommonItemData();
			HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Chip, chipType.Id);
			bool isLock = handBookInfo == null;
			bool isNew = handBookInfo != null && !handBookInfo.IsRead;
			handBookCommonItemData.Icon = chipType.Icon;
			handBookCommonItemData.Title = ConfigMultiTextLang.GetLocalTextNew(chipType.TypeDescription, null);
			handBookCommonItemData.Config = chipType;
			handBookCommonItemData.IsLock = isLock;
			handBookCommonItemData.IsNew = isNew;
			this.HandBookCommonItemDataList.Add(handBookCommonItemData);
		}
		HandBookChipDynamicData[] data = this.BuildContentData();
		DynamicScrollView<ChipHandBookItem, HandBootChipDynamicItem, HandBookChipDynamicData> contentGenericLayout = this.ContentGenericLayout;
		if (contentGenericLayout == null)
		{
			return;
		}
		contentGenericLayout.RefreshByData(data, false, false);
	}

	// Token: 0x0600E531 RID: 58673 RVA: 0x003DE7E8 File Offset: 0x003DC9E8
	private ChipHandBookItem InitChipItem(object data, UUIItem uiItem, int index)
	{
		ChipHandBookItem chipHandBookItem = new ChipHandBookItem();
		chipHandBookItem.BindToggleCallback(new TChipToggleFunction(this.ChipToggleFunction));
		chipHandBookItem.BindChildToggleCallback(new TChildChipToggleFunction(this.ChildChipToggleFunction));
		this.ChipHandBookItemList.Add(chipHandBookItem);
		return chipHandBookItem;
	}

	// Token: 0x0600E532 RID: 58674 RVA: 0x003DE82C File Offset: 0x003DCA2C
	private void ChipToggleFunction(int selectId)
	{
		this.CurrentSelectChip = selectId;
		HandBookChipDynamicData[] data = this.BuildContentData();
		DynamicScrollView<ChipHandBookItem, HandBootChipDynamicItem, HandBookChipDynamicData> contentGenericLayout = this.ContentGenericLayout;
		if (contentGenericLayout != null)
		{
			contentGenericLayout.RefreshByData(data, true, false);
		}
		DynamicScrollView<ChipHandBookItem, HandBootChipDynamicItem, HandBookChipDynamicData> contentGenericLayout2 = this.ContentGenericLayout;
		if (contentGenericLayout2 == null)
		{
			return;
		}
		contentGenericLayout2.BindLateUpdate(delegate(float _)
		{
			DynamicScrollView<ChipHandBookItem, HandBootChipDynamicItem, HandBookChipDynamicData> contentGenericLayout3 = this.ContentGenericLayout;
			if (contentGenericLayout3 != null)
			{
				contentGenericLayout3.ScrollToItemIndex(this.ScrollToIndex, true, false).Forget();
			}
			DynamicScrollView<ChipHandBookItem, HandBootChipDynamicItem, HandBookChipDynamicData> contentGenericLayout4 = this.ContentGenericLayout;
			if (contentGenericLayout4 == null)
			{
				return;
			}
			contentGenericLayout4.UnBindLateUpdate();
		});
	}

	// Token: 0x0600E533 RID: 58675 RVA: 0x003DE878 File Offset: 0x003DCA78
	private void ChildChipToggleFunction(ChipHandBook chipHandBook, UUIExtendToggle toggle)
	{
		this.CurSelectConfig = new ChipHandBook?(chipHandBook);
		UUIExtendToggle currentToggle = this.CurrentToggle;
		if (currentToggle != null)
		{
			currentToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentToggle = toggle;
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Chip, this.CurSelectConfig.Value.Id);
		bool flag = handBookInfo == null;
		if (flag)
		{
			this.RefreshLockState(flag);
			return;
		}
		string infoDisplayTitle = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayTitle(this.CurSelectConfig.Value.Id);
		base.GetText(4).SetText(infoDisplayTitle, true);
		ChipType? chipTypeConfig = ConfigBase<HandBookConfig>.Instance.GetChipTypeConfig(chipHandBook.Type);
		base.GetText(5).ShowTextNew(chipTypeConfig.Value.TypeDescription);
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
		base.GetText(11).ShowTextNew(chipHandBook.VoiceDescrtption);
		base.GetButton(12).RootUIComp.Get().SetUIActive(false);
		base.GetButton(13).RootUIComp.Get().SetUIActive(true);
		string infoDisplayDesc = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayDesc(this.CurSelectConfig.Value.Id);
		bool uiactive2 = infoDisplayDesc != null && infoDisplayDesc.Length > 0;
		base.GetItem(20).SetUIActive(uiactive2);
		base.GetText(21).SetText(infoDisplayDesc, true);
		base.GetItem(18).SetUIActive(false);
		if (handBookInfo != null && !handBookInfo.IsRead)
		{
			ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest(EHandBookTabType.Chip, this.CurSelectConfig.Value.Id);
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(6), "DateOfAcquisition", new <>z__ReadOnlySingleElementList<object>(flag ? "" : handBookInfo.CreateTime));
	}

	// Token: 0x0600E534 RID: 58676 RVA: 0x003DEB14 File Offset: 0x003DCD14
	protected void RefreshLockText()
	{
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("ChipHandBookLock");
		base.GetText(15).SetText(textById, true);
	}

	// Token: 0x0600E535 RID: 58677 RVA: 0x003DEB40 File Offset: 0x003DCD40
	private int SortIndex(ChipType a, ChipType b)
	{
		return a.Id - b.Id;
	}

	// Token: 0x0600E536 RID: 58678 RVA: 0x003DEB54 File Offset: 0x003DCD54
	protected void InitCommonTabTitle()
	{
		HandBookEntrance? handBookEntranceConfig = ConfigBase<HandBookConfig>.Instance.GetHandBookEntranceConfig(EHandBookTabType.Chip);
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnClickCloseButton));
		this.CaptionItem.SetTitleLocalText(handBookEntranceConfig.Value.Name);
		this.CaptionItem.SetTitleIcon(handBookEntranceConfig.Value.TitleIcon);
	}

	// Token: 0x0600E537 RID: 58679 RVA: 0x003DEBCA File Offset: 0x003DCDCA
	private void OnClickCloseButton()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ChipHandBookView, null);
	}

	// Token: 0x0600E538 RID: 58680 RVA: 0x003DEBDC File Offset: 0x003DCDDC
	private void OnClickPlayButton()
	{
		base.GetButton(12).RootUIComp.Get().SetUIActive(true);
		base.GetButton(13).RootUIComp.Get().SetUIActive(false);
		if (this.AudioDelegate == null)
		{
			this.AudioDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnAkPostEventCallback>(new Action<EAkCallbackType, UAkCallbackInfo>(this.CallBackDuration));
		}
		string infoDisplayAudio = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayAudio(this.CurSelectConfig.Value.Id);
		Singleton<AudioController>.Instance.PostEventByUi(infoDisplayAudio, this.AudioResult, new int?(this.PlayFlag), this.AudioDelegate);
	}

	// Token: 0x0600E539 RID: 58681 RVA: 0x003DEC80 File Offset: 0x003DCE80
	private void OnClickStopButton()
	{
		base.GetButton(12).RootUIComp.Get().SetUIActive(false);
		base.GetButton(13).RootUIComp.Get().SetUIActive(true);
		if (this.CurSelectConfig == null)
		{
			return;
		}
		this.ClearTimerId();
		this.CurTime = 0f;
		Singleton<AudioController>.Instance.StopEvent(this.AudioResult, true, null);
		this.VoiceProgressText.SetText("", true);
	}

	// Token: 0x0600E53A RID: 58682 RVA: 0x003DED0D File Offset: 0x003DCF0D
	private void ClearTimerId()
	{
		if (this.TimerId != null && this.TimerId.Valid())
		{
			this.TimerId.Remove();
		}
		this.TimerId = null;
	}

	// Token: 0x0600E53B RID: 58683 RVA: 0x003DED38 File Offset: 0x003DCF38
	private void OnClickTextureButton()
	{
		string[] infoDisplayPictures = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayPictures(this.CurSelectConfig.Value.Id);
		int type = this.CurSelectConfig.Value.Type;
		ChipType? chipTypeConfig = ConfigBase<HandBookConfig>.Instance.GetChipTypeConfig(type);
		HandBookPhotoData handBookPhotoData = new HandBookPhotoData();
		string infoDisplayDesc = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayDesc(this.CurSelectConfig.Value.Id);
		List<string> list = new List<string>();
		list.Add(infoDisplayDesc);
		List<string> list2 = new List<string>();
		list2.Add(ConfigMultiTextLang.GetLocalTextNew(chipTypeConfig.Value.TypeDescription, null));
		List<string> list3 = new List<string>();
		string infoDisplayTitle = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayTitle(this.CurSelectConfig.Value.Id);
		list3.Add(infoDisplayTitle);
		handBookPhotoData.DescrtptionText = list;
		handBookPhotoData.TypeText = list2;
		handBookPhotoData.NameText = list3;
		handBookPhotoData.HandBookType = EHandBookTabType.Chip;
		handBookPhotoData.Index = 0;
		handBookPhotoData.TextureList = infoDisplayPictures.ToList<string>();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HandBookPhotoView, handBookPhotoData, null);
	}

	// Token: 0x0600E53C RID: 58684 RVA: 0x003DEE54 File Offset: 0x003DD054
	[NullableContext(2)]
	private void CallBackDuration(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
	{
		if (callbackType == EAkCallbackType.Duration)
		{
			UAkDurationCallbackInfo uakDurationCallbackInfo = callbackInfo as UAkDurationCallbackInfo;
			this.TotalTime = (float)Math.Ceiling((double)(uakDurationCallbackInfo.Duration / (float)this.ChangeNum));
			this.TimerId = TimerSystem.Instance.Loop(delegate(float _)
			{
				this.CurTime += 1f;
				if (this.CurTime > this.TotalTime)
				{
					this.OnClickStopButton();
					return;
				}
				int curSecond = (int)(this.CurTime % (float)this.TimeHex);
				int curMinute = (int)Math.Floor((double)(this.CurTime / (float)this.TimeHex));
				int totalSecond = (int)(this.TotalTime % (float)this.TimeHex);
				int totalMinute = (int)Math.Floor((double)(this.TotalTime / (float)this.TimeHex));
				this.SetVoiceProgress(curSecond, curMinute, totalSecond, totalMinute);
			}, this.Interval, (int)(this.TotalTime + 1f), 1f, null, null, true);
		}
	}

	// Token: 0x0600E53D RID: 58685 RVA: 0x003DEEC0 File Offset: 0x003DD0C0
	protected void SetVoiceProgress(int curSecond, int curMinute, int totalSecond, int totalMinute)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(this.VoiceProgressText, "VoiceProgress", new <>z__ReadOnlyArray<object>(new object[]
		{
			this.TimeFormat((float)curMinute),
			this.TimeFormat((float)curSecond),
			this.TimeFormat((float)totalMinute),
			this.TimeFormat((float)totalSecond)
		}));
	}

	// Token: 0x0600E53E RID: 58686 RVA: 0x003DEF1A File Offset: 0x003DD11A
	protected string TimeFormat(float time)
	{
		if (time >= (float)this.TimeMin)
		{
			return time.ToString();
		}
		return "0" + time.ToString();
	}

	// Token: 0x0600E53F RID: 58687 RVA: 0x003DEF40 File Offset: 0x003DD140
	protected void RefreshCollectText()
	{
		int[] collectProgress = ControllerBase<HandBookController>.Instance.GetCollectProgress(EHandBookTabType.Chip);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "RoleExp", new <>z__ReadOnlyArray<object>(new object[]
		{
			collectProgress[0],
			collectProgress[1]
		}));
	}

	// Token: 0x0600E540 RID: 58688 RVA: 0x003DEF90 File Offset: 0x003DD190
	protected override void OnBeforeDestroy()
	{
		if (this.ContentGenericLayout != null)
		{
			this.ContentGenericLayout.ClearChildren();
			this.ContentGenericLayout = null;
		}
		if (this.AudioDelegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EAkCallbackType, UAkCallbackInfo>(this.CallBackDuration));
			this.AudioDelegate = null;
		}
		Singleton<AudioController>.Instance.StopEvent(this.AudioResult, true, null);
		this.CurTime = 0f;
		this.TotalTime = 0f;
		this.VoiceProgressText = null;
		this.ChipHandBookItemList = new List<ChipHandBookItem>();
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		this.CurSelectConfig = null;
	}

	// Token: 0x0600E541 RID: 58689 RVA: 0x003DF030 File Offset: 0x003DD230
	private HandBookChipDynamicData[] BuildContentData()
	{
		if (this.CurrentSelectChip == -1)
		{
			this.CurrentSelectChip = ((ChipHandBook)this.HandBookCommonItemDataList[0].Config).Id;
		}
		List<HandBookChipDynamicData> list = new List<HandBookChipDynamicData>();
		foreach (HandBookCommonItemData handBookCommonItemData in this.HandBookCommonItemDataList)
		{
			bool flag = this.CurrentSelectChip == ((ChipHandBook)handBookCommonItemData.Config).Id;
			list.Add(new HandBookChipDynamicData
			{
				HandBookCommonItemData = handBookCommonItemData,
				IsShowContent = flag
			});
			if (flag)
			{
				this.ScrollToIndex = this.HandBookCommonItemDataList.IndexOf(handBookCommonItemData);
				IEnumerable<ChipHandBook> chipHandBookConfigList = ConfigBase<HandBookConfig>.Instance.GetChipHandBookConfigList(((ChipHandBook)handBookCommonItemData.Config).Id);
				bool isShowContent = true;
				foreach (ChipHandBook chipHandBook in chipHandBookConfigList)
				{
					list.Add(new HandBookChipDynamicData
					{
						HandBookChipConfigId = new int?(chipHandBook.Id),
						IsShowContent = isShowContent
					});
					isShowContent = false;
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x04006E46 RID: 28230
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<ChipHandBookItem, HandBootChipDynamicItem, HandBookChipDynamicData> ContentGenericLayout;

	// Token: 0x04006E47 RID: 28231
	[Nullable(2)]
	private HandBootChipDynamicItem HandBootChipDynamicItem;

	// Token: 0x04006E48 RID: 28232
	private int CurrentSelectChip = -1;

	// Token: 0x04006E49 RID: 28233
	private int ScrollToIndex = -1;

	// Token: 0x04006E4A RID: 28234
	protected List<HandBookCommonItemData> HandBookCommonItemDataList;

	// Token: 0x04006E4B RID: 28235
	private ChipHandBook? CurSelectConfig;

	// Token: 0x04006E4C RID: 28236
	private readonly PlayResult AudioResult = new PlayResult();

	// Token: 0x04006E4D RID: 28237
	private readonly int PlayFlag = 8;

	// Token: 0x04006E4E RID: 28238
	[Nullable(2)]
	private FOnAkPostEventCallback AudioDelegate;

	// Token: 0x04006E4F RID: 28239
	private readonly int ChangeNum = 1000;

	// Token: 0x04006E50 RID: 28240
	[Nullable(2)]
	private TimerHandle TimerId;

	// Token: 0x04006E51 RID: 28241
	private float CurTime;

	// Token: 0x04006E52 RID: 28242
	private float TotalTime;

	// Token: 0x04006E53 RID: 28243
	private readonly float Interval = 1000f;

	// Token: 0x04006E54 RID: 28244
	[Nullable(2)]
	private UUIText VoiceProgressText;

	// Token: 0x04006E55 RID: 28245
	private List<ChipHandBookItem> ChipHandBookItemList;

	// Token: 0x04006E56 RID: 28246
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04006E57 RID: 28247
	private readonly int TimeHex = 60;

	// Token: 0x04006E58 RID: 28248
	private readonly int TimeMin = 10;

	// Token: 0x04006E59 RID: 28249
	[Nullable(2)]
	private UUIExtendToggle CurrentToggle;
}
