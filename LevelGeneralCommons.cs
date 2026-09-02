using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.CreatureTools;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

// Token: 0x02000FA0 RID: 4000
[NullableContext(1)]
[Nullable(0)]
public class LevelGeneralCommons : IStaticVariableResetter
{
	// Token: 0x06006632 RID: 26162 RVA: 0x0019BAB5 File Offset: 0x00199CB5
	static LevelGeneralCommons()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(LevelGeneralCommons.CreateStaticDefaultValue), new Action(LevelGeneralCommons.ResetStaticDefaultValue));
	}

	// Token: 0x06006633 RID: 26163 RVA: 0x0019BAD4 File Offset: 0x00199CD4
	public static void Init()
	{
		LevelGeneralCommons.TempTags = new List<string>();
		LevelGeneralCommons.TempFindEntities = new List<EntityHandle>();
	}

	// Token: 0x06006634 RID: 26164 RVA: 0x0019BAEA File Offset: 0x00199CEA
	public static void Clear()
	{
		if (LevelGeneralCommons.TempTags != null)
		{
			LevelGeneralCommons.TempTags.Clear();
		}
		if (LevelGeneralCommons.TempFindEntities != null)
		{
			LevelGeneralCommons.TempFindEntities.Clear();
		}
	}

	// Token: 0x06006635 RID: 26165 RVA: 0x0019BB10 File Offset: 0x00199D10
	public static void AddPublicTag(string inTag, AActor inTarget)
	{
		if (LevelGeneralCommons.TempTags == null)
		{
			return;
		}
		IBPI_CreatureInterface_C ibpi_CreatureInterface_C = inTarget as IBPI_CreatureInterface_C;
		if (ibpi_CreatureInterface_C == null)
		{
			return;
		}
		LevelGeneralCommons.TempTags.Clear();
		LevelGeneralCommons.TempTags.Add(inTag);
		ControllerBase<CreatureController>.Instance.AddPublicTags(ibpi_CreatureInterface_C.GetEntityId(), LevelGeneralCommons.TempTags);
	}

	// Token: 0x06006636 RID: 26166 RVA: 0x0019BB5C File Offset: 0x00199D5C
	public static void RemovePublicTag(string inTag, AActor inTarget)
	{
		if (LevelGeneralCommons.TempTags == null)
		{
			return;
		}
		IBPI_CreatureInterface_C ibpi_CreatureInterface_C = inTarget as IBPI_CreatureInterface_C;
		if (ibpi_CreatureInterface_C == null)
		{
			return;
		}
		LevelGeneralCommons.TempTags.Clear();
		LevelGeneralCommons.TempTags.Add(inTag);
		ControllerBase<CreatureController>.Instance.RemovePublicTags(ibpi_CreatureInterface_C.GetEntityId(), LevelGeneralCommons.TempTags);
	}

	// Token: 0x06006637 RID: 26167 RVA: 0x0019BBA6 File Offset: 0x00199DA6
	[return: Nullable(2)]
	public static AActor FindTargetWithTag(string inTag)
	{
		if (LevelGeneralCommons.TempFindEntities == null)
		{
			return null;
		}
		ModelBase<CreatureModel>.Instance.GetEntitiesWithTag(inTag, ref LevelGeneralCommons.TempFindEntities);
		if (LevelGeneralCommons.TempFindEntities.Count == 0)
		{
			return null;
		}
		return ControllerBase<CharacterController>.Instance.GetActor(LevelGeneralCommons.TempFindEntities[0]);
	}

	// Token: 0x06006638 RID: 26168 RVA: 0x0019BBE4 File Offset: 0x00199DE4
	public static void FindTargetsWithTag(string inTag, ref List<AActor> refActors)
	{
		if (LevelGeneralCommons.TempFindEntities == null)
		{
			return;
		}
		refActors.Clear();
		ModelBase<CreatureModel>.Instance.GetEntitiesWithTag(inTag, ref LevelGeneralCommons.TempFindEntities);
		if (LevelGeneralCommons.TempFindEntities.Count == 0)
		{
			return;
		}
		foreach (EntityHandle entity in LevelGeneralCommons.TempFindEntities)
		{
			AActor actor = ControllerBase<CharacterController>.Instance.GetActor(entity);
			if (actor != null)
			{
				refActors.Add(actor);
			}
		}
	}

	// Token: 0x06006639 RID: 26169 RVA: 0x0019BC74 File Offset: 0x00199E74
	public unsafe static void UpdateEntityTag(int inEntityId, string inTag, bool isAdd)
	{
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(inEntityId);
		if (entityById == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Level;
			ELogAuthor author = ELogAuthor.YZH;
			string message = "[ControllerHolder.LevelGeneralController.UpdateEntityTag] 无法找到对应entity 修改tag";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", inEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Tag", inTag);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		AActor actor = ControllerBase<CharacterController>.Instance.GetActor(entityById);
		if (actor == null)
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Level;
			ELogAuthor author2 = ELogAuthor.YZH;
			string message2 = "[ControllerHolder.LevelGeneralController.UpdateEntityTag] 无法找到对应表现Actor 修改tag";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", inEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Tag", inTag);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		FName value = FNameUtil.GetDynamicFName(inTag).Value;
		if (isAdd)
		{
			actor.Tags.Add(value);
			LevelGeneralCommons.AddPublicTag(inTag, actor);
			return;
		}
		int num = actor.Tags.FindIndex(value);
		if (num == -1)
		{
			return;
		}
		actor.Tags.RemoveAt(num);
		LevelGeneralCommons.RemovePublicTag(inTag, actor);
	}

	// Token: 0x0600663A RID: 26170 RVA: 0x0019BDA0 File Offset: 0x00199FA0
	[NullableContext(2)]
	public static string GetConditionGroupHintText(int inConditionGroupId)
	{
		ConditionGroup? config = ConfigConditionGroupById.GetConfig(inConditionGroupId, true);
		if (config == null)
		{
			return null;
		}
		return config.GetValueOrDefault().HintText;
	}

	// Token: 0x0600663B RID: 26171 RVA: 0x0019BDD0 File Offset: 0x00199FD0
	public static void PrechangeStateTag(int pbDataId, int tagId, string reason)
	{
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
		if (entityByPbDataId == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Level;
			ELogAuthor author = ELogAuthor.CH;
			string message = "[ChangePerformanceTag] 找不到对应的Entity";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataId", pbDataId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (entityByPbDataId.IsInit)
		{
			LevelGeneralCommons.PrechangeStateTagInternal(pbDataId, entityByPbDataId, tagId);
			return;
		}
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module2 = ELogModule.Level;
		ELogAuthor author2 = ELogAuthor.CH;
		string message2 = "[ChangePerformanceTag] 对应的Entity并未初始化完成";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("pbDataId", pbDataId);
		instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
	}

	// Token: 0x0600663C RID: 26172 RVA: 0x0019BE58 File Offset: 0x0019A058
	private unsafe static void PrechangeStateTagInternal(int pbDataId, EntityHandle handle, int tagId)
	{
		WorldEntity entity = handle.Entity;
		LevelTagComponent levelTagComponent = (entity != null) ? entity.GetComponent<LevelTagComponent>() : null;
		if (levelTagComponent == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Level;
			ELogAuthor author = ELogAuthor.CH;
			string message = "[ChangePerformanceTag] 找不到对应的LevelTagComponent";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataId", pbDataId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		string nameByTagId = GameplayTagUtils.GetNameByTagId(tagId);
		if (levelTagComponent.HasTag(tagId))
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Level;
			ELogAuthor author2 = ELogAuthor.ZYL;
			string message2 = "[ChangePerformanceTag] 已经拥有该状态Tag, 无需再切状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TagName", nameByTagId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("pbDataId", pbDataId);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		WorldEntity entity2 = handle.Entity;
		CreatureDataComponent creatureDataComponent = (entity2 != null) ? entity2.GetComponent<CreatureDataComponent>() : null;
		EntityStateComponent component = TdUtils.GetComponent<EntityStateComponent>(((creatureDataComponent != null) ? creatureDataComponent.GetPbEntityInitData() : null).ComponentsData, EConfigComponent.EntityStateComponent);
		foreach (string state in IActionDefine.GetStatesByType(component.Type))
		{
			int tagIdByName = GameplayTagUtils.GetTagIdByName(IActionDefine.GetEntityStateTag(component.Type, state));
			levelTagComponent.RemoveServerTagByIdLocal(tagIdByName, "ChangePerformanceTag");
		}
		levelTagComponent.AddServerTagByIdLocal(tagId, "ChangePerformanceTag");
		Singleton<EventSystem>.Instance.EmitWithTarget<int>(handle.Entity, EEventName.OnSceneItemStatePreChangeInSequence, tagId);
	}

	// Token: 0x0600663D RID: 26173 RVA: 0x0019BFC4 File Offset: 0x0019A1C4
	public static void ChangeToDestroyState(int pbDataId)
	{
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
		if (entityByPbDataId == null)
		{
			return;
		}
		if (!entityByPbDataId.IsInit)
		{
			return;
		}
		WorldEntity entity = entityByPbDataId.Entity;
		LevelTagComponent levelTagComponent = (entity != null) ? entity.GetComponent<LevelTagComponent>() : null;
		WorldEntity entity2 = entityByPbDataId.Entity;
		SceneItemStateComponent sceneItemStateComponent = (entity2 != null) ? entity2.GetComponent<SceneItemStateComponent>() : null;
		if (sceneItemStateComponent != null)
		{
			int stateTagId = sceneItemStateComponent.StateTagId;
			if (levelTagComponent != null)
			{
				levelTagComponent.RemoveServerTagByIdLocal(sceneItemStateComponent.StateTagId, "ChangeToDestroyState");
			}
		}
		if (levelTagComponent != null)
		{
			levelTagComponent.AddServerTagByIdLocal(GameplayTagDefine.EGameplayTagId["关卡.Common.状态.销毁"], "ChangeToDestroyState");
		}
	}

	// Token: 0x0600663E RID: 26174 RVA: 0x0019C04C File Offset: 0x0019A24C
	public static void RollbackDestroyState(int pbDataId, int tagId)
	{
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
		if (entityByPbDataId == null)
		{
			return;
		}
		if (!entityByPbDataId.IsInit)
		{
			return;
		}
		WorldEntity entity = entityByPbDataId.Entity;
		LevelTagComponent levelTagComponent = (entity != null) ? entity.GetComponent<LevelTagComponent>() : null;
		WorldEntity entity2 = entityByPbDataId.Entity;
		SceneItemStateComponent sceneItemStateComponent = (entity2 != null) ? entity2.GetComponent<SceneItemStateComponent>() : null;
		bool flag;
		if (sceneItemStateComponent == null)
		{
			flag = false;
		}
		else
		{
			int stateTagId = sceneItemStateComponent.StateTagId;
			flag = true;
		}
		if (flag && levelTagComponent != null)
		{
			levelTagComponent.RemoveServerTagByIdLocal(GameplayTagDefine.EGameplayTagId["关卡.Common.状态.销毁"], "RollbackDestroyState");
		}
		if (levelTagComponent != null)
		{
			levelTagComponent.AddServerTagByIdLocal(tagId, "RollbackDestroyState");
		}
	}

	// Token: 0x0600663F RID: 26175 RVA: 0x0019C0D3 File Offset: 0x0019A2D3
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x06006640 RID: 26176 RVA: 0x0019C0D5 File Offset: 0x0019A2D5
	public static void ResetStaticDefaultValue()
	{
		LevelGeneralCommons.TempTags = null;
		LevelGeneralCommons.TempFindEntities = null;
	}

	// Token: 0x0400308C RID: 12428
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<string> TempTags;

	// Token: 0x0400308D RID: 12429
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<EntityHandle> TempFindEntities;
}
