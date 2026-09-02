using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle
{
	// Token: 0x020055A4 RID: 21924
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EPhantomBattleHeadAnim : IEquatable<EPhantomBattleHeadAnim>
	{
		// Token: 0x06037CD2 RID: 228562 RVA: 0x00E235F4 File Offset: 0x00E217F4
		private EPhantomBattleHeadAnim(string value)
		{
			this._Value = value;
		}

		// Token: 0x06037CD3 RID: 228563 RVA: 0x00E235FD File Offset: 0x00E217FD
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06037CD4 RID: 228564 RVA: 0x00E23605 File Offset: 0x00E21805
		public bool Equals(EPhantomBattleHeadAnim other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x06037CD5 RID: 228565 RVA: 0x00E23618 File Offset: 0x00E21818
		public override bool Equals(object obj)
		{
			if (obj is EPhantomBattleHeadAnim)
			{
				EPhantomBattleHeadAnim other = (EPhantomBattleHeadAnim)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06037CD6 RID: 228566 RVA: 0x00E2363D File Offset: 0x00E2183D
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06037CD7 RID: 228567 RVA: 0x00E23650 File Offset: 0x00E21850
		public static bool operator ==(EPhantomBattleHeadAnim left, EPhantomBattleHeadAnim right)
		{
			return left.Equals(right);
		}

		// Token: 0x06037CD8 RID: 228568 RVA: 0x00E2365A File Offset: 0x00E2185A
		public static bool operator !=(EPhantomBattleHeadAnim left, EPhantomBattleHeadAnim right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0401FF40 RID: 130880
		private readonly string _Value;

		// Token: 0x0401FF41 RID: 130881
		public static readonly EPhantomBattleHeadAnim FactorMeShow = new EPhantomBattleHeadAnim("LightShowRight");

		// Token: 0x0401FF42 RID: 130882
		public static readonly EPhantomBattleHeadAnim FactorOtherShow = new EPhantomBattleHeadAnim("LightShowLeft");

		// Token: 0x0401FF43 RID: 130883
		public static readonly EPhantomBattleHeadAnim DamageAccumulate = new EPhantomBattleHeadAnim("DamageAccumulate");

		// Token: 0x0401FF44 RID: 130884
		public static readonly EPhantomBattleHeadAnim Damage = new EPhantomBattleHeadAnim("Damage");

		// Token: 0x0401FF45 RID: 130885
		public static readonly EPhantomBattleHeadAnim DamageNPC = new EPhantomBattleHeadAnim("DamageNPC");

		// Token: 0x0401FF46 RID: 130886
		public static readonly EPhantomBattleHeadAnim Kill = new EPhantomBattleHeadAnim("Kill");

		// Token: 0x0401FF47 RID: 130887
		public static readonly EPhantomBattleHeadAnim Hit = new EPhantomBattleHeadAnim("Hit");
	}
}
