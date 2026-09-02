using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Audio
{
	// Token: 0x02006161 RID: 24929
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EStatePlayerState
	{
		// Token: 0x04023579 RID: 144761
		public const string StateGroupName = "battle_music_state";

		// Token: 0x0402357A RID: 144762
		public const string NotContactEnemy = "none";

		// Token: 0x0402357B RID: 144763
		public const string InBattleNotDamageEnemy = "battle_in";

		// Token: 0x0402357C RID: 144764
		public const string InBattleDamagedEnemy = "battle_strong";
	}
}
