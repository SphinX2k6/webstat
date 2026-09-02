using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Scene.Assets.PCG.BP_Tools
{
	// Token: 0x020039F0 RID: 14832
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 16)]
	[UnrealObjectPath("/Game/Aki/Scene/Assets/PCG/BP_Tools/Rock_Matrix_4.Rock_Matrix_4")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
	public struct Rock_Matrix_4 : IEqualityOperators<Rock_Matrix_4, Rock_Matrix_4, bool>, IEquatable<Rock_Matrix_4>, IUnrealScriptStruct
	{
		// Token: 0x0601E13F RID: 123199 RVA: 0x008EB2DA File Offset: 0x008E94DA
		public Rock_Matrix_4(float m_xy, float m_xz, float m_yz, float k)
		{
			this.m_xy = m_xy;
			this.m_xz = m_xz;
			this.m_yz = m_yz;
			this.k = k;
		}

		// Token: 0x0601E140 RID: 123200 RVA: 0x008EB2F9 File Offset: 0x008E94F9
		public static bool operator ==(Rock_Matrix_4 left, Rock_Matrix_4 right)
		{
			return left.m_xy == right.m_xy && left.m_xz == right.m_xz && left.m_yz == right.m_yz && left.k == right.k;
		}

		// Token: 0x0601E141 RID: 123201 RVA: 0x008EB335 File Offset: 0x008E9535
		public static bool operator !=(Rock_Matrix_4 left, Rock_Matrix_4 right)
		{
			return !(left == right);
		}

		// Token: 0x0601E142 RID: 123202 RVA: 0x008EB341 File Offset: 0x008E9541
		public bool Equals(Rock_Matrix_4 other)
		{
			return this == other;
		}

		// Token: 0x0601E143 RID: 123203 RVA: 0x008EB350 File Offset: 0x008E9550
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is Rock_Matrix_4)
			{
				Rock_Matrix_4 other = (Rock_Matrix_4)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0601E144 RID: 123204 RVA: 0x008EB375 File Offset: 0x008E9575
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float, float>(this.m_xy, this.m_xz, this.m_yz, this.k);
		}

		// Token: 0x0601E145 RID: 123205 RVA: 0x008EB394 File Offset: 0x008E9594
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (Rock_Matrix_4._ScriptStructPtr != 0) ? Rock_Matrix_4._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Scene/Assets/PCG/BP_Tools/Rock_Matrix_4.Rock_Matrix_4", ref Rock_Matrix_4._ScriptStructPtr);
		}

		// Token: 0x0400EC33 RID: 60467
		[FieldOffset(0)]
		public float m_xy;

		// Token: 0x0400EC34 RID: 60468
		[FieldOffset(4)]
		public float m_xz;

		// Token: 0x0400EC35 RID: 60469
		[FieldOffset(8)]
		public float m_yz;

		// Token: 0x0400EC36 RID: 60470
		[FieldOffset(12)]
		public float k;

		// Token: 0x0400EC37 RID: 60471
		public const string __ObjectPath = "/Game/Aki/Scene/Assets/PCG/BP_Tools/Rock_Matrix_4.Rock_Matrix_4";

		// Token: 0x0400EC38 RID: 60472
		private static IntPtr _ScriptStructPtr;
	}
}
