using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02000FE4 RID: 4068
[NullableContext(1)]
[Nullable(0)]
public class AchievementGroupTitleItem : UiPanelBase
{
	// Token: 0x060068E7 RID: 26855 RVA: 0x001B5453 File Offset: 0x001B3653
	public void Initialize(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x060068E8 RID: 26856 RVA: 0x001B5464 File Offset: 0x001B3664
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
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
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060068E9 RID: 26857 RVA: 0x001B5594 File Offset: 0x001B3794
	protected override void OnStart()
	{
		this.AchievementGridItem = new AchievementGridItem();
		this.AchievementGridItem.Initialize(base.GetItem(1).GetOwner());
		this.AchievementGridItem.SetActive(false);
		this.ProgressConfirmItem = new AchievementProgressConfirmItem(base.GetItem(0));
		this.ProgressConfirmItem.SetClickCallback(new Action(this.OnClickButton));
		this.AddEventListener();
	}

	// Token: 0x060068EA RID: 26858 RVA: 0x001B55FE File Offset: 0x001B37FE
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAchievementGroupDataNotify, new Action<int>(this.OnAchievementGroupDataNotify));
	}

	// Token: 0x060068EB RID: 26859 RVA: 0x001B561C File Offset: 0x001B381C
	public void Update(AchievementGroupData groupData)
	{
		this.GroupData = groupData;
		this.RefreshUi(groupData);
	}

	// Token: 0x060068EC RID: 26860 RVA: 0x001B562C File Offset: 0x001B382C
	private void RefreshUi(AchievementGroupData groupData)
	{
		if (groupData == null)
		{
			return;
		}
		UUIText text = base.GetText(3);
		UUIText text2 = base.GetText(5);
		UUIText text3 = base.GetText(6);
		EAchievementStateEnum finishState = groupData.GetFinishState();
		bool flag = groupData.GetRewards().Count > 0;
		UUIText text4 = base.GetText(2);
		if (text4 != null)
		{
			text4.SetText(groupData.GetTitle(), true);
		}
		text.SetText(groupData.GetAchievementGroupProgress(), true);
		if (text != null)
		{
			text.SetUIActive(flag);
		}
		if (text3 != null)
		{
			text3.SetUIActive(flag);
		}
		base.SetTextureByPath(groupData.GetTexture(), base.GetTexture(4), null, null);
		base.SetTextureByPath(groupData.GetBackgroundIcon(), base.GetTexture(7), null, null);
		AchievementProgressConfirmItem progressConfirmItem = this.ProgressConfirmItem;
		if (progressConfirmItem != null)
		{
			progressConfirmItem.SetActive(finishState == EAchievementStateEnum.CanGetReward && flag);
		}
		AchievementProgressConfirmItem progressConfirmItem2 = this.ProgressConfirmItem;
		if (progressConfirmItem2 != null)
		{
			progressConfirmItem2.RefreshRedPoint(groupData.RedPoint());
		}
		if (!flag)
		{
			if (text2 != null)
			{
				text2.SetUIActive(false);
			}
		}
		else if (finishState == EAchievementStateEnum.CanGetReward)
		{
			if (text2 != null)
			{
				text2.SetUIActive(false);
			}
		}
		else if (finishState == EAchievementStateEnum.HaveGetReward)
		{
			if (text2 != null)
			{
				text2.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "CollectActivity_state_recived", Array.Empty<object>());
		}
		else
		{
			if (text2 != null)
			{
				text2.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "Text_Doing_Text", Array.Empty<object>());
		}
		this.RefreshReward(groupData);
	}

	// Token: 0x060068ED RID: 26861 RVA: 0x001B577C File Offset: 0x001B397C
	private void RefreshReward(AchievementGroupData groupData)
	{
		List<TItem> list = (groupData != null) ? groupData.GetRewards() : null;
		if (list.Count > 0)
		{
			this.AchievementGridItem.SetActive(true);
			AchievementGridItemData achievementGridItemData = new AchievementGridItemData();
			achievementGridItemData.Data = new TItem?(list[0]);
			achievementGridItemData.GetRewardState = (groupData.GetFinishState() == EAchievementStateEnum.HaveGetReward);
			this.AchievementGridItem.Refresh(achievementGridItemData, false, 0);
			return;
		}
		this.AchievementGridItem.SetActive(false);
	}

	// Token: 0x060068EE RID: 26862 RVA: 0x001B57ED File Offset: 0x001B39ED
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
	}

	// Token: 0x060068EF RID: 26863 RVA: 0x001B57F5 File Offset: 0x001B39F5
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAchievementGroupDataNotify, new Action<int>(this.OnAchievementGroupDataNotify));
	}

	// Token: 0x060068F0 RID: 26864 RVA: 0x001B5813 File Offset: 0x001B3A13
	private void OnAchievementGroupDataNotify(int groupId)
	{
		this.RefreshUi(this.GroupData);
	}

	// Token: 0x060068F1 RID: 26865 RVA: 0x001B5821 File Offset: 0x001B3A21
	private void OnClickButton()
	{
		ControllerBase<AchievementController>.Instance.RequestGetAchievementReward(true, this.GroupData.GetId());
	}

	// Token: 0x040031E5 RID: 12773
	[Nullable(2)]
	private AchievementGroupData GroupData;

	// Token: 0x040031E6 RID: 12774
	[Nullable(2)]
	private AchievementGridItem AchievementGridItem;

	// Token: 0x040031E7 RID: 12775
	[Nullable(2)]
	private AchievementProgressConfirmItem ProgressConfirmItem;

	// Token: 0x020073C1 RID: 29633
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x040280D2 RID: 164050
		Confirm,
		// Token: 0x040280D3 RID: 164051
		CommonGridItem,
		// Token: 0x040280D4 RID: 164052
		Title,
		// Token: 0x040280D5 RID: 164053
		Progress,
		// Token: 0x040280D6 RID: 164054
		IconTexture,
		// Token: 0x040280D7 RID: 164055
		ProgressingText,
		// Token: 0x040280D8 RID: 164056
		ProgressPreText,
		// Token: 0x040280D9 RID: 164057
		BackgroundTexture
	}
}
