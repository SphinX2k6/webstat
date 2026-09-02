using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Phantom.Vision.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024F2 RID: 9458
[NullableContext(2)]
[Nullable(0)]
public class VisionDetailComponent : UiPanelBase
{
	// Token: 0x060125ED RID: 75245 RVA: 0x0050D294 File Offset: 0x0050B494
	[NullableContext(1)]
	public VisionDetailComponent(UUIItem actor)
	{
		this.SourceItem = actor;
	}

	// Token: 0x060125EE RID: 75246 RVA: 0x0050D2A4 File Offset: 0x0050B4A4
	public UniTask Init()
	{
		VisionDetailComponent.<Init>d__7 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<VisionDetailComponent.<Init>d__7>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060125EF RID: 75247 RVA: 0x0050D2E7 File Offset: 0x0050B4E7
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x060125F0 RID: 75248 RVA: 0x0050D320 File Offset: 0x0050B520
	protected override UniTask OnBeforeStartAsync()
	{
		VisionDetailComponent.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionDetailComponent.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060125F1 RID: 75249 RVA: 0x0050D363 File Offset: 0x0050B563
	protected override void OnStart()
	{
		this.UnderComponent = new VisionDetailUnderComponent(base.GetItem(0));
		this.VisionDetailInfoComponent.SetClickCallBack(new Action(this.OnClickMainItem));
	}

	// Token: 0x060125F2 RID: 75250 RVA: 0x0050D38E File Offset: 0x0050B58E
	public UUIItem GetTxtItemByIndex(int index)
	{
		VisionDetailInfoComponent visionDetailInfoComponent = this.VisionDetailInfoComponent;
		if (visionDetailInfoComponent == null)
		{
			return null;
		}
		return visionDetailInfoComponent.GetTxtItemByIndex(index);
	}

	// Token: 0x060125F3 RID: 75251 RVA: 0x0050D3A2 File Offset: 0x0050B5A2
	protected void OnClickMainItem()
	{
	}

	// Token: 0x060125F4 RID: 75252 RVA: 0x0050D3A4 File Offset: 0x0050B5A4
	[NullableContext(1)]
	public void SetUnderLeftButtonText(string textId)
	{
		this.UnderComponent.RefreshLeftButtonText(textId);
	}

	// Token: 0x060125F5 RID: 75253 RVA: 0x0050D3B2 File Offset: 0x0050B5B2
	[NullableContext(1)]
	public void Update(PhantomBattleData data, int roleId, int cost, bool ifCompare = false)
	{
		this.CurrentPhantomData = data;
		this.RoleId = roleId;
		this.Cost = cost;
		this.CurrentCompareState = ifCompare;
		this.RefreshDetailView();
		this.UnderComponent.Update(data);
	}

	// Token: 0x060125F6 RID: 75254 RVA: 0x0050D3E4 File Offset: 0x0050B5E4
	private void RefreshDetailView()
	{
		int key = (this.CurrentCompareState > false) ? 1 : 0;
		bool ifSimpleState = ModelBase<PhantomBattleModel>.Instance.GetIfSimpleState(key);
		VisionDetailInfoComponentData visionDetailInfoComponentData = new VisionDetailInfoComponentData();
		visionDetailInfoComponentData.DataBase = this.CurrentPhantomData;
		visionDetailInfoComponentData.RoleId = this.RoleId;
		visionDetailInfoComponentData.Cost = this.Cost;
		int num = -1;
		if (!this.CurrentCompareState)
		{
			num = ModelBase<PhantomBattleModel>.Instance.CurrentEquipmentSelectIndex;
		}
		List<VisionFetterData> previewShowFetterList = this.CurrentPhantomData.GetPreviewShowFetterList(num, this.RoleId);
		bool flag = this.CurrentPhantomData.IfEquipSameNameMonsterOnRole(num, this.RoleId);
		bool flag2 = this.CurrentPhantomData.IfEquipOverNeedOnRole(previewShowFetterList);
		bool ifPreview = false;
		PhantomDataBase dataByIndex = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId).GetPhantomData().GetDataByIndex(0);
		if (dataByIndex == null || dataByIndex.GetIncrId() != this.CurrentPhantomData.GetUniqueId())
		{
			ifPreview = true;
		}
		foreach (VisionDetailDesc data in VisionDetailDesc.ConvertVisionSkillDescToDescData(this.CurrentPhantomData.GetNormalSkillConfig().Value, this.CurrentPhantomData.GetPhantomLevel(), num == 0 || num == -1, ifPreview, this.CurrentPhantomData.GetQuality()))
		{
			visionDetailInfoComponentData.AddDescData(data);
		}
		foreach (VisionDetailDesc data2 in VisionDetailDesc.ConvertVisionFetterDataToDetailDescData(previewShowFetterList, flag, new bool?(flag2), delegate
		{
			ControllerBase<PhantomBattleController>.Instance.OpenPhantomBattleFetterView(this.CurrentPhantomData.GetFetterGroupId(), this.RoleId, true, null);
		}))
		{
			visionDetailInfoComponentData.AddDescData(data2);
		}
		if (this.CurrentCompareState && visionDetailInfoComponentData.DescData != null)
		{
			foreach (VisionDetailDesc visionDetailDesc in visionDetailInfoComponentData.DescData)
			{
				visionDetailDesc.AnimationState = false;
				visionDetailDesc.CompareState = this.CurrentCompareState;
			}
		}
		if (flag)
		{
			foreach (VisionDetailDesc data3 in VisionDetailDesc.CreateSameMonsterTips())
			{
				visionDetailInfoComponentData.AddDescData(data3);
			}
		}
		if (flag2)
		{
			foreach (VisionDetailDesc data4 in VisionDetailDesc.CreateOverNeedTips())
			{
				visionDetailInfoComponentData.AddDescData(data4);
			}
		}
		this.VisionDetailInfoComponent.Refresh(visionDetailInfoComponentData, this.CurrentCompareState, ifSimpleState);
		this.VisionDetailInfoComponent.SetActive(true);
	}

	// Token: 0x060125F7 RID: 75255 RVA: 0x0050D6A0 File Offset: 0x0050B8A0
	public void SetButtonPanelShowState(bool state)
	{
		this.UnderComponent.SetActive(state);
	}

	// Token: 0x060125F8 RID: 75256 RVA: 0x0050D6AE File Offset: 0x0050B8AE
	public void RefreshViewByCompareState(bool state)
	{
		this.UnderComponent.RefreshViewByCompareState(state);
	}

	// Token: 0x060125F9 RID: 75257 RVA: 0x0050D6BC File Offset: 0x0050B8BC
	public VisionDetailUnderComponent GetDetailUnderComponent()
	{
		return this.UnderComponent;
	}

	// Token: 0x04008F40 RID: 36672
	private bool CurrentCompareState;

	// Token: 0x04008F41 RID: 36673
	private int RoleId;

	// Token: 0x04008F42 RID: 36674
	private int Cost;

	// Token: 0x04008F43 RID: 36675
	private PhantomBattleData CurrentPhantomData;

	// Token: 0x04008F44 RID: 36676
	private readonly UUIItem SourceItem;

	// Token: 0x04008F45 RID: 36677
	private VisionDetailUnderComponent UnderComponent;

	// Token: 0x04008F46 RID: 36678
	private VisionDetailInfoComponent VisionDetailInfoComponent;

	// Token: 0x02008808 RID: 34824
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DF47 RID: 188231
		UnderPanel,
		// Token: 0x0402DF48 RID: 188232
		InfoPanel
	}
}
