using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Bubble
{
	// Token: 0x02006A89 RID: 27273
	[NullableContext(1)]
	[Nullable(0)]
	public class TuningStandBubbleProxy
	{
		// Token: 0x06043754 RID: 276308 RVA: 0x011611C4 File Offset: 0x0115F3C4
		public TuningStandBubbleProxy(IList<ITuningStandBubbleConfig> bubbleDataList)
		{
			this.BubbleClassMap[ETuningStandBubbleTriggerType.Enter] = new TuningStandBubbleTypeEnter();
			this.BubbleClassMap[ETuningStandBubbleTriggerType.StartLink] = new TuningStandBubbleTypeStartLink();
			this.BubbleClassMap[ETuningStandBubbleTriggerType.InvalidLink] = new TuningStandBubbleTypeInValidLink();
			this.BubbleClassMap[ETuningStandBubbleTriggerType.LinkUp] = new TuningStandBubbleTypeLinkUp();
			this.BubbleClassMap[ETuningStandBubbleTriggerType.LinkMiss] = new TuningStandBubbleTypeLinkMiss();
			this.BubbleClassMap[ETuningStandBubbleTriggerType.LinkComplete] = new TuningStandBubbleTypeLinkComplete();
			this.BubbleClassMap[ETuningStandBubbleTriggerType.Reset] = new TuningStandBubbleTypeReset();
			this.BubbleClassMap[ETuningStandBubbleTriggerType.TooLong] = new TuningStandBubbleTypeTooLong();
			foreach (ITuningStandBubbleConfig tuningStandBubbleConfig in bubbleDataList)
			{
				this.BubbleClassMap[tuningStandBubbleConfig.TriggerType].Init(tuningStandBubbleConfig.Flow);
			}
			Singleton<EventSystem>.Instance.Add<ETuningStandBubbleTriggerType>(EEventName.TuningStandBubbleEnd, new Action<ETuningStandBubbleTriggerType>(this.OnBubbleEnd));
		}

		// Token: 0x06043755 RID: 276309 RVA: 0x011612D8 File Offset: 0x0115F4D8
		public bool TryStartBubbleFlow(ETuningStandBubbleTriggerType type)
		{
			TuningStandBubbleTypeBase tuningStandBubbleTypeBase;
			if (!this.BubbleClassMap.TryGetValue(type, out tuningStandBubbleTypeBase))
			{
				return false;
			}
			ETuningStandBubbleTriggerType? curPlayingType = this.CurPlayingType;
			if ((curPlayingType.GetValueOrDefault() == type & curPlayingType != null) && !tuningStandBubbleTypeBase.GetCanInterruptBySelf())
			{
				return false;
			}
			TuningStandBubbleTypeBase tuningStandBubbleTypeBase2 = tuningStandBubbleTypeBase;
			curPlayingType = this.CurPlayingType;
			ETuningStandBubbleTriggerType etuningStandBubbleTriggerType = ETuningStandBubbleTriggerType.Enter;
			if (tuningStandBubbleTypeBase2.TryStartBubble(!(curPlayingType.GetValueOrDefault() == etuningStandBubbleTriggerType & curPlayingType != null)))
			{
				if (this.CurPlayingType != null)
				{
					TuningStandBubbleTypeBase tuningStandBubbleTypeBase3 = this.BubbleClassMap[this.CurPlayingType.Value];
					if (tuningStandBubbleTypeBase3 != null)
					{
						tuningStandBubbleTypeBase3.Interrupted();
					}
				}
				this.CurPlayingType = new ETuningStandBubbleTriggerType?(type);
				return true;
			}
			return false;
		}

		// Token: 0x06043756 RID: 276310 RVA: 0x01161381 File Offset: 0x0115F581
		private void OnBubbleEnd(ETuningStandBubbleTriggerType _)
		{
			this.CurPlayingType = null;
		}

		// Token: 0x06043757 RID: 276311 RVA: 0x01161390 File Offset: 0x0115F590
		public void Destroy()
		{
			foreach (KeyValuePair<ETuningStandBubbleTriggerType, TuningStandBubbleTypeBase> keyValuePair in this.BubbleClassMap)
			{
				keyValuePair.Value.Destroy();
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.TuningStandBubbleEnd, new Action<ETuningStandBubbleTriggerType>(this.OnBubbleEnd));
			this.BubbleClassMap.Clear();
		}

		// Token: 0x04025ACA RID: 154314
		private readonly Dictionary<ETuningStandBubbleTriggerType, TuningStandBubbleTypeBase> BubbleClassMap = new Dictionary<ETuningStandBubbleTriggerType, TuningStandBubbleTypeBase>();

		// Token: 0x04025ACB RID: 154315
		private ETuningStandBubbleTriggerType? CurPlayingType;
	}
}
