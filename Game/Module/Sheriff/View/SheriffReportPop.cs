using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View
{
	// Token: 0x02004FD3 RID: 20435
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffReportPop : UiTickViewBase
	{
		// Token: 0x06034B1F RID: 215839 RVA: 0x00D36F0B File Offset: 0x00D3510B
		public SheriffReportPop(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034B20 RID: 215840 RVA: 0x00D36F28 File Offset: 0x00D35128
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBackBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickTogSkyEyeTab));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnClickTogSkyEyeTab2));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034B21 RID: 215841 RVA: 0x00D370BC File Offset: 0x00D352BC
		protected override void OnStart()
		{
			AUIBaseActor rootActor = this.RootActor;
			if (rootActor != null)
			{
				rootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnSequenceEventStart));
			}
			this.InitData();
			bool uiactive = this.BothPage && this.AnomalyInfo.EndingTime != 0L;
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle != null)
			{
				extendToggle.RootUIComp.Get().SetUIActive(uiactive);
			}
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(3);
			if (extendToggle2 != null)
			{
				extendToggle2.RootUIComp.Get().SetUIActive(uiactive);
			}
			this.TabDataList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(EUiViewName.SheriffReportPop);
			this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(5), EKeyMode.Default);
		}

		// Token: 0x06034B22 RID: 215842 RVA: 0x00D37179 File Offset: 0x00D35379
		protected override void OnBeforeShow()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle != null)
			{
				extendToggle.SetSelfInteractive(false);
			}
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(3);
			if (extendToggle2 == null)
			{
				return;
			}
			extendToggle2.SetSelfInteractive(false);
		}

		// Token: 0x06034B23 RID: 215843 RVA: 0x00D371A0 File Offset: 0x00D353A0
		protected override void OnBeforeDestroy()
		{
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent != null)
			{
				tabViewComponent.DestroyTabViewComponent();
			}
			this.TabViewComponent = null;
		}

		// Token: 0x06034B24 RID: 215844 RVA: 0x00D371BC File Offset: 0x00D353BC
		private void InitData()
		{
			ISheriffReportPopViewParam sheriffReportPopViewParam = this.OpenParam as ISheriffReportPopViewParam;
			this.CriminalId = sheriffReportPopViewParam.CriminalId;
			this.BothPage = sheriffReportPopViewParam.BothPage;
			this.CriminalInfo = ModelBase<SheriffModel>.Instance.GetCriminalInfo(this.CriminalId);
			SheriffCriminal value = ConfigBase<SheriffConfig>.Instance.GetCriminalConfigById(this.CriminalId).Value;
			this.AnomalyInfo = ModelBase<SheriffModel>.Instance.GetAnomalyInfo(value.SheriffAnomalyId);
			SheriffAnomaly value2 = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(value.SheriffAnomalyId).Value;
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.ShowTextNew(value2.Name);
			}
			int anomalyProgressPercent = ModelBase<SheriffModel>.Instance.GetAnomalyProgressPercent(value.SheriffAnomalyId);
			string text2 = (anomalyProgressPercent == 100) ? "Sheriff_EventProgress_19" : "Sheriff_EventProgress_1";
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText text3 = base.GetText(6);
			string textStringId = text2;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(anomalyProgressPercent);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			instance.SetLocalTextNew(text3, textStringId, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
		}

		// Token: 0x06034B25 RID: 215845 RVA: 0x00D372C9 File Offset: 0x00D354C9
		private void OnClickBackBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x06034B26 RID: 215846 RVA: 0x00D372D4 File Offset: 0x00D354D4
		private void OnClickTogSkyEyeTab(EToggleState state)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			SheriffReportPopParam extraParams = new SheriffReportPopParam
			{
				CriminalId = this.CriminalId,
				CloseCallback = delegate
				{
					this.OnClickBackBtn();
				}
			};
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent == null)
			{
				return;
			}
			tabViewComponent.ToggleCallBack(this.TabDataList[0], EUiTabViewName.SheriffReportDetailItem, null, extraParams, null);
		}

		// Token: 0x06034B27 RID: 215847 RVA: 0x00D37348 File Offset: 0x00D35548
		private void OnClickTogSkyEyeTab2(EToggleState state)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
			if (tabViewComponent == null)
			{
				return;
			}
			tabViewComponent.ToggleCallBack(this.TabDataList[1], EUiTabViewName.SheriffReportRecordItem, null, this.CriminalId, null);
		}

		// Token: 0x06034B28 RID: 215848 RVA: 0x00D373A4 File Offset: 0x00D355A4
		private void OnSequenceEventStart(string sequenceName, string eventName)
		{
			if (sequenceName != "Start" || eventName != "Start")
			{
				return;
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle != null)
			{
				extendToggle.SetSelfInteractive(true);
			}
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(3);
			if (extendToggle2 != null)
			{
				extendToggle2.SetSelfInteractive(true);
			}
			if (this.BothPage)
			{
				if (this.AnomalyInfo.EndingTime == 0L)
				{
					UUIExtendToggle extendToggle3 = base.GetExtendToggle(2);
					if (extendToggle3 == null)
					{
						return;
					}
					extendToggle3.SetToggleState(EToggleState.ETT_Checked, true, false, false);
					return;
				}
				else
				{
					UUIExtendToggle extendToggle4 = base.GetExtendToggle(3);
					if (extendToggle4 == null)
					{
						return;
					}
					extendToggle4.SetToggleState(EToggleState.ETT_Checked, true, false, false);
					return;
				}
			}
			else
			{
				UUIExtendToggle extendToggle5 = base.GetExtendToggle(3);
				if (extendToggle5 == null)
				{
					return;
				}
				extendToggle5.SetToggleState(EToggleState.ETT_Checked, true, false, false);
				return;
			}
		}

		// Token: 0x0401E5FE RID: 124414
		private List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x0401E5FF RID: 124415
		[Nullable(2)]
		protected SheriffAnomalyInfo AnomalyInfo;

		// Token: 0x0401E600 RID: 124416
		[Nullable(2)]
		protected SheriffCriminalInfo CriminalInfo;

		// Token: 0x0401E601 RID: 124417
		[Nullable(2)]
		protected TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x0401E602 RID: 124418
		protected int CriminalId;

		// Token: 0x0401E603 RID: 124419
		protected bool BothPage = true;

		// Token: 0x0200AF9F RID: 44959
		[NullableContext(0)]
		private static class EDefine
		{
			// Token: 0x04036803 RID: 223235
			public const int BackBtn = 0;

			// Token: 0x04036804 RID: 223236
			public const int PanelTab = 1;

			// Token: 0x04036805 RID: 223237
			public const int TogSkyEyeTab = 2;

			// Token: 0x04036806 RID: 223238
			public const int TogSkyEyeTab2 = 3;

			// Token: 0x04036807 RID: 223239
			public const int TxtTitle = 4;

			// Token: 0x04036808 RID: 223240
			public const int Content = 5;

			// Token: 0x04036809 RID: 223241
			public const int TxtProgress = 6;
		}
	}
}
