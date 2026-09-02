using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062D7 RID: 25303
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisSelectLevelItemDetailPanel : UiPanelBase
	{
		// Token: 0x0603FA59 RID: 260697 RVA: 0x01050F8C File Offset: 0x0104F18C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIArtText)),
				new ValueTuple<int, Type>(8, typeof(UUIArtText)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickedSelectButton))
			};
		}

		// Token: 0x0603FA5A RID: 260698 RVA: 0x01051118 File Offset: 0x0104F318
		private void InitTickSystem()
		{
			this.TickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.RefreshTimeTick), "TetrisSelectLevelItemDetailPanel", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Pause(this.TickId);
			}
		}

		// Token: 0x0603FA5B RID: 260699 RVA: 0x01051169 File Offset: 0x0104F369
		protected override void OnStart()
		{
			this.InitTickSystem();
			this.LevelData = (this.OpenParam as ITetrisSelectGroupData);
			this.ViewSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603FA5C RID: 260700 RVA: 0x01051193 File Offset: 0x0104F393
		protected override void OnBeforeShow()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Resume(this.TickId);
			}
		}

		// Token: 0x0603FA5D RID: 260701 RVA: 0x010511B0 File Offset: 0x0104F3B0
		public void Refresh(ITetrisSelectGroupData data)
		{
			this.LevelData = data;
			this.ChallengeId = new int?(this.LevelData.ChallengeIds[0]);
			this.IsOpen = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData().CheckChallengeIsOpen(this.LevelData.ChallengeIds[0]);
			this.IsPrevComplete = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData().CheckPreChallengeComplete(this.LevelData.ChallengeIds[0]);
			this.IsComplete = this.CheckAllChallengesComplete();
			this.RefreshPanel();
			this.RefreshRedPoint();
			this.PlayAnim("Start");
		}

		// Token: 0x0603FA5E RID: 260702 RVA: 0x0105124F File Offset: 0x0104F44F
		protected override void OnAfterHide()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Pause(this.TickId);
			}
		}

		// Token: 0x0603FA5F RID: 260703 RVA: 0x0105126B File Offset: 0x0104F46B
		protected override void OnBeforeDestroy()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickId);
				this.TickId = -1;
			}
			LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
			if (viewSequencePlayer != null)
			{
				viewSequencePlayer.Clear();
			}
			this.ViewSequencePlayer = null;
		}

		// Token: 0x0603FA60 RID: 260704 RVA: 0x010512A8 File Offset: 0x0104F4A8
		private void RefreshPanel()
		{
			UUIArtText artText = base.GetArtText(7);
			if (artText != null)
			{
				artText.SetText("0");
			}
			UUIArtText artText2 = base.GetArtText(8);
			if (artText2 != null)
			{
				artText2.SetText(this.LevelData.GroupId.ToString());
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(this.ChallengeId.Value).TotalLevelName, Array.Empty<object>());
			if (this.IsComplete)
			{
				this.RefreshCompletePanel();
				return;
			}
			if (this.IsOpen && this.IsPrevComplete)
			{
				this.RefreshOpenPanel();
				return;
			}
			if (!this.IsOpen || !this.IsPrevComplete)
			{
				this.RefreshLockPanel();
			}
		}

		// Token: 0x0603FA61 RID: 260705 RVA: 0x01051364 File Offset: 0x0104F564
		private void RefreshCompletePanel()
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(3);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			if (TetrisUtils.IsEggLevel(ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(this.ChallengeId.Value)))
			{
				UUIItem item4 = base.GetItem(14);
				if (item4 != null)
				{
					item4.SetUIActive(true);
				}
				UUIItem item5 = base.GetItem(13);
				if (item5 != null)
				{
					item5.SetUIActive(false);
				}
				UUIArtText artText = base.GetArtText(7);
				if (artText != null)
				{
					artText.SetText("");
				}
				UUIArtText artText2 = base.GetArtText(8);
				if (artText2 != null)
				{
					artText2.SetText("");
				}
			}
			else
			{
				UUIItem item6 = base.GetItem(13);
				if (item6 != null)
				{
					item6.SetUIActive(true);
				}
				UUIItem item7 = base.GetItem(14);
				if (item7 != null)
				{
					item7.SetUIActive(false);
				}
			}
			UUIArtText artText3 = base.GetArtText(7);
			if (artText3 != null)
			{
				artText3.SetColor(FColor.FromHex("5c89a0"));
			}
			UUIArtText artText4 = base.GetArtText(8);
			if (artText4 != null)
			{
				artText4.SetColor(FColor.FromHex("7bffad"));
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "Tetristext_03", Array.Empty<object>());
		}

		// Token: 0x0603FA62 RID: 260706 RVA: 0x0105149C File Offset: 0x0104F69C
		private void RefreshOpenPanel()
		{
			UUIArtText artText = base.GetArtText(7);
			if (artText != null)
			{
				artText.SetColor(FColor.FromHex("9277fc"));
			}
			UUIArtText artText2 = base.GetArtText(8);
			if (artText2 != null)
			{
				artText2.SetColor(FColor.FromHex("ebd4ff"));
			}
			if (TetrisUtils.IsEggLevel(ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(this.ChallengeId.Value)))
			{
				UUIItem item = base.GetItem(6);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(5);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUIArtText artText3 = base.GetArtText(7);
				if (artText3 != null)
				{
					artText3.SetText("");
				}
				UUIArtText artText4 = base.GetArtText(8);
				if (artText4 != null)
				{
					artText4.SetText("");
				}
			}
			UUIItem item3 = base.GetItem(2);
			if (item3 != null)
			{
				item3.SetUIActive(true);
			}
			UUIItem item4 = base.GetItem(1);
			if (item4 != null)
			{
				item4.SetUIActive(false);
			}
			UUIItem item5 = base.GetItem(3);
			if (item5 != null)
			{
				item5.SetUIActive(false);
			}
			int num = 0;
			foreach (int challengeId in this.LevelData.ChallengeIds)
			{
				if (ControllerBase<ActivityTetrisController>.Instance.GetTetrisData().CheckChallengeComplete(challengeId))
				{
					num++;
				}
			}
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Tetristext_04", "Tetristext_04");
			UUIText text = base.GetText(11);
			string str = multiTextByKey;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
			defaultInterpolatedStringHandler.AppendLiteral("(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.LevelData.ChallengeIds.Count);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			text.SetText(str + defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603FA63 RID: 260707 RVA: 0x01051664 File Offset: 0x0104F864
		private void RefreshLockPanel()
		{
			UUIArtText artText = base.GetArtText(7);
			if (artText != null)
			{
				artText.SetColor(FColor.FromHex("4c4c4c"));
			}
			UUIArtText artText2 = base.GetArtText(8);
			if (artText2 != null)
			{
				artText2.SetColor(FColor.FromHex("8f8f8e"));
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(2);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			if (!this.IsOpen)
			{
				base.GetText(4).SetText(ControllerBase<ActivityTetrisController>.Instance.GetTetrisData().GetUnlockDesc(this.ChallengeId.Value), true);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Tetristext_12", Array.Empty<object>());
		}

		// Token: 0x0603FA64 RID: 260708 RVA: 0x01051730 File Offset: 0x0104F930
		private bool CheckAllChallengesComplete()
		{
			ActivityTetrisData tetrisData = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData();
			if (tetrisData == null || this.LevelData == null)
			{
				return false;
			}
			foreach (int challengeId in this.LevelData.ChallengeIds)
			{
				if (!tetrisData.CheckChallengeComplete(challengeId))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603FA65 RID: 260709 RVA: 0x010517AC File Offset: 0x0104F9AC
		private void RefreshRedPoint()
		{
			ActivityTetrisData tetrisData = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData();
			if (tetrisData == null)
			{
				return;
			}
			bool uiactive = tetrisData.CheckGroupRedPointShow(this.LevelData.ChallengeIds);
			UUIItem item = base.GetItem(12);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x0603FA66 RID: 260710 RVA: 0x010517F0 File Offset: 0x0104F9F0
		public void PlayAnim(string sequenceName)
		{
			if (this.ViewSequencePlayer.GetCurrentSequence() == sequenceName)
			{
				this.ViewSequencePlayer.ReplaySequenceByKey(sequenceName);
				return;
			}
			this.ViewSequencePlayer.StopPlayingSequence(false, true);
			this.ViewSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
		}

		// Token: 0x0603FA67 RID: 260711 RVA: 0x01051844 File Offset: 0x0104FA44
		public void RefreshTimeTick(float deltaTime)
		{
			if (ControllerBase<ActivityTetrisController>.Instance.GetTetrisData() == null)
			{
				return;
			}
			if (this.LevelData == null)
			{
				return;
			}
			bool isOpen = this.IsOpen;
			this.IsOpen = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData().CheckChallengeIsOpen(this.LevelData.ChallengeIds[0]);
			if (isOpen != this.IsOpen)
			{
				this.IsPrevComplete = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData().CheckPreChallengeComplete(this.LevelData.ChallengeIds[0]);
				this.IsComplete = this.CheckAllChallengesComplete();
				this.RefreshPanel();
				this.RefreshRedPoint();
				return;
			}
			if (!this.IsOpen)
			{
				base.GetText(4).SetText(ControllerBase<ActivityTetrisController>.Instance.GetTetrisData().GetUnlockDesc(this.ChallengeId.Value), true);
			}
		}

		// Token: 0x0603FA68 RID: 260712 RVA: 0x0105190C File Offset: 0x0104FB0C
		private void OnClickedSelectButton()
		{
			if (!this.IsOpen)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Encirle_LevelLockTips_Text", Array.Empty<object>());
				return;
			}
			if (this.IsPrevComplete)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.TetrisLevelDetailView, this.LevelData, null);
				return;
			}
			int unlockId = ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(this.ChallengeId.Value).UnlockId;
			if (unlockId == 0)
			{
				return;
			}
			string levelName = ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(unlockId).LevelName;
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(levelName, levelName);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Encirle_DifficultyLockTips_Text", new object[]
			{
				multiTextByKey
			});
		}

		// Token: 0x04023BCA RID: 146378
		[Nullable(2)]
		private ITetrisSelectGroupData LevelData;

		// Token: 0x04023BCB RID: 146379
		private bool IsOpen;

		// Token: 0x04023BCC RID: 146380
		private bool IsPrevComplete;

		// Token: 0x04023BCD RID: 146381
		private int? ChallengeId;

		// Token: 0x04023BCE RID: 146382
		[Nullable(2)]
		private LevelSequencePlayer ViewSequencePlayer;

		// Token: 0x04023BCF RID: 146383
		private bool IsComplete;

		// Token: 0x04023BD0 RID: 146384
		private int TickId = -1;
	}
}
