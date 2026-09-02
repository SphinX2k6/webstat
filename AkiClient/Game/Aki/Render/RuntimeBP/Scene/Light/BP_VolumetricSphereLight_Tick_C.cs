using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003AAA RID: 15018
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricSphereLight_Tick.BP_VolumetricSphereLight_Tick_C")]
	[UnrealStructLayout(1464, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1464)]
	public class BP_VolumetricSphereLight_Tick_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601FF82 RID: 130946 RVA: 0x0091EA07 File Offset: 0x0091CC07
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricSphereLight_Tick_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricSphereLight_Tick.BP_VolumetricSphereLight_Tick_C");
			}
			return BP_VolumetricSphereLight_Tick_C._ClassPtr;
		}

		// Token: 0x0601FF83 RID: 130947 RVA: 0x0091EA2C File Offset: 0x0091CC2C
		public BP_VolumetricSphereLight_Tick_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricSphereLight_Tick_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FF84 RID: 130948 RVA: 0x0091EA54 File Offset: 0x0091CC54
		[NullableContext(1)]
		public BP_VolumetricSphereLight_Tick_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricSphereLight_Tick_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700333F RID: 13119
		// (get) Token: 0x0601FF85 RID: 130949 RVA: 0x0091EA88 File Offset: 0x0091CC88
		// (set) Token: 0x0601FF86 RID: 130950 RVA: 0x0091EAC1 File Offset: 0x0091CCC1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003340 RID: 13120
		// (get) Token: 0x0601FF87 RID: 130951 RVA: 0x0091EAE2 File Offset: 0x0091CCE2
		// (set) Token: 0x0601FF88 RID: 130952 RVA: 0x0091EAF6 File Offset: 0x0091CCF6
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003341 RID: 13121
		// (get) Token: 0x0601FF89 RID: 130953 RVA: 0x0091EB0B File Offset: 0x0091CD0B
		// (set) Token: 0x0601FF8A RID: 130954 RVA: 0x0091EB1F File Offset: 0x0091CD1F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003342 RID: 13122
		// (get) Token: 0x0601FF8B RID: 130955 RVA: 0x0091EB34 File Offset: 0x0091CD34
		// (set) Token: 0x0601FF8C RID: 130956 RVA: 0x0091EB48 File Offset: 0x0091CD48
		public unsafe UStaticMesh SphereLightStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003343 RID: 13123
		// (get) Token: 0x0601FF8D RID: 130957 RVA: 0x0091EB5D File Offset: 0x0091CD5D
		// (set) Token: 0x0601FF8E RID: 130958 RVA: 0x0091EB71 File Offset: 0x0091CD71
		public unsafe UMaterialInstance SphereLightMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003344 RID: 13124
		// (get) Token: 0x0601FF8F RID: 130959 RVA: 0x0091EB86 File Offset: 0x0091CD86
		// (set) Token: 0x0601FF90 RID: 130960 RVA: 0x0091EB96 File Offset: 0x0091CD96
		public unsafe bool IsReverseCulling
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003345 RID: 13125
		// (get) Token: 0x0601FF91 RID: 130961 RVA: 0x0091EBA7 File Offset: 0x0091CDA7
		// (set) Token: 0x0601FF92 RID: 130962 RVA: 0x0091EBB7 File Offset: 0x0091CDB7
		public unsafe bool IsWholeDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003346 RID: 13126
		// (get) Token: 0x0601FF93 RID: 130963 RVA: 0x0091EBC8 File Offset: 0x0091CDC8
		// (set) Token: 0x0601FF94 RID: 130964 RVA: 0x0091EBD8 File Offset: 0x0091CDD8
		public unsafe bool OutDistanceFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003347 RID: 13127
		// (get) Token: 0x0601FF95 RID: 130965 RVA: 0x0091EBE9 File Offset: 0x0091CDE9
		// (set) Token: 0x0601FF96 RID: 130966 RVA: 0x0091EBF9 File Offset: 0x0091CDF9
		public unsafe bool ApplyFog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003348 RID: 13128
		// (get) Token: 0x0601FF97 RID: 130967 RVA: 0x0091EC0A File Offset: 0x0091CE0A
		// (set) Token: 0x0601FF98 RID: 130968 RVA: 0x0091EC1A File Offset: 0x0091CE1A
		public unsafe bool IsTickIntenisty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003349 RID: 13129
		// (get) Token: 0x0601FF99 RID: 130969 RVA: 0x0091EC2B File Offset: 0x0091CE2B
		// (set) Token: 0x0601FF9A RID: 130970 RVA: 0x0091EC3B File Offset: 0x0091CE3B
		public unsafe float FogInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700334A RID: 13130
		// (get) Token: 0x0601FF9B RID: 130971 RVA: 0x0091EC4C File Offset: 0x0091CE4C
		// (set) Token: 0x0601FF9C RID: 130972 RVA: 0x0091EC5C File Offset: 0x0091CE5C
		public unsafe float FogPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700334B RID: 13131
		// (get) Token: 0x0601FF9D RID: 130973 RVA: 0x0091EC6D File Offset: 0x0091CE6D
		// (set) Token: 0x0601FF9E RID: 130974 RVA: 0x0091EC7D File Offset: 0x0091CE7D
		public unsafe float SkyLightInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700334C RID: 13132
		// (get) Token: 0x0601FF9F RID: 130975 RVA: 0x0091EC8E File Offset: 0x0091CE8E
		// (set) Token: 0x0601FFA0 RID: 130976 RVA: 0x0091EC9E File Offset: 0x0091CE9E
		public unsafe float SkyLightOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700334D RID: 13133
		// (get) Token: 0x0601FFA1 RID: 130977 RVA: 0x0091ECAF File Offset: 0x0091CEAF
		// (set) Token: 0x0601FFA2 RID: 130978 RVA: 0x0091ECC3 File Offset: 0x0091CEC3
		public unsafe FLinearColor InsideColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700334E RID: 13134
		// (get) Token: 0x0601FFA3 RID: 130979 RVA: 0x0091ECD8 File Offset: 0x0091CED8
		// (set) Token: 0x0601FFA4 RID: 130980 RVA: 0x0091ECEC File Offset: 0x0091CEEC
		public unsafe FLinearColor OutSideColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700334F RID: 13135
		// (get) Token: 0x0601FFA5 RID: 130981 RVA: 0x0091ED01 File Offset: 0x0091CF01
		// (set) Token: 0x0601FFA6 RID: 130982 RVA: 0x0091ED11 File Offset: 0x0091CF11
		public unsafe float SphereRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003350 RID: 13136
		// (get) Token: 0x0601FFA7 RID: 130983 RVA: 0x0091ED22 File Offset: 0x0091CF22
		// (set) Token: 0x0601FFA8 RID: 130984 RVA: 0x0091ED32 File Offset: 0x0091CF32
		public unsafe float LightStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003351 RID: 13137
		// (get) Token: 0x0601FFA9 RID: 130985 RVA: 0x0091ED43 File Offset: 0x0091CF43
		// (set) Token: 0x0601FFAA RID: 130986 RVA: 0x0091ED53 File Offset: 0x0091CF53
		public unsafe float NearFadeStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17003352 RID: 13138
		// (get) Token: 0x0601FFAB RID: 130987 RVA: 0x0091ED64 File Offset: 0x0091CF64
		// (set) Token: 0x0601FFAC RID: 130988 RVA: 0x0091ED74 File Offset: 0x0091CF74
		public unsafe float FullIntLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003353 RID: 13139
		// (get) Token: 0x0601FFAD RID: 130989 RVA: 0x0091ED85 File Offset: 0x0091CF85
		// (set) Token: 0x0601FFAE RID: 130990 RVA: 0x0091ED95 File Offset: 0x0091CF95
		public unsafe float FarFadeLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricSphereLight_Tick_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003354 RID: 13140
		// (get) Token: 0x0601FFAF RID: 130991 RVA: 0x0091EDA6 File Offset: 0x0091CFA6
		// (set) Token: 0x0601FFB0 RID: 130992 RVA: 0x0091EDBA File Offset: 0x0091CFBA
		public unsafe UMaterialInstanceDynamic MaterialInstanceDynamic
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17003355 RID: 13141
		// (get) Token: 0x0601FFB1 RID: 130993 RVA: 0x0091EDCF File Offset: 0x0091CFCF
		// (set) Token: 0x0601FFB2 RID: 130994 RVA: 0x0091EDE3 File Offset: 0x0091CFE3
		public unsafe UMaterialInstance SphereLightMatWithOutDF
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17003356 RID: 13142
		// (get) Token: 0x0601FFB3 RID: 130995 RVA: 0x0091EDF8 File Offset: 0x0091CFF8
		// (set) Token: 0x0601FFB4 RID: 130996 RVA: 0x0091EE0C File Offset: 0x0091D00C
		public unsafe UMaterialInstance SphereLightMatWithOutFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17003357 RID: 13143
		// (get) Token: 0x0601FFB5 RID: 130997 RVA: 0x0091EE21 File Offset: 0x0091D021
		// (set) Token: 0x0601FFB6 RID: 130998 RVA: 0x0091EE35 File Offset: 0x0091D035
		public unsafe UMaterialInstance SphereLightMatWithOutDFWithOutFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricSphereLight_Tick_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x0601FFB7 RID: 130999 RVA: 0x0091EE4A File Offset: 0x0091D04A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateVolumetricSphereLight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLight_Tick_C.__UpdateVolumetricSphereLight_NativeFunctionPtr, null);
		}

		// Token: 0x0601FFB8 RID: 131000 RVA: 0x0091EE5E File Offset: 0x0091D05E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLight_Tick_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FFB9 RID: 131001 RVA: 0x0091EE72 File Offset: 0x0091D072
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLight_Tick_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FFBA RID: 131002 RVA: 0x0091EE87 File Offset: 0x0091D087
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLight_Tick_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FFBB RID: 131003 RVA: 0x0091EE9B File Offset: 0x0091D09B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLight_Tick_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FFBC RID: 131004 RVA: 0x0091EEB0 File Offset: 0x0091D0B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VolumetricSphereLight_Tick_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricSphereLight_Tick_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLight_Tick_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLight_Tick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLight_Tick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FFBD RID: 131005 RVA: 0x0091EEF8 File Offset: 0x0091D0F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricSphereLight_Tick_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricSphereLight_Tick_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLight_Tick_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLight_Tick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLight_Tick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FFBE RID: 131006 RVA: 0x0091EF40 File Offset: 0x0091D140
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_VolumetricSphereLight_Tick_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricSphereLight_Tick_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLight_Tick_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLight_Tick_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricSphereLight_Tick_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FFBF RID: 131007 RVA: 0x0091EF88 File Offset: 0x0091D188
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricSphereLight_Tick_C.__EditorTick_FunctionParams* ptr = stackalloc BP_VolumetricSphereLight_Tick_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricSphereLight_Tick_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLight_Tick_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLight_Tick_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FFC0 RID: 131008 RVA: 0x0091EFD0 File Offset: 0x0091D1D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricSphereLight_Tick(int EntryPoint)
		{
			BP_VolumetricSphereLight_Tick_C.__ExecuteUbergraph_BP_VolumetricSphereLight_Tick_FunctionParams* ptr = stackalloc BP_VolumetricSphereLight_Tick_C.__ExecuteUbergraph_BP_VolumetricSphereLight_Tick_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_VolumetricSphereLight_Tick_C.__ExecuteUbergraph_BP_VolumetricSphereLight_Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricSphereLight_Tick_C.__ExecuteUbergraph_BP_VolumetricSphereLight_Tick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricSphereLight_Tick_C.__ExecuteUbergraph_BP_VolumetricSphereLight_Tick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FFC1 RID: 131009 RVA: 0x0091F017 File Offset: 0x0091D217
		protected BP_VolumetricSphereLight_Tick_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FEA9 RID: 65193
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricSphereLight_Tick.BP_VolumetricSphereLight_Tick_C";

		// Token: 0x0400FEAA RID: 65194
		private static IntPtr _ClassPtr;

		// Token: 0x0400FEAB RID: 65195
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FEAC RID: 65196
		internal static int __PropertyOffset_0;

		// Token: 0x0400FEAD RID: 65197
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FEAE RID: 65198
		internal static int __PropertyOffset_1;

		// Token: 0x0400FEAF RID: 65199
		internal static int __PropertyOffset_2;

		// Token: 0x0400FEB0 RID: 65200
		internal static int __PropertyOffset_3;

		// Token: 0x0400FEB1 RID: 65201
		internal static int __PropertyOffset_4;

		// Token: 0x0400FEB2 RID: 65202
		internal static int __PropertyOffset_5;

		// Token: 0x0400FEB3 RID: 65203
		internal static int __PropertyOffset_6;

		// Token: 0x0400FEB4 RID: 65204
		internal static int __PropertyOffset_7;

		// Token: 0x0400FEB5 RID: 65205
		internal static int __PropertyOffset_8;

		// Token: 0x0400FEB6 RID: 65206
		internal static int __PropertyOffset_9;

		// Token: 0x0400FEB7 RID: 65207
		internal static int __PropertyOffset_10;

		// Token: 0x0400FEB8 RID: 65208
		internal static int __PropertyOffset_11;

		// Token: 0x0400FEB9 RID: 65209
		internal static int __PropertyOffset_12;

		// Token: 0x0400FEBA RID: 65210
		internal static int __PropertyOffset_13;

		// Token: 0x0400FEBB RID: 65211
		internal static int __PropertyOffset_14;

		// Token: 0x0400FEBC RID: 65212
		internal static int __PropertyOffset_15;

		// Token: 0x0400FEBD RID: 65213
		internal static int __PropertyOffset_16;

		// Token: 0x0400FEBE RID: 65214
		internal static int __PropertyOffset_17;

		// Token: 0x0400FEBF RID: 65215
		internal static int __PropertyOffset_18;

		// Token: 0x0400FEC0 RID: 65216
		internal static int __PropertyOffset_19;

		// Token: 0x0400FEC1 RID: 65217
		internal static int __PropertyOffset_20;

		// Token: 0x0400FEC2 RID: 65218
		internal static int __PropertyOffset_21;

		// Token: 0x0400FEC3 RID: 65219
		internal static int __PropertyOffset_22;

		// Token: 0x0400FEC4 RID: 65220
		internal static int __PropertyOffset_23;

		// Token: 0x0400FEC5 RID: 65221
		internal static int __PropertyOffset_24;

		// Token: 0x0400FEC6 RID: 65222
		private static IntPtr __UpdateVolumetricSphereLight_NativeFunctionPtr;

		// Token: 0x0400FEC7 RID: 65223
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FEC8 RID: 65224
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FEC9 RID: 65225
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FECA RID: 65226
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FECB RID: 65227
		private static IntPtr __ExecuteUbergraph_BP_VolumetricSphereLight_Tick_NativeFunctionPtr;

		// Token: 0x0200993D RID: 39229
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F9C RID: 204700
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200993E RID: 39230
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F9D RID: 204701
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200993F RID: 39231
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricSphereLight_Tick_FunctionParams
		{
			// Token: 0x04031F9E RID: 204702
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
