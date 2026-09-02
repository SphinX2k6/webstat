using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.BakePlanet.BluePrint
{
	// Token: 0x02003C46 RID: 15430
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/BakePlanet/BluePrint/BP_Baked_Planet.BP_Baked_Planet_C")]
	[UnrealStructLayout(1192, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1185)]
	public class BP_Baked_Planet_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060237F5 RID: 145397 RVA: 0x00983EB0 File Offset: 0x009820B0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Baked_Planet_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/BakePlanet/BluePrint/BP_Baked_Planet.BP_Baked_Planet_C");
			}
			return BP_Baked_Planet_C._ClassPtr;
		}

		// Token: 0x060237F6 RID: 145398 RVA: 0x00983ED4 File Offset: 0x009820D4
		public BP_Baked_Planet_C() : this(BuiltinUtils.AllocNativeUObject(BP_Baked_Planet_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060237F7 RID: 145399 RVA: 0x00983EFC File Offset: 0x009820FC
		[NullableContext(1)]
		public BP_Baked_Planet_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Baked_Planet_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170046BE RID: 18110
		// (get) Token: 0x060237F8 RID: 145400 RVA: 0x00983F30 File Offset: 0x00982130
		// (set) Token: 0x060237F9 RID: 145401 RVA: 0x00983F69 File Offset: 0x00982169
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170046BF RID: 18111
		// (get) Token: 0x060237FA RID: 145402 RVA: 0x00983F8A File Offset: 0x0098218A
		// (set) Token: 0x060237FB RID: 145403 RVA: 0x00983F9E File Offset: 0x0098219E
		public unsafe UStaticMeshComponent Atmosphere_Simple
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170046C0 RID: 18112
		// (get) Token: 0x060237FC RID: 145404 RVA: 0x00983FB3 File Offset: 0x009821B3
		// (set) Token: 0x060237FD RID: 145405 RVA: 0x00983FC7 File Offset: 0x009821C7
		public unsafe UStaticMeshComponent Planet_Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170046C1 RID: 18113
		// (get) Token: 0x060237FE RID: 145406 RVA: 0x00983FDC File Offset: 0x009821DC
		// (set) Token: 0x060237FF RID: 145407 RVA: 0x00983FF0 File Offset: 0x009821F0
		public unsafe UStaticMeshComponent root
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170046C2 RID: 18114
		// (get) Token: 0x06023800 RID: 145408 RVA: 0x00984005 File Offset: 0x00982205
		// (set) Token: 0x06023801 RID: 145409 RVA: 0x00984015 File Offset: 0x00982215
		public unsafe bool UseCustomLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x170046C3 RID: 18115
		// (get) Token: 0x06023802 RID: 145410 RVA: 0x00984026 File Offset: 0x00982226
		// (set) Token: 0x06023803 RID: 145411 RVA: 0x0098403A File Offset: 0x0098223A
		public unsafe FRotator CustomLightDir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170046C4 RID: 18116
		// (get) Token: 0x06023804 RID: 145412 RVA: 0x0098404F File Offset: 0x0098224F
		// (set) Token: 0x06023805 RID: 145413 RVA: 0x00984063 File Offset: 0x00982263
		public unsafe UMaterialInstanceDynamic DMI_Atmosphere_Simple
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170046C5 RID: 18117
		// (get) Token: 0x06023806 RID: 145414 RVA: 0x00984078 File Offset: 0x00982278
		// (set) Token: 0x06023807 RID: 145415 RVA: 0x0098408C File Offset: 0x0098228C
		public unsafe UMaterialInstanceDynamic DMI_Atmosphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170046C6 RID: 18118
		// (get) Token: 0x06023808 RID: 145416 RVA: 0x009840A1 File Offset: 0x009822A1
		// (set) Token: 0x06023809 RID: 145417 RVA: 0x009840B5 File Offset: 0x009822B5
		public unsafe UMaterialInstanceDynamic DMI_Planet
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170046C7 RID: 18119
		// (get) Token: 0x0602380A RID: 145418 RVA: 0x009840CA File Offset: 0x009822CA
		// (set) Token: 0x0602380B RID: 145419 RVA: 0x009840DE File Offset: 0x009822DE
		public unsafe UMaterialInstanceDynamic DMI_Clouds
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170046C8 RID: 18120
		// (get) Token: 0x0602380C RID: 145420 RVA: 0x009840F3 File Offset: 0x009822F3
		// (set) Token: 0x0602380D RID: 145421 RVA: 0x00984107 File Offset: 0x00982307
		public unsafe UMaterialInterface Planet_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_Planet_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170046C9 RID: 18121
		// (get) Token: 0x0602380E RID: 145422 RVA: 0x0098411C File Offset: 0x0098231C
		// (set) Token: 0x0602380F RID: 145423 RVA: 0x0098412C File Offset: 0x0098232C
		public unsafe float PlanetRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170046CA RID: 18122
		// (get) Token: 0x06023810 RID: 145424 RVA: 0x0098413D File Offset: 0x0098233D
		// (set) Token: 0x06023811 RID: 145425 RVA: 0x0098414D File Offset: 0x0098234D
		public unsafe bool Simple_Atmosphere_Enabled
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170046CB RID: 18123
		// (get) Token: 0x06023812 RID: 145426 RVA: 0x0098415E File Offset: 0x0098235E
		// (set) Token: 0x06023813 RID: 145427 RVA: 0x0098416E File Offset: 0x0098236E
		public unsafe float Direct_Atmosphere_Brightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170046CC RID: 18124
		// (get) Token: 0x06023814 RID: 145428 RVA: 0x0098417F File Offset: 0x0098237F
		// (set) Token: 0x06023815 RID: 145429 RVA: 0x0098418F File Offset: 0x0098238F
		public unsafe float Edge_Atmosphere_Brightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170046CD RID: 18125
		// (get) Token: 0x06023816 RID: 145430 RVA: 0x009841A0 File Offset: 0x009823A0
		// (set) Token: 0x06023817 RID: 145431 RVA: 0x009841B0 File Offset: 0x009823B0
		public unsafe float Global_Brightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170046CE RID: 18126
		// (get) Token: 0x06023818 RID: 145432 RVA: 0x009841C1 File Offset: 0x009823C1
		// (set) Token: 0x06023819 RID: 145433 RVA: 0x009841D1 File Offset: 0x009823D1
		public unsafe float Fake_Day_Night_Transition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170046CF RID: 18127
		// (get) Token: 0x0602381A RID: 145434 RVA: 0x009841E2 File Offset: 0x009823E2
		// (set) Token: 0x0602381B RID: 145435 RVA: 0x009841F2 File Offset: 0x009823F2
		public unsafe float Atmosphere_Power
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170046D0 RID: 18128
		// (get) Token: 0x0602381C RID: 145436 RVA: 0x00984203 File Offset: 0x00982403
		// (set) Token: 0x0602381D RID: 145437 RVA: 0x00984213 File Offset: 0x00982413
		public unsafe float Fake_Scattering
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170046D1 RID: 18129
		// (get) Token: 0x0602381E RID: 145438 RVA: 0x00984224 File Offset: 0x00982424
		// (set) Token: 0x0602381F RID: 145439 RVA: 0x00984238 File Offset: 0x00982438
		public unsafe FLinearColor Simple_Atmosphere_Day_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170046D2 RID: 18130
		// (get) Token: 0x06023820 RID: 145440 RVA: 0x0098424D File Offset: 0x0098244D
		// (set) Token: 0x06023821 RID: 145441 RVA: 0x00984261 File Offset: 0x00982461
		public unsafe FLinearColor Simple_Atmosphere_Night_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170046D3 RID: 18131
		// (get) Token: 0x06023822 RID: 145442 RVA: 0x00984276 File Offset: 0x00982476
		// (set) Token: 0x06023823 RID: 145443 RVA: 0x00984286 File Offset: 0x00982486
		public unsafe bool Refresh_Blueprint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_Planet_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x06023824 RID: 145444 RVA: 0x00984297 File Offset: 0x00982497
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Baked_Planet_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023825 RID: 145445 RVA: 0x009842AB File Offset: 0x009824AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Baked_Planet_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023826 RID: 145446 RVA: 0x009842C0 File Offset: 0x009824C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Baked_Planet_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023827 RID: 145447 RVA: 0x009842D4 File Offset: 0x009824D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Baked_Planet_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023828 RID: 145448 RVA: 0x009842EC File Offset: 0x009824EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Baked_Planet(int EntryPoint)
		{
			BP_Baked_Planet_C.__ExecuteUbergraph_BP_Baked_Planet_FunctionParams* ptr = stackalloc BP_Baked_Planet_C.__ExecuteUbergraph_BP_Baked_Planet_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Baked_Planet_C.__ExecuteUbergraph_BP_Baked_Planet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Baked_Planet_C.__ExecuteUbergraph_BP_Baked_Planet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Baked_Planet_C.__ExecuteUbergraph_BP_Baked_Planet_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023829 RID: 145449 RVA: 0x00984333 File Offset: 0x00982533
		protected BP_Baked_Planet_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401212E RID: 74030
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/BakePlanet/BluePrint/BP_Baked_Planet.BP_Baked_Planet_C";

		// Token: 0x0401212F RID: 74031
		private static IntPtr _ClassPtr;

		// Token: 0x04012130 RID: 74032
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012131 RID: 74033
		internal static int __PropertyOffset_0;

		// Token: 0x04012132 RID: 74034
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012133 RID: 74035
		internal static int __PropertyOffset_1;

		// Token: 0x04012134 RID: 74036
		internal static int __PropertyOffset_2;

		// Token: 0x04012135 RID: 74037
		internal static int __PropertyOffset_3;

		// Token: 0x04012136 RID: 74038
		internal static int __PropertyOffset_4;

		// Token: 0x04012137 RID: 74039
		internal static int __PropertyOffset_5;

		// Token: 0x04012138 RID: 74040
		internal static int __PropertyOffset_6;

		// Token: 0x04012139 RID: 74041
		internal static int __PropertyOffset_7;

		// Token: 0x0401213A RID: 74042
		internal static int __PropertyOffset_8;

		// Token: 0x0401213B RID: 74043
		internal static int __PropertyOffset_9;

		// Token: 0x0401213C RID: 74044
		internal static int __PropertyOffset_10;

		// Token: 0x0401213D RID: 74045
		internal static int __PropertyOffset_11;

		// Token: 0x0401213E RID: 74046
		internal static int __PropertyOffset_12;

		// Token: 0x0401213F RID: 74047
		internal static int __PropertyOffset_13;

		// Token: 0x04012140 RID: 74048
		internal static int __PropertyOffset_14;

		// Token: 0x04012141 RID: 74049
		internal static int __PropertyOffset_15;

		// Token: 0x04012142 RID: 74050
		internal static int __PropertyOffset_16;

		// Token: 0x04012143 RID: 74051
		internal static int __PropertyOffset_17;

		// Token: 0x04012144 RID: 74052
		internal static int __PropertyOffset_18;

		// Token: 0x04012145 RID: 74053
		internal static int __PropertyOffset_19;

		// Token: 0x04012146 RID: 74054
		internal static int __PropertyOffset_20;

		// Token: 0x04012147 RID: 74055
		internal static int __PropertyOffset_21;

		// Token: 0x04012148 RID: 74056
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012149 RID: 74057
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401214A RID: 74058
		private static IntPtr __ExecuteUbergraph_BP_Baked_Planet_NativeFunctionPtr;

		// Token: 0x02009CF3 RID: 40179
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_Baked_Planet_FunctionParams
		{
			// Token: 0x04032693 RID: 206483
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
