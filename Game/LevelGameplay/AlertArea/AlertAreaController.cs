using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay.AlertArea
{
	// Token: 0x02006F6D RID: 28525
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class AlertAreaController : ControllerBase<AlertAreaController>
	{
		// Token: 0x060450A0 RID: 282784 RVA: 0x011FA7EC File Offset: 0x011F89EC
		protected override bool OnClear()
		{
			List<int> list = new List<int>();
			foreach (int item in this.AlertValueProgressTimerHandle.Keys)
			{
				list.Add(item);
			}
			foreach (int areaId in list)
			{
				this.DisableAlertValueProgressTimer(areaId);
			}
			this.AlertValueProgressTimerHandle.Clear();
			return true;
		}

		// Token: 0x060450A1 RID: 282785 RVA: 0x011FA898 File Offset: 0x011F8A98
		public void UpdateAlertDataByServerNotify(AlertAreaNotify notify)
		{
			AlertAreaModel instance = ModelBase<AlertAreaModel>.Instance;
			foreach (int areaId in notify.RemoveAreaIds)
			{
				this.DisableAlertValueProgressTimer(areaId);
				instance.DisableAlertArea(areaId);
			}
			foreach (AlertArea alertArea in notify.AlertAreas)
			{
				if (!instance.GetAreaAlertEnabled(alertArea.AreaId))
				{
					instance.EnableAlertArea(alertArea.AreaId, alertArea.AlertValue, alertArea.EnableUi, alertArea.VisibleUi);
					if (alertArea.ChangeSpeed != 0f)
					{
						this.EnableAlertValueProgressTimer(alertArea.AreaId, alertArea.ChangeSpeed, 1000);
					}
				}
				else
				{
					instance.UpdateAreaAlertValue(alertArea.AreaId, alertArea.AlertValue);
					instance.UpdateAreaAlertUiEnabled(alertArea.AreaId, alertArea.EnableUi);
					instance.UpdateAreaAlertUiVisible(alertArea.AreaId, alertArea.VisibleUi);
					if (alertArea.ChangeSpeed != 0f)
					{
						this.EnableAlertValueProgressTimer(alertArea.AreaId, alertArea.ChangeSpeed, 1000);
					}
					else
					{
						this.DisableAlertValueProgressTimer(alertArea.AreaId);
					}
				}
			}
		}

		// Token: 0x060450A2 RID: 282786 RVA: 0x011FAA00 File Offset: 0x011F8C00
		public void EnableAlertValueProgressTimer(int areaId, float deltaVal, int interval)
		{
			this.DisableAlertValueProgressTimer(areaId);
			TimerHandle value = TimerSystem.Instance.Forever(delegate(float _)
			{
				if (!ModelBase<AlertAreaModel>.Instance.GetAreaAlertEnabled(areaId))
				{
					this.DisableAlertValueProgressTimer(areaId);
					return;
				}
				float areaAlertValue = ModelBase<AlertAreaModel>.Instance.GetAreaAlertValue(areaId);
				ModelBase<AlertAreaModel>.Instance.UpdateAreaAlertValue(areaId, areaAlertValue + deltaVal);
			}, (float)interval, 1f, null, null, true);
			this.AlertValueProgressTimerHandle[areaId] = value;
		}

		// Token: 0x060450A3 RID: 282787 RVA: 0x011FAA68 File Offset: 0x011F8C68
		public void DisableAlertValueProgressTimer(int areaId)
		{
			TimerHandle timerHandle;
			if (this.AlertValueProgressTimerHandle.TryGetValue(areaId, out timerHandle) && timerHandle != null)
			{
				if (TimerSystem.Instance.Has(timerHandle))
				{
					TimerSystem.Instance.Remove(timerHandle);
				}
				this.AlertValueProgressTimerHandle.Remove(areaId);
			}
		}

		// Token: 0x0402683D RID: 157757
		private const int ALERT_VAL_PROGRESS_INTERVAL = 1000;

		// Token: 0x0402683E RID: 157758
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private readonly Dictionary<int, TimerHandle> AlertValueProgressTimerHandle = new Dictionary<int, TimerHandle>();
	}
}
