using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.AlertArea
{
	// Token: 0x02006F6F RID: 28527
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class AlertAreaModel : ModelBase<AlertAreaModel>
	{
		// Token: 0x060450A6 RID: 282790 RVA: 0x011FAAD7 File Offset: 0x011F8CD7
		public bool GetAreaAlertEnabled(int areaId)
		{
			return this.EnabledAreaAlertData.ContainsKey(areaId);
		}

		// Token: 0x060450A7 RID: 282791 RVA: 0x011FAAE8 File Offset: 0x011F8CE8
		public bool GetAreaAlertUiEnabled(int areaId)
		{
			AlertAreaData alertAreaData;
			return this.EnabledAreaAlertData.TryGetValue(areaId, out alertAreaData) && alertAreaData != null && alertAreaData.AlertUiEnabled;
		}

		// Token: 0x060450A8 RID: 282792 RVA: 0x011FAB14 File Offset: 0x011F8D14
		public bool GetAreaAlertUiVisible(int areaId)
		{
			AlertAreaData alertAreaData;
			return this.EnabledAreaAlertData.TryGetValue(areaId, out alertAreaData) && (alertAreaData != null && alertAreaData.AlertUiEnabled) && alertAreaData.AlertUiVisible;
		}

		// Token: 0x060450A9 RID: 282793 RVA: 0x011FAB48 File Offset: 0x011F8D48
		public int? GetAlertUiVisibleAreaId()
		{
			foreach (KeyValuePair<int, AlertAreaData> keyValuePair in this.EnabledAreaAlertData)
			{
				int key = keyValuePair.Key;
				AlertAreaData value = keyValuePair.Value;
				if (value != null && value.AlertUiEnabled && value.AlertUiVisible)
				{
					return new int?(key);
				}
			}
			return null;
		}

		// Token: 0x060450AA RID: 282794 RVA: 0x011FABD0 File Offset: 0x011F8DD0
		public float GetAreaAlertValue(int areaId)
		{
			AlertAreaData alertAreaData;
			if (!this.EnabledAreaAlertData.TryGetValue(areaId, out alertAreaData))
			{
				return 0f;
			}
			if (alertAreaData == null)
			{
				return 0f;
			}
			return alertAreaData.AlertValue;
		}

		// Token: 0x060450AB RID: 282795 RVA: 0x011FAC04 File Offset: 0x011F8E04
		public void UpdateAreaAlertValue(int areaId, float newValue)
		{
			AlertAreaData alertAreaData;
			if (!this.EnabledAreaAlertData.TryGetValue(areaId, out alertAreaData))
			{
				return;
			}
			float num = Singleton<MathUtils>.Instance.Clamp(newValue, alertAreaData.MinAlertValue, alertAreaData.MaxAlertValue);
			if (alertAreaData.AlertValue == num)
			{
				return;
			}
			alertAreaData.AlertValue = num;
			Singleton<EventSystem>.Instance.Emit<int, float>(EEventName.OnUpdateAreaAlertValue, areaId, newValue);
		}

		// Token: 0x060450AC RID: 282796 RVA: 0x011FAC60 File Offset: 0x011F8E60
		public void UpdateAreaAlertUiEnabled(int areaId, bool newEnabled)
		{
			AlertAreaData alertAreaData;
			if (!this.EnabledAreaAlertData.TryGetValue(areaId, out alertAreaData) || alertAreaData.AlertUiEnabled == newEnabled)
			{
				return;
			}
			if (!newEnabled)
			{
				this.UpdateAreaAlertUiVisible(areaId, false);
			}
			alertAreaData.AlertUiEnabled = newEnabled;
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnUpdateAreaAlertUiEnable, areaId, newEnabled);
		}

		// Token: 0x060450AD RID: 282797 RVA: 0x011FACAC File Offset: 0x011F8EAC
		public void UpdateAreaAlertUiVisible(int areaId, bool newVisible)
		{
			AlertAreaData alertAreaData;
			if (!this.EnabledAreaAlertData.TryGetValue(areaId, out alertAreaData) || !alertAreaData.AlertUiEnabled || alertAreaData.AlertUiVisible == newVisible)
			{
				return;
			}
			alertAreaData.AlertUiVisible = newVisible;
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnUpdateAreaAlertUiVisible, areaId, newVisible);
		}

		// Token: 0x060450AE RID: 282798 RVA: 0x011FACF4 File Offset: 0x011F8EF4
		public void EnableAlertArea(int areaId, float initValue, bool initUiEnable, bool initUiVisible)
		{
			if (this.EnabledAreaAlertData.ContainsKey(areaId))
			{
				return;
			}
			AlertAreaConfig? config = ConfigAlertAreaConfigById.GetConfig(areaId, true);
			if (config == null)
			{
				return;
			}
			AlertAreaData alertAreaData = new AlertAreaData(config.Value.MinValue, config.Value.MaxValue);
			alertAreaData.AlertValue = Singleton<MathUtils>.Instance.Clamp(initValue, alertAreaData.MinAlertValue, alertAreaData.MaxAlertValue);
			alertAreaData.AlertUiEnabled = initUiEnable;
			alertAreaData.AlertUiVisible = initUiVisible;
			this.EnabledAreaAlertData[areaId] = alertAreaData;
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnUpdateAreaAlertEnable, areaId, true);
			if (alertAreaData.AlertUiEnabled)
			{
				Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnUpdateAreaAlertUiEnable, areaId, true);
			}
			if (alertAreaData.AlertUiVisible)
			{
				Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnUpdateAreaAlertUiVisible, areaId, true);
			}
		}

		// Token: 0x060450AF RID: 282799 RVA: 0x011FADC8 File Offset: 0x011F8FC8
		public void DisableAlertArea(int areaId)
		{
			AlertAreaData alertAreaData;
			if (!this.EnabledAreaAlertData.TryGetValue(areaId, out alertAreaData))
			{
				return;
			}
			if (alertAreaData.AlertUiEnabled && alertAreaData.AlertUiVisible)
			{
				alertAreaData.AlertUiVisible = false;
				Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnUpdateAreaAlertUiVisible, areaId, false);
			}
			if (alertAreaData.AlertUiEnabled)
			{
				alertAreaData.AlertUiEnabled = false;
				Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnUpdateAreaAlertUiEnable, areaId, false);
			}
			this.EnabledAreaAlertData.Remove(areaId);
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnUpdateAreaAlertEnable, areaId, false);
		}

		// Token: 0x04026844 RID: 157764
		private readonly Dictionary<int, AlertAreaData> EnabledAreaAlertData = new Dictionary<int, AlertAreaData>();
	}
}
