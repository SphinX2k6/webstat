using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.GreatSword
{
	// Token: 0x02004BB4 RID: 19380
	[NullableContext(1)]
	[Nullable(0)]
	public class GreatSwordMarkPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x06032996 RID: 207254 RVA: 0x00CAC5AA File Offset: 0x00CAA7AA
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x06032997 RID: 207255 RVA: 0x00CAC5B1 File Offset: 0x00CAA7B1
		protected override void OnStart()
		{
			this.TargetListPanel = new GreatSwordMarkTargetListPanel();
			this.TargetListPanel.Initialize(base.GetVerticalLayout(16));
			base.OnStart();
		}

		// Token: 0x06032998 RID: 207256 RVA: 0x00CAC5D8 File Offset: 0x00CAA7D8
		protected override UniTask OnBeforeShowWorldMapSecondaryUiAsync(params object[] param)
		{
			GreatSwordMarkPanel.<OnBeforeShowWorldMapSecondaryUiAsync>d__5 <OnBeforeShowWorldMapSecondaryUiAsync>d__;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>4__this = this;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.param = param;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>1__state = -1;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>t__builder.Start<GreatSwordMarkPanel.<OnBeforeShowWorldMapSecondaryUiAsync>d__5>(ref <OnBeforeShowWorldMapSecondaryUiAsync>d__);
			return <OnBeforeShowWorldMapSecondaryUiAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032999 RID: 207257 RVA: 0x00CAC624 File Offset: 0x00CAA824
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(7);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIVerticalLayout verticalLayout2 = base.GetVerticalLayout(5);
			if (verticalLayout2 != null)
			{
				verticalLayout2.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(32);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext == null)
			{
				return;
			}
			layoutContext.SetConfirmBtnActive(true);
		}

		// Token: 0x0603299A RID: 207258 RVA: 0x00CAC6B0 File Offset: 0x00CAA8B0
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0 && param[0] is GreatSwordChallengeMarkItem)
			{
				GreatSwordChallengeMarkItem selectedMarkItem = this.SelectedMarkItem;
				int num = (selectedMarkItem != null) ? selectedMarkItem.MarkConfigId : 0;
				MapMark? config = ConfigMapMarkByMarkId.GetConfig(num, true);
				if (config == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Map;
					ELogAuthor author = ELogAuthor.LYX;
					string message = "缺少标记配置";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", num);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonEnableClickByTeleportState(this.LayoutContext);
				WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
				WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
				WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), config.Value.MarkDesc, Array.Empty<object>());
				base.UpdateMultiMap();
				base.UpdateTopRightIconActive();
				base.UpdateHidePlayMapTipPanel();
				UUIVerticalLayout verticalLayout = base.GetVerticalLayout(16);
				if (verticalLayout != null)
				{
					verticalLayout.RootUIComp.Get().SetUIActive(true);
				}
				this.RefreshLayout();
			}
		}

		// Token: 0x0603299B RID: 207259 RVA: 0x00CAC7AD File Offset: 0x00CAA9AD
		protected override void OnConfirmBtnClick(int index)
		{
			this.HandleTeleport();
		}

		// Token: 0x0603299C RID: 207260 RVA: 0x00CAC7B8 File Offset: 0x00CAA9B8
		private void RefreshLayout()
		{
			ITrialChallenge challenge = ModelBase<GreatSwordChallengeModel>.Instance.GetChallenge();
			if (challenge == null)
			{
				return;
			}
			for (int i = 0; i < challenge.SubChallenges.Count; i++)
			{
				ITrialSubChallenge trialSubChallenge = challenge.SubChallenges[i];
				GreatSwordMarkTargetListPanel targetListPanel = this.TargetListPanel;
				GreatSwordMarkTargetListItemPanel greatSwordMarkTargetListItemPanel;
				if (targetListPanel == null)
				{
					greatSwordMarkTargetListItemPanel = null;
				}
				else
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Target_");
					defaultInterpolatedStringHandler.AppendFormatted<int>(i);
					greatSwordMarkTargetListItemPanel = targetListPanel.AddItemByKey(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				GreatSwordMarkTargetListItemPanel greatSwordMarkTargetListItemPanel2 = greatSwordMarkTargetListItemPanel;
				if (greatSwordMarkTargetListItemPanel2 != null)
				{
					greatSwordMarkTargetListItemPanel2.SetDescTxt(trialSubChallenge.Config.MapGoalText);
					greatSwordMarkTargetListItemPanel2.SetState(trialSubChallenge.Completed);
				}
			}
		}

		// Token: 0x0603299D RID: 207261 RVA: 0x00CAC852 File Offset: 0x00CAAA52
		protected override void OnBeforeDestroy()
		{
			GreatSwordMarkTargetListPanel targetListPanel = this.TargetListPanel;
			if (targetListPanel != null)
			{
				targetListPanel.Clear();
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x0401D7D9 RID: 120793
		[Nullable(2)]
		private GreatSwordChallengeMarkItem SelectedMarkItem;

		// Token: 0x0401D7DA RID: 120794
		[Nullable(2)]
		private GreatSwordMarkTargetListPanel TargetListPanel;

		// Token: 0x0200AC98 RID: 44184
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035A21 RID: 219681
			public const int GreatSwordChallengePanel = 0;
		}
	}
}
