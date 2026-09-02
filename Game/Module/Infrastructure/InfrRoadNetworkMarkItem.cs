using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C6B RID: 23659
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrRoadNetworkMarkItem : UiPanelBase
	{
		// Token: 0x0603BC92 RID: 244882 RVA: 0x00F27F60 File Offset: 0x00F26160
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickBtnToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x170097EC RID: 38892
		// (get) Token: 0x0603BC93 RID: 244883 RVA: 0x00F28110 File Offset: 0x00F26310
		private InfrRoadBuild Config
		{
			get
			{
				return ConfigBase<InfrastructureConfig>.Instance.GetRoadConfigById(this.RoadId).Value;
			}
		}

		// Token: 0x0603BC94 RID: 244884 RVA: 0x00F28135 File Offset: 0x00F26335
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
			this.SeqPlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
		}

		// Token: 0x0603BC95 RID: 244885 RVA: 0x00F28160 File Offset: 0x00F26360
		protected override void OnAfterShow()
		{
			if (!this.NeedPlayFinishSeq)
			{
				LevelSequencePlayer seqPlayer = this.SeqPlayer;
				if (seqPlayer == null)
				{
					return;
				}
				seqPlayer.PlayLevelSequenceByName("Start", false, null, false);
			}
		}

		// Token: 0x0603BC96 RID: 244886 RVA: 0x00F28195 File Offset: 0x00F26395
		public void Refresh(int roadId)
		{
			this.RoadId = roadId;
			this.RefreshDifficulty();
			this.RefreshTopRightIcon();
			this.RefreshPanel();
		}

		// Token: 0x0603BC97 RID: 244887 RVA: 0x00F281B0 File Offset: 0x00F263B0
		private void RefreshDifficulty()
		{
			InfrastructureDefine.IInfrRoadData roadDataByRoadId = ModelBase<InfrastructureModel>.Instance.GetRoadDataByRoadId(this.RoadId);
			if (roadDataByRoadId != null && roadDataByRoadId.Status == InfrStatusPb.InfrStatusProgress)
			{
				int difficulty = this.Config.Difficulty;
				UiResource? uiResource;
				string path = (ConfigBase<UiResourceConfig>.Instance.GetResourceConfig(InfrastructureDefine.difficultySpriteResourceId[difficulty]) != null) ? uiResource.GetValueOrDefault().Path : null;
				this.SetSpriteByPath(path, base.GetSprite(5), true, null, null);
				return;
			}
			UUISprite sprite = base.GetSprite(5);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(false);
		}

		// Token: 0x0603BC98 RID: 244888 RVA: 0x00F28250 File Offset: 0x00F26450
		private void RefreshTopRightIcon()
		{
			InfrastructureModel instance = ModelBase<InfrastructureModel>.Instance;
			InfrastructureDefine.IInfrRoadData roadDataByRoadId = instance.GetRoadDataByRoadId(this.RoadId);
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUISprite sprite2 = base.GetSprite(3);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(false);
			}
			if (roadDataByRoadId == null || (roadDataByRoadId != null && roadDataByRoadId.Status == InfrStatusPb.InfrStatusLock))
			{
				UUIItem item = base.GetItem(2);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				UUIItem item2 = base.GetItem(1);
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
				LevelSequencePlayer seqPlayer = this.SeqPlayer;
				if (seqPlayer == null)
				{
					return;
				}
				seqPlayer.PlayLevelSequenceByName("LockState", false, null, false);
				return;
			}
			else
			{
				if (instance.TracedRoadId != this.RoadId)
				{
					if (instance.RecommendRoadId == this.RoadId)
					{
						UUISprite sprite3 = base.GetSprite(4);
						if (sprite3 == null)
						{
							return;
						}
						sprite3.SetUIActive(true);
					}
					return;
				}
				UUISprite sprite4 = base.GetSprite(3);
				if (sprite4 == null)
				{
					return;
				}
				sprite4.SetUIActive(true);
				return;
			}
		}

		// Token: 0x0603BC99 RID: 244889 RVA: 0x00F2832C File Offset: 0x00F2652C
		private void RefreshPanel()
		{
			InfrastructureDefine.IInfrRoadData roadDataByRoadId = ModelBase<InfrastructureModel>.Instance.GetRoadDataByRoadId(this.RoadId);
			InfrStatusPb infrStatusPb = (roadDataByRoadId != null) ? roadDataByRoadId.Status : InfrStatusPb.InfrStatusLock;
			if (infrStatusPb == InfrStatusPb.InfrStatusLock)
			{
				UUIItem item = base.GetItem(8);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUINiagara uiNiagara = base.GetUiNiagara(7);
				if (uiNiagara != null)
				{
					uiNiagara.SetUIActive(false);
				}
			}
			else if (infrStatusPb == InfrStatusPb.InfrStatusComplete)
			{
				if (!this.NeedPlayFinishSeq || this.FinishId != this.RoadId)
				{
					UUIItem item2 = base.GetItem(8);
					if (item2 != null)
					{
						item2.SetUIActive(false);
					}
					UUIItem item3 = base.GetItem(2);
					if (item3 != null)
					{
						item3.SetUIActive(true);
					}
					UUIItem item4 = base.GetItem(1);
					if (item4 != null)
					{
						item4.SetUIActive(true);
					}
					UUINiagara uiNiagara2 = base.GetUiNiagara(7);
					if (uiNiagara2 != null)
					{
						uiNiagara2.SetUIActive(true);
					}
					UUIItem item5 = base.GetItem(6);
					if (item5 != null)
					{
						item5.SetUIActive(true);
					}
				}
			}
			else
			{
				UUIItem item6 = base.GetItem(8);
				if (item6 != null)
				{
					item6.SetUIActive(false);
				}
				UUINiagara uiNiagara3 = base.GetUiNiagara(7);
				if (uiNiagara3 != null)
				{
					uiNiagara3.SetUIActive(true);
				}
			}
			bool roadMaterialEnough = ModelBase<InfrastructureModel>.Instance.GetRoadMaterialEnough(this.RoadId);
			UUIItem item7 = base.GetItem(9);
			if (item7 == null)
			{
				return;
			}
			item7.SetUIActive(roadMaterialEnough && infrStatusPb == InfrStatusPb.InfrStatusProgress);
		}

		// Token: 0x0603BC9A RID: 244890 RVA: 0x00F28458 File Offset: 0x00F26658
		public void SetOnClickToggleCb(Action<int> cb)
		{
			this.OnClickToggleCb = cb;
		}

		// Token: 0x0603BC9B RID: 244891 RVA: 0x00F28461 File Offset: 0x00F26661
		private void OnClickBtnToggle(EToggleState _)
		{
			Action<int> onClickToggleCb = this.OnClickToggleCb;
			if (onClickToggleCb == null)
			{
				return;
			}
			onClickToggleCb(this.RoadId);
		}

		// Token: 0x0603BC9C RID: 244892 RVA: 0x00F28479 File Offset: 0x00F26679
		public void SetSelected(bool selected)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			if (selected)
			{
				Action<int> onClickToggleCb = this.OnClickToggleCb;
				if (onClickToggleCb == null)
				{
					return;
				}
				onClickToggleCb(this.RoadId);
			}
		}

		// Token: 0x0603BC9D RID: 244893 RVA: 0x00F284B1 File Offset: 0x00F266B1
		public void SetNeedPlayFinishSeq(bool needPlayFinishSeq, int finishId)
		{
			this.NeedPlayFinishSeq = needPlayFinishSeq;
			this.FinishId = finishId;
		}

		// Token: 0x0603BC9E RID: 244894 RVA: 0x00F284C4 File Offset: 0x00F266C4
		public void ShowMarkFinish(Action cb)
		{
			this.NeedPlayFinishSeq = false;
			this.RefreshPanel();
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.PlayLevelSequenceByName("Finish", false, null, false);
			}
			this.OnFinishPlayEnd = cb;
		}

		// Token: 0x0603BC9F RID: 244895 RVA: 0x00F28508 File Offset: 0x00F26708
		public void ShowMarkUnlock(Action cb)
		{
			ModelBase<InfrastructureModel>.Instance.SetUnlockRoadMarkPlaySeq(this.RoadId);
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.PlayLevelSequenceByName("Unlock", false, null, false);
			}
			this.OnUnlockPlayEnd = cb;
		}

		// Token: 0x0603BCA0 RID: 244896 RVA: 0x00F28550 File Offset: 0x00F26750
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Finish")
			{
				Action onFinishPlayEnd = this.OnFinishPlayEnd;
				if (onFinishPlayEnd != null)
				{
					onFinishPlayEnd();
				}
				this.OnFinishPlayEnd = null;
				return;
			}
			if (sequenceName == "Unlock")
			{
				Action onUnlockPlayEnd = this.OnUnlockPlayEnd;
				if (onUnlockPlayEnd != null)
				{
					onUnlockPlayEnd();
				}
				this.OnUnlockPlayEnd = null;
			}
		}

		// Token: 0x0603BCA1 RID: 244897 RVA: 0x00F285A8 File Offset: 0x00F267A8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			UUIItem uuiitem = (extendToggle != null) ? extendToggle.GetRootComponent() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x04021987 RID: 137607
		private int RoadId;

		// Token: 0x04021988 RID: 137608
		private bool NeedPlayFinishSeq;

		// Token: 0x04021989 RID: 137609
		private int FinishId;

		// Token: 0x0402198A RID: 137610
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0402198B RID: 137611
		private Action<int> OnClickToggleCb;

		// Token: 0x0402198C RID: 137612
		private Action OnFinishPlayEnd;

		// Token: 0x0402198D RID: 137613
		private Action OnUnlockPlayEnd;

		// Token: 0x0200BD18 RID: 48408
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403A466 RID: 238694
			public const int Toggle = 0;

			// Token: 0x0403A467 RID: 238695
			public const int PanelIcon = 1;

			// Token: 0x0403A468 RID: 238696
			public const int PanelNor = 2;

			// Token: 0x0403A469 RID: 238697
			public const int SpriteTarget = 3;

			// Token: 0x0403A46A RID: 238698
			public const int SpriteRecommend = 4;

			// Token: 0x0403A46B RID: 238699
			public const int SpriteStar = 5;

			// Token: 0x0403A46C RID: 238700
			public const int PanelDone = 6;

			// Token: 0x0403A46D RID: 238701
			public const int NiagaraUnlock = 7;

			// Token: 0x0403A46E RID: 238702
			public const int PanelLock = 8;

			// Token: 0x0403A46F RID: 238703
			public const int PanelUpgrade = 9;
		}
	}
}
