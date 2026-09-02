using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BAB RID: 27563
	public class LevelEventHighlightExploreUi : LevelEventBase
	{
		// Token: 0x06043FDE RID: 278494 RVA: 0x0119E3D8 File Offset: 0x0119C5D8
		public LevelEventHighlightExploreUi(int id) : base(id)
		{
		}

		// Token: 0x06043FDF RID: 278495 RVA: 0x0119E3E4 File Offset: 0x0119C5E4
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				base.FinishExecute(false, false, true);
			}
			BaseExploreComponent activeExploreComponent = ModelBase<CharacterExploreModel>.Instance.GetActiveExploreComponent();
			if (activeExploreComponent == null)
			{
				return;
			}
			ToggleHighlightExploreUi toggleHighlightExploreUi = inParams as ToggleHighlightExploreUi;
			switch (toggleHighlightExploreUi.Type)
			{
			case EHighlightExploreSkillIconType.Show:
			{
				IShowHighlightExploreSkillIcon showHighlightExploreSkillIcon = toggleHighlightExploreUi as IShowHighlightExploreSkillIcon;
				BaseExploreComponent baseExploreComponent = activeExploreComponent;
				int skillType = showHighlightExploreSkillIcon.SkillType;
				float duration = showHighlightExploreSkillIcon.Duration;
				bool? isSwitchBack = showHighlightExploreSkillIcon.IsSwitchBack;
				EHighlightType? highlightType = showHighlightExploreSkillIcon.HighlightType;
				baseExploreComponent.ShowHighlightExploreSkill(skillType, duration, isSwitchBack, (highlightType != null) ? highlightType.GetValueOrDefault().ToEnumString() : null, null, null, null);
				return;
			}
			case EHighlightExploreSkillIconType.Hide:
				activeExploreComponent.HideHighlightExploreSkill();
				break;
			case EHighlightExploreSkillIconType.ToggleAndHighlightItem:
			{
				IToggleAndHighlightItem toggleAndHighlightItem = toggleHighlightExploreUi as IToggleAndHighlightItem;
				BaseExploreComponent baseExploreComponent2 = activeExploreComponent;
				int skillType2 = toggleAndHighlightItem.SkillType;
				float duration2 = -1f;
				bool? needRevertSkill = new bool?(toggleAndHighlightItem.IsSwitchBack.GetValueOrDefault());
				EHighlightType? highlightType = toggleAndHighlightItem.HighlightType;
				baseExploreComponent2.ShowHighlightExploreSkill(skillType2, duration2, needRevertSkill, (highlightType != null) ? highlightType.GetValueOrDefault().ToEnumString() : null, new int?(toggleAndHighlightItem.ItemId), toggleAndHighlightItem.IsShowTips, null);
				ILeaveAreaItem leaveAreaItem = LeaveAreaItemInfoIds.Get(toggleAndHighlightItem.ItemId);
				if (leaveAreaItem != null)
				{
					LeaveAreaItemInfo.TryLeave(leaveAreaItem);
					return;
				}
				break;
			}
			default:
				return;
			}
		}
	}
}
