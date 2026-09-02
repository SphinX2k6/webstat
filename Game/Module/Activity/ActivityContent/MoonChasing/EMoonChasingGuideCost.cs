using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing
{
	// Token: 0x0200674D RID: 26445
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EMoonChasingGuideCost : IEquatable<EMoonChasingGuideCost>
	{
		// Token: 0x06041F10 RID: 270096 RVA: 0x010EAACC File Offset: 0x010E8CCC
		private EMoonChasingGuideCost(string value)
		{
			this._Value = value;
		}

		// Token: 0x06041F11 RID: 270097 RVA: 0x010EAAD5 File Offset: 0x010E8CD5
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06041F12 RID: 270098 RVA: 0x010EAADD File Offset: 0x010E8CDD
		public bool Equals(EMoonChasingGuideCost other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x06041F13 RID: 270099 RVA: 0x010EAAF0 File Offset: 0x010E8CF0
		public override bool Equals(object obj)
		{
			if (obj is EMoonChasingGuideCost)
			{
				EMoonChasingGuideCost other = (EMoonChasingGuideCost)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06041F14 RID: 270100 RVA: 0x010EAB15 File Offset: 0x010E8D15
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06041F15 RID: 270101 RVA: 0x010EAB28 File Offset: 0x010E8D28
		public static bool operator ==(EMoonChasingGuideCost left, EMoonChasingGuideCost right)
		{
			return left.Equals(right);
		}

		// Token: 0x06041F16 RID: 270102 RVA: 0x010EAB32 File Offset: 0x010E8D32
		public static bool operator !=(EMoonChasingGuideCost left, EMoonChasingGuideCost right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04024CA0 RID: 150688
		private readonly string _Value;

		// Token: 0x04024CA1 RID: 150689
		public static readonly EMoonChasingGuideCost Cost = new EMoonChasingGuideCost("Cost");
	}
}
