using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x0200430D RID: 17165
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SBaseCurve.SBaseCurve")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SBaseCurve : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D70E RID: 186126 RVA: 0x00AC0480 File Offset: 0x00ABE680
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBaseCurve._ScriptStructPtr != 0) ? SBaseCurve._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SBaseCurve.SBaseCurve", ref SBaseCurve._ScriptStructPtr);
		}

		// Token: 0x17007C08 RID: 31752
		// (get) Token: 0x0602D70F RID: 186127 RVA: 0x00AC04A4 File Offset: 0x00ABE6A4
		// (set) Token: 0x0602D710 RID: 186128 RVA: 0x00AC04B8 File Offset: 0x00ABE6B8
		public unsafe TEnumAsByte<EBaseCurveType> CurveType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBaseCurve.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBaseCurve.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007C09 RID: 31753
		// (get) Token: 0x0602D711 RID: 186129 RVA: 0x00AC04CD File Offset: 0x00ABE6CD
		// (set) Token: 0x0602D712 RID: 186130 RVA: 0x00AC04DD File Offset: 0x00ABE6DD
		public unsafe float N
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBaseCurve.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBaseCurve.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007C0A RID: 31754
		// (get) Token: 0x0602D713 RID: 186131 RVA: 0x00AC04EE File Offset: 0x00ABE6EE
		// (set) Token: 0x0602D714 RID: 186132 RVA: 0x00AC0502 File Offset: 0x00ABE702
		[Nullable(2)]
		public unsafe UCurveFloat FloatCurve
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + SBaseCurve.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SBaseCurve.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0602D715 RID: 186133 RVA: 0x00AC0517 File Offset: 0x00ABE717
		public SBaseCurve()
		{
		}

		// Token: 0x0602D716 RID: 186134 RVA: 0x00AC051F File Offset: 0x00ABE71F
		public SBaseCurve(TEnumAsByte<EBaseCurveType> CurveType, float N, [Nullable(1)] UCurveFloat FloatCurve)
		{
			this.CurveType = CurveType;
			this.N = N;
			this.FloatCurve = FloatCurve;
		}

		// Token: 0x0602D717 RID: 186135 RVA: 0x00AC053C File Offset: 0x00ABE73C
		protected override IntPtr GetUStructPtr()
		{
			return SBaseCurve.StaticStruct();
		}

		// Token: 0x0602D718 RID: 186136 RVA: 0x00AC0548 File Offset: 0x00ABE748
		[NullableContext(2)]
		public SBaseCurve(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D719 RID: 186137 RVA: 0x00AC0552 File Offset: 0x00ABE752
		public SBaseCurve(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D71A RID: 186138 RVA: 0x00AC055D File Offset: 0x00ABE75D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBaseCurve(Pointer, false, true);
		}

		// Token: 0x0602D71B RID: 186139 RVA: 0x00AC0567 File Offset: 0x00ABE767
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBaseCurve(Pointer, MemoryOwner);
		}

		// Token: 0x040199E6 RID: 104934
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SBaseCurve.SBaseCurve";

		// Token: 0x040199E7 RID: 104935
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040199E8 RID: 104936
		internal static int __PropertyOffset_0;

		// Token: 0x040199E9 RID: 104937
		internal static int __PropertyOffset_1;

		// Token: 0x040199EA RID: 104938
		internal static int __PropertyOffset_2;
	}
}
