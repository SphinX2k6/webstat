using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002292 RID: 8850
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleTaskItem : GridProxyAbstract<MotorTechTaskNode>
{
	// Token: 0x06010BAF RID: 68527 RVA: 0x004956CC File Offset: 0x004938CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnBtnIconClick)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnBtnGetClick)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnBtnJumpClick))
		};
	}

	// Token: 0x06010BB0 RID: 68528 RVA: 0x00495844 File Offset: 0x00493A44
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleTaskItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleTaskItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010BB1 RID: 68529 RVA: 0x00495887 File Offset: 0x00493A87
	protected override void OnBeforeDestroy()
	{
		this.RemoveTagCountDownTimer();
	}

	// Token: 0x06010BB2 RID: 68530 RVA: 0x00495890 File Offset: 0x00493A90
	public override void Refresh(MotorTechTaskNode data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.TreeType = data.TreeType;
		MotorTask? motorTaskConfig = ConfigBase<MotorConfig>.Instance.GetMotorTaskConfig(data.TaskId);
		MotorTechTree? motorTechTreeConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(this.TreeType);
		if (motorTaskConfig == null || motorTechTreeConfig == null)
		{
			return;
		}
		this.JumpId = motorTaskConfig.Value.JumpId;
		int num = data.ProcessInfo.Current;
		int target = data.ProcessInfo.Target;
		string icon = ConfigBase<ItemConfig>.Instance.GetConfig(motorTechTreeConfig.Value.TpItemId).Value.Icon;
		base.GetText(1).SetText(num.ToString() + "/" + target.ToString(), true);
		base.GetText(8).SetText("+" + motorTaskConfig.Value.RewardTpCount.ToString(), true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), motorTaskConfig.Value.Title, Array.Empty<object>());
		base.SetTextureByPath(icon, base.GetTexture(9), null, null);
		int waitRewardCount = data.RewardInfo.WaitRewardCount;
		int rewardedCount = data.RewardInfo.RewardedCount;
		int maxRewardCount = data.RewardInfo.MaxRewardCount;
		if (waitRewardCount > 0)
		{
			base.GetItem(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			base.GetButton(5).RootUIComp.Get().SetUIActive(false);
			base.GetButton(6).RootUIComp.Get().SetUIActive(true);
		}
		else if (maxRewardCount > 0 && rewardedCount >= maxRewardCount)
		{
			base.GetItem(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(true);
			base.GetItem(7).SetUIActive(true);
			base.GetButton(5).RootUIComp.Get().SetUIActive(false);
			base.GetButton(6).RootUIComp.Get().SetUIActive(false);
		}
		else
		{
			bool flag = motorTaskConfig.Value.JumpId > 0;
			base.GetItem(2).SetUIActive(!flag);
			base.GetItem(3).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			base.GetButton(5).RootUIComp.Get().SetUIActive(flag);
			base.GetButton(6).RootUIComp.Get().SetUIActive(false);
		}
		bool flag2 = false;
		if (data.Type == EMotorTechTaskType.Loop)
		{
			flag2 = true;
		}
		else if (data.Type == EMotorTechTaskType.Limited)
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			flag2 = ((double)data.EndTime > serverTime);
		}
		this.TagItem.SetUiActive(flag2);
		if (flag2)
		{
			this.TagItem.Refresh(data);
		}
		this.RefreshTagCountDown();
	}

	// Token: 0x06010BB3 RID: 68531 RVA: 0x00495B98 File Offset: 0x00493D98
	private void RefreshTagCountDown()
	{
		this.RemoveTagCountDownTimer();
		if (this.Data == null || this.Data.Type != EMotorTechTaskType.Limited)
		{
			return;
		}
		this.TimerHandle = TimerSystem.Instance.Forever(new TTimerAction(this.BeginTagCountDownTimer), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
	}

	// Token: 0x06010BB4 RID: 68532 RVA: 0x00495BF4 File Offset: 0x00493DF4
	private void BeginTagCountDownTimer(float delta)
	{
		double endTime = (double)this.Data.EndTime;
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if (endTime - serverTime <= 0.0)
		{
			this.TagItem.SetUiActive(false);
			this.RemoveTagCountDownTimer();
			return;
		}
		this.TagItem.SetUiActive(true);
		this.TagItem.Refresh(this.Data);
	}

	// Token: 0x06010BB5 RID: 68533 RVA: 0x00495C55 File Offset: 0x00493E55
	private void RemoveTagCountDownTimer()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.Instance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06010BB6 RID: 68534 RVA: 0x00495C78 File Offset: 0x00493E78
	private void OnBtnIconClick()
	{
		int tpItemId = ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(this.TreeType).Value.TpItemId;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(tpItemId, true, null);
	}

	// Token: 0x06010BB7 RID: 68535 RVA: 0x00495CB4 File Offset: 0x00493EB4
	private void OnBtnGetClick()
	{
		int[] waitRewardTaskIds = ModelBase<MotorcycleDevelopModel>.Instance.GetWaitRewardTaskIds(this.TreeType);
		ControllerBase<MotorcycleDevelopController>.Instance.RequestMotorTechTaskOneKeyReward(waitRewardTaskIds);
	}

	// Token: 0x06010BB8 RID: 68536 RVA: 0x00495CDD File Offset: 0x00493EDD
	private void OnBtnJumpClick()
	{
		if (this.JumpId <= 0)
		{
			return;
		}
		SkipTaskManager.RunByConfigId(this.JumpId, null);
	}

	// Token: 0x06010BB9 RID: 68537 RVA: 0x00495CF8 File Offset: 0x00493EF8
	public UUIItem GetBtnGet()
	{
		return base.GetButton(6).RootUIComp.Get();
	}

	// Token: 0x06010BBA RID: 68538 RVA: 0x00495D19 File Offset: 0x00493F19
	public UUIItem GetNavigationItem()
	{
		return base.GetItem(11);
	}

	// Token: 0x04008400 RID: 33792
	private int TreeType;

	// Token: 0x04008401 RID: 33793
	private int JumpId;

	// Token: 0x04008402 RID: 33794
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x04008403 RID: 33795
	[Nullable(2)]
	private MotorcycleTaskTagItem TagItem;

	// Token: 0x04008404 RID: 33796
	[Nullable(2)]
	private MotorTechTaskNode Data;

	// Token: 0x0200855C RID: 34140
	[NullableContext(0)]
	private class EMotorTaskItemComponent
	{
		// Token: 0x0402D212 RID: 184850
		public const int TxtTitle = 0;

		// Token: 0x0402D213 RID: 184851
		public const int TxtProgress = 1;

		// Token: 0x0402D214 RID: 184852
		public const int DoingItem = 2;

		// Token: 0x0402D215 RID: 184853
		public const int DoneItem = 3;

		// Token: 0x0402D216 RID: 184854
		public const int BtnIcon = 4;

		// Token: 0x0402D217 RID: 184855
		public const int BtnJump = 5;

		// Token: 0x0402D218 RID: 184856
		public const int BtnGet = 6;

		// Token: 0x0402D219 RID: 184857
		public const int DoneMaskItem = 7;

		// Token: 0x0402D21A RID: 184858
		public const int TxtAddPointNum = 8;

		// Token: 0x0402D21B RID: 184859
		public const int TexIcon = 9;

		// Token: 0x0402D21C RID: 184860
		public const int TagRoot = 10;

		// Token: 0x0402D21D RID: 184861
		public const int ItemNavigation = 11;
	}
}
