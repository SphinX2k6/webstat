using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.DeadRevive
{
	// Token: 0x02005DCC RID: 24012
	public class ReviveSmallItemGrid : SmallItemGrid
	{
		// Token: 0x0603C727 RID: 247591 RVA: 0x00F598E8 File Offset: 0x00F57AE8
		public void Refresh(int itemId, int itemCount)
		{
			this.ItemId = new int?(itemId);
			int num = (int)ModelBase<BuffItemModel>.Instance.GetBuffItemRemainCdTime(itemId);
			PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
			propSmallItemGrid.Data = itemId;
			propSmallItemGrid.ItemConfigId = new int?(itemId);
			string bottomText;
			if (itemCount <= 0)
			{
				bottomText = "";
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(itemCount);
				bottomText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			propSmallItemGrid.BottomText = bottomText;
			propSmallItemGrid.CoolDownTime = new int?(num);
			PropSmallItemGrid parameters = propSmallItemGrid;
			base.Apply<PropSmallItemGrid>(parameters);
			this.RemainCdTime = num;
			this.TotalCdTime = (int)ModelBase<BuffItemModel>.Instance.GetBuffItemTotalCdTime(this.ItemId.Value);
			if (this.Timer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.Timer);
			}
			this.Timer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnCoolDownRefresh), 20f, 1f, null, null, true);
		}

		// Token: 0x0603C728 RID: 247592 RVA: 0x00F599D0 File Offset: 0x00F57BD0
		public void RefreshCoolDown()
		{
			double buffItemRemainCdTime = ModelBase<BuffItemModel>.Instance.GetBuffItemRemainCdTime(this.ItemId.Value);
			base.SetCoolDown(new float?((float)buffItemRemainCdTime), new float?((float)this.TotalCdTime));
		}

		// Token: 0x0603C729 RID: 247593 RVA: 0x00F59A0C File Offset: 0x00F57C0C
		private void OnCoolDownRefresh(float _)
		{
			if (this.RemainCdTime <= 0)
			{
				if (this.Timer != null)
				{
					TimerSystem.GameplayTimeInstance.Remove(this.Timer);
				}
				this.Timer = null;
				return;
			}
			this.RefreshCoolDown();
			this.RemainCdTime = this.RemainCdTime;
		}

		// Token: 0x0603C72A RID: 247594 RVA: 0x00F59A4A File Offset: 0x00F57C4A
		protected void OnDestroyed()
		{
			this.ItemId = null;
			if (this.Timer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.Timer);
			}
			this.Timer = null;
			this.RemainCdTime = -1;
			this.TotalCdTime = 1;
		}

		// Token: 0x04021FC1 RID: 139201
		public int? ItemId;

		// Token: 0x04021FC2 RID: 139202
		[Nullable(2)]
		private TimerHandle Timer;

		// Token: 0x04021FC3 RID: 139203
		private int RemainCdTime = -1;

		// Token: 0x04021FC4 RID: 139204
		private int TotalCdTime = 1;
	}
}
