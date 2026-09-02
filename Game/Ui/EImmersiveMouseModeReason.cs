using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A24 RID: 18980
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EImmersiveMouseModeReason : IEquatable<EImmersiveMouseModeReason>
	{
		// Token: 0x0603198A RID: 203146 RVA: 0x00C5B473 File Offset: 0x00C59673
		private EImmersiveMouseModeReason(string value)
		{
			this._Value = value;
		}

		// Token: 0x0603198B RID: 203147 RVA: 0x00C5B47C File Offset: 0x00C5967C
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x0603198C RID: 203148 RVA: 0x00C5B484 File Offset: 0x00C59684
		public bool Equals(EImmersiveMouseModeReason other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x0603198D RID: 203149 RVA: 0x00C5B498 File Offset: 0x00C59698
		public override bool Equals(object obj)
		{
			if (obj is EImmersiveMouseModeReason)
			{
				EImmersiveMouseModeReason other = (EImmersiveMouseModeReason)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0603198E RID: 203150 RVA: 0x00C5B4BD File Offset: 0x00C596BD
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x0603198F RID: 203151 RVA: 0x00C5B4D0 File Offset: 0x00C596D0
		public static bool operator ==(EImmersiveMouseModeReason left, EImmersiveMouseModeReason right)
		{
			return left.Equals(right);
		}

		// Token: 0x06031990 RID: 203152 RVA: 0x00C5B4DA File Offset: 0x00C596DA
		public static bool operator !=(EImmersiveMouseModeReason left, EImmersiveMouseModeReason right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0401CE0C RID: 118284
		private readonly string _Value;

		// Token: 0x0401CE0D RID: 118285
		public static readonly EImmersiveMouseModeReason Qte = new EImmersiveMouseModeReason("Qte");

		// Token: 0x0401CE0E RID: 118286
		public static readonly EImmersiveMouseModeReason Qta = new EImmersiveMouseModeReason("Qta");

		// Token: 0x0401CE0F RID: 118287
		public static readonly EImmersiveMouseModeReason PlotAutoSelectOptionHover = new EImmersiveMouseModeReason("PlotAutoSelectOptionHover");
	}
}
