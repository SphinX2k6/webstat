using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x02006905 RID: 26885
	public class DropCatchGameplayPauseView : UiViewBase
	{
		// Token: 0x06042C96 RID: 273558 RVA: 0x01123C44 File Offset: 0x01121E44
		[NullableContext(1)]
		public DropCatchGameplayPauseView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06042C97 RID: 273559 RVA: 0x01123C50 File Offset: 0x01121E50
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIArtText)),
				new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnClickExit)),
				new ValueTuple<int, Delegate>(4, new Action(this.OnClickContinue)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickRestart))
			};
		}

		// Token: 0x06042C98 RID: 273560 RVA: 0x01123D3F File Offset: 0x01121F3F
		protected override void OnStart()
		{
			this.Proxy = (this.OpenParam as DropCatchGameplayProxy);
			this.Proxy.PauseGameplay("PauseView");
			this.InitScoreLevelLayout();
			this.RefreshCurScore();
			this.RefreshRestartButtonVisible();
		}

		// Token: 0x06042C99 RID: 273561 RVA: 0x01123D74 File Offset: 0x01121F74
		private void InitScoreLevelLayout()
		{
			DropCatchGameplayProxy proxy = this.Proxy;
			List<float> list;
			if (proxy == null)
			{
				list = null;
			}
			else
			{
				DropCatchGameplayViewModel gameplayViewModel = proxy.GetGameplayViewModel();
				list = ((gameplayViewModel != null) ? gameplayViewModel.GetScoreLevels() : null);
			}
			List<float> list2 = list;
			if (list2 == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DropCatch, ELogAuthor.CB, "获取关卡配置失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.ScoreLevelLayout = new GenericLayout<DropCatchPauseScoreItem, IScoreLevelItemData>(base.GetVerticalLayout(1), () => new DropCatchPauseScoreItem(), null, false, true);
			List<IScoreLevelItemData> list3 = new List<IScoreLevelItemData>();
			foreach (float num in list2)
			{
				list3.Add(new IScoreLevelItemData
				{
					Score = num,
					IsFinish = (this.Proxy.GetCurScore() >= num)
				});
			}
			this.ScoreLevelLayout.RefreshByData(list3, null, false);
		}

		// Token: 0x06042C9A RID: 273562 RVA: 0x01123E74 File Offset: 0x01122074
		private void RefreshCurScore()
		{
			UUIArtText artText = base.GetArtText(0);
			if (artText == null)
			{
				return;
			}
			artText.SetText(this.Proxy.GetCurScore().ToString());
		}

		// Token: 0x06042C9B RID: 273563 RVA: 0x01123EA8 File Offset: 0x011220A8
		private void OnClickExit()
		{
			DropCatchGameplayProxy proxy = this.Proxy;
			DropCatchGameplay? dropCatchGameplay = (proxy != null) ? proxy.GetGameplayConfig() : null;
			if (dropCatchGameplay != null && dropCatchGameplay.GetValueOrDefault().IsNeedSettle)
			{
				DropCatchGameplayProxy proxy2 = this.Proxy;
				if (proxy2 != null)
				{
					proxy2.SettleGameplay(EDropCatchGameplaySettleReason.Exit);
				}
			}
			else
			{
				DropCatchGameplayProxy proxy3 = this.Proxy;
				if (proxy3 != null)
				{
					proxy3.EndGameplay();
				}
			}
			base.CloseMe(null);
		}

		// Token: 0x06042C9C RID: 273564 RVA: 0x01123F19 File Offset: 0x01122119
		private void OnClickContinue()
		{
			base.CloseMe(null);
		}

		// Token: 0x06042C9D RID: 273565 RVA: 0x01123F22 File Offset: 0x01122122
		private void OnClickRestart()
		{
			DropCatchGameplayProxy proxy = this.Proxy;
			if (proxy != null)
			{
				proxy.StartGameplay(this.Proxy.GetCurGameplayId());
			}
			base.CloseMe(null);
		}

		// Token: 0x06042C9E RID: 273566 RVA: 0x01123F48 File Offset: 0x01122148
		private void RefreshRestartButtonVisible()
		{
			DropCatchGameplayProxy proxy = this.Proxy;
			DropCatchGameplay? dropCatchGameplay = (proxy != null) ? proxy.GetGameplayConfig() : null;
			if (dropCatchGameplay == null)
			{
				return;
			}
			UUIButtonComponent button = base.GetButton(5);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(!dropCatchGameplay.Value.IsSpecial);
		}

		// Token: 0x06042C9F RID: 273567 RVA: 0x01123FAA File Offset: 0x011221AA
		protected override void OnBeforeDestroy()
		{
			DropCatchGameplayProxy proxy = this.Proxy;
			if (proxy == null)
			{
				return;
			}
			proxy.ResumeGameplay("PauseView");
		}

		// Token: 0x04025365 RID: 152421
		[Nullable(2)]
		private DropCatchGameplayProxy Proxy;

		// Token: 0x04025366 RID: 152422
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DropCatchPauseScoreItem, IScoreLevelItemData> ScoreLevelLayout;
	}
}
