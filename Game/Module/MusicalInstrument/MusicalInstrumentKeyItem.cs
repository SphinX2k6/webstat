using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056D4 RID: 22228
	public abstract class MusicalInstrumentKeyItem : UiPanelBase
	{
		// Token: 0x06038949 RID: 231753 RVA: 0x00E55BC5 File Offset: 0x00E53DC5
		public virtual void OnQteFocus(bool isFocus)
		{
		}

		// Token: 0x0603894A RID: 231754 RVA: 0x00E55BC7 File Offset: 0x00E53DC7
		public virtual void OnQtePerformance(bool success)
		{
		}

		// Token: 0x04020479 RID: 132217
		public int RowIndex;

		// Token: 0x0402047A RID: 132218
		public int ColumnIndex;

		// Token: 0x0402047B RID: 132219
		[Nullable(2)]
		public Action<int, int> OnPointerDownCallback;
	}
}
