using System;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel
{
	// Token: 0x02005BDD RID: 23517
	public class SolarSpeedInstanceDungeonViewModel : InstanceDungeonViewModelBase
	{
		// Token: 0x0603B8A6 RID: 243878 RVA: 0x00F17D6D File Offset: 0x00F15F6D
		protected override bool OnCheckNeedOnTimer(int instanceId)
		{
			this.View.RefreshSolarSpeedInstance(0f, true);
			return true;
		}

		// Token: 0x0603B8A7 RID: 243879 RVA: 0x00F17D81 File Offset: 0x00F15F81
		protected override void OnTimerRefreshFunction(float delta)
		{
			this.View.RefreshSolarSpeedInstance(delta, false);
		}
	}
}
