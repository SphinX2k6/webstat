using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B55 RID: 23381
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreOnlineChallengePlayer : UiPanelBase
	{
		// Token: 0x0603B26E RID: 242286 RVA: 0x00EF787C File Offset: 0x00EF5A7C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B26F RID: 242287 RVA: 0x00EF7928 File Offset: 0x00EF5B28
		protected override UniTask OnBeforeStartAsync()
		{
			RewardExploreOnlineChallengePlayer.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RewardExploreOnlineChallengePlayer.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B270 RID: 242288 RVA: 0x00EF796B File Offset: 0x00EF5B6B
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshOnlineChallengePlayer, new Action(this.OnRefreshOnlineChallengePlayer));
		}

		// Token: 0x0603B271 RID: 242289 RVA: 0x00EF7989 File Offset: 0x00EF5B89
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshOnlineChallengePlayer, new Action(this.OnRefreshOnlineChallengePlayer));
		}

		// Token: 0x0603B272 RID: 242290 RVA: 0x00EF79A8 File Offset: 0x00EF5BA8
		private UniTask InitOnlineChallengePlayerList()
		{
			RewardExploreOnlineChallengePlayer.<InitOnlineChallengePlayerList>d__18 <InitOnlineChallengePlayerList>d__;
			<InitOnlineChallengePlayerList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitOnlineChallengePlayerList>d__.<>4__this = this;
			<InitOnlineChallengePlayerList>d__.<>1__state = -1;
			<InitOnlineChallengePlayerList>d__.<>t__builder.Start<RewardExploreOnlineChallengePlayer.<InitOnlineChallengePlayerList>d__18>(ref <InitOnlineChallengePlayerList>d__);
			return <InitOnlineChallengePlayerList>d__.<>t__builder.Task;
		}

		// Token: 0x0603B273 RID: 242291 RVA: 0x00EF79EB File Offset: 0x00EF5BEB
		public void FullRefresh()
		{
			this.RefreshData();
			this.RefreshView();
		}

		// Token: 0x0603B274 RID: 242292 RVA: 0x00EF79FC File Offset: 0x00EF5BFC
		private UniTask InitView()
		{
			RewardExploreOnlineChallengePlayer.<InitView>d__20 <InitView>d__;
			<InitView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitView>d__.<>4__this = this;
			<InitView>d__.<>1__state = -1;
			<InitView>d__.<>t__builder.Start<RewardExploreOnlineChallengePlayer.<InitView>d__20>(ref <InitView>d__);
			return <InitView>d__.<>t__builder.Task;
		}

		// Token: 0x0603B275 RID: 242293 RVA: 0x00EF7A40 File Offset: 0x00EF5C40
		private void RefreshData()
		{
			List<ScenePlayerData> allScenePlayers = ModelBase<CreatureModel>.Instance.GetAllScenePlayers();
			this.LastPlayerIdList = this.PlayerIdList;
			this.PlayerIdList = Array.Empty<int>();
			foreach (ScenePlayerData scenePlayerData in allScenePlayers)
			{
				EContinuingChallenge? continuingChallengeConfirmState = ModelBase<OnlineModel>.Instance.GetContinuingChallengeConfirmState(scenePlayerData.GetPlayerId());
				EContinuingChallenge econtinuingChallenge = EContinuingChallenge.Accept;
				if (continuingChallengeConfirmState.GetValueOrDefault() == econtinuingChallenge & continuingChallengeConfirmState != null)
				{
					this.PlayerIdList.Append(scenePlayerData.GetPlayerId());
				}
			}
		}

		// Token: 0x0603B276 RID: 242294 RVA: 0x00EF7AE0 File Offset: 0x00EF5CE0
		private void RefreshView()
		{
			if (this.PlayerIdList.Length == 0)
			{
				base.SetUiActive(false);
				return;
			}
			base.SetUiActive(true);
			int[] array = this.playerItemIndicesUsedBySeq[this.PlayerIdList.Length - 1];
			for (int i = 0; i < 3; i++)
			{
				if (i < this.PlayerIdList.Length)
				{
					this.PlayerItems[array[i]].SetUiActive(true);
					this.PlayerItems[array[i]].Refresh(this.PlayerIdList[i]);
				}
				else
				{
					this.PlayerItems[array[i]].SetUiActive(false);
				}
			}
		}

		// Token: 0x0603B277 RID: 242295 RVA: 0x00EF7B68 File Offset: 0x00EF5D68
		private void ProcessSequence()
		{
			if (this.PlayerIdList.Length <= this.LastPlayerIdList.Length)
			{
				return;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName(this.playerItemSeqNames[this.PlayerIdList.Length - 1], false, null, false);
			}
			if (!this.HasTextSeqEverPlayed)
			{
				UUIText text = base.GetText(0);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.PlayLevelSequenceByName("Start_T", false, null, false);
				}
				this.HasTextSeqEverPlayed = true;
			}
		}

		// Token: 0x0603B278 RID: 242296 RVA: 0x00EF7BF8 File Offset: 0x00EF5DF8
		private void OnRefreshOnlineChallengePlayer()
		{
			this.FullRefresh();
		}

		// Token: 0x0603B279 RID: 242297 RVA: 0x00EF7C00 File Offset: 0x00EF5E00
		public RewardExploreOnlineChallengePlayer()
		{
			int[][] array = new int[3][];
			array[0] = new int[]
			{
				0,
				1,
				2
			};
			int num = 1;
			int[] array2 = new int[3];
			array2[0] = 1;
			array2[1] = 2;
			array[num] = array2;
			array[2] = new int[]
			{
				0,
				1,
				2
			};
			this.playerItemIndicesUsedBySeq = array;
			this.playerItemChildTypes = new int[]
			{
				2,
				1,
				3
			};
			this.playerItemSeqNames = new string[]
			{
				"Start01",
				"Start02",
				"Start03"
			};
			this.PlayerItems = Array.Empty<RewardExploreOnlineChallengePlayerItem>();
			this.LastPlayerIdList = Array.Empty<int>();
			this.PlayerIdList = Array.Empty<int>();
			base..ctor();
		}

		// Token: 0x04021585 RID: 136581
		private const int MAX_PLAYER_COUNT = 3;

		// Token: 0x04021586 RID: 136582
		private readonly int[][] playerItemIndicesUsedBySeq;

		// Token: 0x04021587 RID: 136583
		private const string SEQ_NAME_PLAYER_01 = "Start01";

		// Token: 0x04021588 RID: 136584
		private const string SEQ_NAME_PLAYER_02 = "Start02";

		// Token: 0x04021589 RID: 136585
		private const string SEQ_NAME_PLAYER_03 = "Start03";

		// Token: 0x0402158A RID: 136586
		private const string SEQ_NAME_TEX = "Start_T";

		// Token: 0x0402158B RID: 136587
		private readonly int[] playerItemChildTypes;

		// Token: 0x0402158C RID: 136588
		private readonly string[] playerItemSeqNames;

		// Token: 0x0402158D RID: 136589
		private bool HasTextSeqEverPlayed;

		// Token: 0x0402158E RID: 136590
		private RewardExploreOnlineChallengePlayerItem[] PlayerItems;

		// Token: 0x0402158F RID: 136591
		private int[] LastPlayerIdList;

		// Token: 0x04021590 RID: 136592
		private int[] PlayerIdList;

		// Token: 0x04021591 RID: 136593
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200BB57 RID: 47959
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039CFB RID: 236795
			public const int TextTips = 0;

			// Token: 0x04039CFC RID: 236796
			public const int PlayerItemMiddle = 1;

			// Token: 0x04039CFD RID: 236797
			public const int PlayerItemLeft = 2;

			// Token: 0x04039CFE RID: 236798
			public const int PlayerItemRight = 3;
		}
	}
}
