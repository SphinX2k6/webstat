using System;
using Aki.Config;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D26 RID: 23846
	public class FlagChallengeBuffData
	{
		// Token: 0x17009884 RID: 39044
		// (get) Token: 0x0603C22C RID: 246316 RVA: 0x00F40702 File Offset: 0x00F3E902
		// (set) Token: 0x0603C22D RID: 246317 RVA: 0x00F4070A File Offset: 0x00F3E90A
		public bool IsSelected
		{
			get
			{
				return this.IsSelectedIntl;
			}
			set
			{
				this.IsSelectedIntl = value;
			}
		}

		// Token: 0x0603C22E RID: 246318 RVA: 0x00F40714 File Offset: 0x00F3E914
		public FlagChallengeBuffData(int id)
		{
			this.Id = id;
			this.Config = ConfigBase<FlagChallengeConfig>.Instance.GetRoleBuffConfig(id).Value;
			this.EndLevel = this.Config.Level;
		}

		// Token: 0x0603C22F RID: 246319 RVA: 0x00F40758 File Offset: 0x00F3E958
		public EFlagChallengeBuffStatus GetBuffStatus()
		{
			int activityId = this.Config.ActivityId;
			int level = this.Config.Level;
			int calculatedLevel = ModelBase<FlagChallengeModel>.Instance.GetCalculatedLevel(activityId);
			if (calculatedLevel >= level)
			{
				return EFlagChallengeBuffStatus.Active;
			}
			int tempLevel = ModelBase<FlagChallengeModel>.Instance.GetTempLevel(activityId);
			if (calculatedLevel + tempLevel >= level)
			{
				return EFlagChallengeBuffStatus.TempActive;
			}
			return EFlagChallengeBuffStatus.NotActive;
		}

		// Token: 0x0603C230 RID: 246320 RVA: 0x00F407AC File Offset: 0x00F3E9AC
		public bool IsNotActive()
		{
			return this.GetBuffStatus() == EFlagChallengeBuffStatus.NotActive;
		}

		// Token: 0x0603C231 RID: 246321 RVA: 0x00F407B7 File Offset: 0x00F3E9B7
		public bool IsActive()
		{
			return this.GetBuffStatus() == EFlagChallengeBuffStatus.Active;
		}

		// Token: 0x0603C232 RID: 246322 RVA: 0x00F407C2 File Offset: 0x00F3E9C2
		public bool IsTempActive()
		{
			return this.GetBuffStatus() == EFlagChallengeBuffStatus.TempActive;
		}

		// Token: 0x0603C233 RID: 246323 RVA: 0x00F407CD File Offset: 0x00F3E9CD
		public bool IsActiveOrTempActive()
		{
			return this.IsActive() || this.IsTempActive();
		}

		// Token: 0x0603C234 RID: 246324 RVA: 0x00F407DF File Offset: 0x00F3E9DF
		public void SetStartLevel(int level)
		{
			this.StartLevel = level;
		}

		// Token: 0x0603C235 RID: 246325 RVA: 0x00F407E8 File Offset: 0x00F3E9E8
		public int GetStartLevel()
		{
			return this.StartLevel;
		}

		// Token: 0x0603C236 RID: 246326 RVA: 0x00F407F0 File Offset: 0x00F3E9F0
		public int GetEndLevel()
		{
			return this.EndLevel;
		}

		// Token: 0x0603C237 RID: 246327 RVA: 0x00F407F8 File Offset: 0x00F3E9F8
		public void SetIndex(int index)
		{
			this.Index = index;
		}

		// Token: 0x0603C238 RID: 246328 RVA: 0x00F40801 File Offset: 0x00F3EA01
		public int GetIndex()
		{
			return this.Index;
		}

		// Token: 0x04021C0B RID: 138251
		public readonly int Id;

		// Token: 0x04021C0C RID: 138252
		public readonly FlagChallengeRoleBuff Config;

		// Token: 0x04021C0D RID: 138253
		private int StartLevel;

		// Token: 0x04021C0E RID: 138254
		private int EndLevel;

		// Token: 0x04021C0F RID: 138255
		private int Index;

		// Token: 0x04021C10 RID: 138256
		private bool IsSelectedIntl;
	}
}
