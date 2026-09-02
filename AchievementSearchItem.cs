using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FEB RID: 4075
[NullableContext(1)]
[Nullable(0)]
public class AchievementSearchItem : UiPanelBase
{
	// Token: 0x0600693D RID: 26941 RVA: 0x001B6E0E File Offset: 0x001B500E
	public AchievementSearchItem(UUIItem uiItem)
	{
		this.SourceItem = uiItem;
	}

	// Token: 0x0600693E RID: 26942 RVA: 0x001B6E28 File Offset: 0x001B5028
	public UniTask Init()
	{
		AchievementSearchItem.<Init>d__6 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<AchievementSearchItem.<Init>d__6>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600693F RID: 26943 RVA: 0x001B6E6C File Offset: 0x001B506C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIDynScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006940 RID: 26944 RVA: 0x001B6ED8 File Offset: 0x001B50D8
	protected override UniTask OnBeforeStartAsync()
	{
		AchievementSearchItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AchievementSearchItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006941 RID: 26945 RVA: 0x001B6F1B File Offset: 0x001B511B
	protected override void OnStart()
	{
		base.GetUIDynScrollViewComponent(0).GetRootComponent().SetUIActive(this.CurrentSearchScrollerState);
		this.AddEventListener();
	}

	// Token: 0x06006942 RID: 26946 RVA: 0x001B6F3A File Offset: 0x001B513A
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnGetAchievementSearchTextChange, new Action(this.OnGetAchievementSearchTextChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnAchievementDataNotify, new Action(this.OnAchievementDataNotify));
	}

	// Token: 0x06006943 RID: 26947 RVA: 0x001B6F74 File Offset: 0x001B5174
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGetAchievementSearchTextChange, new Action(this.OnGetAchievementSearchTextChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAchievementDataNotify, new Action(this.OnAchievementDataNotify));
	}

	// Token: 0x06006944 RID: 26948 RVA: 0x001B6FAE File Offset: 0x001B51AE
	protected override void OnBeforeDestroy()
	{
		if (this.ScrollView != null)
		{
			this.ScrollView.ClearChildren();
			this.ScrollView = null;
		}
		if (this.AchievementSearchResultDynItem != null)
		{
			this.AchievementSearchResultDynItem.ClearItem();
			this.AchievementSearchResultDynItem = null;
		}
		this.RemoveEventListener();
	}

	// Token: 0x06006945 RID: 26949 RVA: 0x001B6FEA File Offset: 0x001B51EA
	public void Update()
	{
		this.RefreshSearchResult();
	}

	// Token: 0x06006946 RID: 26950 RVA: 0x001B6FF2 File Offset: 0x001B51F2
	public void ResetSearchState()
	{
		this.CurrentSearchingText = string.Empty;
	}

	// Token: 0x06006947 RID: 26951 RVA: 0x001B7000 File Offset: 0x001B5200
	private void RefreshSearchResult()
	{
		string currentSearchText = ModelBase<AchievementModel>.Instance.CurrentSearchText;
		if (this.CurrentSearchingText == currentSearchText)
		{
			return;
		}
		this.RefreshUi();
	}

	// Token: 0x06006948 RID: 26952 RVA: 0x001B7030 File Offset: 0x001B5230
	private void RefreshUi()
	{
		AchievementModel instance = ModelBase<AchievementModel>.Instance;
		if (!instance.AchievementSearchState)
		{
			return;
		}
		string currentSearchText = instance.CurrentSearchText;
		Dictionary<AchievementCategoryData, Dictionary<AchievementGroupData, AchievementData[]>> searchResult = instance.GetSearchResult();
		this.CurrentSearchingText = currentSearchText;
		bool searchResultIfNull = instance.GetSearchResultIfNull();
		base.GetUIDynScrollViewComponent(0).GetRootComponent().SetUIActive(!searchResultIfNull);
		this.CurrentSearchScrollerState = !searchResultIfNull;
		List<AchievementSearchData> searchResultData = instance.GetSearchResultData(searchResult);
		instance.CurrentCacheSearchData = searchResultData;
		this.ScrollView.RefreshByData(searchResultData.ToArray(), false, false);
	}

	// Token: 0x06006949 RID: 26953 RVA: 0x001B70AC File Offset: 0x001B52AC
	private AchievementSearchResultItem CreateResultItem(AchievementSearchData data, UUIItem uiItem, int index)
	{
		return new AchievementSearchResultItem();
	}

	// Token: 0x0600694A RID: 26954 RVA: 0x001B70B3 File Offset: 0x001B52B3
	private void OnGetAchievementSearchTextChange()
	{
		if (ModelBase<AchievementModel>.Instance.AchievementSearchState)
		{
			this.RefreshSearchResult();
		}
	}

	// Token: 0x0600694B RID: 26955 RVA: 0x001B70C7 File Offset: 0x001B52C7
	private void OnAchievementDataNotify()
	{
		ModelBase<AchievementModel>.Instance.RefreshSearchResult();
		this.RefreshUi();
	}

	// Token: 0x04003201 RID: 12801
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<AchievementSearchResultItem, AchievementSearchResultDynItem, AchievementSearchData> ScrollView;

	// Token: 0x04003202 RID: 12802
	[Nullable(2)]
	private AchievementSearchResultDynItem AchievementSearchResultDynItem;

	// Token: 0x04003203 RID: 12803
	private bool CurrentSearchScrollerState;

	// Token: 0x04003204 RID: 12804
	private string CurrentSearchingText = string.Empty;

	// Token: 0x04003205 RID: 12805
	[Nullable(2)]
	private readonly UUIItem SourceItem;

	// Token: 0x020073CB RID: 29643
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x04028104 RID: 164100
		SearchScroller,
		// Token: 0x04028105 RID: 164101
		TemplateItem
	}
}
