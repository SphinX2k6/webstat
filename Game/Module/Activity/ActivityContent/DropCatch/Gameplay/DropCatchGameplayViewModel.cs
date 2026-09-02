using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay
{
	// Token: 0x020068F6 RID: 26870
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayViewModel
	{
		// Token: 0x06042C45 RID: 273477 RVA: 0x01122AD8 File Offset: 0x01120CD8
		public int GetCurGameplayId()
		{
			return this.CurGameplayId;
		}

		// Token: 0x06042C46 RID: 273478 RVA: 0x01122AE0 File Offset: 0x01120CE0
		public void SetCurGameplayId(int gameplayId)
		{
			this.CurGameplayId = gameplayId;
			this.ScoreLevels.Clear();
			DropCatchGameplay? dropCatchGameplayById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayById(gameplayId);
			if (dropCatchGameplayById == null)
			{
				return;
			}
			foreach (int id in dropCatchGameplayById.Value.RewardIds())
			{
				DropCatchReward? dropCatchReward;
				this.ScoreLevels.Add((float)((ConfigBase<DropCatchConfig>.Instance.GetDropCatchRewardById(id) != null) ? dropCatchReward.GetValueOrDefault().Score : 0));
			}
		}

		// Token: 0x06042C47 RID: 273479 RVA: 0x01122B6E File Offset: 0x01120D6E
		public void AddScore(float score)
		{
			this.CurScore += score;
		}

		// Token: 0x06042C48 RID: 273480 RVA: 0x01122B7E File Offset: 0x01120D7E
		public float GetCurScore()
		{
			return this.CurScore;
		}

		// Token: 0x06042C49 RID: 273481 RVA: 0x01122B86 File Offset: 0x01120D86
		public Dictionary<int, int> GetDropItemRecord()
		{
			return this.DropItemRecord;
		}

		// Token: 0x06042C4A RID: 273482 RVA: 0x01122B90 File Offset: 0x01120D90
		public void AddDropItemRecord(int itemId)
		{
			int num;
			this.DropItemRecord.TryGetValue(itemId, out num);
			num++;
			if (this.DropItemRecord.ContainsKey(itemId))
			{
				this.DropItemRecord[itemId] = num;
				return;
			}
			this.DropItemRecord.Add(itemId, num);
		}

		// Token: 0x06042C4B RID: 273483 RVA: 0x01122BD9 File Offset: 0x01120DD9
		public List<float> GetScoreLevels()
		{
			return this.ScoreLevels;
		}

		// Token: 0x06042C4C RID: 273484 RVA: 0x01122BE1 File Offset: 0x01120DE1
		public string GetGameplayTimeStamp()
		{
			return this.GameplayTimeStamp;
		}

		// Token: 0x06042C4D RID: 273485 RVA: 0x01122BE9 File Offset: 0x01120DE9
		public void SetGameplayTimeStamp(string timestamp)
		{
			this.GameplayTimeStamp = timestamp;
		}

		// Token: 0x06042C4E RID: 273486 RVA: 0x01122BF2 File Offset: 0x01120DF2
		public void AddSkillTimes()
		{
			this.SkillTimes += 1f;
		}

		// Token: 0x06042C4F RID: 273487 RVA: 0x01122C06 File Offset: 0x01120E06
		public float GetSkillTimes()
		{
			return this.SkillTimes;
		}

		// Token: 0x06042C50 RID: 273488 RVA: 0x01122C0E File Offset: 0x01120E0E
		public void AddAddTime(float time)
		{
			this.AddTime += time;
		}

		// Token: 0x06042C51 RID: 273489 RVA: 0x01122C1E File Offset: 0x01120E1E
		public float GetAddTime()
		{
			return this.AddTime;
		}

		// Token: 0x06042C52 RID: 273490 RVA: 0x01122C26 File Offset: 0x01120E26
		public void Reset()
		{
			this.CurScore = 0f;
			this.DropItemRecord.Clear();
			this.GameplayTimeStamp = "";
			this.SkillTimes = 0f;
			this.AddTime = 0f;
		}

		// Token: 0x04025327 RID: 152359
		private int CurGameplayId;

		// Token: 0x04025328 RID: 152360
		private float CurScore;

		// Token: 0x04025329 RID: 152361
		private readonly Dictionary<int, int> DropItemRecord = new Dictionary<int, int>();

		// Token: 0x0402532A RID: 152362
		private readonly List<float> ScoreLevels = new List<float>();

		// Token: 0x0402532B RID: 152363
		private string GameplayTimeStamp = "";

		// Token: 0x0402532C RID: 152364
		private float SkillTimes;

		// Token: 0x0402532D RID: 152365
		private float AddTime;
	}
}
