using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EB6 RID: 24246
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalEndingData
	{
		// Token: 0x0603CF0C RID: 249612 RVA: 0x00F7A8AC File Offset: 0x00F78AAC
		public CiacconaGalEndingData(CiacconaGalEnding config)
		{
			this.Config = config;
			this.IsFinishedInternal = false;
			this.IsRewardedInternal = false;
		}

		// Token: 0x170099B3 RID: 39347
		// (get) Token: 0x0603CF0D RID: 249613 RVA: 0x00F7A8CC File Offset: 0x00F78ACC
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x170099B4 RID: 39348
		// (get) Token: 0x0603CF0E RID: 249614 RVA: 0x00F7A8E8 File Offset: 0x00F78AE8
		public string Title
		{
			get
			{
				return this.Config.Title;
			}
		}

		// Token: 0x170099B5 RID: 39349
		// (get) Token: 0x0603CF0F RID: 249615 RVA: 0x00F7A904 File Offset: 0x00F78B04
		public string Desc
		{
			get
			{
				return this.Config.Desc;
			}
		}

		// Token: 0x170099B6 RID: 39350
		// (get) Token: 0x0603CF10 RID: 249616 RVA: 0x00F7A920 File Offset: 0x00F78B20
		public string ImagePath
		{
			get
			{
				return this.Config.BackgroundImage;
			}
		}

		// Token: 0x170099B7 RID: 39351
		// (get) Token: 0x0603CF11 RID: 249617 RVA: 0x00F7A93C File Offset: 0x00F78B3C
		public string DetailImagePath
		{
			get
			{
				return this.Config.DetailBackgroundImage;
			}
		}

		// Token: 0x170099B8 RID: 39352
		// (get) Token: 0x0603CF12 RID: 249618 RVA: 0x00F7A958 File Offset: 0x00F78B58
		public ECiacconaGalEndingType Type
		{
			get
			{
				return (ECiacconaGalEndingType)this.Config.Type;
			}
		}

		// Token: 0x170099B9 RID: 39353
		// (get) Token: 0x0603CF13 RID: 249619 RVA: 0x00F7A974 File Offset: 0x00F78B74
		public int RewardId
		{
			get
			{
				return this.Config.Reward;
			}
		}

		// Token: 0x170099BA RID: 39354
		// (get) Token: 0x0603CF14 RID: 249620 RVA: 0x00F7A98F File Offset: 0x00F78B8F
		public bool IsFinished
		{
			get
			{
				return this.IsFinishedInternal;
			}
		}

		// Token: 0x170099BB RID: 39355
		// (get) Token: 0x0603CF15 RID: 249621 RVA: 0x00F7A997 File Offset: 0x00F78B97
		public bool IsRewarded
		{
			get
			{
				return this.IsRewardedInternal;
			}
		}

		// Token: 0x0603CF16 RID: 249622 RVA: 0x00F7A99F File Offset: 0x00F78B9F
		public void UpdateByServerData(CiacconaActivityResultPbData data)
		{
			this.IsFinishedInternal = true;
			this.IsRewardedInternal = data.TakeReward;
		}

		// Token: 0x04022364 RID: 140132
		private bool IsFinishedInternal;

		// Token: 0x04022365 RID: 140133
		private bool IsRewardedInternal;

		// Token: 0x04022366 RID: 140134
		private readonly CiacconaGalEnding Config;
	}
}
