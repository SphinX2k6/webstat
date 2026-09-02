using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.SkipInterface;

namespace ActivityNamespace.MapTravel.MapTravelSubViewTravelTask
{
	// Token: 0x020043CB RID: 17355
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class TaskLockItem : TaskItemBase<MapTravelLockAreaData>
	{
		// Token: 0x0602E21D RID: 188957 RVA: 0x00AD8FB9 File Offset: 0x00AD71B9
		public TaskLockItem(ActivityMapTravelData activityBaseData) : base(activityBaseData)
		{
		}

		// Token: 0x0602E21E RID: 188958 RVA: 0x00AD8FC4 File Offset: 0x00AD71C4
		public void Refresh(MapTravelLockAreaData taskData)
		{
			this.TaskData = taskData;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), LevelGeneralCommons.GetConditionGroupHintText(taskData.ConditionGroupId) ?? "", Array.Empty<object>());
			base.GetText(1).SetUIActive(false);
			this.ButtonItem.SetUiActive(taskData.JumpId > 0);
			base.GetItem(6).SetUIActive(taskData.JumpId == 0);
			base.GetItem(5).SetUIActive(true);
		}

		// Token: 0x0602E21F RID: 188959 RVA: 0x00AD9045 File Offset: 0x00AD7245
		protected override void OnClickedButton()
		{
			if (this.TaskData.JumpId > 0)
			{
				SkipTaskManager.RunByConfigId(this.TaskData.JumpId, null);
			}
		}
	}
}
