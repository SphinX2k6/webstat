using System;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A1D RID: 18973
	public class TouchData
	{
		// Token: 0x1700844F RID: 33871
		// (get) Token: 0x06031933 RID: 203059 RVA: 0x00C5AFF3 File Offset: 0x00C591F3
		// (set) Token: 0x06031934 RID: 203060 RVA: 0x00C5AFFB File Offset: 0x00C591FB
		public bool IsPress { get; set; }

		// Token: 0x17008450 RID: 33872
		// (get) Token: 0x06031935 RID: 203061 RVA: 0x00C5B004 File Offset: 0x00C59204
		// (set) Token: 0x06031936 RID: 203062 RVA: 0x00C5B00C File Offset: 0x00C5920C
		public int TouchId { get; set; }

		// Token: 0x17008451 RID: 33873
		// (get) Token: 0x06031937 RID: 203063 RVA: 0x00C5B015 File Offset: 0x00C59215
		// (set) Token: 0x06031938 RID: 203064 RVA: 0x00C5B01D File Offset: 0x00C5921D
		public FVector TouchPosition { get; set; }

		// Token: 0x06031939 RID: 203065 RVA: 0x00C5B026 File Offset: 0x00C59226
		public TouchData(bool isPress, int touchId, FVector touchPosition)
		{
			this.IsPress = isPress;
			this.TouchId = touchId;
			this.TouchPosition = touchPosition;
		}
	}
}
