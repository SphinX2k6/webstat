using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.SkipInterface;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064AE RID: 25774
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoadBookTaskLockItem : RoadBookTaskItemBase<RoadBookLockAreaData>
	{
		// Token: 0x060409B0 RID: 264624 RVA: 0x0108F7A0 File Offset: 0x0108D9A0
		public RoadBookTaskLockItem(ActivityRoadBookData activityBaseData) : base(activityBaseData)
		{
		}

		// Token: 0x060409B1 RID: 264625 RVA: 0x0108F7AC File Offset: 0x0108D9AC
		public override void Refresh(RoadBookLockAreaData taskData, bool isSelected, int gridIndex)
		{
			this.TaskData = taskData;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), LevelGeneralCommons.GetConditionGroupHintText(taskData.ConditionGroupId) ?? "", Array.Empty<object>());
			base.GetText(1).SetUIActive(false);
			this.ButtonItem.SetUiActive(taskData.JumpId > 0);
			base.GetItem(6).SetUIActive(taskData.JumpId == 0);
			base.GetItem(5).SetUIActive(true);
		}

		// Token: 0x060409B2 RID: 264626 RVA: 0x0108F82D File Offset: 0x0108DA2D
		protected override void OnClickedButton()
		{
			if (this.TaskData.JumpId != 0)
			{
				SkipTaskManager.RunByConfigId(this.TaskData.JumpId, null);
			}
		}

		// Token: 0x040242CA RID: 148170
		protected new RoadBookLockAreaData TaskData;
	}
}
