using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Core.Framework;
using CSharpScript.Game;
using UnrealEngine;

// Token: 0x02001EC2 RID: 7874
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class HideActorController : ControllerBase<HideActorController>
{
	// Token: 0x0600E8B7 RID: 59575 RVA: 0x003EEFD4 File Offset: 0x003ED1D4
	protected override bool OnInit()
	{
		this.IsHideMesh = false;
		this.IsHideEffect = false;
		this.HiddenEffectSet.Clear();
		this.HiddenMeshMap.Clear();
		this.IsHideNpcMesh = false;
		this.IsHideNpcEffect = false;
		this.HiddenNpcEffectSet.Clear();
		this.HiddenNpcMeshMap.Clear();
		this.HideActorParameterDirty = false;
		this.HideNpcParameterDirty = false;
		base.PauseTick();
		return true;
	}

	// Token: 0x0600E8B8 RID: 59576 RVA: 0x003EF040 File Offset: 0x003ED240
	protected override void OnTick(float delta)
	{
		if (this.IsHideMesh || this.IsHideEffect || this.IsHideNpcMesh || this.IsHideNpcEffect)
		{
			if (this.HideActorParameterDirty || this.HideNpcParameterDirty)
			{
				this.HideActorInternal(this.IsHideMesh, this.IsHideEffect, true);
				this.HideNpcActorInternal(this.IsHideMesh, this.IsHideEffect, true);
				return;
			}
			if (this.HideDistance > 0f)
			{
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				if (baseCharacter != null && baseCharacter.IsValid() && this.HideBasisBoneName != FNameUtil.NONE)
				{
					USkeletalMeshComponent mesh = Global.BaseCharacter.Mesh;
					if (mesh != null && mesh.DoesSocketExist(this.HideBasisBoneName))
					{
						Vector tmpVector = this.TmpVector;
						Vector vector = tmpVector;
						FVectorDouble fvectorDouble = Global.BaseCharacter.Mesh.D_GetSocketLocation(this.HideBasisBoneName);
						vector.FromUeVector(fvectorDouble);
						if (!this.HideLocation.Equals(tmpVector, 0.0001))
						{
							this.HideActorInternal(this.IsHideMesh, this.IsHideEffect, true);
							this.HideNpcActorInternal(this.IsHideMesh, this.IsHideEffect, true);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600E8B9 RID: 59577 RVA: 0x003EF162 File Offset: 0x003ED362
	public void HideMesh()
	{
		if (this.IsHideMesh)
		{
			return;
		}
		this.IsHideMesh = true;
		this.HideActorInternal(true, false, false);
		base.ResumeTick();
	}

	// Token: 0x0600E8BA RID: 59578 RVA: 0x003EF183 File Offset: 0x003ED383
	public void HideEffect()
	{
		if (this.IsHideEffect)
		{
			return;
		}
		this.IsHideEffect = true;
		this.HideActorInternal(false, true, false);
		base.ResumeTick();
	}

	// Token: 0x0600E8BB RID: 59579 RVA: 0x003EF1A4 File Offset: 0x003ED3A4
	public void HideNpcMesh()
	{
		if (this.IsHideNpcMesh)
		{
			return;
		}
		this.IsHideNpcMesh = true;
		this.HideNpcActorInternal(true, false, false);
		base.ResumeTick();
	}

	// Token: 0x0600E8BC RID: 59580 RVA: 0x003EF1C5 File Offset: 0x003ED3C5
	public void HideNpcEffect()
	{
		if (this.IsHideNpcEffect)
		{
			return;
		}
		this.IsHideNpcEffect = true;
		this.HideNpcActorInternal(false, true, false);
		base.ResumeTick();
	}

	// Token: 0x0600E8BD RID: 59581 RVA: 0x003EF1E6 File Offset: 0x003ED3E6
	public void ShowMesh()
	{
		if (!this.IsHideMesh)
		{
			return;
		}
		this.IsHideMesh = false;
		this.ShowActorInternal(true, false);
	}

	// Token: 0x0600E8BE RID: 59582 RVA: 0x003EF200 File Offset: 0x003ED400
	public void ShowEffect()
	{
		if (!this.IsHideEffect)
		{
			return;
		}
		this.IsHideEffect = false;
		this.ShowActorInternal(false, true);
	}

	// Token: 0x0600E8BF RID: 59583 RVA: 0x003EF21A File Offset: 0x003ED41A
	public void ShowNpcMesh()
	{
		if (!this.IsHideNpcMesh)
		{
			return;
		}
		this.IsHideNpcMesh = false;
		this.ShowNpcActorInternal(true, false);
	}

	// Token: 0x0600E8C0 RID: 59584 RVA: 0x003EF234 File Offset: 0x003ED434
	public void ShowNpcEffect()
	{
		if (!this.IsHideNpcEffect)
		{
			return;
		}
		this.IsHideNpcEffect = false;
		this.ShowNpcActorInternal(false, true);
	}

	// Token: 0x0600E8C1 RID: 59585 RVA: 0x003EF24E File Offset: 0x003ED44E
	public void SetHideParameter(float distance, FName boneName)
	{
		if (this.HideDistance == distance && this.HideBasisBoneName == boneName)
		{
			return;
		}
		this.HideDistance = distance;
		this.HideBasisBoneName = boneName;
		this.HideActorParameterDirty = true;
		this.HideNpcParameterDirty = true;
		base.ResumeTick();
	}

	// Token: 0x0600E8C2 RID: 59586 RVA: 0x003EF28A File Offset: 0x003ED48A
	public void ResetHideParameter()
	{
		this.HideDistance = 0f;
		this.HideBasisBoneName = FNameUtil.NONE;
		this.HideActorParameterDirty = false;
		this.HideNpcParameterDirty = false;
		base.PauseTick();
	}

	// Token: 0x0600E8C3 RID: 59587 RVA: 0x003EF2B8 File Offset: 0x003ED4B8
	private void HideActorInternal(bool hideMesh, bool hideEffect, bool forceUpdateEntity = false)
	{
		if (Global.BaseCharacter == null)
		{
			return;
		}
		HashSet<EntityHandle> characterValidHandles = this.GetCharacterValidHandles(forceUpdateEntity);
		if (this.HiddenMeshMap.Count > 0)
		{
			List<EntityHandle> list = new List<EntityHandle>();
			foreach (KeyValuePair<EntityHandle, int> keyValuePair in this.HiddenMeshMap)
			{
				EntityHandle key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (!characterValidHandles.Contains(key))
				{
					list.Add(key);
					if (key.Valid)
					{
						key.Entity.GetComponent<CharacterActorComponent>().EnableActor(value);
					}
				}
			}
			foreach (EntityHandle key2 in list)
			{
				this.HiddenMeshMap.Remove(key2);
			}
		}
		if (this.HiddenEffectSet.Count > 0)
		{
			List<EntityHandle> list2 = new List<EntityHandle>();
			foreach (EntityHandle entityHandle in this.HiddenEffectSet)
			{
				if (!characterValidHandles.Contains(entityHandle))
				{
					list2.Add(entityHandle);
					if (entityHandle.Valid)
					{
						this.HideEffectInternal(entityHandle, false);
					}
				}
			}
			foreach (EntityHandle item in list2)
			{
				this.HiddenEffectSet.Remove(item);
			}
		}
		foreach (EntityHandle entityHandle2 in characterValidHandles)
		{
			if (entityHandle2.Valid && entityHandle2.IsInit && entityHandle2.Entity.Active)
			{
				CharacterActorComponent component = entityHandle2.Entity.GetComponent<CharacterActorComponent>();
				TsBaseCharacter tsBaseCharacter = (component != null) ? component.Actor : null;
				if (tsBaseCharacter != null && tsBaseCharacter != Global.BaseCharacter && CampUtils.GetCampRelationship(tsBaseCharacter.Camp, Global.BaseCharacter.Camp) != ERelation.Friend)
				{
					if (!this.HiddenMeshMap.ContainsKey(entityHandle2) && hideMesh)
					{
						int value2 = component.DisableActor("[HideActorController] 隐藏Mesh");
						this.HiddenMeshMap[entityHandle2] = value2;
					}
					if (!this.HiddenEffectSet.Contains(entityHandle2) && hideEffect)
					{
						this.HideEffectInternal(entityHandle2, true);
						this.HiddenEffectSet.Add(entityHandle2);
					}
				}
			}
		}
	}

	// Token: 0x0600E8C4 RID: 59588 RVA: 0x003EF57C File Offset: 0x003ED77C
	private void HideNpcActorInternal(bool hideMesh, bool hideEffect, bool forceUpdateEntity = false)
	{
		if (Global.BaseCharacter == null)
		{
			return;
		}
		HashSet<EntityHandle> npcValidHandles = this.GetNpcValidHandles(forceUpdateEntity);
		if (this.HiddenNpcMeshMap.Count > 0)
		{
			List<EntityHandle> list = new List<EntityHandle>();
			foreach (KeyValuePair<EntityHandle, int> keyValuePair in this.HiddenNpcMeshMap)
			{
				EntityHandle key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (!npcValidHandles.Contains(key))
				{
					list.Add(key);
					if (key.Valid)
					{
						key.Entity.GetComponent<BaseCharacterComponent>().EnableActor(value);
						this.HideHeadInfoInternal(key, false);
					}
				}
			}
			foreach (EntityHandle key2 in list)
			{
				this.HiddenNpcMeshMap.Remove(key2);
			}
		}
		if (this.HiddenNpcEffectSet.Count > 0)
		{
			List<EntityHandle> list2 = new List<EntityHandle>();
			foreach (EntityHandle entityHandle in this.HiddenNpcEffectSet)
			{
				if (!npcValidHandles.Contains(entityHandle))
				{
					list2.Add(entityHandle);
					if (entityHandle.Valid)
					{
						this.HideEffectInternal(entityHandle, false);
					}
				}
			}
			foreach (EntityHandle item in list2)
			{
				this.HiddenNpcEffectSet.Remove(item);
			}
		}
		foreach (EntityHandle entityHandle2 in npcValidHandles)
		{
			if (entityHandle2.Valid && entityHandle2.IsInit && entityHandle2.Entity.Active)
			{
				BaseCharacterComponent component = entityHandle2.Entity.GetComponent<BaseCharacterComponent>();
				TsBaseCharacter tsBaseCharacter = (component != null) ? component.Actor : null;
				if (tsBaseCharacter != null && tsBaseCharacter != Global.BaseCharacter)
				{
					CreatureDataComponent component2 = entityHandle2.Entity.GetComponent<CreatureDataComponent>();
					if (component2 != null && component2.Valid && component2.IsNpc())
					{
						if (!this.HiddenNpcMeshMap.ContainsKey(entityHandle2) && hideMesh)
						{
							this.HideHeadInfoInternal(entityHandle2, true);
							int value2 = component.DisableActor("[HideNpcActorController] 隐藏NpcMesh");
							this.HiddenNpcMeshMap[entityHandle2] = value2;
						}
						if (!this.HiddenNpcEffectSet.Contains(entityHandle2) && hideEffect)
						{
							this.HideEffectInternal(entityHandle2, true);
							this.HiddenNpcEffectSet.Add(entityHandle2);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600E8C5 RID: 59589 RVA: 0x003EF8A4 File Offset: 0x003EDAA4
	private void ShowActorInternal(bool showMesh, bool showEffect)
	{
		if (showMesh)
		{
			foreach (KeyValuePair<EntityHandle, int> keyValuePair in this.HiddenMeshMap)
			{
				EntityHandle key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (key.Valid)
				{
					key.Entity.GetComponent<CharacterActorComponent>().EnableActor(value);
				}
			}
			this.HiddenMeshMap.Clear();
		}
		if (showEffect)
		{
			foreach (EntityHandle entityHandle in this.HiddenEffectSet)
			{
				if (entityHandle.Valid)
				{
					this.HideEffectInternal(entityHandle, false);
				}
			}
			this.HiddenEffectSet.Clear();
		}
	}

	// Token: 0x0600E8C6 RID: 59590 RVA: 0x003EF988 File Offset: 0x003EDB88
	private void ShowNpcActorInternal(bool showMesh, bool showEffect)
	{
		if (showMesh)
		{
			foreach (KeyValuePair<EntityHandle, int> keyValuePair in this.HiddenNpcMeshMap)
			{
				EntityHandle key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (key.Valid)
				{
					key.Entity.GetComponent<BaseCharacterComponent>().EnableActor(value);
					this.HideHeadInfoInternal(key, false);
				}
			}
			this.HiddenNpcMeshMap.Clear();
		}
		if (showEffect)
		{
			foreach (EntityHandle entityHandle in this.HiddenNpcEffectSet)
			{
				if (entityHandle.Valid)
				{
					this.HideEffectInternal(entityHandle, false);
				}
			}
			this.HiddenNpcEffectSet.Clear();
		}
	}

	// Token: 0x0600E8C7 RID: 59591 RVA: 0x003EFA74 File Offset: 0x003EDC74
	private unsafe HashSet<EntityHandle> GetCharacterValidHandles(bool forceUpdateEntity)
	{
		if (this.LastFrameUpdateActor == (long)Singleton<Time>.Instance.Frame && !this.HideActorParameterDirty && !forceUpdateEntity)
		{
			return this.CharacterHandles;
		}
		this.LastFrameUpdateActor = (long)Singleton<Time>.Instance.Frame;
		this.HideActorParameterDirty = false;
		this.CharacterHandles.Clear();
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (this.HideDistance > 0f && baseCharacter != null && baseCharacter.IsValid() && this.HideBasisBoneName != FNameUtil.NONE)
		{
			USkeletalMeshComponent mesh = baseCharacter.Mesh;
			if (mesh != null && mesh.DoesSocketExist(this.HideBasisBoneName))
			{
				Vector hideLocation = this.HideLocation;
				Vector vector = hideLocation;
				FVectorDouble fvectorDouble = baseCharacter.Mesh.D_GetSocketLocation(this.HideBasisBoneName);
				vector.FromUeVector(fvectorDouble);
				ModelBase<CreatureModel>.Instance.GetEntitiesInRangeWithLocation(hideLocation, this.HideDistance, HideActorController.CHARACTER, this.CharacterHandles, true);
				return this.CharacterHandles;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Character;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "[HideActorController][Actor]隐藏全部角色";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("baseCharacter", (baseCharacter != null) ? new bool?(baseCharacter.IsValid()) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("HideDistance", this.HideDistance);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("HideBasisBoneName", this.HideBasisBoneName);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
		string item = "SocketExist";
		bool? flag;
		if (baseCharacter == null)
		{
			flag = null;
		}
		else
		{
			USkeletalMeshComponent mesh2 = baseCharacter.Mesh;
			flag = ((mesh2 != null) ? new bool?(mesh2.DoesSocketExist(this.HideBasisBoneName)) : null);
		}
		ptr = new ValueTuple<string, object>(item, flag);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		IReadOnlyList<EntityHandle> allEntities = ModelBase<CreatureModel>.Instance.GetAllEntities();
		if (allEntities != null)
		{
			foreach (EntityHandle item2 in allEntities)
			{
				this.CharacterHandles.Add(item2);
			}
		}
		return this.CharacterHandles;
	}

	// Token: 0x0600E8C8 RID: 59592 RVA: 0x003EFCA4 File Offset: 0x003EDEA4
	private unsafe HashSet<EntityHandle> GetNpcValidHandles(bool forceUpdateEntity)
	{
		if (this.LastFrameUpdateNpc == (long)Singleton<Time>.Instance.Frame && !this.HideNpcParameterDirty && !forceUpdateEntity)
		{
			return this.NpcHandles;
		}
		this.LastFrameUpdateNpc = (long)Singleton<Time>.Instance.Frame;
		this.HideNpcParameterDirty = false;
		this.NpcHandles.Clear();
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (this.HideDistance > 0f && baseCharacter != null && baseCharacter.IsValid() && this.HideBasisBoneName != FNameUtil.NONE)
		{
			USkeletalMeshComponent mesh = baseCharacter.Mesh;
			if (mesh != null && mesh.DoesSocketExist(this.HideBasisBoneName))
			{
				Vector hideLocation = this.HideLocation;
				Vector vector = hideLocation;
				FVectorDouble fvectorDouble = baseCharacter.Mesh.D_GetSocketLocation(this.HideBasisBoneName);
				vector.FromUeVector(fvectorDouble);
				ModelBase<CreatureModel>.Instance.GetEntitiesInRangeWithLocation(hideLocation, this.HideDistance, HideActorController.NPC, this.NpcHandles, true);
				return this.NpcHandles;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Character;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "[HideActorController][Npc]隐藏全部角色";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("baseCharacter", (baseCharacter != null) ? new bool?(baseCharacter.IsValid()) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("HideDistance", this.HideDistance);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("HideBasisBoneName", this.HideBasisBoneName);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
		string item = "SocketExist";
		bool? flag;
		if (baseCharacter == null)
		{
			flag = null;
		}
		else
		{
			USkeletalMeshComponent mesh2 = baseCharacter.Mesh;
			flag = ((mesh2 != null) ? new bool?(mesh2.DoesSocketExist(this.HideBasisBoneName)) : null);
		}
		ptr = new ValueTuple<string, object>(item, flag);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		IReadOnlyList<EntityHandle> allEntities = ModelBase<CreatureModel>.Instance.GetAllEntities();
		if (allEntities != null)
		{
			foreach (EntityHandle item2 in allEntities)
			{
				this.NpcHandles.Add(item2);
			}
		}
		return this.NpcHandles;
	}

	// Token: 0x0600E8C9 RID: 59593 RVA: 0x003EFED4 File Offset: 0x003EE0D4
	private void HideEffectInternal(EntityHandle handle, bool hidden)
	{
		CharacterSkillComponent component = handle.Entity.GetComponent<CharacterSkillComponent>();
		if (component != null)
		{
			Skill currentSkill = component.CurrentSkill;
			if (currentSkill != null)
			{
				currentSkill.SetEffectHidden(hidden);
			}
		}
		CharacterGameplayCueComponent component2 = handle.Entity.GetComponent<CharacterGameplayCueComponent>();
		if (component2 == null)
		{
			return;
		}
		component2.SetHidden(hidden);
	}

	// Token: 0x0600E8CA RID: 59594 RVA: 0x003EFF0E File Offset: 0x003EE10E
	private void HideHeadInfoInternal(EntityHandle handle, bool hidden)
	{
		PawnHeadInfoComponent component = handle.Entity.GetComponent<PawnHeadInfoComponent>();
		if (component == null)
		{
			return;
		}
		component.EnableHeadInfo(!hidden);
	}

	// Token: 0x0600E8CB RID: 59595 RVA: 0x003EFF29 File Offset: 0x003EE129
	protected override bool OnClear()
	{
		this.IsHideMesh = false;
		this.IsHideEffect = false;
		this.ShowActorInternal(true, true);
		this.IsHideNpcMesh = false;
		this.IsHideNpcEffect = false;
		this.ShowNpcActorInternal(true, true);
		this.ResetHideParameter();
		return true;
	}

	// Token: 0x0400701D RID: 28701
	private static readonly EEntityTypeQuery CHARACTER = EEntityTypeQuery.PasserbyNPC | EEntityTypeQuery.Boss | EEntityTypeQuery.Team;

	// Token: 0x0400701E RID: 28702
	private static readonly EEntityTypeQuery NPC = EEntityTypeQuery.SimpleNPC | EEntityTypeQuery.NormalNPC | EEntityTypeQuery.PasserbyNPC;

	// Token: 0x0400701F RID: 28703
	private bool IsHideMesh;

	// Token: 0x04007020 RID: 28704
	private bool IsHideEffect;

	// Token: 0x04007021 RID: 28705
	private readonly HashSet<EntityHandle> HiddenEffectSet = new HashSet<EntityHandle>();

	// Token: 0x04007022 RID: 28706
	private readonly Dictionary<EntityHandle, int> HiddenMeshMap = new Dictionary<EntityHandle, int>();

	// Token: 0x04007023 RID: 28707
	private bool IsHideNpcMesh;

	// Token: 0x04007024 RID: 28708
	private bool IsHideNpcEffect;

	// Token: 0x04007025 RID: 28709
	private readonly HashSet<EntityHandle> HiddenNpcEffectSet = new HashSet<EntityHandle>();

	// Token: 0x04007026 RID: 28710
	private readonly Dictionary<EntityHandle, int> HiddenNpcMeshMap = new Dictionary<EntityHandle, int>();

	// Token: 0x04007027 RID: 28711
	private float HideDistance;

	// Token: 0x04007028 RID: 28712
	private FName HideBasisBoneName = FNameUtil.NONE;

	// Token: 0x04007029 RID: 28713
	private long LastFrameUpdateActor;

	// Token: 0x0400702A RID: 28714
	private long LastFrameUpdateNpc;

	// Token: 0x0400702B RID: 28715
	private bool HideActorParameterDirty;

	// Token: 0x0400702C RID: 28716
	private bool HideNpcParameterDirty;

	// Token: 0x0400702D RID: 28717
	private readonly HashSet<EntityHandle> CharacterHandles = new HashSet<EntityHandle>();

	// Token: 0x0400702E RID: 28718
	private readonly HashSet<EntityHandle> NpcHandles = new HashSet<EntityHandle>();

	// Token: 0x0400702F RID: 28719
	private readonly Vector HideLocation = Vector.Create();

	// Token: 0x04007030 RID: 28720
	private readonly Vector TmpVector = Vector.Create();

	// Token: 0x04007031 RID: 28721
	private const bool Debug = false;
}
