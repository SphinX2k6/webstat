using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x020069AE RID: 27054
	public class CoopProgressSubConditionData : CoopSubConditionDataBase
	{
		// Token: 0x0604316D RID: 274797 RVA: 0x0113B47C File Offset: 0x0113967C
		public CoopProgressSubConditionData(int id, ECoopSubConditionType taskType) : base(id, taskType)
		{
			CoopTaskConfig? coopTaskConfigById = ConfigBase<CoopConfig>.Instance.GetCoopTaskConfigById(id);
			if (coopTaskConfigById == null)
			{
				return;
			}
			this.Title = (coopTaskConfigById.Value.TaskTitle2 ?? "");
		}

		// Token: 0x0604316E RID: 274798 RVA: 0x0113B4C8 File Offset: 0x011396C8
		public override bool IsShowJumpBtn()
		{
			CoopTaskConfig? coopTaskConfigById = ConfigBase<CoopConfig>.Instance.GetCoopTaskConfigById(this.Id);
			return coopTaskConfigById != null && (coopTaskConfigById.Value.ItemId != 0 || coopTaskConfigById.Value.Condition2MapId != 0);
		}

		// Token: 0x0604316F RID: 274799 RVA: 0x0113B516 File Offset: 0x01139716
		public override bool IsTaskDone()
		{
			if (this.Target == 0)
			{
				return this.IsDone;
			}
			return this.Current >= this.Target;
		}

		// Token: 0x06043170 RID: 274800 RVA: 0x0113B538 File Offset: 0x01139738
		[NullableContext(1)]
		public override void RefreshData(CoopTaskCompleteInfo data)
		{
			ConditionTask task = data.Task;
			this.Current = ((task != null) ? task.Current : 0);
			ConditionTask task2 = data.Task;
			this.Target = ((task2 != null) ? task2.Target : 0);
			ConditionTask task3 = data.Task;
			this.IsDone = (task3 != null && task3.Status == ConditionTaskState.ConditionTaskFinish);
		}

		// Token: 0x06043171 RID: 274801 RVA: 0x0113B590 File Offset: 0x01139790
		public override void OnJumpClick()
		{
			CoopTaskConfig? coopTaskConfigById = ConfigBase<CoopConfig>.Instance.GetCoopTaskConfigById(this.Id);
			if (coopTaskConfigById != null && coopTaskConfigById.Value.ItemId != 0)
			{
				SkipTaskManager.RunByConfigId(840001, coopTaskConfigById.Value.ItemId);
			}
			if (coopTaskConfigById != null && coopTaskConfigById.Value.Condition2MapId != 0 && coopTaskConfigById.Value.Condition2MarkId != 0)
			{
				OneOf<MapMark, DynamicMapMark> value = ConfigBase<MapConfig>.Instance.SearchMarkConfig(coopTaskConfigById.Value.Condition2MarkId).Value;
				WorldMapViewOpenParams data;
				if (value.IsT1)
				{
					data = new WorldMapViewOpenParams
					{
						MarkType = (EMarkType)value.AsT1.ObjectType,
						MarkId = new int?(value.AsT1.MarkId),
						OpenFogId = new int?(0)
					};
				}
				else
				{
					data = new WorldMapViewOpenParams
					{
						MarkType = (EMarkType)value.AsT2.ObjectType,
						MarkId = new int?(value.AsT2.MarkId),
						OpenFogId = new int?(0)
					};
				}
				ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
			}
		}

		// Token: 0x0402563D RID: 153149
		private bool IsDone;
	}
}
