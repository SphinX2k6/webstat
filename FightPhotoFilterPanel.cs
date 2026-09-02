using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020025C2 RID: 9666
public class FightPhotoFilterPanel : FightPhotoTabPanelBase
{
	// Token: 0x06012E4F RID: 77391 RVA: 0x0053A0E4 File Offset: 0x005382E4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUISprite))
		};
	}

	// Token: 0x06012E50 RID: 77392 RVA: 0x0053A154 File Offset: 0x00538354
	protected override UniTask OnBeforeStartAsync()
	{
		FightPhotoFilterPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FightPhotoFilterPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012E51 RID: 77393 RVA: 0x0053A197 File Offset: 0x00538397
	[NullableContext(1)]
	private FightPhotoOptionItem CreateFilterItem()
	{
		return new FightPhotoOptionItem
		{
			OnToggleClick = new Action<FightPhotoOption>(this.OnToggleClick)
		};
	}

	// Token: 0x06012E52 RID: 77394 RVA: 0x0053A1B0 File Offset: 0x005383B0
	private void OnToggleClick(FightPhotoOption data)
	{
		this.FilterLayout.GetGenericLayout().SelectGridProxyByKey(data.Id, false);
		PhotographController.SetFightPhotographExtraOption(EFightPhotoExtraOptionType.Filter, data.Id, false);
	}

	// Token: 0x06012E53 RID: 77395 RVA: 0x0053A1E0 File Offset: 0x005383E0
	[NullableContext(1)]
	private void ScrollToSelectedItem(object key)
	{
		GenericScrollViewNew<FightPhotoOptionItem, FightPhotoOption> filterLayout = this.FilterLayout;
		UUIItem uuiitem = (filterLayout != null) ? filterLayout.GetItemByKey(key) : null;
		if (uuiitem == null)
		{
			return;
		}
		this.FilterLayout.LateScrollTo(uuiitem, null, false);
	}

	// Token: 0x040093A4 RID: 37796
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<FightPhotoOptionItem, FightPhotoOption> FilterLayout;

	// Token: 0x02008922 RID: 35106
	private enum EComponents
	{
		// Token: 0x0402E45D RID: 189533
		SvFilter,
		// Token: 0x0402E45E RID: 189534
		TogBattlePhotoFilter,
		// Token: 0x0402E45F RID: 189535
		SpriteArrowUp,
		// Token: 0x0402E460 RID: 189536
		SpriteArrowDown
	}
}
