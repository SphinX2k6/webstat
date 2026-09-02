using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004319 RID: 17177
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SFloatCurve.SFloatCurve")]
	[UnrealStructLayout(8, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 8)]
	public class SFloatCurve : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D8F3 RID: 186611 RVA: 0x00AC373C File Offset: 0x00AC193C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFloatCurve._ScriptStructPtr != 0) ? SFloatCurve._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SFloatCurve.SFloatCurve", ref SFloatCurve._ScriptStructPtr);
		}

		// Token: 0x17007CCB RID: 31947
		// (get) Token: 0x0602D8F4 RID: 186612 RVA: 0x00AC3760 File Offset: 0x00AC1960
		// (set) Token: 0x0602D8F5 RID: 186613 RVA: 0x00AC3774 File Offset: 0x00AC1974
		[Nullable(2)]
		public unsafe UCurveFloat FloatCurve
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + SFloatCurve.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SFloatCurve.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602D8F6 RID: 186614 RVA: 0x00AC3789 File Offset: 0x00AC1989
		public SFloatCurve()
		{
		}

		// Token: 0x0602D8F7 RID: 186615 RVA: 0x00AC3791 File Offset: 0x00AC1991
		[NullableContext(1)]
		public SFloatCurve(UCurveFloat FloatCurve)
		{
			this.FloatCurve = FloatCurve;
		}

		// Token: 0x0602D8F8 RID: 186616 RVA: 0x00AC37A0 File Offset: 0x00AC19A0
		protected override IntPtr GetUStructPtr()
		{
			return SFloatCurve.StaticStruct();
		}

		// Token: 0x0602D8F9 RID: 186617 RVA: 0x00AC37AC File Offset: 0x00AC19AC
		[NullableContext(2)]
		public SFloatCurve(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D8FA RID: 186618 RVA: 0x00AC37B6 File Offset: 0x00AC19B6
		public SFloatCurve(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D8FB RID: 186619 RVA: 0x00AC37C1 File Offset: 0x00AC19C1
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFloatCurve(Pointer, false, true);
		}

		// Token: 0x0602D8FC RID: 186620 RVA: 0x00AC37CB File Offset: 0x00AC19CB
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFloatCurve(Pointer, MemoryOwner);
		}

		// Token: 0x04019AFE RID: 105214
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SFloatCurve.SFloatCurve";

		// Token: 0x04019AFF RID: 105215
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019B00 RID: 105216
		internal static int __PropertyOffset_0;
	}
}
