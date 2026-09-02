using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RacingBets.View.Item.RacingBetsMatchTable
{
	// Token: 0x0200529C RID: 21148
	public class RacingBetsEliminationMatchPanel : UiPanelBase
	{
		// Token: 0x06036151 RID: 221521 RVA: 0x00D9DA5C File Offset: 0x00D9BC5C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem))
			};
		}

		// Token: 0x06036152 RID: 221522 RVA: 0x00D9DBC4 File Offset: 0x00D9BDC4
		protected override void OnBeforeCreate()
		{
			this.UiLevelSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiLevelSequence);
		}

		// Token: 0x06036153 RID: 221523 RVA: 0x00D9DBE0 File Offset: 0x00D9BDE0
		protected override UniTask OnBeforeStartAsync()
		{
			RacingBetsEliminationMatchPanel.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsEliminationMatchPanel.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036154 RID: 221524 RVA: 0x00D9DC24 File Offset: 0x00D9BE24
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			RacingBetsEliminationMatchPanel.<OnBeforeShowAsyncImplement>d__10 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<RacingBetsEliminationMatchPanel.<OnBeforeShowAsyncImplement>d__10>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06036155 RID: 221525 RVA: 0x00D9DC68 File Offset: 0x00D9BE68
		private void RefreshLine()
		{
			int[] groupMatchListArray = ConfigBase<RacingBetsConfig>.Instance.GetMatchTableConfigById(2).Value.GetGroupMatchListArray();
			for (int i = 0; i < groupMatchListArray.Length - 1; i++)
			{
				RacingBetsGroupMatchData racingBetsGroupMatchData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsGroupMatchData(groupMatchListArray[i]);
				int name = i;
				UUIItem item = base.GetItem(name);
				if (item != null)
				{
					item.SetUIActive(racingBetsGroupMatchData.IsGroupMatchFinished());
				}
			}
		}

		// Token: 0x06036156 RID: 221526 RVA: 0x00D9DCD0 File Offset: 0x00D9BED0
		public UniTask PlayAnim()
		{
			RacingBetsEliminationMatchPanel.<PlayAnim>d__12 <PlayAnim>d__;
			<PlayAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAnim>d__.<>4__this = this;
			<PlayAnim>d__.<>1__state = -1;
			<PlayAnim>d__.<>t__builder.Start<RacingBetsEliminationMatchPanel.<PlayAnim>d__12>(ref <PlayAnim>d__);
			return <PlayAnim>d__.<>t__builder.Task;
		}

		// Token: 0x06036157 RID: 221527 RVA: 0x00D9DD14 File Offset: 0x00D9BF14
		public void ResetItemAlpha()
		{
			foreach (RacingBetsMatchItemBase racingBetsMatchItemBase in this.MatchItemList)
			{
				racingBetsMatchItemBase.GetRootItem().Alpha = 0f;
			}
		}

		// Token: 0x0401F125 RID: 127269
		private const int GROUP_MATCH_NUM = 7;

		// Token: 0x0401F126 RID: 127270
		private const int ADVANCED_INDEX = 5;

		// Token: 0x0401F127 RID: 127271
		private const int FAILURE_INDEX1 = 2;

		// Token: 0x0401F128 RID: 127272
		private const int FAILURE_INDEX2 = 4;

		// Token: 0x0401F129 RID: 127273
		[Nullable(2)]
		public UiBehaviorLevelSequence UiLevelSequence;

		// Token: 0x0401F12A RID: 127274
		[Nullable(1)]
		private readonly List<RacingBetsMatchItemBase> MatchItemList = new List<RacingBetsMatchItemBase>();

		// Token: 0x0200B207 RID: 45575
		private class EComponent
		{
			// Token: 0x040372F1 RID: 226033
			public const int ItemLine1 = 0;

			// Token: 0x040372F2 RID: 226034
			public const int ItemLine2 = 1;

			// Token: 0x040372F3 RID: 226035
			public const int ItemLine3 = 2;

			// Token: 0x040372F4 RID: 226036
			public const int ItemLine4 = 3;

			// Token: 0x040372F5 RID: 226037
			public const int ItemLine5 = 4;

			// Token: 0x040372F6 RID: 226038
			public const int ItemPos1 = 5;

			// Token: 0x040372F7 RID: 226039
			public const int ItemPos2 = 6;

			// Token: 0x040372F8 RID: 226040
			public const int ItemPos3 = 7;

			// Token: 0x040372F9 RID: 226041
			public const int ItemPos4 = 8;

			// Token: 0x040372FA RID: 226042
			public const int ItemPos5 = 9;

			// Token: 0x040372FB RID: 226043
			public const int ItemPos6 = 10;

			// Token: 0x040372FC RID: 226044
			public const int ItemPos7 = 11;

			// Token: 0x040372FD RID: 226045
			public const int ScrollView = 12;

			// Token: 0x040372FE RID: 226046
			public const int Content = 13;

			// Token: 0x040372FF RID: 226047
			public const int ItemLeftIcon = 14;

			// Token: 0x04037300 RID: 226048
			public const int ItemRightIcon = 15;
		}
	}
}
