using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D5A RID: 3418
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateMeshDitherDetect.TsAnimNotifyStateMeshDitherDetect_C")]
public class TsAnimNotifyStateMeshDitherDetect : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003FA RID: 1018
	// (get) Token: 0x060048EB RID: 18667 RVA: 0x0009B8E8 File Offset: 0x00099AE8
	// (set) Token: 0x060048EC RID: 18668 RVA: 0x0009B921 File Offset: 0x00099B21
	[UProperty(EPropertyFlags.CPF_None)]
	public SMeshDitherDetectConfig MeshDitherDetectConfig
	{
		get
		{
			base.FastCheckIsValid();
			SMeshDitherDetectConfig result;
			if ((result = this._MeshDitherDetectConfig) == null)
			{
				result = (this._MeshDitherDetectConfig = new SMeshDitherDetectConfig(base.NativePtr + (IntPtr)TsAnimNotifyStateMeshDitherDetect.__PropertyOffset_MeshDitherDetectConfig, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SMeshDitherDetectConfig.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateMeshDitherDetect.__PropertyOffset_MeshDitherDetectConfig, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x060048ED RID: 18669 RVA: 0x0009B94C File Offset: 0x00099B4C
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

	// Token: 0x060048EE RID: 18670 RVA: 0x0009B9F4 File Offset: 0x00099BF4
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (this.MeshDitherDetectConfig == null)
		{
			return false;
		}
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(((TsBaseCharacter)owner).EntityId);
		if (entityById == null || !entityById.Valid)
		{
			return false;
		}
		WorldEntity entity = entityById.Entity;
		CharacterMeshDitherDetectComponent characterMeshDitherDetectComponent = (entity != null) ? entity.GetComponent<CharacterMeshDitherDetectComponent>() : null;
		if (characterMeshDitherDetectComponent == null || !characterMeshDitherDetectComponent.Valid)
		{
			return false;
		}
		this.MeshDitherDetectConfigId = characterMeshDitherDetectComponent.EnableDetectDither(this.MeshDitherDetectConfig);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Character;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "[Mesh虚化检测]ANS开启角色Mesh检测并虚化";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", owner);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return true;
	}

	// Token: 0x060048EF RID: 18671 RVA: 0x0009BAA0 File Offset: 0x00099CA0
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

	// Token: 0x060048F0 RID: 18672 RVA: 0x0009BB40 File Offset: 0x00099D40
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.MeshDitherDetectConfig == null)
		{
			return false;
		}
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(((TsBaseCharacter)owner).EntityId);
		if (entityById == null || !entityById.Valid)
		{
			return false;
		}
		WorldEntity entity = entityById.Entity;
		CharacterMeshDitherDetectComponent characterMeshDitherDetectComponent = (entity != null) ? entity.GetComponent<CharacterMeshDitherDetectComponent>() : null;
		if (characterMeshDitherDetectComponent == null || !characterMeshDitherDetectComponent.Valid)
		{
			return false;
		}
		characterMeshDitherDetectComponent.DisableDetectDither(this.MeshDitherDetectConfigId);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Character;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "[Mesh虚化检测]ANS关闭角色Mesh检测并虚化";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", owner);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return true;
	}

	// Token: 0x060048F1 RID: 18673 RVA: 0x0009BBE8 File Offset: 0x00099DE8
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

	// Token: 0x060048F2 RID: 18674 RVA: 0x0009BC63 File Offset: 0x00099E63
	protected override string GetNotifyName_Implementation()
	{
		return "角色Mesh检测并虚化";
	}

	// Token: 0x060048F3 RID: 18675 RVA: 0x0009BC6A File Offset: 0x00099E6A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateMeshDitherDetect._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateMeshDitherDetect.TsAnimNotifyStateMeshDitherDetect_C");
		}
		return TsAnimNotifyStateMeshDitherDetect._ClassPtr;
	}

	// Token: 0x060048F4 RID: 18676 RVA: 0x0009BC90 File Offset: 0x00099E90
	public TsAnimNotifyStateMeshDitherDetect() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateMeshDitherDetect.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060048F5 RID: 18677 RVA: 0x0009BCB8 File Offset: 0x00099EB8
	public TsAnimNotifyStateMeshDitherDetect(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateMeshDitherDetect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060048F6 RID: 18678 RVA: 0x0009BCEB File Offset: 0x00099EEB
	protected TsAnimNotifyStateMeshDitherDetect(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060048F7 RID: 18679 RVA: 0x0009BCFC File Offset: 0x00099EFC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060048F8 RID: 18680 RVA: 0x0009BD38 File Offset: 0x00099F38
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060048F9 RID: 18681 RVA: 0x0009BD6B File Offset: 0x00099F6B
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001469 RID: 5225
	private int MeshDitherDetectConfigId = -1;

	// Token: 0x0400146A RID: 5226
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateMeshDitherDetect.TsAnimNotifyStateMeshDitherDetect_C";

	// Token: 0x0400146B RID: 5227
	private static IntPtr _ClassPtr;

	// Token: 0x0400146C RID: 5228
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400146D RID: 5229
	private static int __PropertyOffset_MeshDitherDetectConfig;

	// Token: 0x0400146E RID: 5230
	[Nullable(2)]
	private SMeshDitherDetectConfig _MeshDitherDetectConfig;
}
