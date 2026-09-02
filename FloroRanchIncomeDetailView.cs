using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.FloroRanch;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C34 RID: 7220
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchIncomeDetailView : UiViewBase
{
	// Token: 0x0600D248 RID: 53832 RVA: 0x0037E640 File Offset: 0x0037C840
	public FloroRanchIncomeDetailView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D249 RID: 53833 RVA: 0x0037E670 File Offset: 0x0037C870
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnCloseButtonClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.OnToggleCheckClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnToggleOrderClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnCloseButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D24A RID: 53834 RVA: 0x0037E8D0 File Offset: 0x0037CAD0
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchIncomeDetailView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchIncomeDetailView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D24B RID: 53835 RVA: 0x0037E913 File Offset: 0x0037CB13
	private OneTextDropDownItem CreateDropDownItem(UUIItem uiItem, FloroRanchFilterType type)
	{
		return new OneTextDropDownItem(uiItem);
	}

	// Token: 0x0600D24C RID: 53836 RVA: 0x0037E91B File Offset: 0x0037CB1B
	private OneTextTitleItem CreateTitleItem(UUIItem uiItem)
	{
		return new OneTextTitleItem(uiItem);
	}

	// Token: 0x0600D24D RID: 53837 RVA: 0x0037E924 File Offset: 0x0037CB24
	protected override void OnBeforeShow()
	{
		ModelBase<FloroRanchGamePlayModel>.Instance.RefreshLastIncomeEntityList();
		this.IsShowNotPresentCard = false;
		this.IsAscending = true;
		base.GetText(2).SetText(ModelBase<FloroRanchModel>.Instance.GetCoinText(ModelBase<FloroRanchGamePlayModel>.Instance.GetLastDayIncome()), true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "Farm_ShowAllAnimal", new <>z__ReadOnlySingleElementList<object>(ModelBase<FloroRanchGamePlayModel>.Instance.OwnCardEntityCount));
		base.SetTextureByPath(ModelBase<FloroRanchModel>.Instance.GetFloroRanchCurrencyConfig(ECurrencyType.Coin).GetSmallIcon(), base.GetTexture(1), null, null);
		this.RefreshScrollViewInfo();
	}

	// Token: 0x0600D24E RID: 53838 RVA: 0x0037E9C1 File Offset: 0x0037CBC1
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnFloroRanchCardEntityCountChange, new Action(this.OnFloroRanchCardEntityCountChange));
	}

	// Token: 0x0600D24F RID: 53839 RVA: 0x0037E9DF File Offset: 0x0037CBDF
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFloroRanchCardEntityCountChange, new Action(this.OnFloroRanchCardEntityCountChange));
	}

	// Token: 0x0600D250 RID: 53840 RVA: 0x0037EA00 File Offset: 0x0037CC00
	protected override void OnStart()
	{
		IReadOnlyList<FloroRanchFilterType> floroRanchFilterTypeConfigList = ConfigBase<FloroRanchConfig>.Instance.GetFloroRanchFilterTypeConfigList();
		if (floroRanchFilterTypeConfigList.Count <= 0)
		{
			this.DropDownList.SetUiActive(false);
			return;
		}
		this.CurrentFilterData = floroRanchFilterTypeConfigList[0];
		this.DropDownList.InitScroll(floroRanchFilterTypeConfigList, new Func<FloroRanchFilterType, TableTextArgNew>(this.GetDropDownText), 0, true);
		this.DropDownList.SetShowType(ECommonDropDownShowType.Up);
		this.DropDownList.SetOnSelectCall(new Action<int, FloroRanchFilterType>(this.OnSelectFilter));
	}

	// Token: 0x0600D251 RID: 53841 RVA: 0x0037EA78 File Offset: 0x0037CC78
	private FloroRanchIncomeItem CreateIncomeItem()
	{
		FloroRanchIncomeItem floroRanchIncomeItem = new FloroRanchIncomeItem();
		floroRanchIncomeItem.BindClickCallBack(new Action<int, FloroRanchEntityBase>(this.OnIncomeItemClick));
		floroRanchIncomeItem.SetSelectState(false);
		this.IncomeItemList.Add(floroRanchIncomeItem);
		return floroRanchIncomeItem;
	}

	// Token: 0x0600D252 RID: 53842 RVA: 0x0037EAB4 File Offset: 0x0037CCB4
	private void OnIncomeItemClick(int gridIndex, FloroRanchEntityBase floroRanchEntity)
	{
		this.OnItemSelect(gridIndex);
		FloroRanchEntityDataComponent floroRanchEntityDataComponent = floroRanchEntity.CheckGetComponent<FloroRanchEntityDataComponent>();
		int point = floroRanchEntityDataComponent.Point;
		bool flag = floroRanchEntityDataComponent.IsValid && point != -1;
		if (flag)
		{
			this.ShowTips(floroRanchEntity);
		}
		else
		{
			if (point == -1)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_AnimalBehind", Array.Empty<object>());
			}
			this.HideRightInfoTip();
		}
		if (!flag || floroRanchEntity.EntityType == EFloroRanchEntityType.Toy)
		{
			Action<int> selectStateCallback = this.SelectStateCallback;
			if (selectStateCallback == null)
			{
				return;
			}
			selectStateCallback(-1);
			return;
		}
		else if (floroRanchEntityDataComponent != null && floroRanchEntityDataComponent.IsValid && flag)
		{
			Action<int> selectStateCallback2 = this.SelectStateCallback;
			if (selectStateCallback2 == null)
			{
				return;
			}
			selectStateCallback2(point);
			return;
		}
		else
		{
			Action<int> selectStateCallback3 = this.SelectStateCallback;
			if (selectStateCallback3 == null)
			{
				return;
			}
			selectStateCallback3(0);
			return;
		}
	}

	// Token: 0x0600D253 RID: 53843 RVA: 0x0037EB64 File Offset: 0x0037CD64
	private void OnItemSelect(int gridIndex)
	{
		this.RefreshIncomeItemToggleState(false, this.IncomeItemSelectIndex);
		if (gridIndex < 0 || gridIndex >= this.DataList.Count || gridIndex == this.IncomeItemSelectIndex)
		{
			this.IncomeItemSelectIndex = -1;
		}
		else
		{
			this.IncomeItemSelectIndex = gridIndex;
		}
		this.RefreshIncomeItemToggleState(true, gridIndex);
	}

	// Token: 0x0600D254 RID: 53844 RVA: 0x0037EBB1 File Offset: 0x0037CDB1
	private void CancelItemSelect()
	{
		this.OnItemSelect(-1);
		this.HideRightInfoTip();
		Action<int> selectStateCallback = this.SelectStateCallback;
		if (selectStateCallback == null)
		{
			return;
		}
		selectStateCallback(-1);
	}

	// Token: 0x0600D255 RID: 53845 RVA: 0x0037EBD4 File Offset: 0x0037CDD4
	private void SetTipType(FloroRanchEntityBase floroRanchEntity)
	{
		EFloroRanchEntityType entityType = floroRanchEntity.EntityType;
		int point = floroRanchEntity.CheckGetComponent<FloroRanchEntityDataComponent>().Point;
		switch (entityType)
		{
		case EFloroRanchEntityType.Terrain:
		{
			FloroRanchEntityBase mainEntityData = null;
			if (point != -1)
			{
				mainEntityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCardEntityByPoint(point);
			}
			this.SelectTipData.ChangeTipInfo(EFloroRanchTipType.Terrain, mainEntityData, floroRanchEntity);
			return;
		}
		case EFloroRanchEntityType.Card:
		{
			FloroRanchEntityBase subEntityData = null;
			if (point != -1)
			{
				subEntityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetTerrainEntityByPoint(point);
			}
			this.SelectTipData.ChangeTipInfo(EFloroRanchTipType.Terrain, floroRanchEntity, subEntityData);
			return;
		}
		case EFloroRanchEntityType.Toy:
			this.SelectTipData.ChangeTipInfo(EFloroRanchTipType.Toy, floroRanchEntity, null);
			return;
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "SetTipType Invalid entity type:";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityType", entityType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		}
	}

	// Token: 0x0600D256 RID: 53846 RVA: 0x0037EC8C File Offset: 0x0037CE8C
	private void ShowTips(FloroRanchEntityBase floroRanchEntity)
	{
		this.SetTipType(floroRanchEntity);
		FloroRanchEntityBase lastMainEntityData = this.SelectTipData.LastMainEntityData;
		FloroRanchEntityBase lastSubEntityData = this.SelectTipData.LastSubEntityData;
		bool mainEntityData = this.SelectTipData.MainEntityData != null;
		FloroRanchEntityBase subEntityData = this.SelectTipData.SubEntityData;
		bool lastTipType = this.SelectTipData.LastTipType != EFloroRanchTipType.None;
		EFloroRanchTipType tipType = this.SelectTipData.TipType;
		bool playAnim = !lastTipType || tipType == EFloroRanchTipType.None;
		if (mainEntityData)
		{
			this.ShowMainTip(playAnim);
		}
		else if (lastMainEntityData != null)
		{
			this.HideMainTip(playAnim);
		}
		if (subEntityData != null)
		{
			this.ShowSubTip(playAnim);
			return;
		}
		if (lastSubEntityData != null)
		{
			this.HideSubTip(playAnim);
		}
	}

	// Token: 0x0600D257 RID: 53847 RVA: 0x0037ED20 File Offset: 0x0037CF20
	private void HideSubTip(bool playAnim = true)
	{
		this.SubTipLevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
		if (!playAnim)
		{
			this.SubTipLevelSequencePlayer.EndSequenceLastFrame("Close");
			FloroRanchTerrainTipItem subTipInfoItem = this.SubTipInfoItem;
			if (subTipInfoItem == null)
			{
				return;
			}
			subTipInfoItem.SetUiActive(false);
		}
	}

	// Token: 0x0600D258 RID: 53848 RVA: 0x0037ED6C File Offset: 0x0037CF6C
	private void HideMainTip(bool playAnim = true)
	{
		this.MainTipLevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
		if (!playAnim)
		{
			this.MainTipLevelSequencePlayer.EndSequenceLastFrame("Close");
			FloroRanchCommonTipItem mainTipInfoItem = this.MainTipInfoItem;
			if (mainTipInfoItem == null)
			{
				return;
			}
			mainTipInfoItem.SetUiActive(false);
		}
	}

	// Token: 0x0600D259 RID: 53849 RVA: 0x0037EDB8 File Offset: 0x0037CFB8
	private void ShowSubTip(bool playAnim = true)
	{
		FloroRanchEntityBase subEntityData = this.SelectTipData.SubEntityData;
		this.SubTipInfoItem.RefreshInfoTipByEntity(subEntityData);
		this.SetSubTipHeight((this.SelectTipData.MainEntityData != null) ? 240 : 380);
		this.SubTipLevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		if (!playAnim)
		{
			this.SubTipLevelSequencePlayer.EndSequenceLastFrame("Start");
		}
	}

	// Token: 0x0600D25A RID: 53850 RVA: 0x0037EE30 File Offset: 0x0037D030
	private void ShowMainTip(bool playAnim = true)
	{
		FloroRanchEntityBase mainEntityData = this.SelectTipData.MainEntityData;
		FloroRanchCommonTipItem mainTipInfoItem = this.MainTipInfoItem;
		if (mainTipInfoItem != null)
		{
			mainTipInfoItem.RefreshInfoTipByParam(new FloroRanchCommonTipParam
			{
				TipType = EFloroRanchCommonTipType.Entity,
				EntityData = mainEntityData,
				RemoveCallback = new Action<FloroRanchEntityBase>(this.OnSellClick),
				CurrencyData = null
			});
		}
		this.MainTipLevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		if (!playAnim)
		{
			this.MainTipLevelSequencePlayer.EndSequenceLastFrame("Start");
		}
	}

	// Token: 0x0600D25B RID: 53851 RVA: 0x0037EEB4 File Offset: 0x0037D0B4
	private void HideRightInfoTip()
	{
		this.SelectTipData.ChangeTipInfo(EFloroRanchTipType.None, null, null);
		this.HideMainTip(true);
		this.HideSubTip(true);
	}

	// Token: 0x0600D25C RID: 53852 RVA: 0x0037EED4 File Offset: 0x0037D0D4
	private void SetSubTipHeight(int height)
	{
		FloroRanchTerrainTipItem subTipInfoItem = this.SubTipInfoItem;
		UUIItem uuiitem = (subTipInfoItem != null) ? subTipInfoItem.GetRootItem() : null;
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetHeight((float)height);
	}

	// Token: 0x0600D25D RID: 53853 RVA: 0x0037EF00 File Offset: 0x0037D100
	private void OnSellClick(FloroRanchEntityBase floroRanchEntity)
	{
		this.RefreshIncomeItemToggleState(false, this.IncomeItemSelectIndex);
		this.RefreshScrollViewInfo();
		this.SubTipInfoItem.GetRootItem().SetUIActive(false);
		this.MainTipInfoItem.GetRootItem().SetUIActive(false);
		Action<int> selectStateCallback = this.SelectStateCallback;
		if (selectStateCallback == null)
		{
			return;
		}
		selectStateCallback(-1);
	}

	// Token: 0x0600D25E RID: 53854 RVA: 0x0037EF53 File Offset: 0x0037D153
	private void RefreshIncomeItemToggleState(bool isSelected, int gridIndex)
	{
		if (gridIndex < 0 || gridIndex >= this.IncomeItemList.Count)
		{
			return;
		}
		this.IncomeItemList[gridIndex].SetSelectState(isSelected);
	}

	// Token: 0x0600D25F RID: 53855 RVA: 0x0037EF7C File Offset: 0x0037D17C
	private void RefreshScrollViewInfo()
	{
		this.DataList = ModelBase<FloroRanchGamePlayModel>.Instance.GetLastIncomeEntityList(this.CurrentFilterData, this.IsAscending, this.IsShowNotPresentCard);
		this.IncomeScrollView.RefreshByData(this.DataList, null, false);
		base.GetItem(11).SetUIActive(this.DataList.Count <= 0);
	}

	// Token: 0x0600D260 RID: 53856 RVA: 0x0037EFDC File Offset: 0x0037D1DC
	private void OnSelectFilter(int index, FloroRanchFilterType data)
	{
		this.CurrentFilterData = data;
		this.RefreshScrollViewInfo();
		this.CancelItemSelect();
	}

	// Token: 0x0600D261 RID: 53857 RVA: 0x0037EFF1 File Offset: 0x0037D1F1
	private TableTextArgNew GetDropDownText(FloroRanchFilterType data)
	{
		return new TableTextArgNew(data.Name, Array.Empty<object>());
	}

	// Token: 0x0600D262 RID: 53858 RVA: 0x0037F004 File Offset: 0x0037D204
	private void OnToggleCheckClick(EToggleState _)
	{
		this.IsShowNotPresentCard = !this.IsShowNotPresentCard;
		this.RefreshScrollViewInfo();
		this.CancelItemSelect();
	}

	// Token: 0x0600D263 RID: 53859 RVA: 0x0037F021 File Offset: 0x0037D221
	private void OnToggleOrderClick(EToggleState _)
	{
		this.IsAscending = !this.IsAscending;
		this.RefreshScrollViewInfo();
		this.CancelItemSelect();
	}

	// Token: 0x0600D264 RID: 53860 RVA: 0x0037F03E File Offset: 0x0037D23E
	private void OnCloseButtonClick()
	{
		Action<int> selectStateCallback = this.SelectStateCallback;
		if (selectStateCallback != null)
		{
			selectStateCallback(-1);
		}
		this.CancelItemSelect();
		base.CloseMe(null);
	}

	// Token: 0x0600D265 RID: 53861 RVA: 0x0037F05F File Offset: 0x0037D25F
	private void MainTipSequenceFinishEvent(string sequenceName)
	{
		if (sequenceName == "Close")
		{
			FloroRanchCommonTipItem mainTipInfoItem = this.MainTipInfoItem;
			if (mainTipInfoItem == null)
			{
				return;
			}
			mainTipInfoItem.SetUiActive(false);
		}
	}

	// Token: 0x0600D266 RID: 53862 RVA: 0x0037F07F File Offset: 0x0037D27F
	private void SubTipSequenceFinishEvent(string sequenceName)
	{
		if (sequenceName == "Close")
		{
			FloroRanchTerrainTipItem subTipInfoItem = this.SubTipInfoItem;
			if (subTipInfoItem == null)
			{
				return;
			}
			subTipInfoItem.SetUiActive(false);
		}
	}

	// Token: 0x0600D267 RID: 53863 RVA: 0x0037F0A0 File Offset: 0x0037D2A0
	private void OnFloroRanchCardEntityCountChange()
	{
		int ownCardEntityCount = ModelBase<FloroRanchGamePlayModel>.Instance.OwnCardEntityCount;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "Farm_ShowAllAnimal", new <>z__ReadOnlySingleElementList<object>(ownCardEntityCount));
	}

	// Token: 0x0400643B RID: 25659
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<FloroRanchIncomeItem, IFloroRanchDetailData> IncomeScrollView;

	// Token: 0x0400643C RID: 25660
	private readonly List<FloroRanchIncomeItem> IncomeItemList = new List<FloroRanchIncomeItem>();

	// Token: 0x0400643D RID: 25661
	private CommonDropDown<TableTextArgNew, FloroRanchFilterType> DropDownList;

	// Token: 0x0400643E RID: 25662
	private FloroRanchFilterType CurrentFilterData;

	// Token: 0x0400643F RID: 25663
	private bool IsShowNotPresentCard;

	// Token: 0x04006440 RID: 25664
	private bool IsAscending = true;

	// Token: 0x04006441 RID: 25665
	private List<IFloroRanchDetailData> DataList = new List<IFloroRanchDetailData>();

	// Token: 0x04006442 RID: 25666
	private int IncomeItemSelectIndex = -1;

	// Token: 0x04006443 RID: 25667
	private FloroRanchTipData SelectTipData;

	// Token: 0x04006444 RID: 25668
	[Nullable(2)]
	private FloroRanchCommonTipItem MainTipInfoItem;

	// Token: 0x04006445 RID: 25669
	[Nullable(2)]
	private FloroRanchTerrainTipItem SubTipInfoItem;

	// Token: 0x04006446 RID: 25670
	[Nullable(2)]
	private LevelSequencePlayer MainTipLevelSequencePlayer;

	// Token: 0x04006447 RID: 25671
	[Nullable(2)]
	private LevelSequencePlayer SubTipLevelSequencePlayer;

	// Token: 0x04006448 RID: 25672
	[Nullable(2)]
	private Action<int> SelectStateCallback;

	// Token: 0x02007F30 RID: 32560
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402B496 RID: 177302
		public const int CloseButton = 0;

		// Token: 0x0402B497 RID: 177303
		public const int CoinTexture = 1;

		// Token: 0x0402B498 RID: 177304
		public const int IncomeCoin = 2;

		// Token: 0x0402B499 RID: 177305
		public const int IncomeScrollView = 3;

		// Token: 0x0402B49A RID: 177306
		public const int IncomeItem = 4;

		// Token: 0x0402B49B RID: 177307
		public const int DropDown = 5;

		// Token: 0x0402B49C RID: 177308
		public const int OrderToggle = 6;

		// Token: 0x0402B49D RID: 177309
		public const int CheckToggle = 7;

		// Token: 0x0402B49E RID: 177310
		public const int CheckToggleText = 8;

		// Token: 0x0402B49F RID: 177311
		public const int RightInfoRoot = 9;

		// Token: 0x0402B4A0 RID: 177312
		public const int MaskButton = 10;

		// Token: 0x0402B4A1 RID: 177313
		public const int EmptyPanel = 11;
	}
}
