using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054BF RID: 21695
	[NullableContext(2)]
	[Nullable(0)]
	public class GymItemBase : UiPanelBase
	{
		// Token: 0x06037429 RID: 226345 RVA: 0x00E04EB0 File Offset: 0x00E030B0
		protected void OnClickLevel()
		{
			if (this.Level > 0 && this.CallbackOnClick != null)
			{
				if (!ModelBase<PhantomArenaModel>.Instance.IsGymLock(this.Level, this.ActivityId))
				{
					this.CallbackOnClick(this.Level);
					return;
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattleGym_Locked", Array.Empty<object>());
			}
		}

		// Token: 0x0603742A RID: 226346 RVA: 0x00E04F0C File Offset: 0x00E0310C
		public double GetAnchorOffsetX()
		{
			return (double)this.RootItem.GetAnchorOffsetX();
		}

		// Token: 0x0603742B RID: 226347 RVA: 0x00E04F1A File Offset: 0x00E0311A
		public virtual void Refresh()
		{
		}

		// Token: 0x0603742C RID: 226348 RVA: 0x00E04F1C File Offset: 0x00E0311C
		protected void OnFocus()
		{
			if (this.Level > 0 && this.CallbackOnFocus != null)
			{
				this.CallbackOnFocus(this.Level);
			}
		}

		// Token: 0x0603742D RID: 226349 RVA: 0x00E04F40 File Offset: 0x00E03140
		protected void OnHover()
		{
			if (this.Level > 0 && this.CallbackOnHover != null)
			{
				this.CallbackOnHover(this.Level);
			}
		}

		// Token: 0x0603742E RID: 226350 RVA: 0x00E04F64 File Offset: 0x00E03164
		protected void OnUnHover()
		{
			if (this.Level > 0 && this.CallbackOnUnHover != null)
			{
				this.CallbackOnUnHover(this.Level);
			}
		}

		// Token: 0x0603742F RID: 226351 RVA: 0x00E04F88 File Offset: 0x00E03188
		public void PlayUnlock()
		{
			if (this.Level <= 0)
			{
				return;
			}
			PhantomArenaModel instance = ModelBase<PhantomArenaModel>.Instance;
			if (!instance.IsGymLock(this.Level, this.ActivityId) && !instance.IsGymUnlockChecked(this.Level, this.ActivityId))
			{
				ModelBase<PhantomArenaModel>.Instance.SetGymUnlockChecked(this.Level, this.ActivityId);
				this.Refresh();
				UiSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer == null)
				{
					return;
				}
				sequencePlayer.PlaySequence("Unlock", false, null);
			}
		}

		// Token: 0x06037430 RID: 226352 RVA: 0x00E05008 File Offset: 0x00E03208
		protected bool GetRedDotState()
		{
			return this.Level > 0 && ModelBase<PhantomArenaModel>.Instance.GetGymRedDotById(this.Level, this.ActivityId);
		}

		// Token: 0x06037431 RID: 226353 RVA: 0x00E0502B File Offset: 0x00E0322B
		public virtual void RefreshRedDot()
		{
		}

		// Token: 0x0401FC40 RID: 130112
		public int Level = -1;

		// Token: 0x0401FC41 RID: 130113
		public int ActivityId;

		// Token: 0x0401FC42 RID: 130114
		public Action<int> CallbackOnClick;

		// Token: 0x0401FC43 RID: 130115
		public Action<int> CallbackOnHover;

		// Token: 0x0401FC44 RID: 130116
		public Action<int> CallbackOnFocus;

		// Token: 0x0401FC45 RID: 130117
		public Action<int> CallbackOnUnHover;

		// Token: 0x0401FC46 RID: 130118
		protected UiSequencePlayer SequencePlayer;
	}
}
