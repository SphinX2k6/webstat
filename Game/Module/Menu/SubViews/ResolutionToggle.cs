using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005790 RID: 22416
	public class ResolutionToggle : LanguageToggleBase
	{
		// Token: 0x0603904E RID: 233550 RVA: 0x00E72F64 File Offset: 0x00E71164
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
		}

		// Token: 0x0603904F RID: 233551 RVA: 0x00E72F6C File Offset: 0x00E7116C
		[NullableContext(1)]
		public void SetMainRawText(string text)
		{
			this.MainText.SetText(text, true);
		}

		// Token: 0x06039050 RID: 233552 RVA: 0x00E72F7B File Offset: 0x00E7117B
		protected override void OnStart()
		{
			base.OnStart();
			base.GetText(2).SetUIActive(false);
		}
	}
}
