using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F45 RID: 24389
	[NullableContext(1)]
	[Nullable(0)]
	public class GroupSkillCdInfo
	{
		// Token: 0x17009A33 RID: 39475
		// (get) Token: 0x0603D454 RID: 250964 RVA: 0x00F94F12 File Offset: 0x00F93112
		public float CurRemainingCd
		{
			get
			{
				if (this.SkillCdFinishStamp != 0.0)
				{
					return (float)((this.SkillCdFinishStamp - Singleton<Time>.Instance.FlowTime) * Singleton<TimeUtil>.Instance.Millisecond);
				}
				return 0f;
			}
		}

		// Token: 0x0603D455 RID: 250965 RVA: 0x00F94F48 File Offset: 0x00F93148
		public bool IsInCd()
		{
			return this.RemainingCount < this.LimitCount;
		}

		// Token: 0x0603D456 RID: 250966 RVA: 0x00F94F58 File Offset: 0x00F93158
		public bool HasRemainingCount()
		{
			return this.RemainingCount > 0;
		}

		// Token: 0x0603D457 RID: 250967 RVA: 0x00F94F63 File Offset: 0x00F93163
		public bool IsInDelay()
		{
			return this.IsInDelayInner;
		}

		// Token: 0x0603D458 RID: 250968 RVA: 0x00F94F6C File Offset: 0x00F9316C
		public bool StartCd(int skillId, float cdProportion, [Nullable(2)] EntityHandle handle, CharacterSkillCdComponent cdComp, int skillGenre)
		{
			this.EntityHandle = handle;
			SkillCdInfo skillCdInfo;
			if (!this.SkillCdInfoMap.TryGetValue(skillId, out skillCdInfo))
			{
				return false;
			}
			if (this.RemainingCount <= 0)
			{
				return false;
			}
			float num = cdComp.CalcExtraEffectCd(skillCdInfo.SkillCd, skillId, skillGenre) * cdProportion;
			if (this.IsInDelay())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "技能CD延迟期间，不能再用一次技能，必须先打断前一次技能";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillId", skillId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			float cdDelay = skillCdInfo.CdDelay;
			if (cdDelay > 0f)
			{
				this.CurDelaySkillId = skillId;
				this.CurDelaySkillCd = num;
				this.IsInDelayInner = true;
				float interval = Math.Max(20f, cdDelay * (float)Singleton<TimeUtil>.Instance.InverseMillisecond);
				this.SkillDelayTimer = TimerSystem.FlowTimeInstance.Delay(new TTimerAction(this.OnDelayFinish), interval, null, null, true, 1f);
				return true;
			}
			if (num <= 0f)
			{
				return true;
			}
			if (!this.IsInCd())
			{
				this.StartSkillCdTimer(skillId, num);
			}
			else
			{
				this.CdQueue.Push(num);
				this.SkillIdQueue.Push(skillId);
			}
			this.RemainingCount--;
			this.OnCountChanged();
			return true;
		}

		// Token: 0x0603D459 RID: 250969 RVA: 0x00F95094 File Offset: 0x00F93294
		private void OnDelayFinish(float delta)
		{
			this.SkillDelayTimer = null;
			this.IsInDelayInner = false;
			if (this.RemainingCount <= 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.ZFJ, "技能CD延迟计时结束时，可用次数为0，不能进入CD", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int curDelaySkillId = this.CurDelaySkillId;
			float curDelaySkillCd = this.CurDelaySkillCd;
			if (!this.IsInCd())
			{
				this.RemainingCount--;
				this.OnCountChanged();
				this.StartSkillCdTimer(curDelaySkillId, curDelaySkillCd);
				return;
			}
			this.CdQueue.Push(curDelaySkillCd);
			this.SkillIdQueue.Push(curDelaySkillId);
			this.RemainingCount--;
			this.OnCountChanged();
		}

		// Token: 0x0603D45A RID: 250970 RVA: 0x00F95134 File Offset: 0x00F93334
		private void OnSkillCdFinish(float delta)
		{
			double skillCdFinishStamp = this.SkillCdFinishStamp;
			this.SkillCdTimer = null;
			this.SkillCdFinishStamp = 0.0;
			this.RemainingCount++;
			float num = (float)(Math.Max(0.0, Singleton<Time>.Instance.FlowTime - skillCdFinishStamp) * Singleton<TimeUtil>.Instance.Millisecond);
			ValueTuple<int?, float?> nextSkill = this.GetNextSkill();
			int? item = nextSkill.Item1;
			float? item2 = nextSkill.Item2;
			while (item2 != null && num >= item2.Value)
			{
				this.RemainingCount++;
				num -= item2.Value;
				ValueTuple<int?, float?> nextSkill2 = this.GetNextSkill();
				item = nextSkill2.Item1;
				item2 = nextSkill2.Item2;
			}
			if (this.RemainingCount > this.LimitCount)
			{
				this.RemainingCount = this.LimitCount;
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "技能CD结束，可用次数已达上限", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.OnCountChanged();
			if (item == null || item2 == null)
			{
				return;
			}
			this.StartSkillCdTimer(item.Value, item2.Value - num);
		}

		// Token: 0x0603D45B RID: 250971 RVA: 0x00F9524C File Offset: 0x00F9344C
		[NullableContext(0)]
		private ValueTuple<int?, float?> GetNextSkill()
		{
			if (this.SkillIdQueue.Size <= 0 || this.CdQueue.Size <= 0)
			{
				return new ValueTuple<int?, float?>(null, null);
			}
			return new ValueTuple<int?, float?>(new int?(this.SkillIdQueue.Pop()), new float?(this.CdQueue.Pop()));
		}

		// Token: 0x0603D45C RID: 250972 RVA: 0x00F952B2 File Offset: 0x00F934B2
		private void AheadFinishSkillDelay()
		{
			if (this.SkillDelayTimer != null)
			{
				TimerSystem.FlowTimeInstance.Remove(this.SkillDelayTimer);
				this.IsInDelayInner = false;
				this.SkillDelayTimer = null;
			}
		}

		// Token: 0x0603D45D RID: 250973 RVA: 0x00F952DB File Offset: 0x00F934DB
		private void AheadFinishSkillCd()
		{
			if (this.SkillCdTimer != null)
			{
				TimerSystem.FlowTimeInstance.Remove(this.SkillCdTimer);
				this.OnSkillCdFinish(0f);
			}
		}

		// Token: 0x0603D45E RID: 250974 RVA: 0x00F95304 File Offset: 0x00F93504
		private void ChangeSkillCd(float newCd)
		{
			this.SkillCdFinishStamp = ((newCd <= 0f) ? Singleton<Time>.Instance.FlowTime : (Singleton<Time>.Instance.FlowTime + (double)(newCd * (float)Singleton<TimeUtil>.Instance.InverseMillisecond)));
			if (this.SkillCdTimer != null)
			{
				TimerSystem.FlowTimeInstance.Remove(this.SkillCdTimer);
				float interval = Math.Max(20f, newCd * (float)Singleton<TimeUtil>.Instance.InverseMillisecond);
				this.SkillCdTimer = TimerSystem.FlowTimeInstance.Delay(new TTimerAction(this.OnSkillCdFinish), interval, null, null, true, 1f);
			}
		}

		// Token: 0x0603D45F RID: 250975 RVA: 0x00F9539C File Offset: 0x00F9359C
		public void StartSkillCdTimer(int skillId, float cdSecond)
		{
			this.CurMaxCd = cdSecond;
			this.CurSkillId = (long)skillId;
			float num = cdSecond * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			float interval = Math.Max(20f, num);
			this.SkillCdTimer = TimerSystem.FlowTimeInstance.Delay(new TTimerAction(this.OnSkillCdFinish), interval, null, null, true, 1f);
			this.SkillCdFinishStamp = Singleton<Time>.Instance.FlowTime + (double)num;
		}

		// Token: 0x0603D460 RID: 250976 RVA: 0x00F9540C File Offset: 0x00F9360C
		public void SetLimitCount(int? count = null)
		{
			this.LimitCountModify = (count ?? this.ConfigMaxCount);
			this.LimitCount = this.LimitCountModify + this.LimitCountAdd;
			this.ResetAllCd();
		}

		// Token: 0x0603D461 RID: 250977 RVA: 0x00F95454 File Offset: 0x00F93654
		public void AddLimitCount(int count)
		{
			if (count == 0)
			{
				return;
			}
			this.LimitCountAdd += count;
			if (this.LimitCountAdd < 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "技能次数叠加不能小于0", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.LimitCountAdd = 0;
			}
			int num = this.LimitCount - this.RemainingCount;
			this.LimitCount = this.LimitCountModify + this.LimitCountAdd;
			this.RemainingCount = this.LimitCount - num;
			if (count < 0 && this.RemainingCount < 0)
			{
				for (int i = 0; i > this.RemainingCount; i--)
				{
					if (this.CdQueue.Size > 0)
					{
						this.CdQueue.Pop();
					}
					if (this.SkillIdQueue.Size > 0)
					{
						this.SkillIdQueue.Pop();
					}
				}
				this.RemainingCount = 0;
			}
			this.OnCountChanged();
		}

		// Token: 0x0603D462 RID: 250978 RVA: 0x00F95530 File Offset: 0x00F93730
		public void ResetAllCd()
		{
			this.CdQueue.Clear();
			this.SkillIdQueue.Clear();
			this.AheadFinishSkillDelay();
			if (this.SkillCdTimer != null)
			{
				TimerSystem.FlowTimeInstance.Remove(this.SkillCdTimer);
				this.SkillCdTimer = null;
				this.SkillCdFinishStamp = 0.0;
			}
			this.RemainingCount = this.LimitCount;
			this.OnCountChanged();
		}

		// Token: 0x0603D463 RID: 250979 RVA: 0x00F9559A File Offset: 0x00F9379A
		public bool ResetDelayCd()
		{
			if (this.SkillDelayTimer == null)
			{
				return false;
			}
			this.AheadFinishSkillDelay();
			return true;
		}

		// Token: 0x0603D464 RID: 250980 RVA: 0x00F955B0 File Offset: 0x00F937B0
		public void ModifyRemainingCd(float modifyTime, float changeTimePercentage)
		{
			if (!this.IsInCd())
			{
				return;
			}
			float num = this.CurRemainingCd + modifyTime + this.CurMaxCd * changeTimePercentage;
			if (num <= 0f)
			{
				this.AheadFinishSkillCd();
				return;
			}
			this.ChangeSkillCd(num);
			Singleton<EventSystem>.Instance.Emit<GroupSkillCdInfo>(EEventName.CharSkillRemainCdChanged, this);
		}

		// Token: 0x0603D465 RID: 250981 RVA: 0x00F955FC File Offset: 0x00F937FC
		public void OnCountChanged()
		{
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle != null && entityHandle.Valid)
			{
				CharacterBuffComponent component = this.EntityHandle.Entity.GetComponent<CharacterBuffComponent>();
				if (this.RemainingCount <= 0)
				{
					int item = component.AddTagWithReturnHandle(this.CdTags, -1f);
					this.CdTagsHandles.Add(item);
				}
				else
				{
					foreach (int handle in this.CdTagsHandles)
					{
						component.RemoveBuffByHandle(handle, -1, "技能CD结束移除", null, null, null);
					}
					this.CdTagsHandles.Clear();
				}
			}
			this.DispatchCountChangedEvent();
		}

		// Token: 0x0603D466 RID: 250982 RVA: 0x00F956D8 File Offset: 0x00F938D8
		[NullableContext(2)]
		public void InitCdTags(EntityHandle handle)
		{
			this.EntityHandle = handle;
			if (this.RemainingCount > 0 || this.CdTagsHandles.Count > 0)
			{
				return;
			}
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle != null && entityHandle.Valid)
			{
				int item = this.EntityHandle.Entity.GetComponent<CharacterBuffComponent>().AddTagWithReturnHandle(this.CdTags, -1f);
				this.CdTagsHandles.Add(item);
			}
		}

		// Token: 0x0603D467 RID: 250983 RVA: 0x00F95748 File Offset: 0x00F93948
		public void ClearCdTags(int entityId)
		{
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle == null || entityHandle.Id != entityId)
			{
				return;
			}
			EntityHandle entityHandle2 = this.EntityHandle;
			if (entityHandle2 != null && entityHandle2.Valid)
			{
				CharacterBuffComponent component = this.EntityHandle.Entity.GetComponent<CharacterBuffComponent>();
				foreach (int handle in this.CdTagsHandles)
				{
					component.RemoveBuffByHandle(handle, -1, "实体清理时移除技能CDTag", null, null, null);
				}
			}
			this.EntityHandle = null;
			this.CdTagsHandles.Clear();
		}

		// Token: 0x0603D468 RID: 250984 RVA: 0x00F95810 File Offset: 0x00F93A10
		public void ClearLimitCountChange()
		{
			if (this.ConfigMaxCount != this.LimitCount)
			{
				this.SetLimitCount(new int?(this.ConfigMaxCount));
			}
		}

		// Token: 0x0603D469 RID: 250985 RVA: 0x00F95831 File Offset: 0x00F93A31
		private void DispatchCountChangedEvent()
		{
			Singleton<EventSystem>.Instance.Emit<GroupSkillCdInfo>(EEventName.CharSkillCountChanged, this);
		}

		// Token: 0x0603D46A RID: 250986 RVA: 0x00F95841 File Offset: 0x00F93A41
		public void CheckConfigValid()
		{
		}

		// Token: 0x040225DB RID: 140763
		public int GroupId;

		// Token: 0x040225DC RID: 140764
		public int ConfigMaxCount;

		// Token: 0x040225DD RID: 140765
		public int LimitCountModify;

		// Token: 0x040225DE RID: 140766
		public int LimitCountAdd;

		// Token: 0x040225DF RID: 140767
		public int LimitCount;

		// Token: 0x040225E0 RID: 140768
		public int RemainingCount;

		// Token: 0x040225E1 RID: 140769
		public readonly Dictionary<int, SkillCdInfo> SkillCdInfoMap = new Dictionary<int, SkillCdInfo>();

		// Token: 0x040225E2 RID: 140770
		public readonly HashSet<int> EntityIds = new HashSet<int>();

		// Token: 0x040225E3 RID: 140771
		public readonly Queue<int> SkillIdQueue = new Queue<int>(4);

		// Token: 0x040225E4 RID: 140772
		public readonly Queue<float> CdQueue = new Queue<float>(4);

		// Token: 0x040225E5 RID: 140773
		public float CurMaxCd;

		// Token: 0x040225E6 RID: 140774
		public double SkillCdFinishStamp;

		// Token: 0x040225E7 RID: 140775
		public long CurSkillId;

		// Token: 0x040225E8 RID: 140776
		[Nullable(2)]
		private TimerHandle SkillDelayTimer;

		// Token: 0x040225E9 RID: 140777
		[Nullable(2)]
		private TimerHandle SkillCdTimer;

		// Token: 0x040225EA RID: 140778
		public int CurDelaySkillId;

		// Token: 0x040225EB RID: 140779
		public float CurDelaySkillCd;

		// Token: 0x040225EC RID: 140780
		[Nullable(2)]
		private EntityHandle EntityHandle;

		// Token: 0x040225ED RID: 140781
		public readonly List<int> CdTags = new List<int>();

		// Token: 0x040225EE RID: 140782
		private readonly List<int> CdTagsHandles = new List<int>();

		// Token: 0x040225EF RID: 140783
		private bool IsInDelayInner;
	}
}
