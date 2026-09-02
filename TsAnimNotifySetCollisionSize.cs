using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DEA RID: 3562
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySetCollisionSize.TsAnimNotifySetCollisionSize_C")]
public class TsAnimNotifySetCollisionSize : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000568 RID: 1384
	// (get) Token: 0x06005226 RID: 21030 RVA: 0x000BFC3F File Offset: 0x000BDE3F
	// (set) Token: 0x06005227 RID: 21031 RVA: 0x000BFC4F File Offset: 0x000BDE4F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Radius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySetCollisionSize.__PropertyOffset_Radius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySetCollisionSize.__PropertyOffset_Radius) = value;
		}
	}

	// Token: 0x17000569 RID: 1385
	// (get) Token: 0x06005228 RID: 21032 RVA: 0x000BFC60 File Offset: 0x000BDE60
	// (set) Token: 0x06005229 RID: 21033 RVA: 0x000BFC70 File Offset: 0x000BDE70
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float HalfHeight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySetCollisionSize.__PropertyOffset_HalfHeight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySetCollisionSize.__PropertyOffset_HalfHeight) = value;
		}
	}

	// Token: 0x0600522A RID: 21034 RVA: 0x000BFC84 File Offset: 0x000BDE84
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((MeshComp != null) ? MeshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((Animation != null) ? Animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600522B RID: 21035 RVA: 0x000BFD24 File Offset: 0x000BDF24
	[NullableContext(2)]
	protected unsafe virtual bool K2_Notify_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
	{
		AActor owner = MeshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		if (this.HalfHeight <= 0f || this.Radius <= 0f)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CH;
			string message = "TsAnimNotifySetCollisionSize配置了错误的大小。为避免穿墙，必须大于0";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", owner);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("HalfHeight", this.HalfHeight);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Radius", this.Radius);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		tsBaseCharacter.CharacterActorComponent.SetRadiusAndHalfHeight(this.Radius, this.HalfHeight, false, false);
		return true;
	}

	// Token: 0x0600522C RID: 21036 RVA: 0x000BFDF8 File Offset: 0x000BDFF8
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

	// Token: 0x0600522D RID: 21037 RVA: 0x000BFE73 File Offset: 0x000BE073
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "设置碰撞大小";
	}

	// Token: 0x0600522E RID: 21038 RVA: 0x000BFE7A File Offset: 0x000BE07A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifySetCollisionSize._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySetCollisionSize.TsAnimNotifySetCollisionSize_C");
		}
		return TsAnimNotifySetCollisionSize._ClassPtr;
	}

	// Token: 0x0600522F RID: 21039 RVA: 0x000BFEA0 File Offset: 0x000BE0A0
	public TsAnimNotifySetCollisionSize() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySetCollisionSize.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005230 RID: 21040 RVA: 0x000BFEC8 File Offset: 0x000BE0C8
	[NullableContext(1)]
	public TsAnimNotifySetCollisionSize(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySetCollisionSize.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005231 RID: 21041 RVA: 0x000BFEFB File Offset: 0x000BE0FB
	protected TsAnimNotifySetCollisionSize(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005232 RID: 21042 RVA: 0x000BFF04 File Offset: 0x000BE104
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005233 RID: 21043 RVA: 0x000BFF37 File Offset: 0x000BE137
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400182E RID: 6190
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySetCollisionSize.TsAnimNotifySetCollisionSize_C";

	// Token: 0x0400182F RID: 6191
	private static IntPtr _ClassPtr;

	// Token: 0x04001830 RID: 6192
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001831 RID: 6193
	private static int __PropertyOffset_Radius;

	// Token: 0x04001832 RID: 6194
	private static int __PropertyOffset_HalfHeight;
}
