using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.NewWorld.Character.Npc.Component;

namespace CSharpScript.Game.NewWorld.Character.Npc.Controller
{
	// Token: 0x020048D7 RID: 18647
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class NpcTimetableController : ControllerBase<NpcTimetableController>
	{
		// Token: 0x06030A6C RID: 199276 RVA: 0x00BFCFEC File Offset: 0x00BFB1EC
		protected override bool OnInit()
		{
			GlobalConfigFromCsv? globalConfigFromCsv;
			string text = (ConfigGlobalConfigFromCsvByName.GetConfig("Schedule.MaxDelayTime", true) != null) ? globalConfigFromCsv.GetValueOrDefault().Value : null;
			this.MaxDelaySwitchTime = float.Parse(text ?? "0");
			Singleton<Net>.Instance.Register<TimeScheduleTriggerNotify>(ENotifyMessageId.TimeScheduleTriggerNotify, new Action<TimeScheduleTriggerNotify, Net.CallbackStatus>(this.OnTimeScheduleTriggerNotify));
			Singleton<Net>.Instance.Register<TimeScheduleIdleNotify>(ENotifyMessageId.TimeScheduleIdleNotify, new Action<TimeScheduleIdleNotify, Net.CallbackStatus>(this.OnTimeScheduleEndNotify));
			return true;
		}

		// Token: 0x06030A6D RID: 199277 RVA: 0x00BFD06F File Offset: 0x00BFB26F
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TimeScheduleTriggerNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TimeScheduleIdleNotify);
			return true;
		}

		// Token: 0x06030A6E RID: 199278 RVA: 0x00BFD094 File Offset: 0x00BFB294
		protected void OnTimeScheduleTriggerNotify(TimeScheduleTriggerNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			TimetableConfigData timetableConfigData = this.GetTimetableConfigData(data.TimeScheduleId);
			if (timetableConfigData == null)
			{
				return;
			}
			foreach (long num in data.EntityIds)
			{
				this.TimeScheduleCache[num] = timetableConfigData;
				this.ClearTimetableSavedData(num, "Notify");
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num);
				if (entity != null)
				{
					WorldEntity entity2 = entity.Entity;
					if (((entity2 != null) ? new bool?(entity2.IsInit) : null).GetValueOrDefault())
					{
						NpcTimetableComponent component = entity.Entity.GetComponent<NpcTimetableComponent>();
						if (component != null)
						{
							component.SwitchTimetable(timetableConfigData, "Notify", true);
						}
					}
				}
			}
		}

		// Token: 0x06030A6F RID: 199279 RVA: 0x00BFD15C File Offset: 0x00BFB35C
		protected void OnTimeScheduleEndNotify(TimeScheduleIdleNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			foreach (long num in data.EntityIds)
			{
				this.TimeScheduleCache.Remove(num);
				this.ClearTimetableSavedData(num, "Notify");
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num);
				if (entity != null)
				{
					WorldEntity entity2 = entity.Entity;
					if (((entity2 != null) ? new bool?(entity2.IsInit) : null).GetValueOrDefault())
					{
						NpcTimetableComponent component = entity.Entity.GetComponent<NpcTimetableComponent>();
						if (component != null)
						{
							component.StopTimetable("Notify", true);
						}
					}
				}
			}
		}

		// Token: 0x06030A70 RID: 199280 RVA: 0x00BFD210 File Offset: 0x00BFB410
		[NullableContext(2)]
		public TimetableConfigData GetTimeScheduleByCreatureId(long creatureId)
		{
			TimetableConfigData result;
			this.TimeScheduleCache.TryGetValue(creatureId, out result);
			return result;
		}

		// Token: 0x06030A71 RID: 199281 RVA: 0x00BFD230 File Offset: 0x00BFB430
		[NullableContext(2)]
		protected TimetableConfigData GetTimetableConfigData(int scheduleId)
		{
			TimetableConfigData result;
			if (!this.TimeScheduleConfigDataMap.TryGetValue(scheduleId, out result))
			{
				TimetableConfigData timetableConfigData = this.ParseTimeScheduleFromId(scheduleId);
				if (timetableConfigData == null)
				{
					return null;
				}
				this.TimeScheduleConfigDataMap[scheduleId] = timetableConfigData;
				result = timetableConfigData;
			}
			return result;
		}

		// Token: 0x06030A72 RID: 199282 RVA: 0x00BFD26C File Offset: 0x00BFB46C
		[NullableContext(2)]
		protected TimetableConfigData ParseTimeScheduleFromId(int scheduleId)
		{
			TimeSchedule? timeScheduleData = ConfigBase<TimeScheduleConfig>.Instance.GetTimeScheduleData(scheduleId);
			if (timeScheduleData == null)
			{
				return null;
			}
			AiBehaviorTree? aiBehaviorTreeData = ConfigBase<AiBehaviorTreeConfig>.Instance.GetAiBehaviorTreeData(timeScheduleData.Value.BehaviorTree);
			if (((aiBehaviorTreeData != null) ? aiBehaviorTreeData.GetValueOrDefault().BtPath : null) == null || aiBehaviorTreeData.Value.BtPath == "")
			{
				return null;
			}
			TimetableConfigData timetableConfigData = new TimetableConfigData();
			timetableConfigData.BehaviorTreePath = aiBehaviorTreeData.Value.BtPath;
			int num = timeScheduleData.Value.SplineEntityUid.LastIndexOf('_');
			timetableConfigData.SplineId = int.Parse(timeScheduleData.Value.SplineEntityUid.Substring(num + 1));
			num = timeScheduleData.Value.StartTime.IndexOf(':');
			timetableConfigData.StartTime = int.Parse(timeScheduleData.Value.StartTime.Substring(0, num));
			num = timeScheduleData.Value.EndTime.IndexOf(':');
			timetableConfigData.EndTime = int.Parse(timeScheduleData.Value.EndTime.Substring(0, num));
			return timetableConfigData;
		}

		// Token: 0x06030A73 RID: 199283 RVA: 0x00BFD3AA File Offset: 0x00BFB5AA
		public void SaveTimetableSavedData(long creatureId, TimetableSavedData state)
		{
			this.TimetableSavedDataMap[creatureId] = state.DeepCopy();
		}

		// Token: 0x06030A74 RID: 199284 RVA: 0x00BFD3C0 File Offset: 0x00BFB5C0
		public void ClearTimetableSavedData(long creatureId, string reason = "")
		{
			TimetableSavedData timetableSavedData;
			if (!this.TimetableSavedDataMap.TryGetValue(creatureId, out timetableSavedData))
			{
				return;
			}
			this.TimetableSavedDataMap.Remove(creatureId);
		}

		// Token: 0x06030A75 RID: 199285 RVA: 0x00BFD3EC File Offset: 0x00BFB5EC
		[NullableContext(2)]
		public TimetableSavedData GetTimetableSavedData(long creatureId)
		{
			TimetableSavedData result;
			this.TimetableSavedDataMap.TryGetValue(creatureId, out result);
			return result;
		}

		// Token: 0x06030A76 RID: 199286 RVA: 0x00BFD40C File Offset: 0x00BFB60C
		public bool IsInTimeSchedule(Entity entity)
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			return component != null && this.TimeScheduleCache.ContainsKey(component.GetCreatureDataId());
		}

		// Token: 0x06030A77 RID: 199287 RVA: 0x00BFD436 File Offset: 0x00BFB636
		public float GetMaxDelaySwitchTime()
		{
			return this.MaxDelaySwitchTime;
		}

		// Token: 0x06030A78 RID: 199288 RVA: 0x00BFD440 File Offset: 0x00BFB640
		public void TestSwitchSchedule(int scheduleId, IReadOnlyList<int> creatureIds)
		{
			TimetableConfigData timetableConfigData = this.ParseTimeScheduleFromId(scheduleId);
			if (timetableConfigData == null)
			{
				return;
			}
			foreach (int num in creatureIds)
			{
				long num2 = (long)num;
				this.TimeScheduleCache[num2] = timetableConfigData;
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num2);
				if (entity != null)
				{
					WorldEntity entity2 = entity.Entity;
					if (((entity2 != null) ? new bool?(entity2.IsInit) : null).GetValueOrDefault())
					{
						NpcTimetableComponent component = entity.Entity.GetComponent<NpcTimetableComponent>();
						if (component != null)
						{
							component.SwitchTimetable(timetableConfigData, "Test", false);
						}
					}
				}
			}
		}

		// Token: 0x06030A79 RID: 199289 RVA: 0x00BFD4F4 File Offset: 0x00BFB6F4
		public void TestSwitchSchedule2(TimetableConfigData timetableData, IReadOnlyList<long> creatureIds)
		{
			foreach (long num in creatureIds)
			{
				this.TimeScheduleCache[num] = timetableData;
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num);
				if (entity != null)
				{
					WorldEntity entity2 = entity.Entity;
					if (((entity2 != null) ? new bool?(entity2.IsInit) : null).GetValueOrDefault())
					{
						NpcTimetableComponent component = entity.Entity.GetComponent<NpcTimetableComponent>();
						if (component != null)
						{
							component.SwitchTimetable(timetableData, "Test", false);
						}
					}
				}
			}
		}

		// Token: 0x0401BF77 RID: 114551
		protected float MaxDelaySwitchTime;

		// Token: 0x0401BF78 RID: 114552
		protected readonly Dictionary<long, TimetableSavedData> TimetableSavedDataMap = new Dictionary<long, TimetableSavedData>();

		// Token: 0x0401BF79 RID: 114553
		protected readonly Dictionary<int, TimetableConfigData> TimeScheduleConfigDataMap = new Dictionary<int, TimetableConfigData>();

		// Token: 0x0401BF7A RID: 114554
		protected readonly Dictionary<long, TimetableConfigData> TimeScheduleCache = new Dictionary<long, TimetableConfigData>();
	}
}
