using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052D9 RID: 21209
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackSkillConditionHelper
	{
		// Token: 0x060362C8 RID: 221896 RVA: 0x00DA50B8 File Offset: 0x00DA32B8
		public QuickHackSkillConditionResult CheckConditions(IEnumerable<QuickHackConditionInfo> conditionTypes, QuickHackSkillInstance skill, EQuickHackTargetType? hackType, [Nullable(new byte[]
		{
			2,
			1
		})] IEnumerable<EntityHandle> targets)
		{
			foreach (QuickHackConditionInfo quickHackConditionInfo in conditionTypes)
			{
				EQuickHackSkillCondition type = quickHackConditionInfo.Type;
				IQuickHackSkillCondition quickHackSkillCondition;
				if (this.ConditionMap.TryGetValue(type, out quickHackSkillCondition) && !quickHackSkillCondition.Check(skill, hackType, targets, quickHackConditionInfo.ExtraParams, 0))
				{
					return new QuickHackSkillConditionResult(false, new EQuickHackSkillCondition?(type));
				}
			}
			return new QuickHackSkillConditionResult(true, null);
		}

		// Token: 0x060362C9 RID: 221897 RVA: 0x00DA5148 File Offset: 0x00DA3348
		public void RegisterConditionsListener(IEnumerable<EQuickHackSkillCondition> conditionTypes, GenericEventHandler onReceiveEvent)
		{
			foreach (EQuickHackSkillCondition key in conditionTypes)
			{
				List<EEventName> list;
				if (this.ConditionEventMap.TryGetValue(key, out list))
				{
					foreach (EEventName name in list)
					{
						if (!Singleton<EventSystem>.Instance.Has(name, onReceiveEvent))
						{
							Singleton<EventSystem>.Instance.Add(name, onReceiveEvent);
						}
					}
				}
			}
		}

		// Token: 0x060362CA RID: 221898 RVA: 0x00DA51F0 File Offset: 0x00DA33F0
		public void UnRegisterConditionsListener(IEnumerable<EQuickHackSkillCondition> conditionTypes, GenericEventHandler onReceiveEvent)
		{
			foreach (EQuickHackSkillCondition key in conditionTypes)
			{
				List<EEventName> list;
				if (this.ConditionEventMap.TryGetValue(key, out list))
				{
					foreach (EEventName name in list)
					{
						if (Singleton<EventSystem>.Instance.Has(name, onReceiveEvent))
						{
							Singleton<EventSystem>.Instance.Remove(name, onReceiveEvent);
						}
					}
				}
			}
		}

		// Token: 0x060362CB RID: 221899 RVA: 0x00DA5298 File Offset: 0x00DA3498
		[NullableContext(2)]
		public List<EQuickHackSkillCondition> GetTargetExtraConditions(EQuickHackTargetType type)
		{
			List<EQuickHackSkillCondition> result;
			this.TargetExtraConditionsMap.TryGetValue(type, out result);
			return result;
		}

		// Token: 0x0401F210 RID: 127504
		private readonly Dictionary<EQuickHackSkillCondition, IQuickHackSkillCondition> ConditionMap = new Dictionary<EQuickHackSkillCondition, IQuickHackSkillCondition>
		{
			{
				EQuickHackSkillCondition.CheckTargetTypeMatch,
				new QuickHackSkillCheckTargetMatch()
			},
			{
				EQuickHackSkillCondition.CheckRamEnough,
				new QuickHackSkillCheckRamEnough()
			},
			{
				EQuickHackSkillCondition.CheckUsageCountEnough,
				new QuickHackSkillCheckUsageCountEnough()
			},
			{
				EQuickHackSkillCondition.CheckAnyMonsterTypeMatch,
				new QuickHackSkillCheckAnyMonsterTypeMatch()
			},
			{
				EQuickHackSkillCondition.CheckAnySceneItemCanHack,
				new QuickHackSkillCheckAnySceneItemCanHack()
			},
			{
				EQuickHackSkillCondition.CheckAnyTargetNotBeenUsedSkill,
				new QuickHackSkillCheckAnyTargetNotBeenUsedSkill()
			}
		};

		// Token: 0x0401F211 RID: 127505
		private readonly Dictionary<EQuickHackSkillCondition, List<EEventName>> ConditionEventMap = new Dictionary<EQuickHackSkillCondition, List<EEventName>>
		{
			{
				EQuickHackSkillCondition.CheckTargetTypeMatch,
				new List<EEventName>
				{
					EEventName.OnQuickHackTargetChange
				}
			},
			{
				EQuickHackSkillCondition.CheckRamEnough,
				new List<EEventName>
				{
					EEventName.OnQuickHackCurrentRamChange
				}
			},
			{
				EQuickHackSkillCondition.CheckAnyMonsterTypeMatch,
				new List<EEventName>
				{
					EEventName.OnQuickHackTargetChange
				}
			},
			{
				EQuickHackSkillCondition.CheckAnySceneItemCanHack,
				new List<EEventName>
				{
					EEventName.OnQuickHackTargetChange,
					EEventName.OnQuickHackSceneItemStateChange
				}
			},
			{
				EQuickHackSkillCondition.CheckAnyTargetNotBeenUsedSkill,
				new List<EEventName>
				{
					EEventName.OnQuickHackTargetChange,
					EEventName.OnQuickHackCurrentRamChange
				}
			}
		};

		// Token: 0x0401F212 RID: 127506
		private readonly Dictionary<EQuickHackTargetType, List<EQuickHackSkillCondition>> TargetExtraConditionsMap = new Dictionary<EQuickHackTargetType, List<EQuickHackSkillCondition>>
		{
			{
				EQuickHackTargetType.EnemyMonster,
				new List<EQuickHackSkillCondition>
				{
					EQuickHackSkillCondition.CheckAnyMonsterTypeMatch,
					EQuickHackSkillCondition.CheckAnyTargetNotBeenUsedSkill
				}
			},
			{
				EQuickHackTargetType.SceneItem,
				new List<EQuickHackSkillCondition>
				{
					EQuickHackSkillCondition.CheckAnySceneItemCanHack,
					EQuickHackSkillCondition.CheckAnyTargetNotBeenUsedSkill
				}
			},
			{
				EQuickHackTargetType.OwnerSelf,
				new List<EQuickHackSkillCondition>
				{
					EQuickHackSkillCondition.CheckAnyTargetNotBeenUsedSkill
				}
			}
		};
	}
}
