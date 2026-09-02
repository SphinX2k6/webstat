using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.InteractFoliage.Blueprint.MeshActor;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.DandelionInteraction
{
	// Token: 0x02003D4F RID: 15695
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/DandelionInteraction/BP_Big_DandelionInteraction.BP_Big_DandelionInteraction_C")]
	[UnrealStructLayout(1520, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1513)]
	public class BP_Big_DandelionInteraction_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060261AB RID: 156075 RVA: 0x009CE0F5 File Offset: 0x009CC2F5
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Big_DandelionInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/DandelionInteraction/BP_Big_DandelionInteraction.BP_Big_DandelionInteraction_C");
			}
			return BP_Big_DandelionInteraction_C._ClassPtr;
		}

		// Token: 0x060261AC RID: 156076 RVA: 0x009CE11C File Offset: 0x009CC31C
		public BP_Big_DandelionInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_Big_DandelionInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060261AD RID: 156077 RVA: 0x009CE144 File Offset: 0x009CC344
		[NullableContext(1)]
		public BP_Big_DandelionInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Big_DandelionInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700557E RID: 21886
		// (get) Token: 0x060261AE RID: 156078 RVA: 0x009CE178 File Offset: 0x009CC378
		// (set) Token: 0x060261AF RID: 156079 RVA: 0x009CE1B1 File Offset: 0x009CC3B1
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700557F RID: 21887
		// (get) Token: 0x060261B0 RID: 156080 RVA: 0x009CE1D2 File Offset: 0x009CC3D2
		// (set) Token: 0x060261B1 RID: 156081 RVA: 0x009CE1E6 File Offset: 0x009CC3E6
		public unsafe USkeletalMeshComponent SkeletalMeshFoliage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Big_DandelionInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Big_DandelionInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005580 RID: 21888
		// (get) Token: 0x060261B2 RID: 156082 RVA: 0x009CE1FB File Offset: 0x009CC3FB
		// (set) Token: 0x060261B3 RID: 156083 RVA: 0x009CE20F File Offset: 0x009CC40F
		public unsafe UStaticMeshComponent StaticMeshFoliage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Big_DandelionInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Big_DandelionInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005581 RID: 21889
		// (get) Token: 0x060261B4 RID: 156084 RVA: 0x009CE224 File Offset: 0x009CC424
		// (set) Token: 0x060261B5 RID: 156085 RVA: 0x009CE238 File Offset: 0x009CC438
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Big_DandelionInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Big_DandelionInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005582 RID: 21890
		// (get) Token: 0x060261B6 RID: 156086 RVA: 0x009CE24D File Offset: 0x009CC44D
		// (set) Token: 0x060261B7 RID: 156087 RVA: 0x009CE261 File Offset: 0x009CC461
		public unsafe KUROInteractFoliage_C FoliageType
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KUROInteractFoliage_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Big_DandelionInteraction_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Big_DandelionInteraction_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005583 RID: 21891
		// (get) Token: 0x060261B8 RID: 156088 RVA: 0x009CE276 File Offset: 0x009CC476
		// (set) Token: 0x060261B9 RID: 156089 RVA: 0x009CE286 File Offset: 0x009CC486
		public unsafe bool Active
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005584 RID: 21892
		// (get) Token: 0x060261BA RID: 156090 RVA: 0x009CE297 File Offset: 0x009CC497
		// (set) Token: 0x060261BB RID: 156091 RVA: 0x009CE2A7 File Offset: 0x009CC4A7
		public unsafe float TraceRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005585 RID: 21893
		// (get) Token: 0x060261BC RID: 156092 RVA: 0x009CE2B8 File Offset: 0x009CC4B8
		// (set) Token: 0x060261BD RID: 156093 RVA: 0x009CE2CC File Offset: 0x009CC4CC
		public unsafe FTransform CharacterTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005586 RID: 21894
		// (get) Token: 0x060261BE RID: 156094 RVA: 0x009CE2E4 File Offset: 0x009CC4E4
		// (set) Token: 0x060261BF RID: 156095 RVA: 0x009CE31D File Offset: 0x009CC51D
		[Nullable(1)]
		public TArray<float> Primitive_Data
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Primitive_Data) == null)
				{
					result = (this._Primitive_Data = new TArray<float>(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Primitive_Data.CopyAssign(value);
			}
		}

		// Token: 0x17005587 RID: 21895
		// (get) Token: 0x060261C0 RID: 156096 RVA: 0x009CE32B File Offset: 0x009CC52B
		// (set) Token: 0x060261C1 RID: 156097 RVA: 0x009CE33B File Offset: 0x009CC53B
		public unsafe float MinDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005588 RID: 21896
		// (get) Token: 0x060261C2 RID: 156098 RVA: 0x009CE34C File Offset: 0x009CC54C
		// (set) Token: 0x060261C3 RID: 156099 RVA: 0x009CE35C File Offset: 0x009CC55C
		public unsafe float MaxDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005589 RID: 21897
		// (get) Token: 0x060261C4 RID: 156100 RVA: 0x009CE36D File Offset: 0x009CC56D
		// (set) Token: 0x060261C5 RID: 156101 RVA: 0x009CE37D File Offset: 0x009CC57D
		public unsafe float TickTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700558A RID: 21898
		// (get) Token: 0x060261C6 RID: 156102 RVA: 0x009CE38E File Offset: 0x009CC58E
		// (set) Token: 0x060261C7 RID: 156103 RVA: 0x009CE3A2 File Offset: 0x009CC5A2
		public unsafe UNiagaraSystem NiagaraSystem
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Big_DandelionInteraction_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Big_DandelionInteraction_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x1700558B RID: 21899
		// (get) Token: 0x060261C8 RID: 156104 RVA: 0x009CE3B8 File Offset: 0x009CC5B8
		// (set) Token: 0x060261C9 RID: 156105 RVA: 0x009CE3F1 File Offset: 0x009CC5F1
		[Nullable(1)]
		public TArray<FName> ParentSocketNames
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._ParentSocketNames) == null)
				{
					result = (this._ParentSocketNames = new TArray<FName>(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_13, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ParentSocketNames.CopyAssign(value);
			}
		}

		// Token: 0x1700558C RID: 21900
		// (get) Token: 0x060261CA RID: 156106 RVA: 0x009CE3FF File Offset: 0x009CC5FF
		// (set) Token: 0x060261CB RID: 156107 RVA: 0x009CE413 File Offset: 0x009CC613
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700558D RID: 21901
		// (get) Token: 0x060261CC RID: 156108 RVA: 0x009CE428 File Offset: 0x009CC628
		// (set) Token: 0x060261CD RID: 156109 RVA: 0x009CE43C File Offset: 0x009CC63C
		public unsafe FVector WaeponVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700558E RID: 21902
		// (get) Token: 0x060261CE RID: 156110 RVA: 0x009CE451 File Offset: 0x009CC651
		// (set) Token: 0x060261CF RID: 156111 RVA: 0x009CE461 File Offset: 0x009CC661
		public unsafe bool OpenWeaponInteraction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700558F RID: 21903
		// (get) Token: 0x060261D0 RID: 156112 RVA: 0x009CE474 File Offset: 0x009CC674
		// (set) Token: 0x060261D1 RID: 156113 RVA: 0x009CE4AD File Offset: 0x009CC6AD
		[Nullable(1)]
		public TArray<UNiagaraComponent> NiagaraSystemArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UNiagaraComponent> result;
				if ((result = this._NiagaraSystemArray) == null)
				{
					result = (this._NiagaraSystemArray = new TArray<UNiagaraComponent>(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_17, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.NiagaraSystemArray.CopyAssign(value);
			}
		}

		// Token: 0x17005590 RID: 21904
		// (get) Token: 0x060261D2 RID: 156114 RVA: 0x009CE4BB File Offset: 0x009CC6BB
		// (set) Token: 0x060261D3 RID: 156115 RVA: 0x009CE4CB File Offset: 0x009CC6CB
		public unsafe bool NiagaraActive
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Big_DandelionInteraction_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x060261D4 RID: 156116 RVA: 0x009CE4DC File Offset: 0x009CC6DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetNiagaraArray()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Big_DandelionInteraction_C.__SetNiagaraArray_NativeFunctionPtr, null);
		}

		// Token: 0x060261D5 RID: 156117 RVA: 0x009CE4F0 File Offset: 0x009CC6F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateNiagara()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Big_DandelionInteraction_C.__UpdateNiagara_NativeFunctionPtr, null);
		}

		// Token: 0x060261D6 RID: 156118 RVA: 0x009CE504 File Offset: 0x009CC704
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ChangeActiveFoliageNum(float ChangeNum)
		{
			BP_Big_DandelionInteraction_C.__ChangeActiveFoliageNum_FunctionParams* ptr = stackalloc BP_Big_DandelionInteraction_C.__ChangeActiveFoliageNum_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_Big_DandelionInteraction_C.__ChangeActiveFoliageNum_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Big_DandelionInteraction_C.__ChangeActiveFoliageNum_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ChangeNum = ChangeNum;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Big_DandelionInteraction_C.__ChangeActiveFoliageNum_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060261D7 RID: 156119 RVA: 0x009CE54A File Offset: 0x009CC74A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitialData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Big_DandelionInteraction_C.__InitialData_NativeFunctionPtr, null);
		}

		// Token: 0x060261D8 RID: 156120 RVA: 0x009CE55E File Offset: 0x009CC75E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Big_DandelionInteraction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060261D9 RID: 156121 RVA: 0x009CE572 File Offset: 0x009CC772
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Big_DandelionInteraction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060261DA RID: 156122 RVA: 0x009CE587 File Offset: 0x009CC787
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Big_DandelionInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060261DB RID: 156123 RVA: 0x009CE59B File Offset: 0x009CC79B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Big_DandelionInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060261DC RID: 156124 RVA: 0x009CE5B0 File Offset: 0x009CC7B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Big_DandelionInteraction_C.__CustomTick_NativeFunctionPtr, null);
		}

		// Token: 0x060261DD RID: 156125 RVA: 0x009CE5C4 File Offset: 0x009CC7C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Big_DandelionInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Big_DandelionInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Big_DandelionInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Big_DandelionInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Big_DandelionInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060261DE RID: 156126 RVA: 0x009CE60C File Offset: 0x009CC80C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Big_DandelionInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Big_DandelionInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Big_DandelionInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Big_DandelionInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Big_DandelionInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060261DF RID: 156127 RVA: 0x009CE654 File Offset: 0x009CC854
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CallChange(float Weight)
		{
			BP_Big_DandelionInteraction_C.__CallChange_FunctionParams* ptr = stackalloc BP_Big_DandelionInteraction_C.__CallChange_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Big_DandelionInteraction_C.__CallChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Big_DandelionInteraction_C.__CallChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Weight = Weight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Big_DandelionInteraction_C.__CallChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060261E0 RID: 156128 RVA: 0x009CE69C File Offset: 0x009CC89C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Big_DandelionInteraction(int EntryPoint)
		{
			BP_Big_DandelionInteraction_C.__ExecuteUbergraph_BP_Big_DandelionInteraction_FunctionParams* ptr = stackalloc BP_Big_DandelionInteraction_C.__ExecuteUbergraph_BP_Big_DandelionInteraction_FunctionParams[(UIntPtr)447] + 15L / (long)sizeof(BP_Big_DandelionInteraction_C.__ExecuteUbergraph_BP_Big_DandelionInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Big_DandelionInteraction_C.__ExecuteUbergraph_BP_Big_DandelionInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Big_DandelionInteraction_C.__ExecuteUbergraph_BP_Big_DandelionInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060261E1 RID: 156129 RVA: 0x009CE6E6 File Offset: 0x009CC8E6
		protected BP_Big_DandelionInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013BC1 RID: 80833
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/DandelionInteraction/BP_Big_DandelionInteraction.BP_Big_DandelionInteraction_C";

		// Token: 0x04013BC2 RID: 80834
		private static IntPtr _ClassPtr;

		// Token: 0x04013BC3 RID: 80835
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013BC4 RID: 80836
		internal static int __PropertyOffset_0;

		// Token: 0x04013BC5 RID: 80837
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013BC6 RID: 80838
		internal static int __PropertyOffset_1;

		// Token: 0x04013BC7 RID: 80839
		internal static int __PropertyOffset_2;

		// Token: 0x04013BC8 RID: 80840
		internal static int __PropertyOffset_3;

		// Token: 0x04013BC9 RID: 80841
		internal static int __PropertyOffset_4;

		// Token: 0x04013BCA RID: 80842
		internal static int __PropertyOffset_5;

		// Token: 0x04013BCB RID: 80843
		internal static int __PropertyOffset_6;

		// Token: 0x04013BCC RID: 80844
		internal static int __PropertyOffset_7;

		// Token: 0x04013BCD RID: 80845
		internal static int __PropertyOffset_8;

		// Token: 0x04013BCE RID: 80846
		private TArray<float> _Primitive_Data;

		// Token: 0x04013BCF RID: 80847
		internal static int __PropertyOffset_9;

		// Token: 0x04013BD0 RID: 80848
		internal static int __PropertyOffset_10;

		// Token: 0x04013BD1 RID: 80849
		internal static int __PropertyOffset_11;

		// Token: 0x04013BD2 RID: 80850
		internal static int __PropertyOffset_12;

		// Token: 0x04013BD3 RID: 80851
		internal static int __PropertyOffset_13;

		// Token: 0x04013BD4 RID: 80852
		private TArray<FName> _ParentSocketNames;

		// Token: 0x04013BD5 RID: 80853
		internal static int __PropertyOffset_14;

		// Token: 0x04013BD6 RID: 80854
		internal static int __PropertyOffset_15;

		// Token: 0x04013BD7 RID: 80855
		internal static int __PropertyOffset_16;

		// Token: 0x04013BD8 RID: 80856
		internal static int __PropertyOffset_17;

		// Token: 0x04013BD9 RID: 80857
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UNiagaraComponent> _NiagaraSystemArray;

		// Token: 0x04013BDA RID: 80858
		internal static int __PropertyOffset_18;

		// Token: 0x04013BDB RID: 80859
		private static IntPtr __SetNiagaraArray_NativeFunctionPtr;

		// Token: 0x04013BDC RID: 80860
		private static IntPtr __UpdateNiagara_NativeFunctionPtr;

		// Token: 0x04013BDD RID: 80861
		private static IntPtr __ChangeActiveFoliageNum_NativeFunctionPtr;

		// Token: 0x04013BDE RID: 80862
		private static IntPtr __InitialData_NativeFunctionPtr;

		// Token: 0x04013BDF RID: 80863
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013BE0 RID: 80864
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013BE1 RID: 80865
		private static IntPtr __CustomTick_NativeFunctionPtr;

		// Token: 0x04013BE2 RID: 80866
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013BE3 RID: 80867
		private static IntPtr __CallChange_NativeFunctionPtr;

		// Token: 0x04013BE4 RID: 80868
		private static IntPtr __ExecuteUbergraph_BP_Big_DandelionInteraction_NativeFunctionPtr;

		// Token: 0x0200A003 RID: 40963
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ChangeActiveFoliageNum_FunctionParams
		{
			// Token: 0x04032BE2 RID: 207842
			[FieldOffset(0)]
			public float ChangeNum;
		}

		// Token: 0x0200A004 RID: 40964
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032BE3 RID: 207843
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A005 RID: 40965
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __CallChange_FunctionParams
		{
			// Token: 0x04032BE4 RID: 207844
			[FieldOffset(0)]
			public float Weight;
		}

		// Token: 0x0200A006 RID: 40966
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 432)]
		protected ref struct __ExecuteUbergraph_BP_Big_DandelionInteraction_FunctionParams
		{
			// Token: 0x04032BE5 RID: 207845
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
