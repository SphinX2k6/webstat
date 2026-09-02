using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Level.KeepFollowing
{
	// Token: 0x02003E7C RID: 15996
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Level/KeepFollowing/SFreeFollowingConfig.SFreeFollowingConfig")]
	[UnrealStructLayout(72, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 69)]
	public class SFreeFollowingConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060279B8 RID: 162232 RVA: 0x009F6192 File Offset: 0x009F4392
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFreeFollowingConfig._ScriptStructPtr != 0) ? SFreeFollowingConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Level/KeepFollowing/SFreeFollowingConfig.SFreeFollowingConfig", ref SFreeFollowingConfig._ScriptStructPtr);
		}

		// Token: 0x17005DDB RID: 24027
		// (get) Token: 0x060279B9 RID: 162233 RVA: 0x009F61B6 File Offset: 0x009F43B6
		// (set) Token: 0x060279BA RID: 162234 RVA: 0x009F61C6 File Offset: 0x009F43C6
		public unsafe bool Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DDC RID: 24028
		// (get) Token: 0x060279BB RID: 162235 RVA: 0x009F61D7 File Offset: 0x009F43D7
		// (set) Token: 0x060279BC RID: 162236 RVA: 0x009F61E7 File Offset: 0x009F43E7
		public unsafe bool FollowOnRight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DDD RID: 24029
		// (get) Token: 0x060279BD RID: 162237 RVA: 0x009F61F8 File Offset: 0x009F43F8
		// (set) Token: 0x060279BE RID: 162238 RVA: 0x009F6208 File Offset: 0x009F4408
		public unsafe bool AutoChangeSide
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DDE RID: 24030
		// (get) Token: 0x060279BF RID: 162239 RVA: 0x009F6219 File Offset: 0x009F4419
		// (set) Token: 0x060279C0 RID: 162240 RVA: 0x009F6229 File Offset: 0x009F4429
		public unsafe float StartFollowingRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005DDF RID: 24031
		// (get) Token: 0x060279C1 RID: 162241 RVA: 0x009F623A File Offset: 0x009F443A
		// (set) Token: 0x060279C2 RID: 162242 RVA: 0x009F624A File Offset: 0x009F444A
		public unsafe float WalkStartFollowingRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005DE0 RID: 24032
		// (get) Token: 0x060279C3 RID: 162243 RVA: 0x009F625B File Offset: 0x009F445B
		// (set) Token: 0x060279C4 RID: 162244 RVA: 0x009F626B File Offset: 0x009F446B
		public unsafe float FollowRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005DE1 RID: 24033
		// (get) Token: 0x060279C5 RID: 162245 RVA: 0x009F627C File Offset: 0x009F447C
		// (set) Token: 0x060279C6 RID: 162246 RVA: 0x009F628C File Offset: 0x009F448C
		public unsafe float WalkFollowRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005DE2 RID: 24034
		// (get) Token: 0x060279C7 RID: 162247 RVA: 0x009F629D File Offset: 0x009F449D
		// (set) Token: 0x060279C8 RID: 162248 RVA: 0x009F62AD File Offset: 0x009F44AD
		public unsafe float MaxForwardOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005DE3 RID: 24035
		// (get) Token: 0x060279C9 RID: 162249 RVA: 0x009F62BE File Offset: 0x009F44BE
		// (set) Token: 0x060279CA RID: 162250 RVA: 0x009F62CE File Offset: 0x009F44CE
		public unsafe float FullForwardOffsetSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005DE4 RID: 24036
		// (get) Token: 0x060279CB RID: 162251 RVA: 0x009F62DF File Offset: 0x009F44DF
		// (set) Token: 0x060279CC RID: 162252 RVA: 0x009F62EF File Offset: 0x009F44EF
		public unsafe float SideAngleTolerance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005DE5 RID: 24037
		// (get) Token: 0x060279CD RID: 162253 RVA: 0x009F6300 File Offset: 0x009F4500
		// (set) Token: 0x060279CE RID: 162254 RVA: 0x009F6310 File Offset: 0x009F4510
		public unsafe float OffsetAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005DE6 RID: 24038
		// (get) Token: 0x060279CF RID: 162255 RVA: 0x009F6321 File Offset: 0x009F4521
		// (set) Token: 0x060279D0 RID: 162256 RVA: 0x009F6331 File Offset: 0x009F4531
		public unsafe float MovementIntentSmoothingTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005DE7 RID: 24039
		// (get) Token: 0x060279D1 RID: 162257 RVA: 0x009F6342 File Offset: 0x009F4542
		// (set) Token: 0x060279D2 RID: 162258 RVA: 0x009F6352 File Offset: 0x009F4552
		public unsafe float StopConfirmTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005DE8 RID: 24040
		// (get) Token: 0x060279D3 RID: 162259 RVA: 0x009F6363 File Offset: 0x009F4563
		// (set) Token: 0x060279D4 RID: 162260 RVA: 0x009F6373 File Offset: 0x009F4573
		public unsafe float WalkBehindTargetPauseTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005DE9 RID: 24041
		// (get) Token: 0x060279D5 RID: 162261 RVA: 0x009F6384 File Offset: 0x009F4584
		// (set) Token: 0x060279D6 RID: 162262 RVA: 0x009F6394 File Offset: 0x009F4594
		public unsafe float RunReferenceDirectionSmoothingTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005DEA RID: 24042
		// (get) Token: 0x060279D7 RID: 162263 RVA: 0x009F63A5 File Offset: 0x009F45A5
		// (set) Token: 0x060279D8 RID: 162264 RVA: 0x009F63B5 File Offset: 0x009F45B5
		public unsafe float SprintReferenceDirectionSmoothingTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005DEB RID: 24043
		// (get) Token: 0x060279D9 RID: 162265 RVA: 0x009F63C6 File Offset: 0x009F45C6
		// (set) Token: 0x060279DA RID: 162266 RVA: 0x009F63D6 File Offset: 0x009F45D6
		public unsafe bool EnableLocalMovementHold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DEC RID: 24044
		// (get) Token: 0x060279DB RID: 162267 RVA: 0x009F63E7 File Offset: 0x009F45E7
		// (set) Token: 0x060279DC RID: 162268 RVA: 0x009F63F7 File Offset: 0x009F45F7
		public unsafe float LocalMovementEnterRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005DED RID: 24045
		// (get) Token: 0x060279DD RID: 162269 RVA: 0x009F6408 File Offset: 0x009F4608
		// (set) Token: 0x060279DE RID: 162270 RVA: 0x009F6418 File Offset: 0x009F4618
		public unsafe float LocalMovementEnterConfirmTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005DEE RID: 24046
		// (get) Token: 0x060279DF RID: 162271 RVA: 0x009F6429 File Offset: 0x009F4629
		// (set) Token: 0x060279E0 RID: 162272 RVA: 0x009F6439 File Offset: 0x009F4639
		public unsafe bool DebugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFreeFollowingConfig.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x060279E1 RID: 162273 RVA: 0x009F644A File Offset: 0x009F464A
		public SFreeFollowingConfig()
		{
		}

		// Token: 0x060279E2 RID: 162274 RVA: 0x009F6454 File Offset: 0x009F4654
		public SFreeFollowingConfig(bool Enable, bool FollowOnRight, bool AutoChangeSide, float StartFollowingRadius, float WalkStartFollowingRadius, float FollowRadius, float WalkFollowRadius, float MaxForwardOffset, float FullForwardOffsetSpeed, float SideAngleTolerance, float OffsetAngle, float MovementIntentSmoothingTime, float StopConfirmTime, float WalkBehindTargetPauseTime, float RunReferenceDirectionSmoothingTime, float SprintReferenceDirectionSmoothingTime, bool EnableLocalMovementHold, float LocalMovementEnterRate, float LocalMovementEnterConfirmTime, bool DebugDraw)
		{
			this.Enable = Enable;
			this.FollowOnRight = FollowOnRight;
			this.AutoChangeSide = AutoChangeSide;
			this.StartFollowingRadius = StartFollowingRadius;
			this.WalkStartFollowingRadius = WalkStartFollowingRadius;
			this.FollowRadius = FollowRadius;
			this.WalkFollowRadius = WalkFollowRadius;
			this.MaxForwardOffset = MaxForwardOffset;
			this.FullForwardOffsetSpeed = FullForwardOffsetSpeed;
			this.SideAngleTolerance = SideAngleTolerance;
			this.OffsetAngle = OffsetAngle;
			this.MovementIntentSmoothingTime = MovementIntentSmoothingTime;
			this.StopConfirmTime = StopConfirmTime;
			this.WalkBehindTargetPauseTime = WalkBehindTargetPauseTime;
			this.RunReferenceDirectionSmoothingTime = RunReferenceDirectionSmoothingTime;
			this.SprintReferenceDirectionSmoothingTime = SprintReferenceDirectionSmoothingTime;
			this.EnableLocalMovementHold = EnableLocalMovementHold;
			this.LocalMovementEnterRate = LocalMovementEnterRate;
			this.LocalMovementEnterConfirmTime = LocalMovementEnterConfirmTime;
			this.DebugDraw = DebugDraw;
		}

		// Token: 0x060279E3 RID: 162275 RVA: 0x009F6504 File Offset: 0x009F4704
		protected override IntPtr GetUStructPtr()
		{
			return SFreeFollowingConfig.StaticStruct();
		}

		// Token: 0x060279E4 RID: 162276 RVA: 0x009F6510 File Offset: 0x009F4710
		[NullableContext(2)]
		public SFreeFollowingConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060279E5 RID: 162277 RVA: 0x009F651A File Offset: 0x009F471A
		public SFreeFollowingConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060279E6 RID: 162278 RVA: 0x009F6525 File Offset: 0x009F4725
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFreeFollowingConfig(Pointer, false, true);
		}

		// Token: 0x060279E7 RID: 162279 RVA: 0x009F652F File Offset: 0x009F472F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFreeFollowingConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014C35 RID: 85045
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Level/KeepFollowing/SFreeFollowingConfig.SFreeFollowingConfig";

		// Token: 0x04014C36 RID: 85046
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014C37 RID: 85047
		internal static int __PropertyOffset_0;

		// Token: 0x04014C38 RID: 85048
		internal static int __PropertyOffset_1;

		// Token: 0x04014C39 RID: 85049
		internal static int __PropertyOffset_2;

		// Token: 0x04014C3A RID: 85050
		internal static int __PropertyOffset_3;

		// Token: 0x04014C3B RID: 85051
		internal static int __PropertyOffset_4;

		// Token: 0x04014C3C RID: 85052
		internal static int __PropertyOffset_5;

		// Token: 0x04014C3D RID: 85053
		internal static int __PropertyOffset_6;

		// Token: 0x04014C3E RID: 85054
		internal static int __PropertyOffset_7;

		// Token: 0x04014C3F RID: 85055
		internal static int __PropertyOffset_8;

		// Token: 0x04014C40 RID: 85056
		internal static int __PropertyOffset_9;

		// Token: 0x04014C41 RID: 85057
		internal static int __PropertyOffset_10;

		// Token: 0x04014C42 RID: 85058
		internal static int __PropertyOffset_11;

		// Token: 0x04014C43 RID: 85059
		internal static int __PropertyOffset_12;

		// Token: 0x04014C44 RID: 85060
		internal static int __PropertyOffset_13;

		// Token: 0x04014C45 RID: 85061
		internal static int __PropertyOffset_14;

		// Token: 0x04014C46 RID: 85062
		internal static int __PropertyOffset_15;

		// Token: 0x04014C47 RID: 85063
		internal static int __PropertyOffset_16;

		// Token: 0x04014C48 RID: 85064
		internal static int __PropertyOffset_17;

		// Token: 0x04014C49 RID: 85065
		internal static int __PropertyOffset_18;

		// Token: 0x04014C4A RID: 85066
		internal static int __PropertyOffset_19;
	}
}
