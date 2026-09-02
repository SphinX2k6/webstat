using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotoDevelop
{
	// Token: 0x0200671C RID: 26396
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ActivityMotorDevelopConfig : ConfigBase<ActivityMotorDevelopConfig>
	{
		// Token: 0x06041DAE RID: 269742 RVA: 0x010E55BC File Offset: 0x010E37BC
		public MotorDevelopActivity? GetActivityDataById(int id)
		{
			return ConfigMotorDevelopActivityByActivityId.GetConfig(id, true);
		}

		// Token: 0x06041DAF RID: 269743 RVA: 0x010E55C5 File Offset: 0x010E37C5
		public MotorDevelopTask? GetMotorDevelopTaskById(int id)
		{
			return ConfigMotorDevelopTaskByTaskId.GetConfig(id, true);
		}
	}
}
