using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200424E RID: 16974
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(3, 1, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 3)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SClimbState.SClimbState")]
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 3)]
	public struct SClimbState : IEqualityOperators<SClimbState, SClimbState, bool>, IEquatable<SClimbState>, IUnrealScriptStruct
	{
		// Token: 0x0602CF3E RID: 184126 RVA: 0x00AB400C File Offset: 0x00AB220C
		public SClimbState(TEnumAsByte<EClimbState> 攀爬状态, TEnumAsByte<EEnterClimb> 进入攀爬类型, TEnumAsByte<EExitClimb> 退出攀爬类型)
		{
			this.攀爬状态 = 攀爬状态;
			this.进入攀爬类型 = 进入攀爬类型;
			this.退出攀爬类型 = 退出攀爬类型;
		}

		// Token: 0x0602CF3F RID: 184127 RVA: 0x00AB4023 File Offset: 0x00AB2223
		public static bool operator ==(SClimbState left, SClimbState right)
		{
			return left.攀爬状态 == right.攀爬状态 && left.进入攀爬类型 == right.进入攀爬类型 && left.退出攀爬类型 == right.退出攀爬类型;
		}

		// Token: 0x0602CF40 RID: 184128 RVA: 0x00AB405E File Offset: 0x00AB225E
		public static bool operator !=(SClimbState left, SClimbState right)
		{
			return !(left == right);
		}

		// Token: 0x0602CF41 RID: 184129 RVA: 0x00AB406A File Offset: 0x00AB226A
		public bool Equals(SClimbState other)
		{
			return this == other;
		}

		// Token: 0x0602CF42 RID: 184130 RVA: 0x00AB4078 File Offset: 0x00AB2278
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SClimbState)
			{
				SClimbState other = (SClimbState)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602CF43 RID: 184131 RVA: 0x00AB409D File Offset: 0x00AB229D
		public override int GetHashCode()
		{
			return HashCode.Combine<TEnumAsByte<EClimbState>, TEnumAsByte<EEnterClimb>, TEnumAsByte<EExitClimb>>(this.攀爬状态, this.进入攀爬类型, this.退出攀爬类型);
		}

		// Token: 0x0602CF44 RID: 184132 RVA: 0x00AB40B6 File Offset: 0x00AB22B6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SClimbState._ScriptStructPtr != 0) ? SClimbState._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SClimbState.SClimbState", ref SClimbState._ScriptStructPtr);
		}

		// Token: 0x04019377 RID: 103287
		[FieldOffset(0)]
		public TEnumAsByte<EClimbState> 攀爬状态;

		// Token: 0x04019378 RID: 103288
		[FieldOffset(1)]
		public TEnumAsByte<EEnterClimb> 进入攀爬类型;

		// Token: 0x04019379 RID: 103289
		[FieldOffset(2)]
		public TEnumAsByte<EExitClimb> 退出攀爬类型;

		// Token: 0x0401937A RID: 103290
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SClimbState.SClimbState";

		// Token: 0x0401937B RID: 103291
		private static IntPtr _ScriptStructPtr;
	}
}
