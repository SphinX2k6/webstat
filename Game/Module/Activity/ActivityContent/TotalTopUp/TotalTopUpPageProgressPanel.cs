using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006281 RID: 25217
	public class TotalTopUpPageProgressPanel : UiPanelBase
	{
		// Token: 0x0603F7F0 RID: 260080 RVA: 0x01047900 File Offset: 0x01045B00
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
		}

		// Token: 0x0603F7F1 RID: 260081 RVA: 0x0104799C File Offset: 0x01045B9C
		protected override UniTask OnBeforeStartAsync()
		{
			TotalTopUpPageProgressPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TotalTopUpPageProgressPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F7F2 RID: 260082 RVA: 0x010479E0 File Offset: 0x01045BE0
		[NullableContext(1)]
		public void Refresh(TotalTopUpPageViewModel viewModel)
		{
			this.PageViewModel = viewModel;
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetText(viewModel.CurrentScore.ToString(), true);
			}
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.SetText(viewModel.NextScore.ToString(), true);
			}
			UUISprite sprite = base.GetSprite(2);
			float progressPercent = viewModel.ProgressPercent;
			if (sprite != null)
			{
				sprite.SetFillAmount(progressPercent);
			}
			bool flag = viewModel.ProgressPercent >= 1f;
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!flag);
		}

		// Token: 0x04023A4F RID: 145999
		[Nullable(2)]
		private TotalTopUpPageViewModel PageViewModel;

		// Token: 0x04023A50 RID: 146000
		[Nullable(2)]
		private TotalTopUpPageGetScoreBtnItem GetScoreBtn;

		// Token: 0x0200C365 RID: 50021
		private class ENode
		{
			// Token: 0x0403C36A RID: 246634
			public const int TextCurrentScore = 0;

			// Token: 0x0403C36B RID: 246635
			public const int TextNextScore = 1;

			// Token: 0x0403C36C RID: 246636
			public const int SpriteProgressBar = 2;

			// Token: 0x0403C36D RID: 246637
			public const int BtnGetScore = 3;

			// Token: 0x0403C36E RID: 246638
			public const int ItemProgressBar = 4;

			// Token: 0x0403C36F RID: 246639
			public const int ItemFinished = 5;
		}
	}
}
