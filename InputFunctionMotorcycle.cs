using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using AkiClient.Game.Aki.Character.Vision;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;

// Token: 0x02003093 RID: 12435
[NullableContext(2)]
[Nullable(0)]
public static class InputFunctionMotorcycle
{
	// Token: 0x06019A28 RID: 105000 RVA: 0x00773670 File Offset: 0x00771870
	private static SInputCommand VisionSkill1Function(float time, bool isForce = false)
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null)
		{
			return null;
		}
		CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		CharacterDriveVehicleComponent characterDriveVehicleComponent = (entity != null) ? entity.GetComponent<CharacterDriveVehicleComponent>() : null;
		Entity entity2 = (characterDriveVehicleComponent != null) ? characterDriveVehicleComponent.VehicleEntity : null;
		if (entity2 == null)
		{
			return null;
		}
		BaseTagComponent component = entity2.GetComponent<BaseTagComponent>();
		if (component == null)
		{
			return null;
		}
		SInputCommand sinputCommand = InputFunctionCommon.CreateInputCommandFromDataTable(entity2.Id, EInputAction.幻象1, EInputState.Press);
		if (sinputCommand != null)
		{
			return sinputCommand;
		}
		int num = 0;
		int num2 = 0;
		MotorcycleExploreComponent component2 = entity2.GetComponent<MotorcycleExploreComponent>();
		int? num3 = (component2 != null) ? new int?(component2.GetSkillIdByCurrentTarget()) : null;
		if (num3 != null && num3.Value != 0)
		{
			num = num3.Value;
			num2 = 6004;
		}
		if (num == 0)
		{
			num2 = ModelBase<RouletteModel>.Instance.CurrentExploreSkillId;
			SVisionData visionData = PhantomUtil.GetVisionData(num2);
			if (visionData != null && visionData.类型 == EVisionType.探索)
			{
				num = visionData.技能ID;
			}
			if (num == 10001012 && component.HasAnyTag(new int[]
			{
				GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中"],
				GameplayTagDefine.EGameplayTagId["载具.摩托.跳跃"],
				GameplayTagDefine.EGameplayTagId["战斗状态.技能限制.禁止声骸展示技能"],
				GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.禁用声骸显像"]
			}))
			{
				return null;
			}
			if (InputFunctionMotorcycle.PullCollectionMutexSkillIds.Contains(num) && component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.摩托车.拉取采集物.技能中"]))
			{
				return null;
			}
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Vehicle;
		ELogAuthor author = ELogAuthor.CK;
		string message = "摩托车释放技能";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillId", num);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (num != 0)
		{
			if (isForce || ModelBase<ExploreSkillFlagModel>.Instance.GetExploreSkillFlagEnable((EExploreSkillType)num))
			{
				ModelBase<RouletteModel>.Instance.TrySendExploreToolGeneralUseLogData(num2, 0, 0);
				return InputFunctionCommon.CreateSkillCommand(entity2, num);
			}
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(EMapExploreToolCheckTipId.TempTeleporterPlacementBanned.ToEnumString(), Array.Empty<object>());
		}
		return null;
	}

	// Token: 0x06019A29 RID: 105001 RVA: 0x00773865 File Offset: 0x00771A65
	public static SInputCommand MotorcycleVisionSkill1OnPress(float time)
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			return null;
		}
		return InputFunctionMotorcycle.VisionSkill1Function(time, false);
	}

	// Token: 0x06019A2A RID: 105002 RVA: 0x0077387C File Offset: 0x00771A7C
	public static SInputCommand MotorcycleVisionSkill1OnRelease(float time)
	{
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			return null;
		}
		if (UiBlueprintFunctionLibrary.IsLongPressExploreButton())
		{
			return null;
		}
		return InputFunctionMotorcycle.VisionSkill1Function(time, false);
	}

	// Token: 0x06019A2B RID: 105003 RVA: 0x0077389C File Offset: 0x00771A9C
	public static int? GetVisionSkill1SkillId(bool isForce = false)
	{
		SInputCommand sinputCommand = InputFunctionMotorcycle.VisionSkill1Function(0f, isForce);
		if (sinputCommand != null)
		{
			return new int?(sinputCommand.IntValue);
		}
		return null;
	}

	// Token: 0x0400CC33 RID: 52275
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly HashSet<int> PullCollectionMutexSkillIds = new HashSet<int>
	{
		10001012,
		10001007,
		10001013,
		10001011
	};
}
