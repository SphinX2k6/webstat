using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006673 RID: 26227
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EMowingBuffQualityHexColor : IEquatable<EMowingBuffQualityHexColor>
	{
		// Token: 0x0604182A RID: 268330 RVA: 0x010D09B7 File Offset: 0x010CEBB7
		private EMowingBuffQualityHexColor(string value)
		{
			this._Value = value;
		}

		// Token: 0x0604182B RID: 268331 RVA: 0x010D09C0 File Offset: 0x010CEBC0
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x0604182C RID: 268332 RVA: 0x010D09C8 File Offset: 0x010CEBC8
		public bool Equals(EMowingBuffQualityHexColor other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x0604182D RID: 268333 RVA: 0x010D09DC File Offset: 0x010CEBDC
		public override bool Equals(object obj)
		{
			if (obj is EMowingBuffQualityHexColor)
			{
				EMowingBuffQualityHexColor other = (EMowingBuffQualityHexColor)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0604182E RID: 268334 RVA: 0x010D0A01 File Offset: 0x010CEC01
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x0604182F RID: 268335 RVA: 0x010D0A14 File Offset: 0x010CEC14
		public static bool operator ==(EMowingBuffQualityHexColor left, EMowingBuffQualityHexColor right)
		{
			return left.Equals(right);
		}

		// Token: 0x06041830 RID: 268336 RVA: 0x010D0A1E File Offset: 0x010CEC1E
		public static bool operator !=(EMowingBuffQualityHexColor left, EMowingBuffQualityHexColor right)
		{
			return !left.Equals(right);
		}

		// Token: 0x040249C5 RID: 149957
		private readonly string _Value;

		// Token: 0x040249C6 RID: 149958
		public static readonly EMowingBuffQualityHexColor Default = new EMowingBuffQualityHexColor("FFFFFFFF");

		// Token: 0x040249C7 RID: 149959
		public static readonly EMowingBuffQualityHexColor Gold = new EMowingBuffQualityHexColor("FFBD47FF");

		// Token: 0x040249C8 RID: 149960
		public static readonly EMowingBuffQualityHexColor Purple = new EMowingBuffQualityHexColor("7645A3FF");

		// Token: 0x040249C9 RID: 149961
		public static readonly EMowingBuffQualityHexColor Blue = new EMowingBuffQualityHexColor("3E9DFFFF");
	}
}
