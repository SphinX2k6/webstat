using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005140 RID: 20800
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikeBossChallengeDebuffItem : GridProxyAbstract<RoguelikeBossChallengeBuffData>
	{
		// Token: 0x060358AE RID: 219310 RVA: 0x00D70E7C File Offset: 0x00D6F07C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnBtnDetailClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060358AF RID: 219311 RVA: 0x00D70FC7 File Offset: 0x00D6F1C7
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x060358B0 RID: 219312 RVA: 0x00D70FDC File Offset: 0x00D6F1DC
		[NullableContext(1)]
		public override void Refresh(RoguelikeBossChallengeBuffData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
			RogueTowerBuff? rogueTowerBuff = (instance != null) ? instance.GetRogueTowerBuffConfig(data.Id) : null;
			if (rogueTowerBuff == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), rogueTowerBuff.Value.Name, Array.Empty<object>());
			this.RefreshDesc(rogueTowerBuff.Value);
			base.SetTextureByPath(rogueTowerBuff.Value.Icon, base.GetTexture(1), null, null);
			base.GetItem(4).SetUIActive(data.IsNew);
			base.GetItem(6).SetUIActive(data.IsActive);
		}

		// Token: 0x060358B1 RID: 219313 RVA: 0x00D71096 File Offset: 0x00D6F296
		public void SetNewTipsVisible(bool visible)
		{
			base.GetItem(4).SetUIActive(visible);
		}

		// Token: 0x060358B2 RID: 219314 RVA: 0x00D710A5 File Offset: 0x00D6F2A5
		public bool IsCurrentBossBuff(int bossId)
		{
			RoguelikeBossChallengeBuffData currentData = this.CurrentData;
			return currentData != null && currentData.BossId == bossId;
		}

		// Token: 0x060358B3 RID: 219315 RVA: 0x00D710BC File Offset: 0x00D6F2BC
		public void PlayStartSequence()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
		}

		// Token: 0x060358B4 RID: 219316 RVA: 0x00D710E8 File Offset: 0x00D6F2E8
		public UUIButtonComponent GetDetailBtn()
		{
			return base.GetButton(5);
		}

		// Token: 0x060358B5 RID: 219317 RVA: 0x00D710F1 File Offset: 0x00D6F2F1
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			this.CurrentData = null;
		}

		// Token: 0x060358B6 RID: 219318 RVA: 0x00D71114 File Offset: 0x00D6F314
		private void RefreshDesc(RogueTowerBuff cfg)
		{
			RoguelikeBossChallengeBuffData currentData = this.CurrentData;
			EDescModel edescModel = (currentData != null) ? currentData.DescMode : EDescModel.DETAIL;
			string textStringId = (edescModel == EDescModel.SIMPLE) ? cfg.BriefDesc : cfg.Describe;
			string[] args = (edescModel == EDescModel.SIMPLE) ? cfg.BriefDescParam() : cfg.DescParam();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textStringId, args);
		}

		// Token: 0x060358B7 RID: 219319 RVA: 0x00D7116D File Offset: 0x00D6F36D
		private void OnBtnDetailClick()
		{
			if (this.CurrentData == null)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeBossChallengeBuffDetailView, new int[]
			{
				this.CurrentData.BossId,
				this.CurrentData.Id
			}, null);
		}

		// Token: 0x0401EC34 RID: 126004
		protected RoguelikeBossChallengeBuffData CurrentData;

		// Token: 0x0401EC35 RID: 126005
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0200B0DF RID: 45279
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036DE0 RID: 224736
			public const int SprBuffIcon = 0;

			// Token: 0x04036DE1 RID: 224737
			public const int TexBuffIcon = 1;

			// Token: 0x04036DE2 RID: 224738
			public const int TxtBuffName = 2;

			// Token: 0x04036DE3 RID: 224739
			public const int TxtDesc = 3;

			// Token: 0x04036DE4 RID: 224740
			public const int PnlNewTips = 4;

			// Token: 0x04036DE5 RID: 224741
			public const int BtnDetail = 5;

			// Token: 0x04036DE6 RID: 224742
			public const int ItemActive = 6;
		}
	}
}
