using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Metaballs
{
	// Token: 0x02003BBF RID: 15295
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Metaballs/BP_MetaballForMobile.BP_MetaballForMobile_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class BP_MetaballForMobile_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060224C9 RID: 140489 RVA: 0x00961728 File Offset: 0x0095F928
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MetaballForMobile_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Metaballs/BP_MetaballForMobile.BP_MetaballForMobile_C");
			}
			return BP_MetaballForMobile_C._ClassPtr;
		}

		// Token: 0x060224CA RID: 140490 RVA: 0x0096174C File Offset: 0x0095F94C
		public BP_MetaballForMobile_C() : this(BuiltinUtils.AllocNativeUObject(BP_MetaballForMobile_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060224CB RID: 140491 RVA: 0x00961774 File Offset: 0x0095F974
		[NullableContext(1)]
		public BP_MetaballForMobile_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MetaballForMobile_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004020 RID: 16416
		// (get) Token: 0x060224CC RID: 140492 RVA: 0x009617A7 File Offset: 0x0095F9A7
		// (set) Token: 0x060224CD RID: 140493 RVA: 0x009617BB File Offset: 0x0095F9BB
		public unsafe UBoxComponent BoundSize
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17004021 RID: 16417
		// (get) Token: 0x060224CE RID: 140494 RVA: 0x009617D0 File Offset: 0x0095F9D0
		// (set) Token: 0x060224CF RID: 140495 RVA: 0x009617E4 File Offset: 0x0095F9E4
		public unsafe UStaticMeshComponent Sphere4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004022 RID: 16418
		// (get) Token: 0x060224D0 RID: 140496 RVA: 0x009617F9 File Offset: 0x0095F9F9
		// (set) Token: 0x060224D1 RID: 140497 RVA: 0x0096180D File Offset: 0x0095FA0D
		public unsafe UStaticMeshComponent Sphere3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004023 RID: 16419
		// (get) Token: 0x060224D2 RID: 140498 RVA: 0x00961822 File Offset: 0x0095FA22
		// (set) Token: 0x060224D3 RID: 140499 RVA: 0x00961836 File Offset: 0x0095FA36
		public unsafe UStaticMeshComponent Sphere2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004024 RID: 16420
		// (get) Token: 0x060224D4 RID: 140500 RVA: 0x0096184B File Offset: 0x0095FA4B
		// (set) Token: 0x060224D5 RID: 140501 RVA: 0x0096185F File Offset: 0x0095FA5F
		public unsafe UStaticMeshComponent Sphere1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004025 RID: 16421
		// (get) Token: 0x060224D6 RID: 140502 RVA: 0x00961874 File Offset: 0x0095FA74
		// (set) Token: 0x060224D7 RID: 140503 RVA: 0x00961888 File Offset: 0x0095FA88
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004026 RID: 16422
		// (get) Token: 0x060224D8 RID: 140504 RVA: 0x0096189D File Offset: 0x0095FA9D
		// (set) Token: 0x060224D9 RID: 140505 RVA: 0x009618B1 File Offset: 0x0095FAB1
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004027 RID: 16423
		// (get) Token: 0x060224DA RID: 140506 RVA: 0x009618C6 File Offset: 0x0095FAC6
		// (set) Token: 0x060224DB RID: 140507 RVA: 0x009618DA File Offset: 0x0095FADA
		public unsafe FVector 包围盒范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004028 RID: 16424
		// (get) Token: 0x060224DC RID: 140508 RVA: 0x009618EF File Offset: 0x0095FAEF
		// (set) Token: 0x060224DD RID: 140509 RVA: 0x009618FF File Offset: 0x0095FAFF
		public unsafe float 小球运动模式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004029 RID: 16425
		// (get) Token: 0x060224DE RID: 140510 RVA: 0x00961910 File Offset: 0x0095FB10
		// (set) Token: 0x060224DF RID: 140511 RVA: 0x00961920 File Offset: 0x0095FB20
		public unsafe float 小球基础半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700402A RID: 16426
		// (get) Token: 0x060224E0 RID: 140512 RVA: 0x00961931 File Offset: 0x0095FB31
		// (set) Token: 0x060224E1 RID: 140513 RVA: 0x00961941 File Offset: 0x0095FB41
		public unsafe float 小球半径波动
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700402B RID: 16427
		// (get) Token: 0x060224E2 RID: 140514 RVA: 0x00961952 File Offset: 0x0095FB52
		// (set) Token: 0x060224E3 RID: 140515 RVA: 0x00961962 File Offset: 0x0095FB62
		public unsafe float 小球运动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700402C RID: 16428
		// (get) Token: 0x060224E4 RID: 140516 RVA: 0x00961973 File Offset: 0x0095FB73
		// (set) Token: 0x060224E5 RID: 140517 RVA: 0x00961987 File Offset: 0x0095FB87
		public unsafe UMaterialInstanceDynamic SphereDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x1700402D RID: 16429
		// (get) Token: 0x060224E6 RID: 140518 RVA: 0x0096199C File Offset: 0x0095FB9C
		// (set) Token: 0x060224E7 RID: 140519 RVA: 0x009619B0 File Offset: 0x0095FBB0
		public unsafe FLinearColor 小球中心颜色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700402E RID: 16430
		// (get) Token: 0x060224E8 RID: 140520 RVA: 0x009619C5 File Offset: 0x0095FBC5
		// (set) Token: 0x060224E9 RID: 140521 RVA: 0x009619D9 File Offset: 0x0095FBD9
		public unsafe FLinearColor 小球边缘颜色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700402F RID: 16431
		// (get) Token: 0x060224EA RID: 140522 RVA: 0x009619EE File Offset: 0x0095FBEE
		// (set) Token: 0x060224EB RID: 140523 RVA: 0x009619FE File Offset: 0x0095FBFE
		public unsafe float 核心球半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004030 RID: 16432
		// (get) Token: 0x060224EC RID: 140524 RVA: 0x00961A0F File Offset: 0x0095FC0F
		// (set) Token: 0x060224ED RID: 140525 RVA: 0x00961A1F File Offset: 0x0095FC1F
		public unsafe float 核心球表面游动范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004031 RID: 16433
		// (get) Token: 0x060224EE RID: 140526 RVA: 0x00961A30 File Offset: 0x0095FC30
		// (set) Token: 0x060224EF RID: 140527 RVA: 0x00961A40 File Offset: 0x0095FC40
		public unsafe float 反射强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004032 RID: 16434
		// (get) Token: 0x060224F0 RID: 140528 RVA: 0x00961A51 File Offset: 0x0095FC51
		// (set) Token: 0x060224F1 RID: 140529 RVA: 0x00961A65 File Offset: 0x0095FC65
		public unsafe UTextureCube 反射贴图
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureCube>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17004033 RID: 16435
		// (get) Token: 0x060224F2 RID: 140530 RVA: 0x00961A7A File Offset: 0x0095FC7A
		// (set) Token: 0x060224F3 RID: 140531 RVA: 0x00961A8A File Offset: 0x0095FC8A
		public unsafe float 核心噪声尺寸
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004034 RID: 16436
		// (get) Token: 0x060224F4 RID: 140532 RVA: 0x00961A9B File Offset: 0x0095FC9B
		// (set) Token: 0x060224F5 RID: 140533 RVA: 0x00961AAF File Offset: 0x0095FCAF
		public unsafe UVolumeTexture 噪声贴图
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UVolumeTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17004035 RID: 16437
		// (get) Token: 0x060224F6 RID: 140534 RVA: 0x00961AC4 File Offset: 0x0095FCC4
		// (set) Token: 0x060224F7 RID: 140535 RVA: 0x00961AD8 File Offset: 0x0095FCD8
		public unsafe FLinearColor 核心噪声颜色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004036 RID: 16438
		// (get) Token: 0x060224F8 RID: 140536 RVA: 0x00961AED File Offset: 0x0095FCED
		// (set) Token: 0x060224F9 RID: 140537 RVA: 0x00961AFD File Offset: 0x0095FCFD
		public unsafe float 核心噪声范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004037 RID: 16439
		// (get) Token: 0x060224FA RID: 140538 RVA: 0x00961B0E File Offset: 0x0095FD0E
		// (set) Token: 0x060224FB RID: 140539 RVA: 0x00961B1E File Offset: 0x0095FD1E
		public unsafe float 核心噪声阈值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MetaballForMobile_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004038 RID: 16440
		// (get) Token: 0x060224FC RID: 140540 RVA: 0x00961B2F File Offset: 0x0095FD2F
		// (set) Token: 0x060224FD RID: 140541 RVA: 0x00961B43 File Offset: 0x0095FD43
		public unsafe UMaterialInstanceDynamic CoreSphereDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MetaballForMobile_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x060224FE RID: 140542 RVA: 0x00961B58 File Offset: 0x0095FD58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MetaballForMobile_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060224FF RID: 140543 RVA: 0x00961B6C File Offset: 0x0095FD6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MetaballForMobile_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022500 RID: 140544 RVA: 0x00961B81 File Offset: 0x0095FD81
		protected BP_MetaballForMobile_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401158B RID: 71051
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Metaballs/BP_MetaballForMobile.BP_MetaballForMobile_C";

		// Token: 0x0401158C RID: 71052
		private static IntPtr _ClassPtr;

		// Token: 0x0401158D RID: 71053
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401158E RID: 71054
		internal static int __PropertyOffset_0;

		// Token: 0x0401158F RID: 71055
		internal static int __PropertyOffset_1;

		// Token: 0x04011590 RID: 71056
		internal static int __PropertyOffset_2;

		// Token: 0x04011591 RID: 71057
		internal static int __PropertyOffset_3;

		// Token: 0x04011592 RID: 71058
		internal static int __PropertyOffset_4;

		// Token: 0x04011593 RID: 71059
		internal static int __PropertyOffset_5;

		// Token: 0x04011594 RID: 71060
		internal static int __PropertyOffset_6;

		// Token: 0x04011595 RID: 71061
		internal static int __PropertyOffset_7;

		// Token: 0x04011596 RID: 71062
		internal static int __PropertyOffset_8;

		// Token: 0x04011597 RID: 71063
		internal static int __PropertyOffset_9;

		// Token: 0x04011598 RID: 71064
		internal static int __PropertyOffset_10;

		// Token: 0x04011599 RID: 71065
		internal static int __PropertyOffset_11;

		// Token: 0x0401159A RID: 71066
		internal static int __PropertyOffset_12;

		// Token: 0x0401159B RID: 71067
		internal static int __PropertyOffset_13;

		// Token: 0x0401159C RID: 71068
		internal static int __PropertyOffset_14;

		// Token: 0x0401159D RID: 71069
		internal static int __PropertyOffset_15;

		// Token: 0x0401159E RID: 71070
		internal static int __PropertyOffset_16;

		// Token: 0x0401159F RID: 71071
		internal static int __PropertyOffset_17;

		// Token: 0x040115A0 RID: 71072
		internal static int __PropertyOffset_18;

		// Token: 0x040115A1 RID: 71073
		internal static int __PropertyOffset_19;

		// Token: 0x040115A2 RID: 71074
		internal static int __PropertyOffset_20;

		// Token: 0x040115A3 RID: 71075
		internal static int __PropertyOffset_21;

		// Token: 0x040115A4 RID: 71076
		internal static int __PropertyOffset_22;

		// Token: 0x040115A5 RID: 71077
		internal static int __PropertyOffset_23;

		// Token: 0x040115A6 RID: 71078
		internal static int __PropertyOffset_24;

		// Token: 0x040115A7 RID: 71079
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
