using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TowerDefenseUi.HeadState;

namespace CSharpScript.Game.Module.TowerDefenseUi
{
	// Token: 0x02004E7B RID: 20091
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class TowerDefenseUiController : ControllerBase<TowerDefenseUiController>
	{
		// Token: 0x06033E85 RID: 212613 RVA: 0x00CFD9E9 File Offset: 0x00CFBBE9
		protected override bool OnInit()
		{
			this.HeadStateManager = new TowerDefenseHeadStateManager();
			this.HeadStateManager.Init();
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			return true;
		}

		// Token: 0x06033E86 RID: 212614 RVA: 0x00CFDA1E File Offset: 0x00CFBC1E
		protected override bool OnLeaveLevel()
		{
			TowerDefenseHeadStateManager headStateManager = this.HeadStateManager;
			if (headStateManager != null)
			{
				headStateManager.Clear();
			}
			this.IsEnable = false;
			return true;
		}

		// Token: 0x06033E87 RID: 212615 RVA: 0x00CFDA39 File Offset: 0x00CFBC39
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			if (this.HeadStateManager != null)
			{
				this.HeadStateManager.Clear();
				this.HeadStateManager = null;
			}
			this.IsEnable = false;
			return true;
		}

		// Token: 0x06033E88 RID: 212616 RVA: 0x00CFDA79 File Offset: 0x00CFBC79
		private void OnWorldDone()
		{
			this.IsEnable = (ControllerBase<KuroSimpleCombatController>.Instance.CurSubController != null);
			if (!this.IsEnable)
			{
				return;
			}
			TowerDefenseHeadStateManager headStateManager = this.HeadStateManager;
			if (headStateManager == null)
			{
				return;
			}
			headStateManager.OnWorldDone();
		}

		// Token: 0x06033E89 RID: 212617 RVA: 0x00CFDAA7 File Offset: 0x00CFBCA7
		protected override void OnTick(float delta)
		{
			if (!this.IsEnable)
			{
				return;
			}
			TowerDefenseHeadStateManager headStateManager = this.HeadStateManager;
			if (headStateManager == null)
			{
				return;
			}
			headStateManager.Tick(delta);
		}

		// Token: 0x0401E04B RID: 122955
		private Stat TickStat = Stat.Create("TowerDefenseUiController.OnTick", "", "");

		// Token: 0x0401E04C RID: 122956
		[Nullable(2)]
		public TowerDefenseHeadStateManager HeadStateManager;

		// Token: 0x0401E04D RID: 122957
		public bool IsEnable;
	}
}
