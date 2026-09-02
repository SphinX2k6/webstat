using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F6D RID: 16237
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(12, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 12)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SReBulletDataAimed.SReBulletDataAimed")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 12)]
	public struct SReBulletDataAimed : IEqualityOperators<SReBulletDataAimed, SReBulletDataAimed, bool>, IEquatable<SReBulletDataAimed>, IUnrealScriptStruct
	{
		// Token: 0x060288A2 RID: 166050 RVA: 0x00A0E618 File Offset: 0x00A0C818
		public SReBulletDataAimed(bool 跟随骨骼发射, bool 初始旋转是否面向目标, bool 瞄准发射, float 瞄准子弹最大偏转角度, float 瞄准子弹最大射程)
		{
			this.跟随骨骼发射 = 跟随骨骼发射;
			this.初始旋转是否面向目标 = 初始旋转是否面向目标;
			this.瞄准发射 = 瞄准发射;
			this.瞄准子弹最大偏转角度 = 瞄准子弹最大偏转角度;
			this.瞄准子弹最大射程 = 瞄准子弹最大射程;
		}

		// Token: 0x060288A3 RID: 166051 RVA: 0x00A0E640 File Offset: 0x00A0C840
		public static bool operator ==(SReBulletDataAimed left, SReBulletDataAimed right)
		{
			return left.跟随骨骼发射 == right.跟随骨骼发射 && left.初始旋转是否面向目标 == right.初始旋转是否面向目标 && left.瞄准发射 == right.瞄准发射 && left.瞄准子弹最大偏转角度 == right.瞄准子弹最大偏转角度 && left.瞄准子弹最大射程 == right.瞄准子弹最大射程;
		}

		// Token: 0x060288A4 RID: 166052 RVA: 0x00A0E695 File Offset: 0x00A0C895
		public static bool operator !=(SReBulletDataAimed left, SReBulletDataAimed right)
		{
			return !(left == right);
		}

		// Token: 0x060288A5 RID: 166053 RVA: 0x00A0E6A1 File Offset: 0x00A0C8A1
		public bool Equals(SReBulletDataAimed other)
		{
			return this == other;
		}

		// Token: 0x060288A6 RID: 166054 RVA: 0x00A0E6B0 File Offset: 0x00A0C8B0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SReBulletDataAimed)
			{
				SReBulletDataAimed other = (SReBulletDataAimed)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060288A7 RID: 166055 RVA: 0x00A0E6D5 File Offset: 0x00A0C8D5
		public override int GetHashCode()
		{
			return HashCode.Combine<bool, bool, bool, float, float>(this.跟随骨骼发射, this.初始旋转是否面向目标, this.瞄准发射, this.瞄准子弹最大偏转角度, this.瞄准子弹最大射程);
		}

		// Token: 0x060288A8 RID: 166056 RVA: 0x00A0E6FA File Offset: 0x00A0C8FA
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataAimed._ScriptStructPtr != 0) ? SReBulletDataAimed._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SReBulletDataAimed.SReBulletDataAimed", ref SReBulletDataAimed._ScriptStructPtr);
		}

		// Token: 0x0401560E RID: 87566
		[FieldOffset(0)]
		public bool 跟随骨骼发射;

		// Token: 0x0401560F RID: 87567
		[FieldOffset(1)]
		public bool 初始旋转是否面向目标;

		// Token: 0x04015610 RID: 87568
		[FieldOffset(2)]
		public bool 瞄准发射;

		// Token: 0x04015611 RID: 87569
		[FieldOffset(4)]
		public float 瞄准子弹最大偏转角度;

		// Token: 0x04015612 RID: 87570
		[FieldOffset(8)]
		public float 瞄准子弹最大射程;

		// Token: 0x04015613 RID: 87571
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SReBulletDataAimed.SReBulletDataAimed";

		// Token: 0x04015614 RID: 87572
		private static IntPtr _ScriptStructPtr;
	}
}
