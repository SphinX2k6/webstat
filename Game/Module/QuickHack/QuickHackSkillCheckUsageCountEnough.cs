using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052D3 RID: 21203
	public class QuickHackSkillCheckUsageCountEnough : IQuickHackSkillCondition
	{
		// Token: 0x060362BE RID: 221886 RVA: 0x00DA4E77 File Offset: 0x00DA3077
		[NullableContext(1)]
		public bool Check(QuickHackSkillInstance skill, EQuickHackTargetType? hackType, [Nullable(new byte[]
		{
			2,
			1
		})] IEnumerable<EntityHandle> targets, [Nullable(new byte[]
		{
			2,
			1
		})] IEnumerable<string> extraParams = null, int paramsLength = 0)
		{
			return skill.GetUsageCount() != 0;
		}
	}
}
