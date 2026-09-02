using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F46 RID: 24390
	[NullableContext(1)]
	[Nullable(0)]
	public class PassiveSkillCdData
	{
		// Token: 0x0603D46C RID: 250988 RVA: 0x00F9589B File Offset: 0x00F93A9B
		public void Clear()
		{
			this.SkillCdInfoMap.Clear();
		}

		// Token: 0x040225F0 RID: 140784
		public readonly Dictionary<long, PassiveSkillCdInfo> SkillCdInfoMap = new Dictionary<long, PassiveSkillCdInfo>();

		// Token: 0x040225F1 RID: 140785
		public readonly Dictionary<long, long> ServerSkillCd = new Dictionary<long, long>();
	}
}
