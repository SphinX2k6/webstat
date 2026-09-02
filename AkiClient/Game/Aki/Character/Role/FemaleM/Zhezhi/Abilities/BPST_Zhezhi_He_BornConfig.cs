using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Role.FemaleM.Zhezhi.Abilities
{
	// Token: 0x02003FF2 RID: 16370
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 24)]
	[UnrealObjectPath("/Game/Aki/Character/Role/FemaleM/Zhezhi/Abilities/BPST_Zhezhi_He_BornConfig.BPST_Zhezhi_He_BornConfig")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 24)]
	public struct BPST_Zhezhi_He_BornConfig : IEqualityOperators<BPST_Zhezhi_He_BornConfig, BPST_Zhezhi_He_BornConfig, bool>, IEquatable<BPST_Zhezhi_He_BornConfig>, IUnrealScriptStruct
	{
		// Token: 0x060296B9 RID: 169657 RVA: 0x00A2DA6C File Offset: 0x00A2BC6C
		public BPST_Zhezhi_He_BornConfig(FVector BornOffset, float BornAddRot, int SommonID, int SkillID)
		{
			this.BornOffset = BornOffset;
			this.BornAddRot = BornAddRot;
			this.SommonID = SommonID;
			this.SkillID = SkillID;
		}

		// Token: 0x060296BA RID: 169658 RVA: 0x00A2DA8C File Offset: 0x00A2BC8C
		public static bool operator ==(BPST_Zhezhi_He_BornConfig left, BPST_Zhezhi_He_BornConfig right)
		{
			return left.BornOffset == right.BornOffset && left.BornAddRot == right.BornAddRot && left.SommonID == right.SommonID && left.SkillID == right.SkillID;
		}

		// Token: 0x060296BB RID: 169659 RVA: 0x00A2DAD8 File Offset: 0x00A2BCD8
		public static bool operator !=(BPST_Zhezhi_He_BornConfig left, BPST_Zhezhi_He_BornConfig right)
		{
			return !(left == right);
		}

		// Token: 0x060296BC RID: 169660 RVA: 0x00A2DAE4 File Offset: 0x00A2BCE4
		public bool Equals(BPST_Zhezhi_He_BornConfig other)
		{
			return this == other;
		}

		// Token: 0x060296BD RID: 169661 RVA: 0x00A2DAF4 File Offset: 0x00A2BCF4
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is BPST_Zhezhi_He_BornConfig)
			{
				BPST_Zhezhi_He_BornConfig other = (BPST_Zhezhi_He_BornConfig)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060296BE RID: 169662 RVA: 0x00A2DB19 File Offset: 0x00A2BD19
		public override int GetHashCode()
		{
			return HashCode.Combine<FVector, float, int, int>(this.BornOffset, this.BornAddRot, this.SommonID, this.SkillID);
		}

		// Token: 0x060296BF RID: 169663 RVA: 0x00A2DB38 File Offset: 0x00A2BD38
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (BPST_Zhezhi_He_BornConfig._ScriptStructPtr != 0) ? BPST_Zhezhi_He_BornConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Role/FemaleM/Zhezhi/Abilities/BPST_Zhezhi_He_BornConfig.BPST_Zhezhi_He_BornConfig", ref BPST_Zhezhi_He_BornConfig._ScriptStructPtr);
		}

		// Token: 0x04016104 RID: 90372
		[FieldOffset(0)]
		public FVector BornOffset;

		// Token: 0x04016105 RID: 90373
		[FieldOffset(12)]
		public float BornAddRot;

		// Token: 0x04016106 RID: 90374
		[FieldOffset(16)]
		public int SommonID;

		// Token: 0x04016107 RID: 90375
		[FieldOffset(20)]
		public int SkillID;

		// Token: 0x04016108 RID: 90376
		public const string __ObjectPath = "/Game/Aki/Character/Role/FemaleM/Zhezhi/Abilities/BPST_Zhezhi_He_BornConfig.BPST_Zhezhi_He_BornConfig";

		// Token: 0x04016109 RID: 90377
		private static IntPtr _ScriptStructPtr;
	}
}
