using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Star
{
	// Token: 0x02003CAC RID: 15532
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Star/BP_Star.BP_Star_C")]
	[UnrealStructLayout(1144, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1144)]
	public class BP_Star_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024A05 RID: 150021 RVA: 0x009A333C File Offset: 0x009A153C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Star_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Star/BP_Star.BP_Star_C");
			}
			return BP_Star_C._ClassPtr;
		}

		// Token: 0x06024A06 RID: 150022 RVA: 0x009A3360 File Offset: 0x009A1560
		public BP_Star_C() : this(BuiltinUtils.AllocNativeUObject(BP_Star_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024A07 RID: 150023 RVA: 0x009A3388 File Offset: 0x009A1588
		[NullableContext(1)]
		public BP_Star_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Star_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004D08 RID: 19720
		// (get) Token: 0x06024A08 RID: 150024 RVA: 0x009A33BB File Offset: 0x009A15BB
		// (set) Token: 0x06024A09 RID: 150025 RVA: 0x009A33CF File Offset: 0x009A15CF
		public unsafe UStaticMeshComponent StarLayer3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17004D09 RID: 19721
		// (get) Token: 0x06024A0A RID: 150026 RVA: 0x009A33E4 File Offset: 0x009A15E4
		// (set) Token: 0x06024A0B RID: 150027 RVA: 0x009A33F8 File Offset: 0x009A15F8
		public unsafe UStaticMeshComponent StarLayer2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004D0A RID: 19722
		// (get) Token: 0x06024A0C RID: 150028 RVA: 0x009A340D File Offset: 0x009A160D
		// (set) Token: 0x06024A0D RID: 150029 RVA: 0x009A3421 File Offset: 0x009A1621
		public unsafe UStaticMeshComponent StarLayer1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004D0B RID: 19723
		// (get) Token: 0x06024A0E RID: 150030 RVA: 0x009A3436 File Offset: 0x009A1636
		// (set) Token: 0x06024A0F RID: 150031 RVA: 0x009A344A File Offset: 0x009A164A
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004D0C RID: 19724
		// (get) Token: 0x06024A10 RID: 150032 RVA: 0x009A345F File Offset: 0x009A165F
		// (set) Token: 0x06024A11 RID: 150033 RVA: 0x009A346F File Offset: 0x009A166F
		public unsafe float RotationLayer1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Star_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Star_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004D0D RID: 19725
		// (get) Token: 0x06024A12 RID: 150034 RVA: 0x009A3480 File Offset: 0x009A1680
		// (set) Token: 0x06024A13 RID: 150035 RVA: 0x009A3490 File Offset: 0x009A1690
		public unsafe float RotationLayer2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Star_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Star_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004D0E RID: 19726
		// (get) Token: 0x06024A14 RID: 150036 RVA: 0x009A34A1 File Offset: 0x009A16A1
		// (set) Token: 0x06024A15 RID: 150037 RVA: 0x009A34B1 File Offset: 0x009A16B1
		public unsafe float RotationLayer3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Star_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Star_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004D0F RID: 19727
		// (get) Token: 0x06024A16 RID: 150038 RVA: 0x009A34C2 File Offset: 0x009A16C2
		// (set) Token: 0x06024A17 RID: 150039 RVA: 0x009A34D6 File Offset: 0x009A16D6
		public unsafe FLinearColor Layer1Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Star_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Star_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004D10 RID: 19728
		// (get) Token: 0x06024A18 RID: 150040 RVA: 0x009A34EB File Offset: 0x009A16EB
		// (set) Token: 0x06024A19 RID: 150041 RVA: 0x009A34FF File Offset: 0x009A16FF
		public unsafe FLinearColor Layer2Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Star_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Star_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004D11 RID: 19729
		// (get) Token: 0x06024A1A RID: 150042 RVA: 0x009A3514 File Offset: 0x009A1714
		// (set) Token: 0x06024A1B RID: 150043 RVA: 0x009A3528 File Offset: 0x009A1728
		public unsafe FLinearColor Layer3Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Star_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Star_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004D12 RID: 19730
		// (get) Token: 0x06024A1C RID: 150044 RVA: 0x009A353D File Offset: 0x009A173D
		// (set) Token: 0x06024A1D RID: 150045 RVA: 0x009A3551 File Offset: 0x009A1751
		public unsafe UMaterialInstanceDynamic MID_Layer1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004D13 RID: 19731
		// (get) Token: 0x06024A1E RID: 150046 RVA: 0x009A3566 File Offset: 0x009A1766
		// (set) Token: 0x06024A1F RID: 150047 RVA: 0x009A357A File Offset: 0x009A177A
		public unsafe UMaterialInstanceDynamic MID_Layer2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004D14 RID: 19732
		// (get) Token: 0x06024A20 RID: 150048 RVA: 0x009A358F File Offset: 0x009A178F
		// (set) Token: 0x06024A21 RID: 150049 RVA: 0x009A35A3 File Offset: 0x009A17A3
		public unsafe UMaterialInstanceDynamic MID_Layer3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Star_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x06024A22 RID: 150050 RVA: 0x009A35B8 File Offset: 0x009A17B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Visible(bool Bool)
		{
			BP_Star_C.__Visible_FunctionParams* ptr = stackalloc BP_Star_C.__Visible_FunctionParams[(UIntPtr)18] + 15L / (long)sizeof(BP_Star_C.__Visible_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Star_C.__Visible_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Bool = Bool;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Star_C.__Visible_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024A23 RID: 150051 RVA: 0x009A3600 File Offset: 0x009A1800
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetupData(float RotationLayer1, float RotationLayer2, float RotationLayer3, FLinearColor ColorLayer1, FLinearColor ColorLayer2, FLinearColor ColorLayer3)
		{
			BP_Star_C.__SetupData_FunctionParams* ptr = stackalloc BP_Star_C.__SetupData_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(BP_Star_C.__SetupData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Star_C.__SetupData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RotationLayer1 = RotationLayer1;
			ptr->RotationLayer2 = RotationLayer2;
			ptr->RotationLayer3 = RotationLayer3;
			ptr->ColorLayer1 = ColorLayer1;
			ptr->ColorLayer2 = ColorLayer2;
			ptr->ColorLayer3 = ColorLayer3;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Star_C.__SetupData_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024A24 RID: 150052 RVA: 0x009A366C File Offset: 0x009A186C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RotateStar(float DeltaTime)
		{
			BP_Star_C.__RotateStar_FunctionParams* ptr = stackalloc BP_Star_C.__RotateStar_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Star_C.__RotateStar_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Star_C.__RotateStar_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Star_C.__RotateStar_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024A25 RID: 150053 RVA: 0x009A36B4 File Offset: 0x009A18B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RotateMesh(UStaticMeshComponent Mesh, float RotataionSpeed, float DeltaTime)
		{
			BP_Star_C.__RotateMesh_FunctionParams* ptr = stackalloc BP_Star_C.__RotateMesh_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(BP_Star_C.__RotateMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Star_C.__RotateMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			ptr->RotataionSpeed = RotataionSpeed;
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Star_C.__RotateMesh_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024A26 RID: 150054 RVA: 0x009A371A File Offset: 0x009A191A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Star_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024A27 RID: 150055 RVA: 0x009A372E File Offset: 0x009A192E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Star_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024A28 RID: 150056 RVA: 0x009A3743 File Offset: 0x009A1943
		protected BP_Star_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012C7E RID: 76926
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Star/BP_Star.BP_Star_C";

		// Token: 0x04012C7F RID: 76927
		private static IntPtr _ClassPtr;

		// Token: 0x04012C80 RID: 76928
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012C81 RID: 76929
		internal static int __PropertyOffset_0;

		// Token: 0x04012C82 RID: 76930
		internal static int __PropertyOffset_1;

		// Token: 0x04012C83 RID: 76931
		internal static int __PropertyOffset_2;

		// Token: 0x04012C84 RID: 76932
		internal static int __PropertyOffset_3;

		// Token: 0x04012C85 RID: 76933
		internal static int __PropertyOffset_4;

		// Token: 0x04012C86 RID: 76934
		internal static int __PropertyOffset_5;

		// Token: 0x04012C87 RID: 76935
		internal static int __PropertyOffset_6;

		// Token: 0x04012C88 RID: 76936
		internal static int __PropertyOffset_7;

		// Token: 0x04012C89 RID: 76937
		internal static int __PropertyOffset_8;

		// Token: 0x04012C8A RID: 76938
		internal static int __PropertyOffset_9;

		// Token: 0x04012C8B RID: 76939
		internal static int __PropertyOffset_10;

		// Token: 0x04012C8C RID: 76940
		internal static int __PropertyOffset_11;

		// Token: 0x04012C8D RID: 76941
		internal static int __PropertyOffset_12;

		// Token: 0x04012C8E RID: 76942
		private static IntPtr __Visible_NativeFunctionPtr;

		// Token: 0x04012C8F RID: 76943
		private static IntPtr __SetupData_NativeFunctionPtr;

		// Token: 0x04012C90 RID: 76944
		private static IntPtr __RotateStar_NativeFunctionPtr;

		// Token: 0x04012C91 RID: 76945
		private static IntPtr __RotateMesh_NativeFunctionPtr;

		// Token: 0x04012C92 RID: 76946
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x02009E27 RID: 40487
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3)]
		protected ref struct __Visible_FunctionParams
		{
			// Token: 0x04032873 RID: 206963
			[FieldOffset(0)]
			public bool Bool;
		}

		// Token: 0x02009E28 RID: 40488
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected ref struct __SetupData_FunctionParams
		{
			// Token: 0x04032874 RID: 206964
			[FieldOffset(0)]
			public float RotationLayer1;

			// Token: 0x04032875 RID: 206965
			[FieldOffset(4)]
			public float RotationLayer2;

			// Token: 0x04032876 RID: 206966
			[FieldOffset(8)]
			public float RotationLayer3;

			// Token: 0x04032877 RID: 206967
			[FieldOffset(12)]
			public FLinearColor ColorLayer1;

			// Token: 0x04032878 RID: 206968
			[FieldOffset(28)]
			public FLinearColor ColorLayer2;

			// Token: 0x04032879 RID: 206969
			[FieldOffset(44)]
			public FLinearColor ColorLayer3;
		}

		// Token: 0x02009E29 RID: 40489
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __RotateStar_FunctionParams
		{
			// Token: 0x0403287A RID: 206970
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009E2A RID: 40490
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected ref struct __RotateMesh_FunctionParams
		{
			// Token: 0x0403287B RID: 206971
			[FieldOffset(0)]
			public IntPtr Mesh;

			// Token: 0x0403287C RID: 206972
			[FieldOffset(8)]
			public float RotataionSpeed;

			// Token: 0x0403287D RID: 206973
			[FieldOffset(12)]
			public float DeltaTime;
		}
	}
}
