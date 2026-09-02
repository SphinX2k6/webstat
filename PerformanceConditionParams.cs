using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200302A RID: 12330
[NullableContext(1)]
[Nullable(0)]
public class PerformanceConditionParams
{
	// Token: 0x060192DB RID: 103131 RVA: 0x0072E76C File Offset: 0x0072C96C
	public PerformanceConditionParams(CharacterAnimationComponent animComp, PerformanceCondition config)
	{
		this.AnimComp = animComp;
		this.Config = config;
		for (int i = 0; i < 3; i++)
		{
			this.DisableTagIds.Add(new HashSet<int>());
			GameplayTagArray? gameplayTagArray = config.DisableTags(i);
			for (int j = 0; j < gameplayTagArray.Value.ArrayStringLength; j++)
			{
				int tagIdByName = GameplayTagUtils.GetTagIdByName(gameplayTagArray.Value.ArrayString(j));
				if (tagIdByName != 0)
				{
					this.DisableTagIds[i].Add(tagIdByName);
				}
			}
		}
	}

	// Token: 0x0400C5C0 RID: 50624
	public List<HashSet<int>> DisableTagIds = new List<HashSet<int>>();

	// Token: 0x0400C5C1 RID: 50625
	public CharacterAnimationComponent AnimComp;

	// Token: 0x0400C5C2 RID: 50626
	public PerformanceCondition Config;
}
