using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200679C RID: 26524
	[NullableContext(1)]
	public interface IDockyardViewInterface
	{
		// Token: 0x06042248 RID: 270920
		void ShowTipsPanel(int id);

		// Token: 0x06042249 RID: 270921
		void HideTipsPanel();

		// Token: 0x0604224A RID: 270922
		void SetTrawlState(bool state);

		// Token: 0x0604224B RID: 270923
		[NullableContext(2)]
		void CloseMe(Action<bool> callback = null);

		// Token: 0x0604224C RID: 270924
		void NotifyQuicklySellActive(bool isActive);

		// Token: 0x0604224D RID: 270925
		UUIItem GetQuicklySellPanelParentItem();
	}
}
