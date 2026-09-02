using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CD9 RID: 19673
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct ESpecialPanelHandleDefine : IEquatable<ESpecialPanelHandleDefine>
	{
		// Token: 0x060332E5 RID: 209637 RVA: 0x00CCFEEB File Offset: 0x00CCE0EB
		private ESpecialPanelHandleDefine(string value)
		{
			this._value = value;
		}

		// Token: 0x060332E6 RID: 209638 RVA: 0x00CCFEF4 File Offset: 0x00CCE0F4
		public static ESpecialPanelHandleDefine FromString(string value)
		{
			return new ESpecialPanelHandleDefine(value);
		}

		// Token: 0x060332E7 RID: 209639 RVA: 0x00CCFEFC File Offset: 0x00CCE0FC
		public override string ToString()
		{
			return this._value;
		}

		// Token: 0x060332E8 RID: 209640 RVA: 0x00CCFF04 File Offset: 0x00CCE104
		public bool Equals(ESpecialPanelHandleDefine other)
		{
			return this._value == other._value;
		}

		// Token: 0x060332E9 RID: 209641 RVA: 0x00CCFF18 File Offset: 0x00CCE118
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is ESpecialPanelHandleDefine)
			{
				ESpecialPanelHandleDefine other = (ESpecialPanelHandleDefine)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060332EA RID: 209642 RVA: 0x00CCFF3D File Offset: 0x00CCE13D
		public override int GetHashCode()
		{
			string value = this._value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x060332EB RID: 209643 RVA: 0x00CCFF50 File Offset: 0x00CCE150
		public static bool operator ==(ESpecialPanelHandleDefine left, ESpecialPanelHandleDefine right)
		{
			return left.Equals(right);
		}

		// Token: 0x060332EC RID: 209644 RVA: 0x00CCFF5A File Offset: 0x00CCE15A
		public static bool operator !=(ESpecialPanelHandleDefine left, ESpecialPanelHandleDefine right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0401DBDF RID: 121823
		private readonly string _value;

		// Token: 0x0401DBE0 RID: 121824
		public static readonly ESpecialPanelHandleDefine Default = new ESpecialPanelHandleDefine("Default");

		// Token: 0x0401DBE1 RID: 121825
		public static readonly ESpecialPanelHandleDefine VisionChooseMain = new ESpecialPanelHandleDefine("VisionChooseMain");

		// Token: 0x0401DBE2 RID: 121826
		public static readonly ESpecialPanelHandleDefine FunctionView = new ESpecialPanelHandleDefine("MainMenu");

		// Token: 0x0401DBE3 RID: 121827
		public static readonly ESpecialPanelHandleDefine RoleSkill = new ESpecialPanelHandleDefine("RoleSkill");

		// Token: 0x0401DBE4 RID: 121828
		public static readonly ESpecialPanelHandleDefine RoleResonance = new ESpecialPanelHandleDefine("RoleResonance");

		// Token: 0x0401DBE5 RID: 121829
		public static readonly ESpecialPanelHandleDefine Inventory = new ESpecialPanelHandleDefine("Inventory");

		// Token: 0x0401DBE6 RID: 121830
		public static readonly ESpecialPanelHandleDefine Roulette = new ESpecialPanelHandleDefine("Roulette");

		// Token: 0x0401DBE7 RID: 121831
		public static readonly ESpecialPanelHandleDefine ExploreReward = new ESpecialPanelHandleDefine("ExploreReward");

		// Token: 0x0401DBE8 RID: 121832
		public static readonly ESpecialPanelHandleDefine VisionAssemble = new ESpecialPanelHandleDefine("VisionAssemble");

		// Token: 0x0401DBE9 RID: 121833
		public static readonly ESpecialPanelHandleDefine PhantomArenaBattle = new ESpecialPanelHandleDefine("PhantomArenaBattle");

		// Token: 0x0401DBEA RID: 121834
		public static readonly ESpecialPanelHandleDefine PhantomManageConfig = new ESpecialPanelHandleDefine("PhantomManageConfig");

		// Token: 0x0401DBEB RID: 121835
		public static readonly ESpecialPanelHandleDefine HonamiStoryBackpack = new ESpecialPanelHandleDefine("HonamiStoryBackpack");
	}
}
