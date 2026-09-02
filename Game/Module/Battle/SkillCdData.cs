using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F49 RID: 24393
	[NullableContext(1)]
	[Nullable(0)]
	public class SkillCdData
	{
		// Token: 0x0603D47B RID: 251003 RVA: 0x00F96092 File Offset: 0x00F94292
		public int GenerateCdShareGroupId(int groupId)
		{
			if (groupId == 0)
			{
				this.ShareGroupGenerator++;
				return this.ShareGroupGenerator;
			}
			return groupId;
		}

		// Token: 0x0603D47C RID: 251004 RVA: 0x00F960AD File Offset: 0x00F942AD
		public void Clear()
		{
			this.SkillId2GroupIdMap.Clear();
			this.GroupSkillCdInfoMap.Clear();
			this.ShareGroupGenerator = 0;
		}

		// Token: 0x040225FD RID: 140797
		public readonly Dictionary<int, int> SkillId2GroupIdMap = new Dictionary<int, int>();

		// Token: 0x040225FE RID: 140798
		public readonly Dictionary<int, GroupSkillCdInfo> GroupSkillCdInfoMap = new Dictionary<int, GroupSkillCdInfo>();

		// Token: 0x040225FF RID: 140799
		private int ShareGroupGenerator;

		// Token: 0x04022600 RID: 140800
		public readonly Dictionary<int, List<long>> ServerSkillCd = new Dictionary<int, List<long>>();

		// Token: 0x04022601 RID: 140801
		public readonly Dictionary<int, List<long>> ServerGroupSkillCd = new Dictionary<int, List<long>>();

		// Token: 0x04022602 RID: 140802
		public bool NeedTick = true;
	}
}
