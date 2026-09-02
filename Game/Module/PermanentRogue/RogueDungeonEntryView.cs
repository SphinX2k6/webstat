using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005671 RID: 22129
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueDungeonEntryView : UiViewBase
	{
		// Token: 0x06038640 RID: 230976 RVA: 0x00E47273 File Offset: 0x00E45473
		[NullableContext(1)]
		public RogueDungeonEntryView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038641 RID: 230977 RVA: 0x00E47284 File Offset: 0x00E45484
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem))
			};
		}

		// Token: 0x06038642 RID: 230978 RVA: 0x00E47364 File Offset: 0x00E45564
		protected override UniTask OnBeforeStartAsync()
		{
			RogueDungeonEntryView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueDungeonEntryView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038643 RID: 230979 RVA: 0x00E473A8 File Offset: 0x00E455A8
		protected override void OnStart()
		{
			this.DungeonConfig = (RogueDungeonParam)this.OpenParam;
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			UUIItem item = base.GetItem(3);
			UUIItem item2 = base.GetItem(8);
			this.NoCircleAttachViewInstance = new NoCircleAttachView<int, RogueDungeonDataItem>(item.GetOwner() as AUIBaseActor, false);
			NoCircleAttachView<int, RogueDungeonDataItem> noCircleAttachViewInstance = this.NoCircleAttachViewInstance;
			if (noCircleAttachViewInstance != null)
			{
				noCircleAttachViewInstance.SetIfNeedFakeItem(true);
			}
			this.NoCircleAttachViewInstance.CreateItems(base.GetItem(4).GetOwner(), 0f, new Func<AActor, int, int, RogueDungeonDataItem>(this.CreateNoCircleAttachItem), EAttachDirection.Vertical);
			NoCircleAttachView<int, RogueDungeonDataItem> noCircleAttachViewInstance2 = this.NoCircleAttachViewInstance;
			if (noCircleAttachViewInstance2 != null)
			{
				noCircleAttachViewInstance2.SetControllerItem(item2);
			}
			base.GetItem(4).SetUIActive(false);
			int currentSelectedInst = ModelBase<ActivityPermanentRogueModel>.Instance.GetCurrentSelectedInst(this.DungeonConfig.SeasonId);
			int attachTo = this.DungeonConfig.DungeonList.Contains(currentSelectedInst) ? this.DungeonConfig.DungeonList.IndexOf(currentSelectedInst) : 0;
			int[] dungeonList = this.DungeonConfig.DungeonList;
			this.NoCircleAttachViewInstance.ReloadView(dungeonList.Length, dungeonList, attachTo);
		}

		// Token: 0x06038644 RID: 230980 RVA: 0x00E474B5 File Offset: 0x00E456B5
		protected override void OnBeforeShow()
		{
			this.RefreshSkillConfig();
			this.BindRedDot();
		}

		// Token: 0x06038645 RID: 230981 RVA: 0x00E474C3 File Offset: 0x00E456C3
		protected override void OnBeforeHide()
		{
			this.UnbindRedDot();
		}

		// Token: 0x06038646 RID: 230982 RVA: 0x00E474CB File Offset: 0x00E456CB
		protected override void OnBeforeDestroy()
		{
			this.CaptionItem = null;
			this.DungeonConfig = null;
			this.NoCircleAttachViewInstance = null;
			this.InfoComponent = null;
			this.SequencePlayer = null;
		}

		// Token: 0x06038647 RID: 230983 RVA: 0x00E474F0 File Offset: 0x00E456F0
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RogueResTalentLevelUp, new Action<int>(this.OnSkillUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.RogueResEnterInstClicked, new Action(this.OnClickedEnter));
		}

		// Token: 0x06038648 RID: 230984 RVA: 0x00E4752A File Offset: 0x00E4572A
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RogueResTalentLevelUp, new Action<int>(this.OnSkillUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResEnterInstClicked, new Action(this.OnClickedEnter));
		}

		// Token: 0x06038649 RID: 230985 RVA: 0x00E47564 File Offset: 0x00E45764
		private void OnClickBack()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603864A RID: 230986 RVA: 0x00E47570 File Offset: 0x00E45770
		[NullableContext(1)]
		private void OnItemClick(RogueDungeonDataItem item)
		{
			if (this.NoCircleAttachViewInstance.IsVelocityMoveState())
			{
				return;
			}
			if (item.GetData() == null)
			{
				return;
			}
			this.NoCircleAttachViewInstance.AttachToIndex(item.GetCurrentShowItemIndex(), false);
			if (!ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(item.GetData().Value))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RogueRes_DungeonLock", Array.Empty<object>());
			}
		}

		// Token: 0x0603864B RID: 230987 RVA: 0x00E475DC File Offset: 0x00E457DC
		private void OnSkillTreeClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueResSkillView, this.DungeonConfig.SeasonId, null);
		}

		// Token: 0x0603864C RID: 230988 RVA: 0x00E475FE File Offset: 0x00E457FE
		private void OnSkillUpdate(int skillId)
		{
			this.RefreshSkillConfig();
		}

		// Token: 0x0603864D RID: 230989 RVA: 0x00E47608 File Offset: 0x00E45808
		private void OnClickedEnter()
		{
			foreach (RogueDungeonDataItem rogueDungeonDataItem in this.NoCircleAttachViewInstance.GetItems())
			{
				rogueDungeonDataItem.UnSelectWhenEnter();
			}
		}

		// Token: 0x0603864E RID: 230990 RVA: 0x00E47660 File Offset: 0x00E45860
		[NullableContext(1)]
		private RogueDungeonDataItem CreateNoCircleAttachItem(AActor actor, int index, int showNum)
		{
			RogueDungeonDataItem rogueDungeonDataItem = new RogueDungeonDataItem(actor);
			rogueDungeonDataItem.CreateByActorAsync(actor, null, false);
			rogueDungeonDataItem.OnToggleClick = new Action<RogueDungeonDataItem>(this.OnItemClick);
			rogueDungeonDataItem.OnSelectCall = new Action<int>(this.OnDungeonSelectedRefresh);
			rogueDungeonDataItem.CheckToggleCanClick = new Func<int, bool>(this.CheckToggleCanClick);
			return rogueDungeonDataItem;
		}

		// Token: 0x0603864F RID: 230991 RVA: 0x00E476B3 File Offset: 0x00E458B3
		private bool CheckToggleCanClick(int id)
		{
			return !this.NoCircleAttachViewInstance.MovingState() && id != this.SelectedId;
		}

		// Token: 0x06038650 RID: 230992 RVA: 0x00E476D0 File Offset: 0x00E458D0
		private void BindRedDot()
		{
			RogueButtonItemA btnSkillItem = this.BtnSkillItem;
			if (btnSkillItem == null)
			{
				return;
			}
			btnSkillItem.BindRedDot(ERedDotName.RogueResSkillTree, new int?(this.DungeonConfig.SeasonId));
		}

		// Token: 0x06038651 RID: 230993 RVA: 0x00E476F7 File Offset: 0x00E458F7
		private void UnbindRedDot()
		{
			RogueButtonItemA btnSkillItem = this.BtnSkillItem;
			if (btnSkillItem == null)
			{
				return;
			}
			btnSkillItem.UnBindRedDot();
		}

		// Token: 0x06038652 RID: 230994 RVA: 0x00E4770C File Offset: 0x00E4590C
		private void RefreshSkillConfig()
		{
			int skillTreeLevel = ModelBase<ActivityPermanentRogueModel>.Instance.GetSkillTreeLevel(this.DungeonConfig.SeasonId);
			RogueButtonItemA btnSkillItem = this.BtnSkillItem;
			if (btnSkillItem == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Lv.");
			defaultInterpolatedStringHandler.AppendFormatted<int>(skillTreeLevel);
			btnSkillItem.SetNum(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06038653 RID: 230995 RVA: 0x00E47764 File Offset: 0x00E45964
		private void OnDungeonSelectedRefresh(int id)
		{
			this.InfoComponent.RefreshDungeonConfig(id);
			RogueResDungeonConfig? config = ConfigRogueResDungeonConfigById.GetConfig(id, true);
			if (config == null)
			{
				return;
			}
			this.SelectedId = id;
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (((sequencePlayer != null) ? sequencePlayer.GetCurrentSequence() : null) == "Switch")
			{
				LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
				if (sequencePlayer2 != null)
				{
					sequencePlayer2.ReplaySequenceByKey("Switch");
				}
			}
			else
			{
				LevelSequencePlayer sequencePlayer3 = this.SequencePlayer;
				if (((sequencePlayer3 != null) ? sequencePlayer3.GetCurrentSequence() : null) == null)
				{
					LevelSequencePlayer sequencePlayer4 = this.SequencePlayer;
					if (sequencePlayer4 != null)
					{
						sequencePlayer4.PlayLevelSequenceByName("Switch", false, null, false);
					}
				}
			}
			string path = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? config.Value.CoverF : config.Value.CoverM;
			base.SetTextureByPath(path, base.GetTexture(2), null, null);
			bool flag = ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(id);
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(!flag);
		}

		// Token: 0x06038654 RID: 230996 RVA: 0x00E4786C File Offset: 0x00E45A6C
		[NullableContext(1)]
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
			NoCircleAttachView<int, RogueDungeonDataItem> noCircleAttachViewInstance = this.NoCircleAttachViewInstance;
			UUIItem uuiitem;
			if (noCircleAttachViewInstance == null)
			{
				uuiitem = null;
			}
			else
			{
				RogueDungeonDataItem itemByShowIndex = noCircleAttachViewInstance.GetItemByShowIndex(0);
				uuiitem = ((itemByShowIndex != null) ? itemByShowIndex.GetRootItem() : null);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}

		// Token: 0x040202AC RID: 131756
		private RogueDungeonParam DungeonConfig;

		// Token: 0x040202AD RID: 131757
		private PopupCaptionItem CaptionItem;

		// Token: 0x040202AE RID: 131758
		private RogueDungeonInfoItem InfoComponent;

		// Token: 0x040202AF RID: 131759
		private RogueButtonItemA BtnSkillItem;

		// Token: 0x040202B0 RID: 131760
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private NoCircleAttachView<int, RogueDungeonDataItem> NoCircleAttachViewInstance;

		// Token: 0x040202B1 RID: 131761
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x040202B2 RID: 131762
		private int SelectedId = -1;
	}
}
