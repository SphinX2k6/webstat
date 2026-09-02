using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.UiCameraAnimation.Struct
{
	// Token: 0x02003DFD RID: 15869
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/UiCameraAnimation/Struct/SUiCameraAnimationSettings.SUiCameraAnimationSettings")]
	[UnrealStructLayout(448, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 446)]
	public class SUiCameraAnimationSettings : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060270D7 RID: 159959 RVA: 0x009E8D5E File Offset: 0x009E6F5E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SUiCameraAnimationSettings._ScriptStructPtr != 0) ? SUiCameraAnimationSettings._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/UiCameraAnimation/Struct/SUiCameraAnimationSettings.SUiCameraAnimationSettings", ref SUiCameraAnimationSettings._ScriptStructPtr);
		}

		// Token: 0x17005ABB RID: 23227
		// (get) Token: 0x060270D8 RID: 159960 RVA: 0x009E8D82 File Offset: 0x009E6F82
		// (set) Token: 0x060270D9 RID: 159961 RVA: 0x009E8D92 File Offset: 0x009E6F92
		public unsafe bool IsEmptyState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005ABC RID: 23228
		// (get) Token: 0x060270DA RID: 159962 RVA: 0x009E8DA3 File Offset: 0x009E6FA3
		// (set) Token: 0x060270DB RID: 159963 RVA: 0x009E8DB7 File Offset: 0x009E6FB7
		public unsafe string ReplaceCameraTag
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SUiCameraAnimationSettings.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SUiCameraAnimationSettings.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17005ABD RID: 23229
		// (get) Token: 0x060270DC RID: 159964 RVA: 0x009E8DCC File Offset: 0x009E6FCC
		// (set) Token: 0x060270DD RID: 159965 RVA: 0x009E8DE0 File Offset: 0x009E6FE0
		public unsafe string Description
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SUiCameraAnimationSettings.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SUiCameraAnimationSettings.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17005ABE RID: 23230
		// (get) Token: 0x060270DE RID: 159966 RVA: 0x009E8DF5 File Offset: 0x009E6FF5
		// (set) Token: 0x060270DF RID: 159967 RVA: 0x009E8E09 File Offset: 0x009E7009
		public unsafe string SocketName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SUiCameraAnimationSettings.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SUiCameraAnimationSettings.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17005ABF RID: 23231
		// (get) Token: 0x060270E0 RID: 159968 RVA: 0x009E8E1E File Offset: 0x009E701E
		// (set) Token: 0x060270E1 RID: 159969 RVA: 0x009E8E32 File Offset: 0x009E7032
		[Nullable(0)]
		public unsafe TEnumAsByte<EUiCameraAnimationTargetType> TargetType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_4);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005AC0 RID: 23232
		// (get) Token: 0x060270E2 RID: 159970 RVA: 0x009E8E47 File Offset: 0x009E7047
		// (set) Token: 0x060270E3 RID: 159971 RVA: 0x009E8E5B File Offset: 0x009E705B
		public unsafe string TargetActorTag
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SUiCameraAnimationSettings.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SUiCameraAnimationSettings.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x17005AC1 RID: 23233
		// (get) Token: 0x060270E4 RID: 159972 RVA: 0x009E8E70 File Offset: 0x009E7070
		// (set) Token: 0x060270E5 RID: 159973 RVA: 0x009E8E84 File Offset: 0x009E7084
		[Nullable(0)]
		public unsafe TEnumAsByte<EUiCameraAnimationLocationType> LocationType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_6);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005AC2 RID: 23234
		// (get) Token: 0x060270E6 RID: 159974 RVA: 0x009E8E99 File Offset: 0x009E7099
		// (set) Token: 0x060270E7 RID: 159975 RVA: 0x009E8EAD File Offset: 0x009E70AD
		public unsafe FVector Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005AC3 RID: 23235
		// (get) Token: 0x060270E8 RID: 159976 RVA: 0x009E8EC2 File Offset: 0x009E70C2
		// (set) Token: 0x060270E9 RID: 159977 RVA: 0x009E8ED6 File Offset: 0x009E70D6
		[Nullable(0)]
		public unsafe TEnumAsByte<EUiCameraAnimationRotationType> RotationType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_8);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005AC4 RID: 23236
		// (get) Token: 0x060270EA RID: 159978 RVA: 0x009E8EEB File Offset: 0x009E70EB
		// (set) Token: 0x060270EB RID: 159979 RVA: 0x009E8EFF File Offset: 0x009E70FF
		public unsafe FRotator Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005AC5 RID: 23237
		// (get) Token: 0x060270EC RID: 159980 RVA: 0x009E8F14 File Offset: 0x009E7114
		// (set) Token: 0x060270ED RID: 159981 RVA: 0x009E8F24 File Offset: 0x009E7124
		public unsafe bool IsTrack
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005AC6 RID: 23238
		// (get) Token: 0x060270EE RID: 159982 RVA: 0x009E8F35 File Offset: 0x009E7135
		// (set) Token: 0x060270EF RID: 159983 RVA: 0x009E8F45 File Offset: 0x009E7145
		public unsafe bool IsTrackWorldLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005AC7 RID: 23239
		// (get) Token: 0x060270F0 RID: 159984 RVA: 0x009E8F56 File Offset: 0x009E7156
		// (set) Token: 0x060270F1 RID: 159985 RVA: 0x009E8F66 File Offset: 0x009E7166
		public unsafe bool bOverrideTrackPitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005AC8 RID: 23240
		// (get) Token: 0x060270F2 RID: 159986 RVA: 0x009E8F77 File Offset: 0x009E7177
		// (set) Token: 0x060270F3 RID: 159987 RVA: 0x009E8F87 File Offset: 0x009E7187
		public unsafe float TrackPitchOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005AC9 RID: 23241
		// (get) Token: 0x060270F4 RID: 159988 RVA: 0x009E8F98 File Offset: 0x009E7198
		// (set) Token: 0x060270F5 RID: 159989 RVA: 0x009E8FA8 File Offset: 0x009E71A8
		public unsafe bool bTargetActorAsCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005ACA RID: 23242
		// (get) Token: 0x060270F6 RID: 159990 RVA: 0x009E8FB9 File Offset: 0x009E71B9
		// (set) Token: 0x060270F7 RID: 159991 RVA: 0x009E8FCD File Offset: 0x009E71CD
		public unsafe FVector TrackLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005ACB RID: 23243
		// (get) Token: 0x060270F8 RID: 159992 RVA: 0x009E8FE2 File Offset: 0x009E71E2
		// (set) Token: 0x060270F9 RID: 159993 RVA: 0x009E8FF2 File Offset: 0x009E71F2
		public unsafe float ArmLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005ACC RID: 23244
		// (get) Token: 0x060270FA RID: 159994 RVA: 0x009E9003 File Offset: 0x009E7203
		// (set) Token: 0x060270FB RID: 159995 RVA: 0x009E9017 File Offset: 0x009E7217
		public unsafe FVector ArmOffsetLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005ACD RID: 23245
		// (get) Token: 0x060270FC RID: 159996 RVA: 0x009E902C File Offset: 0x009E722C
		// (set) Token: 0x060270FD RID: 159997 RVA: 0x009E9040 File Offset: 0x009E7240
		public unsafe FRotator ArmOffsetRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005ACE RID: 23246
		// (get) Token: 0x060270FE RID: 159998 RVA: 0x009E9055 File Offset: 0x009E7255
		// (set) Token: 0x060270FF RID: 159999 RVA: 0x009E9065 File Offset: 0x009E7265
		public unsafe bool IsDynamicFov
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005ACF RID: 23247
		// (get) Token: 0x06027100 RID: 160000 RVA: 0x009E9076 File Offset: 0x009E7276
		// (set) Token: 0x06027101 RID: 160001 RVA: 0x009E908A File Offset: 0x009E728A
		public unsafe FIntPoint DynamicBaseResolution
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005AD0 RID: 23248
		// (get) Token: 0x06027102 RID: 160002 RVA: 0x009E909F File Offset: 0x009E729F
		// (set) Token: 0x06027103 RID: 160003 RVA: 0x009E90AF File Offset: 0x009E72AF
		public unsafe float CameraFieldOfView
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17005AD1 RID: 23249
		// (get) Token: 0x06027104 RID: 160004 RVA: 0x009E90C0 File Offset: 0x009E72C0
		// (set) Token: 0x06027105 RID: 160005 RVA: 0x009E90D0 File Offset: 0x009E72D0
		public unsafe bool ArmCollisionTest
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005AD2 RID: 23250
		// (get) Token: 0x06027106 RID: 160006 RVA: 0x009E90E1 File Offset: 0x009E72E1
		// (set) Token: 0x06027107 RID: 160007 RVA: 0x009E90F1 File Offset: 0x009E72F1
		public unsafe float FocalDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17005AD3 RID: 23251
		// (get) Token: 0x06027108 RID: 160008 RVA: 0x009E9102 File Offset: 0x009E7302
		// (set) Token: 0x06027109 RID: 160009 RVA: 0x009E9112 File Offset: 0x009E7312
		public unsafe float Aperture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17005AD4 RID: 23252
		// (get) Token: 0x0602710A RID: 160010 RVA: 0x009E9123 File Offset: 0x009E7323
		// (set) Token: 0x0602710B RID: 160011 RVA: 0x009E9133 File Offset: 0x009E7333
		public unsafe float FocalRegion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17005AD5 RID: 23253
		// (get) Token: 0x0602710C RID: 160012 RVA: 0x009E9144 File Offset: 0x009E7344
		// (set) Token: 0x0602710D RID: 160013 RVA: 0x009E9154 File Offset: 0x009E7354
		public unsafe float PostProcessBlendWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17005AD6 RID: 23254
		// (get) Token: 0x0602710E RID: 160014 RVA: 0x009E9165 File Offset: 0x009E7365
		// (set) Token: 0x0602710F RID: 160015 RVA: 0x009E9175 File Offset: 0x009E7375
		public unsafe float BlendInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17005AD7 RID: 23255
		// (get) Token: 0x06027110 RID: 160016 RVA: 0x009E9186 File Offset: 0x009E7386
		// (set) Token: 0x06027111 RID: 160017 RVA: 0x009E9196 File Offset: 0x009E7396
		public unsafe float BlendInExp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17005AD8 RID: 23256
		// (get) Token: 0x06027112 RID: 160018 RVA: 0x009E91A7 File Offset: 0x009E73A7
		// (set) Token: 0x06027113 RID: 160019 RVA: 0x009E91C6 File Offset: 0x009E73C6
		public TSoftObjectPtr<ULevelSequence> BlendInCameraSequence
		{
			get
			{
				return new TSoftObjectPtr<ULevelSequence>(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_29, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_29, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005AD9 RID: 23257
		// (get) Token: 0x06027114 RID: 160020 RVA: 0x009E91EB File Offset: 0x009E73EB
		// (set) Token: 0x06027115 RID: 160021 RVA: 0x009E91FB File Offset: 0x009E73FB
		public unsafe float BlendInCameraSequencePlayRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17005ADA RID: 23258
		// (get) Token: 0x06027116 RID: 160022 RVA: 0x009E920C File Offset: 0x009E740C
		// (set) Token: 0x06027117 RID: 160023 RVA: 0x009E921C File Offset: 0x009E741C
		public unsafe bool bRevertBlendInCameraSequence
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005ADB RID: 23259
		// (get) Token: 0x06027118 RID: 160024 RVA: 0x009E922D File Offset: 0x009E742D
		// (set) Token: 0x06027119 RID: 160025 RVA: 0x009E924C File Offset: 0x009E744C
		public TSoftObjectPtr<ULevelSequence> BlendOutCameraSequence
		{
			get
			{
				return new TSoftObjectPtr<ULevelSequence>(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_32, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_32, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005ADC RID: 23260
		// (get) Token: 0x0602711A RID: 160026 RVA: 0x009E9271 File Offset: 0x009E7471
		// (set) Token: 0x0602711B RID: 160027 RVA: 0x009E9281 File Offset: 0x009E7481
		public unsafe float BlendOutCameraSequencePlayRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17005ADD RID: 23261
		// (get) Token: 0x0602711C RID: 160028 RVA: 0x009E9292 File Offset: 0x009E7492
		// (set) Token: 0x0602711D RID: 160029 RVA: 0x009E92A2 File Offset: 0x009E74A2
		public unsafe bool bRevertBlendOutCameraSequence
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005ADE RID: 23262
		// (get) Token: 0x0602711E RID: 160030 RVA: 0x009E92B3 File Offset: 0x009E74B3
		// (set) Token: 0x0602711F RID: 160031 RVA: 0x009E92C7 File Offset: 0x009E74C7
		[Nullable(0)]
		public unsafe TEnumAsByte<EViewTargetBlendFunction> BlendInFunction
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_35);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17005ADF RID: 23263
		// (get) Token: 0x06027120 RID: 160032 RVA: 0x009E92DC File Offset: 0x009E74DC
		// (set) Token: 0x06027121 RID: 160033 RVA: 0x009E92FB File Offset: 0x009E74FB
		public TSoftObjectPtr<ULevelSequence> BlendInSequence
		{
			get
			{
				return new TSoftObjectPtr<ULevelSequence>(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_36, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_36, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005AE0 RID: 23264
		// (get) Token: 0x06027122 RID: 160034 RVA: 0x009E9320 File Offset: 0x009E7520
		// (set) Token: 0x06027123 RID: 160035 RVA: 0x009E9330 File Offset: 0x009E7530
		public unsafe bool bBlendInSequenceReverse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_37) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_37) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005AE1 RID: 23265
		// (get) Token: 0x06027124 RID: 160036 RVA: 0x009E9341 File Offset: 0x009E7541
		// (set) Token: 0x06027125 RID: 160037 RVA: 0x009E9351 File Offset: 0x009E7551
		public unsafe float BlendInPlayRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17005AE2 RID: 23266
		// (get) Token: 0x06027126 RID: 160038 RVA: 0x009E9362 File Offset: 0x009E7562
		// (set) Token: 0x06027127 RID: 160039 RVA: 0x009E9372 File Offset: 0x009E7572
		public unsafe float BlendOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17005AE3 RID: 23267
		// (get) Token: 0x06027128 RID: 160040 RVA: 0x009E9383 File Offset: 0x009E7583
		// (set) Token: 0x06027129 RID: 160041 RVA: 0x009E9393 File Offset: 0x009E7593
		public unsafe float BlendOutExp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17005AE4 RID: 23268
		// (get) Token: 0x0602712A RID: 160042 RVA: 0x009E93A4 File Offset: 0x009E75A4
		// (set) Token: 0x0602712B RID: 160043 RVA: 0x009E93B8 File Offset: 0x009E75B8
		[Nullable(0)]
		public unsafe TEnumAsByte<EViewTargetBlendFunction> BlendOutFunction
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_41);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17005AE5 RID: 23269
		// (get) Token: 0x0602712C RID: 160044 RVA: 0x009E93CD File Offset: 0x009E75CD
		// (set) Token: 0x0602712D RID: 160045 RVA: 0x009E93EC File Offset: 0x009E75EC
		public TSoftObjectPtr<ULevelSequence> BlendOutSequence
		{
			get
			{
				return new TSoftObjectPtr<ULevelSequence>(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_42, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_42, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005AE6 RID: 23270
		// (get) Token: 0x0602712E RID: 160046 RVA: 0x009E9411 File Offset: 0x009E7611
		// (set) Token: 0x0602712F RID: 160047 RVA: 0x009E9421 File Offset: 0x009E7621
		public unsafe float BlendOutPlayRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17005AE7 RID: 23271
		// (get) Token: 0x06027130 RID: 160048 RVA: 0x009E9432 File Offset: 0x009E7632
		// (set) Token: 0x06027131 RID: 160049 RVA: 0x009E9442 File Offset: 0x009E7642
		public unsafe bool bBlendOutSequenceReverse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005AE8 RID: 23272
		// (get) Token: 0x06027132 RID: 160050 RVA: 0x009E9453 File Offset: 0x009E7653
		// (set) Token: 0x06027133 RID: 160051 RVA: 0x009E9463 File Offset: 0x009E7663
		public unsafe bool bResetCameraTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationSettings.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x06027134 RID: 160052 RVA: 0x009E9474 File Offset: 0x009E7674
		public SUiCameraAnimationSettings()
		{
		}

		// Token: 0x06027135 RID: 160053 RVA: 0x009E947C File Offset: 0x009E767C
		public SUiCameraAnimationSettings(bool IsEmptyState, string ReplaceCameraTag, string Description, string SocketName, [Nullable(0)] TEnumAsByte<EUiCameraAnimationTargetType> TargetType, string TargetActorTag, [Nullable(0)] TEnumAsByte<EUiCameraAnimationLocationType> LocationType, FVector Location, [Nullable(0)] TEnumAsByte<EUiCameraAnimationRotationType> RotationType, FRotator Rotation, bool IsTrack, bool IsTrackWorldLocation, bool bOverrideTrackPitch, float TrackPitchOverride, bool bTargetActorAsCenter, FVector TrackLocation, float ArmLength, FVector ArmOffsetLocation, FRotator ArmOffsetRotation, bool IsDynamicFov, FIntPoint DynamicBaseResolution, float CameraFieldOfView, bool ArmCollisionTest, float FocalDistance, float Aperture, float FocalRegion, float PostProcessBlendWeight, float BlendInTime, float BlendInExp, TSoftObjectPtr<ULevelSequence> BlendInCameraSequence, float BlendInCameraSequencePlayRate, bool bRevertBlendInCameraSequence, TSoftObjectPtr<ULevelSequence> BlendOutCameraSequence, float BlendOutCameraSequencePlayRate, bool bRevertBlendOutCameraSequence, [Nullable(0)] TEnumAsByte<EViewTargetBlendFunction> BlendInFunction, TSoftObjectPtr<ULevelSequence> BlendInSequence, bool bBlendInSequenceReverse, float BlendInPlayRate, float BlendOutTime, float BlendOutExp, [Nullable(0)] TEnumAsByte<EViewTargetBlendFunction> BlendOutFunction, TSoftObjectPtr<ULevelSequence> BlendOutSequence, float BlendOutPlayRate, bool bBlendOutSequenceReverse, bool bResetCameraTransform)
		{
			this.IsEmptyState = IsEmptyState;
			this.ReplaceCameraTag = ReplaceCameraTag;
			this.Description = Description;
			this.SocketName = SocketName;
			this.TargetType = TargetType;
			this.TargetActorTag = TargetActorTag;
			this.LocationType = LocationType;
			this.Location = Location;
			this.RotationType = RotationType;
			this.Rotation = Rotation;
			this.IsTrack = IsTrack;
			this.IsTrackWorldLocation = IsTrackWorldLocation;
			this.bOverrideTrackPitch = bOverrideTrackPitch;
			this.TrackPitchOverride = TrackPitchOverride;
			this.bTargetActorAsCenter = bTargetActorAsCenter;
			this.TrackLocation = TrackLocation;
			this.ArmLength = ArmLength;
			this.ArmOffsetLocation = ArmOffsetLocation;
			this.ArmOffsetRotation = ArmOffsetRotation;
			this.IsDynamicFov = IsDynamicFov;
			this.DynamicBaseResolution = DynamicBaseResolution;
			this.CameraFieldOfView = CameraFieldOfView;
			this.ArmCollisionTest = ArmCollisionTest;
			this.FocalDistance = FocalDistance;
			this.Aperture = Aperture;
			this.FocalRegion = FocalRegion;
			this.PostProcessBlendWeight = PostProcessBlendWeight;
			this.BlendInTime = BlendInTime;
			this.BlendInExp = BlendInExp;
			this.BlendInCameraSequence = BlendInCameraSequence;
			this.BlendInCameraSequencePlayRate = BlendInCameraSequencePlayRate;
			this.bRevertBlendInCameraSequence = bRevertBlendInCameraSequence;
			this.BlendOutCameraSequence = BlendOutCameraSequence;
			this.BlendOutCameraSequencePlayRate = BlendOutCameraSequencePlayRate;
			this.bRevertBlendOutCameraSequence = bRevertBlendOutCameraSequence;
			this.BlendInFunction = BlendInFunction;
			this.BlendInSequence = BlendInSequence;
			this.bBlendInSequenceReverse = bBlendInSequenceReverse;
			this.BlendInPlayRate = BlendInPlayRate;
			this.BlendOutTime = BlendOutTime;
			this.BlendOutExp = BlendOutExp;
			this.BlendOutFunction = BlendOutFunction;
			this.BlendOutSequence = BlendOutSequence;
			this.BlendOutPlayRate = BlendOutPlayRate;
			this.bBlendOutSequenceReverse = bBlendOutSequenceReverse;
			this.bResetCameraTransform = bResetCameraTransform;
		}

		// Token: 0x06027136 RID: 160054 RVA: 0x009E95FC File Offset: 0x009E77FC
		protected override IntPtr GetUStructPtr()
		{
			return SUiCameraAnimationSettings.StaticStruct();
		}

		// Token: 0x06027137 RID: 160055 RVA: 0x009E9608 File Offset: 0x009E7808
		[NullableContext(2)]
		public SUiCameraAnimationSettings(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027138 RID: 160056 RVA: 0x009E9612 File Offset: 0x009E7812
		public SUiCameraAnimationSettings(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027139 RID: 160057 RVA: 0x009E961D File Offset: 0x009E781D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SUiCameraAnimationSettings(Pointer, false, true);
		}

		// Token: 0x0602713A RID: 160058 RVA: 0x009E9627 File Offset: 0x009E7827
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SUiCameraAnimationSettings(Pointer, MemoryOwner);
		}

		// Token: 0x04014663 RID: 83555
		public const string __ObjectPath = "/Game/Aki/Data/UiCameraAnimation/Struct/SUiCameraAnimationSettings.SUiCameraAnimationSettings";

		// Token: 0x04014664 RID: 83556
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014665 RID: 83557
		internal static int __PropertyOffset_0;

		// Token: 0x04014666 RID: 83558
		internal static int __PropertyOffset_1;

		// Token: 0x04014667 RID: 83559
		internal static int __PropertyOffset_2;

		// Token: 0x04014668 RID: 83560
		internal static int __PropertyOffset_3;

		// Token: 0x04014669 RID: 83561
		internal static int __PropertyOffset_4;

		// Token: 0x0401466A RID: 83562
		internal static int __PropertyOffset_5;

		// Token: 0x0401466B RID: 83563
		internal static int __PropertyOffset_6;

		// Token: 0x0401466C RID: 83564
		internal static int __PropertyOffset_7;

		// Token: 0x0401466D RID: 83565
		internal static int __PropertyOffset_8;

		// Token: 0x0401466E RID: 83566
		internal static int __PropertyOffset_9;

		// Token: 0x0401466F RID: 83567
		internal static int __PropertyOffset_10;

		// Token: 0x04014670 RID: 83568
		internal static int __PropertyOffset_11;

		// Token: 0x04014671 RID: 83569
		internal static int __PropertyOffset_12;

		// Token: 0x04014672 RID: 83570
		internal static int __PropertyOffset_13;

		// Token: 0x04014673 RID: 83571
		internal static int __PropertyOffset_14;

		// Token: 0x04014674 RID: 83572
		internal static int __PropertyOffset_15;

		// Token: 0x04014675 RID: 83573
		internal static int __PropertyOffset_16;

		// Token: 0x04014676 RID: 83574
		internal static int __PropertyOffset_17;

		// Token: 0x04014677 RID: 83575
		internal static int __PropertyOffset_18;

		// Token: 0x04014678 RID: 83576
		internal static int __PropertyOffset_19;

		// Token: 0x04014679 RID: 83577
		internal static int __PropertyOffset_20;

		// Token: 0x0401467A RID: 83578
		internal static int __PropertyOffset_21;

		// Token: 0x0401467B RID: 83579
		internal static int __PropertyOffset_22;

		// Token: 0x0401467C RID: 83580
		internal static int __PropertyOffset_23;

		// Token: 0x0401467D RID: 83581
		internal static int __PropertyOffset_24;

		// Token: 0x0401467E RID: 83582
		internal static int __PropertyOffset_25;

		// Token: 0x0401467F RID: 83583
		internal static int __PropertyOffset_26;

		// Token: 0x04014680 RID: 83584
		internal static int __PropertyOffset_27;

		// Token: 0x04014681 RID: 83585
		internal static int __PropertyOffset_28;

		// Token: 0x04014682 RID: 83586
		internal static int __PropertyOffset_29;

		// Token: 0x04014683 RID: 83587
		internal static int __PropertyOffset_30;

		// Token: 0x04014684 RID: 83588
		internal static int __PropertyOffset_31;

		// Token: 0x04014685 RID: 83589
		internal static int __PropertyOffset_32;

		// Token: 0x04014686 RID: 83590
		internal static int __PropertyOffset_33;

		// Token: 0x04014687 RID: 83591
		internal static int __PropertyOffset_34;

		// Token: 0x04014688 RID: 83592
		internal static int __PropertyOffset_35;

		// Token: 0x04014689 RID: 83593
		internal static int __PropertyOffset_36;

		// Token: 0x0401468A RID: 83594
		internal static int __PropertyOffset_37;

		// Token: 0x0401468B RID: 83595
		internal static int __PropertyOffset_38;

		// Token: 0x0401468C RID: 83596
		internal static int __PropertyOffset_39;

		// Token: 0x0401468D RID: 83597
		internal static int __PropertyOffset_40;

		// Token: 0x0401468E RID: 83598
		internal static int __PropertyOffset_41;

		// Token: 0x0401468F RID: 83599
		internal static int __PropertyOffset_42;

		// Token: 0x04014690 RID: 83600
		internal static int __PropertyOffset_43;

		// Token: 0x04014691 RID: 83601
		internal static int __PropertyOffset_44;

		// Token: 0x04014692 RID: 83602
		internal static int __PropertyOffset_45;
	}
}
