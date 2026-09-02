using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.CreatureTools;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D5B RID: 3419
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateMeshVisibility.TsAnimNotifyStateMeshVisibility_C")]
public class TsAnimNotifyStateMeshVisibility : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003FB RID: 1019
	// (get) Token: 0x060048FA RID: 18682 RVA: 0x0009BD7F File Offset: 0x00099F7F
	// (set) Token: 0x060048FB RID: 18683 RVA: 0x0009BD93 File Offset: 0x00099F93
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string HideMeshName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateMeshVisibility.__PropertyOffset_HideMeshName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateMeshVisibility.__PropertyOffset_HideMeshName)), value);
		}
	}

	// Token: 0x170003FC RID: 1020
	// (get) Token: 0x060048FC RID: 18684 RVA: 0x0009BDA8 File Offset: 0x00099FA8
	// (set) Token: 0x060048FD RID: 18685 RVA: 0x0009BDB8 File Offset: 0x00099FB8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Visibility
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateMeshVisibility.__PropertyOffset_Visibility) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateMeshVisibility.__PropertyOffset_Visibility) = (value ? 1 : 0);
		}
	}

	// Token: 0x060048FE RID: 18686 RVA: 0x0009BDCC File Offset: 0x00099FCC
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

	// Token: 0x060048FF RID: 18687 RVA: 0x0009BE74 File Offset: 0x0009A074
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (this.EntityMeshMap == null)
		{
			this.EntityMeshMap = new Dictionary<int, List<USkeletalMeshComponent>>();
		}
		AActor owner = meshComp.GetOwner();
		TArray<UActorComponent> tarray = owner.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
		USkeletalMeshComponent uskeletalMeshComponent = null;
		for (int i = 0; i < tarray.Num(); i++)
		{
			UActorComponent uactorComponent = tarray.Get(i);
			if (uactorComponent.GetName() == this.HideMeshName)
			{
				uskeletalMeshComponent = (uactorComponent as USkeletalMeshComponent);
				break;
			}
		}
		BP_EWorldType worldType = UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldType(owner);
		if (worldType != BP_EWorldType.Game && worldType != BP_EWorldType.PIE)
		{
			if (uskeletalMeshComponent != null)
			{
				uskeletalMeshComponent.SetVisibility(this.Visibility, false);
			}
			return true;
		}
		IBPI_CreatureInterface_C ibpi_CreatureInterface_C = owner as IBPI_CreatureInterface_C;
		if (ibpi_CreatureInterface_C == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.YZ, "TsAnimNotifyStateHideMesh,该Actor不是一个实体", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		int entityId = ibpi_CreatureInterface_C.GetEntityId();
		List<USkeletalMeshComponent> list;
		if (!this.EntityMeshMap.TryGetValue(entityId, out list))
		{
			list = (this.EntityMeshMap[entityId] = new List<USkeletalMeshComponent>());
		}
		if (uskeletalMeshComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Render;
			ELogAuthor author = ELogAuthor.YZ;
			string message = "TsAnimNotifyStateHideMesh无法找到Mesh";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("填入Mesh名", this.HideMeshName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		list.Add(uskeletalMeshComponent);
		uskeletalMeshComponent.SetVisibility(this.Visibility, false);
		return true;
	}

	// Token: 0x06004900 RID: 18688 RVA: 0x0009BFAC File Offset: 0x0009A1AC
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

	// Token: 0x06004901 RID: 18689 RVA: 0x0009C04C File Offset: 0x0009A24C
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		BP_EWorldType worldType = UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldType(owner);
		if (worldType != BP_EWorldType.Game && worldType != BP_EWorldType.PIE)
		{
			TArray<UActorComponent> tarray = owner.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
			USkeletalMeshComponent uskeletalMeshComponent = null;
			for (int i = 0; i < tarray.Num(); i++)
			{
				UActorComponent uactorComponent = tarray.Get(i);
				if (uactorComponent.GetName() == this.HideMeshName)
				{
					uskeletalMeshComponent = (uactorComponent as USkeletalMeshComponent);
					break;
				}
			}
			if (uskeletalMeshComponent != null)
			{
				uskeletalMeshComponent.SetVisibility(!this.Visibility, false);
			}
			return true;
		}
		int entityId = (owner as IBPI_CreatureInterface_C).GetEntityId();
		List<USkeletalMeshComponent> list;
		if (this.EntityMeshMap.TryGetValue(entityId, out list))
		{
			foreach (USkeletalMeshComponent uskeletalMeshComponent2 in list)
			{
				if (uskeletalMeshComponent2.GetName() == this.HideMeshName)
				{
					uskeletalMeshComponent2.SetVisibility(!this.Visibility, false);
					break;
				}
			}
		}
		return true;
	}

	// Token: 0x06004902 RID: 18690 RVA: 0x0009C15C File Offset: 0x0009A35C
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

	// Token: 0x06004903 RID: 18691 RVA: 0x0009C1D7 File Offset: 0x0009A3D7
	protected override string GetNotifyName_Implementation()
	{
		return "控制角色Mesh显隐";
	}

	// Token: 0x06004904 RID: 18692 RVA: 0x0009C1DE File Offset: 0x0009A3DE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateMeshVisibility._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateMeshVisibility.TsAnimNotifyStateMeshVisibility_C");
		}
		return TsAnimNotifyStateMeshVisibility._ClassPtr;
	}

	// Token: 0x06004905 RID: 18693 RVA: 0x0009C204 File Offset: 0x0009A404
	public TsAnimNotifyStateMeshVisibility() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateMeshVisibility.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004906 RID: 18694 RVA: 0x0009C22C File Offset: 0x0009A42C
	public TsAnimNotifyStateMeshVisibility(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateMeshVisibility.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004907 RID: 18695 RVA: 0x0009C25F File Offset: 0x0009A45F
	protected TsAnimNotifyStateMeshVisibility(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004908 RID: 18696 RVA: 0x0009C274 File Offset: 0x0009A474
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004909 RID: 18697 RVA: 0x0009C2B0 File Offset: 0x0009A4B0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600490A RID: 18698 RVA: 0x0009C2E3 File Offset: 0x0009A4E3
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400146F RID: 5231
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<int, List<USkeletalMeshComponent>> EntityMeshMap = new Dictionary<int, List<USkeletalMeshComponent>>();

	// Token: 0x04001470 RID: 5232
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateMeshVisibility.TsAnimNotifyStateMeshVisibility_C";

	// Token: 0x04001471 RID: 5233
	private static IntPtr _ClassPtr;

	// Token: 0x04001472 RID: 5234
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001473 RID: 5235
	private static int __PropertyOffset_HideMeshName;

	// Token: 0x04001474 RID: 5236
	private static int __PropertyOffset_Visibility;
}
