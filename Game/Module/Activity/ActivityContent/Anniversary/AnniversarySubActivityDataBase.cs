using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069DE RID: 27102
	public abstract class AnniversarySubActivityDataBase
	{
		// Token: 0x060432E2 RID: 275170 RVA: 0x01143398 File Offset: 0x01141598
		public AnniversarySubActivityDataBase(int id)
		{
			this.Id = id;
			AnniversaryEntrance? anniversaryEntranceById = ConfigBase<AnniversaryActivityConfig>.Instance.GetAnniversaryEntranceById(id);
			if (anniversaryEntranceById != null)
			{
				this.ActivityId = anniversaryEntranceById.Value.ActivityId;
			}
		}

		// Token: 0x060432E3 RID: 275171 RVA: 0x011433DC File Offset: 0x011415DC
		public EAnniversarySubId GetSubId()
		{
			return (EAnniversarySubId)this.Id;
		}

		// Token: 0x060432E4 RID: 275172 RVA: 0x011433E4 File Offset: 0x011415E4
		public int GetActivityId()
		{
			return this.ActivityId;
		}

		// Token: 0x060432E5 RID: 275173 RVA: 0x011433EC File Offset: 0x011415EC
		[NullableContext(2)]
		public ActivityBaseData GetActivityData()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId);
		}

		// Token: 0x060432E6 RID: 275174 RVA: 0x011433FE File Offset: 0x011415FE
		public void SetUnlockTime(long unlockTime)
		{
			this.UnlockTime = unlockTime;
		}

		// Token: 0x1700A1F6 RID: 41462
		// (get) Token: 0x060432E7 RID: 275175 RVA: 0x01143407 File Offset: 0x01141607
		public long GetUnlockTime
		{
			get
			{
				return this.UnlockTime;
			}
		}

		// Token: 0x060432E8 RID: 275176 RVA: 0x01143410 File Offset: 0x01141610
		public EAnniversaryActivityState GetCurrentState()
		{
			ActivityBaseData activityData = this.GetActivityData();
			if (activityData == null)
			{
				return EAnniversaryActivityState.Lock;
			}
			if (activityData.CheckIfClose())
			{
				return EAnniversaryActivityState.Close;
			}
			if (activityData.FinishShowState)
			{
				return EAnniversaryActivityState.Finish;
			}
			return EAnniversaryActivityState.Unlock;
		}

		// Token: 0x060432E9 RID: 275177 RVA: 0x0114343E File Offset: 0x0114163E
		public virtual void FirstClickOpenView()
		{
			ControllerBase<ActivityController>.Instance.OpenActivityById(this.ActivityId, EActivityViewOpenType.Other, null, null);
		}

		// Token: 0x060432EA RID: 275178
		public abstract ValueTuple<int, int> GetCurrentProgress();

		// Token: 0x060432EB RID: 275179 RVA: 0x01143454 File Offset: 0x01141654
		public bool NeedPlayUnlockSequence()
		{
			if (ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) == null)
			{
				return false;
			}
			ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.AnniversaryActivityFirstClick) as ServerStorageSet;
			return serverStorageSet == null || !serverStorageSet.Has(this.ActivityId);
		}

		// Token: 0x04025704 RID: 153348
		protected int Id;

		// Token: 0x04025705 RID: 153349
		protected int ActivityId;

		// Token: 0x04025706 RID: 153350
		protected long UnlockTime;
	}
}
