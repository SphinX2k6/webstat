using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink
{
	// Token: 0x020066FA RID: 26362
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorDecalLinkMainViewModel
	{
		// Token: 0x1700A09B RID: 41115
		// (get) Token: 0x06041CCA RID: 269514 RVA: 0x010E1740 File Offset: 0x010DF940
		public int ActivityId
		{
			get
			{
				return this.ActivityIdPrivate;
			}
		}

		// Token: 0x06041CCB RID: 269515 RVA: 0x010E1748 File Offset: 0x010DF948
		public void InitFromActivityDataIfNot(MotorDecalLinkData activityData)
		{
			int num = (activityData != null) ? activityData.Id : 0;
			if (this.ActivityIdPrivate == num)
			{
				return;
			}
			this.ActivityIdPrivate = num;
			this.HelpId = ((activityData != null) ? activityData.GetHelpId() : 0);
			this.CaptionTitle = ((activityData != null) ? activityData.GetTitleTextId() : "");
			IReadOnlyList<MotorDecalIp> ipConfigListByActivityId = ConfigBase<MotorDecalLinkConfig>.Instance.GetIpConfigListByActivityId(num);
			List<int> list = new List<int>();
			for (int i = 0; i < ipConfigListByActivityId.Count; i++)
			{
				MotorDecalIp config = ipConfigListByActivityId[i];
				MotorDecalLinkIpViewModel motorDecalLinkIpViewModel = new MotorDecalLinkIpViewModel();
				motorDecalLinkIpViewModel.InitFromConfig(config, i);
				motorDecalLinkIpViewModel.ActivityId = num;
				this.IpList.Add(motorDecalLinkIpViewModel);
				list.Add(config.Id);
			}
			string message = "MainViewModel初始化";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ipList", list);
			MotorDecalLinkUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.SelectIpIndex(0);
		}

		// Token: 0x06041CCC RID: 269516 RVA: 0x010E1825 File Offset: 0x010DFA25
		public void SelectIpIndex(int index)
		{
			if (index < 0 || index >= this.IpList.Count)
			{
				return;
			}
			this.CurrentIpIndex = index;
		}

		// Token: 0x06041CCD RID: 269517 RVA: 0x010E1844 File Offset: 0x010DFA44
		public void MoveSelectIpIndex(int delta)
		{
			int num = this.CurrentIpIndex + delta;
			num %= this.IpList.Count;
			if (num < 0)
			{
				num += this.IpList.Count;
			}
			this.SelectIpIndex(num);
		}

		// Token: 0x06041CCE RID: 269518 RVA: 0x010E1884 File Offset: 0x010DFA84
		public void RefreshIpTaskStates(Dictionary<int, ActivityTaskData> activityQuestData)
		{
			foreach (MotorDecalLinkIpViewModel motorDecalLinkIpViewModel in this.IpList)
			{
				motorDecalLinkIpViewModel.RefreshTaskStates(activityQuestData);
			}
			this.RefreshProgress(activityQuestData);
		}

		// Token: 0x06041CCF RID: 269519 RVA: 0x010E18DC File Offset: 0x010DFADC
		private void RefreshProgress(Dictionary<int, ActivityTaskData> activityQuestData)
		{
			this.ProgressTotalCount = activityQuestData.Count;
			this.ProgressCompletedCount = 0;
			foreach (KeyValuePair<int, ActivityTaskData> keyValuePair in activityQuestData)
			{
				if (keyValuePair.Value.Status == EActivityTaskState.FinishedAndClaimed)
				{
					this.ProgressCompletedCount++;
				}
			}
			this.ProgressText = this.ProgressCompletedCount.ToString() + "/" + this.ProgressTotalCount.ToString();
		}

		// Token: 0x06041CD0 RID: 269520 RVA: 0x010E197C File Offset: 0x010DFB7C
		[NullableContext(2)]
		public MotorDecalLinkIpViewModel GetCurrentIpViewModel()
		{
			if (this.CurrentIpIndex < 0 || this.CurrentIpIndex >= this.IpList.Count)
			{
				return null;
			}
			return this.IpList[this.CurrentIpIndex];
		}

		// Token: 0x04024B45 RID: 150341
		private int ActivityIdPrivate;

		// Token: 0x04024B46 RID: 150342
		public int HelpId;

		// Token: 0x04024B47 RID: 150343
		public string CaptionTitle = "";

		// Token: 0x04024B48 RID: 150344
		public List<MotorDecalLinkIpViewModel> IpList = new List<MotorDecalLinkIpViewModel>();

		// Token: 0x04024B49 RID: 150345
		public int CurrentIpIndex;

		// Token: 0x04024B4A RID: 150346
		public string ProgressText = "";

		// Token: 0x04024B4B RID: 150347
		public int ProgressCompletedCount;

		// Token: 0x04024B4C RID: 150348
		public int ProgressTotalCount;

		// Token: 0x04024B4D RID: 150349
		public bool HasFirstRead;

		// Token: 0x04024B4E RID: 150350
		public bool HasRewardCanReceive;
	}
}
