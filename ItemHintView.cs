using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002061 RID: 8289
[NullableContext(1)]
[Nullable(0)]
public class ItemHintView : UiTickViewBase
{
	// Token: 0x0600FCC0 RID: 64704 RVA: 0x00455ED7 File Offset: 0x004540D7
	public ItemHintView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FCC1 RID: 64705 RVA: 0x00455EE0 File Offset: 0x004540E0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0600FCC2 RID: 64706 RVA: 0x00455F19 File Offset: 0x00454119
	protected override void OnBeforeDestroy()
	{
		if (this.ListSlideControl != null)
		{
			this.ListSlideControl.DestroyMe();
			this.ListSlideControl = null;
		}
		if (this.ListPriorSlideControl != null)
		{
			this.ListPriorSlideControl.DestroyMe();
			this.ListPriorSlideControl = null;
		}
	}

	// Token: 0x0600FCC3 RID: 64707 RVA: 0x00455F50 File Offset: 0x00454150
	protected override void OnStart()
	{
		if (!this.CheckNext() && !this.CheckPriorNext())
		{
			Singleton<Log>.Instance.Warn(ELogModule.ItemHint, ELogAuthor.ZJC, "进包列表为空, 但打开了界面!", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.CloseMe(null);
			return;
		}
		UUIItem item = base.GetItem(1);
		UUIItem item2 = base.GetItem(0);
		item.SetUIActive(false);
		item2.SetUIActive(false);
		this.ListSlideControl = new ListSliderControl<ItemHintItem>(new ListSliderControlData<ItemHintItem>(item.GetParentAsUIItem(), new Func<ItemHintItem>(this.CreateItemProxy), new Func<bool>(this.CheckNext))
		{
			MaxShowCount = new int?(this.GetIntoBagMaxCount()),
			AddItemTime = new float?((float)this.AddItemTime()),
			ItemSliderTime = new float?((float)ConfigBase<RewardConfig>.Instance.GetSliderTime()),
			ItemShowTime = new float?((float)ConfigBase<RewardConfig>.Instance.GetShowTime()),
			FinishCallback = new Action(this.FinishCallback),
			SliderMode = new ESliderMode?(ESliderMode.SliderWhenPlayEnd),
			ChildResourceId = "UiItem_ItemListB"
		});
		this.ListSlideControl.DisEnableParentLayout();
		this.ListPriorSlideControl = new ListSliderControl<ItemPriorHintItem>(new ListSliderControlData<ItemPriorHintItem>(item2.GetParentAsUIItem(), new Func<ItemPriorHintItem>(this.CreatePriorItemProxy), new Func<bool>(this.CheckPriorNext))
		{
			MaxShowCount = new int?(this.GetPriorIntoBagMaxCount()),
			AddItemTime = new float?((float)this.AddItemTime()),
			ItemSliderTime = new float?((float)ConfigBase<RewardConfig>.Instance.GetSliderTime()),
			ItemShowTime = new float?((float)ConfigBase<RewardConfig>.Instance.GetShowTime()),
			FinishCallback = new Action(this.FinishCallback),
			SliderMode = new ESliderMode?(ESliderMode.SliderWhenPlayEnd),
			ChildResourceId = "UiItem_ItemListA"
		});
		this.ListPriorSlideControl.DisEnableParentLayout();
	}

	// Token: 0x0600FCC4 RID: 64708 RVA: 0x00456112 File Offset: 0x00454312
	private ItemHintItem CreateItemProxy()
	{
		return new ItemHintItem();
	}

	// Token: 0x0600FCC5 RID: 64709 RVA: 0x00456119 File Offset: 0x00454319
	private ItemPriorHintItem CreatePriorItemProxy()
	{
		return new ItemPriorHintItem();
	}

	// Token: 0x0600FCC6 RID: 64710 RVA: 0x00456120 File Offset: 0x00454320
	private int GetIntoBagMaxCount()
	{
		return ConfigBase<ItemConfig>.Instance.GetItemListMaxSize();
	}

	// Token: 0x0600FCC7 RID: 64711 RVA: 0x0045612C File Offset: 0x0045432C
	private int GetPriorIntoBagMaxCount()
	{
		return ConfigBase<ItemConfig>.Instance.GetPriorItemListMaxSize();
	}

	// Token: 0x0600FCC8 RID: 64712 RVA: 0x00456138 File Offset: 0x00454338
	private bool CheckNext()
	{
		return !ModelBase<ItemHintModel>.Instance.IsMainInterfaceDataEmpty;
	}

	// Token: 0x0600FCC9 RID: 64713 RVA: 0x00456147 File Offset: 0x00454347
	private bool CheckPriorNext()
	{
		return !ModelBase<ItemHintModel>.Instance.IsPriorInterfaceDataEmpty;
	}

	// Token: 0x0600FCCA RID: 64714 RVA: 0x00456156 File Offset: 0x00454356
	private int AddItemTime()
	{
		return ConfigBase<RewardConfig>.Instance.GetNextItemTime();
	}

	// Token: 0x0600FCCB RID: 64715 RVA: 0x00456162 File Offset: 0x00454362
	private void FinishCallback()
	{
		if (this.ListPriorSlideControl.IsFinish && this.ListSlideControl.IsFinish)
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x0600FCCC RID: 64716 RVA: 0x00456185 File Offset: 0x00454385
	protected override void OnTick(float delta)
	{
		if (this.ListPriorSlideControl != null)
		{
			this.ListPriorSlideControl.Tick(delta);
		}
		if (this.ListSlideControl != null)
		{
			this.ListSlideControl.Tick(delta);
		}
	}

	// Token: 0x0400792D RID: 31021
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ListSliderControl<ItemHintItem> ListSlideControl;

	// Token: 0x0400792E RID: 31022
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ListSliderControl<ItemPriorHintItem> ListPriorSlideControl;

	// Token: 0x020083FC RID: 33788
	[NullableContext(0)]
	private enum EItemHintViewCom
	{
		// Token: 0x0402CBD1 RID: 183249
		ItemPriorHintItem,
		// Token: 0x0402CBD2 RID: 183250
		ItemHintItem
	}
}
