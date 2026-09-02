using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x02006986 RID: 27014
	[NullableContext(1)]
	[Nullable(0)]
	public class CoopLevelData
	{
		// Token: 0x1700A1E3 RID: 41443
		// (get) Token: 0x0604309D RID: 274589 RVA: 0x011372AC File Offset: 0x011354AC
		public bool IsShowDoingNew
		{
			get
			{
				return this.State == ECoopLevelStatus.Doing && !(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.CoopRoleNewLevelRedDot) as ServerStorageSet).Has(this.LevelId);
			}
		}

		// Token: 0x0604309E RID: 274590 RVA: 0x011372D8 File Offset: 0x011354D8
		public CoopLevelData(int id)
		{
			this.LevelId = id;
			CoopRoleLevel? coopConfigById = ConfigBase<CoopConfig>.Instance.GetCoopConfigById(id);
			this.Level = coopConfigById.Value.CoopLevel;
			this.RoleId = coopConfigById.Value.CoopRoleId;
			CoopRoleLevel? coopConfigById2 = ConfigBase<CoopConfig>.Instance.GetCoopConfigById(id);
			this.SubConditionId = coopConfigById2.Value.TaskGroupId;
			this.IsHaveSubCondition = (coopConfigById2.Value.TaskGroupId != 0);
			if (this.IsHaveSubCondition)
			{
				CoopTaskConfig? coopTaskConfigById = ConfigBase<CoopConfig>.Instance.GetCoopTaskConfigById(this.SubConditionId);
				if (coopTaskConfigById.Value.CoopPreQuest != 0)
				{
					CoopPreTaskSubConditionData value = new CoopPreTaskSubConditionData(this.SubConditionId, ECoopSubConditionType.ECoopPreTaskSubConditionData);
					this.CoopSubConditionDataDict.Add(ECoopSubConditionType.ECoopPreTaskSubConditionData, value);
				}
				if (!string.IsNullOrEmpty(coopTaskConfigById.Value.TaskTitle2))
				{
					CoopProgressSubConditionData value2 = new CoopProgressSubConditionData(this.SubConditionId, ECoopSubConditionType.ECoopProgressSubConditionData);
					this.CoopSubConditionDataDict.Add(ECoopSubConditionType.ECoopProgressSubConditionData, value2);
				}
				if (!string.IsNullOrEmpty(coopTaskConfigById.Value.TaskTitle3))
				{
					CoopMapTaskSubConditionData1 value3 = new CoopMapTaskSubConditionData1(this.SubConditionId, ECoopSubConditionType.ECoopMapTaskSubConditionData1);
					this.CoopSubConditionDataDict.Add(ECoopSubConditionType.ECoopMapTaskSubConditionData1, value3);
				}
				if (!string.IsNullOrEmpty(coopTaskConfigById.Value.TaskTitle4))
				{
					CoopMapTaskSubConditionData2 value4 = new CoopMapTaskSubConditionData2(this.SubConditionId, ECoopSubConditionType.ECoopMapTaskSubConditionData2);
					this.CoopSubConditionDataDict.Add(ECoopSubConditionType.ECoopMapTaskSubConditionData2, value4);
				}
				if (!string.IsNullOrEmpty(coopTaskConfigById.Value.TaskTitle5))
				{
					CoopTimeMapTaskSubConditionData value5 = new CoopTimeMapTaskSubConditionData(this.SubConditionId, ECoopSubConditionType.ECoopTimeMapTaskSubConditionData);
					this.CoopSubConditionDataDict.Add(ECoopSubConditionType.ECoopTimeMapTaskSubConditionData, value5);
				}
			}
		}

		// Token: 0x0604309F RID: 274591 RVA: 0x01137484 File Offset: 0x01135684
		public void UpdateSubConditionState(CoopTaskCompleteInfo data)
		{
			foreach (CoopSubConditionDataBase coopSubConditionDataBase in this.CoopSubConditionDataDict.Values)
			{
				coopSubConditionDataBase.RefreshData(data);
			}
		}

		// Token: 0x060430A0 RID: 274592 RVA: 0x011374DC File Offset: 0x011356DC
		public List<CoopSubConditionDataBase> GetSubConditionList()
		{
			return new List<CoopSubConditionDataBase>(this.CoopSubConditionDataDict.Values);
		}

		// Token: 0x060430A1 RID: 274593 RVA: 0x011374F0 File Offset: 0x011356F0
		public bool IsAllSubConditionDone()
		{
			if (!this.IsHaveSubCondition)
			{
				return true;
			}
			using (Dictionary<ECoopSubConditionType, CoopSubConditionDataBase>.ValueCollection.Enumerator enumerator = this.CoopSubConditionDataDict.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsTaskDone())
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x04025544 RID: 152900
		public int LevelId;

		// Token: 0x04025545 RID: 152901
		public int Level;

		// Token: 0x04025546 RID: 152902
		public int RoleId;

		// Token: 0x04025547 RID: 152903
		public ECoopLevelStatus State;

		// Token: 0x04025548 RID: 152904
		public bool IsHaveSubCondition;

		// Token: 0x04025549 RID: 152905
		public int SubConditionId;

		// Token: 0x0402554A RID: 152906
		public Dictionary<ECoopSubConditionType, CoopSubConditionDataBase> CoopSubConditionDataDict = new Dictionary<ECoopSubConditionType, CoopSubConditionDataBase>();
	}
}
