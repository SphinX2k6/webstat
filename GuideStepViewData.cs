using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Guide.StepInfo;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E26 RID: 7718
[NullableContext(2)]
[Nullable(0)]
public class GuideStepViewData
{
	// Token: 0x170011C8 RID: 4552
	// (get) Token: 0x0600E411 RID: 58385 RVA: 0x003D6AE6 File Offset: 0x003D4CE6
	public bool IsMultiAttach
	{
		get
		{
			return this.MultiAttachItems != null;
		}
	}

	// Token: 0x170011C9 RID: 4553
	// (get) Token: 0x0600E412 RID: 58386 RVA: 0x003D6AF4 File Offset: 0x003D4CF4
	[Nullable(1)]
	public object ViewConf
	{
		[NullableContext(1)]
		get
		{
			switch (this.Owner.Config.ContentType)
			{
			case 1:
				this.ViewConfInner = ConfigBase<GuideConfig>.Instance.GetGuideTips(this.Owner.Id);
				break;
			case 3:
				this.ViewConfInner = ConfigBase<GuideConfig>.Instance.GetGuideTutorial(this.Owner.Id);
				break;
			case 4:
				this.ViewConfInner = ConfigBase<GuideConfig>.Instance.GetGuideFocus(this.Owner.Id);
				break;
			}
			if (this.ViewConfInner == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.TL;
				string message = "引导步骤id找不到引导类型数据, 清检查配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("this.Owner!.Id", this.Owner.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return this.ViewConfInner;
		}
	}

	// Token: 0x0600E413 RID: 58387 RVA: 0x003D6BD7 File Offset: 0x003D4DD7
	public UUIItem GetAttachedUiItem()
	{
		return this.AttachedUiItem;
	}

	// Token: 0x0600E414 RID: 58388 RVA: 0x003D6BDF File Offset: 0x003D4DDF
	public void ResetAttachedUiItem()
	{
		this.AttachedUiItem = null;
	}

	// Token: 0x0600E415 RID: 58389 RVA: 0x003D6BE8 File Offset: 0x003D4DE8
	public UUIItem GetAttachedUiItemForShow()
	{
		return this.AttachedUiItemForShow ?? this.AttachedUiItem;
	}

	// Token: 0x0600E416 RID: 58390 RVA: 0x003D6BFA File Offset: 0x003D4DFA
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<UUIItem> GetMultiAttachItems()
	{
		return this.MultiAttachItems;
	}

	// Token: 0x0600E417 RID: 58391 RVA: 0x003D6C04 File Offset: 0x003D4E04
	public void SetAttachedUiItem(UUIItem uiItem)
	{
		if (this.Owner.Config.ContentType != 4)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
			defaultInterpolatedStringHandler.AppendLiteral("引导步骤 ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Owner.Id);
			defaultInterpolatedStringHandler.AppendLiteral(" 的界面类型不是聚焦引导, 无法添加依附的Ui节点");
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.AttachedUiItem = uiItem;
	}

	// Token: 0x0600E418 RID: 58392 RVA: 0x003D6C84 File Offset: 0x003D4E84
	[NullableContext(1)]
	public void SetAttachedUiItemForShow(UUIItem uiItem)
	{
		if (this.Owner.Config.ContentType != 4)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 1);
			defaultInterpolatedStringHandler.AppendLiteral("引导步骤 ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Owner.Id);
			defaultInterpolatedStringHandler.AppendLiteral(" 的界面类型不是聚焦引导, 无法添加依附的Ui节点(显示用)");
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.AttachedUiItemForShow = uiItem;
	}

	// Token: 0x0600E419 RID: 58393 RVA: 0x003D6D04 File Offset: 0x003D4F04
	public void SetMultiAttachItems([Nullable(new byte[]
	{
		2,
		1
	})] List<UUIItem> uiItems)
	{
		if (this.Owner.Config.ContentType != 4)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
			defaultInterpolatedStringHandler.AppendLiteral("引导步骤 ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Owner.Id);
			defaultInterpolatedStringHandler.AppendLiteral(" 的界面类型不是聚焦引导, 无法添加依附的Ui节点");
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.MultiAttachItems = uiItems;
	}

	// Token: 0x0600E41A RID: 58394 RVA: 0x003D6D81 File Offset: 0x003D4F81
	[NullableContext(1)]
	public void TryLockScrollView(UUIScrollViewComponent scrollView)
	{
		this.ScrollView = scrollView;
		this.ScrollViewEnable = this.ScrollView.GetEnable();
		this.ScrollView.SetEnable(false);
	}

	// Token: 0x0600E41B RID: 58395 RVA: 0x003D6DA7 File Offset: 0x003D4FA7
	public void TryUnLockScrollView()
	{
		if (this.ScrollView == null)
		{
			return;
		}
		this.ScrollView.SetEnable(this.ScrollViewEnable);
	}

	// Token: 0x0600E41C RID: 58396 RVA: 0x003D6DC3 File Offset: 0x003D4FC3
	public UiPanelBase GetAttachedView()
	{
		return this.AttachedView;
	}

	// Token: 0x0600E41D RID: 58397 RVA: 0x003D6DCB File Offset: 0x003D4FCB
	[NullableContext(1)]
	public void SetAttachedView(UiPanelBase value)
	{
		this.AttachedView = value;
	}

	// Token: 0x0600E41E RID: 58398 RVA: 0x003D6DD4 File Offset: 0x003D4FD4
	[NullableContext(1)]
	public GuideStepViewData(GuideStepInfo owner)
	{
		this.Owner = owner;
	}

	// Token: 0x0600E41F RID: 58399 RVA: 0x003D6DEA File Offset: 0x003D4FEA
	public void Clear()
	{
		this.TryUnLockScrollView();
		this.AttachedView = null;
		this.AttachedUiItem = null;
		this.AttachedUiItemForShow = null;
		this.ScrollView = null;
	}

	// Token: 0x04006DA1 RID: 28065
	private bool ScrollViewEnable = true;

	// Token: 0x04006DA2 RID: 28066
	private UUIScrollViewComponent ScrollView;

	// Token: 0x04006DA3 RID: 28067
	private readonly GuideStepInfo Owner;

	// Token: 0x04006DA4 RID: 28068
	private object ViewConfInner;

	// Token: 0x04006DA5 RID: 28069
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<UUIItem> MultiAttachItems;

	// Token: 0x04006DA6 RID: 28070
	private UiPanelBase AttachedView;

	// Token: 0x04006DA7 RID: 28071
	public bool IsAttachToBattleView;

	// Token: 0x04006DA8 RID: 28072
	private UUIItem AttachedUiItem;

	// Token: 0x04006DA9 RID: 28073
	private UUIItem AttachedUiItemForShow;
}
