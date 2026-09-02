using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052D2 RID: 21202
	public class QuickHackSkillCheckRamEnough : IQuickHackSkillCondition
	{
		// Token: 0x060362BC RID: 221884 RVA: 0x00DA4E38 File Offset: 0x00DA3038
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
			QuickHackRamManager ramManager = ModelBase<QuickHackModel>.Instance.RamManager;
			return ramManager != null && ramManager.GetCurrentRam() >= (float)skill.GetConfig().RamCost;
		}
	}
}
