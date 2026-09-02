using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200547B RID: 21627
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EPhantomArenaTextId : IEquatable<EPhantomArenaTextId>
	{
		// Token: 0x06037187 RID: 225671 RVA: 0x00DFD773 File Offset: 0x00DFB973
		private EPhantomArenaTextId(string value)
		{
			this._Value = value;
		}

		// Token: 0x06037188 RID: 225672 RVA: 0x00DFD77C File Offset: 0x00DFB97C
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06037189 RID: 225673 RVA: 0x00DFD784 File Offset: 0x00DFB984
		public bool Equals(EPhantomArenaTextId other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x0603718A RID: 225674 RVA: 0x00DFD798 File Offset: 0x00DFB998
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is EPhantomArenaTextId)
			{
				EPhantomArenaTextId other = (EPhantomArenaTextId)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0603718B RID: 225675 RVA: 0x00DFD7BD File Offset: 0x00DFB9BD
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x0603718C RID: 225676 RVA: 0x00DFD7D0 File Offset: 0x00DFB9D0
		public static bool operator ==(EPhantomArenaTextId left, EPhantomArenaTextId right)
		{
			return left.Equals(right);
		}

		// Token: 0x0603718D RID: 225677 RVA: 0x00DFD7DA File Offset: 0x00DFB9DA
		public static bool operator !=(EPhantomArenaTextId left, EPhantomArenaTextId right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0401FB51 RID: 129873
		private readonly string _Value;

		// Token: 0x0401FB52 RID: 129874
		public static readonly EPhantomArenaTextId TextExp = new EPhantomArenaTextId("PhantomBattle_1152");

		// Token: 0x0401FB53 RID: 129875
		public static readonly EPhantomArenaTextId TextEntranceTitle = new EPhantomArenaTextId("PhantomBattle_1151");

		// Token: 0x0401FB54 RID: 129876
		public static readonly EPhantomArenaTextId TextRewardProgress = new EPhantomArenaTextId("PhantomBattle_1153");

		// Token: 0x0401FB55 RID: 129877
		public static readonly EPhantomArenaTextId TextFirstPassRewardTitle = new EPhantomArenaTextId("PhantomBattle_1154");

		// Token: 0x0401FB56 RID: 129878
		public static readonly EPhantomArenaTextId TextReChallengeRewardTitle = new EPhantomArenaTextId("PhantomBattle_1155");

		// Token: 0x0401FB57 RID: 129879
		public static readonly EPhantomArenaTextId TextChallengeProgressNormal = new EPhantomArenaTextId("PhantomBattle_1159");

		// Token: 0x0401FB58 RID: 129880
		public static readonly EPhantomArenaTextId TextChallengeProgressSelect = new EPhantomArenaTextId("PhantomBattle_1160");

		// Token: 0x0401FB59 RID: 129881
		public static readonly EPhantomArenaTextId TextMysteryNpcName = new EPhantomArenaTextId("PhantomBattle_1164");

		// Token: 0x0401FB5A RID: 129882
		public static readonly EPhantomArenaTextId TextMysteryNpcDesc = new EPhantomArenaTextId("PhantomBattle_1165");

		// Token: 0x0401FB5B RID: 129883
		public static readonly EPhantomArenaTextId TextGuideQuestTip = new EPhantomArenaTextId("PhantomBattle_1182");

		// Token: 0x0401FB5C RID: 129884
		public static readonly EPhantomArenaTextId TextGotoQuest = new EPhantomArenaTextId("PhantomBattle_1183");
	}
}
