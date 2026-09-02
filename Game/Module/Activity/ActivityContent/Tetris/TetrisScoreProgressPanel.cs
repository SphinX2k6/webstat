using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062D4 RID: 25300
	public class TetrisScoreProgressPanel : UiPanelBase
	{
		// Token: 0x0603FA4E RID: 260686 RVA: 0x010509B0 File Offset: 0x0104EBB0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUITexture))
			};
		}

		// Token: 0x0603FA4F RID: 260687 RVA: 0x01050A78 File Offset: 0x0104EC78
		protected override void OnStart()
		{
			this.ViewSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603FA50 RID: 260688 RVA: 0x01050A8B File Offset: 0x0104EC8B
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
			if (viewSequencePlayer != null)
			{
				viewSequencePlayer.Clear();
			}
			this.ViewSequencePlayer = null;
		}

		// Token: 0x0603FA51 RID: 260689 RVA: 0x01050AA8 File Offset: 0x0104ECA8
		public void RefreshInfinite(int currentScore)
		{
			TetrisGem? gemConfig = ConfigBase<ActivityTetrisConfig>.Instance.GetGemConfig(0);
			this.SetSpriteByPath(gemConfig.Value.TargetBgPath, base.GetSprite(1), false, null, null);
			base.SetTextureByPath(gemConfig.Value.TargetTextureBgPath, base.GetTexture(7), null, null);
			this.SetSpriteByPath(gemConfig.Value.TargetIconPath, base.GetSprite(0), false, null, null);
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetText(currentScore.ToString(), true);
			}
			base.GetSprite(1).SetFillAmount(1f);
			base.GetItem(3).SetUIActive((long)currentScore > ControllerBase<TetrisController>.Instance.GetHighestScore());
			if (currentScore > this.CurrentScore)
			{
				base.GetItem(5).SetUIActive(false);
				base.GetItem(5).SetUIActive(true);
				this.ViewSequencePlayer.PlayLevelSequenceByName("Up", false, null, false);
			}
			else
			{
				base.GetItem(5).SetUIActive(false);
			}
			this.CurrentScore = currentScore;
		}

		// Token: 0x0603FA52 RID: 260690 RVA: 0x01050BD0 File Offset: 0x0104EDD0
		public void Refresh(int currentScore, int targetScore)
		{
			TetrisGem? gemConfig = ConfigBase<ActivityTetrisConfig>.Instance.GetGemConfig(0);
			this.SetSpriteByPath(gemConfig.Value.TargetBgPath, base.GetSprite(1), false, null, null);
			base.SetTextureByPath(gemConfig.Value.TargetTextureBgPath, base.GetTexture(7), null, null);
			this.SetSpriteByPath(gemConfig.Value.TargetIconPath, base.GetSprite(0), false, null, null);
			int value = Math.Min(currentScore, targetScore);
			UUIText text = base.GetText(2);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(targetScore);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			base.GetSprite(1).SetFillAmount((float)currentScore / (float)targetScore);
			if (currentScore > this.CurrentScore)
			{
				base.GetItem(5).SetUIActive(false);
				base.GetItem(5).SetUIActive(true);
				this.ViewSequencePlayer.PlayLevelSequenceByName("Up", false, null, false);
			}
			else
			{
				base.GetItem(5).SetUIActive(false);
			}
			this.CurrentScore = currentScore;
		}

		// Token: 0x04023BB6 RID: 146358
		private int CurrentScore;

		// Token: 0x04023BB7 RID: 146359
		[Nullable(2)]
		private LevelSequencePlayer ViewSequencePlayer;
	}
}
