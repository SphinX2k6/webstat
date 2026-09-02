using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.ResManager;

namespace CSharpScript.Game.Module.WorldMap.RegionalTerminal.Data
{
	// Token: 0x02004BF4 RID: 19444
	[NullableContext(2)]
	[Nullable(0)]
	public class RegionalTerminalActivityData : RegionalTerminalGameplayData
	{
		// Token: 0x1700871D RID: 34589
		// (get) Token: 0x06032BD5 RID: 207829 RVA: 0x00CB619E File Offset: 0x00CB439E
		private ActivityBaseData ActivityBaseData
		{
			get
			{
				return ModelBase<ActivityModel>.Instance.GetActivityById(this.GameplayId);
			}
		}

		// Token: 0x06032BD6 RID: 207830 RVA: 0x00CB61B0 File Offset: 0x00CB43B0
		public override void TerminalFunction(Action<bool> callback = null)
		{
			if (this.ActivityBaseData == null)
			{
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			if (!this.GetShowState())
			{
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			AreaTerminalActivitySkipLogEvent areaTerminalActivitySkipLogEvent = new AreaTerminalActivitySkipLogEvent();
			areaTerminalActivitySkipLogEvent.i_id = this.Id;
			if (this.ActivityBaseData.CanPreOpen() && !this.ActivityBaseData.IsUnLock())
			{
				ControllerBase<ActivityController>.Instance.OpenActivityById(this.ActivityBaseData.Id, EActivityViewOpenType.Other, null, null);
				if (callback != null)
				{
					callback(true);
				}
				areaTerminalActivitySkipLogEvent.i_type = 3;
				ControllerBase<LogReportController>.Instance.LogReport(areaTerminalActivitySkipLogEvent);
				return;
			}
			if (!ModelBase<SubPackageDownLoadModel>.Instance.CheckActivityTeleportHaveSubPackage(this.ActivityBaseData.Id))
			{
				int[] downLoadSubPackageListArray = this.ActivityBaseData.LocalConfig.Value.GetDownLoadSubPackageListArray();
				foreach (int id in downLoadSubPackageListArray)
				{
					DownLoadSubPackage? downLoadSubPackageById = ConfigBase<SubPackageConfig>.Instance.GetDownLoadSubPackageById(id);
					if (downLoadSubPackageById != null)
					{
						foreach (int blockId in downLoadSubPackageById.Value.GetAreaArray())
						{
							if (ControllerBase<ResourceManagerController>.Instance.IsNeedReOpenMap(blockId))
							{
								ModelBase<SubPackageDownLoadModel>.Instance.OpenBlockNeedReLoginConfirm();
								return;
							}
						}
					}
				}
				ModelBase<SubPackageDownLoadModel>.Instance.OpenSubPackageDownLoadConfirmBySubPackageIds(this.ActivityBaseData.LocalConfig.Value.AreaTips, downLoadSubPackageListArray.ToList<int>());
				return;
			}
			ControllerBase<ActivityController>.Instance.OpenActivityContentView(this.ActivityBaseData);
			if (callback != null)
			{
				callback(true);
			}
			if (this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				areaTerminalActivitySkipLogEvent.i_type = 4;
			}
			else
			{
				areaTerminalActivitySkipLogEvent.i_type = 2;
			}
			ControllerBase<LogReportController>.Instance.LogReport(areaTerminalActivitySkipLogEvent);
		}

		// Token: 0x06032BD7 RID: 207831 RVA: 0x00CB635F File Offset: 0x00CB455F
		public override void BarFunction()
		{
			if (this.GetLockState())
			{
				ControllerBase<RegionalTerminalController>.Instance.OpenTerminalOverviewView(this.Id);
				return;
			}
			this.TerminalFunction(null);
		}

		// Token: 0x06032BD8 RID: 207832 RVA: 0x00CB6381 File Offset: 0x00CB4581
		public override bool GetShowState()
		{
			return ModelBase<ActivityModel>.Instance.IsActivityOpen(this.GameplayId);
		}

		// Token: 0x06032BD9 RID: 207833 RVA: 0x00CB6394 File Offset: 0x00CB4594
		public override ERedDotName? GetRedDotName()
		{
			if (this.GetLockState())
			{
				return null;
			}
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			ERedDotName? result = (activityBaseData != null) ? activityBaseData.GetExternalButtonRedPointName() : null;
			if (result == null)
			{
				return null;
			}
			return result;
		}

		// Token: 0x06032BDA RID: 207834 RVA: 0x00CB63E2 File Offset: 0x00CB45E2
		public override int GetRedDotId()
		{
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			if (activityBaseData == null)
			{
				return 0;
			}
			return activityBaseData.GetExternalButtonRedPointId();
		}

		// Token: 0x06032BDB RID: 207835 RVA: 0x00CB63F5 File Offset: 0x00CB45F5
		public override bool GetRedDotState()
		{
			if (this.GetLockState())
			{
				return false;
			}
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			return activityBaseData != null && activityBaseData.GetExternalButtonRedPointState();
		}

		// Token: 0x06032BDC RID: 207836 RVA: 0x00CB6412 File Offset: 0x00CB4612
		public override bool GetLockState()
		{
			if (!this.GetShowState())
			{
				return true;
			}
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			return activityBaseData == null || !activityBaseData.IsUnLock();
		}

		// Token: 0x06032BDD RID: 207837 RVA: 0x00CB6434 File Offset: 0x00CB4634
		[NullableContext(1)]
		public override IRegionalTerminalViewParams GetViewParams()
		{
			bool lockState = this.GetLockState();
			bool flag = this.ActivityBaseData.CanPreOpen() && lockState;
			bool flag2 = this.ActivityBaseData.HasPreOpenCondition();
			bool flag3 = !flag && lockState;
			int num = 0;
			if (!flag2)
			{
				num = this.ActivityBaseData.ConditionGroupId;
			}
			else if (!flag)
			{
				num = this.ActivityBaseData.PreOpenConditionGroupId;
			}
			return new RegionalTerminalViewParams
			{
				ShowLockPanel = flag3,
				ShowButton = !flag3,
				LockClickFunc = delegate
				{
					ControllerBase<ActivityController>.Instance.OpenActivityConditionView(this.ActivityBaseData.Id);
					AreaTerminalActivitySkipLogEvent areaTerminalActivitySkipLogEvent = new AreaTerminalActivitySkipLogEvent();
					areaTerminalActivitySkipLogEvent.i_id = this.Id;
					areaTerminalActivitySkipLogEvent.i_type = 1;
					ControllerBase<LogReportController>.Instance.LogReport(areaTerminalActivitySkipLogEvent);
				},
				LockTxtId = ((num > 0) ? (LevelGeneralCommons.GetConditionGroupHintText(num) ?? "") : ""),
				ButtonTxtId = (flag ? "Terminal_Area_UnlockInAdvance" : base.GetGameplayConfig().UnlockButtonText)
			};
		}

		// Token: 0x06032BDE RID: 207838 RVA: 0x00CB64F0 File Offset: 0x00CB46F0
		public override List<TItem> GetRewardPreviewList()
		{
			List<TItem> rewardPreviewList = base.GetRewardPreviewList();
			if (rewardPreviewList != null && rewardPreviewList.Count > 0)
			{
				return rewardPreviewList;
			}
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			List<TItem> list = (activityBaseData != null) ? activityBaseData.GetPreviewReward(null) : null;
			if (list == null || list.Count <= 0)
			{
				return null;
			}
			return list;
		}
	}
}
