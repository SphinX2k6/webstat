using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Item
{
	// Token: 0x02006A81 RID: 27265
	[NullableContext(1)]
	[Nullable(0)]
	public class TuningStandGridBase : UiPanelBase
	{
		// Token: 0x06043706 RID: 276230 RVA: 0x0115FD05 File Offset: 0x0115DF05
		public TuningStandGridBase(TuningGridData data)
		{
			this.Data = data;
			this.GridType = new ETuningStandGridType?(data.GridType);
		}

		// Token: 0x1700A26B RID: 41579
		// (get) Token: 0x06043707 RID: 276231 RVA: 0x0115FD25 File Offset: 0x0115DF25
		// (set) Token: 0x06043708 RID: 276232 RVA: 0x0115FD2D File Offset: 0x0115DF2D
		protected TuningGridData Data { get; set; }

		// Token: 0x06043709 RID: 276233 RVA: 0x0115FD36 File Offset: 0x0115DF36
		public virtual void OnRefreshGrid()
		{
		}

		// Token: 0x0604370A RID: 276234 RVA: 0x0115FD38 File Offset: 0x0115DF38
		protected virtual void OnResetGrid()
		{
		}

		// Token: 0x0604370B RID: 276235 RVA: 0x0115FD3A File Offset: 0x0115DF3A
		public void ResetGrid(TuningGridData data)
		{
			this.Data = data;
			this.CurSelected = false;
			this.OnResetGrid();
		}

		// Token: 0x0604370C RID: 276236 RVA: 0x0115FD50 File Offset: 0x0115DF50
		protected virtual void InitGrid()
		{
		}

		// Token: 0x0604370D RID: 276237 RVA: 0x0115FD52 File Offset: 0x0115DF52
		protected virtual void OnToggleHover()
		{
		}

		// Token: 0x0604370E RID: 276238 RVA: 0x0115FD54 File Offset: 0x0115DF54
		protected virtual void OnToggleUnHover()
		{
		}

		// Token: 0x0604370F RID: 276239 RVA: 0x0115FD56 File Offset: 0x0115DF56
		protected virtual void OnTogglePress()
		{
		}

		// Token: 0x06043710 RID: 276240 RVA: 0x0115FD58 File Offset: 0x0115DF58
		protected virtual void OnToggleRelease()
		{
		}

		// Token: 0x06043711 RID: 276241 RVA: 0x0115FD5A File Offset: 0x0115DF5A
		protected virtual void OnToggleCancel()
		{
		}

		// Token: 0x06043712 RID: 276242 RVA: 0x0115FD5C File Offset: 0x0115DF5C
		public virtual void PlayInAnim(float dist)
		{
		}

		// Token: 0x06043713 RID: 276243 RVA: 0x0115FD5E File Offset: 0x0115DF5E
		public virtual void OnLinkMiss(bool isEnd)
		{
		}

		// Token: 0x06043714 RID: 276244 RVA: 0x0115FD60 File Offset: 0x0115DF60
		protected ETuningStandPrevDirect GetPrevDirection()
		{
			ITuningStateData curGridState = this.Data.GetCurGridState();
			int index = this.Data.Index;
			if (curGridState.Prev == null)
			{
				return ETuningStandPrevDirect.None;
			}
			int value = curGridState.Prev.Value;
			if (value == index - 1)
			{
				return ETuningStandPrevDirect.Left;
			}
			if (value == index + 1)
			{
				return ETuningStandPrevDirect.Right;
			}
			if (value <= index)
			{
				return ETuningStandPrevDirect.Top;
			}
			return ETuningStandPrevDirect.Bottom;
		}

		// Token: 0x06043715 RID: 276245 RVA: 0x0115FDBD File Offset: 0x0115DFBD
		public virtual void StartRevolving()
		{
		}

		// Token: 0x04025A8D RID: 154253
		protected ETuningStandGridType? GridType;

		// Token: 0x04025A8E RID: 154254
		protected bool CurSelected;
	}
}
