using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;
using UnrealEngine;

// Token: 0x02002FE0 RID: 12256
[NullableContext(1)]
[Nullable(0)]
public class RegionDetectTrigger : Trigger
{
	// Token: 0x17002194 RID: 8596
	// (get) Token: 0x06018FA8 RID: 102312 RVA: 0x00715564 File Offset: 0x00713764
	[Nullable(2)]
	private UKuroRegionDetectComponent RegionDetect
	{
		[NullableContext(2)]
		get
		{
			if (this.regionDetectInner != null)
			{
				return this.regionDetectInner;
			}
			CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
			TsBaseCharacter tsBaseCharacter;
			if (ownerTriggerComp == null)
			{
				tsBaseCharacter = null;
			}
			else
			{
				Entity entity = ownerTriggerComp.Entity;
				if (entity == null)
				{
					tsBaseCharacter = null;
				}
				else
				{
					BaseCharacterComponent component = entity.GetComponent<BaseCharacterComponent>();
					tsBaseCharacter = ((component != null) ? component.Actor : null);
				}
			}
			TsBaseCharacter tsBaseCharacter2 = tsBaseCharacter;
			this.regionDetectInner = (((tsBaseCharacter2 != null) ? tsBaseCharacter2.GetComponentByClass(UKuroRegionDetectComponent.StaticClass()) : null) as UKuroRegionDetectComponent);
			return this.regionDetectInner;
		}
	}

	// Token: 0x06018FA9 RID: 102313 RVA: 0x007155D2 File Offset: 0x007137D2
	[NullableContext(2)]
	public RegionDetectTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018FAA RID: 102314 RVA: 0x007155F9 File Offset: 0x007137F9
	public override void OnInitParams(string[] triggerParams)
	{
		this.RegionNameSet = new HashSet<string>(((triggerParams.Length != 0) ? triggerParams[0] : string.Empty).Split('#', StringSplitOptions.None));
	}

	// Token: 0x06018FAB RID: 102315 RVA: 0x0071561C File Offset: 0x0071381C
	protected override void OnActive()
	{
		this.AddEvent();
		UKuroRegionDetectComponent regionDetect = this.RegionDetect;
		if (regionDetect == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.PassiveSkill;
			CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
			instance.Error(flag, (ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, "[被动]RegionDetectTrigger regionDetect为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.DetectId = regionDetect.GetRegionDetectId();
		this.RefreshDetectRoles();
		using (HashSet<string>.Enumerator enumerator = this.RegionNameSet.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				string regionName = enumerator.Current;
				UKuroRegionEventBinder regionEvent = regionDetect.GetRegionEvent(regionName, this.DetectId);
				if (regionEvent != null)
				{
					regionEvent.Callback.Add(delegate(bool isInRegion, AActor target)
					{
						int targetId;
						if (target != null && this.ActorToEntityId.TryGetValue(target, out targetId))
						{
							this.OnEvent(targetId, regionName, isInRegion);
						}
					});
				}
			}
		}
	}

	// Token: 0x06018FAC RID: 102316 RVA: 0x007156FC File Offset: 0x007138FC
	protected override void OnInactive()
	{
		this.RemoveEvent();
		UKuroRegionDetectComponent regionDetect = this.RegionDetect;
		if (regionDetect == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.PassiveSkill;
			CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
			instance.Error(flag, (ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, "[被动]RegionDetectTrigger regionDetect为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.DetectId > 0)
		{
			regionDetect.RemoveRegionDetect(this.DetectId);
		}
	}

	// Token: 0x06018FAD RID: 102317 RVA: 0x0071575C File Offset: 0x0071395C
	private void AddEvent()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		Entity entity = (ownerTriggerComp != null) ? ownerTriggerComp.Entity : null;
		if (entity == null)
		{
			return;
		}
		if (!Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		}
		if (!Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.OnOtherChangeRole, new Action<EntityHandle, EntityHandle>(this.OnOtherChangeRole)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.OnOtherChangeRole, new Action<EntityHandle, EntityHandle>(this.OnOtherChangeRole));
		}
		if (!Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		}
	}

	// Token: 0x06018FAE RID: 102318 RVA: 0x00715834 File Offset: 0x00713A34
	private void RemoveEvent()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		Entity entity = (ownerTriggerComp != null) ? ownerTriggerComp.Entity : null;
		if (entity == null)
		{
			return;
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(entity, EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.OnOtherChangeRole, new Action<EntityHandle, EntityHandle>(this.OnOtherChangeRole)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(entity, EEventName.OnOtherChangeRole, new Action<EntityHandle, EntityHandle>(this.OnOtherChangeRole));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(entity, EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(entity, EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		}
	}

	// Token: 0x06018FAF RID: 102319 RVA: 0x00715909 File Offset: 0x00713B09
	private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		this.RefreshDetectRoles();
	}

	// Token: 0x06018FB0 RID: 102320 RVA: 0x00715911 File Offset: 0x00713B11
	private void OnOtherChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		this.RefreshDetectRoles();
	}

	// Token: 0x06018FB1 RID: 102321 RVA: 0x00715919 File Offset: 0x00713B19
	private void OnUpdateSceneTeam()
	{
		this.RefreshDetectRoles();
	}

	// Token: 0x06018FB2 RID: 102322 RVA: 0x00715924 File Offset: 0x00713B24
	protected void RefreshDetectRoles()
	{
		if (this.RegionDetect == null)
		{
			return;
		}
		TArray<AActor> tarray = new TArray<AActor>();
		foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(false))
		{
			EntityHandle entityHandle = sceneTeamItem.EntityHandle;
			if (entityHandle != null && entityHandle.Valid)
			{
				AActor actor = ControllerBase<CharacterController>.Instance.GetActor(entityHandle);
				if (actor != null)
				{
					this.ActorToEntityId[actor] = entityHandle.Id;
					tarray.Add(actor);
				}
			}
		}
		this.RegionDetect.SetEventTargets(tarray, this.DetectId);
	}

	// Token: 0x06018FB3 RID: 102323 RVA: 0x007159D4 File Offset: 0x00713BD4
	protected void OnEvent(int targetId, string regionName, bool isInRegion)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		Entity value = Singleton<EntitySystem>.Instance.Get(targetId);
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["Target"] = value;
		dictionary["IsInRegion"] = isInRegion;
		dictionary["RegionName"] = regionName;
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018FB4 RID: 102324 RVA: 0x00715A44 File Offset: 0x00713C44
	public override string GetDebugTriggerType()
	{
		List<string> list = new List<string>();
		foreach (AActor aactor in this.ActorToEntityId.Keys)
		{
			list.Add(aactor.GetName());
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 2);
		defaultInterpolatedStringHandler.AppendLiteral("当角色");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join(",", list));
		defaultInterpolatedStringHandler.AppendLiteral("进入指定区域");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join(",", this.RegionNameSet));
		defaultInterpolatedStringHandler.AppendLiteral("时触发");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C328 RID: 49960
	private HashSet<string> RegionNameSet = new HashSet<string>();

	// Token: 0x0400C329 RID: 49961
	private int DetectId;

	// Token: 0x0400C32A RID: 49962
	private readonly Dictionary<AActor, int> ActorToEntityId = new Dictionary<AActor, int>();

	// Token: 0x0400C32B RID: 49963
	[Nullable(2)]
	private UKuroRegionDetectComponent regionDetectInner;
}
