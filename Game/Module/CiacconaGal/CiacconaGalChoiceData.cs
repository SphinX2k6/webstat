using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EB5 RID: 24245
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalChoiceData
	{
		// Token: 0x0603CEFE RID: 249598 RVA: 0x00F7A6EF File Offset: 0x00F788EF
		public CiacconaGalChoiceData(CiacconaGalChoice config)
		{
			this.Config = config;
		}

		// Token: 0x170099A8 RID: 39336
		// (get) Token: 0x0603CEFF RID: 249599 RVA: 0x00F7A70C File Offset: 0x00F7890C
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x170099A9 RID: 39337
		// (get) Token: 0x0603CF00 RID: 249600 RVA: 0x00F7A728 File Offset: 0x00F78928
		public string Content
		{
			get
			{
				return this.Config.Content;
			}
		}

		// Token: 0x170099AA RID: 39338
		// (get) Token: 0x0603CF01 RID: 249601 RVA: 0x00F7A744 File Offset: 0x00F78944
		public int RequiredInspiration
		{
			get
			{
				return this.Config.RequiredInspiration;
			}
		}

		// Token: 0x170099AB RID: 39339
		// (get) Token: 0x0603CF02 RID: 249602 RVA: 0x00F7A760 File Offset: 0x00F78960
		public bool NeedInspiration
		{
			get
			{
				return this.Config.RequiredInspiration > 0;
			}
		}

		// Token: 0x170099AC RID: 39340
		// (get) Token: 0x0603CF03 RID: 249603 RVA: 0x00F7A77E File Offset: 0x00F7897E
		public bool IsAvailable
		{
			get
			{
				return this.State == ECiacconaGalStepState.Normal;
			}
		}

		// Token: 0x170099AD RID: 39341
		// (get) Token: 0x0603CF04 RID: 249604 RVA: 0x00F7A789 File Offset: 0x00F78989
		public ECiacconaGalStepState State
		{
			get
			{
				if (!this.IsUnlocked)
				{
					return ECiacconaGalStepState.LockingByCondition;
				}
				if (!this.HasInspired)
				{
					return ECiacconaGalStepState.LockingByInspiration;
				}
				if (this.HasChosen)
				{
					return ECiacconaGalStepState.Chosen;
				}
				return ECiacconaGalStepState.Normal;
			}
		}

		// Token: 0x170099AE RID: 39342
		// (get) Token: 0x0603CF05 RID: 249605 RVA: 0x00F7A7AC File Offset: 0x00F789AC
		public int ToStepId
		{
			get
			{
				return this.Config.ToStep;
			}
		}

		// Token: 0x170099AF RID: 39343
		// (get) Token: 0x0603CF06 RID: 249606 RVA: 0x00F7A7C8 File Offset: 0x00F789C8
		public int CorrSubEndingId
		{
			get
			{
				return this.Config.CorrSubEnding;
			}
		}

		// Token: 0x170099B0 RID: 39344
		// (get) Token: 0x0603CF07 RID: 249607 RVA: 0x00F7A7E3 File Offset: 0x00F789E3
		private bool HasChosen
		{
			get
			{
				return this.HasChosenInternal;
			}
		}

		// Token: 0x170099B1 RID: 39345
		// (get) Token: 0x0603CF08 RID: 249608 RVA: 0x00F7A7EB File Offset: 0x00F789EB
		private bool HasInspired
		{
			get
			{
				return !this.NeedInspiration || this.HasInspiredInternal;
			}
		}

		// Token: 0x170099B2 RID: 39346
		// (get) Token: 0x0603CF09 RID: 249609 RVA: 0x00F7A7FD File Offset: 0x00F789FD
		private bool IsUnlocked
		{
			get
			{
				return this.IsUnlockedInternal;
			}
		}

		// Token: 0x0603CF0A RID: 249610 RVA: 0x00F7A808 File Offset: 0x00F78A08
		public void UpdateByServerData(CiacconaChapterPbData chapterData)
		{
			foreach (CiacconaChapterChoicePbData ciacconaChapterChoicePbData in chapterData.ChoiceDatas)
			{
				if (ciacconaChapterChoicePbData.ChoiceId == this.Id)
				{
					this.HasInspiredInternal = ciacconaChapterChoicePbData.InspirationUnlock;
					this.IsUnlockedInternal = ciacconaChapterChoicePbData.ConditionUnlock;
					break;
				}
			}
			this.HasChosenInternal = chapterData.ResultDatas.Any((CiacconaChapterResultPbData resultData) => resultData.ResultId == this.CorrSubEndingId && resultData.Finish);
		}

		// Token: 0x04022360 RID: 140128
		private bool HasInspiredInternal = true;

		// Token: 0x04022361 RID: 140129
		private bool HasChosenInternal;

		// Token: 0x04022362 RID: 140130
		private bool IsUnlockedInternal = true;

		// Token: 0x04022363 RID: 140131
		private readonly CiacconaGalChoice Config;
	}
}
