using System;
using System.Runtime.CompilerServices;

// Token: 0x02001995 RID: 6549
[NullableContext(1)]
[Nullable(0)]
public readonly struct ETipsUiType : IEquatable<ETipsUiType>
{
	// Token: 0x0600BC02 RID: 48130 RVA: 0x0031ECA8 File Offset: 0x0031CEA8
	private ETipsUiType(string value)
	{
		this._Value = value;
	}

	// Token: 0x0600BC03 RID: 48131 RVA: 0x0031ECB1 File Offset: 0x0031CEB1
	public override string ToString()
	{
		return this._Value;
	}

	// Token: 0x0600BC04 RID: 48132 RVA: 0x0031ECB9 File Offset: 0x0031CEB9
	public bool Equals(ETipsUiType other)
	{
		return this._Value == other._Value;
	}

	// Token: 0x0600BC05 RID: 48133 RVA: 0x0031ECCC File Offset: 0x0031CECC
	public override bool Equals(object obj)
	{
		if (obj is ETipsUiType)
		{
			ETipsUiType other = (ETipsUiType)obj;
			return this.Equals(other);
		}
		return false;
	}

	// Token: 0x0600BC06 RID: 48134 RVA: 0x0031ECF1 File Offset: 0x0031CEF1
	public override int GetHashCode()
	{
		string value = this._Value;
		if (value == null)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	// Token: 0x0600BC07 RID: 48135 RVA: 0x0031ED04 File Offset: 0x0031CF04
	public static bool operator ==(ETipsUiType left, ETipsUiType right)
	{
		return left.Equals(right);
	}

	// Token: 0x0600BC08 RID: 48136 RVA: 0x0031ED0E File Offset: 0x0031CF0E
	public static bool operator !=(ETipsUiType left, ETipsUiType right)
	{
		return !left.Equals(right);
	}

	// Token: 0x040058FE RID: 22782
	private readonly string _Value;

	// Token: 0x040058FF RID: 22783
	public const string ItemTipsComponentValue = "ItemTipsComponent";

	// Token: 0x04005900 RID: 22784
	public static readonly ETipsUiType ItemTipsComponent = new ETipsUiType("ItemTipsComponent");

	// Token: 0x04005901 RID: 22785
	public const string PowerTipsItemValue = "PowerTipsItem";

	// Token: 0x04005902 RID: 22786
	public static readonly ETipsUiType PowerTipsItem = new ETipsUiType("PowerTipsItem");

	// Token: 0x04005903 RID: 22787
	public const string PersonalCardPreviewComponentValue = "PersonalCardPreviewComponent";

	// Token: 0x04005904 RID: 22788
	public static readonly ETipsUiType PersonalCardPreviewComponent = new ETipsUiType("PersonalCardPreviewComponent");

	// Token: 0x04005905 RID: 22789
	public const string PersonalHeadPreviewComponentValue = "PersonalHeadPreviewComponent";

	// Token: 0x04005906 RID: 22790
	public static readonly ETipsUiType PersonalHeadPreviewComponent = new ETipsUiType("PersonalHeadPreviewComponent");

	// Token: 0x04005907 RID: 22791
	public const string PersonalTitlePreviewComponentValue = "PersonalTitlePreviewComponent";

	// Token: 0x04005908 RID: 22792
	public static readonly ETipsUiType PersonalTitlePreviewComponent = new ETipsUiType("PersonalTitlePreviewComponent");

	// Token: 0x04005909 RID: 22793
	public const string HonamiStoryTipsItemValue = "HonamiStoryTipsItem";

	// Token: 0x0400590A RID: 22794
	public static readonly ETipsUiType HonamiStoryTipsItem = new ETipsUiType("HonamiStoryTipsItem");

	// Token: 0x0400590B RID: 22795
	public const string FurnitureTipsItemValue = "FurnitureTipsItem";

	// Token: 0x0400590C RID: 22796
	public static readonly ETipsUiType FurnitureTipsItem = new ETipsUiType("FurnitureTipsItem");

	// Token: 0x0400590D RID: 22797
	public const string PinballTipsItemValue = "PinballTipsItem";

	// Token: 0x0400590E RID: 22798
	public static readonly ETipsUiType PinballTipsItem = new ETipsUiType("PinballTipsItem");
}
