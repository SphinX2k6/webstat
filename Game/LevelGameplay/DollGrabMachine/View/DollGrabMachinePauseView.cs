using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006F0A RID: 28426
	[NullableContext(2)]
	[Nullable(0)]
	public class DollGrabMachinePauseView : UiViewBase
	{
		// Token: 0x06044DD0 RID: 282064 RVA: 0x011EB79C File Offset: 0x011E999C
		[NullableContext(1)]
		public DollGrabMachinePauseView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044DD1 RID: 282065 RVA: 0x011EB7A8 File Offset: 0x011E99A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnExitButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnGotoButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044DD2 RID: 282066 RVA: 0x011EB9C0 File Offset: 0x011E9BC0
		protected override void OnStart()
		{
			this.GenericLayout = new GenericLayout<DollGrabMachinePauseItem, IGrabItemData>(base.GetHorizontalLayout(1), new Func<DollGrabMachinePauseItem>(this.CreateDollGrabPauseItem), null, false, true);
			this.PnlEmptyReward = base.GetItem(3);
			this.PnlReward = base.GetItem(6);
			this.PnlEndlessModel = base.GetItem(7);
			this.EndlessCurrentScore = base.GetText(8);
			this.EndlessTotalScore = base.GetText(9);
			this.EndlessSpriteCheck = base.GetSprite(10);
			this.EndlessTxtDescri02 = base.GetText(11);
		}

		// Token: 0x06044DD3 RID: 282067 RVA: 0x011EBA4C File Offset: 0x011E9C4C
		protected override UniTask OnBeforeShowAsyncImplementImplement()
		{
			DollGrabMachinePauseView.<OnBeforeShowAsyncImplementImplement>d__11 <OnBeforeShowAsyncImplementImplement>d__;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<DollGrabMachinePauseView.<OnBeforeShowAsyncImplementImplement>d__11>(ref <OnBeforeShowAsyncImplementImplement>d__);
			return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06044DD4 RID: 282068 RVA: 0x011EBA90 File Offset: 0x011E9C90
		private UniTask RefreshNormalMode()
		{
			DollGrabMachinePauseView.<RefreshNormalMode>d__12 <RefreshNormalMode>d__;
			<RefreshNormalMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshNormalMode>d__.<>4__this = this;
			<RefreshNormalMode>d__.<>1__state = -1;
			<RefreshNormalMode>d__.<>t__builder.Start<DollGrabMachinePauseView.<RefreshNormalMode>d__12>(ref <RefreshNormalMode>d__);
			return <RefreshNormalMode>d__.<>t__builder.Task;
		}

		// Token: 0x06044DD5 RID: 282069 RVA: 0x011EBAD4 File Offset: 0x011E9CD4
		private void RefreshEndlessMode()
		{
			UUIItem pnlEmptyReward = this.PnlEmptyReward;
			if (pnlEmptyReward != null)
			{
				pnlEmptyReward.SetUIActive(false);
			}
			UUIItem pnlReward = this.PnlReward;
			if (pnlReward != null)
			{
				pnlReward.SetUIActive(false);
			}
			UUIItem pnlEndlessModel = this.PnlEndlessModel;
			if (pnlEndlessModel != null)
			{
				pnlEndlessModel.SetUIActive(true);
			}
			IDollGrabInfiniteRewardData endlessRewardData = ControllerBase<DollGrabMachineController>.Instance.EndlessRewardData;
			UUIText endlessCurrentScore = this.EndlessCurrentScore;
			if (endlessCurrentScore != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int?>((endlessRewardData != null) ? new int?(endlessRewardData.CurrentScore) : null);
				endlessCurrentScore.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			UUIText endlessTotalScore = this.EndlessTotalScore;
			if (endlessTotalScore != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int?>((endlessRewardData != null) ? new int?(endlessRewardData.CurrentAccumulatedScore) : null);
				endlessTotalScore.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			UUISprite endlessSpriteCheck = this.EndlessSpriteCheck;
			if (endlessSpriteCheck != null)
			{
				endlessSpriteCheck.SetUIActive(endlessRewardData != null && endlessRewardData.IsFinalReward);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.EndlessTxtDescri02, "KClaw_Infinite_Requirement", new <>z__ReadOnlySingleElementList<object>((endlessRewardData != null) ? endlessRewardData.TargetAccumulatedScore : "0"));
		}

		// Token: 0x06044DD6 RID: 282070 RVA: 0x011EBBF4 File Offset: 0x011E9DF4
		private void OnExitButtonClick()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DollGrabMachineExitConfirm);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				base.CloseMe(null);
				ControllerBase<DollGrabMachineController>.Instance.PreExitDollGrabMachine(EDollGrabMachineEndReason.Exit, true);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06044DD7 RID: 282071 RVA: 0x011EBC30 File Offset: 0x011E9E30
		private void OnGotoButtonClick()
		{
			base.CloseMe(null);
			ControllerBase<DollGrabMachineController>.Instance.ResumeDollGrabMachine();
		}

		// Token: 0x06044DD8 RID: 282072 RVA: 0x011EBC43 File Offset: 0x011E9E43
		[NullableContext(1)]
		private DollGrabMachinePauseItem CreateDollGrabPauseItem()
		{
			return new DollGrabMachinePauseItem();
		}

		// Token: 0x040265F4 RID: 157172
		private UUIItem PnlReward;

		// Token: 0x040265F5 RID: 157173
		private UUIItem PnlEmptyReward;

		// Token: 0x040265F6 RID: 157174
		private UUIItem PnlEndlessModel;

		// Token: 0x040265F7 RID: 157175
		private UUIText EndlessCurrentScore;

		// Token: 0x040265F8 RID: 157176
		private UUIText EndlessTotalScore;

		// Token: 0x040265F9 RID: 157177
		private UUISprite EndlessSpriteCheck;

		// Token: 0x040265FA RID: 157178
		private UUIText EndlessTxtDescri02;

		// Token: 0x040265FB RID: 157179
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DollGrabMachinePauseItem, IGrabItemData> GenericLayout;
	}
}
