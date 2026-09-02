using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Item
{
	// Token: 0x02006A84 RID: 27268
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TuningStandGridItem : GridProxyAbstract<TuningGridData>
	{
		// Token: 0x06043729 RID: 276265 RVA: 0x01160481 File Offset: 0x0115E681
		[NullableContext(1)]
		public override void Refresh(TuningGridData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			if (data.GridType == ETuningStandGridType.Empty)
			{
				return;
			}
			if (this.Grid != null)
			{
				this.Grid.SetUiActive(false);
				this.ResetGrid();
				this.PlayShowAnim();
			}
		}

		// Token: 0x0604372A RID: 276266 RVA: 0x011604B4 File Offset: 0x0115E6B4
		public UniTask CreateGrid()
		{
			TuningStandGridItem.<CreateGrid>d__4 <CreateGrid>d__;
			<CreateGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateGrid>d__.<>4__this = this;
			<CreateGrid>d__.<>1__state = -1;
			<CreateGrid>d__.<>t__builder.Start<TuningStandGridItem.<CreateGrid>d__4>(ref <CreateGrid>d__);
			return <CreateGrid>d__.<>t__builder.Task;
		}

		// Token: 0x0604372B RID: 276267 RVA: 0x011604F7 File Offset: 0x0115E6F7
		public void RefreshGrid()
		{
			if (this.Data.GridType == ETuningStandGridType.Empty)
			{
				return;
			}
			this.Grid.OnRefreshGrid();
		}

		// Token: 0x0604372C RID: 276268 RVA: 0x01160512 File Offset: 0x0115E712
		public TuningStandGridBase GetGrid()
		{
			return this.Grid;
		}

		// Token: 0x0604372D RID: 276269 RVA: 0x0116051A File Offset: 0x0115E71A
		private void ResetGrid()
		{
			if (this.Data.GridType == ETuningStandGridType.Empty)
			{
				return;
			}
			this.Grid.ResetGrid(this.Data);
		}

		// Token: 0x0604372E RID: 276270 RVA: 0x0116053C File Offset: 0x0115E73C
		public void PlayShowAnim()
		{
			if (this.Data.GridType == ETuningStandGridType.Empty)
			{
				return;
			}
			if (this.TimeHandle != null)
			{
				if (TimerSystem.Instance.Has(this.TimeHandle))
				{
					TimerSystem.Instance.Remove(this.TimeHandle);
				}
				this.TimeHandle = null;
			}
			double dist = this.Data.GetCenterDistance();
			if (dist == 0.0)
			{
				this.Grid.SetUiActive(true);
				this.Grid.PlayInAnim(0f);
				return;
			}
			double num = 0.0;
			int num2 = 1;
			while ((double)num2 <= dist)
			{
				num += (double)(330 / num2);
				num2++;
			}
			this.TimeHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.Grid.SetUiActive(true);
				this.Grid.PlayInAnim((float)dist);
			}, (float)((long)(num / 2.0)), null, null, true, 1f);
		}

		// Token: 0x0604372F RID: 276271 RVA: 0x0116062D File Offset: 0x0115E82D
		public void OnLinkMiss(bool isEnd)
		{
			if (this.Data.GridType == ETuningStandGridType.Empty)
			{
				return;
			}
			this.Grid.OnLinkMiss(isEnd);
		}

		// Token: 0x06043730 RID: 276272 RVA: 0x01160649 File Offset: 0x0115E849
		public void StartRevolving()
		{
			if (this.Data.GridType == ETuningStandGridType.Empty)
			{
				return;
			}
			this.Grid.StartRevolving();
		}

		// Token: 0x04025AA5 RID: 154277
		protected TuningGridData Data;

		// Token: 0x04025AA6 RID: 154278
		protected TuningStandGridBase Grid;

		// Token: 0x04025AA7 RID: 154279
		protected TimerHandle TimeHandle;
	}
}
