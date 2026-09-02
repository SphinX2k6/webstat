using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062C0 RID: 25280
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisComboPanel : UiPanelBase
	{
		// Token: 0x0603F9C7 RID: 260551 RVA: 0x0104D820 File Offset: 0x0104BA20
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIArtText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIArtText))
			};
		}

		// Token: 0x0603F9C8 RID: 260552 RVA: 0x0104D8FE File Offset: 0x0104BAFE
		protected override void OnStart()
		{
			this.GemList = new GenericLayout<TetrisComboGemGrid, ITetrisGemGetData>(base.GetHorizontalLayout(3), new Func<TetrisComboGemGrid>(this.CreateGemItem), null, false, true);
			this.ViewSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603F9C9 RID: 260553 RVA: 0x0104D932 File Offset: 0x0104BB32
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
			if (viewSequencePlayer != null)
			{
				viewSequencePlayer.Clear();
			}
			this.ViewSequencePlayer = null;
		}

		// Token: 0x0603F9CA RID: 260554 RVA: 0x0104D94C File Offset: 0x0104BB4C
		private TetrisComboGemGrid CreateGemItem()
		{
			return new TetrisComboGemGrid();
		}

		// Token: 0x0603F9CB RID: 260555 RVA: 0x0104D954 File Offset: 0x0104BB54
		public void Refresh(IComboData data)
		{
			if (data.GameMode == EGameMode.GemCollection && data.ClearedLines <= 1 && data.GemList.Count == 0)
			{
				base.SetUiActive(false);
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_cube_efx_match_level1");
				return;
			}
			base.SetUiActive(true);
			this.RefreshViewSequence(data);
			this.RefreshEvaluation(data.ClearedLines, data.IsBoardEmpty);
			this.RefreshColor(data.ClearedLines, data.IsBoardEmpty);
			this.RefreshScore(data.Score, data.GameMode);
			this.RefreshCombo(data.ComboCount);
			this.RefreshGemList(data.GemList);
		}

		// Token: 0x0603F9CC RID: 260556 RVA: 0x0104D9F4 File Offset: 0x0104BBF4
		private void RefreshViewSequence(IComboData data)
		{
			if (data.IsBoardEmpty)
			{
				this.ViewSequencePlayer.PlayLevelSequenceByName("Yellow", false, null, false);
				return;
			}
			if (data.ClearedLines >= 4)
			{
				this.ViewSequencePlayer.PlayLevelSequenceByName("Red", false, null, false);
				return;
			}
			this.ViewSequencePlayer.PlayLevelSequenceByName("Normal", false, null, false);
		}

		// Token: 0x0603F9CD RID: 260557 RVA: 0x0104DA68 File Offset: 0x0104BC68
		private void RefreshEvaluation(int clearedLines, bool isBoardEmpty)
		{
			UUIItem item = base.GetItem(1);
			UUITexture texture = base.GetTexture(2);
			if (item == null || texture == null)
			{
				return;
			}
			if (clearedLines <= 1 && !isBoardEmpty)
			{
				item.SetUIActive(false);
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_cube_efx_match_level1");
				return;
			}
			item.SetUIActive(true);
			EComboTexturePath value = EComboTexturePath.Good;
			if (isBoardEmpty)
			{
				value = EComboTexturePath.Unbelievable;
			}
			else if (clearedLines >= 4)
			{
				value = EComboTexturePath.Excellent;
			}
			else if (clearedLines >= 3)
			{
				value = EComboTexturePath.Great;
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_cube_efx_match_level2");
			}
			else if (clearedLines >= 2)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_cube_efx_match_level2");
			}
			base.SetTextureByPath(value.ToEnumString(), texture, null, null);
		}

		// Token: 0x0603F9CE RID: 260558 RVA: 0x0104DB08 File Offset: 0x0104BD08
		private void RefreshColor(int clearedLines, bool isBoardEmpty)
		{
			EComboTextColor ecomboTextColor = EComboTextColor.Good;
			EComboBgTexturePath value = EComboBgTexturePath.Good;
			if (isBoardEmpty)
			{
				ecomboTextColor = EComboTextColor.Unbelievable;
				value = EComboBgTexturePath.Unbelievable;
			}
			else if (clearedLines >= 4)
			{
				ecomboTextColor = EComboTextColor.Excellent;
				value = EComboBgTexturePath.Excellent;
			}
			else if (clearedLines >= 3)
			{
				value = EComboBgTexturePath.Great;
				ecomboTextColor = EComboTextColor.Great;
			}
			else if (clearedLines <= 1)
			{
				ecomboTextColor = EComboTextColor.Default;
				value = EComboBgTexturePath.Default;
			}
			TetrisComboPanel.CurrentComboColorHex = ecomboTextColor;
			FColor color = FColor.FromHex(ecomboTextColor.ToEnumString());
			base.SetTextureByPath(value.ToEnumString(), base.GetTexture(0), null, null);
			UUIArtText artText = base.GetArtText(6);
			if (artText == null)
			{
				return;
			}
			artText.SetColor(color);
		}

		// Token: 0x0603F9CF RID: 260559 RVA: 0x0104DB80 File Offset: 0x0104BD80
		private void RefreshScore(int score, EGameMode gameMode)
		{
			UUIItem item = base.GetItem(5);
			UUIArtText artText = base.GetArtText(6);
			if (item == null || artText == null)
			{
				return;
			}
			bool flag = gameMode != EGameMode.GemCollection && score > 0;
			item.SetUIActive(flag);
			if (flag)
			{
				artText.SetText("+" + score.ToString());
			}
		}

		// Token: 0x0603F9D0 RID: 260560 RVA: 0x0104DBD4 File Offset: 0x0104BDD4
		private void RefreshCombo(int comboCount)
		{
			UUIItem item = base.GetItem(7);
			UUIArtText artText = base.GetArtText(8);
			if (item == null || artText == null)
			{
				return;
			}
			bool flag = comboCount >= 2;
			item.SetUIActive(flag);
			if (flag)
			{
				artText.SetText(comboCount.ToString());
			}
		}

		// Token: 0x0603F9D1 RID: 260561 RVA: 0x0104DC18 File Offset: 0x0104BE18
		private void RefreshGemList(List<ITetrisGemGetData> gemList)
		{
			if (gemList.Count == 0)
			{
				base.GetHorizontalLayout(3).RootUIComp.Get().SetUIActive(false);
				return;
			}
			base.GetHorizontalLayout(3).RootUIComp.Get().SetUIActive(true);
			base.GetItem(5).SetUIActive(false);
			this.GemList.RefreshByData(gemList, null, false);
		}

		// Token: 0x04023B3C RID: 146236
		[StaticVariableRuleIgnore]
		public static EComboTextColor CurrentComboColorHex;

		// Token: 0x04023B3D RID: 146237
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<TetrisComboGemGrid, ITetrisGemGetData> GemList;

		// Token: 0x04023B3E RID: 146238
		[Nullable(2)]
		private LevelSequencePlayer ViewSequencePlayer;
	}
}
