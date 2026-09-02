using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain
{
	// Token: 0x02006944 RID: 26948
	public class ActivityDirectTrainData : ActivityBaseData
	{
		// Token: 0x06042E21 RID: 273953 RVA: 0x0112AF78 File Offset: 0x01129178
		[NullableContext(1)]
		protected override void PhraseEx(ActivityData data)
		{
			ThroughTrainActivityData throughTrainActivityData = data.ThroughTrainActivityData;
			if (throughTrainActivityData != null)
			{
				this.IsFinished = throughTrainActivityData.IsFinish;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.ActivityDirectTrainDataUpdate);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityDirectTrainRedDotUpdate, base.Id);
		}

		// Token: 0x1700A1CE RID: 41422
		// (get) Token: 0x06042E22 RID: 273954 RVA: 0x0112AFC4 File Offset: 0x011291C4
		// (set) Token: 0x06042E23 RID: 273955 RVA: 0x0112B014 File Offset: 0x01129214
		public bool HaveDisplayedGotoRedDot
		{
			get
			{
				if (this.HaveDisplayedGotoRedDotInner == null)
				{
					HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.DirectTrainGotoRedDotHaveDisplayedByActId, null) ?? new HashSet<int>();
					this.HaveDisplayedGotoRedDotInner = new bool?(hashSet.Contains(base.Id));
				}
				return this.HaveDisplayedGotoRedDotInner.Value;
			}
			set
			{
				bool? haveDisplayedGotoRedDotInner = this.HaveDisplayedGotoRedDotInner;
				if (!(haveDisplayedGotoRedDotInner.GetValueOrDefault() == value & haveDisplayedGotoRedDotInner != null))
				{
					if (base.IsUnLock() || ActivityDirectTrainHelper.IsProOpen)
					{
						HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.DirectTrainGotoRedDotHaveDisplayedByActId, null) ?? new HashSet<int>();
						if (value)
						{
							hashSet.Add(base.Id);
						}
						else
						{
							hashSet.Remove(base.Id);
						}
						LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.DirectTrainGotoRedDotHaveDisplayedByActId, hashSet);
					}
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityDirectTrainRedDotUpdate, base.Id);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
				}
				this.HaveDisplayedGotoRedDotInner = new bool?(value);
			}
		}

		// Token: 0x1700A1CF RID: 41423
		// (get) Token: 0x06042E24 RID: 273956 RVA: 0x0112B0BF File Offset: 0x011292BF
		public override bool RedPointShowState
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06042E25 RID: 273957 RVA: 0x0112B0C2 File Offset: 0x011292C2
		protected override bool GetExDataFinishShowState()
		{
			return this.IsFinished;
		}

		// Token: 0x04025440 RID: 152640
		public bool IsFinished;

		// Token: 0x04025441 RID: 152641
		private bool? HaveDisplayedGotoRedDotInner;
	}
}
