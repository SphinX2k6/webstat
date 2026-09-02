using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005138 RID: 20792
	[NullableContext(2)]
	[Nullable(0)]
	public class RoguelikeAchieveViewModel
	{
		// Token: 0x06035865 RID: 219237 RVA: 0x00D702F8 File Offset: 0x00D6E4F8
		[NullableContext(1)]
		public void Init(IRoguelikeAchieveViewInfo viewState)
		{
			this.ViewStateInternal = viewState;
		}

		// Token: 0x06035866 RID: 219238 RVA: 0x00D70301 File Offset: 0x00D6E501
		[NullableContext(1)]
		public void SetViewState(IRoguelikeAchieveViewInfo viewState)
		{
			this.ViewStateInternal = viewState;
		}

		// Token: 0x17008C67 RID: 35943
		// (get) Token: 0x06035868 RID: 219240 RVA: 0x00D70318 File Offset: 0x00D6E518
		// (set) Token: 0x06035867 RID: 219239 RVA: 0x00D7030A File Offset: 0x00D6E50A
		public ERoguelikeAchieveViewMode Mode
		{
			get
			{
				return this.ViewStateInternal.Mode;
			}
			set
			{
				this.ViewStateInternal.Mode = value;
			}
		}

		// Token: 0x17008C68 RID: 35944
		// (get) Token: 0x06035869 RID: 219241 RVA: 0x00D70325 File Offset: 0x00D6E525
		public bool IsArchiveMode
		{
			get
			{
				return this.Mode == ERoguelikeAchieveViewMode.Archive;
			}
		}

		// Token: 0x17008C69 RID: 35945
		// (get) Token: 0x0603586A RID: 219242 RVA: 0x00D70330 File Offset: 0x00D6E530
		public bool IsUseArchiveMode
		{
			get
			{
				return this.Mode == ERoguelikeAchieveViewMode.UseArchive;
			}
		}

		// Token: 0x0603586B RID: 219243 RVA: 0x00D7033C File Offset: 0x00D6E53C
		public void TempArchiveSaved(int slotId)
		{
			this.IsTempRecordSaved = true;
			RoguelikeAchieveSlotData archiveBySlotId = this.GetArchiveBySlotId(slotId);
			if (archiveBySlotId != null)
			{
				int slotId2 = archiveBySlotId.ArchiveInfoData.SlotId;
				int index = archiveBySlotId.ArchiveInfoData.Index;
				archiveBySlotId.ArchiveInfoData = this.TempRecordInfo;
				archiveBySlotId.ArchiveInfoData.SlotId = slotId2;
				archiveBySlotId.ArchiveInfoData.Index = index;
			}
		}

		// Token: 0x0603586C RID: 219244 RVA: 0x00D70398 File Offset: 0x00D6E598
		public RoguelikeAchieveSlotData GetArchiveBySlotId(int slotId)
		{
			return this.ArchiveSlotList.Find(delegate(RoguelikeAchieveSlotData data)
			{
				RogueArchiveInfoData archiveInfoData = data.ArchiveInfoData;
				return archiveInfoData != null && archiveInfoData.SlotId == slotId;
			});
		}

		// Token: 0x17008C6A RID: 35946
		// (get) Token: 0x0603586E RID: 219246 RVA: 0x00D703D7 File Offset: 0x00D6E5D7
		// (set) Token: 0x0603586D RID: 219245 RVA: 0x00D703C9 File Offset: 0x00D6E5C9
		public RogueArchiveInfoData TempRecordInfo
		{
			get
			{
				return this.ViewStateInternal.TempRecordInfo;
			}
			set
			{
				this.ViewStateInternal.TempRecordInfo = value;
			}
		}

		// Token: 0x17008C6B RID: 35947
		// (get) Token: 0x0603586F RID: 219247 RVA: 0x00D703E4 File Offset: 0x00D6E5E4
		// (set) Token: 0x06035870 RID: 219248 RVA: 0x00D703EC File Offset: 0x00D6E5EC
		public bool IsTempRecordSaved
		{
			get
			{
				return this.IsTempRecordSavedInternal;
			}
			set
			{
				this.IsTempRecordSavedInternal = value;
			}
		}

		// Token: 0x17008C6C RID: 35948
		// (get) Token: 0x06035871 RID: 219249 RVA: 0x00D703F5 File Offset: 0x00D6E5F5
		public bool ShouldShowTempRecord
		{
			get
			{
				return this.IsArchiveMode && this.TempRecordInfo != null;
			}
		}

		// Token: 0x06035872 RID: 219250 RVA: 0x00D7040C File Offset: 0x00D6E60C
		public RoguelikeAchieveSlotData GetArchiveSlot(int slotIndex)
		{
			return this.ArchiveSlotList.Find((RoguelikeAchieveSlotData slotData) => slotData.SlotIndex == slotIndex);
		}

		// Token: 0x06035873 RID: 219251 RVA: 0x00D7043D File Offset: 0x00D6E63D
		public RogueArchiveInfoData GetArchiveInfo(int slotIndex)
		{
			RoguelikeAchieveSlotData archiveSlot = this.GetArchiveSlot(slotIndex);
			if (archiveSlot == null)
			{
				return null;
			}
			return archiveSlot.ArchiveInfoData;
		}

		// Token: 0x17008C6D RID: 35949
		// (get) Token: 0x06035874 RID: 219252 RVA: 0x00D70451 File Offset: 0x00D6E651
		// (set) Token: 0x06035875 RID: 219253 RVA: 0x00D70459 File Offset: 0x00D6E659
		public int SelectedRecordGridIndex
		{
			get
			{
				return this.SelectedRecordGridIndexInternal;
			}
			set
			{
				this.SelectedRecordGridIndexInternal = value;
			}
		}

		// Token: 0x17008C6E RID: 35950
		// (get) Token: 0x06035876 RID: 219254 RVA: 0x00D70462 File Offset: 0x00D6E662
		// (set) Token: 0x06035877 RID: 219255 RVA: 0x00D7046A File Offset: 0x00D6E66A
		public bool IsTempRecordSelected
		{
			get
			{
				return this.IsTempRecordSelectedInternal;
			}
			set
			{
				this.IsTempRecordSelectedInternal = value;
			}
		}

		// Token: 0x17008C6F RID: 35951
		// (get) Token: 0x06035878 RID: 219256 RVA: 0x00D70473 File Offset: 0x00D6E673
		public RogueArchiveInfoData SelectedArchiveInfoData
		{
			get
			{
				if (this.IsTempRecordSelectedInternal)
				{
					return this.TempRecordInfo;
				}
				RoguelikeAchieveSlotData selectedSlotData = this.SelectedSlotData;
				if (selectedSlotData == null)
				{
					return null;
				}
				return selectedSlotData.ArchiveInfoData;
			}
		}

		// Token: 0x17008C70 RID: 35952
		// (get) Token: 0x06035879 RID: 219257 RVA: 0x00D70495 File Offset: 0x00D6E695
		public RoguelikeAchieveSlotData SelectedSlotData
		{
			get
			{
				if (this.SelectedRecordGridIndexInternal < 0)
				{
					return null;
				}
				if (this.SelectedRecordGridIndexInternal >= this.ArchiveSlotList.Count)
				{
					return null;
				}
				return this.ArchiveSlotList[this.SelectedRecordGridIndexInternal];
			}
		}

		// Token: 0x0401EC23 RID: 125987
		public int InstId;

		// Token: 0x0401EC24 RID: 125988
		[Nullable(1)]
		public List<RoguelikeAchieveSlotData> ArchiveSlotList = new List<RoguelikeAchieveSlotData>();

		// Token: 0x0401EC25 RID: 125989
		private bool IsTempRecordSavedInternal;

		// Token: 0x0401EC26 RID: 125990
		[Nullable(1)]
		private IRoguelikeAchieveViewInfo ViewStateInternal;

		// Token: 0x0401EC27 RID: 125991
		private int SelectedRecordGridIndexInternal = -1;

		// Token: 0x0401EC28 RID: 125992
		private bool IsTempRecordSelectedInternal;
	}
}
