using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200424D RID: 16973
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(28, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 25)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SClimbInfo.SClimbInfo")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 28)]
	public struct SClimbInfo : IEqualityOperators<SClimbInfo, SClimbInfo, bool>, IEquatable<SClimbInfo>, IUnrealScriptStruct
	{
		// Token: 0x0602CF37 RID: 184119 RVA: 0x00AB3F18 File Offset: 0x00AB2118
		public SClimbInfo(FVector 攀爬速度向量, bool 攀爬移动中, FVector2D 攀爬输入向量, bool 攀爬受阻)
		{
			this.攀爬速度向量 = 攀爬速度向量;
			this.攀爬移动中 = 攀爬移动中;
			this.攀爬输入向量 = 攀爬输入向量;
			this.攀爬受阻 = 攀爬受阻;
		}

		// Token: 0x0602CF38 RID: 184120 RVA: 0x00AB3F38 File Offset: 0x00AB2138
		public static bool operator ==(SClimbInfo left, SClimbInfo right)
		{
			return left.攀爬速度向量 == right.攀爬速度向量 && left.攀爬移动中 == right.攀爬移动中 && left.攀爬输入向量 == right.攀爬输入向量 && left.攀爬受阻 == right.攀爬受阻;
		}

		// Token: 0x0602CF39 RID: 184121 RVA: 0x00AB3F89 File Offset: 0x00AB2189
		public static bool operator !=(SClimbInfo left, SClimbInfo right)
		{
			return !(left == right);
		}

		// Token: 0x0602CF3A RID: 184122 RVA: 0x00AB3F95 File Offset: 0x00AB2195
		public bool Equals(SClimbInfo other)
		{
			return this == other;
		}

		// Token: 0x0602CF3B RID: 184123 RVA: 0x00AB3FA4 File Offset: 0x00AB21A4
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SClimbInfo)
			{
				SClimbInfo other = (SClimbInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602CF3C RID: 184124 RVA: 0x00AB3FC9 File Offset: 0x00AB21C9
		public override int GetHashCode()
		{
			return HashCode.Combine<FVector, bool, FVector2D, bool>(this.攀爬速度向量, this.攀爬移动中, this.攀爬输入向量, this.攀爬受阻);
		}

		// Token: 0x0602CF3D RID: 184125 RVA: 0x00AB3FE8 File Offset: 0x00AB21E8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SClimbInfo._ScriptStructPtr != 0) ? SClimbInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SClimbInfo.SClimbInfo", ref SClimbInfo._ScriptStructPtr);
		}

		// Token: 0x04019371 RID: 103281
		[FieldOffset(0)]
		public FVector 攀爬速度向量;

		// Token: 0x04019372 RID: 103282
		[FieldOffset(12)]
		public bool 攀爬移动中;

		// Token: 0x04019373 RID: 103283
		[FieldOffset(16)]
		public FVector2D 攀爬输入向量;

		// Token: 0x04019374 RID: 103284
		[FieldOffset(24)]
		public bool 攀爬受阻;

		// Token: 0x04019375 RID: 103285
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SClimbInfo.SClimbInfo";

		// Token: 0x04019376 RID: 103286
		private static IntPtr _ScriptStructPtr;
	}
}
