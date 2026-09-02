using System;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CAD RID: 27821
	public class LevelConditionCheckCharacterTagInfo : CodeCondition
	{
		// Token: 0x1700A35C RID: 41820
		// (get) Token: 0x0604435C RID: 279388 RVA: 0x011B4188 File Offset: 0x011B2388
		public override ECodeCondition CodeType
		{
			get
			{
				return ECodeCondition.CheckCharacterTag;
			}
		}

		// Token: 0x040260B4 RID: 155828
		public int TagId;

		// Token: 0x040260B5 RID: 155829
		public bool IsContain;
	}
}
