using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012FF RID: 4863
[NullableContext(1)]
[Nullable(0)]
public class DangoMonopolyRoundBuffShowView : DangoMonopolyViewBase
{
	// Token: 0x17000B1A RID: 2842
	// (get) Token: 0x06008438 RID: 33848 RVA: 0x0022EBE0 File Offset: 0x0022CDE0
	[Nullable(2)]
	public new DangoMonopolyRoundBuffShowViewParam OpenParam
	{
		[NullableContext(2)]
		get
		{
			return this.OpenParam as DangoMonopolyRoundBuffShowViewParam;
		}
	}

	// Token: 0x06008439 RID: 33849 RVA: 0x0022EBED File Offset: 0x0022CDED
	public DangoMonopolyRoundBuffShowView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600843A RID: 33850 RVA: 0x0022EBF8 File Offset: 0x0022CDF8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickClose))
		};
	}

	// Token: 0x0600843B RID: 33851 RVA: 0x0022ECB9 File Offset: 0x0022CEB9
	private void InitDataParam()
	{
	}

	// Token: 0x0600843C RID: 33852 RVA: 0x0022ECBC File Offset: 0x0022CEBC
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyRoundBuffShowView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyRoundBuffShowView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600843D RID: 33853 RVA: 0x0022ECFF File Offset: 0x0022CEFF
	protected override void OnBeforeShow()
	{
		GenericLayout<DangoMonopolyRoundBuffShowItem, IDangoMonopolyRoundBuffData> buffLayout = this.BuffLayout;
		if (buffLayout == null)
		{
			return;
		}
		buffLayout.RefreshByData(this.GetBuffList(), null, true);
	}

	// Token: 0x0600843E RID: 33854 RVA: 0x0022ED1C File Offset: 0x0022CF1C
	private List<IDangoMonopolyRoundBuffData> GetBuffList()
	{
		DangoMonopolyRoundBuffShowViewParam openParam = this.OpenParam;
		int key = (openParam != null) ? openParam.BoardId : 0;
		DangoMonopolyBoardData currentBoardData;
		if (!this.ActivityData.BoardMap.TryGetValue(key, out currentBoardData))
		{
			currentBoardData = this.ActivityData.CurrentBoardData;
		}
		return ((currentBoardData != null) ? currentBoardData.GetDangoBuffShowList() : null) ?? new List<IDangoMonopolyRoundBuffData>();
	}

	// Token: 0x0600843F RID: 33855 RVA: 0x0022ED72 File Offset: 0x0022CF72
	protected override void OnBeforeDestroy()
	{
		DangoMonopolyRoundBuffShowViewParam openParam = this.OpenParam;
		if (openParam == null)
		{
			return;
		}
		CustomPromise promise = openParam.Promise;
		if (promise == null)
		{
			return;
		}
		promise.SetResult();
	}

	// Token: 0x06008440 RID: 33856 RVA: 0x0022ED8E File Offset: 0x0022CF8E
	private void OnClickClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x06008441 RID: 33857 RVA: 0x0022ED97 File Offset: 0x0022CF97
	private DangoMonopolyRoundBuffShowItem CreateBuffItem()
	{
		return new DangoMonopolyRoundBuffShowItem();
	}

	// Token: 0x04003EC3 RID: 16067
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<DangoMonopolyRoundBuffShowItem, IDangoMonopolyRoundBuffData> BuffLayout;

	// Token: 0x020076A8 RID: 30376
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028E15 RID: 167445
		BtnClose,
		// Token: 0x04028E16 RID: 167446
		TxtTitle,
		// Token: 0x04028E17 RID: 167447
		BtnEmpty,
		// Token: 0x04028E18 RID: 167448
		VLayoutProperty,
		// Token: 0x04028E19 RID: 167449
		ItemProperty
	}
}
