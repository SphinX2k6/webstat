using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200271D RID: 10013
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsDangoRankPanel : UiPanelBase
{
	// Token: 0x06013C08 RID: 80904 RVA: 0x0057F361 File Offset: 0x0057D561
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06013C09 RID: 80905 RVA: 0x0057F39C File Offset: 0x0057D59C
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsDangoRankPanel.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsDangoRankPanel.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013C0A RID: 80906 RVA: 0x0057F3E0 File Offset: 0x0057D5E0
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(0);
		object obj;
		if (item == null)
		{
			obj = null;
		}
		else
		{
			UUIItem attachUIChild = item.GetAttachUIChild(0);
			obj = ((attachUIChild != null) ? attachUIChild.GetOwner() : null);
		}
		this.TemplateGridActor = (obj as AUIBaseActor);
		if (this.TemplateGridActor == null)
		{
			return;
		}
		UUIItem uiitem = this.TemplateGridActor.GetUIItem();
		this.DangoRankItemHeight = ((uiitem != null) ? uiitem.GetHeight() : 0f);
		UUIItem uiitem2 = this.TemplateGridActor.GetUIItem();
		if (uiitem2 == null)
		{
			return;
		}
		uiitem2.SetUIActive(false);
	}

	// Token: 0x06013C0B RID: 80907 RVA: 0x0057F458 File Offset: 0x0057D658
	public UniTask InitAsync(List<RacingBetsDungeonDangoInfo> rankingList, bool needRank = true, bool layoutByListOrder = false)
	{
		RacingBetsDangoRankPanel.<InitAsync>d__12 <InitAsync>d__;
		<InitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitAsync>d__.<>4__this = this;
		<InitAsync>d__.rankingList = rankingList;
		<InitAsync>d__.needRank = needRank;
		<InitAsync>d__.layoutByListOrder = layoutByListOrder;
		<InitAsync>d__.<>1__state = -1;
		<InitAsync>d__.<>t__builder.Start<RacingBetsDangoRankPanel.<InitAsync>d__12>(ref <InitAsync>d__);
		return <InitAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013C0C RID: 80908 RVA: 0x0057F4B4 File Offset: 0x0057D6B4
	private UniTask CreateRacingBetsDangoRankItemAsync(int index, RacingBetsDungeonDangoInfo rankInfo)
	{
		RacingBetsDangoRankPanel.<CreateRacingBetsDangoRankItemAsync>d__13 <CreateRacingBetsDangoRankItemAsync>d__;
		<CreateRacingBetsDangoRankItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateRacingBetsDangoRankItemAsync>d__.<>4__this = this;
		<CreateRacingBetsDangoRankItemAsync>d__.rankInfo = rankInfo;
		<CreateRacingBetsDangoRankItemAsync>d__.<>1__state = -1;
		<CreateRacingBetsDangoRankItemAsync>d__.<>t__builder.Start<RacingBetsDangoRankPanel.<CreateRacingBetsDangoRankItemAsync>d__13>(ref <CreateRacingBetsDangoRankItemAsync>d__);
		return <CreateRacingBetsDangoRankItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013C0D RID: 80909 RVA: 0x0057F4FF File Offset: 0x0057D6FF
	[NullableContext(2)]
	private UUIItem CreateItemActor()
	{
		if (this.TemplateGridActor == null)
		{
			return null;
		}
		return Singleton<LguiUtil>.Instance.CopyItem(this.TemplateGridActor.GetUIItem(), base.GetRootItem());
	}

	// Token: 0x06013C0E RID: 80910 RVA: 0x0057F528 File Offset: 0x0057D728
	public UniTask RefreshRankItemAsync()
	{
		RacingBetsDangoRankPanel.<RefreshRankItemAsync>d__15 <RefreshRankItemAsync>d__;
		<RefreshRankItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRankItemAsync>d__.<>4__this = this;
		<RefreshRankItemAsync>d__.<>1__state = -1;
		<RefreshRankItemAsync>d__.<>t__builder.Start<RacingBetsDangoRankPanel.<RefreshRankItemAsync>d__15>(ref <RefreshRankItemAsync>d__);
		return <RefreshRankItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x040099D8 RID: 39384
	[Nullable(2)]
	private AUIBaseActor TemplateGridActor;

	// Token: 0x040099D9 RID: 39385
	private readonly Dictionary<RacingBetsDungeonDangoInfo, RacingBetsDangoRankItem> RankItemMap = new Dictionary<RacingBetsDungeonDangoInfo, RacingBetsDangoRankItem>();

	// Token: 0x040099DA RID: 39386
	public float DangoRankItemHeight;

	// Token: 0x040099DB RID: 39387
	public int DangoRankInterval = 20;

	// Token: 0x040099DC RID: 39388
	private List<RacingBetsDangoRankItem> RankItemList = new List<RacingBetsDangoRankItem>();

	// Token: 0x040099DD RID: 39389
	[Nullable(2)]
	private UCurveFloat LerpCurve;

	// Token: 0x040099DE RID: 39390
	private bool NeedRank = true;

	// Token: 0x040099DF RID: 39391
	private bool LayoutByListOrder;

	// Token: 0x02008ABF RID: 35519
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402EC82 RID: 191618
		Content,
		// Token: 0x0402EC83 RID: 191619
		Item
	}
}
