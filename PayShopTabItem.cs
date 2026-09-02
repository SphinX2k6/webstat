using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001A67 RID: 6759
[NullableContext(1)]
[Nullable(0)]
public class PayShopTabItem : CommonTabItem, ITabViewRegister
{
	// Token: 0x0600C18B RID: 49547 RVA: 0x0032F599 File Offset: 0x0032D799
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUIText)));
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(6, typeof(UUIItem)));
	}

	// Token: 0x0600C18C RID: 49548 RVA: 0x0032F5D7 File Offset: 0x0032D7D7
	public UUIText GetNameTextComponent()
	{
		return base.GetText(5);
	}

	// Token: 0x0600C18D RID: 49549 RVA: 0x0032F5E0 File Offset: 0x0032D7E0
	public UniTask RefreshContentItem(PayShopDefine.EPayShopTabType payShopId)
	{
		PayShopTabItem.<RefreshContentItem>d__6 <RefreshContentItem>d__;
		<RefreshContentItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshContentItem>d__.<>4__this = this;
		<RefreshContentItem>d__.payShopId = payShopId;
		<RefreshContentItem>d__.<>1__state = -1;
		<RefreshContentItem>d__.<>t__builder.Start<PayShopTabItem.<RefreshContentItem>d__6>(ref <RefreshContentItem>d__);
		return <RefreshContentItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600C18E RID: 49550 RVA: 0x0032F62B File Offset: 0x0032D82B
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
	}

	// Token: 0x0600C18F RID: 49551 RVA: 0x0032F63C File Offset: 0x0032D83C
	public override void Refresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		base.Refresh(data, isSelected, gridIndex);
		this.GetTabToggle().RootUIComp.Get().SetUIActive(false);
		this.GetTabToggle().RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x0600C190 RID: 49552 RVA: 0x0032F684 File Offset: 0x0032D884
	public override void BindRedDot(ERedDotName redDotName, int? uId = 0)
	{
		base.BindRedDot(redDotName, uId);
		this.RedDotId = uId;
	}

	// Token: 0x0600C191 RID: 49553 RVA: 0x0032F695 File Offset: 0x0032D895
	public override void UnBindRedDot()
	{
		base.UnBindGivenUid(this.RedDotId);
	}

	// Token: 0x04005A94 RID: 23188
	private int? RedDotId;

	// Token: 0x04005A95 RID: 23189
	private readonly Dictionary<PayShopDefine.EPayShopTabType, UUIItem> ContentItemMap = new Dictionary<PayShopDefine.EPayShopTabType, UUIItem>();

	// Token: 0x04005A96 RID: 23190
	private PayShopDefine.EPayShopTabType? CurrentPayShopId;

	// Token: 0x02007D20 RID: 32032
	[NullableContext(0)]
	private class ECommonTabItem
	{
		// Token: 0x0402AA87 RID: 174727
		public const int NameText = 5;

		// Token: 0x0402AA88 RID: 174728
		public const int ContentItem = 6;
	}
}
