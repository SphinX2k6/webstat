using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Manager
{
	// Token: 0x020069F2 RID: 27122
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ControllerManager : ControllerManagerBase<ControllerManager>
	{
		// Token: 0x0604335B RID: 275291 RVA: 0x01146367 File Offset: 0x01144567
		public override bool Init()
		{
			bool result = base.Init();
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			return result;
		}

		// Token: 0x0604335C RID: 275292 RVA: 0x0114638B File Offset: 0x0114458B
		public override bool Clear()
		{
			bool result = base.Clear();
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			return result;
		}

		// Token: 0x0604335D RID: 275293 RVA: 0x011463AF File Offset: 0x011445AF
		private void OnBattleStateChanged(bool isInFight)
		{
			this.IsInFight = isInFight;
		}
	}
}
