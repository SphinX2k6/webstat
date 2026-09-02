using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

namespace CSharpScript.Game.Module.Audio
{
	// Token: 0x0200615E RID: 24926
	[NullableContext(1)]
	[Nullable(0)]
	public class EntityCooldownProbability
	{
		// Token: 0x17009AEC RID: 39660
		// (get) Token: 0x0603EFC8 RID: 257992 RVA: 0x01024E69 File Offset: 0x01023069
		private Dictionary<int, EntityCooldownProbability.CooldownRecord> AudioEventCooldownTimeMapById
		{
			get
			{
				if (this.AudioEventCooldownTimeMapByIdInternal == null)
				{
					this.AudioEventCooldownTimeMapByIdInternal = new Dictionary<int, EntityCooldownProbability.CooldownRecord>();
				}
				return this.AudioEventCooldownTimeMapByIdInternal;
			}
		}

		// Token: 0x17009AED RID: 39661
		// (get) Token: 0x0603EFC9 RID: 257993 RVA: 0x01024E84 File Offset: 0x01023084
		private Dictionary<string, EntityCooldownProbability.CooldownRecord> AudioEventCooldownTimeMapByName
		{
			get
			{
				if (this.AudioEventCooldownTimeMapByNameInternal == null)
				{
					this.AudioEventCooldownTimeMapByNameInternal = new Dictionary<string, EntityCooldownProbability.CooldownRecord>();
				}
				return this.AudioEventCooldownTimeMapByNameInternal;
			}
		}

		// Token: 0x0603EFCA RID: 257994 RVA: 0x01024E9F File Offset: 0x0102309F
		public void Init(int id, int modelId)
		{
			this.EntityId = id;
			this.ModelId = modelId;
		}

		// Token: 0x0603EFCB RID: 257995 RVA: 0x01024EAF File Offset: 0x010230AF
		public void Clear()
		{
			this.TagComp = null;
			this.AudioEventCooldownTimeMapById.Clear();
			this.AudioEventCooldownTimeMapByIdInternal = null;
			this.AudioEventCooldownTimeMapByName.Clear();
			this.AudioEventCooldownTimeMapByNameInternal = null;
		}

		// Token: 0x0603EFCC RID: 257996 RVA: 0x01024EDC File Offset: 0x010230DC
		public bool CheckTimeOutCooldownRecords()
		{
			bool flag = this.CheckTimeOutCooldownRecordsImpl<int>(this.AudioEventCooldownTimeMapById);
			bool flag2 = this.CheckTimeOutCooldownRecordsImpl<string>(this.AudioEventCooldownTimeMapByName);
			return flag && flag2;
		}

		// Token: 0x0603EFCD RID: 257997 RVA: 0x01024F04 File Offset: 0x01023104
		private bool CheckTimeOutCooldownRecordsImpl<T>(Dictionary<T, EntityCooldownProbability.CooldownRecord> dict)
		{
			List<T> list = new List<T>();
			foreach (KeyValuePair<T, EntityCooldownProbability.CooldownRecord> keyValuePair in dict)
			{
				if (Singleton<Time>.Instance.Now - keyValuePair.Value.Time >= Math.Max(keyValuePair.Value.Cooldown, 20000.0))
				{
					list.Add(keyValuePair.Key);
				}
			}
			foreach (T key in list)
			{
				dict.Remove(key);
			}
			return dict.Count == 0;
		}

		// Token: 0x0603EFCE RID: 257998 RVA: 0x01024FDC File Offset: 0x010231DC
		public bool CheckPlayAudio([Nullable(new byte[]
		{
			0,
			1
		})] OneOf<int, string> eventObj, IAudioCoolDownWithTagInfo info, bool update = true, bool log = true)
		{
			if (info.TagProbability != null && info.TagProbability.Num() > 0)
			{
				if (this.TagComp == null)
				{
					this.TagComp = Singleton<EntitySystem>.Instance.GetComponent<BaseTagComponent>(this.EntityId);
				}
				int num = 0;
				while (num < info.TagProbability.Num() && this.TagComp != null)
				{
					SGameplayTagProbabilityCooldownInfo sgameplayTagProbabilityCooldownInfo = info.TagProbability.Get(num);
					if (sgameplayTagProbabilityCooldownInfo != null && this.TagComp.HasTag(sgameplayTagProbabilityCooldownInfo.GameplayTag.TagId()))
					{
						bool flag = this.CheckCooldownProbability(eventObj, (double)sgameplayTagProbabilityCooldownInfo.Probability, (double)sgameplayTagProbabilityCooldownInfo.CooldownTime, update, log);
						bool flag2 = flag && update && log;
						return flag;
					}
					num++;
				}
			}
			bool flag3 = this.CheckCooldownProbability(eventObj, info.DefaultProbability, (double)info.DefaultCooldownTime, update, log);
			bool flag4 = flag3 && log;
			return flag3;
		}

		// Token: 0x0603EFCF RID: 257999 RVA: 0x010250A8 File Offset: 0x010232A8
		public void UpdateCooldownRecord([Nullable(new byte[]
		{
			0,
			1
		})] OneOf<int, string> eventObj, double probability, double cooldownTime, bool log = true)
		{
			if (eventObj.IsT1)
			{
				this.UpdateCooldownRecordImpl<int>(this.AudioEventCooldownTimeMapById, eventObj.AsT1, probability, cooldownTime, log);
				return;
			}
			if (eventObj.IsT2)
			{
				this.UpdateCooldownRecordImpl<string>(this.AudioEventCooldownTimeMapByName, eventObj.AsT2, probability, cooldownTime, log);
			}
		}

		// Token: 0x0603EFD0 RID: 258000 RVA: 0x010250F8 File Offset: 0x010232F8
		private void UpdateCooldownRecordImpl<T>(Dictionary<T, EntityCooldownProbability.CooldownRecord> dict, T eventObj, double probability, double cooldownTime, bool log = true)
		{
			EntityCooldownProbability.CooldownRecord cooldownRecord;
			if (dict.TryGetValue(eventObj, out cooldownRecord))
			{
				double now = Singleton<Time>.Instance.Now;
				double time = cooldownRecord.Time;
			}
			dict[eventObj] = new EntityCooldownProbability.CooldownRecord
			{
				Time = Singleton<Time>.Instance.Now,
				Cooldown = cooldownTime
			};
		}

		// Token: 0x0603EFD1 RID: 258001 RVA: 0x0102514C File Offset: 0x0102334C
		private bool CheckCooldownProbability([Nullable(new byte[]
		{
			0,
			1
		})] OneOf<int, string> eventObj, double probability, double cooldownTime, bool update = true, bool log = true)
		{
			if (this.GetProbabilityResult<OneOf<int, string>>(eventObj, probability, log))
			{
				double num = -1.0;
				EntityCooldownProbability.CooldownRecord cooldownRecord2;
				if (eventObj.IsT1)
				{
					EntityCooldownProbability.CooldownRecord cooldownRecord;
					if (this.AudioEventCooldownTimeMapById.TryGetValue(eventObj.AsT1, out cooldownRecord))
					{
						num = Singleton<Time>.Instance.Now - cooldownRecord.Time;
					}
				}
				else if (eventObj.IsT2 && this.AudioEventCooldownTimeMapByName.TryGetValue(eventObj.AsT2, out cooldownRecord2))
				{
					num = Singleton<Time>.Instance.Now - cooldownRecord2.Time;
				}
				if (num < 0.0 || num > cooldownTime)
				{
					if (cooldownTime != 0.0 && update)
					{
						this.UpdateCooldownRecord(eventObj, probability, cooldownTime, log);
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603EFD2 RID: 258002 RVA: 0x0102520C File Offset: 0x0102340C
		private bool GetProbabilityResult<[Nullable(2)] T>(T eventObj, double probability, bool log = true)
		{
			if (Math.Abs(probability - 1.0) < 0.0001 || Math.Abs(probability) < 0.0001)
			{
				return Math.Abs(probability - 1.0) < 0.0001;
			}
			double num = new Random().NextDouble();
			bool flag = num >= probability && log;
			return num < probability;
		}

		// Token: 0x0603EFD3 RID: 258003 RVA: 0x01025278 File Offset: 0x01023478
		public static bool GetProbability(Number probability)
		{
			if (probability == 1 || probability == 0)
			{
				return probability == 1;
			}
			return new Random().NextDouble() < probability;
		}

		// Token: 0x04023572 RID: 144754
		public int EntityId;

		// Token: 0x04023573 RID: 144755
		public int ModelId;

		// Token: 0x04023574 RID: 144756
		[Nullable(2)]
		public BaseTagComponent TagComp;

		// Token: 0x04023575 RID: 144757
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, EntityCooldownProbability.CooldownRecord> AudioEventCooldownTimeMapByIdInternal;

		// Token: 0x04023576 RID: 144758
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, EntityCooldownProbability.CooldownRecord> AudioEventCooldownTimeMapByNameInternal;

		// Token: 0x0200C2E8 RID: 49896
		[NullableContext(0)]
		public class CooldownRecord
		{
			// Token: 0x1700AA4A RID: 43594
			// (get) Token: 0x0604E70D RID: 321293 RVA: 0x015C2806 File Offset: 0x015C0A06
			// (set) Token: 0x0604E70E RID: 321294 RVA: 0x015C280E File Offset: 0x015C0A0E
			public double Time { get; set; }

			// Token: 0x1700AA4B RID: 43595
			// (get) Token: 0x0604E70F RID: 321295 RVA: 0x015C2817 File Offset: 0x015C0A17
			// (set) Token: 0x0604E710 RID: 321296 RVA: 0x015C281F File Offset: 0x015C0A1F
			public double Cooldown { get; set; }
		}
	}
}
