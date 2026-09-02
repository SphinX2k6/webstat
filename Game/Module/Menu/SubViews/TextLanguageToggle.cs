using System;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005792 RID: 22418
	public class TextLanguageToggle : LanguageToggleBase
	{
		// Token: 0x06039056 RID: 233558 RVA: 0x00E72FE8 File Offset: 0x00E711E8
		protected override void OnStart()
		{
			base.OnStart();
			base.GetText(2).SetUIActive(false);
		}

		// Token: 0x06039057 RID: 233559 RVA: 0x00E72FFD File Offset: 0x00E711FD
		public void SetSpriteActive(bool isShow)
		{
		}
	}
}
