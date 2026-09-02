using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.TrainingDegree;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BBF RID: 23487
	public class InstanceDungeonFailView : UiViewBase
	{
		// Token: 0x0603B758 RID: 243544 RVA: 0x00F1291E File Offset: 0x00F10B1E
		[NullableContext(1)]
		public InstanceDungeonFailView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x1700977A RID: 38778
		// (get) Token: 0x0603B759 RID: 243545 RVA: 0x00F12928 File Offset: 0x00F10B28
		private InstanceDungeon? InstanceConfig
		{
			get
			{
				if (this.InstanceId == 0)
				{
					return null;
				}
				return ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.InstanceId);
			}
		}

		// Token: 0x0603B75A RID: 243546 RVA: 0x00F12958 File Offset: 0x00F10B58
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnLeave));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnAgain));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B75B RID: 243547 RVA: 0x00F12A84 File Offset: 0x00F10C84
		protected override void OnStart()
		{
			this.InstanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ReviveView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ReviveView, null);
			}
			this.InitView();
			this.InitAutoLeaveTimer();
			this.TrainingView = new TrainingView();
			this.TrainingView.Show(base.GetVerticalLayout(4), null);
			base.SetButtonUiActive(2, false);
		}

		// Token: 0x0603B75C RID: 243548 RVA: 0x00F12AF4 File Offset: 0x00F10CF4
		protected override void OnBeforeDestroy()
		{
			TrainingView trainingView = this.TrainingView;
			if (trainingView != null)
			{
				trainingView.Clear();
			}
			this.TrainingView = null;
			this.ClearAutoLeaveTimer();
		}

		// Token: 0x0603B75D RID: 243549 RVA: 0x00F12B14 File Offset: 0x00F10D14
		private void InitView()
		{
			base.GetText(0).ShowTextNew(this.InstanceConfig.Value.FailTips);
		}

		// Token: 0x0603B75E RID: 243550 RVA: 0x00F12B44 File Offset: 0x00F10D44
		private void InitAutoLeaveTimer()
		{
			int leftSecondToAutoLeave = this.InstanceConfig.Value.AutoLeaveTime;
			this.AutoLeaveTimerId = TimerSystem.GameplayTimeInstance.Loop(delegate(float _)
			{
				int leftSecondToAutoLeave;
				if (leftSecondToAutoLeave <= 0)
				{
					this.LeaveInstance();
					return;
				}
				LguiUtil instance = Singleton<LguiUtil>.Instance;
				UUIText text = this.GetText(3);
				string textTableId = "InstanceDungeonLeftTimeToAutoLeave";
				leftSecondToAutoLeave = leftSecondToAutoLeave;
				leftSecondToAutoLeave--;
				instance.SetLocalText(text, textTableId, new <>z__ReadOnlySingleElementList<object>(leftSecondToAutoLeave));
			}, 1000f, leftSecondToAutoLeave + 1, 1f, null, null, true);
		}

		// Token: 0x0603B75F RID: 243551 RVA: 0x00F12BAB File Offset: 0x00F10DAB
		private void ClearAutoLeaveTimer()
		{
			if (this.AutoLeaveTimerId != null && TimerSystem.GameplayTimeInstance.Has(this.AutoLeaveTimerId))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.AutoLeaveTimerId);
			}
			this.AutoLeaveTimerId = null;
		}

		// Token: 0x0603B760 RID: 243552 RVA: 0x00F12BE0 File Offset: 0x00F10DE0
		private UniTask LeaveInstance()
		{
			InstanceDungeonFailView.<LeaveInstance>d__13 <LeaveInstance>d__;
			<LeaveInstance>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LeaveInstance>d__.<>4__this = this;
			<LeaveInstance>d__.<>1__state = -1;
			<LeaveInstance>d__.<>t__builder.Start<InstanceDungeonFailView.<LeaveInstance>d__13>(ref <LeaveInstance>d__);
			return <LeaveInstance>d__.<>t__builder.Task;
		}

		// Token: 0x0603B761 RID: 243553 RVA: 0x00F12C23 File Offset: 0x00F10E23
		private void OnClickBtnLeave()
		{
			this.LeaveInstance();
		}

		// Token: 0x0603B762 RID: 243554 RVA: 0x00F12C2C File Offset: 0x00F10E2C
		private void OnClickBtnAgain()
		{
			this.ClearAutoLeaveTimer();
			ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().ContinueWith(delegate(bool _)
			{
				if (Singleton<UiManager>.Instance.IsViewShow(this.ViewInfo.Name))
				{
					base.CloseMe(null);
				}
			});
		}

		// Token: 0x04021800 RID: 137216
		private int InstanceId;

		// Token: 0x04021801 RID: 137217
		[Nullable(2)]
		private TimerHandle AutoLeaveTimerId;

		// Token: 0x04021802 RID: 137218
		[Nullable(2)]
		private TrainingView TrainingView;

		// Token: 0x0200BC28 RID: 48168
		private static class EChildCom
		{
			// Token: 0x0403A096 RID: 237718
			public const int TextTips = 0;

			// Token: 0x0403A097 RID: 237719
			public const int BtnLeave = 1;

			// Token: 0x0403A098 RID: 237720
			public const int BtnAgain = 2;

			// Token: 0x0403A099 RID: 237721
			public const int TextLeftTime = 3;

			// Token: 0x0403A09A RID: 237722
			public const int RoleTrainingLayout = 4;
		}
	}
}
