using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013CC RID: 5068
[NullableContext(1)]
[Nullable(0)]
public class BusinessHelperView : UiViewBase
{
	// Token: 0x06008BFD RID: 35837 RVA: 0x0024D6FB File Offset: 0x0024B8FB
	public BusinessHelperView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06008BFE RID: 35838 RVA: 0x0024D710 File Offset: 0x0024B910
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(USpineSkeletonAnimationComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06008BFF RID: 35839 RVA: 0x0024D7AC File Offset: 0x0024B9AC
	private UniTask InitHelperPanel()
	{
		BusinessHelperView.<InitHelperPanel>d__7 <InitHelperPanel>d__;
		<InitHelperPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitHelperPanel>d__.<>4__this = this;
		<InitHelperPanel>d__.<>1__state = -1;
		<InitHelperPanel>d__.<>t__builder.Start<BusinessHelperView.<InitHelperPanel>d__7>(ref <InitHelperPanel>d__);
		return <InitHelperPanel>d__.<>t__builder.Task;
	}

	// Token: 0x06008C00 RID: 35840 RVA: 0x0024D7F0 File Offset: 0x0024B9F0
	private UniTask InitInteractivePanel()
	{
		BusinessHelperView.<InitInteractivePanel>d__8 <InitInteractivePanel>d__;
		<InitInteractivePanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitInteractivePanel>d__.<>4__this = this;
		<InitInteractivePanel>d__.<>1__state = -1;
		<InitInteractivePanel>d__.<>t__builder.Start<BusinessHelperView.<InitInteractivePanel>d__8>(ref <InitInteractivePanel>d__);
		return <InitInteractivePanel>d__.<>t__builder.Task;
	}

	// Token: 0x06008C01 RID: 35841 RVA: 0x0024D834 File Offset: 0x0024BA34
	private UniTask InitCaptionItem()
	{
		BusinessHelperView.<InitCaptionItem>d__9 <InitCaptionItem>d__;
		<InitCaptionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCaptionItem>d__.<>4__this = this;
		<InitCaptionItem>d__.<>1__state = -1;
		<InitCaptionItem>d__.<>t__builder.Start<BusinessHelperView.<InitCaptionItem>d__9>(ref <InitCaptionItem>d__);
		return <InitCaptionItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008C02 RID: 35842 RVA: 0x0024D878 File Offset: 0x0024BA78
	protected override UniTask OnBeforeStartAsync()
	{
		BusinessHelperView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BusinessHelperView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008C03 RID: 35843 RVA: 0x0024D8BB File Offset: 0x0024BABB
	protected override void OnBeforeShow()
	{
		this.Vc.Show();
		ControllerBase<ActivityMoonChasingController>.Instance.CheckIsActivityClose();
	}

	// Token: 0x06008C04 RID: 35844 RVA: 0x0024D8D2 File Offset: 0x0024BAD2
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OpenTipsShopView, new Action(this.Vc.RefreshInteractivePanel));
	}

	// Token: 0x06008C05 RID: 35845 RVA: 0x0024D8F5 File Offset: 0x0024BAF5
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenTipsShopView, new Action(this.Vc.RefreshInteractivePanel));
	}

	// Token: 0x06008C06 RID: 35846 RVA: 0x0024D918 File Offset: 0x0024BB18
	public UniTask RefreshSpine(int roleId)
	{
		BusinessHelperView.<RefreshSpine>d__14 <RefreshSpine>d__;
		<RefreshSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshSpine>d__.<>4__this = this;
		<RefreshSpine>d__.roleId = roleId;
		<RefreshSpine>d__.<>1__state = -1;
		<RefreshSpine>d__.<>t__builder.Start<BusinessHelperView.<RefreshSpine>d__14>(ref <RefreshSpine>d__);
		return <RefreshSpine>d__.<>t__builder.Task;
	}

	// Token: 0x06008C07 RID: 35847 RVA: 0x0024D964 File Offset: 0x0024BB64
	public void SkipToHelpPanel()
	{
		BusinessHelperPanel helperPanel = this.HelperPanel;
		if (helperPanel != null)
		{
			helperPanel.SetActive(true);
		}
		this.CaptionItem.SetTitleIconByResourceId("SP_ChasingMoonIcon8").Forget();
		base.PlaySequenceAsync("SwitchOut", true, false, null).ContinueWith(delegate()
		{
			BusinessInteractivePanel interactivePanel = this.InteractivePanel;
			if (interactivePanel == null)
			{
				return;
			}
			interactivePanel.SetActive(false);
		}).Forget();
	}

	// Token: 0x06008C08 RID: 35848 RVA: 0x0024D9C4 File Offset: 0x0024BBC4
	public void SkipToInteractivePanel()
	{
		BusinessInteractivePanel interactivePanel = this.InteractivePanel;
		if (interactivePanel != null)
		{
			interactivePanel.SetActive(true);
		}
		this.CaptionItem.SetTitleIconByResourceId("SP_ChasingMoonIcon1").Forget();
		base.PlaySequenceAsync("SwitchIn", true, false, null).ContinueWith(delegate()
		{
			BusinessHelperPanel helperPanel = this.HelperPanel;
			if (helperPanel != null)
			{
				helperPanel.SetActive(false);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.MoonChasingOnOpenInteractive);
		}).Forget();
	}

	// Token: 0x06008C09 RID: 35849 RVA: 0x0024DA24 File Offset: 0x0024BC24
	public void RefreshInteractivePanel()
	{
		BusinessInteractivePanel interactivePanel = this.InteractivePanel;
		if (interactivePanel == null)
		{
			return;
		}
		interactivePanel.Refresh().Forget();
	}

	// Token: 0x06008C0A RID: 35850 RVA: 0x0024DA3C File Offset: 0x0024BC3C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length < 1)
		{
			return null;
		}
		string a = configParams[0];
		if (!(a == "Helper") && !(a == "HelperFirst"))
		{
			if (!(a == "Interactive"))
			{
				return null;
			}
			BusinessInteractivePanel interactivePanel = this.InteractivePanel;
			if (interactivePanel == null)
			{
				return null;
			}
			return interactivePanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
		else
		{
			BusinessHelperPanel helperPanel = this.HelperPanel;
			if (helperPanel == null)
			{
				return null;
			}
			return helperPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
	}

	// Token: 0x06008C0B RID: 35851 RVA: 0x0024DAA5 File Offset: 0x0024BCA5
	public void ShowView(bool inInInteractive)
	{
		if (ModelBase<MoonChasingModel>.Instance.CheckRoleFosterTipsRedDotState())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Moonfiesta_HeartFullTip", Array.Empty<object>());
		}
		if (!inInInteractive)
		{
			BusinessHelperPanel helperPanel = this.HelperPanel;
			if (helperPanel == null)
			{
				return;
			}
			helperPanel.SetActive(true);
		}
	}

	// Token: 0x04004140 RID: 16704
	[Nullable(2)]
	protected PopupCaptionItem CaptionItem;

	// Token: 0x04004141 RID: 16705
	[Nullable(2)]
	protected BusinessHelperPanel HelperPanel;

	// Token: 0x04004142 RID: 16706
	[Nullable(2)]
	protected BusinessInteractivePanel InteractivePanel;

	// Token: 0x04004143 RID: 16707
	private readonly BusinessHelperViewController Vc = new BusinessHelperViewController();

	// Token: 0x020077A5 RID: 30629
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x040292EA RID: 168682
		public const int CaptionItem = 0;

		// Token: 0x040292EB RID: 168683
		public const int HelperItem = 1;

		// Token: 0x040292EC RID: 168684
		public const int InteractiveItem = 2;

		// Token: 0x040292ED RID: 168685
		public const int RoleSpineItem = 3;

		// Token: 0x040292EE RID: 168686
		public const int RoleSpine = 4;

		// Token: 0x040292EF RID: 168687
		public const int LockItem = 5;
	}
}
