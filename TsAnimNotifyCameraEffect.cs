using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DB1 RID: 3505
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCameraEffect.TsAnimNotifyCameraEffect_C")]
public class TsAnimNotifyCameraEffect : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004F6 RID: 1270
	// (get) Token: 0x06004F14 RID: 20244 RVA: 0x000B5397 File Offset: 0x000B3597
	// (set) Token: 0x06004F15 RID: 20245 RVA: 0x000B53AB File Offset: 0x000B35AB
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EffectScreenPlayData_C EffectData
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<EffectScreenPlayData_C>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyCameraEffect.__PropertyOffset_EffectData);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyCameraEffect.__PropertyOffset_EffectData, value);
		}
	}

	// Token: 0x06004F16 RID: 20246 RVA: 0x000B53C0 File Offset: 0x000B35C0
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

	// Token: 0x06004F17 RID: 20247 RVA: 0x000B545F File Offset: 0x000B365F
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.EffectData != null)
		{
			ScreenEffectSystem.GetInstance().PlayScreenEffect(this.EffectData);
		}
		return true;
	}

	// Token: 0x06004F18 RID: 20248 RVA: 0x000B547C File Offset: 0x000B367C
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

	// Token: 0x06004F19 RID: 20249 RVA: 0x000B54F7 File Offset: 0x000B36F7
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "镜头特效";
	}

	// Token: 0x06004F1A RID: 20250 RVA: 0x000B54FE File Offset: 0x000B36FE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyCameraEffect._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCameraEffect.TsAnimNotifyCameraEffect_C");
		}
		return TsAnimNotifyCameraEffect._ClassPtr;
	}

	// Token: 0x06004F1B RID: 20251 RVA: 0x000B5524 File Offset: 0x000B3724
	public TsAnimNotifyCameraEffect() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyCameraEffect.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004F1C RID: 20252 RVA: 0x000B554C File Offset: 0x000B374C
	[NullableContext(1)]
	public TsAnimNotifyCameraEffect(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyCameraEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004F1D RID: 20253 RVA: 0x000B557F File Offset: 0x000B377F
	protected TsAnimNotifyCameraEffect(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004F1E RID: 20254 RVA: 0x000B5588 File Offset: 0x000B3788
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004F1F RID: 20255 RVA: 0x000B55BB File Offset: 0x000B37BB
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040016FE RID: 5886
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCameraEffect.TsAnimNotifyCameraEffect_C";

	// Token: 0x040016FF RID: 5887
	private static IntPtr _ClassPtr;

	// Token: 0x04001700 RID: 5888
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001701 RID: 5889
	private static int __PropertyOffset_EffectData;
}
