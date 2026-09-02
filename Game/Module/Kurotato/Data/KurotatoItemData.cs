using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AF0 RID: 23280
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoItemData
	{
		// Token: 0x0603ADE8 RID: 241128 RVA: 0x00EEE48D File Offset: 0x00EEC68D
		public KurotatoItemData(KurotatoItem config, int activityId)
		{
			this.Config = config;
			this.ActivityId = activityId;
		}

		// Token: 0x170095C2 RID: 38338
		// (get) Token: 0x0603ADE9 RID: 241129 RVA: 0x00EEE4A3 File Offset: 0x00EEC6A3
		// (set) Token: 0x0603ADEA RID: 241130 RVA: 0x00EEE4AB File Offset: 0x00EEC6AB
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

		// Token: 0x170095C3 RID: 38339
		// (get) Token: 0x0603ADEB RID: 241131 RVA: 0x00EEE4B4 File Offset: 0x00EEC6B4
		public bool HasRedDot
		{
			get
			{
				return this.IsUnLock && this.ConditionId != 0 && ModelBase<ActivityModel>.Instance.GetActivityCacheData(this.ActivityId, 0, 3, this.Id, 0) == 0;
			}
		}

		// Token: 0x0603ADEC RID: 241132 RVA: 0x00EEE4E4 File Offset: 0x00EEC6E4
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
			ModelBase<ActivityModel>.Instance.SaveActivityData(this.ActivityId, 3, this.Id, 0, 1);
			if (!emitEvent)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshKurotatoWeaponAndPropRedDot);
		}

		// Token: 0x170095C4 RID: 38340
		// (get) Token: 0x0603ADED RID: 241133 RVA: 0x00EEE548 File Offset: 0x00EEC748
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x170095C5 RID: 38341
		// (get) Token: 0x0603ADEE RID: 241134 RVA: 0x00EEE564 File Offset: 0x00EEC764
		public string Name
		{
			get
			{
				return this.Config.Name;
			}
		}

		// Token: 0x170095C6 RID: 38342
		// (get) Token: 0x0603ADEF RID: 241135 RVA: 0x00EEE580 File Offset: 0x00EEC780
		public string Desc
		{
			get
			{
				return this.Config.Desc;
			}
		}

		// Token: 0x170095C7 RID: 38343
		// (get) Token: 0x0603ADF0 RID: 241136 RVA: 0x00EEE59C File Offset: 0x00EEC79C
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

		// Token: 0x170095C8 RID: 38344
		// (get) Token: 0x0603ADF1 RID: 241137 RVA: 0x00EEE5E0 File Offset: 0x00EEC7E0
		public int ConditionId
		{
			get
			{
				return this.Config.UnlockConditionId;
			}
		}

		// Token: 0x170095C9 RID: 38345
		// (get) Token: 0x0603ADF2 RID: 241138 RVA: 0x00EEE5FC File Offset: 0x00EEC7FC
		public int Quality
		{
			get
			{
				return this.Config.Quality;
			}
		}

		// Token: 0x04021404 RID: 136196
		private readonly KurotatoItem Config;

		// Token: 0x04021405 RID: 136197
		private bool IsUnLockInternal;

		// Token: 0x04021406 RID: 136198
		private readonly int ActivityId;
	}
}
