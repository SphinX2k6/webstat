using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.UniversalComponents
{
	// Token: 0x0200624A RID: 25162
	public class ActivityConditionView : CommonConditionView
	{
		// Token: 0x0603F6F0 RID: 259824 RVA: 0x01042D1F File Offset: 0x01040F1F
		[NullableContext(1)]
		public ActivityConditionView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603F6F1 RID: 259825 RVA: 0x01042D28 File Offset: 0x01040F28
		protected override void OnStart()
		{
			ActivityConditionGroupData activityConditionGroupData = this.OpenParam as ActivityConditionGroupData;
			this.ActivityId = activityConditionGroupData.ActivityId;
			if (this.ActivityId == 0)
			{
				return;
			}
			ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId);
			if (activityById == null)
			{
				return;
			}
			ModelBase<ActivityModel>.Instance.SendActivityLockConditionLogData(activityById);
			List<IActivityConditionData> activityConditionData = ModelBase<ActivityModel>.Instance.GetActivityConditionData(activityById);
			if (activityById.HasPreOpenCondition())
			{
				this.ConditionGroupData = new ConditionGroupData(activityById.PreOpenConditionGroupId, activityConditionData, activityById.LocalConfig.Value.Name, true);
			}
			else
			{
				this.ConditionGroupData = new ConditionGroupData(activityById.ConditionGroupId, activityConditionData, activityById.LocalConfig.Value.Name, false);
			}
			this.TextIdMap["FinishAllConditionOpen"] = "ActivityNotOpen_Tips01";
			this.TextIdMap["FinishAnyConditionOpen"] = "ActivityNotOpen_Tips02";
			this.TextIdMap["FinishAllConditionPreOpen"] = "ActivityNotPreOpen_Tips01";
			this.TextIdMap["FinishAnyConditionPreOpen"] = "ActivityNotPreOpen_Tips02";
			base.CreateConditionLayout();
		}

		// Token: 0x040239A0 RID: 145824
		private int ActivityId;
	}
}
