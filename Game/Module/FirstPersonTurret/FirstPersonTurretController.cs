using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.FirstPersonTurret.View;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.FirstPersonTurret
{
	// Token: 0x02005D7D RID: 23933
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class FirstPersonTurretController : ControllerBase<FirstPersonTurretController>
	{
		// Token: 0x0603C455 RID: 246869 RVA: 0x00F4AFD1 File Offset: 0x00F491D1
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603C456 RID: 246870 RVA: 0x00F4AFD4 File Offset: 0x00F491D4
		protected override void OnTick(float delta)
		{
		}

		// Token: 0x0603C457 RID: 246871 RVA: 0x00F4AFD8 File Offset: 0x00F491D8
		public void Start(GeneralLogicTreeContext context)
		{
			this.IsInGameplay = true;
			GeneralLogicTreeContext context2 = this.Context;
			if (context2 != null)
			{
				context2.Release();
			}
			this.Context = GeneralLogicTreeContext.Create(context.BtType, context.TreeIncId, context.TreeConfigId, context.NodeId, null);
			this.BindInputActions();
			this.OpenUi();
		}

		// Token: 0x0603C458 RID: 246872 RVA: 0x00F4B035 File Offset: 0x00F49235
		public void End()
		{
			this.IsInGameplay = false;
			this.UnBindInputActions();
			GeneralLogicTreeContext context = this.Context;
			if (context != null)
			{
				context.Release();
			}
			this.Context = null;
			this.CloseUi();
		}

		// Token: 0x0603C459 RID: 246873 RVA: 0x00F4B062 File Offset: 0x00F49262
		protected override bool OnClear()
		{
			this.End();
			return true;
		}

		// Token: 0x0603C45A RID: 246874 RVA: 0x00F4B06C File Offset: 0x00F4926C
		private void OpenUi()
		{
			BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
			if (instance != null)
			{
				BattleUiChildViewData childViewData = instance.ChildViewData;
				if (childViewData != null)
				{
					childViewData.HideBattleView(EBattleUiVisibleReason.Custom, new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
					{
						EBattleUiChild.Mission,
						EBattleUiChild.Formation,
						EBattleUiChild.GamepadFormation,
						EBattleUiChild.BattleHud,
						EBattleUiChild.ScreenEffect,
						EBattleUiChild.DamageView
					}), 0);
				}
			}
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FirstPersonTurretView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.FirstPersonTurretView, null, new TOpenViewCallBack(this.OnOpenFightUiFinished));
				return;
			}
			this.RefreshUi();
		}

		// Token: 0x0603C45B RID: 246875 RVA: 0x00F4B0E0 File Offset: 0x00F492E0
		private void OnOpenFightUiFinished(bool success, int viewId)
		{
			if (!success || !this.IsInGameplay)
			{
				this.CloseUi();
				return;
			}
			this.RefreshUi();
		}

		// Token: 0x0603C45C RID: 246876 RVA: 0x00F4B0FA File Offset: 0x00F492FA
		private void CloseUi()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FirstPersonTurretView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.FirstPersonTurretView, null);
			}
			BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
			if (instance == null)
			{
				return;
			}
			BattleUiChildViewData childViewData = instance.ChildViewData;
			if (childViewData == null)
			{
				return;
			}
			childViewData.ShowBattleView(EBattleUiVisibleReason.Custom, 0);
		}

		// Token: 0x0603C45D RID: 246877 RVA: 0x00F4B138 File Offset: 0x00F49338
		private void RefreshUi()
		{
			FirstPersonTurretView view = this.GetView();
			if (view == null)
			{
				return;
			}
			view.OnExitClicked = new Action(this.OnExitClicked);
		}

		// Token: 0x0603C45E RID: 246878 RVA: 0x00F4B162 File Offset: 0x00F49362
		[NullableContext(2)]
		private FirstPersonTurretView GetView()
		{
			return Singleton<UiManager>.Instance.GetViewByName(EUiViewName.FirstPersonTurretView) as FirstPersonTurretView;
		}

		// Token: 0x0603C45F RID: 246879 RVA: 0x00F4B178 File Offset: 0x00F49378
		private void BindInputActions()
		{
			ControllerBase<InputDistributeController>.Instance.BindAction("玩法放弃", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0603C460 RID: 246880 RVA: 0x00F4B195 File Offset: 0x00F49395
		private void UnBindInputActions()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction("玩法放弃", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0603C461 RID: 246881 RVA: 0x00F4B1B2 File Offset: 0x00F493B2
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (this.IsInGameplay && actionType == InputDistributeDefine.EActionType.Press && actionName == "玩法放弃")
			{
				this.OnExitClicked();
			}
		}

		// Token: 0x0603C462 RID: 246882 RVA: 0x00F4B1D2 File Offset: 0x00F493D2
		private void OnExitClicked()
		{
			ControllerBase<InstanceDungeonController>.Instance.OnClickInstanceDungeonExitButton(null, null, true);
		}

		// Token: 0x04021E39 RID: 138809
		private bool IsInGameplay;

		// Token: 0x04021E3A RID: 138810
		[Nullable(2)]
		private GeneralLogicTreeContext Context;
	}
}
