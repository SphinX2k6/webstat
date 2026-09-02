using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029CA RID: 10698
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerRecordView : UiViewBase
{
	// Token: 0x06015540 RID: 87360 RVA: 0x005E902F File Offset: 0x005E722F
	public ShipTowerRecordView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015541 RID: 87361 RVA: 0x005E9038 File Offset: 0x005E7238
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06015542 RID: 87362 RVA: 0x005E91EF File Offset: 0x005E73EF
	private void InitDataParam()
	{
		this.AreaList = ModelBase<ShipTowerModel>.Instance.RecordList;
		this.StageData = ModelBase<ShipTowerModel>.Instance.GetEndlessStageData();
	}

	// Token: 0x06015543 RID: 87363 RVA: 0x005E9214 File Offset: 0x005E7414
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerRecordView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerRecordView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015544 RID: 87364 RVA: 0x005E9258 File Offset: 0x005E7458
	protected override void OnStart()
	{
		ShipTowerStageData stageData = this.StageData;
		string key = ((stageData != null) ? stageData.TitleKey : null) ?? "";
		base.GetText(5).ShowTextNew(key);
	}

	// Token: 0x06015545 RID: 87365 RVA: 0x005E928E File Offset: 0x005E748E
	private ShipTowerAreaItem CreateAreaItem()
	{
		return new ShipTowerAreaItem
		{
			ClickCallBack = new Action<ShipTowerAreaItemData>(this.OnAreaItemClick)
		};
	}

	// Token: 0x06015546 RID: 87366 RVA: 0x005E92A8 File Offset: 0x005E74A8
	private void OnAreaItemClick(ShipTowerAreaItemData data)
	{
		this.SelectData = data;
		List<ShipTowerRecordItemData> recordList = data.RecordList;
		bool flag;
		if (recordList == null)
		{
			flag = false;
		}
		else
		{
			flag = recordList.Any((ShipTowerRecordItemData value) => value.TeamList.Count > 0);
		}
		List<ShipTowerRecordItemData> recordList2 = data.RecordList;
		bool flag2;
		if (recordList2 == null)
		{
			flag2 = false;
		}
		else
		{
			flag2 = recordList2.Any((ShipTowerRecordItemData value) => value.BuffId > 0);
		}
		bool flag3 = flag2;
		bool flag4 = flag && flag3;
		this.SetEmptyState(!flag4);
		if (flag4 && data.RecordList != null)
		{
			GenericLayout<ShipTowerRecordItem, ShipTowerRecordItemData> layoutInfo = this.LayoutInfo;
			if (layoutInfo != null)
			{
				layoutInfo.RefreshByData(data.RecordList, null, true);
			}
		}
		List<ShipTowerRecordItemData> recordList3 = data.RecordList;
		int num;
		if (recordList3 == null)
		{
			num = 0;
		}
		else
		{
			num = recordList3.Sum((ShipTowerRecordItemData value) => value.Score);
		}
		int score = num;
		List<ShipTowerRecordItemData> recordList4 = data.RecordList;
		int num2;
		if (recordList4 == null)
		{
			num2 = 0;
		}
		else
		{
			num2 = recordList4.Sum((ShipTowerRecordItemData value) => value.Wave);
		}
		int num3 = num2;
		base.GetText(6).SetText(score.ToString(), true);
		base.GetText(7).SetText(num3.ToString(), true);
		UUITexture texture = base.GetTexture(8);
		ShipTowerStageData stageData = this.StageData;
		string text = (stageData != null) ? stageData.GetStageGradeResIdByScore(score) : null;
		bool flag5 = text != null;
		if (texture != null)
		{
			texture.SetUIActive(flag5);
		}
		if (flag5 && text != null)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text);
			base.SetTextureByPath(resourcePath, texture, null, null);
		}
		base.PlaySequence("Switch", null, false);
		this.RefreshShareBtn();
	}

	// Token: 0x06015547 RID: 87367 RVA: 0x005E944C File Offset: 0x005E764C
	private void SetEmptyState(bool isShow)
	{
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(!isShow);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(isShow);
	}

	// Token: 0x06015548 RID: 87368 RVA: 0x005E9476 File Offset: 0x005E7676
	private int GetSelectAreaIndex()
	{
		return 0;
	}

	// Token: 0x06015549 RID: 87369 RVA: 0x005E947C File Offset: 0x005E767C
	private void OnShareBtnClicked()
	{
		ShipTowerAreaItemData selectData = this.SelectData;
		if (selectData == null || selectData.RecordList == null || selectData.RecordList.Count <= 0)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		foreach (ShipTowerRecordItemData shipTowerRecordItemData in selectData.RecordList)
		{
			num += shipTowerRecordItemData.Score;
			num2 += shipTowerRecordItemData.Wave;
		}
		ShipTowerStageData stageData = this.StageData;
		string gradeResId = (stageData != null) ? stageData.GetShareStageGradeResIdByScore(num) : null;
		ShipTowerRecordShareData shipTowerRecordShareData = new ShipTowerRecordShareData
		{
			AreaTitle = selectData.Name,
			TotalScore = num,
			TotalWave = num2,
			GradeResId = gradeResId,
			RecordList = selectData.RecordList,
			DateText = selectData.TimeContent
		};
		PhotoSaveViewParam param = new PhotoSaveViewParam
		{
			ScreenShot = false,
			PrepareFullScreenShot = false,
			IsHiddenBattleView = false,
			HandBookPhotoData = null,
			GachaData = null,
			FragmentMemory = null,
			RoleSkinData = null,
			ShareId = 13,
			ShipTowerRecordShareData = shipTowerRecordShareData
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhotoSaveView, param, null);
	}

	// Token: 0x0601554A RID: 87370 RVA: 0x005E95B4 File Offset: 0x005E77B4
	private void RefreshShareBtn()
	{
		ShipTowerStageData stageData = this.StageData;
		bool flag = stageData != null && stageData.IsEndLess && this.AreaList.Count > 0;
		ShareBtnItem shareBtnItem = this.ShareBtnItem;
		if (shareBtnItem != null)
		{
			shareBtnItem.SetUiActive(flag);
		}
		if (flag)
		{
			ShareBtnItem shareBtnItem2 = this.ShareBtnItem;
			if (shareBtnItem2 == null)
			{
				return;
			}
			shareBtnItem2.SetShareActionId(EShareActionId.ChallengeRecord);
		}
	}

	// Token: 0x0601554B RID: 87371 RVA: 0x005E960E File Offset: 0x005E780E
	private ShipTowerRecordItem CreateRecordItem()
	{
		return new ShipTowerRecordItem();
	}

	// Token: 0x0400A454 RID: 42068
	[Nullable(2)]
	private PopupCaptionItem PopupCaption;

	// Token: 0x0400A455 RID: 42069
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<ShipTowerAreaItem, ShipTowerAreaItemData> AreaLoopView;

	// Token: 0x0400A456 RID: 42070
	private List<ShipTowerAreaItemData> AreaList;

	// Token: 0x0400A457 RID: 42071
	[Nullable(2)]
	private ShipTowerAreaItemData SelectData;

	// Token: 0x0400A458 RID: 42072
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ShipTowerRecordItem, ShipTowerRecordItemData> LayoutInfo;

	// Token: 0x0400A459 RID: 42073
	[Nullable(2)]
	private ShipTowerStageData StageData;

	// Token: 0x0400A45A RID: 42074
	[Nullable(2)]
	private ShareBtnItem ShareBtnItem;

	// Token: 0x02008D29 RID: 36137
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F79B RID: 194459
		public const int ItemCaption = 0;

		// Token: 0x0402F79C RID: 194460
		public const int ButtonHelp = 1;

		// Token: 0x0402F79D RID: 194461
		public const int LoopViewPeriod = 2;

		// Token: 0x0402F79E RID: 194462
		public const int ItemEmpty = 3;

		// Token: 0x0402F79F RID: 194463
		public const int ItemDescRoot = 4;

		// Token: 0x0402F7A0 RID: 194464
		public const int TextDungeonName = 5;

		// Token: 0x0402F7A1 RID: 194465
		public const int TextMaxScore = 6;

		// Token: 0x0402F7A2 RID: 194466
		public const int TextMaxWave = 7;

		// Token: 0x0402F7A3 RID: 194467
		public const int TextureGrade = 8;

		// Token: 0x0402F7A4 RID: 194468
		public const int VLayoutTeamRecord = 9;

		// Token: 0x0402F7A5 RID: 194469
		public const int ItemPeriod = 10;

		// Token: 0x0402F7A6 RID: 194470
		public const int ShareItem = 11;
	}
}
