using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DD3 RID: 3539
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyHideMesh.TsAnimNotifyHideMesh_C")]
public class TsAnimNotifyHideMesh : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000534 RID: 1332
	// (get) Token: 0x060050E0 RID: 20704 RVA: 0x000BB3A3 File Offset: 0x000B95A3
	// (set) Token: 0x060050E1 RID: 20705 RVA: 0x000BB3B7 File Offset: 0x000B95B7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ChildMeshName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyHideMesh.__PropertyOffset_ChildMeshName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyHideMesh.__PropertyOffset_ChildMeshName)), value);
		}
	}

	// Token: 0x17000535 RID: 1333
	// (get) Token: 0x060050E2 RID: 20706 RVA: 0x000BB3CC File Offset: 0x000B95CC
	// (set) Token: 0x060050E3 RID: 20707 RVA: 0x000BB3DC File Offset: 0x000B95DC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool HideChildren
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyHideMesh.__PropertyOffset_HideChildren) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyHideMesh.__PropertyOffset_HideChildren) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000536 RID: 1334
	// (get) Token: 0x060050E4 RID: 20708 RVA: 0x000BB3ED File Offset: 0x000B95ED
	// (set) Token: 0x060050E5 RID: 20709 RVA: 0x000BB3FD File Offset: 0x000B95FD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool HideChildrenActors
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyHideMesh.__PropertyOffset_HideChildrenActors) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyHideMesh.__PropertyOffset_HideChildrenActors) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000537 RID: 1335
	// (get) Token: 0x060050E6 RID: 20710 RVA: 0x000BB40E File Offset: 0x000B960E
	// (set) Token: 0x060050E7 RID: 20711 RVA: 0x000BB41E File Offset: 0x000B961E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Hide
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyHideMesh.__PropertyOffset_Hide) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyHideMesh.__PropertyOffset_Hide) = (value ? 1 : 0);
		}
	}

	// Token: 0x060050E8 RID: 20712 RVA: 0x000BB430 File Offset: 0x000B9630
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

	// Token: 0x060050E9 RID: 20713 RVA: 0x000BB4D0 File Offset: 0x000B96D0
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner == null)
		{
			return false;
		}
		UMeshComponent umeshComponent = null;
		if (string.IsNullOrEmpty(this.ChildMeshName))
		{
			umeshComponent = meshComp;
		}
		else
		{
			TArray<UActorComponent> tarray = owner.K2_GetComponentsByClass(UMeshComponent.StaticClass());
			for (int i = tarray.Num() - 1; i >= 0; i--)
			{
				UMeshComponent umeshComponent2 = tarray.Get(i) as UMeshComponent;
				if (((umeshComponent2 != null) ? umeshComponent2.GetName() : null) == this.ChildMeshName)
				{
					umeshComponent = umeshComponent2;
					break;
				}
			}
		}
		if (umeshComponent == null)
		{
			return false;
		}
		umeshComponent.SetHiddenInGame(this.Hide, this.HideChildren);
		return true;
	}

	// Token: 0x060050EA RID: 20714 RVA: 0x000BB568 File Offset: 0x000B9768
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

	// Token: 0x060050EB RID: 20715 RVA: 0x000BB5E3 File Offset: 0x000B97E3
	protected override string GetNotifyName_Implementation()
	{
		return "隐藏网格体";
	}

	// Token: 0x060050EC RID: 20716 RVA: 0x000BB5EA File Offset: 0x000B97EA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyHideMesh._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyHideMesh.TsAnimNotifyHideMesh_C");
		}
		return TsAnimNotifyHideMesh._ClassPtr;
	}

	// Token: 0x060050ED RID: 20717 RVA: 0x000BB610 File Offset: 0x000B9810
	public TsAnimNotifyHideMesh() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyHideMesh.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060050EE RID: 20718 RVA: 0x000BB638 File Offset: 0x000B9838
	public TsAnimNotifyHideMesh(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyHideMesh.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060050EF RID: 20719 RVA: 0x000BB66B File Offset: 0x000B986B
	protected TsAnimNotifyHideMesh(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060050F0 RID: 20720 RVA: 0x000BB674 File Offset: 0x000B9874
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060050F1 RID: 20721 RVA: 0x000BB6A7 File Offset: 0x000B98A7
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017AF RID: 6063
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyHideMesh.TsAnimNotifyHideMesh_C";

	// Token: 0x040017B0 RID: 6064
	private static IntPtr _ClassPtr;

	// Token: 0x040017B1 RID: 6065
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017B2 RID: 6066
	private static int __PropertyOffset_ChildMeshName;

	// Token: 0x040017B3 RID: 6067
	private static int __PropertyOffset_HideChildren;

	// Token: 0x040017B4 RID: 6068
	private static int __PropertyOffset_HideChildrenActors;

	// Token: 0x040017B5 RID: 6069
	private static int __PropertyOffset_Hide;
}
