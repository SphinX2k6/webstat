using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing.Components.TearItem
{
	// Token: 0x02006572 RID: 25970
	[NullableContext(2)]
	[Nullable(0)]
	public class PrizeDrawingTearCoverItem : PrizeDrawingTearCoverItemBase
	{
		// Token: 0x06040DEA RID: 265706 RVA: 0x010A341C File Offset: 0x010A161C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040DEB RID: 265707 RVA: 0x010A365C File Offset: 0x010A185C
		protected override void OnStart()
		{
			this.TearRoot = base.GetItem(1);
			this.TearShadowRoot = base.GetItem(5);
			TArray<UUIItem> attachUIChildren = this.TearRoot.GetAttachUIChildren();
			for (int i = 0; i < attachUIChildren.Num(); i++)
			{
				this.TearItemList.Add(attachUIChildren.Get(i));
			}
			TArray<UUIItem> attachUIChildren2 = this.TearShadowRoot.GetAttachUIChildren();
			for (int j = 0; j < attachUIChildren2.Num(); j++)
			{
				this.TearShadowItemList.Add(attachUIChildren2.Get(j));
			}
			this.EmojiItemList.AddRange(new UUIItem[]
			{
				base.GetItem(6),
				base.GetItem(7),
				base.GetItem(8),
				base.GetItem(9)
			});
			foreach (UUIItem uiItem in this.EmojiItemList)
			{
				this.EmojiSeqPlayerList.Add(new LevelSequencePlayer(uiItem));
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.InitializeFx();
		}

		// Token: 0x06040DEC RID: 265708 RVA: 0x010A3788 File Offset: 0x010A1988
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			foreach (LevelSequencePlayer levelSequencePlayer2 in this.EmojiSeqPlayerList)
			{
				levelSequencePlayer2.Clear();
			}
			if (this.LoopAudioHandle != null)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.LoopAudioHandle.Value, EAudioActionType.Stop, null);
			}
		}

		// Token: 0x06040DED RID: 265709 RVA: 0x010A3818 File Offset: 0x010A1A18
		public void OnTick(float progress)
		{
			if (this.IsOpened)
			{
				return;
			}
			if (progress > 0.1f && !this.IsDragStarted)
			{
				this.IsDragStarted = true;
				this.OnFirstStartDrag();
			}
			float num = 1f / (float)this.TearItemList.Count;
			float alpha = Math.Abs(progress % num) / num;
			int num2 = (int)Math.Floor((double)(progress / num));
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 >= this.TearItemList.Count)
			{
				this.PlayRevelAnimation();
				this.Open(true);
				return;
			}
			if (this.CachedSelectedIndex != num2)
			{
				if (num2 > this.CachedTearAudioIndex)
				{
					this.CachedTearAudioIndex = num2;
					Singleton<AudioSystem>.Instance.PostEvent("play_ui_prizedrawing_ticket_tear_new_click");
				}
				else if (num2 < this.CachedSelectedIndex)
				{
					Singleton<AudioSystem>.Instance.PostEvent("play_ui_prizedrawing_ticket_tear_back");
				}
				else
				{
					Singleton<AudioSystem>.Instance.PostEvent("play_ui_prizedrawing_ticket_tear_torn_click");
				}
				this.SetTearActive(num2);
			}
			int num3 = num2 - 1;
			if (num3 > this.CachedEmojiIndex)
			{
				this.SetEmojiActive(num3);
				this.EmojiSeqPlayerList[num3].PlaySequencePurely("Emoji", false, false, null, null, false);
			}
			if (num3 == -1)
			{
				this.SetEmojiActive(-1);
			}
			float from = (num2 - 1 >= 0 && num2 - 1 < PrizeDrawingTearCoverItemConstants.ShineDissolve.Length) ? PrizeDrawingTearCoverItemConstants.ShineDissolve[num2 - 1] : 0f;
			float to = (num2 < PrizeDrawingTearCoverItemConstants.ShineDissolve.Length) ? PrizeDrawingTearCoverItemConstants.ShineDissolve[num2] : 0f;
			float value = Singleton<MathUtils>.Instance.Lerp(from, to, alpha);
			UUINiagara shineItem = this.ShineItem;
			if (shineItem != null)
			{
				shineItem.SetNiagaraVarFloat("Dissolve", value);
			}
			UUINiagara shineItemMinor = this.ShineItemMinor;
			if (shineItemMinor != null)
			{
				shineItemMinor.SetNiagaraVarFloat("Dissolve", value);
			}
			float from2 = (num2 - 1 >= 0 && num2 - 1 < PrizeDrawingTearCoverItemConstants.GlowMaskOffsetV.Length) ? PrizeDrawingTearCoverItemConstants.GlowMaskOffsetV[num2 - 1] : -4f;
			float to2 = (num2 < PrizeDrawingTearCoverItemConstants.GlowMaskOffsetV.Length) ? PrizeDrawingTearCoverItemConstants.GlowMaskOffsetV[num2] : -4f;
			this.GlowOffsetVector.A = Singleton<MathUtils>.Instance.Lerp(from2, to2, alpha);
			UUITexture glowItem = this.GlowItem;
			if (glowItem != null)
			{
				glowItem.SetCustomMaterialVectorParameter(PrizeDrawingTearCoverItemConstants.GLOW_MASK_UV_NAME, this.GlowOffsetVector);
			}
			UUITexture glowItemMinor = this.GlowItemMinor;
			if (glowItemMinor != null)
			{
				glowItemMinor.SetCustomMaterialVectorParameter(PrizeDrawingTearCoverItemConstants.GLOW_MASK_UV_NAME, this.GlowOffsetVector);
			}
			float from3 = (num2 - 1 >= 0 && num2 - 1 < PrizeDrawingTearCoverItemConstants.GlowAlpha.Length) ? PrizeDrawingTearCoverItemConstants.GlowAlpha[num2 - 1] : 0f;
			float to3 = (num2 < PrizeDrawingTearCoverItemConstants.GlowAlpha.Length) ? PrizeDrawingTearCoverItemConstants.GlowAlpha[num2] : 0f;
			float alpha2 = Singleton<MathUtils>.Instance.Lerp(from3, to3, alpha);
			UUITexture glowItem2 = this.GlowItem;
			if (glowItem2 != null)
			{
				glowItem2.SetAlpha(alpha2);
			}
			UUITexture glowItemMinor2 = this.GlowItemMinor;
			if (glowItemMinor2 != null)
			{
				glowItemMinor2.SetAlpha(alpha2);
			}
			Singleton<AudioSystem>.Instance.SetRtpcValue("sys_game_prizedrawing_ticket_torn", progress * 100f, null);
		}

		// Token: 0x06040DEE RID: 265710 RVA: 0x010A3ADD File Offset: 0x010A1CDD
		public bool IsUnOpened()
		{
			return !this.IsOpened;
		}

		// Token: 0x06040DEF RID: 265711 RVA: 0x010A3AE8 File Offset: 0x010A1CE8
		private void SetTearActive(int index)
		{
			if (this.CachedSelectedIndex >= 0 && this.CachedSelectedIndex < this.TearItemList.Count)
			{
				UUIItem uuiitem = this.TearItemList[this.CachedSelectedIndex];
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(false);
				}
			}
			if (index >= 0 && index < this.TearItemList.Count)
			{
				UUIItem uuiitem2 = this.TearItemList[index];
				if (uuiitem2 != null)
				{
					uuiitem2.SetUIActive(true);
				}
			}
			if (this.CachedSelectedIndex >= 0 && this.CachedSelectedIndex < this.TearShadowItemList.Count)
			{
				UUIItem uuiitem3 = this.TearShadowItemList[this.CachedSelectedIndex];
				if (uuiitem3 != null)
				{
					uuiitem3.SetUIActive(false);
				}
			}
			if (index >= 0 && index < this.TearShadowItemList.Count)
			{
				UUIItem uuiitem4 = this.TearShadowItemList[index];
				if (uuiitem4 != null)
				{
					uuiitem4.SetUIActive(true);
				}
			}
			this.CachedSelectedIndex = index;
		}

		// Token: 0x06040DF0 RID: 265712 RVA: 0x010A3BC4 File Offset: 0x010A1DC4
		private void SetEmojiActive(int index)
		{
			if (this.CachedEmojiIndex >= 0 && this.CachedEmojiIndex < this.EmojiItemList.Count)
			{
				UUIItem uuiitem = this.EmojiItemList[this.CachedEmojiIndex];
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(false);
				}
			}
			if (index >= 0 && index < this.EmojiItemList.Count)
			{
				UUIItem uuiitem2 = this.EmojiItemList[index];
				if (uuiitem2 != null)
				{
					uuiitem2.SetUIActive(true);
				}
			}
			this.CachedEmojiIndex = index;
		}

		// Token: 0x06040DF1 RID: 265713 RVA: 0x010A3C3B File Offset: 0x010A1E3B
		public void SetTearShadowActive(bool active)
		{
			UUIItem tearShadowRoot = this.TearShadowRoot;
			if (tearShadowRoot == null)
			{
				return;
			}
			tearShadowRoot.SetUIActive(active);
		}

		// Token: 0x06040DF2 RID: 265714 RVA: 0x010A3C50 File Offset: 0x010A1E50
		public void Open(bool playAudio)
		{
			this.IsOpened = true;
			UUIItem tearRoot = this.TearRoot;
			if (tearRoot != null)
			{
				tearRoot.SetUIActive(false);
			}
			UUIItem tearShadowRoot = this.TearShadowRoot;
			if (tearShadowRoot != null)
			{
				tearShadowRoot.SetUIActive(false);
			}
			this.SetEmojiActive(-1);
			this.OnOpened();
			if (!playAudio)
			{
				return;
			}
			if (this.FxLevel != EFxLevel.None)
			{
				if (this.LoopAudioHandle != null)
				{
					Singleton<AudioSystem>.Instance.ExecuteAction(this.LoopAudioHandle.Value, EAudioActionType.Stop, null);
					this.LoopAudioHandle = null;
				}
				Singleton<AudioSystem>.Instance.SetRtpcValue("sys_game_prizedrawing_ticket_torn", 0f, null);
				Singleton<AudioSystem>.Instance.PostEvent("stop_ui_prizedrawing_ticket_bigprize_light_loop");
			}
			switch (this.FxLevel)
			{
			case EFxLevel.None:
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_prizedrawing_ticket_tear_new_click");
				return;
			case EFxLevel.Minor:
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_prizedrawing_ticket_normalprize_light_finish");
				return;
			case EFxLevel.Super:
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_prizedrawing_ticket_bigprize_light_finish");
				return;
			default:
				return;
			}
		}

		// Token: 0x06040DF3 RID: 265715 RVA: 0x010A3D52 File Offset: 0x010A1F52
		public void PlayRevelAnimation()
		{
			PrizeDrawingTearItemBase tearItem = this.TearItem;
			if (tearItem == null)
			{
				return;
			}
			tearItem.PlayRevelAnimation();
		}

		// Token: 0x06040DF4 RID: 265716 RVA: 0x010A3D64 File Offset: 0x010A1F64
		private void OnFirstStartDrag()
		{
			if (this.FxLevel == EFxLevel.Super)
			{
				UUINiagara burstItem = this.BurstItem;
				if (burstItem != null)
				{
					burstItem.SetUIActive(true);
				}
			}
			else if (this.FxLevel == EFxLevel.Minor)
			{
				UUINiagara burstItemMinor = this.BurstItemMinor;
				if (burstItemMinor != null)
				{
					burstItemMinor.SetUIActive(true);
				}
			}
			if (this.FxLevel != EFxLevel.None)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_prizedrawing_ticket_bigprize_light_start");
			}
		}

		// Token: 0x06040DF5 RID: 265717 RVA: 0x010A3DC1 File Offset: 0x010A1FC1
		public void OnStartDragging()
		{
			if (this.FxLevel != EFxLevel.None)
			{
				this.LoopAudioHandle = new int?(Singleton<AudioSystem>.Instance.PostEvent("play_ui_prizedrawing_ticket_bigprize_light_loop"));
			}
		}

		// Token: 0x06040DF6 RID: 265718 RVA: 0x010A3DE8 File Offset: 0x010A1FE8
		public void OnStopDragging()
		{
			if (this.FxLevel != EFxLevel.None)
			{
				if (this.LoopAudioHandle != null)
				{
					Singleton<AudioSystem>.Instance.ExecuteAction(this.LoopAudioHandle.Value, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs(new int?(1000), null, null)));
					this.LoopAudioHandle = null;
				}
				Singleton<AudioSystem>.Instance.PostEvent("stop_ui_prizedrawing_ticket_bigprize_light_loop");
			}
		}

		// Token: 0x06040DF7 RID: 265719 RVA: 0x010A3E5A File Offset: 0x010A205A
		protected void OnOpened()
		{
			Action openedCallback = this.OpenedCallback;
			if (openedCallback == null)
			{
				return;
			}
			openedCallback();
		}

		// Token: 0x06040DF8 RID: 265720 RVA: 0x010A3E6C File Offset: 0x010A206C
		public void Reset()
		{
			this.IsOpened = false;
			this.TearRoot.SetUIActive(true);
			this.SetTearActive(0);
			UUINiagara shineItem = this.ShineItem;
			if (shineItem != null)
			{
				shineItem.SetNiagaraVarFloat("Dissolve", 0f);
			}
			UUINiagara shineItemMinor = this.ShineItemMinor;
			if (shineItemMinor != null)
			{
				shineItemMinor.SetNiagaraVarFloat("Dissolve", 0f);
			}
			this.GlowOffsetVector.A = -4f;
			UUITexture glowItem = this.GlowItem;
			if (glowItem != null)
			{
				glowItem.SetCustomMaterialVectorParameter(PrizeDrawingTearCoverItemConstants.GLOW_MASK_UV_NAME, this.GlowOffsetVector);
			}
			UUITexture glowItemMinor = this.GlowItemMinor;
			if (glowItemMinor != null)
			{
				glowItemMinor.SetCustomMaterialVectorParameter(PrizeDrawingTearCoverItemConstants.GLOW_MASK_UV_NAME, this.GlowOffsetVector);
			}
			UUITexture glowItem2 = this.GlowItem;
			if (glowItem2 != null)
			{
				glowItem2.SetAlpha(0f);
			}
			UUITexture glowItemMinor2 = this.GlowItemMinor;
			if (glowItemMinor2 != null)
			{
				glowItemMinor2.SetAlpha(0f);
			}
			UUINiagara burstItem = this.BurstItem;
			if (burstItem != null)
			{
				burstItem.SetUIActive(false);
			}
			UUINiagara burstItemMinor = this.BurstItemMinor;
			if (burstItemMinor != null)
			{
				burstItemMinor.SetUIActive(false);
			}
			this.CachedTearAudioIndex = 0;
			this.IsDragStarted = false;
		}

		// Token: 0x06040DF9 RID: 265721 RVA: 0x010A3F70 File Offset: 0x010A2170
		public void RefreshEffectVisible(EFxLevel fxLevel)
		{
			this.FxLevel = fxLevel;
			this.TearShadowRoot.SetUIActive(fxLevel == EFxLevel.None);
			UUIItem fxControl = this.FxControl;
			if (fxControl != null)
			{
				fxControl.SetUIActive(fxLevel == EFxLevel.Super);
			}
			UUIItem fxControl2 = this.FxControl;
			if (fxControl2 != null)
			{
				fxControl2.SetAlpha(fxLevel == EFxLevel.Super);
			}
			UUIItem fxControlMinor = this.FxControlMinor;
			if (fxControlMinor != null)
			{
				fxControlMinor.SetUIActive(fxLevel == EFxLevel.Minor);
			}
			UUIItem fxControlMinor2 = this.FxControlMinor;
			if (fxControlMinor2 == null)
			{
				return;
			}
			fxControlMinor2.SetAlpha(fxLevel == EFxLevel.Minor);
		}

		// Token: 0x06040DFA RID: 265722 RVA: 0x010A3FE8 File Offset: 0x010A21E8
		[NullableContext(1)]
		public UniTask CreateTearItem(List<IKujiAwardData> rewards, ETearType tearType)
		{
			PrizeDrawingTearCoverItem.<CreateTearItem>d__40 <CreateTearItem>d__;
			<CreateTearItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateTearItem>d__.<>4__this = this;
			<CreateTearItem>d__.rewards = rewards;
			<CreateTearItem>d__.tearType = tearType;
			<CreateTearItem>d__.<>1__state = -1;
			<CreateTearItem>d__.<>t__builder.Start<PrizeDrawingTearCoverItem.<CreateTearItem>d__40>(ref <CreateTearItem>d__);
			return <CreateTearItem>d__.<>t__builder.Task;
		}

		// Token: 0x06040DFB RID: 265723 RVA: 0x010A403B File Offset: 0x010A223B
		[NullableContext(1)]
		public UUIItem GetFxControl()
		{
			return this.FxControl;
		}

		// Token: 0x06040DFC RID: 265724 RVA: 0x010A4043 File Offset: 0x010A2243
		[NullableContext(1)]
		public UUIItem GetFxControlMinor()
		{
			return this.FxControlMinor;
		}

		// Token: 0x06040DFD RID: 265725 RVA: 0x010A404C File Offset: 0x010A224C
		private void InitializeFx()
		{
			this.ShineItem = base.GetUiNiagara(3);
			this.GlowItem = base.GetTexture(4);
			this.BurstItem = base.GetUiNiagara(2);
			this.ShineItemMinor = base.GetUiNiagara(13);
			this.BurstItemMinor = base.GetUiNiagara(12);
			this.GlowItemMinor = base.GetTexture(11);
			this.FxControl = base.GetItem(14);
			this.FxControlMinor = base.GetItem(15);
			UUINiagara shineItem = this.ShineItem;
			if (shineItem != null)
			{
				shineItem.SetUIActive(true);
			}
			UUITexture glowItem = this.GlowItem;
			if (glowItem != null)
			{
				glowItem.SetUIActive(true);
			}
			UUINiagara burstItem = this.BurstItem;
			if (burstItem != null)
			{
				burstItem.SetUIActive(false);
			}
			UUINiagara shineItemMinor = this.ShineItemMinor;
			if (shineItemMinor != null)
			{
				shineItemMinor.SetUIActive(true);
			}
			UUINiagara burstItemMinor = this.BurstItemMinor;
			if (burstItemMinor != null)
			{
				burstItemMinor.SetUIActive(false);
			}
			UUITexture glowItemMinor = this.GlowItemMinor;
			if (glowItemMinor != null)
			{
				glowItemMinor.SetUIActive(true);
			}
			UUIItem fxControl = this.FxControl;
			if (fxControl != null)
			{
				fxControl.SetUIActive(false);
			}
			UUIItem fxControlMinor = this.FxControlMinor;
			if (fxControlMinor == null)
			{
				return;
			}
			fxControlMinor.SetUIActive(false);
		}

		// Token: 0x04024683 RID: 149123
		[Nullable(1)]
		private readonly List<UUIItem> TearItemList = new List<UUIItem>();

		// Token: 0x04024684 RID: 149124
		[Nullable(1)]
		private readonly List<UUIItem> TearShadowItemList = new List<UUIItem>();

		// Token: 0x04024685 RID: 149125
		private int CachedSelectedIndex;

		// Token: 0x04024686 RID: 149126
		private bool IsOpened;

		// Token: 0x04024687 RID: 149127
		public Action OpenedCallback;

		// Token: 0x04024688 RID: 149128
		private FLinearColor GlowOffsetVector = new FLinearColor(1f, 5f, 0f, 0f);

		// Token: 0x04024689 RID: 149129
		[Nullable(1)]
		private readonly List<UUIItem> EmojiItemList = new List<UUIItem>();

		// Token: 0x0402468A RID: 149130
		[Nullable(1)]
		private readonly List<LevelSequencePlayer> EmojiSeqPlayerList = new List<LevelSequencePlayer>();

		// Token: 0x0402468B RID: 149131
		private int CachedEmojiIndex = -1;

		// Token: 0x0402468C RID: 149132
		private int CachedTearAudioIndex;

		// Token: 0x0402468D RID: 149133
		private EFxLevel FxLevel;

		// Token: 0x0402468E RID: 149134
		private bool IsDragStarted;

		// Token: 0x0402468F RID: 149135
		private int? LoopAudioHandle;

		// Token: 0x04024690 RID: 149136
		private UUIItem TearRoot;

		// Token: 0x04024691 RID: 149137
		private UUIItem TearShadowRoot;

		// Token: 0x04024692 RID: 149138
		private UUINiagara ShineItem;

		// Token: 0x04024693 RID: 149139
		private UUITexture GlowItem;

		// Token: 0x04024694 RID: 149140
		private UUINiagara BurstItem;

		// Token: 0x04024695 RID: 149141
		private UUINiagara ShineItemMinor;

		// Token: 0x04024696 RID: 149142
		private UUINiagara BurstItemMinor;

		// Token: 0x04024697 RID: 149143
		private UUITexture GlowItemMinor;

		// Token: 0x04024698 RID: 149144
		private UUIItem FxControl;

		// Token: 0x04024699 RID: 149145
		private UUIItem FxControlMinor;

		// Token: 0x0402469A RID: 149146
		private LevelSequencePlayer LevelSequencePlayer;
	}
}
