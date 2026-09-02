using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.SkipInterface;

// Token: 0x020024BF RID: 9407
[NullableContext(2)]
[Nullable(0)]
public class PhantomInteractDetailViewModel
{
	// Token: 0x1700173E RID: 5950
	// (get) Token: 0x06012453 RID: 74835 RVA: 0x00506960 File Offset: 0x00504B60
	// (set) Token: 0x06012454 RID: 74836 RVA: 0x00506968 File Offset: 0x00504B68
	public int MonsterId { get; set; }

	// Token: 0x1700173F RID: 5951
	// (get) Token: 0x06012455 RID: 74837 RVA: 0x00506971 File Offset: 0x00504B71
	// (set) Token: 0x06012456 RID: 74838 RVA: 0x00506979 File Offset: 0x00504B79
	public string IconPath { get; set; }

	// Token: 0x17001740 RID: 5952
	// (get) Token: 0x06012457 RID: 74839 RVA: 0x00506982 File Offset: 0x00504B82
	// (set) Token: 0x06012458 RID: 74840 RVA: 0x0050698A File Offset: 0x00504B8A
	public string Name { get; set; }

	// Token: 0x17001741 RID: 5953
	// (get) Token: 0x06012459 RID: 74841 RVA: 0x00506993 File Offset: 0x00504B93
	// (set) Token: 0x0601245A RID: 74842 RVA: 0x0050699B File Offset: 0x00504B9B
	public bool IsSpecial { get; set; }

	// Token: 0x17001742 RID: 5954
	// (get) Token: 0x0601245B RID: 74843 RVA: 0x005069A4 File Offset: 0x00504BA4
	// (set) Token: 0x0601245C RID: 74844 RVA: 0x005069AC File Offset: 0x00504BAC
	public bool IsInArea { get; set; }

	// Token: 0x17001743 RID: 5955
	// (get) Token: 0x0601245D RID: 74845 RVA: 0x005069B5 File Offset: 0x00504BB5
	// (set) Token: 0x0601245E RID: 74846 RVA: 0x005069BD File Offset: 0x00504BBD
	public bool IsUnlocked { get; set; }

	// Token: 0x17001744 RID: 5956
	// (get) Token: 0x0601245F RID: 74847 RVA: 0x005069C6 File Offset: 0x00504BC6
	// (set) Token: 0x06012460 RID: 74848 RVA: 0x005069CE File Offset: 0x00504BCE
	public string SkillPicturePath { get; set; }

	// Token: 0x17001745 RID: 5957
	// (get) Token: 0x06012461 RID: 74849 RVA: 0x005069D7 File Offset: 0x00504BD7
	// (set) Token: 0x06012462 RID: 74850 RVA: 0x005069DF File Offset: 0x00504BDF
	public string SkillName { get; set; }

	// Token: 0x17001746 RID: 5958
	// (get) Token: 0x06012463 RID: 74851 RVA: 0x005069E8 File Offset: 0x00504BE8
	// (set) Token: 0x06012464 RID: 74852 RVA: 0x005069F0 File Offset: 0x00504BF0
	public string SkillDescription { get; set; }

	// Token: 0x17001747 RID: 5959
	// (get) Token: 0x06012465 RID: 74853 RVA: 0x005069F9 File Offset: 0x00504BF9
	// (set) Token: 0x06012466 RID: 74854 RVA: 0x00506A01 File Offset: 0x00504C01
	public IGetWayItemData GetWayItemData { get; set; }

	// Token: 0x17001748 RID: 5960
	// (get) Token: 0x06012467 RID: 74855 RVA: 0x00506A0A File Offset: 0x00504C0A
	public bool NeedGetWay
	{
		get
		{
			return this.IsSpecial && !this.IsUnlocked;
		}
	}

	// Token: 0x17001749 RID: 5961
	// (get) Token: 0x06012468 RID: 74856 RVA: 0x00506A1F File Offset: 0x00504C1F
	// (set) Token: 0x06012469 RID: 74857 RVA: 0x00506A27 File Offset: 0x00504C27
	private int GetWayConfigId { get; set; }

	// Token: 0x0601246A RID: 74858 RVA: 0x00506A30 File Offset: 0x00504C30
	public void RefreshData(IPhantomInteractGridViewModel gridViewModel)
	{
		if (gridViewModel == null)
		{
			return;
		}
		this.MonsterId = gridViewModel.MonsterId;
		CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(this.MonsterId);
		if (calabashDevelopRewardByMonsterId == null)
		{
			return;
		}
		this.Name = gridViewModel.Name;
		this.IconPath = gridViewModel.IconPath;
		this.IsSpecial = gridViewModel.IsSpecial;
		this.IsInArea = gridViewModel.IsInArea;
		this.IsUnlocked = gridViewModel.IsUnlocked;
		this.SkillPicturePath = calabashDevelopRewardByMonsterId.Value.SpecialSkillPicturePath;
		this.SkillName = calabashDevelopRewardByMonsterId.Value.SpecialSkillName;
		this.SkillDescription = calabashDevelopRewardByMonsterId.Value.SpecialSkillDescription;
		if (this.NeedGetWay && this.GetWayConfigId != gridViewModel.GetWayConfigId)
		{
			this.GetWayItemData = null;
			this.GetWayConfigId = gridViewModel.GetWayConfigId;
			if (this.GetWayConfigId > 0)
			{
				AccessPath? getWayConfig = ConfigBase<GetWayConfig>.Instance.GetConfigById(this.GetWayConfigId);
				if (getWayConfig != null)
				{
					this.GetWayItemData = new GetWayItemData(getWayConfig.Value.Id, EGetWayItemType.CanJump, "PhantomDisplay_AccessTips", 0, delegate()
					{
						SkipTaskManager.RunByConfigId(getWayConfig.Value.Id, null);
					});
				}
			}
		}
	}
}
