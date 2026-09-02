using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02000D0B RID: 3339
[NullableContext(1)]
[Nullable(0)]
public abstract class IAiPerception
{
	// Token: 0x060042DE RID: 17118
	public abstract void SetAiSenseEnable(int index, bool enable);

	// Token: 0x060042DF RID: 17119
	public abstract void AddOrRemoveAiSense(int aiSenseId, bool add);

	// Token: 0x060042E0 RID: 17120
	public abstract void EnableAiSenseByType(int type, bool enable);

	// Token: 0x060042E1 RID: 17121
	public abstract string GetEnableAiSenseDebug();

	// Token: 0x060042E2 RID: 17122
	public abstract void Tick();

	// Token: 0x060042E3 RID: 17123
	public abstract void Clear(bool allClear = true, bool collectEvent = false);

	// Token: 0x060042E4 RID: 17124
	public abstract void OnEntityCampModified(Entity entity, ECamp oldCamp, ECamp newCamp);

	// Token: 0x060042E5 RID: 17125
	public abstract void SetAiSenseEnableWithoutForbidAllSense(bool enable);

	// Token: 0x060042E6 RID: 17126
	public abstract void SetAllAiSenseEnable(bool enable);

	// Token: 0x0400112D RID: 4397
	public HashSet<int> Allies = new HashSet<int>();

	// Token: 0x0400112E RID: 4398
	public HashSet<int> Enemies = new HashSet<int>();

	// Token: 0x0400112F RID: 4399
	public HashSet<int> Neutrals = new HashSet<int>();

	// Token: 0x04001130 RID: 4400
	public HashSet<int> AllEnemies = new HashSet<int>();

	// Token: 0x04001131 RID: 4401
	public HashSet<int> ShareAllyLink = new HashSet<int>();

	// Token: 0x04001132 RID: 4402
	public float MaxSenseRange;
}
