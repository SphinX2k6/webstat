using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200426B RID: 17003
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(8, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 8)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SKSCSkillAction.SKSCSkillAction")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
	public struct SKSCSkillAction : IEqualityOperators<SKSCSkillAction, SKSCSkillAction, bool>, IEquatable<SKSCSkillAction>, IUnrealScriptStruct
	{
		// Token: 0x0602D15F RID: 184671 RVA: 0x00AB6FE8 File Offset: 0x00AB51E8
		public SKSCSkillAction(TEnumAsByte<EKSCSkillActionType> ActionType, int SkillIndex)
		{
			this.ActionType = ActionType;
			this.SkillIndex = SkillIndex;
		}

		// Token: 0x0602D160 RID: 184672 RVA: 0x00AB6FF8 File Offset: 0x00AB51F8
		public static bool operator ==(SKSCSkillAction left, SKSCSkillAction right)
		{
			return left.ActionType == right.ActionType && left.SkillIndex == right.SkillIndex;
		}

		// Token: 0x0602D161 RID: 184673 RVA: 0x00AB701D File Offset: 0x00AB521D
		public static bool operator !=(SKSCSkillAction left, SKSCSkillAction right)
		{
			return !(left == right);
		}

		// Token: 0x0602D162 RID: 184674 RVA: 0x00AB7029 File Offset: 0x00AB5229
		public bool Equals(SKSCSkillAction other)
		{
			return this == other;
		}

		// Token: 0x0602D163 RID: 184675 RVA: 0x00AB7038 File Offset: 0x00AB5238
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SKSCSkillAction)
			{
				SKSCSkillAction other = (SKSCSkillAction)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602D164 RID: 184676 RVA: 0x00AB705D File Offset: 0x00AB525D
		public override int GetHashCode()
		{
			return HashCode.Combine<TEnumAsByte<EKSCSkillActionType>, int>(this.ActionType, this.SkillIndex);
		}

		// Token: 0x0602D165 RID: 184677 RVA: 0x00AB7070 File Offset: 0x00AB5270
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SKSCSkillAction._ScriptStructPtr != 0) ? SKSCSkillAction._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SKSCSkillAction.SKSCSkillAction", ref SKSCSkillAction._ScriptStructPtr);
		}

		// Token: 0x0401947A RID: 103546
		[FieldOffset(0)]
		public TEnumAsByte<EKSCSkillActionType> ActionType;

		// Token: 0x0401947B RID: 103547
		[FieldOffset(4)]
		public int SkillIndex;

		// Token: 0x0401947C RID: 103548
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SKSCSkillAction.SKSCSkillAction";

		// Token: 0x0401947D RID: 103549
		private static IntPtr _ScriptStructPtr;
	}
}
