using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062D5 RID: 25301
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TetrisGemProgressGrid : GridProxyAbstract<ITetrisGemProgressData>
	{
		// Token: 0x0603FA54 RID: 260692 RVA: 0x01050D14 File Offset: 0x0104EF14
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

		// Token: 0x0603FA55 RID: 260693 RVA: 0x01050DDC File Offset: 0x0104EFDC
		protected override void OnStart()
		{
			this.ViewSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603FA56 RID: 260694 RVA: 0x01050DF0 File Offset: 0x0104EFF0
		[NullableContext(1)]
		public override void Refresh(ITetrisGemProgressData data, bool isSelected, int gridIndex)
		{
			TetrisGem? gemConfig = ConfigBase<ActivityTetrisConfig>.Instance.GetGemConfig(data.GemId);
			this.SetSpriteByPath(gemConfig.Value.TargetBgPath, base.GetSprite(1), false, null, null);
			base.SetTextureByPath(gemConfig.Value.TargetTextureBgPath, base.GetTexture(7), null, null);
			this.SetSpriteByPath(gemConfig.Value.TargetIconPath, base.GetSprite(0), false, null, null);
			int num = Math.Min(data.CurrentGemCount, data.TargetGemCount);
			UUIText text = base.GetText(2);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int?>((data != null) ? new int?(data.TargetGemCount) : null);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			base.GetSprite(1).SetFillAmount((float)data.CurrentGemCount / (float)data.TargetGemCount);
			int num2 = num;
			ITetrisGemProgressData levelData = this.LevelData;
			if (num2 > ((levelData != null) ? levelData.CurrentGemCount : 0))
			{
				base.GetItem(5).SetUIActive(false);
				base.GetItem(5).SetUIActive(true);
				this.ViewSequencePlayer.PlayLevelSequenceByName("Up", false, null, false);
			}
			else
			{
				base.GetItem(5).SetUIActive(false);
			}
			this.LevelData = data;
		}

		// Token: 0x0603FA57 RID: 260695 RVA: 0x01050F68 File Offset: 0x0104F168
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
			if (viewSequencePlayer != null)
			{
				viewSequencePlayer.Clear();
			}
			this.ViewSequencePlayer = null;
		}

		// Token: 0x04023BB8 RID: 146360
		private ITetrisGemProgressData LevelData;

		// Token: 0x04023BB9 RID: 146361
		private LevelSequencePlayer ViewSequencePlayer;
	}
}
