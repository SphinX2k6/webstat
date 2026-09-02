using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066F4 RID: 26356
	public class MotorFightSuccessView : UiViewBase
	{
		// Token: 0x06041CA0 RID: 269472 RVA: 0x010E07DE File Offset: 0x010DE9DE
		[NullableContext(1)]
		public MotorFightSuccessView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041CA1 RID: 269473 RVA: 0x010E07E8 File Offset: 0x010DE9E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnExitBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnReChallengeBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041CA2 RID: 269474 RVA: 0x010E0A04 File Offset: 0x010DEC04
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightSuccessView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightSuccessView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041CA3 RID: 269475 RVA: 0x010E0A47 File Offset: 0x010DEC47
		[NullableContext(1)]
		private CommonItemSmallItemGrid InitGridItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x06041CA4 RID: 269476 RVA: 0x010E0A4E File Offset: 0x010DEC4E
		private void OnReChallengeBtnClick()
		{
			ControllerBase<MotorFightController>.Instance.ReChallengeMotorFightDungeon();
		}

		// Token: 0x06041CA5 RID: 269477 RVA: 0x010E0A5A File Offset: 0x010DEC5A
		private void OnExitBtnClick()
		{
			ControllerBase<MotorFightController>.Instance.LeaveInstanceDungeon();
		}

		// Token: 0x04024B37 RID: 150327
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

		// Token: 0x0200C73E RID: 51006
		private class EComponents
		{
			// Token: 0x0403D575 RID: 251253
			public const int TextWaveNum = 0;

			// Token: 0x0403D576 RID: 251254
			public const int TextWaveScore = 1;

			// Token: 0x0403D577 RID: 251255
			public const int TextKillNum = 2;

			// Token: 0x0403D578 RID: 251256
			public const int TextKillScore = 3;

			// Token: 0x0403D579 RID: 251257
			public const int TextBuffGateNum = 4;

			// Token: 0x0403D57A RID: 251258
			public const int TextBuffGateScore = 5;

			// Token: 0x0403D57B RID: 251259
			public const int ArtTextTotalScore = 6;

			// Token: 0x0403D57C RID: 251260
			public const int ItemNewRecordLabel = 7;

			// Token: 0x0403D57D RID: 251261
			public const int LayoutReward = 8;

			// Token: 0x0403D57E RID: 251262
			public const int ItemRewardPanel = 9;

			// Token: 0x0403D57F RID: 251263
			public const int BtnExit = 10;

			// Token: 0x0403D580 RID: 251264
			public const int BtnReChallenge = 11;
		}
	}
}
