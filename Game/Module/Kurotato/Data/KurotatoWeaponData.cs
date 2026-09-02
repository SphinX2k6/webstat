using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AF6 RID: 23286
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoWeaponData
	{
		// Token: 0x0603AE41 RID: 241217 RVA: 0x00EEEDD3 File Offset: 0x00EECFD3
		public KurotatoWeaponData(KurotatoWeapon config, int activityId)
		{
			this.Config = config;
			this.ActivityId = activityId;
		}

		// Token: 0x170095F9 RID: 38393
		// (get) Token: 0x0603AE42 RID: 241218 RVA: 0x00EEEDE9 File Offset: 0x00EECFE9
		// (set) Token: 0x0603AE43 RID: 241219 RVA: 0x00EEEDF1 File Offset: 0x00EECFF1
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

		// Token: 0x170095FA RID: 38394
		// (get) Token: 0x0603AE44 RID: 241220 RVA: 0x00EEEDFA File Offset: 0x00EECFFA
		public bool HasRedDot
		{
			get
			{
				return this.IsUnLock && this.ConditionId != 0 && ModelBase<ActivityModel>.Instance.GetActivityCacheData(this.ActivityId, 0, 2, this.Id, 0) == 0;
			}
		}

		// Token: 0x0603AE45 RID: 241221 RVA: 0x00EEEE2C File Offset: 0x00EED02C
		public void ReadRedDot(bool emitEvent = true)
		{
			if (!this.IsUnLock)
			{
				return;
			}
			if (!this.HasRedDot)
			{
				return;
			}
			ModelBase<ActivityModel>.Instance.SaveActivityData(this.ActivityId, 2, this.Id, 0, 1);
			if (!emitEvent)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoWeaponAndPropRedDot);
		}

		// Token: 0x170095FB RID: 38395
		// (get) Token: 0x0603AE46 RID: 241222 RVA: 0x00EEEE90 File Offset: 0x00EED090
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x170095FC RID: 38396
		// (get) Token: 0x0603AE47 RID: 241223 RVA: 0x00EEEEAC File Offset: 0x00EED0AC
		public string Name
		{
			get
			{
				return this.Config.Name;
			}
		}

		// Token: 0x170095FD RID: 38397
		// (get) Token: 0x0603AE48 RID: 241224 RVA: 0x00EEEEC8 File Offset: 0x00EED0C8
		public string Desc
		{
			get
			{
				return this.Config.Desc;
			}
		}

		// Token: 0x170095FE RID: 38398
		// (get) Token: 0x0603AE49 RID: 241225 RVA: 0x00EEEEE4 File Offset: 0x00EED0E4
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

		// Token: 0x170095FF RID: 38399
		// (get) Token: 0x0603AE4A RID: 241226 RVA: 0x00EEEF28 File Offset: 0x00EED128
		public int ConditionId
		{
			get
			{
				return ConfigBase<KurotatoConfig>.Instance.GetWeaponGroupById(this.Config.GroupId).Value.UnlockConditionId;
			}
		}

		// Token: 0x17009600 RID: 38400
		// (get) Token: 0x0603AE4B RID: 241227 RVA: 0x00EEEF60 File Offset: 0x00EED160
		public int Quality
		{
			get
			{
				return this.Config.Quality;
			}
		}

		// Token: 0x0402141D RID: 136221
		private readonly KurotatoWeapon Config;

		// Token: 0x0402141E RID: 136222
		private bool IsUnLockInternal;

		// Token: 0x0402141F RID: 136223
		private readonly int ActivityId;
	}
}
