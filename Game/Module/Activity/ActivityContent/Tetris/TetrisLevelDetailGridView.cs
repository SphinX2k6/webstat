using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062C7 RID: 25287
	public class TetrisLevelDetailGridView : GridProxyAbstract<Tetris>
	{
		// Token: 0x0603F9E2 RID: 260578 RVA: 0x0104E19C File Offset: 0x0104C39C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickedEnterButton))
			};
		}

		// Token: 0x0603F9E3 RID: 260579 RVA: 0x0104E245 File Offset: 0x0104C445
		protected override void OnStart()
		{
			this.AddEventListener();
		}

		// Token: 0x0603F9E4 RID: 260580 RVA: 0x0104E24D File Offset: 0x0104C44D
		protected void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnTetrisChallengeStateUpdate, new Action<int>(this.OnTetrisChallengeStateUpdate));
		}

		// Token: 0x0603F9E5 RID: 260581 RVA: 0x0104E26B File Offset: 0x0104C46B
		protected void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnTetrisChallengeStateUpdate, new Action<int>(this.OnTetrisChallengeStateUpdate));
		}

		// Token: 0x0603F9E6 RID: 260582 RVA: 0x0104E289 File Offset: 0x0104C489
		public override void Refresh(Tetris data, bool isSelected, int gridIndex)
		{
			this.ChallengeConfig = new Tetris?(data);
			this.RefreshTitle();
			this.RefreshLockAndComplete();
		}

		// Token: 0x0603F9E7 RID: 260583 RVA: 0x0104E2A4 File Offset: 0x0104C4A4
		public int? GetChallengeDifficulty()
		{
			if (this.ChallengeConfig == null)
			{
				return null;
			}
			return new int?(this.ChallengeConfig.Value.Mode);
		}

		// Token: 0x0603F9E8 RID: 260584 RVA: 0x0104E2E0 File Offset: 0x0104C4E0
		private void RefreshLockAndComplete()
		{
			ActivityTetrisData tetrisData = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData();
			if (tetrisData == null || this.ChallengeConfig == null)
			{
				return;
			}
			bool flag = tetrisData.CheckPreChallengeComplete(this.ChallengeConfig.Value.Id);
			bool uiactive = tetrisData.CheckChallengeComplete(this.ChallengeConfig.Value.Id);
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(uiactive);
		}

		// Token: 0x0603F9E9 RID: 260585 RVA: 0x0104E368 File Offset: 0x0104C568
		private void RefreshTitle()
		{
			string textStringId = (this.ChallengeConfig != null && this.ChallengeConfig.GetValueOrDefault().Mode == 0) ? "Tetristext_06" : "Tetristext_07";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
		}

		// Token: 0x0603F9EA RID: 260586 RVA: 0x0104E3BD File Offset: 0x0104C5BD
		public void SetToggleActive(bool selected)
		{
			this.IsSelected = selected;
			this.RefreshToggleState();
			this.SetClickRedDotState();
		}

		// Token: 0x0603F9EB RID: 260587 RVA: 0x0104E3D4 File Offset: 0x0104C5D4
		private void RefreshToggleState()
		{
			if (ControllerBase<ActivityTetrisController>.Instance.GetTetrisData() == null || this.ChallengeConfig == null)
			{
				return;
			}
			EToggleState state = EToggleState.ETT_UnChecked;
			if (this.IsSelected)
			{
				state = EToggleState.ETT_Checked;
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, false, false, false);
		}

		// Token: 0x0603F9EC RID: 260588 RVA: 0x0104E41D File Offset: 0x0104C61D
		private void OnTetrisChallengeStateUpdate(int challengeId)
		{
			this.RefreshLockAndComplete();
			this.RefreshToggleState();
		}

		// Token: 0x0603F9ED RID: 260589 RVA: 0x0104E42C File Offset: 0x0104C62C
		private void OnClickedEnterButton(EToggleState state)
		{
			if (this.ChallengeConfig == null)
			{
				return;
			}
			if (ControllerBase<ActivityTetrisController>.Instance.GetTetrisData() == null)
			{
				return;
			}
			(Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TetrisLevelDetailView) as TetrisLevelDetailView).ChangeDifficultyIndex(this.ChallengeConfig.Value.Mode);
			if (state == EToggleState.ETT_Checked)
			{
				this.SetClickRedDotState();
			}
		}

		// Token: 0x0603F9EE RID: 260590 RVA: 0x0104E48C File Offset: 0x0104C68C
		public void SetClickRedDotState()
		{
			int activityId = ControllerBase<ActivityTetrisController>.Instance.ActivityId;
			ModelBase<ActivityModel>.Instance.SaveActivityData(activityId, 10001, this.ChallengeConfig.Value.Id, 0, 1);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}

		// Token: 0x0603F9EF RID: 260591 RVA: 0x0104E4DA File Offset: 0x0104C6DA
		protected override void OnBeforeDestroy()
		{
			this.RemoveEventListener();
		}

		// Token: 0x04023B50 RID: 146256
		private Tetris? ChallengeConfig;

		// Token: 0x04023B51 RID: 146257
		private bool IsSelected;
	}
}
