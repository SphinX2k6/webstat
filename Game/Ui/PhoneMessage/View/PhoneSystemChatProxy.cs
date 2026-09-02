using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui.PhoneMessage.View
{
	// Token: 0x02004A67 RID: 19047
	[NullableContext(1)]
	[Nullable(0)]
	public class PhoneSystemChatProxy
	{
		// Token: 0x06031BC7 RID: 203719 RVA: 0x00C74177 File Offset: 0x00C72377
		public void RegisterView(PhoneMsgPanelViewBig view)
		{
			this.View = view;
		}

		// Token: 0x06031BC8 RID: 203720 RVA: 0x00C74180 File Offset: 0x00C72380
		public void SetChatSelectPanelBlackMarkEnable(bool isEnable)
		{
			this.View.SetChatSelectPanelBlackMarkEnable(isEnable);
		}

		// Token: 0x0401D1D0 RID: 119248
		private PhoneMsgPanelViewBig View;
	}
}
