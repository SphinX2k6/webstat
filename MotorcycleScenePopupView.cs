using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200230A RID: 8970
public class MotorcycleScenePopupView : UiViewBase
{
	// Token: 0x06011098 RID: 69784 RVA: 0x004AD67B File Offset: 0x004AB87B
	[NullableContext(1)]
	public MotorcycleScenePopupView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011099 RID: 69785 RVA: 0x004AD684 File Offset: 0x004AB884
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x0601109A RID: 69786 RVA: 0x004AD6F4 File Offset: 0x004AB8F4
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleScenePopupView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleScenePopupView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601109B RID: 69787 RVA: 0x004AD738 File Offset: 0x004AB938
	private UniTask InitDeActivePanelAsync()
	{
		MotorcycleScenePopupView.<InitDeActivePanelAsync>d__8 <InitDeActivePanelAsync>d__;
		<InitDeActivePanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitDeActivePanelAsync>d__.<>4__this = this;
		<InitDeActivePanelAsync>d__.<>1__state = -1;
		<InitDeActivePanelAsync>d__.<>t__builder.Start<MotorcycleScenePopupView.<InitDeActivePanelAsync>d__8>(ref <InitDeActivePanelAsync>d__);
		return <InitDeActivePanelAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601109C RID: 69788 RVA: 0x004AD77C File Offset: 0x004AB97C
	private UniTask InitConfirmBtnAsync()
	{
		MotorcycleScenePopupView.<InitConfirmBtnAsync>d__9 <InitConfirmBtnAsync>d__;
		<InitConfirmBtnAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitConfirmBtnAsync>d__.<>4__this = this;
		<InitConfirmBtnAsync>d__.<>1__state = -1;
		<InitConfirmBtnAsync>d__.<>t__builder.Start<MotorcycleScenePopupView.<InitConfirmBtnAsync>d__9>(ref <InitConfirmBtnAsync>d__);
		return <InitConfirmBtnAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601109D RID: 69789 RVA: 0x004AD7BF File Offset: 0x004AB9BF
	protected override void OnBeforeDestroy()
	{
		GenericLayout<MotorcycleScenePopupItem, int> sceneLayout = this.SceneLayout;
		if (sceneLayout != null)
		{
			sceneLayout.ClearChildren();
		}
		this.SceneLayout = null;
		this.ConfirmBtn = null;
	}

	// Token: 0x0601109E RID: 69790 RVA: 0x004AD7E0 File Offset: 0x004AB9E0
	[NullableContext(1)]
	private MotorcycleScenePopupItem CreateSceneItem()
	{
		return new MotorcycleScenePopupItem
		{
			OnClickToggleBack = new Action<int>(this.OnClickSceneItem),
			GetCurrentSceneId = (() => this.CurrentSelectedSceneId)
		};
	}

	// Token: 0x0601109F RID: 69791 RVA: 0x004AD80C File Offset: 0x004ABA0C
	private UniTask RefreshSceneListAsync()
	{
		MotorcycleScenePopupView.<RefreshSceneListAsync>d__12 <RefreshSceneListAsync>d__;
		<RefreshSceneListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshSceneListAsync>d__.<>4__this = this;
		<RefreshSceneListAsync>d__.<>1__state = -1;
		<RefreshSceneListAsync>d__.<>t__builder.Start<MotorcycleScenePopupView.<RefreshSceneListAsync>d__12>(ref <RefreshSceneListAsync>d__);
		return <RefreshSceneListAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060110A0 RID: 69792 RVA: 0x004AD850 File Offset: 0x004ABA50
	private void SelectDefaultScene()
	{
		int currentSceneId = ModelBase<MotorcycleDiyModel>.Instance.GetCurrentSceneId();
		if (currentSceneId > 0)
		{
			GenericLayout<MotorcycleScenePopupItem, int> sceneLayout = this.SceneLayout;
			if (sceneLayout != null)
			{
				sceneLayout.SelectGridProxyByKey(currentSceneId, false);
			}
			GenericLayout<MotorcycleScenePopupItem, int> sceneLayout2 = this.SceneLayout;
			if (sceneLayout2 == null)
			{
				return;
			}
			MotorcycleScenePopupItem layoutItemByKey = sceneLayout2.GetLayoutItemByKey(currentSceneId);
			if (layoutItemByKey == null)
			{
				return;
			}
			layoutItemByKey.SetToggleState(true, true);
		}
	}

	// Token: 0x060110A1 RID: 69793 RVA: 0x004AD8A8 File Offset: 0x004ABAA8
	private void RefreshBottomBar()
	{
		MotorScene? motorSceneConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorSceneConfig(this.CurrentSelectedSceneId);
		if (motorSceneConfig == null)
		{
			ButtonItem confirmBtn = this.ConfirmBtn;
			if (confirmBtn != null)
			{
				confirmBtn.SetActive(false);
			}
			FunctionalPanelConditionLock deActivePanel = this.DeActivePanel;
			if (deActivePanel == null)
			{
				return;
			}
			deActivePanel.SetUiActive(false);
			return;
		}
		else if (!ModelBase<MotorcycleDiyModel>.Instance.HasScene(this.CurrentSelectedSceneId))
		{
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(motorSceneConfig.Value.UnlockItem);
			if (itemConfig != null && itemConfig.Value.ItemAccessLength > 0)
			{
				int accessPathId = itemConfig.Value.ItemAccess(0);
				AccessPath? accessPathConfig = ConfigBase<InventoryConfig>.Instance.GetAccessPathConfig(accessPathId);
				if (accessPathConfig != null)
				{
					FunctionalPanelConditionLock deActivePanel2 = this.DeActivePanel;
					if (deActivePanel2 != null)
					{
						deActivePanel2.SetTextByTextId(accessPathConfig.Value.Description, Array.Empty<string>());
					}
				}
			}
			ButtonItem confirmBtn2 = this.ConfirmBtn;
			if (confirmBtn2 != null)
			{
				confirmBtn2.SetActive(false);
			}
			FunctionalPanelConditionLock deActivePanel3 = this.DeActivePanel;
			if (deActivePanel3 == null)
			{
				return;
			}
			deActivePanel3.SetUiActive(true);
			return;
		}
		else
		{
			int currentSceneId = ModelBase<MotorcycleDiyModel>.Instance.GetCurrentSceneId();
			bool flag = this.CurrentSelectedSceneId == currentSceneId;
			string textId = flag ? "MotorUILevel_Onuse" : "MotorUILevel_useButton";
			FunctionalPanelConditionLock deActivePanel4 = this.DeActivePanel;
			if (deActivePanel4 != null)
			{
				deActivePanel4.SetUiActive(false);
			}
			ButtonItem confirmBtn3 = this.ConfirmBtn;
			if (confirmBtn3 != null)
			{
				confirmBtn3.SetActive(true);
			}
			ButtonItem confirmBtn4 = this.ConfirmBtn;
			if (confirmBtn4 != null)
			{
				confirmBtn4.SetEnableClick(!flag);
			}
			ButtonItem confirmBtn5 = this.ConfirmBtn;
			if (confirmBtn5 == null)
			{
				return;
			}
			confirmBtn5.SetLocalTextNew(textId, Array.Empty<object>());
			return;
		}
	}

	// Token: 0x060110A2 RID: 69794 RVA: 0x004ADA28 File Offset: 0x004ABC28
	private void OnClickSceneItem(int sceneId)
	{
		if (this.CurrentSelectedSceneId > 0 && this.CurrentSelectedSceneId != sceneId)
		{
			GenericLayout<MotorcycleScenePopupItem, int> sceneLayout = this.SceneLayout;
			if (sceneLayout != null)
			{
				sceneLayout.DeselectCurrentGridProxy();
			}
		}
		this.CurrentSelectedSceneId = sceneId;
		GenericLayout<MotorcycleScenePopupItem, int> sceneLayout2 = this.SceneLayout;
		MotorcycleScenePopupItem motorcycleScenePopupItem = (sceneLayout2 != null) ? sceneLayout2.GetLayoutItemByKey(sceneId) : null;
		if (motorcycleScenePopupItem != null)
		{
			ModelBase<MotorcycleDiyModel>.Instance.RecordHadCheckNewScene(sceneId);
			motorcycleScenePopupItem.RefreshRedDot();
		}
		GenericLayout<MotorcycleScenePopupItem, int> sceneLayout3 = this.SceneLayout;
		if (sceneLayout3 != null)
		{
			sceneLayout3.SelectGridProxyByKey(sceneId, true);
		}
		this.RefreshBottomBar();
	}

	// Token: 0x060110A3 RID: 69795 RVA: 0x004ADAAA File Offset: 0x004ABCAA
	private void OnClickConfirmButton()
	{
		if (!ModelBase<MotorcycleDiyModel>.Instance.HasScene(this.CurrentSelectedSceneId))
		{
			return;
		}
		ControllerBase<MotorcycleDiyController>.Instance.UseMotorSceneRequest(this.CurrentSelectedSceneId, delegate
		{
			this.SwitchScene();
		});
	}

	// Token: 0x060110A4 RID: 69796 RVA: 0x004ADADC File Offset: 0x004ABCDC
	protected void SwitchScene()
	{
		int currentSceneId = ModelBase<MotorcycleDiyModel>.Instance.GetCurrentSceneId();
		if (currentSceneId <= 0)
		{
			return;
		}
		MotorScene? motorSceneConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorSceneConfig(currentSceneId);
		if (motorSceneConfig == null || StringUtils.IsBlank(motorSceneConfig.Value.SceneId))
		{
			return;
		}
		Singleton<UiSceneManager>.Instance.SwitchUiSceneWithBlackScreen(motorSceneConfig.Value.SceneId, delegate(bool isSuccess)
		{
			MotorcycleScenePopupView.<<SwitchScene>b__17_0>d <<SwitchScene>b__17_0>d;
			<<SwitchScene>b__17_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<SwitchScene>b__17_0>d.<>4__this = this;
			<<SwitchScene>b__17_0>d.isSuccess = isSuccess;
			<<SwitchScene>b__17_0>d.<>1__state = -1;
			<<SwitchScene>b__17_0>d.<>t__builder.Start<MotorcycleScenePopupView.<<SwitchScene>b__17_0>d>(ref <<SwitchScene>b__17_0>d);
			return <<SwitchScene>b__17_0>d.<>t__builder.Task;
		}).Forget();
	}

	// Token: 0x0400860E RID: 34318
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<MotorcycleScenePopupItem, int> SceneLayout;

	// Token: 0x0400860F RID: 34319
	[Nullable(2)]
	private FunctionalPanelConditionLock DeActivePanel;

	// Token: 0x04008610 RID: 34320
	[Nullable(2)]
	private ButtonItem ConfirmBtn;

	// Token: 0x04008611 RID: 34321
	private int CurrentSelectedSceneId;

	// Token: 0x02008610 RID: 34320
	private class EComponent
	{
		// Token: 0x0402D594 RID: 185748
		public const int SceneLayout = 0;

		// Token: 0x0402D595 RID: 185749
		public const int SceneItem = 1;

		// Token: 0x0402D596 RID: 185750
		public const int DeActivePanel = 2;

		// Token: 0x0402D597 RID: 185751
		public const int ConfirmButton = 3;
	}
}
