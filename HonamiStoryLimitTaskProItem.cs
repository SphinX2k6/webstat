using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F35 RID: 7989
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryLimitTaskProItem : UiPanelBase
{
	// Token: 0x0600EED9 RID: 61145 RVA: 0x00414A98 File Offset: 0x00412C98
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EEDA RID: 61146 RVA: 0x00414B43 File Offset: 0x00412D43
	protected override void OnStart()
	{
		this.ProgressLayout = new GenericLayout<HonamiStoryLimitTaskScoreItem, HonamiStoryScoreRewardData>(base.GetHorizontalLayout(2), new Func<HonamiStoryLimitTaskScoreItem>(this.InitScoreItem), (AUIBaseActor)base.GetItem(3).GetOwner(), false, true);
	}

	// Token: 0x0600EEDB RID: 61147 RVA: 0x00414B76 File Offset: 0x00412D76
	private HonamiStoryLimitTaskScoreItem InitScoreItem()
	{
		return new HonamiStoryLimitTaskScoreItem
		{
			OnClickToGet = this.OnClickToGet
		};
	}

	// Token: 0x0600EEDC RID: 61148 RVA: 0x00414B8C File Offset: 0x00412D8C
	public UniTask RefreshAsync(int currentProgress, List<HonamiStoryScoreRewardData> dataList)
	{
		HonamiStoryLimitTaskProItem.<RefreshAsync>d__7 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.currentProgress = currentProgress;
		<RefreshAsync>d__.dataList = dataList;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<HonamiStoryLimitTaskProItem.<RefreshAsync>d__7>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x040072E4 RID: 29412
	private const float FIRST_OFFSET = 410f;

	// Token: 0x040072E5 RID: 29413
	private GenericLayout<HonamiStoryLimitTaskScoreItem, HonamiStoryScoreRewardData> ProgressLayout;

	// Token: 0x040072E6 RID: 29414
	[Nullable(2)]
	public Action OnClickToGet;

	// Token: 0x020082A4 RID: 33444
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C4E7 RID: 181479
		TxtScore,
		// Token: 0x0402C4E8 RID: 181480
		SprBarFill,
		// Token: 0x0402C4E9 RID: 181481
		PnlPointRewardLayout,
		// Token: 0x0402C4EA RID: 181482
		PnlPointReward
	}
}
