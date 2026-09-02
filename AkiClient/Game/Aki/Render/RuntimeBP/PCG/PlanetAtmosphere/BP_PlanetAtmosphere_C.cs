using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PlanetAtmosphere
{
	// Token: 0x02003BA3 RID: 15267
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PlanetAtmosphere/BP_PlanetAtmosphere.BP_PlanetAtmosphere_C")]
	[UnrealStructLayout(1136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1132)]
	public class BP_PlanetAtmosphere_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021EFA RID: 139002 RVA: 0x00957B4F File Offset: 0x00955D4F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PlanetAtmosphere_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PlanetAtmosphere/BP_PlanetAtmosphere.BP_PlanetAtmosphere_C");
			}
			return BP_PlanetAtmosphere_C._ClassPtr;
		}

		// Token: 0x06021EFB RID: 139003 RVA: 0x00957B74 File Offset: 0x00955D74
		public BP_PlanetAtmosphere_C() : this(BuiltinUtils.AllocNativeUObject(BP_PlanetAtmosphere_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021EFC RID: 139004 RVA: 0x00957B9C File Offset: 0x00955D9C
		[NullableContext(1)]
		public BP_PlanetAtmosphere_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PlanetAtmosphere_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003DD2 RID: 15826
		// (get) Token: 0x06021EFD RID: 139005 RVA: 0x00957BD0 File Offset: 0x00955DD0
		// (set) Token: 0x06021EFE RID: 139006 RVA: 0x00957C09 File Offset: 0x00955E09
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003DD3 RID: 15827
		// (get) Token: 0x06021EFF RID: 139007 RVA: 0x00957C2A File Offset: 0x00955E2A
		// (set) Token: 0x06021F00 RID: 139008 RVA: 0x00957C3E File Offset: 0x00955E3E
		public unsafe UStaticMeshComponent PlanetAtmosphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlanetAtmosphere_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlanetAtmosphere_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003DD4 RID: 15828
		// (get) Token: 0x06021F01 RID: 139009 RVA: 0x00957C53 File Offset: 0x00955E53
		// (set) Token: 0x06021F02 RID: 139010 RVA: 0x00957C67 File Offset: 0x00955E67
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlanetAtmosphere_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlanetAtmosphere_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003DD5 RID: 15829
		// (get) Token: 0x06021F03 RID: 139011 RVA: 0x00957C7C File Offset: 0x00955E7C
		// (set) Token: 0x06021F04 RID: 139012 RVA: 0x00957C90 File Offset: 0x00955E90
		public unsafe UMaterialInstanceDynamic DMI_TransmitanceLut
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlanetAtmosphere_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlanetAtmosphere_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003DD6 RID: 15830
		// (get) Token: 0x06021F05 RID: 139013 RVA: 0x00957CA5 File Offset: 0x00955EA5
		// (set) Token: 0x06021F06 RID: 139014 RVA: 0x00957CB9 File Offset: 0x00955EB9
		public unsafe UMaterialInstanceDynamic DMI_PlanetAtmosphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlanetAtmosphere_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlanetAtmosphere_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003DD7 RID: 15831
		// (get) Token: 0x06021F07 RID: 139015 RVA: 0x00957CCE File Offset: 0x00955ECE
		// (set) Token: 0x06021F08 RID: 139016 RVA: 0x00957CE2 File Offset: 0x00955EE2
		public unsafe UTexture2D AtmosphereLut
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlanetAtmosphere_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlanetAtmosphere_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003DD8 RID: 15832
		// (get) Token: 0x06021F09 RID: 139017 RVA: 0x00957CF7 File Offset: 0x00955EF7
		// (set) Token: 0x06021F0A RID: 139018 RVA: 0x00957D07 File Offset: 0x00955F07
		public unsafe bool UseCustomLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003DD9 RID: 15833
		// (get) Token: 0x06021F0B RID: 139019 RVA: 0x00957D18 File Offset: 0x00955F18
		// (set) Token: 0x06021F0C RID: 139020 RVA: 0x00957D28 File Offset: 0x00955F28
		public unsafe bool UseFakeSky
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003DDA RID: 15834
		// (get) Token: 0x06021F0D RID: 139021 RVA: 0x00957D39 File Offset: 0x00955F39
		// (set) Token: 0x06021F0E RID: 139022 RVA: 0x00957D4D File Offset: 0x00955F4D
		public unsafe FRotator CustomLightDir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003DDB RID: 15835
		// (get) Token: 0x06021F0F RID: 139023 RVA: 0x00957D62 File Offset: 0x00955F62
		// (set) Token: 0x06021F10 RID: 139024 RVA: 0x00957D72 File Offset: 0x00955F72
		public unsafe float 星球半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003DDC RID: 15836
		// (get) Token: 0x06021F11 RID: 139025 RVA: 0x00957D83 File Offset: 0x00955F83
		// (set) Token: 0x06021F12 RID: 139026 RVA: 0x00957D93 File Offset: 0x00955F93
		public unsafe float 大气厚度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003DDD RID: 15837
		// (get) Token: 0x06021F13 RID: 139027 RVA: 0x00957DA4 File Offset: 0x00955FA4
		// (set) Token: 0x06021F14 RID: 139028 RVA: 0x00957DB4 File Offset: 0x00955FB4
		public unsafe float Density
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003DDE RID: 15838
		// (get) Token: 0x06021F15 RID: 139029 RVA: 0x00957DC5 File Offset: 0x00955FC5
		// (set) Token: 0x06021F16 RID: 139030 RVA: 0x00957DD5 File Offset: 0x00955FD5
		public unsafe float DensityFallOff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003DDF RID: 15839
		// (get) Token: 0x06021F17 RID: 139031 RVA: 0x00957DE6 File Offset: 0x00955FE6
		// (set) Token: 0x06021F18 RID: 139032 RVA: 0x00957DF6 File Offset: 0x00955FF6
		public unsafe float ScatteringScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003DE0 RID: 15840
		// (get) Token: 0x06021F19 RID: 139033 RVA: 0x00957E07 File Offset: 0x00956007
		// (set) Token: 0x06021F1A RID: 139034 RVA: 0x00957E17 File Offset: 0x00956017
		public unsafe float Luminance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003DE1 RID: 15841
		// (get) Token: 0x06021F1B RID: 139035 RVA: 0x00957E28 File Offset: 0x00956028
		// (set) Token: 0x06021F1C RID: 139036 RVA: 0x00957E3C File Offset: 0x0095603C
		public unsafe FVector WaveLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlanetAtmosphere_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x06021F1D RID: 139037 RVA: 0x00957E51 File Offset: 0x00956051
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Lut保存_确定好效果后再点()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlanetAtmosphere_C.__Lut保存_确定好效果后再点_NativeFunctionPtr, null);
		}

		// Token: 0x06021F1E RID: 139038 RVA: 0x00957E65 File Offset: 0x00956065
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Lut烘焙_调整下面参数后都需要点此按钮_()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlanetAtmosphere_C.__Lut烘焙_调整下面参数后都需要点此按钮__NativeFunctionPtr, null);
		}

		// Token: 0x06021F1F RID: 139039 RVA: 0x00957E79 File Offset: 0x00956079
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlanetAtmosphere_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021F20 RID: 139040 RVA: 0x00957E8D File Offset: 0x0095608D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlanetAtmosphere_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021F21 RID: 139041 RVA: 0x00957EA4 File Offset: 0x009560A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PlanetAtmosphere(int EntryPoint)
		{
			BP_PlanetAtmosphere_C.__ExecuteUbergraph_BP_PlanetAtmosphere_FunctionParams* ptr = stackalloc BP_PlanetAtmosphere_C.__ExecuteUbergraph_BP_PlanetAtmosphere_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PlanetAtmosphere_C.__ExecuteUbergraph_BP_PlanetAtmosphere_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlanetAtmosphere_C.__ExecuteUbergraph_BP_PlanetAtmosphere_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlanetAtmosphere_C.__ExecuteUbergraph_BP_PlanetAtmosphere_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021F22 RID: 139042 RVA: 0x00957EEB File Offset: 0x009560EB
		protected BP_PlanetAtmosphere_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401122B RID: 70187
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PlanetAtmosphere/BP_PlanetAtmosphere.BP_PlanetAtmosphere_C";

		// Token: 0x0401122C RID: 70188
		private static IntPtr _ClassPtr;

		// Token: 0x0401122D RID: 70189
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401122E RID: 70190
		internal static int __PropertyOffset_0;

		// Token: 0x0401122F RID: 70191
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011230 RID: 70192
		internal static int __PropertyOffset_1;

		// Token: 0x04011231 RID: 70193
		internal static int __PropertyOffset_2;

		// Token: 0x04011232 RID: 70194
		internal static int __PropertyOffset_3;

		// Token: 0x04011233 RID: 70195
		internal static int __PropertyOffset_4;

		// Token: 0x04011234 RID: 70196
		internal static int __PropertyOffset_5;

		// Token: 0x04011235 RID: 70197
		internal static int __PropertyOffset_6;

		// Token: 0x04011236 RID: 70198
		internal static int __PropertyOffset_7;

		// Token: 0x04011237 RID: 70199
		internal static int __PropertyOffset_8;

		// Token: 0x04011238 RID: 70200
		internal static int __PropertyOffset_9;

		// Token: 0x04011239 RID: 70201
		internal static int __PropertyOffset_10;

		// Token: 0x0401123A RID: 70202
		internal static int __PropertyOffset_11;

		// Token: 0x0401123B RID: 70203
		internal static int __PropertyOffset_12;

		// Token: 0x0401123C RID: 70204
		internal static int __PropertyOffset_13;

		// Token: 0x0401123D RID: 70205
		internal static int __PropertyOffset_14;

		// Token: 0x0401123E RID: 70206
		internal static int __PropertyOffset_15;

		// Token: 0x0401123F RID: 70207
		private static IntPtr __Lut保存_确定好效果后再点_NativeFunctionPtr;

		// Token: 0x04011240 RID: 70208
		private static IntPtr __Lut烘焙_调整下面参数后都需要点此按钮__NativeFunctionPtr;

		// Token: 0x04011241 RID: 70209
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011242 RID: 70210
		private static IntPtr __ExecuteUbergraph_BP_PlanetAtmosphere_NativeFunctionPtr;

		// Token: 0x02009B76 RID: 39798
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_PlanetAtmosphere_FunctionParams
		{
			// Token: 0x04032369 RID: 205673
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
