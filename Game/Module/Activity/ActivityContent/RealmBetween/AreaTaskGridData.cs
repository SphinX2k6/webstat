using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006557 RID: 25943
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class AreaTaskGridData : MultiTemplateGridDataBase<IAreaTaskItemData, AreaTaskItem>
	{
		// Token: 0x06040D30 RID: 265520 RVA: 0x0109F8A3 File Offset: 0x0109DAA3
		public AreaTaskGridData(ActivityTaskData taskData, RealmBetweenAreaData areaData, ActivityRealmBetweenData activity)
		{
			base.Data = new IAreaTaskItemData
			{
				TaskData = taskData,
				AreaData = areaData
			};
			this.Activity = activity;
		}

		// Token: 0x06040D31 RID: 265521 RVA: 0x0109F8CB File Offset: 0x0109DACB
		public override int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x06040D32 RID: 265522 RVA: 0x0109F8CE File Offset: 0x0109DACE
		public override AreaTaskItem CreateProxy()
		{
			return new AreaTaskItem(this.Activity);
		}

		// Token: 0x040245F2 RID: 148978
		private readonly ActivityRealmBetweenData Activity;
	}
}
