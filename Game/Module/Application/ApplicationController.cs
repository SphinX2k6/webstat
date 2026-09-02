using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Application
{
	// Token: 0x02006184 RID: 24964
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ApplicationController : ControllerBase<ApplicationController>
	{
		// Token: 0x0603F15C RID: 258396 RVA: 0x0102E026 File Offset: 0x0102C226
		protected override bool OnInit()
		{
			Singleton<Application>.Instance.AddApplicationHandler(EApplicationLifetimeDelegate.ApplicationWillEnterBackgroundDelegate, new Action(this.ApplicationWillEnterBackground));
			Singleton<Application>.Instance.AddApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasReactivatedDelegate, new Action(this.ApplicationHasReactivated));
			return true;
		}

		// Token: 0x0603F15D RID: 258397 RVA: 0x0102E057 File Offset: 0x0102C257
		protected override bool OnClear()
		{
			Singleton<Application>.Instance.RemoveApplicationHandler(EApplicationLifetimeDelegate.ApplicationWillEnterBackgroundDelegate, new Action(this.ApplicationWillEnterBackground));
			Singleton<Application>.Instance.RemoveApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasReactivatedDelegate, new Action(this.ApplicationHasReactivated));
			return true;
		}

		// Token: 0x0603F15E RID: 258398 RVA: 0x0102E088 File Offset: 0x0102C288
		private void ApplicationWillEnterBackground()
		{
		}

		// Token: 0x0603F15F RID: 258399 RVA: 0x0102E08A File Offset: 0x0102C28A
		private void ApplicationHasReactivated()
		{
		}
	}
}
