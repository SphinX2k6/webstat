using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003AA5 RID: 15013
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricLightTri.BP_VolumetricLightTri_C")]
	[UnrealStructLayout(1136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1132)]
	public class BP_VolumetricLightTri_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601FE0E RID: 130574 RVA: 0x0091C96C File Offset: 0x0091AB6C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricLightTri_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricLightTri.BP_VolumetricLightTri_C");
			}
			return BP_VolumetricLightTri_C._ClassPtr;
		}

		// Token: 0x0601FE0F RID: 130575 RVA: 0x0091C990 File Offset: 0x0091AB90
		public BP_VolumetricLightTri_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricLightTri_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FE10 RID: 130576 RVA: 0x0091C9B8 File Offset: 0x0091ABB8
		[NullableContext(1)]
		public BP_VolumetricLightTri_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricLightTri_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170032A5 RID: 12965
		// (get) Token: 0x0601FE11 RID: 130577 RVA: 0x0091C9EB File Offset: 0x0091ABEB
		// (set) Token: 0x0601FE12 RID: 130578 RVA: 0x0091C9FF File Offset: 0x0091ABFF
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightTri_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightTri_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170032A6 RID: 12966
		// (get) Token: 0x0601FE13 RID: 130579 RVA: 0x0091CA14 File Offset: 0x0091AC14
		// (set) Token: 0x0601FE14 RID: 130580 RVA: 0x0091CA28 File Offset: 0x0091AC28
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightTri_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightTri_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170032A7 RID: 12967
		// (get) Token: 0x0601FE15 RID: 130581 RVA: 0x0091CA3D File Offset: 0x0091AC3D
		// (set) Token: 0x0601FE16 RID: 130582 RVA: 0x0091CA51 File Offset: 0x0091AC51
		public unsafe UStaticMesh StaticMeshTri
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightTri_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightTri_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170032A8 RID: 12968
		// (get) Token: 0x0601FE17 RID: 130583 RVA: 0x0091CA66 File Offset: 0x0091AC66
		// (set) Token: 0x0601FE18 RID: 130584 RVA: 0x0091CA76 File Offset: 0x0091AC76
		public unsafe bool IsReverseCulling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170032A9 RID: 12969
		// (get) Token: 0x0601FE19 RID: 130585 RVA: 0x0091CA87 File Offset: 0x0091AC87
		// (set) Token: 0x0601FE1A RID: 130586 RVA: 0x0091CA9B File Offset: 0x0091AC9B
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightTri_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricLightTri_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170032AA RID: 12970
		// (get) Token: 0x0601FE1B RID: 130587 RVA: 0x0091CAB0 File Offset: 0x0091ACB0
		// (set) Token: 0x0601FE1C RID: 130588 RVA: 0x0091CAC0 File Offset: 0x0091ACC0
		public unsafe float FogInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170032AB RID: 12971
		// (get) Token: 0x0601FE1D RID: 130589 RVA: 0x0091CAD1 File Offset: 0x0091ACD1
		// (set) Token: 0x0601FE1E RID: 130590 RVA: 0x0091CAE5 File Offset: 0x0091ACE5
		public unsafe FLinearColor InsideColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170032AC RID: 12972
		// (get) Token: 0x0601FE1F RID: 130591 RVA: 0x0091CAFA File Offset: 0x0091ACFA
		// (set) Token: 0x0601FE20 RID: 130592 RVA: 0x0091CB0E File Offset: 0x0091AD0E
		public unsafe FLinearColor OutsideColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170032AD RID: 12973
		// (get) Token: 0x0601FE21 RID: 130593 RVA: 0x0091CB23 File Offset: 0x0091AD23
		// (set) Token: 0x0601FE22 RID: 130594 RVA: 0x0091CB33 File Offset: 0x0091AD33
		public unsafe float LightStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170032AE RID: 12974
		// (get) Token: 0x0601FE23 RID: 130595 RVA: 0x0091CB44 File Offset: 0x0091AD44
		// (set) Token: 0x0601FE24 RID: 130596 RVA: 0x0091CB54 File Offset: 0x0091AD54
		public unsafe float NearFadeStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170032AF RID: 12975
		// (get) Token: 0x0601FE25 RID: 130597 RVA: 0x0091CB65 File Offset: 0x0091AD65
		// (set) Token: 0x0601FE26 RID: 130598 RVA: 0x0091CB75 File Offset: 0x0091AD75
		public unsafe float FarFadeLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170032B0 RID: 12976
		// (get) Token: 0x0601FE27 RID: 130599 RVA: 0x0091CB86 File Offset: 0x0091AD86
		// (set) Token: 0x0601FE28 RID: 130600 RVA: 0x0091CB96 File Offset: 0x0091AD96
		public unsafe float FullIntLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170032B1 RID: 12977
		// (get) Token: 0x0601FE29 RID: 130601 RVA: 0x0091CBA7 File Offset: 0x0091ADA7
		// (set) Token: 0x0601FE2A RID: 130602 RVA: 0x0091CBB7 File Offset: 0x0091ADB7
		public unsafe float X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170032B2 RID: 12978
		// (get) Token: 0x0601FE2B RID: 130603 RVA: 0x0091CBC8 File Offset: 0x0091ADC8
		// (set) Token: 0x0601FE2C RID: 130604 RVA: 0x0091CBD8 File Offset: 0x0091ADD8
		public unsafe float Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170032B3 RID: 12979
		// (get) Token: 0x0601FE2D RID: 130605 RVA: 0x0091CBE9 File Offset: 0x0091ADE9
		// (set) Token: 0x0601FE2E RID: 130606 RVA: 0x0091CBF9 File Offset: 0x0091ADF9
		public unsafe float Z
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170032B4 RID: 12980
		// (get) Token: 0x0601FE2F RID: 130607 RVA: 0x0091CC0A File Offset: 0x0091AE0A
		// (set) Token: 0x0601FE30 RID: 130608 RVA: 0x0091CC1A File Offset: 0x0091AE1A
		public unsafe float Clip
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricLightTri_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x0601FE31 RID: 130609 RVA: 0x0091CC2B File Offset: 0x0091AE2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricLightTri_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FE32 RID: 130610 RVA: 0x0091CC3F File Offset: 0x0091AE3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricLightTri_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FE33 RID: 130611 RVA: 0x0091CC54 File Offset: 0x0091AE54
		protected BP_VolumetricLightTri_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FDDF RID: 64991
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricLightTri.BP_VolumetricLightTri_C";

		// Token: 0x0400FDE0 RID: 64992
		private static IntPtr _ClassPtr;

		// Token: 0x0400FDE1 RID: 64993
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FDE2 RID: 64994
		internal static int __PropertyOffset_0;

		// Token: 0x0400FDE3 RID: 64995
		internal static int __PropertyOffset_1;

		// Token: 0x0400FDE4 RID: 64996
		internal static int __PropertyOffset_2;

		// Token: 0x0400FDE5 RID: 64997
		internal static int __PropertyOffset_3;

		// Token: 0x0400FDE6 RID: 64998
		internal static int __PropertyOffset_4;

		// Token: 0x0400FDE7 RID: 64999
		internal static int __PropertyOffset_5;

		// Token: 0x0400FDE8 RID: 65000
		internal static int __PropertyOffset_6;

		// Token: 0x0400FDE9 RID: 65001
		internal static int __PropertyOffset_7;

		// Token: 0x0400FDEA RID: 65002
		internal static int __PropertyOffset_8;

		// Token: 0x0400FDEB RID: 65003
		internal static int __PropertyOffset_9;

		// Token: 0x0400FDEC RID: 65004
		internal static int __PropertyOffset_10;

		// Token: 0x0400FDED RID: 65005
		internal static int __PropertyOffset_11;

		// Token: 0x0400FDEE RID: 65006
		internal static int __PropertyOffset_12;

		// Token: 0x0400FDEF RID: 65007
		internal static int __PropertyOffset_13;

		// Token: 0x0400FDF0 RID: 65008
		internal static int __PropertyOffset_14;

		// Token: 0x0400FDF1 RID: 65009
		internal static int __PropertyOffset_15;

		// Token: 0x0400FDF2 RID: 65010
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
