using System;

namespace CSharpScript.Game.Module.Manufacture.Compose
{
	// Token: 0x020059BD RID: 22973
	public class IBaseItemData
	{
		// Token: 0x17009490 RID: 38032
		// (get) Token: 0x0603A2E3 RID: 238307 RVA: 0x00EBC070 File Offset: 0x00EBA270
		// (set) Token: 0x0603A2E4 RID: 238308 RVA: 0x00EBC078 File Offset: 0x00EBA278
		public EComposeListType MainType { get; set; }

		// Token: 0x17009491 RID: 38033
		// (get) Token: 0x0603A2E5 RID: 238309 RVA: 0x00EBC081 File Offset: 0x00EBA281
		// (set) Token: 0x0603A2E6 RID: 238310 RVA: 0x00EBC089 File Offset: 0x00EBA289
		public int ConfigId { get; set; }

		// Token: 0x17009492 RID: 38034
		// (get) Token: 0x0603A2E7 RID: 238311 RVA: 0x00EBC092 File Offset: 0x00EBA292
		// (set) Token: 0x0603A2E8 RID: 238312 RVA: 0x00EBC09A File Offset: 0x00EBA29A
		public bool IsNew { get; set; }

		// Token: 0x17009493 RID: 38035
		// (get) Token: 0x0603A2E9 RID: 238313 RVA: 0x00EBC0A3 File Offset: 0x00EBA2A3
		// (set) Token: 0x0603A2EA RID: 238314 RVA: 0x00EBC0AB File Offset: 0x00EBA2AB
		public int Quality { get; set; }

		// Token: 0x17009494 RID: 38036
		// (get) Token: 0x0603A2EB RID: 238315 RVA: 0x00EBC0B4 File Offset: 0x00EBA2B4
		// (set) Token: 0x0603A2EC RID: 238316 RVA: 0x00EBC0BC File Offset: 0x00EBA2BC
		public double ExistStartTime { get; set; }

		// Token: 0x17009495 RID: 38037
		// (get) Token: 0x0603A2ED RID: 238317 RVA: 0x00EBC0C5 File Offset: 0x00EBA2C5
		// (set) Token: 0x0603A2EE RID: 238318 RVA: 0x00EBC0CD File Offset: 0x00EBA2CD
		public double ExistEndTime { get; set; }

		// Token: 0x17009496 RID: 38038
		// (get) Token: 0x0603A2EF RID: 238319 RVA: 0x00EBC0D6 File Offset: 0x00EBA2D6
		// (set) Token: 0x0603A2F0 RID: 238320 RVA: 0x00EBC0DE File Offset: 0x00EBA2DE
		public int MadeCountInLimitTime { get; set; }

		// Token: 0x17009497 RID: 38039
		// (get) Token: 0x0603A2F1 RID: 238321 RVA: 0x00EBC0E7 File Offset: 0x00EBA2E7
		// (set) Token: 0x0603A2F2 RID: 238322 RVA: 0x00EBC0EF File Offset: 0x00EBA2EF
		public int TotalMakeCountInLimitTime { get; set; }

		// Token: 0x17009498 RID: 38040
		// (get) Token: 0x0603A2F3 RID: 238323 RVA: 0x00EBC0F8 File Offset: 0x00EBA2F8
		// (set) Token: 0x0603A2F4 RID: 238324 RVA: 0x00EBC100 File Offset: 0x00EBA300
		public bool IsLimitForever { get; set; }

		// Token: 0x17009499 RID: 38041
		// (get) Token: 0x0603A2F5 RID: 238325 RVA: 0x00EBC109 File Offset: 0x00EBA309
		// (set) Token: 0x0603A2F6 RID: 238326 RVA: 0x00EBC111 File Offset: 0x00EBA311
		public int IsUnlock { get; set; }

		// Token: 0x1700949A RID: 38042
		// (get) Token: 0x0603A2F7 RID: 238327 RVA: 0x00EBC11A File Offset: 0x00EBA31A
		// (set) Token: 0x0603A2F8 RID: 238328 RVA: 0x00EBC122 File Offset: 0x00EBA322
		public int GroupId { get; set; }

		// Token: 0x1700949B RID: 38043
		// (get) Token: 0x0603A2F9 RID: 238329 RVA: 0x00EBC12B File Offset: 0x00EBA32B
		// (set) Token: 0x0603A2FA RID: 238330 RVA: 0x00EBC133 File Offset: 0x00EBA333
		public int SortId { get; set; }
	}
}
