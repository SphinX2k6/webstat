using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062CF RID: 25295
	public class TetrisDetailIconPanel : UiPanelBase
	{
		// Token: 0x0603FA13 RID: 260627 RVA: 0x0104EEBC File Offset: 0x0104D0BC
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
		}

		// Token: 0x0603FA14 RID: 260628 RVA: 0x0104F024 File Offset: 0x0104D224
		[NullableContext(1)]
		public void Refresh(ITetrisSelectGroupData data)
		{
			this.LevelData = data;
			this.ChallengeId = new int?(this.LevelData.ChallengeIds[0]);
			this.IsOpen = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData().CheckChallengeIsOpen(this.LevelData.ChallengeIds[0]);
			this.IsPrevComplete = ControllerBase<ActivityTetrisController>.Instance.GetTetrisData().CheckPreChallengeComplete(this.LevelData.ChallengeIds[0]);
			this.IsComplete = this.CheckAllChallengesComplete();
			this.RefreshPanel();
		}

		// Token: 0x0603FA15 RID: 260629 RVA: 0x0104F0B4 File Offset: 0x0104D2B4
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

		// Token: 0x0603FA16 RID: 260630 RVA: 0x0104F13C File Offset: 0x0104D33C
		private void RefreshCompletePanel()
		{
			if (TetrisUtils.IsEggLevel(ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(this.ChallengeId.Value)))
			{
				UUIItem item = base.GetItem(14);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(13);
				if (item2 != null)
				{
					item2.SetUIActive(false);
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
				UUIItem item3 = base.GetItem(13);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
				UUIItem item4 = base.GetItem(14);
				if (item4 != null)
				{
					item4.SetUIActive(false);
				}
			}
			UUIItem item5 = base.GetItem(1);
			if (item5 != null)
			{
				item5.SetUIActive(true);
			}
			UUIItem item6 = base.GetItem(2);
			if (item6 != null)
			{
				item6.SetUIActive(false);
			}
			UUIItem item7 = base.GetItem(3);
			if (item7 != null)
			{
				item7.SetUIActive(false);
			}
			UUIArtText artText3 = base.GetArtText(7);
			if (artText3 != null)
			{
				artText3.SetColor(FColor.FromHex("5c89a0"));
			}
			UUIArtText artText4 = base.GetArtText(8);
			if (artText4 == null)
			{
				return;
			}
			artText4.SetColor(FColor.FromHex("7bffad"));
		}

		// Token: 0x0603FA17 RID: 260631 RVA: 0x0104F258 File Offset: 0x0104D458
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
			if (item5 == null)
			{
				return;
			}
			item5.SetUIActive(false);
		}

		// Token: 0x0603FA18 RID: 260632 RVA: 0x0104F348 File Offset: 0x0104D548
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
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
		}

		// Token: 0x0603FA19 RID: 260633 RVA: 0x0104F3C8 File Offset: 0x0104D5C8
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

		// Token: 0x04023B85 RID: 146309
		[Nullable(2)]
		private ITetrisSelectGroupData LevelData;

		// Token: 0x04023B86 RID: 146310
		private int? ChallengeId;

		// Token: 0x04023B87 RID: 146311
		private bool IsOpen;

		// Token: 0x04023B88 RID: 146312
		private bool IsPrevComplete;

		// Token: 0x04023B89 RID: 146313
		private bool IsComplete;
	}
}
