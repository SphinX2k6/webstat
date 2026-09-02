using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200156E RID: 5486
public class RoleGiftSplashView : UiViewBase
{
	// Token: 0x06009A00 RID: 39424 RVA: 0x002851D0 File Offset: 0x002833D0
	[NullableContext(1)]
	public RoleGiftSplashView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06009A01 RID: 39425 RVA: 0x002851DC File Offset: 0x002833DC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnConfirmClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009A02 RID: 39426 RVA: 0x00285282 File Offset: 0x00283482
	protected override void OnBeforeShow()
	{
		this.FinishRoleGiftSplashScreenTask();
	}

	// Token: 0x06009A03 RID: 39427 RVA: 0x0028528A File Offset: 0x0028348A
	private void FinishRoleGiftSplashScreenTask()
	{
		if (this.SplashScreenTaskFinished)
		{
			return;
		}
		this.SplashScreenTaskFinished = true;
		ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.RoleGiftActivity);
	}

	// Token: 0x06009A04 RID: 39428 RVA: 0x002852A8 File Offset: 0x002834A8
	protected override UniTask OnBeforeStartAsync()
	{
		RoleGiftSplashView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleGiftSplashView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009A05 RID: 39429 RVA: 0x002852EB File Offset: 0x002834EB
	protected override void OnStart()
	{
		this.RefreshRoleDesc();
	}

	// Token: 0x06009A06 RID: 39430 RVA: 0x002852F4 File Offset: 0x002834F4
	private unsafe void RefreshRoleDesc()
	{
		RoleGiftData roleGiftDataCached = this.RoleGiftDataCached;
		if (roleGiftDataCached == null)
		{
			return;
		}
		int roleId = roleGiftDataCached.GetRoleId();
		if (roleId > 0)
		{
			RoleDescribeComponent descComponent = this.DescComponent;
			if (descComponent == null)
			{
				return;
			}
			descComponent.Update(roleId, false);
			return;
		}
		else
		{
			string message = "RoleGiftSplashView";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", "invalid_role_id");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("activityId", this.ActivityIdCached);
			RoleGiftUtil.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
	}

	// Token: 0x06009A07 RID: 39431 RVA: 0x00285394 File Offset: 0x00283594
	private unsafe void OnClickLook()
	{
		RoleGiftData roleGiftDataCached = this.RoleGiftDataCached;
		if (roleGiftDataCached == null)
		{
			string message = "RoleGiftSplashView OnClickLook";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", "no_gift_data");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("activityId", this.ActivityIdCached);
			RoleGiftUtil.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		int roleTrialId = roleGiftDataCached.GetRoleTrialId();
		if (roleTrialId == 0)
		{
			string message2 = "RoleGiftSplashView OnClickLook";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("reason", "no_role_trial_id");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("activityId", roleGiftDataCached.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("roleId", roleGiftDataCached.GetRoleId());
			RoleGiftUtil.Debug(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return;
		}
		RoleController instance = ControllerBase<RoleController>.Instance;
		ERoleAgentType agentType = ERoleAgentType.Preview;
		int selectRoleId = 0;
		int num = 1;
		List<int> list = new List<int>(num);
		CollectionsMarshal.SetCount<int>(list, num);
		Span<int> span = CollectionsMarshal.AsSpan<int>(list);
		int index = 0;
		*span[index] = roleTrialId;
		instance.OpenRoleMainView(agentType, selectRoleId, list, null, null);
	}

	// Token: 0x06009A08 RID: 39432 RVA: 0x002854C8 File Offset: 0x002836C8
	private void OnBtnConfirmClick()
	{
		int activityIdCached = this.ActivityIdCached;
		if (activityIdCached <= 0)
		{
			return;
		}
		this.FinishRoleGiftSplashScreenTask();
		SkipTaskManager.Run(ESkipName.SkipToActivity, new object[]
		{
			activityIdCached
		});
		base.CloseMe(null);
	}

	// Token: 0x04004709 RID: 18185
	private int ActivityIdCached;

	// Token: 0x0400470A RID: 18186
	[Nullable(2)]
	private RoleGiftData RoleGiftDataCached;

	// Token: 0x0400470B RID: 18187
	[Nullable(2)]
	private RoleDescribeComponent DescComponent;

	// Token: 0x0400470C RID: 18188
	private bool SplashScreenTaskFinished;

	// Token: 0x02007932 RID: 31026
	private enum ENode
	{
		// Token: 0x04029A48 RID: 170568
		ItemRoleDesc,
		// Token: 0x04029A49 RID: 170569
		BtnConfirm
	}
}
