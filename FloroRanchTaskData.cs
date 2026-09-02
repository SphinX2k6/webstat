using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;

// Token: 0x02001BD1 RID: 7121
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchTaskData
{
	// Token: 0x0600CF46 RID: 53062 RVA: 0x00371B52 File Offset: 0x0036FD52
	public FloroRanchTaskData(FloroRanchTask config)
	{
		this.Config = config;
		this.RewardList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(config.DropId);
	}

	// Token: 0x0600CF47 RID: 53063 RVA: 0x00371B91 File Offset: 0x0036FD91
	public void UpdateUnLockState(bool isUnLock)
	{
		this.IsUnLockInternal = isUnLock;
	}

	// Token: 0x170010DE RID: 4318
	// (get) Token: 0x0600CF48 RID: 53064 RVA: 0x00371B9A File Offset: 0x0036FD9A
	public bool IsUnLock
	{
		get
		{
			return this.IsUnLockInternal;
		}
	}

	// Token: 0x170010DF RID: 4319
	// (get) Token: 0x0600CF49 RID: 53065 RVA: 0x00371BA4 File Offset: 0x0036FDA4
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x170010E0 RID: 4320
	// (get) Token: 0x0600CF4A RID: 53066 RVA: 0x00371BC0 File Offset: 0x0036FDC0
	public bool IsLimitTime
	{
		get
		{
			return this.Config.LimitTime;
		}
	}

	// Token: 0x170010E1 RID: 4321
	// (get) Token: 0x0600CF4B RID: 53067 RVA: 0x00371BDC File Offset: 0x0036FDDC
	public EFloroRanchTaskTabType TabType
	{
		get
		{
			return (EFloroRanchTaskTabType)this.Config.PageType;
		}
	}

	// Token: 0x170010E2 RID: 4322
	// (get) Token: 0x0600CF4C RID: 53068 RVA: 0x00371BF8 File Offset: 0x0036FDF8
	public string TaskName
	{
		get
		{
			return this.Config.RewardName;
		}
	}

	// Token: 0x170010E3 RID: 4323
	// (get) Token: 0x0600CF4D RID: 53069 RVA: 0x00371C14 File Offset: 0x0036FE14
	public int JumpId
	{
		get
		{
			return this.Config.JumpId;
		}
	}

	// Token: 0x040062B6 RID: 25270
	private readonly FloroRanchTask Config;

	// Token: 0x040062B7 RID: 25271
	public EActivityTaskState Status = EActivityTaskState.Active;

	// Token: 0x040062B8 RID: 25272
	private bool IsUnLockInternal = true;

	// Token: 0x040062B9 RID: 25273
	public int Current;

	// Token: 0x040062BA RID: 25274
	public int Target;

	// Token: 0x040062BB RID: 25275
	public List<TItem> RewardList = new List<TItem>();

	// Token: 0x040062BC RID: 25276
	[Nullable(2)]
	public FloroRanchTaskData.TReceive ReceiveDelegate;

	// Token: 0x02007EAF RID: 32431
	// (Invoke) Token: 0x06047FDA RID: 294874
	[NullableContext(0)]
	public delegate void TReceive(int taskId);
}
