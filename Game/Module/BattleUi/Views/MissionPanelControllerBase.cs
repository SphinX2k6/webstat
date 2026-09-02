using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006050 RID: 24656
	public abstract class MissionPanelControllerBase
	{
		// Token: 0x17009A86 RID: 39558
		// (get) Token: 0x0603E344 RID: 254788
		protected abstract EMissionPanelControllerType ControllerType { get; }

		// Token: 0x0603E345 RID: 254789
		public abstract void AddEvents();

		// Token: 0x0603E346 RID: 254790
		public abstract void RemoveEvents();

		// Token: 0x0603E347 RID: 254791
		public abstract void OnDestroy();
	}
}
