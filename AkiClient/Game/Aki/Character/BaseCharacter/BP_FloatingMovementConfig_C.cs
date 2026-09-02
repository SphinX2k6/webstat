using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041C9 RID: 16841
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BP_FloatingMovementConfig.BP_FloatingMovementConfig_C")]
	[UnrealStructLayout(904, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 904)]
	public class BP_FloatingMovementConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CC53 RID: 183379 RVA: 0x00AAF0CB File Offset: 0x00AAD2CB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FloatingMovementConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/BP_FloatingMovementConfig.BP_FloatingMovementConfig_C");
			}
			return BP_FloatingMovementConfig_C._ClassPtr;
		}

		// Token: 0x0602CC54 RID: 183380 RVA: 0x00AAF0F0 File Offset: 0x00AAD2F0
		public BP_FloatingMovementConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_FloatingMovementConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CC55 RID: 183381 RVA: 0x00AAF118 File Offset: 0x00AAD318
		public BP_FloatingMovementConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FloatingMovementConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170078EC RID: 30956
		// (get) Token: 0x0602CC56 RID: 183382 RVA: 0x00AAF14B File Offset: 0x00AAD34B
		// (set) Token: 0x0602CC57 RID: 183383 RVA: 0x00AAF15B File Offset: 0x00AAD35B
		public unsafe int MoveSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170078ED RID: 30957
		// (get) Token: 0x0602CC58 RID: 183384 RVA: 0x00AAF16C File Offset: 0x00AAD36C
		// (set) Token: 0x0602CC59 RID: 183385 RVA: 0x00AAF17C File Offset: 0x00AAD37C
		public unsafe int SprintSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170078EE RID: 30958
		// (get) Token: 0x0602CC5A RID: 183386 RVA: 0x00AAF18D File Offset: 0x00AAD38D
		// (set) Token: 0x0602CC5B RID: 183387 RVA: 0x00AAF19D File Offset: 0x00AAD39D
		public unsafe int TurnSpeedDeg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170078EF RID: 30959
		// (get) Token: 0x0602CC5C RID: 183388 RVA: 0x00AAF1AE File Offset: 0x00AAD3AE
		// (set) Token: 0x0602CC5D RID: 183389 RVA: 0x00AAF1BE File Offset: 0x00AAD3BE
		public unsafe int AirEnergyConsumption
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170078F0 RID: 30960
		// (get) Token: 0x0602CC5E RID: 183390 RVA: 0x00AAF1CF File Offset: 0x00AAD3CF
		// (set) Token: 0x0602CC5F RID: 183391 RVA: 0x00AAF1DF File Offset: 0x00AAD3DF
		public unsafe int RiseEnergyConsumption
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170078F1 RID: 30961
		// (get) Token: 0x0602CC60 RID: 183392 RVA: 0x00AAF1F0 File Offset: 0x00AAD3F0
		// (set) Token: 0x0602CC61 RID: 183393 RVA: 0x00AAF200 File Offset: 0x00AAD400
		public unsafe int DropEnergyConsumption
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170078F2 RID: 30962
		// (get) Token: 0x0602CC62 RID: 183394 RVA: 0x00AAF211 File Offset: 0x00AAD411
		// (set) Token: 0x0602CC63 RID: 183395 RVA: 0x00AAF221 File Offset: 0x00AAD421
		public unsafe int DodgeEnergyConsumption
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170078F3 RID: 30963
		// (get) Token: 0x0602CC64 RID: 183396 RVA: 0x00AAF232 File Offset: 0x00AAD432
		// (set) Token: 0x0602CC65 RID: 183397 RVA: 0x00AAF242 File Offset: 0x00AAD442
		public unsafe int MoveEnergyConsumption
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170078F4 RID: 30964
		// (get) Token: 0x0602CC66 RID: 183398 RVA: 0x00AAF253 File Offset: 0x00AAD453
		// (set) Token: 0x0602CC67 RID: 183399 RVA: 0x00AAF263 File Offset: 0x00AAD463
		public unsafe int FastMoveEnergyConsumption
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170078F5 RID: 30965
		// (get) Token: 0x0602CC68 RID: 183400 RVA: 0x00AAF274 File Offset: 0x00AAD474
		// (set) Token: 0x0602CC69 RID: 183401 RVA: 0x00AAF284 File Offset: 0x00AAD484
		public unsafe int SprintEnergyConsumption
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170078F6 RID: 30966
		// (get) Token: 0x0602CC6A RID: 183402 RVA: 0x00AAF295 File Offset: 0x00AAD495
		// (set) Token: 0x0602CC6B RID: 183403 RVA: 0x00AAF2A5 File Offset: 0x00AAD4A5
		public unsafe int EnergyRecoverSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170078F7 RID: 30967
		// (get) Token: 0x0602CC6C RID: 183404 RVA: 0x00AAF2B6 File Offset: 0x00AAD4B6
		// (set) Token: 0x0602CC6D RID: 183405 RVA: 0x00AAF2C6 File Offset: 0x00AAD4C6
		public unsafe int EnergyRecoverCoolDownTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170078F8 RID: 30968
		// (get) Token: 0x0602CC6E RID: 183406 RVA: 0x00AAF2D7 File Offset: 0x00AAD4D7
		// (set) Token: 0x0602CC6F RID: 183407 RVA: 0x00AAF2E7 File Offset: 0x00AAD4E7
		public unsafe int AirCriticalHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170078F9 RID: 30969
		// (get) Token: 0x0602CC70 RID: 183408 RVA: 0x00AAF2F8 File Offset: 0x00AAD4F8
		// (set) Token: 0x0602CC71 RID: 183409 RVA: 0x00AAF308 File Offset: 0x00AAD508
		public unsafe int CloseToGroundHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170078FA RID: 30970
		// (get) Token: 0x0602CC72 RID: 183410 RVA: 0x00AAF319 File Offset: 0x00AAD519
		// (set) Token: 0x0602CC73 RID: 183411 RVA: 0x00AAF329 File Offset: 0x00AAD529
		public unsafe int RiseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170078FB RID: 30971
		// (get) Token: 0x0602CC74 RID: 183412 RVA: 0x00AAF33A File Offset: 0x00AAD53A
		// (set) Token: 0x0602CC75 RID: 183413 RVA: 0x00AAF34A File Offset: 0x00AAD54A
		public unsafe int DropSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170078FC RID: 30972
		// (get) Token: 0x0602CC76 RID: 183414 RVA: 0x00AAF35B File Offset: 0x00AAD55B
		// (set) Token: 0x0602CC77 RID: 183415 RVA: 0x00AAF36B File Offset: 0x00AAD56B
		public unsafe float AnimLerpAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170078FD RID: 30973
		// (get) Token: 0x0602CC78 RID: 183416 RVA: 0x00AAF37C File Offset: 0x00AAD57C
		// (set) Token: 0x0602CC79 RID: 183417 RVA: 0x00AAF38C File Offset: 0x00AAD58C
		public unsafe float SpeedAcceleration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170078FE RID: 30974
		// (get) Token: 0x0602CC7A RID: 183418 RVA: 0x00AAF39D File Offset: 0x00AAD59D
		// (set) Token: 0x0602CC7B RID: 183419 RVA: 0x00AAF3AD File Offset: 0x00AAD5AD
		public unsafe float DirectionLerpAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170078FF RID: 30975
		// (get) Token: 0x0602CC7C RID: 183420 RVA: 0x00AAF3C0 File Offset: 0x00AAD5C0
		// (set) Token: 0x0602CC7D RID: 183421 RVA: 0x00AAF3F9 File Offset: 0x00AAD5F9
		public FGameplayTagContainer ForbidRotationTagList
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._ForbidRotationTagList) == null)
				{
					result = (this._ForbidRotationTagList = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007900 RID: 30976
		// (get) Token: 0x0602CC7E RID: 183422 RVA: 0x00AAF41C File Offset: 0x00AAD61C
		// (set) Token: 0x0602CC7F RID: 183423 RVA: 0x00AAF455 File Offset: 0x00AAD655
		public SFloatingMovementState DefaultMode
		{
			get
			{
				base.FastCheckIsValid();
				SFloatingMovementState result;
				if ((result = this._DefaultMode) == null)
				{
					result = (this._DefaultMode = new SFloatingMovementState(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatingMovementState.StaticStruct(), base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007901 RID: 30977
		// (get) Token: 0x0602CC80 RID: 183424 RVA: 0x00AAF478 File Offset: 0x00AAD678
		// (set) Token: 0x0602CC81 RID: 183425 RVA: 0x00AAF4B1 File Offset: 0x00AAD6B1
		public SFloatingMovementState FloatingMode
		{
			get
			{
				base.FastCheckIsValid();
				SFloatingMovementState result;
				if ((result = this._FloatingMode) == null)
				{
					result = (this._FloatingMode = new SFloatingMovementState(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatingMovementState.StaticStruct(), base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007902 RID: 30978
		// (get) Token: 0x0602CC82 RID: 183426 RVA: 0x00AAF4D4 File Offset: 0x00AAD6D4
		// (set) Token: 0x0602CC83 RID: 183427 RVA: 0x00AAF50D File Offset: 0x00AAD70D
		public SFloatingMovementState RiseMode
		{
			get
			{
				base.FastCheckIsValid();
				SFloatingMovementState result;
				if ((result = this._RiseMode) == null)
				{
					result = (this._RiseMode = new SFloatingMovementState(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatingMovementState.StaticStruct(), base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007903 RID: 30979
		// (get) Token: 0x0602CC84 RID: 183428 RVA: 0x00AAF530 File Offset: 0x00AAD730
		// (set) Token: 0x0602CC85 RID: 183429 RVA: 0x00AAF569 File Offset: 0x00AAD769
		public SFloatingMovementState DropMode
		{
			get
			{
				base.FastCheckIsValid();
				SFloatingMovementState result;
				if ((result = this._DropMode) == null)
				{
					result = (this._DropMode = new SFloatingMovementState(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatingMovementState.StaticStruct(), base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007904 RID: 30980
		// (get) Token: 0x0602CC86 RID: 183430 RVA: 0x00AAF58C File Offset: 0x00AAD78C
		// (set) Token: 0x0602CC87 RID: 183431 RVA: 0x00AAF5C5 File Offset: 0x00AAD7C5
		public SFloatingMovementState WalkMode
		{
			get
			{
				base.FastCheckIsValid();
				SFloatingMovementState result;
				if ((result = this._WalkMode) == null)
				{
					result = (this._WalkMode = new SFloatingMovementState(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SFloatingMovementState.StaticStruct(), base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007905 RID: 30981
		// (get) Token: 0x0602CC88 RID: 183432 RVA: 0x00AAF5E8 File Offset: 0x00AAD7E8
		// (set) Token: 0x0602CC89 RID: 183433 RVA: 0x00AAF621 File Offset: 0x00AAD821
		public FGameplayTagContainer ForbidCloseToGrounTagList
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._ForbidCloseToGrounTagList) == null)
				{
					result = (this._ForbidCloseToGrounTagList = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_FloatingMovementConfig_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602CC8A RID: 183434 RVA: 0x00AAF642 File Offset: 0x00AAD842
		protected BP_FloatingMovementConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018F27 RID: 102183
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BP_FloatingMovementConfig.BP_FloatingMovementConfig_C";

		// Token: 0x04018F28 RID: 102184
		private static IntPtr _ClassPtr;

		// Token: 0x04018F29 RID: 102185
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018F2A RID: 102186
		internal static int __PropertyOffset_0;

		// Token: 0x04018F2B RID: 102187
		internal static int __PropertyOffset_1;

		// Token: 0x04018F2C RID: 102188
		internal static int __PropertyOffset_2;

		// Token: 0x04018F2D RID: 102189
		internal static int __PropertyOffset_3;

		// Token: 0x04018F2E RID: 102190
		internal static int __PropertyOffset_4;

		// Token: 0x04018F2F RID: 102191
		internal static int __PropertyOffset_5;

		// Token: 0x04018F30 RID: 102192
		internal static int __PropertyOffset_6;

		// Token: 0x04018F31 RID: 102193
		internal static int __PropertyOffset_7;

		// Token: 0x04018F32 RID: 102194
		internal static int __PropertyOffset_8;

		// Token: 0x04018F33 RID: 102195
		internal static int __PropertyOffset_9;

		// Token: 0x04018F34 RID: 102196
		internal static int __PropertyOffset_10;

		// Token: 0x04018F35 RID: 102197
		internal static int __PropertyOffset_11;

		// Token: 0x04018F36 RID: 102198
		internal static int __PropertyOffset_12;

		// Token: 0x04018F37 RID: 102199
		internal static int __PropertyOffset_13;

		// Token: 0x04018F38 RID: 102200
		internal static int __PropertyOffset_14;

		// Token: 0x04018F39 RID: 102201
		internal static int __PropertyOffset_15;

		// Token: 0x04018F3A RID: 102202
		internal static int __PropertyOffset_16;

		// Token: 0x04018F3B RID: 102203
		internal static int __PropertyOffset_17;

		// Token: 0x04018F3C RID: 102204
		internal static int __PropertyOffset_18;

		// Token: 0x04018F3D RID: 102205
		internal static int __PropertyOffset_19;

		// Token: 0x04018F3E RID: 102206
		[Nullable(2)]
		private FGameplayTagContainer _ForbidRotationTagList;

		// Token: 0x04018F3F RID: 102207
		internal static int __PropertyOffset_20;

		// Token: 0x04018F40 RID: 102208
		[Nullable(2)]
		private SFloatingMovementState _DefaultMode;

		// Token: 0x04018F41 RID: 102209
		internal static int __PropertyOffset_21;

		// Token: 0x04018F42 RID: 102210
		[Nullable(2)]
		private SFloatingMovementState _FloatingMode;

		// Token: 0x04018F43 RID: 102211
		internal static int __PropertyOffset_22;

		// Token: 0x04018F44 RID: 102212
		[Nullable(2)]
		private SFloatingMovementState _RiseMode;

		// Token: 0x04018F45 RID: 102213
		internal static int __PropertyOffset_23;

		// Token: 0x04018F46 RID: 102214
		[Nullable(2)]
		private SFloatingMovementState _DropMode;

		// Token: 0x04018F47 RID: 102215
		internal static int __PropertyOffset_24;

		// Token: 0x04018F48 RID: 102216
		[Nullable(2)]
		private SFloatingMovementState _WalkMode;

		// Token: 0x04018F49 RID: 102217
		internal static int __PropertyOffset_25;

		// Token: 0x04018F4A RID: 102218
		[Nullable(2)]
		private FGameplayTagContainer _ForbidCloseToGrounTagList;
	}
}
