using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEffect
{
	// Token: 0x02006CA8 RID: 27816
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class LevelEffectModel : ModelBase<LevelEffectModel>
	{
		// Token: 0x06044352 RID: 279378 RVA: 0x011B40E2 File Offset: 0x011B22E2
		public void AcquireMpcParam(string key, int effectId)
		{
			this.MpcParamOwners[key] = effectId;
		}

		// Token: 0x06044353 RID: 279379 RVA: 0x011B40F4 File Offset: 0x011B22F4
		public bool ReleaseMpcParamIfOwner(string key, int effectId)
		{
			int num;
			if (!this.MpcParamOwners.TryGetValue(key, out num) || num != effectId)
			{
				return false;
			}
			this.MpcParamOwners.Remove(key);
			return true;
		}

		// Token: 0x06044354 RID: 279380 RVA: 0x011B4125 File Offset: 0x011B2325
		protected override bool OnLeaveLevel()
		{
			this.MpcParamOwners.Clear();
			return true;
		}

		// Token: 0x06044355 RID: 279381 RVA: 0x011B4133 File Offset: 0x011B2333
		protected override bool OnClear()
		{
			this.MpcParamOwners.Clear();
			return true;
		}

		// Token: 0x040260AD RID: 155821
		private readonly Dictionary<string, int> MpcParamOwners = new Dictionary<string, int>();
	}
}
