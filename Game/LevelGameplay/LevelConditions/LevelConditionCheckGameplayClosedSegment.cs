using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D08 RID: 27912
	public class LevelConditionCheckGameplayClosedSegment : LevelConditionBase
	{
		// Token: 0x06044444 RID: 279620 RVA: 0x011BBC84 File Offset: 0x011B9E84
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return this.IsInNormalDungeon(inConditionInfo) || this.FindRunningTimerTree() != null;
		}

		// Token: 0x06044445 RID: 279621 RVA: 0x011BBC9C File Offset: 0x011B9E9C
		private bool IsInNormalDungeon(Condition inConditionInfo)
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
			InstanceDungeon? instanceDungeon = (instance != null) ? instance.GetConfig(instanceId) : null;
			return instanceDungeon != null && instanceDungeon.Value.InstType == 2;
		}

		// Token: 0x06044446 RID: 279622 RVA: 0x011BBCF0 File Offset: 0x011B9EF0
		[NullableContext(2)]
		private unsafe BaseBehaviorTree FindRunningTimerTree()
		{
			foreach (BaseBehaviorTree baseBehaviorTree in ModelBase<GeneralLogicTreeModel>.Instance.GetAllBehaviorTrees().Values)
			{
				BaseBehaviorTree baseBehaviorTree2 = baseBehaviorTree;
				List<string> includes = null;
				int num = 1;
				List<string> list = new List<string>(num);
				CollectionsMarshal.SetCount<string>(list, num);
				Span<string> span = CollectionsMarshal.AsSpan<string>(list);
				int index = 0;
				*span[index] = ETimerType.WaitTime.ToEnumString();
				if (baseBehaviorTree2.HasRunningTimers(includes, list))
				{
					return baseBehaviorTree;
				}
			}
			return null;
		}
	}
}
