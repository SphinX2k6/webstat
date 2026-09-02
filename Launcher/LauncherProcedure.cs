using System;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Util;

namespace CSharpScript.Launcher
{
	// Token: 0x02004497 RID: 17559
	public class LauncherProcedure
	{
		// Token: 0x0602E51A RID: 189722 RVA: 0x00ADF223 File Offset: 0x00ADD423
		public static void Init()
		{
		}

		// Token: 0x0602E51B RID: 189723 RVA: 0x00ADF225 File Offset: 0x00ADD425
		public static void Destroy()
		{
			Singleton<AppLinks>.Instance.Destroy();
			Singleton<LauncherAudio>.Instance.Destroy();
			Singleton<PakKeyUpdate>.Instance.Destroy();
		}
	}
}
