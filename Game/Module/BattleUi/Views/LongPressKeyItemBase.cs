using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006049 RID: 24649
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class LongPressKeyItemBase : KeyItemBase
	{
		// Token: 0x0603E2E2 RID: 254690 RVA: 0x00FE0587 File Offset: 0x00FDE787
		[NullableContext(1)]
		public void RefreshActionLongPress(string actionName, float longPressTime = 0f)
		{
			if (this.ActionName == actionName)
			{
				return;
			}
			this.LongPressTime = longPressTime;
			this.RefreshAction(actionName);
			this.SetLongPressItemVisible(longPressTime > 0f);
			this.SetLongPressPercent(0f);
		}

		// Token: 0x0603E2E3 RID: 254691 RVA: 0x00FE05BF File Offset: 0x00FDE7BF
		public void ForceShowLongPress()
		{
			this.LongPressTime = 0f;
			this.SetLongPressItemVisible(true);
			this.SetLongPressPercent(100f);
		}

		// Token: 0x0603E2E4 RID: 254692 RVA: 0x00FE05DE File Offset: 0x00FDE7DE
		[NullableContext(1)]
		public override void RefreshAxis(string axisName)
		{
			if (this.AxisName == axisName)
			{
				return;
			}
			this.LongPressTime = 0f;
			this.SetLongPressItemVisible(false);
			base.RefreshAxis(axisName);
		}

		// Token: 0x0603E2E5 RID: 254693 RVA: 0x00FE0608 File Offset: 0x00FDE808
		protected override void OnBeforeDestroy()
		{
			this.DeactivateLongPressRefresh();
		}

		// Token: 0x0603E2E6 RID: 254694 RVA: 0x00FE0610 File Offset: 0x00FDE810
		[NullableContext(1)]
		protected override void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType)
		{
			if (!this.IsEnable)
			{
				this.DeactivateLongPressRefresh();
				return;
			}
			if (actionType == InputDistributeDefine.EActionType.Press)
			{
				this.ActivateLongPressRefresh();
				return;
			}
			this.DeactivateLongPressRefresh();
		}

		// Token: 0x0603E2E7 RID: 254695 RVA: 0x00FE0634 File Offset: 0x00FDE834
		public void Tick(float delta)
		{
			if (!this.IsPress)
			{
				return;
			}
			if (!this.IsEnable)
			{
				this.DeactivateLongPressRefresh();
				return;
			}
			this.PressTime += delta;
			this.SetLongPressPercent(this.PressTime / this.LongPressTime);
			if (this.PressTime >= this.LongPressTime)
			{
				this.DeactivateLongPressRefresh();
			}
		}

		// Token: 0x0603E2E8 RID: 254696 RVA: 0x00FE068E File Offset: 0x00FDE88E
		private void ActivateLongPressRefresh()
		{
			this.PressTime = 0f;
			this.SetLongPressPercent(0f);
			this.IsPress = true;
		}

		// Token: 0x0603E2E9 RID: 254697 RVA: 0x00FE06AD File Offset: 0x00FDE8AD
		private void DeactivateLongPressRefresh()
		{
			this.PressTime = 0f;
			this.SetLongPressPercent(0f);
			this.IsPress = false;
		}

		// Token: 0x0603E2EA RID: 254698 RVA: 0x00FE06CC File Offset: 0x00FDE8CC
		private void SetLongPressItemVisible(bool bVisible)
		{
			UUIItem longPressItem = this.GetLongPressItem();
			if (longPressItem == null)
			{
				return;
			}
			longPressItem.SetUIActive(bVisible);
		}

		// Token: 0x0603E2EB RID: 254699 RVA: 0x00FE06DF File Offset: 0x00FDE8DF
		private void SetLongPressPercent(float percent)
		{
			UUITexture longPressTexture = this.GetLongPressTexture();
			if (longPressTexture == null)
			{
				return;
			}
			longPressTexture.SetFillAmount(percent);
		}

		// Token: 0x0603E2EC RID: 254700
		protected abstract override UUIText GetKeyText();

		// Token: 0x0603E2ED RID: 254701
		protected abstract override UUITexture GetKeyTexture();

		// Token: 0x0603E2EE RID: 254702
		protected abstract UUITexture GetLongPressTexture();

		// Token: 0x0603E2EF RID: 254703
		protected abstract UUIItem GetLongPressItem();

		// Token: 0x04022DB8 RID: 142776
		private float LongPressTime;

		// Token: 0x04022DB9 RID: 142777
		private float PressTime;

		// Token: 0x04022DBA RID: 142778
		private bool IsPress;
	}
}
