using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FDB RID: 4059
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AchievementDataItem : GridProxyAbstract<AchievementData>
{
	// Token: 0x1700082C RID: 2092
	// (get) Token: 0x0600688B RID: 26763 RVA: 0x001B3C81 File Offset: 0x001B1E81
	// (set) Token: 0x0600688C RID: 26764 RVA: 0x001B3C89 File Offset: 0x001B1E89
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public new ScrollViewDelegate<IGridProxy<AchievementData>, AchievementData> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x1700082D RID: 2093
	// (get) Token: 0x0600688D RID: 26765 RVA: 0x001B3C92 File Offset: 0x001B1E92
	// (set) Token: 0x0600688E RID: 26766 RVA: 0x001B3C9A File Offset: 0x001B1E9A
	public new int GridIndex { get; set; }

	// Token: 0x1700082E RID: 2094
	// (get) Token: 0x0600688F RID: 26767 RVA: 0x001B3CA3 File Offset: 0x001B1EA3
	// (set) Token: 0x06006890 RID: 26768 RVA: 0x001B3CAB File Offset: 0x001B1EAB
	public new int DisplayIndex { get; set; }

	// Token: 0x06006891 RID: 26769 RVA: 0x001B3CB4 File Offset: 0x001B1EB4
	public UniTask Init(UUIItem item)
	{
		AchievementDataItem.<Init>d__17 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<AchievementDataItem.<Init>d__17>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06006892 RID: 26770 RVA: 0x001B3D00 File Offset: 0x001B1F00
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06006893 RID: 26771 RVA: 0x001B3E8F File Offset: 0x001B208F
	protected override void OnStart()
	{
		if (this.AchievementGridItem == null)
		{
			this.AchievementGridItem = new AchievementGridItem();
			this.AchievementGridItem.Initialize(base.GetItem(8).GetOwner());
		}
		this.AchievementGridItem.SetActive(false);
		this.AddEventListener();
	}

	// Token: 0x06006894 RID: 26772 RVA: 0x001B3ECD File Offset: 0x001B20CD
	public override void Refresh(AchievementData data, bool isSelected, int gridIndex)
	{
		this.RefreshUi(data);
	}

	// Token: 0x06006895 RID: 26773 RVA: 0x001B3ED8 File Offset: 0x001B20D8
	public void RefreshUi(AchievementData data)
	{
		if (data == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Achievement, ELogAuthor.BB, "AchievementDataItem Data为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.AchievementData = data;
		int? currentProgress = data.GetCurrentProgress();
		int? maxProgress = data.GetMaxProgress();
		EAchievementStateEnum finishState = data.GetFinishState();
		UUIText text = base.GetText(5);
		UUIText text2 = base.GetText(6);
		UUIText text3 = base.GetText(3);
		if (ModelBase<AchievementModel>.Instance.AchievementSearchState)
		{
			string currentSearchText = ModelBase<AchievementModel>.Instance.CurrentSearchText;
			text.SetText(data.GetReplaceTitle(currentSearchText), true);
			text2.SetText(data.GetReplaceDesc(currentSearchText), true);
		}
		else
		{
			text.SetText(data.GetTitle(), true);
			text2.SetText(data.GetDesc(), true);
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(7), "CollectProgress", new <>z__ReadOnlyArray<object>(new object[]
		{
			currentProgress,
			maxProgress
		}));
		base.SetButtonUiActive(2, finishState == EAchievementStateEnum.CanGetReward);
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(data.RedPoint());
		}
		UUIItem item2 = base.GetItem(4);
		if (item2 != null)
		{
			item2.SetUIActive(finishState == EAchievementStateEnum.HaveGetReward);
		}
		if (finishState == EAchievementStateEnum.UnFinished)
		{
			if (text3 != null)
			{
				text3.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, "Text_Doing_Text", Array.Empty<object>());
		}
		else if (finishState == EAchievementStateEnum.CanGetReward)
		{
			if (text3 != null)
			{
				text3.SetUIActive(false);
			}
		}
		else
		{
			if (text3 != null)
			{
				text3.SetUIActive(true);
			}
			DateTime localDateTime = DateTimeOffset.FromUnixTimeMilliseconds(data.GetFinishTime().Value * (long)Singleton<TimeUtil>.Instance.InverseMillisecond).LocalDateTime;
			string newText = Singleton<TimeUtil>.Instance.DateFormat4(localDateTime);
			if (text3 != null)
			{
				text3.SetText(newText, true);
			}
		}
		List<TItem> rewards = data.GetRewards();
		if (rewards.Count > 0)
		{
			this.RefreshRewardItem(rewards[0]);
		}
		this.RefreshStar();
	}

	// Token: 0x06006896 RID: 26774 RVA: 0x001B40B1 File Offset: 0x001B22B1
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x06006897 RID: 26775 RVA: 0x001B40BA File Offset: 0x001B22BA
	public AUIBaseActor GetUsingItem(AchievementData data)
	{
		return (AUIBaseActor)base.GetRootItem().GetOwner();
	}

	// Token: 0x06006898 RID: 26776 RVA: 0x001B40CC File Offset: 0x001B22CC
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAchievementDataWithIdNotify, new Action<int>(this.OnAchievementDataWithIdNotify));
	}

	// Token: 0x06006899 RID: 26777 RVA: 0x001B40EA File Offset: 0x001B22EA
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAchievementDataWithIdNotify, new Action<int>(this.OnAchievementDataWithIdNotify));
	}

	// Token: 0x0600689A RID: 26778 RVA: 0x001B4108 File Offset: 0x001B2308
	private void OnAchievementDataWithIdNotify(int id)
	{
		if (this.AchievementData != null && id == this.AchievementData.GetId() && (this.AchievementData.IfSingleAchievement() || (!this.AchievementData.IfSingleAchievement() && this.AchievementData.GetNextLink() == 0)))
		{
			this.RefreshUi(this.AchievementData);
		}
	}

	// Token: 0x0600689B RID: 26779 RVA: 0x001B415E File Offset: 0x001B235E
	private void OnClickButton()
	{
		ControllerBase<AchievementController>.Instance.RequestGetAchievementReward(false, this.AchievementData.GetId());
	}

	// Token: 0x0600689C RID: 26780 RVA: 0x001B4178 File Offset: 0x001B2378
	private void RefreshStar()
	{
		if (this.StarItem != null)
		{
			this.StarItem.Destroy(null);
			this.StarItem = null;
		}
		int count = this.AchievementData.IfSingleAchievement() ? this.AchievementData.GetAchievementShowStar() : AchievementDataItem.MaxStarCount;
		this.StarItem = new AchievementStarItem(count, this.AchievementData, base.GetItem(9));
	}

	// Token: 0x0600689D RID: 26781 RVA: 0x001B41DC File Offset: 0x001B23DC
	private void RefreshRewardItem(TItem data)
	{
		this.AchievementGridItem.SetActive(true);
		AchievementGridItemData achievementGridItemData = new AchievementGridItemData();
		achievementGridItemData.Data = new TItem?(data);
		achievementGridItemData.GetRewardState = (this.AchievementData.GetFinishState() == EAchievementStateEnum.HaveGetReward);
		this.AchievementGridItem.Refresh(achievementGridItemData, false, 0);
	}

	// Token: 0x0600689E RID: 26782 RVA: 0x001B4229 File Offset: 0x001B2429
	protected override void OnBeforeDestroy()
	{
		if (this.StarItem != null)
		{
			this.StarItem.Destroy(null);
		}
		if (this.AchievementGridItem != null)
		{
			this.AchievementGridItem.Destroy(null);
		}
		if (this.AchievementData != null)
		{
			this.AchievementData = null;
		}
		this.RemoveEventListener();
	}

	// Token: 0x040031C7 RID: 12743
	[Nullable(2)]
	private AchievementStarItem StarItem;

	// Token: 0x040031C8 RID: 12744
	[Nullable(2)]
	private AchievementData AchievementData;

	// Token: 0x040031C9 RID: 12745
	[Nullable(2)]
	private AchievementGridItem AchievementGridItem;

	// Token: 0x040031CA RID: 12746
	private static readonly int MaxStarCount = 3;

	// Token: 0x020073B6 RID: 29622
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x04028099 RID: 163993
		Toggle,
		// Token: 0x0402809A RID: 163994
		RedDot,
		// Token: 0x0402809B RID: 163995
		ReceiveBtn,
		// Token: 0x0402809C RID: 163996
		AchieveStateText,
		// Token: 0x0402809D RID: 163997
		CompleteItem,
		// Token: 0x0402809E RID: 163998
		AchieveTitle,
		// Token: 0x0402809F RID: 163999
		AchieveDesc,
		// Token: 0x040280A0 RID: 164000
		AchieveProgress,
		// Token: 0x040280A1 RID: 164001
		CommonGridItem,
		// Token: 0x040280A2 RID: 164002
		StarPos
	}
}
