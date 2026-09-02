using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DEF RID: 28143
	public class LevelConditionTargetTagCheck : LevelConditionBase
	{
		// Token: 0x06044639 RID: 280121 RVA: 0x011C4530 File Offset: 0x011C2730
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("CreatureGen");
			string limitParams2 = inConditionInfo.GetLimitParams("Tag");
			string limitParams3 = inConditionInfo.GetLimitParams("CheckTag");
			if (limitParams == null || limitParams2 == null || limitParams3 == null)
			{
				return false;
			}
			string limitParams4 = inConditionInfo.GetLimitParams("MatchAll");
			string limitParams5 = inConditionInfo.GetLimitParams("Negative");
			long ownerId = UKismetStringLibrary.Conv_StringToInt64(limitParams);
			List<EntityHandle> list = new List<EntityHandle>();
			ModelBase<CreatureModel>.Instance.GetEntitiesWithOwnerId(ownerId, ref list);
			if (list.Count == 0)
			{
				return false;
			}
			bool flag = limitParams4 != null && limitParams4 == "1";
			bool flag2 = limitParams5 != null && limitParams5 == "1";
			bool flag3 = false;
			if (flag)
			{
				for (int i = 0; i < list.Count; i++)
				{
					CreatureDataComponent component = list[i].Entity.GetComponent<CreatureDataComponent>();
					if (!component.ContainsTag(limitParams2))
					{
						return flag3;
					}
					flag3 = component.ContainsTag(limitParams3);
					if (flag2 && flag3)
					{
						return false;
					}
					if (!flag3)
					{
						return flag3;
					}
				}
				return flag3;
			}
			for (int j = 0; j < list.Count; j++)
			{
				CreatureDataComponent component2 = list[j].Entity.GetComponent<CreatureDataComponent>();
				if (component2.ContainsTag(limitParams2))
				{
					flag3 = component2.ContainsTag(limitParams3);
					if (flag2 && !flag3)
					{
						return true;
					}
					if (flag3)
					{
						return flag3;
					}
				}
			}
			return false;
		}
	}
}
