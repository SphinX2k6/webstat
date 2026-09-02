using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002035 RID: 8245
public class ItemViewDefine
{
	// Token: 0x0400789F RID: 30879
	public const int REFRESH_CD_INTERVAL = 500;

	// Token: 0x040078A0 RID: 30880
	public const int MAX_DESTROY_MODE_COUNT = 100;

	// Token: 0x020083DD RID: 33757
	[NullableContext(1)]
	public interface IDestroyPreviewData
	{
		// Token: 0x1700A83F RID: 43071
		// (get) Token: 0x06048870 RID: 297072
		// (set) Token: 0x06048871 RID: 297073
		List<TItem> OriginList { get; set; }

		// Token: 0x1700A840 RID: 43072
		// (get) Token: 0x06048872 RID: 297074
		// (set) Token: 0x06048873 RID: 297075
		List<TItem> ResultList { get; set; }
	}

	// Token: 0x020083DE RID: 33758
	[NullableContext(1)]
	[Nullable(0)]
	public class DestroyPreviewData : ItemViewDefine.IDestroyPreviewData
	{
		// Token: 0x1700A841 RID: 43073
		// (get) Token: 0x06048874 RID: 297076 RVA: 0x0137A5A2 File Offset: 0x013787A2
		// (set) Token: 0x06048875 RID: 297077 RVA: 0x0137A5AA File Offset: 0x013787AA
		public List<TItem> OriginList { get; set; }

		// Token: 0x1700A842 RID: 43074
		// (get) Token: 0x06048876 RID: 297078 RVA: 0x0137A5B3 File Offset: 0x013787B3
		// (set) Token: 0x06048877 RID: 297079 RVA: 0x0137A5BB File Offset: 0x013787BB
		public List<TItem> ResultList { get; set; }
	}

	// Token: 0x020083DF RID: 33759
	public enum EItemOperationMode
	{
		// Token: 0x0402CB48 RID: 183112
		Normal,
		// Token: 0x0402CB49 RID: 183113
		Destruction
	}

	// Token: 0x020083E0 RID: 33760
	public enum EDestroyViewMode
	{
		// Token: 0x0402CB4B RID: 183115
		Default,
		// Token: 0x0402CB4C RID: 183116
		Disabled,
		// Token: 0x0402CB4D RID: 183117
		Multiple
	}

	// Token: 0x020083E1 RID: 33761
	public enum ETipsButtonType
	{
		// Token: 0x0402CB4F RID: 183119
		Use,
		// Token: 0x0402CB50 RID: 183120
		RouletteEquip,
		// Token: 0x0402CB51 RID: 183121
		WeaponCultivate,
		// Token: 0x0402CB52 RID: 183122
		VisionCultivate,
		// Token: 0x0402CB53 RID: 183123
		FragmentMemory,
		// Token: 0x0402CB54 RID: 183124
		EquipBuffItem,
		// Token: 0x0402CB55 RID: 183125
		QuestReview,
		// Token: 0x0402CB56 RID: 183126
		ChineseZither
	}
}
