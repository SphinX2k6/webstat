using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EB3 RID: 24243
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalChapterData
	{
		// Token: 0x0603CEEA RID: 249578 RVA: 0x00F7A52A File Offset: 0x00F7872A
		public CiacconaGalChapterData(CiacconaGalChapter Config)
		{
			this.Config = Config;
			this.InternelSubEndingIds = new int[]
			{
				Config.SubEnding1,
				Config.SubEnding2,
				Config.SubEnding3
			};
		}

		// Token: 0x17009998 RID: 39320
		// (get) Token: 0x0603CEEB RID: 249579 RVA: 0x00F7A563 File Offset: 0x00F78763
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x17009999 RID: 39321
		// (get) Token: 0x0603CEEC RID: 249580 RVA: 0x00F7A570 File Offset: 0x00F78770
		public string Title
		{
			get
			{
				return this.Config.Title;
			}
		}

		// Token: 0x1700999A RID: 39322
		// (get) Token: 0x0603CEED RID: 249581 RVA: 0x00F7A57D File Offset: 0x00F7877D
		public string Desc
		{
			get
			{
				return this.Config.Desc;
			}
		}

		// Token: 0x1700999B RID: 39323
		// (get) Token: 0x0603CEEE RID: 249582 RVA: 0x00F7A58A File Offset: 0x00F7878A
		public int[] StepIds
		{
			get
			{
				return this.Config.Steps();
			}
		}

		// Token: 0x1700999C RID: 39324
		// (get) Token: 0x0603CEEF RID: 249583 RVA: 0x00F7A597 File Offset: 0x00F78797
		public string ImageSmallPath
		{
			get
			{
				return this.Config.ChapterImageSmall;
			}
		}

		// Token: 0x1700999D RID: 39325
		// (get) Token: 0x0603CEF0 RID: 249584 RVA: 0x00F7A5A4 File Offset: 0x00F787A4
		public string ImageLargePath
		{
			get
			{
				return this.Config.ChapterImageLarge;
			}
		}

		// Token: 0x1700999E RID: 39326
		// (get) Token: 0x0603CEF1 RID: 249585 RVA: 0x00F7A5B1 File Offset: 0x00F787B1
		public int[] SubEndingIds
		{
			get
			{
				return this.InternelSubEndingIds;
			}
		}

		// Token: 0x1700999F RID: 39327
		// (get) Token: 0x0603CEF2 RID: 249586 RVA: 0x00F7A5B9 File Offset: 0x00F787B9
		public int BranchingStepId
		{
			get
			{
				return this.Config.BranchPoint;
			}
		}

		// Token: 0x170099A0 RID: 39328
		// (get) Token: 0x0603CEF3 RID: 249587 RVA: 0x00F7A5C6 File Offset: 0x00F787C6
		public bool IsFinished
		{
			get
			{
				return this.IsFinishedInternal;
			}
		}

		// Token: 0x170099A1 RID: 39329
		// (get) Token: 0x0603CEF4 RID: 249588 RVA: 0x00F7A5CE File Offset: 0x00F787CE
		public bool IsUnlocked
		{
			get
			{
				return this.IsUnlockInternal;
			}
		}

		// Token: 0x170099A2 RID: 39330
		// (get) Token: 0x0603CEF5 RID: 249589 RVA: 0x00F7A5D6 File Offset: 0x00F787D6
		public string MusicEvent
		{
			get
			{
				return this.Config.MusicEvent;
			}
		}

		// Token: 0x0603CEF6 RID: 249590 RVA: 0x00F7A5E3 File Offset: 0x00F787E3
		public int GetSubEndingId(int index)
		{
			return this.InternelSubEndingIds[index];
		}

		// Token: 0x0603CEF7 RID: 249591 RVA: 0x00F7A5F0 File Offset: 0x00F787F0
		public void UpdateByServerData(CiacconaChapterPbData data)
		{
			using (IEnumerator<CiacconaChapterResultPbData> enumerator = data.ResultDatas.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Finish)
					{
						this.IsFinishedInternal = true;
						break;
					}
				}
			}
			this.IsUnlockInternal = data.Unlock;
		}

		// Token: 0x0402235B RID: 140123
		private CiacconaGalChapter Config;

		// Token: 0x0402235C RID: 140124
		private readonly int[] InternelSubEndingIds;

		// Token: 0x0402235D RID: 140125
		private bool IsFinishedInternal;

		// Token: 0x0402235E RID: 140126
		private bool IsUnlockInternal;
	}
}
