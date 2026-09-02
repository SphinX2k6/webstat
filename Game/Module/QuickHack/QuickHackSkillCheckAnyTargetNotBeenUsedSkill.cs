using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052D6 RID: 21206
	public class QuickHackSkillCheckAnyTargetNotBeenUsedSkill : IQuickHackSkillCondition
	{
		// Token: 0x060362C4 RID: 221892 RVA: 0x00DA4FE4 File Offset: 0x00DA31E4
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
			if (targets == null)
			{
				return false;
			}
			Dictionary<int, HashSet<int>> targetBeenUsedSkillRecordMap = ModelBase<QuickHackModel>.Instance.TargetBeenUsedSkillRecordMap;
			if (targetBeenUsedSkillRecordMap == null)
			{
				return true;
			}
			int id = skill.GetConfig().Id;
			foreach (EntityHandle entityHandle in targets)
			{
				if (entityHandle.Valid)
				{
					HashSet<int> hashSet;
					if (!targetBeenUsedSkillRecordMap.TryGetValue(entityHandle.Id, out hashSet))
					{
						return true;
					}
					if (!hashSet.Contains(id))
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
