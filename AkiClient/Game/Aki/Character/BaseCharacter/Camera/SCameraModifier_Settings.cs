using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004312 RID: 17170
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_Settings.SCameraModifier_Settings")]
	[UnrealStructLayout(360, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 360)]
	public class SCameraModifier_Settings : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D7CD RID: 186317 RVA: 0x00AC1B3D File Offset: 0x00ABFD3D
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraModifier_Settings._ScriptStructPtr != 0) ? SCameraModifier_Settings._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_Settings.SCameraModifier_Settings", ref SCameraModifier_Settings._ScriptStructPtr);
		}

		// Token: 0x17007C54 RID: 31828
		// (get) Token: 0x0602D7CE RID: 186318 RVA: 0x00AC1B61 File Offset: 0x00ABFD61
		// (set) Token: 0x0602D7CF RID: 186319 RVA: 0x00AC1B71 File Offset: 0x00ABFD71
		public unsafe int Priority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007C55 RID: 31829
		// (get) Token: 0x0602D7D0 RID: 186320 RVA: 0x00AC1B82 File Offset: 0x00ABFD82
		// (set) Token: 0x0602D7D1 RID: 186321 RVA: 0x00AC1B92 File Offset: 0x00ABFD92
		public unsafe bool IsModifiedArmLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C56 RID: 31830
		// (get) Token: 0x0602D7D2 RID: 186322 RVA: 0x00AC1BA3 File Offset: 0x00ABFDA3
		// (set) Token: 0x0602D7D3 RID: 186323 RVA: 0x00AC1BB3 File Offset: 0x00ABFDB3
		public unsafe float ArmLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007C57 RID: 31831
		// (get) Token: 0x0602D7D4 RID: 186324 RVA: 0x00AC1BC4 File Offset: 0x00ABFDC4
		// (set) Token: 0x0602D7D5 RID: 186325 RVA: 0x00AC1BD4 File Offset: 0x00ABFDD4
		public unsafe float ArmLengthAdditional
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007C58 RID: 31832
		// (get) Token: 0x0602D7D6 RID: 186326 RVA: 0x00AC1BE5 File Offset: 0x00ABFDE5
		// (set) Token: 0x0602D7D7 RID: 186327 RVA: 0x00AC1BF5 File Offset: 0x00ABFDF5
		public unsafe bool IsModifiedArmRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C59 RID: 31833
		// (get) Token: 0x0602D7D8 RID: 186328 RVA: 0x00AC1C06 File Offset: 0x00ABFE06
		// (set) Token: 0x0602D7D9 RID: 186329 RVA: 0x00AC1C16 File Offset: 0x00ABFE16
		public unsafe bool IsModifiedArmRotationRoll
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C5A RID: 31834
		// (get) Token: 0x0602D7DA RID: 186330 RVA: 0x00AC1C27 File Offset: 0x00ABFE27
		// (set) Token: 0x0602D7DB RID: 186331 RVA: 0x00AC1C37 File Offset: 0x00ABFE37
		public unsafe bool IsModifiedArmRotationPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C5B RID: 31835
		// (get) Token: 0x0602D7DC RID: 186332 RVA: 0x00AC1C48 File Offset: 0x00ABFE48
		// (set) Token: 0x0602D7DD RID: 186333 RVA: 0x00AC1C58 File Offset: 0x00ABFE58
		public unsafe bool IsModifiedArmRotationYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C5C RID: 31836
		// (get) Token: 0x0602D7DE RID: 186334 RVA: 0x00AC1C69 File Offset: 0x00ABFE69
		// (set) Token: 0x0602D7DF RID: 186335 RVA: 0x00AC1C7D File Offset: 0x00ABFE7D
		public unsafe TEnumAsByte<ECameraModifyParamType> ArmRotationType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007C5D RID: 31837
		// (get) Token: 0x0602D7E0 RID: 186336 RVA: 0x00AC1C92 File Offset: 0x00ABFE92
		// (set) Token: 0x0602D7E1 RID: 186337 RVA: 0x00AC1CA6 File Offset: 0x00ABFEA6
		public unsafe FRotator ArmRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007C5E RID: 31838
		// (get) Token: 0x0602D7E2 RID: 186338 RVA: 0x00AC1CBB File Offset: 0x00ABFEBB
		// (set) Token: 0x0602D7E3 RID: 186339 RVA: 0x00AC1CCF File Offset: 0x00ABFECF
		[Nullable(2)]
		public unsafe UCurveVector ArmRotationCurve
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveVector>(base.NativePtr / (IntPtr)sizeof(void*) + SCameraModifier_Settings.__PropertyOffset_10);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SCameraModifier_Settings.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17007C5F RID: 31839
		// (get) Token: 0x0602D7E4 RID: 186340 RVA: 0x00AC1CE4 File Offset: 0x00ABFEE4
		// (set) Token: 0x0602D7E5 RID: 186341 RVA: 0x00AC1CF8 File Offset: 0x00ABFEF8
		public unsafe TEnumAsByte<ECameraModifyParamType> ArmRotationAdditionalType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007C60 RID: 31840
		// (get) Token: 0x0602D7E6 RID: 186342 RVA: 0x00AC1D0D File Offset: 0x00ABFF0D
		// (set) Token: 0x0602D7E7 RID: 186343 RVA: 0x00AC1D21 File Offset: 0x00ABFF21
		public unsafe FRotator ArmRotationAdditional
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007C61 RID: 31841
		// (get) Token: 0x0602D7E8 RID: 186344 RVA: 0x00AC1D36 File Offset: 0x00ABFF36
		// (set) Token: 0x0602D7E9 RID: 186345 RVA: 0x00AC1D4A File Offset: 0x00ABFF4A
		[Nullable(2)]
		public unsafe UCurveVector ArmRotationAdditionalCurve
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveVector>(base.NativePtr / (IntPtr)sizeof(void*) + SCameraModifier_Settings.__PropertyOffset_13);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SCameraModifier_Settings.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17007C62 RID: 31842
		// (get) Token: 0x0602D7EA RID: 186346 RVA: 0x00AC1D5F File Offset: 0x00ABFF5F
		// (set) Token: 0x0602D7EB RID: 186347 RVA: 0x00AC1D6F File Offset: 0x00ABFF6F
		public unsafe bool IsModifiedCameraOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C63 RID: 31843
		// (get) Token: 0x0602D7EC RID: 186348 RVA: 0x00AC1D80 File Offset: 0x00ABFF80
		// (set) Token: 0x0602D7ED RID: 186349 RVA: 0x00AC1D90 File Offset: 0x00ABFF90
		public unsafe bool IsModifiedCameraOffsetX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C64 RID: 31844
		// (get) Token: 0x0602D7EE RID: 186350 RVA: 0x00AC1DA1 File Offset: 0x00ABFFA1
		// (set) Token: 0x0602D7EF RID: 186351 RVA: 0x00AC1DB1 File Offset: 0x00ABFFB1
		public unsafe bool IsModifiedCameraOffsetY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C65 RID: 31845
		// (get) Token: 0x0602D7F0 RID: 186352 RVA: 0x00AC1DC2 File Offset: 0x00ABFFC2
		// (set) Token: 0x0602D7F1 RID: 186353 RVA: 0x00AC1DD2 File Offset: 0x00ABFFD2
		public unsafe bool IsModifiedCameraOffsetZ
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C66 RID: 31846
		// (get) Token: 0x0602D7F2 RID: 186354 RVA: 0x00AC1DE3 File Offset: 0x00ABFFE3
		// (set) Token: 0x0602D7F3 RID: 186355 RVA: 0x00AC1DF7 File Offset: 0x00ABFFF7
		public unsafe TEnumAsByte<ECameraModifyParamType> CameraOffsetType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17007C67 RID: 31847
		// (get) Token: 0x0602D7F4 RID: 186356 RVA: 0x00AC1E0C File Offset: 0x00AC000C
		// (set) Token: 0x0602D7F5 RID: 186357 RVA: 0x00AC1E20 File Offset: 0x00AC0020
		public unsafe FVector CameraOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17007C68 RID: 31848
		// (get) Token: 0x0602D7F6 RID: 186358 RVA: 0x00AC1E35 File Offset: 0x00AC0035
		// (set) Token: 0x0602D7F7 RID: 186359 RVA: 0x00AC1E49 File Offset: 0x00AC0049
		[Nullable(2)]
		public unsafe UCurveVector CameraOffsetCurve
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveVector>(base.NativePtr / (IntPtr)sizeof(void*) + SCameraModifier_Settings.__PropertyOffset_20);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SCameraModifier_Settings.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17007C69 RID: 31849
		// (get) Token: 0x0602D7F8 RID: 186360 RVA: 0x00AC1E5E File Offset: 0x00AC005E
		// (set) Token: 0x0602D7F9 RID: 186361 RVA: 0x00AC1E72 File Offset: 0x00AC0072
		public unsafe TEnumAsByte<ECameraModifyParamType> CameraOffsetAdditionalType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17007C6A RID: 31850
		// (get) Token: 0x0602D7FA RID: 186362 RVA: 0x00AC1E87 File Offset: 0x00AC0087
		// (set) Token: 0x0602D7FB RID: 186363 RVA: 0x00AC1E9B File Offset: 0x00AC009B
		public unsafe FVector CameraOffsetAdditional
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17007C6B RID: 31851
		// (get) Token: 0x0602D7FC RID: 186364 RVA: 0x00AC1EB0 File Offset: 0x00AC00B0
		// (set) Token: 0x0602D7FD RID: 186365 RVA: 0x00AC1EC4 File Offset: 0x00AC00C4
		[Nullable(2)]
		public unsafe UCurveVector CameraOffsetAdditionalCurve
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveVector>(base.NativePtr / (IntPtr)sizeof(void*) + SCameraModifier_Settings.__PropertyOffset_23);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SCameraModifier_Settings.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17007C6C RID: 31852
		// (get) Token: 0x0602D7FE RID: 186366 RVA: 0x00AC1ED9 File Offset: 0x00AC00D9
		// (set) Token: 0x0602D7FF RID: 186367 RVA: 0x00AC1EE9 File Offset: 0x00AC00E9
		public unsafe bool IsModifiedCameraFov
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C6D RID: 31853
		// (get) Token: 0x0602D800 RID: 186368 RVA: 0x00AC1EFA File Offset: 0x00AC00FA
		// (set) Token: 0x0602D801 RID: 186369 RVA: 0x00AC1F0A File Offset: 0x00AC010A
		public unsafe bool StopModifyOnMontageEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C6E RID: 31854
		// (get) Token: 0x0602D802 RID: 186370 RVA: 0x00AC1F1B File Offset: 0x00AC011B
		// (set) Token: 0x0602D803 RID: 186371 RVA: 0x00AC1F2B File Offset: 0x00AC012B
		public unsafe float CameraFov
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17007C6F RID: 31855
		// (get) Token: 0x0602D804 RID: 186372 RVA: 0x00AC1F3C File Offset: 0x00AC013C
		// (set) Token: 0x0602D805 RID: 186373 RVA: 0x00AC1F4C File Offset: 0x00AC014C
		public unsafe bool OverrideCameraInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C70 RID: 31856
		// (get) Token: 0x0602D806 RID: 186374 RVA: 0x00AC1F5D File Offset: 0x00AC015D
		// (set) Token: 0x0602D807 RID: 186375 RVA: 0x00AC1F6D File Offset: 0x00AC016D
		public unsafe bool ResetFinalArmRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C71 RID: 31857
		// (get) Token: 0x0602D808 RID: 186376 RVA: 0x00AC1F7E File Offset: 0x00AC017E
		// (set) Token: 0x0602D809 RID: 186377 RVA: 0x00AC1F8E File Offset: 0x00AC018E
		public unsafe bool IsResetFinalArmRotationToSpecificPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C72 RID: 31858
		// (get) Token: 0x0602D80A RID: 186378 RVA: 0x00AC1F9F File Offset: 0x00AC019F
		// (set) Token: 0x0602D80B RID: 186379 RVA: 0x00AC1FAF File Offset: 0x00AC01AF
		public unsafe float ResetFinalArmRotationToSpecificPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17007C73 RID: 31859
		// (get) Token: 0x0602D80C RID: 186380 RVA: 0x00AC1FC0 File Offset: 0x00AC01C0
		// (set) Token: 0x0602D80D RID: 186381 RVA: 0x00AC1FD0 File Offset: 0x00AC01D0
		public unsafe bool IsResetFinalArmRotationToSpecificYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C74 RID: 31860
		// (get) Token: 0x0602D80E RID: 186382 RVA: 0x00AC1FE1 File Offset: 0x00AC01E1
		// (set) Token: 0x0602D80F RID: 186383 RVA: 0x00AC1FF1 File Offset: 0x00AC01F1
		public unsafe float ResetFinalArmRotationToSpecificYaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17007C75 RID: 31861
		// (get) Token: 0x0602D810 RID: 186384 RVA: 0x00AC2002 File Offset: 0x00AC0202
		// (set) Token: 0x0602D811 RID: 186385 RVA: 0x00AC2012 File Offset: 0x00AC0212
		public unsafe bool ResetFinalArmLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C76 RID: 31862
		// (get) Token: 0x0602D812 RID: 186386 RVA: 0x00AC2023 File Offset: 0x00AC0223
		// (set) Token: 0x0602D813 RID: 186387 RVA: 0x00AC2033 File Offset: 0x00AC0233
		public unsafe bool IsResetFinalArmLengthToSpecificValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C77 RID: 31863
		// (get) Token: 0x0602D814 RID: 186388 RVA: 0x00AC2044 File Offset: 0x00AC0244
		// (set) Token: 0x0602D815 RID: 186389 RVA: 0x00AC2054 File Offset: 0x00AC0254
		public unsafe float ResetFinalArmLengthToSpecificValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17007C78 RID: 31864
		// (get) Token: 0x0602D816 RID: 186390 RVA: 0x00AC2065 File Offset: 0x00AC0265
		// (set) Token: 0x0602D817 RID: 186391 RVA: 0x00AC2075 File Offset: 0x00AC0275
		public unsafe bool IsResetFinalArmLengthToDynamicValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C79 RID: 31865
		// (get) Token: 0x0602D818 RID: 186392 RVA: 0x00AC2088 File Offset: 0x00AC0288
		// (set) Token: 0x0602D819 RID: 186393 RVA: 0x00AC20CB File Offset: 0x00AC02CB
		[Nullable(1)]
		public TArray<SCameraModifier_Settings_ArmLengthDynamicValue> ResetFinalArmLengthToDynamicValue
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SCameraModifier_Settings_ArmLengthDynamicValue> result;
				if ((result = this._ResetFinalArmLengthToDynamicValue) == null)
				{
					result = (this._ResetFinalArmLengthToDynamicValue = new TArray<SCameraModifier_Settings_ArmLengthDynamicValue>(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_37, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ResetFinalArmLengthToDynamicValue.CopyAssign(value);
			}
		}

		// Token: 0x17007C7A RID: 31866
		// (get) Token: 0x0602D81A RID: 186394 RVA: 0x00AC20D9 File Offset: 0x00AC02D9
		// (set) Token: 0x0602D81B RID: 186395 RVA: 0x00AC20E9 File Offset: 0x00AC02E9
		public unsafe bool IsLockInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_38) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_38) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C7B RID: 31867
		// (get) Token: 0x0602D81C RID: 186396 RVA: 0x00AC20FA File Offset: 0x00AC02FA
		// (set) Token: 0x0602D81D RID: 186397 RVA: 0x00AC210A File Offset: 0x00AC030A
		public unsafe bool IsLerpArmLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_39) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_39) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C7C RID: 31868
		// (get) Token: 0x0602D81E RID: 186398 RVA: 0x00AC211B File Offset: 0x00AC031B
		// (set) Token: 0x0602D81F RID: 186399 RVA: 0x00AC212B File Offset: 0x00AC032B
		public unsafe bool IsSwitchModifier
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C7D RID: 31869
		// (get) Token: 0x0602D820 RID: 186400 RVA: 0x00AC213C File Offset: 0x00AC033C
		// (set) Token: 0x0602D821 RID: 186401 RVA: 0x00AC214C File Offset: 0x00AC034C
		public unsafe bool IsForcePlayModify
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_41) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_41) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C7E RID: 31870
		// (get) Token: 0x0602D822 RID: 186402 RVA: 0x00AC215D File Offset: 0x00AC035D
		// (set) Token: 0x0602D823 RID: 186403 RVA: 0x00AC216D File Offset: 0x00AC036D
		public unsafe bool StopModifyOnZoomInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_42) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_42) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C7F RID: 31871
		// (get) Token: 0x0602D824 RID: 186404 RVA: 0x00AC2180 File Offset: 0x00AC0380
		// (set) Token: 0x0602D825 RID: 186405 RVA: 0x00AC21C3 File Offset: 0x00AC03C3
		[Nullable(1)]
		public SCameraModifier_SettingsAdditional ModifySettingsAdditional
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SCameraModifier_SettingsAdditional result;
				if ((result = this._ModifySettingsAdditional) == null)
				{
					result = (this._ModifySettingsAdditional = new SCameraModifier_SettingsAdditional(base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_43, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCameraModifier_SettingsAdditional.StaticStruct(), base.NativePtr + (IntPtr)SCameraModifier_Settings.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D826 RID: 186406 RVA: 0x00AC21E4 File Offset: 0x00AC03E4
		public SCameraModifier_Settings()
		{
		}

		// Token: 0x0602D827 RID: 186407 RVA: 0x00AC21EC File Offset: 0x00AC03EC
		[NullableContext(1)]
		public SCameraModifier_Settings(int Priority, bool IsModifiedArmLength, float ArmLength, float ArmLengthAdditional, bool IsModifiedArmRotation, bool IsModifiedArmRotationRoll, bool IsModifiedArmRotationPitch, bool IsModifiedArmRotationYaw, [Nullable(0)] TEnumAsByte<ECameraModifyParamType> ArmRotationType, FRotator ArmRotation, UCurveVector ArmRotationCurve, [Nullable(0)] TEnumAsByte<ECameraModifyParamType> ArmRotationAdditionalType, FRotator ArmRotationAdditional, UCurveVector ArmRotationAdditionalCurve, bool IsModifiedCameraOffset, bool IsModifiedCameraOffsetX, bool IsModifiedCameraOffsetY, bool IsModifiedCameraOffsetZ, [Nullable(0)] TEnumAsByte<ECameraModifyParamType> CameraOffsetType, FVector CameraOffset, UCurveVector CameraOffsetCurve, [Nullable(0)] TEnumAsByte<ECameraModifyParamType> CameraOffsetAdditionalType, FVector CameraOffsetAdditional, UCurveVector CameraOffsetAdditionalCurve, bool IsModifiedCameraFov, bool StopModifyOnMontageEnd, float CameraFov, bool OverrideCameraInput, bool ResetFinalArmRotation, bool IsResetFinalArmRotationToSpecificPitch, float ResetFinalArmRotationToSpecificPitch, bool IsResetFinalArmRotationToSpecificYaw, float ResetFinalArmRotationToSpecificYaw, bool ResetFinalArmLength, bool IsResetFinalArmLengthToSpecificValue, float ResetFinalArmLengthToSpecificValue, bool IsResetFinalArmLengthToDynamicValue, TArray<SCameraModifier_Settings_ArmLengthDynamicValue> ResetFinalArmLengthToDynamicValue, bool IsLockInput, bool IsLerpArmLocation, bool IsSwitchModifier, bool IsForcePlayModify, bool StopModifyOnZoomInput, SCameraModifier_SettingsAdditional ModifySettingsAdditional)
		{
			this.Priority = Priority;
			this.IsModifiedArmLength = IsModifiedArmLength;
			this.ArmLength = ArmLength;
			this.ArmLengthAdditional = ArmLengthAdditional;
			this.IsModifiedArmRotation = IsModifiedArmRotation;
			this.IsModifiedArmRotationRoll = IsModifiedArmRotationRoll;
			this.IsModifiedArmRotationPitch = IsModifiedArmRotationPitch;
			this.IsModifiedArmRotationYaw = IsModifiedArmRotationYaw;
			this.ArmRotationType = ArmRotationType;
			this.ArmRotation = ArmRotation;
			this.ArmRotationCurve = ArmRotationCurve;
			this.ArmRotationAdditionalType = ArmRotationAdditionalType;
			this.ArmRotationAdditional = ArmRotationAdditional;
			this.ArmRotationAdditionalCurve = ArmRotationAdditionalCurve;
			this.IsModifiedCameraOffset = IsModifiedCameraOffset;
			this.IsModifiedCameraOffsetX = IsModifiedCameraOffsetX;
			this.IsModifiedCameraOffsetY = IsModifiedCameraOffsetY;
			this.IsModifiedCameraOffsetZ = IsModifiedCameraOffsetZ;
			this.CameraOffsetType = CameraOffsetType;
			this.CameraOffset = CameraOffset;
			this.CameraOffsetCurve = CameraOffsetCurve;
			this.CameraOffsetAdditionalType = CameraOffsetAdditionalType;
			this.CameraOffsetAdditional = CameraOffsetAdditional;
			this.CameraOffsetAdditionalCurve = CameraOffsetAdditionalCurve;
			this.IsModifiedCameraFov = IsModifiedCameraFov;
			this.StopModifyOnMontageEnd = StopModifyOnMontageEnd;
			this.CameraFov = CameraFov;
			this.OverrideCameraInput = OverrideCameraInput;
			this.ResetFinalArmRotation = ResetFinalArmRotation;
			this.IsResetFinalArmRotationToSpecificPitch = IsResetFinalArmRotationToSpecificPitch;
			this.ResetFinalArmRotationToSpecificPitch = ResetFinalArmRotationToSpecificPitch;
			this.IsResetFinalArmRotationToSpecificYaw = IsResetFinalArmRotationToSpecificYaw;
			this.ResetFinalArmRotationToSpecificYaw = ResetFinalArmRotationToSpecificYaw;
			this.ResetFinalArmLength = ResetFinalArmLength;
			this.IsResetFinalArmLengthToSpecificValue = IsResetFinalArmLengthToSpecificValue;
			this.ResetFinalArmLengthToSpecificValue = ResetFinalArmLengthToSpecificValue;
			this.IsResetFinalArmLengthToDynamicValue = IsResetFinalArmLengthToDynamicValue;
			this.ResetFinalArmLengthToDynamicValue = ResetFinalArmLengthToDynamicValue;
			this.IsLockInput = IsLockInput;
			this.IsLerpArmLocation = IsLerpArmLocation;
			this.IsSwitchModifier = IsSwitchModifier;
			this.IsForcePlayModify = IsForcePlayModify;
			this.StopModifyOnZoomInput = StopModifyOnZoomInput;
			this.ModifySettingsAdditional = ModifySettingsAdditional;
		}

		// Token: 0x0602D828 RID: 186408 RVA: 0x00AC235C File Offset: 0x00AC055C
		protected override IntPtr GetUStructPtr()
		{
			return SCameraModifier_Settings.StaticStruct();
		}

		// Token: 0x0602D829 RID: 186409 RVA: 0x00AC2368 File Offset: 0x00AC0568
		[NullableContext(2)]
		public SCameraModifier_Settings(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D82A RID: 186410 RVA: 0x00AC2372 File Offset: 0x00AC0572
		public SCameraModifier_Settings(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D82B RID: 186411 RVA: 0x00AC237D File Offset: 0x00AC057D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraModifier_Settings(Pointer, false, true);
		}

		// Token: 0x0602D82C RID: 186412 RVA: 0x00AC2387 File Offset: 0x00AC0587
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraModifier_Settings(Pointer, MemoryOwner);
		}

		// Token: 0x04019A65 RID: 105061
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_Settings.SCameraModifier_Settings";

		// Token: 0x04019A66 RID: 105062
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019A67 RID: 105063
		internal static int __PropertyOffset_0;

		// Token: 0x04019A68 RID: 105064
		internal static int __PropertyOffset_1;

		// Token: 0x04019A69 RID: 105065
		internal static int __PropertyOffset_2;

		// Token: 0x04019A6A RID: 105066
		internal static int __PropertyOffset_3;

		// Token: 0x04019A6B RID: 105067
		internal static int __PropertyOffset_4;

		// Token: 0x04019A6C RID: 105068
		internal static int __PropertyOffset_5;

		// Token: 0x04019A6D RID: 105069
		internal static int __PropertyOffset_6;

		// Token: 0x04019A6E RID: 105070
		internal static int __PropertyOffset_7;

		// Token: 0x04019A6F RID: 105071
		internal static int __PropertyOffset_8;

		// Token: 0x04019A70 RID: 105072
		internal static int __PropertyOffset_9;

		// Token: 0x04019A71 RID: 105073
		internal static int __PropertyOffset_10;

		// Token: 0x04019A72 RID: 105074
		internal static int __PropertyOffset_11;

		// Token: 0x04019A73 RID: 105075
		internal static int __PropertyOffset_12;

		// Token: 0x04019A74 RID: 105076
		internal static int __PropertyOffset_13;

		// Token: 0x04019A75 RID: 105077
		internal static int __PropertyOffset_14;

		// Token: 0x04019A76 RID: 105078
		internal static int __PropertyOffset_15;

		// Token: 0x04019A77 RID: 105079
		internal static int __PropertyOffset_16;

		// Token: 0x04019A78 RID: 105080
		internal static int __PropertyOffset_17;

		// Token: 0x04019A79 RID: 105081
		internal static int __PropertyOffset_18;

		// Token: 0x04019A7A RID: 105082
		internal static int __PropertyOffset_19;

		// Token: 0x04019A7B RID: 105083
		internal static int __PropertyOffset_20;

		// Token: 0x04019A7C RID: 105084
		internal static int __PropertyOffset_21;

		// Token: 0x04019A7D RID: 105085
		internal static int __PropertyOffset_22;

		// Token: 0x04019A7E RID: 105086
		internal static int __PropertyOffset_23;

		// Token: 0x04019A7F RID: 105087
		internal static int __PropertyOffset_24;

		// Token: 0x04019A80 RID: 105088
		internal static int __PropertyOffset_25;

		// Token: 0x04019A81 RID: 105089
		internal static int __PropertyOffset_26;

		// Token: 0x04019A82 RID: 105090
		internal static int __PropertyOffset_27;

		// Token: 0x04019A83 RID: 105091
		internal static int __PropertyOffset_28;

		// Token: 0x04019A84 RID: 105092
		internal static int __PropertyOffset_29;

		// Token: 0x04019A85 RID: 105093
		internal static int __PropertyOffset_30;

		// Token: 0x04019A86 RID: 105094
		internal static int __PropertyOffset_31;

		// Token: 0x04019A87 RID: 105095
		internal static int __PropertyOffset_32;

		// Token: 0x04019A88 RID: 105096
		internal static int __PropertyOffset_33;

		// Token: 0x04019A89 RID: 105097
		internal static int __PropertyOffset_34;

		// Token: 0x04019A8A RID: 105098
		internal static int __PropertyOffset_35;

		// Token: 0x04019A8B RID: 105099
		internal static int __PropertyOffset_36;

		// Token: 0x04019A8C RID: 105100
		internal static int __PropertyOffset_37;

		// Token: 0x04019A8D RID: 105101
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SCameraModifier_Settings_ArmLengthDynamicValue> _ResetFinalArmLengthToDynamicValue;

		// Token: 0x04019A8E RID: 105102
		internal static int __PropertyOffset_38;

		// Token: 0x04019A8F RID: 105103
		internal static int __PropertyOffset_39;

		// Token: 0x04019A90 RID: 105104
		internal static int __PropertyOffset_40;

		// Token: 0x04019A91 RID: 105105
		internal static int __PropertyOffset_41;

		// Token: 0x04019A92 RID: 105106
		internal static int __PropertyOffset_42;

		// Token: 0x04019A93 RID: 105107
		internal static int __PropertyOffset_43;

		// Token: 0x04019A94 RID: 105108
		[Nullable(2)]
		private SCameraModifier_SettingsAdditional _ModifySettingsAdditional;
	}
}
