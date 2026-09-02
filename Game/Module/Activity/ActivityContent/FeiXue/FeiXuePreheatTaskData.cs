using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FeiXue
{
	// Token: 0x0200683D RID: 26685
	[NullableContext(1)]
	[Nullable(0)]
	public class FeiXuePreheatTaskData
	{
		// Token: 0x06042872 RID: 272498 RVA: 0x011137C4 File Offset: 0x011119C4
		public FeiXuePreheatTaskData(FeiXuePreheatInfo taskData)
		{
			this.Data = taskData;
			this.Status = (EFeiXuePreheatTaskState)taskData.State;
			this.Current = ((taskData.State >= 2) ? 1 : 0);
			this.Config = ConfigFeiXuePreheatById.GetConfig(taskData.Id, true);
			this.RewardList = new List<TItem>(ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(this.Config.Value.DropId));
		}

		// Token: 0x06042873 RID: 272499 RVA: 0x01113848 File Offset: 0x01111A48
		public void UpdateTaskData(FeiXuePreheatInfo taskData)
		{
			this.Data = taskData;
			this.Status = (EFeiXuePreheatTaskState)taskData.State;
			this.Current = ((taskData.State >= 2) ? 1 : 0);
		}

		// Token: 0x1700A18A RID: 41354
		// (get) Token: 0x06042874 RID: 272500 RVA: 0x0111386F File Offset: 0x01111A6F
		public bool IsLock
		{
			get
			{
				return this.Status == EFeiXuePreheatTaskState.Lock;
			}
		}

		// Token: 0x1700A18B RID: 41355
		// (get) Token: 0x06042875 RID: 272501 RVA: 0x0111387A File Offset: 0x01111A7A
		public bool IsDoing
		{
			get
			{
				return this.Status == EFeiXuePreheatTaskState.UnLock;
			}
		}

		// Token: 0x1700A18C RID: 41356
		// (get) Token: 0x06042876 RID: 272502 RVA: 0x01113885 File Offset: 0x01111A85
		public bool IsUnclaimed
		{
			get
			{
				return this.Status == EFeiXuePreheatTaskState.Claimable;
			}
		}

		// Token: 0x1700A18D RID: 41357
		// (get) Token: 0x06042877 RID: 272503 RVA: 0x01113890 File Offset: 0x01111A90
		public bool IsFinished
		{
			get
			{
				return this.Status == EFeiXuePreheatTaskState.Finished;
			}
		}

		// Token: 0x1700A18E RID: 41358
		// (get) Token: 0x06042878 RID: 272504 RVA: 0x0111389B File Offset: 0x01111A9B
		public int Id
		{
			get
			{
				return this.Data.Id;
			}
		}

		// Token: 0x1700A18F RID: 41359
		// (get) Token: 0x06042879 RID: 272505 RVA: 0x011138A8 File Offset: 0x01111AA8
		public string QuestName
		{
			get
			{
				return this.Config.Value.QuestName;
			}
		}

		// Token: 0x1700A190 RID: 41360
		// (get) Token: 0x0604287A RID: 272506 RVA: 0x011138C8 File Offset: 0x01111AC8
		public long UnlockTime
		{
			get
			{
				return Singleton<MathUtils>.Instance.LongToBigInt(this.Data.QuestUnlockTime);
			}
		}

		// Token: 0x1700A191 RID: 41361
		// (get) Token: 0x0604287B RID: 272507 RVA: 0x011138E0 File Offset: 0x01111AE0
		public string QuestDesc
		{
			get
			{
				return this.Config.Value.QuestDesc;
			}
		}

		// Token: 0x04025067 RID: 151655
		public FeiXuePreheat? Config;

		// Token: 0x04025068 RID: 151656
		[Nullable(2)]
		public FeiXuePreheatInfo Data;

		// Token: 0x04025069 RID: 151657
		public EFeiXuePreheatTaskState Status;

		// Token: 0x0402506A RID: 151658
		public List<TItem> RewardList = new List<TItem>();

		// Token: 0x0402506B RID: 151659
		public int Current;

		// Token: 0x0402506C RID: 151660
		public int Target = 1;
	}
}
