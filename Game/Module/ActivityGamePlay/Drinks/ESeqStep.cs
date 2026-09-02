using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ActivityGamePlay.Drinks
{
	// Token: 0x020069EB RID: 27115
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct ESeqStep : IEquatable<ESeqStep>
	{
		// Token: 0x06043322 RID: 275234 RVA: 0x011447DC File Offset: 0x011429DC
		private ESeqStep(string value)
		{
			this._Value = value;
		}

		// Token: 0x06043323 RID: 275235 RVA: 0x011447E5 File Offset: 0x011429E5
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06043324 RID: 275236 RVA: 0x011447ED File Offset: 0x011429ED
		public bool Equals(ESeqStep other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x06043325 RID: 275237 RVA: 0x01144800 File Offset: 0x01142A00
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is ESeqStep)
			{
				ESeqStep other = (ESeqStep)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06043326 RID: 275238 RVA: 0x01144825 File Offset: 0x01142A25
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06043327 RID: 275239 RVA: 0x01144838 File Offset: 0x01142A38
		public static bool operator ==(ESeqStep left, ESeqStep right)
		{
			return left.Equals(right);
		}

		// Token: 0x06043328 RID: 275240 RVA: 0x01144842 File Offset: 0x01142A42
		public static bool operator !=(ESeqStep left, ESeqStep right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06043329 RID: 275241 RVA: 0x0114484F File Offset: 0x01142A4F
		public static implicit operator string(ESeqStep step)
		{
			return step._Value;
		}

		// Token: 0x04025718 RID: 153368
		private readonly string _Value;

		// Token: 0x04025719 RID: 153369
		public static readonly ESeqStep Begin = new ESeqStep("A");

		// Token: 0x0402571A RID: 153370
		public static readonly ESeqStep DrinksStart = new ESeqStep("B");

		// Token: 0x0402571B RID: 153371
		public static readonly ESeqStep DrinkQTE1End = new ESeqStep("C");

		// Token: 0x0402571C RID: 153372
		public static readonly ESeqStep DrinkQTE2End = new ESeqStep("D");

		// Token: 0x0402571D RID: 153373
		public static readonly ESeqStep DrinkQTE3End = new ESeqStep("E");

		// Token: 0x0402571E RID: 153374
		public static readonly ESeqStep BatchingEnd = new ESeqStep("F");

		// Token: 0x0402571F RID: 153375
		public static readonly ESeqStep ShakeEnd = new ESeqStep("G");

		// Token: 0x04025720 RID: 153376
		public static readonly ESeqStep ShowEnd = new ESeqStep("H");
	}
}
