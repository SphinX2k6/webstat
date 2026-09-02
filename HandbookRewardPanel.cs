using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020013EC RID: 5100
[NullableContext(1)]
[Nullable(0)]
public class HandbookRewardPanel : UiPanelBase
{
	// Token: 0x06008D62 RID: 36194 RVA: 0x00252E4C File Offset: 0x0025104C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUISprite))
		};
	}

	// Token: 0x06008D63 RID: 36195 RVA: 0x00252F00 File Offset: 0x00251100
	protected override void OnStart()
	{
		this.RewardLayout = new GenericLayout<HandbookRewardItem, int>(base.GetHorizontalLayout(3), new Func<HandbookRewardItem>(this.OnCreateRewardItem), null, false, true);
		UUIItem item = base.GetItem(0);
		this.MaxProgressWidth = item.GetWidth();
		this.ProgressBarItem = base.GetItem(0);
		base.GetSprite(2).SetUIActive(false);
		base.GetSprite(6).SetUIActive(false);
	}

	// Token: 0x06008D64 RID: 36196 RVA: 0x00252F69 File Offset: 0x00251169
	protected override void OnBeforeShow()
	{
		this.Refresh();
	}

	// Token: 0x06008D65 RID: 36197 RVA: 0x00252F71 File Offset: 0x00251171
	protected override void OnBeforeDestroy()
	{
		this.ProgressBarItem = null;
	}

	// Token: 0x06008D66 RID: 36198 RVA: 0x00252F7C File Offset: 0x0025117C
	public void Refresh()
	{
		this.RewardIdList = ModelBase<MoonChasingModel>.Instance.HandbookRewardIdList;
		this.CurrentValue = ModelBase<MoonChasingModel>.Instance.GetHandbookUnlockCount();
		this.CurrentFinishedRewardCount = 0;
		for (int i = 0; i < this.RewardIdList.Count; i++)
		{
			int id = this.RewardIdList[i];
			HandbookRewardData handbookRewardDataById = ModelBase<MoonChasingModel>.Instance.GetHandbookRewardDataById(id);
			if (handbookRewardDataById != null)
			{
				if (handbookRewardDataById.GetState(this.CurrentValue) != EHandbookRewardState.Active)
				{
					this.CurrentFinishedRewardCount++;
				}
				this.MaxValue = Math.Max(handbookRewardDataById.Goal, this.MaxValue);
			}
		}
		this.TotalRewardCount = this.RewardIdList.Count;
		if (this.TotalRewardCount <= 0)
		{
			return;
		}
		this.RewardLayout.RefreshByData(this.RewardIdList, null, false);
		this.LineWidth = (this.MaxProgressWidth - this.RewardWidth * (float)(this.TotalRewardCount - 1)) / (float)this.TotalRewardCount;
		this.SetProgressBarPercent((float)this.CurrentValue / (float)this.MaxValue);
	}

	// Token: 0x06008D67 RID: 36199 RVA: 0x0025307D File Offset: 0x0025127D
	public void RefreshLayout()
	{
		this.RewardIdList = ModelBase<MoonChasingModel>.Instance.HandbookRewardIdList;
		this.RewardLayout.RefreshByData(this.RewardIdList, null, false);
	}

	// Token: 0x06008D68 RID: 36200 RVA: 0x002530A4 File Offset: 0x002512A4
	private void SetProgressBarPercent(float percent)
	{
		float num = (float)Math.Min(this.CurrentFinishedRewardCount, this.TotalRewardCount - 1) * this.RewardWidth;
		float num2 = this.LineWidth * (float)this.TotalRewardCount * Math.Min(percent, 1f);
		float stretchRight = this.MaxProgressWidth - num - num2;
		this.ProgressBarItem.SetStretchRight(stretchRight);
	}

	// Token: 0x06008D69 RID: 36201 RVA: 0x00253100 File Offset: 0x00251300
	private HandbookRewardItem OnCreateRewardItem()
	{
		UUIItem item = base.GetItem(1);
		UUISprite sprite = base.GetSprite(2);
		Singleton<LguiUtil>.Instance.CopyItem(sprite, item).SetUIActive(true);
		UUIItem item2 = base.GetItem(5);
		UUISprite sprite2 = base.GetSprite(6);
		Singleton<LguiUtil>.Instance.CopyItem(sprite2, item2).SetUIActive(true);
		return new HandbookRewardItem();
	}

	// Token: 0x040041D9 RID: 16857
	private GenericLayout<HandbookRewardItem, int> RewardLayout;

	// Token: 0x040041DA RID: 16858
	private UUIItem ProgressBarItem;

	// Token: 0x040041DB RID: 16859
	private int CurrentValue;

	// Token: 0x040041DC RID: 16860
	private int MaxValue;

	// Token: 0x040041DD RID: 16861
	private List<int> RewardIdList = new List<int>();

	// Token: 0x040041DE RID: 16862
	private int CurrentFinishedRewardCount;

	// Token: 0x040041DF RID: 16863
	private float MaxProgressWidth;

	// Token: 0x040041E0 RID: 16864
	private readonly float RewardWidth = 120f;

	// Token: 0x040041E1 RID: 16865
	private float LineWidth;

	// Token: 0x040041E2 RID: 16866
	private int TotalRewardCount;

	// Token: 0x020077E3 RID: 30691
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029411 RID: 168977
		public const int ProgressPanel = 0;

		// Token: 0x04029412 RID: 168978
		public const int BarPanel = 1;

		// Token: 0x04029413 RID: 168979
		public const int BarSprite = 2;

		// Token: 0x04029414 RID: 168980
		public const int RewardPanel = 3;

		// Token: 0x04029415 RID: 168981
		public const int RewardItem = 4;

		// Token: 0x04029416 RID: 168982
		public const int PanelBackground = 5;

		// Token: 0x04029417 RID: 168983
		public const int BackgroundSprite = 6;
	}
}
