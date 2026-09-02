using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051DD RID: 20957
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueBattleLinkItem : UiPanelBase
	{
		// Token: 0x06035D4B RID: 220491 RVA: 0x00D8B214 File Offset: 0x00D89414
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnBtnSelf))
			};
		}

		// Token: 0x06035D4C RID: 220492 RVA: 0x00D8B2BD File Offset: 0x00D894BD
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x06035D4D RID: 220493 RVA: 0x00D8B2D0 File Offset: 0x00D894D0
		private void OnBtnSelf()
		{
			Action onClickCallBack = this.OnClickCallBack;
			if (onClickCallBack == null)
			{
				return;
			}
			onClickCallBack();
		}

		// Token: 0x06035D4E RID: 220494 RVA: 0x00D8B2E4 File Offset: 0x00D894E4
		private bool IsAnyBondLinkCanActivate()
		{
			foreach (RoleBondInfo roleBondInfo in ModelBase<RogueBattleModel>.Instance.GetAllOwnedRoleBondData())
			{
				if (ModelBase<RogueBattleModel>.Instance.IsBondLinkCanActivate(roleBondInfo.ConfigId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06035D4F RID: 220495 RVA: 0x00D8B350 File Offset: 0x00D89550
		public void RefreshLinkInfo(int formationIndex)
		{
			RogueResFormation formationDataByIndex = ModelBase<RogueBattleModel>.Instance.GetFormationDataByIndex(formationIndex);
			if (formationDataByIndex == null)
			{
				return;
			}
			int linkId = formationDataByIndex.LinkId;
			if (linkId == 0)
			{
				bool flag = this.IsAnyBondLinkCanActivate();
				string textStringId = flag ? "RogueRes_LinkActHint_Desc" : "RogueBattle_TeamEdit_LinkLock";
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_TeamRoleSkillNone");
				base.SetTextureShowUntilLoaded(resourcePath, base.GetTexture(2), null);
				base.GetItem(3).SetUIActive(flag);
				base.GetItem(4).SetUIActive(flag);
				if (flag)
				{
					if (this.LevelSequencePlayer.GetCurrentSequence() == "Loop")
					{
						this.LevelSequencePlayer.ReplaySequenceByKey("Loop");
					}
					else
					{
						this.LevelSequencePlayer.StopPlayingSequence(false, true);
						this.LevelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
					}
				}
				else
				{
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer != null)
					{
						levelSequencePlayer.StopSequenceByKey("Loop", false, true);
					}
				}
			}
			else
			{
				RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(linkId);
				base.SetTextureShowUntilLoaded(rogueResBond.Value.Icon, base.GetTexture(2), null);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RogueBattle_TeamEdit_LinkUnlock", new <>z__ReadOnlySingleElementList<object>(ConfigBase<TextConfig>.Instance.GetMultiText(rogueResBond.Value.Name, Array.Empty<string>())));
				base.GetItem(3).SetUIActive(true);
				base.GetItem(4).SetUIActive(true);
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.StopSequenceByKey("Loop", false, true);
				}
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.RogueTeamEditViewLinkBtnRefresh, linkId != 0);
		}

		// Token: 0x0401EE42 RID: 126530
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401EE43 RID: 126531
		public Action OnClickCallBack;
	}
}
