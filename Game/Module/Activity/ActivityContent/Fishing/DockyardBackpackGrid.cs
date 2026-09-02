using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006792 RID: 26514
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DockyardBackpackGrid : GridProxyAbstract<IPanelPos>
	{
		// Token: 0x1700A0D4 RID: 41172
		// (get) Token: 0x06042187 RID: 270727 RVA: 0x010F53F8 File Offset: 0x010F35F8
		// (set) Token: 0x06042188 RID: 270728 RVA: 0x010F5400 File Offset: 0x010F3600
		public EFishingGridShowType ShowType
		{
			get
			{
				return this.ShowTypeInternal;
			}
			set
			{
				if (this.ShowTypeInternal == value)
				{
					return;
				}
				this.ShowTypeInternal = value;
				this.StateFunc[value]();
			}
		}

		// Token: 0x06042189 RID: 270729 RVA: 0x010F5424 File Offset: 0x010F3624
		private void SetDisableState()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GridSellDisable");
			this.SetSpriteByPath(resourcePath, this.BgSprite, false, null, null);
			this.BgSprite.SetUIActive(true);
		}

		// Token: 0x0604218A RID: 270730 RVA: 0x010F5468 File Offset: 0x010F3668
		private void SetEmptyState()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GridEmpty");
			this.SetSpriteByPath(resourcePath, this.BgSprite, false, null, null);
			this.BgSprite.SetUIActive(true);
		}

		// Token: 0x0604218B RID: 270731 RVA: 0x010F54AC File Offset: 0x010F36AC
		private void SetPreviewState()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GridFinsh");
			this.SetSpriteByPath(resourcePath, this.BgSprite, false, null, null);
			this.BgSprite.SetUIActive(true);
		}

		// Token: 0x0604218C RID: 270732 RVA: 0x010F54F0 File Offset: 0x010F36F0
		private void SetSingleOccupancyState()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GridReplace");
			this.SetSpriteByPath(resourcePath, this.BgSprite, false, null, null);
			this.BgSprite.SetUIActive(true);
		}

		// Token: 0x0604218D RID: 270733 RVA: 0x010F5534 File Offset: 0x010F3734
		private void SetMultiOccupancyState()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GridError");
			this.SetSpriteByPath(resourcePath, this.BgSprite, false, null, null);
			this.BgSprite.SetUIActive(true);
		}

		// Token: 0x0604218E RID: 270734 RVA: 0x010F5578 File Offset: 0x010F3778
		private void SetProhibitState()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GridError");
			this.SetSpriteByPath(resourcePath, this.BgSprite, false, null, null);
			this.BgSprite.SetUIActive(true);
		}

		// Token: 0x0604218F RID: 270735 RVA: 0x010F55BC File Offset: 0x010F37BC
		private void SetFinishState()
		{
			int previewBackpackData = this.ParentModel.GetPreviewBackpackData(this.BackpackGridPos);
			DockyardItemBlockData itemBlockData = this.ParentModel.BackpackData.GetItemBlockData(previewBackpackData);
			this.SetSpriteByPath(ConfigBase<FishingConfig>.Instance.GetFishingQualityConfig(itemBlockData.Data.Quality).GridSprite, this.BgSprite, false, null, null);
			this.BgSprite.SetUIActive(true);
		}

		// Token: 0x06042190 RID: 270736 RVA: 0x010F5630 File Offset: 0x010F3830
		public DockyardBackpackGrid(DockyardBackpackPanelModelBase parentModel)
		{
			this.ParentModel = parentModel;
			this.StateFunc = new Dictionary<EFishingGridShowType, Action>
			{
				{
					EFishingGridShowType.None,
					null
				},
				{
					EFishingGridShowType.Disable,
					new Action(this.SetDisableState)
				},
				{
					EFishingGridShowType.Empty,
					new Action(this.SetEmptyState)
				},
				{
					EFishingGridShowType.Preview,
					new Action(this.SetPreviewState)
				},
				{
					EFishingGridShowType.SingleOccupancy,
					new Action(this.SetSingleOccupancyState)
				},
				{
					EFishingGridShowType.MultiOccupancy,
					new Action(this.SetMultiOccupancyState)
				},
				{
					EFishingGridShowType.Prohibit,
					new Action(this.SetProhibitState)
				},
				{
					EFishingGridShowType.Finish,
					new Action(this.SetFinishState)
				}
			};
		}

		// Token: 0x06042191 RID: 270737 RVA: 0x010F56E4 File Offset: 0x010F38E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042192 RID: 270738 RVA: 0x010F5770 File Offset: 0x010F3970
		protected override void OnStart()
		{
			this.BgSprite = base.GetSprite(0);
			this.QuicklySellSprite = base.GetSprite(1);
			this.SequencePlayer = new UiSequencePlayer(this.QuicklySellSprite);
			this.RootSequence = new UiSequencePlayer(this.RootItem);
			this.SetSpriteMaskActive(false);
		}

		// Token: 0x06042193 RID: 270739 RVA: 0x010F57C0 File Offset: 0x010F39C0
		protected override void OnBeforeDestroy()
		{
			this.SequencePlayer.Clear();
			this.RootSequence.Clear();
		}

		// Token: 0x06042194 RID: 270740 RVA: 0x010F57D8 File Offset: 0x010F39D8
		private void SetQuicklySellSuccessState()
		{
			this.QuicklySellSprite.SetColor(FColor.FromHex("#DAC8AC"));
			this.QuicklySellSprite.SetUIActive(true);
			if (!this.SequencePlayer.IsSequenceInPlaying("Activate"))
			{
				this.SequencePlayer.PlaySequencePurely("Activate", false, false);
			}
		}

		// Token: 0x06042195 RID: 270741 RVA: 0x010F582C File Offset: 0x010F3A2C
		private void SetQuicklySellFailureState()
		{
			this.QuicklySellSprite.SetColor(FColor.FromHex("#F88D99"));
			this.QuicklySellSprite.SetUIActive(true);
			if (!this.SequencePlayer.IsSequenceInPlaying("Activate"))
			{
				this.SequencePlayer.PlaySequencePurely("Activate", false, false);
			}
		}

		// Token: 0x06042196 RID: 270742 RVA: 0x010F5880 File Offset: 0x010F3A80
		private void SetQuicklySellNormalState()
		{
			this.QuicklySellSprite.SetUIActive(this.BackpackGridData.IsQuicklySell);
			this.SequencePlayer.StopSequenceByKey("Activate", true, true);
			if (this.BackpackGridData.IsQuicklySell)
			{
				this.QuicklySellSprite.SetColor(FColor.FromHex("#FFFFFF"));
			}
		}

		// Token: 0x06042197 RID: 270743 RVA: 0x010F58D7 File Offset: 0x010F3AD7
		public bool InDisable()
		{
			return !this.BackpackGridData.IsValid;
		}

		// Token: 0x06042198 RID: 270744 RVA: 0x010F58E7 File Offset: 0x010F3AE7
		public bool IsQuicklySell()
		{
			return this.BackpackGridData.IsQuicklySell;
		}

		// Token: 0x06042199 RID: 270745 RVA: 0x010F58F4 File Offset: 0x010F3AF4
		public override void Refresh(IPanelPos pos, bool isSelected, int gridIndex)
		{
			this.BackpackGridPos = pos;
			this.BackpackGridData = this.ParentModel.BackpackData.GetBackpackGridData(pos);
			this.QuicklySellSprite.SetUIActive(this.BackpackGridData.IsQuicklySell);
			this.ShowType = (this.InDisable() ? EFishingGridShowType.Disable : EFishingGridShowType.Empty);
		}

		// Token: 0x0604219A RID: 270746 RVA: 0x010F5948 File Offset: 0x010F3B48
		public void RefreshPreview(int id, EFishingGridShowType showType)
		{
			if (this.InDisable())
			{
				this.ShowType = EFishingGridShowType.Prohibit;
				return;
			}
			if (this.ParentModel.IsInSelectState)
			{
				this.SetSpriteMaskActive(false);
			}
			if (showType == EFishingGridShowType.Preview)
			{
				this.ParentModel.SetPreviewBackpackData(this.BackpackGridPos, id);
				this.ShowType = EFishingGridShowType.Preview;
				return;
			}
			if (showType == EFishingGridShowType.Finish)
			{
				this.ParentModel.SetPreviewBackpackData(this.BackpackGridPos, id);
				this.ShowType = EFishingGridShowType.Finish;
				return;
			}
			this.ShowType = showType;
		}

		// Token: 0x0604219B RID: 270747 RVA: 0x010F59BC File Offset: 0x010F3BBC
		public void RefreshQuicklySell(EFishingQuicklySellType showType)
		{
			if (showType == EFishingQuicklySellType.QuicklySellSuccess)
			{
				this.SetQuicklySellSuccessState();
				return;
			}
			if (showType == EFishingQuicklySellType.QuicklySellFailure)
			{
				this.SetQuicklySellFailureState();
				return;
			}
			if (showType == EFishingQuicklySellType.Normal)
			{
				this.SetQuicklySellNormalState();
			}
		}

		// Token: 0x0604219C RID: 270748 RVA: 0x010F59DD File Offset: 0x010F3BDD
		public void ResetQuicklySell()
		{
			this.RefreshQuicklySell(EFishingQuicklySellType.Normal);
		}

		// Token: 0x0604219D RID: 270749 RVA: 0x010F59E6 File Offset: 0x010F3BE6
		public void ResetPreviewBgForce()
		{
			if (this.InDisable())
			{
				this.ShowType = EFishingGridShowType.Disable;
				return;
			}
			this.ParentModel.SetPreviewBackpackData(this.BackpackGridPos, -1);
			this.ShowType = EFishingGridShowType.Empty;
		}

		// Token: 0x0604219E RID: 270750 RVA: 0x010F5A14 File Offset: 0x010F3C14
		public void ResetPreviewBg(int id)
		{
			if (this.InDisable())
			{
				this.ShowType = EFishingGridShowType.Disable;
				return;
			}
			int previewBackpackData = this.ParentModel.GetPreviewBackpackData(this.BackpackGridPos);
			if (previewBackpackData == id || previewBackpackData == -1)
			{
				this.ParentModel.SetPreviewBackpackData(this.BackpackGridPos, -1);
				this.ShowType = EFishingGridShowType.Empty;
				this.SetSpriteMaskActive(false);
				return;
			}
			this.ShowType = EFishingGridShowType.Finish;
			this.SetSpriteMaskActive(this.ParentModel.IsInSelectState);
		}

		// Token: 0x0604219F RID: 270751 RVA: 0x010F5A84 File Offset: 0x010F3C84
		public void SetItemBlockId(int id)
		{
			this.ParentModel.SetPreviewBackpackData(this.BackpackGridPos, id);
		}

		// Token: 0x060421A0 RID: 270752 RVA: 0x010F5A98 File Offset: 0x010F3C98
		public int GetItemBlockId()
		{
			return this.ParentModel.GetPreviewBackpackData(this.BackpackGridPos);
		}

		// Token: 0x060421A1 RID: 270753 RVA: 0x010F5AAB File Offset: 0x010F3CAB
		public override object GetKey(IPanelPos data, int displayIndex)
		{
			return data;
		}

		// Token: 0x060421A2 RID: 270754 RVA: 0x010F5AAE File Offset: 0x010F3CAE
		public void SetSpriteMaskActive(bool value)
		{
			base.GetSprite(2).SetUIActive(value);
		}

		// Token: 0x060421A3 RID: 270755 RVA: 0x010F5ABD File Offset: 0x010F3CBD
		public void PlaySequence(string sequenceName)
		{
			this.RootSequence.StopPrevSequence(false, true);
			this.RootSequence.PlaySequencePurely(sequenceName, false, false);
		}

		// Token: 0x04024D78 RID: 150904
		private DockyardBackpackGridData BackpackGridData;

		// Token: 0x04024D79 RID: 150905
		private IPanelPos BackpackGridPos;

		// Token: 0x04024D7A RID: 150906
		private readonly DockyardBackpackPanelModelBase ParentModel;

		// Token: 0x04024D7B RID: 150907
		private EFishingGridShowType ShowTypeInternal;

		// Token: 0x04024D7C RID: 150908
		private UUISprite BgSprite;

		// Token: 0x04024D7D RID: 150909
		private UUISprite QuicklySellSprite;

		// Token: 0x04024D7E RID: 150910
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04024D7F RID: 150911
		private UiSequencePlayer RootSequence;

		// Token: 0x04024D80 RID: 150912
		private readonly Dictionary<EFishingGridShowType, Action> StateFunc;

		// Token: 0x0200C7B5 RID: 51125
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D7AC RID: 251820
			public const int BgSprite = 0;

			// Token: 0x0403D7AD RID: 251821
			public const int QuicklySellSprite = 1;

			// Token: 0x0403D7AE RID: 251822
			public const int SpriteMask = 2;
		}
	}
}
