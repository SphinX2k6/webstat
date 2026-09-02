using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FB0 RID: 24496
	[NullableContext(1)]
	[Nullable(0)]
	public class ScorePanel : BattleChildViewPanel
	{
		// Token: 0x0603D8E1 RID: 252129 RVA: 0x00FAD310 File Offset: 0x00FAB510
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D8E2 RID: 252130 RVA: 0x00FAD358 File Offset: 0x00FAB558
		public override UniTask InitializeAsync()
		{
			ScorePanel.<InitializeAsync>d__7 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<ScorePanel.<InitializeAsync>d__7>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D8E3 RID: 252131 RVA: 0x00FAD39B File Offset: 0x00FAB59B
		public override void Reset()
		{
			this.ScoreItemList.Clear();
			this.RogueScoreItem = null;
			this.FarmGoldScoreItem = null;
			base.Reset();
		}

		// Token: 0x0603D8E4 RID: 252132 RVA: 0x00FAD3BC File Offset: 0x00FAB5BC
		protected override void OnBeforeDestroyImplement()
		{
			this.ScoreItemList.Clear();
			this.RogueScoreItem = null;
			this.FarmGoldScoreItem = null;
		}

		// Token: 0x0603D8E5 RID: 252133 RVA: 0x00FAD3D7 File Offset: 0x00FAB5D7
		protected override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.BattleScoreEnableChanged, new Action<int, bool>(this.OnBattleScoreEnableChanged));
		}

		// Token: 0x0603D8E6 RID: 252134 RVA: 0x00FAD3F5 File Offset: 0x00FAB5F5
		protected override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleScoreEnableChanged, new Action<int, bool>(this.OnBattleScoreEnableChanged));
		}

		// Token: 0x0603D8E7 RID: 252135 RVA: 0x00FAD413 File Offset: 0x00FAB613
		private void OnBattleScoreEnableChanged(int scoreId, bool enable)
		{
			if (enable)
			{
				this.TryLoadScoreItem(scoreId);
			}
		}

		// Token: 0x0603D8E8 RID: 252136 RVA: 0x00FAD420 File Offset: 0x00FAB620
		private void TryLoadScoreItem(int scoreId)
		{
			BattleScoreConf? battleScoreConfig = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreConfig(scoreId);
			if (battleScoreConfig == null)
			{
				return;
			}
			EBattleScoreType type = (EBattleScoreType)battleScoreConfig.Value.Type;
			if (type == EBattleScoreType.LevelPlayReport)
			{
				this.LoadRogueScoreItem(false).Forget();
				return;
			}
			if (type != EBattleScoreType.VisionArena)
			{
				return;
			}
			this.LoadVisionArenaScoreItem(scoreId).Forget();
		}

		// Token: 0x0603D8E9 RID: 252137 RVA: 0x00FAD478 File Offset: 0x00FAB678
		private UniTask LoadRogueScoreItem(bool initHide = true)
		{
			ScorePanel.<LoadRogueScoreItem>d__14 <LoadRogueScoreItem>d__;
			<LoadRogueScoreItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadRogueScoreItem>d__.<>4__this = this;
			<LoadRogueScoreItem>d__.initHide = initHide;
			<LoadRogueScoreItem>d__.<>1__state = -1;
			<LoadRogueScoreItem>d__.<>t__builder.Start<ScorePanel.<LoadRogueScoreItem>d__14>(ref <LoadRogueScoreItem>d__);
			return <LoadRogueScoreItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D8EA RID: 252138 RVA: 0x00FAD4C4 File Offset: 0x00FAB6C4
		private UniTask LoadFarmGoldScoreItem()
		{
			ScorePanel.<LoadFarmGoldScoreItem>d__15 <LoadFarmGoldScoreItem>d__;
			<LoadFarmGoldScoreItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadFarmGoldScoreItem>d__.<>4__this = this;
			<LoadFarmGoldScoreItem>d__.<>1__state = -1;
			<LoadFarmGoldScoreItem>d__.<>t__builder.Start<ScorePanel.<LoadFarmGoldScoreItem>d__15>(ref <LoadFarmGoldScoreItem>d__);
			return <LoadFarmGoldScoreItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D8EB RID: 252139 RVA: 0x00FAD508 File Offset: 0x00FAB708
		private UniTask LoadDreamLinkScoreItem()
		{
			ScorePanel.<LoadDreamLinkScoreItem>d__16 <LoadDreamLinkScoreItem>d__;
			<LoadDreamLinkScoreItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadDreamLinkScoreItem>d__.<>4__this = this;
			<LoadDreamLinkScoreItem>d__.<>1__state = -1;
			<LoadDreamLinkScoreItem>d__.<>t__builder.Start<ScorePanel.<LoadDreamLinkScoreItem>d__16>(ref <LoadDreamLinkScoreItem>d__);
			return <LoadDreamLinkScoreItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D8EC RID: 252140 RVA: 0x00FAD54C File Offset: 0x00FAB74C
		private UniTask LoadLinkScoreItem()
		{
			ScorePanel.<LoadLinkScoreItem>d__17 <LoadLinkScoreItem>d__;
			<LoadLinkScoreItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadLinkScoreItem>d__.<>4__this = this;
			<LoadLinkScoreItem>d__.<>1__state = -1;
			<LoadLinkScoreItem>d__.<>t__builder.Start<ScorePanel.<LoadLinkScoreItem>d__17>(ref <LoadLinkScoreItem>d__);
			return <LoadLinkScoreItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D8ED RID: 252141 RVA: 0x00FAD590 File Offset: 0x00FAB790
		private UniTask LoadShipTowerScoreItem()
		{
			ScorePanel.<LoadShipTowerScoreItem>d__18 <LoadShipTowerScoreItem>d__;
			<LoadShipTowerScoreItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadShipTowerScoreItem>d__.<>4__this = this;
			<LoadShipTowerScoreItem>d__.<>1__state = -1;
			<LoadShipTowerScoreItem>d__.<>t__builder.Start<ScorePanel.<LoadShipTowerScoreItem>d__18>(ref <LoadShipTowerScoreItem>d__);
			return <LoadShipTowerScoreItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D8EE RID: 252142 RVA: 0x00FAD5D4 File Offset: 0x00FAB7D4
		private UniTask LoadBossPilingScoreItem()
		{
			ScorePanel.<LoadBossPilingScoreItem>d__19 <LoadBossPilingScoreItem>d__;
			<LoadBossPilingScoreItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadBossPilingScoreItem>d__.<>4__this = this;
			<LoadBossPilingScoreItem>d__.<>1__state = -1;
			<LoadBossPilingScoreItem>d__.<>t__builder.Start<ScorePanel.<LoadBossPilingScoreItem>d__19>(ref <LoadBossPilingScoreItem>d__);
			return <LoadBossPilingScoreItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D8EF RID: 252143 RVA: 0x00FAD618 File Offset: 0x00FAB818
		private UniTask LoadVisionArenaScoreItem(int scoreId)
		{
			ScorePanel.<LoadVisionArenaScoreItem>d__20 <LoadVisionArenaScoreItem>d__;
			<LoadVisionArenaScoreItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadVisionArenaScoreItem>d__.<>4__this = this;
			<LoadVisionArenaScoreItem>d__.scoreId = scoreId;
			<LoadVisionArenaScoreItem>d__.<>1__state = -1;
			<LoadVisionArenaScoreItem>d__.<>t__builder.Start<ScorePanel.<LoadVisionArenaScoreItem>d__20>(ref <LoadVisionArenaScoreItem>d__);
			return <LoadVisionArenaScoreItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603D8F0 RID: 252144 RVA: 0x00FAD664 File Offset: 0x00FAB864
		protected override void OnShowBattleChildViewPanel(bool isFirst)
		{
			if (isFirst)
			{
				foreach (BaseScoreItem baseScoreItem in this.ScoreItemList.Values)
				{
					baseScoreItem.OnShowFirstTime();
				}
			}
		}

		// Token: 0x0603D8F1 RID: 252145 RVA: 0x00FAD6BC File Offset: 0x00FAB8BC
		public override void OnTickBattleChildViewPanel(float delta)
		{
			foreach (BaseScoreItem baseScoreItem in this.ScoreItemList.Values)
			{
				if (baseScoreItem.IsScoreEnable)
				{
					baseScoreItem.OnTick(delta);
				}
			}
		}

		// Token: 0x0603D8F2 RID: 252146 RVA: 0x00FAD71C File Offset: 0x00FAB91C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			BaseScoreItem valueOrDefault = this.ScoreItemList.GetValueOrDefault("ShipTowerScoreItem");
			UUIItem uuiitem = (valueOrDefault != null) ? valueOrDefault.GetGuideUiItem("0") : null;
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

		// Token: 0x0402291E RID: 141598
		[StaticVariableRuleIgnore]
		private static readonly Stat TickStatsObject = Stat.Create("[BattleView]ScorePanelTick", "", "");

		// Token: 0x0402291F RID: 141599
		private readonly Dictionary<string, BaseScoreItem> ScoreItemList = new Dictionary<string, BaseScoreItem>();

		// Token: 0x04022920 RID: 141600
		[Nullable(2)]
		private RogueScoreItem RogueScoreItem;

		// Token: 0x04022921 RID: 141601
		[Nullable(2)]
		private FarmGoldScoreItem FarmGoldScoreItem;

		// Token: 0x0200BFD3 RID: 49107
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403B0BB RID: 241851
			FarmGoldPoint
		}

		// Token: 0x0200BFD4 RID: 49108
		[Nullable(0)]
		private static class EScoreItemType
		{
			// Token: 0x0403B0BC RID: 241852
			public const string RogueScoreItemType = "RogueScoreItem";

			// Token: 0x0403B0BD RID: 241853
			public const string FarmGoldScoreItemType = "FarmGoldScoreItem";

			// Token: 0x0403B0BE RID: 241854
			public const string DreamLinkScoreItemType = "DreamLinkScoreItem";

			// Token: 0x0403B0BF RID: 241855
			public const string LinkScoreItemType = "LinkScoreItem";

			// Token: 0x0403B0C0 RID: 241856
			public const string VisionArenaScoreItemType = "VisionArenaScoreItem";

			// Token: 0x0403B0C1 RID: 241857
			public const string ShipTowerScoreItemType = "ShipTowerScoreItem";

			// Token: 0x0403B0C2 RID: 241858
			public const string BossPilingScoreItem = "BossPilingScoreItem";
		}
	}
}
