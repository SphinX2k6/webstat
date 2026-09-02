using System;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005E00 RID: 24064
	public interface ICookingData : ICookItemData
	{
		// Token: 0x170098E2 RID: 39138
		// (get) Token: 0x0603C8DB RID: 248027
		// (set) Token: 0x0603C8DC RID: 248028
		ESubCookDataType SubType { get; set; }

		// Token: 0x170098E3 RID: 39139
		// (get) Token: 0x0603C8DD RID: 248029
		// (set) Token: 0x0603C8DE RID: 248030
		int UniqueId { get; set; }

		// Token: 0x170098E4 RID: 39140
		// (get) Token: 0x0603C8DF RID: 248031
		// (set) Token: 0x0603C8E0 RID: 248032
		int CookCount { get; set; }

		// Token: 0x170098E5 RID: 39141
		// (get) Token: 0x0603C8E1 RID: 248033
		// (set) Token: 0x0603C8E2 RID: 248034
		int? LastRoleId { get; set; }

		// Token: 0x170098E6 RID: 39142
		// (get) Token: 0x0603C8E3 RID: 248035
		// (set) Token: 0x0603C8E4 RID: 248036
		int IsCook { get; set; }

		// Token: 0x170098E7 RID: 39143
		// (get) Token: 0x0603C8E5 RID: 248037
		// (set) Token: 0x0603C8E6 RID: 248038
		int EffectType { get; set; }

		// Token: 0x170098E8 RID: 39144
		// (get) Token: 0x0603C8E7 RID: 248039
		// (set) Token: 0x0603C8E8 RID: 248040
		int DataId { get; set; }

		// Token: 0x170098E9 RID: 39145
		// (get) Token: 0x0603C8E9 RID: 248041
		// (set) Token: 0x0603C8EA RID: 248042
		int LimitTotalCount { get; set; }

		// Token: 0x170098EA RID: 39146
		// (get) Token: 0x0603C8EB RID: 248043
		// (set) Token: 0x0603C8EC RID: 248044
		int LimitedCount { get; set; }

		// Token: 0x170098EB RID: 39147
		// (get) Token: 0x0603C8ED RID: 248045
		// (set) Token: 0x0603C8EE RID: 248046
		double ExistStartTime { get; set; }

		// Token: 0x170098EC RID: 39148
		// (get) Token: 0x0603C8EF RID: 248047
		// (set) Token: 0x0603C8F0 RID: 248048
		double ExistEndTime { get; set; }
	}
}
