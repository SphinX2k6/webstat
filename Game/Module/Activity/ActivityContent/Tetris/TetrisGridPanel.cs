using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062C5 RID: 25285
	public class TetrisGridPanel : UiPanelBase
	{
		// Token: 0x0603F9DF RID: 260575 RVA: 0x0104E093 File Offset: 0x0104C293
		public TetrisGridPanel(int row = 0, int column = 0)
		{
			this.Row = row;
			this.Column = column;
		}

		// Token: 0x0603F9E0 RID: 260576 RVA: 0x0104E0AC File Offset: 0x0104C2AC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x0603F9E1 RID: 260577 RVA: 0x0104E108 File Offset: 0x0104C308
		[NullableContext(1)]
		public void Refresh(ICellInstance data)
		{
			TetrisGem? gemConfig = ConfigBase<ActivityTetrisConfig>.Instance.GetGemConfig(data.ColorId);
			base.GetSprite(1).SetUIActive(true);
			this.SetSpriteByPath((data.GemType == EGemType.None) ? gemConfig.Value.IconPath : gemConfig.Value.GemPath, base.GetSprite(1), false, null, null);
			this.SetSpriteByPath(gemConfig.Value.BgPath, base.GetSprite(0), false, null, null);
		}

		// Token: 0x04023B48 RID: 146248
		public int Row;

		// Token: 0x04023B49 RID: 146249
		public int Column;
	}
}
