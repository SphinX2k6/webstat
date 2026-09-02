using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Input.Structures
{
	// Token: 0x020041A6 RID: 16806
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(12, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 12)]
	[UnrealObjectPath("/Game/Aki/Character/Input/Structures/SInputCaches.SInputCaches")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 12)]
	public struct SInputCaches : IEqualityOperators<SInputCaches, SInputCaches, bool>, IEquatable<SInputCaches>, IUnrealScriptStruct
	{
		// Token: 0x0602C9E7 RID: 182759 RVA: 0x00AA8310 File Offset: 0x00AA6510
		public SInputCaches(float 按下, float 抬起, float 长按)
		{
			this.按下 = 按下;
			this.抬起 = 抬起;
			this.长按 = 长按;
		}

		// Token: 0x0602C9E8 RID: 182760 RVA: 0x00AA8327 File Offset: 0x00AA6527
		public static bool operator ==(SInputCaches left, SInputCaches right)
		{
			return left.按下 == right.按下 && left.抬起 == right.抬起 && left.长按 == right.长按;
		}

		// Token: 0x0602C9E9 RID: 182761 RVA: 0x00AA8355 File Offset: 0x00AA6555
		public static bool operator !=(SInputCaches left, SInputCaches right)
		{
			return !(left == right);
		}

		// Token: 0x0602C9EA RID: 182762 RVA: 0x00AA8361 File Offset: 0x00AA6561
		public bool Equals(SInputCaches other)
		{
			return this == other;
		}

		// Token: 0x0602C9EB RID: 182763 RVA: 0x00AA8370 File Offset: 0x00AA6570
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SInputCaches)
			{
				SInputCaches other = (SInputCaches)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602C9EC RID: 182764 RVA: 0x00AA8395 File Offset: 0x00AA6595
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float>(this.按下, this.抬起, this.长按);
		}

		// Token: 0x0602C9ED RID: 182765 RVA: 0x00AA83AE File Offset: 0x00AA65AE
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInputCaches._ScriptStructPtr != 0) ? SInputCaches._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Input/Structures/SInputCaches.SInputCaches", ref SInputCaches._ScriptStructPtr);
		}

		// Token: 0x04018D41 RID: 101697
		[FieldOffset(0)]
		public float 按下;

		// Token: 0x04018D42 RID: 101698
		[FieldOffset(4)]
		public float 抬起;

		// Token: 0x04018D43 RID: 101699
		[FieldOffset(8)]
		public float 长按;

		// Token: 0x04018D44 RID: 101700
		public const string __ObjectPath = "/Game/Aki/Character/Input/Structures/SInputCaches.SInputCaches";

		// Token: 0x04018D45 RID: 101701
		private static IntPtr _ScriptStructPtr;
	}
}
