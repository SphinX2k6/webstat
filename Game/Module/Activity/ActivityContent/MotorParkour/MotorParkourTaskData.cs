using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066AE RID: 26286
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorParkourTaskData
	{
		// Token: 0x06041A5A RID: 268890 RVA: 0x010D518C File Offset: 0x010D338C
		public MotorParkourTaskData(int id)
		{
			MotorParkourReward? motorParkourTaskById = ConfigBase<MotorParkourConfig>.Instance.GetMotorParkourTaskById(id);
			if (motorParkourTaskById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorParkour;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "摩托跑酷任务不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.Config = motorParkourTaskById.Value;
			this.RewardList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(this.Config.DropId).ToArray();
		}

		// Token: 0x1700A04B RID: 41035
		// (get) Token: 0x06041A5B RID: 268891 RVA: 0x010D5223 File Offset: 0x010D3423
		public bool IsRunning
		{
			get
			{
				return this.Status == EActivityTaskState.Active;
			}
		}

		// Token: 0x1700A04C RID: 41036
		// (get) Token: 0x06041A5C RID: 268892 RVA: 0x010D522E File Offset: 0x010D342E
		public bool IsFinished
		{
			get
			{
				return this.Status == EActivityTaskState.FinishedAndUnclaimed;
			}
		}

		// Token: 0x1700A04D RID: 41037
		// (get) Token: 0x06041A5D RID: 268893 RVA: 0x010D5239 File Offset: 0x010D3439
		public bool IsReceived
		{
			get
			{
				return this.Status == EActivityTaskState.FinishedAndClaimed;
			}
		}

		// Token: 0x1700A04E RID: 41038
		// (get) Token: 0x06041A5E RID: 268894 RVA: 0x010D5244 File Offset: 0x010D3444
		// (set) Token: 0x06041A5F RID: 268895 RVA: 0x010D524C File Offset: 0x010D344C
		public int LevelId
		{
			get
			{
				return this.LevelInternal;
			}
			set
			{
				this.LevelInternal = value;
			}
		}

		// Token: 0x1700A04F RID: 41039
		// (get) Token: 0x06041A60 RID: 268896 RVA: 0x010D5255 File Offset: 0x010D3455
		public int RecordId
		{
			get
			{
				return this.Config.RecordId;
			}
		}

		// Token: 0x1700A050 RID: 41040
		// (get) Token: 0x06041A61 RID: 268897 RVA: 0x010D5262 File Offset: 0x010D3462
		public string Desc
		{
			get
			{
				return this.Config.Desc;
			}
		}

		// Token: 0x04024A52 RID: 150098
		private MotorParkourReward Config;

		// Token: 0x04024A53 RID: 150099
		public TItem[] RewardList = Array.Empty<TItem>();

		// Token: 0x04024A54 RID: 150100
		private int LevelInternal;

		// Token: 0x04024A55 RID: 150101
		public EActivityTaskState Status = EActivityTaskState.Active;
	}
}
