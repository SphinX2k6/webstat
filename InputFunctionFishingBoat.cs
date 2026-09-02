using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using AkiClient.Game.Aki.Character.Vision;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using UnrealEngine;

// Token: 0x02003092 RID: 12434
[NullableContext(2)]
[Nullable(0)]
public static class InputFunctionFishingBoat
{
	// Token: 0x06019A22 RID: 104994 RVA: 0x007733E0 File Offset: 0x007715E0
	private static EFishingSkillType? GetFishingSkillType(int exploreToolId)
	{
		switch (exploreToolId)
		{
		case 1018:
			return new EFishingSkillType?(EFishingSkillType.鱼饵);
		case 1019:
			return new EFishingSkillType?(EFishingSkillType.传送);
		case 1020:
			return new EFishingSkillType?(EFishingSkillType.驱散幽灵);
		case 1021:
			return new EFishingSkillType?(EFishingSkillType.炸鱼);
		default:
			return null;
		}
	}

	// Token: 0x06019A23 RID: 104995 RVA: 0x00773434 File Offset: 0x00771634
	private static SInputCommand VisionSkill1Function(float time)
	{
		EntityHandle entityHandle = ModelBase<FishingModel>.Instance.GetShipData().GetEntityHandle();
		WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
		if (worldEntity == null || !worldEntity.Valid)
		{
			return null;
		}
		if (!InputFunctionCommon.CanVehicleResponseInput(worldEntity))
		{
			return null;
		}
		int currentExploreSkillId = ModelBase<RouletteModel>.Instance.CurrentExploreSkillId;
		if (currentExploreSkillId == 0)
		{
			return null;
		}
		int num = 0;
		SVisionData visionData = PhantomUtil.GetVisionData(currentExploreSkillId);
		if (visionData != null && visionData.类型 == EVisionType.探索)
		{
			num = visionData.技能ID;
		}
		if (num == 0)
		{
			return null;
		}
		EFishingSkillType? fishingSkillType = InputFunctionFishingBoat.GetFishingSkillType(currentExploreSkillId);
		if (fishingSkillType == null)
		{
			return InputFunctionCommon.CreateSkillCommand(worldEntity, num);
		}
		CharacterSkillCdComponent component = worldEntity.GetComponent<CharacterSkillCdComponent>();
		if (component != null && component.Valid && component.IsSkillInCd(num, true))
		{
			ControllerBase<FishingController>.Instance.ShowFishingSkillTips(fishingSkillType.Value, EFishingSkillCheckResult.SkillInCd);
			return null;
		}
		EFishingSkillCheckResult efishingSkillCheckResult = ControllerBase<FishingController>.Instance.CheckFishingSkillCanBegin(fishingSkillType.Value);
		if (efishingSkillCheckResult != EFishingSkillCheckResult.Usable && efishingSkillCheckResult != EFishingSkillCheckResult.TempFishingPointLimit)
		{
			ControllerBase<FishingController>.Instance.ShowFishingSkillTips(fishingSkillType.Value, efishingSkillCheckResult);
			return null;
		}
		SInputCommand sinputCommand = InputFunctionCommon.CreateSkillCommand(worldEntity, num);
		if (sinputCommand == null)
		{
			return null;
		}
		FishingBoatInputComponent component2 = worldEntity.GetComponent<FishingBoatInputComponent>();
		if (efishingSkillCheckResult == EFishingSkillCheckResult.TempFishingPointLimit)
		{
			if (component2 != null)
			{
				component2.ExecuteSkillWithConfirmBox(num, EConfirmBoxConfigId.FishingBaitLimit, ControllerBase<FishingController>.Instance.GetFishingSkillCostId());
			}
			return null;
		}
		EConfirmBoxConfigId configId;
		if (InputFunctionFishingBoat.NeedConfirmSkillMap.TryGetValue(fishingSkillType.Value, out configId))
		{
			if (component2 != null)
			{
				component2.ExecuteSkillWithConfirmBox(num, configId, ControllerBase<FishingController>.Instance.GetFishingSkillCostId());
			}
			return null;
		}
		return sinputCommand;
	}

	// Token: 0x06019A24 RID: 104996 RVA: 0x007735A9 File Offset: 0x007717A9
	public static SInputCommand FishingBoatVisionSkill1OnPress(float time)
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			return null;
		}
		return InputFunctionFishingBoat.VisionSkill1Function(time);
	}

	// Token: 0x06019A25 RID: 104997 RVA: 0x007735BF File Offset: 0x007717BF
	public static SInputCommand FishingBoatVisionSkill1OnRelease(float time)
	{
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			return null;
		}
		if (UiBlueprintFunctionLibrary.IsLongPressExploreButton())
		{
			return null;
		}
		return InputFunctionFishingBoat.VisionSkill1Function(time);
	}

	// Token: 0x06019A26 RID: 104998 RVA: 0x007735E0 File Offset: 0x007717E0
	public static SInputCommand CreateFishingBoatSprintCommand(int skillId)
	{
		EntityHandle entityHandle = ModelBase<FishingModel>.Instance.GetShipData().GetEntityHandle();
		WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
		if (worldEntity == null || !worldEntity.Valid)
		{
			return new SInputCommand(ECommandType.Skill, skillId, default(FGameplayTag));
		}
		FishingBoatPerformComponent component = worldEntity.GetComponent<FishingBoatPerformComponent>();
		if (component == null || !component.CheckCanSprint())
		{
			return null;
		}
		return InputFunctionCommon.CreateSkillCommand(worldEntity, skillId);
	}

	// Token: 0x06019A27 RID: 104999 RVA: 0x0077364B File Offset: 0x0077184B
	// Note: this type is marked as 'beforefieldinit'.
	static InputFunctionFishingBoat()
	{
		Dictionary<EFishingSkillType, EConfirmBoxConfigId> dictionary = new Dictionary<EFishingSkillType, EConfirmBoxConfigId>();
		dictionary[EFishingSkillType.传送] = EConfirmBoxConfigId.FishingTeleport;
		dictionary[EFishingSkillType.鱼饵] = EConfirmBoxConfigId.FishingBait;
		InputFunctionFishingBoat.NeedConfirmSkillMap = dictionary;
	}

	// Token: 0x0400CC32 RID: 52274
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<EFishingSkillType, EConfirmBoxConfigId> NeedConfirmSkillMap;
}
