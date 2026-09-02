using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001EB2 RID: 7858
[NullableContext(1)]
[Nullable(0)]
public class WeaponHandBookView : UiViewBase
{
	// Token: 0x0600E85E RID: 59486 RVA: 0x003ECF23 File Offset: 0x003EB123
	public WeaponHandBookView(UiViewInfo viewInfo) : base(viewInfo)
	{
		this.WeaponIdList = new List<int>();
		this.WeaponSkinIdList = new List<int>();
	}

	// Token: 0x0600E85F RID: 59487 RVA: 0x003ECF50 File Offset: 0x003EB150
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIDynScrollViewComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(14, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(13, new Action<EToggleState>(this.EnterInternalView)),
			new ValueTuple<int, Delegate>(14, new Action<EToggleState>(this.OnFullToggleClick))
		};
	}

	// Token: 0x0600E860 RID: 59488 RVA: 0x003ED13C File Offset: 0x003EB33C
	private UniTask InitCaptionItemAsync()
	{
		WeaponHandBookView.<InitCaptionItemAsync>d__18 <InitCaptionItemAsync>d__;
		<InitCaptionItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCaptionItemAsync>d__.<>4__this = this;
		<InitCaptionItemAsync>d__.<>1__state = -1;
		<InitCaptionItemAsync>d__.<>t__builder.Start<WeaponHandBookView.<InitCaptionItemAsync>d__18>(ref <InitCaptionItemAsync>d__);
		return <InitCaptionItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E861 RID: 59489 RVA: 0x003ED180 File Offset: 0x003EB380
	private UniTask InitWeaponDetailTipsViewAsync()
	{
		WeaponHandBookView.<InitWeaponDetailTipsViewAsync>d__19 <InitWeaponDetailTipsViewAsync>d__;
		<InitWeaponDetailTipsViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitWeaponDetailTipsViewAsync>d__.<>4__this = this;
		<InitWeaponDetailTipsViewAsync>d__.<>1__state = -1;
		<InitWeaponDetailTipsViewAsync>d__.<>t__builder.Start<WeaponHandBookView.<InitWeaponDetailTipsViewAsync>d__19>(ref <InitWeaponDetailTipsViewAsync>d__);
		return <InitWeaponDetailTipsViewAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E862 RID: 59490 RVA: 0x003ED1C4 File Offset: 0x003EB3C4
	private UniTask InitWeaponGenericLayoutAsync()
	{
		WeaponHandBookView.<InitWeaponGenericLayoutAsync>d__20 <InitWeaponGenericLayoutAsync>d__;
		<InitWeaponGenericLayoutAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitWeaponGenericLayoutAsync>d__.<>4__this = this;
		<InitWeaponGenericLayoutAsync>d__.<>1__state = -1;
		<InitWeaponGenericLayoutAsync>d__.<>t__builder.Start<WeaponHandBookView.<InitWeaponGenericLayoutAsync>d__20>(ref <InitWeaponGenericLayoutAsync>d__);
		return <InitWeaponGenericLayoutAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E863 RID: 59491 RVA: 0x003ED208 File Offset: 0x003EB408
	protected override UniTask OnBeforeStartAsync()
	{
		WeaponHandBookView.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeaponHandBookView.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E864 RID: 59492 RVA: 0x003ED24C File Offset: 0x003EB44C
	protected override void OnStart()
	{
		ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.WeaponLevelUpView);
		this.WeaponIdList = ModelBase<HandBookModel>.Instance.GetAllHandBookWeaponIdList().ToList<int>();
		this.WeaponSkinIdList = ModelBase<HandBookModel>.Instance.GetAllHandBookWeaponSkinIdList().ToList<int>();
		GenericScrollViewNew<HandBookTab, int> tabScrollview = this.TabScrollview;
		if (tabScrollview == null)
		{
			return;
		}
		tabScrollview.RefreshByData(new List<int>
		{
			0,
			1
		}, delegate
		{
			GenericScrollViewNew<HandBookTab, int> tabScrollview2 = this.TabScrollview;
			if (tabScrollview2 == null)
			{
				return;
			}
			HandBookTab scrollItemByIndex = tabScrollview2.GetScrollItemByIndex(0);
			if (scrollItemByIndex == null)
			{
				return;
			}
			scrollItemByIndex.SelectToggle();
		}, false);
	}

	// Token: 0x0600E865 RID: 59493 RVA: 0x003ED2BE File Offset: 0x003EB4BE
	private WeaponHandBookItem CreateNodeGrid(WeaponHandBookDynamicData data, UUIItem uiItem, int index)
	{
		return new WeaponHandBookItem
		{
			OnClickCallBack = new Action<UUIExtendToggle, int>(this.OnClickWeaponItemCallBack)
		};
	}

	// Token: 0x0600E866 RID: 59494 RVA: 0x003ED2D7 File Offset: 0x003EB4D7
	private HandBookTab InitTabItem()
	{
		return new HandBookTab
		{
			OnClickCallBack = new Action<UUIExtendToggle, int>(this.OnClickTabCallBack)
		};
	}

	// Token: 0x0600E867 RID: 59495 RVA: 0x003ED2F0 File Offset: 0x003EB4F0
	private void OnFilterUpdate(List<int> list, bool isOutSideChange, EFilterSortType OperationType)
	{
		if (list == null || list.Count <= 0)
		{
			base.GetUIDynScrollViewComponent(6).RootUIComp.Get().SetUIActive(false);
			return;
		}
		base.GetUIDynScrollViewComponent(6).RootUIComp.Get().SetUIActive(true);
		Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
		if (this.CurrentShowType == 0)
		{
			foreach (int itemId in list)
			{
				WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(itemId);
				if (weaponConfigByItemId != null)
				{
					if (!dictionary.ContainsKey(weaponConfigByItemId.Value.WeaponType))
					{
						dictionary[weaponConfigByItemId.Value.WeaponType] = new List<int>();
					}
					dictionary[weaponConfigByItemId.Value.WeaponType].Add(weaponConfigByItemId.Value.ItemId);
				}
			}
		}
		if (this.CurrentShowType == 1)
		{
			foreach (int id in list)
			{
				WeaponSkin weaponSkinConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponSkinConfig(id);
				if (!dictionary.ContainsKey(weaponSkinConfig.WeaponSkinType))
				{
					dictionary[weaponSkinConfig.WeaponSkinType] = new List<int>();
				}
				dictionary[weaponSkinConfig.WeaponSkinType].Add(weaponSkinConfig.Id);
			}
		}
		List<WeaponHandBookDynamicData> list2 = new List<WeaponHandBookDynamicData>();
		bool isSkin = this.CurrentShowType == 1;
		List<int> list3 = new List<int>(dictionary.Keys);
		list3.Sort((int a, int b) => a - b);
		foreach (int num in list3)
		{
			List<int> list4 = dictionary[num];
			WeaponHandBookDynamicData weaponHandBookDynamicData = new WeaponHandBookDynamicData();
			list2.Add(weaponHandBookDynamicData);
			weaponHandBookDynamicData.TitleId = (ConfigBase<WeaponConfig>.Instance.GetWeaponTypeName(num) ?? "");
			WeaponHandBookDynamicData weaponHandBookDynamicData2 = new WeaponHandBookDynamicData();
			List<WeaponHandBookDynamicLayoutItemData> list5 = new List<WeaponHandBookDynamicLayoutItemData>();
			foreach (int value in list4)
			{
				list5.Add(new WeaponHandBookDynamicLayoutItemData
				{
					IsSkin = isSkin,
					ItemId = new int?(value)
				});
			}
			weaponHandBookDynamicData2.ItemData = list5;
			list2.Add(weaponHandBookDynamicData2);
		}
		if (list2.Count <= 0)
		{
			this.RefeshView();
			return;
		}
		HandBookModel instance = ModelBase<HandBookModel>.Instance;
		WeaponHandBookDynamicData weaponHandBookDynamicData3 = list2.ElementAtOrDefault(1);
		int? num2;
		if (weaponHandBookDynamicData3 == null)
		{
			num2 = null;
		}
		else
		{
			List<WeaponHandBookDynamicLayoutItemData> itemData = weaponHandBookDynamicData3.ItemData;
			if (itemData == null)
			{
				num2 = null;
			}
			else
			{
				WeaponHandBookDynamicLayoutItemData weaponHandBookDynamicLayoutItemData = itemData.ElementAtOrDefault(0);
				num2 = ((weaponHandBookDynamicLayoutItemData != null) ? weaponHandBookDynamicLayoutItemData.ItemId : null);
			}
		}
		int? num3 = num2;
		instance.CurrentSelectWeaponHandBookId = num3.GetValueOrDefault();
		DynamicScrollView<WeaponHandBookItem, WeaponHandBookDynamicItem, WeaponHandBookDynamicData> weaponGenericLayout = this.WeaponGenericLayout;
		if (weaponGenericLayout == null)
		{
			return;
		}
		weaponGenericLayout.RefreshByData(list2.ToArray(), false, false);
	}

	// Token: 0x0600E868 RID: 59496 RVA: 0x003ED640 File Offset: 0x003EB840
	private void RefeshView()
	{
		if (this.CurrentShowType == 0)
		{
			base.GetItem(9).SetUIActive(true);
			base.GetItem(10).SetUIActive(false);
			this.RefeshWeaponView();
		}
		if (this.CurrentShowType == 1)
		{
			base.GetItem(9).SetUIActive(false);
			base.GetItem(10).SetUIActive(true);
			this.RefeshWeaponSkinView();
		}
	}

	// Token: 0x0600E869 RID: 59497 RVA: 0x003ED6A4 File Offset: 0x003EB8A4
	private void RefeshWeaponView()
	{
		if (this.CurrentId == 0)
		{
			return;
		}
		if (ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(this.CurrentId) == null)
		{
			return;
		}
		base.GetItem(17).SetUIActive(true);
		WeaponTrialData curData = (this.CurrentShowType == 0 && base.GetExtendToggle(14).GetToggleState() == EToggleState.ETT_Checked) ? this.TrialWeaponData.GetFullLevelWeaponData() : this.TrialWeaponData;
		this.UpdateWeaponDetail(curData);
		int num = ModelBase<HandBookModel>.Instance.GetAllHandBookWeaponIdList().Length;
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.SetText(num.ToString(), true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "WeaponHandBook_Weapon_Name", Array.Empty<object>());
	}

	// Token: 0x0600E86A RID: 59498 RVA: 0x003ED75D File Offset: 0x003EB95D
	private void UpdateWeaponDetail(WeaponTrialData curData)
	{
		this.WeaponDetailTipsView.UpdateComponent(curData);
	}

	// Token: 0x0600E86B RID: 59499 RVA: 0x003ED76C File Offset: 0x003EB96C
	private void RefeshWeaponSkinView()
	{
		if (this.CurrentId == 0)
		{
			return;
		}
		WeaponSkin weaponSkinConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponSkinConfig(this.CurrentId);
		base.GetItem(17).SetUIActive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), weaponSkinConfig.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), weaponSkinConfig.BgDescription, Array.Empty<object>());
		int num = ModelBase<HandBookModel>.Instance.GetAllHandBookWeaponSkinIdList().Length;
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.SetText(num.ToString(), true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "WeaponHandBook_WeaponSkin_Name", Array.Empty<object>());
	}

	// Token: 0x0600E86C RID: 59500 RVA: 0x003ED820 File Offset: 0x003EBA20
	private void OnClickWeaponItemCallBack(UUIExtendToggle toggle, int id)
	{
		if (this.CurrentWeaponToggle != toggle)
		{
			UUIExtendToggle currentWeaponToggle = this.CurrentWeaponToggle;
			if (currentWeaponToggle != null)
			{
				currentWeaponToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			}
		}
		this.CurrentWeaponToggle = toggle;
		if (this.CurrentId == id)
		{
			return;
		}
		this.ChangeWeapon(new int?(id));
		ModelBase<HandBookModel>.Instance.CurrentSelectWeaponHandBookId = id;
		this.CurrentId = id;
		this.RefeshView();
		this.ReadWeaponHandBook(id);
	}

	// Token: 0x0600E86D RID: 59501 RVA: 0x003ED888 File Offset: 0x003EBA88
	private void ChangeWeapon(int? id = null)
	{
		int skinId = -1;
		if (this.CurrentShowType == 0 && id != null && id.GetValueOrDefault() != 0)
		{
			WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(id.Value);
			this.TrialWeaponData.SetTrialId(weaponConfigByItemId.Value.HandBookTrialId, true);
		}
		if (this.CurrentShowType == 1 && id != null && id.GetValueOrDefault() != 0)
		{
			WeaponSkin weaponSkinConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponSkinConfig(id.Value);
			this.TrialWeaponData.SetTrialId(weaponSkinConfig.HandBookTrialId, true);
			skinId = id.Value;
		}
		WeaponTrialData weaponInstance = (this.CurrentShowType == 0 && base.GetExtendToggle(14).GetToggleState() == EToggleState.ETT_Checked) ? this.TrialWeaponData.GetFullLevelWeaponData() : this.TrialWeaponData;
		ControllerBase<WeaponController>.Instance.OnSelectedWeaponChange(weaponInstance, this.WeaponObserver, this.WeaponScabbardObserver, skinId, this.NeedMeshStreaming);
	}

	// Token: 0x0600E86E RID: 59502 RVA: 0x003ED978 File Offset: 0x003EBB78
	private void OnClickTabCallBack(UUIExtendToggle toggle, int type)
	{
		UUIExtendToggle currentTabToggle = this.CurrentTabToggle;
		if (currentTabToggle != null)
		{
			currentTabToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentTabToggle = toggle;
		this.CurrentShowType = type;
		if (type == 0)
		{
			FilterSortEntrance<int> filterBtn = this.FilterBtn;
			if (filterBtn != null)
			{
				filterBtn.ClearData(EFilterSortGroupId.WeaponSkinHandBook);
			}
			FilterSortEntrance<int> filterBtn2 = this.FilterBtn;
			if (filterBtn2 != null)
			{
				filterBtn2.UpdateData(EFilterSortGroupId.WeaponHandBook, this.WeaponIdList, Array.Empty<object>());
			}
		}
		if (type == 1)
		{
			FilterSortEntrance<int> filterBtn3 = this.FilterBtn;
			if (filterBtn3 != null)
			{
				filterBtn3.ClearData(EFilterSortGroupId.WeaponHandBook);
			}
			FilterSortEntrance<int> filterBtn4 = this.FilterBtn;
			if (filterBtn4 == null)
			{
				return;
			}
			filterBtn4.UpdateData(EFilterSortGroupId.WeaponSkinHandBook, this.WeaponSkinIdList, Array.Empty<object>());
		}
	}

	// Token: 0x0600E86F RID: 59503 RVA: 0x003EDA10 File Offset: 0x003EBC10
	private void EnterInternalView(EToggleState toggleState)
	{
		if (this.IsInternal)
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.PlaySequence("Off", false, null);
			}
			base.GetItem(15).SetUIActive(true);
			base.GetItem(2).SetUIActive(true);
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SetUiActive(true);
			}
			this.RefeshView();
			this.IsInternal = false;
			return;
		}
		UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
		if (uiViewSequence2 != null)
		{
			uiViewSequence2.PlaySequence("On", false, null);
		}
		base.GetItem(15).SetUIActive(false);
		base.GetItem(2).SetUIActive(false);
		base.GetItem(9).SetUIActive(false);
		base.GetItem(10).SetUIActive(false);
		PopupCaptionItem captionItem2 = this.CaptionItem;
		if (captionItem2 != null)
		{
			captionItem2.SetUiActive(false);
		}
		this.IsInternal = true;
	}

	// Token: 0x0600E870 RID: 59504 RVA: 0x003EDAF0 File Offset: 0x003EBCF0
	private void OnFullToggleClick(EToggleState toggleState)
	{
		this.ChangeWeapon(null);
		this.RefeshView();
	}

	// Token: 0x0600E871 RID: 59505 RVA: 0x003EDB14 File Offset: 0x003EBD14
	protected override void OnBeforeDestroy()
	{
		Singleton<UiSceneManager>.Instance.DestroyWeaponObserver(this.WeaponObserver);
		this.WeaponObserver = null;
		Singleton<UiSceneManager>.Instance.DestroyWeaponScabbardObserver(this.WeaponScabbardObserver);
		this.WeaponScabbardObserver = null;
		ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.None);
		FilterSortEntrance<int> filterBtn = this.FilterBtn;
		if (filterBtn != null)
		{
			filterBtn.ClearData(EFilterSortGroupId.WeaponHandBook);
		}
		FilterSortEntrance<int> filterBtn2 = this.FilterBtn;
		if (filterBtn2 == null)
		{
			return;
		}
		filterBtn2.ClearData(EFilterSortGroupId.WeaponSkinHandBook);
	}

	// Token: 0x0600E872 RID: 59506 RVA: 0x003EDB80 File Offset: 0x003EBD80
	private void ReadWeaponHandBook(int handBookId)
	{
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Weapon, handBookId);
		if (handBookInfo == null)
		{
			return;
		}
		if (!handBookInfo.IsRead)
		{
			ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest(EHandBookTabType.Weapon, handBookId);
		}
	}

	// Token: 0x04006FF0 RID: 28656
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04006FF1 RID: 28657
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<WeaponHandBookItem, WeaponHandBookDynamicItem, WeaponHandBookDynamicData> WeaponGenericLayout;

	// Token: 0x04006FF2 RID: 28658
	[Nullable(2)]
	private WeaponHandBookDynamicItem WeaponBaseItem;

	// Token: 0x04006FF3 RID: 28659
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<HandBookTab, int> TabScrollview;

	// Token: 0x04006FF4 RID: 28660
	[Nullable(2)]
	private FilterSortEntrance<int> FilterBtn;

	// Token: 0x04006FF5 RID: 28661
	private List<int> WeaponIdList;

	// Token: 0x04006FF6 RID: 28662
	private List<int> WeaponSkinIdList;

	// Token: 0x04006FF7 RID: 28663
	[Nullable(2)]
	private UUIExtendToggle CurrentTabToggle;

	// Token: 0x04006FF8 RID: 28664
	[Nullable(2)]
	private UUIExtendToggle CurrentWeaponToggle;

	// Token: 0x04006FF9 RID: 28665
	private int CurrentShowType;

	// Token: 0x04006FFA RID: 28666
	[Nullable(2)]
	private SkeletalObserverHandle WeaponObserver;

	// Token: 0x04006FFB RID: 28667
	[Nullable(2)]
	private SkeletalObserverHandle WeaponScabbardObserver;

	// Token: 0x04006FFC RID: 28668
	[Nullable(2)]
	private WeaponDetailTipsComponent WeaponDetailTipsView;

	// Token: 0x04006FFD RID: 28669
	private int CurrentId;

	// Token: 0x04006FFE RID: 28670
	private readonly bool NeedMeshStreaming;

	// Token: 0x04006FFF RID: 28671
	private readonly WeaponTrialData TrialWeaponData = new WeaponTrialData();

	// Token: 0x04007000 RID: 28672
	private bool IsInternal;

	// Token: 0x020081F2 RID: 33266
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402C152 RID: 180562
		public const int CaptionItem = 0;

		// Token: 0x0402C153 RID: 180563
		public const int TabScrollView = 1;

		// Token: 0x0402C154 RID: 180564
		public const int TabItem = 2;

		// Token: 0x0402C155 RID: 180565
		public const int DragItem = 3;

		// Token: 0x0402C156 RID: 180566
		public const int CollectText = 4;

		// Token: 0x0402C157 RID: 180567
		public const int CollectNumText = 5;

		// Token: 0x0402C158 RID: 180568
		public const int WeaponScrollView = 6;

		// Token: 0x0402C159 RID: 180569
		public const int WeaponScrollItem = 7;

		// Token: 0x0402C15A RID: 180570
		public const int SortFilterItem = 8;

		// Token: 0x0402C15B RID: 180571
		public const int WeaponDetailsItem = 9;

		// Token: 0x0402C15C RID: 180572
		public const int SkinDetailsItem = 10;

		// Token: 0x0402C15D RID: 180573
		public const int SkinTitleText = 11;

		// Token: 0x0402C15E RID: 180574
		public const int SkinDesText = 12;

		// Token: 0x0402C15F RID: 180575
		public const int CheckToggle = 13;

		// Token: 0x0402C160 RID: 180576
		public const int FullLevelToggle = 14;

		// Token: 0x0402C161 RID: 180577
		public const int LeftItem = 15;

		// Token: 0x0402C162 RID: 180578
		public const int RightItem = 16;

		// Token: 0x0402C163 RID: 180579
		public const int FullLevelToggleRootItem = 17;
	}
}
