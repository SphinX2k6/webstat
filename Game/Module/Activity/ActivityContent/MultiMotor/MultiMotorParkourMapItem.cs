using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x0200665E RID: 26206
	[NullableContext(1)]
	[Nullable(0)]
	public class MultiMotorParkourMapItem : UiPanelBase
	{
		// Token: 0x06041716 RID: 268054 RVA: 0x010CBABE File Offset: 0x010C9CBE
		public MultiMotorParkourMapItem(MultiMotorLevelData levelData)
		{
			this.LevelData = levelData;
		}

		// Token: 0x06041717 RID: 268055 RVA: 0x010CBAF0 File Offset: 0x010C9CF0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUI2DLineRaw));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUI2DLineRaw));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041718 RID: 268056 RVA: 0x010CBC20 File Offset: 0x010C9E20
		protected override UniTask OnBeforeStartAsync()
		{
			MultiMotorParkourMapItem.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MultiMotorParkourMapItem.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041719 RID: 268057 RVA: 0x010CBC63 File Offset: 0x010C9E63
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshOnlineTeamList, new Action(this.OnRefreshOnlineTeamList));
		}

		// Token: 0x0604171A RID: 268058 RVA: 0x010CBC84 File Offset: 0x010C9E84
		private void OnRefreshOnlineTeamList()
		{
			List<OnlineTeamData> teamList = ModelBase<OnlineModel>.Instance.GetTeamList();
			int num = 0;
			for (int i = 0; i < MultiMotorParkourMapItem.NumberToComponent.Length; i++)
			{
				int num2 = i + 1;
				if (num2 != this.SelfPlayerNumber)
				{
					int playerId = 0;
					foreach (OnlineTeamData onlineTeamData in teamList)
					{
						if (onlineTeamData.PlayerNumber == num2)
						{
							playerId = onlineTeamData.PlayerId;
							break;
						}
					}
					if (num < this.PlayerMarkItemOthers.Count)
					{
						this.PlayerMarkItemOthers[num].PlayerId = playerId;
					}
					num++;
				}
			}
		}

		// Token: 0x0604171B RID: 268059 RVA: 0x010CBD3C File Offset: 0x010C9F3C
		public void DrawMapPathLine()
		{
			ModelBase<MotorParkourMapModel>.Instance.InitSplinePoints(this.LevelData.Config.Value.SplineId, (float)((int)this.LevelData.Config.Value.MapScale), this.CenterOffset, this.LevelData.Config.Value.SplineStartIndex, this.LevelData.Config.Value.SplineEndIndex);
			TArray<FVector2D> splinePoints = ModelBase<MotorParkourMapModel>.Instance.SplinePoints;
			UUI2DLineRaw uiLineRaw = base.GetUiLineRaw(1);
			if (uiLineRaw != null)
			{
				uiLineRaw.SetPoints(splinePoints, false);
			}
			this.MaxPointsCount = splinePoints.Num();
		}

		// Token: 0x0604171C RID: 268060 RVA: 0x010CBDF4 File Offset: 0x010C9FF4
		public void UpdatePlayerPosition()
		{
			MotorParkourPlayerMarkItem playerMarkItem = this.PlayerMarkItem;
			if (playerMarkItem != null)
			{
				playerMarkItem.UpdatePosition((float)((int)this.LevelData.Config.Value.MapScale), this.CenterOffset);
			}
			foreach (MotorParkourPlayerMarkItem motorParkourPlayerMarkItem in this.PlayerMarkItemOthers)
			{
				motorParkourPlayerMarkItem.UpdateOthersPosition(this.LevelData.Config.Value.MapScale, this.CenterOffset);
			}
			TArray<FVector2D> pathTakenSplinePoints = ModelBase<MotorParkourMapModel>.Instance.GetPathTakenSplinePoints();
			UUI2DLineRaw uiLineRaw = base.GetUiLineRaw(2);
			if (uiLineRaw != null)
			{
				uiLineRaw.SetPoints(pathTakenSplinePoints, false);
			}
			if (this.CurrentPointsCount != pathTakenSplinePoints.Num())
			{
				this.CurrentPointsCount = pathTakenSplinePoints.Num();
				ControllerBase<MultiMotorController>.Instance.MotorOnlineProgressReportPush(this.LevelData.Config.Value.InstId, (float)this.CurrentPointsCount / (float)this.MaxPointsCount * 10000f);
			}
		}

		// Token: 0x04024978 RID: 149880
		private static readonly int[] NumberToComponent = new int[]
		{
			7,
			5,
			6
		};

		// Token: 0x04024979 RID: 149881
		[Nullable(2)]
		private MotorParkourPlayerMarkItem PlayerMarkItem;

		// Token: 0x0402497A RID: 149882
		private readonly List<MotorParkourPlayerMarkItem> PlayerMarkItemOthers = new List<MotorParkourPlayerMarkItem>();

		// Token: 0x0402497B RID: 149883
		private readonly Vector2D UiOffset = Vector2D.Create();

		// Token: 0x0402497C RID: 149884
		private readonly Vector2D CenterOffset = Vector2D.Create();

		// Token: 0x0402497D RID: 149885
		private int MaxPointsCount;

		// Token: 0x0402497E RID: 149886
		private int CurrentPointsCount;

		// Token: 0x0402497F RID: 149887
		private int SelfPlayerNumber;

		// Token: 0x04024980 RID: 149888
		public MultiMotorLevelData LevelData;

		// Token: 0x0200C680 RID: 50816
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D1E6 RID: 250342
			public const int ItemMarkPanel = 0;

			// Token: 0x0403D1E7 RID: 250343
			public const int LineRawMapPath = 1;

			// Token: 0x0403D1E8 RID: 250344
			public const int LineRawPathTaken = 2;

			// Token: 0x0403D1E9 RID: 250345
			public const int ItemEndPoint = 3;

			// Token: 0x0403D1EA RID: 250346
			public const int ItemPlayer = 4;

			// Token: 0x0403D1EB RID: 250347
			public const int ItemPlayer2P = 5;

			// Token: 0x0403D1EC RID: 250348
			public const int ItemPlayer3P = 6;

			// Token: 0x0403D1ED RID: 250349
			public const int ItemPlayer1P = 7;
		}
	}
}
