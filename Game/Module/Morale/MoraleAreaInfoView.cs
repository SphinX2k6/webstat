using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Morale.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005700 RID: 22272
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleAreaInfoView : UiViewBase
	{
		// Token: 0x06038AC6 RID: 232134 RVA: 0x00E59E2A File Offset: 0x00E5802A
		public MoraleAreaInfoView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038AC7 RID: 232135 RVA: 0x00E59E40 File Offset: 0x00E58040
		protected unsafe override void OnRegisterComponent()
		{
			int num = 20;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnBtnSmallFlagDesc));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(19, new Action(this.OnClickBtnExploreBoxTrack));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06038AC8 RID: 232136 RVA: 0x00E5A16C File Offset: 0x00E5836C
		private void InitDataParam()
		{
			this.Model = ModelBase<MoraleModel>.Instance;
			MoraleAreaInfoView.Params @params = this.OpenParam as MoraleAreaInfoView.Params;
			int areaId = (@params != null) ? @params.AreaId : this.Model.AreaDataList[0].Id;
			this.AreaData = this.Model.GetAreaData(areaId);
			MoraleAreaInfoView.Params params2 = this.OpenParam as MoraleAreaInfoView.Params;
			int flagId = ((params2 != null) ? params2.FlagId : null) ?? this.AreaData.GetDefaultSelectFlagId();
			this.FlagData = this.AreaData.GetFlag(flagId);
		}

		// Token: 0x06038AC9 RID: 232137 RVA: 0x00E5A214 File Offset: 0x00E58414
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleAreaInfoView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleAreaInfoView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038ACA RID: 232138 RVA: 0x00E5A258 File Offset: 0x00E58458
		protected override UniTask OnPlayingStartSequenceAsync()
		{
			MoraleAreaInfoView.<OnPlayingStartSequenceAsync>d__15 <OnPlayingStartSequenceAsync>d__;
			<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingStartSequenceAsync>d__.<>4__this = this;
			<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
			<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<MoraleAreaInfoView.<OnPlayingStartSequenceAsync>d__15>(ref <OnPlayingStartSequenceAsync>d__);
			return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038ACB RID: 232139 RVA: 0x00E5A29B File Offset: 0x00E5849B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.MoraleAreaChangeFlag, new Action<int>(this.EventMoraleAreaChangeFlag));
		}

		// Token: 0x06038ACC RID: 232140 RVA: 0x00E5A2B9 File Offset: 0x00E584B9
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.MoraleAreaChangeFlag, new Action<int>(this.EventMoraleAreaChangeFlag));
		}

		// Token: 0x06038ACD RID: 232141 RVA: 0x00E5A2D7 File Offset: 0x00E584D7
		protected override void OnBeforeShow()
		{
			this.UpdateData();
		}

		// Token: 0x06038ACE RID: 232142 RVA: 0x00E5A2DF File Offset: 0x00E584DF
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06038ACF RID: 232143 RVA: 0x00E5A2E1 File Offset: 0x00E584E1
		private void OnBtnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038AD0 RID: 232144 RVA: 0x00E5A2EC File Offset: 0x00E584EC
		public void UpdateData()
		{
			this.SumLvInfoPanel.UpdateData();
			this.MapPanel.UpdateData();
			this.SelectFlag(this.FlagData);
			this.PopupCaption.SetTitleLocalText(this.AreaData.Config.Name);
			this.UpdateSmallFlagNumPercent();
			this.UpdateFlagBoxNumPercent();
			this.UpdateExploreBoxNumPercent();
		}

		// Token: 0x06038AD1 RID: 232145 RVA: 0x00E5A348 File Offset: 0x00E58548
		public void UpdateSmallFlagNumPercent()
		{
			if (!ConfigBase<MoraleConfig>.Instance.GetMoraleIsShowSmallFlagProgress())
			{
				UUIItem item = base.GetItem(3);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else
			{
				bool flag = this.Model.IsMoraleGameOver();
				UUIItem item2 = base.GetItem(3);
				if (item2 != null)
				{
					item2.SetUIActive(!flag);
				}
				if (flag)
				{
					return;
				}
				int areaFlagTotalNum = this.AreaData.GetAreaFlagTotalNum(EMoraleFlagType.Small);
				int areaFlagActiveNum = this.AreaData.GetAreaFlagActiveNum(EMoraleFlagType.Small);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(areaFlagActiveNum);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(areaFlagTotalNum);
				string newText = defaultInterpolatedStringHandler.ToStringAndClear();
				UUIText text = base.GetText(17);
				if (text == null)
				{
					return;
				}
				text.SetText(newText, true);
				return;
			}
		}

		// Token: 0x06038AD2 RID: 232146 RVA: 0x00E5A3F8 File Offset: 0x00E585F8
		public void UpdateFlagBoxNumPercent()
		{
			int allFlagBoxTotalCount = this.AreaData.GetAllFlagBoxTotalCount();
			int allFlagBoxReceivedCount = this.AreaData.GetAllFlagBoxReceivedCount();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(allFlagBoxReceivedCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(allFlagBoxTotalCount);
			string newText = defaultInterpolatedStringHandler.ToStringAndClear();
			UUIText text = base.GetText(15);
			if (text == null)
			{
				return;
			}
			text.SetText(newText, true);
		}

		// Token: 0x06038AD3 RID: 232147 RVA: 0x00E5A460 File Offset: 0x00E58660
		public void UpdateExploreBoxNumPercent()
		{
			UUIButtonComponent button = base.GetButton(19);
			UUIItem uuiitem = (button != null) ? button.RootUIComp.Get() : null;
			UUIItem item = base.GetItem(18);
			if (!ConfigBase<MoraleConfig>.Instance.GetMoraleHighFlagUnFinishIsShowExploreBoxProgress() && !this.AreaData.HighDifficultyFlagSomeActive())
			{
				if (item != null)
				{
					item.SetUIActive(false);
				}
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(false);
				}
				return;
			}
			int exploreBoxTotalCount = this.AreaData.ExploreBoxTotalCount;
			int exploreBoxReceivedCount = this.AreaData.ExploreBoxReceivedCount;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(exploreBoxReceivedCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(exploreBoxTotalCount);
			string newText = defaultInterpolatedStringHandler.ToStringAndClear();
			UUIText text = base.GetText(16);
			if (text != null)
			{
				text.SetText(newText, true);
			}
			if (item != null)
			{
				item.SetUIActive(true);
			}
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(exploreBoxReceivedCount < exploreBoxTotalCount);
			}
		}

		// Token: 0x06038AD4 RID: 232148 RVA: 0x00E5A535 File Offset: 0x00E58735
		public void SelectFlag(MoraleAreaFlagData flagData)
		{
			this.FlagData = flagData;
			this.UpdateSelectFlagState();
			this.FlagMonsterInfoPanel.UpdateData(this.FlagData);
			this.MapPanel.UpdateFlagState();
		}

		// Token: 0x06038AD5 RID: 232149 RVA: 0x00E5A560 File Offset: 0x00E58760
		public void SelectFlagId(int flagId)
		{
			this.FlagData = this.AreaData.GetFlag(flagId);
			this.SelectFlag(this.FlagData);
		}

		// Token: 0x06038AD6 RID: 232150 RVA: 0x00E5A580 File Offset: 0x00E58780
		private void EventMoraleAreaChangeFlag(int flagId)
		{
			this.SelectFlagId(flagId);
		}

		// Token: 0x06038AD7 RID: 232151 RVA: 0x00E5A58C File Offset: 0x00E5878C
		public UniTask UpdateMapData()
		{
			MoraleAreaInfoView.<UpdateMapData>d__28 <UpdateMapData>d__;
			<UpdateMapData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateMapData>d__.<>4__this = this;
			<UpdateMapData>d__.<>1__state = -1;
			<UpdateMapData>d__.<>t__builder.Start<MoraleAreaInfoView.<UpdateMapData>d__28>(ref <UpdateMapData>d__);
			return <UpdateMapData>d__.<>t__builder.Task;
		}

		// Token: 0x06038AD8 RID: 232152 RVA: 0x00E5A5D0 File Offset: 0x00E587D0
		private UniTask UpdateMapBg()
		{
			MoraleAreaInfoView.<UpdateMapBg>d__29 <UpdateMapBg>d__;
			<UpdateMapBg>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateMapBg>d__.<>4__this = this;
			<UpdateMapBg>d__.<>1__state = -1;
			<UpdateMapBg>d__.<>t__builder.Start<MoraleAreaInfoView.<UpdateMapBg>d__29>(ref <UpdateMapBg>d__);
			return <UpdateMapBg>d__.<>t__builder.Task;
		}

		// Token: 0x06038AD9 RID: 232153 RVA: 0x00E5A614 File Offset: 0x00E58814
		private UniTask UpdateDiffLightBg()
		{
			MoraleAreaInfoView.<UpdateDiffLightBg>d__30 <UpdateDiffLightBg>d__;
			<UpdateDiffLightBg>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateDiffLightBg>d__.<>4__this = this;
			<UpdateDiffLightBg>d__.<>1__state = -1;
			<UpdateDiffLightBg>d__.<>t__builder.Start<MoraleAreaInfoView.<UpdateDiffLightBg>d__30>(ref <UpdateDiffLightBg>d__);
			return <UpdateDiffLightBg>d__.<>t__builder.Task;
		}

		// Token: 0x06038ADA RID: 232154 RVA: 0x00E5A657 File Offset: 0x00E58857
		private void OnClickFlagItem(MoraleAreaFlagData flagData)
		{
			this.SelectFlag(flagData);
			this.FlagMonsterInfoPanel.PlayEnter();
			this.UpdateDiffLightBg().Forget();
		}

		// Token: 0x06038ADB RID: 232155 RVA: 0x00E5A678 File Offset: 0x00E58878
		public void UpdateSelectFlagState()
		{
			MoraleAreaFlagData flagData = this.FlagData;
			IReadOnlyList<MoraleAreaFlagData> uiFlagList = this.AreaData.GetUiFlagList();
			for (int i = 0; i < uiFlagList.Count; i++)
			{
				MoraleAreaFlagData moraleAreaFlagData = uiFlagList[i];
				moraleAreaFlagData.SetSelectState(moraleAreaFlagData.Id == flagData.Id);
			}
		}

		// Token: 0x06038ADC RID: 232156 RVA: 0x00E5A6C4 File Offset: 0x00E588C4
		private void OnBtnSmallFlagDesc()
		{
			MoraleModel instance = ModelBase<MoraleModel>.Instance;
			string descKey = ((instance != null) ? new bool?(instance.IsMoraleGameOver()) : null).GetValueOrDefault() ? "Morale_title_39" : "Morale_title_21";
			this.SmallFlagDescPanel.SetActive(true);
			this.SmallFlagDescPanel.UpdateDesc(descKey);
		}

		// Token: 0x06038ADD RID: 232157 RVA: 0x00E5A71E File Offset: 0x00E5891E
		private void OnClickBtnExploreBoxTrack()
		{
			MoraleModel instance = ModelBase<MoraleModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.TrackAreaExploreBox(this.AreaData.Id);
		}

		// Token: 0x06038ADE RID: 232158 RVA: 0x00E5A73A File Offset: 0x00E5893A
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx([Nullable(new byte[]
		{
			2,
			1
		})] string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "BossFlag"))
			{
				return null;
			}
			MoraleAreaInfoMapPanel mapPanel = this.MapPanel;
			if (mapPanel == null)
			{
				return null;
			}
			return mapPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x04020501 RID: 132353
		public PopupCaptionItem PopupCaption;

		// Token: 0x04020502 RID: 132354
		public MoraleSumLvInfoPanel SumLvInfoPanel;

		// Token: 0x04020503 RID: 132355
		public MoraleFlagMonsterInfoPanel FlagMonsterInfoPanel;

		// Token: 0x04020504 RID: 132356
		public MoraleAreaInfoMapPanel MapPanel;

		// Token: 0x04020505 RID: 132357
		public MoraleAreaInfoFlagDescPanel SmallFlagDescPanel;

		// Token: 0x04020506 RID: 132358
		public MoraleAreaData AreaData;

		// Token: 0x04020507 RID: 132359
		public MoraleAreaFlagData FlagData;

		// Token: 0x04020508 RID: 132360
		public MoraleModel Model;

		// Token: 0x04020509 RID: 132361
		public string LastLightBgPath = "";

		// Token: 0x0200B775 RID: 46965
		[NullableContext(0)]
		[RequiredMember]
		public class Params
		{
			// Token: 0x0604D20F RID: 315919 RVA: 0x01542316 File Offset: 0x01540516
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public Params()
			{
			}

			// Token: 0x04038BDD RID: 232413
			[RequiredMember]
			public int AreaId;

			// Token: 0x04038BDE RID: 232414
			public int? FlagId;
		}

		// Token: 0x0200B776 RID: 46966
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x04038BE0 RID: 232416
			ItemCaption,
			// Token: 0x04038BE1 RID: 232417
			ItemLevelInfoPanel,
			// Token: 0x04038BE2 RID: 232418
			ItemLeftBottomRoot,
			// Token: 0x04038BE3 RID: 232419
			ItemSmallFlagTipsRoot,
			// Token: 0x04038BE4 RID: 232420
			ItemFlagInfoPanel,
			// Token: 0x04038BE5 RID: 232421
			ItemArea1Pos,
			// Token: 0x04038BE6 RID: 232422
			ItemArea2Pos,
			// Token: 0x04038BE7 RID: 232423
			ItemArea3Pos,
			// Token: 0x04038BE8 RID: 232424
			ItemArea4Pos,
			// Token: 0x04038BE9 RID: 232425
			ItemArea5Pos,
			// Token: 0x04038BEA RID: 232426
			TexMapBg,
			// Token: 0x04038BEB RID: 232427
			TexDiffLight,
			// Token: 0x04038BEC RID: 232428
			SpriteMapGridBg,
			// Token: 0x04038BED RID: 232429
			ItemSmallFlagDesc,
			// Token: 0x04038BEE RID: 232430
			BtnSmallFlagDesc,
			// Token: 0x04038BEF RID: 232431
			TxtFlagBoxNumPercent,
			// Token: 0x04038BF0 RID: 232432
			TxtExploreBoxNumPercent,
			// Token: 0x04038BF1 RID: 232433
			TxtSmallFlagNumPercent,
			// Token: 0x04038BF2 RID: 232434
			ItemExploreBoxRoot,
			// Token: 0x04038BF3 RID: 232435
			BtnExploreBoxTrack
		}
	}
}
