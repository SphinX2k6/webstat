using System;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CAF RID: 27823
	public class LevelConditionCheckEntityTagInfo : CodeCondition
	{
		// Token: 0x1700A35E RID: 41822
		// (get) Token: 0x06044360 RID: 279392 RVA: 0x011B419E File Offset: 0x011B239E
		public override ECodeCondition CodeType
		{
			get
			{
				return ECodeCondition.CheckEntityTag;
			}
		}

		// Token: 0x040260B7 RID: 155831
		public int TagId;

		// Token: 0x040260B8 RID: 155832
		public int EntityId;

		// Token: 0x040260B9 RID: 155833
		public bool IsContain;
	}
}
