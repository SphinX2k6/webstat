using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x0200502B RID: 20523
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EResourceId : IEquatable<EResourceId>
	{
		// Token: 0x06034DE7 RID: 216551 RVA: 0x00D46562 File Offset: 0x00D44762
		private EResourceId(string value)
		{
			this._Value = value;
		}

		// Token: 0x06034DE8 RID: 216552 RVA: 0x00D4656B File Offset: 0x00D4476B
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06034DE9 RID: 216553 RVA: 0x00D46573 File Offset: 0x00D44773
		public bool Equals(EResourceId other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x06034DEA RID: 216554 RVA: 0x00D46588 File Offset: 0x00D44788
		public override bool Equals(object obj)
		{
			if (obj is EResourceId)
			{
				EResourceId other = (EResourceId)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06034DEB RID: 216555 RVA: 0x00D465AD File Offset: 0x00D447AD
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06034DEC RID: 216556 RVA: 0x00D465C0 File Offset: 0x00D447C0
		public static bool operator ==(EResourceId left, EResourceId right)
		{
			return left.Equals(right);
		}

		// Token: 0x06034DED RID: 216557 RVA: 0x00D465CA File Offset: 0x00D447CA
		public static bool operator !=(EResourceId left, EResourceId right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0401E7A5 RID: 124837
		private readonly string _Value;

		// Token: 0x0401E7A6 RID: 124838
		public static readonly EResourceId PlanRole = new EResourceId("UiItem_PlanRole");

		// Token: 0x0401E7A7 RID: 124839
		public static readonly EResourceId PlanWeapon = new EResourceId("UiItem_PlanWeapon");

		// Token: 0x0401E7A8 RID: 124840
		public static readonly EResourceId PlanVision = new EResourceId("UiItem_PlanVision");

		// Token: 0x0401E7A9 RID: 124841
		public static readonly EResourceId PlanSkill = new EResourceId("UiItem_PlanRoleSkill");
	}
}
