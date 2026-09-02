using System;

namespace CSharpScript.Launcher.Ui.Splash
{
	// Token: 0x020044F9 RID: 17657
	public abstract class SplashUmgBase
	{
		// Token: 0x0602E8AC RID: 190636 RVA: 0x00B070E2 File Offset: 0x00B052E2
		public void Init()
		{
			this.OnCreateWidget();
			this.OnShow();
		}

		// Token: 0x0602E8AD RID: 190637 RVA: 0x00B070F0 File Offset: 0x00B052F0
		public void Destroy()
		{
			this.OnDestroy();
		}

		// Token: 0x0602E8AE RID: 190638
		protected abstract void OnCreateWidget();

		// Token: 0x0602E8AF RID: 190639
		protected abstract void OnShow();

		// Token: 0x0602E8B0 RID: 190640
		protected abstract void OnDestroy();
	}
}
