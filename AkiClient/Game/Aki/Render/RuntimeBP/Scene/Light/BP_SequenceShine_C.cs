using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A95 RID: 14997
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SequenceShine.BP_SequenceShine_C")]
	[UnrealStructLayout(1664, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1664)]
	public class BP_SequenceShine_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F94F RID: 129359 RVA: 0x009156D4 File Offset: 0x009138D4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SequenceShine_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SequenceShine.BP_SequenceShine_C");
			}
			return BP_SequenceShine_C._ClassPtr;
		}

		// Token: 0x0601F950 RID: 129360 RVA: 0x009156F8 File Offset: 0x009138F8
		public BP_SequenceShine_C() : this(BuiltinUtils.AllocNativeUObject(BP_SequenceShine_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F951 RID: 129361 RVA: 0x00915720 File Offset: 0x00913920
		[NullableContext(1)]
		public BP_SequenceShine_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SequenceShine_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170030BB RID: 12475
		// (get) Token: 0x0601F952 RID: 129362 RVA: 0x00915754 File Offset: 0x00913954
		// (set) Token: 0x0601F953 RID: 129363 RVA: 0x0091578D File Offset: 0x0091398D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170030BC RID: 12476
		// (get) Token: 0x0601F954 RID: 129364 RVA: 0x009157AE File Offset: 0x009139AE
		// (set) Token: 0x0601F955 RID: 129365 RVA: 0x009157C2 File Offset: 0x009139C2
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170030BD RID: 12477
		// (get) Token: 0x0601F956 RID: 129366 RVA: 0x009157D7 File Offset: 0x009139D7
		// (set) Token: 0x0601F957 RID: 129367 RVA: 0x009157EB File Offset: 0x009139EB
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170030BE RID: 12478
		// (get) Token: 0x0601F958 RID: 129368 RVA: 0x00915800 File Offset: 0x00913A00
		// (set) Token: 0x0601F959 RID: 129369 RVA: 0x00915814 File Offset: 0x00913A14
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170030BF RID: 12479
		// (get) Token: 0x0601F95A RID: 129370 RVA: 0x00915829 File Offset: 0x00913A29
		// (set) Token: 0x0601F95B RID: 129371 RVA: 0x0091583D File Offset: 0x00913A3D
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170030C0 RID: 12480
		// (get) Token: 0x0601F95C RID: 129372 RVA: 0x00915854 File Offset: 0x00913A54
		// (set) Token: 0x0601F95D RID: 129373 RVA: 0x0091588D File Offset: 0x00913A8D
		[Nullable(1)]
		public TMap<FName, float> Scalar_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170030C1 RID: 12481
		// (get) Token: 0x0601F95E RID: 129374 RVA: 0x0091589C File Offset: 0x00913A9C
		// (set) Token: 0x0601F95F RID: 129375 RVA: 0x009158D5 File Offset: 0x00913AD5
		[Nullable(1)]
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170030C2 RID: 12482
		// (get) Token: 0x0601F960 RID: 129376 RVA: 0x009158E4 File Offset: 0x00913AE4
		// (set) Token: 0x0601F961 RID: 129377 RVA: 0x0091591D File Offset: 0x00913B1D
		[Nullable(1)]
		public TMap<FName, UTexture> Texture_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170030C3 RID: 12483
		// (get) Token: 0x0601F962 RID: 129378 RVA: 0x0091592B File Offset: 0x00913B2B
		// (set) Token: 0x0601F963 RID: 129379 RVA: 0x0091593B File Offset: 0x00913B3B
		public unsafe float CenterX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170030C4 RID: 12484
		// (get) Token: 0x0601F964 RID: 129380 RVA: 0x0091594C File Offset: 0x00913B4C
		// (set) Token: 0x0601F965 RID: 129381 RVA: 0x0091595C File Offset: 0x00913B5C
		public unsafe float CenterY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170030C5 RID: 12485
		// (get) Token: 0x0601F966 RID: 129382 RVA: 0x0091596D File Offset: 0x00913B6D
		// (set) Token: 0x0601F967 RID: 129383 RVA: 0x0091597D File Offset: 0x00913B7D
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170030C6 RID: 12486
		// (get) Token: 0x0601F968 RID: 129384 RVA: 0x0091598E File Offset: 0x00913B8E
		// (set) Token: 0x0601F969 RID: 129385 RVA: 0x009159A2 File Offset: 0x00913BA2
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170030C7 RID: 12487
		// (get) Token: 0x0601F96A RID: 129386 RVA: 0x009159B7 File Offset: 0x00913BB7
		// (set) Token: 0x0601F96B RID: 129387 RVA: 0x009159C7 File Offset: 0x00913BC7
		public unsafe float LengthIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170030C8 RID: 12488
		// (get) Token: 0x0601F96C RID: 129388 RVA: 0x009159D8 File Offset: 0x00913BD8
		// (set) Token: 0x0601F96D RID: 129389 RVA: 0x009159E8 File Offset: 0x00913BE8
		public unsafe float NumSamples
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170030C9 RID: 12489
		// (get) Token: 0x0601F96E RID: 129390 RVA: 0x009159F9 File Offset: 0x00913BF9
		// (set) Token: 0x0601F96F RID: 129391 RVA: 0x00915A0D File Offset: 0x00913C0D
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170030CA RID: 12490
		// (get) Token: 0x0601F970 RID: 129392 RVA: 0x00915A22 File Offset: 0x00913C22
		// (set) Token: 0x0601F971 RID: 129393 RVA: 0x00915A32 File Offset: 0x00913C32
		public unsafe float Length
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170030CB RID: 12491
		// (get) Token: 0x0601F972 RID: 129394 RVA: 0x00915A43 File Offset: 0x00913C43
		// (set) Token: 0x0601F973 RID: 129395 RVA: 0x00915A53 File Offset: 0x00913C53
		public unsafe int ToonDepth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170030CC RID: 12492
		// (get) Token: 0x0601F974 RID: 129396 RVA: 0x00915A64 File Offset: 0x00913C64
		// (set) Token: 0x0601F975 RID: 129397 RVA: 0x00915A74 File Offset: 0x00913C74
		public unsafe float TransitionStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170030CD RID: 12493
		// (get) Token: 0x0601F976 RID: 129398 RVA: 0x00915A85 File Offset: 0x00913C85
		// (set) Token: 0x0601F977 RID: 129399 RVA: 0x00915A95 File Offset: 0x00913C95
		public unsafe bool bEnableActorPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x170030CE RID: 12494
		// (get) Token: 0x0601F978 RID: 129400 RVA: 0x00915AA6 File Offset: 0x00913CA6
		// (set) Token: 0x0601F979 RID: 129401 RVA: 0x00915AB6 File Offset: 0x00913CB6
		public unsafe bool DisableStencilTest
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x170030CF RID: 12495
		// (get) Token: 0x0601F97A RID: 129402 RVA: 0x00915AC7 File Offset: 0x00913CC7
		// (set) Token: 0x0601F97B RID: 129403 RVA: 0x00915ADB File Offset: 0x00913CDB
		public unsafe UMaterialInstance Material_DisableStencil
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x0601F97C RID: 129404 RVA: 0x00915AF0 File Offset: 0x00913CF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceShine_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601F97D RID: 129405 RVA: 0x00915B04 File Offset: 0x00913D04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceShine_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F97E RID: 129406 RVA: 0x00915B18 File Offset: 0x00913D18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceShine_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F97F RID: 129407 RVA: 0x00915B2D File Offset: 0x00913D2D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceShine_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F980 RID: 129408 RVA: 0x00915B41 File Offset: 0x00913D41
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceShine_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F981 RID: 129409 RVA: 0x00915B58 File Offset: 0x00913D58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SequenceShine_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SequenceShine_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceShine_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceShine_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceShine_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F982 RID: 129410 RVA: 0x00915BA0 File Offset: 0x00913DA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SequenceShine_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SequenceShine_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceShine_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceShine_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceShine_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F983 RID: 129411 RVA: 0x00915BE7 File Offset: 0x00913DE7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceShine_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F984 RID: 129412 RVA: 0x00915BFB File Offset: 0x00913DFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceShine_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F985 RID: 129413 RVA: 0x00915C10 File Offset: 0x00913E10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SequenceShine_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SequenceShine_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceShine_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceShine_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceShine_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F986 RID: 129414 RVA: 0x00915C58 File Offset: 0x00913E58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SequenceShine_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SequenceShine_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceShine_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceShine_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceShine_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F987 RID: 129415 RVA: 0x00915CA0 File Offset: 0x00913EA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SequenceShine(int EntryPoint)
		{
			BP_SequenceShine_C.__ExecuteUbergraph_BP_SequenceShine_FunctionParams* ptr = stackalloc BP_SequenceShine_C.__ExecuteUbergraph_BP_SequenceShine_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_SequenceShine_C.__ExecuteUbergraph_BP_SequenceShine_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceShine_C.__ExecuteUbergraph_BP_SequenceShine_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceShine_C.__ExecuteUbergraph_BP_SequenceShine_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F988 RID: 129416 RVA: 0x00915CEA File Offset: 0x00913EEA
		protected BP_SequenceShine_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FB2E RID: 64302
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SequenceShine.BP_SequenceShine_C";

		// Token: 0x0400FB2F RID: 64303
		private static IntPtr _ClassPtr;

		// Token: 0x0400FB30 RID: 64304
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FB31 RID: 64305
		internal static int __PropertyOffset_0;

		// Token: 0x0400FB32 RID: 64306
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FB33 RID: 64307
		internal static int __PropertyOffset_1;

		// Token: 0x0400FB34 RID: 64308
		internal static int __PropertyOffset_2;

		// Token: 0x0400FB35 RID: 64309
		internal static int __PropertyOffset_3;

		// Token: 0x0400FB36 RID: 64310
		internal static int __PropertyOffset_4;

		// Token: 0x0400FB37 RID: 64311
		internal static int __PropertyOffset_5;

		// Token: 0x0400FB38 RID: 64312
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400FB39 RID: 64313
		internal static int __PropertyOffset_6;

		// Token: 0x0400FB3A RID: 64314
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400FB3B RID: 64315
		internal static int __PropertyOffset_7;

		// Token: 0x0400FB3C RID: 64316
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400FB3D RID: 64317
		internal static int __PropertyOffset_8;

		// Token: 0x0400FB3E RID: 64318
		internal static int __PropertyOffset_9;

		// Token: 0x0400FB3F RID: 64319
		internal static int __PropertyOffset_10;

		// Token: 0x0400FB40 RID: 64320
		internal static int __PropertyOffset_11;

		// Token: 0x0400FB41 RID: 64321
		internal static int __PropertyOffset_12;

		// Token: 0x0400FB42 RID: 64322
		internal static int __PropertyOffset_13;

		// Token: 0x0400FB43 RID: 64323
		internal static int __PropertyOffset_14;

		// Token: 0x0400FB44 RID: 64324
		internal static int __PropertyOffset_15;

		// Token: 0x0400FB45 RID: 64325
		internal static int __PropertyOffset_16;

		// Token: 0x0400FB46 RID: 64326
		internal static int __PropertyOffset_17;

		// Token: 0x0400FB47 RID: 64327
		internal static int __PropertyOffset_18;

		// Token: 0x0400FB48 RID: 64328
		internal static int __PropertyOffset_19;

		// Token: 0x0400FB49 RID: 64329
		internal static int __PropertyOffset_20;

		// Token: 0x0400FB4A RID: 64330
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400FB4B RID: 64331
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FB4C RID: 64332
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FB4D RID: 64333
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FB4E RID: 64334
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400FB4F RID: 64335
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FB50 RID: 64336
		private static IntPtr __ExecuteUbergraph_BP_SequenceShine_NativeFunctionPtr;

		// Token: 0x02009902 RID: 39170
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F61 RID: 204641
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009903 RID: 39171
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F62 RID: 204642
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009904 RID: 39172
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __ExecuteUbergraph_BP_SequenceShine_FunctionParams
		{
			// Token: 0x04031F63 RID: 204643
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
