using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200535B RID: 21339
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotCenterText
	{
		// Token: 0x060366FA RID: 222970 RVA: 0x00DBB974 File Offset: 0x00DB9B74
		public PlotCenterText()
		{
			this.Text = "";
			this.AudioId = "";
			this.AutoClose = false;
			this.UniversalTone = null;
			this.TalkAkEvent = null;
			this.TalkEndAkEvent = null;
			this.Config = null;
			this.Callback = null;
		}

		// Token: 0x060366FB RID: 222971 RVA: 0x00DBB9CC File Offset: 0x00DB9BCC
		public void Clear()
		{
			this.Text = null;
			this.AudioId = "";
			this.AutoClose = false;
			this.UniversalTone = null;
			this.TalkAkEvent = null;
			this.Config = null;
			this.Callback = null;
		}

		// Token: 0x0401F4E0 RID: 128224
		public string Text;

		// Token: 0x0401F4E1 RID: 128225
		[Nullable(1)]
		public string AudioId;

		// Token: 0x0401F4E2 RID: 128226
		public bool AutoClose;

		// Token: 0x0401F4E3 RID: 128227
		public IUniversalTone UniversalTone;

		// Token: 0x0401F4E4 RID: 128228
		public IPostAkEventType TalkAkEvent;

		// Token: 0x0401F4E5 RID: 128229
		public IPostAkEventType TalkEndAkEvent;

		// Token: 0x0401F4E6 RID: 128230
		[Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public OneOf<ShowCenterText, IShowCenterTextParams>? Config;

		// Token: 0x0401F4E7 RID: 128231
		public Action Callback;
	}
}
