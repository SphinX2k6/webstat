using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011BF RID: 4543
[NullableContext(2)]
[Nullable(0)]
public class ArtemisQteRingBgSingleItem : UiPanelBase
{
	// Token: 0x060077A1 RID: 30625 RVA: 0x001F52A0 File Offset: 0x001F34A0
	public ArtemisQteRingBgSingleItem(int startIndex, int endIndex, bool isWholeRing)
	{
		this.StartIndex = startIndex;
		this.EndIndex = endIndex;
		this.IsWholeRing = isWholeRing;
	}

	// Token: 0x060077A2 RID: 30626 RVA: 0x001F52C0 File Offset: 0x001F34C0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x060077A3 RID: 30627 RVA: 0x001F5330 File Offset: 0x001F3530
	protected override UniTask OnBeforeStartAsync()
	{
		ArtemisQteRingBgSingleItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ArtemisQteRingBgSingleItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060077A4 RID: 30628 RVA: 0x001F5373 File Offset: 0x001F3573
	protected override void OnStart()
	{
		this.Init();
	}

	// Token: 0x060077A5 RID: 30629 RVA: 0x001F537C File Offset: 0x001F357C
	private void Init()
	{
		UUIItem item = base.GetItem(1);
		UUIItem item2 = base.GetItem(2);
		int num = Math.Max(this.StartIndex - 1, 0) * 10;
		FRotator frotator = Rotator.Create(0f, (float)(-(float)num), 0f).ToUeRotator();
		item.SetUIRelativeRotation(frotator);
		item2.SetUIRelativeRotation(frotator);
		float fillAmount = (float)ArtemisQteDefine.CalculateCellSize(this.StartIndex, this.EndIndex) / 36f;
		this.NormalItem.SetFillAmount(fillAmount);
		this.MissItem.SetFillAmount(fillAmount);
	}

	// Token: 0x060077A6 RID: 30630 RVA: 0x001F5404 File Offset: 0x001F3604
	public void SetType(EArtemisAreaType type)
	{
		switch (type)
		{
		case EArtemisAreaType.BlankArea:
			base.GetItem(1).SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
			base.GetItem(2).SetUIActive(false);
			base.GetItem(0).SetUIActive(true);
			break;
		case EArtemisAreaType.QteArea:
		case EArtemisAreaType.PerfectArea:
			break;
		default:
			return;
		}
	}

	// Token: 0x040039EB RID: 14827
	protected int StartIndex;

	// Token: 0x040039EC RID: 14828
	protected int EndIndex;

	// Token: 0x040039ED RID: 14829
	protected bool IsWholeRing;

	// Token: 0x040039EE RID: 14830
	private ArtemisQteRingSingleAreaItem NormalItem;

	// Token: 0x040039EF RID: 14831
	private ArtemisQteRingSingleAreaItem MissItem;

	// Token: 0x040039F0 RID: 14832
	private ArtemisQteRingSingleAreaItem PerfectItem;

	// Token: 0x02007515 RID: 29973
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040286C6 RID: 165574
		public const int PanelCircleTop = 0;

		// Token: 0x040286C7 RID: 165575
		public const int PanelAreaNormal = 1;

		// Token: 0x040286C8 RID: 165576
		public const int PanelAreaMiss = 2;

		// Token: 0x040286C9 RID: 165577
		public const int PanelAreaPerfect = 3;
	}
}
