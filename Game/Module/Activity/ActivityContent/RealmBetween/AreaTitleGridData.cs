using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006555 RID: 25941
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class AreaTitleGridData : MultiTemplateGridDataBase<RealmBetweenAreaData, AreaTitleItem>
	{
		// Token: 0x06040D27 RID: 265511 RVA: 0x0109F686 File Offset: 0x0109D886
		public AreaTitleGridData(RealmBetweenAreaData data, ActivityRealmBetweenData activity)
		{
			base.Data = data;
			this.Activity = activity;
		}

		// Token: 0x06040D28 RID: 265512 RVA: 0x0109F69C File Offset: 0x0109D89C
		public override int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x06040D29 RID: 265513 RVA: 0x0109F69F File Offset: 0x0109D89F
		public override AreaTitleItem CreateProxy()
		{
			return new AreaTitleItem(this.Activity);
		}

		// Token: 0x040245EF RID: 148975
		private readonly ActivityRealmBetweenData Activity;
	}
}
