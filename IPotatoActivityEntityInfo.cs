using System;
using System.Runtime.CompilerServices;

// Token: 0x02000F6F RID: 3951
[NullableContext(2)]
public interface IPotatoActivityEntityInfo : IPotatoCombatInfo, IPotatoConfigInfo
{
	// Token: 0x17000795 RID: 1941
	// (get) Token: 0x060063D4 RID: 25556
	// (set) Token: 0x060063D5 RID: 25557
	int ConfigId { get; set; }

	// Token: 0x17000796 RID: 1942
	// (get) Token: 0x060063D6 RID: 25558
	// (set) Token: 0x060063D7 RID: 25559
	EPotatoMonsterDeathType DeathType { get; set; }

	// Token: 0x17000797 RID: 1943
	// (get) Token: 0x060063D8 RID: 25560
	// (set) Token: 0x060063D9 RID: 25561
	int BuffRadius { get; set; }

	// Token: 0x17000798 RID: 1944
	// (get) Token: 0x060063DA RID: 25562
	// (set) Token: 0x060063DB RID: 25563
	int[] BuffIds { get; set; }

	// Token: 0x17000799 RID: 1945
	// (get) Token: 0x060063DC RID: 25564
	// (set) Token: 0x060063DD RID: 25565
	int[] SpawnIds { get; set; }

	// Token: 0x1700079A RID: 1946
	// (get) Token: 0x060063DE RID: 25566
	// (set) Token: 0x060063DF RID: 25567
	int PolluteRadius { get; set; }

	// Token: 0x1700079B RID: 1947
	// (get) Token: 0x060063E0 RID: 25568
	// (set) Token: 0x060063E1 RID: 25569
	int IncId { get; set; }

	// Token: 0x1700079C RID: 1948
	// (get) Token: 0x060063E2 RID: 25570
	// (set) Token: 0x060063E3 RID: 25571
	int SpawnConfigId { get; set; }

	// Token: 0x1700079D RID: 1949
	// (get) Token: 0x060063E4 RID: 25572
	// (set) Token: 0x060063E5 RID: 25573
	int SpawnConfigGroupIndex { get; set; }
}
