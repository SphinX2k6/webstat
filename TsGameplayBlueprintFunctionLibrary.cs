using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Aki.Protocol;
using Aki.Protocol.Summon;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using AkiClient.Game.Aki.Character.Role.FemaleXL.Jiabeilina_FP.Data;
using AkiClient.Game.Aki.Character.Vision;
using AkiClient.Game.Aki.Core.Fight;
using AkiClient.Game.Aki.Core.World;
using AkiClient.Game.Aki.Data.Common.Struct;
using AkiClient.Game.Aki.Data.Fight.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelFlow;
using CSharpScript.Game.LevelFlow.Action;
using CSharpScript.Game.LevelGamePlay.SplineMoveTask;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.QuickHack;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Controller;
using CSharpScript.Game.Utils;
using Cysharp.Threading.Tasks;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002E33 RID: 11827
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsGameplayBlueprintFunctionLibrary.TsGameplayBlueprintFunctionLibrary_C")]
public class TsGameplayBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x06017FFD RID: 98301 RVA: 0x006B899B File Offset: 0x006B6B9B
	static TsGameplayBlueprintFunctionLibrary()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsGameplayBlueprintFunctionLibrary.CreateStaticDefaultValue), new Action(TsGameplayBlueprintFunctionLibrary.ResetStaticDefaultValue));
	}

	// Token: 0x06017FFE RID: 98302 RVA: 0x006B89BC File Offset: 0x006B6BBC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool ContainsTag(int entityId, FGameplayTag tag)
	{
		BaseTagComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseTagComponent>(entityId);
		return component != null && component.Valid && component.HasTag(tag.TagId());
	}

	// Token: 0x06017FFF RID: 98303 RVA: 0x006B89F4 File Offset: 0x006B6BF4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void AddTag(int entityId, FGameplayTag tag)
	{
		BaseTagComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseTagComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.AddTag(new int?(tag.TagId()));
	}

	// Token: 0x06018000 RID: 98304 RVA: 0x006B8A30 File Offset: 0x006B6C30
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void AddTagWithDuration(int entityId, float duration, FGameplayTag tag)
	{
		CharacterBuffComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterBuffComponent>(entityId);
		if (component == null || !component.Valid || duration <= 0f)
		{
			return;
		}
		component.AddTagWithReturnHandle(new int[]
		{
			tag.TagId()
		}, duration);
	}

	// Token: 0x06018001 RID: 98305 RVA: 0x006B8A7C File Offset: 0x006B6C7C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void AddTagByName(int entityId, string tagName)
	{
		BaseTagComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseTagComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
		if (tagIdByName != 0)
		{
			component.AddTag(new int?(tagIdByName));
			string p = StringUtils.Format("GmAddTag {0} {1} 1", new string[]
			{
				ModelBase<CreatureModel>.Instance.GetCreatureDataId(entityId).ToString(),
				tagIdByName.ToString()
			});
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.RunGm, p);
		}
	}

	// Token: 0x06018002 RID: 98306 RVA: 0x006B8B00 File Offset: 0x006B6D00
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void RemoveTag(int entityId, FGameplayTag tag)
	{
		BaseTagComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseTagComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.RemoveTag(new int?(tag.TagId()));
	}

	// Token: 0x06018003 RID: 98307 RVA: 0x006B8B40 File Offset: 0x006B6D40
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void RemoveTagByName(int entityId, string tagName)
	{
		BaseTagComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseTagComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
		if (tagIdByName != 0)
		{
			component.RemoveTag(new int?(tagIdByName));
			string p = StringUtils.Format("GmRemoveTag {0} {1}", new string[]
			{
				ModelBase<CreatureModel>.Instance.GetCreatureDataId(entityId).ToString(),
				tagIdByName.ToString()
			});
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.RunGm, p);
		}
	}

	// Token: 0x06018004 RID: 98308 RVA: 0x006B8BC4 File Offset: 0x006B6DC4
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void AddCue(int instigatorEntityId, int targetEntityId, long cueId)
	{
		BaseGameplayCueComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseGameplayCueComponent>(targetEntityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById((instigatorEntityId != 0) ? instigatorEntityId : targetEntityId);
		component.AddCue((long)((int)cueId), new GameplayCueParam?(new GameplayCueParam
		{
			Instigator = entityById
		}));
	}

	// Token: 0x06018005 RID: 98309 RVA: 0x006B8C24 File Offset: 0x006B6E24
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void RemoveCue(int entityId, long cueId)
	{
		BaseGameplayCueComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseGameplayCueComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.RemoveCue((long)((int)cueId));
	}

	// Token: 0x06018006 RID: 98310 RVA: 0x006B8C58 File Offset: 0x006B6E58
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetGameplayCueEffectForceRecycle(int entityId, long cueId)
	{
		CharacterGameplayCueComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGameplayCueComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		GameplayCueEffect gameplayCueEffect = component.GetCueByCueId(cueId) as GameplayCueEffect;
		if (gameplayCueEffect != null)
		{
			gameplayCueEffect.IsForceRecycle = true;
		}
	}

	// Token: 0x06018007 RID: 98311 RVA: 0x006B8C9A File Offset: 0x006B6E9A
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool IsLogicAutonomousProxy(int entityId)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		return component != null && component.IsAutonomousProxy;
	}

	// Token: 0x06018008 RID: 98312 RVA: 0x006B8CB4 File Offset: 0x006B6EB4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool RemoveActiveGameplayEffect(int entityId, FActiveGameplayEffectHandle handle, float stacksToRemove = -1f)
	{
		CharacterBuffComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterBuffComponent>(entityId);
		return component != null && component.Valid && component.RemoveBuffByHandle(handle.Handle, (int)stacksToRemove, null, null, null, null) > 0;
	}

	// Token: 0x06018009 RID: 98313 RVA: 0x006B8D10 File Offset: 0x006B6F10
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void RemoveBuffByTag(int entityId, FGameplayTag tag)
	{
		CharacterBuffComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterBuffComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.RemoveBuffByTag(new int?(tag.TagId()), "蓝图通过Tag移除Buff", null);
		}
	}

	// Token: 0x0601800A RID: 98314 RVA: 0x006B8D54 File Offset: 0x006B6F54
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void AddPassiveSkill(int entityId, long passiveSkillId)
	{
		Singleton<global::Log>.Instance.Error(ELogModule.Battle, ELogAuthor.ZQR, "废弃接口已无效", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601800B RID: 98315 RVA: 0x006B8D80 File Offset: 0x006B6F80
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void RemovePassiveSkill(int entityId, long passiveSkillId)
	{
		CharacterPassiveSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPassiveSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.ForgetPassiveSkill(passiveSkillId, false);
		}
	}

	// Token: 0x0601800C RID: 98316 RVA: 0x006B8DAC File Offset: 0x006B6FAC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetPassiveGaSkillId(int entityId, UObject callObject)
	{
	}

	// Token: 0x0601800D RID: 98317 RVA: 0x006B8DB0 File Offset: 0x006B6FB0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected unsafe static void AddBuffForDebug(int instigatorEntityId, int targetEntityId, long buffId)
	{
		long creatureDataId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(instigatorEntityId);
		BaseBuffComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseBuffComponent>(targetEntityId);
		if (component != null)
		{
			component.AddBuffForDebug(buffId, new AddBuffParam
			{
				InstigatorId = creatureDataId,
				Reason = "AddBuffForDebug"
			});
			return;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Battle;
		ELogAuthor author = ELogAuthor.ZQR;
		string message = "添加buff对象没有BuffComponent";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TargetEntityId", targetEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BuffId", buffId);
		instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0601800E RID: 98318 RVA: 0x006B8E54 File Offset: 0x006B7054
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SendCombatEventForDebug(int entityId, string tagName, bool needSave, bool isMainState)
	{
		int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
		string text = isMainState ? "GmSendMainBattleStateToFsm" : "GmSendSubBattleStateToFsm";
		string p = StringUtils.Format("{0} {1} {2} {3}", new string[]
		{
			text,
			ModelBase<CreatureModel>.Instance.GetCreatureDataId(entityId).ToString(),
			tagIdByName.ToString(),
			needSave ? "1" : "0"
		});
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.RunGm, p);
	}

	// Token: 0x0601800F RID: 98319 RVA: 0x006B8ED0 File Offset: 0x006B70D0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SendLevelEventForDebug(int entityId, string tagName)
	{
		int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
		string p = StringUtils.Format("GmFsmSendFsmNotifyLevelPlayEvent {0} {1}", new string[]
		{
			ModelBase<CreatureModel>.Instance.GetCreatureDataId(entityId).ToString(),
			tagIdByName.ToString()
		});
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.RunGm, p);
	}

	// Token: 0x06018010 RID: 98320 RVA: 0x006B8F28 File Offset: 0x006B7128
	[NullableContext(1)]
	private static string GetSpecialBuffToSkillId(long buffId, string skillId)
	{
		if (skillId != "")
		{
			return skillId;
		}
		long num;
		if (SpecialBuffToSkillIdMap.Values.TryGetValue(buffId, out num))
		{
			return num.ToString();
		}
		return "";
	}

	// Token: 0x06018011 RID: 98321 RVA: 0x006B8F60 File Offset: 0x006B7160
	[NullableContext(2)]
	private static Skill TryGetSummonedEntitySkillInner(int entityId, int skillId, ESummonType type)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity == null)
		{
			return null;
		}
		EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(entity, type, 1);
		WorldEntity worldEntity = (summonedEntity != null) ? summonedEntity.Entity : null;
		CharacterSkillComponent characterSkillComponent = (worldEntity != null) ? worldEntity.GetComponent<CharacterSkillComponent>() : null;
		if (characterSkillComponent == null)
		{
			return null;
		}
		return characterSkillComponent.GetSkill(skillId);
	}

	// Token: 0x06018012 RID: 98322 RVA: 0x006B8FAC File Offset: 0x006B71AC
	[NullableContext(2)]
	private static Skill TryGetSummonedEntitySkill(int entityId, int skillId)
	{
		Skill skill = TsGameplayBlueprintFunctionLibrary.TryGetSummonedEntitySkillInner(entityId, skillId, ESummonType.ConcomitantCustom);
		if (skill == null)
		{
			skill = TsGameplayBlueprintFunctionLibrary.TryGetSummonedEntitySkillInner(entityId, skillId, ESummonType.ConcomitantVision);
		}
		if (skill == null)
		{
			skill = TsGameplayBlueprintFunctionLibrary.TryGetSummonedEntitySkillInner(entityId, skillId, ESummonType.ConcomitantPhantomRole);
		}
		return skill;
	}

	// Token: 0x06018013 RID: 98323 RVA: 0x006B8FDC File Offset: 0x006B71DC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected unsafe static void AddBuffFromGA(int entityId, TsBaseCharacter target, long buffId, string skillId, int addCount)
	{
		string specialBuffToSkillId = TsGameplayBlueprintFunctionLibrary.GetSpecialBuffToSkillId(buffId, skillId);
		int num = -1;
		for (int i = 0; i < SpecialIgnoreGaBuff.Values.Length; i++)
		{
			if (SpecialIgnoreGaBuff.Values[i] == buffId)
			{
				num = i;
				break;
			}
		}
		if (specialBuffToSkillId == "" && num == -1)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "AddBuffFromGA的SkillId为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("buffId", buffId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		long creatureDataId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(entityId);
		if (creatureDataId == 0L)
		{
			return;
		}
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		Skill skill = (component != null) ? component.GetSkill(int.Parse(specialBuffToSkillId)) : null;
		long? preMessageId = (skill != null) ? skill.CombatMessageId : null;
		string text;
		if (skill == null)
		{
			text = null;
		}
		else
		{
			UClass abilityClass = skill.AbilityClass;
			text = ((abilityClass != null) ? abilityClass.GetName() : null);
		}
		string value = text;
		if (preMessageId == null)
		{
			long summonerId = Singleton<EntitySystem>.Instance.GetComponent<CreatureDataComponent>(entityId).GetSummonerId();
			if (summonerId > 0L)
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(summonerId);
				WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
				BaseSkillComponent baseSkillComponent = (worldEntity != null) ? worldEntity.GetComponent<BaseSkillComponent>() : null;
				long? num2;
				if (baseSkillComponent == null)
				{
					num2 = null;
				}
				else
				{
					Skill skill2 = baseSkillComponent.GetSkill(int.Parse(specialBuffToSkillId));
					num2 = ((skill2 != null) ? skill2.CombatMessageId : null);
				}
				preMessageId = num2;
				string text2;
				if (baseSkillComponent == null)
				{
					text2 = null;
				}
				else
				{
					Skill skill3 = baseSkillComponent.GetSkill(int.Parse(specialBuffToSkillId));
					if (skill3 == null)
					{
						text2 = null;
					}
					else
					{
						UClass abilityClass2 = skill3.AbilityClass;
						text2 = ((abilityClass2 != null) ? abilityClass2.GetName() : null);
					}
				}
				value = text2;
			}
			else
			{
				Skill skill4 = TsGameplayBlueprintFunctionLibrary.TryGetSummonedEntitySkill(entityId, int.Parse(specialBuffToSkillId));
				preMessageId = ((skill4 != null) ? skill4.CombatMessageId : null);
				string text3;
				if (skill4 == null)
				{
					text3 = null;
				}
				else
				{
					UClass abilityClass3 = skill4.AbilityClass;
					text3 = ((abilityClass3 != null) ? abilityClass3.GetName() : null);
				}
				value = text3;
			}
		}
		if (target != null)
		{
			CharacterBuffComponent characterBuffComponent = target.CharacterActorComponent.Entity.CheckGetComponent<CharacterBuffComponent>();
			if (characterBuffComponent != null)
			{
				BaseBuffComponent baseBuffComponent = characterBuffComponent;
				AddBuffParam addBuffParam = new AddBuffParam();
				addBuffParam.InstigatorId = creatureDataId;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 2);
				defaultInterpolatedStringHandler.AppendLiteral("技能");
				defaultInterpolatedStringHandler.AppendFormatted(specialBuffToSkillId);
				defaultInterpolatedStringHandler.AppendLiteral("GA");
				defaultInterpolatedStringHandler.AppendFormatted(value);
				defaultInterpolatedStringHandler.AppendLiteral("的buff添加");
				addBuffParam.Reason = defaultInterpolatedStringHandler.ToStringAndClear();
				addBuffParam.PreMessageId = preMessageId;
				addBuffParam.OuterStackCount = new int?(addCount);
				baseBuffComponent.AddBuff(buffId, addBuffParam);
				return;
			}
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Battle;
			ELogAuthor author2 = ELogAuthor.ZQR;
			string message2 = "添加buff对象没有BuffComponent";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Target", target);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BuffId", buffId);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x06018014 RID: 98324 RVA: 0x006B928C File Offset: 0x006B748C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void RemoveBuffById(int entityId, long buffId, int stackCount)
	{
		BaseBuffComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseBuffComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.RemoveBuff(buffId, stackCount, "从蓝图移除Buff", null, null, null);
	}

	// Token: 0x06018015 RID: 98325 RVA: 0x006B92E0 File Offset: 0x006B74E0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static int GetBuffCountById(int entityId, long buffId, bool enforceOnGoingCheck)
	{
		BaseBuffComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseBuffComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return 0;
		}
		return component.GetBuffTotalStackById(buffId, enforceOnGoingCheck);
	}

	// Token: 0x06018016 RID: 98326 RVA: 0x006B9314 File Offset: 0x006B7514
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void AddGameplayCueLocal(int entityId, float duration, long cueId)
	{
		BaseBuffComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseBuffComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		long[] cueIds = new long[]
		{
			cueId
		};
		component.AddGameplayCue(cueIds, duration, "蓝图AddGameplayCueLocal");
	}

	// Token: 0x06018017 RID: 98327 RVA: 0x006B9358 File Offset: 0x006B7558
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetGeDebugString(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		return ((component != null) ? component.GetGeDebugStrings() : null) ?? "";
	}

	// Token: 0x06018018 RID: 98328 RVA: 0x006B937A File Offset: 0x006B757A
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetTagDebugStrings(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		return ((component != null) ? component.GetTagDebugStrings() : null) ?? "";
	}

	// Token: 0x06018019 RID: 98329 RVA: 0x006B939C File Offset: 0x006B759C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetBuffDebugStrings(int entityId, string buffStr)
	{
		return TsGameplayBlueprintFunctionLibrary.GetBuffDebugStringsNoBlueprint(entityId, buffStr);
	}

	// Token: 0x0601801A RID: 98330 RVA: 0x006B93A5 File Offset: 0x006B75A5
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetShieldDebugString(int entityId, string filterStr = "")
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		return ((component != null) ? component.GetShieldDebugString(filterStr).Trim() : null) ?? "";
	}

	// Token: 0x0601801B RID: 98331 RVA: 0x006B93CD File Offset: 0x006B75CD
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetPassiveSkillDebugString(int entityId)
	{
		return "";
	}

	// Token: 0x0601801C RID: 98332 RVA: 0x006B93D4 File Offset: 0x006B75D4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetShieldValue(int entityId, int shieldCid)
	{
		CharacterShieldComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterShieldComponent>(entityId);
		return (float)((int)((component != null) ? component.GetShieldValue(shieldCid) : 0f));
	}

	// Token: 0x0601801D RID: 98333 RVA: 0x006B93F4 File Offset: 0x006B75F4
	[NullableContext(1)]
	public static string GetBuffDebugStringsNoBlueprint(int entityId, string buffStr = "")
	{
		CharacterBuffComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterBuffComponent>(entityId);
		CharacterGasDebugComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		return (((component != null) ? component.GetDebugBuffString(buffStr) : null) ?? "未找到buff组件") + "\n" + ((component2 != null) ? component2.GetShieldDebugString("") : null);
	}

	// Token: 0x0601801E RID: 98334 RVA: 0x006B9449 File Offset: 0x006B7649
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetAttributeDebugString(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		return ((component != null) ? component.GetAttributeDebugStrings() : null) ?? "";
	}

	// Token: 0x0601801F RID: 98335 RVA: 0x006B946B File Offset: 0x006B766B
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetAllAttributeDebugStrings(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		return ((component != null) ? component.GetAllAttributeDebugStrings() : null) ?? "";
	}

	// Token: 0x06018020 RID: 98336 RVA: 0x006B948D File Offset: 0x006B768D
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetServerBuffString(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.GetServerBuffString();
	}

	// Token: 0x06018021 RID: 98337 RVA: 0x006B94A5 File Offset: 0x006B76A5
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetServerTagString(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.GetServerTagString();
	}

	// Token: 0x06018022 RID: 98338 RVA: 0x006B94BD File Offset: 0x006B76BD
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetServerAttributeString(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.GetServerAttributeString();
	}

	// Token: 0x06018023 RID: 98339 RVA: 0x006B94D5 File Offset: 0x006B76D5
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetServerPartString(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.GetServerPartString();
	}

	// Token: 0x06018024 RID: 98340 RVA: 0x006B94ED File Offset: 0x006B76ED
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetServerHateString(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.GetServerHateString();
	}

	// Token: 0x06018025 RID: 98341 RVA: 0x006B9505 File Offset: 0x006B7705
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetServerShieldString(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.GetServerShieldString();
	}

	// Token: 0x06018026 RID: 98342 RVA: 0x006B951D File Offset: 0x006B771D
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ServerDebugInfoRequest(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.ServerDebugInfoRequest();
	}

	// Token: 0x06018027 RID: 98343 RVA: 0x006B9534 File Offset: 0x006B7734
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetServerDebugInfoDirty(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		return component != null && component.ServerDebugInfoDirty;
	}

	// Token: 0x06018028 RID: 98344 RVA: 0x006B954C File Offset: 0x006B774C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetServerDebugInfoDirty(int entityId, bool val)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component != null)
		{
			component.ServerDebugInfoDirty = val;
		}
	}

	// Token: 0x06018029 RID: 98345 RVA: 0x006B9570 File Offset: 0x006B7770
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void DebugResetBaseVal(int entityId, float id, float val)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component != null && component != null)
		{
			component.DebugResetBaseValue((int)id, val);
		}
		string p = StringUtils.Format("GmSetAttribute {0} {1} {2}", new string[]
		{
			ModelBase<CreatureModel>.Instance.GetCreatureDataId(entityId).ToString(),
			((int)id).ToString(),
			val.ToString()
		});
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.RunGm, p);
	}

	// Token: 0x0601802A RID: 98346 RVA: 0x006B95E7 File Offset: 0x006B77E7
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void DebugResetFormationValue(int id, float val)
	{
		ControllerBase<FormationAttributeController>.Instance.SetValue((EFormationAttributeId)id, val);
	}

	// Token: 0x0601802B RID: 98347 RVA: 0x006B95F5 File Offset: 0x006B77F5
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string Record(int entityId, bool record)
	{
		if (!Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			return "";
		}
		if (record)
		{
			CharacterGasDebugComponent.BeginRecord();
			return "";
		}
		return CharacterGasDebugComponent.EndRecord();
	}

	// Token: 0x0601802C RID: 98348 RVA: 0x006B961C File Offset: 0x006B781C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void RefreshEntityListView(UListView listView)
	{
		TArray<UObject> listItems = listView.GetListItems();
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = listItems.Num() - 1; i >= 0; i--)
		{
			UObject uobject = listItems.Get(i);
			string[] array = uobject.GetName().Split(',', StringSplitOptions.None);
			int item;
			if (array.Length != 0 && int.TryParse(array[0], out item))
			{
				if (!hashSet.Add(item))
				{
					listView.RemoveItem(uobject);
				}
			}
			else
			{
				listView.RemoveItem(uobject);
			}
		}
		IReadOnlyList<EntityHandle> allEntities = ModelBase<CreatureModel>.Instance.GetAllEntities();
		if (allEntities != null)
		{
			foreach (EntityHandle entityHandle in allEntities)
			{
				if (!hashSet.Contains(entityHandle.Id))
				{
					string text;
					if (entityHandle == null)
					{
						text = null;
					}
					else
					{
						WorldEntity entity = entityHandle.Entity;
						if (entity == null)
						{
							text = null;
						}
						else
						{
							CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
							if (component == null)
							{
								text = null;
							}
							else
							{
								TsBaseCharacter actor = component.Actor;
								text = ((actor != null) ? actor.GetName() : null);
							}
						}
					}
					string text2 = text;
					string str;
					if (text2 != null)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 3);
						defaultInterpolatedStringHandler.AppendFormatted(entityHandle.GetType().Name);
						defaultInterpolatedStringHandler.AppendLiteral("_");
						defaultInterpolatedStringHandler.AppendFormatted<int>(entityHandle.Id);
						defaultInterpolatedStringHandler.AppendLiteral("[");
						defaultInterpolatedStringHandler.AppendFormatted(text2);
						defaultInterpolatedStringHandler.AppendLiteral("]");
						str = defaultInterpolatedStringHandler.ToStringAndClear();
					}
					else
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
						defaultInterpolatedStringHandler.AppendFormatted(entityHandle.GetType().Name);
						defaultInterpolatedStringHandler.AppendLiteral("_");
						defaultInterpolatedStringHandler.AppendFormatted<int>(entityHandle.Id);
						str = defaultInterpolatedStringHandler.ToStringAndClear();
					}
					ULayer item2 = new ULayer(listView, entityHandle.Id.ToString() + "," + str, EObjectFlags.RF_NoFlags);
					listView.AddItem(item2);
				}
			}
		}
	}

	// Token: 0x0601802D RID: 98349 RVA: 0x006B9804 File Offset: 0x006B7A04
	[NullableContext(2)]
	private static string GetEntityActorName(Entity entity)
	{
		if (entity == null)
		{
			return null;
		}
		if (entity.GetComponent<BaseBuffComponent>() == null || entity.GetComponent<BaseSkillComponent>() == null || entity.GetComponent<BaseActorComponent>() == null)
		{
			if (Singleton<Info>.Instance.IsPlayInEditor)
			{
				BaseBuffComponent component = entity.GetComponent<BaseBuffComponent>();
				if (component != null && component.IsTeamBuffComponent())
				{
					return "PlayerEntity";
				}
			}
			return null;
		}
		BaseActorComponent component2 = entity.GetComponent<BaseActorComponent>();
		if (component2 == null)
		{
			return null;
		}
		AActor owner = component2.Owner;
		if (owner == null)
		{
			return null;
		}
		return owner.GetName();
	}

	// Token: 0x0601802E RID: 98350 RVA: 0x006B9874 File Offset: 0x006B7A74
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void RefreshEntityComboBox(UComboBoxString comboBox)
	{
		int optionCount = comboBox.GetOptionCount();
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = optionCount - 1; i >= 0; i--)
		{
			string optionAtIndex = comboBox.GetOptionAtIndex(i);
			Match match = new Regex("^(?<actorName>.+?)_(?<handleId>\\d+)$").Match(optionAtIndex);
			int num = 0;
			if (match.Success && match.Groups["handleId"].Success)
			{
				int.TryParse(match.Groups["handleId"].Value, out num);
			}
			string a = (match.Success && match.Groups["actorName"].Success) ? match.Groups["actorName"].Value : null;
			Entity entity = Singleton<EntitySystem>.Instance.Get(num);
			if (num == 0 || hashSet.Contains(num) || entity == null || a != TsGameplayBlueprintFunctionLibrary.GetEntityActorName(entity))
			{
				comboBox.RemoveOption(optionAtIndex);
			}
			else
			{
				hashSet.Add(num);
			}
		}
		IReadOnlyList<EntityHandle> allEntities = ModelBase<CreatureModel>.Instance.GetAllEntities();
		if (allEntities != null)
		{
			foreach (EntityHandle entityHandle in allEntities)
			{
				if (!hashSet.Contains((entityHandle != null) ? entityHandle.Id : 0))
				{
					string entityActorName = TsGameplayBlueprintFunctionLibrary.GetEntityActorName((entityHandle != null) ? entityHandle.Entity : null);
					if (entityActorName != null)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
						defaultInterpolatedStringHandler.AppendFormatted(entityActorName);
						defaultInterpolatedStringHandler.AppendLiteral("_");
						defaultInterpolatedStringHandler.AppendFormatted<int>(entityHandle.Id);
						comboBox.AddOption(defaultInterpolatedStringHandler.ToStringAndClear());
					}
				}
			}
		}
	}

	// Token: 0x0601802F RID: 98351 RVA: 0x006B9A30 File Offset: 0x006B7C30
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetEntityComboBox(UComboBoxString comboBox, int entityId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		string entityActorName = TsGameplayBlueprintFunctionLibrary.GetEntityActorName(entity);
		string selectedOption = comboBox.GetSelectedOption();
		if (entity == null || entityActorName == null)
		{
			if (!string.IsNullOrEmpty(selectedOption))
			{
				comboBox.ClearSelection();
			}
			return;
		}
		Match match = new Regex("_(?<entityId>\\d+)$").Match(selectedOption ?? "");
		int num = -1;
		if (match.Success && match.Groups["entityId"].Success)
		{
			int.TryParse(match.Groups["entityId"].Value, out num);
		}
		if (num != entityId)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted(entityActorName);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(entityId);
			string text = defaultInterpolatedStringHandler.ToStringAndClear();
			if (comboBox.FindOptionIndex(text) < 0)
			{
				comboBox.AddOption(text);
			}
			comboBox.SetSelectedOption(text);
		}
	}

	// Token: 0x06018030 RID: 98352 RVA: 0x006B9B0F File Offset: 0x006B7D0F
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetDebugEntityId(int entityId)
	{
		ControllerBase<CombatDebugController>.Instance.DebugEntityId = ((ControllerBase<CombatDebugController>.Instance.DebugEntityId == entityId) ? 0 : entityId);
	}

	// Token: 0x06018031 RID: 98353 RVA: 0x006B9B2C File Offset: 0x006B7D2C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static int GetDebugEntityId()
	{
		CombatDebugController instance = ControllerBase<CombatDebugController>.Instance;
		if (instance == null)
		{
			return 0;
		}
		return instance.DebugEntityId;
	}

	// Token: 0x06018032 RID: 98354 RVA: 0x006B9B40 File Offset: 0x006B7D40
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void RefreshBuffListView(int entityId, UListView listView, string filterStr = "")
	{
		MatchCollection matchCollection = new Regex("[0-9]+").Matches(filterStr);
		List<string> list = new List<string>();
		foreach (object obj in matchCollection)
		{
			Match match = (Match)obj;
			if (match.Success)
			{
				list.Add(match.Value);
			}
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		if (baseBuffComponent == null)
		{
			listView.ClearListItems();
			return;
		}
		RoleBuffComponent roleBuffComponent = baseBuffComponent as RoleBuffComponent;
		PlayerBuffComponent playerBuffComponent = (roleBuffComponent != null) ? roleBuffComponent.GetFormationBuffComp() : null;
		TArray<UObject> listItems = listView.GetListItems();
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = listItems.Num() - 1; i >= 0; i--)
		{
			UObject uobject = listItems.Get(i);
			string[] array = uobject.GetName().Split(',', StringSplitOptions.None);
			int handle;
			if (array.Length > 1 && int.TryParse(array[1], out handle))
			{
				IActiveBuff activeBuff = baseBuffComponent.GetBuffByHandle(handle);
				if (activeBuff == null)
				{
					activeBuff = ((playerBuffComponent != null) ? playerBuffComponent.GetBuffByHandle(handle) : null);
				}
				bool flag = false;
				if (activeBuff == null || hashSet.Contains(activeBuff.Handle))
				{
					flag = true;
				}
				else if (list.Count > 0)
				{
					bool flag2 = false;
					foreach (string value in list)
					{
						if (activeBuff.Id.ToString().StartsWith(value))
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						flag = true;
					}
				}
				if (flag)
				{
					listView.RemoveItem(uobject);
				}
				else
				{
					hashSet.Add(activeBuff.Handle);
				}
			}
			else
			{
				listView.RemoveItem(uobject);
			}
		}
		foreach (IActiveBuff activeBuff2 in baseBuffComponent.GetAllBuffs())
		{
			if (!hashSet.Contains(activeBuff2.Handle))
			{
				if (list.Count > 0)
				{
					bool flag3 = false;
					foreach (string value2 in list)
					{
						if (activeBuff2.Id.ToString().StartsWith(value2))
						{
							flag3 = true;
							break;
						}
					}
					if (!flag3)
					{
						goto IL_27D;
					}
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(entityId);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted<int>(activeBuff2.Handle);
				ULayer item = new ULayer(listView, defaultInterpolatedStringHandler.ToStringAndClear(), EObjectFlags.RF_NoFlags);
				listView.AddItem(item);
			}
			IL_27D:;
		}
		if (playerBuffComponent != null)
		{
			foreach (IActiveBuff activeBuff3 in playerBuffComponent.GetAllBuffs())
			{
				if (!hashSet.Contains(activeBuff3.Handle))
				{
					if (list.Count > 0)
					{
						bool flag4 = false;
						foreach (string value3 in list)
						{
							if (activeBuff3.Id.ToString().StartsWith(value3))
							{
								flag4 = true;
								break;
							}
						}
						if (!flag4)
						{
							goto IL_35B;
						}
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(entityId);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted<int>(activeBuff3.Handle);
					ULayer item2 = new ULayer(listView, defaultInterpolatedStringHandler.ToStringAndClear(), EObjectFlags.RF_NoFlags);
					listView.AddItem(item2);
				}
				IL_35B:;
			}
		}
	}

	// Token: 0x06018033 RID: 98355 RVA: 0x006B9EF0 File Offset: 0x006B80F0
	[NullableContext(2)]
	private static ActiveBuffInternal GetDebugBuff(int entityId, int handle)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		IActiveBuff activeBuff = (baseBuffComponent != null) ? baseBuffComponent.GetBuffByHandle(handle) : null;
		if (activeBuff != null)
		{
			return activeBuff as ActiveBuffInternal;
		}
		if (activeBuff == null)
		{
			RoleBuffComponent roleBuffComponent = baseBuffComponent as RoleBuffComponent;
			if (roleBuffComponent != null)
			{
				PlayerBuffComponent formationBuffComp = roleBuffComponent.GetFormationBuffComp();
				return ((formationBuffComp != null) ? formationBuffComp.GetBuffByHandle(handle) : null) as ActiveBuffInternal;
			}
		}
		return null;
	}

	// Token: 0x06018034 RID: 98356 RVA: 0x006B9F54 File Offset: 0x006B8154
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static long GetBuffIdByHandle(int entityId, int handle)
	{
		ActiveBuffInternal debugBuff = TsGameplayBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		if (debugBuff != null)
		{
			long id = debugBuff.Id;
			return debugBuff.Id;
		}
		return -1L;
	}

	// Token: 0x06018035 RID: 98357 RVA: 0x006B9F7E File Offset: 0x006B817E
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static int GetBuffServerIdByHandle(int entityId, int handle)
	{
		ActiveBuffInternal debugBuff = TsGameplayBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		if (debugBuff == null)
		{
			return -1;
		}
		return debugBuff.ServerId;
	}

	// Token: 0x06018036 RID: 98358 RVA: 0x006B9F94 File Offset: 0x006B8194
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetBuffDescByHandle(int entityId, int handle)
	{
		ActiveBuffInternal debugBuff = TsGameplayBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		string text;
		if (debugBuff == null)
		{
			text = null;
		}
		else
		{
			BuffDefinition config = debugBuff.Config;
			text = ((config != null) ? config.Desc : null);
		}
		string text2 = text ?? "Invalid";
		if (((debugBuff != null) ? debugBuff.GetOwnerBuffComponent() : null) is PlayerBuffComponent)
		{
			return "【编队buff】\n" + text2;
		}
		return text2;
	}

	// Token: 0x06018037 RID: 98359 RVA: 0x006B9FEB File Offset: 0x006B81EB
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetBuffActivateByHandle(int entityId, int handle)
	{
		ActiveBuffInternal debugBuff = TsGameplayBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		return debugBuff != null && debugBuff.IsActive();
	}

	// Token: 0x06018038 RID: 98360 RVA: 0x006B9FFF File Offset: 0x006B81FF
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetBuffInstigatorStringByHandle(int entityId, int handle)
	{
		ActiveBuffInternal debugBuff = TsGameplayBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		string text;
		if (debugBuff == null)
		{
			text = null;
		}
		else
		{
			CharacterActorComponent instigatorActorComponent = debugBuff.GetInstigatorActorComponent();
			text = ((instigatorActorComponent != null) ? instigatorActorComponent.Actor.GetName() : null);
		}
		return text ?? "Invalid";
	}

	// Token: 0x06018039 RID: 98361 RVA: 0x006BA030 File Offset: 0x006B8230
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetBuffPeriodStringByHandle(int entityId, int handle)
	{
		ActiveBuffInternal debugBuff = TsGameplayBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		if (debugBuff == null || debugBuff.Period <= 0f)
		{
			return "无";
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<float>(debugBuff.GetRemainPeriod().Value, "F1");
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<float>(debugBuff.Period, "F1");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0601803A RID: 98362 RVA: 0x006BA0A4 File Offset: 0x006B82A4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetBuffDurationStringByHandle(int entityId, int handle)
	{
		ActiveBuffInternal debugBuff = TsGameplayBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		if (debugBuff == null || debugBuff.Duration <= 0f)
		{
			return "无限";
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<float>(debugBuff.GetRemainDuration(), "F1");
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<float>(debugBuff.Duration, "F1");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0601803B RID: 98363 RVA: 0x006BA110 File Offset: 0x006B8310
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetBuffDurationProgress(int entityId, int handle)
	{
		ActiveBuffInternal debugBuff = TsGameplayBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		if (debugBuff == null || debugBuff.Duration <= 0f)
		{
			return 1f;
		}
		return debugBuff.GetRemainDuration() / debugBuff.Duration;
	}

	// Token: 0x0601803C RID: 98364 RVA: 0x006BA148 File Offset: 0x006B8348
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetBuffLivingStatusStringByHandle(int entityId, int handle)
	{
		ActiveBuffInternal debugBuff = TsGameplayBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		return ((debugBuff == null || !debugBuff.IsValid()) ? "销毁" : (debugBuff.IsActive() ? "激活" : "失效")) ?? "";
	}

	// Token: 0x0601803D RID: 98365 RVA: 0x006BA194 File Offset: 0x006B8394
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetBuffLevelStringByHandle(int entityId, int handle)
	{
		ActiveBuffInternal debugBuff = TsGameplayBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		return (((debugBuff != null) ? debugBuff.Level.ToString() : null) ?? "Invalid") ?? "";
	}

	// Token: 0x0601803E RID: 98366 RVA: 0x006BA1D0 File Offset: 0x006B83D0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetBuffStackStringByHandle(int entityId, int handle)
	{
		ActiveBuffInternal debugBuff = TsGameplayBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		return (((debugBuff != null) ? debugBuff.StackCount.ToString() : null) ?? "Invalid") ?? "";
	}

	// Token: 0x0601803F RID: 98367 RVA: 0x006BA20C File Offset: 0x006B840C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetBuffDebugStringByHandle(int entityId, int handle)
	{
		string text = "";
		ActiveBuffInternal debugBuff = TsGameplayBlueprintFunctionLibrary.GetDebugBuff(entityId, handle);
		IBuffComponent buffComponent = (debugBuff != null) ? debugBuff.GetOwnerBuffComponent() : null;
		if (debugBuff == null || buffComponent == null)
		{
			return text;
		}
		if (debugBuff.Config.GrantedTags != null)
		{
			foreach (int tagId in debugBuff.Config.GrantedTags)
			{
				text = text + "附加标签 " + GameplayTagUtils.GetNameByTagId(tagId) + "\n";
			}
		}
		ExtraEffectManager buffEffectManager = buffComponent.BuffEffectManager;
		foreach (BuffEffect buffEffect in (((buffEffectManager != null) ? buffEffectManager.GetEffectsByHandle(debugBuff.Handle) : null) ?? new List<BuffEffect>()))
		{
			double value = buffComponent.GetBuffEffectCd(buffEffect.BuffId, buffEffect.Index) / 1000.0;
			string str = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 3);
			defaultInterpolatedStringHandler.AppendLiteral("持续效果 ");
			defaultInterpolatedStringHandler.AppendFormatted(buffEffect.GetDebugString());
			defaultInterpolatedStringHandler.AppendLiteral("(cd:");
			defaultInterpolatedStringHandler.AppendFormatted<double>(value, "F1");
			defaultInterpolatedStringHandler.AppendLiteral("s");
			defaultInterpolatedStringHandler.AppendFormatted(buffComponent.GetTargetCdDebugStr(buffEffect.BuffId, buffEffect.Index));
			defaultInterpolatedStringHandler.AppendLiteral(")\n");
			text = str + defaultInterpolatedStringHandler.ToStringAndClear();
		}
		if (debugBuff.Config.EffectInfos != null)
		{
			foreach (ExtraEffectParameters extraEffectParameters in debugBuff.Config.EffectInfos)
			{
				BuffExecution executionEffect = extraEffectParameters.ExecutionEffect;
				if (ExtraEffectIdSets.periodExecutionIds.Contains(extraEffectParameters.ExtraEffectId) && executionEffect != null)
				{
					text = text + "周期效果 " + executionEffect.GetDebugString() + "\n";
				}
			}
		}
		if (debugBuff.Config.Modifiers != null)
		{
			IBuffModifierData[] modifiers = debugBuff.Config.Modifiers;
			int i = 0;
			while (i < modifiers.Length)
			{
				IBuffModifierData buffModifierData = modifiers[i];
				float levelValue = AbilityUtils.GetLevelValue<float>(buffModifierData.Value1, debugBuff.Level, 0f);
				float levelValue2 = AbilityUtils.GetLevelValue<float>(buffModifierData.Value2, debugBuff.Level, 0f);
				string text2 = buffModifierData.AttributeId.ToString();
				switch (buffModifierData.CalculationPolicy[0])
				{
				case 0:
				{
					string str2 = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 2);
					defaultInterpolatedStringHandler.AppendLiteral("属性");
					defaultInterpolatedStringHandler.AppendFormatted(text2);
					defaultInterpolatedStringHandler.AppendLiteral("增加");
					defaultInterpolatedStringHandler.AppendFormatted<float[]>(buffModifierData.Value1);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					text = str2 + defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case 1:
				{
					string str3 = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 2);
					defaultInterpolatedStringHandler.AppendLiteral("属性");
					defaultInterpolatedStringHandler.AppendFormatted(text2);
					defaultInterpolatedStringHandler.AppendLiteral("增加");
					defaultInterpolatedStringHandler.AppendFormatted<float>(levelValue * 0.0001f * 100f, "F1");
					defaultInterpolatedStringHandler.AppendLiteral("%\n");
					text = str3 + defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case 2:
				case 4:
				{
					string[] array = new string[]
					{
						"基础值",
						"当前值",
						"附加值"
					};
					string value2 = (buffModifierData.CalculationPolicy[3] < array.Length) ? array[buffModifierData.CalculationPolicy[3]] : "";
					string name = Enum.GetName(typeof(EAttributeType), buffModifierData.CalculationPolicy[1]);
					string str4 = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 8);
					defaultInterpolatedStringHandler.AppendLiteral("属性");
					defaultInterpolatedStringHandler.AppendFormatted(text2);
					defaultInterpolatedStringHandler.AppendFormatted((buffModifierData.CalculationPolicy[0] == 2) ? "增加" : "覆盖为");
					defaultInterpolatedStringHandler.AppendFormatted((buffModifierData.CalculationPolicy[2] == 1) ? "施加者" : "持有者");
					defaultInterpolatedStringHandler.AppendFormatted(name);
					defaultInterpolatedStringHandler.AppendFormatted(value2);
					defaultInterpolatedStringHandler.AppendLiteral("的");
					defaultInterpolatedStringHandler.AppendFormatted<double>((double)levelValue * 0.01, "F1");
					defaultInterpolatedStringHandler.AppendLiteral("%+");
					defaultInterpolatedStringHandler.AppendFormatted<float>(levelValue2);
					defaultInterpolatedStringHandler.AppendFormatted((buffModifierData.CalculationPolicy[4] != 0) ? "(快照)" : "");
					text = str4 + defaultInterpolatedStringHandler.ToStringAndClear();
					if (buffModifierData.CalculationPolicy[5] != 0)
					{
						string str5 = text;
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
						defaultInterpolatedStringHandler.AppendLiteral("，下限");
						defaultInterpolatedStringHandler.AppendFormatted<int>(buffModifierData.CalculationPolicy[5]);
						text = str5 + defaultInterpolatedStringHandler.ToStringAndClear();
					}
					if (buffModifierData.CalculationPolicy[6] != 0)
					{
						string str6 = text;
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
						defaultInterpolatedStringHandler.AppendLiteral("，比例");
						defaultInterpolatedStringHandler.AppendFormatted<int>(buffModifierData.CalculationPolicy[6]);
						text = str6 + defaultInterpolatedStringHandler.ToStringAndClear();
					}
					if (buffModifierData.CalculationPolicy[7] != 0)
					{
						string str7 = text;
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
						defaultInterpolatedStringHandler.AppendLiteral("，上限");
						defaultInterpolatedStringHandler.AppendFormatted<int>(buffModifierData.CalculationPolicy[7]);
						text = str7 + defaultInterpolatedStringHandler.ToStringAndClear();
					}
					text += "\n";
					break;
				}
				case 3:
				{
					string str8 = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 2);
					defaultInterpolatedStringHandler.AppendLiteral("属性");
					defaultInterpolatedStringHandler.AppendFormatted(text2);
					defaultInterpolatedStringHandler.AppendLiteral("覆盖为");
					defaultInterpolatedStringHandler.AppendFormatted<float[]>(buffModifierData.Value1);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					text = str8 + defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case 5:
				case 6:
				case 7:
				case 8:
					goto IL_67D;
				case 9:
				{
					string[] array2 = new string[]
					{
						"基础值",
						"当前值",
						"附加值"
					};
					string value3 = (buffModifierData.CalculationPolicy[3] < array2.Length) ? array2[buffModifierData.CalculationPolicy[3]] : "";
					string name2 = Enum.GetName(typeof(EAttributeType), buffModifierData.CalculationPolicy[1]);
					string str9 = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 4);
					defaultInterpolatedStringHandler.AppendLiteral("属性");
					defaultInterpolatedStringHandler.AppendFormatted(text2);
					defaultInterpolatedStringHandler.AppendLiteral("以");
					defaultInterpolatedStringHandler.AppendFormatted(name2);
					defaultInterpolatedStringHandler.AppendFormatted(value3);
					defaultInterpolatedStringHandler.AppendLiteral("的");
					defaultInterpolatedStringHandler.AppendFormatted<float>(levelValue * 0.0001f * 100f, "F1");
					defaultInterpolatedStringHandler.AppendLiteral("%为万分比增加/减少\n");
					text = str9 + defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				default:
					goto IL_67D;
				}
				IL_68B:
				i++;
				continue;
				IL_67D:
				text = text + "修改属性" + text2;
				goto IL_68B;
			}
		}
		return text.TrimEnd();
	}

	// Token: 0x06018040 RID: 98368 RVA: 0x006BA8D8 File Offset: 0x006B8AD8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetDistance(int entityId, float max)
	{
		CharacterGasDebugComponent.SetDistanceMax(max);
	}

	// Token: 0x06018041 RID: 98369 RVA: 0x006BA8E0 File Offset: 0x006B8AE0
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetAllMovementHistory(int entityId)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.GetAllMovementHistory();
	}

	// Token: 0x06018042 RID: 98370 RVA: 0x006BA8F8 File Offset: 0x006B8AF8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ResetBaseValueLocal(int entityId, int id, float val)
	{
		CharacterGasDebugComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterGasDebugComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.DebugResetBaseValue(id, val);
	}

	// Token: 0x06018043 RID: 98371 RVA: 0x006BA911 File Offset: 0x006B8B11
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetAttributeCurrentValue(int entityId, int attributeId)
	{
		BaseAttributeComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseAttributeComponent>(entityId);
		if (component == null)
		{
			return 0f;
		}
		return component.GetCurrentValue((EAttributeType)attributeId);
	}

	// Token: 0x06018044 RID: 98372 RVA: 0x006BA92E File Offset: 0x006B8B2E
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetAttributeBaseValue(int entityId, int attributeId)
	{
		BaseAttributeComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseAttributeComponent>(entityId);
		if (component == null)
		{
			return 0f;
		}
		return component.GetBaseValue((EAttributeType)attributeId);
	}

	// Token: 0x06018045 RID: 98373 RVA: 0x006BA94B File Offset: 0x006B8B4B
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetRageModeId(int entityId, int id)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetRageModeId(id);
	}

	// Token: 0x06018046 RID: 98374 RVA: 0x006BA963 File Offset: 0x006B8B63
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetHardnessModeId(int entityId, int id)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetHardnessModeId(id);
	}

	// Token: 0x06018047 RID: 98375 RVA: 0x006BA97C File Offset: 0x006B8B7C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void OnHit(int entityId, SHitInformation hitData)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		global::HitInformation hitData2 = global::HitInformation.FromUeHitInformation(hitData);
		if (component == null)
		{
			return;
		}
		component.OnHit(hitData2, null, false, false, null, null, null, null, false);
	}

	// Token: 0x06018048 RID: 98376 RVA: 0x006BA9AE File Offset: 0x006B8BAE
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetBeHitIgnoreRotate(int entityId, bool ignoreRotate)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetBeHitIgnoreRotate(ignoreRotate);
	}

	// Token: 0x06018049 RID: 98377 RVA: 0x006BA9C6 File Offset: 0x006B8BC6
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool CheckHasPart(int entityId)
	{
		CharacterPartComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPartComponent>(entityId);
		return component != null && component.IsMultiPart;
	}

	// Token: 0x0601804A RID: 98378 RVA: 0x006BA9E0 File Offset: 0x006B8BE0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetPartRemainedLife(int entityId, FGameplayTag tag)
	{
		CharacterPartComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPartComponent>(entityId);
		if (component != null && component.IsMultiPart)
		{
			return component.GetPartByTag(tag).RemainedLife();
		}
		return -1f;
	}

	// Token: 0x0601804B RID: 98379 RVA: 0x006BAA18 File Offset: 0x006B8C18
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ResetPartLife(int entityId, FGameplayTag tag)
	{
		CharacterPartComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPartComponent>(entityId);
		if (component != null && component.IsMultiPart)
		{
			component.GetPartByTag(tag).ResetLife();
		}
	}

	// Token: 0x0601804C RID: 98380 RVA: 0x006BAA48 File Offset: 0x006B8C48
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ActiveStiff(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.ActiveStiff(1f);
	}

	// Token: 0x0601804D RID: 98381 RVA: 0x006BAA64 File Offset: 0x006B8C64
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void DeActiveStiff(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.DeActiveStiff("蓝图退出硬直");
	}

	// Token: 0x0601804E RID: 98382 RVA: 0x006BAA80 File Offset: 0x006B8C80
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetAcceptedNewBeHitAndReset(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		return component != null && component.GetAcceptedNewBeHitAndReset();
	}

	// Token: 0x0601804F RID: 98383 RVA: 0x006BAA98 File Offset: 0x006B8C98
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetEnterFkAndReset(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		return component != null && component.GetEnterFkAndReset();
	}

	// Token: 0x06018050 RID: 98384 RVA: 0x006BAAB0 File Offset: 0x006B8CB0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool IsStiff(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		return component != null && component.IsStiff();
	}

	// Token: 0x06018051 RID: 98385 RVA: 0x006BAAC8 File Offset: 0x006B8CC8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetRageModeId(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		return (float)((component != null) ? component.RageModeId : 0);
	}

	// Token: 0x06018052 RID: 98386 RVA: 0x006BAAE2 File Offset: 0x006B8CE2
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetHardnessModeId(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		return (float)((component != null) ? component.HardnessModeId : 0);
	}

	// Token: 0x06018053 RID: 98387 RVA: 0x006BAAFC File Offset: 0x006B8CFC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FName GetBeHitBone(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (((component != null) ? component.BeHitBones : null) != null && component.BeHitBones.Length != 0)
		{
			return component.BeHitBones[0];
		}
		return FNameUtil.EMPTY;
	}

	// Token: 0x06018054 RID: 98388 RVA: 0x006BAB3E File Offset: 0x006B8D3E
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetToughDecreaseValue(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return 0f;
		}
		return component.ToughDecreaseValue;
	}

	// Token: 0x06018055 RID: 98389 RVA: 0x006BAB5A File Offset: 0x006B8D5A
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static SCounterAttack GetCounterAttackInfoInternal(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.CounterAttackInfoInternal;
	}

	// Token: 0x06018056 RID: 98390 RVA: 0x006BAB72 File Offset: 0x006B8D72
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static SVisionCounterAttack GetVisionCounterAttackInfoInternal(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.VisionCounterAttackInfoInternal;
	}

	// Token: 0x06018057 RID: 98391 RVA: 0x006BAB8A File Offset: 0x006B8D8A
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetBeHitTime(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return 0f;
		}
		return component.BeHitTime;
	}

	// Token: 0x06018058 RID: 98392 RVA: 0x006BABA8 File Offset: 0x006B8DA8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static EHitAnim GetBeHitAnim(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return EHitAnim.轻左;
		}
		return component.BeHitAnim;
	}

	// Token: 0x06018059 RID: 98393 RVA: 0x006BABCC File Offset: 0x006B8DCC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetEnterFk(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		return component != null && component.EnterFk;
	}

	// Token: 0x0601805A RID: 98394 RVA: 0x006BABE4 File Offset: 0x006B8DE4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble GetBeHitDirect(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return default(FVectorDouble);
		}
		return component.BeHitDirect.ToUeVector(false);
	}

	// Token: 0x0601805B RID: 98395 RVA: 0x006BAC18 File Offset: 0x006B8E18
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble GetBeHitLocation(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return default(FVectorDouble);
		}
		return component.BeHitLocation.ToUeVector(false);
	}

	// Token: 0x0601805C RID: 98396 RVA: 0x006BAC49 File Offset: 0x006B8E49
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void AddCheckBuffList(int entityId, SCounterAttackBuff addValue)
	{
	}

	// Token: 0x0601805D RID: 98397 RVA: 0x006BAC4B File Offset: 0x006B8E4B
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ClearCheckBuffList(int entityId)
	{
	}

	// Token: 0x0601805E RID: 98398 RVA: 0x006BAC4D File Offset: 0x006B8E4D
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void CounterAttackEnd(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.CounterAttackEnd();
	}

	// Token: 0x0601805F RID: 98399 RVA: 0x006BAC64 File Offset: 0x006B8E64
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void VisionCounterAttackEnd(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.VisionCounterAttackEnd();
	}

	// Token: 0x06018060 RID: 98400 RVA: 0x006BAC7B File Offset: 0x006B8E7B
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetCounterAttackEndTime(int entityId, float baseTime)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetCounterAttackEndTime(baseTime);
	}

	// Token: 0x06018061 RID: 98401 RVA: 0x006BAC93 File Offset: 0x006B8E93
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool IsTriggerCounterAttack(int entityId)
	{
		CharacterHitComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		return component != null && component.IsTriggerCounterAttack;
	}

	// Token: 0x06018062 RID: 98402 RVA: 0x006BACAB File Offset: 0x006B8EAB
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ResetTarget(int entityId)
	{
		CharacterLockOnComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterLockOnComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.ResetTarget();
	}

	// Token: 0x06018063 RID: 98403 RVA: 0x006BACC4 File Offset: 0x006B8EC4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetShowTarget(int entityId, AActor actor)
	{
		CharacterLockOnComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterLockOnComponent>(entityId);
		if (component != null && component.Valid)
		{
			if (actor != null)
			{
				EntityHandle entityByActor = ActorUtils.GetEntityByActor(actor, true);
				WorldEntity entity = (entityByActor != null) ? entityByActor.Entity : null;
				component.SetShowTarget(new EntityHandle(entity), "", false);
				return;
			}
			component.SetShowTarget(null, "", false);
		}
	}

	// Token: 0x06018064 RID: 98404 RVA: 0x006BAD24 File Offset: 0x006B8F24
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ExitLockDirection(int entityId)
	{
		CharacterLockOnComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterLockOnComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.ExitLockDirection();
		}
	}

	// Token: 0x06018065 RID: 98405 RVA: 0x006BAD50 File Offset: 0x006B8F50
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EnterLockDirection(int entityId)
	{
		CharacterLockOnComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterLockOnComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.EnterLockDirection();
		}
	}

	// Token: 0x06018066 RID: 98406 RVA: 0x006BAD7C File Offset: 0x006B8F7C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static TsBaseCharacter GetCurrentTarget(int entityId)
	{
		CharacterLockOnComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterLockOnComponent>(entityId);
		if (component != null && component.Valid)
		{
			EntityHandle currentTarget = component.GetCurrentTarget();
			object obj;
			if (currentTarget == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = currentTarget.Entity;
				if (entity == null)
				{
					obj = null;
				}
				else
				{
					BaseActorComponent component2 = entity.GetComponent<BaseActorComponent>();
					obj = ((component2 != null) ? component2.Owner : null);
				}
			}
			return obj as TsBaseCharacter;
		}
		return null;
	}

	// Token: 0x06018067 RID: 98407 RVA: 0x006BADD1 File Offset: 0x006B8FD1
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetLockOnDebugLine(int entityId, bool isShow)
	{
		LockOnDebug.IsShowDebugLine = isShow;
	}

	// Token: 0x06018068 RID: 98408 RVA: 0x006BADD9 File Offset: 0x006B8FD9
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool ManipulateValid(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		return component != null && component.Valid;
	}

	// Token: 0x06018069 RID: 98409 RVA: 0x006BADF4 File Offset: 0x006B8FF4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static AActor ManipulateGetDrawTarget(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.GetDrawTarget();
		}
		return null;
	}

	// Token: 0x0601806A RID: 98410 RVA: 0x006BAE20 File Offset: 0x006B9020
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static AActor ManipulateGetCastTarget(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.GetCastTarget();
		}
		return null;
	}

	// Token: 0x0601806B RID: 98411 RVA: 0x006BAE4C File Offset: 0x006B904C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float ManipulateGetDrawTargetChantTime(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.GetDrawTargetChantTime();
		}
		return 0f;
	}

	// Token: 0x0601806C RID: 98412 RVA: 0x006BAE7C File Offset: 0x006B907C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool ManipulateChant(int entityId, UKuroBooleanEventBinder eventBinder)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		return component != null && component.Valid && component.Chant(eventBinder);
	}

	// Token: 0x0601806D RID: 98413 RVA: 0x006BAEAC File Offset: 0x006B90AC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool ManipulateDraw(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		return component != null && component.Valid && component.Draw();
	}

	// Token: 0x0601806E RID: 98414 RVA: 0x006BAED8 File Offset: 0x006B90D8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool ManipulateCast(int entityId, float direction)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		return component != null && component.Valid && component.Precast((int)direction);
	}

	// Token: 0x0601806F RID: 98415 RVA: 0x006BAF08 File Offset: 0x006B9108
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ManipulateReset(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.Reset();
		}
	}

	// Token: 0x06018070 RID: 98416 RVA: 0x006BAF34 File Offset: 0x006B9134
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool ManipulateChangeToProjectileState(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		return component != null && component.Valid && component.ChangeToProjectileState();
	}

	// Token: 0x06018071 RID: 98417 RVA: 0x006BAF60 File Offset: 0x006B9160
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool ManipulateChangeToNormalState(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		return component != null && component.Valid && component.ChangeToNormalState();
	}

	// Token: 0x06018072 RID: 98418 RVA: 0x006BAF8C File Offset: 0x006B918C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static AActor GetHoldingActor(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.GetHoldingActor();
		}
		return null;
	}

	// Token: 0x06018073 RID: 98419 RVA: 0x006BAFB8 File Offset: 0x006B91B8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool HasHoldingActor(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		return component != null && component.Valid && component.HasHoldingActor();
	}

	// Token: 0x06018074 RID: 98420 RVA: 0x006BAFE4 File Offset: 0x006B91E4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetDebugDraw(int entityId, bool isActive)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.DebugDrawSphereAndArrow = isActive;
		}
	}

	// Token: 0x06018075 RID: 98421 RVA: 0x006BB010 File Offset: 0x006B9210
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ExtraAction(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.ExtraAction();
		}
	}

	// Token: 0x06018076 RID: 98422 RVA: 0x006BB03C File Offset: 0x006B923C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetQtePosition(int entityId, float rotate, float length, float height, bool referenceTarget, bool adjustWithMonster, float addHeight, int qteType = 0)
	{
		RoleQteComponent component = Singleton<EntitySystem>.Instance.GetComponent<RoleQteComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetQtePosition(new IOffsetParam
		{
			Rotate = rotate,
			Length = length,
			Height = height,
			ReferenceTarget = referenceTarget,
			QteType = (global::EQteType)qteType
		});
	}

	// Token: 0x06018077 RID: 98423 RVA: 0x006BB091 File Offset: 0x006B9291
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static TsBaseCharacter GetGoBattleActor(int entityId)
	{
		RoleQteComponent component = Singleton<EntitySystem>.Instance.GetComponent<RoleQteComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.GoBattleActor;
	}

	// Token: 0x06018078 RID: 98424 RVA: 0x006BB0AC File Offset: 0x006B92AC
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static UDataTable GetDtSkillInfo(int entityId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.GetFightDataTable(EFightDataTableKind.Skill, EFightDataTableSourceType.Self);
		}
		return null;
	}

	// Token: 0x06018079 RID: 98425 RVA: 0x006BB0DC File Offset: 0x006B92DC
	[UFunction(EFunctionFlags.FUNC_None)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	protected static TMap<ECharacterLoadType, UDataTable> GetDtSkillInfoMapForDebug(int entityId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			TMap<ECharacterLoadType, UDataTable> tmap = new TMap<ECharacterLoadType, UDataTable>();
			foreach (KeyValuePair<ECharacterLoadType, UDataTable> keyValuePair in component.GetDebugFightDataTables(EFightDataTableKind.Skill))
			{
				tmap.Add(keyValuePair.Key, keyValuePair.Value);
			}
			return tmap;
		}
		return null;
	}

	// Token: 0x0601807A RID: 98426 RVA: 0x006BB160 File Offset: 0x006B9360
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetLastActivateSkillTime(int entityId)
	{
		CharacterSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.LastActivateSkillTime;
		}
		return 0f;
	}

	// Token: 0x0601807B RID: 98427 RVA: 0x006BB190 File Offset: 0x006B9390
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetLastActivateSkillTime(int entityId, float time)
	{
		CharacterSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.SetLastActivateSkillTime(time);
		}
	}

	// Token: 0x0601807C RID: 98428 RVA: 0x006BB1BC File Offset: 0x006B93BC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetSkillElevationAngle(int entityId)
	{
		CharacterSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.SkillElevationAngle;
		}
		return 0f;
	}

	// Token: 0x0601807D RID: 98429 RVA: 0x006BB1EC File Offset: 0x006B93EC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetSkillElevationAngle(int entityId, float angle)
	{
		CharacterSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.SetSkillElevationAngle(angle);
		}
	}

	// Token: 0x0601807E RID: 98430 RVA: 0x006BB218 File Offset: 0x006B9418
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string CurrentSkillId(int entityId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return "";
		}
		Skill currentSkill = component.CurrentSkill;
		if (currentSkill == null)
		{
			return null;
		}
		return currentSkill.SkillId.ToString();
	}

	// Token: 0x0601807F RID: 98431 RVA: 0x006BB25C File Offset: 0x006B945C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static int CurrentPriority(int entityId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.CurrentPriority;
		}
		return 0;
	}

	// Token: 0x06018080 RID: 98432 RVA: 0x006BB288 File Offset: 0x006B9488
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetCurrentPriority(int entityId, int priority)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.SetCurrentPriority(priority);
		}
	}

	// Token: 0x06018081 RID: 98433 RVA: 0x006BB2B4 File Offset: 0x006B94B4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool HasAbility(int entityId, string skillId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		int skillId2;
		return component != null && component.Valid && int.TryParse(skillId, out skillId2) && component.HasAbility(skillId2);
	}

	// Token: 0x06018082 RID: 98434 RVA: 0x006BB2EC File Offset: 0x006B94EC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	[return: Nullable(2)]
	protected static SSkillInfo GetSkillInfo(int entityId, string skillId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		int skillId2;
		if (component != null && component.Valid && int.TryParse(skillId, out skillId2))
		{
			return component.GetSkillInfo(skillId2);
		}
		return null;
	}

	// Token: 0x06018083 RID: 98435 RVA: 0x006BB324 File Offset: 0x006B9524
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetSkillPriority(int entityId, string skillId, float priority)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		int skillId2;
		if (component != null && component.Valid && int.TryParse(skillId, out skillId2))
		{
			component.SetSkillPriority(skillId2, (int)priority);
		}
	}

	// Token: 0x06018084 RID: 98436 RVA: 0x006BB35C File Offset: 0x006B955C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EndSkill(int entityId, string skillId, bool isSyn, bool isNotEnd)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		int skillId2;
		if (component != null && component.Valid && int.TryParse(skillId, out skillId2))
		{
			component.EndSkill(skillId2, "TsGameplayBlueprintFunctionLibrary.EndSkill");
		}
	}

	// Token: 0x06018085 RID: 98437 RVA: 0x006BB398 File Offset: 0x006B9598
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool BeginSkill(int entityId, FName skillId, bool isSyn, AActor target, FName socketName)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		int skillId2;
		return component != null && component.Valid && int.TryParse(skillId.ToString(), out skillId2) && component.BeginSkill(skillId2, new SkillParam
		{
			TargetActor = target,
			SocketName = socketName.ToString(),
			Reason = "TsGameplayBlueprintFunctionLibrary.BeginSkill"
		});
	}

	// Token: 0x06018086 RID: 98438 RVA: 0x006BB408 File Offset: 0x006B9608
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected unsafe static void BeginSkillAsync(int entityId, FName skillId, [Nullable(2)] AActor target, FName socketName, UKuroBooleanEventBinder eventBinder)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			try
			{
				component.BeginSkillAsync(int.Parse(skillId.ToString()), new SkillParam
				{
					TargetActor = target,
					SocketName = socketName.ToString(),
					Reason = "TsGameplayBlueprintFunctionLibrary.BeginSkillAsync"
				}).ContinueWith(delegate(bool result)
				{
					UKuroBooleanEventBinder eventBinder2 = eventBinder;
					if (((eventBinder2 != null) ? eventBinder2.Callback : null) != null)
					{
						eventBinder.Callback.Broadcast(result);
						return;
					}
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.Battle;
					ELogAuthor author2 = ELogAuthor.HXY;
					string message2 = "BeginSkillAsync eventBinder 无效，无法广播结果";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("entityId", entityId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("skillId", skillId.ToString());
					instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				});
			}
			catch (Exception ex)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.HXY;
				string message = "BeginSkillAsync 异常";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityId", entityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("skillId", skillId.ToString());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("error", ex.ToString());
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
		}
	}

	// Token: 0x06018087 RID: 98439 RVA: 0x006BB550 File Offset: 0x006B9750
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SkillBehaviorBegin(int entityId, GA_Base_C ga, SSkillBehaviorAction action)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		BaseSkillComponent baseSkillComponent = (entity != null) ? entity.GetComponent<BaseSkillComponent>() : null;
		Skill skill = (baseSkillComponent != null) ? baseSkillComponent.GetSkill(ga.SkillId) : null;
		if (entity != null && baseSkillComponent != null && baseSkillComponent.Valid && skill != null)
		{
			BeginSkillBehaviorActionParam param = new BeginSkillBehaviorActionParam
			{
				Entity = entity,
				SkillComponent = baseSkillComponent,
				Skill = skill
			};
			SkillBehaviorAction.Begin(action, param);
		}
	}

	// Token: 0x06018088 RID: 98440 RVA: 0x006BB5BC File Offset: 0x006B97BC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble GetLocationByAction(int entityId, GA_Base_C ga, SSkillBehaviorAction action)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		BaseSkillComponent baseSkillComponent = (entity != null) ? entity.GetComponent<BaseSkillComponent>() : null;
		Skill skill = (baseSkillComponent != null) ? baseSkillComponent.GetSkill(ga.SkillId) : null;
		if (entity != null && baseSkillComponent != null && baseSkillComponent.Valid && skill != null)
		{
			BeginSkillBehaviorActionParam param = new BeginSkillBehaviorActionParam
			{
				Entity = entity,
				SkillComponent = baseSkillComponent,
				Skill = skill
			};
			return SkillBehaviorAction.CalculateLocation(action, param);
		}
		return global::Vector.ZeroVectorDouble;
	}

	// Token: 0x06018089 RID: 98441 RVA: 0x006BB630 File Offset: 0x006B9830
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FRotator GetRotationByAction(int entityId, GA_Base_C ga, SSkillBehaviorAction action)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		BaseSkillComponent baseSkillComponent = (entity != null) ? entity.GetComponent<BaseSkillComponent>() : null;
		Skill skill = (baseSkillComponent != null) ? baseSkillComponent.GetSkill(ga.SkillId) : null;
		if (entity != null && baseSkillComponent != null && baseSkillComponent.Valid && skill != null)
		{
			BeginSkillBehaviorActionParam param = new BeginSkillBehaviorActionParam
			{
				Entity = entity,
				SkillComponent = baseSkillComponent,
				Skill = skill
			};
			return SkillBehaviorAction.CalculateRotation(action, param);
		}
		return global::Rotator.ZeroRotator;
	}

	// Token: 0x0601808A RID: 98442 RVA: 0x006BB6A4 File Offset: 0x006B98A4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool SkillBehaviorSatisfy(int entityId, GA_Base_C ga, SSkillBehaviorCondition condition)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		BaseSkillComponent baseSkillComponent = (entity != null) ? entity.GetComponent<BaseSkillComponent>() : null;
		Skill skill = (baseSkillComponent != null) ? baseSkillComponent.GetSkill(ga.SkillId) : null;
		if (entity != null && baseSkillComponent != null && baseSkillComponent.Valid && skill != null)
		{
			BeginSkillBehaviorConditionParam param = new BeginSkillBehaviorConditionParam
			{
				Entity = entity,
				SkillComponent = baseSkillComponent,
				Skill = skill
			};
			return SkillBehaviorCondition.Satisfy(condition, param);
		}
		return false;
	}

	// Token: 0x0601808B RID: 98443 RVA: 0x006BB714 File Offset: 0x006B9914
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static AActor GetSkillTarget(int entityId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null)
		{
			EntityHandle skillTarget = component.SkillTarget;
			if (((skillTarget != null) ? new bool?(skillTarget.Valid) : null).GetValueOrDefault())
			{
				WorldEntity entity = component.SkillTarget.Entity;
				if (entity == null)
				{
					return null;
				}
				BaseActorComponent component2 = entity.GetComponent<BaseActorComponent>();
				if (component2 == null)
				{
					return null;
				}
				return component2.Owner;
			}
		}
		return null;
	}

	// Token: 0x0601808C RID: 98444 RVA: 0x006BB77C File Offset: 0x006B997C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetSkillTarget(int entityId, AActor target)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.SkillTarget = null;
			if (target != null)
			{
				EntityHandle entityByActor = ActorUtils.GetEntityByActor(target, true);
				WorldEntity worldEntity = (entityByActor != null) ? entityByActor.Entity : null;
				if (worldEntity != null)
				{
					component.SkillTarget = new EntityHandle(worldEntity);
				}
			}
		}
	}

	// Token: 0x0601808D RID: 98445 RVA: 0x006BB7D0 File Offset: 0x006B99D0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void LockOnTargetAndSetShow(int entityId, SSkillTarget config)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.LockOnTargetAndSetShow(config, true);
		}
	}

	// Token: 0x0601808E RID: 98446 RVA: 0x006BB7FC File Offset: 0x006B99FC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool IsHasInputDir(int entityId)
	{
		CharacterSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSkillComponent>(entityId);
		return component != null && component.Valid && component.IsHasInputDir();
	}

	// Token: 0x0601808F RID: 98447 RVA: 0x006BB828 File Offset: 0x006B9A28
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetSkillIdWithGroupId(int entityId, int groupId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.GetSkillIdWithGroupId(groupId).ToString();
		}
		return "";
	}

	// Token: 0x06018090 RID: 98448 RVA: 0x006BB864 File Offset: 0x006B9A64
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetSkillAcceptInput(int entityId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		return component != null && component.Valid && component.SkillAcceptInput;
	}

	// Token: 0x06018091 RID: 98449 RVA: 0x006BB890 File Offset: 0x006B9A90
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetSkillAcceptInput(int entityId, bool skillAcceptInput)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.SetSkillAcceptInput(skillAcceptInput);
		}
	}

	// Token: 0x06018092 RID: 98450 RVA: 0x006BB8BC File Offset: 0x006B9ABC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetCommonSkillCanBeInterrupt(int entityId, bool canBeInterrupt)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.IsMainSkillReadyEnd = canBeInterrupt;
		}
	}

	// Token: 0x06018093 RID: 98451 RVA: 0x006BB8E8 File Offset: 0x006B9AE8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetCommonSkillCanBeInterrupt(int entityId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		return component != null && component.Valid && component.IsMainSkillReadyEnd;
	}

	// Token: 0x06018094 RID: 98452 RVA: 0x006BB914 File Offset: 0x006B9B14
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float OnActivateAbility(int entityId, UGameplayAbility ga, bool isCommitSuccess)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			return (float)component.OnActivateAbility(ga, isCommitSuccess);
		}
		return -1f;
	}

	// Token: 0x06018095 RID: 98453 RVA: 0x006BB948 File Offset: 0x006B9B48
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void OnEndAbility(int entityId, UGameplayAbility ga, bool wasCancelled)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.OnEndAbility(ga, wasCancelled);
		}
	}

	// Token: 0x06018096 RID: 98454 RVA: 0x006BB974 File Offset: 0x006B9B74
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetPriority(int entityId, string skillId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		int skillId2;
		if (component != null && component.Valid && int.TryParse(skillId, out skillId2))
		{
			return (float)component.GetPriority(skillId2);
		}
		return -1f;
	}

	// Token: 0x06018097 RID: 98455 RVA: 0x006BB9B0 File Offset: 0x006B9BB0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetActivePriority(int entityId, string skillId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		int skillId2;
		if (component != null && component.Valid && int.TryParse(skillId, out skillId2))
		{
			return (float)component.GetActivePriority(skillId2);
		}
		return -1f;
	}

	// Token: 0x06018098 RID: 98456 RVA: 0x006BB9EC File Offset: 0x006B9BEC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	[return: Nullable(2)]
	protected static UAnimMontage GetSkillMontageInstance(int entityId, string skillId, int index)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		int skillId2;
		if (component != null && component.Valid && int.TryParse(skillId, out skillId2))
		{
			return component.GetSkillMontageInstance(skillId2, index);
		}
		return null;
	}

	// Token: 0x06018099 RID: 98457 RVA: 0x006BBA24 File Offset: 0x006B9C24
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static int GetSkillNeedPlayMontageIndex(int entityId, string skillId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		int skillId2;
		if (component != null && component.Valid && int.TryParse(skillId, out skillId2))
		{
			return component.GetSkillNeedPlayMontageIndex(skillId2);
		}
		return -1;
	}

	// Token: 0x0601809A RID: 98458 RVA: 0x006BBA5C File Offset: 0x006B9C5C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void CreateSpecifiedTagPlayMontageAndWaitAbilityTask(GA_Base_C gameplayAbility, bool checkHit, FGameplayTag skeletalMeshComponentTag, int montageIndex, FName startSection, float startTimeSeconds, bool needTick, float animRootMotionTranslationScale = 1f)
	{
		TsBaseCharacter tsBaseCharacter = new TsBaseCharacter();
		gameplayAbility.获取施法者(ref tsBaseCharacter);
		int entityId = tsBaseCharacter.EntityId;
		if (checkHit)
		{
			FGameplayTagContainer fgameplayTagContainer = new FGameplayTagContainer();
			FGameplayTag? gameplayTagByName = GameplayTagUtils.GetGameplayTagByName("行为状态.动作状态.受击");
			if (gameplayTagByName != null)
			{
				fgameplayTagContainer.GameplayTags.Add(gameplayTagByName.Value);
				bool flag = false;
				gameplayAbility.是否拥有任意标签(tsBaseCharacter, fgameplayTagContainer, ref flag);
				return;
			}
		}
		else
		{
			TsGameplayBlueprintFunctionLibrary.ExitHitState(entityId);
			AActor owningActorFromActorInfo = gameplayAbility.GetOwningActorFromActorInfo();
			if (owningActorFromActorInfo != null && owningActorFromActorInfo.IsValid())
			{
				TsBaseCharacter tsBaseCharacter2 = owningActorFromActorInfo as TsBaseCharacter;
				if (tsBaseCharacter2 != null)
				{
					string skillId = "";
					gameplayAbility.获取当前GA的技能数据名(ref skillId);
					float rate = 1f;
					gameplayAbility.获取当前技能攻速(ref rate);
					TsGameplayBlueprintFunctionLibrary.PlaySkillMontage2Server(tsBaseCharacter2.EntityId, skillId, (float)montageIndex, rate, startSection.ToString(), startTimeSeconds);
					UAnimMontage uanimMontage = new UAnimMontage();
					gameplayAbility.获取技能动画(montageIndex, ref uanimMontage);
				}
			}
		}
	}

	// Token: 0x0601809B RID: 98459 RVA: 0x006BBB38 File Offset: 0x006B9D38
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetSkillRotateLocation(int entityId, FVectorDouble location)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			global::Vector target = global::Vector.Create(location);
			component.SetRotateTarget(target, ESkillRotateType.Location);
		}
	}

	// Token: 0x0601809C RID: 98460 RVA: 0x006BBB70 File Offset: 0x006B9D70
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetSkillRotateDirect(int entityId, FVectorDouble direct)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			global::Vector target = global::Vector.Create(direct);
			component.SetRotateTarget(target, ESkillRotateType.Direct);
		}
	}

	// Token: 0x0601809D RID: 98461 RVA: 0x006BBBA8 File Offset: 0x006B9DA8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void CallAnimBreakPoint(int entityId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.CallAnimBreakPoint();
		}
	}

	// Token: 0x0601809E RID: 98462 RVA: 0x006BBBD4 File Offset: 0x006B9DD4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void RollingGround(int entityId)
	{
		CharacterSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.RollingGrounded();
		}
	}

	// Token: 0x0601809F RID: 98463 RVA: 0x006BBC00 File Offset: 0x006B9E00
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool ActivateAbilityVision(int entityId, EVisionType visionType)
	{
		CharacterVisionComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterVisionComponent>(entityId);
		return component != null && component.Valid && component.ActivateAbilityVision(visionType);
	}

	// Token: 0x060180A0 RID: 98464 RVA: 0x006BBC30 File Offset: 0x006B9E30
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool EndAbilityVision(int entityId, EVisionType visionType)
	{
		CharacterVisionComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterVisionComponent>(entityId);
		return component != null && component.Valid && component.EndAbilityVision(visionType);
	}

	// Token: 0x060180A1 RID: 98465 RVA: 0x006BBC60 File Offset: 0x006B9E60
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ActivateAbilityVisionPlayAudio(int entityId, EVisionType visionType)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component != null && component.Valid)
		{
			if (visionType != EVisionType.召唤)
			{
				if (visionType == EVisionType.变身)
				{
					ControllerBase<RoleAudioController>.Instance.PlayRoleAudio(component.Entity, ERoleAudioType.VisionMorph, null);
					return;
				}
			}
			else
			{
				ControllerBase<RoleAudioController>.Instance.PlayRoleAudio(component.Entity, ERoleAudioType.VisionSummon, null);
			}
		}
	}

	// Token: 0x060180A2 RID: 98466 RVA: 0x006BBCBC File Offset: 0x006B9EBC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static TArray<int> GetVisionIdList(int entityId)
	{
		TArray<int> tarray = new TArray<int>();
		CharacterVisionComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterVisionComponent>(entityId);
		if (component != null && component.Valid)
		{
			int visionId = component.GetVisionId(null);
			if (visionId != 0)
			{
				tarray.Add(visionId);
			}
		}
		return tarray;
	}

	// Token: 0x060180A3 RID: 98467 RVA: 0x006BBD01 File Offset: 0x006B9F01
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ExitMultiSkillStateOfMorphVision(int entityId)
	{
		EntityHandle summonedEntityByOwnerId = PhantomUtil.GetSummonedEntityByOwnerId(entityId, ESummonType.ConcomitantVision, 1);
		VisionSkillComponent visionSkillComponent = (summonedEntityByOwnerId != null) ? summonedEntityByOwnerId.Entity.GetComponent<VisionSkillComponent>() : null;
		if (visionSkillComponent == null)
		{
			return;
		}
		visionSkillComponent.ExitMultiSkillState();
	}

	// Token: 0x060180A4 RID: 98468 RVA: 0x006BBD26 File Offset: 0x006B9F26
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetKeepMultiSkillState(int entityId, bool keepOnMorphEnd, bool keepOnGoDown)
	{
		EntityHandle summonedEntityByOwnerId = PhantomUtil.GetSummonedEntityByOwnerId(entityId, ESummonType.ConcomitantVision, 1);
		VisionSkillComponent visionSkillComponent = (summonedEntityByOwnerId != null) ? summonedEntityByOwnerId.Entity.GetComponent<VisionSkillComponent>() : null;
		if (visionSkillComponent == null)
		{
			return;
		}
		visionSkillComponent.SetKeepMultiSkillState(keepOnMorphEnd, keepOnGoDown);
	}

	// Token: 0x060180A5 RID: 98469 RVA: 0x006BBD4D File Offset: 0x006B9F4D
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetEnableAttackInputActionOfMorphVision(int entityId, bool bEnable)
	{
		EntityHandle summonedEntityByOwnerId = PhantomUtil.GetSummonedEntityByOwnerId(entityId, ESummonType.ConcomitantVision, 1);
		VisionSkillComponent visionSkillComponent = (summonedEntityByOwnerId != null) ? summonedEntityByOwnerId.Entity.GetComponent<VisionSkillComponent>() : null;
		if (visionSkillComponent == null)
		{
			return;
		}
		visionSkillComponent.SetEnableAttackInputAction(bEnable);
	}

	// Token: 0x060180A6 RID: 98470 RVA: 0x006BBD73 File Offset: 0x006B9F73
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static TArray<int> GetVisionLevelList(int entityId)
	{
		return new TArray<int>();
	}

	// Token: 0x060180A7 RID: 98471 RVA: 0x006BBD7A File Offset: 0x006B9F7A
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static int GetVisionSkillId(int entityId, float visionId, float level)
	{
		return PhantomUtil.GetEntityVisionSkillId(entityId, (int)visionId);
	}

	// Token: 0x060180A8 RID: 98472 RVA: 0x006BBD84 File Offset: 0x006B9F84
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void InterruptSkill(int entityId, string skillId, bool isSyn)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		int skillId2;
		if (component != null && component.Valid && int.TryParse(skillId, out skillId2))
		{
			component.EndSkill(skillId2, "TsGameplayBlueprintFunctionLibrary.InterruptSkill");
		}
	}

	// Token: 0x060180A9 RID: 98473 RVA: 0x006BBDC0 File Offset: 0x006B9FC0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void DeleteSkills(int entityId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.StopAllSkills("TsGameplayBlueprintFunctionLibrary.DeleteSkills");
		}
	}

	// Token: 0x060180AA RID: 98474 RVA: 0x006BBDF0 File Offset: 0x006B9FF0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetCurrentMontageCorrespondingSkillId(int entityId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.GetCurrentMontageCorrespondingSkillId().ToString();
		}
		return "";
	}

	// Token: 0x060180AB RID: 98475 RVA: 0x006BBE28 File Offset: 0x006BA028
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetSocketName(int entityId, string socketName)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.SkillTargetSocket = socketName;
		}
	}

	// Token: 0x060180AC RID: 98476 RVA: 0x006BBE54 File Offset: 0x006BA054
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetSocketName(int entityId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.SkillTargetSocket;
		}
		return "";
	}

	// Token: 0x060180AD RID: 98477 RVA: 0x006BBE84 File Offset: 0x006BA084
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FTransformDouble GetPointTransform(int entityId, string boneName)
	{
		BaseActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return default(FTransformDouble);
		}
		FName? dynamicFName = FNameUtil.GetDynamicFName(boneName);
		USkeletalMeshComponent skeletalMesh = component.SkeletalMesh;
		if (((skeletalMesh != null) ? new bool?(skeletalMesh.DoesSocketExist(dynamicFName.Value)) : null).GetValueOrDefault())
		{
			return skeletalMesh.D_GetSocketTransform(dynamicFName.Value, ERelativeTransformSpace.RTS_World);
		}
		return default(FTransformDouble);
	}

	// Token: 0x060180AE RID: 98478 RVA: 0x006BBF0C File Offset: 0x006BA10C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void PlaySkillMontage2Server(int entityId, string skillId, float montageIndex, float rate, string startSection, float startTimeSeconds)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		int skillId2;
		if (component != null && component.Valid && int.TryParse(skillId, out skillId2))
		{
			component.PlaySkillMontage2Server(skillId2, (int)montageIndex, rate, startSection, startTimeSeconds);
		}
	}

	// Token: 0x060180AF RID: 98479 RVA: 0x006BBF48 File Offset: 0x006BA148
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EndSkillMontage(int entityId, string skillId, float montageIndex)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		int skillId2;
		if (component != null && component.Valid && int.TryParse(skillId, out skillId2))
		{
			component.EndSkillMontage(skillId2, (int)montageIndex);
		}
	}

	// Token: 0x060180B0 RID: 98480 RVA: 0x006BBF80 File Offset: 0x006BA180
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void BeginAddMoveByInputDirect(int entityId, float maxSpeed, float accelerationTime, float decelerationTime, float delayTime)
	{
		CharacterSpecialSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSpecialSkillComponent>(entityId);
		SpecialSkillKanteleila specialSkillKanteleila = ((component != null) ? component.SpecialSkill : null) as SpecialSkillKanteleila;
		if (specialSkillKanteleila != null)
		{
			specialSkillKanteleila.BeginAddMoveByInputDirect(maxSpeed, accelerationTime, decelerationTime, delayTime);
		}
	}

	// Token: 0x060180B1 RID: 98481 RVA: 0x006BBFB8 File Offset: 0x006BA1B8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void BeginAbsoluteTimeStop(int entityId, float duration, bool stopMove = true)
	{
		SkillUtils.BeginAbsoluteTimeStop(entityId, duration, stopMove, 0f);
	}

	// Token: 0x060180B2 RID: 98482 RVA: 0x006BBFC7 File Offset: 0x006BA1C7
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void EndAbsoluteTimeStop(int entityId)
	{
		SkillUtils.EndAbsoluteTimeStop(entityId);
	}

	// Token: 0x060180B3 RID: 98483 RVA: 0x006BBFCF File Offset: 0x006BA1CF
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void BeginTimeStopRequest(int entityId, float duration)
	{
		SkillUtils.BeginTimeStopRequest(entityId, duration, 0f);
	}

	// Token: 0x060180B4 RID: 98484 RVA: 0x006BBFDD File Offset: 0x006BA1DD
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void EndTimeStopRequest(int entityId)
	{
		SkillUtils.EndTimeStopRequest(entityId);
	}

	// Token: 0x060180B5 RID: 98485 RVA: 0x006BBFE5 File Offset: 0x006BA1E5
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void EndAddMoveByInputDirect(int entityId)
	{
		CharacterSpecialSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSpecialSkillComponent>(entityId);
		SpecialSkillBase specialSkillBase = (component != null) ? component.SpecialSkill : null;
		if (specialSkillBase == null)
		{
			return;
		}
		specialSkillBase.EndAddMoveByInputDirect();
	}

	// Token: 0x060180B6 RID: 98486 RVA: 0x006BC008 File Offset: 0x006BA208
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool CanActivateFixHook(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		return component != null && component.Valid && component.CanActivateFixHook();
	}

	// Token: 0x060180B7 RID: 98487 RVA: 0x006BC034 File Offset: 0x006BA234
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble FixHookTargetLocation(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.GetCurrentTargetLocation().ToUeVector(false);
		}
		return default(FVectorDouble);
	}

	// Token: 0x060180B8 RID: 98488 RVA: 0x006BC070 File Offset: 0x006BA270
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static TArray<FVectorDouble> FixHookTargetPathways(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			List<ValueTuple<global::Vector, global::Vector>> currentPathways = component.GetCurrentPathways();
			if (currentPathways != null)
			{
				TArray<FVectorDouble> tarray = new TArray<FVectorDouble>();
				if (currentPathways.Count > 0)
				{
					using (List<ValueTuple<global::Vector, global::Vector>>.Enumerator enumerator = currentPathways.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ValueTuple<global::Vector, global::Vector> valueTuple = enumerator.Current;
							tarray.Add(valueTuple.Item1.ToUeVector(false));
							tarray.Add(valueTuple.Item2.ToUeVector(false));
						}
						return tarray;
					}
				}
				tarray.Add(component.ActorComp.ActorLocationProxy.ToUeVector(false));
				tarray.Add(component.GetCurrentTargetLocation().ToUeVector(false));
				return tarray;
			}
		}
		return null;
	}

	// Token: 0x060180B9 RID: 98489 RVA: 0x006BC144 File Offset: 0x006BA344
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static AActor FixHookTargetEnterPortalCapture(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.GetCurrentTargetEnterPortalCapture();
		}
		return null;
	}

	// Token: 0x060180BA RID: 98490 RVA: 0x006BC170 File Offset: 0x006BA370
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static AActor FixHookTargetActor(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.GetCurrentTargetActor();
		}
		return null;
	}

	// Token: 0x060180BB RID: 98491 RVA: 0x006BC19C File Offset: 0x006BA39C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool FixHookTargetIsSuiGuangType(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		return component != null && component.Valid && component.GetTargetIsSuiGuangType();
	}

	// Token: 0x060180BC RID: 98492 RVA: 0x006BC1C8 File Offset: 0x006BA3C8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static EHookInteractTypeBp GetHookTargetType(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.GetTargetType();
		}
		return EHookInteractTypeBp.FixedPointHook;
	}

	// Token: 0x060180BD RID: 98493 RVA: 0x006BC1F4 File Offset: 0x006BA3F4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble FixHookTargetForward(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.GetCurrentTargetForward();
		}
		return default(FVectorDouble);
	}

	// Token: 0x060180BE RID: 98494 RVA: 0x006BC228 File Offset: 0x006BA428
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble NextFixHookTargetLocation(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			return component.GetNextTargetLocation();
		}
		return default(FVectorDouble);
	}

	// Token: 0x060180BF RID: 98495 RVA: 0x006BC25C File Offset: 0x006BA45C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool FixHookTargetInheritSpeed(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		return component != null && component.Valid && component.GetInheritSpeed();
	}

	// Token: 0x060180C0 RID: 98496 RVA: 0x006BC288 File Offset: 0x006BA488
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool FixHookTargetIsClimb(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		return component != null && component.Valid && component.GetIsClimb();
	}

	// Token: 0x060180C1 RID: 98497 RVA: 0x006BC2B4 File Offset: 0x006BA4B4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetIsHookEndByInterrupt(int entityId, bool isInterrupt)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.SetIsHookEndByInterrupt(isInterrupt);
		}
	}

	// Token: 0x060180C2 RID: 98498 RVA: 0x006BC2E0 File Offset: 0x006BA4E0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool FixHookIsSummitPoint(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			GrapplingHookPointComponent currentTarget = component.GetCurrentTarget();
			return currentTarget != null && currentTarget.IsSummitPoint;
		}
		return false;
	}

	// Token: 0x060180C3 RID: 98499 RVA: 0x006BC318 File Offset: 0x006BA518
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool FixHookIsNormalPoint(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			GrapplingHookPointComponent currentTarget = component.GetCurrentTarget();
			return currentTarget != null && currentTarget.IsNormalHookPoint;
		}
		return false;
	}

	// Token: 0x060180C4 RID: 98500 RVA: 0x006BC350 File Offset: 0x006BA550
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static int GetHookOverrideSpeed(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			GrapplingHookPointComponent currentTarget = component.GetCurrentTarget();
			return (int)((currentTarget != null) ? currentTarget.HookOverrideSpeed : -1f);
		}
		return -1;
	}

	// Token: 0x060180C5 RID: 98501 RVA: 0x006BC390 File Offset: 0x006BA590
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool FixHookIsGravityPoint(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			GrapplingHookPointComponent currentTarget = component.GetCurrentTarget();
			return currentTarget != null && currentTarget.IsGravityHookPoint;
		}
		return false;
	}

	// Token: 0x060180C6 RID: 98502 RVA: 0x006BC3C8 File Offset: 0x006BA5C8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static int FixHookTargetEntityId(int entityId)
	{
		BaseExploreComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseExploreComponent>(entityId);
		Entity entity;
		if (component == null)
		{
			entity = null;
		}
		else
		{
			GrapplingHookPointComponent interactingTarget = component.InteractingTarget;
			entity = ((interactingTarget != null) ? interactingTarget.Entity : null);
		}
		Entity entity2 = entity;
		if (entity2 != null)
		{
			return entity2.Id;
		}
		return 0;
	}

	// Token: 0x060180C7 RID: 98503 RVA: 0x006BC404 File Offset: 0x006BA604
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool SlashHookPointHasLookAtConfig(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			GrapplingHookPointComponent currentTarget = component.GetCurrentTarget();
			return ((currentTarget != null) ? currentTarget.GetSlashHookCharacterLookAtPoint() : null) != null;
		}
		return false;
	}

	// Token: 0x060180C8 RID: 98504 RVA: 0x006BC440 File Offset: 0x006BA640
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble SlashHookPointCharacterLookAtPoint(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			GrapplingHookPointComponent currentTarget = component.GetCurrentTarget();
			return (((currentTarget != null) ? currentTarget.GetSlashHookCharacterLookAtPoint() : null) ?? global::Vector.ZeroVectorProxy).ToUeVector(false);
		}
		return global::Vector.ZeroVectorDouble;
	}

	// Token: 0x060180C9 RID: 98505 RVA: 0x006BC48C File Offset: 0x006BA68C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool SlashHookPointIsTakeOverCamera(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		if (component != null && component.Valid)
		{
			GrapplingHookPointComponent currentTarget = component.GetCurrentTarget();
			return currentTarget != null && currentTarget.GetLevelPlayTakeOverCamera();
		}
		return false;
	}

	// Token: 0x060180CA RID: 98506 RVA: 0x006BC4C4 File Offset: 0x006BA6C4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble SlashHookPointSafePointLoc(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		FVectorDouble? fvectorDouble;
		if (component == null)
		{
			fvectorDouble = null;
		}
		else
		{
			GrapplingHookPointComponent currentTarget = component.GetCurrentTarget();
			fvectorDouble = ((currentTarget != null) ? new FVectorDouble?(currentTarget.GetSafePointLocation().ToUeVector(false)) : null);
		}
		FVectorDouble? fvectorDouble2 = fvectorDouble;
		if (fvectorDouble2 == null)
		{
			return global::Vector.ZeroVectorDouble;
		}
		return fvectorDouble2.GetValueOrDefault();
	}

	// Token: 0x060180CB RID: 98507 RVA: 0x006BC528 File Offset: 0x006BA728
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FRotator SlashHookPointSafePointRot(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		FRotator? frotator;
		if (component == null)
		{
			frotator = null;
		}
		else
		{
			GrapplingHookPointComponent currentTarget = component.GetCurrentTarget();
			frotator = ((currentTarget != null) ? new FRotator?(currentTarget.GetSafePointRotation().ToUeRotator()) : null);
		}
		FRotator? frotator2 = frotator;
		if (frotator2 == null)
		{
			return global::Rotator.ZeroRotator;
		}
		return frotator2.GetValueOrDefault();
	}

	// Token: 0x060180CC RID: 98508 RVA: 0x006BC58C File Offset: 0x006BA78C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void StartChargeSlash(int entityId)
	{
		GrapplingHookPointComponent component = Singleton<EntitySystem>.Instance.GetComponent<GrapplingHookPointComponent>(entityId);
		if (component != null && component.Valid)
		{
			ControllerBase<ChargeSlashGameplayController>.Instance.StartChargeSlash(component);
		}
	}

	// Token: 0x060180CD RID: 98509 RVA: 0x006BC5BC File Offset: 0x006BA7BC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void StopChargeSlash(int entityId)
	{
		GrapplingHookPointComponent component = Singleton<EntitySystem>.Instance.GetComponent<GrapplingHookPointComponent>(entityId);
		if (component != null && component.Valid)
		{
			ControllerBase<ChargeSlashGameplayController>.Instance.StopChargeSlash(component);
		}
	}

	// Token: 0x060180CE RID: 98510 RVA: 0x006BC5EB File Offset: 0x006BA7EB
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool IsSlashGameplayIsSuccess()
	{
		return ControllerBase<SlashGameplayController>.Instance.CheckGroups();
	}

	// Token: 0x060180CF RID: 98511 RVA: 0x006BC5F7 File Offset: 0x006BA7F7
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static SGravityHookLockInfo GetGravityHookLockInfo(int entityId)
	{
		return ControllerBase<GravityHookController>.Instance.GetGravityHookLockInfo(entityId);
	}

	// Token: 0x060180D0 RID: 98512 RVA: 0x006BC604 File Offset: 0x006BA804
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ChangeGravityByHook(int entityId, int angleRangeMin, int angleRangeMax, float smoothSecondMin, float smoothSecondMax, bool isLerpCamera)
	{
		ControllerBase<GravityHookController>.Instance.ChangeGravity(entityId, (float)angleRangeMin, (float)angleRangeMax, smoothSecondMin, smoothSecondMax, isLerpCamera);
	}

	// Token: 0x060180D1 RID: 98513 RVA: 0x006BC61C File Offset: 0x006BA81C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetIgnoreSocketName(int entityId, string socketName)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.SetIgnoreSocketName(FNameUtil.GetDynamicFName(socketName).Value);
		}
	}

	// Token: 0x060180D2 RID: 98514 RVA: 0x006BC654 File Offset: 0x006BA854
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void DeleteIgnoreSocketName(int entityId, string socketName)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.DeleteIgnoreSocketName(FNameUtil.GetDynamicFName(socketName).Value);
		}
	}

	// Token: 0x060180D3 RID: 98515 RVA: 0x006BC68C File Offset: 0x006BA88C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetToTargetSocketDistance(int entityId)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			return (float)component.GetTargetDistance();
		}
		return -1f;
	}

	// Token: 0x060180D4 RID: 98516 RVA: 0x006BC6C0 File Offset: 0x006BA8C0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetPredictProjectileInfo(int entityId, bool returnValue, ref TArray<FVector> outPathPosition, FVector outLastTraceDestination, FHitResult outHit)
	{
		CharacterThrowComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterThrowComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.SetPredictProjectileInfo(returnValue, ref outPathPosition, outLastTraceDestination, outHit);
	}

	// Token: 0x060180D5 RID: 98517 RVA: 0x006BC6F8 File Offset: 0x006BA8F8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetVisible(int entityId, bool isShow)
	{
		CharacterThrowComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterThrowComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.SetVisible(isShow);
	}

	// Token: 0x060180D6 RID: 98518 RVA: 0x006BC72A File Offset: 0x006BA92A
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static ECharState GetCharUnifiedMoveState(int entityId)
	{
		BaseUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseUnifiedStateComponent>(entityId);
		return (ECharState)((component != null) ? component.MoveState : global::ECharMoveState.Other);
	}

	// Token: 0x060180D7 RID: 98519 RVA: 0x006BC744 File Offset: 0x006BA944
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static ECharParentMoveState GetCharUnifiedPositionState(int entityId)
	{
		BaseUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseUnifiedStateComponent>(entityId);
		return (ECharParentMoveState)((component != null) ? component.PositionState : global::ECharPositionState.Ground);
	}

	// Token: 0x060180D8 RID: 98520 RVA: 0x006BC75E File Offset: 0x006BA95E
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ExitHitState(int entityId)
	{
		CharacterUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterUnifiedStateComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.ExitHitState("");
	}

	// Token: 0x060180D9 RID: 98521 RVA: 0x006BC77A File Offset: 0x006BA97A
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetDirectionState(int entityId, ECharViewDirectionState newViewState)
	{
		BaseUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseUnifiedStateComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetDirectionState((ECharDirectionState)newViewState);
	}

	// Token: 0x060180DA RID: 98522 RVA: 0x006BC792 File Offset: 0x006BA992
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static ECharViewDirectionState GetDirectionState(int entityId)
	{
		BaseUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseUnifiedStateComponent>(entityId);
		return (ECharViewDirectionState)((component != null) ? component.DirectionState : ECharDirectionState.LockDirection);
	}

	// Token: 0x060180DB RID: 98523 RVA: 0x006BC7AC File Offset: 0x006BA9AC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetIsInGame(int entityId)
	{
		BaseUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseUnifiedStateComponent>(entityId);
		return ((component != null) ? component.IsInGame : null).GetValueOrDefault();
	}

	// Token: 0x060180DC RID: 98524 RVA: 0x006BC7E0 File Offset: 0x006BA9E0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SprintPress(int entityId)
	{
		CharacterUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterUnifiedStateComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SprintPress();
	}

	// Token: 0x060180DD RID: 98525 RVA: 0x006BC7F7 File Offset: 0x006BA9F7
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SprintRelease(int entityId)
	{
		CharacterUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterUnifiedStateComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SprintRelease();
	}

	// Token: 0x060180DE RID: 98526 RVA: 0x006BC810 File Offset: 0x006BAA10
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void StandPress(int entityId)
	{
		BaseUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseUnifiedStateComponent>(entityId);
		if (component != null && component.PositionState == global::ECharPositionState.Ground)
		{
			CharacterActorComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
			if (component2 != null && component2.CreatureData.IsRole())
			{
				component.SetMoveState(global::ECharMoveState.Stand);
			}
		}
	}

	// Token: 0x060180DF RID: 98527 RVA: 0x006BC859 File Offset: 0x006BAA59
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SwingPress(int entityId)
	{
		CharacterUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterUnifiedStateComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SwingPress();
	}

	// Token: 0x060180E0 RID: 98528 RVA: 0x006BC870 File Offset: 0x006BAA70
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SwingRelease(int entityId)
	{
		CharacterUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterUnifiedStateComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SwingRelease();
	}

	// Token: 0x060180E1 RID: 98529 RVA: 0x006BC887 File Offset: 0x006BAA87
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void CustomSetWalkOrRun(int entityId, bool isWalk)
	{
		CharacterUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterUnifiedStateComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.CustomSetWalkOrRun(isWalk);
	}

	// Token: 0x060180E2 RID: 98530 RVA: 0x006BC8A0 File Offset: 0x006BAAA0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EnterAimStatus(int entityId, EAimViewState aimViewState)
	{
		CharacterUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterUnifiedStateComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.EnterAimStatus(aimViewState);
	}

	// Token: 0x060180E3 RID: 98531 RVA: 0x006BC8B8 File Offset: 0x006BAAB8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ExitAimStatus(int entityId)
	{
		CharacterUnifiedStateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterUnifiedStateComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.ExitAimStatus();
	}

	// Token: 0x060180E4 RID: 98532 RVA: 0x006BC8CF File Offset: 0x006BAACF
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EnableEntity(int entityId, bool isEnable)
	{
	}

	// Token: 0x060180E5 RID: 98533 RVA: 0x006BC8D4 File Offset: 0x006BAAD4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void UpdateAnimInfoHit(int entityId, BP_ABPLogicParams_C animLogicParams)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		CharacterHitComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component2 == null)
		{
			return;
		}
		AnimLogicParamsSetter animLogicParamsSetter = component.AnimLogicParamsSetter;
		bool flag = component2.GetAcceptedNewBeHitAndReset();
		if (animLogicParamsSetter.AcceptedNewBeHit != flag)
		{
			animLogicParamsSetter.AcceptedNewBeHit = flag;
			animLogicParams.AcceptedNewBeHitRef = flag;
		}
		EHitAnim beHitAnim = component2.BeHitAnim;
		if (animLogicParamsSetter.BeHitAnim != beHitAnim)
		{
			animLogicParamsSetter.BeHitAnim = beHitAnim;
			animLogicParams.BeHitAnimRef = beHitAnim;
		}
		flag = component2.GetEnterFkAndReset();
		if (animLogicParamsSetter.EnterFk != flag)
		{
			animLogicParamsSetter.EnterFk = flag;
			animLogicParams.EnterFkRef = flag;
		}
		flag = component2.GetDoubleHitInAir();
		if (animLogicParamsSetter.DoubleHitInAir != flag)
		{
			animLogicParamsSetter.DoubleHitInAir = flag;
			animLogicParams.DoubleHitInAirRef = flag;
		}
	}

	// Token: 0x060180E6 RID: 98534 RVA: 0x006BC9A8 File Offset: 0x006BABA8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void UpdateAnimInfoFk(int entityId, BP_ABPLogicParams_C animLogicParams)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		CharacterHitComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterHitComponent>(entityId);
		if (component2 == null)
		{
			return;
		}
		AnimLogicParamsSetter animLogicParamsSetter = component.AnimLogicParamsSetter;
		global::Vector vector = component2.BeHitDirect;
		if (!animLogicParamsSetter.BeHitDirect.Equals(vector, 9.999999747378752E-05))
		{
			animLogicParamsSetter.BeHitDirect.DeepCopy(vector);
			animLogicParams.BeHitDirectRef = vector.ToUeVectorOld();
		}
		vector = component2.BeHitLocation;
		if (!animLogicParamsSetter.BeHitLocation.Equals(vector, 9.999999747378752E-05))
		{
			animLogicParamsSetter.BeHitLocation.DeepCopy(vector);
			animLogicParams.BeHitLocationRef = vector.ToUeVectorOld();
		}
	}

	// Token: 0x060180E7 RID: 98535 RVA: 0x006BCA60 File Offset: 0x006BAC60
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void UpdateAnimInfoUnifiedState(int entityId, BP_ABPLogicParams_C animLogicParams)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		BaseUnifiedStateComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<BaseUnifiedStateComponent>(entityId);
		if (component2 == null)
		{
			return;
		}
		AnimLogicParamsSetter animLogicParamsSetter = component.AnimLogicParamsSetter;
		global::ECharMoveState moveState = component2.MoveState;
		if (animLogicParamsSetter.CharMoveState != moveState)
		{
			animLogicParamsSetter.CharMoveState = moveState;
			animLogicParams.CharMoveStateRef = (ECharState)moveState;
		}
		global::ECharPositionState positionState = component2.PositionState;
		if (animLogicParamsSetter.CharPositionState != positionState)
		{
			animLogicParamsSetter.CharPositionState = positionState;
			animLogicParams.CharPositionStateRef = (ECharParentMoveState)positionState;
		}
		ECharDirectionState directionState = component2.DirectionState;
		if (animLogicParamsSetter.CharCameraState != directionState)
		{
			animLogicParamsSetter.CharCameraState = directionState;
			animLogicParams.CharCameraStateRef = (ECharViewDirectionState)directionState;
		}
	}

	// Token: 0x060180E8 RID: 98536 RVA: 0x006BCB1C File Offset: 0x006BAD1C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void UpdateAnimInfoUnifiedStateRoleNpc(int entityId, BP_ABPLogicParams_C animLogicParams)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		BaseUnifiedStateComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<BaseUnifiedStateComponent>(entityId);
		if (component2 == null)
		{
			return;
		}
		AnimLogicParamsSetter animLogicParamsSetter = component.AnimLogicParamsSetter;
		global::ECharMoveState moveState = component2.MoveState;
		if (animLogicParamsSetter.CharMoveState != moveState)
		{
			animLogicParamsSetter.CharMoveState = moveState;
			animLogicParams.CharMoveStateRef = (ECharState)moveState;
		}
	}

	// Token: 0x060180E9 RID: 98537 RVA: 0x006BCB88 File Offset: 0x006BAD88
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool GetIsCharRotateWithCameraWhenManipulate(int entityId)
	{
		CharacterManipulateComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateComponent>(entityId);
		return component != null && component.Valid && component.GetIsCharRotateWithCameraWhenManipulate();
	}

	// Token: 0x060180EA RID: 98538 RVA: 0x006BCBB4 File Offset: 0x006BADB4
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool GetIsUseCatapultUpAnim(int entityId)
	{
		CharacterActionComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActionComponent>(entityId);
		return component != null && component.Valid && component.IsUseCatapultUpAnim;
	}

	// Token: 0x060180EB RID: 98539 RVA: 0x006BCBE0 File Offset: 0x006BADE0
	[UFunction(EFunctionFlags.FUNC_None)]
	public static float GetNextMultiSkillId(int entityId, int skillId)
	{
		CharacterSkillCdComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSkillCdComponent>(entityId);
		if (component != null && component.Valid)
		{
			return (float)component.GetNextMultiSkillId(skillId);
		}
		return 0f;
	}

	// Token: 0x060180EC RID: 98540 RVA: 0x006BCC14 File Offset: 0x006BAE14
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int GetNextMultiSkillIdNew(int entityId, int skillId)
	{
		CharacterSkillCdComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSkillCdComponent>(entityId);
		if (component != null && component.Valid)
		{
			return (int)component.GetNextMultiSkillId(skillId);
		}
		return 0;
	}

	// Token: 0x060180ED RID: 98541 RVA: 0x006BCC44 File Offset: 0x006BAE44
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetManipulateInteractTargetCanInteract(int entityId)
	{
		CharacterManipulateInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateInteractComponent>(entityId);
		return component == null || component.CheckCurrentTargetCanInteract();
	}

	// Token: 0x060180EE RID: 98542 RVA: 0x006BCC68 File Offset: 0x006BAE68
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetHookInteractTargetCanInteract(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		return component == null || component.CheckNextTargetCanInteract();
	}

	// Token: 0x060180EF RID: 98543 RVA: 0x006BCC8C File Offset: 0x006BAE8C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetHookInteractTargetIsIgnorePlayerCollision(int entityId)
	{
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		return component != null && component.GetNextTargetIsIgnorePlayerCollision();
	}

	// Token: 0x060180F0 RID: 98544 RVA: 0x006BCCB0 File Offset: 0x006BAEB0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool StartManipulateInteract(int entityId)
	{
		CharacterManipulateInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateInteractComponent>(entityId);
		return component != null && component.StartPullGiantInteract();
	}

	// Token: 0x060180F1 RID: 98545 RVA: 0x006BCCD4 File Offset: 0x006BAED4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EndManipulateInteract(int entityId)
	{
		CharacterManipulateInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateInteractComponent>(entityId);
		if (component != null)
		{
			component.EndPullGiantInteract();
		}
	}

	// Token: 0x060180F2 RID: 98546 RVA: 0x006BCCF8 File Offset: 0x006BAEF8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool StartStatueInteract(int entityId)
	{
		CharacterManipulateInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateInteractComponent>(entityId);
		return component != null && component.StartStatueInteract();
	}

	// Token: 0x060180F3 RID: 98547 RVA: 0x006BCD1C File Offset: 0x006BAF1C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EndStatueInteract(int entityId)
	{
		CharacterManipulateInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateInteractComponent>(entityId);
		if (component != null)
		{
			component.EndStatueInteract();
		}
	}

	// Token: 0x060180F4 RID: 98548 RVA: 0x006BCD40 File Offset: 0x006BAF40
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool StartCustomInteract(int entityId)
	{
		CharacterManipulateInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateInteractComponent>(entityId);
		return component != null && component.StartCustomInteract();
	}

	// Token: 0x060180F5 RID: 98549 RVA: 0x006BCD64 File Offset: 0x006BAF64
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EndCustomInteract(int entityId)
	{
		CharacterManipulateInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateInteractComponent>(entityId);
		if (component != null)
		{
			component.EndCustomInteract();
		}
	}

	// Token: 0x060180F6 RID: 98550 RVA: 0x006BCD88 File Offset: 0x006BAF88
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void QuantumDiffusionInteract(int entityId)
	{
		CharacterManipulateInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateInteractComponent>(entityId);
		if (component != null)
		{
			component.QuantumDiffusionInteract();
		}
	}

	// Token: 0x060180F7 RID: 98551 RVA: 0x006BCDAC File Offset: 0x006BAFAC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static TArray<AActor> GetShootSwordManipulateInteractActors(int entityId)
	{
		CharacterManipulateInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateInteractComponent>(entityId);
		TArray<AActor> tarray = new TArray<AActor>();
		if (component != null)
		{
			component.GetShootSwordManipulateInteractActors(tarray);
		}
		return tarray;
	}

	// Token: 0x060180F8 RID: 98552 RVA: 0x006BCDD8 File Offset: 0x006BAFD8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble GetManipulateInteractLocation(int entityId)
	{
		CharacterManipulateInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterManipulateInteractComponent>(entityId);
		if (component != null)
		{
			return component.GetTargetLocation().ToUeVector(false);
		}
		return default(FVectorDouble);
	}

	// Token: 0x060180F9 RID: 98553 RVA: 0x006BCE0C File Offset: 0x006BB00C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EnvironmentInfoDetect(int entityId, FVectorDouble location)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component != null)
		{
			ControllerBase<WorldController>.Instance.EnvironmentInfoUpdate(location, component.IsRoleAndCtrlByMe, false);
		}
	}

	// Token: 0x060180FA RID: 98554 RVA: 0x006BCE3C File Offset: 0x006BB03C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void LockOnSpecifyTarget(int entityId, int targetEntityId)
	{
		CharacterLockOnComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterLockOnComponent>(entityId);
		WorldEntity worldEntity = Singleton<EntitySystem>.Instance.Get<WorldEntity>(targetEntityId);
		if (component != null && component.Valid && worldEntity != null && worldEntity.Valid)
		{
			component.LockOnSpecifyTarget(new EntityHandle(worldEntity), "");
		}
	}

	// Token: 0x060180FB RID: 98555 RVA: 0x006BCE88 File Offset: 0x006BB088
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool IsSkillInCd(int entityId, int skillId)
	{
		CharacterSkillCdComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSkillCdComponent>(entityId);
		return component != null && component.Valid && component.IsSkillInCd(skillId, true);
	}

	// Token: 0x060180FC RID: 98556 RVA: 0x006BCEB8 File Offset: 0x006BB0B8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SendHookSkillUseLogData(int entityId, bool hasTarget)
	{
		HookSkillUseLogData hookSkillUseLogData = new HookSkillUseLogData();
		global::Vector actorLocationProxy = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(entityId).ActorLocationProxy;
		hookSkillUseLogData.i_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.AreaId;
		hookSkillUseLogData.i_father_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.Father;
		hookSkillUseLogData.f_pos_x = (float)actorLocationProxy.X;
		hookSkillUseLogData.f_pos_y = (float)actorLocationProxy.Y;
		hookSkillUseLogData.f_pos_z = (float)actorLocationProxy.Z;
		hookSkillUseLogData.i_has_target = ((hasTarget > false) ? 1 : 0);
		ControllerBase<LogReportController>.Instance.UnitLogReport(hookSkillUseLogData);
	}

	// Token: 0x060180FD RID: 98557 RVA: 0x006BCF58 File Offset: 0x006BB158
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SendManipulateSkillUseLogData(int entityId, bool hasTarget)
	{
		ManipulateSkillUseLogData manipulateSkillUseLogData = new ManipulateSkillUseLogData();
		global::Vector actorLocationProxy = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(entityId).ActorLocationProxy;
		manipulateSkillUseLogData.i_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.AreaId;
		manipulateSkillUseLogData.i_father_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.Father;
		manipulateSkillUseLogData.f_pos_x = (float)actorLocationProxy.X;
		manipulateSkillUseLogData.f_pos_y = (float)actorLocationProxy.Y;
		manipulateSkillUseLogData.f_pos_z = (float)actorLocationProxy.Z;
		manipulateSkillUseLogData.i_has_target = ((hasTarget > false) ? 1 : 0);
		ControllerBase<LogReportController>.Instance.UnitLogReport(manipulateSkillUseLogData);
	}

	// Token: 0x060180FE RID: 98558 RVA: 0x006BCFF8 File Offset: 0x006BB1F8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SendScanSkillUseLogData(int entityId, bool hasTarget)
	{
		ScanSkillUseLogData scanSkillUseLogData = new ScanSkillUseLogData();
		global::Vector actorLocationProxy = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId).ActorLocationProxy;
		scanSkillUseLogData.i_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.AreaId;
		scanSkillUseLogData.i_father_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.Father;
		scanSkillUseLogData.f_pos_x = (float)actorLocationProxy.X;
		scanSkillUseLogData.f_pos_y = (float)actorLocationProxy.Y;
		scanSkillUseLogData.f_pos_z = (float)actorLocationProxy.Z;
		scanSkillUseLogData.i_has_target = ((hasTarget > false) ? 1 : 0);
		ControllerBase<LogReportController>.Instance.UnitLogReport(scanSkillUseLogData);
	}

	// Token: 0x060180FF RID: 98559 RVA: 0x006BD098 File Offset: 0x006BB298
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void DynamicAttachEntityToActor(int entityId, int targetEntityId, FName socketName)
	{
		WorldEntity worldEntity = Singleton<EntitySystem>.Instance.Get<WorldEntity>(entityId);
		SceneItemDynamicAttachTargetComponent component = Singleton<EntitySystem>.Instance.GetComponent<SceneItemDynamicAttachTargetComponent>(entityId);
		if (worldEntity == null || component == null)
		{
			return;
		}
		FTransformDouble ftransformDouble = new FTransformDouble();
		WorldEntity worldEntity2 = Singleton<EntitySystem>.Instance.Get<WorldEntity>(targetEntityId);
		AActor aactor;
		if (worldEntity2 == null)
		{
			aactor = null;
		}
		else
		{
			BaseActorComponent component2 = worldEntity2.GetComponent<BaseActorComponent>();
			aactor = ((component2 != null) ? component2.Owner : null);
		}
		AActor aactor2 = aactor;
		if (aactor2 == null)
		{
			return;
		}
		ACharacter acharacter = aactor2 as ACharacter;
		if (acharacter != null)
		{
			if (acharacter.Mesh.DoesSocketExist(socketName))
			{
				ftransformDouble = acharacter.Mesh.D_GetSocketTransform(socketName, ERelativeTransformSpace.RTS_World);
			}
		}
		else
		{
			ftransformDouble = aactor2.D_GetTransform();
		}
		if (worldEntity != null)
		{
			BaseActorComponent component3 = worldEntity.GetComponent<BaseActorComponent>();
			if (component3 != null)
			{
				component3.SetActorLocationAndRotation(ftransformDouble.GetLocation(), ftransformDouble.GetRotation().Rotator(), "unknown", false, null);
			}
		}
		long? num;
		if (worldEntity2 == null)
		{
			num = null;
		}
		else
		{
			CreatureDataComponent component4 = worldEntity2.GetComponent<CreatureDataComponent>();
			num = ((component4 != null) ? new long?(component4.GetCreatureDataId()) : null);
		}
		long? num2 = num;
		if (num2 == null)
		{
			return;
		}
		SceneItemDynamicAttachTargetComponent.AttachParam attachParam = new SceneItemDynamicAttachTargetComponent.AttachParam();
		attachParam.PosAttachType = SceneItemDynamicAttachTargetComponent.EAttachType.CalcUseCurrentRelation;
		attachParam.RotAttachType = SceneItemDynamicAttachTargetComponent.EAttachType.CalcUseCurrentRelation;
		component.RegEntityTargetByCreatureDataId(num2.Value, null, attachParam, "DynamicAttachEntityToActor");
	}

	// Token: 0x06018100 RID: 98560 RVA: 0x006BD1D0 File Offset: 0x006BB3D0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetEntityEnable(int entityId, bool enable, UObject callObject, string reason)
	{
		if (callObject == null || !callObject.IsValid())
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Entity, ELogAuthor.HXY, "调用SetEntityEnable失败，因为callObject为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		string reason2 = "[蓝图:" + callObject.GetName() + "] " + reason;
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity != null && entity.Valid)
		{
			ControllerBase<CreatureController>.Instance.SetEntityEnable(entity, enable, reason2, true);
		}
	}

	// Token: 0x06018101 RID: 98561 RVA: 0x006BD248 File Offset: 0x006BB448
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetActorVisible(int entityId, bool visible, bool collision, bool movable, string reason, bool sync = false)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity != null && entity.Valid)
		{
			ControllerBase<CreatureController>.Instance.SetActorVisible(entity, visible, collision, movable, reason, sync);
		}
	}

	// Token: 0x06018102 RID: 98562 RVA: 0x006BD280 File Offset: 0x006BB480
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetSkillTargetDirection(int entityId, ESkillTargetDirection direction)
	{
		CharacterSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.SetSkillTargetDirection(direction, ESkillTargetPriority.摇杆方向优先);
		}
	}

	// Token: 0x06018103 RID: 98563 RVA: 0x006BD2AC File Offset: 0x006BB4AC
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ChangeAiControllerDebugDraw(int entityId, bool debug)
	{
		CharacterAiComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAiComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.SetDebugDraw(debug);
			return;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.AI;
		ELogAuthor author = ELogAuthor.CWZ;
		string message = "实体不含AiComp";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entityId);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06018104 RID: 98564 RVA: 0x006BD304 File Offset: 0x006BB504
	[UFunction(EFunctionFlags.FUNC_None)]
	public static EHitAnim GetBeHitAnimType(int typeId)
	{
		return (EHitAnim)typeId;
	}

	// Token: 0x06018105 RID: 98565 RVA: 0x006BD308 File Offset: 0x006BB508
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void StartInhalation(int entityId, float strength, float distance, bool isPowerfulMode, float checkAngle, ref TArray<FGameplayTag> tag)
	{
		RoleInhalationComponent component = Singleton<EntitySystem>.Instance.GetComponent<RoleInhalationComponent>(entityId);
		if (component != null && component.Valid)
		{
			List<FGameplayTag> list = new List<FGameplayTag>();
			for (int i = 0; i < tag.Num(); i++)
			{
				list.Add(tag.Get(i));
			}
			component.StartInhalation(strength, distance, isPowerfulMode, checkAngle, list.ToArray());
			component.StartInhalation(strength, distance, isPowerfulMode, checkAngle, list.ToArray());
			component.StartInhalation(strength, distance, isPowerfulMode, checkAngle, list.ToArray());
		}
	}

	// Token: 0x06018106 RID: 98566 RVA: 0x006BD388 File Offset: 0x006BB588
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void StopInhalation(int entityId)
	{
		RoleInhalationComponent component = Singleton<EntitySystem>.Instance.GetComponent<RoleInhalationComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.StopInhalation();
		}
	}

	// Token: 0x06018107 RID: 98567 RVA: 0x006BD3B4 File Offset: 0x006BB5B4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	[return: Nullable(2)]
	public static UKuroDebugMovementComponent TryGetDebugMovementComp(string pbDataId)
	{
		int num = 0;
		try
		{
			num = int.Parse(pbDataId);
		}
		catch
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "添加监听输入的PbDataId转number异常";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataId", pbDataId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		if (num == 0)
		{
			return null;
		}
		List<EntityHandle> list = new List<EntityHandle>();
		ModelBase<CreatureModel>.Instance.GetEntitiesWithPbDataId(num, ref list);
		if (list.Count == 0)
		{
			return null;
		}
		EntityHandle entityHandle = list[0];
		object obj;
		if (entityHandle == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = entityHandle.Entity;
			obj = ((entity != null) ? entity.GetComponent<CreatureDataComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null && obj2.IsVehicle())
		{
			EntityHandle entityHandle2 = list[0];
			object obj3;
			if (entityHandle2 == null)
			{
				obj3 = null;
			}
			else
			{
				WorldEntity entity2 = entityHandle2.Entity;
				if (entity2 == null)
				{
					obj3 = null;
				}
				else
				{
					VehicleActorComponent component = entity2.GetComponent<VehicleActorComponent>();
					obj3 = ((component != null) ? component.DebugMovementComp : null);
				}
			}
			object obj4 = obj3;
			if (obj4 != null)
			{
				obj4.SetDebug(true);
			}
			if (obj4 == null)
			{
				return null;
			}
			return obj4.UeDebugComp;
		}
		else
		{
			EntityHandle entityHandle3 = list[0];
			object obj5;
			if (entityHandle3 == null)
			{
				obj5 = null;
			}
			else
			{
				WorldEntity entity3 = entityHandle3.Entity;
				if (entity3 == null)
				{
					obj5 = null;
				}
				else
				{
					CharacterActorComponent component2 = entity3.GetComponent<CharacterActorComponent>();
					obj5 = ((component2 != null) ? component2.DebugMovementComp : null);
				}
			}
			object obj6 = obj5;
			if (obj6 != null)
			{
				obj6.SetDebug(true);
			}
			if (obj6 == null)
			{
				return null;
			}
			return obj6.UeDebugComp;
		}
		UKuroDebugMovementComponent result;
		return result;
	}

	// Token: 0x06018108 RID: 98568 RVA: 0x006BD4E4 File Offset: 0x006BB6E4
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void TryPlayLinkAnim()
	{
		ControllerBase<BattleLinkController>.Instance.TryPlaySplitScreen();
	}

	// Token: 0x06018109 RID: 98569 RVA: 0x006BD4F0 File Offset: 0x006BB6F0
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FVectorDouble TraceGround(int entityId, FVectorDouble start, FVectorDouble end, bool draw)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
		if (characterActorComponent != null)
		{
			double num = FVectorDouble.Dist(start, end);
			ValueTuple<bool, global::Vector> valueTuple = SkillBehaviorMisc.TraceGroundWithGravity(characterActorComponent, global::Vector.Create(start), draw, (float)num);
			if (valueTuple.Item1 && valueTuple.Item2 != null)
			{
				global::Vector item = valueTuple.Item2;
				return new FVectorDouble(item.X, item.Y, item.Z);
			}
		}
		return default(FVectorDouble);
	}

	// Token: 0x0601810A RID: 98570 RVA: 0x006BD570 File Offset: 0x006BB770
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void ChangePhantomTeam(int phantomFormationId, ref TArray<FGameplayTag> skillTriggerTags)
	{
		List<FGameplayTag> list = new List<FGameplayTag>();
		for (int i = 0; i < skillTriggerTags.Num(); i++)
		{
			list.Add(skillTriggerTags.Get(i));
		}
		ControllerBase<SceneTeamController>.Instance.ChangePhantomTeam(phantomFormationId, list.ToArray());
	}

	// Token: 0x0601810B RID: 98571 RVA: 0x006BD5B4 File Offset: 0x006BB7B4
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void RevertPhantomTeam()
	{
		ControllerBase<SceneTeamController>.Instance.RevertPhantomTeam();
	}

	// Token: 0x0601810C RID: 98572 RVA: 0x006BD5C0 File Offset: 0x006BB7C0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetFormationAttribute(int type)
	{
		FormationAttributeModel instance = ModelBase<FormationAttributeModel>.Instance;
		if (instance == null)
		{
			return 0f;
		}
		return instance.GetValue((EFormationAttributeId)type);
	}

	// Token: 0x0601810D RID: 98573 RVA: 0x006BD5D8 File Offset: 0x006BB7D8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static float GetEntityDeltaMillisecond(int entityId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity != null)
		{
			float num = Singleton<Time>.Instance.DeltaTime * entity.TimeDilation;
			PawnTimeScaleComponent component = entity.GetComponent<PawnTimeScaleComponent>();
			return (float)((int)(num * ((component != null) ? component.CurrentTimeScale : 1f)));
		}
		return 1f;
	}

	// Token: 0x0601810E RID: 98574 RVA: 0x006BD624 File Offset: 0x006BB824
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SyncTwoEntityLocationAndRotation(int fromEntityId, int toEntityId)
	{
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetHandle(fromEntityId) : null;
		CharacterModel instance2 = ModelBase<CharacterModel>.Instance;
		EntityHandle entityHandle2 = (instance2 != null) ? instance2.GetHandle(toEntityId) : null;
		if (entityHandle != null && entityHandle.Valid && entityHandle2 != null && entityHandle2.Valid)
		{
			WorldEntity entity = entityHandle.Entity;
			BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
			WorldEntity entity2 = entityHandle2.Entity;
			BaseActorComponent baseActorComponent2 = (entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null;
			if (baseActorComponent != null && baseActorComponent2 != null)
			{
				baseActorComponent2.SetActorLocationAndRotation(baseActorComponent.ActorLocation, baseActorComponent.ActorRotation, "SyncTwoEntityLocationAndRotation", false, null);
			}
		}
	}

	// Token: 0x0601810F RID: 98575 RVA: 0x006BD6BC File Offset: 0x006BB8BC
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static AActor GetFishingBoat()
	{
		EntityHandle entityHandle = ModelBase<FishingModel>.Instance.GetShipData().GetEntityHandle();
		WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
		if (worldEntity == null || !worldEntity.IsInit)
		{
			return null;
		}
		BaseActorComponent component = worldEntity.GetComponent<BaseActorComponent>();
		if (component == null)
		{
			return null;
		}
		return component.Owner;
	}

	// Token: 0x06018110 RID: 98576 RVA: 0x006BD704 File Offset: 0x006BB904
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void FishingBoatSprint(int entityId, float maxSpeedRatio, int exceedLimitDuration, int duration)
	{
		FishingBoatPerformComponent component = Singleton<EntitySystem>.Instance.GetComponent<FishingBoatPerformComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.FishingBoatEnterSprint(maxSpeedRatio, (float)exceedLimitDuration, (float)duration);
		}
	}

	// Token: 0x06018111 RID: 98577 RVA: 0x006BD733 File Offset: 0x006BB933
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void FishingBoatSkill(EFishingSkillType type)
	{
		ControllerBase<FishingController>.Instance.BeginFishingSkill(type);
	}

	// Token: 0x06018112 RID: 98578 RVA: 0x006BD740 File Offset: 0x006BB940
	[UFunction(EFunctionFlags.FUNC_None)]
	public static EMorphType GetCharacterMorphType(int entityId)
	{
		CharacterMorphComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterMorphComponent>(entityId);
		if (component == null)
		{
			return EMorphType.默认形态;
		}
		return component.GetMorphType();
	}

	// Token: 0x06018113 RID: 98579 RVA: 0x006BD758 File Offset: 0x006BB958
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetCharacterMorphType(int entityId, EMorphType morphType)
	{
		CharacterMorphComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterMorphComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetMorphType(morphType);
	}

	// Token: 0x06018114 RID: 98580 RVA: 0x006BD770 File Offset: 0x006BB970
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetSpecialEnergyAttrValue(int entityId, int attrId, int value)
	{
		AbilityUtils.SetSpecialEnergyAttrValue(entityId, attrId, (float)value);
	}

	// Token: 0x06018115 RID: 98581 RVA: 0x006BD77C File Offset: 0x006BB97C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int GetFuLuoLuoSpecialEnergyType(int entityId, int index)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity != null && entity.Valid)
		{
			return AbilityUtils.GetFuLuoLuoSpecialEnergyType(entity, index);
		}
		return 0;
	}

	// Token: 0x06018116 RID: 98582 RVA: 0x006BD7AC File Offset: 0x006BB9AC
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void StartBattleQte(int entityId, int skillId, int battleQteId)
	{
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
		CharacterSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSkillComponent>(entityId);
		long? num;
		if (component == null)
		{
			num = null;
		}
		else
		{
			Skill skill = component.GetSkill(skillId);
			num = ((skill != null) ? skill.CombatMessageId : null);
		}
		long? num2 = num;
		if (entityById != null && num2 != null)
		{
			ControllerBase<BattleQteController>.Instance.StartBattleQte(battleQteId, num2.Value, entityById, EBattleQteSource.Gameplay);
		}
	}

	// Token: 0x06018117 RID: 98583 RVA: 0x006BD81C File Offset: 0x006BBA1C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void StopGroup1Skill(int entityId, string reason)
	{
		BaseSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.StopGroup1Skill(reason);
		}
	}

	// Token: 0x06018118 RID: 98584 RVA: 0x006BD847 File Offset: 0x006BBA47
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static SCharacterLocationsAndRadius GetCharactersLocationNearBy(FVectorDouble center, float distance, int maxCount)
	{
		return ControllerBase<CreatureController>.Instance.GetCharactersLocationNearBy(center, distance, maxCount);
	}

	// Token: 0x06018119 RID: 98585 RVA: 0x006BD856 File Offset: 0x006BBA56
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static TsBaseCharacter GetCurrentPlayer()
	{
		return Global.BaseCharacter;
	}

	// Token: 0x0601811A RID: 98586 RVA: 0x006BD860 File Offset: 0x006BBA60
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool IsEnemy(TsBaseCharacter owner, TsBaseCharacter other)
	{
		Entity entityNoBlueprint = other.GetEntityNoBlueprint();
		if (owner != null)
		{
			if (entityNoBlueprint != null)
			{
				BaseTagComponent component = entityNoBlueprint.GetComponent<BaseTagComponent>();
				if (((component != null) ? new bool?(component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不被敌方子弹命中"])) : null).GetValueOrDefault())
				{
					return false;
				}
			}
			Entity entityNoBlueprint2 = owner.GetEntityNoBlueprint();
			CreatureDataComponent creatureDataComponent = (entityNoBlueprint2 != null) ? entityNoBlueprint2.GetComponent<CreatureDataComponent>() : null;
			if (creatureDataComponent == null)
			{
				return false;
			}
			CreatureDataComponent creatureDataComponent2 = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CreatureDataComponent>() : null;
			if (creatureDataComponent2 == null)
			{
				return false;
			}
			ECamp selfCamp = (creatureDataComponent.GetEntityType() != EEntityType.Player) ? creatureDataComponent.GetEntityCamp() : ECamp.Player;
			ECamp targetCamp = (creatureDataComponent2.GetEntityType() != EEntityType.Player) ? creatureDataComponent2.GetEntityCamp() : ECamp.Player;
			return ERelation.Enemy * CampUtils.GetCampRelationship(selfCamp, targetCamp) == (ERelation)4;
		}
		return false;
	}

	// Token: 0x0601811B RID: 98587 RVA: 0x006BD914 File Offset: 0x006BBB14
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetWalkOffLedge(int entityId, bool walkOff)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.SetWalkOffLedgeRecord(walkOff);
		}
	}

	// Token: 0x0601811C RID: 98588 RVA: 0x006BD940 File Offset: 0x006BBB40
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void StartFlyingFeather(TsBaseCharacter owner, FVectorDouble initLocation, BP_FlyingFeatherConfig_C config)
	{
		if (owner == null)
		{
			return;
		}
		int entityId = owner.EntityId;
		long? contextId = BulletUtil.GetSkillContextId(owner.GetEntityNoBlueprint(), config.SkillId);
		if (TimerSystem.Instance.Has(TsGameplayBlueprintFunctionLibrary.FlyingFeatherHandle))
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[FlyingFeather] 存在异常的飞雷神羽毛定时器，移除定时器";
			string item = "HandleId";
			TimerHandle flyingFeatherHandle = TsGameplayBlueprintFunctionLibrary.FlyingFeatherHandle;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (flyingFeatherHandle != null) ? new int?(flyingFeatherHandle.Id) : null);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			TimerSystem.Instance.Remove(TsGameplayBlueprintFunctionLibrary.FlyingFeatherHandle);
			TsGameplayBlueprintFunctionLibrary.FlyingFeatherHandle = null;
		}
		if (config.BulletDelayTime > 20 && config.BulletDelayTime < 180000)
		{
			TsGameplayBlueprintFunctionLibrary.FlyingFeatherHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				TsGameplayBlueprintFunctionLibrary.FlyingFeatherHandle = null;
				TsGameplayBlueprintFunctionLibrary.EmitFeatherBullet(owner, initLocation, config, entityId, contextId);
			}, (float)config.BulletDelayTime, null, null, true, 1f);
			return;
		}
		TsGameplayBlueprintFunctionLibrary.EmitFeatherBullet(owner, initLocation, config, entityId, contextId);
	}

	// Token: 0x0601811D RID: 98589 RVA: 0x006BDA88 File Offset: 0x006BBC88
	[NullableContext(1)]
	private static void EmitFeatherBullet(TsBaseCharacter owner, FVectorDouble initLocation, BP_FlyingFeatherConfig_C config, int entityId, long? contextId)
	{
		TsGameplayBlueprintFunctionLibrary.<>c__DisplayClass289_0 CS$<>8__locals1 = new TsGameplayBlueprintFunctionLibrary.<>c__DisplayClass289_0();
		CS$<>8__locals1.entityId = entityId;
		CS$<>8__locals1.owner = owner;
		if (CS$<>8__locals1.owner != null)
		{
			CharacterActorComponent characterActorComponent = CS$<>8__locals1.owner.CharacterActorComponent;
			if (characterActorComponent != null && characterActorComponent.Entity.Valid)
			{
				Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(CS$<>8__locals1.entityId, config.FeatherTarget);
				if (vectorValueByEntity != null)
				{
					Singleton<MathUtils>.Instance.CommonTempVector.Set((double)vectorValueByEntity.X, (double)vectorValueByEntity.Y, (double)vectorValueByEntity.Z);
				}
				else
				{
					Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(initLocation);
				}
				BulletController.BulletCreateParams bulletCreateParams = new BulletController.BulletCreateParams
				{
					SkillId = config.SkillId,
					SkillContextId = contextId,
					InitTargetLocation = new FVectorDouble?(Singleton<MathUtils>.Instance.CommonTempVector.ToUeVector(false))
				};
				BulletEntity bulletEntity = ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(CS$<>8__locals1.owner, config.BulletId, new FTransformDouble?(CS$<>8__locals1.owner.D_GetTransform()), bulletCreateParams, contextId, global::EBulletCreateSource.Others);
				CS$<>8__locals1.bulletId = ((bulletEntity != null) ? new int?(bulletEntity.GetBulletInfo().BulletEntityId) : null);
				TsGameplayBlueprintFunctionLibrary.FlyingFeatherHandle = TimerSystem.Instance.Delay(delegate(float _)
				{
					TsGameplayBlueprintFunctionLibrary.FlyingFeatherHandle = null;
					TsGameplayBlueprintFunctionLibrary.ChangeFlyingFeatherMove(new int?(CS$<>8__locals1.entityId));
					CharacterActorComponent characterActorComponent2 = CS$<>8__locals1.owner.CharacterActorComponent;
					Entity entity = (characterActorComponent2 != null) ? characterActorComponent2.Entity : null;
					if (entity != null && Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.BulletDestroy, new Action<BulletInfo>(base.<EmitFeatherBullet>g__bulletDestroy|0)))
					{
						Singleton<EventSystem>.Instance.RemoveWithTarget(entity, EEventName.BulletDestroy, new Action<BulletInfo>(base.<EmitFeatherBullet>g__bulletDestroy|0));
					}
				}, (float)Singleton<MathUtils>.Instance.Clamp(config.MaxChangeStateTime, 20, 180000), null, null, true, 1f);
				Singleton<EventSystem>.Instance.AddWithTarget(CS$<>8__locals1.owner.CharacterActorComponent.Entity, EEventName.BulletDestroy, new Action<BulletInfo>(CS$<>8__locals1.<EmitFeatherBullet>g__bulletDestroy|0));
				return;
			}
		}
	}

	// Token: 0x0601811E RID: 98590 RVA: 0x006BDC10 File Offset: 0x006BBE10
	private static void ChangeFlyingFeatherMove(int? entityId)
	{
		if (entityId == null)
		{
			return;
		}
		BaseTagComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseTagComponent>(entityId.Value);
		BaseSceneInteractComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId.Value);
		if (component == null || (component2 == null || !component2.GetIsHooking()))
		{
			return;
		}
		if (!component.HasTag(GameplayTagDefine.EGameplayTagId["角色.FP_R2T1CalbrenaMd10011.技能.飞雷神移动中"]))
		{
			component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.FP_R2T1CalbrenaMd10011.技能.飞雷神移动中"]));
		}
	}

	// Token: 0x0601811F RID: 98591 RVA: 0x006BDC94 File Offset: 0x006BBE94
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	[return: Nullable(2)]
	public static string GetFlyingFeatherTargetId(TsBaseCharacter owner)
	{
		if (owner == null)
		{
			return null;
		}
		int entityId = owner.EntityId;
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		int? num;
		if (component == null)
		{
			num = null;
		}
		else
		{
			GrapplingHookPointComponent currentTarget = component.GetCurrentTarget();
			num = ((currentTarget != null) ? new int?(currentTarget.GetHookBindEntityConfig()) : null);
		}
		int? num2 = num;
		if (component == null || num2 == null)
		{
			return null;
		}
		CreatureModel instance = ModelBase<CreatureModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetEntityByPbDataId(num2.Value) : null;
		if (entityHandle == null)
		{
			return null;
		}
		return entityHandle.Id.ToString();
	}

	// Token: 0x06018120 RID: 98592 RVA: 0x006BDD20 File Offset: 0x006BBF20
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	[return: Nullable(2)]
	public static AActor AddFlyingFeatherTargetTag(FGameplayTag tag, string entityId)
	{
		CreatureModel instance = ModelBase<CreatureModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetEntityById(int.Parse(entityId)) : null;
		if (entityHandle == null)
		{
			return null;
		}
		WorldEntity entity = entityHandle.Entity;
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		if ((baseTagComponent == null || !baseTagComponent.HasTag(tag.TagId())) && baseTagComponent != null)
		{
			baseTagComponent.AddTag(new int?(tag.TagId()));
		}
		WorldEntity entity2 = entityHandle.Entity;
		BaseActorComponent baseActorComponent = (entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null;
		if (baseActorComponent == null)
		{
			return null;
		}
		return baseActorComponent.Owner;
	}

	// Token: 0x06018121 RID: 98593 RVA: 0x006BDDA8 File Offset: 0x006BBFA8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FVectorDouble UpdateFlyingFeather(TsBaseCharacter owner, string target)
	{
		if (owner == null)
		{
			return default(FVectorDouble);
		}
		int entityId = owner.EntityId;
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		AActor aactor = (component != null) ? component.GetCurrentTargetActor() : null;
		if (component == null || aactor == null)
		{
			return default(FVectorDouble);
		}
		global::Vector actorLocationProxy = owner.CharacterActorComponent.ActorLocationProxy;
		FVectorDouble fvectorDouble = aactor.D_K2_GetActorLocation();
		ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(entityId, target, (double)((float)fvectorDouble.X), (double)((float)fvectorDouble.Y), (double)((float)fvectorDouble.Z));
		string flyingFeatherTargetId = TsGameplayBlueprintFunctionLibrary.GetFlyingFeatherTargetId(owner);
		if (flyingFeatherTargetId != null)
		{
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			EntityHandle entityHandle = (instance != null) ? instance.GetEntityById(int.Parse(flyingFeatherTargetId)) : null;
			BaseActorComponent baseActorComponent;
			if (entityHandle == null)
			{
				baseActorComponent = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				baseActorComponent = ((entity != null) ? entity.GetComponent<BaseActorComponent>() : null);
			}
			BaseActorComponent baseActorComponent2 = baseActorComponent;
			if (baseActorComponent2 != null)
			{
				Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(baseActorComponent2.ActorLocationProxy);
				Singleton<MathUtils>.Instance.CommonTempVector.SubtractionEqual(actorLocationProxy);
				double num = Singleton<MathUtils>.Instance.CommonTempVector.Size();
				Singleton<MathUtils>.Instance.CommonTempVector.Normalize(9.99999993922529E-09);
				Singleton<MathUtils>.Instance.CommonTempVector.MultiplyEqual(Math.Max(0.0, num - (double)baseActorComponent2.GetRadius()));
				Singleton<MathUtils>.Instance.CommonTempVector.AdditionEqual(actorLocationProxy);
				return Singleton<MathUtils>.Instance.CommonTempVector.ToUeVector(false);
			}
		}
		return fvectorDouble;
	}

	// Token: 0x06018122 RID: 98594 RVA: 0x006BDF0F File Offset: 0x006BC10F
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void EmitGlobalClientEvent(FGameplayTag eventNameTag)
	{
		Singleton<EventSystem>.Instance.Emit<FGameplayTag>(EEventName.CheckClientEvent, eventNameTag);
	}

	// Token: 0x06018123 RID: 98595 RVA: 0x006BDF24 File Offset: 0x006BC124
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int GetDriverEntityId(int vehicleEntityId)
	{
		BaseVehiclePerformComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseVehiclePerformComponent>(vehicleEntityId);
		Entity entity = (component != null) ? component.Driver : null;
		if (entity == null)
		{
			return 0;
		}
		return entity.Id;
	}

	// Token: 0x06018124 RID: 98596 RVA: 0x006BDF54 File Offset: 0x006BC154
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void StartCableWayMove(int id, UKuroBooleanEventBinder eventBinder)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(entity);
		if (handleByEntity == null || !handleByEntity.Valid)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.CH;
			string message = "开始索道移动失败，实体无效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		int? num = (baseCharacter != null) ? new int?(baseCharacter.GetEntityIdNoBlueprint()) : null;
		if (num == null || id != num.Value)
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.CH;
			string message2 = "开始索道移动失败，实体为非主控角色";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("id", id);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(id);
		GrapplingHookPointComponent grapplingHookPointComponent = (component != null) ? component.GetCurrentTarget() : null;
		if (grapplingHookPointComponent == null || grapplingHookPointComponent.GetHookInteractType().GetValueOrDefault() != EHookInteractType.CableWay)
		{
			global::Log instance3 = Singleton<global::Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.CH;
			string message3 = "开始索道移动失败，当前目标不是索道";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("id", id);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return;
		}
		int splineEntityId = (grapplingHookPointComponent.GetHookInteractConfig() as ICableWay).SplineEntityId;
		if (ControllerBase<SplineMoveTaskController>.Instance.GetEntityCurSplineMoveTask((long)id) != null)
		{
			global::Log instance4 = Singleton<global::Log>.Instance;
			ELogModule module4 = ELogModule.Entity;
			ELogAuthor author4 = ELogAuthor.CH;
			string message4 = "开始索道移动时，角色还有样条任务未结束，清理旧任务";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("id", id);
			instance4.Warn(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			ControllerBase<SplineMoveTaskController>.Instance.EndEntityTasks((long)id);
		}
		Entity entity4 = entity;
		if (entity4 != null)
		{
			BaseTagComponent component2 = entity4.GetComponent<BaseTagComponent>();
			if (component2 != null)
			{
				component2.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.关卡运动.关卡运动类型.滑轨UI.隐藏跳跃按键"]));
			}
		}
		Entity entity2 = entity;
		CharacterRailSlideComponent characterRailSlideComponent = (entity2 != null) ? entity2.GetComponent<CharacterRailSlideComponent>() : null;
		if (characterRailSlideComponent == null)
		{
			return;
		}
		characterRailSlideComponent.StartRailSlide(splineEntityId, "/Game/Aki/Data/Level/RailSlide/DA_Strop.DA_Strop", delegate(bool isInterrupt)
		{
			global::Log instance5 = Singleton<global::Log>.Instance;
			ELogModule module5 = ELogModule.Entity;
			ELogAuthor author5 = ELogAuthor.CH;
			string message5 = "索道移动结束";
			ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("id", id);
			instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
			Entity entity3 = entity;
			if (entity3 != null)
			{
				BaseTagComponent component3 = entity3.GetComponent<BaseTagComponent>();
				if (component3 != null)
				{
					component3.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.关卡运动.关卡运动类型.滑轨UI.隐藏跳跃按键"]));
				}
			}
			eventBinder.Callback.Broadcast(isInterrupt);
		});
	}

	// Token: 0x06018125 RID: 98597 RVA: 0x006BE174 File Offset: 0x006BC374
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void StopCableWayMove(int id)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(entity);
		if (handleByEntity == null || !handleByEntity.Valid)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.CH;
			string message = "结束索道移动失败，实体无效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		int? num = (baseCharacter != null) ? new int?(baseCharacter.GetEntityIdNoBlueprint()) : null;
		if (num == null || id != num.Value)
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.CH;
			string message2 = "结束索道移动失败，实体为非主控角色";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("id", id);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		CharacterRailSlideComponent characterRailSlideComponent = (entity != null) ? entity.GetComponent<CharacterRailSlideComponent>() : null;
		if (characterRailSlideComponent == null)
		{
			return;
		}
		characterRailSlideComponent.SetExitSplineRailSlide("GA主动停止", true);
	}

	// Token: 0x06018126 RID: 98598 RVA: 0x006BE254 File Offset: 0x006BC454
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static int GetBuffInstigatorId(int entityId, int buffId, bool getInstigatorSummoner)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		ActiveBuffInternal activeBuffInternal = (baseBuffComponent != null) ? baseBuffComponent.GetBuffById((long)buffId) : null;
		Entity entity2 = (activeBuffInternal != null) ? activeBuffInternal.GetInstigator() : null;
		if (entity2 == null)
		{
			return -1;
		}
		if (!getInstigatorSummoner)
		{
			return entity2.Id;
		}
		CreatureDataComponent component = entity2.GetComponent<CreatureDataComponent>();
		long? num = (component != null) ? new long?(component.GetSummonerId()) : null;
		if (num != null)
		{
			EntityHandle entity3 = ModelBase<CreatureModel>.Instance.GetEntity(num.Value);
			WorldEntity worldEntity = (entity3 != null) ? entity3.Entity : null;
			if (worldEntity != null)
			{
				return worldEntity.Id;
			}
		}
		return entity2.Id;
	}

	// Token: 0x06018127 RID: 98599 RVA: 0x006BE2FC File Offset: 0x006BC4FC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetSubMeshOrder(int entityId, string meshName, bool visible, [Nullable(2)] PD_CharacterControllerData_C charControllerData, [Nullable(new byte[]
	{
		2,
		1
	})] TSoftObjectPtr<UEffectModelBase> effectDataAssetRef, float delayTime)
	{
		SubMeshComponent component = Singleton<EntitySystem>.Instance.GetComponent<SubMeshComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.SetSubMeshOrder(meshName, visible, charControllerData, effectDataAssetRef, delayTime * 1000f);
		}
	}

	// Token: 0x06018128 RID: 98600 RVA: 0x006BE333 File Offset: 0x006BC533
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetPilotThrowSpeed()
	{
		return ModelBase<PilotThrowModel>.Instance.LaunchSpeed;
	}

	// Token: 0x06018129 RID: 98601 RVA: 0x006BE33F File Offset: 0x006BC53F
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble GetPilotThrowDirection()
	{
		return ModelBase<PilotThrowModel>.Instance.LaunchDirection.ToUeVector(false);
	}

	// Token: 0x0601812A RID: 98602 RVA: 0x006BE351 File Offset: 0x006BC551
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetPilotThrowGravity()
	{
		return ModelBase<PilotThrowModel>.Instance.LaunchGravity;
	}

	// Token: 0x0601812B RID: 98603 RVA: 0x006BE35D File Offset: 0x006BC55D
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetPilotThrowNeedMotorRide()
	{
		return ModelBase<PilotThrowModel>.Instance.NeedMotorRide;
	}

	// Token: 0x0601812C RID: 98604 RVA: 0x006BE369 File Offset: 0x006BC569
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetPilotThrowIsDisableInterrupt()
	{
		return ModelBase<PilotThrowModel>.Instance.DisableInterrupt;
	}

	// Token: 0x0601812D RID: 98605 RVA: 0x006BE378 File Offset: 0x006BC578
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void OpenPilotThrowGameplayCamera(int targetEntityId)
	{
		GrapplingHookPointComponent component = Singleton<EntitySystem>.Instance.GetComponent<GrapplingHookPointComponent>(targetEntityId);
		if (component == null || !component.Valid)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelPlay;
			ELogAuthor author = ELogAuthor.CK;
			string message = "[TsExploreComponentBlueprintFunctionLibrary]开启铁驭玩法相机失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TargetEntityId", targetEntityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		IHookInteractType hookInteractType = (component != null) ? component.GetHookInteractConfig() : null;
		if (hookInteractType == null || hookInteractType.Type != EHookInteractType.PilotThrow)
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.CH;
			string message2 = "开启铁驭玩法相机失败, 当前探索组件正在交互的目标交互类型不合法";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EHookInteractType", (hookInteractType != null) ? new EHookInteractType?(hookInteractType.Type) : null);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		IPilotThrow pilotThrow = hookInteractType as IPilotThrow;
		if (pilotThrow == null)
		{
			global::Log instance3 = Singleton<global::Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.CH;
			string message3 = "开启铁驭玩法相机失败, PilotThrow配置无效";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("TargetEntityId", targetEntityId);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return;
		}
		ControllerBase<PilotThrowController>.Instance.EnterInteractHookPoint(component.EntityConfigId, pilotThrow.TitanEntityId, pilotThrow.TargetList);
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.EnterSpecialGameplayCamera(1);
	}

	// Token: 0x0601812E RID: 98606 RVA: 0x006BE4A8 File Offset: 0x006BC6A8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static USkeletalMeshComponent GetCurrentTargetPilotSkeletalMeshComponent(int entityId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(entity);
		if (handleByEntity == null || !handleByEntity.Valid)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.CH;
			string message = "获取当前钩锁目标铁驭Actor失败，实体无效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", entityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		BaseSceneInteractComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		GrapplingHookPointComponent grapplingHookPointComponent = (component != null) ? component.GetCurrentTarget() : null;
		if (grapplingHookPointComponent == null || grapplingHookPointComponent.GetHookInteractType().GetValueOrDefault() != EHookInteractType.PilotThrow)
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.CH;
			string message2 = "获取当前钩锁目标铁驭Actor失败，当前目标不是铁驭钩锁";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("id", entityId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		IPilotThrow pilotThrow = grapplingHookPointComponent.GetHookInteractConfig() as IPilotThrow;
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId((pilotThrow != null) ? pilotThrow.TitanEntityId : 0);
		WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
		if (worldEntity == null || !worldEntity.Valid)
		{
			global::Log instance3 = Singleton<global::Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.CH;
			string message3 = "获取当前钩锁目标铁驭Actor失败，当前目标不是铁驭";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("id", entityId);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return null;
		}
		BaseActorComponent component2 = worldEntity.GetComponent<BaseActorComponent>();
		AActor aactor = (component2 != null) ? component2.Owner : null;
		if (aactor == null || !aactor.IsValid())
		{
			global::Log instance4 = Singleton<global::Log>.Instance;
			ELogModule module4 = ELogModule.Entity;
			ELogAuthor author4 = ELogAuthor.CH;
			string message4 = "获取当前钩锁目标铁驭Actor失败，铁驭Actor无效";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("id", entityId);
			instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			return null;
		}
		return ULGUIBPLibrary.GetComponentInChildren(aactor, USkeletalMeshComponent.StaticClass(), false) as USkeletalMeshComponent;
	}

	// Token: 0x0601812F RID: 98607 RVA: 0x006BE635 File Offset: 0x006BC835
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FVectorDouble GetPilotCurrentInRangePoint()
	{
		global::Vector currentInRangePoint = ModelBase<PilotThrowModel>.Instance.CurrentInRangePoint;
		if (currentInRangePoint == null)
		{
			return global::Vector.ZeroVectorDouble;
		}
		return currentInRangePoint.ToUeVector(false);
	}

	// Token: 0x06018130 RID: 98608 RVA: 0x006BE654 File Offset: 0x006BC854
	[UFunction(EFunctionFlags.FUNC_None)]
	public static float GetVehicleCatapultUnitRisingTime(int entityId)
	{
		VehicleCatapultComponent component = Singleton<EntitySystem>.Instance.GetComponent<VehicleCatapultComponent>(entityId);
		BigJumpUnit bigJumpUnit = (component != null) ? component.GetCatapultUnit() : null;
		if (bigJumpUnit == null)
		{
			return 0f;
		}
		return bigJumpUnit.RisingTime;
	}

	// Token: 0x06018131 RID: 98609 RVA: 0x006BE688 File Offset: 0x006BC888
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void GuessJokerNpcTurnToIdlePerform()
	{
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		if (instance == null || !instance.InGame)
		{
			return;
		}
		ModelBase<GuessJokerGamePlayModel>.Instance.PushPlotActions(new GuessJokerPlotAction[]
		{
			new GuessJokerPlotAction(EGuessJokerPlayerType.Ai, EGuessJokerPlotTiming.AiIdlePerformance, null)
		});
	}

	// Token: 0x06018132 RID: 98610 RVA: 0x006BE6CF File Offset: 0x006BC8CF
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void LevelFlowDeadlySkeletonMeshCastToCharacter()
	{
		ModelBase<LevelFlowModel>.Instance.ResetLevelFlow(false);
	}

	// Token: 0x06018133 RID: 98611 RVA: 0x006BE6DC File Offset: 0x006BC8DC
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void LevelFlowAddBuff(int entityId, int buffId)
	{
		ModelBase<LevelFlowModel>.Instance.PushDynamicAction(new LevelFlowAddBuffAction().Init(entityId, new List<long>
		{
			(long)buffId
		}));
	}

	// Token: 0x06018134 RID: 98612 RVA: 0x006BE700 File Offset: 0x006BC900
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void LevelFlowRemoveBuff(int entityId, int buffId)
	{
		ModelBase<LevelFlowModel>.Instance.PushDynamicAction(new LevelFlowRemoveBuffAction().Init(entityId, new List<long>
		{
			(long)buffId
		}));
	}

	// Token: 0x06018135 RID: 98613 RVA: 0x006BE724 File Offset: 0x006BC924
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void LevelFlowCameraShake(string cameraShakeBp)
	{
		ModelBase<LevelFlowModel>.Instance.PushDynamicAction(new LevelFlowCameraShake().Init(new TriggerCameraShake
		{
			CameraShakeConfig = new ICameraShakeConfig
			{
				Type = ECameraShakeType.Constant
			},
			CameraShakeBp = cameraShakeBp
		}));
	}

	// Token: 0x06018136 RID: 98614 RVA: 0x006BE758 File Offset: 0x006BC958
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void LevelFlowPlayLevelSequence(string path, string mark)
	{
		ModelBase<LevelFlowModel>.Instance.PushDynamicAction(new LevelFlowPlayLevelSequence().Init(new PlayLevelSequence
		{
			LevelSequencePath = path,
			Mark = mark,
			IsEnableCenterOffset = new bool?(true),
			PlayMode = new TPlayMode?(TPlayMode.direct),
			KeepUI = new bool?(true)
		}));
	}

	// Token: 0x06018137 RID: 98615 RVA: 0x006BE7B0 File Offset: 0x006BC9B0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int XigelikaAddBean(int entityId, string bean)
	{
		CharacterSpecialSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSpecialSkillComponent>(entityId);
		if (component == null || !component.Valid || component.SpecialSkill == null)
		{
			return 0;
		}
		SpecialSkillXigelika specialSkillXigelika = component.SpecialSkill as SpecialSkillXigelika;
		if (specialSkillXigelika != null)
		{
			return specialSkillXigelika.AddBean(bean);
		}
		return 0;
	}

	// Token: 0x06018138 RID: 98616 RVA: 0x006BE7FC File Offset: 0x006BC9FC
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int XigelikaGetBeanResultant(int entityId)
	{
		CharacterSpecialSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSpecialSkillComponent>(entityId);
		if (component == null || !component.Valid || component.SpecialSkill == null)
		{
			return 0;
		}
		SpecialSkillXigelika specialSkillXigelika = component.SpecialSkill as SpecialSkillXigelika;
		if (specialSkillXigelika == null)
		{
			return 0;
		}
		return specialSkillXigelika.GetBeanResultant();
	}

	// Token: 0x06018139 RID: 98617 RVA: 0x006BE848 File Offset: 0x006BCA48
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void XigelikaConsumeBean(int entityId)
	{
		CharacterSpecialSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSpecialSkillComponent>(entityId);
		if (component == null || !component.Valid || component.SpecialSkill == null)
		{
			return;
		}
		SpecialSkillXigelika specialSkillXigelika = component.SpecialSkill as SpecialSkillXigelika;
		if (specialSkillXigelika != null)
		{
			specialSkillXigelika.ConsumeBean();
		}
	}

	// Token: 0x0601813A RID: 98618 RVA: 0x006BE890 File Offset: 0x006BCA90
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void XigelikaResetBean(int entityId)
	{
		CharacterSpecialSkillComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSpecialSkillComponent>(entityId);
		if (component == null || !component.Valid || component.SpecialSkill == null)
		{
			return;
		}
		SpecialSkillXigelika specialSkillXigelika = component.SpecialSkill as SpecialSkillXigelika;
		if (specialSkillXigelika != null)
		{
			specialSkillXigelika.ResetBean();
		}
	}

	// Token: 0x0601813B RID: 98619 RVA: 0x006BE8D8 File Offset: 0x006BCAD8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void OpenQuickHack(int deviceId, int ownerEntityId, bool closeWhenInteractFinish, FGameplayTag interactFinishGameplayEventTag)
	{
		ControllerBase<QuickHackController>.Instance.OpenQuickHack(deviceId, ownerEntityId, closeWhenInteractFinish, new FGameplayTag?(interactFinishGameplayEventTag), null);
	}

	// Token: 0x0601813C RID: 98620 RVA: 0x006BE8EE File Offset: 0x006BCAEE
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void CloseQuickHack()
	{
		ControllerBase<QuickHackController>.Instance.CloseQuickHack();
	}

	// Token: 0x0601813D RID: 98621 RVA: 0x006BE8FA File Offset: 0x006BCAFA
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool FunctionOpen(int functionType)
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(functionType);
	}

	// Token: 0x0601813E RID: 98622 RVA: 0x006BE907 File Offset: 0x006BCB07
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x0601813F RID: 98623 RVA: 0x006BE909 File Offset: 0x006BCB09
	public static void ResetStaticDefaultValue()
	{
		TsGameplayBlueprintFunctionLibrary.FlyingFeatherHandle = null;
	}

	// Token: 0x06018140 RID: 98624 RVA: 0x006BE911 File Offset: 0x006BCB11
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsGameplayBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsGameplayBlueprintFunctionLibrary.TsGameplayBlueprintFunctionLibrary_C");
		}
		return TsGameplayBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x06018141 RID: 98625 RVA: 0x006BE938 File Offset: 0x006BCB38
	public TsGameplayBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(TsGameplayBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06018142 RID: 98626 RVA: 0x006BE960 File Offset: 0x006BCB60
	[NullableContext(1)]
	public TsGameplayBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsGameplayBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06018143 RID: 98627 RVA: 0x006BE993 File Offset: 0x006BCB93
	protected TsGameplayBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06018144 RID: 98628 RVA: 0x006BE99C File Offset: 0x006BCB9C
	protected unsafe static void __CPPCALL_ContainsTag_Implementation(TsGameplayBlueprintFunctionLibrary.__ContainsTag_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.ContainsTag(__Params->entityId, __Params->tag);
	}

	// Token: 0x06018145 RID: 98629 RVA: 0x006BE9B5 File Offset: 0x006BCBB5
	protected unsafe static void __CPPCALL_AddTag_Implementation(TsGameplayBlueprintFunctionLibrary.__AddTag_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.AddTag(__Params->entityId, __Params->tag);
	}

	// Token: 0x06018146 RID: 98630 RVA: 0x006BE9C8 File Offset: 0x006BCBC8
	protected unsafe static void __CPPCALL_AddTagWithDuration_Implementation(TsGameplayBlueprintFunctionLibrary.__AddTagWithDuration_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.AddTagWithDuration(__Params->entityId, __Params->duration, __Params->tag);
	}

	// Token: 0x06018147 RID: 98631 RVA: 0x006BE9E4 File Offset: 0x006BCBE4
	protected unsafe static void __CPPCALL_AddTagByName_Implementation(TsGameplayBlueprintFunctionLibrary.__AddTagByName_FunctionParams* __Params)
	{
		string tagName = FString.ToString((void*)(&__Params->tagName));
		TsGameplayBlueprintFunctionLibrary.AddTagByName(__Params->entityId, tagName);
	}

	// Token: 0x06018148 RID: 98632 RVA: 0x006BEA0A File Offset: 0x006BCC0A
	protected unsafe static void __CPPCALL_RemoveTag_Implementation(TsGameplayBlueprintFunctionLibrary.__RemoveTag_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.RemoveTag(__Params->entityId, __Params->tag);
	}

	// Token: 0x06018149 RID: 98633 RVA: 0x006BEA20 File Offset: 0x006BCC20
	protected unsafe static void __CPPCALL_RemoveTagByName_Implementation(TsGameplayBlueprintFunctionLibrary.__RemoveTagByName_FunctionParams* __Params)
	{
		string tagName = FString.ToString((void*)(&__Params->tagName));
		TsGameplayBlueprintFunctionLibrary.RemoveTagByName(__Params->entityId, tagName);
	}

	// Token: 0x0601814A RID: 98634 RVA: 0x006BEA46 File Offset: 0x006BCC46
	protected unsafe static void __CPPCALL_AddCue_Implementation(TsGameplayBlueprintFunctionLibrary.__AddCue_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.AddCue(__Params->instigatorEntityId, __Params->targetEntityId, __Params->cueId);
	}

	// Token: 0x0601814B RID: 98635 RVA: 0x006BEA5F File Offset: 0x006BCC5F
	protected unsafe static void __CPPCALL_RemoveCue_Implementation(TsGameplayBlueprintFunctionLibrary.__RemoveCue_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.RemoveCue(__Params->entityId, __Params->cueId);
	}

	// Token: 0x0601814C RID: 98636 RVA: 0x006BEA72 File Offset: 0x006BCC72
	protected unsafe static void __CPPCALL_SetGameplayCueEffectForceRecycle_Implementation(TsGameplayBlueprintFunctionLibrary.__SetGameplayCueEffectForceRecycle_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetGameplayCueEffectForceRecycle(__Params->entityId, __Params->cueId);
	}

	// Token: 0x0601814D RID: 98637 RVA: 0x006BEA85 File Offset: 0x006BCC85
	protected unsafe static void __CPPCALL_IsLogicAutonomousProxy_Implementation(TsGameplayBlueprintFunctionLibrary.__IsLogicAutonomousProxy_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.IsLogicAutonomousProxy(__Params->entityId);
	}

	// Token: 0x0601814E RID: 98638 RVA: 0x006BEA98 File Offset: 0x006BCC98
	protected unsafe static void __CPPCALL_RemoveActiveGameplayEffect_Implementation(TsGameplayBlueprintFunctionLibrary.__RemoveActiveGameplayEffect_FunctionParams* __Params)
	{
		FActiveGameplayEffectHandle handle = new FActiveGameplayEffectHandle(&__Params->handle, true, true);
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.RemoveActiveGameplayEffect(__Params->entityId, handle, __Params->stacksToRemove);
	}

	// Token: 0x0601814F RID: 98639 RVA: 0x006BEACC File Offset: 0x006BCCCC
	protected unsafe static void __CPPCALL_RemoveBuffByTag_Implementation(TsGameplayBlueprintFunctionLibrary.__RemoveBuffByTag_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.RemoveBuffByTag(__Params->entityId, __Params->tag);
	}

	// Token: 0x06018150 RID: 98640 RVA: 0x006BEADF File Offset: 0x006BCCDF
	protected unsafe static void __CPPCALL_AddPassiveSkill_Implementation(TsGameplayBlueprintFunctionLibrary.__AddPassiveSkill_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.AddPassiveSkill(__Params->entityId, __Params->passiveSkillId);
	}

	// Token: 0x06018151 RID: 98641 RVA: 0x006BEAF2 File Offset: 0x006BCCF2
	protected unsafe static void __CPPCALL_RemovePassiveSkill_Implementation(TsGameplayBlueprintFunctionLibrary.__RemovePassiveSkill_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.RemovePassiveSkill(__Params->entityId, __Params->passiveSkillId);
	}

	// Token: 0x06018152 RID: 98642 RVA: 0x006BEB08 File Offset: 0x006BCD08
	protected unsafe static void __CPPCALL_SetPassiveGaSkillId_Implementation(TsGameplayBlueprintFunctionLibrary.__SetPassiveGaSkillId_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->callObject);
		TsGameplayBlueprintFunctionLibrary.SetPassiveGaSkillId(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x06018153 RID: 98643 RVA: 0x006BEB2D File Offset: 0x006BCD2D
	protected unsafe static void __CPPCALL_AddBuffForDebug_Implementation(TsGameplayBlueprintFunctionLibrary.__AddBuffForDebug_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.AddBuffForDebug(__Params->instigatorEntityId, __Params->targetEntityId, __Params->buffId);
	}

	// Token: 0x06018154 RID: 98644 RVA: 0x006BEB48 File Offset: 0x006BCD48
	protected unsafe static void __CPPCALL_SendCombatEventForDebug_Implementation(TsGameplayBlueprintFunctionLibrary.__SendCombatEventForDebug_FunctionParams* __Params)
	{
		string tagName = FString.ToString((void*)(&__Params->tagName));
		TsGameplayBlueprintFunctionLibrary.SendCombatEventForDebug(__Params->entityId, tagName, __Params->needSave, __Params->isMainState);
	}

	// Token: 0x06018155 RID: 98645 RVA: 0x006BEB7C File Offset: 0x006BCD7C
	protected unsafe static void __CPPCALL_SendLevelEventForDebug_Implementation(TsGameplayBlueprintFunctionLibrary.__SendLevelEventForDebug_FunctionParams* __Params)
	{
		string tagName = FString.ToString((void*)(&__Params->tagName));
		TsGameplayBlueprintFunctionLibrary.SendLevelEventForDebug(__Params->entityId, tagName);
	}

	// Token: 0x06018156 RID: 98646 RVA: 0x006BEBA4 File Offset: 0x006BCDA4
	protected unsafe static void __CPPCALL_AddBuffFromGA_Implementation(TsGameplayBlueprintFunctionLibrary.__AddBuffFromGA_FunctionParams* __Params)
	{
		TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->target);
		string skillId = FString.ToString((void*)(&__Params->skillId));
		TsGameplayBlueprintFunctionLibrary.AddBuffFromGA(__Params->entityId, orCreateUObjectByNativePointer, __Params->buffId, skillId, __Params->addCount);
	}

	// Token: 0x06018157 RID: 98647 RVA: 0x006BEBE3 File Offset: 0x006BCDE3
	protected unsafe static void __CPPCALL_RemoveBuffById_Implementation(TsGameplayBlueprintFunctionLibrary.__RemoveBuffById_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.RemoveBuffById(__Params->entityId, __Params->buffId, __Params->stackCount);
	}

	// Token: 0x06018158 RID: 98648 RVA: 0x006BEBFC File Offset: 0x006BCDFC
	protected unsafe static void __CPPCALL_GetBuffCountById_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffCountById_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetBuffCountById(__Params->entityId, __Params->buffId, __Params->enforceOnGoingCheck);
	}

	// Token: 0x06018159 RID: 98649 RVA: 0x006BEC1B File Offset: 0x006BCE1B
	protected unsafe static void __CPPCALL_AddGameplayCueLocal_Implementation(TsGameplayBlueprintFunctionLibrary.__AddGameplayCueLocal_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.AddGameplayCueLocal(__Params->entityId, __Params->duration, __Params->cueId);
	}

	// Token: 0x0601815A RID: 98650 RVA: 0x006BEC34 File Offset: 0x006BCE34
	protected unsafe static void __CPPCALL_GetGeDebugString_Implementation(TsGameplayBlueprintFunctionLibrary.__GetGeDebugString_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetGeDebugString(__Params->entityId));
	}

	// Token: 0x0601815B RID: 98651 RVA: 0x006BEC4D File Offset: 0x006BCE4D
	protected unsafe static void __CPPCALL_GetTagDebugStrings_Implementation(TsGameplayBlueprintFunctionLibrary.__GetTagDebugStrings_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetTagDebugStrings(__Params->entityId));
	}

	// Token: 0x0601815C RID: 98652 RVA: 0x006BEC68 File Offset: 0x006BCE68
	protected unsafe static void __CPPCALL_GetBuffDebugStrings_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffDebugStrings_FunctionParams* __Params)
	{
		string buffStr = FString.ToString((void*)(&__Params->buffStr));
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetBuffDebugStrings(__Params->entityId, buffStr));
	}

	// Token: 0x0601815D RID: 98653 RVA: 0x006BEC9C File Offset: 0x006BCE9C
	protected unsafe static void __CPPCALL_GetShieldDebugString_Implementation(TsGameplayBlueprintFunctionLibrary.__GetShieldDebugString_FunctionParams* __Params)
	{
		string filterStr = FString.ToString((void*)(&__Params->filterStr));
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetShieldDebugString(__Params->entityId, filterStr));
	}

	// Token: 0x0601815E RID: 98654 RVA: 0x006BECCE File Offset: 0x006BCECE
	protected unsafe static void __CPPCALL_GetPassiveSkillDebugString_Implementation(TsGameplayBlueprintFunctionLibrary.__GetPassiveSkillDebugString_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetPassiveSkillDebugString(__Params->entityId));
	}

	// Token: 0x0601815F RID: 98655 RVA: 0x006BECE7 File Offset: 0x006BCEE7
	protected unsafe static void __CPPCALL_GetShieldValue_Implementation(TsGameplayBlueprintFunctionLibrary.__GetShieldValue_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetShieldValue(__Params->entityId, __Params->shieldCid);
	}

	// Token: 0x06018160 RID: 98656 RVA: 0x006BED00 File Offset: 0x006BCF00
	protected unsafe static void __CPPCALL_GetAttributeDebugString_Implementation(TsGameplayBlueprintFunctionLibrary.__GetAttributeDebugString_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetAttributeDebugString(__Params->entityId));
	}

	// Token: 0x06018161 RID: 98657 RVA: 0x006BED19 File Offset: 0x006BCF19
	protected unsafe static void __CPPCALL_GetAllAttributeDebugStrings_Implementation(TsGameplayBlueprintFunctionLibrary.__GetAllAttributeDebugStrings_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetAllAttributeDebugStrings(__Params->entityId));
	}

	// Token: 0x06018162 RID: 98658 RVA: 0x006BED32 File Offset: 0x006BCF32
	protected unsafe static void __CPPCALL_GetServerBuffString_Implementation(TsGameplayBlueprintFunctionLibrary.__GetServerBuffString_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetServerBuffString(__Params->entityId));
	}

	// Token: 0x06018163 RID: 98659 RVA: 0x006BED4B File Offset: 0x006BCF4B
	protected unsafe static void __CPPCALL_GetServerTagString_Implementation(TsGameplayBlueprintFunctionLibrary.__GetServerTagString_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetServerTagString(__Params->entityId));
	}

	// Token: 0x06018164 RID: 98660 RVA: 0x006BED64 File Offset: 0x006BCF64
	protected unsafe static void __CPPCALL_GetServerAttributeString_Implementation(TsGameplayBlueprintFunctionLibrary.__GetServerAttributeString_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetServerAttributeString(__Params->entityId));
	}

	// Token: 0x06018165 RID: 98661 RVA: 0x006BED7D File Offset: 0x006BCF7D
	protected unsafe static void __CPPCALL_GetServerPartString_Implementation(TsGameplayBlueprintFunctionLibrary.__GetServerPartString_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetServerPartString(__Params->entityId));
	}

	// Token: 0x06018166 RID: 98662 RVA: 0x006BED96 File Offset: 0x006BCF96
	protected unsafe static void __CPPCALL_GetServerHateString_Implementation(TsGameplayBlueprintFunctionLibrary.__GetServerHateString_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetServerHateString(__Params->entityId));
	}

	// Token: 0x06018167 RID: 98663 RVA: 0x006BEDAF File Offset: 0x006BCFAF
	protected unsafe static void __CPPCALL_GetServerShieldString_Implementation(TsGameplayBlueprintFunctionLibrary.__GetServerShieldString_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetServerShieldString(__Params->entityId));
	}

	// Token: 0x06018168 RID: 98664 RVA: 0x006BEDC8 File Offset: 0x006BCFC8
	protected unsafe static void __CPPCALL_ServerDebugInfoRequest_Implementation(TsGameplayBlueprintFunctionLibrary.__ServerDebugInfoRequest_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ServerDebugInfoRequest(__Params->entityId);
	}

	// Token: 0x06018169 RID: 98665 RVA: 0x006BEDD5 File Offset: 0x006BCFD5
	protected unsafe static void __CPPCALL_GetServerDebugInfoDirty_Implementation(TsGameplayBlueprintFunctionLibrary.__GetServerDebugInfoDirty_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetServerDebugInfoDirty(__Params->entityId);
	}

	// Token: 0x0601816A RID: 98666 RVA: 0x006BEDE8 File Offset: 0x006BCFE8
	protected unsafe static void __CPPCALL_SetServerDebugInfoDirty_Implementation(TsGameplayBlueprintFunctionLibrary.__SetServerDebugInfoDirty_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetServerDebugInfoDirty(__Params->entityId, __Params->val);
	}

	// Token: 0x0601816B RID: 98667 RVA: 0x006BEDFB File Offset: 0x006BCFFB
	protected unsafe static void __CPPCALL_DebugResetBaseVal_Implementation(TsGameplayBlueprintFunctionLibrary.__DebugResetBaseVal_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.DebugResetBaseVal(__Params->entityId, __Params->id, __Params->val);
	}

	// Token: 0x0601816C RID: 98668 RVA: 0x006BEE14 File Offset: 0x006BD014
	protected unsafe static void __CPPCALL_DebugResetFormationValue_Implementation(TsGameplayBlueprintFunctionLibrary.__DebugResetFormationValue_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.DebugResetFormationValue(__Params->id, __Params->val);
	}

	// Token: 0x0601816D RID: 98669 RVA: 0x006BEE27 File Offset: 0x006BD027
	protected unsafe static void __CPPCALL_Record_Implementation(TsGameplayBlueprintFunctionLibrary.__Record_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.Record(__Params->entityId, __Params->record));
	}

	// Token: 0x0601816E RID: 98670 RVA: 0x006BEE46 File Offset: 0x006BD046
	protected unsafe static void __CPPCALL_RefreshEntityListView_Implementation(TsGameplayBlueprintFunctionLibrary.__RefreshEntityListView_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.RefreshEntityListView(BuiltinUtils.GetOrCreateUObjectByNativePointer<UListView>(__Params->listView));
	}

	// Token: 0x0601816F RID: 98671 RVA: 0x006BEE58 File Offset: 0x006BD058
	protected unsafe static void __CPPCALL_RefreshEntityComboBox_Implementation(TsGameplayBlueprintFunctionLibrary.__RefreshEntityComboBox_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.RefreshEntityComboBox(BuiltinUtils.GetOrCreateUObjectByNativePointer<UComboBoxString>(__Params->comboBox));
	}

	// Token: 0x06018170 RID: 98672 RVA: 0x006BEE6A File Offset: 0x006BD06A
	protected unsafe static void __CPPCALL_SetEntityComboBox_Implementation(TsGameplayBlueprintFunctionLibrary.__SetEntityComboBox_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetEntityComboBox(BuiltinUtils.GetOrCreateUObjectByNativePointer<UComboBoxString>(__Params->comboBox), __Params->entityId);
	}

	// Token: 0x06018171 RID: 98673 RVA: 0x006BEE82 File Offset: 0x006BD082
	protected unsafe static void __CPPCALL_SetDebugEntityId_Implementation(TsGameplayBlueprintFunctionLibrary.__SetDebugEntityId_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetDebugEntityId(__Params->entityId);
	}

	// Token: 0x06018172 RID: 98674 RVA: 0x006BEE8F File Offset: 0x006BD08F
	protected unsafe static void __CPPCALL_GetDebugEntityId_Implementation(TsGameplayBlueprintFunctionLibrary.__GetDebugEntityId_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetDebugEntityId();
	}

	// Token: 0x06018173 RID: 98675 RVA: 0x006BEE9C File Offset: 0x006BD09C
	protected unsafe static void __CPPCALL_RefreshBuffListView_Implementation(TsGameplayBlueprintFunctionLibrary.__RefreshBuffListView_FunctionParams* __Params)
	{
		UListView orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UListView>(__Params->listView);
		string filterStr = FString.ToString((void*)(&__Params->filterStr));
		TsGameplayBlueprintFunctionLibrary.RefreshBuffListView(__Params->entityId, orCreateUObjectByNativePointer, filterStr);
	}

	// Token: 0x06018174 RID: 98676 RVA: 0x006BEECF File Offset: 0x006BD0CF
	protected unsafe static void __CPPCALL_GetBuffIdByHandle_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffIdByHandle_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetBuffIdByHandle(__Params->entityId, __Params->handle);
	}

	// Token: 0x06018175 RID: 98677 RVA: 0x006BEEE8 File Offset: 0x006BD0E8
	protected unsafe static void __CPPCALL_GetBuffServerIdByHandle_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffServerIdByHandle_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetBuffServerIdByHandle(__Params->entityId, __Params->handle);
	}

	// Token: 0x06018176 RID: 98678 RVA: 0x006BEF01 File Offset: 0x006BD101
	protected unsafe static void __CPPCALL_GetBuffDescByHandle_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffDescByHandle_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetBuffDescByHandle(__Params->entityId, __Params->handle));
	}

	// Token: 0x06018177 RID: 98679 RVA: 0x006BEF20 File Offset: 0x006BD120
	protected unsafe static void __CPPCALL_GetBuffActivateByHandle_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffActivateByHandle_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetBuffActivateByHandle(__Params->entityId, __Params->handle);
	}

	// Token: 0x06018178 RID: 98680 RVA: 0x006BEF39 File Offset: 0x006BD139
	protected unsafe static void __CPPCALL_GetBuffInstigatorStringByHandle_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffInstigatorStringByHandle_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetBuffInstigatorStringByHandle(__Params->entityId, __Params->handle));
	}

	// Token: 0x06018179 RID: 98681 RVA: 0x006BEF58 File Offset: 0x006BD158
	protected unsafe static void __CPPCALL_GetBuffPeriodStringByHandle_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffPeriodStringByHandle_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetBuffPeriodStringByHandle(__Params->entityId, __Params->handle));
	}

	// Token: 0x0601817A RID: 98682 RVA: 0x006BEF77 File Offset: 0x006BD177
	protected unsafe static void __CPPCALL_GetBuffDurationStringByHandle_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffDurationStringByHandle_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetBuffDurationStringByHandle(__Params->entityId, __Params->handle));
	}

	// Token: 0x0601817B RID: 98683 RVA: 0x006BEF96 File Offset: 0x006BD196
	protected unsafe static void __CPPCALL_GetBuffDurationProgress_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffDurationProgress_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetBuffDurationProgress(__Params->entityId, __Params->handle);
	}

	// Token: 0x0601817C RID: 98684 RVA: 0x006BEFAF File Offset: 0x006BD1AF
	protected unsafe static void __CPPCALL_GetBuffLivingStatusStringByHandle_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffLivingStatusStringByHandle_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetBuffLivingStatusStringByHandle(__Params->entityId, __Params->handle));
	}

	// Token: 0x0601817D RID: 98685 RVA: 0x006BEFCE File Offset: 0x006BD1CE
	protected unsafe static void __CPPCALL_GetBuffLevelStringByHandle_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffLevelStringByHandle_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetBuffLevelStringByHandle(__Params->entityId, __Params->handle));
	}

	// Token: 0x0601817E RID: 98686 RVA: 0x006BEFED File Offset: 0x006BD1ED
	protected unsafe static void __CPPCALL_GetBuffStackStringByHandle_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffStackStringByHandle_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetBuffStackStringByHandle(__Params->entityId, __Params->handle));
	}

	// Token: 0x0601817F RID: 98687 RVA: 0x006BF00C File Offset: 0x006BD20C
	protected unsafe static void __CPPCALL_GetBuffDebugStringByHandle_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffDebugStringByHandle_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetBuffDebugStringByHandle(__Params->entityId, __Params->handle));
	}

	// Token: 0x06018180 RID: 98688 RVA: 0x006BF02B File Offset: 0x006BD22B
	protected unsafe static void __CPPCALL_SetDistance_Implementation(TsGameplayBlueprintFunctionLibrary.__SetDistance_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetDistance(__Params->entityId, __Params->max);
	}

	// Token: 0x06018181 RID: 98689 RVA: 0x006BF03E File Offset: 0x006BD23E
	protected unsafe static void __CPPCALL_GetAllMovementHistory_Implementation(TsGameplayBlueprintFunctionLibrary.__GetAllMovementHistory_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetAllMovementHistory(__Params->entityId));
	}

	// Token: 0x06018182 RID: 98690 RVA: 0x006BF057 File Offset: 0x006BD257
	protected unsafe static void __CPPCALL_ResetBaseValueLocal_Implementation(TsGameplayBlueprintFunctionLibrary.__ResetBaseValueLocal_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ResetBaseValueLocal(__Params->entityId, __Params->id, __Params->val);
	}

	// Token: 0x06018183 RID: 98691 RVA: 0x006BF070 File Offset: 0x006BD270
	protected unsafe static void __CPPCALL_GetAttributeCurrentValue_Implementation(TsGameplayBlueprintFunctionLibrary.__GetAttributeCurrentValue_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetAttributeCurrentValue(__Params->entityId, __Params->attributeId);
	}

	// Token: 0x06018184 RID: 98692 RVA: 0x006BF089 File Offset: 0x006BD289
	protected unsafe static void __CPPCALL_GetAttributeBaseValue_Implementation(TsGameplayBlueprintFunctionLibrary.__GetAttributeBaseValue_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetAttributeBaseValue(__Params->entityId, __Params->attributeId);
	}

	// Token: 0x06018185 RID: 98693 RVA: 0x006BF0A2 File Offset: 0x006BD2A2
	protected unsafe static void __CPPCALL_SetRageModeId_Implementation(TsGameplayBlueprintFunctionLibrary.__SetRageModeId_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetRageModeId(__Params->entityId, __Params->id);
	}

	// Token: 0x06018186 RID: 98694 RVA: 0x006BF0B5 File Offset: 0x006BD2B5
	protected unsafe static void __CPPCALL_SetHardnessModeId_Implementation(TsGameplayBlueprintFunctionLibrary.__SetHardnessModeId_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetHardnessModeId(__Params->entityId, __Params->id);
	}

	// Token: 0x06018187 RID: 98695 RVA: 0x006BF0C8 File Offset: 0x006BD2C8
	protected unsafe static void __CPPCALL_OnHit_Implementation(TsGameplayBlueprintFunctionLibrary.__OnHit_FunctionParams* __Params)
	{
		SHitInformation hitData = new SHitInformation(&__Params->hitData, true, true);
		TsGameplayBlueprintFunctionLibrary.OnHit(__Params->entityId, hitData);
	}

	// Token: 0x06018188 RID: 98696 RVA: 0x006BF0F0 File Offset: 0x006BD2F0
	protected unsafe static void __CPPCALL_SetBeHitIgnoreRotate_Implementation(TsGameplayBlueprintFunctionLibrary.__SetBeHitIgnoreRotate_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetBeHitIgnoreRotate(__Params->entityId, __Params->ignoreRotate);
	}

	// Token: 0x06018189 RID: 98697 RVA: 0x006BF103 File Offset: 0x006BD303
	protected unsafe static void __CPPCALL_CheckHasPart_Implementation(TsGameplayBlueprintFunctionLibrary.__CheckHasPart_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.CheckHasPart(__Params->entityId);
	}

	// Token: 0x0601818A RID: 98698 RVA: 0x006BF116 File Offset: 0x006BD316
	protected unsafe static void __CPPCALL_GetPartRemainedLife_Implementation(TsGameplayBlueprintFunctionLibrary.__GetPartRemainedLife_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetPartRemainedLife(__Params->entityId, __Params->tag);
	}

	// Token: 0x0601818B RID: 98699 RVA: 0x006BF12F File Offset: 0x006BD32F
	protected unsafe static void __CPPCALL_ResetPartLife_Implementation(TsGameplayBlueprintFunctionLibrary.__ResetPartLife_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ResetPartLife(__Params->entityId, __Params->tag);
	}

	// Token: 0x0601818C RID: 98700 RVA: 0x006BF142 File Offset: 0x006BD342
	protected unsafe static void __CPPCALL_ActiveStiff_Implementation(TsGameplayBlueprintFunctionLibrary.__ActiveStiff_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ActiveStiff(__Params->entityId);
	}

	// Token: 0x0601818D RID: 98701 RVA: 0x006BF14F File Offset: 0x006BD34F
	protected unsafe static void __CPPCALL_DeActiveStiff_Implementation(TsGameplayBlueprintFunctionLibrary.__DeActiveStiff_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.DeActiveStiff(__Params->entityId);
	}

	// Token: 0x0601818E RID: 98702 RVA: 0x006BF15C File Offset: 0x006BD35C
	protected unsafe static void __CPPCALL_GetAcceptedNewBeHitAndReset_Implementation(TsGameplayBlueprintFunctionLibrary.__GetAcceptedNewBeHitAndReset_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetAcceptedNewBeHitAndReset(__Params->entityId);
	}

	// Token: 0x0601818F RID: 98703 RVA: 0x006BF16F File Offset: 0x006BD36F
	protected unsafe static void __CPPCALL_GetEnterFkAndReset_Implementation(TsGameplayBlueprintFunctionLibrary.__GetEnterFkAndReset_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetEnterFkAndReset(__Params->entityId);
	}

	// Token: 0x06018190 RID: 98704 RVA: 0x006BF182 File Offset: 0x006BD382
	protected unsafe static void __CPPCALL_IsStiff_Implementation(TsGameplayBlueprintFunctionLibrary.__IsStiff_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.IsStiff(__Params->entityId);
	}

	// Token: 0x06018191 RID: 98705 RVA: 0x006BF195 File Offset: 0x006BD395
	protected unsafe static void __CPPCALL_GetRageModeId_Implementation(TsGameplayBlueprintFunctionLibrary.__GetRageModeId_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetRageModeId(__Params->entityId);
	}

	// Token: 0x06018192 RID: 98706 RVA: 0x006BF1A8 File Offset: 0x006BD3A8
	protected unsafe static void __CPPCALL_GetHardnessModeId_Implementation(TsGameplayBlueprintFunctionLibrary.__GetHardnessModeId_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetHardnessModeId(__Params->entityId);
	}

	// Token: 0x06018193 RID: 98707 RVA: 0x006BF1BB File Offset: 0x006BD3BB
	protected unsafe static void __CPPCALL_GetBeHitBone_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBeHitBone_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetBeHitBone(__Params->entityId);
	}

	// Token: 0x06018194 RID: 98708 RVA: 0x006BF1CE File Offset: 0x006BD3CE
	protected unsafe static void __CPPCALL_GetToughDecreaseValue_Implementation(TsGameplayBlueprintFunctionLibrary.__GetToughDecreaseValue_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetToughDecreaseValue(__Params->entityId);
	}

	// Token: 0x06018195 RID: 98709 RVA: 0x006BF1E1 File Offset: 0x006BD3E1
	protected unsafe static void __CPPCALL_GetCounterAttackInfoInternal_Implementation(TsGameplayBlueprintFunctionLibrary.__GetCounterAttackInfoInternal_FunctionParams* __Params)
	{
		UScriptStructStackOnlyPtr nativeUStructPtr = SCounterAttack.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SCounterAttack counterAttackInfoInternal = TsGameplayBlueprintFunctionLibrary.GetCounterAttackInfoInternal(__Params->entityId);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (counterAttackInfoInternal != null) ? counterAttackInfoInternal.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06018196 RID: 98710 RVA: 0x006BF20E File Offset: 0x006BD40E
	protected unsafe static void __CPPCALL_GetVisionCounterAttackInfoInternal_Implementation(TsGameplayBlueprintFunctionLibrary.__GetVisionCounterAttackInfoInternal_FunctionParams* __Params)
	{
		UScriptStructStackOnlyPtr nativeUStructPtr = SVisionCounterAttack.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SVisionCounterAttack visionCounterAttackInfoInternal = TsGameplayBlueprintFunctionLibrary.GetVisionCounterAttackInfoInternal(__Params->entityId);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (visionCounterAttackInfoInternal != null) ? visionCounterAttackInfoInternal.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06018197 RID: 98711 RVA: 0x006BF23B File Offset: 0x006BD43B
	protected unsafe static void __CPPCALL_GetBeHitTime_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBeHitTime_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetBeHitTime(__Params->entityId);
	}

	// Token: 0x06018198 RID: 98712 RVA: 0x006BF24E File Offset: 0x006BD44E
	protected unsafe static void __CPPCALL_GetBeHitAnim_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBeHitAnim_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)TsGameplayBlueprintFunctionLibrary.GetBeHitAnim(__Params->entityId);
	}

	// Token: 0x06018199 RID: 98713 RVA: 0x006BF263 File Offset: 0x006BD463
	protected unsafe static void __CPPCALL_GetEnterFk_Implementation(TsGameplayBlueprintFunctionLibrary.__GetEnterFk_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetEnterFk(__Params->entityId);
	}

	// Token: 0x0601819A RID: 98714 RVA: 0x006BF276 File Offset: 0x006BD476
	protected unsafe static void __CPPCALL_GetBeHitDirect_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBeHitDirect_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetBeHitDirect(__Params->entityId);
	}

	// Token: 0x0601819B RID: 98715 RVA: 0x006BF289 File Offset: 0x006BD489
	protected unsafe static void __CPPCALL_GetBeHitLocation_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBeHitLocation_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetBeHitLocation(__Params->entityId);
	}

	// Token: 0x0601819C RID: 98716 RVA: 0x006BF29C File Offset: 0x006BD49C
	protected unsafe static void __CPPCALL_AddCheckBuffList_Implementation(TsGameplayBlueprintFunctionLibrary.__AddCheckBuffList_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.AddCheckBuffList(__Params->entityId, __Params->addValue);
	}

	// Token: 0x0601819D RID: 98717 RVA: 0x006BF2AF File Offset: 0x006BD4AF
	protected unsafe static void __CPPCALL_ClearCheckBuffList_Implementation(TsGameplayBlueprintFunctionLibrary.__ClearCheckBuffList_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ClearCheckBuffList(__Params->entityId);
	}

	// Token: 0x0601819E RID: 98718 RVA: 0x006BF2BC File Offset: 0x006BD4BC
	protected unsafe static void __CPPCALL_CounterAttackEnd_Implementation(TsGameplayBlueprintFunctionLibrary.__CounterAttackEnd_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.CounterAttackEnd(__Params->entityId);
	}

	// Token: 0x0601819F RID: 98719 RVA: 0x006BF2C9 File Offset: 0x006BD4C9
	protected unsafe static void __CPPCALL_VisionCounterAttackEnd_Implementation(TsGameplayBlueprintFunctionLibrary.__VisionCounterAttackEnd_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.VisionCounterAttackEnd(__Params->entityId);
	}

	// Token: 0x060181A0 RID: 98720 RVA: 0x006BF2D6 File Offset: 0x006BD4D6
	protected unsafe static void __CPPCALL_SetCounterAttackEndTime_Implementation(TsGameplayBlueprintFunctionLibrary.__SetCounterAttackEndTime_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetCounterAttackEndTime(__Params->entityId, __Params->baseTime);
	}

	// Token: 0x060181A1 RID: 98721 RVA: 0x006BF2E9 File Offset: 0x006BD4E9
	protected unsafe static void __CPPCALL_IsTriggerCounterAttack_Implementation(TsGameplayBlueprintFunctionLibrary.__IsTriggerCounterAttack_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.IsTriggerCounterAttack(__Params->entityId);
	}

	// Token: 0x060181A2 RID: 98722 RVA: 0x006BF2FC File Offset: 0x006BD4FC
	protected unsafe static void __CPPCALL_ResetTarget_Implementation(TsGameplayBlueprintFunctionLibrary.__ResetTarget_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ResetTarget(__Params->entityId);
	}

	// Token: 0x060181A3 RID: 98723 RVA: 0x006BF30C File Offset: 0x006BD50C
	protected unsafe static void __CPPCALL_SetShowTarget_Implementation(TsGameplayBlueprintFunctionLibrary.__SetShowTarget_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actor);
		TsGameplayBlueprintFunctionLibrary.SetShowTarget(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x060181A4 RID: 98724 RVA: 0x006BF331 File Offset: 0x006BD531
	protected unsafe static void __CPPCALL_ExitLockDirection_Implementation(TsGameplayBlueprintFunctionLibrary.__ExitLockDirection_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ExitLockDirection(__Params->entityId);
	}

	// Token: 0x060181A5 RID: 98725 RVA: 0x006BF33E File Offset: 0x006BD53E
	protected unsafe static void __CPPCALL_EnterLockDirection_Implementation(TsGameplayBlueprintFunctionLibrary.__EnterLockDirection_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.EnterLockDirection(__Params->entityId);
	}

	// Token: 0x060181A6 RID: 98726 RVA: 0x006BF34B File Offset: 0x006BD54B
	protected unsafe static void __CPPCALL_GetCurrentTarget_Implementation(TsGameplayBlueprintFunctionLibrary.__GetCurrentTarget_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		TsBaseCharacter currentTarget = TsGameplayBlueprintFunctionLibrary.GetCurrentTarget(__Params->entityId);
		ptr = ((currentTarget != null) ? currentTarget.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060181A7 RID: 98727 RVA: 0x006BF36D File Offset: 0x006BD56D
	protected unsafe static void __CPPCALL_SetLockOnDebugLine_Implementation(TsGameplayBlueprintFunctionLibrary.__SetLockOnDebugLine_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetLockOnDebugLine(__Params->entityId, __Params->isShow);
	}

	// Token: 0x060181A8 RID: 98728 RVA: 0x006BF380 File Offset: 0x006BD580
	protected unsafe static void __CPPCALL_ManipulateValid_Implementation(TsGameplayBlueprintFunctionLibrary.__ManipulateValid_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.ManipulateValid(__Params->entityId);
	}

	// Token: 0x060181A9 RID: 98729 RVA: 0x006BF393 File Offset: 0x006BD593
	protected unsafe static void __CPPCALL_ManipulateGetDrawTarget_Implementation(TsGameplayBlueprintFunctionLibrary.__ManipulateGetDrawTarget_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		AActor aactor = TsGameplayBlueprintFunctionLibrary.ManipulateGetDrawTarget(__Params->entityId);
		ptr = ((aactor != null) ? aactor.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060181AA RID: 98730 RVA: 0x006BF3B5 File Offset: 0x006BD5B5
	protected unsafe static void __CPPCALL_ManipulateGetCastTarget_Implementation(TsGameplayBlueprintFunctionLibrary.__ManipulateGetCastTarget_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		AActor aactor = TsGameplayBlueprintFunctionLibrary.ManipulateGetCastTarget(__Params->entityId);
		ptr = ((aactor != null) ? aactor.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060181AB RID: 98731 RVA: 0x006BF3D7 File Offset: 0x006BD5D7
	protected unsafe static void __CPPCALL_ManipulateGetDrawTargetChantTime_Implementation(TsGameplayBlueprintFunctionLibrary.__ManipulateGetDrawTargetChantTime_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.ManipulateGetDrawTargetChantTime(__Params->entityId);
	}

	// Token: 0x060181AC RID: 98732 RVA: 0x006BF3EC File Offset: 0x006BD5EC
	protected unsafe static void __CPPCALL_ManipulateChant_Implementation(TsGameplayBlueprintFunctionLibrary.__ManipulateChant_FunctionParams* __Params)
	{
		UKuroBooleanEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroBooleanEventBinder>(__Params->eventBinder);
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.ManipulateChant(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x060181AD RID: 98733 RVA: 0x006BF417 File Offset: 0x006BD617
	protected unsafe static void __CPPCALL_ManipulateDraw_Implementation(TsGameplayBlueprintFunctionLibrary.__ManipulateDraw_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.ManipulateDraw(__Params->entityId);
	}

	// Token: 0x060181AE RID: 98734 RVA: 0x006BF42A File Offset: 0x006BD62A
	protected unsafe static void __CPPCALL_ManipulateCast_Implementation(TsGameplayBlueprintFunctionLibrary.__ManipulateCast_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.ManipulateCast(__Params->entityId, __Params->direction);
	}

	// Token: 0x060181AF RID: 98735 RVA: 0x006BF443 File Offset: 0x006BD643
	protected unsafe static void __CPPCALL_ManipulateReset_Implementation(TsGameplayBlueprintFunctionLibrary.__ManipulateReset_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ManipulateReset(__Params->entityId);
	}

	// Token: 0x060181B0 RID: 98736 RVA: 0x006BF450 File Offset: 0x006BD650
	protected unsafe static void __CPPCALL_ManipulateChangeToProjectileState_Implementation(TsGameplayBlueprintFunctionLibrary.__ManipulateChangeToProjectileState_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.ManipulateChangeToProjectileState(__Params->entityId);
	}

	// Token: 0x060181B1 RID: 98737 RVA: 0x006BF463 File Offset: 0x006BD663
	protected unsafe static void __CPPCALL_ManipulateChangeToNormalState_Implementation(TsGameplayBlueprintFunctionLibrary.__ManipulateChangeToNormalState_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.ManipulateChangeToNormalState(__Params->entityId);
	}

	// Token: 0x060181B2 RID: 98738 RVA: 0x006BF476 File Offset: 0x006BD676
	protected unsafe static void __CPPCALL_GetHoldingActor_Implementation(TsGameplayBlueprintFunctionLibrary.__GetHoldingActor_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		AActor holdingActor = TsGameplayBlueprintFunctionLibrary.GetHoldingActor(__Params->entityId);
		ptr = ((holdingActor != null) ? holdingActor.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060181B3 RID: 98739 RVA: 0x006BF498 File Offset: 0x006BD698
	protected unsafe static void __CPPCALL_HasHoldingActor_Implementation(TsGameplayBlueprintFunctionLibrary.__HasHoldingActor_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.HasHoldingActor(__Params->entityId);
	}

	// Token: 0x060181B4 RID: 98740 RVA: 0x006BF4AB File Offset: 0x006BD6AB
	protected unsafe static void __CPPCALL_SetDebugDraw_Implementation(TsGameplayBlueprintFunctionLibrary.__SetDebugDraw_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetDebugDraw(__Params->entityId, __Params->isActive);
	}

	// Token: 0x060181B5 RID: 98741 RVA: 0x006BF4BE File Offset: 0x006BD6BE
	protected unsafe static void __CPPCALL_ExtraAction_Implementation(TsGameplayBlueprintFunctionLibrary.__ExtraAction_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ExtraAction(__Params->entityId);
	}

	// Token: 0x060181B6 RID: 98742 RVA: 0x006BF4CB File Offset: 0x006BD6CB
	protected unsafe static void __CPPCALL_SetQtePosition_Implementation(TsGameplayBlueprintFunctionLibrary.__SetQtePosition_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetQtePosition(__Params->entityId, __Params->rotate, __Params->length, __Params->height, __Params->referenceTarget, __Params->adjustWithMonster, __Params->addHeight, __Params->qteType);
	}

	// Token: 0x060181B7 RID: 98743 RVA: 0x006BF502 File Offset: 0x006BD702
	protected unsafe static void __CPPCALL_GetGoBattleActor_Implementation(TsGameplayBlueprintFunctionLibrary.__GetGoBattleActor_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		TsBaseCharacter goBattleActor = TsGameplayBlueprintFunctionLibrary.GetGoBattleActor(__Params->entityId);
		ptr = ((goBattleActor != null) ? goBattleActor.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060181B8 RID: 98744 RVA: 0x006BF524 File Offset: 0x006BD724
	protected unsafe static void __CPPCALL_GetDtSkillInfo_Implementation(TsGameplayBlueprintFunctionLibrary.__GetDtSkillInfo_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		UDataTable dtSkillInfo = TsGameplayBlueprintFunctionLibrary.GetDtSkillInfo(__Params->entityId);
		ptr = ((dtSkillInfo != null) ? dtSkillInfo.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060181B9 RID: 98745 RVA: 0x006BF548 File Offset: 0x006BD748
	protected unsafe static void __CPPCALL_GetDtSkillInfoMapForDebug_Implementation(TsGameplayBlueprintFunctionLibrary.__GetDtSkillInfoMapForDebug_FunctionParams* __Params)
	{
		TMap<ECharacterLoadType, UDataTable> dtSkillInfoMapForDebug = TsGameplayBlueprintFunctionLibrary.GetDtSkillInfoMapForDebug(__Params->entityId);
		if (dtSkillInfoMapForDebug == null)
		{
			return;
		}
		dtSkillInfoMapForDebug.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x060181BA RID: 98746 RVA: 0x006BF57A File Offset: 0x006BD77A
	protected unsafe static void __CPPCALL_GetLastActivateSkillTime_Implementation(TsGameplayBlueprintFunctionLibrary.__GetLastActivateSkillTime_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetLastActivateSkillTime(__Params->entityId);
	}

	// Token: 0x060181BB RID: 98747 RVA: 0x006BF58D File Offset: 0x006BD78D
	protected unsafe static void __CPPCALL_SetLastActivateSkillTime_Implementation(TsGameplayBlueprintFunctionLibrary.__SetLastActivateSkillTime_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetLastActivateSkillTime(__Params->entityId, __Params->time);
	}

	// Token: 0x060181BC RID: 98748 RVA: 0x006BF5A0 File Offset: 0x006BD7A0
	protected unsafe static void __CPPCALL_GetSkillElevationAngle_Implementation(TsGameplayBlueprintFunctionLibrary.__GetSkillElevationAngle_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetSkillElevationAngle(__Params->entityId);
	}

	// Token: 0x060181BD RID: 98749 RVA: 0x006BF5B3 File Offset: 0x006BD7B3
	protected unsafe static void __CPPCALL_SetSkillElevationAngle_Implementation(TsGameplayBlueprintFunctionLibrary.__SetSkillElevationAngle_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetSkillElevationAngle(__Params->entityId, __Params->angle);
	}

	// Token: 0x060181BE RID: 98750 RVA: 0x006BF5C6 File Offset: 0x006BD7C6
	protected unsafe static void __CPPCALL_CurrentSkillId_Implementation(TsGameplayBlueprintFunctionLibrary.__CurrentSkillId_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.CurrentSkillId(__Params->entityId));
	}

	// Token: 0x060181BF RID: 98751 RVA: 0x006BF5DF File Offset: 0x006BD7DF
	protected unsafe static void __CPPCALL_CurrentPriority_Implementation(TsGameplayBlueprintFunctionLibrary.__CurrentPriority_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.CurrentPriority(__Params->entityId);
	}

	// Token: 0x060181C0 RID: 98752 RVA: 0x006BF5F2 File Offset: 0x006BD7F2
	protected unsafe static void __CPPCALL_SetCurrentPriority_Implementation(TsGameplayBlueprintFunctionLibrary.__SetCurrentPriority_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetCurrentPriority(__Params->entityId, __Params->priority);
	}

	// Token: 0x060181C1 RID: 98753 RVA: 0x006BF608 File Offset: 0x006BD808
	protected unsafe static void __CPPCALL_HasAbility_Implementation(TsGameplayBlueprintFunctionLibrary.__HasAbility_FunctionParams* __Params)
	{
		string skillId = FString.ToString((void*)(&__Params->skillId));
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.HasAbility(__Params->entityId, skillId);
	}

	// Token: 0x060181C2 RID: 98754 RVA: 0x006BF634 File Offset: 0x006BD834
	protected unsafe static void __CPPCALL_GetSkillInfo_Implementation(TsGameplayBlueprintFunctionLibrary.__GetSkillInfo_FunctionParams* __Params)
	{
		string skillId = FString.ToString((void*)(&__Params->skillId));
		UScriptStructStackOnlyPtr nativeUStructPtr = SSkillInfo.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SSkillInfo skillInfo = TsGameplayBlueprintFunctionLibrary.GetSkillInfo(__Params->entityId, skillId);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (skillInfo != null) ? skillInfo.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x060181C3 RID: 98755 RVA: 0x006BF67C File Offset: 0x006BD87C
	protected unsafe static void __CPPCALL_SetSkillPriority_Implementation(TsGameplayBlueprintFunctionLibrary.__SetSkillPriority_FunctionParams* __Params)
	{
		string skillId = FString.ToString((void*)(&__Params->skillId));
		TsGameplayBlueprintFunctionLibrary.SetSkillPriority(__Params->entityId, skillId, __Params->priority);
	}

	// Token: 0x060181C4 RID: 98756 RVA: 0x006BF6A8 File Offset: 0x006BD8A8
	protected unsafe static void __CPPCALL_EndSkill_Implementation(TsGameplayBlueprintFunctionLibrary.__EndSkill_FunctionParams* __Params)
	{
		string skillId = FString.ToString((void*)(&__Params->skillId));
		TsGameplayBlueprintFunctionLibrary.EndSkill(__Params->entityId, skillId, __Params->isSyn, __Params->isNotEnd);
	}

	// Token: 0x060181C5 RID: 98757 RVA: 0x006BF6DC File Offset: 0x006BD8DC
	protected unsafe static void __CPPCALL_BeginSkill_Implementation(TsGameplayBlueprintFunctionLibrary.__BeginSkill_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->target);
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.BeginSkill(__Params->entityId, __Params->skillId, __Params->isSyn, orCreateUObjectByNativePointer, __Params->socketName);
	}

	// Token: 0x060181C6 RID: 98758 RVA: 0x006BF71C File Offset: 0x006BD91C
	protected unsafe static void __CPPCALL_BeginSkillAsync_Implementation(TsGameplayBlueprintFunctionLibrary.__BeginSkillAsync_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->target);
		UKuroBooleanEventBinder orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroBooleanEventBinder>(__Params->eventBinder);
		TsGameplayBlueprintFunctionLibrary.BeginSkillAsync(__Params->entityId, __Params->skillId, orCreateUObjectByNativePointer, __Params->socketName, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060181C7 RID: 98759 RVA: 0x006BF75C File Offset: 0x006BD95C
	protected unsafe static void __CPPCALL_SkillBehaviorBegin_Implementation(TsGameplayBlueprintFunctionLibrary.__SkillBehaviorBegin_FunctionParams* __Params)
	{
		GA_Base_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<GA_Base_C>(__Params->ga);
		SSkillBehaviorAction action = new SSkillBehaviorAction(&__Params->action, true, true);
		TsGameplayBlueprintFunctionLibrary.SkillBehaviorBegin(__Params->entityId, orCreateUObjectByNativePointer, action);
	}

	// Token: 0x060181C8 RID: 98760 RVA: 0x006BF794 File Offset: 0x006BD994
	protected unsafe static void __CPPCALL_GetLocationByAction_Implementation(TsGameplayBlueprintFunctionLibrary.__GetLocationByAction_FunctionParams* __Params)
	{
		GA_Base_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<GA_Base_C>(__Params->ga);
		SSkillBehaviorAction action = new SSkillBehaviorAction(&__Params->action, true, true);
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetLocationByAction(__Params->entityId, orCreateUObjectByNativePointer, action);
	}

	// Token: 0x060181C9 RID: 98761 RVA: 0x006BF7D0 File Offset: 0x006BD9D0
	protected unsafe static void __CPPCALL_GetRotationByAction_Implementation(TsGameplayBlueprintFunctionLibrary.__GetRotationByAction_FunctionParams* __Params)
	{
		GA_Base_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<GA_Base_C>(__Params->ga);
		SSkillBehaviorAction action = new SSkillBehaviorAction(&__Params->action, true, true);
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetRotationByAction(__Params->entityId, orCreateUObjectByNativePointer, action);
	}

	// Token: 0x060181CA RID: 98762 RVA: 0x006BF80C File Offset: 0x006BDA0C
	protected unsafe static void __CPPCALL_SkillBehaviorSatisfy_Implementation(TsGameplayBlueprintFunctionLibrary.__SkillBehaviorSatisfy_FunctionParams* __Params)
	{
		GA_Base_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<GA_Base_C>(__Params->ga);
		SSkillBehaviorCondition condition = new SSkillBehaviorCondition(&__Params->condition, true, true);
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.SkillBehaviorSatisfy(__Params->entityId, orCreateUObjectByNativePointer, condition);
	}

	// Token: 0x060181CB RID: 98763 RVA: 0x006BF847 File Offset: 0x006BDA47
	protected unsafe static void __CPPCALL_GetSkillTarget_Implementation(TsGameplayBlueprintFunctionLibrary.__GetSkillTarget_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		AActor skillTarget = TsGameplayBlueprintFunctionLibrary.GetSkillTarget(__Params->entityId);
		ptr = ((skillTarget != null) ? skillTarget.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060181CC RID: 98764 RVA: 0x006BF86C File Offset: 0x006BDA6C
	protected unsafe static void __CPPCALL_SetSkillTarget_Implementation(TsGameplayBlueprintFunctionLibrary.__SetSkillTarget_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->target);
		TsGameplayBlueprintFunctionLibrary.SetSkillTarget(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x060181CD RID: 98765 RVA: 0x006BF894 File Offset: 0x006BDA94
	protected unsafe static void __CPPCALL_LockOnTargetAndSetShow_Implementation(TsGameplayBlueprintFunctionLibrary.__LockOnTargetAndSetShow_FunctionParams* __Params)
	{
		SSkillTarget config = new SSkillTarget(&__Params->config, true, true);
		TsGameplayBlueprintFunctionLibrary.LockOnTargetAndSetShow(__Params->entityId, config);
	}

	// Token: 0x060181CE RID: 98766 RVA: 0x006BF8BC File Offset: 0x006BDABC
	protected unsafe static void __CPPCALL_IsHasInputDir_Implementation(TsGameplayBlueprintFunctionLibrary.__IsHasInputDir_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.IsHasInputDir(__Params->entityId);
	}

	// Token: 0x060181CF RID: 98767 RVA: 0x006BF8CF File Offset: 0x006BDACF
	protected unsafe static void __CPPCALL_GetSkillIdWithGroupId_Implementation(TsGameplayBlueprintFunctionLibrary.__GetSkillIdWithGroupId_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetSkillIdWithGroupId(__Params->entityId, __Params->groupId));
	}

	// Token: 0x060181D0 RID: 98768 RVA: 0x006BF8EE File Offset: 0x006BDAEE
	protected unsafe static void __CPPCALL_GetSkillAcceptInput_Implementation(TsGameplayBlueprintFunctionLibrary.__GetSkillAcceptInput_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetSkillAcceptInput(__Params->entityId);
	}

	// Token: 0x060181D1 RID: 98769 RVA: 0x006BF901 File Offset: 0x006BDB01
	protected unsafe static void __CPPCALL_SetSkillAcceptInput_Implementation(TsGameplayBlueprintFunctionLibrary.__SetSkillAcceptInput_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetSkillAcceptInput(__Params->entityId, __Params->skillAcceptInput);
	}

	// Token: 0x060181D2 RID: 98770 RVA: 0x006BF914 File Offset: 0x006BDB14
	protected unsafe static void __CPPCALL_SetCommonSkillCanBeInterrupt_Implementation(TsGameplayBlueprintFunctionLibrary.__SetCommonSkillCanBeInterrupt_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetCommonSkillCanBeInterrupt(__Params->entityId, __Params->canBeInterrupt);
	}

	// Token: 0x060181D3 RID: 98771 RVA: 0x006BF927 File Offset: 0x006BDB27
	protected unsafe static void __CPPCALL_GetCommonSkillCanBeInterrupt_Implementation(TsGameplayBlueprintFunctionLibrary.__GetCommonSkillCanBeInterrupt_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetCommonSkillCanBeInterrupt(__Params->entityId);
	}

	// Token: 0x060181D4 RID: 98772 RVA: 0x006BF93C File Offset: 0x006BDB3C
	protected unsafe static void __CPPCALL_OnActivateAbility_Implementation(TsGameplayBlueprintFunctionLibrary.__OnActivateAbility_FunctionParams* __Params)
	{
		UGameplayAbility orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UGameplayAbility>(__Params->ga);
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.OnActivateAbility(__Params->entityId, orCreateUObjectByNativePointer, __Params->isCommitSuccess);
	}

	// Token: 0x060181D5 RID: 98773 RVA: 0x006BF970 File Offset: 0x006BDB70
	protected unsafe static void __CPPCALL_OnEndAbility_Implementation(TsGameplayBlueprintFunctionLibrary.__OnEndAbility_FunctionParams* __Params)
	{
		UGameplayAbility orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UGameplayAbility>(__Params->ga);
		TsGameplayBlueprintFunctionLibrary.OnEndAbility(__Params->entityId, orCreateUObjectByNativePointer, __Params->wasCancelled);
	}

	// Token: 0x060181D6 RID: 98774 RVA: 0x006BF99C File Offset: 0x006BDB9C
	protected unsafe static void __CPPCALL_GetPriority_Implementation(TsGameplayBlueprintFunctionLibrary.__GetPriority_FunctionParams* __Params)
	{
		string skillId = FString.ToString((void*)(&__Params->skillId));
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetPriority(__Params->entityId, skillId);
	}

	// Token: 0x060181D7 RID: 98775 RVA: 0x006BF9C8 File Offset: 0x006BDBC8
	protected unsafe static void __CPPCALL_GetActivePriority_Implementation(TsGameplayBlueprintFunctionLibrary.__GetActivePriority_FunctionParams* __Params)
	{
		string skillId = FString.ToString((void*)(&__Params->skillId));
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetActivePriority(__Params->entityId, skillId);
	}

	// Token: 0x060181D8 RID: 98776 RVA: 0x006BF9F4 File Offset: 0x006BDBF4
	protected unsafe static void __CPPCALL_GetSkillMontageInstance_Implementation(TsGameplayBlueprintFunctionLibrary.__GetSkillMontageInstance_FunctionParams* __Params)
	{
		string skillId = FString.ToString((void*)(&__Params->skillId));
		ref IntPtr ptr = ref *(&__Params->__Result);
		UAnimMontage skillMontageInstance = TsGameplayBlueprintFunctionLibrary.GetSkillMontageInstance(__Params->entityId, skillId, __Params->index);
		ptr = ((skillMontageInstance != null) ? skillMontageInstance.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060181D9 RID: 98777 RVA: 0x006BFA38 File Offset: 0x006BDC38
	protected unsafe static void __CPPCALL_GetSkillNeedPlayMontageIndex_Implementation(TsGameplayBlueprintFunctionLibrary.__GetSkillNeedPlayMontageIndex_FunctionParams* __Params)
	{
		string skillId = FString.ToString((void*)(&__Params->skillId));
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetSkillNeedPlayMontageIndex(__Params->entityId, skillId);
	}

	// Token: 0x060181DA RID: 98778 RVA: 0x006BFA64 File Offset: 0x006BDC64
	protected unsafe static void __CPPCALL_CreateSpecifiedTagPlayMontageAndWaitAbilityTask_Implementation(TsGameplayBlueprintFunctionLibrary.__CreateSpecifiedTagPlayMontageAndWaitAbilityTask_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.CreateSpecifiedTagPlayMontageAndWaitAbilityTask(BuiltinUtils.GetOrCreateUObjectByNativePointer<GA_Base_C>(__Params->gameplayAbility), __Params->checkHit, __Params->skeletalMeshComponentTag, __Params->montageIndex, __Params->startSection, __Params->startTimeSeconds, __Params->needTick, __Params->animRootMotionTranslationScale);
	}

	// Token: 0x060181DB RID: 98779 RVA: 0x006BFAA0 File Offset: 0x006BDCA0
	protected unsafe static void __CPPCALL_SetSkillRotateLocation_Implementation(TsGameplayBlueprintFunctionLibrary.__SetSkillRotateLocation_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetSkillRotateLocation(__Params->entityId, __Params->location);
	}

	// Token: 0x060181DC RID: 98780 RVA: 0x006BFAB3 File Offset: 0x006BDCB3
	protected unsafe static void __CPPCALL_SetSkillRotateDirect_Implementation(TsGameplayBlueprintFunctionLibrary.__SetSkillRotateDirect_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetSkillRotateDirect(__Params->entityId, __Params->direct);
	}

	// Token: 0x060181DD RID: 98781 RVA: 0x006BFAC6 File Offset: 0x006BDCC6
	protected unsafe static void __CPPCALL_CallAnimBreakPoint_Implementation(TsGameplayBlueprintFunctionLibrary.__CallAnimBreakPoint_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.CallAnimBreakPoint(__Params->entityId);
	}

	// Token: 0x060181DE RID: 98782 RVA: 0x006BFAD3 File Offset: 0x006BDCD3
	protected unsafe static void __CPPCALL_RollingGround_Implementation(TsGameplayBlueprintFunctionLibrary.__RollingGround_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.RollingGround(__Params->entityId);
	}

	// Token: 0x060181DF RID: 98783 RVA: 0x006BFAE0 File Offset: 0x006BDCE0
	protected unsafe static void __CPPCALL_ActivateAbilityVision_Implementation(TsGameplayBlueprintFunctionLibrary.__ActivateAbilityVision_FunctionParams* __Params)
	{
		EVisionType visionType = (EVisionType)__Params->visionType;
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.ActivateAbilityVision(__Params->entityId, visionType);
	}

	// Token: 0x060181E0 RID: 98784 RVA: 0x006BFB08 File Offset: 0x006BDD08
	protected unsafe static void __CPPCALL_EndAbilityVision_Implementation(TsGameplayBlueprintFunctionLibrary.__EndAbilityVision_FunctionParams* __Params)
	{
		EVisionType visionType = (EVisionType)__Params->visionType;
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.EndAbilityVision(__Params->entityId, visionType);
	}

	// Token: 0x060181E1 RID: 98785 RVA: 0x006BFB30 File Offset: 0x006BDD30
	protected unsafe static void __CPPCALL_ActivateAbilityVisionPlayAudio_Implementation(TsGameplayBlueprintFunctionLibrary.__ActivateAbilityVisionPlayAudio_FunctionParams* __Params)
	{
		EVisionType visionType = (EVisionType)__Params->visionType;
		TsGameplayBlueprintFunctionLibrary.ActivateAbilityVisionPlayAudio(__Params->entityId, visionType);
	}

	// Token: 0x060181E2 RID: 98786 RVA: 0x006BFB50 File Offset: 0x006BDD50
	protected unsafe static void __CPPCALL_GetVisionIdList_Implementation(TsGameplayBlueprintFunctionLibrary.__GetVisionIdList_FunctionParams* __Params)
	{
		TArray<int> visionIdList = TsGameplayBlueprintFunctionLibrary.GetVisionIdList(__Params->entityId);
		if (visionIdList == null)
		{
			return;
		}
		visionIdList.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x060181E3 RID: 98787 RVA: 0x006BFB82 File Offset: 0x006BDD82
	protected unsafe static void __CPPCALL_ExitMultiSkillStateOfMorphVision_Implementation(TsGameplayBlueprintFunctionLibrary.__ExitMultiSkillStateOfMorphVision_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ExitMultiSkillStateOfMorphVision(__Params->entityId);
	}

	// Token: 0x060181E4 RID: 98788 RVA: 0x006BFB8F File Offset: 0x006BDD8F
	protected unsafe static void __CPPCALL_SetKeepMultiSkillState_Implementation(TsGameplayBlueprintFunctionLibrary.__SetKeepMultiSkillState_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetKeepMultiSkillState(__Params->entityId, __Params->keepOnMorphEnd, __Params->keepOnGoDown);
	}

	// Token: 0x060181E5 RID: 98789 RVA: 0x006BFBA8 File Offset: 0x006BDDA8
	protected unsafe static void __CPPCALL_SetEnableAttackInputActionOfMorphVision_Implementation(TsGameplayBlueprintFunctionLibrary.__SetEnableAttackInputActionOfMorphVision_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetEnableAttackInputActionOfMorphVision(__Params->entityId, __Params->bEnable);
	}

	// Token: 0x060181E6 RID: 98790 RVA: 0x006BFBBC File Offset: 0x006BDDBC
	protected unsafe static void __CPPCALL_GetVisionLevelList_Implementation(TsGameplayBlueprintFunctionLibrary.__GetVisionLevelList_FunctionParams* __Params)
	{
		TArray<int> visionLevelList = TsGameplayBlueprintFunctionLibrary.GetVisionLevelList(__Params->entityId);
		if (visionLevelList == null)
		{
			return;
		}
		visionLevelList.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x060181E7 RID: 98791 RVA: 0x006BFBEE File Offset: 0x006BDDEE
	protected unsafe static void __CPPCALL_GetVisionSkillId_Implementation(TsGameplayBlueprintFunctionLibrary.__GetVisionSkillId_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetVisionSkillId(__Params->entityId, __Params->visionId, __Params->level);
	}

	// Token: 0x060181E8 RID: 98792 RVA: 0x006BFC10 File Offset: 0x006BDE10
	protected unsafe static void __CPPCALL_InterruptSkill_Implementation(TsGameplayBlueprintFunctionLibrary.__InterruptSkill_FunctionParams* __Params)
	{
		string skillId = FString.ToString((void*)(&__Params->skillId));
		TsGameplayBlueprintFunctionLibrary.InterruptSkill(__Params->entityId, skillId, __Params->isSyn);
	}

	// Token: 0x060181E9 RID: 98793 RVA: 0x006BFC3C File Offset: 0x006BDE3C
	protected unsafe static void __CPPCALL_DeleteSkills_Implementation(TsGameplayBlueprintFunctionLibrary.__DeleteSkills_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.DeleteSkills(__Params->entityId);
	}

	// Token: 0x060181EA RID: 98794 RVA: 0x006BFC49 File Offset: 0x006BDE49
	protected unsafe static void __CPPCALL_GetCurrentMontageCorrespondingSkillId_Implementation(TsGameplayBlueprintFunctionLibrary.__GetCurrentMontageCorrespondingSkillId_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetCurrentMontageCorrespondingSkillId(__Params->entityId));
	}

	// Token: 0x060181EB RID: 98795 RVA: 0x006BFC64 File Offset: 0x006BDE64
	protected unsafe static void __CPPCALL_SetSocketName_Implementation(TsGameplayBlueprintFunctionLibrary.__SetSocketName_FunctionParams* __Params)
	{
		string socketName = FString.ToString((void*)(&__Params->socketName));
		TsGameplayBlueprintFunctionLibrary.SetSocketName(__Params->entityId, socketName);
	}

	// Token: 0x060181EC RID: 98796 RVA: 0x006BFC8A File Offset: 0x006BDE8A
	protected unsafe static void __CPPCALL_GetSocketName_Implementation(TsGameplayBlueprintFunctionLibrary.__GetSocketName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetSocketName(__Params->entityId));
	}

	// Token: 0x060181ED RID: 98797 RVA: 0x006BFCA4 File Offset: 0x006BDEA4
	protected unsafe static void __CPPCALL_GetPointTransform_Implementation(TsGameplayBlueprintFunctionLibrary.__GetPointTransform_FunctionParams* __Params)
	{
		string boneName = FString.ToString((void*)(&__Params->boneName));
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetPointTransform(__Params->entityId, boneName);
	}

	// Token: 0x060181EE RID: 98798 RVA: 0x006BFCD0 File Offset: 0x006BDED0
	protected unsafe static void __CPPCALL_PlaySkillMontage2Server_Implementation(TsGameplayBlueprintFunctionLibrary.__PlaySkillMontage2Server_FunctionParams* __Params)
	{
		string skillId = FString.ToString((void*)(&__Params->skillId));
		string startSection = FString.ToString((void*)(&__Params->startSection));
		TsGameplayBlueprintFunctionLibrary.PlaySkillMontage2Server(__Params->entityId, skillId, __Params->montageIndex, __Params->rate, startSection, __Params->startTimeSeconds);
	}

	// Token: 0x060181EF RID: 98799 RVA: 0x006BFD18 File Offset: 0x006BDF18
	protected unsafe static void __CPPCALL_EndSkillMontage_Implementation(TsGameplayBlueprintFunctionLibrary.__EndSkillMontage_FunctionParams* __Params)
	{
		string skillId = FString.ToString((void*)(&__Params->skillId));
		TsGameplayBlueprintFunctionLibrary.EndSkillMontage(__Params->entityId, skillId, __Params->montageIndex);
	}

	// Token: 0x060181F0 RID: 98800 RVA: 0x006BFD44 File Offset: 0x006BDF44
	protected unsafe static void __CPPCALL_BeginAddMoveByInputDirect_Implementation(TsGameplayBlueprintFunctionLibrary.__BeginAddMoveByInputDirect_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.BeginAddMoveByInputDirect(__Params->entityId, __Params->maxSpeed, __Params->accelerationTime, __Params->decelerationTime, __Params->delayTime);
	}

	// Token: 0x060181F1 RID: 98801 RVA: 0x006BFD69 File Offset: 0x006BDF69
	protected unsafe static void __CPPCALL_BeginAbsoluteTimeStop_Implementation(TsGameplayBlueprintFunctionLibrary.__BeginAbsoluteTimeStop_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.BeginAbsoluteTimeStop(__Params->entityId, __Params->duration, __Params->stopMove);
	}

	// Token: 0x060181F2 RID: 98802 RVA: 0x006BFD82 File Offset: 0x006BDF82
	protected unsafe static void __CPPCALL_EndAbsoluteTimeStop_Implementation(TsGameplayBlueprintFunctionLibrary.__EndAbsoluteTimeStop_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.EndAbsoluteTimeStop(__Params->entityId);
	}

	// Token: 0x060181F3 RID: 98803 RVA: 0x006BFD8F File Offset: 0x006BDF8F
	protected unsafe static void __CPPCALL_BeginTimeStopRequest_Implementation(TsGameplayBlueprintFunctionLibrary.__BeginTimeStopRequest_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.BeginTimeStopRequest(__Params->entityId, __Params->duration);
	}

	// Token: 0x060181F4 RID: 98804 RVA: 0x006BFDA2 File Offset: 0x006BDFA2
	protected unsafe static void __CPPCALL_EndTimeStopRequest_Implementation(TsGameplayBlueprintFunctionLibrary.__EndTimeStopRequest_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.EndTimeStopRequest(__Params->entityId);
	}

	// Token: 0x060181F5 RID: 98805 RVA: 0x006BFDAF File Offset: 0x006BDFAF
	protected unsafe static void __CPPCALL_EndAddMoveByInputDirect_Implementation(TsGameplayBlueprintFunctionLibrary.__EndAddMoveByInputDirect_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.EndAddMoveByInputDirect(__Params->entityId);
	}

	// Token: 0x060181F6 RID: 98806 RVA: 0x006BFDBC File Offset: 0x006BDFBC
	protected unsafe static void __CPPCALL_CanActivateFixHook_Implementation(TsGameplayBlueprintFunctionLibrary.__CanActivateFixHook_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.CanActivateFixHook(__Params->entityId);
	}

	// Token: 0x060181F7 RID: 98807 RVA: 0x006BFDCF File Offset: 0x006BDFCF
	protected unsafe static void __CPPCALL_FixHookTargetLocation_Implementation(TsGameplayBlueprintFunctionLibrary.__FixHookTargetLocation_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.FixHookTargetLocation(__Params->entityId);
	}

	// Token: 0x060181F8 RID: 98808 RVA: 0x006BFDE4 File Offset: 0x006BDFE4
	protected unsafe static void __CPPCALL_FixHookTargetPathways_Implementation(TsGameplayBlueprintFunctionLibrary.__FixHookTargetPathways_FunctionParams* __Params)
	{
		TArray<FVectorDouble> tarray = TsGameplayBlueprintFunctionLibrary.FixHookTargetPathways(__Params->entityId);
		if (tarray == null)
		{
			return;
		}
		tarray.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x060181F9 RID: 98809 RVA: 0x006BFE16 File Offset: 0x006BE016
	protected unsafe static void __CPPCALL_FixHookTargetEnterPortalCapture_Implementation(TsGameplayBlueprintFunctionLibrary.__FixHookTargetEnterPortalCapture_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		AActor aactor = TsGameplayBlueprintFunctionLibrary.FixHookTargetEnterPortalCapture(__Params->entityId);
		ptr = ((aactor != null) ? aactor.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060181FA RID: 98810 RVA: 0x006BFE38 File Offset: 0x006BE038
	protected unsafe static void __CPPCALL_FixHookTargetActor_Implementation(TsGameplayBlueprintFunctionLibrary.__FixHookTargetActor_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		AActor aactor = TsGameplayBlueprintFunctionLibrary.FixHookTargetActor(__Params->entityId);
		ptr = ((aactor != null) ? aactor.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060181FB RID: 98811 RVA: 0x006BFE5A File Offset: 0x006BE05A
	protected unsafe static void __CPPCALL_FixHookTargetIsSuiGuangType_Implementation(TsGameplayBlueprintFunctionLibrary.__FixHookTargetIsSuiGuangType_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.FixHookTargetIsSuiGuangType(__Params->entityId);
	}

	// Token: 0x060181FC RID: 98812 RVA: 0x006BFE6D File Offset: 0x006BE06D
	protected unsafe static void __CPPCALL_GetHookTargetType_Implementation(TsGameplayBlueprintFunctionLibrary.__GetHookTargetType_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)TsGameplayBlueprintFunctionLibrary.GetHookTargetType(__Params->entityId);
	}

	// Token: 0x060181FD RID: 98813 RVA: 0x006BFE82 File Offset: 0x006BE082
	protected unsafe static void __CPPCALL_FixHookTargetForward_Implementation(TsGameplayBlueprintFunctionLibrary.__FixHookTargetForward_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.FixHookTargetForward(__Params->entityId);
	}

	// Token: 0x060181FE RID: 98814 RVA: 0x006BFE95 File Offset: 0x006BE095
	protected unsafe static void __CPPCALL_NextFixHookTargetLocation_Implementation(TsGameplayBlueprintFunctionLibrary.__NextFixHookTargetLocation_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.NextFixHookTargetLocation(__Params->entityId);
	}

	// Token: 0x060181FF RID: 98815 RVA: 0x006BFEA8 File Offset: 0x006BE0A8
	protected unsafe static void __CPPCALL_FixHookTargetInheritSpeed_Implementation(TsGameplayBlueprintFunctionLibrary.__FixHookTargetInheritSpeed_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.FixHookTargetInheritSpeed(__Params->entityId);
	}

	// Token: 0x06018200 RID: 98816 RVA: 0x006BFEBB File Offset: 0x006BE0BB
	protected unsafe static void __CPPCALL_FixHookTargetIsClimb_Implementation(TsGameplayBlueprintFunctionLibrary.__FixHookTargetIsClimb_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.FixHookTargetIsClimb(__Params->entityId);
	}

	// Token: 0x06018201 RID: 98817 RVA: 0x006BFECE File Offset: 0x006BE0CE
	protected unsafe static void __CPPCALL_SetIsHookEndByInterrupt_Implementation(TsGameplayBlueprintFunctionLibrary.__SetIsHookEndByInterrupt_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetIsHookEndByInterrupt(__Params->entityId, __Params->isInterrupt);
	}

	// Token: 0x06018202 RID: 98818 RVA: 0x006BFEE1 File Offset: 0x006BE0E1
	protected unsafe static void __CPPCALL_FixHookIsSummitPoint_Implementation(TsGameplayBlueprintFunctionLibrary.__FixHookIsSummitPoint_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.FixHookIsSummitPoint(__Params->entityId);
	}

	// Token: 0x06018203 RID: 98819 RVA: 0x006BFEF4 File Offset: 0x006BE0F4
	protected unsafe static void __CPPCALL_FixHookIsNormalPoint_Implementation(TsGameplayBlueprintFunctionLibrary.__FixHookIsNormalPoint_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.FixHookIsNormalPoint(__Params->entityId);
	}

	// Token: 0x06018204 RID: 98820 RVA: 0x006BFF07 File Offset: 0x006BE107
	protected unsafe static void __CPPCALL_GetHookOverrideSpeed_Implementation(TsGameplayBlueprintFunctionLibrary.__GetHookOverrideSpeed_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetHookOverrideSpeed(__Params->entityId);
	}

	// Token: 0x06018205 RID: 98821 RVA: 0x006BFF1A File Offset: 0x006BE11A
	protected unsafe static void __CPPCALL_FixHookIsGravityPoint_Implementation(TsGameplayBlueprintFunctionLibrary.__FixHookIsGravityPoint_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.FixHookIsGravityPoint(__Params->entityId);
	}

	// Token: 0x06018206 RID: 98822 RVA: 0x006BFF2D File Offset: 0x006BE12D
	protected unsafe static void __CPPCALL_FixHookTargetEntityId_Implementation(TsGameplayBlueprintFunctionLibrary.__FixHookTargetEntityId_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.FixHookTargetEntityId(__Params->entityId);
	}

	// Token: 0x06018207 RID: 98823 RVA: 0x006BFF40 File Offset: 0x006BE140
	protected unsafe static void __CPPCALL_SlashHookPointHasLookAtConfig_Implementation(TsGameplayBlueprintFunctionLibrary.__SlashHookPointHasLookAtConfig_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.SlashHookPointHasLookAtConfig(__Params->entityId);
	}

	// Token: 0x06018208 RID: 98824 RVA: 0x006BFF53 File Offset: 0x006BE153
	protected unsafe static void __CPPCALL_SlashHookPointCharacterLookAtPoint_Implementation(TsGameplayBlueprintFunctionLibrary.__SlashHookPointCharacterLookAtPoint_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.SlashHookPointCharacterLookAtPoint(__Params->entityId);
	}

	// Token: 0x06018209 RID: 98825 RVA: 0x006BFF66 File Offset: 0x006BE166
	protected unsafe static void __CPPCALL_SlashHookPointIsTakeOverCamera_Implementation(TsGameplayBlueprintFunctionLibrary.__SlashHookPointIsTakeOverCamera_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.SlashHookPointIsTakeOverCamera(__Params->entityId);
	}

	// Token: 0x0601820A RID: 98826 RVA: 0x006BFF79 File Offset: 0x006BE179
	protected unsafe static void __CPPCALL_SlashHookPointSafePointLoc_Implementation(TsGameplayBlueprintFunctionLibrary.__SlashHookPointSafePointLoc_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.SlashHookPointSafePointLoc(__Params->entityId);
	}

	// Token: 0x0601820B RID: 98827 RVA: 0x006BFF8C File Offset: 0x006BE18C
	protected unsafe static void __CPPCALL_SlashHookPointSafePointRot_Implementation(TsGameplayBlueprintFunctionLibrary.__SlashHookPointSafePointRot_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.SlashHookPointSafePointRot(__Params->entityId);
	}

	// Token: 0x0601820C RID: 98828 RVA: 0x006BFF9F File Offset: 0x006BE19F
	protected unsafe static void __CPPCALL_StartChargeSlash_Implementation(TsGameplayBlueprintFunctionLibrary.__StartChargeSlash_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.StartChargeSlash(__Params->entityId);
	}

	// Token: 0x0601820D RID: 98829 RVA: 0x006BFFAC File Offset: 0x006BE1AC
	protected unsafe static void __CPPCALL_StopChargeSlash_Implementation(TsGameplayBlueprintFunctionLibrary.__StopChargeSlash_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.StopChargeSlash(__Params->entityId);
	}

	// Token: 0x0601820E RID: 98830 RVA: 0x006BFFB9 File Offset: 0x006BE1B9
	protected unsafe static void __CPPCALL_IsSlashGameplayIsSuccess_Implementation(TsGameplayBlueprintFunctionLibrary.__IsSlashGameplayIsSuccess_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.IsSlashGameplayIsSuccess();
	}

	// Token: 0x0601820F RID: 98831 RVA: 0x006BFFC6 File Offset: 0x006BE1C6
	protected unsafe static void __CPPCALL_GetGravityHookLockInfo_Implementation(TsGameplayBlueprintFunctionLibrary.__GetGravityHookLockInfo_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetGravityHookLockInfo(__Params->entityId);
	}

	// Token: 0x06018210 RID: 98832 RVA: 0x006BFFD9 File Offset: 0x006BE1D9
	protected unsafe static void __CPPCALL_ChangeGravityByHook_Implementation(TsGameplayBlueprintFunctionLibrary.__ChangeGravityByHook_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ChangeGravityByHook(__Params->entityId, __Params->angleRangeMin, __Params->angleRangeMax, __Params->smoothSecondMin, __Params->smoothSecondMax, __Params->isLerpCamera);
	}

	// Token: 0x06018211 RID: 98833 RVA: 0x006C0004 File Offset: 0x006BE204
	protected unsafe static void __CPPCALL_SetIgnoreSocketName_Implementation(TsGameplayBlueprintFunctionLibrary.__SetIgnoreSocketName_FunctionParams* __Params)
	{
		string socketName = FString.ToString((void*)(&__Params->socketName));
		TsGameplayBlueprintFunctionLibrary.SetIgnoreSocketName(__Params->entityId, socketName);
	}

	// Token: 0x06018212 RID: 98834 RVA: 0x006C002C File Offset: 0x006BE22C
	protected unsafe static void __CPPCALL_DeleteIgnoreSocketName_Implementation(TsGameplayBlueprintFunctionLibrary.__DeleteIgnoreSocketName_FunctionParams* __Params)
	{
		string socketName = FString.ToString((void*)(&__Params->socketName));
		TsGameplayBlueprintFunctionLibrary.DeleteIgnoreSocketName(__Params->entityId, socketName);
	}

	// Token: 0x06018213 RID: 98835 RVA: 0x006C0052 File Offset: 0x006BE252
	protected unsafe static void __CPPCALL_GetToTargetSocketDistance_Implementation(TsGameplayBlueprintFunctionLibrary.__GetToTargetSocketDistance_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetToTargetSocketDistance(__Params->entityId);
	}

	// Token: 0x06018214 RID: 98836 RVA: 0x006C0068 File Offset: 0x006BE268
	protected unsafe static void __CPPCALL_SetPredictProjectileInfo_Implementation(TsGameplayBlueprintFunctionLibrary.__SetPredictProjectileInfo_FunctionParams* __Params)
	{
		TArray<FVector> tarray = new TArray<FVector>(&__Params->outPathPosition, true, true);
		FHitResult outHit = new FHitResult(&__Params->outHit, true, true);
		TsGameplayBlueprintFunctionLibrary.SetPredictProjectileInfo(__Params->entityId, __Params->returnValue, ref tarray, __Params->outLastTraceDestination, outHit);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->outPathPosition, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x06018215 RID: 98837 RVA: 0x006C00C6 File Offset: 0x006BE2C6
	protected unsafe static void __CPPCALL_SetVisible_Implementation(TsGameplayBlueprintFunctionLibrary.__SetVisible_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetVisible(__Params->entityId, __Params->isShow);
	}

	// Token: 0x06018216 RID: 98838 RVA: 0x006C00D9 File Offset: 0x006BE2D9
	protected unsafe static void __CPPCALL_GetCharUnifiedMoveState_Implementation(TsGameplayBlueprintFunctionLibrary.__GetCharUnifiedMoveState_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)TsGameplayBlueprintFunctionLibrary.GetCharUnifiedMoveState(__Params->entityId);
	}

	// Token: 0x06018217 RID: 98839 RVA: 0x006C00EE File Offset: 0x006BE2EE
	protected unsafe static void __CPPCALL_GetCharUnifiedPositionState_Implementation(TsGameplayBlueprintFunctionLibrary.__GetCharUnifiedPositionState_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)TsGameplayBlueprintFunctionLibrary.GetCharUnifiedPositionState(__Params->entityId);
	}

	// Token: 0x06018218 RID: 98840 RVA: 0x006C0103 File Offset: 0x006BE303
	protected unsafe static void __CPPCALL_ExitHitState_Implementation(TsGameplayBlueprintFunctionLibrary.__ExitHitState_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ExitHitState(__Params->entityId);
	}

	// Token: 0x06018219 RID: 98841 RVA: 0x006C0110 File Offset: 0x006BE310
	protected unsafe static void __CPPCALL_SetDirectionState_Implementation(TsGameplayBlueprintFunctionLibrary.__SetDirectionState_FunctionParams* __Params)
	{
		ECharViewDirectionState newViewState = (ECharViewDirectionState)__Params->newViewState;
		TsGameplayBlueprintFunctionLibrary.SetDirectionState(__Params->entityId, newViewState);
	}

	// Token: 0x0601821A RID: 98842 RVA: 0x006C0130 File Offset: 0x006BE330
	protected unsafe static void __CPPCALL_GetDirectionState_Implementation(TsGameplayBlueprintFunctionLibrary.__GetDirectionState_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)TsGameplayBlueprintFunctionLibrary.GetDirectionState(__Params->entityId);
	}

	// Token: 0x0601821B RID: 98843 RVA: 0x006C0145 File Offset: 0x006BE345
	protected unsafe static void __CPPCALL_GetIsInGame_Implementation(TsGameplayBlueprintFunctionLibrary.__GetIsInGame_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetIsInGame(__Params->entityId);
	}

	// Token: 0x0601821C RID: 98844 RVA: 0x006C0158 File Offset: 0x006BE358
	protected unsafe static void __CPPCALL_SprintPress_Implementation(TsGameplayBlueprintFunctionLibrary.__SprintPress_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SprintPress(__Params->entityId);
	}

	// Token: 0x0601821D RID: 98845 RVA: 0x006C0165 File Offset: 0x006BE365
	protected unsafe static void __CPPCALL_SprintRelease_Implementation(TsGameplayBlueprintFunctionLibrary.__SprintRelease_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SprintRelease(__Params->entityId);
	}

	// Token: 0x0601821E RID: 98846 RVA: 0x006C0172 File Offset: 0x006BE372
	protected unsafe static void __CPPCALL_StandPress_Implementation(TsGameplayBlueprintFunctionLibrary.__StandPress_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.StandPress(__Params->entityId);
	}

	// Token: 0x0601821F RID: 98847 RVA: 0x006C017F File Offset: 0x006BE37F
	protected unsafe static void __CPPCALL_SwingPress_Implementation(TsGameplayBlueprintFunctionLibrary.__SwingPress_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SwingPress(__Params->entityId);
	}

	// Token: 0x06018220 RID: 98848 RVA: 0x006C018C File Offset: 0x006BE38C
	protected unsafe static void __CPPCALL_SwingRelease_Implementation(TsGameplayBlueprintFunctionLibrary.__SwingRelease_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SwingRelease(__Params->entityId);
	}

	// Token: 0x06018221 RID: 98849 RVA: 0x006C0199 File Offset: 0x006BE399
	protected unsafe static void __CPPCALL_CustomSetWalkOrRun_Implementation(TsGameplayBlueprintFunctionLibrary.__CustomSetWalkOrRun_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.CustomSetWalkOrRun(__Params->entityId, __Params->isWalk);
	}

	// Token: 0x06018222 RID: 98850 RVA: 0x006C01AC File Offset: 0x006BE3AC
	protected unsafe static void __CPPCALL_EnterAimStatus_Implementation(TsGameplayBlueprintFunctionLibrary.__EnterAimStatus_FunctionParams* __Params)
	{
		EAimViewState aimViewState = (EAimViewState)__Params->aimViewState;
		TsGameplayBlueprintFunctionLibrary.EnterAimStatus(__Params->entityId, aimViewState);
	}

	// Token: 0x06018223 RID: 98851 RVA: 0x006C01CC File Offset: 0x006BE3CC
	protected unsafe static void __CPPCALL_ExitAimStatus_Implementation(TsGameplayBlueprintFunctionLibrary.__ExitAimStatus_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ExitAimStatus(__Params->entityId);
	}

	// Token: 0x06018224 RID: 98852 RVA: 0x006C01D9 File Offset: 0x006BE3D9
	protected unsafe static void __CPPCALL_EnableEntity_Implementation(TsGameplayBlueprintFunctionLibrary.__EnableEntity_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.EnableEntity(__Params->entityId, __Params->isEnable);
	}

	// Token: 0x06018225 RID: 98853 RVA: 0x006C01EC File Offset: 0x006BE3EC
	protected unsafe static void __CPPCALL_UpdateAnimInfoHit_Implementation(TsGameplayBlueprintFunctionLibrary.__UpdateAnimInfoHit_FunctionParams* __Params)
	{
		BP_ABPLogicParams_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_ABPLogicParams_C>(__Params->animLogicParams);
		TsGameplayBlueprintFunctionLibrary.UpdateAnimInfoHit(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x06018226 RID: 98854 RVA: 0x006C0214 File Offset: 0x006BE414
	protected unsafe static void __CPPCALL_UpdateAnimInfoFk_Implementation(TsGameplayBlueprintFunctionLibrary.__UpdateAnimInfoFk_FunctionParams* __Params)
	{
		BP_ABPLogicParams_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_ABPLogicParams_C>(__Params->animLogicParams);
		TsGameplayBlueprintFunctionLibrary.UpdateAnimInfoFk(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x06018227 RID: 98855 RVA: 0x006C023C File Offset: 0x006BE43C
	protected unsafe static void __CPPCALL_UpdateAnimInfoUnifiedState_Implementation(TsGameplayBlueprintFunctionLibrary.__UpdateAnimInfoUnifiedState_FunctionParams* __Params)
	{
		BP_ABPLogicParams_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_ABPLogicParams_C>(__Params->animLogicParams);
		TsGameplayBlueprintFunctionLibrary.UpdateAnimInfoUnifiedState(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x06018228 RID: 98856 RVA: 0x006C0264 File Offset: 0x006BE464
	protected unsafe static void __CPPCALL_UpdateAnimInfoUnifiedStateRoleNpc_Implementation(TsGameplayBlueprintFunctionLibrary.__UpdateAnimInfoUnifiedStateRoleNpc_FunctionParams* __Params)
	{
		BP_ABPLogicParams_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_ABPLogicParams_C>(__Params->animLogicParams);
		TsGameplayBlueprintFunctionLibrary.UpdateAnimInfoUnifiedStateRoleNpc(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x06018229 RID: 98857 RVA: 0x006C0289 File Offset: 0x006BE489
	protected unsafe static void __CPPCALL_GetIsCharRotateWithCameraWhenManipulate_Implementation(TsGameplayBlueprintFunctionLibrary.__GetIsCharRotateWithCameraWhenManipulate_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetIsCharRotateWithCameraWhenManipulate(__Params->entityId);
	}

	// Token: 0x0601822A RID: 98858 RVA: 0x006C029C File Offset: 0x006BE49C
	protected unsafe static void __CPPCALL_GetIsUseCatapultUpAnim_Implementation(TsGameplayBlueprintFunctionLibrary.__GetIsUseCatapultUpAnim_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetIsUseCatapultUpAnim(__Params->entityId);
	}

	// Token: 0x0601822B RID: 98859 RVA: 0x006C02AF File Offset: 0x006BE4AF
	protected unsafe static void __CPPCALL_GetNextMultiSkillId_Implementation(TsGameplayBlueprintFunctionLibrary.__GetNextMultiSkillId_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetNextMultiSkillId(__Params->entityId, __Params->skillId);
	}

	// Token: 0x0601822C RID: 98860 RVA: 0x006C02C8 File Offset: 0x006BE4C8
	protected unsafe static void __CPPCALL_GetNextMultiSkillIdNew_Implementation(TsGameplayBlueprintFunctionLibrary.__GetNextMultiSkillIdNew_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetNextMultiSkillIdNew(__Params->entityId, __Params->skillId);
	}

	// Token: 0x0601822D RID: 98861 RVA: 0x006C02E1 File Offset: 0x006BE4E1
	protected unsafe static void __CPPCALL_GetManipulateInteractTargetCanInteract_Implementation(TsGameplayBlueprintFunctionLibrary.__GetManipulateInteractTargetCanInteract_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetManipulateInteractTargetCanInteract(__Params->entityId);
	}

	// Token: 0x0601822E RID: 98862 RVA: 0x006C02F4 File Offset: 0x006BE4F4
	protected unsafe static void __CPPCALL_GetHookInteractTargetCanInteract_Implementation(TsGameplayBlueprintFunctionLibrary.__GetHookInteractTargetCanInteract_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetHookInteractTargetCanInteract(__Params->entityId);
	}

	// Token: 0x0601822F RID: 98863 RVA: 0x006C0307 File Offset: 0x006BE507
	protected unsafe static void __CPPCALL_GetHookInteractTargetIsIgnorePlayerCollision_Implementation(TsGameplayBlueprintFunctionLibrary.__GetHookInteractTargetIsIgnorePlayerCollision_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetHookInteractTargetIsIgnorePlayerCollision(__Params->entityId);
	}

	// Token: 0x06018230 RID: 98864 RVA: 0x006C031A File Offset: 0x006BE51A
	protected unsafe static void __CPPCALL_StartManipulateInteract_Implementation(TsGameplayBlueprintFunctionLibrary.__StartManipulateInteract_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.StartManipulateInteract(__Params->entityId);
	}

	// Token: 0x06018231 RID: 98865 RVA: 0x006C032D File Offset: 0x006BE52D
	protected unsafe static void __CPPCALL_EndManipulateInteract_Implementation(TsGameplayBlueprintFunctionLibrary.__EndManipulateInteract_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.EndManipulateInteract(__Params->entityId);
	}

	// Token: 0x06018232 RID: 98866 RVA: 0x006C033A File Offset: 0x006BE53A
	protected unsafe static void __CPPCALL_StartStatueInteract_Implementation(TsGameplayBlueprintFunctionLibrary.__StartStatueInteract_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.StartStatueInteract(__Params->entityId);
	}

	// Token: 0x06018233 RID: 98867 RVA: 0x006C034D File Offset: 0x006BE54D
	protected unsafe static void __CPPCALL_EndStatueInteract_Implementation(TsGameplayBlueprintFunctionLibrary.__EndStatueInteract_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.EndStatueInteract(__Params->entityId);
	}

	// Token: 0x06018234 RID: 98868 RVA: 0x006C035A File Offset: 0x006BE55A
	protected unsafe static void __CPPCALL_StartCustomInteract_Implementation(TsGameplayBlueprintFunctionLibrary.__StartCustomInteract_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.StartCustomInteract(__Params->entityId);
	}

	// Token: 0x06018235 RID: 98869 RVA: 0x006C036D File Offset: 0x006BE56D
	protected unsafe static void __CPPCALL_EndCustomInteract_Implementation(TsGameplayBlueprintFunctionLibrary.__EndCustomInteract_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.EndCustomInteract(__Params->entityId);
	}

	// Token: 0x06018236 RID: 98870 RVA: 0x006C037A File Offset: 0x006BE57A
	protected unsafe static void __CPPCALL_QuantumDiffusionInteract_Implementation(TsGameplayBlueprintFunctionLibrary.__QuantumDiffusionInteract_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.QuantumDiffusionInteract(__Params->entityId);
	}

	// Token: 0x06018237 RID: 98871 RVA: 0x006C0388 File Offset: 0x006BE588
	protected unsafe static void __CPPCALL_GetShootSwordManipulateInteractActors_Implementation(TsGameplayBlueprintFunctionLibrary.__GetShootSwordManipulateInteractActors_FunctionParams* __Params)
	{
		TArray<AActor> shootSwordManipulateInteractActors = TsGameplayBlueprintFunctionLibrary.GetShootSwordManipulateInteractActors(__Params->entityId);
		if (shootSwordManipulateInteractActors == null)
		{
			return;
		}
		shootSwordManipulateInteractActors.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x06018238 RID: 98872 RVA: 0x006C03BA File Offset: 0x006BE5BA
	protected unsafe static void __CPPCALL_GetManipulateInteractLocation_Implementation(TsGameplayBlueprintFunctionLibrary.__GetManipulateInteractLocation_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetManipulateInteractLocation(__Params->entityId);
	}

	// Token: 0x06018239 RID: 98873 RVA: 0x006C03CD File Offset: 0x006BE5CD
	protected unsafe static void __CPPCALL_EnvironmentInfoDetect_Implementation(TsGameplayBlueprintFunctionLibrary.__EnvironmentInfoDetect_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.EnvironmentInfoDetect(__Params->entityId, __Params->location);
	}

	// Token: 0x0601823A RID: 98874 RVA: 0x006C03E0 File Offset: 0x006BE5E0
	protected unsafe static void __CPPCALL_LockOnSpecifyTarget_Implementation(TsGameplayBlueprintFunctionLibrary.__LockOnSpecifyTarget_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.LockOnSpecifyTarget(__Params->entityId, __Params->targetEntityId);
	}

	// Token: 0x0601823B RID: 98875 RVA: 0x006C03F3 File Offset: 0x006BE5F3
	protected unsafe static void __CPPCALL_IsSkillInCd_Implementation(TsGameplayBlueprintFunctionLibrary.__IsSkillInCd_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.IsSkillInCd(__Params->entityId, __Params->skillId);
	}

	// Token: 0x0601823C RID: 98876 RVA: 0x006C040C File Offset: 0x006BE60C
	protected unsafe static void __CPPCALL_SendHookSkillUseLogData_Implementation(TsGameplayBlueprintFunctionLibrary.__SendHookSkillUseLogData_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SendHookSkillUseLogData(__Params->entityId, __Params->hasTarget);
	}

	// Token: 0x0601823D RID: 98877 RVA: 0x006C041F File Offset: 0x006BE61F
	protected unsafe static void __CPPCALL_SendManipulateSkillUseLogData_Implementation(TsGameplayBlueprintFunctionLibrary.__SendManipulateSkillUseLogData_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SendManipulateSkillUseLogData(__Params->entityId, __Params->hasTarget);
	}

	// Token: 0x0601823E RID: 98878 RVA: 0x006C0432 File Offset: 0x006BE632
	protected unsafe static void __CPPCALL_SendScanSkillUseLogData_Implementation(TsGameplayBlueprintFunctionLibrary.__SendScanSkillUseLogData_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SendScanSkillUseLogData(__Params->entityId, __Params->hasTarget);
	}

	// Token: 0x0601823F RID: 98879 RVA: 0x006C0445 File Offset: 0x006BE645
	protected unsafe static void __CPPCALL_DynamicAttachEntityToActor_Implementation(TsGameplayBlueprintFunctionLibrary.__DynamicAttachEntityToActor_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.DynamicAttachEntityToActor(__Params->entityId, __Params->targetEntityId, __Params->socketName);
	}

	// Token: 0x06018240 RID: 98880 RVA: 0x006C0460 File Offset: 0x006BE660
	protected unsafe static void __CPPCALL_SetEntityEnable_Implementation(TsGameplayBlueprintFunctionLibrary.__SetEntityEnable_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->callObject);
		string reason = FString.ToString((void*)(&__Params->reason));
		TsGameplayBlueprintFunctionLibrary.SetEntityEnable(__Params->entityId, __Params->enable, orCreateUObjectByNativePointer, reason);
	}

	// Token: 0x06018241 RID: 98881 RVA: 0x006C049C File Offset: 0x006BE69C
	protected unsafe static void __CPPCALL_SetActorVisible_Implementation(TsGameplayBlueprintFunctionLibrary.__SetActorVisible_FunctionParams* __Params)
	{
		string reason = FString.ToString((void*)(&__Params->reason));
		TsGameplayBlueprintFunctionLibrary.SetActorVisible(__Params->entityId, __Params->visible, __Params->collision, __Params->movable, reason, __Params->sync);
	}

	// Token: 0x06018242 RID: 98882 RVA: 0x006C04DC File Offset: 0x006BE6DC
	protected unsafe static void __CPPCALL_SetSkillTargetDirection_Implementation(TsGameplayBlueprintFunctionLibrary.__SetSkillTargetDirection_FunctionParams* __Params)
	{
		ESkillTargetDirection direction = (ESkillTargetDirection)__Params->direction;
		TsGameplayBlueprintFunctionLibrary.SetSkillTargetDirection(__Params->entityId, direction);
	}

	// Token: 0x06018243 RID: 98883 RVA: 0x006C04FC File Offset: 0x006BE6FC
	protected unsafe static void __CPPCALL_ChangeAiControllerDebugDraw_Implementation(TsGameplayBlueprintFunctionLibrary.__ChangeAiControllerDebugDraw_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.ChangeAiControllerDebugDraw(__Params->entityId, __Params->debug);
	}

	// Token: 0x06018244 RID: 98884 RVA: 0x006C050F File Offset: 0x006BE70F
	protected unsafe static void __CPPCALL_GetBeHitAnimType_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBeHitAnimType_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)TsGameplayBlueprintFunctionLibrary.GetBeHitAnimType(__Params->typeId);
	}

	// Token: 0x06018245 RID: 98885 RVA: 0x006C0524 File Offset: 0x006BE724
	protected unsafe static void __CPPCALL_StartInhalation_Implementation(TsGameplayBlueprintFunctionLibrary.__StartInhalation_FunctionParams* __Params)
	{
		TArray<FGameplayTag> tarray = new TArray<FGameplayTag>(&__Params->tag, true, true);
		TsGameplayBlueprintFunctionLibrary.StartInhalation(__Params->entityId, __Params->strength, __Params->distance, __Params->isPowerfulMode, __Params->checkAngle, ref tarray);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->tag, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x06018246 RID: 98886 RVA: 0x006C057E File Offset: 0x006BE77E
	protected unsafe static void __CPPCALL_StopInhalation_Implementation(TsGameplayBlueprintFunctionLibrary.__StopInhalation_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.StopInhalation(__Params->entityId);
	}

	// Token: 0x06018247 RID: 98887 RVA: 0x006C058C File Offset: 0x006BE78C
	protected unsafe static void __CPPCALL_TryGetDebugMovementComp_Implementation(TsGameplayBlueprintFunctionLibrary.__TryGetDebugMovementComp_FunctionParams* __Params)
	{
		string pbDataId = FString.ToString((void*)(&__Params->pbDataId));
		ref IntPtr ptr = ref *(&__Params->__Result);
		UKuroDebugMovementComponent ukuroDebugMovementComponent = TsGameplayBlueprintFunctionLibrary.TryGetDebugMovementComp(pbDataId);
		ptr = ((ukuroDebugMovementComponent != null) ? ukuroDebugMovementComponent.NativePtr : ((IntPtr)0));
	}

	// Token: 0x06018248 RID: 98888 RVA: 0x006C05C1 File Offset: 0x006BE7C1
	protected unsafe static void __CPPCALL_TryPlayLinkAnim_Implementation(TsGameplayBlueprintFunctionLibrary.__TryPlayLinkAnim_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.TryPlayLinkAnim();
	}

	// Token: 0x06018249 RID: 98889 RVA: 0x006C05C8 File Offset: 0x006BE7C8
	protected unsafe static void __CPPCALL_TraceGround_Implementation(TsGameplayBlueprintFunctionLibrary.__TraceGround_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.TraceGround(__Params->entityId, __Params->start, __Params->end, __Params->draw);
	}

	// Token: 0x0601824A RID: 98890 RVA: 0x006C05F0 File Offset: 0x006BE7F0
	protected unsafe static void __CPPCALL_ChangePhantomTeam_Implementation(TsGameplayBlueprintFunctionLibrary.__ChangePhantomTeam_FunctionParams* __Params)
	{
		TArray<FGameplayTag> tarray = new TArray<FGameplayTag>(&__Params->skillTriggerTags, true, true);
		TsGameplayBlueprintFunctionLibrary.ChangePhantomTeam(__Params->phantomFormationId, ref tarray);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->skillTriggerTags, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x0601824B RID: 98891 RVA: 0x006C0632 File Offset: 0x006BE832
	protected unsafe static void __CPPCALL_RevertPhantomTeam_Implementation(TsGameplayBlueprintFunctionLibrary.__RevertPhantomTeam_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.RevertPhantomTeam();
	}

	// Token: 0x0601824C RID: 98892 RVA: 0x006C0639 File Offset: 0x006BE839
	protected unsafe static void __CPPCALL_GetFormationAttribute_Implementation(TsGameplayBlueprintFunctionLibrary.__GetFormationAttribute_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetFormationAttribute(__Params->type);
	}

	// Token: 0x0601824D RID: 98893 RVA: 0x006C064C File Offset: 0x006BE84C
	protected unsafe static void __CPPCALL_GetEntityDeltaMillisecond_Implementation(TsGameplayBlueprintFunctionLibrary.__GetEntityDeltaMillisecond_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetEntityDeltaMillisecond(__Params->entityId);
	}

	// Token: 0x0601824E RID: 98894 RVA: 0x006C065F File Offset: 0x006BE85F
	protected unsafe static void __CPPCALL_SyncTwoEntityLocationAndRotation_Implementation(TsGameplayBlueprintFunctionLibrary.__SyncTwoEntityLocationAndRotation_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SyncTwoEntityLocationAndRotation(__Params->fromEntityId, __Params->toEntityId);
	}

	// Token: 0x0601824F RID: 98895 RVA: 0x006C0672 File Offset: 0x006BE872
	protected unsafe static void __CPPCALL_GetFishingBoat_Implementation(TsGameplayBlueprintFunctionLibrary.__GetFishingBoat_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		AActor fishingBoat = TsGameplayBlueprintFunctionLibrary.GetFishingBoat();
		ptr = ((fishingBoat != null) ? fishingBoat.NativePtr : ((IntPtr)0));
	}

	// Token: 0x06018250 RID: 98896 RVA: 0x006C068E File Offset: 0x006BE88E
	protected unsafe static void __CPPCALL_FishingBoatSprint_Implementation(TsGameplayBlueprintFunctionLibrary.__FishingBoatSprint_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.FishingBoatSprint(__Params->entityId, __Params->maxSpeedRatio, __Params->exceedLimitDuration, __Params->duration);
	}

	// Token: 0x06018251 RID: 98897 RVA: 0x006C06AD File Offset: 0x006BE8AD
	protected unsafe static void __CPPCALL_FishingBoatSkill_Implementation(TsGameplayBlueprintFunctionLibrary.__FishingBoatSkill_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.FishingBoatSkill((EFishingSkillType)__Params->type);
	}

	// Token: 0x06018252 RID: 98898 RVA: 0x006C06BA File Offset: 0x006BE8BA
	protected unsafe static void __CPPCALL_GetCharacterMorphType_Implementation(TsGameplayBlueprintFunctionLibrary.__GetCharacterMorphType_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)TsGameplayBlueprintFunctionLibrary.GetCharacterMorphType(__Params->entityId);
	}

	// Token: 0x06018253 RID: 98899 RVA: 0x006C06D0 File Offset: 0x006BE8D0
	protected unsafe static void __CPPCALL_SetCharacterMorphType_Implementation(TsGameplayBlueprintFunctionLibrary.__SetCharacterMorphType_FunctionParams* __Params)
	{
		EMorphType morphType = (EMorphType)__Params->morphType;
		TsGameplayBlueprintFunctionLibrary.SetCharacterMorphType(__Params->entityId, morphType);
	}

	// Token: 0x06018254 RID: 98900 RVA: 0x006C06F0 File Offset: 0x006BE8F0
	protected unsafe static void __CPPCALL_SetSpecialEnergyAttrValue_Implementation(TsGameplayBlueprintFunctionLibrary.__SetSpecialEnergyAttrValue_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetSpecialEnergyAttrValue(__Params->entityId, __Params->attrId, __Params->value);
	}

	// Token: 0x06018255 RID: 98901 RVA: 0x006C0709 File Offset: 0x006BE909
	protected unsafe static void __CPPCALL_GetFuLuoLuoSpecialEnergyType_Implementation(TsGameplayBlueprintFunctionLibrary.__GetFuLuoLuoSpecialEnergyType_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetFuLuoLuoSpecialEnergyType(__Params->entityId, __Params->index);
	}

	// Token: 0x06018256 RID: 98902 RVA: 0x006C0722 File Offset: 0x006BE922
	protected unsafe static void __CPPCALL_StartBattleQte_Implementation(TsGameplayBlueprintFunctionLibrary.__StartBattleQte_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.StartBattleQte(__Params->entityId, __Params->skillId, __Params->battleQteId);
	}

	// Token: 0x06018257 RID: 98903 RVA: 0x006C073C File Offset: 0x006BE93C
	protected unsafe static void __CPPCALL_StopGroup1Skill_Implementation(TsGameplayBlueprintFunctionLibrary.__StopGroup1Skill_FunctionParams* __Params)
	{
		string reason = FString.ToString((void*)(&__Params->reason));
		TsGameplayBlueprintFunctionLibrary.StopGroup1Skill(__Params->entityId, reason);
	}

	// Token: 0x06018258 RID: 98904 RVA: 0x006C0762 File Offset: 0x006BE962
	protected unsafe static void __CPPCALL_GetCharactersLocationNearBy_Implementation(TsGameplayBlueprintFunctionLibrary.__GetCharactersLocationNearBy_FunctionParams* __Params)
	{
		UScriptStructStackOnlyPtr nativeUStructPtr = SCharacterLocationsAndRadius.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SCharacterLocationsAndRadius charactersLocationNearBy = TsGameplayBlueprintFunctionLibrary.GetCharactersLocationNearBy(__Params->center, __Params->distance, __Params->maxCount);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (charactersLocationNearBy != null) ? charactersLocationNearBy.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06018259 RID: 98905 RVA: 0x006C079B File Offset: 0x006BE99B
	protected unsafe static void __CPPCALL_GetCurrentPlayer_Implementation(TsGameplayBlueprintFunctionLibrary.__GetCurrentPlayer_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		TsBaseCharacter currentPlayer = TsGameplayBlueprintFunctionLibrary.GetCurrentPlayer();
		ptr = ((currentPlayer != null) ? currentPlayer.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601825A RID: 98906 RVA: 0x006C07B8 File Offset: 0x006BE9B8
	protected unsafe static void __CPPCALL_IsEnemy_Implementation(TsGameplayBlueprintFunctionLibrary.__IsEnemy_FunctionParams* __Params)
	{
		TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->owner);
		TsBaseCharacter orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->other);
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.IsEnemy(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601825B RID: 98907 RVA: 0x006C07EA File Offset: 0x006BE9EA
	protected unsafe static void __CPPCALL_SetWalkOffLedge_Implementation(TsGameplayBlueprintFunctionLibrary.__SetWalkOffLedge_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.SetWalkOffLedge(__Params->entityId, __Params->walkOff);
	}

	// Token: 0x0601825C RID: 98908 RVA: 0x006C0800 File Offset: 0x006BEA00
	protected unsafe static void __CPPCALL_StartFlyingFeather_Implementation(TsGameplayBlueprintFunctionLibrary.__StartFlyingFeather_FunctionParams* __Params)
	{
		TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->owner);
		BP_FlyingFeatherConfig_C orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_FlyingFeatherConfig_C>(__Params->config);
		TsGameplayBlueprintFunctionLibrary.StartFlyingFeather(orCreateUObjectByNativePointer, __Params->initLocation, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601825D RID: 98909 RVA: 0x006C0830 File Offset: 0x006BEA30
	protected unsafe static void __CPPCALL_GetFlyingFeatherTargetId_Implementation(TsGameplayBlueprintFunctionLibrary.__GetFlyingFeatherTargetId_FunctionParams* __Params)
	{
		TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->owner);
		FString.CopyFrom((void*)(&__Params->__Result), TsGameplayBlueprintFunctionLibrary.GetFlyingFeatherTargetId(orCreateUObjectByNativePointer));
	}

	// Token: 0x0601825E RID: 98910 RVA: 0x006C085C File Offset: 0x006BEA5C
	protected unsafe static void __CPPCALL_AddFlyingFeatherTargetTag_Implementation(TsGameplayBlueprintFunctionLibrary.__AddFlyingFeatherTargetTag_FunctionParams* __Params)
	{
		string entityId = FString.ToString((void*)(&__Params->entityId));
		ref IntPtr ptr = ref *(&__Params->__Result);
		AActor aactor = TsGameplayBlueprintFunctionLibrary.AddFlyingFeatherTargetTag(__Params->tag, entityId);
		ptr = ((aactor != null) ? aactor.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601825F RID: 98911 RVA: 0x006C0898 File Offset: 0x006BEA98
	protected unsafe static void __CPPCALL_UpdateFlyingFeather_Implementation(TsGameplayBlueprintFunctionLibrary.__UpdateFlyingFeather_FunctionParams* __Params)
	{
		TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->owner);
		string target = FString.ToString((void*)(&__Params->target));
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.UpdateFlyingFeather(orCreateUObjectByNativePointer, target);
	}

	// Token: 0x06018260 RID: 98912 RVA: 0x006C08CB File Offset: 0x006BEACB
	protected unsafe static void __CPPCALL_EmitGlobalClientEvent_Implementation(TsGameplayBlueprintFunctionLibrary.__EmitGlobalClientEvent_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.EmitGlobalClientEvent(__Params->eventNameTag);
	}

	// Token: 0x06018261 RID: 98913 RVA: 0x006C08D8 File Offset: 0x006BEAD8
	protected unsafe static void __CPPCALL_GetDriverEntityId_Implementation(TsGameplayBlueprintFunctionLibrary.__GetDriverEntityId_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetDriverEntityId(__Params->vehicleEntityId);
	}

	// Token: 0x06018262 RID: 98914 RVA: 0x006C08EC File Offset: 0x006BEAEC
	protected unsafe static void __CPPCALL_StartCableWayMove_Implementation(TsGameplayBlueprintFunctionLibrary.__StartCableWayMove_FunctionParams* __Params)
	{
		UKuroBooleanEventBinder orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroBooleanEventBinder>(__Params->eventBinder);
		TsGameplayBlueprintFunctionLibrary.StartCableWayMove(__Params->id, orCreateUObjectByNativePointer);
	}

	// Token: 0x06018263 RID: 98915 RVA: 0x006C0911 File Offset: 0x006BEB11
	protected unsafe static void __CPPCALL_StopCableWayMove_Implementation(TsGameplayBlueprintFunctionLibrary.__StopCableWayMove_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.StopCableWayMove(__Params->id);
	}

	// Token: 0x06018264 RID: 98916 RVA: 0x006C091E File Offset: 0x006BEB1E
	protected unsafe static void __CPPCALL_GetBuffInstigatorId_Implementation(TsGameplayBlueprintFunctionLibrary.__GetBuffInstigatorId_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetBuffInstigatorId(__Params->entityId, __Params->buffId, __Params->getInstigatorSummoner);
	}

	// Token: 0x06018265 RID: 98917 RVA: 0x006C0940 File Offset: 0x006BEB40
	protected unsafe static void __CPPCALL_SetSubMeshOrder_Implementation(TsGameplayBlueprintFunctionLibrary.__SetSubMeshOrder_FunctionParams* __Params)
	{
		string meshName = FString.ToString((void*)(&__Params->meshName));
		PD_CharacterControllerData_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<PD_CharacterControllerData_C>(__Params->charControllerData);
		TSoftObjectPtr<UEffectModelBase> effectDataAssetRef = new TSoftObjectPtr<UEffectModelBase>(&__Params->effectDataAssetRef, true, true);
		TsGameplayBlueprintFunctionLibrary.SetSubMeshOrder(__Params->entityId, meshName, __Params->visible, orCreateUObjectByNativePointer, effectDataAssetRef, __Params->delayTime);
	}

	// Token: 0x06018266 RID: 98918 RVA: 0x006C098F File Offset: 0x006BEB8F
	protected unsafe static void __CPPCALL_GetPilotThrowSpeed_Implementation(TsGameplayBlueprintFunctionLibrary.__GetPilotThrowSpeed_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetPilotThrowSpeed();
	}

	// Token: 0x06018267 RID: 98919 RVA: 0x006C099C File Offset: 0x006BEB9C
	protected unsafe static void __CPPCALL_GetPilotThrowDirection_Implementation(TsGameplayBlueprintFunctionLibrary.__GetPilotThrowDirection_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetPilotThrowDirection();
	}

	// Token: 0x06018268 RID: 98920 RVA: 0x006C09A9 File Offset: 0x006BEBA9
	protected unsafe static void __CPPCALL_GetPilotThrowGravity_Implementation(TsGameplayBlueprintFunctionLibrary.__GetPilotThrowGravity_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetPilotThrowGravity();
	}

	// Token: 0x06018269 RID: 98921 RVA: 0x006C09B6 File Offset: 0x006BEBB6
	protected unsafe static void __CPPCALL_GetPilotThrowNeedMotorRide_Implementation(TsGameplayBlueprintFunctionLibrary.__GetPilotThrowNeedMotorRide_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetPilotThrowNeedMotorRide();
	}

	// Token: 0x0601826A RID: 98922 RVA: 0x006C09C3 File Offset: 0x006BEBC3
	protected unsafe static void __CPPCALL_GetPilotThrowIsDisableInterrupt_Implementation(TsGameplayBlueprintFunctionLibrary.__GetPilotThrowIsDisableInterrupt_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetPilotThrowIsDisableInterrupt();
	}

	// Token: 0x0601826B RID: 98923 RVA: 0x006C09D0 File Offset: 0x006BEBD0
	protected unsafe static void __CPPCALL_OpenPilotThrowGameplayCamera_Implementation(TsGameplayBlueprintFunctionLibrary.__OpenPilotThrowGameplayCamera_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.OpenPilotThrowGameplayCamera(__Params->targetEntityId);
	}

	// Token: 0x0601826C RID: 98924 RVA: 0x006C09DD File Offset: 0x006BEBDD
	protected unsafe static void __CPPCALL_GetCurrentTargetPilotSkeletalMeshComponent_Implementation(TsGameplayBlueprintFunctionLibrary.__GetCurrentTargetPilotSkeletalMeshComponent_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		USkeletalMeshComponent currentTargetPilotSkeletalMeshComponent = TsGameplayBlueprintFunctionLibrary.GetCurrentTargetPilotSkeletalMeshComponent(__Params->entityId);
		ptr = ((currentTargetPilotSkeletalMeshComponent != null) ? currentTargetPilotSkeletalMeshComponent.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601826D RID: 98925 RVA: 0x006C09FF File Offset: 0x006BEBFF
	protected unsafe static void __CPPCALL_GetPilotCurrentInRangePoint_Implementation(TsGameplayBlueprintFunctionLibrary.__GetPilotCurrentInRangePoint_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetPilotCurrentInRangePoint();
	}

	// Token: 0x0601826E RID: 98926 RVA: 0x006C0A0C File Offset: 0x006BEC0C
	protected unsafe static void __CPPCALL_GetVehicleCatapultUnitRisingTime_Implementation(TsGameplayBlueprintFunctionLibrary.__GetVehicleCatapultUnitRisingTime_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.GetVehicleCatapultUnitRisingTime(__Params->entityId);
	}

	// Token: 0x0601826F RID: 98927 RVA: 0x006C0A1F File Offset: 0x006BEC1F
	protected unsafe static void __CPPCALL_GuessJokerNpcTurnToIdlePerform_Implementation(TsGameplayBlueprintFunctionLibrary.__GuessJokerNpcTurnToIdlePerform_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.GuessJokerNpcTurnToIdlePerform();
	}

	// Token: 0x06018270 RID: 98928 RVA: 0x006C0A26 File Offset: 0x006BEC26
	protected unsafe static void __CPPCALL_LevelFlowDeadlySkeletonMeshCastToCharacter_Implementation(TsGameplayBlueprintFunctionLibrary.__LevelFlowDeadlySkeletonMeshCastToCharacter_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.LevelFlowDeadlySkeletonMeshCastToCharacter();
	}

	// Token: 0x06018271 RID: 98929 RVA: 0x006C0A2D File Offset: 0x006BEC2D
	protected unsafe static void __CPPCALL_LevelFlowAddBuff_Implementation(TsGameplayBlueprintFunctionLibrary.__LevelFlowAddBuff_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.LevelFlowAddBuff(__Params->entityId, __Params->buffId);
	}

	// Token: 0x06018272 RID: 98930 RVA: 0x006C0A40 File Offset: 0x006BEC40
	protected unsafe static void __CPPCALL_LevelFlowRemoveBuff_Implementation(TsGameplayBlueprintFunctionLibrary.__LevelFlowRemoveBuff_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.LevelFlowRemoveBuff(__Params->entityId, __Params->buffId);
	}

	// Token: 0x06018273 RID: 98931 RVA: 0x006C0A53 File Offset: 0x006BEC53
	protected unsafe static void __CPPCALL_LevelFlowCameraShake_Implementation(TsGameplayBlueprintFunctionLibrary.__LevelFlowCameraShake_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.LevelFlowCameraShake(FString.ToString((void*)(&__Params->cameraShakeBp)));
	}

	// Token: 0x06018274 RID: 98932 RVA: 0x006C0A68 File Offset: 0x006BEC68
	protected unsafe static void __CPPCALL_LevelFlowPlayLevelSequence_Implementation(TsGameplayBlueprintFunctionLibrary.__LevelFlowPlayLevelSequence_FunctionParams* __Params)
	{
		string path = FString.ToString((void*)(&__Params->path));
		string mark = FString.ToString((void*)(&__Params->mark));
		TsGameplayBlueprintFunctionLibrary.LevelFlowPlayLevelSequence(path, mark);
	}

	// Token: 0x06018275 RID: 98933 RVA: 0x006C0A94 File Offset: 0x006BEC94
	protected unsafe static void __CPPCALL_XigelikaAddBean_Implementation(TsGameplayBlueprintFunctionLibrary.__XigelikaAddBean_FunctionParams* __Params)
	{
		string bean = FString.ToString((void*)(&__Params->bean));
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.XigelikaAddBean(__Params->entityId, bean);
	}

	// Token: 0x06018276 RID: 98934 RVA: 0x006C0AC0 File Offset: 0x006BECC0
	protected unsafe static void __CPPCALL_XigelikaGetBeanResultant_Implementation(TsGameplayBlueprintFunctionLibrary.__XigelikaGetBeanResultant_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.XigelikaGetBeanResultant(__Params->entityId);
	}

	// Token: 0x06018277 RID: 98935 RVA: 0x006C0AD3 File Offset: 0x006BECD3
	protected unsafe static void __CPPCALL_XigelikaConsumeBean_Implementation(TsGameplayBlueprintFunctionLibrary.__XigelikaConsumeBean_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.XigelikaConsumeBean(__Params->entityId);
	}

	// Token: 0x06018278 RID: 98936 RVA: 0x006C0AE0 File Offset: 0x006BECE0
	protected unsafe static void __CPPCALL_XigelikaResetBean_Implementation(TsGameplayBlueprintFunctionLibrary.__XigelikaResetBean_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.XigelikaResetBean(__Params->entityId);
	}

	// Token: 0x06018279 RID: 98937 RVA: 0x006C0AED File Offset: 0x006BECED
	protected unsafe static void __CPPCALL_OpenQuickHack_Implementation(TsGameplayBlueprintFunctionLibrary.__OpenQuickHack_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.OpenQuickHack(__Params->deviceId, __Params->ownerEntityId, __Params->closeWhenInteractFinish, __Params->interactFinishGameplayEventTag);
	}

	// Token: 0x0601827A RID: 98938 RVA: 0x006C0B0C File Offset: 0x006BED0C
	protected unsafe static void __CPPCALL_CloseQuickHack_Implementation(TsGameplayBlueprintFunctionLibrary.__CloseQuickHack_FunctionParams* __Params)
	{
		TsGameplayBlueprintFunctionLibrary.CloseQuickHack();
	}

	// Token: 0x0601827B RID: 98939 RVA: 0x006C0B13 File Offset: 0x006BED13
	protected unsafe static void __CPPCALL_FunctionOpen_Implementation(TsGameplayBlueprintFunctionLibrary.__FunctionOpen_FunctionParams* __Params)
	{
		__Params->__Result = TsGameplayBlueprintFunctionLibrary.FunctionOpen(__Params->functionType);
	}

	// Token: 0x0400BA17 RID: 47639
	[Nullable(2)]
	private static TimerHandle FlyingFeatherHandle;

	// Token: 0x0400BA18 RID: 47640
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsGameplayBlueprintFunctionLibrary.TsGameplayBlueprintFunctionLibrary_C";

	// Token: 0x0400BA19 RID: 47641
	private static IntPtr _ClassPtr;

	// Token: 0x0400BA1A RID: 47642
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x020090EE RID: 37102
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __ContainsTag_FunctionParams
	{
		// Token: 0x0403085D RID: 198749
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403085E RID: 198750
		[FieldOffset(4)]
		public FGameplayTag tag;

		// Token: 0x0403085F RID: 198751
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04030860 RID: 198752
		[FieldOffset(24)]
		public bool __Result;
	}

	// Token: 0x020090EF RID: 37103
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __AddTag_FunctionParams
	{
		// Token: 0x04030861 RID: 198753
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030862 RID: 198754
		[FieldOffset(4)]
		public FGameplayTag tag;

		// Token: 0x04030863 RID: 198755
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090F0 RID: 37104
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __AddTagWithDuration_FunctionParams
	{
		// Token: 0x04030864 RID: 198756
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030865 RID: 198757
		[FieldOffset(4)]
		public float duration;

		// Token: 0x04030866 RID: 198758
		[FieldOffset(8)]
		public FGameplayTag tag;

		// Token: 0x04030867 RID: 198759
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090F1 RID: 37105
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __AddTagByName_FunctionParams
	{
		// Token: 0x04030868 RID: 198760
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030869 RID: 198761
		[FieldOffset(8)]
		public FString tagName;

		// Token: 0x0403086A RID: 198762
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090F2 RID: 37106
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __RemoveTag_FunctionParams
	{
		// Token: 0x0403086B RID: 198763
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403086C RID: 198764
		[FieldOffset(4)]
		public FGameplayTag tag;

		// Token: 0x0403086D RID: 198765
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090F3 RID: 37107
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __RemoveTagByName_FunctionParams
	{
		// Token: 0x0403086E RID: 198766
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403086F RID: 198767
		[FieldOffset(8)]
		public FString tagName;

		// Token: 0x04030870 RID: 198768
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090F4 RID: 37108
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __AddCue_FunctionParams
	{
		// Token: 0x04030871 RID: 198769
		[FieldOffset(0)]
		public int instigatorEntityId;

		// Token: 0x04030872 RID: 198770
		[FieldOffset(4)]
		public int targetEntityId;

		// Token: 0x04030873 RID: 198771
		[FieldOffset(8)]
		public long cueId;

		// Token: 0x04030874 RID: 198772
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090F5 RID: 37109
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __RemoveCue_FunctionParams
	{
		// Token: 0x04030875 RID: 198773
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030876 RID: 198774
		[FieldOffset(8)]
		public long cueId;

		// Token: 0x04030877 RID: 198775
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090F6 RID: 37110
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetGameplayCueEffectForceRecycle_FunctionParams
	{
		// Token: 0x04030878 RID: 198776
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030879 RID: 198777
		[FieldOffset(8)]
		public long cueId;

		// Token: 0x0403087A RID: 198778
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090F7 RID: 37111
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsLogicAutonomousProxy_FunctionParams
	{
		// Token: 0x0403087B RID: 198779
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403087C RID: 198780
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403087D RID: 198781
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020090F8 RID: 37112
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __RemoveActiveGameplayEffect_FunctionParams
	{
		// Token: 0x0403087E RID: 198782
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403087F RID: 198783
		[FieldOffset(4)]
		public byte handle;

		// Token: 0x04030880 RID: 198784
		[FieldOffset(12)]
		public float stacksToRemove;

		// Token: 0x04030881 RID: 198785
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04030882 RID: 198786
		[FieldOffset(24)]
		public bool __Result;
	}

	// Token: 0x020090F9 RID: 37113
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __RemoveBuffByTag_FunctionParams
	{
		// Token: 0x04030883 RID: 198787
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030884 RID: 198788
		[FieldOffset(4)]
		public FGameplayTag tag;

		// Token: 0x04030885 RID: 198789
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090FA RID: 37114
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __AddPassiveSkill_FunctionParams
	{
		// Token: 0x04030886 RID: 198790
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030887 RID: 198791
		[FieldOffset(8)]
		public long passiveSkillId;

		// Token: 0x04030888 RID: 198792
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090FB RID: 37115
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __RemovePassiveSkill_FunctionParams
	{
		// Token: 0x04030889 RID: 198793
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403088A RID: 198794
		[FieldOffset(8)]
		public long passiveSkillId;

		// Token: 0x0403088B RID: 198795
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090FC RID: 37116
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetPassiveGaSkillId_FunctionParams
	{
		// Token: 0x0403088C RID: 198796
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403088D RID: 198797
		[FieldOffset(8)]
		public IntPtr callObject;

		// Token: 0x0403088E RID: 198798
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090FD RID: 37117
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __AddBuffForDebug_FunctionParams
	{
		// Token: 0x0403088F RID: 198799
		[FieldOffset(0)]
		public int instigatorEntityId;

		// Token: 0x04030890 RID: 198800
		[FieldOffset(4)]
		public int targetEntityId;

		// Token: 0x04030891 RID: 198801
		[FieldOffset(8)]
		public long buffId;

		// Token: 0x04030892 RID: 198802
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090FE RID: 37118
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SendCombatEventForDebug_FunctionParams
	{
		// Token: 0x04030893 RID: 198803
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030894 RID: 198804
		[FieldOffset(8)]
		public FString tagName;

		// Token: 0x04030895 RID: 198805
		[FieldOffset(24)]
		public bool needSave;

		// Token: 0x04030896 RID: 198806
		[FieldOffset(25)]
		public bool isMainState;

		// Token: 0x04030897 RID: 198807
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020090FF RID: 37119
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SendLevelEventForDebug_FunctionParams
	{
		// Token: 0x04030898 RID: 198808
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030899 RID: 198809
		[FieldOffset(8)]
		public FString tagName;

		// Token: 0x0403089A RID: 198810
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009100 RID: 37120
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __AddBuffFromGA_FunctionParams
	{
		// Token: 0x0403089B RID: 198811
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403089C RID: 198812
		[FieldOffset(8)]
		public IntPtr target;

		// Token: 0x0403089D RID: 198813
		[FieldOffset(16)]
		public long buffId;

		// Token: 0x0403089E RID: 198814
		[FieldOffset(24)]
		public FString skillId;

		// Token: 0x0403089F RID: 198815
		[FieldOffset(40)]
		public int addCount;

		// Token: 0x040308A0 RID: 198816
		[FieldOffset(48)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009101 RID: 37121
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __RemoveBuffById_FunctionParams
	{
		// Token: 0x040308A1 RID: 198817
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308A2 RID: 198818
		[FieldOffset(8)]
		public long buffId;

		// Token: 0x040308A3 RID: 198819
		[FieldOffset(16)]
		public int stackCount;

		// Token: 0x040308A4 RID: 198820
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009102 RID: 37122
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetBuffCountById_FunctionParams
	{
		// Token: 0x040308A5 RID: 198821
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308A6 RID: 198822
		[FieldOffset(8)]
		public long buffId;

		// Token: 0x040308A7 RID: 198823
		[FieldOffset(16)]
		public bool enforceOnGoingCheck;

		// Token: 0x040308A8 RID: 198824
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x040308A9 RID: 198825
		[FieldOffset(32)]
		public int __Result;
	}

	// Token: 0x02009103 RID: 37123
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __AddGameplayCueLocal_FunctionParams
	{
		// Token: 0x040308AA RID: 198826
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308AB RID: 198827
		[FieldOffset(4)]
		public float duration;

		// Token: 0x040308AC RID: 198828
		[FieldOffset(8)]
		public long cueId;

		// Token: 0x040308AD RID: 198829
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009104 RID: 37124
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetGeDebugString_FunctionParams
	{
		// Token: 0x040308AE RID: 198830
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308AF RID: 198831
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308B0 RID: 198832
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009105 RID: 37125
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetTagDebugStrings_FunctionParams
	{
		// Token: 0x040308B1 RID: 198833
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308B2 RID: 198834
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308B3 RID: 198835
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009106 RID: 37126
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetBuffDebugStrings_FunctionParams
	{
		// Token: 0x040308B4 RID: 198836
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308B5 RID: 198837
		[FieldOffset(8)]
		public FString buffStr;

		// Token: 0x040308B6 RID: 198838
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x040308B7 RID: 198839
		[FieldOffset(32)]
		public FString __Result;
	}

	// Token: 0x02009107 RID: 37127
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetShieldDebugString_FunctionParams
	{
		// Token: 0x040308B8 RID: 198840
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308B9 RID: 198841
		[FieldOffset(8)]
		public FString filterStr;

		// Token: 0x040308BA RID: 198842
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x040308BB RID: 198843
		[FieldOffset(32)]
		public FString __Result;
	}

	// Token: 0x02009108 RID: 37128
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetPassiveSkillDebugString_FunctionParams
	{
		// Token: 0x040308BC RID: 198844
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308BD RID: 198845
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308BE RID: 198846
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009109 RID: 37129
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetShieldValue_FunctionParams
	{
		// Token: 0x040308BF RID: 198847
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308C0 RID: 198848
		[FieldOffset(4)]
		public int shieldCid;

		// Token: 0x040308C1 RID: 198849
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308C2 RID: 198850
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x0200910A RID: 37130
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetAttributeDebugString_FunctionParams
	{
		// Token: 0x040308C3 RID: 198851
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308C4 RID: 198852
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308C5 RID: 198853
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x0200910B RID: 37131
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetAllAttributeDebugStrings_FunctionParams
	{
		// Token: 0x040308C6 RID: 198854
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308C7 RID: 198855
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308C8 RID: 198856
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x0200910C RID: 37132
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetServerBuffString_FunctionParams
	{
		// Token: 0x040308C9 RID: 198857
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308CA RID: 198858
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308CB RID: 198859
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x0200910D RID: 37133
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetServerTagString_FunctionParams
	{
		// Token: 0x040308CC RID: 198860
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308CD RID: 198861
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308CE RID: 198862
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x0200910E RID: 37134
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetServerAttributeString_FunctionParams
	{
		// Token: 0x040308CF RID: 198863
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308D0 RID: 198864
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308D1 RID: 198865
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x0200910F RID: 37135
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetServerPartString_FunctionParams
	{
		// Token: 0x040308D2 RID: 198866
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308D3 RID: 198867
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308D4 RID: 198868
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009110 RID: 37136
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetServerHateString_FunctionParams
	{
		// Token: 0x040308D5 RID: 198869
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308D6 RID: 198870
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308D7 RID: 198871
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009111 RID: 37137
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetServerShieldString_FunctionParams
	{
		// Token: 0x040308D8 RID: 198872
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308D9 RID: 198873
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308DA RID: 198874
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009112 RID: 37138
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ServerDebugInfoRequest_FunctionParams
	{
		// Token: 0x040308DB RID: 198875
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308DC RID: 198876
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009113 RID: 37139
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetServerDebugInfoDirty_FunctionParams
	{
		// Token: 0x040308DD RID: 198877
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308DE RID: 198878
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308DF RID: 198879
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009114 RID: 37140
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetServerDebugInfoDirty_FunctionParams
	{
		// Token: 0x040308E0 RID: 198880
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308E1 RID: 198881
		[FieldOffset(4)]
		public bool val;

		// Token: 0x040308E2 RID: 198882
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009115 RID: 37141
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __DebugResetBaseVal_FunctionParams
	{
		// Token: 0x040308E3 RID: 198883
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308E4 RID: 198884
		[FieldOffset(4)]
		public float id;

		// Token: 0x040308E5 RID: 198885
		[FieldOffset(8)]
		public float val;

		// Token: 0x040308E6 RID: 198886
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009116 RID: 37142
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __DebugResetFormationValue_FunctionParams
	{
		// Token: 0x040308E7 RID: 198887
		[FieldOffset(0)]
		public int id;

		// Token: 0x040308E8 RID: 198888
		[FieldOffset(4)]
		public float val;

		// Token: 0x040308E9 RID: 198889
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009117 RID: 37143
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __Record_FunctionParams
	{
		// Token: 0x040308EA RID: 198890
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308EB RID: 198891
		[FieldOffset(4)]
		public bool record;

		// Token: 0x040308EC RID: 198892
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040308ED RID: 198893
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009118 RID: 37144
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __RefreshEntityListView_FunctionParams
	{
		// Token: 0x040308EE RID: 198894
		[FieldOffset(0)]
		public IntPtr listView;

		// Token: 0x040308EF RID: 198895
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009119 RID: 37145
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __RefreshEntityComboBox_FunctionParams
	{
		// Token: 0x040308F0 RID: 198896
		[FieldOffset(0)]
		public IntPtr comboBox;

		// Token: 0x040308F1 RID: 198897
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200911A RID: 37146
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetEntityComboBox_FunctionParams
	{
		// Token: 0x040308F2 RID: 198898
		[FieldOffset(0)]
		public IntPtr comboBox;

		// Token: 0x040308F3 RID: 198899
		[FieldOffset(8)]
		public int entityId;

		// Token: 0x040308F4 RID: 198900
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200911B RID: 37147
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetDebugEntityId_FunctionParams
	{
		// Token: 0x040308F5 RID: 198901
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308F6 RID: 198902
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200911C RID: 37148
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetDebugEntityId_FunctionParams
	{
		// Token: 0x040308F7 RID: 198903
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x040308F8 RID: 198904
		[FieldOffset(8)]
		public int __Result;
	}

	// Token: 0x0200911D RID: 37149
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __RefreshBuffListView_FunctionParams
	{
		// Token: 0x040308F9 RID: 198905
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308FA RID: 198906
		[FieldOffset(8)]
		public IntPtr listView;

		// Token: 0x040308FB RID: 198907
		[FieldOffset(16)]
		public FString filterStr;

		// Token: 0x040308FC RID: 198908
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200911E RID: 37150
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBuffIdByHandle_FunctionParams
	{
		// Token: 0x040308FD RID: 198909
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040308FE RID: 198910
		[FieldOffset(4)]
		public int handle;

		// Token: 0x040308FF RID: 198911
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030900 RID: 198912
		[FieldOffset(16)]
		public long __Result;
	}

	// Token: 0x0200911F RID: 37151
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBuffServerIdByHandle_FunctionParams
	{
		// Token: 0x04030901 RID: 198913
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030902 RID: 198914
		[FieldOffset(4)]
		public int handle;

		// Token: 0x04030903 RID: 198915
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030904 RID: 198916
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x02009120 RID: 37152
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetBuffDescByHandle_FunctionParams
	{
		// Token: 0x04030905 RID: 198917
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030906 RID: 198918
		[FieldOffset(4)]
		public int handle;

		// Token: 0x04030907 RID: 198919
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030908 RID: 198920
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009121 RID: 37153
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBuffActivateByHandle_FunctionParams
	{
		// Token: 0x04030909 RID: 198921
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403090A RID: 198922
		[FieldOffset(4)]
		public int handle;

		// Token: 0x0403090B RID: 198923
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403090C RID: 198924
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009122 RID: 37154
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetBuffInstigatorStringByHandle_FunctionParams
	{
		// Token: 0x0403090D RID: 198925
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403090E RID: 198926
		[FieldOffset(4)]
		public int handle;

		// Token: 0x0403090F RID: 198927
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030910 RID: 198928
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009123 RID: 37155
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetBuffPeriodStringByHandle_FunctionParams
	{
		// Token: 0x04030911 RID: 198929
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030912 RID: 198930
		[FieldOffset(4)]
		public int handle;

		// Token: 0x04030913 RID: 198931
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030914 RID: 198932
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009124 RID: 37156
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetBuffDurationStringByHandle_FunctionParams
	{
		// Token: 0x04030915 RID: 198933
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030916 RID: 198934
		[FieldOffset(4)]
		public int handle;

		// Token: 0x04030917 RID: 198935
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030918 RID: 198936
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009125 RID: 37157
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBuffDurationProgress_FunctionParams
	{
		// Token: 0x04030919 RID: 198937
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403091A RID: 198938
		[FieldOffset(4)]
		public int handle;

		// Token: 0x0403091B RID: 198939
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403091C RID: 198940
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009126 RID: 37158
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetBuffLivingStatusStringByHandle_FunctionParams
	{
		// Token: 0x0403091D RID: 198941
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403091E RID: 198942
		[FieldOffset(4)]
		public int handle;

		// Token: 0x0403091F RID: 198943
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030920 RID: 198944
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009127 RID: 37159
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetBuffLevelStringByHandle_FunctionParams
	{
		// Token: 0x04030921 RID: 198945
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030922 RID: 198946
		[FieldOffset(4)]
		public int handle;

		// Token: 0x04030923 RID: 198947
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030924 RID: 198948
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009128 RID: 37160
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetBuffStackStringByHandle_FunctionParams
	{
		// Token: 0x04030925 RID: 198949
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030926 RID: 198950
		[FieldOffset(4)]
		public int handle;

		// Token: 0x04030927 RID: 198951
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030928 RID: 198952
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009129 RID: 37161
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetBuffDebugStringByHandle_FunctionParams
	{
		// Token: 0x04030929 RID: 198953
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403092A RID: 198954
		[FieldOffset(4)]
		public int handle;

		// Token: 0x0403092B RID: 198955
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403092C RID: 198956
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x0200912A RID: 37162
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetDistance_FunctionParams
	{
		// Token: 0x0403092D RID: 198957
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403092E RID: 198958
		[FieldOffset(4)]
		public float max;

		// Token: 0x0403092F RID: 198959
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200912B RID: 37163
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetAllMovementHistory_FunctionParams
	{
		// Token: 0x04030930 RID: 198960
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030931 RID: 198961
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030932 RID: 198962
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x0200912C RID: 37164
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ResetBaseValueLocal_FunctionParams
	{
		// Token: 0x04030933 RID: 198963
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030934 RID: 198964
		[FieldOffset(4)]
		public int id;

		// Token: 0x04030935 RID: 198965
		[FieldOffset(8)]
		public float val;

		// Token: 0x04030936 RID: 198966
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200912D RID: 37165
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetAttributeCurrentValue_FunctionParams
	{
		// Token: 0x04030937 RID: 198967
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030938 RID: 198968
		[FieldOffset(4)]
		public int attributeId;

		// Token: 0x04030939 RID: 198969
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403093A RID: 198970
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x0200912E RID: 37166
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetAttributeBaseValue_FunctionParams
	{
		// Token: 0x0403093B RID: 198971
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403093C RID: 198972
		[FieldOffset(4)]
		public int attributeId;

		// Token: 0x0403093D RID: 198973
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403093E RID: 198974
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x0200912F RID: 37167
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetRageModeId_FunctionParams
	{
		// Token: 0x0403093F RID: 198975
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030940 RID: 198976
		[FieldOffset(4)]
		public int id;

		// Token: 0x04030941 RID: 198977
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009130 RID: 37168
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetHardnessModeId_FunctionParams
	{
		// Token: 0x04030942 RID: 198978
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030943 RID: 198979
		[FieldOffset(4)]
		public int id;

		// Token: 0x04030944 RID: 198980
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009131 RID: 37169
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 2288)]
	protected ref struct __OnHit_FunctionParams
	{
		// Token: 0x04030945 RID: 198981
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030946 RID: 198982
		[FieldOffset(8)]
		public byte hitData;

		// Token: 0x04030947 RID: 198983
		[FieldOffset(2280)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009132 RID: 37170
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetBeHitIgnoreRotate_FunctionParams
	{
		// Token: 0x04030948 RID: 198984
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030949 RID: 198985
		[FieldOffset(4)]
		public bool ignoreRotate;

		// Token: 0x0403094A RID: 198986
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009133 RID: 37171
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CheckHasPart_FunctionParams
	{
		// Token: 0x0403094B RID: 198987
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403094C RID: 198988
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403094D RID: 198989
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009134 RID: 37172
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetPartRemainedLife_FunctionParams
	{
		// Token: 0x0403094E RID: 198990
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403094F RID: 198991
		[FieldOffset(4)]
		public FGameplayTag tag;

		// Token: 0x04030950 RID: 198992
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04030951 RID: 198993
		[FieldOffset(24)]
		public float __Result;
	}

	// Token: 0x02009135 RID: 37173
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ResetPartLife_FunctionParams
	{
		// Token: 0x04030952 RID: 198994
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030953 RID: 198995
		[FieldOffset(4)]
		public FGameplayTag tag;

		// Token: 0x04030954 RID: 198996
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009136 RID: 37174
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ActiveStiff_FunctionParams
	{
		// Token: 0x04030955 RID: 198997
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030956 RID: 198998
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009137 RID: 37175
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __DeActiveStiff_FunctionParams
	{
		// Token: 0x04030957 RID: 198999
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030958 RID: 199000
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009138 RID: 37176
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetAcceptedNewBeHitAndReset_FunctionParams
	{
		// Token: 0x04030959 RID: 199001
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403095A RID: 199002
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403095B RID: 199003
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009139 RID: 37177
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetEnterFkAndReset_FunctionParams
	{
		// Token: 0x0403095C RID: 199004
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403095D RID: 199005
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403095E RID: 199006
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200913A RID: 37178
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsStiff_FunctionParams
	{
		// Token: 0x0403095F RID: 199007
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030960 RID: 199008
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030961 RID: 199009
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200913B RID: 37179
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetRageModeId_FunctionParams
	{
		// Token: 0x04030962 RID: 199010
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030963 RID: 199011
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030964 RID: 199012
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x0200913C RID: 37180
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetHardnessModeId_FunctionParams
	{
		// Token: 0x04030965 RID: 199013
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030966 RID: 199014
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030967 RID: 199015
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x0200913D RID: 37181
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetBeHitBone_FunctionParams
	{
		// Token: 0x04030968 RID: 199016
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030969 RID: 199017
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403096A RID: 199018
		[FieldOffset(16)]
		public FName __Result;
	}

	// Token: 0x0200913E RID: 37182
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetToughDecreaseValue_FunctionParams
	{
		// Token: 0x0403096B RID: 199019
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403096C RID: 199020
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403096D RID: 199021
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x0200913F RID: 37183
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1168)]
	protected ref struct __GetCounterAttackInfoInternal_FunctionParams
	{
		// Token: 0x0403096E RID: 199022
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403096F RID: 199023
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030970 RID: 199024
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x02009140 RID: 37184
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 568)]
	protected ref struct __GetVisionCounterAttackInfoInternal_FunctionParams
	{
		// Token: 0x04030971 RID: 199025
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030972 RID: 199026
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030973 RID: 199027
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x02009141 RID: 37185
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBeHitTime_FunctionParams
	{
		// Token: 0x04030974 RID: 199028
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030975 RID: 199029
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030976 RID: 199030
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009142 RID: 37186
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBeHitAnim_FunctionParams
	{
		// Token: 0x04030977 RID: 199031
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030978 RID: 199032
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030979 RID: 199033
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x02009143 RID: 37187
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetEnterFk_FunctionParams
	{
		// Token: 0x0403097A RID: 199034
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403097B RID: 199035
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403097C RID: 199036
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009144 RID: 37188
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetBeHitDirect_FunctionParams
	{
		// Token: 0x0403097D RID: 199037
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403097E RID: 199038
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403097F RID: 199039
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x02009145 RID: 37189
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetBeHitLocation_FunctionParams
	{
		// Token: 0x04030980 RID: 199040
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030981 RID: 199041
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030982 RID: 199042
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x02009146 RID: 37190
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __AddCheckBuffList_FunctionParams
	{
		// Token: 0x04030983 RID: 199043
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030984 RID: 199044
		[FieldOffset(8)]
		public SCounterAttackBuff addValue;

		// Token: 0x04030985 RID: 199045
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009147 RID: 37191
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ClearCheckBuffList_FunctionParams
	{
		// Token: 0x04030986 RID: 199046
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030987 RID: 199047
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009148 RID: 37192
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __CounterAttackEnd_FunctionParams
	{
		// Token: 0x04030988 RID: 199048
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030989 RID: 199049
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009149 RID: 37193
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __VisionCounterAttackEnd_FunctionParams
	{
		// Token: 0x0403098A RID: 199050
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403098B RID: 199051
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200914A RID: 37194
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetCounterAttackEndTime_FunctionParams
	{
		// Token: 0x0403098C RID: 199052
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403098D RID: 199053
		[FieldOffset(4)]
		public float baseTime;

		// Token: 0x0403098E RID: 199054
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200914B RID: 37195
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsTriggerCounterAttack_FunctionParams
	{
		// Token: 0x0403098F RID: 199055
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030990 RID: 199056
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030991 RID: 199057
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200914C RID: 37196
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ResetTarget_FunctionParams
	{
		// Token: 0x04030992 RID: 199058
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030993 RID: 199059
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200914D RID: 37197
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetShowTarget_FunctionParams
	{
		// Token: 0x04030994 RID: 199060
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030995 RID: 199061
		[FieldOffset(8)]
		public IntPtr actor;

		// Token: 0x04030996 RID: 199062
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200914E RID: 37198
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ExitLockDirection_FunctionParams
	{
		// Token: 0x04030997 RID: 199063
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030998 RID: 199064
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200914F RID: 37199
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EnterLockDirection_FunctionParams
	{
		// Token: 0x04030999 RID: 199065
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403099A RID: 199066
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009150 RID: 37200
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCurrentTarget_FunctionParams
	{
		// Token: 0x0403099B RID: 199067
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403099C RID: 199068
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403099D RID: 199069
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x02009151 RID: 37201
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetLockOnDebugLine_FunctionParams
	{
		// Token: 0x0403099E RID: 199070
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403099F RID: 199071
		[FieldOffset(4)]
		public bool isShow;

		// Token: 0x040309A0 RID: 199072
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009152 RID: 37202
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ManipulateValid_FunctionParams
	{
		// Token: 0x040309A1 RID: 199073
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309A2 RID: 199074
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309A3 RID: 199075
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009153 RID: 37203
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ManipulateGetDrawTarget_FunctionParams
	{
		// Token: 0x040309A4 RID: 199076
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309A5 RID: 199077
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309A6 RID: 199078
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x02009154 RID: 37204
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ManipulateGetCastTarget_FunctionParams
	{
		// Token: 0x040309A7 RID: 199079
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309A8 RID: 199080
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309A9 RID: 199081
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x02009155 RID: 37205
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ManipulateGetDrawTargetChantTime_FunctionParams
	{
		// Token: 0x040309AA RID: 199082
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309AB RID: 199083
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309AC RID: 199084
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009156 RID: 37206
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __ManipulateChant_FunctionParams
	{
		// Token: 0x040309AD RID: 199085
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309AE RID: 199086
		[FieldOffset(8)]
		public IntPtr eventBinder;

		// Token: 0x040309AF RID: 199087
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x040309B0 RID: 199088
		[FieldOffset(24)]
		public bool __Result;
	}

	// Token: 0x02009157 RID: 37207
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ManipulateDraw_FunctionParams
	{
		// Token: 0x040309B1 RID: 199089
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309B2 RID: 199090
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309B3 RID: 199091
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009158 RID: 37208
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ManipulateCast_FunctionParams
	{
		// Token: 0x040309B4 RID: 199092
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309B5 RID: 199093
		[FieldOffset(4)]
		public float direction;

		// Token: 0x040309B6 RID: 199094
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309B7 RID: 199095
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009159 RID: 37209
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ManipulateReset_FunctionParams
	{
		// Token: 0x040309B8 RID: 199096
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309B9 RID: 199097
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200915A RID: 37210
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ManipulateChangeToProjectileState_FunctionParams
	{
		// Token: 0x040309BA RID: 199098
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309BB RID: 199099
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309BC RID: 199100
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200915B RID: 37211
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ManipulateChangeToNormalState_FunctionParams
	{
		// Token: 0x040309BD RID: 199101
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309BE RID: 199102
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309BF RID: 199103
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200915C RID: 37212
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetHoldingActor_FunctionParams
	{
		// Token: 0x040309C0 RID: 199104
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309C1 RID: 199105
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309C2 RID: 199106
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x0200915D RID: 37213
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __HasHoldingActor_FunctionParams
	{
		// Token: 0x040309C3 RID: 199107
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309C4 RID: 199108
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309C5 RID: 199109
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200915E RID: 37214
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetDebugDraw_FunctionParams
	{
		// Token: 0x040309C6 RID: 199110
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309C7 RID: 199111
		[FieldOffset(4)]
		public bool isActive;

		// Token: 0x040309C8 RID: 199112
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200915F RID: 37215
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ExtraAction_FunctionParams
	{
		// Token: 0x040309C9 RID: 199113
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309CA RID: 199114
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009160 RID: 37216
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetQtePosition_FunctionParams
	{
		// Token: 0x040309CB RID: 199115
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309CC RID: 199116
		[FieldOffset(4)]
		public float rotate;

		// Token: 0x040309CD RID: 199117
		[FieldOffset(8)]
		public float length;

		// Token: 0x040309CE RID: 199118
		[FieldOffset(12)]
		public float height;

		// Token: 0x040309CF RID: 199119
		[FieldOffset(16)]
		public bool referenceTarget;

		// Token: 0x040309D0 RID: 199120
		[FieldOffset(17)]
		public bool adjustWithMonster;

		// Token: 0x040309D1 RID: 199121
		[FieldOffset(20)]
		public float addHeight;

		// Token: 0x040309D2 RID: 199122
		[FieldOffset(24)]
		public int qteType;

		// Token: 0x040309D3 RID: 199123
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009161 RID: 37217
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetGoBattleActor_FunctionParams
	{
		// Token: 0x040309D4 RID: 199124
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309D5 RID: 199125
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309D6 RID: 199126
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x02009162 RID: 37218
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetDtSkillInfo_FunctionParams
	{
		// Token: 0x040309D7 RID: 199127
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309D8 RID: 199128
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309D9 RID: 199129
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x02009163 RID: 37219
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 80)]
	protected ref struct __GetDtSkillInfoMapForDebug_FunctionParams
	{
		// Token: 0x040309DA RID: 199130
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309DB RID: 199131
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309DC RID: 199132
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x02009164 RID: 37220
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetLastActivateSkillTime_FunctionParams
	{
		// Token: 0x040309DD RID: 199133
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309DE RID: 199134
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309DF RID: 199135
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009165 RID: 37221
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetLastActivateSkillTime_FunctionParams
	{
		// Token: 0x040309E0 RID: 199136
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309E1 RID: 199137
		[FieldOffset(4)]
		public float time;

		// Token: 0x040309E2 RID: 199138
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009166 RID: 37222
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetSkillElevationAngle_FunctionParams
	{
		// Token: 0x040309E3 RID: 199139
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309E4 RID: 199140
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309E5 RID: 199141
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009167 RID: 37223
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetSkillElevationAngle_FunctionParams
	{
		// Token: 0x040309E6 RID: 199142
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309E7 RID: 199143
		[FieldOffset(4)]
		public float angle;

		// Token: 0x040309E8 RID: 199144
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009168 RID: 37224
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __CurrentSkillId_FunctionParams
	{
		// Token: 0x040309E9 RID: 199145
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309EA RID: 199146
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309EB RID: 199147
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009169 RID: 37225
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CurrentPriority_FunctionParams
	{
		// Token: 0x040309EC RID: 199148
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309ED RID: 199149
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040309EE RID: 199150
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x0200916A RID: 37226
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetCurrentPriority_FunctionParams
	{
		// Token: 0x040309EF RID: 199151
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309F0 RID: 199152
		[FieldOffset(4)]
		public int priority;

		// Token: 0x040309F1 RID: 199153
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200916B RID: 37227
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __HasAbility_FunctionParams
	{
		// Token: 0x040309F2 RID: 199154
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309F3 RID: 199155
		[FieldOffset(8)]
		public FString skillId;

		// Token: 0x040309F4 RID: 199156
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x040309F5 RID: 199157
		[FieldOffset(32)]
		public bool __Result;
	}

	// Token: 0x0200916C RID: 37228
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 496)]
	protected ref struct __GetSkillInfo_FunctionParams
	{
		// Token: 0x040309F6 RID: 199158
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309F7 RID: 199159
		[FieldOffset(8)]
		public FString skillId;

		// Token: 0x040309F8 RID: 199160
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x040309F9 RID: 199161
		[FieldOffset(32)]
		public byte __Result;
	}

	// Token: 0x0200916D RID: 37229
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetSkillPriority_FunctionParams
	{
		// Token: 0x040309FA RID: 199162
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309FB RID: 199163
		[FieldOffset(8)]
		public FString skillId;

		// Token: 0x040309FC RID: 199164
		[FieldOffset(24)]
		public float priority;

		// Token: 0x040309FD RID: 199165
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200916E RID: 37230
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __EndSkill_FunctionParams
	{
		// Token: 0x040309FE RID: 199166
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040309FF RID: 199167
		[FieldOffset(8)]
		public FString skillId;

		// Token: 0x04030A00 RID: 199168
		[FieldOffset(24)]
		public bool isSyn;

		// Token: 0x04030A01 RID: 199169
		[FieldOffset(25)]
		public bool isNotEnd;

		// Token: 0x04030A02 RID: 199170
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200916F RID: 37231
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __BeginSkill_FunctionParams
	{
		// Token: 0x04030A03 RID: 199171
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A04 RID: 199172
		[FieldOffset(4)]
		public FName skillId;

		// Token: 0x04030A05 RID: 199173
		[FieldOffset(16)]
		public bool isSyn;

		// Token: 0x04030A06 RID: 199174
		[FieldOffset(24)]
		public IntPtr target;

		// Token: 0x04030A07 RID: 199175
		[FieldOffset(32)]
		public FName socketName;

		// Token: 0x04030A08 RID: 199176
		[FieldOffset(48)]
		public IntPtr __WorldContext;

		// Token: 0x04030A09 RID: 199177
		[FieldOffset(56)]
		public bool __Result;
	}

	// Token: 0x02009170 RID: 37232
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __BeginSkillAsync_FunctionParams
	{
		// Token: 0x04030A0A RID: 199178
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A0B RID: 199179
		[FieldOffset(4)]
		public FName skillId;

		// Token: 0x04030A0C RID: 199180
		[FieldOffset(16)]
		public IntPtr target;

		// Token: 0x04030A0D RID: 199181
		[FieldOffset(24)]
		public FName socketName;

		// Token: 0x04030A0E RID: 199182
		[FieldOffset(40)]
		public IntPtr eventBinder;

		// Token: 0x04030A0F RID: 199183
		[FieldOffset(48)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009171 RID: 37233
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 864)]
	protected ref struct __SkillBehaviorBegin_FunctionParams
	{
		// Token: 0x04030A10 RID: 199184
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A11 RID: 199185
		[FieldOffset(8)]
		public IntPtr ga;

		// Token: 0x04030A12 RID: 199186
		[FieldOffset(16)]
		public byte action;

		// Token: 0x04030A13 RID: 199187
		[FieldOffset(856)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009172 RID: 37234
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 888)]
	protected ref struct __GetLocationByAction_FunctionParams
	{
		// Token: 0x04030A14 RID: 199188
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A15 RID: 199189
		[FieldOffset(8)]
		public IntPtr ga;

		// Token: 0x04030A16 RID: 199190
		[FieldOffset(16)]
		public byte action;

		// Token: 0x04030A17 RID: 199191
		[FieldOffset(856)]
		public IntPtr __WorldContext;

		// Token: 0x04030A18 RID: 199192
		[FieldOffset(864)]
		public FVectorDouble __Result;
	}

	// Token: 0x02009173 RID: 37235
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 880)]
	protected ref struct __GetRotationByAction_FunctionParams
	{
		// Token: 0x04030A19 RID: 199193
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A1A RID: 199194
		[FieldOffset(8)]
		public IntPtr ga;

		// Token: 0x04030A1B RID: 199195
		[FieldOffset(16)]
		public byte action;

		// Token: 0x04030A1C RID: 199196
		[FieldOffset(856)]
		public IntPtr __WorldContext;

		// Token: 0x04030A1D RID: 199197
		[FieldOffset(864)]
		public FRotator __Result;
	}

	// Token: 0x02009174 RID: 37236
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 104)]
	protected ref struct __SkillBehaviorSatisfy_FunctionParams
	{
		// Token: 0x04030A1E RID: 199198
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A1F RID: 199199
		[FieldOffset(8)]
		public IntPtr ga;

		// Token: 0x04030A20 RID: 199200
		[FieldOffset(16)]
		public byte condition;

		// Token: 0x04030A21 RID: 199201
		[FieldOffset(88)]
		public IntPtr __WorldContext;

		// Token: 0x04030A22 RID: 199202
		[FieldOffset(96)]
		public bool __Result;
	}

	// Token: 0x02009175 RID: 37237
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetSkillTarget_FunctionParams
	{
		// Token: 0x04030A23 RID: 199203
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A24 RID: 199204
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030A25 RID: 199205
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x02009176 RID: 37238
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetSkillTarget_FunctionParams
	{
		// Token: 0x04030A26 RID: 199206
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A27 RID: 199207
		[FieldOffset(8)]
		public IntPtr target;

		// Token: 0x04030A28 RID: 199208
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009177 RID: 37239
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __LockOnTargetAndSetShow_FunctionParams
	{
		// Token: 0x04030A29 RID: 199209
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A2A RID: 199210
		[FieldOffset(8)]
		public byte config;

		// Token: 0x04030A2B RID: 199211
		[FieldOffset(48)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009178 RID: 37240
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsHasInputDir_FunctionParams
	{
		// Token: 0x04030A2C RID: 199212
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A2D RID: 199213
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030A2E RID: 199214
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009179 RID: 37241
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetSkillIdWithGroupId_FunctionParams
	{
		// Token: 0x04030A2F RID: 199215
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A30 RID: 199216
		[FieldOffset(4)]
		public int groupId;

		// Token: 0x04030A31 RID: 199217
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030A32 RID: 199218
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x0200917A RID: 37242
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetSkillAcceptInput_FunctionParams
	{
		// Token: 0x04030A33 RID: 199219
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A34 RID: 199220
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030A35 RID: 199221
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200917B RID: 37243
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetSkillAcceptInput_FunctionParams
	{
		// Token: 0x04030A36 RID: 199222
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A37 RID: 199223
		[FieldOffset(4)]
		public bool skillAcceptInput;

		// Token: 0x04030A38 RID: 199224
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200917C RID: 37244
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetCommonSkillCanBeInterrupt_FunctionParams
	{
		// Token: 0x04030A39 RID: 199225
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A3A RID: 199226
		[FieldOffset(4)]
		public bool canBeInterrupt;

		// Token: 0x04030A3B RID: 199227
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200917D RID: 37245
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCommonSkillCanBeInterrupt_FunctionParams
	{
		// Token: 0x04030A3C RID: 199228
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A3D RID: 199229
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030A3E RID: 199230
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200917E RID: 37246
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __OnActivateAbility_FunctionParams
	{
		// Token: 0x04030A3F RID: 199231
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A40 RID: 199232
		[FieldOffset(8)]
		public IntPtr ga;

		// Token: 0x04030A41 RID: 199233
		[FieldOffset(16)]
		public bool isCommitSuccess;

		// Token: 0x04030A42 RID: 199234
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04030A43 RID: 199235
		[FieldOffset(32)]
		public float __Result;
	}

	// Token: 0x0200917F RID: 37247
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __OnEndAbility_FunctionParams
	{
		// Token: 0x04030A44 RID: 199236
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A45 RID: 199237
		[FieldOffset(8)]
		public IntPtr ga;

		// Token: 0x04030A46 RID: 199238
		[FieldOffset(16)]
		public bool wasCancelled;

		// Token: 0x04030A47 RID: 199239
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009180 RID: 37248
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetPriority_FunctionParams
	{
		// Token: 0x04030A48 RID: 199240
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A49 RID: 199241
		[FieldOffset(8)]
		public FString skillId;

		// Token: 0x04030A4A RID: 199242
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04030A4B RID: 199243
		[FieldOffset(32)]
		public float __Result;
	}

	// Token: 0x02009181 RID: 37249
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetActivePriority_FunctionParams
	{
		// Token: 0x04030A4C RID: 199244
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A4D RID: 199245
		[FieldOffset(8)]
		public FString skillId;

		// Token: 0x04030A4E RID: 199246
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04030A4F RID: 199247
		[FieldOffset(32)]
		public float __Result;
	}

	// Token: 0x02009182 RID: 37250
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetSkillMontageInstance_FunctionParams
	{
		// Token: 0x04030A50 RID: 199248
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A51 RID: 199249
		[FieldOffset(8)]
		public FString skillId;

		// Token: 0x04030A52 RID: 199250
		[FieldOffset(24)]
		public int index;

		// Token: 0x04030A53 RID: 199251
		[FieldOffset(32)]
		public IntPtr __WorldContext;

		// Token: 0x04030A54 RID: 199252
		[FieldOffset(40)]
		public IntPtr __Result;
	}

	// Token: 0x02009183 RID: 37251
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetSkillNeedPlayMontageIndex_FunctionParams
	{
		// Token: 0x04030A55 RID: 199253
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A56 RID: 199254
		[FieldOffset(8)]
		public FString skillId;

		// Token: 0x04030A57 RID: 199255
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04030A58 RID: 199256
		[FieldOffset(32)]
		public int __Result;
	}

	// Token: 0x02009184 RID: 37252
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __CreateSpecifiedTagPlayMontageAndWaitAbilityTask_FunctionParams
	{
		// Token: 0x04030A59 RID: 199257
		[FieldOffset(0)]
		public IntPtr gameplayAbility;

		// Token: 0x04030A5A RID: 199258
		[FieldOffset(8)]
		public bool checkHit;

		// Token: 0x04030A5B RID: 199259
		[FieldOffset(12)]
		public FGameplayTag skeletalMeshComponentTag;

		// Token: 0x04030A5C RID: 199260
		[FieldOffset(24)]
		public int montageIndex;

		// Token: 0x04030A5D RID: 199261
		[FieldOffset(28)]
		public FName startSection;

		// Token: 0x04030A5E RID: 199262
		[FieldOffset(40)]
		public float startTimeSeconds;

		// Token: 0x04030A5F RID: 199263
		[FieldOffset(44)]
		public bool needTick;

		// Token: 0x04030A60 RID: 199264
		[FieldOffset(48)]
		public float animRootMotionTranslationScale;

		// Token: 0x04030A61 RID: 199265
		[FieldOffset(56)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009185 RID: 37253
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetSkillRotateLocation_FunctionParams
	{
		// Token: 0x04030A62 RID: 199266
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A63 RID: 199267
		[FieldOffset(8)]
		public FVectorDouble location;

		// Token: 0x04030A64 RID: 199268
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009186 RID: 37254
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetSkillRotateDirect_FunctionParams
	{
		// Token: 0x04030A65 RID: 199269
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A66 RID: 199270
		[FieldOffset(8)]
		public FVectorDouble direct;

		// Token: 0x04030A67 RID: 199271
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009187 RID: 37255
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __CallAnimBreakPoint_FunctionParams
	{
		// Token: 0x04030A68 RID: 199272
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A69 RID: 199273
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009188 RID: 37256
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __RollingGround_FunctionParams
	{
		// Token: 0x04030A6A RID: 199274
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A6B RID: 199275
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009189 RID: 37257
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __ActivateAbilityVision_FunctionParams
	{
		// Token: 0x04030A6C RID: 199276
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A6D RID: 199277
		[FieldOffset(4)]
		public byte visionType;

		// Token: 0x04030A6E RID: 199278
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030A6F RID: 199279
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200918A RID: 37258
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __EndAbilityVision_FunctionParams
	{
		// Token: 0x04030A70 RID: 199280
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A71 RID: 199281
		[FieldOffset(4)]
		public byte visionType;

		// Token: 0x04030A72 RID: 199282
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030A73 RID: 199283
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200918B RID: 37259
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ActivateAbilityVisionPlayAudio_FunctionParams
	{
		// Token: 0x04030A74 RID: 199284
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A75 RID: 199285
		[FieldOffset(4)]
		public byte visionType;

		// Token: 0x04030A76 RID: 199286
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200918C RID: 37260
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetVisionIdList_FunctionParams
	{
		// Token: 0x04030A77 RID: 199287
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A78 RID: 199288
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030A79 RID: 199289
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x0200918D RID: 37261
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ExitMultiSkillStateOfMorphVision_FunctionParams
	{
		// Token: 0x04030A7A RID: 199290
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A7B RID: 199291
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200918E RID: 37262
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetKeepMultiSkillState_FunctionParams
	{
		// Token: 0x04030A7C RID: 199292
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A7D RID: 199293
		[FieldOffset(4)]
		public bool keepOnMorphEnd;

		// Token: 0x04030A7E RID: 199294
		[FieldOffset(5)]
		public bool keepOnGoDown;

		// Token: 0x04030A7F RID: 199295
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200918F RID: 37263
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetEnableAttackInputActionOfMorphVision_FunctionParams
	{
		// Token: 0x04030A80 RID: 199296
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A81 RID: 199297
		[FieldOffset(4)]
		public bool bEnable;

		// Token: 0x04030A82 RID: 199298
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009190 RID: 37264
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetVisionLevelList_FunctionParams
	{
		// Token: 0x04030A83 RID: 199299
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A84 RID: 199300
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030A85 RID: 199301
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x02009191 RID: 37265
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetVisionSkillId_FunctionParams
	{
		// Token: 0x04030A86 RID: 199302
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A87 RID: 199303
		[FieldOffset(4)]
		public float visionId;

		// Token: 0x04030A88 RID: 199304
		[FieldOffset(8)]
		public float level;

		// Token: 0x04030A89 RID: 199305
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04030A8A RID: 199306
		[FieldOffset(24)]
		public int __Result;
	}

	// Token: 0x02009192 RID: 37266
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __InterruptSkill_FunctionParams
	{
		// Token: 0x04030A8B RID: 199307
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A8C RID: 199308
		[FieldOffset(8)]
		public FString skillId;

		// Token: 0x04030A8D RID: 199309
		[FieldOffset(24)]
		public bool isSyn;

		// Token: 0x04030A8E RID: 199310
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009193 RID: 37267
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __DeleteSkills_FunctionParams
	{
		// Token: 0x04030A8F RID: 199311
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A90 RID: 199312
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009194 RID: 37268
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetCurrentMontageCorrespondingSkillId_FunctionParams
	{
		// Token: 0x04030A91 RID: 199313
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A92 RID: 199314
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030A93 RID: 199315
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009195 RID: 37269
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SetSocketName_FunctionParams
	{
		// Token: 0x04030A94 RID: 199316
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A95 RID: 199317
		[FieldOffset(8)]
		public FString socketName;

		// Token: 0x04030A96 RID: 199318
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009196 RID: 37270
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetSocketName_FunctionParams
	{
		// Token: 0x04030A97 RID: 199319
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A98 RID: 199320
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030A99 RID: 199321
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009197 RID: 37271
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 96)]
	protected ref struct __GetPointTransform_FunctionParams
	{
		// Token: 0x04030A9A RID: 199322
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A9B RID: 199323
		[FieldOffset(8)]
		public FString boneName;

		// Token: 0x04030A9C RID: 199324
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04030A9D RID: 199325
		[FieldOffset(32)]
		public FTransformDouble __Result;
	}

	// Token: 0x02009198 RID: 37272
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __PlaySkillMontage2Server_FunctionParams
	{
		// Token: 0x04030A9E RID: 199326
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030A9F RID: 199327
		[FieldOffset(8)]
		public FString skillId;

		// Token: 0x04030AA0 RID: 199328
		[FieldOffset(24)]
		public float montageIndex;

		// Token: 0x04030AA1 RID: 199329
		[FieldOffset(28)]
		public float rate;

		// Token: 0x04030AA2 RID: 199330
		[FieldOffset(32)]
		public FString startSection;

		// Token: 0x04030AA3 RID: 199331
		[FieldOffset(48)]
		public float startTimeSeconds;

		// Token: 0x04030AA4 RID: 199332
		[FieldOffset(56)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009199 RID: 37273
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __EndSkillMontage_FunctionParams
	{
		// Token: 0x04030AA5 RID: 199333
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AA6 RID: 199334
		[FieldOffset(8)]
		public FString skillId;

		// Token: 0x04030AA7 RID: 199335
		[FieldOffset(24)]
		public float montageIndex;

		// Token: 0x04030AA8 RID: 199336
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200919A RID: 37274
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __BeginAddMoveByInputDirect_FunctionParams
	{
		// Token: 0x04030AA9 RID: 199337
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AAA RID: 199338
		[FieldOffset(4)]
		public float maxSpeed;

		// Token: 0x04030AAB RID: 199339
		[FieldOffset(8)]
		public float accelerationTime;

		// Token: 0x04030AAC RID: 199340
		[FieldOffset(12)]
		public float decelerationTime;

		// Token: 0x04030AAD RID: 199341
		[FieldOffset(16)]
		public float delayTime;

		// Token: 0x04030AAE RID: 199342
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200919B RID: 37275
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __BeginAbsoluteTimeStop_FunctionParams
	{
		// Token: 0x04030AAF RID: 199343
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AB0 RID: 199344
		[FieldOffset(4)]
		public float duration;

		// Token: 0x04030AB1 RID: 199345
		[FieldOffset(8)]
		public bool stopMove;

		// Token: 0x04030AB2 RID: 199346
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200919C RID: 37276
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EndAbsoluteTimeStop_FunctionParams
	{
		// Token: 0x04030AB3 RID: 199347
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AB4 RID: 199348
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200919D RID: 37277
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __BeginTimeStopRequest_FunctionParams
	{
		// Token: 0x04030AB5 RID: 199349
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AB6 RID: 199350
		[FieldOffset(4)]
		public float duration;

		// Token: 0x04030AB7 RID: 199351
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200919E RID: 37278
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EndTimeStopRequest_FunctionParams
	{
		// Token: 0x04030AB8 RID: 199352
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AB9 RID: 199353
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200919F RID: 37279
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EndAddMoveByInputDirect_FunctionParams
	{
		// Token: 0x04030ABA RID: 199354
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030ABB RID: 199355
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091A0 RID: 37280
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CanActivateFixHook_FunctionParams
	{
		// Token: 0x04030ABC RID: 199356
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030ABD RID: 199357
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030ABE RID: 199358
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091A1 RID: 37281
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __FixHookTargetLocation_FunctionParams
	{
		// Token: 0x04030ABF RID: 199359
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AC0 RID: 199360
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AC1 RID: 199361
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x020091A2 RID: 37282
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __FixHookTargetPathways_FunctionParams
	{
		// Token: 0x04030AC2 RID: 199362
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AC3 RID: 199363
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AC4 RID: 199364
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x020091A3 RID: 37283
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __FixHookTargetEnterPortalCapture_FunctionParams
	{
		// Token: 0x04030AC5 RID: 199365
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AC6 RID: 199366
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AC7 RID: 199367
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x020091A4 RID: 37284
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __FixHookTargetActor_FunctionParams
	{
		// Token: 0x04030AC8 RID: 199368
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AC9 RID: 199369
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030ACA RID: 199370
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x020091A5 RID: 37285
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __FixHookTargetIsSuiGuangType_FunctionParams
	{
		// Token: 0x04030ACB RID: 199371
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030ACC RID: 199372
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030ACD RID: 199373
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091A6 RID: 37286
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetHookTargetType_FunctionParams
	{
		// Token: 0x04030ACE RID: 199374
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030ACF RID: 199375
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AD0 RID: 199376
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x020091A7 RID: 37287
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __FixHookTargetForward_FunctionParams
	{
		// Token: 0x04030AD1 RID: 199377
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AD2 RID: 199378
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AD3 RID: 199379
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x020091A8 RID: 37288
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __NextFixHookTargetLocation_FunctionParams
	{
		// Token: 0x04030AD4 RID: 199380
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AD5 RID: 199381
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AD6 RID: 199382
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x020091A9 RID: 37289
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __FixHookTargetInheritSpeed_FunctionParams
	{
		// Token: 0x04030AD7 RID: 199383
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AD8 RID: 199384
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AD9 RID: 199385
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091AA RID: 37290
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __FixHookTargetIsClimb_FunctionParams
	{
		// Token: 0x04030ADA RID: 199386
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030ADB RID: 199387
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030ADC RID: 199388
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091AB RID: 37291
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetIsHookEndByInterrupt_FunctionParams
	{
		// Token: 0x04030ADD RID: 199389
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030ADE RID: 199390
		[FieldOffset(4)]
		public bool isInterrupt;

		// Token: 0x04030ADF RID: 199391
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091AC RID: 37292
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __FixHookIsSummitPoint_FunctionParams
	{
		// Token: 0x04030AE0 RID: 199392
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AE1 RID: 199393
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AE2 RID: 199394
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091AD RID: 37293
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __FixHookIsNormalPoint_FunctionParams
	{
		// Token: 0x04030AE3 RID: 199395
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AE4 RID: 199396
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AE5 RID: 199397
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091AE RID: 37294
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetHookOverrideSpeed_FunctionParams
	{
		// Token: 0x04030AE6 RID: 199398
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AE7 RID: 199399
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AE8 RID: 199400
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x020091AF RID: 37295
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __FixHookIsGravityPoint_FunctionParams
	{
		// Token: 0x04030AE9 RID: 199401
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AEA RID: 199402
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AEB RID: 199403
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091B0 RID: 37296
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __FixHookTargetEntityId_FunctionParams
	{
		// Token: 0x04030AEC RID: 199404
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AED RID: 199405
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AEE RID: 199406
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x020091B1 RID: 37297
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SlashHookPointHasLookAtConfig_FunctionParams
	{
		// Token: 0x04030AEF RID: 199407
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AF0 RID: 199408
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AF1 RID: 199409
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091B2 RID: 37298
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SlashHookPointCharacterLookAtPoint_FunctionParams
	{
		// Token: 0x04030AF2 RID: 199410
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AF3 RID: 199411
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AF4 RID: 199412
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x020091B3 RID: 37299
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SlashHookPointIsTakeOverCamera_FunctionParams
	{
		// Token: 0x04030AF5 RID: 199413
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AF6 RID: 199414
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AF7 RID: 199415
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091B4 RID: 37300
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SlashHookPointSafePointLoc_FunctionParams
	{
		// Token: 0x04030AF8 RID: 199416
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AF9 RID: 199417
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AFA RID: 199418
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x020091B5 RID: 37301
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SlashHookPointSafePointRot_FunctionParams
	{
		// Token: 0x04030AFB RID: 199419
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AFC RID: 199420
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030AFD RID: 199421
		[FieldOffset(16)]
		public FRotator __Result;
	}

	// Token: 0x020091B6 RID: 37302
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __StartChargeSlash_FunctionParams
	{
		// Token: 0x04030AFE RID: 199422
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030AFF RID: 199423
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091B7 RID: 37303
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __StopChargeSlash_FunctionParams
	{
		// Token: 0x04030B00 RID: 199424
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B01 RID: 199425
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091B8 RID: 37304
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __IsSlashGameplayIsSuccess_FunctionParams
	{
		// Token: 0x04030B02 RID: 199426
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030B03 RID: 199427
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x020091B9 RID: 37305
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetGravityHookLockInfo_FunctionParams
	{
		// Token: 0x04030B04 RID: 199428
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B05 RID: 199429
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B06 RID: 199430
		[FieldOffset(16)]
		public SGravityHookLockInfo __Result;
	}

	// Token: 0x020091BA RID: 37306
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __ChangeGravityByHook_FunctionParams
	{
		// Token: 0x04030B07 RID: 199431
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B08 RID: 199432
		[FieldOffset(4)]
		public int angleRangeMin;

		// Token: 0x04030B09 RID: 199433
		[FieldOffset(8)]
		public int angleRangeMax;

		// Token: 0x04030B0A RID: 199434
		[FieldOffset(12)]
		public float smoothSecondMin;

		// Token: 0x04030B0B RID: 199435
		[FieldOffset(16)]
		public float smoothSecondMax;

		// Token: 0x04030B0C RID: 199436
		[FieldOffset(20)]
		public bool isLerpCamera;

		// Token: 0x04030B0D RID: 199437
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091BB RID: 37307
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SetIgnoreSocketName_FunctionParams
	{
		// Token: 0x04030B0E RID: 199438
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B0F RID: 199439
		[FieldOffset(8)]
		public FString socketName;

		// Token: 0x04030B10 RID: 199440
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091BC RID: 37308
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __DeleteIgnoreSocketName_FunctionParams
	{
		// Token: 0x04030B11 RID: 199441
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B12 RID: 199442
		[FieldOffset(8)]
		public FString socketName;

		// Token: 0x04030B13 RID: 199443
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091BD RID: 37309
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetToTargetSocketDistance_FunctionParams
	{
		// Token: 0x04030B14 RID: 199444
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B15 RID: 199445
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B16 RID: 199446
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020091BE RID: 37310
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 192)]
	protected ref struct __SetPredictProjectileInfo_FunctionParams
	{
		// Token: 0x04030B17 RID: 199447
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B18 RID: 199448
		[FieldOffset(4)]
		public bool returnValue;

		// Token: 0x04030B19 RID: 199449
		[FieldOffset(8)]
		public byte outPathPosition;

		// Token: 0x04030B1A RID: 199450
		[FieldOffset(24)]
		public FVector outLastTraceDestination;

		// Token: 0x04030B1B RID: 199451
		[FieldOffset(36)]
		public byte outHit;

		// Token: 0x04030B1C RID: 199452
		[FieldOffset(184)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091BF RID: 37311
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetVisible_FunctionParams
	{
		// Token: 0x04030B1D RID: 199453
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B1E RID: 199454
		[FieldOffset(4)]
		public bool isShow;

		// Token: 0x04030B1F RID: 199455
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091C0 RID: 37312
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCharUnifiedMoveState_FunctionParams
	{
		// Token: 0x04030B20 RID: 199456
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B21 RID: 199457
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B22 RID: 199458
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x020091C1 RID: 37313
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCharUnifiedPositionState_FunctionParams
	{
		// Token: 0x04030B23 RID: 199459
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B24 RID: 199460
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B25 RID: 199461
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x020091C2 RID: 37314
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ExitHitState_FunctionParams
	{
		// Token: 0x04030B26 RID: 199462
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B27 RID: 199463
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091C3 RID: 37315
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetDirectionState_FunctionParams
	{
		// Token: 0x04030B28 RID: 199464
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B29 RID: 199465
		[FieldOffset(4)]
		public byte newViewState;

		// Token: 0x04030B2A RID: 199466
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091C4 RID: 37316
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetDirectionState_FunctionParams
	{
		// Token: 0x04030B2B RID: 199467
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B2C RID: 199468
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B2D RID: 199469
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x020091C5 RID: 37317
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetIsInGame_FunctionParams
	{
		// Token: 0x04030B2E RID: 199470
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B2F RID: 199471
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B30 RID: 199472
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091C6 RID: 37318
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SprintPress_FunctionParams
	{
		// Token: 0x04030B31 RID: 199473
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B32 RID: 199474
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091C7 RID: 37319
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SprintRelease_FunctionParams
	{
		// Token: 0x04030B33 RID: 199475
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B34 RID: 199476
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091C8 RID: 37320
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __StandPress_FunctionParams
	{
		// Token: 0x04030B35 RID: 199477
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B36 RID: 199478
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091C9 RID: 37321
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SwingPress_FunctionParams
	{
		// Token: 0x04030B37 RID: 199479
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B38 RID: 199480
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091CA RID: 37322
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SwingRelease_FunctionParams
	{
		// Token: 0x04030B39 RID: 199481
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B3A RID: 199482
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091CB RID: 37323
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __CustomSetWalkOrRun_FunctionParams
	{
		// Token: 0x04030B3B RID: 199483
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B3C RID: 199484
		[FieldOffset(4)]
		public bool isWalk;

		// Token: 0x04030B3D RID: 199485
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091CC RID: 37324
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EnterAimStatus_FunctionParams
	{
		// Token: 0x04030B3E RID: 199486
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B3F RID: 199487
		[FieldOffset(4)]
		public byte aimViewState;

		// Token: 0x04030B40 RID: 199488
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091CD RID: 37325
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ExitAimStatus_FunctionParams
	{
		// Token: 0x04030B41 RID: 199489
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B42 RID: 199490
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091CE RID: 37326
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EnableEntity_FunctionParams
	{
		// Token: 0x04030B43 RID: 199491
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B44 RID: 199492
		[FieldOffset(4)]
		public bool isEnable;

		// Token: 0x04030B45 RID: 199493
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091CF RID: 37327
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __UpdateAnimInfoHit_FunctionParams
	{
		// Token: 0x04030B46 RID: 199494
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B47 RID: 199495
		[FieldOffset(8)]
		public IntPtr animLogicParams;

		// Token: 0x04030B48 RID: 199496
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091D0 RID: 37328
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __UpdateAnimInfoFk_FunctionParams
	{
		// Token: 0x04030B49 RID: 199497
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B4A RID: 199498
		[FieldOffset(8)]
		public IntPtr animLogicParams;

		// Token: 0x04030B4B RID: 199499
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091D1 RID: 37329
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __UpdateAnimInfoUnifiedState_FunctionParams
	{
		// Token: 0x04030B4C RID: 199500
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B4D RID: 199501
		[FieldOffset(8)]
		public IntPtr animLogicParams;

		// Token: 0x04030B4E RID: 199502
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091D2 RID: 37330
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __UpdateAnimInfoUnifiedStateRoleNpc_FunctionParams
	{
		// Token: 0x04030B4F RID: 199503
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B50 RID: 199504
		[FieldOffset(8)]
		public IntPtr animLogicParams;

		// Token: 0x04030B51 RID: 199505
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091D3 RID: 37331
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetIsCharRotateWithCameraWhenManipulate_FunctionParams
	{
		// Token: 0x04030B52 RID: 199506
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B53 RID: 199507
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B54 RID: 199508
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091D4 RID: 37332
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetIsUseCatapultUpAnim_FunctionParams
	{
		// Token: 0x04030B55 RID: 199509
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B56 RID: 199510
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B57 RID: 199511
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091D5 RID: 37333
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetNextMultiSkillId_FunctionParams
	{
		// Token: 0x04030B58 RID: 199512
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B59 RID: 199513
		[FieldOffset(4)]
		public int skillId;

		// Token: 0x04030B5A RID: 199514
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B5B RID: 199515
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020091D6 RID: 37334
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetNextMultiSkillIdNew_FunctionParams
	{
		// Token: 0x04030B5C RID: 199516
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B5D RID: 199517
		[FieldOffset(4)]
		public int skillId;

		// Token: 0x04030B5E RID: 199518
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B5F RID: 199519
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x020091D7 RID: 37335
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetManipulateInteractTargetCanInteract_FunctionParams
	{
		// Token: 0x04030B60 RID: 199520
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B61 RID: 199521
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B62 RID: 199522
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091D8 RID: 37336
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetHookInteractTargetCanInteract_FunctionParams
	{
		// Token: 0x04030B63 RID: 199523
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B64 RID: 199524
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B65 RID: 199525
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091D9 RID: 37337
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetHookInteractTargetIsIgnorePlayerCollision_FunctionParams
	{
		// Token: 0x04030B66 RID: 199526
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B67 RID: 199527
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B68 RID: 199528
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091DA RID: 37338
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __StartManipulateInteract_FunctionParams
	{
		// Token: 0x04030B69 RID: 199529
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B6A RID: 199530
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B6B RID: 199531
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091DB RID: 37339
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EndManipulateInteract_FunctionParams
	{
		// Token: 0x04030B6C RID: 199532
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B6D RID: 199533
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091DC RID: 37340
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __StartStatueInteract_FunctionParams
	{
		// Token: 0x04030B6E RID: 199534
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B6F RID: 199535
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B70 RID: 199536
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091DD RID: 37341
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EndStatueInteract_FunctionParams
	{
		// Token: 0x04030B71 RID: 199537
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B72 RID: 199538
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091DE RID: 37342
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __StartCustomInteract_FunctionParams
	{
		// Token: 0x04030B73 RID: 199539
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B74 RID: 199540
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B75 RID: 199541
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091DF RID: 37343
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EndCustomInteract_FunctionParams
	{
		// Token: 0x04030B76 RID: 199542
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B77 RID: 199543
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091E0 RID: 37344
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __QuantumDiffusionInteract_FunctionParams
	{
		// Token: 0x04030B78 RID: 199544
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B79 RID: 199545
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091E1 RID: 37345
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetShootSwordManipulateInteractActors_FunctionParams
	{
		// Token: 0x04030B7A RID: 199546
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B7B RID: 199547
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B7C RID: 199548
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x020091E2 RID: 37346
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetManipulateInteractLocation_FunctionParams
	{
		// Token: 0x04030B7D RID: 199549
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B7E RID: 199550
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B7F RID: 199551
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x020091E3 RID: 37347
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __EnvironmentInfoDetect_FunctionParams
	{
		// Token: 0x04030B80 RID: 199552
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B81 RID: 199553
		[FieldOffset(8)]
		public FVectorDouble location;

		// Token: 0x04030B82 RID: 199554
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091E4 RID: 37348
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __LockOnSpecifyTarget_FunctionParams
	{
		// Token: 0x04030B83 RID: 199555
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B84 RID: 199556
		[FieldOffset(4)]
		public int targetEntityId;

		// Token: 0x04030B85 RID: 199557
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091E5 RID: 37349
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsSkillInCd_FunctionParams
	{
		// Token: 0x04030B86 RID: 199558
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B87 RID: 199559
		[FieldOffset(4)]
		public int skillId;

		// Token: 0x04030B88 RID: 199560
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030B89 RID: 199561
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020091E6 RID: 37350
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SendHookSkillUseLogData_FunctionParams
	{
		// Token: 0x04030B8A RID: 199562
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B8B RID: 199563
		[FieldOffset(4)]
		public bool hasTarget;

		// Token: 0x04030B8C RID: 199564
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091E7 RID: 37351
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SendManipulateSkillUseLogData_FunctionParams
	{
		// Token: 0x04030B8D RID: 199565
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B8E RID: 199566
		[FieldOffset(4)]
		public bool hasTarget;

		// Token: 0x04030B8F RID: 199567
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091E8 RID: 37352
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SendScanSkillUseLogData_FunctionParams
	{
		// Token: 0x04030B90 RID: 199568
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B91 RID: 199569
		[FieldOffset(4)]
		public bool hasTarget;

		// Token: 0x04030B92 RID: 199570
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091E9 RID: 37353
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __DynamicAttachEntityToActor_FunctionParams
	{
		// Token: 0x04030B93 RID: 199571
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B94 RID: 199572
		[FieldOffset(4)]
		public int targetEntityId;

		// Token: 0x04030B95 RID: 199573
		[FieldOffset(8)]
		public FName socketName;

		// Token: 0x04030B96 RID: 199574
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091EA RID: 37354
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetEntityEnable_FunctionParams
	{
		// Token: 0x04030B97 RID: 199575
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B98 RID: 199576
		[FieldOffset(4)]
		public bool enable;

		// Token: 0x04030B99 RID: 199577
		[FieldOffset(8)]
		public IntPtr callObject;

		// Token: 0x04030B9A RID: 199578
		[FieldOffset(16)]
		public FString reason;

		// Token: 0x04030B9B RID: 199579
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091EB RID: 37355
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetActorVisible_FunctionParams
	{
		// Token: 0x04030B9C RID: 199580
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030B9D RID: 199581
		[FieldOffset(4)]
		public bool visible;

		// Token: 0x04030B9E RID: 199582
		[FieldOffset(5)]
		public bool collision;

		// Token: 0x04030B9F RID: 199583
		[FieldOffset(6)]
		public bool movable;

		// Token: 0x04030BA0 RID: 199584
		[FieldOffset(8)]
		public FString reason;

		// Token: 0x04030BA1 RID: 199585
		[FieldOffset(24)]
		public bool sync;

		// Token: 0x04030BA2 RID: 199586
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091EC RID: 37356
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetSkillTargetDirection_FunctionParams
	{
		// Token: 0x04030BA3 RID: 199587
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BA4 RID: 199588
		[FieldOffset(4)]
		public byte direction;

		// Token: 0x04030BA5 RID: 199589
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091ED RID: 37357
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ChangeAiControllerDebugDraw_FunctionParams
	{
		// Token: 0x04030BA6 RID: 199590
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BA7 RID: 199591
		[FieldOffset(4)]
		public bool debug;

		// Token: 0x04030BA8 RID: 199592
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091EE RID: 37358
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBeHitAnimType_FunctionParams
	{
		// Token: 0x04030BA9 RID: 199593
		[FieldOffset(0)]
		public int typeId;

		// Token: 0x04030BAA RID: 199594
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030BAB RID: 199595
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x020091EF RID: 37359
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __StartInhalation_FunctionParams
	{
		// Token: 0x04030BAC RID: 199596
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BAD RID: 199597
		[FieldOffset(4)]
		public float strength;

		// Token: 0x04030BAE RID: 199598
		[FieldOffset(8)]
		public float distance;

		// Token: 0x04030BAF RID: 199599
		[FieldOffset(12)]
		public bool isPowerfulMode;

		// Token: 0x04030BB0 RID: 199600
		[FieldOffset(16)]
		public float checkAngle;

		// Token: 0x04030BB1 RID: 199601
		[FieldOffset(24)]
		public byte tag;

		// Token: 0x04030BB2 RID: 199602
		[FieldOffset(40)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091F0 RID: 37360
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __StopInhalation_FunctionParams
	{
		// Token: 0x04030BB3 RID: 199603
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BB4 RID: 199604
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091F1 RID: 37361
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __TryGetDebugMovementComp_FunctionParams
	{
		// Token: 0x04030BB5 RID: 199605
		[FieldOffset(0)]
		public FString pbDataId;

		// Token: 0x04030BB6 RID: 199606
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04030BB7 RID: 199607
		[FieldOffset(24)]
		public IntPtr __Result;
	}

	// Token: 0x020091F2 RID: 37362
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __TryPlayLinkAnim_FunctionParams
	{
		// Token: 0x04030BB8 RID: 199608
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091F3 RID: 37363
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 96)]
	protected ref struct __TraceGround_FunctionParams
	{
		// Token: 0x04030BB9 RID: 199609
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BBA RID: 199610
		[FieldOffset(8)]
		public FVectorDouble start;

		// Token: 0x04030BBB RID: 199611
		[FieldOffset(32)]
		public FVectorDouble end;

		// Token: 0x04030BBC RID: 199612
		[FieldOffset(56)]
		public bool draw;

		// Token: 0x04030BBD RID: 199613
		[FieldOffset(64)]
		public IntPtr __WorldContext;

		// Token: 0x04030BBE RID: 199614
		[FieldOffset(72)]
		public FVectorDouble __Result;
	}

	// Token: 0x020091F4 RID: 37364
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __ChangePhantomTeam_FunctionParams
	{
		// Token: 0x04030BBF RID: 199615
		[FieldOffset(0)]
		public int phantomFormationId;

		// Token: 0x04030BC0 RID: 199616
		[FieldOffset(8)]
		public byte skillTriggerTags;

		// Token: 0x04030BC1 RID: 199617
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091F5 RID: 37365
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __RevertPhantomTeam_FunctionParams
	{
		// Token: 0x04030BC2 RID: 199618
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091F6 RID: 37366
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetFormationAttribute_FunctionParams
	{
		// Token: 0x04030BC3 RID: 199619
		[FieldOffset(0)]
		public int type;

		// Token: 0x04030BC4 RID: 199620
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030BC5 RID: 199621
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020091F7 RID: 37367
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetEntityDeltaMillisecond_FunctionParams
	{
		// Token: 0x04030BC6 RID: 199622
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BC7 RID: 199623
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030BC8 RID: 199624
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020091F8 RID: 37368
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SyncTwoEntityLocationAndRotation_FunctionParams
	{
		// Token: 0x04030BC9 RID: 199625
		[FieldOffset(0)]
		public int fromEntityId;

		// Token: 0x04030BCA RID: 199626
		[FieldOffset(4)]
		public int toEntityId;

		// Token: 0x04030BCB RID: 199627
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091F9 RID: 37369
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetFishingBoat_FunctionParams
	{
		// Token: 0x04030BCC RID: 199628
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030BCD RID: 199629
		[FieldOffset(8)]
		public IntPtr __Result;
	}

	// Token: 0x020091FA RID: 37370
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __FishingBoatSprint_FunctionParams
	{
		// Token: 0x04030BCE RID: 199630
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BCF RID: 199631
		[FieldOffset(4)]
		public float maxSpeedRatio;

		// Token: 0x04030BD0 RID: 199632
		[FieldOffset(8)]
		public int exceedLimitDuration;

		// Token: 0x04030BD1 RID: 199633
		[FieldOffset(12)]
		public int duration;

		// Token: 0x04030BD2 RID: 199634
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091FB RID: 37371
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __FishingBoatSkill_FunctionParams
	{
		// Token: 0x04030BD3 RID: 199635
		[FieldOffset(0)]
		public byte type;

		// Token: 0x04030BD4 RID: 199636
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091FC RID: 37372
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCharacterMorphType_FunctionParams
	{
		// Token: 0x04030BD5 RID: 199637
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BD6 RID: 199638
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030BD7 RID: 199639
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x020091FD RID: 37373
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetCharacterMorphType_FunctionParams
	{
		// Token: 0x04030BD8 RID: 199640
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BD9 RID: 199641
		[FieldOffset(4)]
		public byte morphType;

		// Token: 0x04030BDA RID: 199642
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091FE RID: 37374
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetSpecialEnergyAttrValue_FunctionParams
	{
		// Token: 0x04030BDB RID: 199643
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BDC RID: 199644
		[FieldOffset(4)]
		public int attrId;

		// Token: 0x04030BDD RID: 199645
		[FieldOffset(8)]
		public int value;

		// Token: 0x04030BDE RID: 199646
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020091FF RID: 37375
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetFuLuoLuoSpecialEnergyType_FunctionParams
	{
		// Token: 0x04030BDF RID: 199647
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BE0 RID: 199648
		[FieldOffset(4)]
		public int index;

		// Token: 0x04030BE1 RID: 199649
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030BE2 RID: 199650
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x02009200 RID: 37376
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __StartBattleQte_FunctionParams
	{
		// Token: 0x04030BE3 RID: 199651
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BE4 RID: 199652
		[FieldOffset(4)]
		public int skillId;

		// Token: 0x04030BE5 RID: 199653
		[FieldOffset(8)]
		public int battleQteId;

		// Token: 0x04030BE6 RID: 199654
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009201 RID: 37377
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __StopGroup1Skill_FunctionParams
	{
		// Token: 0x04030BE7 RID: 199655
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BE8 RID: 199656
		[FieldOffset(8)]
		public FString reason;

		// Token: 0x04030BE9 RID: 199657
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009202 RID: 37378
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 88)]
	protected ref struct __GetCharactersLocationNearBy_FunctionParams
	{
		// Token: 0x04030BEA RID: 199658
		[FieldOffset(0)]
		public FVectorDouble center;

		// Token: 0x04030BEB RID: 199659
		[FieldOffset(24)]
		public float distance;

		// Token: 0x04030BEC RID: 199660
		[FieldOffset(28)]
		public int maxCount;

		// Token: 0x04030BED RID: 199661
		[FieldOffset(32)]
		public IntPtr __WorldContext;

		// Token: 0x04030BEE RID: 199662
		[FieldOffset(40)]
		public byte __Result;
	}

	// Token: 0x02009203 RID: 37379
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetCurrentPlayer_FunctionParams
	{
		// Token: 0x04030BEF RID: 199663
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030BF0 RID: 199664
		[FieldOffset(8)]
		public IntPtr __Result;
	}

	// Token: 0x02009204 RID: 37380
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __IsEnemy_FunctionParams
	{
		// Token: 0x04030BF1 RID: 199665
		[FieldOffset(0)]
		public IntPtr owner;

		// Token: 0x04030BF2 RID: 199666
		[FieldOffset(8)]
		public IntPtr other;

		// Token: 0x04030BF3 RID: 199667
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04030BF4 RID: 199668
		[FieldOffset(24)]
		public bool __Result;
	}

	// Token: 0x02009205 RID: 37381
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetWalkOffLedge_FunctionParams
	{
		// Token: 0x04030BF5 RID: 199669
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030BF6 RID: 199670
		[FieldOffset(4)]
		public bool walkOff;

		// Token: 0x04030BF7 RID: 199671
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009206 RID: 37382
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __StartFlyingFeather_FunctionParams
	{
		// Token: 0x04030BF8 RID: 199672
		[FieldOffset(0)]
		public IntPtr owner;

		// Token: 0x04030BF9 RID: 199673
		[FieldOffset(8)]
		public FVectorDouble initLocation;

		// Token: 0x04030BFA RID: 199674
		[FieldOffset(32)]
		public IntPtr config;

		// Token: 0x04030BFB RID: 199675
		[FieldOffset(40)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009207 RID: 37383
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetFlyingFeatherTargetId_FunctionParams
	{
		// Token: 0x04030BFC RID: 199676
		[FieldOffset(0)]
		public IntPtr owner;

		// Token: 0x04030BFD RID: 199677
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030BFE RID: 199678
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009208 RID: 37384
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __AddFlyingFeatherTargetTag_FunctionParams
	{
		// Token: 0x04030BFF RID: 199679
		[FieldOffset(0)]
		public FGameplayTag tag;

		// Token: 0x04030C00 RID: 199680
		[FieldOffset(16)]
		public FString entityId;

		// Token: 0x04030C01 RID: 199681
		[FieldOffset(32)]
		public IntPtr __WorldContext;

		// Token: 0x04030C02 RID: 199682
		[FieldOffset(40)]
		public IntPtr __Result;
	}

	// Token: 0x02009209 RID: 37385
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __UpdateFlyingFeather_FunctionParams
	{
		// Token: 0x04030C03 RID: 199683
		[FieldOffset(0)]
		public IntPtr owner;

		// Token: 0x04030C04 RID: 199684
		[FieldOffset(8)]
		public FString target;

		// Token: 0x04030C05 RID: 199685
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04030C06 RID: 199686
		[FieldOffset(32)]
		public FVectorDouble __Result;
	}

	// Token: 0x0200920A RID: 37386
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __EmitGlobalClientEvent_FunctionParams
	{
		// Token: 0x04030C07 RID: 199687
		[FieldOffset(0)]
		public FGameplayTag eventNameTag;

		// Token: 0x04030C08 RID: 199688
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200920B RID: 37387
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetDriverEntityId_FunctionParams
	{
		// Token: 0x04030C09 RID: 199689
		[FieldOffset(0)]
		public int vehicleEntityId;

		// Token: 0x04030C0A RID: 199690
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C0B RID: 199691
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x0200920C RID: 37388
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __StartCableWayMove_FunctionParams
	{
		// Token: 0x04030C0C RID: 199692
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030C0D RID: 199693
		[FieldOffset(8)]
		public IntPtr eventBinder;

		// Token: 0x04030C0E RID: 199694
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200920D RID: 37389
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __StopCableWayMove_FunctionParams
	{
		// Token: 0x04030C0F RID: 199695
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030C10 RID: 199696
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200920E RID: 37390
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetBuffInstigatorId_FunctionParams
	{
		// Token: 0x04030C11 RID: 199697
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C12 RID: 199698
		[FieldOffset(4)]
		public int buffId;

		// Token: 0x04030C13 RID: 199699
		[FieldOffset(8)]
		public bool getInstigatorSummoner;

		// Token: 0x04030C14 RID: 199700
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04030C15 RID: 199701
		[FieldOffset(24)]
		public int __Result;
	}

	// Token: 0x0200920F RID: 37391
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 104)]
	protected ref struct __SetSubMeshOrder_FunctionParams
	{
		// Token: 0x04030C16 RID: 199702
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C17 RID: 199703
		[FieldOffset(8)]
		public FString meshName;

		// Token: 0x04030C18 RID: 199704
		[FieldOffset(24)]
		public bool visible;

		// Token: 0x04030C19 RID: 199705
		[FieldOffset(32)]
		public IntPtr charControllerData;

		// Token: 0x04030C1A RID: 199706
		[FieldOffset(40)]
		public byte effectDataAssetRef;

		// Token: 0x04030C1B RID: 199707
		[FieldOffset(88)]
		public float delayTime;

		// Token: 0x04030C1C RID: 199708
		[FieldOffset(96)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009210 RID: 37392
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetPilotThrowSpeed_FunctionParams
	{
		// Token: 0x04030C1D RID: 199709
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030C1E RID: 199710
		[FieldOffset(8)]
		public float __Result;
	}

	// Token: 0x02009211 RID: 37393
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetPilotThrowDirection_FunctionParams
	{
		// Token: 0x04030C1F RID: 199711
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030C20 RID: 199712
		[FieldOffset(8)]
		public FVectorDouble __Result;
	}

	// Token: 0x02009212 RID: 37394
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetPilotThrowGravity_FunctionParams
	{
		// Token: 0x04030C21 RID: 199713
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030C22 RID: 199714
		[FieldOffset(8)]
		public float __Result;
	}

	// Token: 0x02009213 RID: 37395
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetPilotThrowNeedMotorRide_FunctionParams
	{
		// Token: 0x04030C23 RID: 199715
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030C24 RID: 199716
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x02009214 RID: 37396
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetPilotThrowIsDisableInterrupt_FunctionParams
	{
		// Token: 0x04030C25 RID: 199717
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030C26 RID: 199718
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x02009215 RID: 37397
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __OpenPilotThrowGameplayCamera_FunctionParams
	{
		// Token: 0x04030C27 RID: 199719
		[FieldOffset(0)]
		public int targetEntityId;

		// Token: 0x04030C28 RID: 199720
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009216 RID: 37398
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCurrentTargetPilotSkeletalMeshComponent_FunctionParams
	{
		// Token: 0x04030C29 RID: 199721
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C2A RID: 199722
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C2B RID: 199723
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x02009217 RID: 37399
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetPilotCurrentInRangePoint_FunctionParams
	{
		// Token: 0x04030C2C RID: 199724
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030C2D RID: 199725
		[FieldOffset(8)]
		public FVectorDouble __Result;
	}

	// Token: 0x02009218 RID: 37400
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetVehicleCatapultUnitRisingTime_FunctionParams
	{
		// Token: 0x04030C2E RID: 199726
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C2F RID: 199727
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C30 RID: 199728
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009219 RID: 37401
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __GuessJokerNpcTurnToIdlePerform_FunctionParams
	{
		// Token: 0x04030C31 RID: 199729
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200921A RID: 37402
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __LevelFlowDeadlySkeletonMeshCastToCharacter_FunctionParams
	{
		// Token: 0x04030C32 RID: 199730
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200921B RID: 37403
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __LevelFlowAddBuff_FunctionParams
	{
		// Token: 0x04030C33 RID: 199731
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C34 RID: 199732
		[FieldOffset(4)]
		public int buffId;

		// Token: 0x04030C35 RID: 199733
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200921C RID: 37404
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __LevelFlowRemoveBuff_FunctionParams
	{
		// Token: 0x04030C36 RID: 199734
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C37 RID: 199735
		[FieldOffset(4)]
		public int buffId;

		// Token: 0x04030C38 RID: 199736
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200921D RID: 37405
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __LevelFlowCameraShake_FunctionParams
	{
		// Token: 0x04030C39 RID: 199737
		[FieldOffset(0)]
		public FString cameraShakeBp;

		// Token: 0x04030C3A RID: 199738
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200921E RID: 37406
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __LevelFlowPlayLevelSequence_FunctionParams
	{
		// Token: 0x04030C3B RID: 199739
		[FieldOffset(0)]
		public FString path;

		// Token: 0x04030C3C RID: 199740
		[FieldOffset(16)]
		public FString mark;

		// Token: 0x04030C3D RID: 199741
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200921F RID: 37407
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __XigelikaAddBean_FunctionParams
	{
		// Token: 0x04030C3E RID: 199742
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C3F RID: 199743
		[FieldOffset(8)]
		public FString bean;

		// Token: 0x04030C40 RID: 199744
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04030C41 RID: 199745
		[FieldOffset(32)]
		public int __Result;
	}

	// Token: 0x02009220 RID: 37408
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __XigelikaGetBeanResultant_FunctionParams
	{
		// Token: 0x04030C42 RID: 199746
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C43 RID: 199747
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C44 RID: 199748
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x02009221 RID: 37409
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __XigelikaConsumeBean_FunctionParams
	{
		// Token: 0x04030C45 RID: 199749
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C46 RID: 199750
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009222 RID: 37410
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __XigelikaResetBean_FunctionParams
	{
		// Token: 0x04030C47 RID: 199751
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030C48 RID: 199752
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009223 RID: 37411
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __OpenQuickHack_FunctionParams
	{
		// Token: 0x04030C49 RID: 199753
		[FieldOffset(0)]
		public int deviceId;

		// Token: 0x04030C4A RID: 199754
		[FieldOffset(4)]
		public int ownerEntityId;

		// Token: 0x04030C4B RID: 199755
		[FieldOffset(8)]
		public bool closeWhenInteractFinish;

		// Token: 0x04030C4C RID: 199756
		[FieldOffset(12)]
		public FGameplayTag interactFinishGameplayEventTag;

		// Token: 0x04030C4D RID: 199757
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009224 RID: 37412
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __CloseQuickHack_FunctionParams
	{
		// Token: 0x04030C4E RID: 199758
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009225 RID: 37413
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __FunctionOpen_FunctionParams
	{
		// Token: 0x04030C4F RID: 199759
		[FieldOffset(0)]
		public int functionType;

		// Token: 0x04030C50 RID: 199760
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030C51 RID: 199761
		[FieldOffset(16)]
		public bool __Result;
	}
}
