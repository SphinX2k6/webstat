using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Common.Struct;
using AkiClient.Game.Aki.Data.Recorder;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020032C9 RID: 13001
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Recorder/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Recorder/TsRecordGameplayCue.TsRecordGameplayCue_C")]
public class TsRecordGameplayCue : AKuroRecordEffect, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002531 RID: 9521
	// (get) Token: 0x0601B43C RID: 111676 RVA: 0x0083024A File Offset: 0x0082E44A
	// (set) Token: 0x0601B43D RID: 111677 RVA: 0x0083025E File Offset: 0x0082E45E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string Path
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsRecordGameplayCue.__PropertyOffset_Path)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsRecordGameplayCue.__PropertyOffset_Path)), value);
		}
	}

	// Token: 0x17002532 RID: 9522
	// (get) Token: 0x0601B43E RID: 111678 RVA: 0x00830273 File Offset: 0x0082E473
	// (set) Token: 0x0601B43F RID: 111679 RVA: 0x00830287 File Offset: 0x0082E487
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector Position0
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsRecordGameplayCue.__PropertyOffset_Position0);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsRecordGameplayCue.__PropertyOffset_Position0) = value;
		}
	}

	// Token: 0x17002533 RID: 9523
	// (get) Token: 0x0601B440 RID: 111680 RVA: 0x0083029C File Offset: 0x0082E49C
	// (set) Token: 0x0601B441 RID: 111681 RVA: 0x008302B0 File Offset: 0x0082E4B0
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe BP_GameplayCueBeamDataAsset_C BeamData
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<BP_GameplayCueBeamDataAsset_C>(base.NativePtr / (IntPtr)sizeof(void*) + TsRecordGameplayCue.__PropertyOffset_BeamData);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsRecordGameplayCue.__PropertyOffset_BeamData, value);
		}
	}

	// Token: 0x0601B442 RID: 111682 RVA: 0x008302C8 File Offset: 0x0082E4C8
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

	// Token: 0x0601B443 RID: 111683 RVA: 0x00830338 File Offset: 0x0082E538
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		base.SetActorTickEnabled(false);
	}

	// Token: 0x0601B444 RID: 111684 RVA: 0x00830344 File Offset: 0x0082E544
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

	// Token: 0x0601B445 RID: 111685 RVA: 0x008303BD File Offset: 0x0082E5BD
	protected virtual void ReceiveEndPlay_Implementation(EEndPlayReason endPlayReason)
	{
		this.OnStop();
	}

	// Token: 0x0601B446 RID: 111686 RVA: 0x008303C8 File Offset: 0x0082E5C8
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

	// Token: 0x0601B447 RID: 111687 RVA: 0x00830438 File Offset: 0x0082E638
	protected virtual void OnPlay_Implementation()
	{
		this.SpawnHookActorRecord();
	}

	// Token: 0x0601B448 RID: 111688 RVA: 0x00830440 File Offset: 0x0082E640
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

	// Token: 0x0601B449 RID: 111689 RVA: 0x008304B0 File Offset: 0x0082E6B0
	protected virtual void OnStop_Implementation()
	{
		TArray<UActorComponent> tarray = base.K2_GetComponentsByClass(UNiagaraComponent.StaticClass());
		for (int i = tarray.Num() - 1; i >= 0; i--)
		{
			base.K2_DestroyComponent(tarray.Get(i));
		}
		base.SetActorTickEnabled(false);
	}

	// Token: 0x0601B44A RID: 111690 RVA: 0x008304F8 File Offset: 0x0082E6F8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveTick_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601B44B RID: 111691 RVA: 0x00830570 File Offset: 0x0082E770
	protected virtual void ReceiveTick_Implementation(float deltaSeconds)
	{
		this.CurrentTime += deltaSeconds;
		if (this.BeamData == null)
		{
			return;
		}
		int num = this.BeamData.TimeLine.Num();
		if (num < 1)
		{
			return;
		}
		while (this.CurrentIndex < num && this.BeamData.TimeLine.Get(this.CurrentIndex) < this.CurrentTime)
		{
			this.CurrentIndex++;
		}
		SVectorArray svectorArray = this.BeamData.PointPositions.Get(this.CurrentIndex);
		if (this.BeamData.TimeLine.Get(this.CurrentIndex) < this.CurrentTime)
		{
			this.SetSpline(1f, svectorArray, svectorArray);
			return;
		}
		if (this.CurrentIndex > 1)
		{
			SVectorArray prevData = this.BeamData.PointPositions.Get(this.CurrentIndex - 1);
			float num2 = this.BeamData.TimeLine.Get(this.CurrentIndex - 1);
			float num3 = this.BeamData.TimeLine.Get(this.CurrentIndex);
			this.SetSpline((this.CurrentTime - num2) / (num3 - num2), prevData, svectorArray);
		}
	}

	// Token: 0x0601B44C RID: 111692 RVA: 0x0083068C File Offset: 0x0082E88C
	private void SpawnHookActorRecord()
	{
		UNiagaraSystem uniagaraSystem = Singleton<ResourceSystem>.Instance.Load<UNiagaraSystem>(this.Path, "js_undefined");
		if (uniagaraSystem == null || !uniagaraSystem.IsValid() || !this.IsValid())
		{
			return;
		}
		UNiagaraComponent uniagaraComponent = (UNiagaraComponent)base.AddComponentByClass(UNiagaraComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName));
		uniagaraComponent.SetAsset(uniagaraSystem, true);
		if (this.BeamData == null)
		{
			base.SetActorTickEnabled(false);
			FVector inValue = UKismetMathLibrary.WD_WorldToLocal(GlobalData.World, new FVectorDouble((double)this.Position0.X, (double)this.Position0.Y, (double)this.Position0.Z));
			uniagaraComponent.SetNiagaraVariableVec3("End", inValue);
			return;
		}
		base.SetActorTickEnabled(true);
		this.SplineComponent = (USplineComponent)base.AddComponentByClass(USplineComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName));
		this.SplineComponent.ClearSplinePoints(true);
		UKuroRenderingRuntimeBPPluginBPLibrary.SetNiagaraSplineComponent(uniagaraComponent, "NewSpline", this.SplineComponent);
	}

	// Token: 0x0601B44D RID: 111693 RVA: 0x0083079C File Offset: 0x0082E99C
	private void SetSpline(float alpha, SVectorArray prevData, SVectorArray nextData)
	{
		if (this.SplineComponent == null)
		{
			return;
		}
		int numberOfSplinePoints = this.SplineComponent.GetNumberOfSplinePoints();
		int num = prevData.Vectors.Num();
		int num2 = nextData.Vectors.Num();
		if (num == 0 || num2 == 0)
		{
			return;
		}
		int num3 = Math.Max(num, num2);
		if (numberOfSplinePoints < num3)
		{
			for (int i = numberOfSplinePoints; i < num3; i++)
			{
				FSplinePoint fsplinePoint = new FSplinePoint((float)i, FVector.ZeroVector, FVector.ZeroVector, FVector.ZeroVector, Rotator.ZeroRotator, FVector.OneVector, ESplinePointType.Linear);
				this.SplineComponent.AddPoint(fsplinePoint, true);
			}
		}
		else if (numberOfSplinePoints > num3)
		{
			for (int j = numberOfSplinePoints - 1; j >= num3; j--)
			{
				this.SplineComponent.RemoveSplinePoint(j, true);
			}
		}
		for (int k = 0; k < num3; k++)
		{
			Vector tmpVector = TsRecordGameplayCue.TmpVector;
			FVectorDouble fvectorDouble = prevData.Vectors.Get(Math.Min(k, num - 1));
			tmpVector.FromUeVector(fvectorDouble);
			Vector tmpVector2 = TsRecordGameplayCue.TmpVector2;
			fvectorDouble = nextData.Vectors.Get(Math.Min(k, num2 - 1));
			tmpVector2.FromUeVector(fvectorDouble);
			Vector.Lerp(TsRecordGameplayCue.TmpVector, TsRecordGameplayCue.TmpVector2, (double)alpha, TsRecordGameplayCue.TmpVector);
			USplineComponent splineComponent = this.SplineComponent;
			int pointIndex = k;
			fvectorDouble = TsRecordGameplayCue.TmpVector.ToUeVector(false);
			splineComponent.D_SetLocationAtSplinePoint(pointIndex, fvectorDouble, ESplineCoordinateSpace.World, true);
		}
	}

	// Token: 0x0601B44E RID: 111694 RVA: 0x008308E6 File Offset: 0x0082EAE6
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsRecordGameplayCue._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Recorder/TsRecordGameplayCue.TsRecordGameplayCue_C");
		}
		return TsRecordGameplayCue._ClassPtr;
	}

	// Token: 0x0601B44F RID: 111695 RVA: 0x0083090C File Offset: 0x0082EB0C
	public TsRecordGameplayCue() : this(BuiltinUtils.AllocNativeUObject(TsRecordGameplayCue.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601B450 RID: 111696 RVA: 0x00830934 File Offset: 0x0082EB34
	public TsRecordGameplayCue(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsRecordGameplayCue.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601B451 RID: 111697 RVA: 0x00830967 File Offset: 0x0082EB67
	protected TsRecordGameplayCue(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601B452 RID: 111698 RVA: 0x00830970 File Offset: 0x0082EB70
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601B453 RID: 111699 RVA: 0x00830978 File Offset: 0x0082EB78
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		this.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601B454 RID: 111700 RVA: 0x00830998 File Offset: 0x0082EB98
	protected virtual void __CPPCALL_OnPlay_Implementation()
	{
		this.OnPlay_Implementation();
	}

	// Token: 0x0601B455 RID: 111701 RVA: 0x008309A0 File Offset: 0x0082EBA0
	protected virtual void __CPPCALL_OnStop_Implementation()
	{
		this.OnStop_Implementation();
	}

	// Token: 0x0601B456 RID: 111702 RVA: 0x008309A8 File Offset: 0x0082EBA8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		this.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0400DE2A RID: 56874
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector = Vector.Create();

	// Token: 0x0400DE2B RID: 56875
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x0400DE2C RID: 56876
	private float CurrentTime;

	// Token: 0x0400DE2D RID: 56877
	private int CurrentIndex;

	// Token: 0x0400DE2E RID: 56878
	[Nullable(2)]
	private USplineComponent SplineComponent;

	// Token: 0x0400DE2F RID: 56879
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Recorder/TsRecordGameplayCue.TsRecordGameplayCue_C";

	// Token: 0x0400DE30 RID: 56880
	private static IntPtr _ClassPtr;

	// Token: 0x0400DE31 RID: 56881
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DE32 RID: 56882
	private static int __PropertyOffset_Path;

	// Token: 0x0400DE33 RID: 56883
	private static int __PropertyOffset_Position0;

	// Token: 0x0400DE34 RID: 56884
	private static int __PropertyOffset_BeamData;
}
