using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001625 RID: 5669
[NullableContext(1)]
[Nullable(0)]
internal class VersionPreheatActivityItem : UiPanelBase
{
	// Token: 0x06009FD6 RID: 40918 RVA: 0x0029C12C File Offset: 0x0029A32C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009FD7 RID: 40919 RVA: 0x0029C1D8 File Offset: 0x0029A3D8
	protected override UniTask OnBeforeStartAsync()
	{
		VersionPreheatActivityItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VersionPreheatActivityItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009FD8 RID: 40920 RVA: 0x0029C21B File Offset: 0x0029A41B
	protected override void OnStart()
	{
		this.Reward.SetUiActive(false);
		this.Bottom.SetUiActive(false);
	}

	// Token: 0x06009FD9 RID: 40921 RVA: 0x0029C235 File Offset: 0x0029A435
	public void RefreshExternal(VersionPreheatActivityInfoData data)
	{
		this.RefreshTitle(data.TitleData);
		this.RefreshDescription(data.DescriptionData);
	}

	// Token: 0x06009FDA RID: 40922 RVA: 0x0029C24F File Offset: 0x0029A44F
	public void RefreshSubTitleExternal(bool isShow, string text)
	{
		this.Title.SetTimeTextVisible(isShow);
		if (isShow)
		{
			this.Title.SetTimeTextByText(text);
		}
	}

	// Token: 0x06009FDB RID: 40923 RVA: 0x0029C26C File Offset: 0x0029A46C
	private void RefreshTitle(VersionPreheatActivityTitleData data)
	{
		this.Title.SetTitleByTextId(data.TitleTextId, Array.Empty<string>());
		this.Title.SetSubTitleByTextId(data.SubTitleTextId, Array.Empty<string>());
		this.Title.SetSubTitleVisible(true);
		this.Title.SetTimeTextVisible(false);
	}

	// Token: 0x06009FDC RID: 40924 RVA: 0x0029C2BD File Offset: 0x0029A4BD
	private void RefreshDescription(VersionPreheatActivityDescriptionData data)
	{
		this.Description.SetContentByTextId(data.ContentTextId, Array.Empty<string>());
	}

	// Token: 0x0400496D RID: 18797
	private ActivityTitleTypeA Title;

	// Token: 0x0400496E RID: 18798
	private ActivityDescriptionTypeA Description;

	// Token: 0x0400496F RID: 18799
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> Reward;

	// Token: 0x04004970 RID: 18800
	private VersionPreheatActivityBottom Bottom;

	// Token: 0x020079DF RID: 31199
	[NullableContext(0)]
	internal class EActivityComponent
	{
		// Token: 0x04029D63 RID: 171363
		public const int TitleItem = 0;

		// Token: 0x04029D64 RID: 171364
		public const int DescriptionItem = 1;

		// Token: 0x04029D65 RID: 171365
		public const int RewardItem = 2;

		// Token: 0x04029D66 RID: 171366
		public const int BottomItem = 3;
	}
}
