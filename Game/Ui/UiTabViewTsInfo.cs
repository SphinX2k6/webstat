using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A5A RID: 19034
	[NullableContext(1)]
	[Nullable(0)]
	public class UiTabViewTsInfo : IUiTabViewTsInfo
	{
		// Token: 0x17008489 RID: 33929
		// (get) Token: 0x06031B7E RID: 203646 RVA: 0x00C63F75 File Offset: 0x00C62175
		// (set) Token: 0x06031B7F RID: 203647 RVA: 0x00C63F7D File Offset: 0x00C6217D
		public TCreateUiTabViewBase CreateUiTabView { get; set; }

		// Token: 0x1700848A RID: 33930
		// (get) Token: 0x06031B80 RID: 203648 RVA: 0x00C63F86 File Offset: 0x00C62186
		// (set) Token: 0x06031B81 RID: 203649 RVA: 0x00C63F8E File Offset: 0x00C6218E
		public string ResourceId { get; set; }

		// Token: 0x06031B82 RID: 203650 RVA: 0x00C63F97 File Offset: 0x00C62197
		public UiTabViewTsInfo(TCreateUiTabViewBase createUiTabView, string resourceId)
		{
			this.CreateUiTabView = createUiTabView;
			this.ResourceId = resourceId;
		}
	}
}
