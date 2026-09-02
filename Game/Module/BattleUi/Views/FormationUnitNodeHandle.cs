using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Battle;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006013 RID: 24595
	[NullableContext(2)]
	[Nullable(0)]
	public class FormationUnitNodeHandle
	{
		// Token: 0x0603DF91 RID: 253841 RVA: 0x00FD07EC File Offset: 0x00FCE9EC
		[NullableContext(1)]
		public UniTask InitializeAsync(UUIItem parentItem)
		{
			FormationUnitNodeHandle.<InitializeAsync>d__2 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.parentItem = parentItem;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<FormationUnitNodeHandle.<InitializeAsync>d__2>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DF92 RID: 253842 RVA: 0x00FD0837 File Offset: 0x00FCEA37
		public void Init(FormationPanel formationPanel, FormationPanel gamepadFormationPanel)
		{
			this.RefreshFormationUnitNodeParent(formationPanel, gamepadFormationPanel);
			this.InitializeLinkEnergyButton();
			this.InitializeWeeklyRogueButton();
			this.InitializeBattleTimeDilationButton();
		}

		// Token: 0x0603DF93 RID: 253843 RVA: 0x00FD0853 File Offset: 0x00FCEA53
		public void Destroy()
		{
			if (this.CurFormationExtraButton == null)
			{
				return;
			}
			this.CurFormationExtraButton.Destroy(null);
			this.CurFormationExtraButton = null;
			this.LinkEnergyButton = null;
			this.WeeklyRogueButton = null;
		}

		// Token: 0x0603DF94 RID: 253844 RVA: 0x00FD087F File Offset: 0x00FCEA7F
		public void Tick(float delta)
		{
			FormationExtraButton curFormationExtraButton = this.CurFormationExtraButton;
			if (curFormationExtraButton == null)
			{
				return;
			}
			curFormationExtraButton.Tick(delta);
		}

		// Token: 0x0603DF95 RID: 253845 RVA: 0x00FD0892 File Offset: 0x00FCEA92
		public void OnInputControllerChange(FormationPanel formationPanel, FormationPanel gamepadFormationPanel)
		{
			this.RefreshFormationUnitNodeParent(formationPanel, gamepadFormationPanel);
		}

		// Token: 0x0603DF96 RID: 253846 RVA: 0x00FD089C File Offset: 0x00FCEA9C
		[NullableContext(1)]
		private UniTask NewFormationUnitNode(UUIItem parentItem)
		{
			FormationUnitNodeHandle.<NewFormationUnitNode>d__7 <NewFormationUnitNode>d__;
			<NewFormationUnitNode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewFormationUnitNode>d__.<>4__this = this;
			<NewFormationUnitNode>d__.parentItem = parentItem;
			<NewFormationUnitNode>d__.<>1__state = -1;
			<NewFormationUnitNode>d__.<>t__builder.Start<FormationUnitNodeHandle.<NewFormationUnitNode>d__7>(ref <NewFormationUnitNode>d__);
			return <NewFormationUnitNode>d__.<>t__builder.Task;
		}

		// Token: 0x0603DF97 RID: 253847 RVA: 0x00FD08E7 File Offset: 0x00FCEAE7
		public UUIItem GetRootItem()
		{
			return this.FormationUnitNode;
		}

		// Token: 0x0603DF98 RID: 253848 RVA: 0x00FD08EF File Offset: 0x00FCEAEF
		public void SetNodeVisible(bool visible)
		{
			UUIItem formationUnitNode = this.FormationUnitNode;
			if (formationUnitNode == null)
			{
				return;
			}
			formationUnitNode.SetUIActive(visible);
		}

		// Token: 0x0603DF99 RID: 253849 RVA: 0x00FD0902 File Offset: 0x00FCEB02
		private void RefreshFormationUnitNodeParent(FormationPanel formationPanel, FormationPanel gamepadFormationPanel)
		{
			if (this.FormationUnitNode == null)
			{
				return;
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				if (gamepadFormationPanel != null)
				{
					gamepadFormationPanel.AddChildToRoleHeadPanel(this.FormationUnitNode);
					return;
				}
			}
			else if (formationPanel != null)
			{
				formationPanel.AddChildToRoleHeadPanel(this.FormationUnitNode);
			}
		}

		// Token: 0x0603DF9A RID: 253850 RVA: 0x00FD0938 File Offset: 0x00FCEB38
		public BattleLinkEnergyButton GetLinkEnergyButton()
		{
			return this.LinkEnergyButton;
		}

		// Token: 0x0603DF9B RID: 253851 RVA: 0x00FD0940 File Offset: 0x00FCEB40
		private void InitializeLinkEnergyButton()
		{
			if (this.LinkEnergyButton != null)
			{
				return;
			}
			if (!ModelBase<BattleLinkModel>.Instance.CheckInNewBattleLink() && !ModelBase<BattleLinkModel>.Instance.CheckInSpecialBattleLink())
			{
				return;
			}
			BattleLinkEnergyButton battleLinkEnergyButton = new BattleLinkEnergyButton();
			string resourceId = battleLinkEnergyButton.GetResourceId();
			if (string.IsNullOrEmpty(resourceId))
			{
				return;
			}
			this.LinkEnergyButton = battleLinkEnergyButton;
			this.LinkEnergyButton.InitHandle(this);
			this.LinkEnergyButton.CreateByResourceIdAsync(resourceId, this.FormationUnitNode, false).Forget();
			this.CurFormationExtraButton = this.LinkEnergyButton;
		}

		// Token: 0x0603DF9C RID: 253852 RVA: 0x00FD09BC File Offset: 0x00FCEBBC
		public void ShowLinkButton(bool isShow)
		{
			if (isShow)
			{
				if (this.LinkEnergyButton == null)
				{
					BattleLinkEnergyButton battleLinkEnergyButton = new BattleLinkEnergyButton();
					string resourceId = battleLinkEnergyButton.GetResourceId();
					if (string.IsNullOrEmpty(resourceId))
					{
						return;
					}
					this.LinkEnergyButton = battleLinkEnergyButton;
					this.LinkEnergyButton.InitHandle(this);
					this.LinkEnergyButton.CreateByResourceIdAsync(resourceId, this.FormationUnitNode, false).ContinueWith(delegate()
					{
						BattleLinkEnergyButton linkEnergyButton3 = this.LinkEnergyButton;
						if (linkEnergyButton3 == null)
						{
							return;
						}
						linkEnergyButton3.SetVisible(true);
					}).Forget();
					this.CurFormationExtraButton = this.LinkEnergyButton;
					return;
				}
				else
				{
					BattleLinkEnergyButton linkEnergyButton = this.LinkEnergyButton;
					if (linkEnergyButton == null)
					{
						return;
					}
					linkEnergyButton.SetVisible(true);
					return;
				}
			}
			else
			{
				BattleLinkEnergyButton linkEnergyButton2 = this.LinkEnergyButton;
				if (linkEnergyButton2 == null)
				{
					return;
				}
				linkEnergyButton2.SetVisible(false);
				return;
			}
		}

		// Token: 0x0603DF9D RID: 253853 RVA: 0x00FD0A56 File Offset: 0x00FCEC56
		public BattleWeeklyRogueButton GetWeeklyRogueButton()
		{
			return this.WeeklyRogueButton;
		}

		// Token: 0x0603DF9E RID: 253854 RVA: 0x00FD0A60 File Offset: 0x00FCEC60
		private void InitializeWeeklyRogueButton()
		{
			if (this.WeeklyRogueButton != null)
			{
				return;
			}
			if (!ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue())
			{
				return;
			}
			this.WeeklyRogueButton = new BattleWeeklyRogueButton();
			this.WeeklyRogueButton.InitHandle(this);
			this.WeeklyRogueButton.CreateByResourceIdAsync("UiItem_WeeklyRogueButton", this.FormationUnitNode, false).Forget();
			this.CurFormationExtraButton = this.WeeklyRogueButton;
			this.WeeklyRogueButton.SetVisible(true);
		}

		// Token: 0x0603DF9F RID: 253855 RVA: 0x00FD0ACE File Offset: 0x00FCECCE
		public BattleTimeDilationButton GetBattleTimeDilationButton()
		{
			return this.BattleTimeDilationButton;
		}

		// Token: 0x0603DFA0 RID: 253856 RVA: 0x00FD0AD8 File Offset: 0x00FCECD8
		private void InitializeBattleTimeDilationButton()
		{
			if (this.BattleTimeDilationButton != null)
			{
				return;
			}
			if (!ModelBase<BattleUiModel>.Instance.IsTimeDilationSkillButtonEnable())
			{
				return;
			}
			this.BattleTimeDilationButton = new BattleTimeDilationButton();
			this.BattleTimeDilationButton.InitHandle(this);
			this.BattleTimeDilationButton.CreateByResourceIdAsync("UiItem_BattlePhotoHourglass", this.FormationUnitNode, false).Forget();
			this.CurFormationExtraButton = this.BattleTimeDilationButton;
			this.BattleTimeDilationButton.SetVisible(true);
		}

		// Token: 0x0603DFA1 RID: 253857 RVA: 0x00FD0B48 File Offset: 0x00FCED48
		public void UpdateTimeDilationButton()
		{
			if (ModelBase<BattleUiModel>.Instance.IsTimeDilationSkillButtonEnable())
			{
				if (this.BattleTimeDilationButton == null)
				{
					this.BattleTimeDilationButton = new BattleTimeDilationButton();
					this.BattleTimeDilationButton.InitHandle(this);
					this.BattleTimeDilationButton.CreateByResourceIdAsync("UiItem_BattlePhotoHourglass", this.FormationUnitNode, false).ContinueWith(delegate()
					{
						BattleTimeDilationButton battleTimeDilationButton3 = this.BattleTimeDilationButton;
						if (battleTimeDilationButton3 == null)
						{
							return;
						}
						battleTimeDilationButton3.SetVisible(ModelBase<BattleUiModel>.Instance.IsTimeDilationSkillButtonEnable());
					}).Forget();
					this.CurFormationExtraButton = this.BattleTimeDilationButton;
					return;
				}
				BattleTimeDilationButton battleTimeDilationButton = this.BattleTimeDilationButton;
				if (battleTimeDilationButton == null)
				{
					return;
				}
				battleTimeDilationButton.SetVisible(true);
				return;
			}
			else
			{
				BattleTimeDilationButton battleTimeDilationButton2 = this.BattleTimeDilationButton;
				if (battleTimeDilationButton2 == null)
				{
					return;
				}
				battleTimeDilationButton2.SetVisible(false);
				return;
			}
		}

		// Token: 0x04022C25 RID: 142373
		private UUIItem FormationUnitNode;

		// Token: 0x04022C26 RID: 142374
		private FormationExtraButton CurFormationExtraButton;

		// Token: 0x04022C27 RID: 142375
		private BattleLinkEnergyButton LinkEnergyButton;

		// Token: 0x04022C28 RID: 142376
		private BattleWeeklyRogueButton WeeklyRogueButton;

		// Token: 0x04022C29 RID: 142377
		private BattleTimeDilationButton BattleTimeDilationButton;
	}
}
