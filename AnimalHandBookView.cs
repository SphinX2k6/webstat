using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;

// Token: 0x02001E35 RID: 7733
[NullableContext(1)]
[Nullable(0)]
public class AnimalHandBookView : HandBookBaseView
{
	// Token: 0x0600E4ED RID: 58605 RVA: 0x003DD38E File Offset: 0x003DB58E
	public AnimalHandBookView(UiViewInfo viewInfo) : base(viewInfo)
	{
		this.ConfigList = new List<AnimalHandBook>();
		this.HandBookCommonItemList = new List<HandBookCommonItem>();
	}

	// Token: 0x0600E4EE RID: 58606 RVA: 0x003DD3AD File Offset: 0x003DB5AD
	protected override void OnStart()
	{
		base.SetDefaultState();
		this.Refresh();
		this.RefreshLockText();
	}

	// Token: 0x0600E4EF RID: 58607 RVA: 0x003DD3C4 File Offset: 0x003DB5C4
	protected override void OnAfterShow()
	{
		this.UiCameraHandleData = Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName("1062", true, true, "1001", false, null, null);
	}

	// Token: 0x0600E4F0 RID: 58608 RVA: 0x003DD3F8 File Offset: 0x003DB5F8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Add<EHandBookTabType, int>(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E4F1 RID: 58609 RVA: 0x003DD45C File Offset: 0x003DB65C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E4F2 RID: 58610 RVA: 0x003DD4C0 File Offset: 0x003DB6C0
	protected override HandBookCommonItem InitHandBookCommonItem()
	{
		HandBookCommonItem handBookCommonItem = new HandBookCommonItem();
		handBookCommonItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnToggleClick));
		this.HandBookCommonItemList.Add(handBookCommonItem);
		return handBookCommonItem;
	}

	// Token: 0x0600E4F3 RID: 58611 RVA: 0x003DD4F4 File Offset: 0x003DB6F4
	public override List<CommonTabItemData> GetTabItemData(List<CommonTabData> tabData)
	{
		List<CommonTabItemData> list = new List<CommonTabItemData>();
		int count = this.TabList.Count;
		for (int i = 0; i < count; i++)
		{
			list.Add(new CommonTabItemData
			{
				Index = i,
				Data = this.TabList[i]
			});
		}
		return list;
	}

	// Token: 0x0600E4F4 RID: 58612 RVA: 0x003DD548 File Offset: 0x003DB748
	protected void OnToggleClick(MediumItemGridExtendCallback callbackParameter)
	{
		HandBookCommonItemData handBookCommonItemData = callbackParameter.Data as HandBookCommonItemData;
		int gridIndex = (callbackParameter.MediumItemGrid as HandBookCommonItem).GridIndex;
		this.ScrollViewCommon.DeselectCurrentGridProxy(false);
		this.ScrollViewCommon.SelectGridProxy(gridIndex, false);
		this.ScrollViewCommon.RefreshGridProxy(gridIndex);
		ControllerBase<HandBookController>.Instance.ClearEffect();
		if (handBookCommonItemData.IsLock)
		{
			base.SetLockState(true);
			return;
		}
		AnimalHandBook animalHandBook = (AnimalHandBook)handBookCommonItemData.Config;
		if (handBookCommonItemData.IsNew)
		{
			ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest(EHandBookTabType.Animal, animalHandBook.Id);
		}
		base.SetLockState(false);
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Animal, animalHandBook.Id);
		if (handBookInfo != null)
		{
			base.SetDateText(handBookInfo.CreateTime);
		}
		if (handBookCommonItemData.IsNew)
		{
			ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest(EHandBookTabType.Animal, animalHandBook.Id);
		}
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(animalHandBook.Name, null);
		base.SetNameText(localTextNew);
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(animalHandBook.Descrtption, null);
		base.SetTypeText(localTextNew2);
		this.RefreshInfoItemLayout(animalHandBook);
		this.RefreshDropItem(animalHandBook);
		ControllerBase<HandBookController>.Instance.SetAnimalMeshShow(animalHandBook.Id, this.SkeletalObserverHandle);
	}

	// Token: 0x0600E4F5 RID: 58613 RVA: 0x003DD670 File Offset: 0x003DB870
	protected void RefreshCollectText()
	{
		int[] collectProgress = ControllerBase<HandBookController>.Instance.GetCollectProgress(EHandBookTabType.Animal);
		base.SetCollectText(collectProgress[0], collectProgress[1]);
	}

	// Token: 0x0600E4F6 RID: 58614 RVA: 0x003DD698 File Offset: 0x003DB898
	protected void RefreshLockText()
	{
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("AnimalHandBookLock");
		base.SetLockText(textById);
	}

	// Token: 0x0600E4F7 RID: 58615 RVA: 0x003DD6BC File Offset: 0x003DB8BC
	protected void RefreshDropItem(AnimalHandBook animalHandBook)
	{
		List<TItem> list = new List<TItem>();
		int[] dropItemIdArray = animalHandBook.GetDropItemIdArray();
		int num = dropItemIdArray.Length;
		for (int i = 0; i < num; i++)
		{
			int itemId = dropItemIdArray[i];
			TItem item = new TItem(new InventoryDefine.GetItemData(itemId, 0), 0);
			list.Add(item);
		}
	}

	// Token: 0x0600E4F8 RID: 58616 RVA: 0x003DD704 File Offset: 0x003DB904
	protected void RefreshInfoItemLayout(AnimalHandBook handBookConfig)
	{
		List<string> list = new List<string>();
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(handBookConfig.TypeDescrtption, null);
		list.Add(localTextNew);
		base.InitInfoItemLayout(list);
	}

	// Token: 0x0600E4F9 RID: 58617 RVA: 0x003DD733 File Offset: 0x003DB933
	private void OnHandBookDataUpdate(EHandBookTabType eHandBookTabType, int i)
	{
		this.Refresh();
	}

	// Token: 0x0600E4FA RID: 58618 RVA: 0x003DD73C File Offset: 0x003DB93C
	protected void Refresh()
	{
		this.ConfigList = ConfigBase<HandBookConfig>.Instance.GetAnimalHandBookConfigList();
		List<HandBookCommonItemData> list = new List<HandBookCommonItemData>();
		int count = this.ConfigList.Count;
		for (int i = 0; i < count; i++)
		{
			AnimalHandBook animalHandBook = this.ConfigList[i];
			HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Animal, animalHandBook.Id);
			bool isLock = handBookInfo == null;
			bool isNew = handBookInfo != null && !handBookInfo.IsRead;
			list.Add(new HandBookCommonItemData
			{
				Icon = animalHandBook.Icon,
				Config = animalHandBook,
				IsLock = isLock,
				IsNew = isNew
			});
		}
		this.HandBookCommonItemList = new List<HandBookCommonItem>();
		base.InitScrollViewByCommonItem(list);
		HandBookEntrance value = ConfigBase<HandBookConfig>.Instance.GetHandBookEntranceConfig(EHandBookTabType.Animal).Value;
		base.InitCommonTabTitle(value.TitleIcon, new CommonTabTitleData(value.Name, Array.Empty<object>()));
		this.RefreshCollectText();
	}

	// Token: 0x0600E4FB RID: 58619 RVA: 0x003DD840 File Offset: 0x003DBA40
	protected void OnHandBookRead(EHandBookTabType type, int id)
	{
		if (type != EHandBookTabType.Animal)
		{
			return;
		}
		int count = this.HandBookCommonItemList.Count;
		for (int i = 0; i < count; i++)
		{
			HandBookCommonItem handBookCommonItem = this.HandBookCommonItemList[i];
			if (((AnimalHandBook)handBookCommonItem.GetData().Config).Id == id)
			{
				handBookCommonItem.SetNewFlagVisible(new bool?(false));
				return;
			}
		}
	}

	// Token: 0x0600E4FC RID: 58620 RVA: 0x003DD89F File Offset: 0x003DBA9F
	protected override void OnBeforePlayCloseSequence()
	{
		Singleton<UiCameraAnimationManager>.Instance.PopCameraHandle(this.UiCameraHandleData, null);
	}

	// Token: 0x0600E4FD RID: 58621 RVA: 0x003DD8B2 File Offset: 0x003DBAB2
	protected override void OnBeforeCreate()
	{
		Singleton<UiSceneManager>.Instance.InitHandBookObserver();
		this.SkeletalObserverHandle = Singleton<UiSceneManager>.Instance.GetHandBookObserver();
	}

	// Token: 0x0600E4FE RID: 58622 RVA: 0x003DD8CE File Offset: 0x003DBACE
	protected override void OnBeforeDestroy()
	{
		Singleton<UiSceneManager>.Instance.DestroyHandBookObserver();
		this.SkeletalObserverHandle = null;
		ControllerBase<HandBookController>.Instance.ClearEffect();
		this.ConfigList = new List<AnimalHandBook>();
		this.HandBookCommonItemList = new List<HandBookCommonItem>();
	}

	// Token: 0x04006E11 RID: 28177
	private IReadOnlyList<AnimalHandBook> ConfigList;

	// Token: 0x04006E12 RID: 28178
	private List<HandBookCommonItem> HandBookCommonItemList;

	// Token: 0x04006E13 RID: 28179
	[Nullable(2)]
	private UiCameraHandleData UiCameraHandleData;

	// Token: 0x04006E14 RID: 28180
	[Nullable(2)]
	private SkeletalObserverHandle SkeletalObserverHandle;
}
