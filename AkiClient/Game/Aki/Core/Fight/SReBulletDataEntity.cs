using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F70 RID: 16240
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(8, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 5)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SReBulletDataEntity.SReBulletDataEntity")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
	public struct SReBulletDataEntity : IEqualityOperators<SReBulletDataEntity, SReBulletDataEntity, bool>, IEquatable<SReBulletDataEntity>, IUnrealScriptStruct
	{
		// Token: 0x06028925 RID: 166181 RVA: 0x00A0F2AB File Offset: 0x00A0D4AB
		public SReBulletDataEntity(int 实体ID, bool 是否随子弹销毁而销毁)
		{
			this.实体ID = 实体ID;
			this.是否随子弹销毁而销毁 = 是否随子弹销毁而销毁;
		}

		// Token: 0x06028926 RID: 166182 RVA: 0x00A0F2BB File Offset: 0x00A0D4BB
		public static bool operator ==(SReBulletDataEntity left, SReBulletDataEntity right)
		{
			return left.实体ID == right.实体ID && left.是否随子弹销毁而销毁 == right.是否随子弹销毁而销毁;
		}

		// Token: 0x06028927 RID: 166183 RVA: 0x00A0F2DB File Offset: 0x00A0D4DB
		public static bool operator !=(SReBulletDataEntity left, SReBulletDataEntity right)
		{
			return !(left == right);
		}

		// Token: 0x06028928 RID: 166184 RVA: 0x00A0F2E7 File Offset: 0x00A0D4E7
		public bool Equals(SReBulletDataEntity other)
		{
			return this == other;
		}

		// Token: 0x06028929 RID: 166185 RVA: 0x00A0F2F8 File Offset: 0x00A0D4F8
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SReBulletDataEntity)
			{
				SReBulletDataEntity other = (SReBulletDataEntity)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602892A RID: 166186 RVA: 0x00A0F31D File Offset: 0x00A0D51D
		public override int GetHashCode()
		{
			return HashCode.Combine<int, bool>(this.实体ID, this.是否随子弹销毁而销毁);
		}

		// Token: 0x0602892B RID: 166187 RVA: 0x00A0F330 File Offset: 0x00A0D530
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataEntity._ScriptStructPtr != 0) ? SReBulletDataEntity._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SReBulletDataEntity.SReBulletDataEntity", ref SReBulletDataEntity._ScriptStructPtr);
		}

		// Token: 0x04015655 RID: 87637
		[FieldOffset(0)]
		public int 实体ID;

		// Token: 0x04015656 RID: 87638
		[FieldOffset(4)]
		public bool 是否随子弹销毁而销毁;

		// Token: 0x04015657 RID: 87639
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SReBulletDataEntity.SReBulletDataEntity";

		// Token: 0x04015658 RID: 87640
		private static IntPtr _ScriptStructPtr;
	}
}
