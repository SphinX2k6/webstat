using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D44 RID: 7492
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleArrowCollectionSelectView : UiViewBase
{
	// Token: 0x0600DCCC RID: 56524 RVA: 0x003B5746 File Offset: 0x003B3946
	public MotorcycleArrowCollectionSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600DCCD RID: 56525 RVA: 0x003B5768 File Offset: 0x003B3968
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIMultiTemplateScrollViewComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x0600DCCE RID: 56526 RVA: 0x003B581C File Offset: 0x003B3A1C
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleArrowCollectionSelectView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleArrowCollectionSelectView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCCF RID: 56527 RVA: 0x003B5860 File Offset: 0x003B3A60
	protected override void OnBeforeShow()
	{
		this.SequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
		this.UpdateData(false);
	}

	// Token: 0x0600DCD0 RID: 56528 RVA: 0x003B5891 File Offset: 0x003B3A91
	protected override void OnAfterDestroy()
	{
		this.ViewModel.OnViewClose();
	}

	// Token: 0x0600DCD1 RID: 56529 RVA: 0x003B58A0 File Offset: 0x003B3AA0
	private void InitScrollViewData()
	{
		List<int> sortedMotorFightItemTypeList = this.ViewModel.GetSortedMotorFightItemTypeList();
		for (int i = 0; i < sortedMotorFightItemTypeList.Count; i++)
		{
			int num = sortedMotorFightItemTypeList[i];
			CollectionTypeItemData collectionTypeItemData = new CollectionTypeItemData();
			collectionTypeItemData.Data = ConfigBase<MotorcycleArrowConfig>.Instance.GetCollectionTypeConfigById(num).Value;
			this.ScrollDataList.Add(collectionTypeItemData);
			List<MotorcycleArrowCollectionItemData> motorFightItemDataListByType = this.ViewModel.GetMotorFightItemDataListByType(num);
			if (motorFightItemDataListByType != null)
			{
				for (int j = 0; j < motorFightItemDataListByType.Count; j++)
				{
					MotorcycleArrowCollectionItemData data = motorFightItemDataListByType[j];
					CollectionGridItemData collectionGridItemData = new CollectionGridItemData();
					collectionGridItemData.Data = data;
					collectionGridItemData.OnClickCb = new Action<MotorcycleArrowCollectionItemData, CollectionGridItem>(this.OnItemClick);
					this.ScrollDataList.Add(collectionGridItemData);
				}
			}
		}
	}

	// Token: 0x0600DCD2 RID: 56530 RVA: 0x003B5967 File Offset: 0x003B3B67
	public void OnBtnClose()
	{
		if (this.ViewModel.CollectionList.Count <= 0)
		{
			this.CloseMeWithCallBack();
		}
	}

	// Token: 0x0600DCD3 RID: 56531 RVA: 0x003B5984 File Offset: 0x003B3B84
	private UniTask CreateCollectionSelectPanel()
	{
		MotorcycleArrowCollectionSelectView.<CreateCollectionSelectPanel>d__19 <CreateCollectionSelectPanel>d__;
		<CreateCollectionSelectPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateCollectionSelectPanel>d__.<>4__this = this;
		<CreateCollectionSelectPanel>d__.<>1__state = -1;
		<CreateCollectionSelectPanel>d__.<>t__builder.Start<MotorcycleArrowCollectionSelectView.<CreateCollectionSelectPanel>d__19>(ref <CreateCollectionSelectPanel>d__);
		return <CreateCollectionSelectPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCD4 RID: 56532 RVA: 0x003B59C7 File Offset: 0x003B3BC7
	private void OnItemClick(MotorcycleArrowCollectionItemData data, CollectionGridItem item)
	{
		item.SetToggleState(false);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleArrowCollectionTipsView, data, null);
	}

	// Token: 0x0600DCD5 RID: 56533 RVA: 0x003B59E1 File Offset: 0x003B3BE1
	public void OnClickRefreshBuff()
	{
		this.RequestUpdateCollectionListAsync().Forget();
	}

	// Token: 0x0600DCD6 RID: 56534 RVA: 0x003B59F0 File Offset: 0x003B3BF0
	private UniTask RequestUpdateCollectionListAsync()
	{
		MotorcycleArrowCollectionSelectView.<RequestUpdateCollectionListAsync>d__22 <RequestUpdateCollectionListAsync>d__;
		<RequestUpdateCollectionListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestUpdateCollectionListAsync>d__.<>4__this = this;
		<RequestUpdateCollectionListAsync>d__.<>1__state = -1;
		<RequestUpdateCollectionListAsync>d__.<>t__builder.Start<MotorcycleArrowCollectionSelectView.<RequestUpdateCollectionListAsync>d__22>(ref <RequestUpdateCollectionListAsync>d__);
		return <RequestUpdateCollectionListAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCD7 RID: 56535 RVA: 0x003B5A33 File Offset: 0x003B3C33
	public void OnClickBtnSure()
	{
		if (this.ViewModel.CollectionList.Count <= 0)
		{
			this.CloseMeWithCallBack();
			return;
		}
		this.SureBuffSelect().Forget();
	}

	// Token: 0x0600DCD8 RID: 56536 RVA: 0x003B5A5C File Offset: 0x003B3C5C
	public UniTask SureBuffSelect()
	{
		MotorcycleArrowCollectionSelectView.<SureBuffSelect>d__24 <SureBuffSelect>d__;
		<SureBuffSelect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SureBuffSelect>d__.<>4__this = this;
		<SureBuffSelect>d__.<>1__state = -1;
		<SureBuffSelect>d__.<>t__builder.Start<MotorcycleArrowCollectionSelectView.<SureBuffSelect>d__24>(ref <SureBuffSelect>d__);
		return <SureBuffSelect>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCD9 RID: 56537 RVA: 0x003B5AA0 File Offset: 0x003B3CA0
	public void UpdateData(bool bRefresh)
	{
		List<MotorcycleArrowCollectionItemData> collectionList = this.ViewModel.CollectionList;
		this.ViewModel.SetSelectCollectionItem(null);
		for (int i = 0; i < this.CollectionItemList.Count; i++)
		{
			MotorcycleArrowCollectionItem motorcycleArrowCollectionItem = this.CollectionItemList[i];
			MotorcycleArrowCollectionItemData motorcycleArrowCollectionItemData = (i < collectionList.Count) ? collectionList[i] : null;
			motorcycleArrowCollectionItem.SetActive(motorcycleArrowCollectionItemData != null);
			if (motorcycleArrowCollectionItemData != null)
			{
				motorcycleArrowCollectionItem.UpdateData(motorcycleArrowCollectionItemData, bRefresh);
				motorcycleArrowCollectionItem.SetSelect(false);
			}
		}
		this.UpdateSureBtnEnable();
		this.UpdateRefreshBtn();
	}

	// Token: 0x0600DCDA RID: 56538 RVA: 0x003B5B24 File Offset: 0x003B3D24
	public void UpdateSureBtnEnable()
	{
		bool enableClick = this.ViewModel.CurSelectCollectionItem != null || this.ViewModel.CollectionList.Count <= 0;
		ButtonItem confirmButton = this.ConfirmButton;
		if (confirmButton == null)
		{
			return;
		}
		confirmButton.SetEnableClick(enableClick);
	}

	// Token: 0x0600DCDB RID: 56539 RVA: 0x003B5B6C File Offset: 0x003B3D6C
	public void UpdateRefreshBtn()
	{
		bool enableClick = this.ViewModel.RemainRefreshCount > 0;
		ButtonItem refreshButton = this.RefreshButton;
		if (refreshButton != null)
		{
			refreshButton.SetLocalTextNew("PrefabTextItem_1210882995_Text", new object[]
			{
				this.ViewModel.RemainRefreshCount,
				this.ViewModel.MaxRefreshCount
			});
		}
		ButtonItem refreshButton2 = this.RefreshButton;
		if (refreshButton2 == null)
		{
			return;
		}
		refreshButton2.SetEnableClick(enableClick);
	}

	// Token: 0x0600DCDC RID: 56540 RVA: 0x003B5BDC File Offset: 0x003B3DDC
	public void UpdateCollectionPanelSelectState()
	{
		MotorcycleArrowCollectionItemData curSelectCollectionItem = this.ViewModel.CurSelectCollectionItem;
		for (int i = 0; i < this.CollectionItemList.Count; i++)
		{
			MotorcycleArrowCollectionItem motorcycleArrowCollectionItem = this.CollectionItemList[i];
			motorcycleArrowCollectionItem.SetSelect(curSelectCollectionItem == motorcycleArrowCollectionItem.CollectionData);
		}
	}

	// Token: 0x0600DCDD RID: 56541 RVA: 0x003B5C27 File Offset: 0x003B3E27
	public void OnSelectCollection(MotorcycleArrowCollectionItemData data)
	{
		this.ViewModel.SetSelectCollectionItem(data);
		this.UpdateCollectionPanelSelectState();
		this.UpdateSureBtnEnable();
	}

	// Token: 0x0600DCDE RID: 56542 RVA: 0x003B5C41 File Offset: 0x003B3E41
	public void UpdateCollectionEmptyState()
	{
		this.CollectionEmpty.SetUIActive(this.ViewModel.IsMotorFightItemEmpty());
	}

	// Token: 0x0600DCDF RID: 56543 RVA: 0x003B5C59 File Offset: 0x003B3E59
	public void CloseMeWithCallBack()
	{
		base.CloseMe(delegate(bool success)
		{
			if (success)
			{
				this.ViewModel.OnViewClose();
			}
		});
	}

	// Token: 0x040069B6 RID: 27062
	public MotorcycleArrowCollectionSelectViewModel ViewModel;

	// Token: 0x040069B7 RID: 27063
	public PopupCaptionItem PopupCaption;

	// Token: 0x040069B8 RID: 27064
	public UUIItem CollectionListParent;

	// Token: 0x040069B9 RID: 27065
	public List<MotorcycleArrowCollectionItem> CollectionItemList = new List<MotorcycleArrowCollectionItem>();

	// Token: 0x040069BA RID: 27066
	public UUIItem CollectionItem;

	// Token: 0x040069BB RID: 27067
	public ButtonItem RefreshButton;

	// Token: 0x040069BC RID: 27068
	public ButtonItem ConfirmButton;

	// Token: 0x040069BD RID: 27069
	[Nullable(2)]
	private MultiTemplateScrollView ItemMultiTemplateScrollView;

	// Token: 0x040069BE RID: 27070
	public UUIItem CollectionEmpty;

	// Token: 0x040069BF RID: 27071
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x040069C0 RID: 27072
	private readonly List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

	// Token: 0x020080DB RID: 32987
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BD23 RID: 179491
		public const int CaptionItem = 0;

		// Token: 0x0402BD24 RID: 179492
		public const int CollectionSelectList = 1;

		// Token: 0x0402BD25 RID: 179493
		public const int CollectionItem = 2;

		// Token: 0x0402BD26 RID: 179494
		public const int RefreshItem = 3;

		// Token: 0x0402BD27 RID: 179495
		public const int SelectItem = 4;

		// Token: 0x0402BD28 RID: 179496
		public const int CollectionBagList = 5;

		// Token: 0x0402BD29 RID: 179497
		public const int CollectionEmpty = 6;
	}
}
