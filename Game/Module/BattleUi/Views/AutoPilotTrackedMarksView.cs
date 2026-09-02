using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F98 RID: 24472
	[NullableContext(2)]
	[Nullable(0)]
	public class AutoPilotTrackedMarksView : BattleChildView
	{
		// Token: 0x0603D712 RID: 251666 RVA: 0x00FA29E9 File Offset: 0x00FA0BE9
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			this.AutoPilotTrackMark = new AutoPilotTrackMark();
			this.AutoPilotTrackMark.Initialize(this.RootItem);
		}

		// Token: 0x0603D713 RID: 251667 RVA: 0x00FA2A0E File Offset: 0x00FA0C0E
		public override void Reset()
		{
			base.Reset();
			AutoPilotTrackMark autoPilotTrackMark = this.AutoPilotTrackMark;
			if (autoPilotTrackMark != null)
			{
				autoPilotTrackMark.Destroy(null);
			}
			this.AutoPilotTrackMark = null;
		}

		// Token: 0x0603D714 RID: 251668 RVA: 0x00FA2A2F File Offset: 0x00FA0C2F
		public void OnShowBattleChildViewPanel()
		{
			AutoPilotTrackMark autoPilotTrackMark = this.AutoPilotTrackMark;
			if (autoPilotTrackMark == null)
			{
				return;
			}
			autoPilotTrackMark.OnUiShow();
		}

		// Token: 0x0603D715 RID: 251669 RVA: 0x00FA2A41 File Offset: 0x00FA0C41
		public void Update(float delta)
		{
			AutoPilotTrackMark autoPilotTrackMark = this.AutoPilotTrackMark;
			if (autoPilotTrackMark == null)
			{
				return;
			}
			autoPilotTrackMark.Update(delta);
		}

		// Token: 0x0603D716 RID: 251670 RVA: 0x00FA2A54 File Offset: 0x00FA0C54
		public void OnHideBattleChildViewPanel()
		{
			AutoPilotTrackMark autoPilotTrackMark = this.AutoPilotTrackMark;
			if (autoPilotTrackMark == null)
			{
				return;
			}
			autoPilotTrackMark.OnUiHide();
		}

		// Token: 0x0603D717 RID: 251671 RVA: 0x00FA2A66 File Offset: 0x00FA0C66
		protected override bool DestroyOverride()
		{
			return true;
		}

		// Token: 0x04022879 RID: 141433
		private AutoPilotTrackMark AutoPilotTrackMark;
	}
}
