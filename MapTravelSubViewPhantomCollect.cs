using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200138F RID: 5007
[NullableContext(1)]
[Nullable(0)]
public class MapTravelSubViewPhantomCollect : UiPanelBase, IMapTravelSubViewInterface
{
	// Token: 0x17000BC0 RID: 3008
	// (get) Token: 0x060089AB RID: 35243 RVA: 0x002434F7 File Offset: 0x002416F7
	// (set) Token: 0x060089AC RID: 35244 RVA: 0x002434FF File Offset: 0x002416FF
	public bool NeedDestroySelf { get; set; }

	// Token: 0x060089AD RID: 35245 RVA: 0x00243508 File Offset: 0x00241708
	public MapTravelSubViewPhantomCollect(ActivityMapTravelData activityBaseData)
	{
		this.ActivityBaseData = activityBaseData;
	}

	// Token: 0x060089AE RID: 35246 RVA: 0x00243518 File Offset: 0x00241718
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060089AF RID: 35247 RVA: 0x002435C4 File Offset: 0x002417C4
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.AreaLayoutList = new LoopScrollView<PhantomCardItem, int>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<PhantomCardItem>(this.OnCreateItem), false);
	}

	// Token: 0x060089B0 RID: 35248 RVA: 0x00243612 File Offset: 0x00241812
	private PhantomCardItem OnCreateItem()
	{
		return new PhantomCardItem(this.ActivityBaseData);
	}

	// Token: 0x060089B1 RID: 35249 RVA: 0x00243620 File Offset: 0x00241820
	protected UniTask Refresh()
	{
		MapTravelSubViewPhantomCollect.<Refresh>d__12 <Refresh>d__;
		<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Refresh>d__.<>4__this = this;
		<Refresh>d__.<>1__state = -1;
		<Refresh>d__.<>t__builder.Start<MapTravelSubViewPhantomCollect.<Refresh>d__12>(ref <Refresh>d__);
		return <Refresh>d__.<>t__builder.Task;
	}

	// Token: 0x060089B2 RID: 35250 RVA: 0x00243664 File Offset: 0x00241864
	public UniTask PlayStartSequence()
	{
		MapTravelSubViewPhantomCollect.<PlayStartSequence>d__13 <PlayStartSequence>d__;
		<PlayStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayStartSequence>d__.<>4__this = this;
		<PlayStartSequence>d__.<>1__state = -1;
		<PlayStartSequence>d__.<>t__builder.Start<MapTravelSubViewPhantomCollect.<PlayStartSequence>d__13>(ref <PlayStartSequence>d__);
		return <PlayStartSequence>d__.<>t__builder.Task;
	}

	// Token: 0x060089B3 RID: 35251 RVA: 0x002436A8 File Offset: 0x002418A8
	public UniTask PlayCloseSequence()
	{
		MapTravelSubViewPhantomCollect.<PlayCloseSequence>d__14 <PlayCloseSequence>d__;
		<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseSequence>d__.<>4__this = this;
		<PlayCloseSequence>d__.<>1__state = -1;
		<PlayCloseSequence>d__.<>t__builder.Start<MapTravelSubViewPhantomCollect.<PlayCloseSequence>d__14>(ref <PlayCloseSequence>d__);
		return <PlayCloseSequence>d__.<>t__builder.Task;
	}

	// Token: 0x060089B4 RID: 35252 RVA: 0x002436EC File Offset: 0x002418EC
	private int SortItem(int a, int b)
	{
		PhantomGain value = ConfigBase<ActivityMapTravelConfig>.Instance.GetPhantomConfig(a).Value;
		PhantomGain value2 = ConfigBase<ActivityMapTravelConfig>.Instance.GetPhantomConfig(b).Value;
		if (value.Sort == value2.Sort)
		{
			return a - b;
		}
		return value.Sort - value2.Sort;
	}

	// Token: 0x0400407F RID: 16511
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04004080 RID: 16512
	private LoopScrollView<PhantomCardItem, int> AreaLayoutList;

	// Token: 0x04004081 RID: 16513
	protected ActivityMapTravelData ActivityBaseData;

	// Token: 0x0200772C RID: 30508
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04029093 RID: 168083
		public const int LoopScrollView = 0;

		// Token: 0x04029094 RID: 168084
		public const int CardItem = 1;

		// Token: 0x04029095 RID: 168085
		public const int TxtTips = 2;

		// Token: 0x04029096 RID: 168086
		public const int TxtCount = 3;
	}
}
