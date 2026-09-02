using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x0200654A RID: 25930
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RealmBetweenTaskLockItem : RealmBetweenTaskItemBase<RealmBetweenLockAreaData>
	{
		// Token: 0x06040CF4 RID: 265460 RVA: 0x0109E5FA File Offset: 0x0109C7FA
		public RealmBetweenTaskLockItem(ActivityRealmBetweenData activityBaseData) : base(activityBaseData)
		{
		}

		// Token: 0x06040CF5 RID: 265461 RVA: 0x0109E604 File Offset: 0x0109C804
		public override void Refresh(RealmBetweenLockAreaData taskData, bool isSelected, int gridIndex)
		{
			this.TaskData = taskData;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), LevelGeneralCommons.GetConditionGroupHintText(taskData.ConditionGroupId) ?? "", Array.Empty<object>());
			base.GetText(1).SetUIActive(false);
			this.ButtonItem.SetUiActive(taskData.JumpId > 0);
			base.GetItem(6).SetUIActive(taskData.JumpId == 0);
			base.GetItem(5).SetUIActive(false);
			this.RewardButtonItem.SetUiActive(false);
			GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> rewardScrollView = this.RewardScrollView;
			if (rewardScrollView == null)
			{
				return;
			}
			rewardScrollView.RefreshByData(new List<IItemGridData>(), null, false);
		}

		// Token: 0x06040CF6 RID: 265462 RVA: 0x0109E6A8 File Offset: 0x0109C8A8
		protected override void OnClickedButton()
		{
			if (this.TaskData.JumpId != 0)
			{
				SkipTaskManager.RunByConfigId(this.TaskData.JumpId, null);
			}
		}

		// Token: 0x040245B7 RID: 148919
		protected new RealmBetweenLockAreaData TaskData;
	}
}
