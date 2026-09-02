using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200546B RID: 21611
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EPhantomCardSettingFailReason : IEquatable<EPhantomCardSettingFailReason>
	{
		// Token: 0x06037177 RID: 225655 RVA: 0x00DFD524 File Offset: 0x00DFB724
		private EPhantomCardSettingFailReason(string value)
		{
			this._Value = value;
		}

		// Token: 0x06037178 RID: 225656 RVA: 0x00DFD52D File Offset: 0x00DFB72D
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06037179 RID: 225657 RVA: 0x00DFD535 File Offset: 0x00DFB735
		public bool Equals(EPhantomCardSettingFailReason other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x0603717A RID: 225658 RVA: 0x00DFD548 File Offset: 0x00DFB748
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is EPhantomCardSettingFailReason)
			{
				EPhantomCardSettingFailReason other = (EPhantomCardSettingFailReason)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0603717B RID: 225659 RVA: 0x00DFD56D File Offset: 0x00DFB76D
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x0603717C RID: 225660 RVA: 0x00DFD580 File Offset: 0x00DFB780
		public static bool operator ==(EPhantomCardSettingFailReason left, EPhantomCardSettingFailReason right)
		{
			return left.Equals(right);
		}

		// Token: 0x0603717D RID: 225661 RVA: 0x00DFD58A File Offset: 0x00DFB78A
		public static bool operator !=(EPhantomCardSettingFailReason left, EPhantomCardSettingFailReason right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0401FAEB RID: 129771
		private readonly string _Value;

		// Token: 0x0401FAEC RID: 129772
		public static readonly EPhantomCardSettingFailReason None = new EPhantomCardSettingFailReason("");

		// Token: 0x0401FAED RID: 129773
		public static readonly EPhantomCardSettingFailReason CardLock = new EPhantomCardSettingFailReason("");

		// Token: 0x0401FAEE RID: 129774
		public static readonly EPhantomCardSettingFailReason CantDragToRecycle = new EPhantomCardSettingFailReason("PhantomBattle_1047");

		// Token: 0x0401FAEF RID: 129775
		public static readonly EPhantomCardSettingFailReason SettingLimit = new EPhantomCardSettingFailReason("PhantomBattle_1048");

		// Token: 0x0401FAF0 RID: 129776
		public static readonly EPhantomCardSettingFailReason EvolveNumLimit = new EPhantomCardSettingFailReason("PhantomBattle_1049");

		// Token: 0x0401FAF1 RID: 129777
		public static readonly EPhantomCardSettingFailReason EvolveOneCostLimit = new EPhantomCardSettingFailReason("PhantomBattle_1050");

		// Token: 0x0401FAF2 RID: 129778
		public static readonly EPhantomCardSettingFailReason NotEnoughCost = new EPhantomCardSettingFailReason("PhantomBattle_1051");

		// Token: 0x0401FAF3 RID: 129779
		public static readonly EPhantomCardSettingFailReason EvolveThreeCostLimit = new EPhantomCardSettingFailReason("PhantomBattle_1062");

		// Token: 0x0401FAF4 RID: 129780
		public static readonly EPhantomCardSettingFailReason NotHasActiveSkill = new EPhantomCardSettingFailReason("PhantomBattle_1064");

		// Token: 0x0401FAF5 RID: 129781
		public static readonly EPhantomCardSettingFailReason FourCostCantEvolve = new EPhantomCardSettingFailReason("PhantomBattle_1126");

		// Token: 0x0401FAF6 RID: 129782
		public static readonly EPhantomCardSettingFailReason FourCostCantBeEvolved = new EPhantomCardSettingFailReason("PhantomBattle_1127");

		// Token: 0x0401FAF7 RID: 129783
		public static readonly EPhantomCardSettingFailReason OneCostCantEvolveOther = new EPhantomCardSettingFailReason("PhantomBattle_1130");

		// Token: 0x0401FAF8 RID: 129784
		public static readonly EPhantomCardSettingFailReason ThreeCostCantEvolveOther = new EPhantomCardSettingFailReason("PhantomBattle_1128");

		// Token: 0x0401FAF9 RID: 129785
		public static readonly EPhantomCardSettingFailReason CantDragMonsterToFunctional = new EPhantomCardSettingFailReason("PhantomBattle_1065");

		// Token: 0x0401FAFA RID: 129786
		public static readonly EPhantomCardSettingFailReason CantDragMonsterByThreeCost = new EPhantomCardSettingFailReason("PhantomBattle_1066");

		// Token: 0x0401FAFB RID: 129787
		public static readonly EPhantomCardSettingFailReason ExistCard = new EPhantomCardSettingFailReason("");

		// Token: 0x0401FAFC RID: 129788
		public static readonly EPhantomCardSettingFailReason FieldCantDragToMonster = new EPhantomCardSettingFailReason("PhantomBattle_1134");

		// Token: 0x0401FAFD RID: 129789
		public static readonly EPhantomCardSettingFailReason FieldCantDragToRecycle = new EPhantomCardSettingFailReason("PhantomBattle_1135");

		// Token: 0x0401FAFE RID: 129790
		public static readonly EPhantomCardSettingFailReason ToolCantDragToFunctional = new EPhantomCardSettingFailReason("PhantomBattle_1180");

		// Token: 0x0401FAFF RID: 129791
		public static readonly EPhantomCardSettingFailReason ToolCantEvolve = new EPhantomCardSettingFailReason("PhantomBattle_1181");

		// Token: 0x0401FB00 RID: 129792
		public static readonly EPhantomCardSettingFailReason WaitBattleSlotIndex = new EPhantomCardSettingFailReason("");
	}
}
