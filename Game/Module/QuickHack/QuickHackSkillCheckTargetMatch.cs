using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052D1 RID: 21201
	public class QuickHackSkillCheckTargetMatch : IQuickHackSkillCondition
	{
		// Token: 0x060362BA RID: 221882 RVA: 0x00DA4DF8 File Offset: 0x00DA2FF8
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
			int targetType = skill.GetConfig().TargetType;
			return targetType == 2 || (hackType != null && targetType == (int)hackType.Value);
		}
	}
}
