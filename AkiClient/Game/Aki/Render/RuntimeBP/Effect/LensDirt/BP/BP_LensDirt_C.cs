using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.LensDirt.BP
{
	// Token: 0x02003D40 RID: 15680
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/LensDirt/BP/BP_LensDirt.BP_LensDirt_C")]
	[UnrealStructLayout(1408, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1408)]
	public class BP_LensDirt_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060260DD RID: 155869 RVA: 0x009CCAF2 File Offset: 0x009CACF2
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LensDirt_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/LensDirt/BP/BP_LensDirt.BP_LensDirt_C");
			}
			return BP_LensDirt_C._ClassPtr;
		}

		// Token: 0x060260DE RID: 155870 RVA: 0x009CCB18 File Offset: 0x009CAD18
		public BP_LensDirt_C() : this(BuiltinUtils.AllocNativeUObject(BP_LensDirt_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060260DF RID: 155871 RVA: 0x009CCB40 File Offset: 0x009CAD40
		[NullableContext(1)]
		public BP_LensDirt_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LensDirt_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005541 RID: 21825
		// (get) Token: 0x060260E0 RID: 155872 RVA: 0x009CCB74 File Offset: 0x009CAD74
		// (set) Token: 0x060260E1 RID: 155873 RVA: 0x009CCBAD File Offset: 0x009CADAD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005542 RID: 21826
		// (get) Token: 0x060260E2 RID: 155874 RVA: 0x009CCBCE File Offset: 0x009CADCE
		// (set) Token: 0x060260E3 RID: 155875 RVA: 0x009CCBE2 File Offset: 0x009CADE2
		public unsafe UStaticMeshComponent LensDirt_Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDirt_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDirt_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005543 RID: 21827
		// (get) Token: 0x060260E4 RID: 155876 RVA: 0x009CCBF7 File Offset: 0x009CADF7
		// (set) Token: 0x060260E5 RID: 155877 RVA: 0x009CCC0B File Offset: 0x009CAE0B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDirt_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDirt_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005544 RID: 21828
		// (get) Token: 0x060260E6 RID: 155878 RVA: 0x009CCC20 File Offset: 0x009CAE20
		// (set) Token: 0x060260E7 RID: 155879 RVA: 0x009CCC34 File Offset: 0x009CAE34
		public unsafe UMaterialInstanceDynamic LensDirt_DynamicMaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDirt_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDirt_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005545 RID: 21829
		// (get) Token: 0x060260E8 RID: 155880 RVA: 0x009CCC49 File Offset: 0x009CAE49
		// (set) Token: 0x060260E9 RID: 155881 RVA: 0x009CCC5D File Offset: 0x009CAE5D
		public unsafe UTexture2D LensDirt_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDirt_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDirt_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005546 RID: 21830
		// (get) Token: 0x060260EA RID: 155882 RVA: 0x009CCC72 File Offset: 0x009CAE72
		// (set) Token: 0x060260EB RID: 155883 RVA: 0x009CCC86 File Offset: 0x009CAE86
		public unsafe FVector Dirt_Tilling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005547 RID: 21831
		// (get) Token: 0x060260EC RID: 155884 RVA: 0x009CCC9B File Offset: 0x009CAE9B
		// (set) Token: 0x060260ED RID: 155885 RVA: 0x009CCCAF File Offset: 0x009CAEAF
		public unsafe UTexture2D DirtMask_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDirt_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LensDirt_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17005548 RID: 21832
		// (get) Token: 0x060260EE RID: 155886 RVA: 0x009CCCC4 File Offset: 0x009CAEC4
		// (set) Token: 0x060260EF RID: 155887 RVA: 0x009CCCD8 File Offset: 0x009CAED8
		public unsafe FVector Mask_Tilling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005549 RID: 21833
		// (get) Token: 0x060260F0 RID: 155888 RVA: 0x009CCCED File Offset: 0x009CAEED
		// (set) Token: 0x060260F1 RID: 155889 RVA: 0x009CCCFD File Offset: 0x009CAEFD
		public unsafe float SphereMask_Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700554A RID: 21834
		// (get) Token: 0x060260F2 RID: 155890 RVA: 0x009CCD0E File Offset: 0x009CAF0E
		// (set) Token: 0x060260F3 RID: 155891 RVA: 0x009CCD1E File Offset: 0x009CAF1E
		public unsafe float SphereMask_Range
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700554B RID: 21835
		// (get) Token: 0x060260F4 RID: 155892 RVA: 0x009CCD2F File Offset: 0x009CAF2F
		// (set) Token: 0x060260F5 RID: 155893 RVA: 0x009CCD3F File Offset: 0x009CAF3F
		public unsafe float SphereMask_Power
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700554C RID: 21836
		// (get) Token: 0x060260F6 RID: 155894 RVA: 0x009CCD50 File Offset: 0x009CAF50
		// (set) Token: 0x060260F7 RID: 155895 RVA: 0x009CCD64 File Offset: 0x009CAF64
		public unsafe FColor Dirt_ColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700554D RID: 21837
		// (get) Token: 0x060260F8 RID: 155896 RVA: 0x009CCD79 File Offset: 0x009CAF79
		// (set) Token: 0x060260F9 RID: 155897 RVA: 0x009CCD89 File Offset: 0x009CAF89
		public unsafe float Dirt_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LensDirt_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x060260FA RID: 155898 RVA: 0x009CCD9A File Offset: 0x009CAF9A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDirt_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060260FB RID: 155899 RVA: 0x009CCDAE File Offset: 0x009CAFAE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LensDirt_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060260FC RID: 155900 RVA: 0x009CCDC3 File Offset: 0x009CAFC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDirt_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060260FD RID: 155901 RVA: 0x009CCDD7 File Offset: 0x009CAFD7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LensDirt_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060260FE RID: 155902 RVA: 0x009CCDEC File Offset: 0x009CAFEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LensDirt_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LensDirt_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LensDirt_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensDirt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDirt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060260FF RID: 155903 RVA: 0x009CCE34 File Offset: 0x009CB034
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LensDirt_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LensDirt_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LensDirt_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensDirt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LensDirt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026100 RID: 155904 RVA: 0x009CCE7C File Offset: 0x009CB07C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_LensDirt_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LensDirt_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LensDirt_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensDirt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LensDirt_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026101 RID: 155905 RVA: 0x009CCEC4 File Offset: 0x009CB0C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_LensDirt_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LensDirt_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LensDirt_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensDirt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LensDirt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026102 RID: 155906 RVA: 0x009CCF0C File Offset: 0x009CB10C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LensDirt(int EntryPoint)
		{
			BP_LensDirt_C.__ExecuteUbergraph_BP_LensDirt_FunctionParams* ptr = stackalloc BP_LensDirt_C.__ExecuteUbergraph_BP_LensDirt_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_LensDirt_C.__ExecuteUbergraph_BP_LensDirt_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LensDirt_C.__ExecuteUbergraph_BP_LensDirt_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LensDirt_C.__ExecuteUbergraph_BP_LensDirt_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026103 RID: 155907 RVA: 0x009CCF53 File Offset: 0x009CB153
		protected BP_LensDirt_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013B1E RID: 80670
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/LensDirt/BP/BP_LensDirt.BP_LensDirt_C";

		// Token: 0x04013B1F RID: 80671
		private static IntPtr _ClassPtr;

		// Token: 0x04013B20 RID: 80672
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013B21 RID: 80673
		internal static int __PropertyOffset_0;

		// Token: 0x04013B22 RID: 80674
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013B23 RID: 80675
		internal static int __PropertyOffset_1;

		// Token: 0x04013B24 RID: 80676
		internal static int __PropertyOffset_2;

		// Token: 0x04013B25 RID: 80677
		internal static int __PropertyOffset_3;

		// Token: 0x04013B26 RID: 80678
		internal static int __PropertyOffset_4;

		// Token: 0x04013B27 RID: 80679
		internal static int __PropertyOffset_5;

		// Token: 0x04013B28 RID: 80680
		internal static int __PropertyOffset_6;

		// Token: 0x04013B29 RID: 80681
		internal static int __PropertyOffset_7;

		// Token: 0x04013B2A RID: 80682
		internal static int __PropertyOffset_8;

		// Token: 0x04013B2B RID: 80683
		internal static int __PropertyOffset_9;

		// Token: 0x04013B2C RID: 80684
		internal static int __PropertyOffset_10;

		// Token: 0x04013B2D RID: 80685
		internal static int __PropertyOffset_11;

		// Token: 0x04013B2E RID: 80686
		internal static int __PropertyOffset_12;

		// Token: 0x04013B2F RID: 80687
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013B30 RID: 80688
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013B31 RID: 80689
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013B32 RID: 80690
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04013B33 RID: 80691
		private static IntPtr __ExecuteUbergraph_BP_LensDirt_NativeFunctionPtr;

		// Token: 0x02009FF7 RID: 40951
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032BD2 RID: 207826
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FF8 RID: 40952
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032BD3 RID: 207827
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FF9 RID: 40953
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_LensDirt_FunctionParams
		{
			// Token: 0x04032BD4 RID: 207828
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
