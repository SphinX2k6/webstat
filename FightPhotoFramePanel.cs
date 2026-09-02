using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020025C4 RID: 9668
public class FightPhotoFramePanel : FightPhotoTabPanelBase
{
	// Token: 0x06012E5D RID: 77405 RVA: 0x0053A3E0 File Offset: 0x005385E0
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

	// Token: 0x06012E5E RID: 77406 RVA: 0x0053A450 File Offset: 0x00538650
	protected override UniTask OnBeforeStartAsync()
	{
		FightPhotoFramePanel.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FightPhotoFramePanel.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012E5F RID: 77407 RVA: 0x0053A494 File Offset: 0x00538694
	private void RefreshArrows(FVector2D? progress)
	{
		GenericScrollViewNew<FightPhotoFrameItem, FightPhotoFrameStyle> frameLayout = this.FrameLayout;
		if (frameLayout == null || !frameLayout.IsExpand)
		{
			base.GetSprite(2).SetUIActive(false);
			base.GetSprite(3).SetUIActive(false);
			return;
		}
		float num = (progress != null) ? progress.GetValueOrDefault().Y : 0f;
		base.GetSprite(2).SetUIActive(num > 0f);
		base.GetSprite(3).SetUIActive(num < 1f);
	}

	// Token: 0x06012E60 RID: 77408 RVA: 0x0053A515 File Offset: 0x00538715
	[NullableContext(1)]
	private FightPhotoFrameItem CreateFrameItem()
	{
		return new FightPhotoFrameItem
		{
			OnToggleClick = new Action<FightPhotoFrameStyle>(this.OnToggleClick)
		};
	}

	// Token: 0x06012E61 RID: 77409 RVA: 0x0053A52E File Offset: 0x0053872E
	private void OnToggleClick(FightPhotoFrameStyle data)
	{
		this.FrameLayout.GetGenericLayout().SelectGridProxyByKey(data.Id, false);
		PhotographController.SetFightPhotographExtraOption(EFightPhotoExtraOptionType.Frame, data.Id, false);
		Action onFrameSwitched = this.OnFrameSwitched;
		if (onFrameSwitched == null)
		{
			return;
		}
		onFrameSwitched();
	}

	// Token: 0x06012E62 RID: 77410 RVA: 0x0053A56C File Offset: 0x0053876C
	[NullableContext(1)]
	private void ScrollToSelectedItem(object key)
	{
		GenericScrollViewNew<FightPhotoFrameItem, FightPhotoFrameStyle> frameLayout = this.FrameLayout;
		UUIItem uuiitem = (frameLayout != null) ? frameLayout.GetItemByKey(key) : null;
		if (uuiitem == null)
		{
			return;
		}
		this.FrameLayout.LateScrollTo(uuiitem, null, false);
	}

	// Token: 0x040093A7 RID: 37799
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<FightPhotoFrameItem, FightPhotoFrameStyle> FrameLayout;

	// Token: 0x040093A8 RID: 37800
	[Nullable(2)]
	public Action OnFrameSwitched;

	// Token: 0x02008926 RID: 35110
	private enum EComponents
	{
		// Token: 0x0402E46E RID: 189550
		SvFrame,
		// Token: 0x0402E46F RID: 189551
		TogBattlePhotoFilter,
		// Token: 0x0402E470 RID: 189552
		SpriteArrowUp,
		// Token: 0x0402E471 RID: 189553
		SpriteArrowDown
	}
}
