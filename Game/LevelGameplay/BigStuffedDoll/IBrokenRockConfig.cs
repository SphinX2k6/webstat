using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F52 RID: 28498
	[NullableContext(1)]
	public interface IBrokenRockConfig
	{
		// Token: 0x1700A46C RID: 42092
		// (get) Token: 0x06044F86 RID: 282502
		int Id { get; }

		// Token: 0x1700A46D RID: 42093
		// (get) Token: 0x06044F87 RID: 282503
		int[] Rings { get; }

		// Token: 0x1700A46E RID: 42094
		// (get) Token: 0x06044F88 RID: 282504
		int ScoreMax { get; }

		// Token: 0x1700A46F RID: 42095
		// (get) Token: 0x06044F89 RID: 282505
		int ScoreUp { get; }

		// Token: 0x1700A470 RID: 42096
		// (get) Token: 0x06044F8A RID: 282506
		int ScoreDown { get; }

		// Token: 0x1700A471 RID: 42097
		// (get) Token: 0x06044F8B RID: 282507
		int GlobalTime { get; }

		// Token: 0x1700A472 RID: 42098
		// (get) Token: 0x06044F8C RID: 282508
		int NormalSkill { get; }

		// Token: 0x1700A473 RID: 42099
		// (get) Token: 0x06044F8D RID: 282509
		int FinishSkill { get; }

		// Token: 0x1700A474 RID: 42100
		// (get) Token: 0x06044F8E RID: 282510
		string EntityUid { get; }
	}
}
