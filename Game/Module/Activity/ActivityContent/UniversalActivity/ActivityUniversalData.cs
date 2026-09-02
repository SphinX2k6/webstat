using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.UniversalActivity
{
	// Token: 0x02006259 RID: 25177
	public class ActivityUniversalData : ActivityBaseData
	{
		// Token: 0x0603F746 RID: 259910 RVA: 0x010444A9 File Offset: 0x010426A9
		[NullableContext(1)]
		protected override void PhraseEx(ActivityData data)
		{
		}

		// Token: 0x0603F747 RID: 259911 RVA: 0x010444AB File Offset: 0x010426AB
		public override bool NeedSelfControlFirstRedPoint()
		{
			return false;
		}

		// Token: 0x0603F748 RID: 259912 RVA: 0x010444AE File Offset: 0x010426AE
		public UniversalActivity? GetExtraConfig()
		{
			return ConfigBase<ActivityUniversalConfig>.Instance.GetActivityUniversalConfig(base.Id);
		}
	}
}
