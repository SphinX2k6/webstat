using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050B6 RID: 20662
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class RoleDevelopProjectBasePanel : UiPanelBase
	{
		// Token: 0x060353CD RID: 218061 RVA: 0x00D58C77 File Offset: 0x00D56E77
		protected override void OnBeforeCreateImplement()
		{
			this.UiViewSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiViewSequence);
		}

		// Token: 0x060353CE RID: 218062 RVA: 0x00D58C91 File Offset: 0x00D56E91
		public void RefreshView(RoleDevelopData data, bool forceRefresh = false)
		{
			this.Data = data;
			this.OnRefreshView(forceRefresh);
		}

		// Token: 0x060353CF RID: 218063
		protected abstract void OnRefreshView(bool forceRefresh);

		// Token: 0x060353D0 RID: 218064 RVA: 0x00D58CA1 File Offset: 0x00D56EA1
		public virtual void OnCommonItemCountAnyChange(int configId)
		{
		}

		// Token: 0x060353D1 RID: 218065 RVA: 0x00D58CA4 File Offset: 0x00D56EA4
		public void PlaySequenceByName(string sequenceName, bool blockClick = false)
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName(sequenceName, blockClick, null);
		}

		// Token: 0x060353D2 RID: 218066 RVA: 0x00D58CCC File Offset: 0x00D56ECC
		public void StopSequenceByName(string sequenceName, bool needEvent = false, bool toLastFrame = false)
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.StopSequenceByKey(sequenceName, needEvent, toLastFrame);
		}

		// Token: 0x0401EA2A RID: 125482
		[Nullable(2)]
		protected RoleDevelopData Data;

		// Token: 0x0401EA2B RID: 125483
		[Nullable(2)]
		public UiBehaviorLevelSequence UiViewSequence;
	}
}
