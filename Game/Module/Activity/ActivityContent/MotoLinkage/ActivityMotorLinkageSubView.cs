using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotoLinkage
{
	// Token: 0x02006714 RID: 26388
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityMotorLinkageSubView : ActivitySubViewBase
	{
		// Token: 0x1700A09F RID: 41119
		// (get) Token: 0x06041D65 RID: 269669 RVA: 0x010E4663 File Offset: 0x010E2863
		[Nullable(2)]
		private ActivityMotorLinkageData MotorData
		{
			[NullableContext(2)]
			get
			{
				return this.ActivityBaseData as ActivityMotorLinkageData;
			}
		}

		// Token: 0x06041D66 RID: 269670 RVA: 0x010E4670 File Offset: 0x010E2870
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
		}

		// Token: 0x06041D67 RID: 269671 RVA: 0x010E4738 File Offset: 0x010E2938
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityMotorLinkageSubView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityMotorLinkageSubView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041D68 RID: 269672 RVA: 0x010E477B File Offset: 0x010E297B
		protected override void OnStart()
		{
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel != null)
			{
				commonInfoPanel.SetBtnText("MotorLinkage_Go", Array.Empty<object>());
			}
			ActivityMotorLinkageData motorData = this.MotorData;
			if (motorData == null)
			{
				return;
			}
			motorData.ReadRedDot();
		}

		// Token: 0x06041D69 RID: 269673 RVA: 0x010E47A8 File Offset: 0x010E29A8
		protected override void OnRefreshView()
		{
			foreach (MotorLinkageButton motorLinkageButton in this.ButtonList)
			{
				motorLinkageButton.Refresh();
			}
			this.RefreshProgress();
			this.RefreshRedDot();
			this.RefreshTab();
		}

		// Token: 0x06041D6A RID: 269674 RVA: 0x010E480C File Offset: 0x010E2A0C
		protected override void OnBeforeDestroy()
		{
			this.CancelResetTimerHandle();
		}

		// Token: 0x06041D6B RID: 269675 RVA: 0x010E4814 File Offset: 0x010E2A14
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRedDotRefresh));
		}

		// Token: 0x06041D6C RID: 269676 RVA: 0x010E4832 File Offset: 0x010E2A32
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRedDotRefresh));
		}

		// Token: 0x06041D6D RID: 269677 RVA: 0x010E4850 File Offset: 0x010E2A50
		private void OnRedDotRefresh(int activityId)
		{
			ActivityMotorLinkageData motorData = this.MotorData;
			int? num = (motorData != null) ? new int?(motorData.Id) : null;
			if (!(activityId == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			this.OnRefreshView();
		}

		// Token: 0x06041D6E RID: 269678 RVA: 0x010E4898 File Offset: 0x010E2A98
		private void RefreshTab()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityTab, this.MotorData.Id);
		}

		// Token: 0x06041D6F RID: 269679 RVA: 0x010E48B8 File Offset: 0x010E2AB8
		public override void PlaySubViewSequence(string name, bool blockClick = false)
		{
			string name2 = name;
			if (name == "ShowView")
			{
				ActivityMotorLinkageData motorData = this.MotorData;
				if (motorData != null && motorData.CanSubViewPlayShowView())
				{
					name2 = "ShowView02";
				}
				else
				{
					name2 = "ShowView01";
				}
			}
			base.PlaySubViewSequence(name2, blockClick);
		}

		// Token: 0x06041D70 RID: 269680 RVA: 0x010E4900 File Offset: 0x010E2B00
		private void RefreshProgress()
		{
			int allIpCurrentProgress = this.MotorData.GetAllIpCurrentProgress();
			int allIpTotalProgress = this.MotorData.GetAllIpTotalProgress();
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(allIpCurrentProgress.ToString() + "/" + allIpTotalProgress.ToString(), true);
		}

		// Token: 0x06041D71 RID: 269681 RVA: 0x010E4950 File Offset: 0x010E2B50
		private void RefreshRedDot()
		{
			bool flag = this.MotorData.HasAnyRewardCanReceive();
			bool flag2 = this.MotorData.HasSkipRedDot();
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel == null)
			{
				return;
			}
			commonInfoPanel.SetFunctionRedDotVisible(flag2 || flag);
		}

		// Token: 0x06041D72 RID: 269682 RVA: 0x010E4988 File Offset: 0x010E2B88
		private UniTask CreateButtonList()
		{
			ActivityMotorLinkageSubView.<CreateButtonList>d__22 <CreateButtonList>d__;
			<CreateButtonList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateButtonList>d__.<>4__this = this;
			<CreateButtonList>d__.<>1__state = -1;
			<CreateButtonList>d__.<>t__builder.Start<ActivityMotorLinkageSubView.<CreateButtonList>d__22>(ref <CreateButtonList>d__);
			return <CreateButtonList>d__.<>t__builder.Task;
		}

		// Token: 0x06041D73 RID: 269683 RVA: 0x010E49CC File Offset: 0x010E2BCC
		private void OnClickDetail()
		{
			Singleton<EventSystem>.Instance.Emit<bool, EActivityViewState, bool?>(EEventName.SetActivityViewState, false, EActivityViewState.Side, null);
			ActivityMotorLinkageData motorData = this.MotorData;
			if (motorData == null)
			{
				return;
			}
			motorData.ReadSkipRedDot();
		}

		// Token: 0x06041D74 RID: 269684 RVA: 0x010E4A04 File Offset: 0x010E2C04
		private void OnButtonClick(int ipId)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorLinkageRewardView, ipId, null);
			this.CancelTimerAndResetState();
			ActivityMotorLinkageData motorData = this.MotorData;
			if (motorData == null)
			{
				return;
			}
			motorData.SetCanSubViewPlayShowView(true);
		}

		// Token: 0x06041D75 RID: 269685 RVA: 0x010E4A34 File Offset: 0x010E2C34
		public override void OnCommonViewStateChange(bool show)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopPlayingSequence(false, true);
			}
			string sequenceName = show ? "ShowView01" : "HideView01";
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlaySequencePurely(sequenceName, true, false, null, null, false);
			}
			if (show)
			{
				this.CancelTimerAndResetState();
			}
		}

		// Token: 0x06041D76 RID: 269686 RVA: 0x010E4A8C File Offset: 0x010E2C8C
		private void OnButtonEnter(int ipId)
		{
			int num = this.IpToIndex(ipId);
			if (this.PlayerStateList == null)
			{
				this.PlayerStateList = new bool[this.roleAnimNameDefine.Length];
				for (int i = 0; i < this.PlayerStateList.Length; i++)
				{
					this.PlayerStateList[i] = true;
				}
			}
			this.CancelResetTimerHandle();
			bool flag = true;
			bool[] playerStateList = this.PlayerStateList;
			for (int j = 0; j < playerStateList.Length; j++)
			{
				if (!playerStateList[j])
				{
					flag = false;
					break;
				}
			}
			for (int k = 0; k < this.roleAnimNameDefine.Length; k++)
			{
				string[] array = this.roleAnimNameDefine[k];
				bool flag2 = num == k;
				if (flag2)
				{
					UUIItem item = base.GetItem(this.fxDefineList[k]);
					if (item != null)
					{
						item.SetUIActive(true);
					}
					UUIItem item2 = base.GetItem(this.fxDefineList[k]);
					if (item2 != null)
					{
						item2.SetAlpha(1f);
					}
				}
				if (this.PlayerStateList[k] != flag2 || flag)
				{
					this.PlayerStateList[k] = flag2;
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer != null)
					{
						levelSequencePlayer.StopSequenceByKey(array[(!flag2) ? 1 : 0], false, false);
					}
					LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
					if (levelSequencePlayer2 != null)
					{
						levelSequencePlayer2.PlaySequencePurely(array[(flag2 > false) ? 1 : 0], false, false, null, null, false);
					}
				}
			}
		}

		// Token: 0x06041D77 RID: 269687 RVA: 0x010E4BCD File Offset: 0x010E2DCD
		private void OnButtonExit()
		{
			this.CancelResetTimerHandle();
			this.StartResetTimerHandle();
		}

		// Token: 0x06041D78 RID: 269688 RVA: 0x010E4BDB File Offset: 0x010E2DDB
		private void CancelTimerAndResetState()
		{
			this.CancelResetTimerHandle();
			this.ResetState();
		}

		// Token: 0x06041D79 RID: 269689 RVA: 0x010E4BEC File Offset: 0x010E2DEC
		private void ResetState()
		{
			if (this.PlayerStateList == null)
			{
				return;
			}
			for (int i = 0; i < this.roleAnimNameDefine.Length; i++)
			{
				string[] array = this.roleAnimNameDefine[i];
				int name = this.fxDefineList[i];
				UUIItem item = base.GetItem(name);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				if (!this.PlayerStateList[i])
				{
					this.PlayerStateList[i] = true;
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer != null)
					{
						levelSequencePlayer.StopSequenceByKey(array[0], false, false);
					}
					LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
					if (levelSequencePlayer2 != null)
					{
						levelSequencePlayer2.PlaySequencePurely(array[1], false, false, null, null, false);
					}
				}
			}
		}

		// Token: 0x06041D7A RID: 269690 RVA: 0x010E4C84 File Offset: 0x010E2E84
		private void CancelResetTimerHandle()
		{
			if (this.ResetStateHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.ResetStateHandle);
				this.ResetStateHandle = null;
			}
		}

		// Token: 0x06041D7B RID: 269691 RVA: 0x010E4CA6 File Offset: 0x010E2EA6
		private void StartResetTimerHandle()
		{
			this.ResetStateHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.ResetState();
				this.ResetStateHandle = null;
			}, 2000f, null, null, true, 1f);
		}

		// Token: 0x06041D7C RID: 269692 RVA: 0x010E4CD4 File Offset: 0x010E2ED4
		private int IpToIndex(int ipId)
		{
			return ControllerBase<ActivityMotorLinkageController>.Instance.ActivityData.GetSortedIpList().FindIndex((int id) => id == ipId);
		}

		// Token: 0x04024BD8 RID: 150488
		private string[][] roleAnimNameDefine = new string[][]
		{
			new string[]
			{
				"RoleLDark",
				"RoleLBright"
			},
			new string[]
			{
				"RoleMDark",
				"RoleMBright"
			},
			new string[]
			{
				"RoleRDark",
				"RoleRBright"
			}
		};

		// Token: 0x04024BD9 RID: 150489
		private int[] fxDefineList = new int[]
		{
			6,
			7,
			5
		};

		// Token: 0x04024BDA RID: 150490
		private int[] buttonDefineList = new int[]
		{
			2,
			3,
			4
		};

		// Token: 0x04024BDB RID: 150491
		private const int RESET_TIME_MS = 2000;

		// Token: 0x04024BDC RID: 150492
		[Nullable(2)]
		private ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x04024BDD RID: 150493
		private readonly List<MotorLinkageButton> ButtonList = new List<MotorLinkageButton>();

		// Token: 0x04024BDE RID: 150494
		[Nullable(2)]
		private bool[] PlayerStateList;

		// Token: 0x04024BDF RID: 150495
		[Nullable(2)]
		private TimerHandle ResetStateHandle;
	}
}
