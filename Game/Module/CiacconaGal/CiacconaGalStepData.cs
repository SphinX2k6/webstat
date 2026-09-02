using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Plot;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EB8 RID: 24248
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalStepData
	{
		// Token: 0x0603CF21 RID: 249633 RVA: 0x00F7AB35 File Offset: 0x00F78D35
		public CiacconaGalStepData(CiacconaGalStep Config)
		{
			this.Config = Config;
		}

		// Token: 0x170099C4 RID: 39364
		// (get) Token: 0x0603CF22 RID: 249634 RVA: 0x00F7AB44 File Offset: 0x00F78D44
		private CiacconaGalStep Config { get; }

		// Token: 0x170099C5 RID: 39365
		// (get) Token: 0x0603CF23 RID: 249635 RVA: 0x00F7AB4C File Offset: 0x00F78D4C
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x170099C6 RID: 39366
		// (get) Token: 0x0603CF24 RID: 249636 RVA: 0x00F7AB68 File Offset: 0x00F78D68
		public ECiacconaGalStepType Type
		{
			get
			{
				return (ECiacconaGalStepType)this.Config.Type;
			}
		}

		// Token: 0x170099C7 RID: 39367
		// (get) Token: 0x0603CF25 RID: 249637 RVA: 0x00F7AB84 File Offset: 0x00F78D84
		public string TalkTid
		{
			get
			{
				return this.Config.Content;
			}
		}

		// Token: 0x170099C8 RID: 39368
		// (get) Token: 0x0603CF26 RID: 249638 RVA: 0x00F7ABA0 File Offset: 0x00F78DA0
		public string Content
		{
			get
			{
				if (StringUtils.IsEmpty(this.Config.Content))
				{
					return string.Empty;
				}
				string flowConfigLocalText = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(this.Config.Content);
				return ModelBase<PlotModel>.Instance.PlotTextReplacer.Replace(flowConfigLocalText, false);
			}
		}

		// Token: 0x170099C9 RID: 39369
		// (get) Token: 0x0603CF27 RID: 249639 RVA: 0x00F7ABF4 File Offset: 0x00F78DF4
		public string ImagePath
		{
			get
			{
				if (string.IsNullOrEmpty(this.Config.ImageMale))
				{
					return this.Config.ImageFemale;
				}
				if (string.IsNullOrEmpty(this.Config.ImageFemale))
				{
					return this.Config.ImageMale;
				}
				EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
				if (playerGender == EPlayerGender.Male)
				{
					return this.Config.ImageMale;
				}
				if (playerGender == EPlayerGender.Female)
				{
					return this.Config.ImageFemale;
				}
				return string.Empty;
			}
		}

		// Token: 0x170099CA RID: 39370
		// (get) Token: 0x0603CF28 RID: 249640 RVA: 0x00F7AC80 File Offset: 0x00F78E80
		public string AudioEvent
		{
			get
			{
				return this.Config.Audio;
			}
		}

		// Token: 0x170099CB RID: 39371
		// (get) Token: 0x0603CF29 RID: 249641 RVA: 0x00F7AC9C File Offset: 0x00F78E9C
		public string MusicState
		{
			get
			{
				return this.Config.MusicState;
			}
		}

		// Token: 0x170099CC RID: 39372
		// (get) Token: 0x0603CF2A RID: 249642 RVA: 0x00F7ACB8 File Offset: 0x00F78EB8
		public string AnimPath
		{
			get
			{
				return this.Config.Anim;
			}
		}

		// Token: 0x170099CD RID: 39373
		// (get) Token: 0x0603CF2B RID: 249643 RVA: 0x00F7ACD4 File Offset: 0x00F78ED4
		public int TriggerSubEndingId
		{
			get
			{
				return this.Config.TriggerSubEnding;
			}
		}

		// Token: 0x170099CE RID: 39374
		// (get) Token: 0x0603CF2C RID: 249644 RVA: 0x00F7ACF0 File Offset: 0x00F78EF0
		public int[] ChoiceIds
		{
			get
			{
				return this.Config.Choices();
			}
		}

		// Token: 0x170099CF RID: 39375
		// (get) Token: 0x0603CF2D RID: 249645 RVA: 0x00F7AD0C File Offset: 0x00F78F0C
		public int NextStepId
		{
			get
			{
				return this.Config.Id + 1;
			}
		}

		// Token: 0x170099D0 RID: 39376
		// (get) Token: 0x0603CF2E RID: 249646 RVA: 0x00F7AD2C File Offset: 0x00F78F2C
		public int SubEndingId
		{
			get
			{
				return this.Config.TriggerSubEnding;
			}
		}

		// Token: 0x170099D1 RID: 39377
		// (get) Token: 0x0603CF2F RID: 249647 RVA: 0x00F7AD47 File Offset: 0x00F78F47
		public int TextAnimDefaultDuration
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x170099D2 RID: 39378
		// (get) Token: 0x0603CF30 RID: 249648 RVA: 0x00F7AD4A File Offset: 0x00F78F4A
		// (set) Token: 0x0603CF31 RID: 249649 RVA: 0x00F7AD52 File Offset: 0x00F78F52
		public int ChosenId
		{
			get
			{
				return this.ChosenIdCache;
			}
			set
			{
				this.ChosenIdCache = value;
			}
		}

		// Token: 0x170099D3 RID: 39379
		// (get) Token: 0x0603CF32 RID: 249650 RVA: 0x00F7AD5C File Offset: 0x00F78F5C
		public bool HasText
		{
			get
			{
				return !string.IsNullOrEmpty(this.Config.Content);
			}
		}

		// Token: 0x0402236A RID: 140138
		private int ChosenIdCache;
	}
}
