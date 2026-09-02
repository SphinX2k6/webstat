using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Input.Structures
{
	// Token: 0x020041A5 RID: 16805
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(2, 1, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 2)]
	[UnrealObjectPath("/Game/Aki/Character/Input/Structures/SInputAction.SInputAction")]
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 2)]
	public struct SInputAction : IEqualityOperators<SInputAction, SInputAction, bool>, IEquatable<SInputAction>, IUnrealScriptStruct
	{
		// Token: 0x0602C9E0 RID: 182752 RVA: 0x00AA8260 File Offset: 0x00AA6460
		public SInputAction(TEnumAsByte<EInputAction> Action, TEnumAsByte<EInputState> State)
		{
			this.Action = Action;
			this.State = State;
		}

		// Token: 0x0602C9E1 RID: 182753 RVA: 0x00AA8270 File Offset: 0x00AA6470
		public static bool operator ==(SInputAction left, SInputAction right)
		{
			return left.Action == right.Action && left.State == right.State;
		}

		// Token: 0x0602C9E2 RID: 182754 RVA: 0x00AA8298 File Offset: 0x00AA6498
		public static bool operator !=(SInputAction left, SInputAction right)
		{
			return !(left == right);
		}

		// Token: 0x0602C9E3 RID: 182755 RVA: 0x00AA82A4 File Offset: 0x00AA64A4
		public bool Equals(SInputAction other)
		{
			return this == other;
		}

		// Token: 0x0602C9E4 RID: 182756 RVA: 0x00AA82B4 File Offset: 0x00AA64B4
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SInputAction)
			{
				SInputAction other = (SInputAction)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602C9E5 RID: 182757 RVA: 0x00AA82D9 File Offset: 0x00AA64D9
		public override int GetHashCode()
		{
			return HashCode.Combine<TEnumAsByte<EInputAction>, TEnumAsByte<EInputState>>(this.Action, this.State);
		}

		// Token: 0x0602C9E6 RID: 182758 RVA: 0x00AA82EC File Offset: 0x00AA64EC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInputAction._ScriptStructPtr != 0) ? SInputAction._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Input/Structures/SInputAction.SInputAction", ref SInputAction._ScriptStructPtr);
		}

		// Token: 0x04018D3D RID: 101693
		[FieldOffset(0)]
		public TEnumAsByte<EInputAction> Action;

		// Token: 0x04018D3E RID: 101694
		[FieldOffset(1)]
		public TEnumAsByte<EInputState> State;

		// Token: 0x04018D3F RID: 101695
		public const string __ObjectPath = "/Game/Aki/Character/Input/Structures/SInputAction.SInputAction";

		// Token: 0x04018D40 RID: 101696
		private static IntPtr _ScriptStructPtr;
	}
}
