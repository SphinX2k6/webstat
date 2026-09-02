using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EB4 RID: 24244
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalChapterSlotData
	{
		// Token: 0x0603CEF8 RID: 249592 RVA: 0x00F7A654 File Offset: 0x00F78854
		public CiacconaGalChapterSlotData(CiacconaChapterSlot config)
		{
			this.Config = config;
		}

		// Token: 0x170099A3 RID: 39331
		// (get) Token: 0x0603CEF9 RID: 249593 RVA: 0x00F7A664 File Offset: 0x00F78864
		public int Id
		{
			get
			{
				return this.Config.Id;
			}
		}

		// Token: 0x170099A4 RID: 39332
		// (get) Token: 0x0603CEFA RID: 249594 RVA: 0x00F7A680 File Offset: 0x00F78880
		public int ChapterId
		{
			get
			{
				return this.Config.ChapterId;
			}
		}

		// Token: 0x170099A5 RID: 39333
		// (get) Token: 0x0603CEFB RID: 249595 RVA: 0x00F7A69C File Offset: 0x00F7889C
		public string SlotImagePath
		{
			get
			{
				return this.Config.SlotImage;
			}
		}

		// Token: 0x170099A6 RID: 39334
		// (get) Token: 0x0603CEFC RID: 249596 RVA: 0x00F7A6B8 File Offset: 0x00F788B8
		public string SlotLockImagePath
		{
			get
			{
				return this.Config.SlotLockImage;
			}
		}

		// Token: 0x170099A7 RID: 39335
		// (get) Token: 0x0603CEFD RID: 249597 RVA: 0x00F7A6D4 File Offset: 0x00F788D4
		public string RomanNumberIconPath
		{
			get
			{
				return this.Config.RomanNumberIcon;
			}
		}

		// Token: 0x0402235F RID: 140127
		private readonly CiacconaChapterSlot Config;
	}
}
