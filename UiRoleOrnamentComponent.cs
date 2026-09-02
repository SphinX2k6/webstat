using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002CB2 RID: 11442
[NullableContext(1)]
[Nullable(0)]
public class UiRoleOrnamentComponent : UiModelComponentBase, IUiModelVisible, IUiModelSetDitherEffect, IUiModelRenderingMaterialChange
{
	// Token: 0x06016F47 RID: 94023 RVA: 0x0065C8CC File Offset: 0x0065AACC
	protected override void OnInit()
	{
		this.RoleDataComponent = base.Owner.CheckGetComponent<UiRoleDataComponent>();
		this.ModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		this.BuffComponent = base.Owner.CheckGetComponent<UiRoleBuffComponent>();
		this.TagComponent = base.Owner.GetComponent<UiModelTagComponent>();
	}

	// Token: 0x06016F48 RID: 94024 RVA: 0x0065C930 File Offset: 0x0065AB30
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnBeforeRoleModelLoad));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleModelReady));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelSetMorphTypeComplete, new Action(this.OnRoleModelReady));
	}

	// Token: 0x06016F49 RID: 94025 RVA: 0x0065C9A4 File Offset: 0x0065ABA4
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnBeforeRoleModelLoad));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleModelReady));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelSetMorphTypeComplete, new Action(this.OnRoleModelReady));
		this.DestroyAllOrnaments();
	}

	// Token: 0x06016F4A RID: 94026 RVA: 0x0065CA1D File Offset: 0x0065AC1D
	public void SetPendingContexts(OrnamentModelContext[] contexts)
	{
		this.PendingOrnamentContexts = contexts;
	}

	// Token: 0x06016F4B RID: 94027 RVA: 0x0065CA26 File Offset: 0x0065AC26
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public OrnamentModelContext[] ConsumePendingContexts()
	{
		OrnamentModelContext[] pendingOrnamentContexts = this.PendingOrnamentContexts;
		this.PendingOrnamentContexts = null;
		return pendingOrnamentContexts;
	}

	// Token: 0x06016F4C RID: 94028 RVA: 0x0065CA35 File Offset: 0x0065AC35
	public bool HasPendingContexts()
	{
		return this.PendingOrnamentContexts != null;
	}

	// Token: 0x06016F4D RID: 94029 RVA: 0x0065CA40 File Offset: 0x0065AC40
	public void RefreshModels([Nullable(new byte[]
	{
		2,
		1
	})] OrnamentModelContext[] contexts = null, bool forceRefresh = false)
	{
		OrnamentModelContext[] array = (contexts != null && contexts.Length != 0) ? contexts : UiModelUtil.GetSkinWearingOrnamentContexts(this.RoleDataComponent.RoleDataId, this.RoleDataComponent.RoleSkinId).ToArray();
		if (array == null || array.Length == 0)
		{
			this.DestroyAllOrnaments();
			return;
		}
		if (!forceRefresh && this.IsSameModelIds(array))
		{
			return;
		}
		(from x in array
		select x.ModelId).ToArray<int>();
		this.OrnamentHandleMap.Keys.ToArray<int>();
		bool flag = this.IsRoleModelLoaded();
		this.OrnamentContextMap.Clear();
		foreach (OrnamentModelContext ornamentModelContext in array)
		{
			this.OrnamentContextMap[ornamentModelContext.ModelId] = ornamentModelContext;
		}
		List<int> list = new List<int>();
		HashSet<int> hashSet = new HashSet<int>();
		foreach (int num in this.OrnamentHandleMap.Keys)
		{
			if (!this.OrnamentContextMap.ContainsKey(num))
			{
				list.Add(num);
			}
			else
			{
				hashSet.Add(num);
			}
		}
		foreach (int modelId in list)
		{
			this.DestroyOrnamentByModelId(modelId);
		}
		foreach (KeyValuePair<int, OrnamentModelContext> keyValuePair in this.OrnamentContextMap)
		{
			int i;
			OrnamentModelContext ornamentModelContext2;
			keyValuePair.Deconstruct(out i, out ornamentModelContext2);
			int num2 = i;
			OrnamentModelContext ornamentModelContext3 = ornamentModelContext2;
			if (ornamentModelContext3.HideInUi)
			{
				if (flag)
				{
					this.AddOrnamentBuffs(num2, ornamentModelContext3.OrnamentUiBuff.ToArray());
				}
			}
			else
			{
				this.OrnamentStateMap[num2] = EOrnamentState.Showing;
				if (!hashSet.Contains(num2))
				{
					SkeletalObserverHandle skeletalObserverHandle;
					if (!this.OrnamentHandleMap.TryGetValue(num2, out skeletalObserverHandle))
					{
						skeletalObserverHandle = SkeletalObserverManager.NewSkeletalObserver(EUiModelUseWay.OrnamentOnRole);
						this.OrnamentHandleMap[num2] = skeletalObserverHandle;
						this.RegisterOrnamentTagListeners(num2);
						UiDecorationLoadComponent uiDecorationLoadComponent = skeletalObserverHandle.Model.CheckGetComponent<UiDecorationLoadComponent>();
						uiDecorationLoadComponent.SetAttachActorComponent(this.ActorComponent);
						int capturedModelId = num2;
						OrnamentModelContext capturedCtx = ornamentModelContext3;
						uiDecorationLoadComponent.LoadModelByModelId(capturedModelId, 0, false, delegate
						{
							if (!this.OrnamentHandleMap.ContainsKey(capturedModelId))
							{
								return;
							}
							if (this.IsRoleModelLoaded())
							{
								this.AttachOrnamentToRole(capturedModelId);
								this.SyncOrnamentVisible(capturedModelId);
								this.SpawnOrnamentEffects(capturedModelId);
								this.AddOrnamentBuffs(capturedModelId, capturedCtx.OrnamentUiBuff.ToArray());
							}
						}, null, true);
					}
					else if (flag)
					{
						this.AttachOrnamentToRole(num2);
						this.SyncOrnamentVisible(num2);
						this.SpawnOrnamentEffects(num2);
						this.AddOrnamentBuffs(num2, ornamentModelContext3.OrnamentUiBuff.ToArray());
					}
				}
			}
		}
	}

	// Token: 0x06016F4E RID: 94030 RVA: 0x0065CD3C File Offset: 0x0065AF3C
	[NullableContext(2)]
	public AActor GetActorByModelId(int modelId)
	{
		SkeletalObserverHandle skeletalObserverHandle;
		if (!this.OrnamentHandleMap.TryGetValue(modelId, out skeletalObserverHandle))
		{
			return null;
		}
		UiModelBase model = skeletalObserverHandle.Model;
		if (model == null)
		{
			return null;
		}
		UiModelActorComponent uiModelActorComponent = model.CheckGetComponent<UiModelActorComponent>();
		if (uiModelActorComponent == null)
		{
			return null;
		}
		return uiModelActorComponent.Actor;
	}

	// Token: 0x06016F4F RID: 94031 RVA: 0x0065CD78 File Offset: 0x0065AF78
	public void OnModelDitherEffectChange(float value)
	{
		foreach (SkeletalObserverHandle skeletalObserverHandle in this.OrnamentHandleMap.Values)
		{
			UiModelBase model = skeletalObserverHandle.Model;
			UiModelDataComponent uiModelDataComponent = (model != null) ? model.CheckGetComponent<UiModelDataComponent>() : null;
			if (uiModelDataComponent != null)
			{
				uiModelDataComponent.SetDitherEffect(value);
			}
		}
	}

	// Token: 0x06016F50 RID: 94032 RVA: 0x0065CDE8 File Offset: 0x0065AFE8
	public void OnRenderingMaterialAdd(int materialId, UObject data, bool isGroup, bool withAnimObject)
	{
		ActiveMaterialEntry activeMaterialEntry = new ActiveMaterialEntry();
		activeMaterialEntry.Data = data;
		activeMaterialEntry.IsGroup = isGroup;
		activeMaterialEntry.WithAnimObject = withAnimObject;
		this.ActiveMaterialMap.Add(materialId, activeMaterialEntry);
		foreach (KeyValuePair<int, SkeletalObserverHandle> keyValuePair in this.OrnamentHandleMap)
		{
			this.AddMaterialToOrnament(keyValuePair.Key, keyValuePair.Value, materialId, data, isGroup, withAnimObject);
		}
	}

	// Token: 0x06016F51 RID: 94033 RVA: 0x0065CE78 File Offset: 0x0065B078
	public void OnRenderingMaterialRemove(int materialId, bool isGroup, bool withEnding)
	{
		this.ActiveMaterialMap.Remove(materialId);
		foreach (KeyValuePair<int, SkeletalObserverHandle> keyValuePair in this.OrnamentHandleMap)
		{
			this.RemoveMaterialFromOrnament(keyValuePair.Key, keyValuePair.Value, materialId, isGroup, withEnding);
		}
	}

	// Token: 0x06016F52 RID: 94034 RVA: 0x0065CEE8 File Offset: 0x0065B0E8
	public void OnModelVisibleChange(bool visible)
	{
		if (visible)
		{
			this.SyncAllOrnamentsVisible();
			return;
		}
		this.SetAllOrnamentsActualVisible(false);
	}

	// Token: 0x06016F53 RID: 94035 RVA: 0x0065CEFC File Offset: 0x0065B0FC
	private void SyncOrnamentVisible(int modelId)
	{
		EOrnamentState eornamentState;
		this.OrnamentStateMap.TryGetValue(modelId, out eornamentState);
		bool flag = eornamentState == EOrnamentState.Showing;
		this.ApplyOrnamentVisible(modelId, flag && this.CheckOrnamentTagVisible(modelId));
	}

	// Token: 0x06016F54 RID: 94036 RVA: 0x0065CF34 File Offset: 0x0065B134
	private void SyncAllOrnamentsVisible()
	{
		foreach (int modelId in this.OrnamentHandleMap.Keys)
		{
			this.SyncOrnamentVisible(modelId);
		}
	}

	// Token: 0x06016F55 RID: 94037 RVA: 0x0065CF8C File Offset: 0x0065B18C
	private void SetAllOrnamentsActualVisible(bool visible)
	{
		foreach (int modelId in this.OrnamentHandleMap.Keys)
		{
			this.ApplyOrnamentVisible(modelId, visible);
			if (visible)
			{
				this.AttachOrnamentToRole(modelId);
			}
		}
	}

	// Token: 0x06016F56 RID: 94038 RVA: 0x0065CFF0 File Offset: 0x0065B1F0
	private void ApplyOrnamentVisible(int modelId, bool visible)
	{
		SkeletalObserverHandle skeletalObserverHandle;
		if (!this.OrnamentHandleMap.TryGetValue(modelId, out skeletalObserverHandle))
		{
			return;
		}
		UiModelBase model = skeletalObserverHandle.Model;
		UiModelDataComponent uiModelDataComponent = (model != null) ? model.CheckGetComponent<UiModelDataComponent>() : null;
		if (uiModelDataComponent == null || visible == uiModelDataComponent.GetVisible())
		{
			return;
		}
		uiModelDataComponent.SetVisible(visible);
	}

	// Token: 0x06016F57 RID: 94039 RVA: 0x0065D038 File Offset: 0x0065B238
	private bool IsSameModelIds(OrnamentModelContext[] ctxList)
	{
		if (ctxList.Length != this.OrnamentContextMap.Count)
		{
			return false;
		}
		foreach (OrnamentModelContext ornamentModelContext in ctxList)
		{
			if (!this.OrnamentContextMap.ContainsKey(ornamentModelContext.ModelId))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06016F58 RID: 94040 RVA: 0x0065D081 File Offset: 0x0065B281
	private bool IsRoleModelLoaded()
	{
		return this.ModelDataComponent.GetModelLoadState() == EUiModelLoadState.LoadComplete;
	}

	// Token: 0x06016F59 RID: 94041 RVA: 0x0065D094 File Offset: 0x0065B294
	private void AttachOrnamentToRole(int modelId)
	{
		if (this.DeferOrnamentAttachUntilRoleMeshReady || !this.IsRoleModelLoaded())
		{
			return;
		}
		SkeletalObserverHandle skeletalObserverHandle;
		if (!this.OrnamentHandleMap.TryGetValue(modelId, out skeletalObserverHandle))
		{
			return;
		}
		UiModelBase model = skeletalObserverHandle.Model;
		UiDecorationLoadComponent uiDecorationLoadComponent = (model != null) ? model.CheckGetComponent<UiDecorationLoadComponent>() : null;
		if (uiDecorationLoadComponent != null)
		{
			uiDecorationLoadComponent.AttachToTarget();
		}
		this.SyncActiveMaterialsToOrnament(modelId, skeletalObserverHandle);
	}

	// Token: 0x06016F5A RID: 94042 RVA: 0x0065D0E8 File Offset: 0x0065B2E8
	private void AttachAllOrnamentToRole()
	{
		foreach (int modelId in this.OrnamentHandleMap.Keys)
		{
			this.AttachOrnamentToRole(modelId);
		}
	}

	// Token: 0x06016F5B RID: 94043 RVA: 0x0065D140 File Offset: 0x0065B340
	private SDecorationConfig GetOrnamentConfig(int configId)
	{
		return DataTableUtil.GetDataTableRowFromName<SDecorationConfig>(EDataTable.DecorationConfig, configId.ToString());
	}

	// Token: 0x06016F5C RID: 94044 RVA: 0x0065D150 File Offset: 0x0065B350
	private void DestroyOrnamentByModelId(int modelId)
	{
		this.OrnamentMaterialIdMap.Remove(modelId);
		this.RemoveOrnamentTagListeners(modelId);
		this.RemoveOrnamentBuffs(modelId);
		this.DestroyOrnamentEffects(modelId);
		SkeletalObserverHandle skeletalObserverHandle;
		if (this.OrnamentHandleMap.TryGetValue(modelId, out skeletalObserverHandle))
		{
			SkeletalObserverManager.DestroySkeletalObserver(skeletalObserverHandle);
		}
		this.OrnamentHandleMap.Remove(modelId);
		this.OrnamentStateMap.Remove(modelId);
		this.OrnamentContextMap.Remove(modelId);
	}

	// Token: 0x06016F5D RID: 94045 RVA: 0x0065D1BC File Offset: 0x0065B3BC
	private void DestroyAllOrnaments()
	{
		this.OrnamentMaterialIdMap.Clear();
		this.RemoveAllOrnamentTagListeners();
		this.RemoveAllOrnamentBuffs();
		this.DestroyAllOrnamentEffects();
		foreach (SkeletalObserverHandle skeletalObserverHandle in this.OrnamentHandleMap.Values)
		{
			SkeletalObserverManager.DestroySkeletalObserver(skeletalObserverHandle);
		}
		this.OrnamentHandleMap.Clear();
		this.OrnamentStateMap.Clear();
		this.OrnamentContextMap.Clear();
	}

	// Token: 0x06016F5E RID: 94046 RVA: 0x0065D250 File Offset: 0x0065B450
	private void AddOrnamentBuffs(int modelId, long[] buffIds)
	{
		if (this.BuffComponent == null || buffIds == null || buffIds.Length == 0)
		{
			return;
		}
		foreach (long buffId in buffIds)
		{
			this.BuffComponent.AddBuffByBuffId(buffId);
		}
		this.OrnamentBuffMap[modelId] = buffIds;
	}

	// Token: 0x06016F5F RID: 94047 RVA: 0x0065D29C File Offset: 0x0065B49C
	private void RemoveOrnamentBuffs(int modelId)
	{
		long[] array;
		if (!this.OrnamentBuffMap.TryGetValue(modelId, out array) || this.BuffComponent == null)
		{
			return;
		}
		foreach (long buffId in array)
		{
			this.BuffComponent.RemoveBuffByBuffId(buffId);
		}
		this.OrnamentBuffMap.Remove(modelId);
	}

	// Token: 0x06016F60 RID: 94048 RVA: 0x0065D2F0 File Offset: 0x0065B4F0
	private void RemoveAllOrnamentBuffs()
	{
		if (this.BuffComponent == null)
		{
			this.OrnamentBuffMap.Clear();
			return;
		}
		foreach (long[] array in this.OrnamentBuffMap.Values)
		{
			foreach (long buffId in array)
			{
				this.BuffComponent.RemoveBuffByBuffId(buffId);
			}
		}
		this.OrnamentBuffMap.Clear();
	}

	// Token: 0x06016F61 RID: 94049 RVA: 0x0065D380 File Offset: 0x0065B580
	private void SpawnOrnamentEffects(int modelId)
	{
		HashSet<int> hashSet;
		if (this.OrnamentEffectHandleMap.TryGetValue(modelId, out hashSet) && hashSet.Count > 0)
		{
			return;
		}
		SDecorationConfig ornamentConfig = this.GetOrnamentConfig(modelId);
		if (ornamentConfig.Effects.Num() <= 0)
		{
			return;
		}
		SkeletalObserverHandle skeletalObserverHandle;
		if (!this.OrnamentHandleMap.TryGetValue(modelId, out skeletalObserverHandle))
		{
			return;
		}
		UiModelBase model = skeletalObserverHandle.Model;
		USkeletalMeshComponent uskeletalMeshComponent;
		if (model == null)
		{
			uskeletalMeshComponent = null;
		}
		else
		{
			UiModelActorComponent uiModelActorComponent = model.CheckGetComponent<UiModelActorComponent>();
			uskeletalMeshComponent = ((uiModelActorComponent != null) ? uiModelActorComponent.MainMeshComponent : null);
		}
		USkeletalMeshComponent uskeletalMeshComponent2 = uskeletalMeshComponent;
		if (uskeletalMeshComponent2 == null)
		{
			return;
		}
		UiModelBase model2 = skeletalObserverHandle.Model;
		UiModelEffectComponent uiModelEffectComponent = (model2 != null) ? model2.CheckGetComponent<UiModelEffectComponent>() : null;
		if (uiModelEffectComponent == null)
		{
			return;
		}
		if (hashSet == null)
		{
			hashSet = new HashSet<int>();
			this.OrnamentEffectHandleMap[modelId] = hashSet;
		}
		for (int i = 0; i < ornamentConfig.Effects.Num(); i++)
		{
			SDecorationConfig_Effect sdecorationConfig_Effect = ornamentConfig.Effects.Get(i);
			UiModelEffectPlayContext context = new UiModelEffectPlayContext
			{
				EffectPath = sdecorationConfig_Effect.EffectData.ToAssetPathName(),
				AttachTargetComponent = uskeletalMeshComponent2,
				Transform = Singleton<MathUtils>.Instance.DefaultTransformDouble,
				SocketName = (FNameUtil.GetDynamicFName(sdecorationConfig_Effect.EffectSocketName) ?? FName.NAME_None)
			};
			int item = uiModelEffectComponent.PlayEffectByContext(context);
			hashSet.Add(item);
		}
	}

	// Token: 0x06016F62 RID: 94050 RVA: 0x0065D4C0 File Offset: 0x0065B6C0
	private void DestroyOrnamentEffects(int modelId)
	{
		HashSet<int> hashSet;
		if (!this.OrnamentEffectHandleMap.TryGetValue(modelId, out hashSet))
		{
			return;
		}
		SkeletalObserverHandle skeletalObserverHandle;
		if (!this.OrnamentHandleMap.TryGetValue(modelId, out skeletalObserverHandle))
		{
			return;
		}
		UiModelBase model = skeletalObserverHandle.Model;
		UiModelEffectComponent uiModelEffectComponent = (model != null) ? model.CheckGetComponent<UiModelEffectComponent>() : null;
		if (uiModelEffectComponent == null)
		{
			return;
		}
		foreach (int effectHandle in hashSet)
		{
			uiModelEffectComponent.StopEffect(effectHandle, true);
		}
		hashSet.Clear();
	}

	// Token: 0x06016F63 RID: 94051 RVA: 0x0065D550 File Offset: 0x0065B750
	private void DestroyAllOrnamentEffects()
	{
		foreach (int modelId in new List<int>(this.OrnamentEffectHandleMap.Keys))
		{
			this.DestroyOrnamentEffects(modelId);
		}
		this.OrnamentEffectHandleMap.Clear();
	}

	// Token: 0x06016F64 RID: 94052 RVA: 0x0065D5B8 File Offset: 0x0065B7B8
	private void OnBeforeRoleModelLoad()
	{
		this.DeferOrnamentAttachUntilRoleMeshReady = true;
		this.SetAllOrnamentsActualVisible(false);
		this.DestroyAllOrnamentEffects();
		this.RemoveAllOrnamentBuffs();
		OrnamentModelContext[] pendingOrnamentContexts = this.PendingOrnamentContexts;
		this.PendingOrnamentContexts = null;
		this.RefreshModels(pendingOrnamentContexts, false);
	}

	// Token: 0x06016F65 RID: 94053 RVA: 0x0065D5F8 File Offset: 0x0065B7F8
	private void OnRoleModelReady()
	{
		this.DeferOrnamentAttachUntilRoleMeshReady = false;
		this.AttachAllOrnamentToRole();
		this.SyncAllOrnamentsVisible();
		foreach (KeyValuePair<int, OrnamentModelContext> keyValuePair in this.OrnamentContextMap)
		{
			int num;
			OrnamentModelContext ornamentModelContext;
			keyValuePair.Deconstruct(out num, out ornamentModelContext);
			int num2 = num;
			OrnamentModelContext ornamentModelContext2 = ornamentModelContext;
			if (ornamentModelContext2.HideInUi)
			{
				this.AddOrnamentBuffs(num2, ornamentModelContext2.OrnamentUiBuff.ToArray());
			}
			else if (this.OrnamentHandleMap.ContainsKey(num2))
			{
				this.SpawnOrnamentEffects(num2);
				this.AddOrnamentBuffs(num2, ornamentModelContext2.OrnamentUiBuff.ToArray());
			}
		}
	}

	// Token: 0x06016F66 RID: 94054 RVA: 0x0065D6AC File Offset: 0x0065B8AC
	private void SyncActiveMaterialsToOrnament(int modelId, SkeletalObserverHandle handle)
	{
		foreach (KeyValuePair<int, ActiveMaterialEntry> keyValuePair in this.ActiveMaterialMap)
		{
			ActiveMaterialEntry value = keyValuePair.Value;
			this.AddMaterialToOrnament(modelId, handle, keyValuePair.Key, value.Data, value.IsGroup, value.WithAnimObject);
		}
	}

	// Token: 0x06016F67 RID: 94055 RVA: 0x0065D724 File Offset: 0x0065B924
	private void AddMaterialToOrnament(int modelId, SkeletalObserverHandle handle, int materialId, UObject data, bool isGroup, bool withAnimObject)
	{
		UiModelBase model = handle.Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		CharRenderingComponent charRenderingComponent = (uiModelActorComponent != null) ? uiModelActorComponent.CharRenderingComponent : null;
		if (charRenderingComponent == null)
		{
			return;
		}
		int value = withAnimObject ? ((int)charRenderingComponent.AddMaterialControllerDataWithAnimObject(data, uiModelActorComponent.MainMeshComponent, null)) : (isGroup ? charRenderingComponent.AddMaterialControllerDataGroup(data) : charRenderingComponent.AddMaterialControllerData(data));
		Dictionary<int, int> dictionary;
		if (!this.OrnamentMaterialIdMap.TryGetValue(modelId, out dictionary))
		{
			dictionary = new Dictionary<int, int>();
			this.OrnamentMaterialIdMap[modelId] = dictionary;
		}
		dictionary[materialId] = value;
	}

	// Token: 0x06016F68 RID: 94056 RVA: 0x0065D7B0 File Offset: 0x0065B9B0
	private void RemoveMaterialFromOrnament(int modelId, SkeletalObserverHandle handle, int materialId, bool isGroup, bool withEnding)
	{
		Dictionary<int, int> dictionary;
		if (!this.OrnamentMaterialIdMap.TryGetValue(modelId, out dictionary))
		{
			return;
		}
		int handle2;
		if (dictionary.TryGetValue(materialId, out handle2))
		{
			dictionary.Remove(materialId);
			UiModelBase model = handle.Model;
			UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
			CharRenderingComponent charRenderingComponent = (uiModelActorComponent != null) ? uiModelActorComponent.CharRenderingComponent : null;
			if (charRenderingComponent == null)
			{
				return;
			}
			if (withEnding)
			{
				if (isGroup)
				{
					charRenderingComponent.RemoveMaterialControllerDataGroupWithEnding(handle2);
					return;
				}
				charRenderingComponent.RemoveMaterialControllerDataWithEnding(handle2);
				return;
			}
			else
			{
				if (isGroup)
				{
					charRenderingComponent.RemoveMaterialControllerDataGroup(handle2);
					return;
				}
				charRenderingComponent.RemoveMaterialControllerData(handle2);
			}
		}
	}

	// Token: 0x06016F69 RID: 94057 RVA: 0x0065D830 File Offset: 0x0065BA30
	private void OnOrnamentTagChanged(int tagId, bool tagExist, params object[] _)
	{
		foreach (Dictionary<int, bool> dictionary in this.OrnamentDisplayTagsMap.Values)
		{
			if (dictionary.ContainsKey(tagId))
			{
				dictionary[tagId] = tagExist;
			}
		}
		foreach (Dictionary<int, bool> dictionary2 in this.OrnamentHideTagsMap.Values)
		{
			if (dictionary2.ContainsKey(tagId))
			{
				dictionary2[tagId] = tagExist;
			}
		}
		this.SyncAllOrnamentsVisible();
	}

	// Token: 0x06016F6A RID: 94058 RVA: 0x0065D8EC File Offset: 0x0065BAEC
	private void RegisterOrnamentTagListeners(int modelId)
	{
		if (this.TagComponent == null)
		{
			return;
		}
		SDecorationConfig ornamentConfig = this.GetOrnamentConfig(modelId);
		Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
		Dictionary<int, bool> dictionary2 = new Dictionary<int, bool>();
		this.AddTagsFromContainer(dictionary, ornamentConfig.UIDisplayTags);
		this.AddTagsFromContainer(dictionary2, ornamentConfig.UIHideTags);
		this.OrnamentDisplayTagsMap[modelId] = dictionary;
		this.OrnamentHideTagsMap[modelId] = dictionary2;
	}

	// Token: 0x06016F6B RID: 94059 RVA: 0x0065D94C File Offset: 0x0065BB4C
	private void AddTagsFromContainer(Dictionary<int, bool> map, FGameplayTagContainer container)
	{
		if (this.TagComponent == null)
		{
			return;
		}
		TArray<FGameplayTag> gameplayTags = container.GameplayTags;
		for (int i = 0; i < gameplayTags.Num(); i++)
		{
			int num = gameplayTags.Get(i).TagId();
			if (num != 0 && !map.ContainsKey(num))
			{
				map[num] = this.TagComponent.ContainsTagById(num);
				int num2;
				this.TagListenerRefCount.TryGetValue(num, out num2);
				if (num2 == 0)
				{
					this.TagComponent.AddTagListener(num, new TTagSwitchedCallback(this.OnOrnamentTagChanged));
				}
				this.TagListenerRefCount[num] = num2 + 1;
			}
		}
	}

	// Token: 0x06016F6C RID: 94060 RVA: 0x0065D9E0 File Offset: 0x0065BBE0
	private void RemoveOrnamentTagListeners(int modelId)
	{
		Dictionary<int, bool> map;
		if (this.OrnamentDisplayTagsMap.TryGetValue(modelId, out map))
		{
			this.RemoveTagListenersFromMap(map);
			this.OrnamentDisplayTagsMap.Remove(modelId);
		}
		Dictionary<int, bool> map2;
		if (this.OrnamentHideTagsMap.TryGetValue(modelId, out map2))
		{
			this.RemoveTagListenersFromMap(map2);
			this.OrnamentHideTagsMap.Remove(modelId);
		}
	}

	// Token: 0x06016F6D RID: 94061 RVA: 0x0065DA38 File Offset: 0x0065BC38
	private void RemoveTagListenersFromMap(Dictionary<int, bool> map)
	{
		if (this.TagComponent == null)
		{
			return;
		}
		foreach (int num in map.Keys)
		{
			int num2;
			this.TagListenerRefCount.TryGetValue(num, out num2);
			if (num2 <= 1)
			{
				this.TagComponent.RemoveTagListener(num, new TTagSwitchedCallback(this.OnOrnamentTagChanged));
				this.TagListenerRefCount.Remove(num);
			}
			else
			{
				this.TagListenerRefCount[num] = num2 - 1;
			}
		}
		map.Clear();
	}

	// Token: 0x06016F6E RID: 94062 RVA: 0x0065DADC File Offset: 0x0065BCDC
	private void RemoveAllOrnamentTagListeners()
	{
		if (this.TagComponent != null)
		{
			foreach (int tagId in this.TagListenerRefCount.Keys)
			{
				this.TagComponent.RemoveTagListener(tagId, new TTagSwitchedCallback(this.OnOrnamentTagChanged));
			}
		}
		this.TagListenerRefCount.Clear();
		this.OrnamentDisplayTagsMap.Clear();
		this.OrnamentHideTagsMap.Clear();
	}

	// Token: 0x06016F6F RID: 94063 RVA: 0x0065DB70 File Offset: 0x0065BD70
	private bool CheckOrnamentTagVisible(int modelId)
	{
		Dictionary<int, bool> map;
		this.OrnamentDisplayTagsMap.TryGetValue(modelId, out map);
		Dictionary<int, bool> map2;
		this.OrnamentHideTagsMap.TryGetValue(modelId, out map2);
		return UiRoleOrnamentComponent.CheckHasTagInMap(map, true) && !UiRoleOrnamentComponent.CheckHasTagInMap(map2, false);
	}

	// Token: 0x06016F70 RID: 94064 RVA: 0x0065DBB0 File Offset: 0x0065BDB0
	[NullableContext(2)]
	private static bool CheckHasTagInMap(Dictionary<int, bool> map, bool defaultValue)
	{
		if (map == null || map.Count == 0)
		{
			return defaultValue;
		}
		using (Dictionary<int, bool>.ValueCollection.Enumerator enumerator = map.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0400B107 RID: 45319
	[Nullable(2)]
	private UiRoleDataComponent RoleDataComponent;

	// Token: 0x0400B108 RID: 45320
	[Nullable(2)]
	private UiModelDataComponent ModelDataComponent;

	// Token: 0x0400B109 RID: 45321
	[Nullable(2)]
	private UiModelActorComponent ActorComponent;

	// Token: 0x0400B10A RID: 45322
	[Nullable(2)]
	private UiModelBuffComponent BuffComponent;

	// Token: 0x0400B10B RID: 45323
	private readonly Dictionary<int, OrnamentModelContext> OrnamentContextMap = new Dictionary<int, OrnamentModelContext>();

	// Token: 0x0400B10C RID: 45324
	private readonly Dictionary<int, EOrnamentState> OrnamentStateMap = new Dictionary<int, EOrnamentState>();

	// Token: 0x0400B10D RID: 45325
	private readonly Dictionary<int, SkeletalObserverHandle> OrnamentHandleMap = new Dictionary<int, SkeletalObserverHandle>();

	// Token: 0x0400B10E RID: 45326
	private readonly Dictionary<int, HashSet<int>> OrnamentEffectHandleMap = new Dictionary<int, HashSet<int>>();

	// Token: 0x0400B10F RID: 45327
	private readonly Dictionary<int, long[]> OrnamentBuffMap = new Dictionary<int, long[]>();

	// Token: 0x0400B110 RID: 45328
	private readonly Dictionary<int, ActiveMaterialEntry> ActiveMaterialMap = new Dictionary<int, ActiveMaterialEntry>();

	// Token: 0x0400B111 RID: 45329
	private readonly Dictionary<int, Dictionary<int, int>> OrnamentMaterialIdMap = new Dictionary<int, Dictionary<int, int>>();

	// Token: 0x0400B112 RID: 45330
	private readonly Dictionary<int, Dictionary<int, bool>> OrnamentDisplayTagsMap = new Dictionary<int, Dictionary<int, bool>>();

	// Token: 0x0400B113 RID: 45331
	private readonly Dictionary<int, Dictionary<int, bool>> OrnamentHideTagsMap = new Dictionary<int, Dictionary<int, bool>>();

	// Token: 0x0400B114 RID: 45332
	private readonly Dictionary<int, int> TagListenerRefCount = new Dictionary<int, int>();

	// Token: 0x0400B115 RID: 45333
	[Nullable(2)]
	private UiModelTagComponent TagComponent;

	// Token: 0x0400B116 RID: 45334
	private bool DeferOrnamentAttachUntilRoleMeshReady;

	// Token: 0x0400B117 RID: 45335
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private OrnamentModelContext[] PendingOrnamentContexts;
}
