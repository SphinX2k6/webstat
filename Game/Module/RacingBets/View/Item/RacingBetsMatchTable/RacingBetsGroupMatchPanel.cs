using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RacingBets.View.Item.RacingBetsMatchTable
{
	// Token: 0x0200529E RID: 21150
	public class RacingBetsGroupMatchPanel : UiPanelBase
	{
		// Token: 0x06036160 RID: 221536 RVA: 0x00D9E0B4 File Offset: 0x00D9C2B4
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
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
		}

		// Token: 0x06036161 RID: 221537 RVA: 0x00D9E17C File Offset: 0x00D9C37C
		protected override void OnBeforeCreate()
		{
			this.UiLevelSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiLevelSequence);
		}

		// Token: 0x06036162 RID: 221538 RVA: 0x00D9E198 File Offset: 0x00D9C398
		protected override UniTask OnBeforeStartAsync()
		{
			RacingBetsGroupMatchPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsGroupMatchPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036163 RID: 221539 RVA: 0x00D9E1DC File Offset: 0x00D9C3DC
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			RacingBetsGroupMatchPanel.<OnBeforeShowAsyncImplement>d__8 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<RacingBetsGroupMatchPanel.<OnBeforeShowAsyncImplement>d__8>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06036164 RID: 221540 RVA: 0x00D9E220 File Offset: 0x00D9C420
		private void RefreshLine()
		{
			int[] groupMatchListArray = ConfigBase<RacingBetsConfig>.Instance.GetMatchTableConfigById(1).Value.GetGroupMatchListArray();
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

		// Token: 0x06036165 RID: 221541 RVA: 0x00D9E288 File Offset: 0x00D9C488
		public UniTask PlayAnim()
		{
			RacingBetsGroupMatchPanel.<PlayAnim>d__10 <PlayAnim>d__;
			<PlayAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAnim>d__.<>4__this = this;
			<PlayAnim>d__.<>1__state = -1;
			<PlayAnim>d__.<>t__builder.Start<RacingBetsGroupMatchPanel.<PlayAnim>d__10>(ref <PlayAnim>d__);
			return <PlayAnim>d__.<>t__builder.Task;
		}

		// Token: 0x06036166 RID: 221542 RVA: 0x00D9E2CC File Offset: 0x00D9C4CC
		public void ResetItemAlpha()
		{
			foreach (RacingBetsMatchItemBase racingBetsMatchItemBase in this.MatchItemList)
			{
				racingBetsMatchItemBase.GetRootItem().Alpha = 0f;
			}
		}

		// Token: 0x0401F12E RID: 127278
		private const int GROUP_MATCH_NUM = 5;

		// Token: 0x0401F12F RID: 127279
		private const int ADVANCED_INDEX = 3;

		// Token: 0x0401F130 RID: 127280
		[Nullable(2)]
		public UiBehaviorLevelSequence UiLevelSequence;

		// Token: 0x0401F131 RID: 127281
		[Nullable(1)]
		private readonly List<RacingBetsMatchItemBase> MatchItemList = new List<RacingBetsMatchItemBase>();

		// Token: 0x0200B20F RID: 45583
		private class EComponent
		{
			// Token: 0x04037329 RID: 226089
			public const int ItemLine1 = 0;

			// Token: 0x0403732A RID: 226090
			public const int ItemLine2 = 1;

			// Token: 0x0403732B RID: 226091
			public const int ItemLine3 = 2;

			// Token: 0x0403732C RID: 226092
			public const int ItemPos1 = 3;

			// Token: 0x0403732D RID: 226093
			public const int ItemPos2 = 4;

			// Token: 0x0403732E RID: 226094
			public const int ItemPos3 = 5;

			// Token: 0x0403732F RID: 226095
			public const int ItemPos4 = 6;

			// Token: 0x04037330 RID: 226096
			public const int ItemPos5 = 7;
		}
	}
}
