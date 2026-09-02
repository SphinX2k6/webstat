using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200513C RID: 20796
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikeBossChallengeBossItem : GridProxyAbstract<RoguelikeBossChallengeBossData>
	{
		// Token: 0x0603588C RID: 219276 RVA: 0x00D705C0 File Offset: 0x00D6E7C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603588D RID: 219277 RVA: 0x00D70755 File Offset: 0x00D6E955
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603588E RID: 219278 RVA: 0x00D70768 File Offset: 0x00D6E968
		[NullableContext(1)]
		public override void Refresh(RoguelikeBossChallengeBossData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			this.RefreshSpecialState(data.IsSpecial);
			this.RefreshState(data.State, data.IsSpecial);
			this.RefreshBossAvatar(data.Id, gridIndex);
			this.RefreshCurrentArrow(data.State, data.IsSpecial);
			this.RefreshSerialNum(gridIndex);
		}

		// Token: 0x0603588F RID: 219279 RVA: 0x00D707C0 File Offset: 0x00D6E9C0
		public void SetArrowVisible(bool visible)
		{
			base.GetSprite(6).SetUIActive(visible);
		}

		// Token: 0x06035890 RID: 219280 RVA: 0x00D707CF File Offset: 0x00D6E9CF
		public bool IsCurrentBoss(int bossId)
		{
			RoguelikeBossChallengeBossData currentData = this.CurrentData;
			return currentData != null && currentData.Id == bossId;
		}

		// Token: 0x06035891 RID: 219281 RVA: 0x00D707E8 File Offset: 0x00D6E9E8
		public void PlaySwitchSequence()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x06035892 RID: 219282 RVA: 0x00D70814 File Offset: 0x00D6EA14
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

		// Token: 0x06035893 RID: 219283 RVA: 0x00D70835 File Offset: 0x00D6EA35
		private void RefreshSpecialState(bool isSpecial)
		{
			base.GetItem(7).SetUIActive(!isSpecial);
			base.GetItem(8).SetUIActive(isSpecial);
		}

		// Token: 0x06035894 RID: 219284 RVA: 0x00D70854 File Offset: 0x00D6EA54
		private void RefreshState(ERoguelikeBossChallengeBossState state, bool isSpecial)
		{
			BossChallengeStateVisibility stateVisibility = this.GetStateVisibility(state);
			if (stateVisibility == null)
			{
				return;
			}
			base.GetItem(0).SetUIActive(stateVisibility.ShowUnlock);
			base.GetItem(2).SetUIActive(stateVisibility.ShowFinished);
			if (isSpecial)
			{
				base.GetTexture(9).SetUIActive(stateVisibility.ShowEmptyIcon);
				return;
			}
			base.GetTexture(1).SetUIActive(stateVisibility.ShowEmptyIcon);
		}

		// Token: 0x06035895 RID: 219285 RVA: 0x00D708BC File Offset: 0x00D6EABC
		private void RefreshBossAvatar(int bossId, int gridIndex)
		{
			if (bossId == 0)
			{
				base.GetTexture(3).SetUIActive(false);
				return;
			}
			RogueTower? rogueTowerConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueTowerConfig(bossId);
			if (rogueTowerConfig == null || string.IsNullOrEmpty(rogueTowerConfig.Value.PreviewIcon))
			{
				return;
			}
			base.SetTextureShowUntilLoaded(rogueTowerConfig.Value.PreviewIcon, base.GetTexture(3), null);
		}

		// Token: 0x06035896 RID: 219286 RVA: 0x00D70924 File Offset: 0x00D6EB24
		private void RefreshCurrentArrow(ERoguelikeBossChallengeBossState state, bool isSpecial)
		{
			bool flag = state == ERoguelikeBossChallengeBossState.Processing;
			base.GetTexture(4).SetUIActive(this.ShowCurrentArrow && !isSpecial && flag);
			base.GetTexture(10).SetUIActive(this.ShowCurrentArrow && isSpecial && flag);
		}

		// Token: 0x06035897 RID: 219287 RVA: 0x00D7096C File Offset: 0x00D6EB6C
		private void RefreshSerialNum(int gridIndex)
		{
			if (gridIndex < 0)
			{
				return;
			}
			string bossChallengeIndexResourceId = this.GetBossChallengeIndexResourceId(gridIndex);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(bossChallengeIndexResourceId);
			if (string.IsNullOrEmpty(resourcePath))
			{
				return;
			}
			this.SetSpriteByPath(resourcePath, base.GetSprite(5), false, null, null);
		}

		// Token: 0x06035898 RID: 219288 RVA: 0x00D709B4 File Offset: 0x00D6EBB4
		private BossChallengeStateVisibility GetStateVisibility(ERoguelikeBossChallengeBossState state)
		{
			switch (state)
			{
			case ERoguelikeBossChallengeBossState.Finished:
				return new BossChallengeStateVisibility
				{
					ShowUnlock = true,
					ShowEmptyIcon = false,
					ShowFinished = true
				};
			case ERoguelikeBossChallengeBossState.Processing:
				return new BossChallengeStateVisibility
				{
					ShowUnlock = true,
					ShowEmptyIcon = false,
					ShowFinished = false
				};
			case ERoguelikeBossChallengeBossState.Locked:
				return new BossChallengeStateVisibility
				{
					ShowUnlock = false,
					ShowEmptyIcon = true,
					ShowFinished = false
				};
			default:
				return null;
			}
		}

		// Token: 0x06035899 RID: 219289 RVA: 0x00D70A28 File Offset: 0x00D6EC28
		[NullableContext(1)]
		private string GetBossChallengeIndexResourceId(int gridIndex)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
			defaultInterpolatedStringHandler.AppendLiteral("SP_RoguelikeBossChallengeIndex");
			defaultInterpolatedStringHandler.AppendFormatted<int>(gridIndex);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0401EC2C RID: 125996
		public bool ShowCurrentArrow;

		// Token: 0x0401EC2D RID: 125997
		protected RoguelikeBossChallengeBossData CurrentData;

		// Token: 0x0401EC2E RID: 125998
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0200B0DA RID: 45274
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036DC7 RID: 224711
			public const int PnlUnlock = 0;

			// Token: 0x04036DC8 RID: 224712
			public const int TexIcon = 1;

			// Token: 0x04036DC9 RID: 224713
			public const int PnlFinished = 2;

			// Token: 0x04036DCA RID: 224714
			public const int TexBossAvatar = 3;

			// Token: 0x04036DCB RID: 224715
			public const int TexCurrArrow = 4;

			// Token: 0x04036DCC RID: 224716
			public const int SprSerialNum = 5;

			// Token: 0x04036DCD RID: 224717
			public const int SprArrow = 6;

			// Token: 0x04036DCE RID: 224718
			public const int PnlNorState = 7;

			// Token: 0x04036DCF RID: 224719
			public const int PnlRedState = 8;

			// Token: 0x04036DD0 RID: 224720
			public const int TexEmptyIconRed = 9;

			// Token: 0x04036DD1 RID: 224721
			public const int TexCurrArrowRed = 10;
		}
	}
}
