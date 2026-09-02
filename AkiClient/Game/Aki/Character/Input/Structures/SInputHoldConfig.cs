using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Input.Structures
{
	// Token: 0x020041A8 RID: 16808
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(8, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 5)]
	[UnrealObjectPath("/Game/Aki/Character/Input/Structures/SInputHoldConfig.SInputHoldConfig")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
	public struct SInputHoldConfig : IEqualityOperators<SInputHoldConfig, SInputHoldConfig, bool>, IEquatable<SInputHoldConfig>, IUnrealScriptStruct
	{
		// Token: 0x0602C9FC RID: 182780 RVA: 0x00AA84C2 File Offset: 0x00AA66C2
		public SInputHoldConfig(float 触发时间, bool 连续触发)
		{
			this.触发时间 = 触发时间;
			this.连续触发 = 连续触发;
		}

		// Token: 0x0602C9FD RID: 182781 RVA: 0x00AA84D2 File Offset: 0x00AA66D2
		public static bool operator ==(SInputHoldConfig left, SInputHoldConfig right)
		{
			return left.触发时间 == right.触发时间 && left.连续触发 == right.连续触发;
		}

		// Token: 0x0602C9FE RID: 182782 RVA: 0x00AA84F2 File Offset: 0x00AA66F2
		public static bool operator !=(SInputHoldConfig left, SInputHoldConfig right)
		{
			return !(left == right);
		}

		// Token: 0x0602C9FF RID: 182783 RVA: 0x00AA84FE File Offset: 0x00AA66FE
		public bool Equals(SInputHoldConfig other)
		{
			return this == other;
		}

		// Token: 0x0602CA00 RID: 182784 RVA: 0x00AA850C File Offset: 0x00AA670C
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SInputHoldConfig)
			{
				SInputHoldConfig other = (SInputHoldConfig)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602CA01 RID: 182785 RVA: 0x00AA8531 File Offset: 0x00AA6731
		public override int GetHashCode()
		{
			return HashCode.Combine<float, bool>(this.触发时间, this.连续触发);
		}

		// Token: 0x0602CA02 RID: 182786 RVA: 0x00AA8544 File Offset: 0x00AA6744
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInputHoldConfig._ScriptStructPtr != 0) ? SInputHoldConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Input/Structures/SInputHoldConfig.SInputHoldConfig", ref SInputHoldConfig._ScriptStructPtr);
		}

		// Token: 0x04018D4B RID: 101707
		[FieldOffset(0)]
		public float 触发时间;

		// Token: 0x04018D4C RID: 101708
		[FieldOffset(4)]
		public bool 连续触发;

		// Token: 0x04018D4D RID: 101709
		public const string __ObjectPath = "/Game/Aki/Character/Input/Structures/SInputHoldConfig.SInputHoldConfig";

		// Token: 0x04018D4E RID: 101710
		private static IntPtr _ScriptStructPtr;
	}
}
