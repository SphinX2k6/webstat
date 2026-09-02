using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004260 RID: 16992
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SFollowMoveInfo.SFollowMoveInfo")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 60)]
	public class SFollowMoveInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D068 RID: 184424 RVA: 0x00AB5B1C File Offset: 0x00AB3D1C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFollowMoveInfo._ScriptStructPtr != 0) ? SFollowMoveInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SFollowMoveInfo.SFollowMoveInfo", ref SFollowMoveInfo._ScriptStructPtr);
		}

		// Token: 0x17007A2B RID: 31275
		// (get) Token: 0x0602D069 RID: 184425 RVA: 0x00AB5B40 File Offset: 0x00AB3D40
		// (set) Token: 0x0602D06A RID: 184426 RVA: 0x00AB5B54 File Offset: 0x00AB3D54
		public unsafe TEnumAsByte<EFollowTargetType> FollowTargetType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A2C RID: 31276
		// (get) Token: 0x0602D06B RID: 184427 RVA: 0x00AB5B69 File Offset: 0x00AB3D69
		// (set) Token: 0x0602D06C RID: 184428 RVA: 0x00AB5B7D File Offset: 0x00AB3D7D
		[Nullable(1)]
		public unsafe string EntityIdBlackboardKey
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SFollowMoveInfo.__PropertyOffset_1)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SFollowMoveInfo.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17007A2D RID: 31277
		// (get) Token: 0x0602D06D RID: 184429 RVA: 0x00AB5B92 File Offset: 0x00AB3D92
		// (set) Token: 0x0602D06E RID: 184430 RVA: 0x00AB5BA6 File Offset: 0x00AB3DA6
		public unsafe FVector Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A2E RID: 31278
		// (get) Token: 0x0602D06F RID: 184431 RVA: 0x00AB5BBB File Offset: 0x00AB3DBB
		// (set) Token: 0x0602D070 RID: 184432 RVA: 0x00AB5BCB File Offset: 0x00AB3DCB
		public unsafe int MaxMoveSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007A2F RID: 31279
		// (get) Token: 0x0602D071 RID: 184433 RVA: 0x00AB5BDC File Offset: 0x00AB3DDC
		// (set) Token: 0x0602D072 RID: 184434 RVA: 0x00AB5BEC File Offset: 0x00AB3DEC
		public unsafe bool KeepDistanceMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007A30 RID: 31280
		// (get) Token: 0x0602D073 RID: 184435 RVA: 0x00AB5BFD File Offset: 0x00AB3DFD
		// (set) Token: 0x0602D074 RID: 184436 RVA: 0x00AB5C0D File Offset: 0x00AB3E0D
		public unsafe int DistanceMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007A31 RID: 31281
		// (get) Token: 0x0602D075 RID: 184437 RVA: 0x00AB5C1E File Offset: 0x00AB3E1E
		// (set) Token: 0x0602D076 RID: 184438 RVA: 0x00AB5C2E File Offset: 0x00AB3E2E
		public unsafe int DistanceMaxSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007A32 RID: 31282
		// (get) Token: 0x0602D077 RID: 184439 RVA: 0x00AB5C3F File Offset: 0x00AB3E3F
		// (set) Token: 0x0602D078 RID: 184440 RVA: 0x00AB5C4F File Offset: 0x00AB3E4F
		public unsafe int DistanceMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007A33 RID: 31283
		// (get) Token: 0x0602D079 RID: 184441 RVA: 0x00AB5C60 File Offset: 0x00AB3E60
		// (set) Token: 0x0602D07A RID: 184442 RVA: 0x00AB5C70 File Offset: 0x00AB3E70
		public unsafe int DistanceForceMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFollowMoveInfo.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x0602D07B RID: 184443 RVA: 0x00AB5C81 File Offset: 0x00AB3E81
		public SFollowMoveInfo()
		{
		}

		// Token: 0x0602D07C RID: 184444 RVA: 0x00AB5C8C File Offset: 0x00AB3E8C
		public SFollowMoveInfo(TEnumAsByte<EFollowTargetType> FollowTargetType, [Nullable(1)] string EntityIdBlackboardKey, FVector Offset, int MaxMoveSpeed, bool KeepDistanceMin, int DistanceMin, int DistanceMaxSpeed, int DistanceMax, int DistanceForceMove)
		{
			this.FollowTargetType = FollowTargetType;
			this.EntityIdBlackboardKey = EntityIdBlackboardKey;
			this.Offset = Offset;
			this.MaxMoveSpeed = MaxMoveSpeed;
			this.KeepDistanceMin = KeepDistanceMin;
			this.DistanceMin = DistanceMin;
			this.DistanceMaxSpeed = DistanceMaxSpeed;
			this.DistanceMax = DistanceMax;
			this.DistanceForceMove = DistanceForceMove;
		}

		// Token: 0x0602D07D RID: 184445 RVA: 0x00AB5CE4 File Offset: 0x00AB3EE4
		protected override IntPtr GetUStructPtr()
		{
			return SFollowMoveInfo.StaticStruct();
		}

		// Token: 0x0602D07E RID: 184446 RVA: 0x00AB5CF0 File Offset: 0x00AB3EF0
		[NullableContext(2)]
		public SFollowMoveInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D07F RID: 184447 RVA: 0x00AB5CFA File Offset: 0x00AB3EFA
		public SFollowMoveInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D080 RID: 184448 RVA: 0x00AB5D05 File Offset: 0x00AB3F05
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFollowMoveInfo(Pointer, false, true);
		}

		// Token: 0x0602D081 RID: 184449 RVA: 0x00AB5D0F File Offset: 0x00AB3F0F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFollowMoveInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04019408 RID: 103432
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SFollowMoveInfo.SFollowMoveInfo";

		// Token: 0x04019409 RID: 103433
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401940A RID: 103434
		internal static int __PropertyOffset_0;

		// Token: 0x0401940B RID: 103435
		internal static int __PropertyOffset_1;

		// Token: 0x0401940C RID: 103436
		internal static int __PropertyOffset_2;

		// Token: 0x0401940D RID: 103437
		internal static int __PropertyOffset_3;

		// Token: 0x0401940E RID: 103438
		internal static int __PropertyOffset_4;

		// Token: 0x0401940F RID: 103439
		internal static int __PropertyOffset_5;

		// Token: 0x04019410 RID: 103440
		internal static int __PropertyOffset_6;

		// Token: 0x04019411 RID: 103441
		internal static int __PropertyOffset_7;

		// Token: 0x04019412 RID: 103442
		internal static int __PropertyOffset_8;
	}
}
