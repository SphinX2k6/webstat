using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001AAE RID: 6830
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class DamageUiController : ControllerBase<DamageUiController>
{
	// Token: 0x0600C3AD RID: 50093 RVA: 0x003395F9 File Offset: 0x003377F9
	protected override bool OnInit()
	{
		Singleton<DamageUiManager>.Instance.Initialize();
		this.AddEvents();
		return true;
	}

	// Token: 0x0600C3AE RID: 50094 RVA: 0x0033960C File Offset: 0x0033780C
	protected override bool OnClear()
	{
		this.RemoveEvents();
		Singleton<DamageUiManager>.Instance.Clear();
		Singleton<DamageUiManager>.Instance.ClearDamageViewData();
		this.StopUeDamageUiManager();
		return true;
	}

	// Token: 0x0600C3AF RID: 50095 RVA: 0x0033962F File Offset: 0x0033782F
	protected override bool OnLeaveLevel()
	{
		Singleton<DamageUiManager>.Instance.OnLeaveLevel();
		this.StopUeDamageUiManager();
		return true;
	}

	// Token: 0x0600C3B0 RID: 50096 RVA: 0x00339644 File Offset: 0x00337844
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	protected override ValueTuple<string, CustomPromise<bool>>? OnPreload()
	{
		CustomPromise<bool> promise = new CustomPromise<bool>();
		Singleton<DamageUiManager>.Instance.PreloadAsync().ContinueWith(delegate()
		{
			promise.SetResult(true);
		}).Forget(delegate(Exception error)
		{
			if (error != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CombatInfo;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "Preload异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", error.Message);
				instance.ErrorWithStack(module, author, message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.CombatInfo;
				ELogAuthor author2 = ELogAuthor.CFT;
				string message2 = "Preload异常";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("error", error);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			promise.SetResult(false);
		}, true);
		return new ValueTuple<string, CustomPromise<bool>>?(new ValueTuple<string, CustomPromise<bool>>("DamageUiController Preload", promise));
	}

	// Token: 0x0600C3B1 RID: 50097 RVA: 0x003396A4 File Offset: 0x003378A4
	protected override void OnTick(float delta)
	{
		Singleton<DamageUiManager>.Instance.Tick(delta);
	}

	// Token: 0x0600C3B2 RID: 50098 RVA: 0x003396B4 File Offset: 0x003378B4
	public void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationLoadCompleted));
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRoleCompleted));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleGoDown, new Action<int>(this.OnRoleGoDown));
		Singleton<EventSystem>.Instance.Add<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.OnAddEntity));
		Singleton<EventSystem>.Instance.Add<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add<int, GameplayCue, bool, int>(EEventName.CharOnBuffAddUIDamage, new Action<int, GameplayCue, bool, int>(this.OnAddBuffDamageUi));
		if (GlobalData.IsPlayInEditor)
		{
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		}
		ModelBase<BattleUiModel>.Instance.ChildViewData.AddCallback(EBattleUiChild.DamageView, new Action(this.OnBattleUiChildVisibleChanged));
	}

	// Token: 0x0600C3B3 RID: 50099 RVA: 0x003397C8 File Offset: 0x003379C8
	public void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationLoadCompleted));
		Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRoleCompleted));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRoleGoDown, new Action<int>(this.OnRoleGoDown));
		Singleton<EventSystem>.Instance.Remove<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.OnAddEntity));
		Singleton<EventSystem>.Instance.Remove<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove<int, GameplayCue, bool, int>(EEventName.CharOnBuffAddUIDamage, new Action<int, GameplayCue, bool, int>(this.OnAddBuffDamageUi));
		if (GlobalData.IsPlayInEditor)
		{
			Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		}
		ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveCallback(EBattleUiChild.DamageView, new Action(this.OnBattleUiChildVisibleChanged));
	}

	// Token: 0x0600C3B4 RID: 50100 RVA: 0x003398D9 File Offset: 0x00337AD9
	private void OnWorldDone()
	{
		this.StartUeDamageUiManager();
	}

	// Token: 0x0600C3B5 RID: 50101 RVA: 0x003398E4 File Offset: 0x00337AE4
	private void OnFormationLoadCompleted()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity != null)
		{
			this.AddEntityEvents(getCurrentEntity.Entity);
		}
	}

	// Token: 0x0600C3B6 RID: 50102 RVA: 0x0033990C File Offset: 0x00337B0C
	private void OnChangeRoleCompleted(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity != null)
		{
			this.AddEntityEvents(getCurrentEntity.Entity);
		}
	}

	// Token: 0x0600C3B7 RID: 50103 RVA: 0x00339934 File Offset: 0x00337B34
	private void OnRoleGoDown(int entityId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity == null)
		{
			return;
		}
		this.RemoveEntityEvents(entity);
	}

	// Token: 0x0600C3B8 RID: 50104 RVA: 0x00339958 File Offset: 0x00337B58
	private void OnAddEntity(EAddEntityType addType, EntityHandle handle, [Nullable(2)] AActor actor)
	{
		this.AddEntityEvents(handle.Entity);
	}

	// Token: 0x0600C3B9 RID: 50105 RVA: 0x00339966 File Offset: 0x00337B66
	private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		this.RemoveEntityEvents(handle.Entity);
	}

	// Token: 0x0600C3BA RID: 50106 RVA: 0x00339974 File Offset: 0x00337B74
	[NullableContext(2)]
	private void AddEntityEvents(Entity entity)
	{
		if (entity == null)
		{
			return;
		}
		if (!Singleton<EventSystem>.Instance.HasWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEntityApplyDamage)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEntityApplyDamage));
		}
	}

	// Token: 0x0600C3BB RID: 50107 RVA: 0x003399AF File Offset: 0x00337BAF
	[NullableContext(2)]
	private void RemoveEntityEvents(Entity entity)
	{
		if (entity == null)
		{
			return;
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEntityApplyDamage)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEntityApplyDamage));
		}
	}

	// Token: 0x0600C3BC RID: 50108 RVA: 0x003399EC File Offset: 0x00337BEC
	private void OnEntityApplyDamage(Entity attacker, Entity victim, RequirementPayload requirements, DamageResult damageResult, FVectorDouble damagePosition)
	{
		float damage = damageResult.Damage;
		Damage damageData = damageResult.DamageData;
		ECalculationType calculateType = (ECalculationType)damageData.CalculateType;
		if (calculateType == ECalculationType.Hurt)
		{
			ModelBase<BattleUiModel>.Instance.ExploreModeData.BeHit(victim);
			Singleton<DamageUiManager>.Instance.ApplyDamage(damage, (int)damageResult.Element, damagePosition, victim, requirements.IsCritical.Value, false, damageData.DamageTextType, requirements.IsImmune.Value ? "Immune" : "", damageData.DamageTextAreaId);
			return;
		}
		if (calculateType != ECalculationType.Heal)
		{
			return;
		}
		CharacterActorComponent component = victim.GetComponent<CharacterActorComponent>();
		Singleton<DamageUiManager>.Instance.ApplyDamage(-damage, 0, component.ActorLocation, victim, false, true, damageData.DamageTextType, "", damageData.DamageTextAreaId);
	}

	// Token: 0x0600C3BD RID: 50109 RVA: 0x00339AA4 File Offset: 0x00337CA4
	private void OnAddBuffDamageUi(int entityId, GameplayCue cue, bool isAdd, int handleId)
	{
		if (!isAdd)
		{
			return;
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
		string[] array = cue.Parameters();
		Singleton<DamageUiManager>.Instance.ApplyDamage(-1f, 0, component.ActorLocation, entity, false, true, (array.Length != 0) ? int.Parse(array[0]) : 0, (array.Length > 1) ? array[1] : "", (array.Length > 2) ? int.Parse(array[2]) : 0);
	}

	// Token: 0x0600C3BE RID: 50110 RVA: 0x00339B19 File Offset: 0x00337D19
	private void InputControllerChange(EInputControllerType last, EInputControllerType now)
	{
		Singleton<DamageUiManager>.Instance.OnEditorPlatformChanged();
	}

	// Token: 0x0600C3BF RID: 50111 RVA: 0x00339B28 File Offset: 0x00337D28
	private void OnBattleUiChildVisibleChanged()
	{
		UUIItem battleViewUnit = Singleton<UiLayer>.Instance.GetBattleViewUnit(0);
		bool childVisible = ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(EBattleUiChild.DamageView);
		battleViewUnit.SetUIActive(childVisible);
	}

	// Token: 0x0600C3C0 RID: 50112 RVA: 0x00339B58 File Offset: 0x00337D58
	public void SetDamageTimeScaleEnable(bool bEnable)
	{
		Singleton<DamageUiManager>.Instance.SetDamageTimeScaleEnable(bEnable);
	}

	// Token: 0x0600C3C1 RID: 50113 RVA: 0x00339B65 File Offset: 0x00337D65
	public int EnableDamageViewOptimization()
	{
		return Singleton<DamageUiManager>.Instance.EnableDamageViewOptimization();
	}

	// Token: 0x0600C3C2 RID: 50114 RVA: 0x00339B71 File Offset: 0x00337D71
	public void DisableDamageViewOptimization(int id)
	{
		Singleton<DamageUiManager>.Instance.DisableDamageViewOptimization(id);
	}

	// Token: 0x0600C3C3 RID: 50115 RVA: 0x00339B7E File Offset: 0x00337D7E
	public void StartUeDamageUiManager()
	{
		Singleton<DamageUiManager>.Instance.StartUeDamageUiManager();
	}

	// Token: 0x0600C3C4 RID: 50116 RVA: 0x00339B8A File Offset: 0x00337D8A
	public void StopUeDamageUiManager()
	{
		Singleton<DamageUiManager>.Instance.StopUeDamageUiManager();
	}

	// Token: 0x0600C3C5 RID: 50117 RVA: 0x00339B96 File Offset: 0x00337D96
	public void SetUeDamageConfig(FDamageConfig config, bool hideDamageCritEffect = false)
	{
		Singleton<DamageUiManager>.Instance.SetUeDamageConfig(config, hideDamageCritEffect);
	}

	// Token: 0x0600C3C6 RID: 50118 RVA: 0x00339BA4 File Offset: 0x00337DA4
	public void UpdateKscWorld()
	{
		Singleton<DamageUiManager>.Instance.UpdateKscWorld();
	}
}
