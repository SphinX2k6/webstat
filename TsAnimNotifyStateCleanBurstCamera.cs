using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D35 RID: 3381
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCleanBurstCamera.TsAnimNotifyStateCleanBurstCamera_C")]
public class TsAnimNotifyStateCleanBurstCamera : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700037C RID: 892
	// (get) Token: 0x06004635 RID: 17973 RVA: 0x0008D89B File Offset: 0x0008BA9B
	// (set) Token: 0x06004636 RID: 17974 RVA: 0x0008D8AB File Offset: 0x0008BAAB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 隐藏敌对目标Mesh
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCleanBurstCamera.__PropertyOffset_隐藏敌对目标Mesh) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCleanBurstCamera.__PropertyOffset_隐藏敌对目标Mesh) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700037D RID: 893
	// (get) Token: 0x06004637 RID: 17975 RVA: 0x0008D8BC File Offset: 0x0008BABC
	// (set) Token: 0x06004638 RID: 17976 RVA: 0x0008D8CC File Offset: 0x0008BACC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 隐藏敌对目标特效
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCleanBurstCamera.__PropertyOffset_隐藏敌对目标特效) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCleanBurstCamera.__PropertyOffset_隐藏敌对目标特效) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700037E RID: 894
	// (get) Token: 0x06004639 RID: 17977 RVA: 0x0008D8DD File Offset: 0x0008BADD
	// (set) Token: 0x0600463A RID: 17978 RVA: 0x0008D8ED File Offset: 0x0008BAED
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 不接受命中特效
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateCleanBurstCamera.__PropertyOffset_不接受命中特效) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateCleanBurstCamera.__PropertyOffset_不接受命中特效) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600463B RID: 17979 RVA: 0x0008D900 File Offset: 0x0008BB00
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600463C RID: 17980 RVA: 0x0008D9A8 File Offset: 0x0008BBA8
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.IsAutonomousProxy)
		{
			return false;
		}
		this.TsHideMesh = this.隐藏敌对目标Mesh;
		this.TsHideEffect = this.隐藏敌对目标特效;
		this.TsNoHitEffect = this.不接受命中特效;
		foreach (EntityHandle entityHandle in ModelBase<CreatureModel>.Instance.GetAllEntities())
		{
			if (entityHandle.IsInit)
			{
				WorldEntity entity = entityHandle.Entity;
				if (entity != null && entity.Active)
				{
					CharacterActorComponent component = entityHandle.Entity.GetComponent<CharacterActorComponent>();
					TsBaseCharacter tsBaseCharacter2 = (component != null) ? component.Actor : null;
					if (tsBaseCharacter2 != null && tsBaseCharacter2 != owner && CampUtils.GetCampRelationship(tsBaseCharacter2.Camp, tsBaseCharacter.Camp) != ERelation.Friend)
					{
						if (this.TsHiddenMap == null)
						{
							this.TsHiddenMap = new Dictionary<EntityHandle, int>();
						}
						if (this.TsHideEffect)
						{
							this.HideEffect(entityHandle, true);
							this.TsHiddenMap[entityHandle] = -1;
						}
						if (this.TsHideMesh)
						{
							int value = component.DisableActor("[TsAnimNotifyStateCleanBurstCamera] 大招镜头帧事件隐藏Mesh");
							this.TsHiddenMap[entityHandle] = value;
						}
					}
				}
			}
		}
		if (this.TsNoHitEffect)
		{
			Entity entityNoBlueprint = tsBaseCharacter.GetEntityNoBlueprint();
			if (entityNoBlueprint != null)
			{
				BaseTagComponent component2 = entityNoBlueprint.GetComponent<BaseTagComponent>();
				if (component2 != null)
				{
					component2.TagContainer.UpdateExactTag(ETagChannel.BattleBuff, GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.不接受命中特效"], 1);
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.HCW;
				string message = "No Entity for TsBaseCharacter ANS CleanBurstCamera Begin";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", tsBaseCharacter);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		return true;
	}

	// Token: 0x0600463D RID: 17981 RVA: 0x0008DB6C File Offset: 0x0008BD6C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600463E RID: 17982 RVA: 0x0008DC14 File Offset: 0x0008BE14
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		if (this.TsHideEffect && this.TsHiddenMap != null)
		{
			foreach (EntityHandle entityHandle in this.TsHiddenMap.Keys)
			{
				if (entityHandle.Valid)
				{
					this.HideEffect(entityHandle, true);
				}
			}
		}
		return true;
	}

	// Token: 0x0600463F RID: 17983 RVA: 0x0008DC88 File Offset: 0x0008BE88
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004640 RID: 17984 RVA: 0x0008DD28 File Offset: 0x0008BF28
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.TsNoHitEffect)
		{
			TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
			if (tsBaseCharacter != null)
			{
				Entity entityNoBlueprint = tsBaseCharacter.GetEntityNoBlueprint();
				if (entityNoBlueprint != null)
				{
					BaseTagComponent component = entityNoBlueprint.GetComponent<BaseTagComponent>();
					if (component != null)
					{
						component.TagContainer.UpdateExactTag(ETagChannel.BattleBuff, GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.不接受命中特效"], -1);
					}
				}
				else
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Test;
					ELogAuthor author = ELogAuthor.HCW;
					string message = "No Entity for TsBaseCharacter ANS CleanBurstCamera End";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", tsBaseCharacter);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
		}
		if (this.TsHiddenMap == null)
		{
			return true;
		}
		foreach (KeyValuePair<EntityHandle, int> keyValuePair in this.TsHiddenMap)
		{
			EntityHandle key = keyValuePair.Key;
			int value = keyValuePair.Value;
			if (key.Valid)
			{
				if (this.TsHideMesh)
				{
					CharacterActorComponent component2 = key.Entity.GetComponent<CharacterActorComponent>();
					if (component2 != null)
					{
						component2.EnableActor(value);
					}
				}
				if (this.TsHideEffect)
				{
					this.HideEffect(key, false);
				}
			}
		}
		this.TsHiddenMap = null;
		return true;
	}

	// Token: 0x06004641 RID: 17985 RVA: 0x0008DE48 File Offset: 0x0008C048
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x06004642 RID: 17986 RVA: 0x0008DEC3 File Offset: 0x0008C0C3
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "大招时显隐Mesh和特效";
	}

	// Token: 0x06004643 RID: 17987 RVA: 0x0008DECA File Offset: 0x0008C0CA
	[NullableContext(1)]
	private void HideEffect(EntityHandle handle, bool hidden)
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

	// Token: 0x06004644 RID: 17988 RVA: 0x0008DF04 File Offset: 0x0008C104
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateCleanBurstCamera._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCleanBurstCamera.TsAnimNotifyStateCleanBurstCamera_C");
		}
		return TsAnimNotifyStateCleanBurstCamera._ClassPtr;
	}

	// Token: 0x06004645 RID: 17989 RVA: 0x0008DF28 File Offset: 0x0008C128
	public TsAnimNotifyStateCleanBurstCamera() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCleanBurstCamera.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004646 RID: 17990 RVA: 0x0008DF50 File Offset: 0x0008C150
	[NullableContext(1)]
	public TsAnimNotifyStateCleanBurstCamera(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateCleanBurstCamera.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004647 RID: 17991 RVA: 0x0008DF83 File Offset: 0x0008C183
	protected TsAnimNotifyStateCleanBurstCamera(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004648 RID: 17992 RVA: 0x0008DF8C File Offset: 0x0008C18C
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004649 RID: 17993 RVA: 0x0008DFC8 File Offset: 0x0008C1C8
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x0600464A RID: 17994 RVA: 0x0008E004 File Offset: 0x0008C204
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600464B RID: 17995 RVA: 0x0008E037 File Offset: 0x0008C237
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040012EF RID: 4847
	private bool TsHideMesh;

	// Token: 0x040012F0 RID: 4848
	private bool TsHideEffect;

	// Token: 0x040012F1 RID: 4849
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<EntityHandle, int> TsHiddenMap;

	// Token: 0x040012F2 RID: 4850
	private bool TsNoHitEffect;

	// Token: 0x040012F3 RID: 4851
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateCleanBurstCamera.TsAnimNotifyStateCleanBurstCamera_C";

	// Token: 0x040012F4 RID: 4852
	private static IntPtr _ClassPtr;

	// Token: 0x040012F5 RID: 4853
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040012F6 RID: 4854
	private static int __PropertyOffset_隐藏敌对目标Mesh;

	// Token: 0x040012F7 RID: 4855
	private static int __PropertyOffset_隐藏敌对目标特效;

	// Token: 0x040012F8 RID: 4856
	private static int __PropertyOffset_不接受命中特效;
}
