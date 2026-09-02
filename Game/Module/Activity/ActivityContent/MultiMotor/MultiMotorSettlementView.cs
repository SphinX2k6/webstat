using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006663 RID: 26211
	[NullableContext(2)]
	[Nullable(0)]
	public class MultiMotorSettlementView : UiTickViewBase
	{
		// Token: 0x06041743 RID: 268099 RVA: 0x010CC811 File Offset: 0x010CAA11
		[NullableContext(1)]
		public MultiMotorSettlementView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06041744 RID: 268100 RVA: 0x010CC81C File Offset: 0x010CAA1C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickLeftBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickRightBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041745 RID: 268101 RVA: 0x010CC9AC File Offset: 0x010CABAC
		protected override UniTask OnBeforeStartAsync()
		{
			MultiMotorSettlementView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MultiMotorSettlementView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041746 RID: 268102 RVA: 0x010CC9F0 File Offset: 0x010CABF0
		protected override void OnStart()
		{
			string textStringId = ModelBase<CreatureModel>.Instance.IsMyWorld() ? "Text_ContinueChallenge_Text" : "Text_SuggestContinueChallenge_Text";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), textStringId, Array.Empty<object>());
			this.InitAutoLeaveTimer();
		}

		// Token: 0x06041747 RID: 268103 RVA: 0x010CCA33 File Offset: 0x010CAC33
		protected override void OnBeforeDestroy()
		{
			this.ClearAutoLeaveTimer();
		}

		// Token: 0x06041748 RID: 268104 RVA: 0x010CCA3C File Offset: 0x010CAC3C
		private void InitAutoLeaveTimer()
		{
			int leftSecondToAutoLeave = 300;
			this.AutoLeaveTimerId = TimerSystem.GameplayTimeInstance.Forever(delegate(float elapsed)
			{
				int leftSecondToAutoLeave;
				if (leftSecondToAutoLeave <= 0)
				{
					this.ClearAutoLeaveTimer();
					ControllerBase<OnlineController>.Instance.LeaveWorldTeamRequest(ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault(), null);
					return;
				}
				LguiUtil instance = Singleton<LguiUtil>.Instance;
				UUIText text = this.GetText(4);
				string textStringId = "Text_InstanceDungeonLeftTimeToAutoLeave_Text";
				leftSecondToAutoLeave = leftSecondToAutoLeave;
				leftSecondToAutoLeave--;
				instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlySingleElementList<object>(leftSecondToAutoLeave.ToString()));
			}, 1000f, 1f, null, null, true);
		}

		// Token: 0x06041749 RID: 268105 RVA: 0x010CCA8A File Offset: 0x010CAC8A
		private void ClearAutoLeaveTimer()
		{
			if (this.AutoLeaveTimerId != null && TimerSystem.GameplayTimeInstance.Has(this.AutoLeaveTimerId))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.AutoLeaveTimerId);
			}
			this.AutoLeaveTimerId = null;
		}

		// Token: 0x0604174A RID: 268106 RVA: 0x010CCAC0 File Offset: 0x010CACC0
		private void OnClickLeftBtn()
		{
			ControllerBase<OnlineController>.Instance.LeaveWorldTeamRequest(ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault(), null);
		}

		// Token: 0x0604174B RID: 268107 RVA: 0x010CCAF2 File Offset: 0x010CACF2
		private void OnClickRightBtn()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.SettleViewButtonSuccessOnMultiCallBack(0);
		}

		// Token: 0x0604174C RID: 268108 RVA: 0x010CCB00 File Offset: 0x010CAD00
		[CompilerGenerated]
		internal static OnlineMotorSettleInfo <OnBeforeStartAsync>g__FindByRank|12_0(int rank, ref MultiMotorSettlementView.<>c__DisplayClass12_0 A_1)
		{
			foreach (OnlineMotorSettleInfo onlineMotorSettleInfo in A_1.openData)
			{
				if (onlineMotorSettleInfo.Ranking == rank)
				{
					return onlineMotorSettleInfo;
				}
			}
			return null;
		}

		// Token: 0x0402498D RID: 149901
		[Nullable(1)]
		public const string ABSOLUTE_RULE_CONST = "MultiMotor_Rank_1_AbsoluteRule_Tag";

		// Token: 0x0402498E RID: 149902
		[Nullable(1)]
		public const string DESTROYER_CONST = "MultiMotor_Rank_1_Destroyer_Tag";

		// Token: 0x0402498F RID: 149903
		private const int AUTO_LEAVE_TIME = 300;

		// Token: 0x04024990 RID: 149904
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, OnlineMotorSettleInfo> SettlementDataMap;

		// Token: 0x04024991 RID: 149905
		private MultiMotorSettlementPlayerItem ChampionItem;

		// Token: 0x04024992 RID: 149906
		private MultiMotorSettlementPlayerItem SecondItem;

		// Token: 0x04024993 RID: 149907
		private MultiMotorSettlementPlayerItem ThirdItem;

		// Token: 0x04024994 RID: 149908
		private RewardExploreOnlineChallengePlayer RewardExploreOnlineChallengePlayerInst;

		// Token: 0x04024995 RID: 149909
		private TimerHandle AutoLeaveTimerId;

		// Token: 0x0200C688 RID: 50824
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D210 RID: 250384
			public const int ChampionItem = 0;

			// Token: 0x0403D211 RID: 250385
			public const int SecondItem = 1;

			// Token: 0x0403D212 RID: 250386
			public const int ThirdItem = 2;

			// Token: 0x0403D213 RID: 250387
			public const int LeftBtn = 3;

			// Token: 0x0403D214 RID: 250388
			public const int LeftBtnText = 4;

			// Token: 0x0403D215 RID: 250389
			public const int RightBtn = 5;

			// Token: 0x0403D216 RID: 250390
			public const int RightBtnText = 6;

			// Token: 0x0403D217 RID: 250391
			public const int ItemTeam = 7;
		}
	}
}
