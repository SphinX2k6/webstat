using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006558 RID: 25944
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class AreaLockGuideGridData : MultiTemplateGridDataBase<IAreaTaskItemData, AreaTaskItem>
	{
		// Token: 0x06040D33 RID: 265523 RVA: 0x0109F8DC File Offset: 0x0109DADC
		public AreaLockGuideGridData(RealmBetweenAreaData areaData, ActivityRealmBetweenData activity)
		{
			RealmBetweenArea? areaConfig = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetAreaConfig(areaData.AreaId);
			int inConditionGroupId = (areaConfig != null) ? areaConfig.GetValueOrDefault().UnLockCondition : 0;
			base.Data = new IAreaTaskItemData
			{
				AreaData = areaData,
				TaskData = null,
				UnlockJumpId = new int?((areaConfig != null) ? areaConfig.GetValueOrDefault().UnlockAccessId : 0),
				UnlockHintText = (LevelGeneralCommons.GetConditionGroupHintText(inConditionGroupId) ?? "")
			};
			this.Activity = activity;
		}

		// Token: 0x06040D34 RID: 265524 RVA: 0x0109F977 File Offset: 0x0109DB77
		public override int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x06040D35 RID: 265525 RVA: 0x0109F97A File Offset: 0x0109DB7A
		public override AreaTaskItem CreateProxy()
		{
			return new AreaTaskItem(this.Activity);
		}

		// Token: 0x040245F3 RID: 148979
		private readonly ActivityRealmBetweenData Activity;
	}
}
