using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FE9 RID: 4073
[NullableContext(2)]
[Nullable(0)]
public class AchievementSearchContentItem : UiPanelBase
{
	// Token: 0x0600691C RID: 26908 RVA: 0x001B6742 File Offset: 0x001B4942
	[NullableContext(1)]
	public AchievementSearchContentItem(UUIItem uiItem)
	{
		this.SourceItem = uiItem;
	}

	// Token: 0x0600691D RID: 26909 RVA: 0x001B6754 File Offset: 0x001B4954
	public UniTask Init()
	{
		AchievementSearchContentItem.<Init>d__8 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<AchievementSearchContentItem.<Init>d__8>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600691E RID: 26910 RVA: 0x001B6798 File Offset: 0x001B4998
	[NullableContext(1)]
	public FVector2D GetItemSize(Vector2D vector)
	{
		UUIItem rootItem = base.GetRootItem();
		vector.Set((double)rootItem.GetWidth(), (double)rootItem.GetHeight());
		return vector.ToUeVector2D(false);
	}

	// Token: 0x0600691F RID: 26911 RVA: 0x001B67C7 File Offset: 0x001B49C7
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x06006920 RID: 26912 RVA: 0x001B67D0 File Offset: 0x001B49D0
	[NullableContext(1)]
	public AUIBaseActor GetUsingItem()
	{
		return (AUIBaseActor)base.GetRootItem().GetOwner();
	}

	// Token: 0x06006921 RID: 26913 RVA: 0x001B67E4 File Offset: 0x001B49E4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006922 RID: 26914 RVA: 0x001B68F4 File Offset: 0x001B4AF4
	protected override void OnStart()
	{
		this.AchievementProgressItem = new AchievementProgressItem(base.GetItem(6));
		this.AchievementProgressItem.SetActive(true);
		this.AchievementGridItem = new AchievementGridItem();
		this.AchievementGridItem.Initialize(base.GetItem(1).GetOwner());
		this.ConfirmItem = new AchievementProgressConfirmItem(base.GetItem(0));
		this.ConfirmItem.SetClickCallback(new Action(this.OnClickButton));
		this.AddEventListener();
	}

	// Token: 0x06006923 RID: 26915 RVA: 0x001B6970 File Offset: 0x001B4B70
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAchievementDataWithIdNotify, new Action<int>(this.OnAchievementDataWithIdNotify));
	}

	// Token: 0x06006924 RID: 26916 RVA: 0x001B698E File Offset: 0x001B4B8E
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAchievementDataWithIdNotify, new Action<int>(this.OnAchievementDataWithIdNotify));
	}

	// Token: 0x06006925 RID: 26917 RVA: 0x001B69AC File Offset: 0x001B4BAC
	private void OnAchievementDataWithIdNotify(int id)
	{
		if (ModelBase<AchievementModel>.Instance.AchievementSearchState)
		{
			return;
		}
		AchievementData achievementData = this.AchievementData;
		int? num = (achievementData != null) ? new int?(achievementData.GetId()) : null;
		if ((id == num.GetValueOrDefault() & num != null) && (this.AchievementData.IfSingleAchievement() || (!this.AchievementData.IfSingleAchievement() && this.AchievementData.GetNextLink() == 0)))
		{
			this.RefreshDesc();
			this.RefreshProgress();
			this.RefreshStar();
			this.RefreshRedPoint();
			this.RefreshReward();
			this.RefreshConfirmBtnState();
			this.RefreshAchievementProgressItem();
		}
	}

	// Token: 0x06006926 RID: 26918 RVA: 0x001B6A4B File Offset: 0x001B4C4B
	private void OnClickButton()
	{
		ControllerBase<AchievementController>.Instance.RequestGetAchievementReward(false, this.AchievementData.GetId());
	}

	// Token: 0x06006927 RID: 26919 RVA: 0x001B6A63 File Offset: 0x001B4C63
	[NullableContext(1)]
	public void Update(AchievementSearchData data)
	{
		this.AchievementData = data.AchievementData;
		this.RefreshTitle();
		this.RefreshDesc();
		this.RefreshProgress();
		this.RefreshStar();
		this.RefreshRedPoint();
		this.RefreshReward();
		this.RefreshConfirmBtnState();
		this.RefreshAchievementProgressItem();
	}

	// Token: 0x06006928 RID: 26920 RVA: 0x001B6AA4 File Offset: 0x001B4CA4
	private void RefreshTitle()
	{
		if (ModelBase<AchievementModel>.Instance.AchievementSearchState)
		{
			base.GetText(2).SetText(this.AchievementData.GetReplaceTitle(ModelBase<AchievementModel>.Instance.CurrentSearchText), true);
			return;
		}
		base.GetText(2).SetText(this.AchievementData.GetTitle(), true);
	}

	// Token: 0x06006929 RID: 26921 RVA: 0x001B6AF8 File Offset: 0x001B4CF8
	private void RefreshDesc()
	{
		if (ModelBase<AchievementModel>.Instance.AchievementSearchState)
		{
			base.GetText(4).SetText(this.AchievementData.GetReplaceDesc(ModelBase<AchievementModel>.Instance.CurrentSearchText), true);
			return;
		}
		base.GetText(4).SetText(this.AchievementData.GetDesc(), true);
	}

	// Token: 0x0600692A RID: 26922 RVA: 0x001B6B4C File Offset: 0x001B4D4C
	private void RefreshProgress()
	{
		int? currentProgress = this.AchievementData.GetCurrentProgress();
		int? maxProgress = this.AchievementData.GetMaxProgress();
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "CollectProgress", new <>z__ReadOnlyArray<object>(new object[]
		{
			currentProgress,
			maxProgress
		}));
	}

	// Token: 0x0600692B RID: 26923 RVA: 0x001B6BA4 File Offset: 0x001B4DA4
	private void RefreshStar()
	{
		if (this.StarItem != null)
		{
			this.StarItem.Destroy(null);
			this.StarItem = null;
		}
		int count = this.AchievementData.IfSingleAchievement() ? this.AchievementData.GetAchievementShowStar() : AchievementSearchContentItem.MaxStarCount;
		this.StarItem = new AchievementStarItem(count, this.AchievementData, base.GetItem(5));
	}

	// Token: 0x0600692C RID: 26924 RVA: 0x001B6C05 File Offset: 0x001B4E05
	private void RefreshRedPoint()
	{
		this.ConfirmItem.RefreshRedPoint(this.AchievementData.RedPoint());
	}

	// Token: 0x0600692D RID: 26925 RVA: 0x001B6C1D File Offset: 0x001B4E1D
	private void RefreshConfirmBtnState()
	{
		this.ConfirmItem.SetActive(this.AchievementData.GetFinishState() == EAchievementStateEnum.CanGetReward);
	}

	// Token: 0x0600692E RID: 26926 RVA: 0x001B6C38 File Offset: 0x001B4E38
	private void RefreshAchievementProgressItem()
	{
		this.AchievementProgressItem.RefreshState(this.AchievementData);
	}

	// Token: 0x0600692F RID: 26927 RVA: 0x001B6C4C File Offset: 0x001B4E4C
	private void RefreshReward()
	{
		List<TItem> rewards = this.AchievementData.GetRewards();
		if (rewards.Count > 0)
		{
			this.RefreshRewardItem(rewards[0]);
		}
	}

	// Token: 0x06006930 RID: 26928 RVA: 0x001B6C7C File Offset: 0x001B4E7C
	private void RefreshRewardItem(TItem data)
	{
		AchievementGridItemData achievementGridItemData = new AchievementGridItemData();
		achievementGridItemData.Data = new TItem?(data);
		achievementGridItemData.GetRewardState = (this.AchievementData.GetFinishState() == EAchievementStateEnum.HaveGetReward);
		this.AchievementGridItem.Refresh(achievementGridItemData, false, 0);
	}

	// Token: 0x06006931 RID: 26929 RVA: 0x001B6CBD File Offset: 0x001B4EBD
	protected override void OnBeforeDestroy()
	{
		if (this.StarItem != null)
		{
			this.StarItem.Destroy(null);
			this.StarItem = null;
		}
		this.RemoveEventListener();
	}

	// Token: 0x040031F8 RID: 12792
	private AchievementStarItem StarItem;

	// Token: 0x040031F9 RID: 12793
	private AchievementData AchievementData;

	// Token: 0x040031FA RID: 12794
	private AchievementProgressItem AchievementProgressItem;

	// Token: 0x040031FB RID: 12795
	private AchievementGridItem AchievementGridItem;

	// Token: 0x040031FC RID: 12796
	private AchievementProgressConfirmItem ConfirmItem;

	// Token: 0x040031FD RID: 12797
	private static readonly int MaxStarCount = 3;

	// Token: 0x040031FE RID: 12798
	private readonly UUIItem SourceItem;

	// Token: 0x020073C7 RID: 29639
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x040280F2 RID: 164082
		Confirm,
		// Token: 0x040280F3 RID: 164083
		CommonGridItem,
		// Token: 0x040280F4 RID: 164084
		Title,
		// Token: 0x040280F5 RID: 164085
		Progress,
		// Token: 0x040280F6 RID: 164086
		Desc,
		// Token: 0x040280F7 RID: 164087
		StarPos,
		// Token: 0x040280F8 RID: 164088
		ProgressBox
	}
}
