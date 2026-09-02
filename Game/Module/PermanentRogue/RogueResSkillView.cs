using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200569A RID: 22170
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueResSkillView : UiViewBase
	{
		// Token: 0x06038743 RID: 231235 RVA: 0x00E4D33B File Offset: 0x00E4B53B
		public RogueResSkillView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038744 RID: 231236 RVA: 0x00E4D368 File Offset: 0x00E4B568
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnBtnSkillOverViewClick)),
				new ValueTuple<int, Delegate>(6, new Action(this.OnBtnMaskClick))
			};
		}

		// Token: 0x06038745 RID: 231237 RVA: 0x00E4D458 File Offset: 0x00E4B658
		protected override UniTask OnBeforeStartAsync()
		{
			RogueResSkillView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueResSkillView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038746 RID: 231238 RVA: 0x00E4D49C File Offset: 0x00E4B69C
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(delegate
			{
				Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
			});
			int num = (int)this.OpenParam;
			RogueResTheme? config = ConfigRogueResThemeById.GetConfig(num, true);
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SetCurrencyItemList(new int[]
				{
					config.Value.SkillItem
				});
			}
			ModelBase<ActivityPermanentRogueModel>.Instance.SetCacheSkillTreeOpen(num);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.PermanentRogueSeasonRedDotUpdate, num);
		}

		// Token: 0x06038747 RID: 231239 RVA: 0x00E4D52C File Offset: 0x00E4B72C
		protected override void OnBeforeShow()
		{
			if (this.SelectColumn > 0 && this.TotalColumn > 0)
			{
				this.ScrollView.BindLateUpdate(delegate(float delta)
				{
					if (this.ExecuteCount == 15)
					{
						base.GetScrollViewWithScrollbar(3).SetScrollProgress(1f - (float)(this.SelectColumn + 1) / (float)(this.TotalColumn + 1));
						this.SelectColumn = -1;
						this.TotalColumn = -1;
						this.ScrollView.UnBindLateUpdate();
					}
					this.ExecuteCount++;
				});
			}
		}

		// Token: 0x06038748 RID: 231240 RVA: 0x00E4D557 File Offset: 0x00E4B757
		protected override void OnBeforeDestroy()
		{
			GenericScrollViewNew<RogueResSkillGridPanel, List<RogueResTalentTree>> scrollView = this.ScrollView;
			if (scrollView == null)
			{
				return;
			}
			scrollView.UnBindLateUpdate();
		}

		// Token: 0x06038749 RID: 231241 RVA: 0x00E4D569 File Offset: 0x00E4B769
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<RogueResSkillNode>(EEventName.RogueResSelectSkill, new Action<RogueResSkillNode>(this.OnSelectSkill));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RogueResTalentLevelUp, new Action<int>(this.OnSkillLevelUp));
		}

		// Token: 0x0603874A RID: 231242 RVA: 0x00E4D5A3 File Offset: 0x00E4B7A3
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResSelectSkill, new Action<RogueResSkillNode>(this.OnSelectSkill));
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResTalentLevelUp, new Action<int>(this.OnSkillLevelUp));
		}

		// Token: 0x0603874B RID: 231243 RVA: 0x00E4D5DD File Offset: 0x00E4B7DD
		protected RogueResSkillGridPanel CreateGridPanel()
		{
			return new RogueResSkillGridPanel();
		}

		// Token: 0x0603874C RID: 231244 RVA: 0x00E4D5E4 File Offset: 0x00E4B7E4
		protected void OnSkillLevelUp(int skillId)
		{
			int p = (int)this.OpenParam;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.PermanentRogueSeasonRedDotUpdate, p);
			GenericScrollViewNew<RogueResSkillGridPanel, List<RogueResTalentTree>> scrollView = this.ScrollView;
			List<RogueResSkillGridPanel> list = (scrollView != null) ? scrollView.GetScrollItemList() : null;
			if (list == null)
			{
				return;
			}
			foreach (RogueResSkillGridPanel rogueResSkillGridPanel in list)
			{
				foreach (RogueResSkillNode rogueResSkillNode in rogueResSkillGridPanel.NodeMap)
				{
					if (rogueResSkillNode != null)
					{
						rogueResSkillNode.Refresh(null);
						RogueResTheme? config = ConfigRogueResThemeById.GetConfig((int)this.OpenParam, true);
						this.CaptionItem.SetCurrencyItemList(new int[]
						{
							config.Value.SkillItem
						});
					}
				}
			}
		}

		// Token: 0x0603874D RID: 231245 RVA: 0x00E4D6EC File Offset: 0x00E4B8EC
		protected void OnBtnMaskClick()
		{
			(base.GetButton(6).GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem).SetUIActive(false);
			this.SkillDetailPanel.SetActive(false);
			this.CurSelectNode.SetToggleState(EToggleState.ETT_UnChecked);
		}

		// Token: 0x0603874E RID: 231246 RVA: 0x00E4D72C File Offset: 0x00E4B92C
		protected void OnBtnSkillOverViewClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueResSkillOverView, this.OpenParam, null);
		}

		// Token: 0x0603874F RID: 231247 RVA: 0x00E4D744 File Offset: 0x00E4B944
		protected void OnSelectSkill(RogueResSkillNode skillNode)
		{
			if (this.CurSelectNode != null)
			{
				this.CurSelectNode.SetToggleState(EToggleState.ETT_UnChecked);
			}
			ModelBase<ActivityPermanentRogueModel>.Instance.SelectSkillId = skillNode.Data.Value.Id;
			this.CurSelectNode = skillNode;
			this.CurSelectNode.SetToggleState(EToggleState.ETT_Checked);
			if (this.SelectColumn == -1)
			{
				GenericScrollViewNew<RogueResSkillGridPanel, List<RogueResTalentTree>> scrollView = this.ScrollView;
				if (scrollView != null)
				{
					scrollView.ScrollTo(skillNode.GridPanelItem, false);
				}
			}
			this.SkillDetailPanel.Refresh(skillNode.Data.Value);
			this.SkillDetailPanel.SetActive(true);
		}

		// Token: 0x06038750 RID: 231248 RVA: 0x00E4D7D8 File Offset: 0x00E4B9D8
		public void BuildSkillTreeConfig()
		{
			int num = (int)this.OpenParam;
			IEnumerable<RogueResTalentTree> configList = ConfigRogueResTalentTreeAll.GetConfigList(true);
			List<RogueResTalentTree> list = new List<RogueResTalentTree>();
			foreach (RogueResTalentTree item in configList)
			{
				if (item.SeasonId == num)
				{
					list.Add(item);
				}
			}
			Dictionary<int, RogueResSort> sortParamMap = new Dictionary<int, RogueResSort>();
			foreach (RogueResTalentTree rogueResTalentTree in list)
			{
				sortParamMap[rogueResTalentTree.Id] = ConfigRogueResSortById.GetConfig(rogueResTalentTree.Id, true).Value;
			}
			list.Sort((RogueResTalentTree a, RogueResTalentTree b) => sortParamMap[a.Id].Column - sortParamMap[b.Id].Column);
			foreach (RogueResTalentTree item2 in list)
			{
				RogueResSort rogueResSort = sortParamMap[item2.Id];
				while (this.SkillTreeConfigList.Count <= rogueResSort.Column)
				{
					this.SkillTreeConfigList.Add(new List<RogueResTalentTree>());
				}
				if (ModelBase<ActivityPermanentRogueModel>.Instance.GetSkillLevelById(item2.Id) == 0 && rogueResSort.Column > this.SelectColumn)
				{
					this.SelectColumn = rogueResSort.Column;
				}
				if (rogueResSort.Column > this.TotalColumn)
				{
					this.TotalColumn = rogueResSort.Column;
				}
				this.SkillTreeConfigList[rogueResSort.Column].Add(item2);
			}
			Comparison<RogueResTalentTree> <>9__1;
			foreach (List<RogueResTalentTree> list2 in this.SkillTreeConfigList)
			{
				if (list2 != null)
				{
					Comparison<RogueResTalentTree> comparison;
					if ((comparison = <>9__1) == null)
					{
						comparison = (<>9__1 = ((RogueResTalentTree a, RogueResTalentTree b) => sortParamMap[a.Id].Row - sortParamMap[b.Id].Row));
					}
					list2.Sort(comparison);
				}
			}
			ModelBase<ActivityPermanentRogueModel>.Instance.SelectSkillId = ModelBase<ActivityPermanentRogueModel>.Instance.GetNextCanUnlockSkillId(num);
		}

		// Token: 0x040203A9 RID: 132009
		private const int ANIM_ENDCOUNT = 15;

		// Token: 0x040203AA RID: 132010
		public List<List<RogueResTalentTree>> SkillTreeConfigList = new List<List<RogueResTalentTree>>();

		// Token: 0x040203AB RID: 132011
		public List<RogueResSkillGridPanel> SkillGridList = new List<RogueResSkillGridPanel>();

		// Token: 0x040203AC RID: 132012
		[Nullable(2)]
		public PopupCaptionItem CaptionItem;

		// Token: 0x040203AD RID: 132013
		[Nullable(2)]
		public RogueResSkillNode CurSelectNode;

		// Token: 0x040203AE RID: 132014
		[Nullable(2)]
		public RogueResSkillDetail SkillDetailPanel;

		// Token: 0x040203AF RID: 132015
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericScrollViewNew<RogueResSkillGridPanel, List<RogueResTalentTree>> ScrollView;

		// Token: 0x040203B0 RID: 132016
		public int SelectColumn;

		// Token: 0x040203B1 RID: 132017
		private int TotalColumn = -1;

		// Token: 0x040203B2 RID: 132018
		public int ExecuteCount = 1;
	}
}
