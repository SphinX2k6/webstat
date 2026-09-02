using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067F8 RID: 26616
	[NullableContext(1)]
	[Nullable(0)]
	public class RequestHandleIn : IRequestHandleIn
	{
		// Token: 0x1700A135 RID: 41269
		// (get) Token: 0x060425B0 RID: 271792 RVA: 0x0110455B File Offset: 0x0110275B
		// (set) Token: 0x060425B1 RID: 271793 RVA: 0x01104563 File Offset: 0x01102763
		public int InteractId { get; set; }

		// Token: 0x1700A136 RID: 41270
		// (get) Token: 0x060425B2 RID: 271794 RVA: 0x0110456C File Offset: 0x0110276C
		// (set) Token: 0x060425B3 RID: 271795 RVA: 0x01104574 File Offset: 0x01102774
		public List<FishingItemInfo> LeftDataList { get; set; }

		// Token: 0x1700A137 RID: 41271
		// (get) Token: 0x060425B4 RID: 271796 RVA: 0x0110457D File Offset: 0x0110277D
		// (set) Token: 0x060425B5 RID: 271797 RVA: 0x01104585 File Offset: 0x01102785
		public List<FishingItemInfo> RightDataList { get; set; }

		// Token: 0x1700A138 RID: 41272
		// (get) Token: 0x060425B6 RID: 271798 RVA: 0x0110458E File Offset: 0x0110278E
		// (set) Token: 0x060425B7 RID: 271799 RVA: 0x01104596 File Offset: 0x01102796
		public int? RemoveIncId { get; set; }

		// Token: 0x1700A139 RID: 41273
		// (get) Token: 0x060425B8 RID: 271800 RVA: 0x0110459F File Offset: 0x0110279F
		// (set) Token: 0x060425B9 RID: 271801 RVA: 0x011045A7 File Offset: 0x011027A7
		public int ActionIncId { get; set; }

		// Token: 0x1700A13A RID: 41274
		// (get) Token: 0x060425BA RID: 271802 RVA: 0x011045B0 File Offset: 0x011027B0
		// (set) Token: 0x060425BB RID: 271803 RVA: 0x011045B8 File Offset: 0x011027B8
		[Nullable(2)]
		public Action<bool, bool> Callback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x060425BC RID: 271804 RVA: 0x011045C1 File Offset: 0x011027C1
		public RequestHandleIn()
		{
			this.LeftDataList = new List<FishingItemInfo>();
			this.RightDataList = new List<FishingItemInfo>();
		}
	}
}
