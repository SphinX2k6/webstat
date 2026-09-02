using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020022CB RID: 8907
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleTechTreeSwitchView : UiViewBase
{
	// Token: 0x170014E0 RID: 5344
	// (get) Token: 0x06010D9C RID: 69020 RVA: 0x0049CB71 File Offset: 0x0049AD71
	private bool IsLockByTime
	{
		get
		{
			return ModelBase<MotorcycleDevelopModel>.Instance.IsSwitchTechTreeTimeLocked();
		}
	}

	// Token: 0x170014E1 RID: 5345
	// (get) Token: 0x06010D9D RID: 69021 RVA: 0x0049CB7D File Offset: 0x0049AD7D
	private bool IsLockByPlayerStatus
	{
		get
		{
			return ModelBase<MotorcycleDevelopModel>.Instance.IsSwitchTechTreePlayerLocked();
		}
	}

	// Token: 0x06010D9E RID: 69022 RVA: 0x0049CB89 File Offset: 0x0049AD89
	public MotorcycleTechTreeSwitchView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010D9F RID: 69023 RVA: 0x0049CB94 File Offset: 0x0049AD94
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
		};
	}

	// Token: 0x06010DA0 RID: 69024 RVA: 0x0049CC04 File Offset: 0x0049AE04
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleTechTreeSwitchView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleTechTreeSwitchView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010DA1 RID: 69025 RVA: 0x0049CC47 File Offset: 0x0049AE47
	protected override void OnBeforeShow()
	{
		UUIInturnAnimController uuiinturnAnimController = base.GetHorizontalLayout(1).GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
		if (uuiinturnAnimController == null)
		{
			return;
		}
		uuiinturnAnimController.Play("", -1, false);
	}

	// Token: 0x06010DA2 RID: 69026 RVA: 0x0049CC7A File Offset: 0x0049AE7A
	protected override void OnBeforeDestroy()
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.Destroy(null);
	}

	// Token: 0x06010DA3 RID: 69027 RVA: 0x0049CC8D File Offset: 0x0049AE8D
	private MotorcycleTechTreeSwitchItem InitItem()
	{
		return new MotorcycleTechTreeSwitchItem
		{
			OnClickToggleBack = new Action<int, UUIExtendToggle>(this.OnClickItem)
		};
	}

	// Token: 0x06010DA4 RID: 69028 RVA: 0x0049CCA8 File Offset: 0x0049AEA8
	private void OnClickItem(int treeType, UUIExtendToggle toggle)
	{
		if (this.CurrentSelectToggle != null)
		{
			this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		this.SelectedTechTreeType = treeType;
		bool enableClick = this.SelectedTechTreeType != this.CacheCurTreeType;
		this.SwitchBtnItem.SetEnableClick(enableClick);
	}

	// Token: 0x06010DA5 RID: 69029 RVA: 0x0049CD09 File Offset: 0x0049AF09
	private void OnBackButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06010DA6 RID: 69030 RVA: 0x0049CD14 File Offset: 0x0049AF14
	private void OnBtnSwitchClick(int _)
	{
		if (this.IsLockByTime)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorBike_TechTree_ChangeFail_Time", Array.Empty<object>());
			return;
		}
		if (this.IsLockByPlayerStatus)
		{
			return;
		}
		int curTreeType = ModelBase<MotorcycleDevelopModel>.Instance.GetCurTreeType();
		if (this.SelectedTechTreeType == curTreeType)
		{
			base.CloseMe(null);
			return;
		}
		ControllerBase<MotorcycleDevelopController>.Instance.RequestMotorTechTreeSwitch(this.SelectedTechTreeType, delegate
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("SwitchMotorTechTreeCD");
			if (intConfig != null)
			{
				ModelBase<MotorcycleDevelopModel>.Instance.StartSwitchTechTreeLockTimer(intConfig.Value);
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(this.SelectedTechTreeType).Value.Name, null);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorBike_TechTree_ChangeSuccess", new object[]
			{
				localTextNew
			});
			base.CloseMe(null);
		});
	}

	// Token: 0x040084D0 RID: 34000
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x040084D1 RID: 34001
	[Nullable(2)]
	private ButtonItem SwitchBtnItem;

	// Token: 0x040084D2 RID: 34002
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<MotorcycleTechTreeSwitchItem, int> TechTreeLayout;

	// Token: 0x040084D3 RID: 34003
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x040084D4 RID: 34004
	private int SelectedTechTreeType;

	// Token: 0x040084D5 RID: 34005
	private int CacheCurTreeType;

	// Token: 0x0200859B RID: 34203
	[NullableContext(0)]
	private class EMotorTechTreeSwitchComponent
	{
		// Token: 0x0402D339 RID: 185145
		public const int ItemCaption = 0;

		// Token: 0x0402D33A RID: 185146
		public const int Layout = 1;

		// Token: 0x0402D33B RID: 185147
		public const int LayoutItem = 2;

		// Token: 0x0402D33C RID: 185148
		public const int BtnConfirm = 3;
	}
}
