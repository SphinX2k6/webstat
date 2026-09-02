using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CC6 RID: 15558
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_FloatingBillboardClouds_Prefab.BP_FloatingBillboardClouds_Prefab_C")]
	[UnrealStructLayout(1552, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1548)]
	public class BP_FloatingBillboardClouds_Prefab_C : AKuroFloatingBillboardCloudPrefabActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024FAF RID: 151471 RVA: 0x009ADABC File Offset: 0x009ABCBC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FloatingBillboardClouds_Prefab_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_FloatingBillboardClouds_Prefab.BP_FloatingBillboardClouds_Prefab_C");
			}
			return BP_FloatingBillboardClouds_Prefab_C._ClassPtr;
		}

		// Token: 0x06024FB0 RID: 151472 RVA: 0x009ADAE0 File Offset: 0x009ABCE0
		public BP_FloatingBillboardClouds_Prefab_C() : this(BuiltinUtils.AllocNativeUObject(BP_FloatingBillboardClouds_Prefab_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024FB1 RID: 151473 RVA: 0x009ADB08 File Offset: 0x009ABD08
		[NullableContext(1)]
		public BP_FloatingBillboardClouds_Prefab_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FloatingBillboardClouds_Prefab_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004EDA RID: 20186
		// (get) Token: 0x06024FB2 RID: 151474 RVA: 0x009ADB3C File Offset: 0x009ABD3C
		// (set) Token: 0x06024FB3 RID: 151475 RVA: 0x009ADB75 File Offset: 0x009ABD75
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004EDB RID: 20187
		// (get) Token: 0x06024FB4 RID: 151476 RVA: 0x009ADB96 File Offset: 0x009ABD96
		// (set) Token: 0x06024FB5 RID: 151477 RVA: 0x009ADBAA File Offset: 0x009ABDAA
		public unsafe UStaticMeshComponent Cloud
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004EDC RID: 20188
		// (get) Token: 0x06024FB6 RID: 151478 RVA: 0x009ADBBF File Offset: 0x009ABDBF
		// (set) Token: 0x06024FB7 RID: 151479 RVA: 0x009ADBD3 File Offset: 0x009ABDD3
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004EDD RID: 20189
		// (get) Token: 0x06024FB8 RID: 151480 RVA: 0x009ADBE8 File Offset: 0x009ABDE8
		// (set) Token: 0x06024FB9 RID: 151481 RVA: 0x009ADBFC File Offset: 0x009ABDFC
		public unsafe UMaterialInstance CloudMatrerial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004EDE RID: 20190
		// (get) Token: 0x06024FBA RID: 151482 RVA: 0x009ADC11 File Offset: 0x009ABE11
		// (set) Token: 0x06024FBB RID: 151483 RVA: 0x009ADC25 File Offset: 0x009ABE25
		public unsafe UMaterialInstanceDynamic CloudDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004EDF RID: 20191
		// (get) Token: 0x06024FBC RID: 151484 RVA: 0x009ADC3A File Offset: 0x009ABE3A
		// (set) Token: 0x06024FBD RID: 151485 RVA: 0x009ADC4E File Offset: 0x009ABE4E
		public unsafe UKuroPDFloatingBillboardCloudPrefab CloudPD
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPDFloatingBillboardCloudPrefab>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004EE0 RID: 20192
		// (get) Token: 0x06024FBE RID: 151486 RVA: 0x009ADC63 File Offset: 0x009ABE63
		// (set) Token: 0x06024FBF RID: 151487 RVA: 0x009ADC73 File Offset: 0x009ABE73
		public unsafe int Number
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004EE1 RID: 20193
		// (get) Token: 0x06024FC0 RID: 151488 RVA: 0x009ADC84 File Offset: 0x009ABE84
		// (set) Token: 0x06024FC1 RID: 151489 RVA: 0x009ADC94 File Offset: 0x009ABE94
		public unsafe int Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004EE2 RID: 20194
		// (get) Token: 0x06024FC2 RID: 151490 RVA: 0x009ADCA8 File Offset: 0x009ABEA8
		// (set) Token: 0x06024FC3 RID: 151491 RVA: 0x009ADCE1 File Offset: 0x009ABEE1
		[Nullable(1)]
		public TArray<UStaticMeshComponent> Childs
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._Childs) == null)
				{
					result = (this._Childs = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Childs.CopyAssign(value);
			}
		}

		// Token: 0x17004EE3 RID: 20195
		// (get) Token: 0x06024FC4 RID: 151492 RVA: 0x009ADCEF File Offset: 0x009ABEEF
		// (set) Token: 0x06024FC5 RID: 151493 RVA: 0x009ADCFF File Offset: 0x009ABEFF
		public unsafe bool First
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004EE4 RID: 20196
		// (get) Token: 0x06024FC6 RID: 151494 RVA: 0x009ADD10 File Offset: 0x009ABF10
		// (set) Token: 0x06024FC7 RID: 151495 RVA: 0x009ADD20 File Offset: 0x009ABF20
		public unsafe int Trans_Sort_Number
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004EE5 RID: 20197
		// (get) Token: 0x06024FC8 RID: 151496 RVA: 0x009ADD31 File Offset: 0x009ABF31
		// (set) Token: 0x06024FC9 RID: 151497 RVA: 0x009ADD41 File Offset: 0x009ABF41
		public unsafe int RelativeHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004EE6 RID: 20198
		// (get) Token: 0x06024FCA RID: 151498 RVA: 0x009ADD52 File Offset: 0x009ABF52
		// (set) Token: 0x06024FCB RID: 151499 RVA: 0x009ADD62 File Offset: 0x009ABF62
		public unsafe float Height_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004EE7 RID: 20199
		// (get) Token: 0x06024FCC RID: 151500 RVA: 0x009ADD73 File Offset: 0x009ABF73
		// (set) Token: 0x06024FCD RID: 151501 RVA: 0x009ADD87 File Offset: 0x009ABF87
		public unsafe FVector CloudScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004EE8 RID: 20200
		// (get) Token: 0x06024FCE RID: 151502 RVA: 0x009ADD9C File Offset: 0x009ABF9C
		// (set) Token: 0x06024FCF RID: 151503 RVA: 0x009ADDB0 File Offset: 0x009ABFB0
		public unsafe FVector Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004EE9 RID: 20201
		// (get) Token: 0x06024FD0 RID: 151504 RVA: 0x009ADDC5 File Offset: 0x009ABFC5
		// (set) Token: 0x06024FD1 RID: 151505 RVA: 0x009ADDD5 File Offset: 0x009ABFD5
		public unsafe float OpacityForSwitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004EEA RID: 20202
		// (get) Token: 0x06024FD2 RID: 151506 RVA: 0x009ADDE6 File Offset: 0x009ABFE6
		// (set) Token: 0x06024FD3 RID: 151507 RVA: 0x009ADDF6 File Offset: 0x009ABFF6
		public unsafe float ChangeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004EEB RID: 20203
		// (get) Token: 0x06024FD4 RID: 151508 RVA: 0x009ADE07 File Offset: 0x009AC007
		// (set) Token: 0x06024FD5 RID: 151509 RVA: 0x009ADE17 File Offset: 0x009AC017
		public unsafe bool Forward
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004EEC RID: 20204
		// (get) Token: 0x06024FD6 RID: 151510 RVA: 0x009ADE28 File Offset: 0x009AC028
		// (set) Token: 0x06024FD7 RID: 151511 RVA: 0x009ADE38 File Offset: 0x009AC038
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004EED RID: 20205
		// (get) Token: 0x06024FD8 RID: 151512 RVA: 0x009ADE49 File Offset: 0x009AC049
		// (set) Token: 0x06024FD9 RID: 151513 RVA: 0x009ADE59 File Offset: 0x009AC059
		public unsafe bool TimeIni
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004EEE RID: 20206
		// (get) Token: 0x06024FDA RID: 151514 RVA: 0x009ADE6A File Offset: 0x009AC06A
		// (set) Token: 0x06024FDB RID: 151515 RVA: 0x009ADE7A File Offset: 0x009AC07A
		public unsafe bool Stop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004EEF RID: 20207
		// (get) Token: 0x06024FDC RID: 151516 RVA: 0x009ADE8B File Offset: 0x009AC08B
		// (set) Token: 0x06024FDD RID: 151517 RVA: 0x009ADE9F File Offset: 0x009AC09F
		public unsafe FVector2D CloudDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004EF0 RID: 20208
		// (get) Token: 0x06024FDE RID: 151518 RVA: 0x009ADEB4 File Offset: 0x009AC0B4
		// (set) Token: 0x06024FDF RID: 151519 RVA: 0x009ADEC8 File Offset: 0x009AC0C8
		public unsafe FVectorDouble CenterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004EF1 RID: 20209
		// (get) Token: 0x06024FE0 RID: 151520 RVA: 0x009ADEDD File Offset: 0x009AC0DD
		// (set) Token: 0x06024FE1 RID: 151521 RVA: 0x009ADEED File Offset: 0x009AC0ED
		public unsafe float StepDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004EF2 RID: 20210
		// (get) Token: 0x06024FE2 RID: 151522 RVA: 0x009ADEFE File Offset: 0x009AC0FE
		// (set) Token: 0x06024FE3 RID: 151523 RVA: 0x009ADF0E File Offset: 0x009AC10E
		public unsafe int CloudRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004EF3 RID: 20211
		// (get) Token: 0x06024FE4 RID: 151524 RVA: 0x009ADF1F File Offset: 0x009AC11F
		// (set) Token: 0x06024FE5 RID: 151525 RVA: 0x009ADF2F File Offset: 0x009AC12F
		public unsafe bool initDone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004EF4 RID: 20212
		// (get) Token: 0x06024FE6 RID: 151526 RVA: 0x009ADF40 File Offset: 0x009AC140
		// (set) Token: 0x06024FE7 RID: 151527 RVA: 0x009ADF50 File Offset: 0x009AC150
		public unsafe float CloudSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17004EF5 RID: 20213
		// (get) Token: 0x06024FE8 RID: 151528 RVA: 0x009ADF61 File Offset: 0x009AC161
		// (set) Token: 0x06024FE9 RID: 151529 RVA: 0x009ADF75 File Offset: 0x009AC175
		public unsafe FVectorDouble CloudPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17004EF6 RID: 20214
		// (get) Token: 0x06024FEA RID: 151530 RVA: 0x009ADF8A File Offset: 0x009AC18A
		// (set) Token: 0x06024FEB RID: 151531 RVA: 0x009ADF9A File Offset: 0x009AC19A
		public unsafe int CloudDissolveDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingBillboardClouds_Prefab_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x06024FEC RID: 151532 RVA: 0x009ADFAC File Offset: 0x009AC1AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCameraLocation(ref FVectorDouble CameraPosition)
		{
			BP_FloatingBillboardClouds_Prefab_C.__GetCameraLocation_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_Prefab_C.__GetCameraLocation_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_FloatingBillboardClouds_Prefab_C.__GetCameraLocation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_Prefab_C.__GetCameraLocation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CameraPosition = CameraPosition;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__GetCameraLocation_NativeFunctionPtr, (void*)ptr);
			CameraPosition = ptr->CameraPosition;
		}

		// Token: 0x06024FED RID: 151533 RVA: 0x009AE008 File Offset: 0x009AC208
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CloudDisappear(FVectorDouble CameraPosition)
		{
			BP_FloatingBillboardClouds_Prefab_C.__CloudDisappear_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_Prefab_C.__CloudDisappear_FunctionParams[(UIntPtr)527] + 15L / (long)sizeof(BP_FloatingBillboardClouds_Prefab_C.__CloudDisappear_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_Prefab_C.__CloudDisappear_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CameraPosition = CameraPosition;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__CloudDisappear_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024FEE RID: 151534 RVA: 0x009AE054 File Offset: 0x009AC254
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CloudChange(float DeltaSeconds)
		{
			BP_FloatingBillboardClouds_Prefab_C.__CloudChange_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_Prefab_C.__CloudChange_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_FloatingBillboardClouds_Prefab_C.__CloudChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_Prefab_C.__CloudChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__CloudChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024FEF RID: 151535 RVA: 0x009AE09A File Offset: 0x009AC29A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Active()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__Active_NativeFunctionPtr, null);
		}

		// Token: 0x06024FF0 RID: 151536 RVA: 0x009AE0B0 File Offset: 0x009AC2B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Timer(float DeltaSeconds, float Speed, bool forward, ref float Progress)
		{
			BP_FloatingBillboardClouds_Prefab_C.__Timer_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_Prefab_C.__Timer_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_FloatingBillboardClouds_Prefab_C.__Timer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_Prefab_C.__Timer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			ptr->Speed = Speed;
			ptr->forward = forward;
			ptr->Progress = Progress;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__Timer_NativeFunctionPtr, (void*)ptr);
			Progress = ptr->Progress;
		}

		// Token: 0x06024FF1 RID: 151537 RVA: 0x009AE116 File Offset: 0x009AC316
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloudInitial()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__CloudInitial_NativeFunctionPtr, null);
		}

		// Token: 0x06024FF2 RID: 151538 RVA: 0x009AE12C File Offset: 0x009AC32C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CloudMove(float DeltaSeconds)
		{
			BP_FloatingBillboardClouds_Prefab_C.__CloudMove_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_Prefab_C.__CloudMove_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BP_FloatingBillboardClouds_Prefab_C.__CloudMove_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_Prefab_C.__CloudMove_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__CloudMove_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024FF3 RID: 151539 RVA: 0x009AE175 File Offset: 0x009AC375
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024FF4 RID: 151540 RVA: 0x009AE189 File Offset: 0x009AC389
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024FF5 RID: 151541 RVA: 0x009AE19E File Offset: 0x009AC39E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024FF6 RID: 151542 RVA: 0x009AE1B2 File Offset: 0x009AC3B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024FF7 RID: 151543 RVA: 0x009AE1C8 File Offset: 0x009AC3C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FloatingBillboardClouds_Prefab_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_Prefab_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatingBillboardClouds_Prefab_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_Prefab_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024FF8 RID: 151544 RVA: 0x009AE210 File Offset: 0x009AC410
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FloatingBillboardClouds_Prefab_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_Prefab_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatingBillboardClouds_Prefab_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_Prefab_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024FF9 RID: 151545 RVA: 0x009AE258 File Offset: 0x009AC458
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_FloatingBillboardClouds_Prefab_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_Prefab_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatingBillboardClouds_Prefab_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_Prefab_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024FFA RID: 151546 RVA: 0x009AE2A0 File Offset: 0x009AC4A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_FloatingBillboardClouds_Prefab_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_Prefab_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatingBillboardClouds_Prefab_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_Prefab_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024FFB RID: 151547 RVA: 0x009AE2E8 File Offset: 0x009AC4E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FloatingBillboardClouds_Prefab(int EntryPoint)
		{
			BP_FloatingBillboardClouds_Prefab_C.__ExecuteUbergraph_BP_FloatingBillboardClouds_Prefab_FunctionParams* ptr = stackalloc BP_FloatingBillboardClouds_Prefab_C.__ExecuteUbergraph_BP_FloatingBillboardClouds_Prefab_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_FloatingBillboardClouds_Prefab_C.__ExecuteUbergraph_BP_FloatingBillboardClouds_Prefab_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingBillboardClouds_Prefab_C.__ExecuteUbergraph_BP_FloatingBillboardClouds_Prefab_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingBillboardClouds_Prefab_C.__ExecuteUbergraph_BP_FloatingBillboardClouds_Prefab_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024FFC RID: 151548 RVA: 0x009AE32F File Offset: 0x009AC52F
		protected BP_FloatingBillboardClouds_Prefab_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401300F RID: 77839
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_FloatingBillboardClouds_Prefab.BP_FloatingBillboardClouds_Prefab_C";

		// Token: 0x04013010 RID: 77840
		private static IntPtr _ClassPtr;

		// Token: 0x04013011 RID: 77841
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013012 RID: 77842
		internal static int __PropertyOffset_0;

		// Token: 0x04013013 RID: 77843
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013014 RID: 77844
		internal static int __PropertyOffset_1;

		// Token: 0x04013015 RID: 77845
		internal static int __PropertyOffset_2;

		// Token: 0x04013016 RID: 77846
		internal static int __PropertyOffset_3;

		// Token: 0x04013017 RID: 77847
		internal static int __PropertyOffset_4;

		// Token: 0x04013018 RID: 77848
		internal static int __PropertyOffset_5;

		// Token: 0x04013019 RID: 77849
		internal static int __PropertyOffset_6;

		// Token: 0x0401301A RID: 77850
		internal static int __PropertyOffset_7;

		// Token: 0x0401301B RID: 77851
		internal static int __PropertyOffset_8;

		// Token: 0x0401301C RID: 77852
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _Childs;

		// Token: 0x0401301D RID: 77853
		internal static int __PropertyOffset_9;

		// Token: 0x0401301E RID: 77854
		internal static int __PropertyOffset_10;

		// Token: 0x0401301F RID: 77855
		internal static int __PropertyOffset_11;

		// Token: 0x04013020 RID: 77856
		internal static int __PropertyOffset_12;

		// Token: 0x04013021 RID: 77857
		internal static int __PropertyOffset_13;

		// Token: 0x04013022 RID: 77858
		internal static int __PropertyOffset_14;

		// Token: 0x04013023 RID: 77859
		internal static int __PropertyOffset_15;

		// Token: 0x04013024 RID: 77860
		internal static int __PropertyOffset_16;

		// Token: 0x04013025 RID: 77861
		internal static int __PropertyOffset_17;

		// Token: 0x04013026 RID: 77862
		internal static int __PropertyOffset_18;

		// Token: 0x04013027 RID: 77863
		internal static int __PropertyOffset_19;

		// Token: 0x04013028 RID: 77864
		internal static int __PropertyOffset_20;

		// Token: 0x04013029 RID: 77865
		internal static int __PropertyOffset_21;

		// Token: 0x0401302A RID: 77866
		internal static int __PropertyOffset_22;

		// Token: 0x0401302B RID: 77867
		internal static int __PropertyOffset_23;

		// Token: 0x0401302C RID: 77868
		internal static int __PropertyOffset_24;

		// Token: 0x0401302D RID: 77869
		internal static int __PropertyOffset_25;

		// Token: 0x0401302E RID: 77870
		internal static int __PropertyOffset_26;

		// Token: 0x0401302F RID: 77871
		internal static int __PropertyOffset_27;

		// Token: 0x04013030 RID: 77872
		internal static int __PropertyOffset_28;

		// Token: 0x04013031 RID: 77873
		private static IntPtr __GetCameraLocation_NativeFunctionPtr;

		// Token: 0x04013032 RID: 77874
		private static IntPtr __CloudDisappear_NativeFunctionPtr;

		// Token: 0x04013033 RID: 77875
		private static IntPtr __CloudChange_NativeFunctionPtr;

		// Token: 0x04013034 RID: 77876
		private static IntPtr __Active_NativeFunctionPtr;

		// Token: 0x04013035 RID: 77877
		private static IntPtr __Timer_NativeFunctionPtr;

		// Token: 0x04013036 RID: 77878
		private static IntPtr __CloudInitial_NativeFunctionPtr;

		// Token: 0x04013037 RID: 77879
		private static IntPtr __CloudMove_NativeFunctionPtr;

		// Token: 0x04013038 RID: 77880
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013039 RID: 77881
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401303A RID: 77882
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401303B RID: 77883
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401303C RID: 77884
		private static IntPtr __ExecuteUbergraph_BP_FloatingBillboardClouds_Prefab_NativeFunctionPtr;

		// Token: 0x02009EAD RID: 40621
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __GetCameraLocation_FunctionParams
		{
			// Token: 0x0403296E RID: 207214
			[FieldOffset(0)]
			public FVectorDouble CameraPosition;
		}

		// Token: 0x02009EAE RID: 40622
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 512)]
		protected ref struct __CloudDisappear_FunctionParams
		{
			// Token: 0x0403296F RID: 207215
			[FieldOffset(0)]
			public FVectorDouble CameraPosition;
		}

		// Token: 0x02009EAF RID: 40623
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __CloudChange_FunctionParams
		{
			// Token: 0x04032970 RID: 207216
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EB0 RID: 40624
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __Timer_FunctionParams
		{
			// Token: 0x04032971 RID: 207217
			[FieldOffset(0)]
			public float DeltaSeconds;

			// Token: 0x04032972 RID: 207218
			[FieldOffset(4)]
			public float Speed;

			// Token: 0x04032973 RID: 207219
			[FieldOffset(8)]
			public bool forward;

			// Token: 0x04032974 RID: 207220
			[FieldOffset(12)]
			public float Progress;
		}

		// Token: 0x02009EB1 RID: 40625
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __CloudMove_FunctionParams
		{
			// Token: 0x04032975 RID: 207221
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EB2 RID: 40626
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032976 RID: 207222
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EB3 RID: 40627
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032977 RID: 207223
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EB4 RID: 40628
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_FloatingBillboardClouds_Prefab_FunctionParams
		{
			// Token: 0x04032978 RID: 207224
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
