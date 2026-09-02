using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006808 RID: 26632
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingHandBookDesData : IFishingHandBookDesData
	{
		// Token: 0x1700A16B RID: 41323
		// (get) Token: 0x06042624 RID: 271908 RVA: 0x0110478D File Offset: 0x0110298D
		// (set) Token: 0x06042625 RID: 271909 RVA: 0x01104795 File Offset: 0x01102995
		public string DesText { get; set; }

		// Token: 0x1700A16C RID: 41324
		// (get) Token: 0x06042626 RID: 271910 RVA: 0x0110479E File Offset: 0x0110299E
		// (set) Token: 0x06042627 RID: 271911 RVA: 0x011047A6 File Offset: 0x011029A6
		public string DataText { get; set; }

		// Token: 0x1700A16D RID: 41325
		// (get) Token: 0x06042628 RID: 271912 RVA: 0x011047AF File Offset: 0x011029AF
		// (set) Token: 0x06042629 RID: 271913 RVA: 0x011047B7 File Offset: 0x011029B7
		public bool? IsGolden { get; set; }

		// Token: 0x1700A16E RID: 41326
		// (get) Token: 0x0604262A RID: 271914 RVA: 0x011047C0 File Offset: 0x011029C0
		// (set) Token: 0x0604262B RID: 271915 RVA: 0x011047C8 File Offset: 0x011029C8
		public bool? IsSliver { get; set; }

		// Token: 0x0604262C RID: 271916 RVA: 0x011047D1 File Offset: 0x011029D1
		public FishingHandBookDesData()
		{
			this.DesText = "";
			this.DataText = "";
		}
	}
}
