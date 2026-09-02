using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029DC RID: 10716
public class ShipTowerShowBuffView : UiTickViewBase
{
	// Token: 0x060155C3 RID: 87491 RVA: 0x005EB515 File Offset: 0x005E9715
	[NullableContext(1)]
	public ShipTowerShowBuffView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060155C4 RID: 87492 RVA: 0x005EB52C File Offset: 0x005E972C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtnRoot))
		};
	}

	// Token: 0x060155C5 RID: 87493 RVA: 0x005EB5BF File Offset: 0x005E97BF
	private void InitDataParam()
	{
		this.ShowBuffIdList = ModelBase<ShipTowerModel>.Instance.ShowBuffIdList;
	}

	// Token: 0x060155C6 RID: 87494 RVA: 0x005EB5D4 File Offset: 0x005E97D4
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerShowBuffView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerShowBuffView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060155C7 RID: 87495 RVA: 0x005EB617 File Offset: 0x005E9817
	protected override void OnBeforeShow()
	{
		this.UpdateData();
	}

	// Token: 0x060155C8 RID: 87496 RVA: 0x005EB620 File Offset: 0x005E9820
	private void UpdateData()
	{
		int num = 0;
		if (this.ShowBuffIdList.Count > 0)
		{
			num = this.ShowBuffIdList[0];
			this.ShowBuffIdList.RemoveAt(0);
		}
		ShipTowerBuffData buffDataByBuffId = ModelBase<ShipTowerModel>.Instance.GetBuffDataByBuffId(num);
		this.CurBuffId = new int?(num);
		if (buffDataByBuffId == null)
		{
			base.CloseMe(null);
			return;
		}
		this.TipCountDown = (float)ConfigBase<CalabashConfig>.Instance.MaxTipCd;
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.ShowTextNew(buffDataByBuffId.ItemNameKey);
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.ShowTextNew(buffDataByBuffId.ObtainedShowDescKey);
		}
		SmallItemGrid itemGrid = this.ItemGrid;
		if (itemGrid == null)
		{
			return;
		}
		itemGrid.Apply<PropSmallItemGrid>(new PropSmallItemGrid
		{
			ItemConfigId = new int?(buffDataByBuffId.ItemId),
			Data = null
		});
	}

	// Token: 0x060155C9 RID: 87497 RVA: 0x005EB6E7 File Offset: 0x005E98E7
	protected override void OnTick(float delta)
	{
		if (this.TipCountDown <= 0f)
		{
			return;
		}
		this.TipCountDown -= delta;
		if (this.TipCountDown <= 0f)
		{
			this.CloseViewOrShowNextData();
		}
	}

	// Token: 0x060155CA RID: 87498 RVA: 0x005EB718 File Offset: 0x005E9918
	protected void CloseViewOrShowNextData()
	{
		if (this.ShowBuffIdList.Count > 0)
		{
			this.ShowNextBuff().Forget();
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x060155CB RID: 87499 RVA: 0x005EB73C File Offset: 0x005E993C
	private UniTask ShowNextBuff()
	{
		ShipTowerShowBuffView.<ShowNextBuff>d__13 <ShowNextBuff>d__;
		<ShowNextBuff>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowNextBuff>d__.<>4__this = this;
		<ShowNextBuff>d__.<>1__state = -1;
		<ShowNextBuff>d__.<>t__builder.Start<ShipTowerShowBuffView.<ShowNextBuff>d__13>(ref <ShowNextBuff>d__);
		return <ShowNextBuff>d__.<>t__builder.Task;
	}

	// Token: 0x060155CC RID: 87500 RVA: 0x005EB77F File Offset: 0x005E997F
	private void OnClickBtnRoot()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OpenActivityViewShipTower);
	}

	// Token: 0x0400A47E RID: 42110
	[Nullable(2)]
	private SmallItemGrid ItemGrid;

	// Token: 0x0400A47F RID: 42111
	private float TipCountDown;

	// Token: 0x0400A480 RID: 42112
	[Nullable(1)]
	private List<int> ShowBuffIdList = new List<int>();

	// Token: 0x0400A481 RID: 42113
	public int? CurBuffId;

	// Token: 0x02008D48 RID: 36168
	private static class EChildType
	{
		// Token: 0x0402F82F RID: 194607
		public const int ItemGrid = 0;

		// Token: 0x0402F830 RID: 194608
		public const int TxtName = 1;

		// Token: 0x0402F831 RID: 194609
		public const int TxtDesc = 2;

		// Token: 0x0402F832 RID: 194610
		public const int BtnRoot = 3;
	}
}
