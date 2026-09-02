using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067F6 RID: 26614
	[NullableContext(1)]
	[Nullable(0)]
	public class RequestCabinPut : IRequestCabinPut
	{
		// Token: 0x1700A129 RID: 41257
		// (get) Token: 0x06042597 RID: 271767 RVA: 0x011044D7 File Offset: 0x011026D7
		// (set) Token: 0x06042598 RID: 271768 RVA: 0x011044DF File Offset: 0x011026DF
		public CabinType Type { get; set; }

		// Token: 0x1700A12A RID: 41258
		// (get) Token: 0x06042599 RID: 271769 RVA: 0x011044E8 File Offset: 0x011026E8
		// (set) Token: 0x0604259A RID: 271770 RVA: 0x011044F0 File Offset: 0x011026F0
		public int? RequestId { get; set; }

		// Token: 0x1700A12B RID: 41259
		// (get) Token: 0x0604259B RID: 271771 RVA: 0x011044F9 File Offset: 0x011026F9
		// (set) Token: 0x0604259C RID: 271772 RVA: 0x01104501 File Offset: 0x01102701
		public List<FishingItemInfo> LeftDataList { get; set; }

		// Token: 0x1700A12C RID: 41260
		// (get) Token: 0x0604259D RID: 271773 RVA: 0x0110450A File Offset: 0x0110270A
		// (set) Token: 0x0604259E RID: 271774 RVA: 0x01104512 File Offset: 0x01102712
		public List<FishingItemInfo> RightDataList { get; set; }

		// Token: 0x1700A12D RID: 41261
		// (get) Token: 0x0604259F RID: 271775 RVA: 0x0110451B File Offset: 0x0110271B
		// (set) Token: 0x060425A0 RID: 271776 RVA: 0x01104523 File Offset: 0x01102723
		public int? RemoveIncId { get; set; }

		// Token: 0x1700A12E RID: 41262
		// (get) Token: 0x060425A1 RID: 271777 RVA: 0x0110452C File Offset: 0x0110272C
		// (set) Token: 0x060425A2 RID: 271778 RVA: 0x01104534 File Offset: 0x01102734
		[Nullable(2)]
		public Action<bool> Callback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x060425A3 RID: 271779 RVA: 0x0110453D File Offset: 0x0110273D
		public RequestCabinPut()
		{
			this.LeftDataList = new List<FishingItemInfo>();
			this.RightDataList = new List<FishingItemInfo>();
		}
	}
}
