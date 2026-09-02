using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A96 RID: 14998
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SequenceShine_Seq.BP_SequenceShine_Seq_C")]
	[UnrealStructLayout(1672, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1669)]
	public class BP_SequenceShine_Seq_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F989 RID: 129417 RVA: 0x00915CF3 File Offset: 0x00913EF3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SequenceShine_Seq_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SequenceShine_Seq.BP_SequenceShine_Seq_C");
			}
			return BP_SequenceShine_Seq_C._ClassPtr;
		}

		// Token: 0x0601F98A RID: 129418 RVA: 0x00915D18 File Offset: 0x00913F18
		public BP_SequenceShine_Seq_C() : this(BuiltinUtils.AllocNativeUObject(BP_SequenceShine_Seq_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F98B RID: 129419 RVA: 0x00915D40 File Offset: 0x00913F40
		[NullableContext(1)]
		public BP_SequenceShine_Seq_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SequenceShine_Seq_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170030D0 RID: 12496
		// (get) Token: 0x0601F98C RID: 129420 RVA: 0x00915D74 File Offset: 0x00913F74
		// (set) Token: 0x0601F98D RID: 129421 RVA: 0x00915DAD File Offset: 0x00913FAD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170030D1 RID: 12497
		// (get) Token: 0x0601F98E RID: 129422 RVA: 0x00915DCE File Offset: 0x00913FCE
		// (set) Token: 0x0601F98F RID: 129423 RVA: 0x00915DE2 File Offset: 0x00913FE2
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_Seq_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_Seq_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170030D2 RID: 12498
		// (get) Token: 0x0601F990 RID: 129424 RVA: 0x00915DF7 File Offset: 0x00913FF7
		// (set) Token: 0x0601F991 RID: 129425 RVA: 0x00915E0B File Offset: 0x0091400B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_Seq_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_Seq_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170030D3 RID: 12499
		// (get) Token: 0x0601F992 RID: 129426 RVA: 0x00915E20 File Offset: 0x00914020
		// (set) Token: 0x0601F993 RID: 129427 RVA: 0x00915E34 File Offset: 0x00914034
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_Seq_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_Seq_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170030D4 RID: 12500
		// (get) Token: 0x0601F994 RID: 129428 RVA: 0x00915E4C File Offset: 0x0091404C
		// (set) Token: 0x0601F995 RID: 129429 RVA: 0x00915E85 File Offset: 0x00914085
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
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170030D5 RID: 12501
		// (get) Token: 0x0601F996 RID: 129430 RVA: 0x00915E94 File Offset: 0x00914094
		// (set) Token: 0x0601F997 RID: 129431 RVA: 0x00915ECD File Offset: 0x009140CD
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
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170030D6 RID: 12502
		// (get) Token: 0x0601F998 RID: 129432 RVA: 0x00915EDC File Offset: 0x009140DC
		// (set) Token: 0x0601F999 RID: 129433 RVA: 0x00915F15 File Offset: 0x00914115
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
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x170030D7 RID: 12503
		// (get) Token: 0x0601F99A RID: 129434 RVA: 0x00915F23 File Offset: 0x00914123
		// (set) Token: 0x0601F99B RID: 129435 RVA: 0x00915F37 File Offset: 0x00914137
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_Seq_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_Seq_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170030D8 RID: 12504
		// (get) Token: 0x0601F99C RID: 129436 RVA: 0x00915F4C File Offset: 0x0091414C
		// (set) Token: 0x0601F99D RID: 129437 RVA: 0x00915F5C File Offset: 0x0091415C
		public unsafe float LengthIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170030D9 RID: 12505
		// (get) Token: 0x0601F99E RID: 129438 RVA: 0x00915F6D File Offset: 0x0091416D
		// (set) Token: 0x0601F99F RID: 129439 RVA: 0x00915F7D File Offset: 0x0091417D
		public unsafe float NumSamples
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170030DA RID: 12506
		// (get) Token: 0x0601F9A0 RID: 129440 RVA: 0x00915F8E File Offset: 0x0091418E
		// (set) Token: 0x0601F9A1 RID: 129441 RVA: 0x00915FA2 File Offset: 0x009141A2
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170030DB RID: 12507
		// (get) Token: 0x0601F9A2 RID: 129442 RVA: 0x00915FB7 File Offset: 0x009141B7
		// (set) Token: 0x0601F9A3 RID: 129443 RVA: 0x00915FC7 File Offset: 0x009141C7
		public unsafe float Length
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170030DC RID: 12508
		// (get) Token: 0x0601F9A4 RID: 129444 RVA: 0x00915FD8 File Offset: 0x009141D8
		// (set) Token: 0x0601F9A5 RID: 129445 RVA: 0x00915FE8 File Offset: 0x009141E8
		public unsafe int ToonDepth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170030DD RID: 12509
		// (get) Token: 0x0601F9A6 RID: 129446 RVA: 0x00915FF9 File Offset: 0x009141F9
		// (set) Token: 0x0601F9A7 RID: 129447 RVA: 0x00916009 File Offset: 0x00914209
		public unsafe float CharacterIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170030DE RID: 12510
		// (get) Token: 0x0601F9A8 RID: 129448 RVA: 0x0091601A File Offset: 0x0091421A
		// (set) Token: 0x0601F9A9 RID: 129449 RVA: 0x0091602E File Offset: 0x0091422E
		public unsafe UMaterialInstance Material_DisableStencil
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_Seq_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SequenceShine_Seq_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170030DF RID: 12511
		// (get) Token: 0x0601F9AA RID: 129450 RVA: 0x00916043 File Offset: 0x00914243
		// (set) Token: 0x0601F9AB RID: 129451 RVA: 0x00916053 File Offset: 0x00914253
		public unsafe float ShineIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170030E0 RID: 12512
		// (get) Token: 0x0601F9AC RID: 129452 RVA: 0x00916064 File Offset: 0x00914264
		// (set) Token: 0x0601F9AD RID: 129453 RVA: 0x00916074 File Offset: 0x00914274
		public unsafe bool EnableSimLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170030E1 RID: 12513
		// (get) Token: 0x0601F9AE RID: 129454 RVA: 0x00916085 File Offset: 0x00914285
		// (set) Token: 0x0601F9AF RID: 129455 RVA: 0x00916095 File Offset: 0x00914295
		public unsafe float SimLightUV_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170030E2 RID: 12514
		// (get) Token: 0x0601F9B0 RID: 129456 RVA: 0x009160A6 File Offset: 0x009142A6
		// (set) Token: 0x0601F9B1 RID: 129457 RVA: 0x009160B6 File Offset: 0x009142B6
		public unsafe float SimLightUV_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170030E3 RID: 12515
		// (get) Token: 0x0601F9B2 RID: 129458 RVA: 0x009160C7 File Offset: 0x009142C7
		// (set) Token: 0x0601F9B3 RID: 129459 RVA: 0x009160D7 File Offset: 0x009142D7
		public unsafe float SimLightRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170030E4 RID: 12516
		// (get) Token: 0x0601F9B4 RID: 129460 RVA: 0x009160E8 File Offset: 0x009142E8
		// (set) Token: 0x0601F9B5 RID: 129461 RVA: 0x009160F8 File Offset: 0x009142F8
		public unsafe float SimLightDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170030E5 RID: 12517
		// (get) Token: 0x0601F9B6 RID: 129462 RVA: 0x00916109 File Offset: 0x00914309
		// (set) Token: 0x0601F9B7 RID: 129463 RVA: 0x00916119 File Offset: 0x00914319
		public unsafe float SimLightIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170030E6 RID: 12518
		// (get) Token: 0x0601F9B8 RID: 129464 RVA: 0x0091612A File Offset: 0x0091432A
		// (set) Token: 0x0601F9B9 RID: 129465 RVA: 0x0091613A File Offset: 0x0091433A
		public unsafe bool DebugSimLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SequenceShine_Seq_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F9BA RID: 129466 RVA: 0x0091614B File Offset: 0x0091434B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceShine_Seq_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601F9BB RID: 129467 RVA: 0x0091615F File Offset: 0x0091435F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceShine_Seq_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F9BC RID: 129468 RVA: 0x00916173 File Offset: 0x00914373
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceShine_Seq_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F9BD RID: 129469 RVA: 0x00916188 File Offset: 0x00914388
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceShine_Seq_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F9BE RID: 129470 RVA: 0x0091619C File Offset: 0x0091439C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceShine_Seq_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F9BF RID: 129471 RVA: 0x009161B4 File Offset: 0x009143B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SequenceShine_Seq_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SequenceShine_Seq_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceShine_Seq_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceShine_Seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceShine_Seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F9C0 RID: 129472 RVA: 0x009161FC File Offset: 0x009143FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SequenceShine_Seq_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SequenceShine_Seq_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceShine_Seq_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceShine_Seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceShine_Seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F9C1 RID: 129473 RVA: 0x00916243 File Offset: 0x00914443
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceShine_Seq_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F9C2 RID: 129474 RVA: 0x00916257 File Offset: 0x00914457
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceShine_Seq_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F9C3 RID: 129475 RVA: 0x0091626C File Offset: 0x0091446C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SequenceShine_Seq_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SequenceShine_Seq_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceShine_Seq_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceShine_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SequenceShine_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F9C4 RID: 129476 RVA: 0x009162B4 File Offset: 0x009144B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SequenceShine_Seq_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SequenceShine_Seq_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SequenceShine_Seq_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceShine_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceShine_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F9C5 RID: 129477 RVA: 0x009162FC File Offset: 0x009144FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SequenceShine_Seq(int EntryPoint)
		{
			BP_SequenceShine_Seq_C.__ExecuteUbergraph_BP_SequenceShine_Seq_FunctionParams* ptr = stackalloc BP_SequenceShine_Seq_C.__ExecuteUbergraph_BP_SequenceShine_Seq_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_SequenceShine_Seq_C.__ExecuteUbergraph_BP_SequenceShine_Seq_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SequenceShine_Seq_C.__ExecuteUbergraph_BP_SequenceShine_Seq_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SequenceShine_Seq_C.__ExecuteUbergraph_BP_SequenceShine_Seq_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F9C6 RID: 129478 RVA: 0x00916343 File Offset: 0x00914543
		protected BP_SequenceShine_Seq_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FB51 RID: 64337
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SequenceShine_Seq.BP_SequenceShine_Seq_C";

		// Token: 0x0400FB52 RID: 64338
		private static IntPtr _ClassPtr;

		// Token: 0x0400FB53 RID: 64339
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FB54 RID: 64340
		internal static int __PropertyOffset_0;

		// Token: 0x0400FB55 RID: 64341
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FB56 RID: 64342
		internal static int __PropertyOffset_1;

		// Token: 0x0400FB57 RID: 64343
		internal static int __PropertyOffset_2;

		// Token: 0x0400FB58 RID: 64344
		internal static int __PropertyOffset_3;

		// Token: 0x0400FB59 RID: 64345
		internal static int __PropertyOffset_4;

		// Token: 0x0400FB5A RID: 64346
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400FB5B RID: 64347
		internal static int __PropertyOffset_5;

		// Token: 0x0400FB5C RID: 64348
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400FB5D RID: 64349
		internal static int __PropertyOffset_6;

		// Token: 0x0400FB5E RID: 64350
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400FB5F RID: 64351
		internal static int __PropertyOffset_7;

		// Token: 0x0400FB60 RID: 64352
		internal static int __PropertyOffset_8;

		// Token: 0x0400FB61 RID: 64353
		internal static int __PropertyOffset_9;

		// Token: 0x0400FB62 RID: 64354
		internal static int __PropertyOffset_10;

		// Token: 0x0400FB63 RID: 64355
		internal static int __PropertyOffset_11;

		// Token: 0x0400FB64 RID: 64356
		internal static int __PropertyOffset_12;

		// Token: 0x0400FB65 RID: 64357
		internal static int __PropertyOffset_13;

		// Token: 0x0400FB66 RID: 64358
		internal static int __PropertyOffset_14;

		// Token: 0x0400FB67 RID: 64359
		internal static int __PropertyOffset_15;

		// Token: 0x0400FB68 RID: 64360
		internal static int __PropertyOffset_16;

		// Token: 0x0400FB69 RID: 64361
		internal static int __PropertyOffset_17;

		// Token: 0x0400FB6A RID: 64362
		internal static int __PropertyOffset_18;

		// Token: 0x0400FB6B RID: 64363
		internal static int __PropertyOffset_19;

		// Token: 0x0400FB6C RID: 64364
		internal static int __PropertyOffset_20;

		// Token: 0x0400FB6D RID: 64365
		internal static int __PropertyOffset_21;

		// Token: 0x0400FB6E RID: 64366
		internal static int __PropertyOffset_22;

		// Token: 0x0400FB6F RID: 64367
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400FB70 RID: 64368
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FB71 RID: 64369
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FB72 RID: 64370
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FB73 RID: 64371
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400FB74 RID: 64372
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FB75 RID: 64373
		private static IntPtr __ExecuteUbergraph_BP_SequenceShine_Seq_NativeFunctionPtr;

		// Token: 0x02009905 RID: 39173
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F64 RID: 204644
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009906 RID: 39174
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F65 RID: 204645
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009907 RID: 39175
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __ExecuteUbergraph_BP_SequenceShine_Seq_FunctionParams
		{
			// Token: 0x04031F66 RID: 204646
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
