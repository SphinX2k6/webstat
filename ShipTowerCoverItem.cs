using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029AD RID: 10669
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerCoverItem : UiPanelBase
{
	// Token: 0x0601545F RID: 87135 RVA: 0x005E5394 File Offset: 0x005E3594
	public UniTask Init(UUIItem item)
	{
		ShipTowerCoverItem.<Init>d__9 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ShipTowerCoverItem.<Init>d__9>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06015460 RID: 87136 RVA: 0x005E53E0 File Offset: 0x005E35E0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x06015461 RID: 87137 RVA: 0x005E5494 File Offset: 0x005E3694
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerCoverItem.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerCoverItem.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015462 RID: 87138 RVA: 0x005E54D8 File Offset: 0x005E36D8
	public void UpdateData(ShipTowerStageData data, bool isCover = false)
	{
		this.ItemData = data;
		this.IsCover = isCover;
		List<int> data2;
		List<int> data3;
		ShipTowerBuffData shipTowerBuffData;
		ShipTowerBuffData shipTowerBuffData2;
		if (this.IsCover)
		{
			data2 = data.TeamDataList[0].GetRoleIdListEdit();
			data3 = data.TeamDataList[1].GetRoleIdListEdit();
			shipTowerBuffData = data.TeamDataList[0].BuffDataEdit;
			shipTowerBuffData2 = data.TeamDataList[1].BuffDataEdit;
			this.BtnConfirm.SetShowText("ConfirmBox_132_ButtonText_1");
		}
		else
		{
			this.BtnConfirm.SetShowText("ConfirmBox_132_ButtonText_0");
			data2 = data.TeamDataList[0].GetRoleIdList();
			data3 = data.TeamDataList[1].GetRoleIdList();
			shipTowerBuffData = data.TeamDataList[0].BuffData;
			shipTowerBuffData2 = data.TeamDataList[1].BuffData;
		}
		this.LayoutRoleList1.RefreshByData(data2, null, false);
		this.LayoutRoleList2.RefreshByData(data3, null, false);
		this.BuffItem1.Apply<PropSmallItemGrid>(new PropSmallItemGrid
		{
			Data = shipTowerBuffData,
			ItemConfigId = new int?((shipTowerBuffData != null) ? shipTowerBuffData.ItemId : 1)
		});
		this.BuffItem2.Apply<PropSmallItemGrid>(new PropSmallItemGrid
		{
			Data = shipTowerBuffData2,
			ItemConfigId = new int?((shipTowerBuffData2 != null) ? shipTowerBuffData2.ItemId : 1)
		});
		int score = this.IsCover ? data.NewChallengeScore : data.CurrentScore;
		base.GetText(4).SetText(score.ToString(), true);
		UUITexture texture = base.GetTexture(5);
		string stageGradeResIdByStageId = ModelBase<ShipTowerModel>.Instance.GetStageGradeResIdByStageId(data.Id, score);
		texture.SetUIActive(stageGradeResIdByStageId != null);
		if (stageGradeResIdByStageId != null)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(stageGradeResIdByStageId);
			base.SetTextureByPath(resourcePath, texture, null, null);
		}
	}

	// Token: 0x06015463 RID: 87139 RVA: 0x005E56A1 File Offset: 0x005E38A1
	private void OnBtnConfirmClick()
	{
		Action<ShipTowerStageData, bool> confirmCallback = this.ConfirmCallback;
		if (confirmCallback == null)
		{
			return;
		}
		confirmCallback(this.ItemData, this.IsCover);
	}

	// Token: 0x06015464 RID: 87140 RVA: 0x005E56BF File Offset: 0x005E38BF
	private ShipTowerCoverRoleItem CreateRoleItem()
	{
		return new ShipTowerCoverRoleItem();
	}

	// Token: 0x06015465 RID: 87141 RVA: 0x005E56C6 File Offset: 0x005E38C6
	private void OnClickBuff(MediumItemGridExtendCallback param)
	{
	}

	// Token: 0x0400A407 RID: 41991
	private ShipTowerStageData ItemData;

	// Token: 0x0400A408 RID: 41992
	private bool IsCover;

	// Token: 0x0400A409 RID: 41993
	private ButtonItem BtnConfirm;

	// Token: 0x0400A40A RID: 41994
	private GenericLayout<ShipTowerCoverRoleItem, int> LayoutRoleList1;

	// Token: 0x0400A40B RID: 41995
	private GenericLayout<ShipTowerCoverRoleItem, int> LayoutRoleList2;

	// Token: 0x0400A40C RID: 41996
	private SmallItemGrid BuffItem1;

	// Token: 0x0400A40D RID: 41997
	private SmallItemGrid BuffItem2;

	// Token: 0x0400A40E RID: 41998
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ShipTowerStageData, bool> ConfirmCallback;

	// Token: 0x02008CFD RID: 36093
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F6CE RID: 194254
		public const int HLayoutRoleList1 = 0;

		// Token: 0x0402F6CF RID: 194255
		public const int HLayoutRoleList2 = 1;

		// Token: 0x0402F6D0 RID: 194256
		public const int ItemBuff1 = 2;

		// Token: 0x0402F6D1 RID: 194257
		public const int ItemBuff2 = 3;

		// Token: 0x0402F6D2 RID: 194258
		public const int TxtScore = 4;

		// Token: 0x0402F6D3 RID: 194259
		public const int TextureGrade = 5;

		// Token: 0x0402F6D4 RID: 194260
		public const int ItemConfirm = 6;
	}
}
