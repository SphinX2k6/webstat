using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066B8 RID: 26296
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorParkourMapItem : UiPanelBase
	{
		// Token: 0x06041A9C RID: 268956 RVA: 0x010D6545 File Offset: 0x010D4745
		public MotorParkourMapItem(MotorParkourLevelData levelData)
		{
			this.LevelData = levelData;
		}

		// Token: 0x06041A9D RID: 268957 RVA: 0x010D656C File Offset: 0x010D476C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
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
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUI2DLineRaw));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUI2DLineRaw));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041A9E RID: 268958 RVA: 0x010D6638 File Offset: 0x010D4838
		protected override UniTask OnBeforeStartAsync()
		{
			MotorParkourMapItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorParkourMapItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041A9F RID: 268959 RVA: 0x010D667C File Offset: 0x010D487C
		public void DrawMapPathLine()
		{
			ModelBase<MotorParkourMapModel>.Instance.InitSplinePoints(this.LevelData.SplineId, this.LevelData.MapScale, this.CenterOffset, this.LevelData.SplineStartIndex, this.LevelData.SplineEndIndex);
			TArray<FVector2D> splinePoints = ModelBase<MotorParkourMapModel>.Instance.SplinePoints;
			UUI2DLineRaw uiLineRaw = base.GetUiLineRaw(1);
			if (uiLineRaw == null)
			{
				return;
			}
			uiLineRaw.SetPoints(splinePoints, false);
		}

		// Token: 0x06041AA0 RID: 268960 RVA: 0x010D66E4 File Offset: 0x010D48E4
		public void UpdatePlayerPosition()
		{
			MotorParkourPlayerMarkItem playerMarkItem = this.PlayerMarkItem;
			if (playerMarkItem != null)
			{
				playerMarkItem.UpdatePosition(this.LevelData.MapScale, this.CenterOffset);
			}
			TArray<FVector2D> pathTakenSplinePoints = ModelBase<MotorParkourMapModel>.Instance.GetPathTakenSplinePoints();
			UUI2DLineRaw uiLineRaw = base.GetUiLineRaw(2);
			if (uiLineRaw == null)
			{
				return;
			}
			uiLineRaw.SetPoints(pathTakenSplinePoints, false);
		}

		// Token: 0x04024A74 RID: 150132
		[Nullable(2)]
		private MotorParkourPlayerMarkItem PlayerMarkItem;

		// Token: 0x04024A75 RID: 150133
		private readonly Vector2D UiOffset = Vector2D.Create();

		// Token: 0x04024A76 RID: 150134
		private readonly Vector2D CenterOffset = Vector2D.Create();

		// Token: 0x04024A77 RID: 150135
		public MotorParkourLevelData LevelData;

		// Token: 0x0200C6DE RID: 50910
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D3A9 RID: 250793
			public const int ItemMarkPanel = 0;

			// Token: 0x0403D3AA RID: 250794
			public const int LineRawMapPath = 1;

			// Token: 0x0403D3AB RID: 250795
			public const int LineRawPathTaken = 2;

			// Token: 0x0403D3AC RID: 250796
			public const int ItemEndPoint = 3;

			// Token: 0x0403D3AD RID: 250797
			public const int ItemPlayer = 4;
		}
	}
}
