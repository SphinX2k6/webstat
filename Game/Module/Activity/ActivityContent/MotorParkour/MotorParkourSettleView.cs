using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066C1 RID: 26305
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorParkourSettleView : UiViewBase
	{
		// Token: 0x06041AE3 RID: 269027 RVA: 0x010D7A90 File Offset: 0x010D5C90
		public MotorParkourSettleView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041AE4 RID: 269028 RVA: 0x010D7A9C File Offset: 0x010D5C9C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 18;
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
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnReChallengeBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnExitBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041AE5 RID: 269029 RVA: 0x010D7D80 File Offset: 0x010D5F80
		protected override void OnBeforeShow()
		{
			MotorParkourSettleView.IMotorParkourSettleViewData motorParkourSettleViewData = this.OpenParam as MotorParkourSettleView.IMotorParkourSettleViewData;
			MotorParkourLevelData levelData = motorParkourSettleViewData.LevelData;
			bool isNewRecord = motorParkourSettleViewData.IsNewRecord;
			List<MotorParkourRankData> newRankList = levelData.GetNewRankList(motorParkourSettleViewData.MyScoreTime);
			int num = newRankList.FindIndex((MotorParkourRankData rankData) => rankData.IsOwn) + 1;
			base.GetItem(0).SetUIActive(num == 1);
			base.GetItem(1).SetUIActive(num == 2);
			base.GetItem(2).SetUIActive(num == 3);
			base.GetItem(3).SetUIActive(num > 3);
			base.GetItem(6).SetUIActive(num == 1);
			base.GetItem(7).SetUIActive(num == 2);
			base.GetItem(8).SetUIActive(num == 3);
			for (int i = 0; i < 3; i++)
			{
				MotorParkourRankData motorParkourRankData = newRankList[i];
				if (motorParkourRankData.IsOwn)
				{
					string playerName = ModelBase<FunctionModel>.Instance.GetPlayerName();
					UUIText text = base.GetText(12 + i * 2);
					if (text != null)
					{
						text.SetText(playerName, true);
					}
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12 + i * 2), motorParkourRankData.Name, Array.Empty<object>());
				}
				string remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat5((double)motorParkourRankData.Time * Singleton<TimeUtil>.Instance.Millisecond);
				UUIText text2 = base.GetText(13 + i * 2);
				if (text2 != null)
				{
					text2.SetText(remainTimeDataFormat, true);
				}
			}
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(isNewRecord);
			}
			string remainTimeDataFormat2 = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat5((double)motorParkourSettleViewData.MyScoreTime * Singleton<TimeUtil>.Instance.Millisecond);
			UUIText text3 = base.GetText(9);
			if (text3 != null)
			{
				text3.SetText(remainTimeDataFormat2, true);
			}
			string remainTimeDataFormat3 = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat5((double)levelData.BestRecordTime * Singleton<TimeUtil>.Instance.Millisecond);
			UUIText text4 = base.GetText(11);
			if (text4 == null)
			{
				return;
			}
			text4.SetText(remainTimeDataFormat3, true);
		}

		// Token: 0x06041AE6 RID: 269030 RVA: 0x010D7F7E File Offset: 0x010D617E
		private void OnReChallengeBtnClick()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon();
		}

		// Token: 0x06041AE7 RID: 269031 RVA: 0x010D7F8B File Offset: 0x010D618B
		private void OnExitBtnClick()
		{
			ControllerBase<MotorParkourController>.Instance.IsNeedShowMotorParkourMainView = true;
			ControllerBase<MotorParkourController>.Instance.LeaveInstanceDungeon();
		}

		// Token: 0x0200C6EF RID: 50927
		public interface IMotorParkourSettleViewData
		{
			// Token: 0x1700AA5B RID: 43611
			// (get) Token: 0x0604EE33 RID: 323123
			// (set) Token: 0x0604EE34 RID: 323124
			MotorParkourLevelData LevelData { get; set; }

			// Token: 0x1700AA5C RID: 43612
			// (get) Token: 0x0604EE35 RID: 323125
			// (set) Token: 0x0604EE36 RID: 323126
			bool IsNewRecord { get; set; }

			// Token: 0x1700AA5D RID: 43613
			// (get) Token: 0x0604EE37 RID: 323127
			// (set) Token: 0x0604EE38 RID: 323128
			int MyScoreTime { get; set; }
		}

		// Token: 0x0200C6F0 RID: 50928
		[Nullable(0)]
		public class MotorParkourSettleViewData : MotorParkourSettleView.IMotorParkourSettleViewData
		{
			// Token: 0x1700AA5E RID: 43614
			// (get) Token: 0x0604EE39 RID: 323129 RVA: 0x015F27F6 File Offset: 0x015F09F6
			// (set) Token: 0x0604EE3A RID: 323130 RVA: 0x015F27FE File Offset: 0x015F09FE
			public MotorParkourLevelData LevelData { get; set; }

			// Token: 0x1700AA5F RID: 43615
			// (get) Token: 0x0604EE3B RID: 323131 RVA: 0x015F2807 File Offset: 0x015F0A07
			// (set) Token: 0x0604EE3C RID: 323132 RVA: 0x015F280F File Offset: 0x015F0A0F
			public bool IsNewRecord { get; set; }

			// Token: 0x1700AA60 RID: 43616
			// (get) Token: 0x0604EE3D RID: 323133 RVA: 0x015F2818 File Offset: 0x015F0A18
			// (set) Token: 0x0604EE3E RID: 323134 RVA: 0x015F2820 File Offset: 0x015F0A20
			public int MyScoreTime { get; set; }
		}

		// Token: 0x0200C6F1 RID: 50929
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D3FB RID: 250875
			public const int ItemFirstBg = 0;

			// Token: 0x0403D3FC RID: 250876
			public const int ItemSecondBg = 1;

			// Token: 0x0403D3FD RID: 250877
			public const int ItemThirdBg = 2;

			// Token: 0x0403D3FE RID: 250878
			public const int ItemNormalBg = 3;

			// Token: 0x0403D3FF RID: 250879
			public const int BtnReChallenge = 4;

			// Token: 0x0403D400 RID: 250880
			public const int BtnExit = 5;

			// Token: 0x0403D401 RID: 250881
			public const int ItemFirstNum = 6;

			// Token: 0x0403D402 RID: 250882
			public const int ItemSecondNum = 7;

			// Token: 0x0403D403 RID: 250883
			public const int ItemThirdNum = 8;

			// Token: 0x0403D404 RID: 250884
			public const int TextMyScoreTime = 9;

			// Token: 0x0403D405 RID: 250885
			public const int ItemNewRecord = 10;

			// Token: 0x0403D406 RID: 250886
			public const int TextBestRecordTime = 11;

			// Token: 0x0403D407 RID: 250887
			public const int TextFirstName = 12;

			// Token: 0x0403D408 RID: 250888
			public const int TextFirstTime = 13;

			// Token: 0x0403D409 RID: 250889
			public const int TextSecondName = 14;

			// Token: 0x0403D40A RID: 250890
			public const int TextSecondTime = 15;

			// Token: 0x0403D40B RID: 250891
			public const int TextThirdName = 16;

			// Token: 0x0403D40C RID: 250892
			public const int TextThirdTime = 17;
		}
	}
}
