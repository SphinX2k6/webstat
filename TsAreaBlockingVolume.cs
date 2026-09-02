using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000F94 RID: 3988
[UClass("/Game/Aki/TypeScript/Game/LevelGamePlay/AreaBlockingVolume/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/LevelGamePlay/AreaBlockingVolume/TsAreaBlockingVolume.TsAreaBlockingVolume_C")]
public class TsAreaBlockingVolume : ATriggerBox, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x060065AA RID: 26026 RVA: 0x00198B64 File Offset: 0x00196D64
	static TsAreaBlockingVolume()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAreaBlockingVolume.CreateStaticDefaultValue), new Action(TsAreaBlockingVolume.ResetStaticDefaultValue));
	}

	// Token: 0x170007E3 RID: 2019
	// (get) Token: 0x060065AB RID: 26027 RVA: 0x00198B83 File Offset: 0x00196D83
	// (set) Token: 0x060065AC RID: 26028 RVA: 0x00198B93 File Offset: 0x00196D93
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int AreaId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAreaBlockingVolume.__PropertyOffset_AreaId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAreaBlockingVolume.__PropertyOffset_AreaId) = value;
		}
	}

	// Token: 0x060065AD RID: 26029 RVA: 0x00198BA4 File Offset: 0x00196DA4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void NotifyEnterArea()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("NotifyEnterArea"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x060065AE RID: 26030 RVA: 0x00198C14 File Offset: 0x00196E14
	protected void NotifyEnterArea_Implementation()
	{
		if (Singleton<Time>.Instance.PlayerTime - TsAreaBlockingVolume.lastLogTime >= 5000.0)
		{
			TsAreaBlockingVolume.lastLogTime = Singleton<Time>.Instance.PlayerTime;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Log;
			ELogAuthor author = ELogAuthor.LC;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
			defaultInterpolatedStringHandler.AppendLiteral("AreaBlockingVolume:进入区域");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.AreaId);
			instance.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.EnterAreaNotify, this.AreaId);
	}

	// Token: 0x060065AF RID: 26031 RVA: 0x00198CA4 File Offset: 0x00196EA4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveHit(UPrimitiveComponent myComp, AActor other, UPrimitiveComponent otherComp, bool bSelfMoved, FVector hitLocation, FVector hitNormal, FVector normalImpulse, in FHitResult hit)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveHit"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveHit_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveHit_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveHit_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MyComp) = ((myComp != null) ? myComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Other) = ((other != null) ? other.NativePtr : ((IntPtr)0));
			*(&ptr2->OtherComp) = ((otherComp != null) ? otherComp.NativePtr : ((IntPtr)0));
			ptr2->bSelfMoved = bSelfMoved;
			ptr2->HitLocation = hitLocation;
			ptr2->HitNormal = hitNormal;
			ptr2->NormalImpulse = normalImpulse;
			UScriptStructStackOnlyPtr nativeUStructPtr = FHitResult.StaticStruct();
			IntPtr dest = &ptr2->Hit;
			object obj = hit;
			UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (obj != null) ? obj.NativePtr : ((IntPtr)0), 1, false);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060065B0 RID: 26032 RVA: 0x00198D98 File Offset: 0x00196F98
	[NullableContext(2)]
	protected void ReceiveHit_Implementation(UPrimitiveComponent myComp, AActor other, UPrimitiveComponent otherComp, bool bSelfMoved, FVector hitLocation, FVector hitNormal, FVector normalImpulse, in FHitResult hit)
	{
		this.NotifyEnterArea();
	}

	// Token: 0x060065B1 RID: 26033 RVA: 0x00198DA0 File Offset: 0x00196FA0
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x060065B2 RID: 26034 RVA: 0x00198DA2 File Offset: 0x00196FA2
	public static void ResetStaticDefaultValue()
	{
		TsAreaBlockingVolume.lastLogTime = 0.0;
	}

	// Token: 0x060065B3 RID: 26035 RVA: 0x00198DB2 File Offset: 0x00196FB2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAreaBlockingVolume._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/LevelGamePlay/AreaBlockingVolume/TsAreaBlockingVolume.TsAreaBlockingVolume_C");
		}
		return TsAreaBlockingVolume._ClassPtr;
	}

	// Token: 0x060065B4 RID: 26036 RVA: 0x00198DD8 File Offset: 0x00196FD8
	public TsAreaBlockingVolume() : this(BuiltinUtils.AllocNativeUObject(TsAreaBlockingVolume.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060065B5 RID: 26037 RVA: 0x00198E00 File Offset: 0x00197000
	[NullableContext(1)]
	public TsAreaBlockingVolume(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAreaBlockingVolume.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060065B6 RID: 26038 RVA: 0x00198E33 File Offset: 0x00197033
	protected TsAreaBlockingVolume(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060065B7 RID: 26039 RVA: 0x00198E3C File Offset: 0x0019703C
	protected virtual void __CPPCALL_NotifyEnterArea_Implementation()
	{
		this.NotifyEnterArea_Implementation();
	}

	// Token: 0x060065B8 RID: 26040 RVA: 0x00198E44 File Offset: 0x00197044
	protected unsafe virtual void __CPPCALL_ReceiveHit_Implementation(AActor.__ReceiveHit_FunctionParams* __Params)
	{
		UPrimitiveComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UPrimitiveComponent>(__Params->MyComp);
		AActor orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->Other);
		UPrimitiveComponent orCreateUObjectByNativePointer3 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UPrimitiveComponent>(__Params->OtherComp);
		FHitResult fhitResult = new FHitResult(&__Params->Hit, true, true);
		this.ReceiveHit_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, orCreateUObjectByNativePointer3, __Params->bSelfMoved, __Params->HitLocation, __Params->HitNormal, __Params->NormalImpulse, fhitResult);
	}

	// Token: 0x0400305F RID: 12383
	private static double lastLogTime;

	// Token: 0x04003060 RID: 12384
	private const int LOG_INTERVAL = 5000;

	// Token: 0x04003061 RID: 12385
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/LevelGamePlay/AreaBlockingVolume/TsAreaBlockingVolume.TsAreaBlockingVolume_C";

	// Token: 0x04003062 RID: 12386
	private static IntPtr _ClassPtr;

	// Token: 0x04003063 RID: 12387
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04003064 RID: 12388
	private static int __PropertyOffset_AreaId;
}
