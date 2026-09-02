using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DDB RID: 3547
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyPanelQte.TsAnimNotifyPanelQte_C")]
public class TsAnimNotifyPanelQte : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000543 RID: 1347
	// (get) Token: 0x0600514A RID: 20810 RVA: 0x000BCBEB File Offset: 0x000BADEB
	// (set) Token: 0x0600514B RID: 20811 RVA: 0x000BCBFB File Offset: 0x000BADFB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int QteId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyPanelQte.__PropertyOffset_QteId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyPanelQte.__PropertyOffset_QteId) = value;
		}
	}

	// Token: 0x17000544 RID: 1348
	// (get) Token: 0x0600514C RID: 20812 RVA: 0x000BCC0C File Offset: 0x000BAE0C
	// (set) Token: 0x0600514D RID: 20813 RVA: 0x000BCC1C File Offset: 0x000BAE1C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CheckAutonomousProxy
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyPanelQte.__PropertyOffset_CheckAutonomousProxy) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyPanelQte.__PropertyOffset_CheckAutonomousProxy) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600514E RID: 20814 RVA: 0x000BCC30 File Offset: 0x000BAE30
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

	// Token: 0x0600514F RID: 20815 RVA: 0x000BCCD0 File Offset: 0x000BAED0
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		long? preMessageId = null;
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		if (this.CheckAutonomousProxy)
		{
			CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
			if (characterActorComponent == null || !characterActorComponent.Valid)
			{
				return false;
			}
			if (!characterActorComponent.IsAutonomousProxy)
			{
				return false;
			}
		}
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		object obj;
		if (tsBaseCharacter == null)
		{
			obj = null;
		}
		else
		{
			CharacterActorComponent characterActorComponent2 = tsBaseCharacter.CharacterActorComponent;
			obj = ((characterActorComponent2 != null) ? characterActorComponent2.Entity : null);
		}
		object obj2 = obj;
		preMessageId = ((obj2 != null) ? obj2.GetComponent<BaseBuffComponent>().CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null);
		ControllerBase<PanelQteController>.Instance.StartAnimNotifyQte(this.QteId, meshComp, preMessageId);
		return true;
	}

	// Token: 0x06005150 RID: 20816 RVA: 0x000BCD80 File Offset: 0x000BAF80
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

	// Token: 0x06005151 RID: 20817 RVA: 0x000BCDFB File Offset: 0x000BAFFB
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "通用QTE";
	}

	// Token: 0x06005152 RID: 20818 RVA: 0x000BCE02 File Offset: 0x000BB002
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyPanelQte._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyPanelQte.TsAnimNotifyPanelQte_C");
		}
		return TsAnimNotifyPanelQte._ClassPtr;
	}

	// Token: 0x06005153 RID: 20819 RVA: 0x000BCE28 File Offset: 0x000BB028
	public TsAnimNotifyPanelQte() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyPanelQte.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005154 RID: 20820 RVA: 0x000BCE50 File Offset: 0x000BB050
	[NullableContext(1)]
	public TsAnimNotifyPanelQte(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyPanelQte.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005155 RID: 20821 RVA: 0x000BCE83 File Offset: 0x000BB083
	protected TsAnimNotifyPanelQte(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005156 RID: 20822 RVA: 0x000BCE8C File Offset: 0x000BB08C
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005157 RID: 20823 RVA: 0x000BCEBF File Offset: 0x000BB0BF
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017D6 RID: 6102
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyPanelQte.TsAnimNotifyPanelQte_C";

	// Token: 0x040017D7 RID: 6103
	private static IntPtr _ClassPtr;

	// Token: 0x040017D8 RID: 6104
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017D9 RID: 6105
	private static int __PropertyOffset_QteId;

	// Token: 0x040017DA RID: 6106
	private static int __PropertyOffset_CheckAutonomousProxy;
}
