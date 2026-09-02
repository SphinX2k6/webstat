using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001214 RID: 4628
[NullableContext(2)]
[Nullable(0)]
public class BabelTowerSvBuffItem : UiPanelBase
{
	// Token: 0x06007ABF RID: 31423 RVA: 0x00200FA4 File Offset: 0x001FF1A4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickLookBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickQuickSelectBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickDelBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007AC0 RID: 31424 RVA: 0x002011BC File Offset: 0x001FF3BC
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerSvBuffItem.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerSvBuffItem.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007AC1 RID: 31425 RVA: 0x00201200 File Offset: 0x001FF400
	public void SetLevelId(int levelId)
	{
		this.LevelId = levelId;
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(levelId);
		UUIButtonComponent button = base.GetButton(6);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(babelTowerLevelConfig.IsDifficult);
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(!babelTowerLevelConfig.IsDifficult);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), babelTowerLevelConfig.NameText ?? "", Array.Empty<object>());
		this.RefreshBuffList(null);
		this.RefreshStarNum();
	}

	// Token: 0x06007AC2 RID: 31426 RVA: 0x00201298 File Offset: 0x001FF498
	public void RefreshBuffList([Nullable(new byte[]
	{
		2,
		1
	})] List<IBabelTowerMutexGroupData> dataList = null)
	{
		List<IBabelTowerMutexGroupData> data = dataList ?? this.BuildMutexGroupDataList();
		GenericScrollViewNew<MutexGroupItem, IBabelTowerMutexGroupData> buffScrollView = this.BuffScrollView;
		if (buffScrollView == null)
		{
			return;
		}
		buffScrollView.RefreshByData(data, null, false);
	}

	// Token: 0x06007AC3 RID: 31427 RVA: 0x002012C4 File Offset: 0x001FF4C4
	public void SetActionButtonsVisible(bool visible, bool? showQuickSelect = null)
	{
		UUIButtonComponent button = base.GetButton(5);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(visible);
		}
		if (showQuickSelect != null)
		{
			UUIButtonComponent button2 = base.GetButton(6);
			if (button2 == null)
			{
				return;
			}
			button2.RootUIComp.Get().SetUIActive(showQuickSelect.Value);
		}
	}

	// Token: 0x06007AC4 RID: 31428 RVA: 0x0020131F File Offset: 0x001FF51F
	public void SetQuickSelectPanelVisible(bool visible)
	{
		this.IsQuickSelectPanelOpen = visible;
		UUIText text = base.GetText(7);
		if (text != null)
		{
			text.SetUIActive(visible);
		}
		ButtonItem applyButton = this.ApplyButton;
		if (applyButton == null)
		{
			return;
		}
		applyButton.SetUiActive(visible);
	}

	// Token: 0x06007AC5 RID: 31429 RVA: 0x0020134C File Offset: 0x001FF54C
	public void SetQuickSelectComponentsOpacity(int quickIndex)
	{
		bool flag = this.IsQuickSelectMode();
		bool flag2 = quickIndex >= 0;
		float uiitemAlpha = (flag && !flag2) ? 0.8f : 1f;
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(3);
		if (scrollViewWithScrollbar != null)
		{
			scrollViewWithScrollbar.RootUIComp.Get().SetUIItemAlpha(uiitemAlpha);
		}
		UUIItem item = base.GetItem(10);
		if (item == null)
		{
			return;
		}
		item.SetUIItemAlpha(uiitemAlpha);
	}

	// Token: 0x06007AC6 RID: 31430 RVA: 0x002013AC File Offset: 0x001FF5AC
	public bool IsQuickSelectMode()
	{
		return this.IsQuickSelectPanelOpen;
	}

	// Token: 0x06007AC7 RID: 31431 RVA: 0x002013B4 File Offset: 0x001FF5B4
	public MutexGroupItem FindMutexGroupItemByDeTermId(int deTermId)
	{
		GenericScrollViewNew<MutexGroupItem, IBabelTowerMutexGroupData> buffScrollView = this.BuffScrollView;
		if (buffScrollView == null)
		{
			return null;
		}
		foreach (MutexGroupItem mutexGroupItem in buffScrollView.GetScrollItemList())
		{
			if (mutexGroupItem.GetBuffItemById(deTermId) != null)
			{
				return mutexGroupItem;
			}
		}
		return null;
	}

	// Token: 0x06007AC8 RID: 31432 RVA: 0x0020141C File Offset: 0x001FF61C
	public void ScrollToDeTerm(int deTermId)
	{
		GenericScrollViewNew<MutexGroupItem, IBabelTowerMutexGroupData> buffScrollView = this.BuffScrollView;
		if (buffScrollView == null || deTermId == 0)
		{
			return;
		}
		foreach (MutexGroupItem mutexGroupItem in buffScrollView.GetScrollItemList())
		{
			SvBuffGridItem buffItemById = mutexGroupItem.GetBuffItemById(deTermId);
			if (buffItemById != null)
			{
				buffScrollView.LateScrollTo(mutexGroupItem.GetRootItem(), null, false);
				buffItemById.FlashHighlight();
				break;
			}
		}
	}

	// Token: 0x06007AC9 RID: 31433 RVA: 0x00201498 File Offset: 0x001FF698
	public void RefreshStarNum()
	{
		int currentDeTermStar = ModelBase<BabelTowerModel>.Instance.GetCurrentDeTermStar();
		int selectedDeTermCount = ModelBase<BabelTowerModel>.Instance.GetSelectedDeTermCount();
		this.SetStarNumText(selectedDeTermCount);
		this.RefreshDifficultyColor(currentDeTermStar);
		Action<int> onRefreshStarNum = this.OnRefreshStarNum;
		if (onRefreshStarNum == null)
		{
			return;
		}
		onRefreshStarNum(currentDeTermStar);
	}

	// Token: 0x06007ACA RID: 31434 RVA: 0x002014DC File Offset: 0x001FF6DC
	private void SetStarNumText(int selectedCount)
	{
		UUIText text = base.GetText(7);
		if (text != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "BabelQuickSelect_star", new <>z__ReadOnlySingleElementList<object>(selectedCount));
		}
	}

	// Token: 0x06007ACB RID: 31435 RVA: 0x00201510 File Offset: 0x001FF710
	private void RefreshDifficultyColor(int currentStar)
	{
		BabelTowerLevel? config = ConfigBabelTowerLevelById.GetConfig(this.LevelId, true);
		if (config == null)
		{
			return;
		}
		BabelTowerLevel valueOrDefault = config.GetValueOrDefault();
		BabelTowerDifficulty? babelTowerDifficulty = ModelBase<BabelTowerModel>.Instance.CalculateDifficultyConfigByStarNum(valueOrDefault.ActivityId, currentStar);
		if (babelTowerDifficulty == null)
		{
			return;
		}
		FColor color = FColor.FromHex(babelTowerDifficulty.GetValueOrDefault().TextBgColor);
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		sprite.SetColor(color);
	}

	// Token: 0x06007ACC RID: 31436 RVA: 0x00201588 File Offset: 0x001FF788
	[NullableContext(1)]
	private List<IBabelTowerMutexGroupData> BuildMutexGroupDataList()
	{
		BabelTowerLevel? config = ConfigBabelTowerLevelById.GetConfig(this.LevelId, true);
		if (config != null)
		{
			BabelTowerLevel valueOrDefault = config.GetValueOrDefault();
			List<IBabelTowerMutexGroupData> list = new List<IBabelTowerMutexGroupData>();
			bool value = true;
			if (valueOrDefault.FixBabelDeTermdsLength > 0)
			{
				List<int> list2 = new List<int>();
				for (int i = 0; i < valueOrDefault.FixBabelDeTermdsLength; i++)
				{
					int num = valueOrDefault.FixBabelDeTermds(i);
					BabelTowerDeTerm babelTowerDeTerm = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTerm(num);
					int j = 1;
					while (babelTowerDeTerm.Star > j)
					{
						list2.Add(0);
						j++;
					}
					list2.Add(num);
					for (j++; j <= 3; j++)
					{
						list2.Add(0);
					}
				}
				list.Add(new BabelTowerMutexGroupData
				{
					MutexId = 0,
					GroupId = 0,
					DeTermList = list2,
					IsNecessary = new bool?(value)
				});
			}
			for (int k = 0; k < valueOrDefault.BabelTowerDeTermMutexArrayLength; k++)
			{
				int num2 = valueOrDefault.BabelTowerDeTermMutexArray(k);
				BabelTowerDeTermMutex babelTowerDeTermMutual = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTermMutual(num2);
				List<int> mergedDeTermListByMutexId = this.GetMergedDeTermListByMutexId(babelTowerDeTermMutual);
				int value2 = 0;
				foreach (int num3 in mergedDeTermListByMutexId)
				{
					if (num3 != 0)
					{
						IBabelTowerSelectInfo valueOrDefault2 = ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo.GetValueOrDefault(num3);
						if (valueOrDefault2 != null && valueOrDefault2.State == EBabelTowerDeTermState.Select)
						{
							value2 = num3;
							break;
						}
					}
				}
				list.Add(new BabelTowerMutexGroupData
				{
					MutexId = num2,
					GroupId = ((babelTowerDeTermMutual.MutexDeTermGroupLength > 0) ? babelTowerDeTermMutual.MutexDeTermGroup(0) : 0),
					DeTermList = mergedDeTermListByMutexId,
					CurrentDeTermId = new int?(value2)
				});
			}
			return list;
		}
		return new List<IBabelTowerMutexGroupData>();
	}

	// Token: 0x06007ACD RID: 31437 RVA: 0x00201764 File Offset: 0x001FF964
	[NullableContext(1)]
	private List<int> GetMergedDeTermListByMutexId(BabelTowerDeTermMutex mutexConfig)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < mutexConfig.MutexDeTermGroupLength; i++)
		{
			int id = mutexConfig.MutexDeTermGroup(i);
			List<BabelTowerDeTerm> list2 = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTermByGroupId(id).ToList<BabelTowerDeTerm>();
			list2.Sort((BabelTowerDeTerm a, BabelTowerDeTerm b) => a.Star - b.Star);
			int star2;
			int star;
			for (star = 1; star <= 3; star = star2 + 1)
			{
				BabelTowerDeTerm? babelTowerDeTerm = (from config in list2
				where config.Star == star
				select new BabelTowerDeTerm?(config)).FirstOrDefault<BabelTowerDeTerm?>();
				if (babelTowerDeTerm != null)
				{
					list.Add(babelTowerDeTerm.GetValueOrDefault().Id);
				}
				else
				{
					list.Add(0);
				}
				star2 = star;
			}
		}
		return list;
	}

	// Token: 0x06007ACE RID: 31438 RVA: 0x00201867 File Offset: 0x001FFA67
	[NullableContext(1)]
	private MutexGroupItem CreateMutexGroupItem()
	{
		MutexGroupItem mutexGroupItem = new MutexGroupItem();
		mutexGroupItem.SetParentItem(this);
		mutexGroupItem.OnBuffClick = new Action<int, UUIExtendToggle>(this.OnBuffItemClick);
		return mutexGroupItem;
	}

	// Token: 0x06007ACF RID: 31439 RVA: 0x00201888 File Offset: 0x001FFA88
	private void OnBuffItemClick(int deTermId, UUIExtendToggle toggle)
	{
		if (deTermId <= 0)
		{
			return;
		}
		IBabelTowerSelectInfo selectInfoByDeTerm = this.GetSelectInfoByDeTerm(deTermId);
		if (selectInfoByDeTerm == null)
		{
			return;
		}
		if (selectInfoByDeTerm.State == EBabelTowerDeTermState.Lock)
		{
			return;
		}
		MutexGroupItem mutexGroupItem = this.FindMutexGroupItemByDeTermId(deTermId);
		if (mutexGroupItem != null)
		{
			mutexGroupItem.HandleToggle(deTermId, toggle);
		}
	}

	// Token: 0x06007AD0 RID: 31440 RVA: 0x002018C4 File Offset: 0x001FFAC4
	private void OnClickLookBtn()
	{
		int levelId = this.LevelId;
		if (levelId <= 0)
		{
			return;
		}
		BabelTowerLevel? config = ConfigBabelTowerLevelById.GetConfig(levelId, true);
		if (config != null)
		{
			BabelTowerLevel valueOrDefault = config.GetValueOrDefault();
			ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId = valueOrDefault.InstId;
			InstanceDungeonMonsterView.InstanceDungeonMonsterViewOpenParam param = new InstanceDungeonMonsterView.InstanceDungeonMonsterViewOpenParam
			{
				InstanceId = valueOrDefault.InstId,
				InfoType = null
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonMonsterPreView, param, null);
			return;
		}
	}

	// Token: 0x06007AD1 RID: 31441 RVA: 0x0020193E File Offset: 0x001FFB3E
	private void OnClickQuickSelectBtn()
	{
		Action onQuickSelectClick = this.OnQuickSelectClick;
		if (onQuickSelectClick == null)
		{
			return;
		}
		onQuickSelectClick();
	}

	// Token: 0x06007AD2 RID: 31442 RVA: 0x00201950 File Offset: 0x001FFB50
	private void OnClickDelBtn()
	{
		Action onClearClick = this.OnClearClick;
		if (onClearClick == null)
		{
			return;
		}
		onClearClick();
	}

	// Token: 0x06007AD3 RID: 31443 RVA: 0x00201962 File Offset: 0x001FFB62
	private void OnClickConfirmBtn(int data)
	{
		Action onConfirmClick = this.OnConfirmClick;
		if (onConfirmClick == null)
		{
			return;
		}
		onConfirmClick();
	}

	// Token: 0x06007AD4 RID: 31444 RVA: 0x00201974 File Offset: 0x001FFB74
	public IBabelTowerSelectInfo GetSelectInfoByDeTerm(int deTermId)
	{
		return ModelBase<BabelTowerModel>.Instance.GetDeTermSelectInfo(deTermId);
	}

	// Token: 0x06007AD5 RID: 31445 RVA: 0x00201981 File Offset: 0x001FFB81
	public void NotifyDeTermToggle(int deTermId)
	{
		Action<int> onDeTermToggle = this.OnDeTermToggle;
		if (onDeTermToggle == null)
		{
			return;
		}
		onDeTermToggle(deTermId);
	}

	// Token: 0x06007AD6 RID: 31446 RVA: 0x00201994 File Offset: 0x001FFB94
	public void ClearAllSelect()
	{
		foreach (KeyValuePair<int, IBabelTowerSelectInfo> keyValuePair in ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo)
		{
			bool key = keyValuePair.Key != 0;
			IBabelTowerSelectInfo value = keyValuePair.Value;
			if (key && value.State == EBabelTowerDeTermState.Select)
			{
				value.State = EBabelTowerDeTermState.Normal;
			}
		}
		this.RefreshBuffList(null);
		this.RefreshStarNum();
	}

	// Token: 0x06007AD7 RID: 31447 RVA: 0x00201A14 File Offset: 0x001FFC14
	[NullableContext(1)]
	public void ApplyQuickSelectDeTerms(List<int> buffGroup)
	{
		Dictionary<int, IBabelTowerSelectInfo> deTermSelectInfo = ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo;
		foreach (KeyValuePair<int, IBabelTowerSelectInfo> keyValuePair in deTermSelectInfo)
		{
			bool key = keyValuePair.Key != 0;
			IBabelTowerSelectInfo value = keyValuePair.Value;
			if (key && value.State == EBabelTowerDeTermState.Select)
			{
				value.State = EBabelTowerDeTermState.Normal;
			}
		}
		foreach (int num in buffGroup)
		{
			IBabelTowerSelectInfo valueOrDefault = deTermSelectInfo.GetValueOrDefault(num);
			if (valueOrDefault != null)
			{
				if (valueOrDefault.State != EBabelTowerDeTermState.StaticSelect)
				{
					valueOrDefault.State = EBabelTowerDeTermState.Select;
				}
			}
			else if (ConfigBabelTowerDeTermById.GetConfig(num, true) != null)
			{
				BabelTowerSelectInfo babelTowerSelectInfo = new BabelTowerSelectInfo();
				babelTowerSelectInfo.State = EBabelTowerDeTermState.Select;
				BabelTowerModel instance = ModelBase<BabelTowerModel>.Instance;
				int deTermSelectIndex = instance.DeTermSelectIndex;
				instance.DeTermSelectIndex = deTermSelectIndex + 1;
				babelTowerSelectInfo.SelectIndex = deTermSelectIndex;
				BabelTowerSelectInfo value2 = babelTowerSelectInfo;
				deTermSelectInfo[num] = value2;
			}
		}
		this.RefreshBuffList(null);
		this.RefreshStarNum();
	}

	// Token: 0x04003AE0 RID: 15072
	private const int MAX_STAR_NUM = 3;

	// Token: 0x04003AE1 RID: 15073
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<MutexGroupItem, IBabelTowerMutexGroupData> BuffScrollView;

	// Token: 0x04003AE2 RID: 15074
	private int LevelId;

	// Token: 0x04003AE3 RID: 15075
	private bool IsQuickSelectPanelOpen;

	// Token: 0x04003AE4 RID: 15076
	private ButtonItem ApplyButton;

	// Token: 0x04003AE5 RID: 15077
	public Action<int, int> OnBuffClick;

	// Token: 0x04003AE6 RID: 15078
	public Action<int> OnDeTermToggle;

	// Token: 0x04003AE7 RID: 15079
	public Action<int> OnDesRightRefresh;

	// Token: 0x04003AE8 RID: 15080
	public Action OnQuickSelectClick;

	// Token: 0x04003AE9 RID: 15081
	public Action OnClearClick;

	// Token: 0x04003AEA RID: 15082
	public Action OnConfirmClick;

	// Token: 0x04003AEB RID: 15083
	public Action<int> OnRefreshStarNum;

	// Token: 0x02007567 RID: 30055
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04028825 RID: 165925
		public const int ColorFrameSprite = 0;

		// Token: 0x04028826 RID: 165926
		public const int BtnLook = 1;

		// Token: 0x04028827 RID: 165927
		public const int DeBuffTopTips = 2;

		// Token: 0x04028828 RID: 165928
		public const int DeBuffItemScroll = 3;

		// Token: 0x04028829 RID: 165929
		public const int UiItemDeBuffItemGroup = 4;

		// Token: 0x0402882A RID: 165930
		public const int BtnFunctionDel = 5;

		// Token: 0x0402882B RID: 165931
		public const int BtnQuickSelect = 6;

		// Token: 0x0402882C RID: 165932
		public const int TxtDeBuffValue = 7;

		// Token: 0x0402882D RID: 165933
		public const int BtnApply = 8;

		// Token: 0x0402882E RID: 165934
		public const int TitleNameText = 9;

		// Token: 0x0402882F RID: 165935
		public const int ApplyBtnGroupItem = 10;
	}
}
