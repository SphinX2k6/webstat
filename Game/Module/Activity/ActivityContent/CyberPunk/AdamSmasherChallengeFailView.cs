using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.TrainingDegree;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x0200695A RID: 26970
	[NullableContext(2)]
	[Nullable(0)]
	public class AdamSmasherChallengeFailView : UiViewBase
	{
		// Token: 0x06042ECE RID: 274126 RVA: 0x0112E0EC File Offset: 0x0112C2EC
		[NullableContext(1)]
		public AdamSmasherChallengeFailView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06042ECF RID: 274127 RVA: 0x0112E0F8 File Offset: 0x0112C2F8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUITexture)),
				new ValueTuple<int, Type>(11, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUIText))
			};
		}

		// Token: 0x06042ED0 RID: 274128 RVA: 0x0112E234 File Offset: 0x0112C434
		protected override UniTask OnBeforeStartAsync()
		{
			AdamSmasherChallengeFailView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<AdamSmasherChallengeFailView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042ED1 RID: 274129 RVA: 0x0112E277 File Offset: 0x0112C477
		protected override void OnStart()
		{
			this.TrainingViewInstance = new TrainingView();
			this.TrainingViewInstance.Show(base.GetHorizontalLayout(7), null);
		}

		// Token: 0x06042ED2 RID: 274130 RVA: 0x0112E297 File Offset: 0x0112C497
		private void OnReturnToChallengeButtonClick(int a)
		{
			ControllerBase<AdamSmasherController>.Instance.OpenAdamSmasherSelectView().Forget<bool>();
			base.CloseMe(null);
		}

		// Token: 0x06042ED3 RID: 274131 RVA: 0x0112E2AF File Offset: 0x0112C4AF
		private void OnReChallengeButtonItemClick(int a)
		{
			ControllerBase<AdamSmasherController>.Instance.ReChallenge(this.StageId).Forget<bool>();
			base.CloseMe(null);
		}

		// Token: 0x06042ED4 RID: 274132 RVA: 0x0112E2CD File Offset: 0x0112C4CD
		private void OnLeaveDungeonClick(int a)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
			base.CloseMe(null);
		}

		// Token: 0x0402548A RID: 152714
		private int StageId;

		// Token: 0x0402548B RID: 152715
		private TrainingView TrainingViewInstance;

		// Token: 0x0402548C RID: 152716
		private ButtonItem ReturnToChallenge;

		// Token: 0x0402548D RID: 152717
		private ButtonItem ReChallengeButtonItem;

		// Token: 0x0200C8F9 RID: 51449
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403DD23 RID: 253219
			Revive,
			// Token: 0x0403DD24 RID: 253220
			Fail,
			// Token: 0x0403DD25 RID: 253221
			ReturnToChallenge,
			// Token: 0x0403DD26 RID: 253222
			ReChallengeButtonItem,
			// Token: 0x0403DD27 RID: 253223
			WaitTime,
			// Token: 0x0403DD28 RID: 253224
			ReviveTitle,
			// Token: 0x0403DD29 RID: 253225
			ReviveContent,
			// Token: 0x0403DD2A RID: 253226
			RoleTrainingLayout,
			// Token: 0x0403DD2B RID: 253227
			ReviveAtLocationBtn,
			// Token: 0x0403DD2C RID: 253228
			AutoReviveCountDownText,
			// Token: 0x0403DD2D RID: 253229
			ItemTexture,
			// Token: 0x0403DD2E RID: 253230
			ItemText,
			// Token: 0x0403DD2F RID: 253231
			GiveUpBtnText
		}
	}
}
