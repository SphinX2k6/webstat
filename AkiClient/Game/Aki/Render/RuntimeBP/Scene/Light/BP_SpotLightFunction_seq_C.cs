using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A9B RID: 15003
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SpotLightFunction_seq.BP_SpotLightFunction_seq_C")]
	[UnrealStructLayout(1104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1104)]
	public class BP_SpotLightFunction_seq_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601FAB8 RID: 129720 RVA: 0x00917AA8 File Offset: 0x00915CA8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SpotLightFunction_seq_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SpotLightFunction_seq.BP_SpotLightFunction_seq_C");
			}
			return BP_SpotLightFunction_seq_C._ClassPtr;
		}

		// Token: 0x0601FAB9 RID: 129721 RVA: 0x00917ACC File Offset: 0x00915CCC
		public BP_SpotLightFunction_seq_C() : this(BuiltinUtils.AllocNativeUObject(BP_SpotLightFunction_seq_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FABA RID: 129722 RVA: 0x00917AF4 File Offset: 0x00915CF4
		[NullableContext(1)]
		public BP_SpotLightFunction_seq_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SpotLightFunction_seq_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003144 RID: 12612
		// (get) Token: 0x0601FABB RID: 129723 RVA: 0x00917B28 File Offset: 0x00915D28
		// (set) Token: 0x0601FABC RID: 129724 RVA: 0x00917B61 File Offset: 0x00915D61
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003145 RID: 12613
		// (get) Token: 0x0601FABD RID: 129725 RVA: 0x00917B82 File Offset: 0x00915D82
		// (set) Token: 0x0601FABE RID: 129726 RVA: 0x00917B96 File Offset: 0x00915D96
		public unsafe USpotLightComponent SpotLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpotLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpotLightFunction_seq_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpotLightFunction_seq_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003146 RID: 12614
		// (get) Token: 0x0601FABF RID: 129727 RVA: 0x00917BAB File Offset: 0x00915DAB
		// (set) Token: 0x0601FAC0 RID: 129728 RVA: 0x00917BBF File Offset: 0x00915DBF
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpotLightFunction_seq_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpotLightFunction_seq_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003147 RID: 12615
		// (get) Token: 0x0601FAC1 RID: 129729 RVA: 0x00917BD4 File Offset: 0x00915DD4
		// (set) Token: 0x0601FAC2 RID: 129730 RVA: 0x00917BE8 File Offset: 0x00915DE8
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpotLightFunction_seq_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpotLightFunction_seq_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003148 RID: 12616
		// (get) Token: 0x0601FAC3 RID: 129731 RVA: 0x00917BFD File Offset: 0x00915DFD
		// (set) Token: 0x0601FAC4 RID: 129732 RVA: 0x00917C11 File Offset: 0x00915E11
		public unsafe UMaterialInstanceDynamic Material_DY
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpotLightFunction_seq_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpotLightFunction_seq_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003149 RID: 12617
		// (get) Token: 0x0601FAC5 RID: 129733 RVA: 0x00917C26 File Offset: 0x00915E26
		// (set) Token: 0x0601FAC6 RID: 129734 RVA: 0x00917C36 File Offset: 0x00915E36
		public unsafe float UV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700314A RID: 12618
		// (get) Token: 0x0601FAC7 RID: 129735 RVA: 0x00917C47 File Offset: 0x00915E47
		// (set) Token: 0x0601FAC8 RID: 129736 RVA: 0x00917C57 File Offset: 0x00915E57
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700314B RID: 12619
		// (get) Token: 0x0601FAC9 RID: 129737 RVA: 0x00917C68 File Offset: 0x00915E68
		// (set) Token: 0x0601FACA RID: 129738 RVA: 0x00917C78 File Offset: 0x00915E78
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700314C RID: 12620
		// (get) Token: 0x0601FACB RID: 129739 RVA: 0x00917C89 File Offset: 0x00915E89
		// (set) Token: 0x0601FACC RID: 129740 RVA: 0x00917C99 File Offset: 0x00915E99
		public unsafe float Constrast
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700314D RID: 12621
		// (get) Token: 0x0601FACD RID: 129741 RVA: 0x00917CAA File Offset: 0x00915EAA
		// (set) Token: 0x0601FACE RID: 129742 RVA: 0x00917CBA File Offset: 0x00915EBA
		public unsafe float EvolutionaryIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700314E RID: 12622
		// (get) Token: 0x0601FACF RID: 129743 RVA: 0x00917CCB File Offset: 0x00915ECB
		// (set) Token: 0x0601FAD0 RID: 129744 RVA: 0x00917CDB File Offset: 0x00915EDB
		public unsafe float EvolutionarySpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpotLightFunction_seq_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700314F RID: 12623
		// (get) Token: 0x0601FAD1 RID: 129745 RVA: 0x00917CEC File Offset: 0x00915EEC
		// (set) Token: 0x0601FAD2 RID: 129746 RVA: 0x00917D00 File Offset: 0x00915F00
		public unsafe UTexture Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpotLightFunction_seq_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpotLightFunction_seq_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x0601FAD3 RID: 129747 RVA: 0x00917D15 File Offset: 0x00915F15
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SpotLightFunction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpotLightFunction_seq_C.__SpotLightFunction_NativeFunctionPtr, null);
		}

		// Token: 0x0601FAD4 RID: 129748 RVA: 0x00917D29 File Offset: 0x00915F29
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpotLightFunction_seq_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FAD5 RID: 129749 RVA: 0x00917D3D File Offset: 0x00915F3D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpotLightFunction_seq_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FAD6 RID: 129750 RVA: 0x00917D54 File Offset: 0x00915F54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SpotLightFunction_seq_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SpotLightFunction_seq_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SpotLightFunction_seq_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpotLightFunction_seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpotLightFunction_seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FAD7 RID: 129751 RVA: 0x00917D9C File Offset: 0x00915F9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SpotLightFunction_seq_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SpotLightFunction_seq_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SpotLightFunction_seq_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpotLightFunction_seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpotLightFunction_seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FAD8 RID: 129752 RVA: 0x00917DE4 File Offset: 0x00915FE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SpotLightFunction_seq(int EntryPoint)
		{
			BP_SpotLightFunction_seq_C.__ExecuteUbergraph_BP_SpotLightFunction_seq_FunctionParams* ptr = stackalloc BP_SpotLightFunction_seq_C.__ExecuteUbergraph_BP_SpotLightFunction_seq_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_SpotLightFunction_seq_C.__ExecuteUbergraph_BP_SpotLightFunction_seq_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpotLightFunction_seq_C.__ExecuteUbergraph_BP_SpotLightFunction_seq_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpotLightFunction_seq_C.__ExecuteUbergraph_BP_SpotLightFunction_seq_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FAD9 RID: 129753 RVA: 0x00917E2B File Offset: 0x0091602B
		protected BP_SpotLightFunction_seq_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FC01 RID: 64513
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_SpotLightFunction_seq.BP_SpotLightFunction_seq_C";

		// Token: 0x0400FC02 RID: 64514
		private static IntPtr _ClassPtr;

		// Token: 0x0400FC03 RID: 64515
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FC04 RID: 64516
		internal static int __PropertyOffset_0;

		// Token: 0x0400FC05 RID: 64517
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FC06 RID: 64518
		internal static int __PropertyOffset_1;

		// Token: 0x0400FC07 RID: 64519
		internal static int __PropertyOffset_2;

		// Token: 0x0400FC08 RID: 64520
		internal static int __PropertyOffset_3;

		// Token: 0x0400FC09 RID: 64521
		internal static int __PropertyOffset_4;

		// Token: 0x0400FC0A RID: 64522
		internal static int __PropertyOffset_5;

		// Token: 0x0400FC0B RID: 64523
		internal static int __PropertyOffset_6;

		// Token: 0x0400FC0C RID: 64524
		internal static int __PropertyOffset_7;

		// Token: 0x0400FC0D RID: 64525
		internal static int __PropertyOffset_8;

		// Token: 0x0400FC0E RID: 64526
		internal static int __PropertyOffset_9;

		// Token: 0x0400FC0F RID: 64527
		internal static int __PropertyOffset_10;

		// Token: 0x0400FC10 RID: 64528
		internal static int __PropertyOffset_11;

		// Token: 0x0400FC11 RID: 64529
		private static IntPtr __SpotLightFunction_NativeFunctionPtr;

		// Token: 0x0400FC12 RID: 64530
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FC13 RID: 64531
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FC14 RID: 64532
		private static IntPtr __ExecuteUbergraph_BP_SpotLightFunction_seq_NativeFunctionPtr;

		// Token: 0x02009913 RID: 39187
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F72 RID: 204658
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009914 RID: 39188
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_SpotLightFunction_seq_FunctionParams
		{
			// Token: 0x04031F73 RID: 204659
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
