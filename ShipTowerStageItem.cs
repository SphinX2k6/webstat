using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029DD RID: 10717
public class ShipTowerStageItem : UiPanelBase
{
	// Token: 0x060155CE RID: 87502 RVA: 0x005EB79C File Offset: 0x005E999C
	[NullableContext(1)]
	public UniTask Init(UUIItem item, int data)
	{
		ShipTowerStageItem.<Init>d__2 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.data = data;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ShipTowerStageItem.<Init>d__2>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060155CF RID: 87503 RVA: 0x005EB7F0 File Offset: 0x005E99F0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUITexture))
		};
	}

	// Token: 0x060155D0 RID: 87504 RVA: 0x005EB8B8 File Offset: 0x005E9AB8
	protected override void OnBeforeShow()
	{
		this.UpdateData();
	}

	// Token: 0x060155D1 RID: 87505 RVA: 0x005EB8C0 File Offset: 0x005E9AC0
	public void UpdateData()
	{
		ShipTowerStageData stageDataById = ModelBase<ShipTowerModel>.Instance.GetStageDataById(this.ItemDataId);
		if (stageDataById == null)
		{
			return;
		}
		bool flag = stageDataById.IsUnLocked();
		bool uiactive = stageDataById.IsPassed();
		bool uiactive2 = stageDataById.IsCurrent();
		base.GetItem(1).SetUIActive(flag);
		base.GetItem(0).SetUIActive(!flag);
		base.GetItem(2).SetUIActive(uiactive);
		base.GetText(3).SetText(stageDataById.OrderIndex.ToString(), true);
		base.GetText(5).ShowTextNew(stageDataById.TitleKey);
		base.GetSprite(6).SetUIActive(uiactive2);
		string stageGradeResIdByScore = stageDataById.GetStageGradeResIdByScore(stageDataById.CurrentScore);
		bool flag2 = stageGradeResIdByScore != null;
		UUITexture texture = base.GetTexture(7);
		if (texture != null)
		{
			texture.SetUIActive(flag2);
		}
		if (flag2 && stageGradeResIdByScore != null)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(stageGradeResIdByScore);
			base.SetTextureByPath(resourcePath, texture, null, null);
		}
		bool flag3 = stageDataById.CurrentScore > 0;
		UUIText text = base.GetText(4);
		text.SetUIActive(flag3);
		if (flag3)
		{
			string textStringId = "GhostShipPoint_Text";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlySingleElementList<object>(stageDataById.CurrentScore.ToString()));
		}
	}

	// Token: 0x0400A482 RID: 42114
	protected int ItemDataId;

	// Token: 0x02008D4B RID: 36171
	private static class EChildType
	{
		// Token: 0x0402F83B RID: 194619
		public const int ItemLocked = 0;

		// Token: 0x0402F83C RID: 194620
		public const int ItemUnlocked = 1;

		// Token: 0x0402F83D RID: 194621
		public const int ItemPassed = 2;

		// Token: 0x0402F83E RID: 194622
		public const int TxtStageOrderId = 3;

		// Token: 0x0402F83F RID: 194623
		public const int TxtScore = 4;

		// Token: 0x0402F840 RID: 194624
		public const int TxtTitle = 5;

		// Token: 0x0402F841 RID: 194625
		public const int SpriteCurrent = 6;

		// Token: 0x0402F842 RID: 194626
		public const int TexScoreGrade = 7;
	}
}
