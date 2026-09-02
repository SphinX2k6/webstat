using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity
{
	// Token: 0x0200694F RID: 26959
	public class DirectTrainActivityData : ActivityBaseData
	{
		// Token: 0x06042E78 RID: 274040 RVA: 0x0112C31C File Offset: 0x0112A51C
		[NullableContext(1)]
		protected override void PhraseEx(ActivityData data)
		{
			ThroughTrainSummaryActivityData throughTrainSummaryActivityData = data.ThroughTrainSummaryActivityData;
			RepeatedField<int> repeatedField = (throughTrainSummaryActivityData != null) ? throughTrainSummaryActivityData.ActivityIds : null;
			DirectTrainModel instance = ModelBase<DirectTrainModel>.Instance;
			if (instance != null)
			{
				instance.SetMainSubActivityIds(repeatedField);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.ActivityDirectTrainDataUpdate);
			if (this.IsAllSubActivityFinishedOrAbsent(repeatedField))
			{
				base.ForceClose();
			}
		}

		// Token: 0x06042E79 RID: 274041 RVA: 0x0112C36C File Offset: 0x0112A56C
		[NullableContext(2)]
		private bool IsAllSubActivityFinishedOrAbsent(IReadOnlyList<int> subActivityIds)
		{
			if (subActivityIds == null || subActivityIds.Count == 0)
			{
				return true;
			}
			foreach (int id in subActivityIds)
			{
				ActivityModel instance = ModelBase<ActivityModel>.Instance;
				ActivityBaseData activityBaseData = (instance != null) ? instance.GetActivityById(id) : null;
				if (activityBaseData != null && !activityBaseData.FinishShowState)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06042E7A RID: 274042 RVA: 0x0112C3E0 File Offset: 0x0112A5E0
		public override bool GetExDataRedPointShowState()
		{
			DirectTrainModel instance = ModelBase<DirectTrainModel>.Instance;
			return instance != null && instance.HasUnReadSubActivity();
		}

		// Token: 0x06042E7B RID: 274043 RVA: 0x0112C3F2 File Offset: 0x0112A5F2
		protected override bool GetExDataFinishShowState()
		{
			return false;
		}

		// Token: 0x1700A1D3 RID: 41427
		// (get) Token: 0x06042E7C RID: 274044 RVA: 0x0112C3F5 File Offset: 0x0112A5F5
		public override bool RedPointShowState
		{
			get
			{
				return this.CheckIfInShowTime() && !base.IsHiddenByConfig() && (base.GetIfFirstOpen() || this.GetExDataRedPointShowState());
			}
		}
	}
}
