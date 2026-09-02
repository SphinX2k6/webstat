using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C69 RID: 23657
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrRoadNetworkMainView : UiViewBase
	{
		// Token: 0x0603BC54 RID: 244820 RVA: 0x00F25D1C File Offset: 0x00F23F1C
		public InfrRoadNetworkMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603BC55 RID: 244821 RVA: 0x00F25D88 File Offset: 0x00F23F88
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
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
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIDraggableComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnClickMask));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BC56 RID: 244822 RVA: 0x00F26005 File Offset: 0x00F24205
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<InfrastructureDefine.InfrNoticeData>>(EEventName.InfrastructureRoadNoticeUpdate, new Action<IReadOnlyList<InfrastructureDefine.InfrNoticeData>>(this.OnNoticeUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.InfrastructureTraceRoadUpdate, new Action(this.OnTraceRoadUpdate));
		}

		// Token: 0x0603BC57 RID: 244823 RVA: 0x00F2603F File Offset: 0x00F2423F
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<IReadOnlyList<InfrastructureDefine.InfrNoticeData>>(EEventName.InfrastructureRoadNoticeUpdate, new Action<IReadOnlyList<InfrastructureDefine.InfrNoticeData>>(this.OnNoticeUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.InfrastructureTraceRoadUpdate, new Action(this.OnTraceRoadUpdate));
		}

		// Token: 0x0603BC58 RID: 244824 RVA: 0x00F2607C File Offset: 0x00F2427C
		protected override UniTask OnBeforeStartAsync()
		{
			InfrRoadNetworkMainView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InfrRoadNetworkMainView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC59 RID: 244825 RVA: 0x00F260C0 File Offset: 0x00F242C0
		private void SetupOpenParam(InfrastructureDefine.IInfrRoadNetworkOpenParam openParam)
		{
			if (openParam == null)
			{
				return;
			}
			this.OpenDeliveryType = openParam.DeliveryType;
			this.OpenRoadId = openParam.RoadId;
			this.NeedPlayFinishSeq = openParam.NeedPlayFinishSeq.GetValueOrDefault();
		}

		// Token: 0x0603BC5A RID: 244826 RVA: 0x00F26100 File Offset: 0x00F24300
		private UniTask CreateCaption()
		{
			InfrRoadNetworkMainView.<CreateCaption>d__21 <CreateCaption>d__;
			<CreateCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCaption>d__.<>4__this = this;
			<CreateCaption>d__.<>1__state = -1;
			<CreateCaption>d__.<>t__builder.Start<InfrRoadNetworkMainView.<CreateCaption>d__21>(ref <CreateCaption>d__);
			return <CreateCaption>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC5B RID: 244827 RVA: 0x00F26144 File Offset: 0x00F24344
		private UniTask CreateMapPanel()
		{
			InfrRoadNetworkMainView.<CreateMapPanel>d__22 <CreateMapPanel>d__;
			<CreateMapPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateMapPanel>d__.<>4__this = this;
			<CreateMapPanel>d__.<>1__state = -1;
			<CreateMapPanel>d__.<>t__builder.Start<InfrRoadNetworkMainView.<CreateMapPanel>d__22>(ref <CreateMapPanel>d__);
			return <CreateMapPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC5C RID: 244828 RVA: 0x00F26188 File Offset: 0x00F24388
		private UniTask CreateFireExpItem()
		{
			InfrRoadNetworkMainView.<CreateFireExpItem>d__23 <CreateFireExpItem>d__;
			<CreateFireExpItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateFireExpItem>d__.<>4__this = this;
			<CreateFireExpItem>d__.<>1__state = -1;
			<CreateFireExpItem>d__.<>t__builder.Start<InfrRoadNetworkMainView.<CreateFireExpItem>d__23>(ref <CreateFireExpItem>d__);
			return <CreateFireExpItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC5D RID: 244829 RVA: 0x00F261CC File Offset: 0x00F243CC
		private UniTask RefreshCaption()
		{
			InfrRoadNetworkMainView.<RefreshCaption>d__24 <RefreshCaption>d__;
			<RefreshCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCaption>d__.<>4__this = this;
			<RefreshCaption>d__.<>1__state = -1;
			<RefreshCaption>d__.<>t__builder.Start<InfrRoadNetworkMainView.<RefreshCaption>d__24>(ref <RefreshCaption>d__);
			return <RefreshCaption>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC5E RID: 244830 RVA: 0x00F2620F File Offset: 0x00F2440F
		protected override void OnStart()
		{
			this.CreateMoveComponent();
			this.RefreshFireExpItem();
			this.InitZoom();
			this.OnNoticeUpdate(new List<InfrastructureDefine.InfrNoticeData>());
			this.RefreshMapInitialParam();
		}

		// Token: 0x0603BC5F RID: 244831 RVA: 0x00F26234 File Offset: 0x00F24434
		protected override void OnBeforeShow()
		{
			this.MapPanel.RefreshMarkScale((float)this.MoveComponent.MapScale);
			this.MoveComponent.BindTouch();
			this.MoveComponent.AddGamepadEvent();
			this.SetMapMarkTraced();
		}

		// Token: 0x0603BC60 RID: 244832 RVA: 0x00F26269 File Offset: 0x00F24469
		protected override void OnAfterHide()
		{
			this.MoveComponent.UnbindTouch();
			this.MoveComponent.RemoveGamepadEvent();
		}

		// Token: 0x0603BC61 RID: 244833 RVA: 0x00F26281 File Offset: 0x00F24481
		protected override void OnAfterPlayStartSequence()
		{
			this.MapPanel.ShowMarkUnlock(this.NeedPlayFinishSeq, new Action(this.ShowBuildFinishSequence));
		}

		// Token: 0x0603BC62 RID: 244834 RVA: 0x00F262A0 File Offset: 0x00F244A0
		private void CreateMoveComponent()
		{
			this.MoveComponent = new BuildingMapMoveComponent(base.GetDraggable(9), true, true, false);
			IReadOnlyList<float> floatArrayConfig = ConfigCommonParamById.GetFloatArrayConfig("InfrRoadNetworkMapSizeParam");
			this.MoveComponent.SetScaleSafeArea((double)floatArrayConfig[0], (double)floatArrayConfig[1]);
			this.MoveComponent.PointerBeginDragExtraCallBack = new Action<ULGUIPointerEventData>(this.CheckInfoPanel);
			this.MoveComponent.PointerUpExtraCallBack = new Action<ULGUIPointerEventData>(this.CheckInfoPanel);
			this.MoveComponent.SetChangeScaleCallback(new Action<ESetScaleSource>(this.OnChangeSlider));
		}

		// Token: 0x0603BC63 RID: 244835 RVA: 0x00F26330 File Offset: 0x00F24530
		private void InitZoom()
		{
			UUISliderComponent slider = base.GetSlider(7);
			slider.SetMinValue((float)this.MoveComponent.MapScaleSafeArea.Min, false, false);
			slider.SetMaxValue((float)this.MoveComponent.MapScaleSafeArea.Max, false, false);
			slider.OnValueChangeCb.Bind(new Action<float>(this.OnSliderValueChange));
			this.ZoomIn = new LongPressButton(base.GetButton(5), new Action<float>(this.OnZoomIn), 100);
			this.ZoomOut = new LongPressButton(base.GetButton(6), new Action<float>(this.OnZoomOut), 100);
		}

		// Token: 0x0603BC64 RID: 244836 RVA: 0x00F263CC File Offset: 0x00F245CC
		private void RefreshFireExpItem()
		{
			this.FireExpPanel.SetOnClickHelpCb(delegate
			{
				int helpIdRoadProcess = ConfigBase<InfrastructureConfig>.Instance.GetHelpIdRoadProcess();
				ControllerBase<HelpController>.Instance.OpenHelpById(helpIdRoadProcess);
			});
			if (this.NeedPlayFinishSeq)
			{
				this.FireExpPanel.RefreshExpBeforeRoadBuilt(this.OpenRoadId);
			}
		}

		// Token: 0x0603BC65 RID: 244837 RVA: 0x00F2641C File Offset: 0x00F2461C
		private void SetMapMarkTraced()
		{
			InfrastructureDefine.IInfrRoadNetworkOpenParam infrRoadNetworkOpenParam = this.OpenParam as InfrastructureDefine.IInfrRoadNetworkOpenParam;
			if (infrRoadNetworkOpenParam != null && !infrRoadNetworkOpenParam.NeedPlayFinishSeq.GetValueOrDefault())
			{
				this.MapPanel.SelectMark(this.OpenDeliveryType, this.OpenRoadId);
			}
		}

		// Token: 0x0603BC66 RID: 244838 RVA: 0x00F26460 File Offset: 0x00F24660
		private void ShowBuildFinishSequence()
		{
			if (this.NeedPlayFinishSeq)
			{
				Action allFinishFunc = delegate()
				{
					if (!this.NeedPlayFinishSeq)
					{
						return;
					}
					this.NeedPlayFinishSeq = false;
					UUITexture texture2 = this.GetTexture(11);
					if (texture2 != null)
					{
						texture2.SetUIActive(false);
					}
					Singleton<UiManager>.Instance.OpenView(EUiViewName.InfrastructureSettleView, new InfrastructureDefine.InfrSettleViewOpenParam
					{
						DeliveryType = this.OpenDeliveryType,
						RoadId = this.OpenRoadId
					}, null);
				};
				this.FireExpPanel.SetOnDigitSequenceFinishCb(allFinishFunc);
				this.MapPanel.RefreshFinishTextureLine(this.OpenRoadId);
				Action <>9__2;
				base.PlaySequence("Finish", delegate
				{
					InfrRoadNetworkMapPanel mapPanel = this.MapPanel;
					ActionInfrastructureItemDeliveryType openDeliveryType = this.OpenDeliveryType;
					int openRoadId = this.OpenRoadId;
					Action onFinishPlayEnd;
					if ((onFinishPlayEnd = <>9__2) == null)
					{
						onFinishPlayEnd = (<>9__2 = delegate()
						{
							if (!this.FireExpPanel.UpdateExp())
							{
								allFinishFunc();
							}
						});
					}
					mapPanel.ShowMarkFinishSeq(openDeliveryType, openRoadId, onFinishPlayEnd);
				}, false);
				return;
			}
			UUITexture texture = base.GetTexture(11);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(false);
		}

		// Token: 0x0603BC67 RID: 244839 RVA: 0x00F264E4 File Offset: 0x00F246E4
		private void RefreshMapInitialParam()
		{
			float value = ConfigCommonParamById.GetFloatConfig("InfrRoadNetworkMapDefaultSize").Value;
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("InfrRoadNetworkMapDefaultPos");
			this.PreScale = (double)value;
			this.PreOffset = new Tuple<double, double>((double)intArrayConfig[0], (double)intArrayConfig[1]);
			if (!this.NeedPlayFinishSeq)
			{
				this.MoveComponent.SetScale((double)value, ESetScaleSource.Other, null);
				this.MoveComponent.MoveToTarget(new double[]
				{
					(double)intArrayConfig[0],
					(double)intArrayConfig[1]
				}, LTweenEase.Linear, 0.0, null);
				return;
			}
			Tuple<float, float> tuple;
			if (this.OpenDeliveryType == ActionInfrastructureItemDeliveryType.Road)
			{
				tuple = this.MapPanel.GetMarkUiPosition(this.OpenRoadId);
			}
			else
			{
				tuple = this.MapPanel.GetObservatoryMarkUiPosition();
			}
			float? floatConfig = ConfigCommonParamById.GetFloatConfig("InfrRoadNetworkFoaclScale");
			this.MoveComponent.SetScale((double)floatConfig.Value, ESetScaleSource.Other, null);
			this.MoveComponent.MoveToTarget(new double[]
			{
				(double)tuple.Item1,
				(double)tuple.Item2
			}, LTweenEase.Linear, 0.0, null);
		}

		// Token: 0x0603BC68 RID: 244840 RVA: 0x00F265F8 File Offset: 0x00F247F8
		private void RefreshPartUiVisible()
		{
			this.Caption.SetUiActive(!this.ShowInfoPanel);
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(!this.ShowInfoPanel);
			}
			UUIButtonComponent button = base.GetButton(15);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(this.ShowInfoPanel);
			}
			if (this.ShowInfoPanel && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InfrRoadNetworkInfoView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.InfrRoadNetworkInfoView, new InfrastructureDefine.InfrRoadNetworkInfoOpenParam
				{
					InfoParam = this.SelectedParam,
					BuildCb = delegate
					{
						this.OnClickBtnBuild();
					},
					CloseCb = delegate
					{
						this.CheckInfoPanel(null);
					}
				}, delegate(bool isSuccess, int viewId)
				{
					if (isSuccess)
					{
						base.AddChildViewById(viewId);
					}
				});
			}
		}

		// Token: 0x0603BC69 RID: 244841 RVA: 0x00F266C3 File Offset: 0x00F248C3
		protected override void OnBeforeDestroy()
		{
			this.MoveComponent.Destroy();
			if (this.TimerId != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
				this.TimerId = null;
			}
		}

		// Token: 0x0603BC6A RID: 244842 RVA: 0x00F266F0 File Offset: 0x00F248F0
		private void OnZoomOut(float _)
		{
			this.MoveComponent.LongPressScroll((float)(-(float)this.MoveComponent.ScaleStep));
		}

		// Token: 0x0603BC6B RID: 244843 RVA: 0x00F2670A File Offset: 0x00F2490A
		private void OnZoomIn(float _)
		{
			this.MoveComponent.LongPressScroll((float)this.MoveComponent.ScaleStep);
		}

		// Token: 0x0603BC6C RID: 244844 RVA: 0x00F26723 File Offset: 0x00F24923
		private void OnSliderValueChange(float value)
		{
			this.MoveComponent.SliderScroll(value);
		}

		// Token: 0x0603BC6D RID: 244845 RVA: 0x00F26731 File Offset: 0x00F24931
		private void OnChangeSlider(ESetScaleSource source)
		{
			UUISliderComponent slider = base.GetSlider(7);
			if (slider != null)
			{
				slider.SetValue((float)this.MoveComponent.MapScale, true);
			}
			this.MapPanel.RefreshMarkScale((float)this.MoveComponent.MapScale);
		}

		// Token: 0x0603BC6E RID: 244846 RVA: 0x00F2676C File Offset: 0x00F2496C
		private void CheckInfoPanel(ULGUIPointerEventData data)
		{
			if (this.ShowInfoPanel)
			{
				this.ShowInfoPanel = false;
				this.SelectedParam = null;
				Singleton<UiManager>.Instance.CloseView(EUiViewName.InfrRoadNetworkInfoView, null);
				this.MapPanel.DeselectMark();
				base.PlaySequence("ShowView", null, false);
				float value = ConfigCommonParamById.GetFloatConfig("InfrRoadNetworkFocalTime").Value;
				this.MoveComponent.ScaleToTarget(this.PreScale, new float[]
				{
					(float)this.PreOffset.Item1,
					(float)this.PreOffset.Item2
				}, LTweenEase.Linear, value, ETweenScaleType.Normal, null);
			}
			FVector2D anchorOffset = this.MapPanel.GetRootItem().GetAnchorOffset();
			this.PreOffset = new Tuple<double, double>((double)(-(double)anchorOffset.X) / this.PreScale, (double)(-(double)anchorOffset.Y) / this.PreScale);
			this.RefreshPartUiVisible();
		}

		// Token: 0x0603BC6F RID: 244847 RVA: 0x00F26848 File Offset: 0x00F24A48
		private void OnSelectMark(InfrastructureDefine.IInfrMaterialsDeliveryOpenParam param)
		{
			if (this.SelectedParam == null)
			{
				base.PlaySequence("SweepCarrier", null, false);
			}
			this.SelectedParam = param;
			this.ShowInfoPanel = true;
			InfrastructureDefine.InfrRoadNetworkInfoOpenParam infrRoadNetworkInfoOpenParam = new InfrastructureDefine.InfrRoadNetworkInfoOpenParam
			{
				InfoParam = param,
				BuildCb = delegate
				{
					this.OnClickBtnBuild();
				},
				CloseCb = delegate
				{
					this.CheckInfoPanel(null);
				}
			};
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InfrRoadNetworkInfoView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.InfrRoadNetworkInfoView, infrRoadNetworkInfoOpenParam, delegate(bool isSuccess, int viewId)
				{
					if (isSuccess)
					{
						base.AddChildViewById(viewId);
					}
				});
			}
			else
			{
				Singleton<EventSystem>.Instance.Emit<InfrastructureDefine.IInfrRoadNetworkInfoOpenParam>(EEventName.InfrastructureSelectRoadNetworkMark, infrRoadNetworkInfoOpenParam);
			}
			this.PreScale = this.MoveComponent.MapScale;
			FVector2D anchorOffset = this.MapPanel.GetRootItem().GetAnchorOffset();
			this.PreOffset = new Tuple<double, double>((double)(-(double)anchorOffset.X) / this.PreScale, (double)(-(double)anchorOffset.Y) / this.PreScale);
			float value = ConfigCommonParamById.GetFloatConfig("InfrRoadNetworkFocalTime").Value;
			Tuple<float, float> tuple;
			if (param.DeliveryType == ActionInfrastructureItemDeliveryType.Road)
			{
				tuple = this.MapPanel.GetMarkUiPosition(param.RoadId);
			}
			else
			{
				tuple = this.MapPanel.GetObservatoryMarkUiPosition();
			}
			UUIItem item = base.GetItem(12);
			FVector? fvector = (item != null) ? new FVector?(item.GetUIWorldPosition()) : null;
			float value2 = ConfigCommonParamById.GetFloatConfig("InfrRoadNetworkFoaclScale").Value;
			tuple = new Tuple<float, float>(tuple.Item1 - fvector.Value.X / value2, tuple.Item2 - fvector.Value.Y / value2);
			this.MoveComponent.ScaleToTarget((double)value2, new float[]
			{
				tuple.Item1,
				tuple.Item2
			}, LTweenEase.Linear, value, ETweenScaleType.PreventOverScaling, null);
			this.RefreshPartUiVisible();
		}

		// Token: 0x0603BC70 RID: 244848 RVA: 0x00F26A10 File Offset: 0x00F24C10
		private void OnNoticeUpdate(IReadOnlyList<InfrastructureDefine.InfrNoticeData> notices)
		{
			if (notices.Count != 0)
			{
				UUIText text = base.GetText(10);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				InfrastructureDefine.InfrNoticeData infrNoticeData = (from n in notices
				orderby n.CreateTime descending
				select n).FirstOrDefault<InfrastructureDefine.InfrNoticeData>();
				InfrPasser? infrPasserConfigById = ConfigBase<InfrastructureConfig>.Instance.GetInfrPasserConfigById(infrNoticeData.PasserId);
				InfrRoadBuild? roadConfigById = ConfigBase<InfrastructureConfig>.Instance.GetRoadConfigById(infrNoticeData.RoadId);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "BuildRoad_InfrPasser", new <>z__ReadOnlyArray<object>(new object[]
				{
					new TableTextArgNew(infrPasserConfigById.Value.Name, Array.Empty<object>()),
					new TableTextArgNew(roadConfigById.Value.Name, Array.Empty<object>()),
					infrNoticeData.GiftCount
				}));
				return;
			}
			UUIText text2 = base.GetText(8);
			if (text2 != null)
			{
				text2.ShowTextNew("BuildRoadNet_SmsNotReceived");
			}
			UUIText text3 = base.GetText(10);
			if (text3 == null)
			{
				return;
			}
			text3.SetUIActive(false);
		}

		// Token: 0x0603BC71 RID: 244849 RVA: 0x00F26B1C File Offset: 0x00F24D1C
		private UniTask OnClickBtnBuild()
		{
			InfrRoadNetworkMainView.<OnClickBtnBuild>d__44 <OnClickBtnBuild>d__;
			<OnClickBtnBuild>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnClickBtnBuild>d__.<>4__this = this;
			<OnClickBtnBuild>d__.<>1__state = -1;
			<OnClickBtnBuild>d__.<>t__builder.Start<InfrRoadNetworkMainView.<OnClickBtnBuild>d__44>(ref <OnClickBtnBuild>d__);
			return <OnClickBtnBuild>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC72 RID: 244850 RVA: 0x00F26B5F File Offset: 0x00F24D5F
		private void OnTraceRoadUpdate()
		{
			this.MapPanel.RefreshAllMarks();
		}

		// Token: 0x0603BC73 RID: 244851 RVA: 0x00F26B6C File Offset: 0x00F24D6C
		private void OnClickMask()
		{
			this.CheckInfoPanel(null);
		}

		// Token: 0x0603BC74 RID: 244852 RVA: 0x00F26B75 File Offset: 0x00F24D75
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "RoadMark"))
			{
				return null;
			}
			InfrRoadNetworkMapPanel mapPanel = this.MapPanel;
			if (mapPanel == null)
			{
				return null;
			}
			return mapPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0402196B RID: 137579
		private readonly PopupCaptionItem Caption = new PopupCaptionItem(null);

		// Token: 0x0402196C RID: 137580
		private readonly InfrRoadNetworkMapPanel MapPanel = new InfrRoadNetworkMapPanel();

		// Token: 0x0402196D RID: 137581
		private readonly InfrastructureFireExpPanel FireExpPanel = new InfrastructureFireExpPanel();

		// Token: 0x0402196E RID: 137582
		private InfrastructureDefine.IInfrMaterialsDeliveryOpenParam SelectedParam;

		// Token: 0x0402196F RID: 137583
		private BuildingMapMoveComponent MoveComponent;

		// Token: 0x04021970 RID: 137584
		protected LongPressButton ZoomIn;

		// Token: 0x04021971 RID: 137585
		protected LongPressButton ZoomOut;

		// Token: 0x04021972 RID: 137586
		private bool ShowInfoPanel;

		// Token: 0x04021973 RID: 137587
		private TimerHandle TimerId;

		// Token: 0x04021974 RID: 137588
		private ActionInfrastructureItemDeliveryType OpenDeliveryType = ActionInfrastructureItemDeliveryType.Road;

		// Token: 0x04021975 RID: 137589
		private int OpenRoadId;

		// Token: 0x04021976 RID: 137590
		private bool NeedPlayFinishSeq;

		// Token: 0x04021977 RID: 137591
		private double PreScale = 1.0;

		// Token: 0x04021978 RID: 137592
		private Tuple<double, double> PreOffset = new Tuple<double, double>(0.0, 0.0);

		// Token: 0x0200BD08 RID: 48392
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403A3EA RID: 238570
			public const int ItemCaption = 0;

			// Token: 0x0403A3EB RID: 238571
			public const int PanelMapRoot = 1;

			// Token: 0x0403A3EC RID: 238572
			public const int PanelViewRoot = 2;

			// Token: 0x0403A3ED RID: 238573
			public const int PanelUi = 3;

			// Token: 0x0403A3EE RID: 238574
			public const int FireExpPanel = 4;

			// Token: 0x0403A3EF RID: 238575
			public const int BtnAdd = 5;

			// Token: 0x0403A3F0 RID: 238576
			public const int BtnReduce = 6;

			// Token: 0x0403A3F1 RID: 238577
			public const int SliderScaleCtrl = 7;

			// Token: 0x0403A3F2 RID: 238578
			public const int TextInfo = 8;

			// Token: 0x0403A3F3 RID: 238579
			public const int MapItem = 9;

			// Token: 0x0403A3F4 RID: 238580
			public const int TextTips = 10;

			// Token: 0x0403A3F5 RID: 238581
			public const int TextureMask = 11;

			// Token: 0x0403A3F6 RID: 238582
			public const int PanelPos = 12;

			// Token: 0x0403A3F7 RID: 238583
			public const int PanelMsgLayout = 13;

			// Token: 0x0403A3F8 RID: 238584
			public const int MsgItem = 14;

			// Token: 0x0403A3F9 RID: 238585
			public const int BtnMask = 15;
		}
	}
}
