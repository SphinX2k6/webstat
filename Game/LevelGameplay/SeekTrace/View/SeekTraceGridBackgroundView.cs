using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.SeekTrace.View
{
	// Token: 0x02006B0F RID: 27407
	public class SeekTraceGridBackgroundView : UiPanelBase, IGridProxy<bool>
	{
		// Token: 0x1700A2FD RID: 41725
		// (get) Token: 0x06043B96 RID: 277398 RVA: 0x01179EDE File Offset: 0x011780DE
		// (set) Token: 0x06043B97 RID: 277399 RVA: 0x01179EE6 File Offset: 0x011780E6
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public IScrollViewDelegate<IGridProxy<bool>, bool> ScrollViewDelegate { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700A2FE RID: 41726
		// (get) Token: 0x06043B98 RID: 277400 RVA: 0x01179EEF File Offset: 0x011780EF
		// (set) Token: 0x06043B99 RID: 277401 RVA: 0x01179EF7 File Offset: 0x011780F7
		public int GridIndex { get; set; }

		// Token: 0x1700A2FF RID: 41727
		// (get) Token: 0x06043B9A RID: 277402 RVA: 0x01179F00 File Offset: 0x01178100
		// (set) Token: 0x06043B9B RID: 277403 RVA: 0x01179F08 File Offset: 0x01178108
		public int DisplayIndex { get; set; }

		// Token: 0x06043B9C RID: 277404 RVA: 0x01179F11 File Offset: 0x01178111
		public void Refresh(bool enable, bool isSelected, int gridIndex)
		{
			if (!enable)
			{
				base.GetRootItem().SetAlpha(0f);
			}
		}

		// Token: 0x06043B9D RID: 277405 RVA: 0x01179F26 File Offset: 0x01178126
		public void Clear()
		{
		}

		// Token: 0x06043B9E RID: 277406 RVA: 0x01179F28 File Offset: 0x01178128
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06043B9F RID: 277407 RVA: 0x01179F2A File Offset: 0x0117812A
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06043BA0 RID: 277408 RVA: 0x01179F2C File Offset: 0x0117812C
		[NullableContext(2)]
		public object GetKey(bool data, int gridIndex)
		{
			return this.GridIndex;
		}
	}
}
