using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CDF RID: 19679
	[NullableContext(1)]
	[Nullable(0)]
	public class UiNavigationModeModule : IStaticVariableResetter
	{
		// Token: 0x06033313 RID: 209683 RVA: 0x00CD0A6F File Offset: 0x00CCEC6F
		static UiNavigationModeModule()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(UiNavigationModeModule.CreateStaticDefaultValue), new Action(UiNavigationModeModule.ResetStaticDefaultValue));
		}

		// Token: 0x170087CD RID: 34765
		// (get) Token: 0x06033314 RID: 209684 RVA: 0x00CD0A8E File Offset: 0x00CCEC8E
		private static Vector TempValue
		{
			get
			{
				return UiNavigationModeModule._tempValue;
			}
		}

		// Token: 0x170087CE RID: 34766
		// (get) Token: 0x06033315 RID: 209685 RVA: 0x00CD0A95 File Offset: 0x00CCEC95
		public static FindOppositeNavigationResult FindOppositeNavigationResult
		{
			get
			{
				return UiNavigationModeModule._findOppositeNavigationResult;
			}
		}

		// Token: 0x06033316 RID: 209686 RVA: 0x00CD0A9C File Offset: 0x00CCEC9C
		public UiNavigationModeModule(TsUiNavigationBehaviorListener listener)
		{
			this.Listener = listener;
			this.NavigateTolerance = listener.NavigateTolerance;
			this.NavigateToleranceReverse = listener.NavigateToleranceReverse;
		}

		// Token: 0x06033317 RID: 209687 RVA: 0x00CD0ADC File Offset: 0x00CCECDC
		private static bool IsInItemRange(Vector offsetPosition, bool isVertical, TsUiNavigationBehaviorListener listener)
		{
			UUIItem rootComponent = listener.GetRootComponent();
			if (rootComponent == null)
			{
				return false;
			}
			FVector2D localSpaceCenter = rootComponent.GetLocalSpaceCenter();
			FVector2D localSpaceLeftBottomPoint = rootComponent.GetLocalSpaceLeftBottomPoint();
			FVector2D localSpaceRightTopPoint = rootComponent.GetLocalSpaceRightTopPoint();
			if (isVertical)
			{
				double num = (double)localSpaceCenter.X - offsetPosition.X;
				return num >= (double)localSpaceLeftBottomPoint.X && num <= (double)localSpaceRightTopPoint.X;
			}
			double num2 = (double)localSpaceCenter.Y - offsetPosition.Z;
			return num2 >= (double)localSpaceLeftBottomPoint.Y && num2 <= (double)localSpaceRightTopPoint.Y;
		}

		// Token: 0x06033318 RID: 209688 RVA: 0x00CD0B64 File Offset: 0x00CCED64
		private static bool ReplaceBestByDistance(double distance, double positiveDistance)
		{
			return (Math.Abs(distance - positiveDistance) < 0.0001 && (UiNavigationModeModule.TempValue.X < 0.0 || UiNavigationModeModule.TempValue.Z > 0.0)) || positiveDistance - distance >= 0.0001;
		}

		// Token: 0x06033319 RID: 209689 RVA: 0x00CD0BC1 File Offset: 0x00CCEDC1
		private static bool CheckSkipByPriorityMode([Nullable(2)] UUIScrollViewWithScrollbarComponent srcScrollView, TsUiNavigationBehaviorListener otherListener, UINavigationPriorityMode mode)
		{
			if (mode == UINavigationPriorityMode.DistanceOnlySameScroll)
			{
				UiNavigationScrollProxy scrollProxy = otherListener.ScrollProxy;
				return srcScrollView != ((scrollProxy != null) ? scrollProxy.ScrollView : null);
			}
			return false;
		}

		// Token: 0x0603331A RID: 209690 RVA: 0x00CD0BE4 File Offset: 0x00CCEDE4
		[return: Nullable(2)]
		public static TsUiNavigationBehaviorListener FindOppositeNavigationComponent(Vector srcPosition, TsUiNavigationBehaviorListener[] listenerArray, UINavigationWrapMode wrapMode, UINavigationPriorityMode priorityMode, bool isVertical, double navigateTolerance, double navigateToleranceReverse, float verticalScrollValue, float horizontalScrollValue, [Nullable(2)] UUIScrollViewWithScrollbarComponent srcScrollView, NavigationGroup groupConfig, bool forceReturnNegative = false)
		{
			double num = 0.0;
			double num2 = double.MaxValue;
			double num3 = double.MaxValue;
			bool flag = false;
			TsUiNavigationBehaviorListener result = null;
			double num4 = 0.0;
			double num5 = double.MaxValue;
			double num6 = double.MinValue;
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = null;
			Vector vector = Vector.Create();
			Vector vector2 = Vector.Create();
			int i = 0;
			int num7 = listenerArray.Length;
			while (i < num7)
			{
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = listenerArray[i];
				if (tsUiNavigationBehaviorListener2.GetNavigationComponent().CheckFindOpposite() && !UiNavigationModeModule.CheckSkipByPriorityMode(srcScrollView, tsUiNavigationBehaviorListener2, priorityMode))
				{
					UiNavigationModeModule.GetComponentPosition(tsUiNavigationBehaviorListener2).Subtraction(srcPosition, vector);
					double num8 = vector.Size();
					vector2.DeepCopy(vector);
					vector2.Normalize(9.99999993922529E-09);
					double num9 = Vector.DotProduct(UiNavigationModeModule.TempValue, vector2);
					if (!Singleton<MathUtils>.Instance.IsNearlyEqual(num9, 0.0, new double?(0.0001)))
					{
						double num10 = isVertical ? Math.Abs(vector.Z) : Math.Abs(vector.X);
						if (num9 > 0.0)
						{
							bool flag2 = Singleton<MathUtils>.Instance.IsNearlyEqual(num9, 1.0, new double?(navigateTolerance));
							bool flag3 = Singleton<MathUtils>.Instance.IsNearlyEqual(num, 1.0, new double?(navigateTolerance));
							bool flag4 = false;
							bool flag5 = false;
							switch (priorityMode)
							{
							case UINavigationPriorityMode.Distance:
							case UINavigationPriorityMode.DistanceOnlySameScroll:
								flag5 = UiNavigationModeModule.IsInItemRange(vector, isVertical, tsUiNavigationBehaviorListener2);
								if (!flag5 || !flag)
								{
									if (UiNavigationModeModule.ReplaceBestByDistance(num8, num2))
									{
										flag4 = true;
									}
								}
								else if (Singleton<MathUtils>.Instance.IsNearlyEqual(num10, num3, new double?((double)1)))
								{
									if (UiNavigationModeModule.ReplaceBestByDistance(num8, num2))
									{
										flag4 = true;
									}
								}
								else if (num10 < num3)
								{
									flag4 = true;
								}
								break;
							case UINavigationPriorityMode.Direction:
								if (flag2 && num8 < num2)
								{
									flag4 = true;
								}
								break;
							case UINavigationPriorityMode.DistanceDirection:
								if (flag2)
								{
									if (!flag3 || (flag3 && num8 < num2))
									{
										flag4 = true;
									}
								}
								else if (!flag3 && num8 < num2)
								{
									flag4 = true;
								}
								break;
							case UINavigationPriorityMode.DirectionAngle:
								if (flag2)
								{
									if (!flag3)
									{
										flag4 = true;
									}
									else if (num9 > num)
									{
										flag4 = true;
									}
								}
								break;
							}
							if (flag4)
							{
								num = num9;
								num2 = num8;
								result = tsUiNavigationBehaviorListener2;
								num3 = num10;
								flag = flag5;
							}
						}
						else
						{
							bool flag6 = false;
							if (priorityMode == UINavigationPriorityMode.DistanceOnlySameScroll)
							{
								if (Singleton<MathUtils>.Instance.IsNearlyEqual(num10, num6, new double?((double)1)))
								{
									if (num8 < num5)
									{
										flag6 = true;
									}
								}
								else if (num10 > num6)
								{
									flag6 = true;
								}
							}
							else
							{
								bool flag7 = Singleton<MathUtils>.Instance.IsNearlyEqual(num9, -1.0, new double?(navigateToleranceReverse));
								bool flag8 = Singleton<MathUtils>.Instance.IsNearlyEqual(num4, -1.0, new double?(navigateToleranceReverse));
								if (flag7)
								{
									if (!flag8 || (flag8 && num8 > num5))
									{
										flag6 = true;
									}
								}
								else if (!flag8)
								{
									bool flag9 = Singleton<MathUtils>.Instance.IsNearlyEqual(num9, num4, null);
									if ((!flag9 && num9 < num4) || (flag9 && num8 > num5))
									{
										flag6 = true;
									}
								}
							}
							if (flag6)
							{
								num4 = num9;
								num6 = num10;
								num5 = num8;
								tsUiNavigationBehaviorListener = tsUiNavigationBehaviorListener2;
							}
						}
					}
				}
				i++;
			}
			if (forceReturnNegative && tsUiNavigationBehaviorListener != null)
			{
				UiNavigationModeModule.FindOppositeNavigationResult.IsOppositeNavigationPositive = false;
				return tsUiNavigationBehaviorListener;
			}
			if (!Singleton<MathUtils>.Instance.IsNearlyEqual(num, 0.0, null))
			{
				UiNavigationModeModule.FindOppositeNavigationResult.IsOppositeNavigationPositive = true;
				return result;
			}
			if (srcScrollView is UUIDynScrollViewComponent && !((UUIDynScrollViewComponent)srcScrollView).IsAllItemDisplayed())
			{
				return null;
			}
			if (wrapMode == UINavigationWrapMode.Wrap && UiNavigationModeModule.IsNeedReturnBestPick(verticalScrollValue, horizontalScrollValue, tsUiNavigationBehaviorListener, srcScrollView, groupConfig))
			{
				UiNavigationModeModule.FindOppositeNavigationResult.IsOppositeNavigationPositive = false;
				return tsUiNavigationBehaviorListener;
			}
			return null;
		}

		// Token: 0x0603331B RID: 209691 RVA: 0x00CD0F98 File Offset: 0x00CCF198
		[NullableContext(2)]
		private static bool IsNeedReturnBestPick(float verticalScrollValue, float horizontalScrollValue, TsUiNavigationBehaviorListener negativeBestPick, UUIScrollViewWithScrollbarComponent scrollView, [Nullable(1)] NavigationGroup groupConfig)
		{
			bool flag;
			if (negativeBestPick == null)
			{
				flag = (null != null);
			}
			else
			{
				UiNavigationScrollProxy scrollProxy = negativeBestPick.ScrollProxy;
				flag = (((scrollProxy != null) ? scrollProxy.ScrollView : null) != null);
			}
			if (!flag || scrollView == null)
			{
				return true;
			}
			if (scrollView is UUIDynScrollViewComponent)
			{
				return true;
			}
			if (scrollView.CheckContentUnderSize())
			{
				return true;
			}
			if (scrollView.Horizontal && UiNavigationModeModule.TempValue.X != 0.0)
			{
				bool flag2 = UiNavigationModeModule.TempValue.X > 0.0;
				return (horizontalScrollValue >= 0.9999f || !flag2 || groupConfig == null || !groupConfig.SlideToRightOrDown) && (horizontalScrollValue <= 0.0001f || flag2 || groupConfig == null || !groupConfig.SlideToLeftOrTop);
			}
			if (scrollView.Vertical && UiNavigationModeModule.TempValue.Z != 0.0)
			{
				bool flag3 = UiNavigationModeModule.TempValue.Z < 0.0;
				return (verticalScrollValue >= 0.9999f || !flag3 || groupConfig == null || !groupConfig.SlideToRightOrDown) && (verticalScrollValue <= 0.0001f || flag3 || groupConfig == null || !groupConfig.SlideToLeftOrTop);
			}
			return true;
		}

		// Token: 0x0603331C RID: 209692 RVA: 0x00CD10B4 File Offset: 0x00CCF2B4
		[return: Nullable(2)]
		public static TsUiNavigationBehaviorListener FindDynamicScrollViewNavigationComponent(NavigationDynamicScrollViewFindContext context)
		{
			if (context.NextType == EDynamicScrollViewFindNextType.None)
			{
				NavigationGroup groupConfig = context.GroupConfig;
				UUIDynScrollViewComponent uuidynScrollViewComponent = context.ScrollView as UUIDynScrollViewComponent;
				List<TsUiNavigationBehaviorListener> oppositeListenerListByListener = groupConfig.GetOppositeListenerListByListener(uuidynScrollViewComponent.GetOwner(), null);
				return UiNavigationModeModule.FindOppositeNavigationComponent(context.IsScrollToEdge ? context.LastListenerPosition : UiNavigationModeModule.GetComponentPosition(context.LastListener), oppositeListenerListByListener.ToArray(), context.WrapMode, context.PriorityMode, context.IsVertical, context.NavigateTolerance, context.NavigateToleranceReverse, context.VerticalScrollValue, context.HorizontalScrollValue, uuidynScrollViewComponent, context.GroupConfig, context.NegativeDirection);
			}
			if (context.NeedWaitScroll)
			{
				return null;
			}
			List<TsUiNavigationBehaviorListener> listenerListenerList = UiNavigationModeModule.GetListenerListenerList(context.LastListener);
			int num = context.IsScrollToEdge ? -1 : listenerListenerList.IndexOf(context.LastListener);
			if (context.NextType == EDynamicScrollViewFindNextType.ToNext)
			{
				int num2 = (num == -1) ? 0 : (num + 1);
				for (int i = num2; i < listenerListenerList.Count; i++)
				{
					TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = listenerListenerList[i];
					if (tsUiNavigationBehaviorListener.IsCanFocus())
					{
						return tsUiNavigationBehaviorListener;
					}
				}
				for (int j = 0; j < num2; j++)
				{
					TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = listenerListenerList[j];
					if (tsUiNavigationBehaviorListener2.IsCanFocus())
					{
						return tsUiNavigationBehaviorListener2;
					}
				}
			}
			else
			{
				int num3 = (num == -1) ? (listenerListenerList.Count - 1) : (num - 1);
				for (int k = num3; k >= 0; k--)
				{
					TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener3 = listenerListenerList[k];
					if (tsUiNavigationBehaviorListener3.IsCanFocus())
					{
						return tsUiNavigationBehaviorListener3;
					}
				}
				for (int l = listenerListenerList.Count - 1; l > num3; l--)
				{
					TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener4 = listenerListenerList[l];
					if (tsUiNavigationBehaviorListener4.IsCanFocus())
					{
						return tsUiNavigationBehaviorListener4;
					}
				}
			}
			return null;
		}

		// Token: 0x0603331D RID: 209693 RVA: 0x00CD124A File Offset: 0x00CCF44A
		[NullableContext(2)]
		private UUISelectableComponent FindNavigationComponentByMultiTemplateScrollView(UINavigationWrapMode wrapMode, UINavigationPriorityMode priorityMode, bool isVertical)
		{
			return this.Listener.GetNavigationComponent().FindMultiTemplateScrollViewNavigationComponent(UiNavigationModeModule.TempValue.ToUeVectorOld(), wrapMode, priorityMode, this.Direction, this.NavigateTolerance, this.NavigateToleranceReverse);
		}

		// Token: 0x0603331E RID: 209694 RVA: 0x00CD127C File Offset: 0x00CCF47C
		[NullableContext(2)]
		private UUISelectableComponent FindNavigationComponentOld(UINavigationWrapMode wrapMode, UINavigationPriorityMode priorityMode, bool isVertical)
		{
			UUISelectableComponent uuiselectableComponent = this.Listener.GetNavigationComponent().FindLoopScrollViewNavigationComponent(UiNavigationModeModule.TempValue.ToUeVectorOld(), wrapMode);
			if (uuiselectableComponent == null)
			{
				NavigationGroup navigationGroup = this.Listener.GetNavigationGroup();
				UiNavigationScrollProxy scrollProxy = this.Listener.ScrollProxy;
				UUIScrollViewWithScrollbarComponent uuiscrollViewWithScrollbarComponent = (scrollProxy != null) ? scrollProxy.ScrollView : null;
				AActor scrollViewActor = this.Listener.ScrollViewActor;
				AActor layoutActor = this.Listener.LayoutActor;
				List<TsUiNavigationBehaviorListener> oppositeListenerListByListener = navigationGroup.GetOppositeListenerListByListener(scrollViewActor, layoutActor);
				List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
				for (int i = 0; i < oppositeListenerListByListener.Count; i++)
				{
					TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = oppositeListenerListByListener[i];
					if (tsUiNavigationBehaviorListener != this.Listener)
					{
						list.Add(tsUiNavigationBehaviorListener);
					}
				}
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = UiNavigationModeModule.FindOppositeNavigationComponent(UiNavigationModeModule.GetComponentPosition(this.Listener), list.ToArray(), wrapMode, priorityMode, isVertical, (double)this.NavigateTolerance, (double)this.NavigateToleranceReverse, (uuiscrollViewWithScrollbarComponent != null) ? uuiscrollViewWithScrollbarComponent.Progress.Y : 0f, (uuiscrollViewWithScrollbarComponent != null) ? uuiscrollViewWithScrollbarComponent.Progress.X : 0f, uuiscrollViewWithScrollbarComponent, navigationGroup, false);
				TsUiNavigationPanelConfig panelConfig = this.Listener.PanelConfig;
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener3 = (panelConfig != null) ? panelConfig.HandleAfterFindOpposite(this.Direction, this.Listener, tsUiNavigationBehaviorListener2, UiNavigationModeModule.FindOppositeNavigationResult.IsOppositeNavigationPositive) : null;
				uuiselectableComponent = ((tsUiNavigationBehaviorListener3 != null) ? tsUiNavigationBehaviorListener3.GetSelectableComponent() : null);
				if (tsUiNavigationBehaviorListener2 == null && this.Listener.HasDynamicScrollView())
				{
					this.CreateDynamicNavigationContext(isVertical, wrapMode, priorityMode, navigationGroup, EDynamicScrollViewFindNextType.None);
				}
			}
			return uuiselectableComponent;
		}

		// Token: 0x0603331F RID: 209695 RVA: 0x00CD13DE File Offset: 0x00CCF5DE
		[NullableContext(2)]
		private UUISelectableComponent FindNavigationComponentByMode(UINavigationWrapMode wrapMode, UINavigationPriorityMode priorityMode, bool isVertical)
		{
			if (this.Listener.HasMultiTemplateScrollView())
			{
				return this.FindNavigationComponentByMultiTemplateScrollView(wrapMode, priorityMode, isVertical);
			}
			return this.FindNavigationComponentOld(wrapMode, priorityMode, isVertical);
		}

		// Token: 0x06033320 RID: 209696 RVA: 0x00CD1400 File Offset: 0x00CCF600
		[return: TupleElementNames(new string[]
		{
			"NeedScrollToIndex",
			"NeedScrollNext",
			"IsReversed",
			"IsNegativeDirection"
		})]
		[return: Nullable(0)]
		private ValueTuple<int, bool, bool, bool> GetFindContextData(UUIDynScrollViewComponent scroll, NavigationGroup groupConfig, bool isPositive)
		{
			int totalItemNum = scroll.TotalItemNum;
			int startItemIndex = scroll.GetStartItemIndex();
			int endItemIndex = scroll.GetEndItemIndex();
			bool item = false;
			bool item2 = false;
			bool item3 = false;
			int item4;
			if (endItemIndex == totalItemNum - 1 && isPositive)
			{
				bool flag = scroll.IsItemInViewportEdgeByIndex(totalItemNum - 1);
				if (groupConfig.SlideToRightOrDown && !flag)
				{
					item4 = totalItemNum - 1;
				}
				else
				{
					item4 = 0;
					item3 = true;
					item2 = true;
				}
			}
			else if (startItemIndex == 0 && !isPositive)
			{
				bool flag2 = scroll.IsItemInViewportEdgeByIndex(0);
				if (groupConfig.SlideToLeftOrTop && !flag2)
				{
					item4 = 0;
				}
				else
				{
					item4 = totalItemNum - 1;
					item3 = true;
					item2 = false;
				}
			}
			else
			{
				item = true;
				item4 = (isPositive ? (endItemIndex + 1) : (startItemIndex - 1));
				item2 = !isPositive;
			}
			return new ValueTuple<int, bool, bool, bool>(item4, item, item2, item3);
		}

		// Token: 0x06033321 RID: 209697 RVA: 0x00CD14AC File Offset: 0x00CCF6AC
		private void CreateDynamicNavigationContext(bool isVertical, UINavigationWrapMode wrapMode, UINavigationPriorityMode priorityMode, NavigationGroup groupConfig, EDynamicScrollViewFindNextType nextType)
		{
			if (!this.Listener.HasDynamicScrollView())
			{
				return;
			}
			UiNavigationScrollProxy scrollProxy = this.Listener.ScrollProxy;
			UUIDynScrollViewComponent uuidynScrollViewComponent = ((scrollProxy != null) ? scrollProxy.ScrollView : null) as UUIDynScrollViewComponent;
			if (uuidynScrollViewComponent != null && isVertical != uuidynScrollViewComponent.Vertical && wrapMode == UINavigationWrapMode.None)
			{
				return;
			}
			if (!uuidynScrollViewComponent.IsAllItemDisplayed())
			{
				bool isPositive = isVertical ? (UiNavigationModeModule.TempValue.Z < 0.0) : (UiNavigationModeModule.TempValue.X > 0.0);
				ValueTuple<int, bool, bool, bool> findContextData = this.GetFindContextData(uuidynScrollViewComponent, groupConfig, isPositive);
				Vector componentPosition = UiNavigationModeModule.GetComponentPosition(this.Listener);
				NavigationDynamicScrollViewFindContext navigationDynamicScrollViewFindContext = new NavigationDynamicScrollViewFindContext();
				navigationDynamicScrollViewFindContext.LastListenerPosition = componentPosition;
				navigationDynamicScrollViewFindContext.WrapMode = wrapMode;
				navigationDynamicScrollViewFindContext.IsVertical = isVertical;
				navigationDynamicScrollViewFindContext.PriorityMode = priorityMode;
				navigationDynamicScrollViewFindContext.ScrollView = uuidynScrollViewComponent;
				navigationDynamicScrollViewFindContext.GroupConfig = groupConfig;
				navigationDynamicScrollViewFindContext.NavigateTolerance = (double)this.NavigateTolerance;
				navigationDynamicScrollViewFindContext.NavigateToleranceReverse = (double)this.NavigateToleranceReverse;
				navigationDynamicScrollViewFindContext.NegativeDirection = findContextData.Item4;
				navigationDynamicScrollViewFindContext.Reversed = findContextData.Item3;
				navigationDynamicScrollViewFindContext.LastListener = this.Listener;
				navigationDynamicScrollViewFindContext.NextType = nextType;
				navigationDynamicScrollViewFindContext.NeedWaitScroll = findContextData.Item2;
				navigationDynamicScrollViewFindContext.IsScrollToEdge = !findContextData.Item2;
				NavigationDynamicScrollViewFindContext navigationDynamicScrollViewFindContext2 = navigationDynamicScrollViewFindContext;
				UUIScrollbarComponent uuiscrollbarComponent = uuidynScrollViewComponent.VerticalScrollbarComp.Get();
				navigationDynamicScrollViewFindContext2.VerticalScrollValue = ((uuiscrollbarComponent != null) ? uuiscrollbarComponent.Value : 0f);
				NavigationDynamicScrollViewFindContext navigationDynamicScrollViewFindContext3 = navigationDynamicScrollViewFindContext;
				UUIScrollbarComponent uuiscrollbarComponent2 = uuidynScrollViewComponent.HorizontalScrollbarComp.Get();
				navigationDynamicScrollViewFindContext3.HorizontalScrollValue = ((uuiscrollbarComponent2 != null) ? uuiscrollbarComponent2.Value : 0f);
				if (isVertical == uuidynScrollViewComponent.Vertical || findContextData.Item4)
				{
					TsUiNavigationPanelConfig panelConfig = this.Listener.PanelConfig;
					if (panelConfig != null)
					{
						panelConfig.MarkToFindDynamicGrid(navigationDynamicScrollViewFindContext);
					}
				}
				float offset = isVertical ? this.Listener.RootUIComp.Get().Height : this.Listener.RootUIComp.Get().Width;
				uuidynScrollViewComponent.ScrollToItemIndexForNavigation(findContextData.Item1, findContextData.Item3, offset);
			}
		}

		// Token: 0x06033322 RID: 209698 RVA: 0x00CD16AF File Offset: 0x00CCF8AF
		private static List<TsUiNavigationBehaviorListener> GetListenerListenerList(TsUiNavigationBehaviorListener listener)
		{
			if (listener.HasDynamicScrollView())
			{
				return ControllerBase<UiNavigationNewController>.Instance.GetDynamicScrollListenerListByListener(listener);
			}
			return listener.GetNavigationGroup().ListenerList;
		}

		// Token: 0x06033323 RID: 209699 RVA: 0x00CD16D0 File Offset: 0x00CCF8D0
		[NullableContext(2)]
		private UUISelectableComponent GetNextNavigationComponent(bool isVertical, UINavigationWrapMode wrapMode, UINavigationPriorityMode priorityMode)
		{
			if (this.Listener.HasMultiTemplateScrollView())
			{
				UiNavigationModeModule.TempValue.Set(1.0, 0.0, 0.0);
				return this.Listener.GetNavigationComponent().FindMultiTemplateScrollViewNavigationComponent(UiNavigationModeModule.TempValue.ToUeVectorOld(), UINavigationWrapMode.Next, priorityMode, this.Direction, this.NavigateTolerance, this.NavigateToleranceReverse);
			}
			if (this.Listener.HasLoopScrollView())
			{
				UiNavigationModeModule.TempValue.Set(1.0, 0.0, 0.0);
				UUISelectableComponent uuiselectableComponent = this.Listener.ScrollProxy.ScrollView.FindNavigationComponent(this.Listener.GetSelectableComponent(), UiNavigationModeModule.TempValue.ToUeVectorOld(), UINavigationWrapMode.Next, false);
				if (uuiselectableComponent != null)
				{
					return uuiselectableComponent;
				}
			}
			List<TsUiNavigationBehaviorListener> listenerListenerList = UiNavigationModeModule.GetListenerListenerList(this.Listener);
			int count = listenerListenerList.Count;
			if (count <= 0)
			{
				return this.Listener.GetSelectableComponent();
			}
			int num = listenerListenerList.IndexOf(this.Listener);
			if (num == -1)
			{
				return null;
			}
			for (int i = num + 1; i < count; i++)
			{
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = listenerListenerList[i];
				if (tsUiNavigationBehaviorListener.IsCanFocus())
				{
					UiNavigationModeModule.FindOppositeNavigationResult.IsOppositeNavigationPositive = true;
					return tsUiNavigationBehaviorListener.GetSelectableComponent();
				}
			}
			if (this.Listener.HasDynamicScrollView())
			{
				UiNavigationScrollProxy scrollProxy = this.Listener.ScrollProxy;
				if (!(((scrollProxy != null) ? scrollProxy.ScrollView : null) as UUIDynScrollViewComponent).IsAllItemDisplayed())
				{
					UiNavigationModeModule.FindOppositeNavigationResult.IsOppositeNavigationPositive = false;
					this.CreateDynamicNavigationContext(isVertical, wrapMode, priorityMode, this.Listener.GetNavigationGroup(), EDynamicScrollViewFindNextType.ToNext);
					return null;
				}
			}
			for (int j = 0; j < num; j++)
			{
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = listenerListenerList[j];
				if (tsUiNavigationBehaviorListener2.IsCanFocus())
				{
					UiNavigationModeModule.FindOppositeNavigationResult.IsOppositeNavigationPositive = false;
					return tsUiNavigationBehaviorListener2.GetSelectableComponent();
				}
			}
			return null;
		}

		// Token: 0x06033324 RID: 209700 RVA: 0x00CD189C File Offset: 0x00CCFA9C
		[NullableContext(2)]
		private UUISelectableComponent GetPrevNavigationComponent(bool isVertical, UINavigationWrapMode wrapMode, UINavigationPriorityMode priorityMode)
		{
			if (this.Listener.HasMultiTemplateScrollView())
			{
				UiNavigationModeModule.TempValue.Set(-1.0, 0.0, 0.0);
				return this.Listener.GetNavigationComponent().FindMultiTemplateScrollViewNavigationComponent(UiNavigationModeModule.TempValue.ToUeVectorOld(), UINavigationWrapMode.Next, priorityMode, this.Direction, this.NavigateTolerance, this.NavigateToleranceReverse);
			}
			if (this.Listener.HasLoopScrollView())
			{
				UiNavigationModeModule.TempValue.Set(-1.0, 0.0, 0.0);
				UUISelectableComponent uuiselectableComponent = this.Listener.ScrollProxy.ScrollView.FindNavigationComponent(this.Listener.GetSelectableComponent(), UiNavigationModeModule.TempValue.ToUeVectorOld(), UINavigationWrapMode.Next, false);
				if (uuiselectableComponent != null)
				{
					return uuiselectableComponent;
				}
			}
			List<TsUiNavigationBehaviorListener> listenerListenerList = UiNavigationModeModule.GetListenerListenerList(this.Listener);
			int count = listenerListenerList.Count;
			if (count <= 0)
			{
				return this.Listener.GetSelectableComponent();
			}
			int num = listenerListenerList.IndexOf(this.Listener);
			if (num == -1)
			{
				return null;
			}
			for (int i = num - 1; i >= 0; i--)
			{
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = listenerListenerList[i];
				if (tsUiNavigationBehaviorListener.IsCanFocus())
				{
					UiNavigationModeModule.FindOppositeNavigationResult.IsOppositeNavigationPositive = true;
					return tsUiNavigationBehaviorListener.GetSelectableComponent();
				}
			}
			if (this.Listener.HasDynamicScrollView())
			{
				UiNavigationScrollProxy scrollProxy = this.Listener.ScrollProxy;
				if (!(((scrollProxy != null) ? scrollProxy.ScrollView : null) as UUIDynScrollViewComponent).IsAllItemDisplayed())
				{
					UiNavigationModeModule.FindOppositeNavigationResult.IsOppositeNavigationPositive = false;
					this.CreateDynamicNavigationContext(isVertical, wrapMode, priorityMode, this.Listener.GetNavigationGroup(), EDynamicScrollViewFindNextType.ToPrev);
					return null;
				}
			}
			for (int j = count - 1; j > num; j--)
			{
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = listenerListenerList[j];
				if (tsUiNavigationBehaviorListener2.IsCanFocus())
				{
					UiNavigationModeModule.FindOppositeNavigationResult.IsOppositeNavigationPositive = false;
					return tsUiNavigationBehaviorListener2.GetSelectableComponent();
				}
			}
			return null;
		}

		// Token: 0x06033325 RID: 209701 RVA: 0x00CD1A68 File Offset: 0x00CCFC68
		[return: Nullable(2)]
		private UUISelectableComponent FindNavigationComponent(NavigationGroup groupConfig)
		{
			if (Math.Abs(UiNavigationModeModule.TempValue.X) >= Math.Abs(UiNavigationModeModule.TempValue.Z))
			{
				UINavigationWrapMode uinavigationWrapMode = groupConfig.HorizontalWrapMode;
				if (uinavigationWrapMode <= UINavigationWrapMode.Wrap)
				{
					UiNavigationModeModule.TempValue.Set((double)Math.Sign(UiNavigationModeModule.TempValue.X), 0.0, 0.0);
					return this.FindNavigationComponentByMode(groupConfig.HorizontalWrapMode, groupConfig.HorizontalPriorityMode, false);
				}
				if (uinavigationWrapMode != UINavigationWrapMode.Next)
				{
					return null;
				}
				if (UiNavigationModeModule.TempValue.X > 0.0)
				{
					return this.GetNextNavigationComponent(false, groupConfig.HorizontalWrapMode, groupConfig.HorizontalPriorityMode);
				}
				return this.GetPrevNavigationComponent(false, groupConfig.HorizontalWrapMode, groupConfig.HorizontalPriorityMode);
			}
			else
			{
				UINavigationWrapMode uinavigationWrapMode = groupConfig.VerticalWrapMode;
				if (uinavigationWrapMode <= UINavigationWrapMode.Wrap)
				{
					UiNavigationModeModule.TempValue.Set(0.0, 0.0, (double)Math.Sign(UiNavigationModeModule.TempValue.Z));
					return this.FindNavigationComponentByMode(groupConfig.VerticalWrapMode, groupConfig.VerticalPriorityMode, true);
				}
				if (uinavigationWrapMode != UINavigationWrapMode.Next)
				{
					return null;
				}
				if (UiNavigationModeModule.TempValue.Z < 0.0)
				{
					return this.GetNextNavigationComponent(true, groupConfig.VerticalWrapMode, groupConfig.VerticalPriorityMode);
				}
				return this.GetPrevNavigationComponent(true, groupConfig.VerticalWrapMode, groupConfig.VerticalPriorityMode);
			}
		}

		// Token: 0x06033326 RID: 209702 RVA: 0x00CD1BB4 File Offset: 0x00CCFDB4
		[NullableContext(2)]
		private AActor GetNavigationModeActor(ELGUINavigationDirection direction)
		{
			if (direction == ELGUINavigationDirection.Up)
			{
				return this.Listener.NavigationMode.TopActor;
			}
			if (direction == ELGUINavigationDirection.Down)
			{
				return this.Listener.NavigationMode.DownActor;
			}
			if (direction == ELGUINavigationDirection.Left)
			{
				return this.Listener.NavigationMode.LeftActor;
			}
			if (direction == ELGUINavigationDirection.Right)
			{
				return this.Listener.NavigationMode.RightActor;
			}
			return null;
		}

		// Token: 0x06033327 RID: 209703 RVA: 0x00CD1C18 File Offset: 0x00CCFE18
		private EUISelectableNavigationMode? GetNavigationMode(ELGUINavigationDirection direction)
		{
			if (direction == ELGUINavigationDirection.Up)
			{
				return new EUISelectableNavigationMode?(this.Listener.NavigationMode.TopMode);
			}
			if (direction == ELGUINavigationDirection.Down)
			{
				return new EUISelectableNavigationMode?(this.Listener.NavigationMode.DownMode);
			}
			if (direction == ELGUINavigationDirection.Left)
			{
				return new EUISelectableNavigationMode?(this.Listener.NavigationMode.LeftMode);
			}
			if (direction == ELGUINavigationDirection.Right)
			{
				return new EUISelectableNavigationMode?(this.Listener.NavigationMode.RightMode);
			}
			return null;
		}

		// Token: 0x06033328 RID: 209704 RVA: 0x00CD1C98 File Offset: 0x00CCFE98
		private void HandleTempValue(ELGUINavigationDirection direction)
		{
			this.Direction = direction;
			if (direction == ELGUINavigationDirection.Up)
			{
				FVectorDouble fvectorDouble = this.Listener.GetRootComponent().D_GetRightVector();
				UiNavigationModeModule.TempValue.Set(fvectorDouble.X, fvectorDouble.Y, fvectorDouble.Z);
			}
			if (direction == ELGUINavigationDirection.Down)
			{
				FVectorDouble fvectorDouble2 = this.Listener.GetRootComponent().D_GetRightVector();
				UiNavigationModeModule.TempValue.Set(-fvectorDouble2.X, -fvectorDouble2.Y, -fvectorDouble2.Z);
			}
			if (direction == ELGUINavigationDirection.Left)
			{
				FVectorDouble fvectorDouble3 = this.Listener.GetRootComponent().D_GetForwardVector();
				UiNavigationModeModule.TempValue.Set(-fvectorDouble3.X, -fvectorDouble3.Y, -fvectorDouble3.Z);
			}
			if (direction == ELGUINavigationDirection.Right)
			{
				FVectorDouble fvectorDouble4 = this.Listener.GetRootComponent().D_GetForwardVector();
				UiNavigationModeModule.TempValue.Set(fvectorDouble4.X, fvectorDouble4.Y, fvectorDouble4.Z);
			}
		}

		// Token: 0x06033329 RID: 209705 RVA: 0x00CD1D78 File Offset: 0x00CCFF78
		[NullableContext(2)]
		private UUISelectableComponent FindSelectable()
		{
			UUIItem uuiitem = this.Listener.RootUIComp.Get();
			if (uuiitem == null)
			{
				return null;
			}
			ULGUICanvas renderCanvas = uuiitem.GetRenderCanvas();
			if (renderCanvas == null || renderCanvas.GetRootCanvas() == null)
			{
				return null;
			}
			if (uuiitem.IsScreenSpaceOverlayUI())
			{
				USceneComponent rootComponent = uuiitem.GetRootCanvas().GetOwner().RootComponent;
				return this.FindSelectableByCanvas(rootComponent);
			}
			return this.FindSelectableByCanvas(null);
		}

		// Token: 0x0603332A RID: 209706 RVA: 0x00CD1DDC File Offset: 0x00CCFFDC
		[NullableContext(2)]
		private UUISelectableComponent FindSelectableByCanvas(USceneComponent inParent)
		{
			UiNavigationModeModule.TempValue.Normalize(0.0);
			NavigationGroup navigationGroup = this.Listener.GetNavigationGroup();
			if (navigationGroup != null)
			{
				return this.FindNavigationComponent(navigationGroup);
			}
			Vector componentPosition = UiNavigationModeModule.GetComponentPosition(this.Listener);
			double num = double.MinValue;
			UUISelectableComponent selectableComponent = this.Listener.GetSelectableComponent();
			TArray<UActorComponent> componentsInChildren = ULGUIBPLibrary.GetComponentsInChildren(inParent.GetOwner(), TsUiNavigationBehaviorListener.StaticClass(), false);
			int i = 0;
			int num2 = componentsInChildren.Num();
			while (i < num2)
			{
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = componentsInChildren.Get(i) as TsUiNavigationBehaviorListener;
				if (!(tsUiNavigationBehaviorListener.GroupName != this.Listener.GroupName) && tsUiNavigationBehaviorListener.IsCanFocus())
				{
					Vector componentPosition2 = UiNavigationModeModule.GetComponentPosition(tsUiNavigationBehaviorListener);
					componentPosition2.Subtraction(componentPosition, componentPosition2);
					double num3 = Vector.DotProduct(UiNavigationModeModule.TempValue, componentPosition2);
					if (num3 > 0.1)
					{
						double num4 = num3 / componentPosition2.SizeSquared();
						if (num4 > num)
						{
							num = num4;
							selectableComponent = tsUiNavigationBehaviorListener.GetSelectableComponent();
						}
					}
				}
				i++;
			}
			return selectableComponent;
		}

		// Token: 0x0603332B RID: 209707 RVA: 0x00CD1EEC File Offset: 0x00CD00EC
		private static Vector GetComponentPosition(TsUiNavigationBehaviorListener listener)
		{
			FVector2D localSpaceCenter = listener.GetRootComponent().GetLocalSpaceCenter();
			Vector vector = Vector.Create((double)localSpaceCenter.X, (double)localSpaceCenter.Y, 0.0);
			Transform.Create(listener.GetRootSceneComponent().D_K2_GetComponentToWorld()).TransformPosition(vector, vector);
			return vector;
		}

		// Token: 0x0603332C RID: 209708 RVA: 0x00CD1F40 File Offset: 0x00CD0140
		[NullableContext(2)]
		public USceneComponent FindActorByDirection(ELGUINavigationDirection direction, bool bCheckSelfActive = true)
		{
			EUISelectableNavigationMode? navigationMode = this.GetNavigationMode(direction);
			EUISelectableNavigationMode? euiselectableNavigationMode = navigationMode;
			EUISelectableNavigationMode euiselectableNavigationMode2 = EUISelectableNavigationMode.Explicit;
			if (euiselectableNavigationMode.GetValueOrDefault() == euiselectableNavigationMode2 & euiselectableNavigationMode != null)
			{
				UUIItem uuiitem = this.Listener.RootUIComp.Get();
				if (bCheckSelfActive && !uuiitem.IsUIActiveInHierarchy())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiNavigation;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "当前选中的导航监听组件按钮不可视";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DisplayName", uuiitem.displayName);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return null;
				}
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = this.GetNavigationModeActor(direction).GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) as TsUiNavigationBehaviorListener;
				if (tsUiNavigationBehaviorListener == null || tsUiNavigationBehaviorListener.IsCanFocus())
				{
					return tsUiNavigationBehaviorListener.GetBehaviorComponent().GetRootSceneComponent();
				}
				UiNavigationModeModule modeModule = tsUiNavigationBehaviorListener.ModeModule;
				if (modeModule == null)
				{
					return null;
				}
				return modeModule.FindActorByDirection(direction, false);
			}
			else
			{
				euiselectableNavigationMode = navigationMode;
				euiselectableNavigationMode2 = EUISelectableNavigationMode.Auto;
				if (!(euiselectableNavigationMode.GetValueOrDefault() == euiselectableNavigationMode2 & euiselectableNavigationMode != null))
				{
					return null;
				}
				this.HandleTempValue(direction);
				UUISelectableComponent uuiselectableComponent = this.FindSelectable();
				if (uuiselectableComponent == null)
				{
					return null;
				}
				return uuiselectableComponent.GetRootSceneComponent();
			}
		}

		// Token: 0x0603332D RID: 209709 RVA: 0x00CD2042 File Offset: 0x00CD0242
		public static void CreateStaticDefaultValue()
		{
			UiNavigationModeModule._tempValue = Vector.Create();
			UiNavigationModeModule._findOppositeNavigationResult = new FindOppositeNavigationResult();
		}

		// Token: 0x0603332E RID: 209710 RVA: 0x00CD2058 File Offset: 0x00CD0258
		public static void ResetStaticDefaultValue()
		{
			UiNavigationModeModule._tempValue = null;
			UiNavigationModeModule._findOppositeNavigationResult = null;
		}

		// Token: 0x0401DC04 RID: 121860
		private readonly TsUiNavigationBehaviorListener Listener;

		// Token: 0x0401DC05 RID: 121861
		private readonly float NavigateTolerance = 1E-08f;

		// Token: 0x0401DC06 RID: 121862
		private readonly float NavigateToleranceReverse = 0.0001f;

		// Token: 0x0401DC07 RID: 121863
		private ELGUINavigationDirection Direction;

		// Token: 0x0401DC08 RID: 121864
		[Nullable(2)]
		private static Vector _tempValue;

		// Token: 0x0401DC09 RID: 121865
		[Nullable(2)]
		public static FindOppositeNavigationResult _findOppositeNavigationResult;
	}
}
