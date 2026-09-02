using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.DT
{
	// Token: 0x02004010 RID: 16400
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/DT/SPerformanceRoleInfo.SPerformanceRoleInfo")]
	[UnrealStructLayout(8, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 8)]
	public class SPerformanceRoleInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602A99D RID: 174493 RVA: 0x00A5DA4D File Offset: 0x00A5BC4D
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPerformanceRoleInfo._ScriptStructPtr != 0) ? SPerformanceRoleInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Role/Common/Data/DT/SPerformanceRoleInfo.SPerformanceRoleInfo", ref SPerformanceRoleInfo._ScriptStructPtr);
		}

		// Token: 0x17006EF3 RID: 28403
		// (get) Token: 0x0602A99E RID: 174494 RVA: 0x00A5DA71 File Offset: 0x00A5BC71
		// (set) Token: 0x0602A99F RID: 174495 RVA: 0x00A5DA81 File Offset: 0x00A5BC81
		public unsafe float SkillRotateIn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPerformanceRoleInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPerformanceRoleInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006EF4 RID: 28404
		// (get) Token: 0x0602A9A0 RID: 174496 RVA: 0x00A5DA92 File Offset: 0x00A5BC92
		// (set) Token: 0x0602A9A1 RID: 174497 RVA: 0x00A5DAA2 File Offset: 0x00A5BCA2
		public unsafe float SkillRotateOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPerformanceRoleInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPerformanceRoleInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602A9A2 RID: 174498 RVA: 0x00A5DAB3 File Offset: 0x00A5BCB3
		public SPerformanceRoleInfo()
		{
		}

		// Token: 0x0602A9A3 RID: 174499 RVA: 0x00A5DABB File Offset: 0x00A5BCBB
		public SPerformanceRoleInfo(float SkillRotateIn, float SkillRotateOut)
		{
			this.SkillRotateIn = SkillRotateIn;
			this.SkillRotateOut = SkillRotateOut;
		}

		// Token: 0x0602A9A4 RID: 174500 RVA: 0x00A5DAD1 File Offset: 0x00A5BCD1
		protected override IntPtr GetUStructPtr()
		{
			return SPerformanceRoleInfo.StaticStruct();
		}

		// Token: 0x0602A9A5 RID: 174501 RVA: 0x00A5DADD File Offset: 0x00A5BCDD
		[NullableContext(2)]
		public SPerformanceRoleInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602A9A6 RID: 174502 RVA: 0x00A5DAE7 File Offset: 0x00A5BCE7
		public SPerformanceRoleInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602A9A7 RID: 174503 RVA: 0x00A5DAF2 File Offset: 0x00A5BCF2
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPerformanceRoleInfo(Pointer, false, true);
		}

		// Token: 0x0602A9A8 RID: 174504 RVA: 0x00A5DAFC File Offset: 0x00A5BCFC
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPerformanceRoleInfo(Pointer, MemoryOwner);
		}

		// Token: 0x040172D0 RID: 94928
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/DT/SPerformanceRoleInfo.SPerformanceRoleInfo";

		// Token: 0x040172D1 RID: 94929
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040172D2 RID: 94930
		internal static int __PropertyOffset_0;

		// Token: 0x040172D3 RID: 94931
		internal static int __PropertyOffset_1;
	}
}
