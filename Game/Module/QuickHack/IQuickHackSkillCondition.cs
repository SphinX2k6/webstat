using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052D0 RID: 21200
	[NullableContext(1)]
	public interface IQuickHackSkillCondition
	{
		// Token: 0x060362B9 RID: 221881
		bool Check(QuickHackSkillInstance skillConfig, EQuickHackTargetType? hackType, [Nullable(new byte[]
		{
			2,
			1
		})] IEnumerable<EntityHandle> targets, [Nullable(new byte[]
		{
			2,
			1
		})] IEnumerable<string> extraParams = null, int paramsLength = 0);
	}
}
