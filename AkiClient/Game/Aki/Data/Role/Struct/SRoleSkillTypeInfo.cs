using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Role.Struct
{
	// Token: 0x02003E0F RID: 15887
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(12, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 12)]
	[UnrealObjectPath("/Game/Aki/Data/Role/Struct/SRoleSkillTypeInfo.SRoleSkillTypeInfo")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 12)]
	public struct SRoleSkillTypeInfo : IEqualityOperators<SRoleSkillTypeInfo, SRoleSkillTypeInfo, bool>, IEquatable<SRoleSkillTypeInfo>, IUnrealScriptStruct
	{
		// Token: 0x060272A1 RID: 160417 RVA: 0x009EB45C File Offset: 0x009E965C
		public SRoleSkillTypeInfo(FName 技能类别名称)
		{
			this.技能类别名称 = 技能类别名称;
		}

		// Token: 0x060272A2 RID: 160418 RVA: 0x009EB465 File Offset: 0x009E9665
		public static bool operator ==(SRoleSkillTypeInfo left, SRoleSkillTypeInfo right)
		{
			return left.技能类别名称 == right.技能类别名称;
		}

		// Token: 0x060272A3 RID: 160419 RVA: 0x009EB478 File Offset: 0x009E9678
		public static bool operator !=(SRoleSkillTypeInfo left, SRoleSkillTypeInfo right)
		{
			return !(left == right);
		}

		// Token: 0x060272A4 RID: 160420 RVA: 0x009EB484 File Offset: 0x009E9684
		public bool Equals(SRoleSkillTypeInfo other)
		{
			return this == other;
		}

		// Token: 0x060272A5 RID: 160421 RVA: 0x009EB494 File Offset: 0x009E9694
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SRoleSkillTypeInfo)
			{
				SRoleSkillTypeInfo other = (SRoleSkillTypeInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060272A6 RID: 160422 RVA: 0x009EB4B9 File Offset: 0x009E96B9
		public override int GetHashCode()
		{
			return HashCode.Combine<FName>(this.技能类别名称);
		}

		// Token: 0x060272A7 RID: 160423 RVA: 0x009EB4C6 File Offset: 0x009E96C6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRoleSkillTypeInfo._ScriptStructPtr != 0) ? SRoleSkillTypeInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Role/Struct/SRoleSkillTypeInfo.SRoleSkillTypeInfo", ref SRoleSkillTypeInfo._ScriptStructPtr);
		}

		// Token: 0x04014765 RID: 83813
		[FieldOffset(0)]
		public FName 技能类别名称;

		// Token: 0x04014766 RID: 83814
		public const string __ObjectPath = "/Game/Aki/Data/Role/Struct/SRoleSkillTypeInfo.SRoleSkillTypeInfo";

		// Token: 0x04014767 RID: 83815
		private static IntPtr _ScriptStructPtr;
	}
}
