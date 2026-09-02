using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.ExploreLevel;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using UnrealEngine;

// Token: 0x02001B62 RID: 7010
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ExploreLevelPreviewItem : GridProxyAbstract<CountryExploreLevelRewardData>
{
	// Token: 0x0600CB07 RID: 51975 RVA: 0x003621CC File Offset: 0x003603CC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600CB08 RID: 51976 RVA: 0x003622DA File Offset: 0x003604DA
	protected override void OnStart()
	{
		this.RewardScrollView = new GenericScrollView<CommonItemSmallItemGrid>(base.GetScrollViewWithScrollbar(4), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CommonItemSmallItemGrid>(this.OnCreateRewardItemGrid), null);
	}

	// Token: 0x0600CB09 RID: 51977 RVA: 0x003622FB File Offset: 0x003604FB
	protected override void OnBeforeDestroy()
	{
		this.RewardScrollView = null;
	}

	// Token: 0x0600CB0A RID: 51978 RVA: 0x00362304 File Offset: 0x00360504
	public override void Refresh(CountryExploreLevelRewardData data, bool isSelected, int gridIndex)
	{
		Dictionary<int, int> dropItemNumMap = data.GetDropItemNumMap();
		List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
		if (dropItemNumMap != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in dropItemNumMap)
			{
				list.Add(new ValueTuple<int, int>(keyValuePair.Key, keyValuePair.Value));
			}
		}
		GenericScrollView<CommonItemSmallItemGrid> rewardScrollView = this.RewardScrollView;
		if (rewardScrollView != null)
		{
			rewardScrollView.RefreshByData<ValueTuple<int, int>>(list, null);
		}
		base.SetTextureByPath(data.GetScoreTexturePath(), base.GetTexture(0), null, null);
		CountryExploreLevelData currentCountryExploreLevelData = ModelBase<ExploreLevelModel>.Instance.GetCurrentCountryExploreLevelData();
		int? num = (currentCountryExploreLevelData != null) ? new int?(currentCountryExploreLevelData.GetExploreLevel()) : null;
		int exploreLevel = data.GetExploreLevel();
		bool flag = num.GetValueOrDefault() >= exploreLevel & num != null;
		base.GetSprite(1).SetUIActive(flag);
		base.GetText(2).SetUIActive(!flag);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.GetScoreNameId(), Array.Empty<object>());
		string rewardNameId = data.GetRewardNameId();
		UUIText text = base.GetText(6);
		if (!string.IsNullOrEmpty(rewardNameId))
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(rewardNameId, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "ExploreUnlockPreviewText", new <>z__ReadOnlySingleElementList<object>(localTextNew));
			text.SetUIActive(true);
		}
		else
		{
			text.SetUIActive(false);
		}
		base.GetSprite(5).SetUIActive(data.IsShowUnlockSprite());
	}

	// Token: 0x0600CB0B RID: 51979 RVA: 0x0036248C File Offset: 0x0036068C
	private ILayoutItem<CommonItemSmallItemGrid> OnCreateRewardItemGrid(object rawData, UUIItem uiItem, int index)
	{
		ValueTuple<int, int> valueTuple = (ValueTuple<int, int>)rawData;
		CommonItemSmallItemGrid commonItemSmallItemGrid = new CommonItemSmallItemGrid();
		commonItemSmallItemGrid.Initialize(uiItem.GetOwner());
		commonItemSmallItemGrid.RefreshByConfigId(valueTuple.Item1, new int?(valueTuple.Item2), null, false, false);
		return new LayoutItem<CommonItemSmallItemGrid>
		{
			Key = index,
			Value = commonItemSmallItemGrid
		};
	}

	// Token: 0x04006117 RID: 24855
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<CommonItemSmallItemGrid> RewardScrollView;

	// Token: 0x02007E4C RID: 32332
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B067 RID: 176231
		ExploreLevelTexture,
		// Token: 0x0402B068 RID: 176232
		DoneSprite,
		// Token: 0x0402B069 RID: 176233
		NotDoneText,
		// Token: 0x0402B06A RID: 176234
		ExploreLevelNameText,
		// Token: 0x0402B06B RID: 176235
		RewardScrollViewWithScrollBar,
		// Token: 0x0402B06C RID: 176236
		SpecialSprite,
		// Token: 0x0402B06D RID: 176237
		TipsText
	}
}
