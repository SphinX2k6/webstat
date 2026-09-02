using System;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CB1 RID: 27825
	public class LevelConditionCheckGravityFlipEntityDirectionSameAsPlayerInfo : CodeCondition
	{
		// Token: 0x1700A360 RID: 41824
		// (get) Token: 0x06044364 RID: 279396 RVA: 0x011B41B4 File Offset: 0x011B23B4
		public override ECodeCondition CodeType
		{
			get
			{
				return ECodeCondition.CheckGravityFlipEntityDirectionSameAsPlayer;
			}
		}

		// Token: 0x040260BB RID: 155835
		public int EntityId;
	}
}
