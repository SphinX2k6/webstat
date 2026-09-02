using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Level.Destructible
{
	// Token: 0x02003E7E RID: 15998
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/Destructible/DestructibleStruct.DestructibleStruct")]
	[UnrealStructLayout(240, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 236)]
	public class DestructibleStruct : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060279FE RID: 162302 RVA: 0x009F671B File Offset: 0x009F491B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (DestructibleStruct._ScriptStructPtr != 0) ? DestructibleStruct._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Level/Destructible/DestructibleStruct.DestructibleStruct", ref DestructibleStruct._ScriptStructPtr);
		}

		// Token: 0x17005DF8 RID: 24056
		// (get) Token: 0x060279FF RID: 162303 RVA: 0x009F673F File Offset: 0x009F493F
		// (set) Token: 0x06027A00 RID: 162304 RVA: 0x009F6753 File Offset: 0x009F4953
		public unsafe string 备注
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)DestructibleStruct.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)DestructibleStruct.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005DF9 RID: 24057
		// (get) Token: 0x06027A01 RID: 162305 RVA: 0x009F6768 File Offset: 0x009F4968
		// (set) Token: 0x06027A02 RID: 162306 RVA: 0x009F6787 File Offset: 0x009F4987
		public TSoftObjectPtr<UKuroDestructibleAsset> DestructibleAsset
		{
			get
			{
				return new TSoftObjectPtr<UKuroDestructibleAsset>(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005DFA RID: 24058
		// (get) Token: 0x06027A03 RID: 162307 RVA: 0x009F67AC File Offset: 0x009F49AC
		// (set) Token: 0x06027A04 RID: 162308 RVA: 0x009F67CB File Offset: 0x009F49CB
		public TSoftObjectPtr<UKuroDestructibleDestructionAsset> DestructibleDestructionAsset
		{
			get
			{
				return new TSoftObjectPtr<UKuroDestructibleDestructionAsset>(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005DFB RID: 24059
		// (get) Token: 0x06027A05 RID: 162309 RVA: 0x009F67F0 File Offset: 0x009F49F0
		// (set) Token: 0x06027A06 RID: 162310 RVA: 0x009F6800 File Offset: 0x009F4A00
		public unsafe bool IsRelativePosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DFC RID: 24060
		// (get) Token: 0x06027A07 RID: 162311 RVA: 0x009F6811 File Offset: 0x009F4A11
		// (set) Token: 0x06027A08 RID: 162312 RVA: 0x009F6825 File Offset: 0x009F4A25
		public unsafe FVectorDouble Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005DFD RID: 24061
		// (get) Token: 0x06027A09 RID: 162313 RVA: 0x009F683A File Offset: 0x009F4A3A
		// (set) Token: 0x06027A0A RID: 162314 RVA: 0x009F684E File Offset: 0x009F4A4E
		public unsafe FTransform ModelTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005DFE RID: 24062
		// (get) Token: 0x06027A0B RID: 162315 RVA: 0x009F6863 File Offset: 0x009F4A63
		// (set) Token: 0x06027A0C RID: 162316 RVA: 0x009F6873 File Offset: 0x009F4A73
		public unsafe float TraceSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005DFF RID: 24063
		// (get) Token: 0x06027A0D RID: 162317 RVA: 0x009F6884 File Offset: 0x009F4A84
		// (set) Token: 0x06027A0E RID: 162318 RVA: 0x009F6894 File Offset: 0x009F4A94
		public unsafe ETrackMethod TrackMethod
		{
			get
			{
				return (ETrackMethod)(*(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_7));
			}
			set
			{
				*(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_7) = (byte)value;
			}
		}

		// Token: 0x17005E00 RID: 24064
		// (get) Token: 0x06027A0F RID: 162319 RVA: 0x009F68A5 File Offset: 0x009F4AA5
		// (set) Token: 0x06027A10 RID: 162320 RVA: 0x009F68B5 File Offset: 0x009F4AB5
		public unsafe float TrackPredictionFactor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005E01 RID: 24065
		// (get) Token: 0x06027A11 RID: 162321 RVA: 0x009F68C6 File Offset: 0x009F4AC6
		// (set) Token: 0x06027A12 RID: 162322 RVA: 0x009F68D6 File Offset: 0x009F4AD6
		public unsafe float StopTrackTargetDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005E02 RID: 24066
		// (get) Token: 0x06027A13 RID: 162323 RVA: 0x009F68E7 File Offset: 0x009F4AE7
		// (set) Token: 0x06027A14 RID: 162324 RVA: 0x009F68FB File Offset: 0x009F4AFB
		[Nullable(0)]
		public unsafe TEnumAsByte<FauxPhysicsRotateType> TrackType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_10);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005E03 RID: 24067
		// (get) Token: 0x06027A15 RID: 162325 RVA: 0x009F6910 File Offset: 0x009F4B10
		// (set) Token: 0x06027A16 RID: 162326 RVA: 0x009F6924 File Offset: 0x009F4B24
		public unsafe FVector LocalRotationAxis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005E04 RID: 24068
		// (get) Token: 0x06027A17 RID: 162327 RVA: 0x009F6939 File Offset: 0x009F4B39
		// (set) Token: 0x06027A18 RID: 162328 RVA: 0x009F6949 File Offset: 0x009F4B49
		public unsafe float AngularImpulseRadians
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005E05 RID: 24069
		// (get) Token: 0x06027A19 RID: 162329 RVA: 0x009F695A File Offset: 0x009F4B5A
		// (set) Token: 0x06027A1A RID: 162330 RVA: 0x009F696A File Offset: 0x009F4B6A
		public unsafe int HitBuff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005E06 RID: 24070
		// (get) Token: 0x06027A1B RID: 162331 RVA: 0x009F697B File Offset: 0x009F4B7B
		// (set) Token: 0x06027A1C RID: 162332 RVA: 0x009F698B File Offset: 0x009F4B8B
		public unsafe int RevertMaximumHP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)DestructibleStruct.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x06027A1D RID: 162333 RVA: 0x009F699C File Offset: 0x009F4B9C
		public DestructibleStruct()
		{
		}

		// Token: 0x06027A1E RID: 162334 RVA: 0x009F69A4 File Offset: 0x009F4BA4
		public DestructibleStruct(string 备注, TSoftObjectPtr<UKuroDestructibleAsset> DestructibleAsset, TSoftObjectPtr<UKuroDestructibleDestructionAsset> DestructibleDestructionAsset, bool IsRelativePosition, FVectorDouble Position, FTransform ModelTransform, float TraceSpeed, ETrackMethod TrackMethod, float TrackPredictionFactor, float StopTrackTargetDistance, [Nullable(0)] TEnumAsByte<FauxPhysicsRotateType> TrackType, FVector LocalRotationAxis, float AngularImpulseRadians, int HitBuff, int RevertMaximumHP)
		{
			this.备注 = 备注;
			this.DestructibleAsset = DestructibleAsset;
			this.DestructibleDestructionAsset = DestructibleDestructionAsset;
			this.IsRelativePosition = IsRelativePosition;
			this.Position = Position;
			this.ModelTransform = ModelTransform;
			this.TraceSpeed = TraceSpeed;
			this.TrackMethod = TrackMethod;
			this.TrackPredictionFactor = TrackPredictionFactor;
			this.StopTrackTargetDistance = StopTrackTargetDistance;
			this.TrackType = TrackType;
			this.LocalRotationAxis = LocalRotationAxis;
			this.AngularImpulseRadians = AngularImpulseRadians;
			this.HitBuff = HitBuff;
			this.RevertMaximumHP = RevertMaximumHP;
		}

		// Token: 0x06027A1F RID: 162335 RVA: 0x009F6A2C File Offset: 0x009F4C2C
		protected override IntPtr GetUStructPtr()
		{
			return DestructibleStruct.StaticStruct();
		}

		// Token: 0x06027A20 RID: 162336 RVA: 0x009F6A38 File Offset: 0x009F4C38
		[NullableContext(2)]
		public DestructibleStruct(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027A21 RID: 162337 RVA: 0x009F6A42 File Offset: 0x009F4C42
		public DestructibleStruct(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027A22 RID: 162338 RVA: 0x009F6A4D File Offset: 0x009F4C4D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new DestructibleStruct(Pointer, false, true);
		}

		// Token: 0x06027A23 RID: 162339 RVA: 0x009F6A57 File Offset: 0x009F4C57
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new DestructibleStruct(Pointer, MemoryOwner);
		}

		// Token: 0x04014C57 RID: 85079
		public const string __ObjectPath = "/Game/Aki/Data/Level/Destructible/DestructibleStruct.DestructibleStruct";

		// Token: 0x04014C58 RID: 85080
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014C59 RID: 85081
		internal static int __PropertyOffset_0;

		// Token: 0x04014C5A RID: 85082
		internal static int __PropertyOffset_1;

		// Token: 0x04014C5B RID: 85083
		internal static int __PropertyOffset_2;

		// Token: 0x04014C5C RID: 85084
		internal static int __PropertyOffset_3;

		// Token: 0x04014C5D RID: 85085
		internal static int __PropertyOffset_4;

		// Token: 0x04014C5E RID: 85086
		internal static int __PropertyOffset_5;

		// Token: 0x04014C5F RID: 85087
		internal static int __PropertyOffset_6;

		// Token: 0x04014C60 RID: 85088
		internal static int __PropertyOffset_7;

		// Token: 0x04014C61 RID: 85089
		internal static int __PropertyOffset_8;

		// Token: 0x04014C62 RID: 85090
		internal static int __PropertyOffset_9;

		// Token: 0x04014C63 RID: 85091
		internal static int __PropertyOffset_10;

		// Token: 0x04014C64 RID: 85092
		internal static int __PropertyOffset_11;

		// Token: 0x04014C65 RID: 85093
		internal static int __PropertyOffset_12;

		// Token: 0x04014C66 RID: 85094
		internal static int __PropertyOffset_13;

		// Token: 0x04014C67 RID: 85095
		internal static int __PropertyOffset_14;
	}
}
