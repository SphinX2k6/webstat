using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.DeadRevive;
using CSharpScript.Game.Module.FlagChallenge;
using CSharpScript.Game.Module.TrainingDegree;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F25 RID: 24357
	public class FlagChallengeReviveView : UiTickViewBase
	{
		// Token: 0x0603D2B3 RID: 250547 RVA: 0x00F8B51B File Offset: 0x00F8971B
		[NullableContext(1)]
		public FlagChallengeReviveView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603D2B4 RID: 250548 RVA: 0x00F8B524 File Offset: 0x00F89724
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickRevive));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickGiveUp));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D2B5 RID: 250549 RVA: 0x00F8B760 File Offset: 0x00F89960
		protected override void OnStart()
		{
			this.IsAutoRevived = false;
			this.AutoReviveCountDown = base.GetText(9);
			this.AutoReviveCountDownTime = 60f;
			this.AutoReviveCountDown.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(this.AutoReviveCountDown, "ReviveItemTips", new <>z__ReadOnlySingleElementList<object>(this.AutoReviveCountDownTime));
			UUIText text = base.GetText(5);
			DeadReviveModel instance = ModelBase<DeadReviveModel>.Instance;
			text.ShowTextNew(((instance.ReviveConfig != null) ? instance.ReviveConfig.GetValueOrDefault().ReviveTitle : null) ?? string.Empty);
			UUIText text2 = base.GetText(6);
			DeadReviveModel instance2 = ModelBase<DeadReviveModel>.Instance;
			string key = ((instance2.ReviveConfig != null) ? instance2.ReviveConfig.GetValueOrDefault().ReviveContent : null) ?? "Morale_title_29";
			text2.ShowTextNew(key);
			this.TrainingView = new TrainingView();
			this.TrainingView.Show(base.GetHorizontalLayout(7), ModelBase<FlagChallengeBattleModel>.Instance.GetTrainingDataList());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "Morale_32_Fail_LowLevelButt", Array.Empty<object>());
			base.GetButton(3).RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x0603D2B6 RID: 250550 RVA: 0x00F8B88D File Offset: 0x00F89A8D
		protected override void OnTick(float delta)
		{
			if (this.IsAutoRevived)
			{
				return;
			}
			this.TimeCount += delta;
			if (this.TimeCount >= 1000f)
			{
				this.TimeCount = 0f;
				this.AutoReviveOnTick();
			}
		}

		// Token: 0x0603D2B7 RID: 250551 RVA: 0x00F8B8C4 File Offset: 0x00F89AC4
		protected override void OnBeforeDestroy()
		{
			TrainingView trainingView = this.TrainingView;
			if (trainingView != null)
			{
				trainingView.Clear();
			}
			this.TrainingView = null;
			this.AutoReviveCountDown = null;
			this.TimeCount = 0f;
			this.AutoReviveCountDownTime = 0f;
			this.IsAutoRevived = false;
			ModelBase<DeadReviveModel>.Instance.ClearExternalHandles();
		}

		// Token: 0x0603D2B8 RID: 250552 RVA: 0x00F8B918 File Offset: 0x00F89B18
		private void AutoReviveOnTick()
		{
			if (this.IsAutoRevived)
			{
				return;
			}
			if (this.AutoReviveCountDownTime <= 0f)
			{
				this.IsAutoRevived = true;
				this.OnClickRevive();
				return;
			}
			this.AutoReviveCountDownTime -= 1f;
			Singleton<LguiUtil>.Instance.SetLocalText(this.AutoReviveCountDown, "ReviveItemTips", new <>z__ReadOnlySingleElementList<object>(this.AutoReviveCountDownTime));
		}

		// Token: 0x0603D2B9 RID: 250553 RVA: 0x00F8B980 File Offset: 0x00F89B80
		private void OnClickRevive()
		{
			ControllerBase<DeadReviveController>.Instance.ReviveRequest(false, null, new int?(0));
			base.CloseMe(null);
		}

		// Token: 0x0603D2BA RID: 250554 RVA: 0x00F8B99C File Offset: 0x00F89B9C
		private void OnClickGiveUp()
		{
			int activityId = ModelBase<FlagChallengeBattleModel>.Instance.ActivityId;
			int levelId = ModelBase<FlagChallengeBattleModel>.Instance.LevelId;
			int levelRecommendStrongholdId = ModelBase<FlagChallengeModel>.Instance.GetLevelRecommendStrongholdId(activityId, levelId, null);
			ControllerBase<DeadReviveController>.Instance.ReviveRequest(false, null, new int?(levelRecommendStrongholdId));
			base.CloseMe(null);
		}

		// Token: 0x040224D3 RID: 140499
		private const float TIME_SECOND = 1000f;

		// Token: 0x040224D4 RID: 140500
		private const float AUTO_REVIVE_TIME = 60f;

		// Token: 0x040224D5 RID: 140501
		private float TimeCount;

		// Token: 0x040224D6 RID: 140502
		private bool IsAutoRevived;

		// Token: 0x040224D7 RID: 140503
		private float AutoReviveCountDownTime;

		// Token: 0x040224D8 RID: 140504
		[Nullable(2)]
		private UUIText AutoReviveCountDown;

		// Token: 0x040224D9 RID: 140505
		[Nullable(2)]
		private TrainingView TrainingView;

		// Token: 0x0200BF2E RID: 48942
		private enum EComponentType
		{
			// Token: 0x0403AD86 RID: 241030
			Revive,
			// Token: 0x0403AD87 RID: 241031
			Fail,
			// Token: 0x0403AD88 RID: 241032
			ReviveBtn,
			// Token: 0x0403AD89 RID: 241033
			GiveUpBtn,
			// Token: 0x0403AD8A RID: 241034
			WaitTime,
			// Token: 0x0403AD8B RID: 241035
			ReviveTitle,
			// Token: 0x0403AD8C RID: 241036
			ReviveContent,
			// Token: 0x0403AD8D RID: 241037
			RoleTrainingLayout,
			// Token: 0x0403AD8E RID: 241038
			ReviveAtLocationBtn,
			// Token: 0x0403AD8F RID: 241039
			AutoReviveCountDownText,
			// Token: 0x0403AD90 RID: 241040
			ItemTexture,
			// Token: 0x0403AD91 RID: 241041
			ItemText,
			// Token: 0x0403AD92 RID: 241042
			GiveUpBtnText
		}
	}
}
