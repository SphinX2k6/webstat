using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004285 RID: 17029
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 16)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SVelocityBlend.SVelocityBlend")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
	public struct SVelocityBlend : IEqualityOperators<SVelocityBlend, SVelocityBlend, bool>, IEquatable<SVelocityBlend>, IUnrealScriptStruct
	{
		// Token: 0x0602D3CF RID: 185295 RVA: 0x00ABAC51 File Offset: 0x00AB8E51
		public SVelocityBlend(float 前, float 后, float 左, float 右)
		{
			this.前 = 前;
			this.后 = 后;
			this.左 = 左;
			this.右 = 右;
		}

		// Token: 0x0602D3D0 RID: 185296 RVA: 0x00ABAC70 File Offset: 0x00AB8E70
		public static bool operator ==(SVelocityBlend left, SVelocityBlend right)
		{
			return left.前 == right.前 && left.后 == right.后 && left.左 == right.左 && left.右 == right.右;
		}

		// Token: 0x0602D3D1 RID: 185297 RVA: 0x00ABACAC File Offset: 0x00AB8EAC
		public static bool operator !=(SVelocityBlend left, SVelocityBlend right)
		{
			return !(left == right);
		}

		// Token: 0x0602D3D2 RID: 185298 RVA: 0x00ABACB8 File Offset: 0x00AB8EB8
		public bool Equals(SVelocityBlend other)
		{
			return this == other;
		}

		// Token: 0x0602D3D3 RID: 185299 RVA: 0x00ABACC8 File Offset: 0x00AB8EC8
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SVelocityBlend)
			{
				SVelocityBlend other = (SVelocityBlend)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602D3D4 RID: 185300 RVA: 0x00ABACED File Offset: 0x00AB8EED
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float, float>(this.前, this.后, this.左, this.右);
		}

		// Token: 0x0602D3D5 RID: 185301 RVA: 0x00ABAD0C File Offset: 0x00AB8F0C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SVelocityBlend._ScriptStructPtr != 0) ? SVelocityBlend._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SVelocityBlend.SVelocityBlend", ref SVelocityBlend._ScriptStructPtr);
		}

		// Token: 0x040195BF RID: 103871
		[FieldOffset(0)]
		public float 前;

		// Token: 0x040195C0 RID: 103872
		[FieldOffset(4)]
		public float 后;

		// Token: 0x040195C1 RID: 103873
		[FieldOffset(8)]
		public float 左;

		// Token: 0x040195C2 RID: 103874
		[FieldOffset(12)]
		public float 右;

		// Token: 0x040195C3 RID: 103875
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SVelocityBlend.SVelocityBlend";

		// Token: 0x040195C4 RID: 103876
		private static IntPtr _ScriptStructPtr;
	}
}
