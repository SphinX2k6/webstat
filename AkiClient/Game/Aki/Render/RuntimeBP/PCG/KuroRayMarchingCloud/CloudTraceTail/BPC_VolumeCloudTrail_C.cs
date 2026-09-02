using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud.CloudTraceTail
{
	// Token: 0x02003BF4 RID: 15348
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/CloudTraceTail/BPC_VolumeCloudTrail.BPC_VolumeCloudTrail_C")]
	[UnrealStructLayout(848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 838)]
	public class BPC_VolumeCloudTrail_C : USceneComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022AC0 RID: 142016 RVA: 0x0096B7A0 File Offset: 0x009699A0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BPC_VolumeCloudTrail_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/CloudTraceTail/BPC_VolumeCloudTrail.BPC_VolumeCloudTrail_C");
			}
			return BPC_VolumeCloudTrail_C._ClassPtr;
		}

		// Token: 0x06022AC1 RID: 142017 RVA: 0x0096B7C4 File Offset: 0x009699C4
		public BPC_VolumeCloudTrail_C() : this(BuiltinUtils.AllocNativeUObject(BPC_VolumeCloudTrail_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022AC2 RID: 142018 RVA: 0x0096B7EC File Offset: 0x009699EC
		[NullableContext(1)]
		public BPC_VolumeCloudTrail_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BPC_VolumeCloudTrail_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004221 RID: 16929
		// (get) Token: 0x06022AC3 RID: 142019 RVA: 0x0096B820 File Offset: 0x00969A20
		// (set) Token: 0x06022AC4 RID: 142020 RVA: 0x0096B859 File Offset: 0x00969A59
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004222 RID: 16930
		// (get) Token: 0x06022AC5 RID: 142021 RVA: 0x0096B87A File Offset: 0x00969A7A
		// (set) Token: 0x06022AC6 RID: 142022 RVA: 0x0096B88E File Offset: 0x00969A8E
		public unsafe FVector LastMotionOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17004223 RID: 16931
		// (get) Token: 0x06022AC7 RID: 142023 RVA: 0x0096B8A3 File Offset: 0x00969AA3
		// (set) Token: 0x06022AC8 RID: 142024 RVA: 0x0096B8B7 File Offset: 0x00969AB7
		public unsafe UMaterialInstanceDynamic RTMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BPC_VolumeCloudTrail_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BPC_VolumeCloudTrail_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004224 RID: 16932
		// (get) Token: 0x06022AC9 RID: 142025 RVA: 0x0096B8CC File Offset: 0x00969ACC
		// (set) Token: 0x06022ACA RID: 142026 RVA: 0x0096B8E0 File Offset: 0x00969AE0
		public unsafe AActor BindActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BPC_VolumeCloudTrail_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BPC_VolumeCloudTrail_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004225 RID: 16933
		// (get) Token: 0x06022ACB RID: 142027 RVA: 0x0096B8F5 File Offset: 0x00969AF5
		// (set) Token: 0x06022ACC RID: 142028 RVA: 0x0096B905 File Offset: 0x00969B05
		public unsafe float Value
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004226 RID: 16934
		// (get) Token: 0x06022ACD RID: 142029 RVA: 0x0096B916 File Offset: 0x00969B16
		// (set) Token: 0x06022ACE RID: 142030 RVA: 0x0096B92A File Offset: 0x00969B2A
		public unsafe UMaterialInstanceDynamic RTMaterial_Pre
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BPC_VolumeCloudTrail_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BPC_VolumeCloudTrail_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004227 RID: 16935
		// (get) Token: 0x06022ACF RID: 142031 RVA: 0x0096B93F File Offset: 0x00969B3F
		// (set) Token: 0x06022AD0 RID: 142032 RVA: 0x0096B953 File Offset: 0x00969B53
		public unsafe FVectorDouble LastPostion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004228 RID: 16936
		// (get) Token: 0x06022AD1 RID: 142033 RVA: 0x0096B968 File Offset: 0x00969B68
		// (set) Token: 0x06022AD2 RID: 142034 RVA: 0x0096B978 File Offset: 0x00969B78
		public unsafe bool bFadeWhenStop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004229 RID: 16937
		// (get) Token: 0x06022AD3 RID: 142035 RVA: 0x0096B989 File Offset: 0x00969B89
		// (set) Token: 0x06022AD4 RID: 142036 RVA: 0x0096B999 File Offset: 0x00969B99
		public unsafe bool bFirstTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700422A RID: 16938
		// (get) Token: 0x06022AD5 RID: 142037 RVA: 0x0096B9AA File Offset: 0x00969BAA
		// (set) Token: 0x06022AD6 RID: 142038 RVA: 0x0096B9BE File Offset: 0x00969BBE
		public unsafe UTexture2D CloudMask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BPC_VolumeCloudTrail_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BPC_VolumeCloudTrail_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x1700422B RID: 16939
		// (get) Token: 0x06022AD7 RID: 142039 RVA: 0x0096B9D3 File Offset: 0x00969BD3
		// (set) Token: 0x06022AD8 RID: 142040 RVA: 0x0096B9E3 File Offset: 0x00969BE3
		public unsafe bool bDrawBound
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700422C RID: 16940
		// (get) Token: 0x06022AD9 RID: 142041 RVA: 0x0096B9F4 File Offset: 0x00969BF4
		// (set) Token: 0x06022ADA RID: 142042 RVA: 0x0096BA08 File Offset: 0x00969C08
		public unsafe UMaterialInstanceDynamic lowCloudMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BPC_VolumeCloudTrail_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BPC_VolumeCloudTrail_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x1700422D RID: 16941
		// (get) Token: 0x06022ADB RID: 142043 RVA: 0x0096BA1D File Offset: 0x00969C1D
		// (set) Token: 0x06022ADC RID: 142044 RVA: 0x0096BA2D File Offset: 0x00969C2D
		public unsafe float BoundSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700422E RID: 16942
		// (get) Token: 0x06022ADD RID: 142045 RVA: 0x0096BA3E File Offset: 0x00969C3E
		// (set) Token: 0x06022ADE RID: 142046 RVA: 0x0096BA52 File Offset: 0x00969C52
		public unsafe UMaterialInstanceDynamic bottomMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BPC_VolumeCloudTrail_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BPC_VolumeCloudTrail_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x1700422F RID: 16943
		// (get) Token: 0x06022ADF RID: 142047 RVA: 0x0096BA67 File Offset: 0x00969C67
		// (set) Token: 0x06022AE0 RID: 142048 RVA: 0x0096BA7B File Offset: 0x00969C7B
		public unsafe FVectorDouble targetPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004230 RID: 16944
		// (get) Token: 0x06022AE1 RID: 142049 RVA: 0x0096BA90 File Offset: 0x00969C90
		// (set) Token: 0x06022AE2 RID: 142050 RVA: 0x0096BAA0 File Offset: 0x00969CA0
		public unsafe float radialSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004231 RID: 16945
		// (get) Token: 0x06022AE3 RID: 142051 RVA: 0x0096BAB1 File Offset: 0x00969CB1
		// (set) Token: 0x06022AE4 RID: 142052 RVA: 0x0096BAC1 File Offset: 0x00969CC1
		public unsafe float radialSize_boat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004232 RID: 16946
		// (get) Token: 0x06022AE5 RID: 142053 RVA: 0x0096BAD2 File Offset: 0x00969CD2
		// (set) Token: 0x06022AE6 RID: 142054 RVA: 0x0096BAE2 File Offset: 0x00969CE2
		public unsafe float radialSize_kanteleila
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004233 RID: 16947
		// (get) Token: 0x06022AE7 RID: 142055 RVA: 0x0096BAF3 File Offset: 0x00969CF3
		// (set) Token: 0x06022AE8 RID: 142056 RVA: 0x0096BB03 File Offset: 0x00969D03
		public unsafe float BoundSize_boat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004234 RID: 16948
		// (get) Token: 0x06022AE9 RID: 142057 RVA: 0x0096BB14 File Offset: 0x00969D14
		// (set) Token: 0x06022AEA RID: 142058 RVA: 0x0096BB24 File Offset: 0x00969D24
		public unsafe float BoundSize_man
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004235 RID: 16949
		// (get) Token: 0x06022AEB RID: 142059 RVA: 0x0096BB35 File Offset: 0x00969D35
		// (set) Token: 0x06022AEC RID: 142060 RVA: 0x0096BB45 File Offset: 0x00969D45
		public unsafe double MinHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004236 RID: 16950
		// (get) Token: 0x06022AED RID: 142061 RVA: 0x0096BB56 File Offset: 0x00969D56
		// (set) Token: 0x06022AEE RID: 142062 RVA: 0x0096BB66 File Offset: 0x00969D66
		public unsafe float BoatOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004237 RID: 16951
		// (get) Token: 0x06022AEF RID: 142063 RVA: 0x0096BB77 File Offset: 0x00969D77
		// (set) Token: 0x06022AF0 RID: 142064 RVA: 0x0096BB8B File Offset: 0x00969D8B
		public unsafe FVectorDouble LastPostion_raw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004238 RID: 16952
		// (get) Token: 0x06022AF1 RID: 142065 RVA: 0x0096BBA0 File Offset: 0x00969DA0
		// (set) Token: 0x06022AF2 RID: 142066 RVA: 0x0096BBB4 File Offset: 0x00969DB4
		public unsafe FVectorDouble targetPosition_raw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004239 RID: 16953
		// (get) Token: 0x06022AF3 RID: 142067 RVA: 0x0096BBC9 File Offset: 0x00969DC9
		// (set) Token: 0x06022AF4 RID: 142068 RVA: 0x0096BBD9 File Offset: 0x00969DD9
		public unsafe float FadeMinSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700423A RID: 16954
		// (get) Token: 0x06022AF5 RID: 142069 RVA: 0x0096BBEA File Offset: 0x00969DEA
		// (set) Token: 0x06022AF6 RID: 142070 RVA: 0x0096BBFA File Offset: 0x00969DFA
		public unsafe float StaticMinSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700423B RID: 16955
		// (get) Token: 0x06022AF7 RID: 142071 RVA: 0x0096BC0B File Offset: 0x00969E0B
		// (set) Token: 0x06022AF8 RID: 142072 RVA: 0x0096BC1B File Offset: 0x00969E1B
		public unsafe float FlakeSP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700423C RID: 16956
		// (get) Token: 0x06022AF9 RID: 142073 RVA: 0x0096BC2C File Offset: 0x00969E2C
		// (set) Token: 0x06022AFA RID: 142074 RVA: 0x0096BC3C File Offset: 0x00969E3C
		public unsafe bool bKanteleila
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700423D RID: 16957
		// (get) Token: 0x06022AFB RID: 142075 RVA: 0x0096BC4D File Offset: 0x00969E4D
		// (set) Token: 0x06022AFC RID: 142076 RVA: 0x0096BC5D File Offset: 0x00969E5D
		public unsafe bool bBoat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPC_VolumeCloudTrail_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022AFD RID: 142077 RVA: 0x0096BC6E File Offset: 0x00969E6E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TrailTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BPC_VolumeCloudTrail_C.__TrailTick_NativeFunctionPtr, null);
		}

		// Token: 0x06022AFE RID: 142078 RVA: 0x0096BC84 File Offset: 0x00969E84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BPC_VolumeCloudTrail_C.__ReceiveTick_FunctionParams* ptr = stackalloc BPC_VolumeCloudTrail_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BPC_VolumeCloudTrail_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPC_VolumeCloudTrail_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BPC_VolumeCloudTrail_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022AFF RID: 142079 RVA: 0x0096BCCC File Offset: 0x00969ECC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BPC_VolumeCloudTrail_C.__ReceiveTick_FunctionParams* ptr = stackalloc BPC_VolumeCloudTrail_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BPC_VolumeCloudTrail_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPC_VolumeCloudTrail_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BPC_VolumeCloudTrail_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022B00 RID: 142080 RVA: 0x0096BD14 File Offset: 0x00969F14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BPC_VolumeCloudTrail(int EntryPoint)
		{
			BPC_VolumeCloudTrail_C.__ExecuteUbergraph_BPC_VolumeCloudTrail_FunctionParams* ptr = stackalloc BPC_VolumeCloudTrail_C.__ExecuteUbergraph_BPC_VolumeCloudTrail_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BPC_VolumeCloudTrail_C.__ExecuteUbergraph_BPC_VolumeCloudTrail_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPC_VolumeCloudTrail_C.__ExecuteUbergraph_BPC_VolumeCloudTrail_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BPC_VolumeCloudTrail_C.__ExecuteUbergraph_BPC_VolumeCloudTrail_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022B01 RID: 142081 RVA: 0x0096BD5B File Offset: 0x00969F5B
		protected BPC_VolumeCloudTrail_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011925 RID: 71973
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/CloudTraceTail/BPC_VolumeCloudTrail.BPC_VolumeCloudTrail_C";

		// Token: 0x04011926 RID: 71974
		private static IntPtr _ClassPtr;

		// Token: 0x04011927 RID: 71975
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011928 RID: 71976
		internal static int __PropertyOffset_0;

		// Token: 0x04011929 RID: 71977
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401192A RID: 71978
		internal static int __PropertyOffset_1;

		// Token: 0x0401192B RID: 71979
		internal static int __PropertyOffset_2;

		// Token: 0x0401192C RID: 71980
		internal static int __PropertyOffset_3;

		// Token: 0x0401192D RID: 71981
		internal static int __PropertyOffset_4;

		// Token: 0x0401192E RID: 71982
		internal static int __PropertyOffset_5;

		// Token: 0x0401192F RID: 71983
		internal static int __PropertyOffset_6;

		// Token: 0x04011930 RID: 71984
		internal static int __PropertyOffset_7;

		// Token: 0x04011931 RID: 71985
		internal static int __PropertyOffset_8;

		// Token: 0x04011932 RID: 71986
		internal static int __PropertyOffset_9;

		// Token: 0x04011933 RID: 71987
		internal static int __PropertyOffset_10;

		// Token: 0x04011934 RID: 71988
		internal static int __PropertyOffset_11;

		// Token: 0x04011935 RID: 71989
		internal static int __PropertyOffset_12;

		// Token: 0x04011936 RID: 71990
		internal static int __PropertyOffset_13;

		// Token: 0x04011937 RID: 71991
		internal static int __PropertyOffset_14;

		// Token: 0x04011938 RID: 71992
		internal static int __PropertyOffset_15;

		// Token: 0x04011939 RID: 71993
		internal static int __PropertyOffset_16;

		// Token: 0x0401193A RID: 71994
		internal static int __PropertyOffset_17;

		// Token: 0x0401193B RID: 71995
		internal static int __PropertyOffset_18;

		// Token: 0x0401193C RID: 71996
		internal static int __PropertyOffset_19;

		// Token: 0x0401193D RID: 71997
		internal static int __PropertyOffset_20;

		// Token: 0x0401193E RID: 71998
		internal static int __PropertyOffset_21;

		// Token: 0x0401193F RID: 71999
		internal static int __PropertyOffset_22;

		// Token: 0x04011940 RID: 72000
		internal static int __PropertyOffset_23;

		// Token: 0x04011941 RID: 72001
		internal static int __PropertyOffset_24;

		// Token: 0x04011942 RID: 72002
		internal static int __PropertyOffset_25;

		// Token: 0x04011943 RID: 72003
		internal static int __PropertyOffset_26;

		// Token: 0x04011944 RID: 72004
		internal static int __PropertyOffset_27;

		// Token: 0x04011945 RID: 72005
		internal static int __PropertyOffset_28;

		// Token: 0x04011946 RID: 72006
		private static IntPtr __TrailTick_NativeFunctionPtr;

		// Token: 0x04011947 RID: 72007
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011948 RID: 72008
		private static IntPtr __ExecuteUbergraph_BPC_VolumeCloudTrail_NativeFunctionPtr;

		// Token: 0x02009C0A RID: 39946
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032464 RID: 205924
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C0B RID: 39947
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BPC_VolumeCloudTrail_FunctionParams
		{
			// Token: 0x04032465 RID: 205925
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
