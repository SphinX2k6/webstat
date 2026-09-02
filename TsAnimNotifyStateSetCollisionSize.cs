using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D7A RID: 3450
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetCollisionSize.TsAnimNotifyStateSetCollisionSize_C")]
public class TsAnimNotifyStateSetCollisionSize : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x06004B64 RID: 19300 RVA: 0x000A69AB File Offset: 0x000A4BAB
	static TsAnimNotifyStateSetCollisionSize()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateSetCollisionSize.CreateStaticDefaultValue), new Action(TsAnimNotifyStateSetCollisionSize.ResetStaticDefaultValue));
	}

	// Token: 0x06004B65 RID: 19301 RVA: 0x000A69CA File Offset: 0x000A4BCA
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateSetCollisionSize.saveId = new Dictionary<int, int>();
	}

	// Token: 0x06004B66 RID: 19302 RVA: 0x000A69D6 File Offset: 0x000A4BD6
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateSetCollisionSize.saveId = null;
	}

	// Token: 0x17000469 RID: 1129
	// (get) Token: 0x06004B67 RID: 19303 RVA: 0x000A69DE File Offset: 0x000A4BDE
	// (set) Token: 0x06004B68 RID: 19304 RVA: 0x000A69EE File Offset: 0x000A4BEE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Id
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetCollisionSize.__PropertyOffset_Id);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetCollisionSize.__PropertyOffset_Id) = value;
		}
	}

	// Token: 0x1700046A RID: 1130
	// (get) Token: 0x06004B69 RID: 19305 RVA: 0x000A69FF File Offset: 0x000A4BFF
	// (set) Token: 0x06004B6A RID: 19306 RVA: 0x000A6A0F File Offset: 0x000A4C0F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Radius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetCollisionSize.__PropertyOffset_Radius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetCollisionSize.__PropertyOffset_Radius) = value;
		}
	}

	// Token: 0x1700046B RID: 1131
	// (get) Token: 0x06004B6B RID: 19307 RVA: 0x000A6A20 File Offset: 0x000A4C20
	// (set) Token: 0x06004B6C RID: 19308 RVA: 0x000A6A30 File Offset: 0x000A4C30
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float HalfHeight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetCollisionSize.__PropertyOffset_HalfHeight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetCollisionSize.__PropertyOffset_HalfHeight) = value;
		}
	}

	// Token: 0x06004B6D RID: 19309 RVA: 0x000A6A44 File Offset: 0x000A4C44
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

	// Token: 0x06004B6E RID: 19310 RVA: 0x000A6AEC File Offset: 0x000A4CEC
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		if (this.HalfHeight <= 0f || this.Radius <= 0f)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "TsAnimNotifyStateSetCollisionSize配置了错误的大小。为避免穿墙，必须大于0";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", owner);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("HalfHeight", this.HalfHeight);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Radius", this.Radius);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		int id = characterActorComponent.Entity.Id;
		TsAnimNotifyStateSetCollisionSize.saveId[id] = this.Id;
		characterActorComponent.SetRadiusAndHalfHeight(this.Radius, this.HalfHeight, false, false);
		return true;
	}

	// Token: 0x06004B6F RID: 19311 RVA: 0x000A6BE0 File Offset: 0x000A4DE0
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

	// Token: 0x06004B70 RID: 19312 RVA: 0x000A6C80 File Offset: 0x000A4E80
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		int id = characterActorComponent.Entity.Id;
		int num;
		if (TsAnimNotifyStateSetCollisionSize.saveId.TryGetValue(id, out num) && num == this.Id)
		{
			characterActorComponent.ResetCapsuleRadiusAndHeight(false);
			TsAnimNotifyStateSetCollisionSize.saveId.Remove(id);
		}
		return true;
	}

	// Token: 0x06004B71 RID: 19313 RVA: 0x000A6CE4 File Offset: 0x000A4EE4
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

	// Token: 0x06004B72 RID: 19314 RVA: 0x000A6D5F File Offset: 0x000A4F5F
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "设置胶囊体大小";
	}

	// Token: 0x06004B73 RID: 19315 RVA: 0x000A6D66 File Offset: 0x000A4F66
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSetCollisionSize._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetCollisionSize.TsAnimNotifyStateSetCollisionSize_C");
		}
		return TsAnimNotifyStateSetCollisionSize._ClassPtr;
	}

	// Token: 0x06004B74 RID: 19316 RVA: 0x000A6D8C File Offset: 0x000A4F8C
	public TsAnimNotifyStateSetCollisionSize() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetCollisionSize.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004B75 RID: 19317 RVA: 0x000A6DB4 File Offset: 0x000A4FB4
	[NullableContext(1)]
	public TsAnimNotifyStateSetCollisionSize(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetCollisionSize.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004B76 RID: 19318 RVA: 0x000A6DE7 File Offset: 0x000A4FE7
	protected TsAnimNotifyStateSetCollisionSize(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004B77 RID: 19319 RVA: 0x000A6DF0 File Offset: 0x000A4FF0
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004B78 RID: 19320 RVA: 0x000A6E2C File Offset: 0x000A502C
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004B79 RID: 19321 RVA: 0x000A6E5F File Offset: 0x000A505F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400158A RID: 5514
	[Nullable(1)]
	private static Dictionary<int, int> saveId;

	// Token: 0x0400158B RID: 5515
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetCollisionSize.TsAnimNotifyStateSetCollisionSize_C";

	// Token: 0x0400158C RID: 5516
	private static IntPtr _ClassPtr;

	// Token: 0x0400158D RID: 5517
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400158E RID: 5518
	private static int __PropertyOffset_Id;

	// Token: 0x0400158F RID: 5519
	private static int __PropertyOffset_Radius;

	// Token: 0x04001590 RID: 5520
	private static int __PropertyOffset_HalfHeight;
}
