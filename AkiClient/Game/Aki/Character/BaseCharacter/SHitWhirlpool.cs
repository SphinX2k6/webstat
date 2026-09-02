using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004268 RID: 17000
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SHitWhirlpool.SHitWhirlpool")]
	[UnrealStructLayout(28, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 25)]
	public class SHitWhirlpool : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D123 RID: 184611 RVA: 0x00AB6B2B File Offset: 0x00AB4D2B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SHitWhirlpool._ScriptStructPtr != 0) ? SHitWhirlpool._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SHitWhirlpool.SHitWhirlpool", ref SHitWhirlpool._ScriptStructPtr);
		}

		// Token: 0x17007A69 RID: 31337
		// (get) Token: 0x0602D124 RID: 184612 RVA: 0x00AB6B4F File Offset: 0x00AB4D4F
		// (set) Token: 0x0602D125 RID: 184613 RVA: 0x00AB6B63 File Offset: 0x00AB4D63
		public unsafe FVector 滞空相对位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitWhirlpool.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitWhirlpool.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A6A RID: 31338
		// (get) Token: 0x0602D126 RID: 184614 RVA: 0x00AB6B78 File Offset: 0x00AB4D78
		// (set) Token: 0x0602D127 RID: 184615 RVA: 0x00AB6B88 File Offset: 0x00AB4D88
		public unsafe float 滞空时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitWhirlpool.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitWhirlpool.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A6B RID: 31339
		// (get) Token: 0x0602D128 RID: 184616 RVA: 0x00AB6B99 File Offset: 0x00AB4D99
		// (set) Token: 0x0602D129 RID: 184617 RVA: 0x00AB6BA9 File Offset: 0x00AB4DA9
		public unsafe float 到滞空点时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitWhirlpool.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitWhirlpool.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A6C RID: 31340
		// (get) Token: 0x0602D12A RID: 184618 RVA: 0x00AB6BBA File Offset: 0x00AB4DBA
		// (set) Token: 0x0602D12B RID: 184619 RVA: 0x00AB6BCA File Offset: 0x00AB4DCA
		public unsafe float 滞空高度限制
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitWhirlpool.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitWhirlpool.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007A6D RID: 31341
		// (get) Token: 0x0602D12C RID: 184620 RVA: 0x00AB6BDB File Offset: 0x00AB4DDB
		// (set) Token: 0x0602D12D RID: 184621 RVA: 0x00AB6BEF File Offset: 0x00AB4DEF
		public unsafe TEnumAsByte<EVelocityCurveType> 到滞空点曲线
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHitWhirlpool.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHitWhirlpool.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602D12E RID: 184622 RVA: 0x00AB6C04 File Offset: 0x00AB4E04
		public SHitWhirlpool()
		{
		}

		// Token: 0x0602D12F RID: 184623 RVA: 0x00AB6C0C File Offset: 0x00AB4E0C
		public SHitWhirlpool(FVector 滞空相对位置, float 滞空时间, float 到滞空点时间, float 滞空高度限制, TEnumAsByte<EVelocityCurveType> 到滞空点曲线)
		{
			this.滞空相对位置 = 滞空相对位置;
			this.滞空时间 = 滞空时间;
			this.到滞空点时间 = 到滞空点时间;
			this.滞空高度限制 = 滞空高度限制;
			this.到滞空点曲线 = 到滞空点曲线;
		}

		// Token: 0x0602D130 RID: 184624 RVA: 0x00AB6C39 File Offset: 0x00AB4E39
		protected override IntPtr GetUStructPtr()
		{
			return SHitWhirlpool.StaticStruct();
		}

		// Token: 0x0602D131 RID: 184625 RVA: 0x00AB6C45 File Offset: 0x00AB4E45
		[NullableContext(2)]
		public SHitWhirlpool(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D132 RID: 184626 RVA: 0x00AB6C4F File Offset: 0x00AB4E4F
		public SHitWhirlpool(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D133 RID: 184627 RVA: 0x00AB6C5A File Offset: 0x00AB4E5A
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SHitWhirlpool(Pointer, false, true);
		}

		// Token: 0x0602D134 RID: 184628 RVA: 0x00AB6C64 File Offset: 0x00AB4E64
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SHitWhirlpool(Pointer, MemoryOwner);
		}

		// Token: 0x04019460 RID: 103520
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SHitWhirlpool.SHitWhirlpool";

		// Token: 0x04019461 RID: 103521
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019462 RID: 103522
		internal static int __PropertyOffset_0;

		// Token: 0x04019463 RID: 103523
		internal static int __PropertyOffset_1;

		// Token: 0x04019464 RID: 103524
		internal static int __PropertyOffset_2;

		// Token: 0x04019465 RID: 103525
		internal static int __PropertyOffset_3;

		// Token: 0x04019466 RID: 103526
		internal static int __PropertyOffset_4;
	}
}
