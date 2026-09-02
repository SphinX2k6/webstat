using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002E6C RID: 11884
[NullableContext(2)]
[Nullable(0)]
internal class MontageTask
{
	// Token: 0x170020CC RID: 8396
	// (get) Token: 0x0601869B RID: 99995 RVA: 0x006D7463 File Offset: 0x006D5663
	public bool Invalid
	{
		get
		{
			return this.InvalidInternal;
		}
	}

	// Token: 0x0601869C RID: 99996 RVA: 0x006D746B File Offset: 0x006D566B
	public MontageTask(BaseMontageComponent montageComponent, int handle, Action playCallback = null, Action<bool> endCallback = null)
	{
		this.MontageComponent = montageComponent;
		this.Handle = handle;
		this.PlayCallback = playCallback;
		this.EndCallback = endCallback;
		this.ReadyToPlay = false;
	}

	// Token: 0x0601869D RID: 99997 RVA: 0x006D74A4 File Offset: 0x006D56A4
	[NullableContext(1)]
	public void InitWithPath(string montageName, float blendInTime = -1f)
	{
		this.BlendInTime = blendInTime;
		this.MontageName = montageName;
		BaseMontageComponent montageComponent = this.MontageComponent;
		UAnimMontage uanimMontage = (montageComponent != null) ? montageComponent.GetMontageByName(montageName, true, false) : null;
		BaseMontageComponent montageComponent2 = this.MontageComponent;
		string text = (montageComponent2 != null) ? montageComponent2.GetMontagePathByName(montageName, true, false) : null;
		if (this.MontageComponent == null || uanimMontage == null || string.IsNullOrEmpty(text))
		{
			this.InvalidInternal = true;
			return;
		}
		this.InitInternal(uanimMontage, montageName, text, blendInTime);
	}

	// Token: 0x0601869E RID: 99998 RVA: 0x006D7510 File Offset: 0x006D5710
	[NullableContext(1)]
	public void InitWithMontage(UAnimMontage montage, float blendInTime = -1f)
	{
		this.BlendInTime = blendInTime;
		string text = (montage != null) ? montage.GetName() : null;
		BaseMontageComponent montageComponent = this.MontageComponent;
		string text2 = (montageComponent != null) ? montageComponent.GetMontagePathByName(text, true, false) : null;
		if (this.MontageComponent == null || string.IsNullOrEmpty(text2) || string.IsNullOrEmpty(text))
		{
			this.InvalidInternal = true;
			return;
		}
		this.InitInternal(montage, text, text2, blendInTime);
	}

	// Token: 0x0601869F RID: 99999 RVA: 0x006D7574 File Offset: 0x006D5774
	[NullableContext(1)]
	private void InitInternal(UAnimMontage montage, string montageName, string path, float blendInTime)
	{
		if (montage == null)
		{
			this.InvalidInternal = true;
			return;
		}
		this.BlendInTime = blendInTime;
		this.MontageName = montage.GetName();
		this.MontagePathHash = UGASBPLibrary.FnvHash(path);
		BaseMontageComponent montageComponent = this.MontageComponent;
		this.MontageNeedPush2Server = (montageComponent != null && montageComponent.IsMontageNeedPush2Server(montageName));
		if (this.InvalidInternal)
		{
			return;
		}
		this.Montage = montage;
		if (this.ReadyToPlay)
		{
			this.Play(0f, -1f);
		}
	}

	// Token: 0x060186A0 RID: 100000 RVA: 0x006D75F0 File Offset: 0x006D57F0
	public void Play(float startPosition = 0f, float remainedTrigger = -1f)
	{
		if (this.InvalidInternal)
		{
			return;
		}
		Action playCallback = this.PlayCallback;
		if (playCallback != null)
		{
			playCallback();
		}
		if (this.Montage != null && !this.Playing)
		{
			float blendTime = this.Montage.BlendIn.BlendTime;
			if (this.BlendInTime >= 0f)
			{
				this.Montage.BlendIn.BlendTime = this.BlendInTime;
			}
			float remainedTrigger2 = BaseMontageComponent.RemainedTriggerOn ? remainedTrigger : -1f;
			this.UeMontageTask = UAsyncTaskPlayMontageAndWait.ListenRemainForPlayMontage(this.MontageComponent.GetMainAnimInstance(), this.Montage, 1f, startPosition, FNameUtil.NONE, remainedTrigger2);
			if (this.UeMontageTask.MontageLength <= 0f)
			{
				Action<bool> endCallback = this.EndCallback;
				if (endCallback != null)
				{
					endCallback(true);
				}
				this.MontageComponent.EndMontageTask(this.Handle);
				return;
			}
			if (this.BlendInTime >= 0f)
			{
				this.Montage.BlendIn.BlendTime = blendTime;
			}
			this.UeMontageTask.EndCallback.Add(delegate(bool isInterrupted)
			{
				Action<bool> endCallback2 = this.EndCallback;
				if (endCallback2 != null)
				{
					endCallback2(isInterrupted);
				}
				this.MontageComponent.EndMontageTask(this.Handle);
			});
			this.UeMontageTask.RemainCallback.Add(delegate(float remainTime)
			{
				Action<float> remainCallback = this.RemainCallback;
				if (remainCallback == null)
				{
					return;
				}
				remainCallback(remainTime);
			});
			this.MontageComponent.PushMontageInfo(new MontageInfo
			{
				MontageNames = new List<string>(),
				MontageTaskMessageId = this.MontageComponent.MontageTaskMessageId
			}, this.Montage);
			this.Playing = true;
		}
		this.ReadyToPlay = true;
	}

	// Token: 0x060186A1 RID: 100001 RVA: 0x006D7768 File Offset: 0x006D5968
	public void EndTask()
	{
		UAsyncTaskPlayMontageAndWait ueMontageTask = this.UeMontageTask;
		if (ueMontageTask != null)
		{
			ueMontageTask.EndTask();
		}
		UAsyncTaskPlayMontageAndWait ueMontageTask2 = this.UeMontageTask;
		if (ueMontageTask2 != null)
		{
			ueMontageTask2.EndCallback.Clear();
		}
		UAsyncTaskPlayMontageAndWait ueMontageTask3 = this.UeMontageTask;
		if (ueMontageTask3 != null)
		{
			ueMontageTask3.RemainCallback.Clear();
		}
		this.UeMontageTask = null;
		this.MontageComponent = null;
		this.PlayCallback = null;
		this.EndCallback = null;
		this.RemainCallback = null;
		this.InvalidInternal = true;
	}

	// Token: 0x0400BBA9 RID: 48041
	public UAnimMontage Montage;

	// Token: 0x0400BBAA RID: 48042
	public float BlendInTime;

	// Token: 0x0400BBAB RID: 48043
	public int MontagePathHash;

	// Token: 0x0400BBAC RID: 48044
	[Nullable(1)]
	public string MontageName = "";

	// Token: 0x0400BBAD RID: 48045
	public bool MontageNeedPush2Server;

	// Token: 0x0400BBAE RID: 48046
	public Action<float> RemainCallback;

	// Token: 0x0400BBAF RID: 48047
	private UAsyncTaskPlayMontageAndWait UeMontageTask;

	// Token: 0x0400BBB0 RID: 48048
	private bool ReadyToPlay;

	// Token: 0x0400BBB1 RID: 48049
	private bool Playing;

	// Token: 0x0400BBB2 RID: 48050
	private bool InvalidInternal;

	// Token: 0x0400BBB3 RID: 48051
	public BaseMontageComponent MontageComponent;

	// Token: 0x0400BBB4 RID: 48052
	public int Handle;

	// Token: 0x0400BBB5 RID: 48053
	public Action PlayCallback;

	// Token: 0x0400BBB6 RID: 48054
	public Action<bool> EndCallback;
}
