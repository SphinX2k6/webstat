using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200126E RID: 4718
[NullableContext(1)]
[Nullable(0)]
public class BlackCoastRewardPanel : UiPanelBase
{
	// Token: 0x06007DF6 RID: 32246 RVA: 0x00213E20 File Offset: 0x00212020
	public BlackCoastRewardPanel(ActivityBlackCoastData data)
	{
		this.ActivityBaseData = data;
	}

	// Token: 0x06007DF7 RID: 32247 RVA: 0x00213E3C File Offset: 0x0021203C
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007DF8 RID: 32248 RVA: 0x00213F4C File Offset: 0x0021214C
	protected override void OnStart()
	{
		this.RewardLayout = new GenericLayout<BlackCoastRewardItem, BlackCoastProgressRewardData>(base.GetHorizontalLayout(3), new Func<BlackCoastRewardItem>(this.OnCreateRewardItem), null, false, true);
		UUIItem item = base.GetItem(0);
		this.MaxProgressWidth = item.GetWidth();
		this.ProgressBarItem = base.GetItem(0);
		base.GetSprite(2).SetUIActive(false);
		base.GetSprite(6).SetUIActive(false);
	}

	// Token: 0x06007DF9 RID: 32249 RVA: 0x00213FB5 File Offset: 0x002121B5
	protected override void OnBeforeDestroy()
	{
		this.ProgressBarItem = null;
	}

	// Token: 0x06007DFA RID: 32250 RVA: 0x00213FC0 File Offset: 0x002121C0
	public void Refresh()
	{
		this.CurrentValue = this.ActivityBaseData.GetProgressItemCount();
		this.CurrentFinishedRewardCount = 0;
		BlackCoastProgressRewardData[] allProgressRewardData = this.ActivityBaseData.GetAllProgressRewardData();
		foreach (BlackCoastProgressRewardData blackCoastProgressRewardData in allProgressRewardData)
		{
			if (blackCoastProgressRewardData.GetState() != EActivityTaskState.Active)
			{
				this.CurrentFinishedRewardCount++;
			}
			this.MaxValue = Math.Max(blackCoastProgressRewardData.Goal, this.MaxValue);
		}
		this.TotalRewardCount = allProgressRewardData.Length;
		if (this.TotalRewardCount <= 0)
		{
			return;
		}
		this.RewardLayout.RefreshByData(allProgressRewardData.ToList<BlackCoastProgressRewardData>(), null, false);
		this.LineWidth = (this.MaxProgressWidth - this.RewardWidth * (float)(this.TotalRewardCount - 1)) / (float)this.TotalRewardCount;
		this.SetProgressBarPercent((float)this.CurrentValue / (float)this.MaxValue);
	}

	// Token: 0x06007DFB RID: 32251 RVA: 0x00214093 File Offset: 0x00212293
	public void RefreshLayout()
	{
		this.RewardLayout.RefreshByData(this.ActivityBaseData.GetAllProgressRewardData().ToList<BlackCoastProgressRewardData>(), null, false);
	}

	// Token: 0x06007DFC RID: 32252 RVA: 0x002140B4 File Offset: 0x002122B4
	private void SetProgressBarPercent(float percent)
	{
		float num = (float)Math.Min(this.CurrentFinishedRewardCount, this.TotalRewardCount - 1) * this.RewardWidth;
		float num2 = this.LineWidth * (float)this.TotalRewardCount * Math.Min(percent, 1f);
		float stretchRight = this.MaxProgressWidth - num - num2;
		this.ProgressBarItem.SetStretchRight(stretchRight);
	}

	// Token: 0x06007DFD RID: 32253 RVA: 0x00214110 File Offset: 0x00212310
	private BlackCoastRewardItem OnCreateRewardItem()
	{
		UUIItem item = base.GetItem(1);
		UUISprite sprite = base.GetSprite(2);
		Singleton<LguiUtil>.Instance.CopyItem(sprite, item).SetUIActive(true);
		UUIItem item2 = base.GetItem(5);
		UUISprite sprite2 = base.GetSprite(6);
		Singleton<LguiUtil>.Instance.CopyItem(sprite2, item2).SetUIActive(true);
		return new BlackCoastRewardItem
		{
			RequestGetAllAvailableReward = delegate()
			{
				int[] allAvailableProgressRewardIds = this.ActivityBaseData.GetAllAvailableProgressRewardIds();
				if (allAvailableProgressRewardIds.Length != 0)
				{
					ControllerBase<ActivityBlackCoastController>.Instance.RequestDataProgressReward(this.ActivityBaseData.Id, allAvailableProgressRewardIds);
				}
			}
		};
	}

	// Token: 0x04003C73 RID: 15475
	private const float REWARD_WIDTH = 120f;

	// Token: 0x04003C74 RID: 15476
	protected ActivityBlackCoastData ActivityBaseData;

	// Token: 0x04003C75 RID: 15477
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<BlackCoastRewardItem, BlackCoastProgressRewardData> RewardLayout;

	// Token: 0x04003C76 RID: 15478
	[Nullable(2)]
	private UUIItem ProgressBarItem;

	// Token: 0x04003C77 RID: 15479
	private int CurrentValue;

	// Token: 0x04003C78 RID: 15480
	private int MaxValue;

	// Token: 0x04003C79 RID: 15481
	private int CurrentFinishedRewardCount;

	// Token: 0x04003C7A RID: 15482
	private float MaxProgressWidth;

	// Token: 0x04003C7B RID: 15483
	private readonly float RewardWidth = 120f;

	// Token: 0x04003C7C RID: 15484
	private float LineWidth;

	// Token: 0x04003C7D RID: 15485
	private int TotalRewardCount;

	// Token: 0x020075EA RID: 30186
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028A97 RID: 166551
		public const int ProgressPanel = 0;

		// Token: 0x04028A98 RID: 166552
		public const int BarPanel = 1;

		// Token: 0x04028A99 RID: 166553
		public const int BarSprite = 2;

		// Token: 0x04028A9A RID: 166554
		public const int RewardPanel = 3;

		// Token: 0x04028A9B RID: 166555
		public const int RewardItem = 4;

		// Token: 0x04028A9C RID: 166556
		public const int PanelBackground = 5;

		// Token: 0x04028A9D RID: 166557
		public const int BackgroundSprite = 6;
	}
}
