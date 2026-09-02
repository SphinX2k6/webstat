using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EB9 RID: 24249
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalSubEndingData
	{
		// Token: 0x0603CF33 RID: 249651 RVA: 0x00F7AD7F File Offset: 0x00F78F7F
		public CiacconaGalSubEndingData(CiacconaGalSubEnding config)
		{
			this.Config = config;
		}

		// Token: 0x170099D4 RID: 39380
		// (get) Token: 0x0603CF34 RID: 249652 RVA: 0x00F7AD90 File Offset: 0x00F78F90
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x170099D5 RID: 39381
		// (get) Token: 0x0603CF35 RID: 249653 RVA: 0x00F7ADAC File Offset: 0x00F78FAC
		public string Title
		{
			get
			{
				return this.Config.Title;
			}
		}

		// Token: 0x170099D6 RID: 39382
		// (get) Token: 0x0603CF36 RID: 249654 RVA: 0x00F7ADC8 File Offset: 0x00F78FC8
		public string Desc
		{
			get
			{
				return this.Config.Desc;
			}
		}

		// Token: 0x170099D7 RID: 39383
		// (get) Token: 0x0603CF37 RID: 249655 RVA: 0x00F7ADE4 File Offset: 0x00F78FE4
		public string ImagePath
		{
			get
			{
				return this.Config.BackgroundImage;
			}
		}

		// Token: 0x170099D8 RID: 39384
		// (get) Token: 0x0603CF38 RID: 249656 RVA: 0x00F7AE00 File Offset: 0x00F79000
		public ECiacconaGalSubEndingType Type
		{
			get
			{
				return (ECiacconaGalSubEndingType)this.Config.Type;
			}
		}

		// Token: 0x170099D9 RID: 39385
		// (get) Token: 0x0603CF39 RID: 249657 RVA: 0x00F7AE1C File Offset: 0x00F7901C
		public int RewardId
		{
			get
			{
				return this.Config.Reward;
			}
		}

		// Token: 0x170099DA RID: 39386
		// (get) Token: 0x0603CF3A RID: 249658 RVA: 0x00F7AE37 File Offset: 0x00F79037
		public bool IsFinished
		{
			get
			{
				return this.IsFinishedInternal;
			}
		}

		// Token: 0x170099DB RID: 39387
		// (get) Token: 0x0603CF3B RID: 249659 RVA: 0x00F7AE3F File Offset: 0x00F7903F
		public bool IsRewarded
		{
			get
			{
				return this.IsRewardedInternal;
			}
		}

		// Token: 0x170099DC RID: 39388
		// (get) Token: 0x0603CF3C RID: 249660 RVA: 0x00F7AE48 File Offset: 0x00F79048
		public bool ShouldExitOnFirstFinish
		{
			get
			{
				return this.Config.ExitOnFinish;
			}
		}

		// Token: 0x170099DD RID: 39389
		// (get) Token: 0x0603CF3D RID: 249661 RVA: 0x00F7AE63 File Offset: 0x00F79063
		public bool IsFaked
		{
			get
			{
				return this.IsFakedInternal;
			}
		}

		// Token: 0x0603CF3E RID: 249662 RVA: 0x00F7AE6B File Offset: 0x00F7906B
		public void UpdateByServerData(CiacconaChapterResultPbData data)
		{
			this.IsFinishedInternal = data.Finish;
			this.IsRewardedInternal = data.TakeReward;
			this.IsFakedInternal = false;
		}

		// Token: 0x0603CF3F RID: 249663 RVA: 0x00F7AE8C File Offset: 0x00F7908C
		public void ClientSetFinished(bool isFinished)
		{
			if (this.IsFinishedInternal == isFinished)
			{
				return;
			}
			this.IsFinishedInternal = isFinished;
			this.IsFakedInternal = true;
		}

		// Token: 0x0402236C RID: 140140
		private bool IsFinishedInternal;

		// Token: 0x0402236D RID: 140141
		private bool IsRewardedInternal;

		// Token: 0x0402236E RID: 140142
		private bool IsFakedInternal;

		// Token: 0x0402236F RID: 140143
		private readonly CiacconaGalSubEnding Config;
	}
}
