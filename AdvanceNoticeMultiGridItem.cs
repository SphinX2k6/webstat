using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200118C RID: 4492
public class AdvanceNoticeMultiGridItem : UiPanelBase
{
	// Token: 0x06007634 RID: 30260 RVA: 0x001EE891 File Offset: 0x001ECA91
	public AdvanceNoticeMultiGridItem(int advertisingPageInfoId)
	{
		this.AdvertisingPageInfoId = advertisingPageInfoId;
	}

	// Token: 0x06007635 RID: 30261 RVA: 0x001EE8AC File Offset: 0x001ECAAC
	protected override void OnRegisterComponent()
	{
		int gridCount = this.GetGridCount();
		for (int i = 0; i < gridCount; i++)
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i, typeof(UUIItem)));
		}
	}

	// Token: 0x06007636 RID: 30262 RVA: 0x001EE8E8 File Offset: 0x001ECAE8
	protected override UniTask OnBeforeStartAsync()
	{
		AdvanceNoticeMultiGridItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AdvanceNoticeMultiGridItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007637 RID: 30263 RVA: 0x001EE92C File Offset: 0x001ECB2C
	public int GetGridCount()
	{
		return ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingPageInfoById(this.AdvertisingPageInfoId).GetTabIdArrayArray().Length;
	}

	// Token: 0x06007638 RID: 30264 RVA: 0x001EE953 File Offset: 0x001ECB53
	public void PlayAnim()
	{
		UUIInturnAnimController animControllerComponent = this.AnimControllerComponent;
		if (animControllerComponent == null)
		{
			return;
		}
		animControllerComponent.Play("", -1, false);
	}

	// Token: 0x0400393C RID: 14652
	[Nullable(1)]
	private readonly List<AdvanceNoticeGridItem> GridItemList = new List<AdvanceNoticeGridItem>();

	// Token: 0x0400393D RID: 14653
	[Nullable(2)]
	protected UUIInturnAnimController AnimControllerComponent;

	// Token: 0x0400393E RID: 14654
	public readonly int AdvertisingPageInfoId;
}
