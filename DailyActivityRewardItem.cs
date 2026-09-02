using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AA2 RID: 6818
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DailyActivityRewardItem : GridProxyAbstract<DailyActivityRewardData>
{
	// Token: 0x0600C34C RID: 49996 RVA: 0x0033744F File Offset: 0x0033564F
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600C34D RID: 49997 RVA: 0x00337488 File Offset: 0x00335688
	protected override UniTask OnBeforeStartAsync()
	{
		DailyActivityRewardItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DailyActivityRewardItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C34E RID: 49998 RVA: 0x003374CC File Offset: 0x003356CC
	[NullableContext(1)]
	public override void Refresh(DailyActivityRewardData data, bool isSelected, int gridIndex)
	{
		double progress = data.Progress;
		float num = (float)(gridIndex + 1) / (float)data.MaxIndex;
		float num2 = (float)gridIndex / (float)data.MaxIndex;
		if (progress >= (double)num)
		{
			this.ProgressSprite.SetFillAmount(1f);
		}
		else
		{
			double num3 = progress - (double)num2;
			double num4 = (num3 > 0.0) ? (num3 / (double)(num - num2)) : 0.0;
			this.ProgressSprite.SetFillAmount((float)num4);
		}
		this.Data = data;
		this.RewardItem.Refresh(data.RewardId, isSelected, gridIndex);
		this.DailyActiveState = this.RewardItem.DailyActiveState;
	}

	// Token: 0x0600C34F RID: 49999 RVA: 0x0033756C File Offset: 0x0033576C
	public void RefreshProgress(double progress)
	{
		this.Data.Progress = progress;
		this.RefreshSelf();
	}

	// Token: 0x0600C350 RID: 50000 RVA: 0x00337580 File Offset: 0x00335780
	public void RefreshSelf()
	{
		this.Refresh(this.Data, false, base.GridIndex);
	}

	// Token: 0x0600C351 RID: 50001 RVA: 0x00337598 File Offset: 0x00335798
	public UniTask PlayRewardAnimAsync()
	{
		DailyActivityRewardItem.<PlayRewardAnimAsync>d__12 <PlayRewardAnimAsync>d__;
		<PlayRewardAnimAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayRewardAnimAsync>d__.<>4__this = this;
		<PlayRewardAnimAsync>d__.<>1__state = -1;
		<PlayRewardAnimAsync>d__.<>t__builder.Start<DailyActivityRewardItem.<PlayRewardAnimAsync>d__12>(ref <PlayRewardAnimAsync>d__);
		return <PlayRewardAnimAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04005D8D RID: 23949
	private UUISprite ProgressSprite;

	// Token: 0x04005D8E RID: 23950
	private DailyActivityRewardItemContent RewardItem;

	// Token: 0x04005D8F RID: 23951
	private DailyActivityRewardData Data;

	// Token: 0x04005D90 RID: 23952
	public EDailyActiveState? DailyActiveState;

	// Token: 0x04005D91 RID: 23953
	public Action RewardRequestDelegate;

	// Token: 0x04005D92 RID: 23954
	public DailyActivityDefine.IActivityRewardPanelDataAdapter DataAdapter;

	// Token: 0x04005D93 RID: 23955
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<RewardPopupData> ShowRewardPopupDelegate;
}
