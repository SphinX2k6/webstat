using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.ZoneFollowCamera
{
	// Token: 0x02003E92 RID: 16018
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/ZoneFollowCamera/BP_ZoneFollowCameraZone.BP_ZoneFollowCameraZone_C")]
	[UnrealStructLayout(1128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1124)]
	public class BP_ZoneFollowCameraZone_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027ADA RID: 162522 RVA: 0x009F7DCC File Offset: 0x009F5FCC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ZoneFollowCameraZone_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Gameplay/ZoneFollowCamera/BP_ZoneFollowCameraZone.BP_ZoneFollowCameraZone_C");
			}
			return BP_ZoneFollowCameraZone_C._ClassPtr;
		}

		// Token: 0x06027ADB RID: 162523 RVA: 0x009F7DF0 File Offset: 0x009F5FF0
		public BP_ZoneFollowCameraZone_C() : this(BuiltinUtils.AllocNativeUObject(BP_ZoneFollowCameraZone_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027ADC RID: 162524 RVA: 0x009F7E18 File Offset: 0x009F6018
		[NullableContext(1)]
		public BP_ZoneFollowCameraZone_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ZoneFollowCameraZone_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005E3B RID: 24123
		// (get) Token: 0x06027ADD RID: 162525 RVA: 0x009F7E4B File Offset: 0x009F604B
		// (set) Token: 0x06027ADE RID: 162526 RVA: 0x009F7E5F File Offset: 0x009F605F
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraZone_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraZone_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005E3C RID: 24124
		// (get) Token: 0x06027ADF RID: 162527 RVA: 0x009F7E74 File Offset: 0x009F6074
		// (set) Token: 0x06027AE0 RID: 162528 RVA: 0x009F7E88 File Offset: 0x009F6088
		public unsafe UCameraComponent SettingCamera
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCameraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraZone_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraZone_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005E3D RID: 24125
		// (get) Token: 0x06027AE1 RID: 162529 RVA: 0x009F7E9D File Offset: 0x009F609D
		// (set) Token: 0x06027AE2 RID: 162530 RVA: 0x009F7EB1 File Offset: 0x009F60B1
		public unsafe USceneComponent CenterRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraZone_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraZone_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005E3E RID: 24126
		// (get) Token: 0x06027AE3 RID: 162531 RVA: 0x009F7EC6 File Offset: 0x009F60C6
		// (set) Token: 0x06027AE4 RID: 162532 RVA: 0x009F7EDA File Offset: 0x009F60DA
		public unsafe UBoxComponent BoxCollision
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraZone_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraZone_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005E3F RID: 24127
		// (get) Token: 0x06027AE5 RID: 162533 RVA: 0x009F7EEF File Offset: 0x009F60EF
		// (set) Token: 0x06027AE6 RID: 162534 RVA: 0x009F7F03 File Offset: 0x009F6103
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraZone_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ZoneFollowCameraZone_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005E40 RID: 24128
		// (get) Token: 0x06027AE7 RID: 162535 RVA: 0x009F7F18 File Offset: 0x009F6118
		// (set) Token: 0x06027AE8 RID: 162536 RVA: 0x009F7F2C File Offset: 0x009F612C
		public unsafe FVector 相对中心点映射百分比
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ZoneFollowCameraZone_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ZoneFollowCameraZone_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005E41 RID: 24129
		// (get) Token: 0x06027AE9 RID: 162537 RVA: 0x009F7F41 File Offset: 0x009F6141
		// (set) Token: 0x06027AEA RID: 162538 RVA: 0x009F7F55 File Offset: 0x009F6155
		public unsafe FVector 默认相机相对偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ZoneFollowCameraZone_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ZoneFollowCameraZone_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005E42 RID: 24130
		// (get) Token: 0x06027AEB RID: 162539 RVA: 0x009F7F6A File Offset: 0x009F616A
		// (set) Token: 0x06027AEC RID: 162540 RVA: 0x009F7F7E File Offset: 0x009F617E
		public unsafe FRotator 默认相机相对旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ZoneFollowCameraZone_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ZoneFollowCameraZone_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005E43 RID: 24131
		// (get) Token: 0x06027AED RID: 162541 RVA: 0x009F7F93 File Offset: 0x009F6193
		// (set) Token: 0x06027AEE RID: 162542 RVA: 0x009F7FA7 File Offset: 0x009F61A7
		public unsafe FRotator 世界旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ZoneFollowCameraZone_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ZoneFollowCameraZone_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005E44 RID: 24132
		// (get) Token: 0x06027AEF RID: 162543 RVA: 0x009F7FBC File Offset: 0x009F61BC
		// (set) Token: 0x06027AF0 RID: 162544 RVA: 0x009F7FD0 File Offset: 0x009F61D0
		public unsafe FVector 世界偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ZoneFollowCameraZone_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ZoneFollowCameraZone_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x06027AF1 RID: 162545 RVA: 0x009F7FE5 File Offset: 0x009F61E5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ZoneFollowCameraZone_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06027AF2 RID: 162546 RVA: 0x009F7FF9 File Offset: 0x009F61F9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ZoneFollowCameraZone_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06027AF3 RID: 162547 RVA: 0x009F800E File Offset: 0x009F620E
		protected BP_ZoneFollowCameraZone_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014CFC RID: 85244
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Gameplay/ZoneFollowCamera/BP_ZoneFollowCameraZone.BP_ZoneFollowCameraZone_C";

		// Token: 0x04014CFD RID: 85245
		private static IntPtr _ClassPtr;

		// Token: 0x04014CFE RID: 85246
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014CFF RID: 85247
		internal static int __PropertyOffset_0;

		// Token: 0x04014D00 RID: 85248
		internal static int __PropertyOffset_1;

		// Token: 0x04014D01 RID: 85249
		internal static int __PropertyOffset_2;

		// Token: 0x04014D02 RID: 85250
		internal static int __PropertyOffset_3;

		// Token: 0x04014D03 RID: 85251
		internal static int __PropertyOffset_4;

		// Token: 0x04014D04 RID: 85252
		internal static int __PropertyOffset_5;

		// Token: 0x04014D05 RID: 85253
		internal static int __PropertyOffset_6;

		// Token: 0x04014D06 RID: 85254
		internal static int __PropertyOffset_7;

		// Token: 0x04014D07 RID: 85255
		internal static int __PropertyOffset_8;

		// Token: 0x04014D08 RID: 85256
		internal static int __PropertyOffset_9;

		// Token: 0x04014D09 RID: 85257
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
