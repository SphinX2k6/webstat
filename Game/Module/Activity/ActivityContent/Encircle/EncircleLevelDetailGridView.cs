using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006870 RID: 26736
	public class EncircleLevelDetailGridView : GridProxyAbstract<int>
	{
		// Token: 0x06042A14 RID: 272916 RVA: 0x01119A38 File Offset: 0x01117C38
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickedEnterButton))
			};
		}

		// Token: 0x06042A15 RID: 272917 RVA: 0x01119B23 File Offset: 0x01117D23
		protected override void OnStart()
		{
			this.AddEventListener();
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnUndeterminedClicked.Add(new Action(this.OnClickToggleOnUndetermined));
		}

		// Token: 0x06042A16 RID: 272918 RVA: 0x01119B4D File Offset: 0x01117D4D
		protected void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<EncircleChallengePb>(EEventName.EncircleDataUpdate, new Action<EncircleChallengePb>(this.OnEncircleDataUpdate));
		}

		// Token: 0x06042A17 RID: 272919 RVA: 0x01119B6B File Offset: 0x01117D6B
		protected void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.EncircleDataUpdate, new Action<EncircleChallengePb>(this.OnEncircleDataUpdate));
		}

		// Token: 0x06042A18 RID: 272920 RVA: 0x01119B89 File Offset: 0x01117D89
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.RefreshView(data);
			this.RefreshDesc();
		}

		// Token: 0x06042A19 RID: 272921 RVA: 0x01119B98 File Offset: 0x01117D98
		public int? GetChallengeDifficulty()
		{
			if (this.ChallengeConfig == null)
			{
				return null;
			}
			return new int?(this.ChallengeConfig.Value.Difficulty);
		}

		// Token: 0x06042A1A RID: 272922 RVA: 0x01119BD4 File Offset: 0x01117DD4
		private void RefreshDesc()
		{
			string textStringId = "EncircleLevelType_Single";
			if (this.GetChallengeDifficulty().GetValueOrDefault() == 1)
			{
				textStringId = "EncircleLevelType_Couple";
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textStringId, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), textStringId, Array.Empty<object>());
		}

		// Token: 0x06042A1B RID: 272923 RVA: 0x01119C2C File Offset: 0x01117E2C
		private void RefreshView(int data)
		{
			this.ChallengeId = data;
			this.ChallengeConfig = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleChallengeConfig(this.ChallengeId);
			ActivityEncircleData encircleData = ControllerBase<ActivityEncircleController>.Instance.GetEncircleData();
			this.IsFinish = encircleData.CheckChallengeComplete(this.ChallengeId);
			this.IsPrevFinish = (this.ChallengeConfig.Value.PreId == 0 || encircleData.CheckChallengeComplete(this.ChallengeConfig.Value.PreId));
			if (this.IsPrevFinish)
			{
				this.SetToggleActive();
			}
			this.RefreshComplete();
			this.RefreshRecord();
		}

		// Token: 0x06042A1C RID: 272924 RVA: 0x01119CC4 File Offset: 0x01117EC4
		private void RefreshRecord()
		{
			if (this.IsFinish)
			{
				ActivityEncircleData encircleData = ControllerBase<ActivityEncircleController>.Instance.GetEncircleData();
				UUIText text = base.GetText(4);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(4), "Encircle_FewestSteps", new <>z__ReadOnlySingleElementList<object>(encircleData.GetChallengeRecord(this.ChallengeId)));
				return;
			}
			UUIText text2 = base.GetText(4);
			if (text2 == null)
			{
				return;
			}
			text2.SetUIActive(false);
		}

		// Token: 0x06042A1D RID: 272925 RVA: 0x01119D38 File Offset: 0x01117F38
		private void RefreshComplete()
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(this.IsFinish);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(this.IsPrevFinish);
			}
			UUIItem item3 = base.GetItem(5);
			if (item3 != null)
			{
				item3.SetUIActive(!this.IsPrevFinish);
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(this.IsPrevFinish ? EToggleState.ETT_Checked : EToggleState.ETT_UnDetermined, false, false, false);
		}

		// Token: 0x06042A1E RID: 272926 RVA: 0x01119DB1 File Offset: 0x01117FB1
		public void SetToggleActive()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
			this.SetClickRedDotState();
		}

		// Token: 0x06042A1F RID: 272927 RVA: 0x01119DD0 File Offset: 0x01117FD0
		[NullableContext(1)]
		private void OnEncircleDataUpdate(EncircleChallengePb newData)
		{
			this.RefreshView(this.ChallengeId);
		}

		// Token: 0x06042A20 RID: 272928 RVA: 0x01119DE0 File Offset: 0x01117FE0
		private void OnClickToggleOnUndetermined()
		{
			string levelTitle = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleChallengeConfig(this.ChallengeConfig.Value.PreId).Value.LevelTitle;
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(levelTitle, levelTitle);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Encirle_DifficultyLockTips_Text", new object[]
			{
				multiTextByKey
			});
		}

		// Token: 0x06042A21 RID: 272929 RVA: 0x01119E44 File Offset: 0x01118044
		private void OnClickedEnterButton(EToggleState state)
		{
			if (this.ChallengeConfig == null)
			{
				return;
			}
			if (!this.IsPrevFinish)
			{
				return;
			}
			(Singleton<UiManager>.Instance.GetViewByName(EUiViewName.EncircleLevelDetailView) as EncircleLevelDetailView).ChangeDifficultyIndex(this.ChallengeConfig.Value.Difficulty);
			if (state == EToggleState.ETT_Checked)
			{
				this.SetClickRedDotState();
			}
		}

		// Token: 0x06042A22 RID: 272930 RVA: 0x01119EA0 File Offset: 0x011180A0
		public void SetClickRedDotState()
		{
			int activityId = ControllerBase<ActivityEncircleController>.Instance.ActivityId;
			ModelBase<ActivityModel>.Instance.SaveActivityData(activityId, 10001, this.ChallengeId, 0, 1);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}

		// Token: 0x06042A23 RID: 272931 RVA: 0x01119EE1 File Offset: 0x011180E1
		protected override void OnBeforeDestroy()
		{
			this.RemoveEventListener();
		}

		// Token: 0x0402514C RID: 151884
		private int ChallengeId;

		// Token: 0x0402514D RID: 151885
		private bool IsFinish;

		// Token: 0x0402514E RID: 151886
		private bool IsPrevFinish;

		// Token: 0x0402514F RID: 151887
		private EncircleChallenge? ChallengeConfig;
	}
}
