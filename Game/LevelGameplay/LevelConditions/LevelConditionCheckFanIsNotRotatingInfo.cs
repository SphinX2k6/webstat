using System;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CAE RID: 27822
	public class LevelConditionCheckFanIsNotRotatingInfo : CodeCondition
	{
		// Token: 0x1700A35D RID: 41821
		// (get) Token: 0x0604435E RID: 279390 RVA: 0x011B4193 File Offset: 0x011B2393
		public override ECodeCondition CodeType
		{
			get
			{
				return ECodeCondition.CheckFanIsNotRotating;
			}
		}

		// Token: 0x040260B6 RID: 155830
		public int EntityId;
	}
}
