using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002784 RID: 10116
[NullableContext(1)]
[Nullable(0)]
public class RogueBattleTokenSelectResultView : UiViewBase
{
	// Token: 0x06013F36 RID: 81718 RVA: 0x0059004E File Offset: 0x0058E24E
	public RogueBattleTokenSelectResultView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013F37 RID: 81719 RVA: 0x00590060 File Offset: 0x0058E260
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnMask))
		};
	}

	// Token: 0x06013F38 RID: 81720 RVA: 0x005900E0 File Offset: 0x0058E2E0
	private void OnClickBtnMask()
	{
		MapRogueOp opData = ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam);
		if (opData == null)
		{
			return;
		}
		AddTokenView addTokenView = opData.Data.ShowViewOp.AddTokenView;
		if (addTokenView.Type == 1)
		{
			ModelBase<MapRogueModel>.Instance.ExecuteOpData((int)this.OpenParam, null);
			base.CloseMe(null);
			return;
		}
		this.Index++;
		if (this.Index >= addTokenView.RogueResGainDatas.Count)
		{
			ModelBase<MapRogueModel>.Instance.ExecuteOpData((int)this.OpenParam, null);
			base.CloseMe(null);
			return;
		}
		this.TokenLayout.RefreshByData(addTokenView.RogueResGainDatas.ToList<RogueResGainData>().GetRange(this.Index, this.PerShowCount), null, false);
	}

	// Token: 0x06013F39 RID: 81721 RVA: 0x005901A7 File Offset: 0x0058E3A7
	private RogueBattleTokenItem CreateItem()
	{
		return new RogueBattleTokenItem();
	}

	// Token: 0x06013F3A RID: 81722 RVA: 0x005901B0 File Offset: 0x0058E3B0
	protected override UniTask OnBeforeStartAsync()
	{
		RogueBattleTokenSelectResultView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleTokenSelectResultView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04009B71 RID: 39793
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RogueBattleTokenItem, RogueResGainData> TokenLayout;

	// Token: 0x04009B72 RID: 39794
	[Nullable(2)]
	private RogueBattleTopPanel TopPanel;

	// Token: 0x04009B73 RID: 39795
	private int Index;

	// Token: 0x04009B74 RID: 39796
	private int PerShowCount = 1;
}
