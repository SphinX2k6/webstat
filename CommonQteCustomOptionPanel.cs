using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200261A RID: 9754
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteCustomOptionPanel : CommonQteItemBase<CommonQteSelectOptionContext>
{
	// Token: 0x0601328E RID: 78478 RVA: 0x0055153A File Offset: 0x0054F73A
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0601328F RID: 78479 RVA: 0x00551563 File Offset: 0x0054F763
	public override void SetPreloadQte(int qteId)
	{
		this.PreloadQteId = qteId;
	}

	// Token: 0x06013290 RID: 78480 RVA: 0x0055156C File Offset: 0x0054F76C
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteCustomOptionPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteCustomOptionPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013291 RID: 78481 RVA: 0x005515AF File Offset: 0x0054F7AF
	protected override void OnStart()
	{
		base.OnStart();
		base.SetUiActive(false);
	}

	// Token: 0x06013292 RID: 78482 RVA: 0x005515C0 File Offset: 0x0054F7C0
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		foreach (CommonQteCustomOptionItem commonQteCustomOptionItem in this.OptionItemList)
		{
			commonQteCustomOptionItem.Destroy(null);
		}
		this.OptionItemList.Clear();
	}

	// Token: 0x06013293 RID: 78483 RVA: 0x00551624 File Offset: 0x0054F824
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteSelectOptionContext;
	}

	// Token: 0x06013294 RID: 78484 RVA: 0x00551630 File Offset: 0x0054F830
	public override void SetQteContext(CommonQteContextBase context)
	{
		CommonQteSelectOptionContext commonQteSelectOptionContext = context as CommonQteSelectOptionContext;
		if (commonQteSelectOptionContext == null)
		{
			return;
		}
		this.QteHandle = context.HandleId;
		this.CommonQteContext = commonQteSelectOptionContext;
		foreach (CommonQteCustomOptionItem commonQteCustomOptionItem in this.OptionItemList)
		{
			commonQteCustomOptionItem.SetQteContext(context);
		}
		base.SetQteActive(context);
		this.PlayQteStart();
	}

	// Token: 0x06013295 RID: 78485 RVA: 0x005516AC File Offset: 0x0054F8AC
	protected override void OnPlayQteStart()
	{
		this.IsQteStart = true;
		this.IsQteInteractive = true;
		base.SetUiActive(true);
		foreach (CommonQteCustomOptionItem commonQteCustomOptionItem in this.OptionItemList)
		{
			commonQteCustomOptionItem.PlayQteStart();
		}
	}

	// Token: 0x06013296 RID: 78486 RVA: 0x00551714 File Offset: 0x0054F914
	protected override void OnHandleQteEnd()
	{
		foreach (CommonQteCustomOptionItem commonQteCustomOptionItem in new List<CommonQteCustomOptionItem>(this.OptionItemList))
		{
			commonQteCustomOptionItem.PlayQteEnd();
		}
	}

	// Token: 0x06013297 RID: 78487 RVA: 0x0055176C File Offset: 0x0054F96C
	public void OnOptionItemPlayEnded(CommonQteCustomOptionItem optionItem)
	{
		int num = this.OptionItemList.IndexOf(optionItem);
		if (num != -1)
		{
			this.OptionItemList.RemoveAt(num);
		}
		if (this.OptionItemList.Count == 0)
		{
			base.Destroy(null);
		}
	}

	// Token: 0x06013298 RID: 78488 RVA: 0x005517AC File Offset: 0x0054F9AC
	protected override void OnTickQteItem(float delta)
	{
		if (!this.CommonQteContext.IsPermanent)
		{
			CommonQteSelectOptionContext commonQteContext = this.CommonQteContext;
			float value = (commonQteContext != null) ? commonQteContext.GetRemainingTimeProgress() : 1f;
			foreach (CommonQteCustomOptionItem commonQteCustomOptionItem in this.OptionItemList)
			{
				commonQteCustomOptionItem.SetProgress(value);
			}
		}
		CommonQteModel instance = ModelBase<CommonQteModel>.Instance;
		if (instance != null && instance.IsRefreshMode)
		{
			foreach (CommonQteCustomOptionItem commonQteCustomOptionItem2 in this.OptionItemList)
			{
				commonQteCustomOptionItem2.RefreshUiOffset();
			}
			if (this.IsAttaching)
			{
				this.Reattach(this.CommonQteContext);
			}
		}
	}

	// Token: 0x06013299 RID: 78489 RVA: 0x0055188C File Offset: 0x0054FA8C
	protected override bool IsUseBaseAction()
	{
		return false;
	}

	// Token: 0x04009588 RID: 38280
	private int PreloadQteId;

	// Token: 0x04009589 RID: 38281
	private readonly List<CommonQteCustomOptionItem> OptionItemList = new List<CommonQteCustomOptionItem>();

	// Token: 0x020089B3 RID: 35251
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E74F RID: 190287
		OffsetPanel
	}
}
