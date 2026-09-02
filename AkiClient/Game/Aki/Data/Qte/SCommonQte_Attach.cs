using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E44 RID: 15940
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 50)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/SCommonQte_Attach.SCommonQte_Attach")]
	[StructLayout(LayoutKind.Explicit, Pack = 8, Size = 56)]
	public struct SCommonQte_Attach : IEqualityOperators<SCommonQte_Attach, SCommonQte_Attach, bool>, IEquatable<SCommonQte_Attach>, IUnrealScriptStruct
	{
		// Token: 0x06027488 RID: 160904 RVA: 0x009EE17B File Offset: 0x009EC37B
		public SCommonQte_Attach(FVectorDouble Location, FVectorDouble Rotation, bool KeepRelativeToCamera, bool UseTargetScreenPos)
		{
			this.Location = Location;
			this.Rotation = Rotation;
			this.KeepRelativeToCamera = KeepRelativeToCamera;
			this.UseTargetScreenPos = UseTargetScreenPos;
		}

		// Token: 0x06027489 RID: 160905 RVA: 0x009EE19C File Offset: 0x009EC39C
		public static bool operator ==(SCommonQte_Attach left, SCommonQte_Attach right)
		{
			return left.Location == right.Location && left.Rotation == right.Rotation && left.KeepRelativeToCamera == right.KeepRelativeToCamera && left.UseTargetScreenPos == right.UseTargetScreenPos;
		}

		// Token: 0x0602748A RID: 160906 RVA: 0x009EE1ED File Offset: 0x009EC3ED
		public static bool operator !=(SCommonQte_Attach left, SCommonQte_Attach right)
		{
			return !(left == right);
		}

		// Token: 0x0602748B RID: 160907 RVA: 0x009EE1F9 File Offset: 0x009EC3F9
		public bool Equals(SCommonQte_Attach other)
		{
			return this == other;
		}

		// Token: 0x0602748C RID: 160908 RVA: 0x009EE208 File Offset: 0x009EC408
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SCommonQte_Attach)
			{
				SCommonQte_Attach other = (SCommonQte_Attach)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602748D RID: 160909 RVA: 0x009EE22D File Offset: 0x009EC42D
		public override int GetHashCode()
		{
			return HashCode.Combine<FVectorDouble, FVectorDouble, bool, bool>(this.Location, this.Rotation, this.KeepRelativeToCamera, this.UseTargetScreenPos);
		}

		// Token: 0x0602748E RID: 160910 RVA: 0x009EE24C File Offset: 0x009EC44C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCommonQte_Attach._ScriptStructPtr != 0) ? SCommonQte_Attach._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SCommonQte_Attach.SCommonQte_Attach", ref SCommonQte_Attach._ScriptStructPtr);
		}

		// Token: 0x04014912 RID: 84242
		[FieldOffset(0)]
		public FVectorDouble Location;

		// Token: 0x04014913 RID: 84243
		[FieldOffset(24)]
		public FVectorDouble Rotation;

		// Token: 0x04014914 RID: 84244
		[FieldOffset(48)]
		public bool KeepRelativeToCamera;

		// Token: 0x04014915 RID: 84245
		[FieldOffset(49)]
		public bool UseTargetScreenPos;

		// Token: 0x04014916 RID: 84246
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SCommonQte_Attach.SCommonQte_Attach";

		// Token: 0x04014917 RID: 84247
		private static IntPtr _ScriptStructPtr;
	}
}
