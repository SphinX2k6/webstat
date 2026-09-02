using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AF5 RID: 23285
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoRoleData
	{
		// Token: 0x0603AE25 RID: 241189 RVA: 0x00EEEA3B File Offset: 0x00EECC3B
		public KurotatoRoleData(KurotatoCharacter config, int activityId)
		{
			this.Config = config;
			this.ActivityId = activityId;
		}

		// Token: 0x170095E5 RID: 38373
		// (get) Token: 0x0603AE26 RID: 241190 RVA: 0x00EEEA51 File Offset: 0x00EECC51
		// (set) Token: 0x0603AE27 RID: 241191 RVA: 0x00EEEA59 File Offset: 0x00EECC59
		public bool IsUnLock
		{
			get
			{
				return this.IsUnLockInternal;
			}
			set
			{
				this.IsUnLockInternal = value;
			}
		}

		// Token: 0x170095E6 RID: 38374
		// (get) Token: 0x0603AE28 RID: 241192 RVA: 0x00EEEA62 File Offset: 0x00EECC62
		// (set) Token: 0x0603AE29 RID: 241193 RVA: 0x00EEEA6A File Offset: 0x00EECC6A
		public int HistoryWave
		{
			get
			{
				return this.HistoryWaveInternal;
			}
			set
			{
				this.HistoryWaveInternal = value;
			}
		}

		// Token: 0x170095E7 RID: 38375
		// (get) Token: 0x0603AE2A RID: 241194 RVA: 0x00EEEA73 File Offset: 0x00EECC73
		// (set) Token: 0x0603AE2B RID: 241195 RVA: 0x00EEEA7B File Offset: 0x00EECC7B
		public int HistoryKillNum
		{
			get
			{
				return this.HistoryKillNumInternal;
			}
			set
			{
				this.HistoryKillNumInternal = value;
			}
		}

		// Token: 0x170095E8 RID: 38376
		// (get) Token: 0x0603AE2C RID: 241196 RVA: 0x00EEEA84 File Offset: 0x00EECC84
		public bool HasHistory
		{
			get
			{
				return this.HistoryWaveInternal != 0;
			}
		}

		// Token: 0x170095E9 RID: 38377
		// (get) Token: 0x0603AE2D RID: 241197 RVA: 0x00EEEA8F File Offset: 0x00EECC8F
		public bool HasArchived
		{
			get
			{
				return this.ArchivedDataInternal != null;
			}
		}

		// Token: 0x170095EA RID: 38378
		// (get) Token: 0x0603AE2E RID: 241198 RVA: 0x00EEEA9A File Offset: 0x00EECC9A
		// (set) Token: 0x0603AE2F RID: 241199 RVA: 0x00EEEAA2 File Offset: 0x00EECCA2
		[Nullable(2)]
		public KurotatoInstInfo ArchivedData
		{
			[NullableContext(2)]
			get
			{
				return this.ArchivedDataInternal;
			}
			[NullableContext(2)]
			set
			{
				this.ArchivedDataInternal = value;
			}
		}

		// Token: 0x170095EB RID: 38379
		// (get) Token: 0x0603AE30 RID: 241200 RVA: 0x00EEEAAB File Offset: 0x00EECCAB
		public bool HasHandBookRedDot
		{
			get
			{
				return this.IsUnLock && this.ConditionId != 0 && ModelBase<ActivityModel>.Instance.GetActivityCacheData(this.ActivityId, 0, 1, this.Id, 0) == 0;
			}
		}

		// Token: 0x0603AE31 RID: 241201 RVA: 0x00EEEADC File Offset: 0x00EECCDC
		public void ReadHandBookRedDot(bool emitEvent = true)
		{
			if (!this.IsUnLock)
			{
				return;
			}
			if (!this.HasHandBookRedDot)
			{
				return;
			}
			ModelBase<ActivityModel>.Instance.SaveActivityData(this.ActivityId, 1, this.Id, 0, 1);
			if (!emitEvent)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoRoleRedDot);
		}

		// Token: 0x170095EC RID: 38380
		// (get) Token: 0x0603AE32 RID: 241202 RVA: 0x00EEEB3E File Offset: 0x00EECD3E
		public bool HasRoleSelectRedDot
		{
			get
			{
				return this.IsUnLock && this.ConditionId != 0 && ModelBase<ActivityModel>.Instance.GetActivityCacheData(this.ActivityId, 0, 5, this.Id, 0) == 0;
			}
		}

		// Token: 0x0603AE33 RID: 241203 RVA: 0x00EEEB6E File Offset: 0x00EECD6E
		public void ReadRoleSelectRedDot()
		{
			if (!this.IsUnLock)
			{
				return;
			}
			if (!this.HasRoleSelectRedDot)
			{
				return;
			}
			ModelBase<ActivityModel>.Instance.SaveActivityData(this.ActivityId, 5, this.Id, 0, 1);
		}

		// Token: 0x170095ED RID: 38381
		// (get) Token: 0x0603AE34 RID: 241204 RVA: 0x00EEEB9B File Offset: 0x00EECD9B
		public bool NeedPlayUnlockAnim
		{
			get
			{
				return this.IsUnLock && this.ConditionId != 0 && ModelBase<ActivityModel>.Instance.GetActivityCacheData(this.ActivityId, 0, 6, this.Id, 0) == 0;
			}
		}

		// Token: 0x0603AE35 RID: 241205 RVA: 0x00EEEBCB File Offset: 0x00EECDCB
		public void MarkUnlockAnimPlayed()
		{
			if (!this.NeedPlayUnlockAnim)
			{
				return;
			}
			ModelBase<ActivityModel>.Instance.SaveActivityData(this.ActivityId, 6, this.Id, 0, 1);
		}

		// Token: 0x170095EE RID: 38382
		// (get) Token: 0x0603AE36 RID: 241206 RVA: 0x00EEEBF0 File Offset: 0x00EECDF0
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x170095EF RID: 38383
		// (get) Token: 0x0603AE37 RID: 241207 RVA: 0x00EEEC0C File Offset: 0x00EECE0C
		public string Name
		{
			get
			{
				return this.Config.Name;
			}
		}

		// Token: 0x170095F0 RID: 38384
		// (get) Token: 0x0603AE38 RID: 241208 RVA: 0x00EEEC28 File Offset: 0x00EECE28
		public string Desc
		{
			get
			{
				return this.Config.Desc;
			}
		}

		// Token: 0x170095F1 RID: 38385
		// (get) Token: 0x0603AE39 RID: 241209 RVA: 0x00EEEC44 File Offset: 0x00EECE44
		public string[] DescParam
		{
			get
			{
				int descParamsLength = this.Config.DescParamsLength;
				string[] array = new string[descParamsLength];
				for (int i = 0; i < descParamsLength; i++)
				{
					array[i] = this.Config.DescParams(i);
				}
				return array;
			}
		}

		// Token: 0x170095F2 RID: 38386
		// (get) Token: 0x0603AE3A RID: 241210 RVA: 0x00EEEC86 File Offset: 0x00EECE86
		public int RealRoleId
		{
			get
			{
				return ModelBase<KurotatoModel>.Instance.GetRoleDataByKurotatoRoleId(this.Id).GetDataId();
			}
		}

		// Token: 0x170095F3 RID: 38387
		// (get) Token: 0x0603AE3B RID: 241211 RVA: 0x00EEEC9D File Offset: 0x00EECE9D
		public int RealRoleSkinId
		{
			get
			{
				return ModelBase<KurotatoModel>.Instance.GetRoleDataByKurotatoRoleId(this.Id).GetRoleSkinId();
			}
		}

		// Token: 0x170095F4 RID: 38388
		// (get) Token: 0x0603AE3C RID: 241212 RVA: 0x00EEECB4 File Offset: 0x00EECEB4
		public List<int> InitItemIds
		{
			get
			{
				if (this.InitItemIdsInternal == null)
				{
					this.InitItemIdsInternal = new List<int>();
					int initItemIdsLength = this.Config.InitItemIdsLength;
					for (int i = 0; i < initItemIdsLength; i++)
					{
						int num = this.Config.InitItemIds(i);
						KurotatoItem? itemConfigByItemId = ConfigBase<KurotatoConfig>.Instance.GetItemConfigByItemId(num);
						if (itemConfigByItemId != null && itemConfigByItemId.Value.Type == 2)
						{
							this.InitItemIdsInternal.Add(num);
						}
					}
				}
				return this.InitItemIdsInternal;
			}
		}

		// Token: 0x170095F5 RID: 38389
		// (get) Token: 0x0603AE3D RID: 241213 RVA: 0x00EEED3C File Offset: 0x00EECF3C
		public List<int> InitWeaponIds
		{
			get
			{
				List<int> list = new List<int>();
				int initWeaponIdsLength = this.Config.InitWeaponIdsLength;
				for (int i = 0; i < initWeaponIdsLength; i++)
				{
					list.Add(this.Config.InitWeaponIds(i));
				}
				return list;
			}
		}

		// Token: 0x170095F6 RID: 38390
		// (get) Token: 0x0603AE3E RID: 241214 RVA: 0x00EEED80 File Offset: 0x00EECF80
		public int ConditionId
		{
			get
			{
				return this.Config.UnlockConditionId;
			}
		}

		// Token: 0x170095F7 RID: 38391
		// (get) Token: 0x0603AE3F RID: 241215 RVA: 0x00EEED9C File Offset: 0x00EECF9C
		public int JumpLevelId
		{
			get
			{
				return this.Config.JumpLevelId;
			}
		}

		// Token: 0x170095F8 RID: 38392
		// (get) Token: 0x0603AE40 RID: 241216 RVA: 0x00EEEDB8 File Offset: 0x00EECFB8
		public int SortId
		{
			get
			{
				return this.Config.SortId;
			}
		}

		// Token: 0x04021416 RID: 136214
		private readonly KurotatoCharacter Config;

		// Token: 0x04021417 RID: 136215
		private bool IsUnLockInternal;

		// Token: 0x04021418 RID: 136216
		private int HistoryWaveInternal;

		// Token: 0x04021419 RID: 136217
		private int HistoryKillNumInternal;

		// Token: 0x0402141A RID: 136218
		private readonly int ActivityId;

		// Token: 0x0402141B RID: 136219
		[Nullable(2)]
		private KurotatoInstInfo ArchivedDataInternal;

		// Token: 0x0402141C RID: 136220
		[Nullable(2)]
		private List<int> InitItemIdsInternal;
	}
}
