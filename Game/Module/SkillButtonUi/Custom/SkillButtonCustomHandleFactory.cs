using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.SkillButtonUi.Custom
{
	// Token: 0x02004FA3 RID: 20387
	[NullableContext(2)]
	[Nullable(0)]
	public static class SkillButtonCustomHandleFactory
	{
		// Token: 0x060349E4 RID: 215524 RVA: 0x00D33334 File Offset: 0x00D31534
		public static SkillButtonCustomHandleBase GetSkillButtonCustomHandleById(int customHandleId)
		{
			if (customHandleId == 0)
			{
				return null;
			}
			SkillButtonCustom? config = ConfigSkillButtonCustomById.GetConfig(customHandleId, true);
			if (config == null)
			{
				return null;
			}
			SkillButtonCustomHandleBase skillButtonCustomHandleByType = SkillButtonCustomHandleFactory.GetSkillButtonCustomHandleByType((ESkillButtonCustomHandle)config.Value.Type);
			if (skillButtonCustomHandleByType != null)
			{
				SkillButtonCustom value = config.Value;
				skillButtonCustomHandleByType.TagIds.AddRange(value.GetTagIdsArray() ?? Array.Empty<int>());
				skillButtonCustomHandleByType.BuffIds.AddRange(value.GetBuffIdsArray() ?? Array.Empty<long>());
				for (int i = 0; i < value.ParamsLength; i++)
				{
					skillButtonCustomHandleByType.Params.Add(value.Params(i));
				}
			}
			return skillButtonCustomHandleByType;
		}

		// Token: 0x060349E5 RID: 215525 RVA: 0x00D333DC File Offset: 0x00D315DC
		public static SkillButtonCustomHandleBase GetSkillButtonCustomHandleByType(ESkillButtonCustomHandle customHandleType)
		{
			Type type;
			if (SkillButtonCustomHandleFactory.Map.TryGetValue(customHandleType, out type) && type != null)
			{
				SkillButtonCustomHandleBase skillButtonCustomHandleBase = Activator.CreateInstance(type) as SkillButtonCustomHandleBase;
				skillButtonCustomHandleBase.HandleType = customHandleType;
				return skillButtonCustomHandleBase;
			}
			return null;
		}

		// Token: 0x060349E6 RID: 215526 RVA: 0x00D33418 File Offset: 0x00D31618
		// Note: this type is marked as 'beforefieldinit'.
		static SkillButtonCustomHandleFactory()
		{
			Dictionary<ESkillButtonCustomHandle, Type> dictionary = new Dictionary<ESkillButtonCustomHandle, Type>();
			dictionary[ESkillButtonCustomHandle.KeLaiTaUltimate] = typeof(SkillButtonCustomHandleKeLaiTaUltimate);
			dictionary[ESkillButtonCustomHandle.HackFollowAttack] = typeof(SkillButtonCustomHandleHackFollowAttach);
			dictionary[ESkillButtonCustomHandle.ZanNiUltimate] = typeof(SkillButtonCustomHandleZanNiUltimate);
			dictionary[ESkillButtonCustomHandle.AimisiMobileUpDown] = typeof(SkillButtonCustomHandleAimisiMobileUpDown);
			dictionary[ESkillButtonCustomHandle.DotIndicator] = typeof(SkillButtonCustomHandleDotIndicator);
			dictionary[ESkillButtonCustomHandle.SharedHoldRingFx] = typeof(SkillButtonCustomHandleSharedHoldRingFx);
			dictionary[ESkillButtonCustomHandle.HoldRingFxSimulateRestore] = typeof(SkillButtonCustomHandleHoldRingFxSimulateRestore);
			dictionary[ESkillButtonCustomHandle.OverrideAttributeColorByTag] = typeof(SkillButtonCustomHandleOverrideAttributeColorByTag);
			SkillButtonCustomHandleFactory.Map = dictionary;
		}

		// Token: 0x0401E55D RID: 124253
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static Dictionary<ESkillButtonCustomHandle, Type> Map;
	}
}
