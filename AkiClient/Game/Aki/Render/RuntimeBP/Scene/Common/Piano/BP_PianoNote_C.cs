using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.Piano
{
	// Token: 0x02003AE5 RID: 15077
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_PianoNote.BP_PianoNote_C")]
	[UnrealStructLayout(1176, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1176)]
	public class BP_PianoNote_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020588 RID: 132488 RVA: 0x009294D7 File Offset: 0x009276D7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PianoNote_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_PianoNote.BP_PianoNote_C");
			}
			return BP_PianoNote_C._ClassPtr;
		}

		// Token: 0x06020589 RID: 132489 RVA: 0x009294FC File Offset: 0x009276FC
		public BP_PianoNote_C() : this(BuiltinUtils.AllocNativeUObject(BP_PianoNote_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602058A RID: 132490 RVA: 0x00929524 File Offset: 0x00927724
		[NullableContext(1)]
		public BP_PianoNote_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PianoNote_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700352A RID: 13610
		// (get) Token: 0x0602058B RID: 132491 RVA: 0x00929558 File Offset: 0x00927758
		// (set) Token: 0x0602058C RID: 132492 RVA: 0x00929591 File Offset: 0x00927791
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PianoNote_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PianoNote_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700352B RID: 13611
		// (get) Token: 0x0602058D RID: 132493 RVA: 0x009295B2 File Offset: 0x009277B2
		// (set) Token: 0x0602058E RID: 132494 RVA: 0x009295C6 File Offset: 0x009277C6
		public unsafe USceneComponent Effect_Slot_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700352C RID: 13612
		// (get) Token: 0x0602058F RID: 132495 RVA: 0x009295DB File Offset: 0x009277DB
		// (set) Token: 0x06020590 RID: 132496 RVA: 0x009295EF File Offset: 0x009277EF
		public unsafe USceneComponent Effect_Slot_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700352D RID: 13613
		// (get) Token: 0x06020591 RID: 132497 RVA: 0x00929604 File Offset: 0x00927804
		// (set) Token: 0x06020592 RID: 132498 RVA: 0x00929618 File Offset: 0x00927818
		public unsafe USceneComponent Effect_Slot_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700352E RID: 13614
		// (get) Token: 0x06020593 RID: 132499 RVA: 0x0092962D File Offset: 0x0092782D
		// (set) Token: 0x06020594 RID: 132500 RVA: 0x00929641 File Offset: 0x00927841
		public unsafe USceneComponent Effect_Slot_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700352F RID: 13615
		// (get) Token: 0x06020595 RID: 132501 RVA: 0x00929656 File Offset: 0x00927856
		// (set) Token: 0x06020596 RID: 132502 RVA: 0x0092966A File Offset: 0x0092786A
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003530 RID: 13616
		// (get) Token: 0x06020597 RID: 132503 RVA: 0x0092967F File Offset: 0x0092787F
		// (set) Token: 0x06020598 RID: 132504 RVA: 0x00929693 File Offset: 0x00927893
		public unsafe FLinearColor Active_Material_Rim_Light_Color_A888AF6A45124F81A06A9CB54FC79F6B
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoNote_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoNote_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003531 RID: 13617
		// (get) Token: 0x06020599 RID: 132505 RVA: 0x009296A8 File Offset: 0x009278A8
		// (set) Token: 0x0602059A RID: 132506 RVA: 0x009296B8 File Offset: 0x009278B8
		public unsafe float Active_Material_Rim_Power_A888AF6A45124F81A06A9CB54FC79F6B
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoNote_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoNote_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003532 RID: 13618
		// (get) Token: 0x0602059B RID: 132507 RVA: 0x009296C9 File Offset: 0x009278C9
		// (set) Token: 0x0602059C RID: 132508 RVA: 0x009296DD File Offset: 0x009278DD
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Active_Material__Direction_A888AF6A45124F81A06A9CB54FC79F6B
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoNote_C.__PropertyOffset_8);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoNote_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003533 RID: 13619
		// (get) Token: 0x0602059D RID: 132509 RVA: 0x009296F2 File Offset: 0x009278F2
		// (set) Token: 0x0602059E RID: 132510 RVA: 0x00929706 File Offset: 0x00927906
		public unsafe UTimelineComponent Active_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003534 RID: 13620
		// (get) Token: 0x0602059F RID: 132511 RVA: 0x0092971B File Offset: 0x0092791B
		// (set) Token: 0x060205A0 RID: 132512 RVA: 0x0092972F File Offset: 0x0092792F
		public unsafe USceneComponent RootSceneComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003535 RID: 13621
		// (get) Token: 0x060205A1 RID: 132513 RVA: 0x00929744 File Offset: 0x00927944
		// (set) Token: 0x060205A2 RID: 132514 RVA: 0x00929758 File Offset: 0x00927958
		public unsafe UKuroMaterialControllerComponent MaterialController
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroMaterialControllerComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003536 RID: 13622
		// (get) Token: 0x060205A3 RID: 132515 RVA: 0x0092976D File Offset: 0x0092796D
		// (set) Token: 0x060205A4 RID: 132516 RVA: 0x0092977D File Offset: 0x0092797D
		public unsafe int TriggerCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoNote_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoNote_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003537 RID: 13623
		// (get) Token: 0x060205A5 RID: 132517 RVA: 0x0092978E File Offset: 0x0092798E
		// (set) Token: 0x060205A6 RID: 132518 RVA: 0x0092979E File Offset: 0x0092799E
		public unsafe bool IsTriggerd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoNote_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoNote_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003538 RID: 13624
		// (get) Token: 0x060205A7 RID: 132519 RVA: 0x009297B0 File Offset: 0x009279B0
		// (set) Token: 0x060205A8 RID: 132520 RVA: 0x009297E9 File Offset: 0x009279E9
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> MaterialInstanceArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._MaterialInstanceArray) == null)
				{
					result = (this._MaterialInstanceArray = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_PianoNote_C.__PropertyOffset_14, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstanceArray.CopyAssign(value);
			}
		}

		// Token: 0x17003539 RID: 13625
		// (get) Token: 0x060205A9 RID: 132521 RVA: 0x009297F7 File Offset: 0x009279F7
		// (set) Token: 0x060205AA RID: 132522 RVA: 0x0092980B File Offset: 0x00927A0B
		public unsafe UObject ActiveEffectDA_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x1700353A RID: 13626
		// (get) Token: 0x060205AB RID: 132523 RVA: 0x00929820 File Offset: 0x00927A20
		// (set) Token: 0x060205AC RID: 132524 RVA: 0x00929834 File Offset: 0x00927A34
		public unsafe UObject ActiveEffectDA_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700353B RID: 13627
		// (get) Token: 0x060205AD RID: 132525 RVA: 0x00929849 File Offset: 0x00927A49
		// (set) Token: 0x060205AE RID: 132526 RVA: 0x0092985D File Offset: 0x00927A5D
		public unsafe UObject ActiveEffectDA_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoNote_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x060205AF RID: 132527 RVA: 0x00929872 File Offset: 0x00927A72
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AddTriggerCount()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoNote_C.__AddTriggerCount_NativeFunctionPtr, null);
		}

		// Token: 0x060205B0 RID: 132528 RVA: 0x00929886 File Offset: 0x00927A86
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Active_Material__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoNote_C.__Active_Material__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x060205B1 RID: 132529 RVA: 0x0092989A File Offset: 0x00927A9A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Active_Material__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoNote_C.__Active_Material__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x060205B2 RID: 132530 RVA: 0x009298AE File Offset: 0x00927AAE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoNote_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060205B3 RID: 132531 RVA: 0x009298C2 File Offset: 0x00927AC2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PianoNote_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060205B4 RID: 132532 RVA: 0x009298D8 File Offset: 0x00927AD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PianoNote(int EntryPoint)
		{
			BP_PianoNote_C.__ExecuteUbergraph_BP_PianoNote_FunctionParams* ptr = stackalloc BP_PianoNote_C.__ExecuteUbergraph_BP_PianoNote_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_PianoNote_C.__ExecuteUbergraph_BP_PianoNote_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PianoNote_C.__ExecuteUbergraph_BP_PianoNote_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PianoNote_C.__ExecuteUbergraph_BP_PianoNote_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060205B5 RID: 132533 RVA: 0x0092991F File Offset: 0x00927B1F
		protected BP_PianoNote_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010254 RID: 66132
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_PianoNote.BP_PianoNote_C";

		// Token: 0x04010255 RID: 66133
		private static IntPtr _ClassPtr;

		// Token: 0x04010256 RID: 66134
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010257 RID: 66135
		internal static int __PropertyOffset_0;

		// Token: 0x04010258 RID: 66136
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010259 RID: 66137
		internal static int __PropertyOffset_1;

		// Token: 0x0401025A RID: 66138
		internal static int __PropertyOffset_2;

		// Token: 0x0401025B RID: 66139
		internal static int __PropertyOffset_3;

		// Token: 0x0401025C RID: 66140
		internal static int __PropertyOffset_4;

		// Token: 0x0401025D RID: 66141
		internal static int __PropertyOffset_5;

		// Token: 0x0401025E RID: 66142
		internal static int __PropertyOffset_6;

		// Token: 0x0401025F RID: 66143
		internal static int __PropertyOffset_7;

		// Token: 0x04010260 RID: 66144
		internal static int __PropertyOffset_8;

		// Token: 0x04010261 RID: 66145
		internal static int __PropertyOffset_9;

		// Token: 0x04010262 RID: 66146
		internal static int __PropertyOffset_10;

		// Token: 0x04010263 RID: 66147
		internal static int __PropertyOffset_11;

		// Token: 0x04010264 RID: 66148
		internal static int __PropertyOffset_12;

		// Token: 0x04010265 RID: 66149
		internal static int __PropertyOffset_13;

		// Token: 0x04010266 RID: 66150
		internal static int __PropertyOffset_14;

		// Token: 0x04010267 RID: 66151
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _MaterialInstanceArray;

		// Token: 0x04010268 RID: 66152
		internal static int __PropertyOffset_15;

		// Token: 0x04010269 RID: 66153
		internal static int __PropertyOffset_16;

		// Token: 0x0401026A RID: 66154
		internal static int __PropertyOffset_17;

		// Token: 0x0401026B RID: 66155
		private static IntPtr __AddTriggerCount_NativeFunctionPtr;

		// Token: 0x0401026C RID: 66156
		private static IntPtr __Active_Material__FinishedFunc_NativeFunctionPtr;

		// Token: 0x0401026D RID: 66157
		private static IntPtr __Active_Material__UpdateFunc_NativeFunctionPtr;

		// Token: 0x0401026E RID: 66158
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401026F RID: 66159
		private static IntPtr __ExecuteUbergraph_BP_PianoNote_NativeFunctionPtr;

		// Token: 0x0200999A RID: 39322
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ExecuteUbergraph_BP_PianoNote_FunctionParams
		{
			// Token: 0x0403202A RID: 204842
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
