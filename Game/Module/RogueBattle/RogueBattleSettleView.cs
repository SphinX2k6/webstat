using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.PermanentRogue;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200527B RID: 21115
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueBattleSettleView : UiViewBase
	{
		// Token: 0x06036029 RID: 221225 RVA: 0x00D97AC1 File Offset: 0x00D95CC1
		[NullableContext(1)]
		public RogueBattleSettleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603602A RID: 221226 RVA: 0x00D97ACC File Offset: 0x00D95CCC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUISprite))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnLeft)),
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnRight)),
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickBtnMask)),
				new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtnMask))
			};
		}

		// Token: 0x0603602B RID: 221227 RVA: 0x00D97C88 File Offset: 0x00D95E88
		private void OnClickBtnLeft()
		{
			this.PageIndex--;
			this.RefreshPanel();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("SwitchL", false, null, false);
		}

		// Token: 0x0603602C RID: 221228 RVA: 0x00D97CCC File Offset: 0x00D95ECC
		private void OnClickBtnRight()
		{
			this.PageIndex++;
			this.RefreshPanel();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("SwitchR", false, null, false);
		}

		// Token: 0x0603602D RID: 221229 RVA: 0x00D97D10 File Offset: 0x00D95F10
		private void OnClickBtnMask()
		{
			if (this.PageIndex == 0)
			{
				this.OnClickBtnRight();
				return;
			}
			if (ControllerBase<MapRogueController>.Instance.CheckInMapRogueInstance())
			{
				int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
				ControllerBase<ActivityPermanentRogueController>.Instance.SetReturnToWorld(instanceId);
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x0603602E RID: 221230 RVA: 0x00D97D68 File Offset: 0x00D95F68
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleSettleView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleSettleView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603602F RID: 221231 RVA: 0x00D97DAC File Offset: 0x00D95FAC
		protected void RefreshDetail()
		{
			InstResultView instResultView = (InstResultView)this.OpenParam;
			if (instResultView == null)
			{
				return;
			}
			int teamLevel = instResultView.TeamLevel;
			int count = instResultView.Roles.Count;
			int num = 0;
			using (IEnumerator<RoleBondInfo> enumerator = instResultView.RoleBondInfos.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Level != 0)
					{
						num++;
					}
				}
			}
			string textStringId = instResultView.IsSucc ? "RogueRes_Settle_Title_Success" : "RogueRes_Settle_Title_Fail";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textStringId, Array.Empty<object>());
			int num2 = 0;
			foreach (RogueResGainData rogueResGainData in instResultView.Roles)
			{
				num2 += rogueResGainData.RogueResRole.Level;
			}
			base.GetText(8).SetText(teamLevel.ToString(), true);
			base.GetText(9).SetText(count.ToString(), true);
			base.GetText(10).SetText(num2.ToString(), true);
			base.GetText(11).SetText(num.ToString(), true);
			base.GetItem(12).SetUIActive(instResultView.IsNewRecord);
			RogueResGridExplore? exploreByInstId = ConfigBase<MapRogueConfig>.Instance.GetExploreByInstId(instResultView.InstId);
			if (exploreByInstId != null)
			{
				int value = 0;
				foreach (DicIntInt dicIntInt in exploreByInstId.Value.RankMapIter())
				{
					int key = dicIntInt.Key;
					int value2 = dicIntInt.Value;
					if (instResultView.Score < value2)
					{
						value = key - 1;
						break;
					}
					value = key;
				}
				switch (value)
				{
				case 1:
					Singleton<AudioSystem>.Instance.SetState("ui_rogue_settle", "settle_c", true);
					break;
				case 2:
					Singleton<AudioSystem>.Instance.SetState("ui_rogue_settle", "settle_b", true);
					break;
				case 3:
					Singleton<AudioSystem>.Instance.SetState("ui_rogue_settle", "settle_a", true);
					break;
				case 4:
					Singleton<AudioSystem>.Instance.SetState("ui_rogue_settle", "settle_s", true);
					break;
				}
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_fx_spl_rogue_accounts");
				UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
				defaultInterpolatedStringHandler.AppendLiteral("RogueRes_Settle_Rank_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				string resourcePath = instance.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
				base.TrySetSpriteByPath(resourcePath, base.GetSprite(13), false, null, null);
			}
		}

		// Token: 0x06036030 RID: 221232 RVA: 0x00D98070 File Offset: 0x00D96270
		protected void RefreshPanel()
		{
			RogueBattleSettleChallengeInfoPanel challengeInfoPanelComponent = this.ChallengeInfoPanelComponent;
			if (challengeInfoPanelComponent != null)
			{
				challengeInfoPanelComponent.GetRootItem().SetUIActive(this.PageIndex == 0);
			}
			RogueBattleSettleDataInfoPanel dataInfoPanelComponent = this.DataInfoPanelComponent;
			if (dataInfoPanelComponent != null)
			{
				dataInfoPanelComponent.GetRootItem().SetUIActive(this.PageIndex == 1);
			}
			base.GetButton(0).RootUIComp.Get().SetUIActive(this.PageIndex > 0);
			base.GetButton(1).RootUIComp.Get().SetUIActive(this.PageIndex < 1);
		}

		// Token: 0x0401F0A6 RID: 127142
		protected RogueBattleSettleChallengeInfoPanel ChallengeInfoPanelComponent;

		// Token: 0x0401F0A7 RID: 127143
		protected RogueBattleSettleDataInfoPanel DataInfoPanelComponent;

		// Token: 0x0401F0A8 RID: 127144
		protected int PageIndex;

		// Token: 0x0401F0A9 RID: 127145
		protected LevelSequencePlayer LevelSequencePlayer;
	}
}
