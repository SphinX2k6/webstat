using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F48 RID: 24392
	[NullableContext(1)]
	[Nullable(0)]
	public class PassiveSkillCdInfo
	{
		// Token: 0x0603D475 RID: 250997 RVA: 0x00F95DE4 File Offset: 0x00F93FE4
		public double GetCurRemainingCd(int entityId)
		{
			double valueOrDefault = this.SkillCdFinishStampMap.GetValueOrDefault(entityId, 0.0);
			if (valueOrDefault != 0.0)
			{
				return (valueOrDefault - Singleton<Time>.Instance.FlowTime) * Singleton<TimeUtil>.Instance.Millisecond;
			}
			return 0.0;
		}

		// Token: 0x0603D476 RID: 250998 RVA: 0x00F95E34 File Offset: 0x00F94034
		public bool IsInCd(int entityId)
		{
			return this.GetCurRemainingCd(entityId) > (double)Math.Max(this.Threshold, 0f);
		}

		// Token: 0x0603D477 RID: 250999 RVA: 0x00F95E50 File Offset: 0x00F94050
		private unsafe void RemoveInvalidCd()
		{
			List<int> list = new List<int>();
			foreach (int num in this.SkillCdFinishStampMap.Keys)
			{
				if (this.IsInCd(num))
				{
					break;
				}
				list.Add(num);
			}
			foreach (int key in list)
			{
				this.SkillCdFinishStampMap.Remove(key);
			}
			if (this.SkillCdFinishStampMap.Count >= 20)
			{
				int? num2 = null;
				if (this.EntityIds.Count > 0)
				{
					HashSet<int>.Enumerator enumerator3 = this.EntityIds.GetEnumerator();
					if (enumerator3.MoveNext())
					{
						num2 = new int?(enumerator3.Current);
					}
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.TZQ;
				string message = "被动技能CD数量超上限,移除最先的entityCD";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("skillId", this.SkillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("firstEntityId", num2);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				if (num2 != null)
				{
					this.SkillCdFinishStampMap.Remove(num2.Value);
				}
			}
		}

		// Token: 0x0603D478 RID: 251000 RVA: 0x00F95FCC File Offset: 0x00F941CC
		public bool StartCd(long skillId, int entityId, float cdTime = -1f)
		{
			if (this.IsInCd(entityId))
			{
				return false;
			}
			float num = cdTime;
			if (num == -1f)
			{
				num = this.SkillCd;
			}
			if (num <= 0f)
			{
				return true;
			}
			this.CurMaxCd = num;
			double valueOrDefault = this.SkillCdFinishStampMap.GetValueOrDefault(entityId, 0.0);
			double value = ((Singleton<Time>.Instance.FlowTime > valueOrDefault) ? Singleton<Time>.Instance.FlowTime : valueOrDefault) + (double)(num * (float)Singleton<TimeUtil>.Instance.InverseMillisecond);
			this.RemoveInvalidCd();
			this.SkillCdFinishStampMap.Remove(entityId);
			this.SkillCdFinishStampMap.Add(entityId, value);
			return true;
		}

		// Token: 0x0603D479 RID: 251001 RVA: 0x00F96067 File Offset: 0x00F94267
		public void ResetAllCd()
		{
			this.SkillCdFinishStampMap.Clear();
		}

		// Token: 0x040225F5 RID: 140789
		private const int MAX_CD_COUNT = 20;

		// Token: 0x040225F6 RID: 140790
		public long SkillId;

		// Token: 0x040225F7 RID: 140791
		public float SkillCd;

		// Token: 0x040225F8 RID: 140792
		public float Threshold;

		// Token: 0x040225F9 RID: 140793
		public bool IsShareAllCdSkill;

		// Token: 0x040225FA RID: 140794
		public readonly HashSet<int> EntityIds = new HashSet<int>();

		// Token: 0x040225FB RID: 140795
		public float CurMaxCd;

		// Token: 0x040225FC RID: 140796
		public readonly OrderedDictionary<int, double> SkillCdFinishStampMap = new OrderedDictionary<int, double>();
	}
}
