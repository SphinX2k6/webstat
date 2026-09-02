using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052D7 RID: 21207
	public class QuickHackConditionInfo
	{
		// Token: 0x060362C6 RID: 221894 RVA: 0x00DA5084 File Offset: 0x00DA3284
		public QuickHackConditionInfo(EQuickHackSkillCondition type, [Nullable(new byte[]
		{
			2,
			1
		})] IEnumerable<string> extraParams, int paramsLength)
		{
		}

		// Token: 0x0401F20B RID: 127499
		public readonly EQuickHackSkillCondition Type = type;

		// Token: 0x0401F20C RID: 127500
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public readonly IEnumerable<string> ExtraParams = extraParams;

		// Token: 0x0401F20D RID: 127501
		public readonly int ParamsLength = paramsLength;
	}
}
