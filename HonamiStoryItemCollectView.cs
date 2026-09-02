using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F21 RID: 7969
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryItemCollectView : UiViewBase
{
	// Token: 0x0600EE70 RID: 61040 RVA: 0x00411E3C File Offset: 0x0041003C
	public HonamiStoryItemCollectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EE71 RID: 61041 RVA: 0x00411E48 File Offset: 0x00410048
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EE72 RID: 61042 RVA: 0x00411FBC File Offset: 0x004101BC
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryItemCollectView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryItemCollectView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE73 RID: 61043 RVA: 0x00411FFF File Offset: 0x004101FF
	private HonamiStoryItemCollectItemView InitCollectItem()
	{
		return new HonamiStoryItemCollectItemView
		{
			OnClickToggleBack = new Action<int, HonamiStoryItemCollectionData>(this.OnClickItem),
			CanToggleChange = new Func<int, bool>(this.CanToggleChange)
		};
	}

	// Token: 0x0600EE74 RID: 61044 RVA: 0x0041202A File Offset: 0x0041022A
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStoryItemCollectGetReward, new Action(this.RefreshView));
	}

	// Token: 0x0600EE75 RID: 61045 RVA: 0x00412048 File Offset: 0x00410248
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryItemCollectGetReward, new Action(this.RefreshView));
	}

	// Token: 0x0600EE76 RID: 61046 RVA: 0x00412068 File Offset: 0x00410268
	private void RefreshView()
	{
		this.RefreshProgressTxt();
		List<HonamiStoryItemCollectionData> sortDataList = this.GetSortDataList();
		this.PnlCollectItemList.GetGenericLayout().DeselectCurrentGridProxy();
		this.PnlCollectItemList.RefreshByData(sortDataList, null, false);
		this.OnClickItem(0, sortDataList[0]);
	}

	// Token: 0x0600EE77 RID: 61047 RVA: 0x004120B0 File Offset: 0x004102B0
	private void RefreshProgressTxt()
	{
		string str = this.GetUnLockItemNum().ToString();
		string str2 = this.ActData.GetItemCollectionDataList().Count.ToString();
		base.GetText(7).SetText(str + "/" + str2, true);
	}

	// Token: 0x0600EE78 RID: 61048 RVA: 0x00412100 File Offset: 0x00410300
	private int GetUnLockItemNum()
	{
		int num = 0;
		using (List<HonamiStoryItemCollectionData>.Enumerator enumerator = this.ActData.GetItemCollectionDataList().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.State != EHonamiStoryCollectState.Unfinished)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x0600EE79 RID: 61049 RVA: 0x00412160 File Offset: 0x00410360
	private List<HonamiStoryItemCollectionData> GetSortDataList()
	{
		if (this.ActData == null)
		{
			return new List<HonamiStoryItemCollectionData>();
		}
		Dictionary<EHonamiStoryCollectState, int> statePriority = new Dictionary<EHonamiStoryCollectState, int>
		{
			{
				EHonamiStoryCollectState.Finished,
				1
			},
			{
				EHonamiStoryCollectState.GotReward,
				2
			},
			{
				EHonamiStoryCollectState.Unfinished,
				3
			}
		};
		List<HonamiStoryItemCollectionData> list = new List<HonamiStoryItemCollectionData>(this.ActData.GetItemCollectionDataList());
		list.Sort((HonamiStoryItemCollectionData a, HonamiStoryItemCollectionData b) => statePriority[a.State] - statePriority[b.State]);
		return list;
	}

	// Token: 0x0600EE7A RID: 61050 RVA: 0x004121C8 File Offset: 0x004103C8
	private void OnClickItem(int gridIndex, HonamiStoryItemCollectionData data)
	{
		this.CurSelectItemData = data;
		this.PnlCollectItemList.SelectGridProxy(gridIndex, false);
		base.SetTextureByPath(data.GetConfig.Icon, base.GetTexture(9), null, null);
		UUIItem texture = base.GetTexture(9);
		bool bUseChangeColor = data.State == EHonamiStoryCollectState.Unfinished;
		FColor? fcolor = new FColor?(base.GetTexture(9).changeColor);
		texture.SetChangeColor(bUseChangeColor, fcolor);
		base.GetItem(8).SetUIActive(data.State == EHonamiStoryCollectState.Unfinished);
		if (this.CurSelectItemData.State != EHonamiStoryCollectState.Unfinished)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.CurSelectItemData.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.CurSelectItemData.Desc, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.CurSelectItemData.Desc, Array.Empty<object>());
		}
		bool uiactive = this.CurSelectItemData.State > EHonamiStoryCollectState.Unfinished;
		base.GetItem(2).SetUIActive(uiactive);
		base.GetText(4).SetUIActive(uiactive);
		this.RewardBtn.RefreshView(this.CurSelectItemData);
	}

	// Token: 0x0600EE7B RID: 61051 RVA: 0x004122F9 File Offset: 0x004104F9
	private bool CanToggleChange(int gridIndex)
	{
		return gridIndex != this.PnlCollectItemList.GetSelectedIndex();
	}

	// Token: 0x0600EE7C RID: 61052 RVA: 0x0041230C File Offset: 0x0041050C
	private void OnClickHelpBtn()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(442);
	}

	// Token: 0x0600EE7D RID: 61053 RVA: 0x0041231D File Offset: 0x0041051D
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400726A RID: 29290
	[Nullable(2)]
	private HonamiStoryActivityData ActData;

	// Token: 0x0400726B RID: 29291
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400726C RID: 29292
	private GenericScrollViewNew<HonamiStoryItemCollectItemView, HonamiStoryItemCollectionData> PnlCollectItemList;

	// Token: 0x0400726D RID: 29293
	[Nullable(2)]
	private HonamiStoryItemCollectionData CurSelectItemData;

	// Token: 0x0400726E RID: 29294
	[Nullable(2)]
	private HonamiStoryItemCollectRewardBtn RewardBtn;

	// Token: 0x0200829A RID: 33434
	[NullableContext(0)]
	private enum EHonamiStoryItemCollectComponent
	{
		// Token: 0x0402C4B9 RID: 181433
		SvItemInfo,
		// Token: 0x0402C4BA RID: 181434
		TogItem,
		// Token: 0x0402C4BB RID: 181435
		PnlTxtTitle,
		// Token: 0x0402C4BC RID: 181436
		TxtInfoTitle,
		// Token: 0x0402C4BD RID: 181437
		TxtInfo,
		// Token: 0x0402C4BE RID: 181438
		BtnReward,
		// Token: 0x0402C4BF RID: 181439
		ItemCaption,
		// Token: 0x0402C4C0 RID: 181440
		TxtProgress,
		// Token: 0x0402C4C1 RID: 181441
		ItemLock,
		// Token: 0x0402C4C2 RID: 181442
		TexItem
	}
}
