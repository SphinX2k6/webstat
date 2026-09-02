using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DB8 RID: 3512
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeRoleQte.TsAnimNotifyChangeRoleQte_C")]
public class TsAnimNotifyChangeRoleQte : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700050B RID: 1291
	// (get) Token: 0x06004F82 RID: 20354 RVA: 0x000B68F3 File Offset: 0x000B4AF3
	// (set) Token: 0x06004F83 RID: 20355 RVA: 0x000B6903 File Offset: 0x000B4B03
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int QteId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyChangeRoleQte.__PropertyOffset_QteId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyChangeRoleQte.__PropertyOffset_QteId) = value;
		}
	}

	// Token: 0x1700050C RID: 1292
	// (get) Token: 0x06004F84 RID: 20356 RVA: 0x000B6914 File Offset: 0x000B4B14
	// (set) Token: 0x06004F85 RID: 20357 RVA: 0x000B6924 File Offset: 0x000B4B24
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float QteDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyChangeRoleQte.__PropertyOffset_QteDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyChangeRoleQte.__PropertyOffset_QteDistance) = value;
		}
	}

	// Token: 0x06004F86 RID: 20358 RVA: 0x000B6938 File Offset: 0x000B4B38
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
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

	// Token: 0x06004F87 RID: 20359 RVA: 0x000B69D8 File Offset: 0x000B4BD8
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return true;
		}
		SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
		if (getCurrentTeamItem != null)
		{
			EntityHandle entityHandle = getCurrentTeamItem.EntityHandle;
			bool? flag;
			if (entityHandle == null)
			{
				flag = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				if (entity == null)
				{
					flag = null;
				}
				else
				{
					BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
					flag = ((component != null) ? new bool?(component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"])) : null);
				}
			}
			bool? flag2 = flag;
			if (flag2.GetValueOrDefault())
			{
				return true;
			}
		}
		if (this.QteDistance > 0f)
		{
			AActor owner = meshComp.GetOwner();
			FVectorDouble? fvectorDouble = (owner != null) ? new FVectorDouble?(owner.D_K2_GetActorLocation()) : null;
			Vector vector;
			if (getCurrentTeamItem == null)
			{
				vector = null;
			}
			else
			{
				EntityHandle entityHandle2 = getCurrentTeamItem.EntityHandle;
				if (entityHandle2 == null)
				{
					vector = null;
				}
				else
				{
					WorldEntity entity2 = entityHandle2.Entity;
					vector = ((entity2 != null) ? entity2.GetComponent<CharacterActorComponent>().ActorLocationProxy : null);
				}
			}
			Vector vector2 = vector;
			if (fvectorDouble == null || vector2 == null)
			{
				return true;
			}
			if (Math.Pow(fvectorDouble.Value.X - vector2.X, 2.0) + Math.Pow(fvectorDouble.Value.Y - vector2.Y, 2.0) + Math.Pow(fvectorDouble.Value.Z - vector2.Z, 2.0) > (double)(this.QteDistance * this.QteDistance))
			{
				return true;
			}
		}
		long? preMessageId = null;
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			object obj;
			if (tsBaseCharacter == null)
			{
				obj = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
				obj = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
			}
			object obj2 = obj;
			preMessageId = ((obj2 != null) ? obj2.GetComponent<BaseBuffComponent>().CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null);
		}
		foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(false))
		{
			long creatureDataId = sceneTeamItem.GetCreatureDataId();
			long? num = (getCurrentTeamItem != null) ? new long?(getCurrentTeamItem.GetCreatureDataId()) : null;
			if (!(creatureDataId == num.GetValueOrDefault() & num != null) && sceneTeamItem.CanGoBattle() == EGoBattleResultType.Success)
			{
				ControllerBase<PanelQteController>.Instance.StartAnimNotifyQte(this.QteId, meshComp, preMessageId);
				return true;
			}
		}
		return true;
	}

	// Token: 0x06004F88 RID: 20360 RVA: 0x000B6C40 File Offset: 0x000B4E40
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x06004F89 RID: 20361 RVA: 0x000B6CBB File Offset: 0x000B4EBB
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "换人QTE";
	}

	// Token: 0x06004F8A RID: 20362 RVA: 0x000B6CC2 File Offset: 0x000B4EC2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyChangeRoleQte._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeRoleQte.TsAnimNotifyChangeRoleQte_C");
		}
		return TsAnimNotifyChangeRoleQte._ClassPtr;
	}

	// Token: 0x06004F8B RID: 20363 RVA: 0x000B6CE8 File Offset: 0x000B4EE8
	public TsAnimNotifyChangeRoleQte() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyChangeRoleQte.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004F8C RID: 20364 RVA: 0x000B6D10 File Offset: 0x000B4F10
	[NullableContext(1)]
	public TsAnimNotifyChangeRoleQte(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyChangeRoleQte.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004F8D RID: 20365 RVA: 0x000B6D43 File Offset: 0x000B4F43
	protected TsAnimNotifyChangeRoleQte(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004F8E RID: 20366 RVA: 0x000B6D4C File Offset: 0x000B4F4C
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004F8F RID: 20367 RVA: 0x000B6D7F File Offset: 0x000B4F7F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400172E RID: 5934
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeRoleQte.TsAnimNotifyChangeRoleQte_C";

	// Token: 0x0400172F RID: 5935
	private static IntPtr _ClassPtr;

	// Token: 0x04001730 RID: 5936
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001731 RID: 5937
	private static int __PropertyOffset_QteId;

	// Token: 0x04001732 RID: 5938
	private static int __PropertyOffset_QteDistance;
}
