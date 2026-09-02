using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Effect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020032C8 RID: 13000
[UClass("/Game/Aki/TypeScript/Game/Recorder/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Recorder/TsRecordEffect.TsRecordEffect_C")]
public class TsRecordEffect : AKuroRecordEffect, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700252D RID: 9517
	// (get) Token: 0x0601B41F RID: 111647 RVA: 0x0082FBD2 File Offset: 0x0082DDD2
	// (set) Token: 0x0601B420 RID: 111648 RVA: 0x0082FBE6 File Offset: 0x0082DDE6
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string EffectModelDataPath
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsRecordEffect.__PropertyOffset_EffectModelDataPath)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsRecordEffect.__PropertyOffset_EffectModelDataPath)), value);
		}
	}

	// Token: 0x1700252E RID: 9518
	// (get) Token: 0x0601B421 RID: 111649 RVA: 0x0082FBFB File Offset: 0x0082DDFB
	// (set) Token: 0x0601B422 RID: 111650 RVA: 0x0082FC0B File Offset: 0x0082DE0B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int LifeTimeType
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsRecordEffect.__PropertyOffset_LifeTimeType);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsRecordEffect.__PropertyOffset_LifeTimeType) = value;
		}
	}

	// Token: 0x1700252F RID: 9519
	// (get) Token: 0x0601B423 RID: 111651 RVA: 0x0082FC1C File Offset: 0x0082DE1C
	// (set) Token: 0x0601B424 RID: 111652 RVA: 0x0082FC30 File Offset: 0x0082DE30
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UEffectModelBase EffectModelData
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UEffectModelBase>(base.NativePtr / (IntPtr)sizeof(void*) + TsRecordEffect.__PropertyOffset_EffectModelData);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsRecordEffect.__PropertyOffset_EffectModelData, value);
		}
	}

	// Token: 0x17002530 RID: 9520
	// (get) Token: 0x0601B425 RID: 111653 RVA: 0x0082FC45 File Offset: 0x0082DE45
	// (set) Token: 0x0601B426 RID: 111654 RVA: 0x0082FC55 File Offset: 0x0082DE55
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ManualProcessTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsRecordEffect.__PropertyOffset_ManualProcessTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsRecordEffect.__PropertyOffset_ManualProcessTime) = value;
		}
	}

	// Token: 0x0601B427 RID: 111655 RVA: 0x0082FC68 File Offset: 0x0082DE68
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveBeginPlay()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveBeginPlay"), out num);
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

	// Token: 0x0601B428 RID: 111656 RVA: 0x0082FCD8 File Offset: 0x0082DED8
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		base.SetActorTickEnabled(true);
	}

	// Token: 0x0601B429 RID: 111657 RVA: 0x0082FCE4 File Offset: 0x0082DEE4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveEndPlay(EEndPlayReason endPlayReason)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveEndPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveEndPlay_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveEndPlay_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveEndPlay_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(byte*)(&ptr2->EndPlayReason) = (byte)endPlayReason;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B42A RID: 111658 RVA: 0x0082FD60 File Offset: 0x0082DF60
	protected virtual void ReceiveEndPlay_Implementation(EEndPlayReason endPlayReason)
	{
		if (!Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle))
		{
			return;
		}
		Singleton<EffectSystem>.Instance.StopEffectById(this.EffectHandle, "[TsRecordEffect.ReceiveEndPlay]", true, null);
	}

	// Token: 0x0601B42B RID: 111659 RVA: 0x0082FDA0 File Offset: 0x0082DFA0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTick(float delta)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveTick_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = delta;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B42C RID: 111660 RVA: 0x0082FE18 File Offset: 0x0082E018
	protected virtual void ReceiveTick_Implementation(float delta)
	{
		if (this.Playing && this.EffectModelData == null && !string.IsNullOrEmpty(this.EffectModelDataPath))
		{
			this.TryAddEffectView();
		}
		if (this.EffectHandle != 0)
		{
			if (!Singleton<Info>.Instance.IsGameRunning())
			{
				Singleton<EffectSystem>.Instance.TickHandleInEditor(this.EffectHandle, delta);
			}
			if (this.LifeTimeType == 3 && this.ManualProcessTime > -1f)
			{
				Singleton<EffectSystem>.Instance.HandleSeekToTimeWithProcess(this.EffectHandle, this.ManualProcessTime, true, delta);
			}
			if (this.LastHidden != base.bHidden)
			{
				this.LastHidden = base.bHidden;
				Singleton<EffectSystem>.Instance.SetEffectHidden(this.EffectHandle, base.bHidden, null, false);
			}
		}
	}

	// Token: 0x0601B42D RID: 111661 RVA: 0x0082FED0 File Offset: 0x0082E0D0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnPlay()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnPlay"), out num);
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

	// Token: 0x0601B42E RID: 111662 RVA: 0x0082FF40 File Offset: 0x0082E140
	protected virtual void OnPlay_Implementation()
	{
		this.Playing = true;
		this.TryAddEffectView();
	}

	// Token: 0x0601B42F RID: 111663 RVA: 0x0082FF50 File Offset: 0x0082E150
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnStop()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnStop"), out num);
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

	// Token: 0x0601B430 RID: 111664 RVA: 0x0082FFC0 File Offset: 0x0082E1C0
	protected virtual void OnStop_Implementation()
	{
		this.Playing = false;
		if (!Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle))
		{
			return;
		}
		Singleton<EffectSystem>.Instance.StopEffectById(this.EffectHandle, "[TsRecordEffect.OnStop]", false, null);
	}

	// Token: 0x0601B431 RID: 111665 RVA: 0x00830008 File Offset: 0x0082E208
	private unsafe void TryAddEffectView()
	{
		if (this.EffectModelData == null)
		{
			if (string.IsNullOrEmpty(this.EffectModelDataPath))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Recorder;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "No EffectModelData";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", this);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Recorder;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "No EffectModelData but TryLoad";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", this);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Path", this.EffectModelDataPath);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.EffectModelData = Singleton<ResourceSystem>.Instance.Load<UEffectModelBase>(this.EffectModelDataPath, "js_undefined");
		}
		if (this.EffectHandle != 0)
		{
			return;
		}
		string pathName = UKismetSystemLibrary.GetPathName(this.EffectModelData);
		FTransformDouble value = base.D_GetTransform();
		EffectSystem instance3 = Singleton<EffectSystem>.Instance;
		FTransformDouble? ftransformDouble = new FTransformDouble?(value);
		this.EffectHandle = instance3.SpawnEffect(this, ftransformDouble, pathName, "[TsRecordEffect.TryAddEffectView]", new EffectContext(null, this, false), EEffectType.Fight, delegate(int h)
		{
			if (this.LifeTimeType == 3)
			{
				Singleton<EffectSystem>.Instance.FreezeHandle(h, true, false);
			}
		}, null, null, false, false);
		if (!Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle))
		{
			return;
		}
		OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.EffectHandle);
		FName? fname = null;
		effectActor.K2_AttachToActor(this, fname, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false);
	}

	// Token: 0x0601B432 RID: 111666 RVA: 0x00830163 File Offset: 0x0082E363
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsRecordEffect._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Recorder/TsRecordEffect.TsRecordEffect_C");
		}
		return TsRecordEffect._ClassPtr;
	}

	// Token: 0x0601B433 RID: 111667 RVA: 0x00830188 File Offset: 0x0082E388
	public TsRecordEffect() : this(BuiltinUtils.AllocNativeUObject(TsRecordEffect.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601B434 RID: 111668 RVA: 0x008301B0 File Offset: 0x0082E3B0
	[NullableContext(1)]
	public TsRecordEffect(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsRecordEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601B435 RID: 111669 RVA: 0x008301E3 File Offset: 0x0082E3E3
	protected TsRecordEffect(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601B436 RID: 111670 RVA: 0x008301EC File Offset: 0x0082E3EC
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601B437 RID: 111671 RVA: 0x008301F4 File Offset: 0x0082E3F4
	protected unsafe virtual void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		this.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601B438 RID: 111672 RVA: 0x00830214 File Offset: 0x0082E414
	protected unsafe virtual void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		this.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601B439 RID: 111673 RVA: 0x00830222 File Offset: 0x0082E422
	protected virtual void __CPPCALL_OnPlay_Implementation()
	{
		this.OnPlay_Implementation();
	}

	// Token: 0x0601B43A RID: 111674 RVA: 0x0083022A File Offset: 0x0082E42A
	protected virtual void __CPPCALL_OnStop_Implementation()
	{
		this.OnStop_Implementation();
	}

	// Token: 0x0400DE20 RID: 56864
	private int EffectHandle;

	// Token: 0x0400DE21 RID: 56865
	private bool Playing;

	// Token: 0x0400DE22 RID: 56866
	private bool LastHidden;

	// Token: 0x0400DE23 RID: 56867
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Recorder/TsRecordEffect.TsRecordEffect_C";

	// Token: 0x0400DE24 RID: 56868
	private static IntPtr _ClassPtr;

	// Token: 0x0400DE25 RID: 56869
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DE26 RID: 56870
	private static int __PropertyOffset_EffectModelDataPath;

	// Token: 0x0400DE27 RID: 56871
	private static int __PropertyOffset_LifeTimeType;

	// Token: 0x0400DE28 RID: 56872
	private static int __PropertyOffset_EffectModelData;

	// Token: 0x0400DE29 RID: 56873
	private static int __PropertyOffset_ManualProcessTime;
}
