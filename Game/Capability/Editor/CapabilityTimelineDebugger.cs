using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.Capability.Editor
{
	// Token: 0x0200707C RID: 28796
	[NullableContext(1)]
	[Nullable(0)]
	public class CapabilityTimelineDebugger : IStaticVariableResetter
	{
		// Token: 0x06045C9C RID: 285852 RVA: 0x012422B8 File Offset: 0x012404B8
		static CapabilityTimelineDebugger()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CapabilityTimelineDebugger.CreateStaticDefaultValue), new Action(CapabilityTimelineDebugger.ResetStaticDefaultValue));
		}

		// Token: 0x06045C9D RID: 285853 RVA: 0x01242364 File Offset: 0x01240564
		public CapabilityTimelineDebugger(CapabilityDebugger Debugger)
		{
			this.Debugger = Debugger;
		}

		// Token: 0x06045C9E RID: 285854 RVA: 0x01242418 File Offset: 0x01240618
		private static void ApplyFontConfig(UTextBlock tb, FontConfig cfg)
		{
			tb.Font.Size = cfg.Size;
			if (cfg.Typeface.Length > 0)
			{
				tb.Font.TypefaceFontName = FNameUtil.GetDynamicFName(cfg.Typeface).Value;
			}
			tb.Font.LetterSpacing = cfg.LetterSpacing;
			tb.SetColorAndOpacity(new FSlateColor(cfg.Color, ESlateColorStylingMode.UseColor_Specified));
		}

		// Token: 0x06045C9F RID: 285855 RVA: 0x0124248C File Offset: 0x0124068C
		public void Show()
		{
			if (this.RootWidget != null)
			{
				return;
			}
			this.RootWidget = this.BuildWidget();
			if (this.RootWidget == null)
			{
				return;
			}
			APlayerController playerController = UGameplayStatics.GetPlayerController(GlobalData.World, 0);
			if (playerController != null)
			{
				this.RootWidget.SetOwningPlayer(playerController);
			}
			this.RootWidget.AddToViewport(1000);
			this.TickHandle = TimerSystem.Instance.Forever(delegate(float _)
			{
				this.Redraw();
			}, 100f, 1f, null, "CapabilityTimelineDebugger.Redraw", true);
		}

		// Token: 0x06045CA0 RID: 285856 RVA: 0x01242510 File Offset: 0x01240710
		public void Hide()
		{
			if (this.TickHandle != null)
			{
				this.TickHandle.Remove();
				this.TickHandle = null;
			}
			if (this.RootWidget != null)
			{
				this.RootWidget.RemoveFromParent();
				this.RootWidget = null;
				this.WidgetTree = null;
				this.Canvas = null;
				this.CursorSlot = null;
				this.NowLabel = null;
				this.NowLabelText = "";
				this.CursorTimeLabel = null;
				this.CursorTimeLabelSlot = null;
				this.CursorTimeLabelText = "";
			}
			this.Rows.Clear();
			this.SpanBuckets.Clear();
			this.EventBuckets.Clear();
			this.IdToRowIndex.Clear();
			this.RowIds.Clear();
			this.Ticks.Clear();
			this.TickSlots.Clear();
			this.TickLabels.Clear();
			this.TickLabelSlots.Clear();
			this.TickLabelTexts.Clear();
			this.UsedTicks = 0;
			this.UsedTickLabels = 0;
		}

		// Token: 0x06045CA1 RID: 285857 RVA: 0x0124260E File Offset: 0x0124080E
		public bool IsVisible()
		{
			return this.RootWidget != null;
		}

		// Token: 0x06045CA2 RID: 285858 RVA: 0x01242619 File Offset: 0x01240819
		public void SetZoom(float zoom)
		{
			if ((double)zoom > 0.05 && zoom < 50f)
			{
				this.Zoom = zoom;
			}
		}

		// Token: 0x06045CA3 RID: 285859 RVA: 0x01242637 File Offset: 0x01240837
		public void SetWindowSeconds(float s)
		{
			if (s >= 1f && s <= 600f)
			{
				this.WindowSeconds = s;
			}
		}

		// Token: 0x06045CA4 RID: 285860 RVA: 0x01242650 File Offset: 0x01240850
		[NullableContext(2)]
		private UUserWidget BuildWidget()
		{
			return null;
		}

		// Token: 0x06045CA5 RID: 285861 RVA: 0x01242654 File Offset: 0x01240854
		private void BuildLegend(UCanvasPanel canvas)
		{
			UWidgetTree widgetTree = this.WidgetTree;
			int num = 28;
			for (int i = 0; i < CapabilityTimelineDebugger.legendEntries.Count; i++)
			{
				ValueTuple<FLinearColor, string> valueTuple = CapabilityTimelineDebugger.legendEntries[i];
				FLinearColor item = valueTuple.Item1;
				string item2 = valueTuple.Item2;
				int num2 = 8 + i * 110;
				UImage uimage = new UImage(widgetTree, null, EObjectFlags.RF_NoFlags);
				uimage.SetColorAndOpacity(item);
				UCanvasPanelSlot ucanvasPanelSlot = canvas.AddChildToCanvas(uimage);
				if (ucanvasPanelSlot != null)
				{
					ucanvasPanelSlot.SetPosition(new FVector2D((float)num2, (float)(num + 4)));
					ucanvasPanelSlot.SetSize(new FVector2D(12f, 10f));
				}
				UTextBlock utextBlock = new UTextBlock(widgetTree, null, EObjectFlags.RF_NoFlags);
				utextBlock.SetText(item2);
				CapabilityTimelineDebugger.ApplyFontConfig(utextBlock, CapabilityTimelineDebugger.legendFontConfig);
				UCanvasPanelSlot ucanvasPanelSlot2 = canvas.AddChildToCanvas(utextBlock);
				if (ucanvasPanelSlot2 != null)
				{
					ucanvasPanelSlot2.SetPosition(new FVector2D((float)(num2 + 12 + 4), (float)num));
					ucanvasPanelSlot2.SetSize(new FVector2D(92f, 18f));
				}
			}
		}

		// Token: 0x06045CA6 RID: 285862 RVA: 0x01242750 File Offset: 0x01240950
		private void Redraw()
		{
			if (this.Canvas == null)
			{
				return;
			}
			try
			{
				CapabilityDebugger debugger = this.Debugger;
				double nowSeconds = Singleton<Time>.Instance.NowSeconds;
				double num = Math.Max(0.0, nowSeconds - (double)this.WindowSeconds);
				double endTime = nowSeconds;
				float num2 = 80f * this.Zoom;
				List<string> list = debugger.CollectAllCapabilityIds();
				int num3 = Math.Min(list.Count, 64);
				this.BucketizeByRow(list, num3, num, endTime, debugger);
				for (int i = 0; i < num3; i++)
				{
					string text = list[i];
					int y = 62 + i * 22;
					try
					{
						RowPool pool = this.EnsureRow(i);
						this.UpdateLabel(pool, text, 8, y);
						this.LayoutRow(pool, this.SpanBuckets[i], this.EventBuckets[i], num, num2, y, nowSeconds);
					}
					finally
					{
					}
				}
				for (int j = num3; j < this.Rows.Count; j++)
				{
					this.HideRow(this.Rows[j]);
				}
				this.UpdateNowLabel(nowSeconds);
				this.LayoutTimeAxis(num, endTime, num2);
				if (this.CursorSlot != null)
				{
					double num4 = 240.0 + (nowSeconds - num) * (double)num2;
					int num5 = Math.Max(36, 14 + num3 * 22);
					this.CursorSlot.SetPosition(new FVector2D((float)num4, 48f));
					this.CursorSlot.SetSize(new FVector2D(1f, (float)num5));
					if (this.CursorTimeLabelSlot != null && this.CursorTimeLabel != null)
					{
						this.CursorTimeLabelSlot.SetPosition(new FVector2D((float)(num4 + 2.0), 48f));
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
						defaultInterpolatedStringHandler.AppendFormatted<double>(nowSeconds, "F2");
						defaultInterpolatedStringHandler.AppendLiteral("s");
						string text2 = defaultInterpolatedStringHandler.ToStringAndClear();
						if (this.CursorTimeLabelText != text2)
						{
							this.CursorTimeLabel.SetText(text2);
							this.CursorTimeLabelText = text2;
						}
					}
				}
			}
			finally
			{
			}
		}

		// Token: 0x06045CA7 RID: 285863 RVA: 0x0124298C File Offset: 0x01240B8C
		private void UpdateNowLabel(double now)
		{
			if (this.NowLabel == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 3);
			defaultInterpolatedStringHandler.AppendLiteral("Now: ");
			defaultInterpolatedStringHandler.AppendFormatted<double>(now, "F1");
			defaultInterpolatedStringHandler.AppendLiteral("s   Window: ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.WindowSeconds);
			defaultInterpolatedStringHandler.AppendLiteral("s   Zoom: x");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.Zoom, "F2");
			string text = defaultInterpolatedStringHandler.ToStringAndClear();
			if (this.NowLabelText != text)
			{
				this.NowLabel.SetText(text);
				this.NowLabelText = text;
			}
		}

		// Token: 0x06045CA8 RID: 285864 RVA: 0x01242A2C File Offset: 0x01240C2C
		private void LayoutTimeAxis(double startTime, double endTime, float pps)
		{
			UCanvasPanel canvas = this.Canvas;
			UWidgetTree widgetTree = this.WidgetTree;
			try
			{
				int num = 48;
				double num2 = Math.Ceiling(startTime / 1.0) * 1.0;
				int num3 = 0;
				int num4 = 0;
				double num5 = num2;
				while (num5 <= endTime + 0.001 && num3 < 256)
				{
					double num6 = 240.0 + (num5 - startTime) * (double)pps;
					bool flag = Math.Abs(num5 / 5.0 - Math.Round(num5 / 5.0)) < 0.001;
					int num7 = flag ? 14 : ((int)Math.Floor(7.0));
					UImage uimage = this.Ticks[num3];
					UCanvasPanelSlot ucanvasPanelSlot = this.TickSlots[num3];
					if (uimage == null)
					{
						uimage = new UImage(widgetTree, null, EObjectFlags.RF_NoFlags);
						uimage.SetColorAndOpacity(CapabilityTimelineDebugger.tickColor);
						ucanvasPanelSlot = canvas.AddChildToCanvas(uimage);
						this.Ticks[num3] = uimage;
						this.TickSlots[num3] = ucanvasPanelSlot;
					}
					if (ucanvasPanelSlot != null)
					{
						ucanvasPanelSlot.SetPosition(new FVector2D((float)num6, (float)(num + (14 - num7))));
						ucanvasPanelSlot.SetSize(new FVector2D(1f, (float)num7));
					}
					uimage.SetVisibility(ESlateVisibility.HitTestInvisible);
					num3++;
					if (flag)
					{
						UTextBlock utextBlock = this.TickLabels[num4];
						UCanvasPanelSlot ucanvasPanelSlot2 = this.TickLabelSlots[num4];
						if (utextBlock == null)
						{
							utextBlock = new UTextBlock(widgetTree, null, EObjectFlags.RF_NoFlags);
							CapabilityTimelineDebugger.ApplyFontConfig(utextBlock, CapabilityTimelineDebugger.tickLabelFontConfig);
							ucanvasPanelSlot2 = canvas.AddChildToCanvas(utextBlock);
							this.TickLabels[num4] = utextBlock;
							this.TickLabelSlots[num4] = ucanvasPanelSlot2;
							this.TickLabelTexts[num4] = "";
						}
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
						defaultInterpolatedStringHandler.AppendFormatted<double>(num5, "F0");
						defaultInterpolatedStringHandler.AppendLiteral("s");
						string text = defaultInterpolatedStringHandler.ToStringAndClear();
						if (this.TickLabelTexts[num4] != text)
						{
							utextBlock.SetText(text);
							this.TickLabelTexts[num4] = text;
						}
						if (ucanvasPanelSlot2 != null)
						{
							ucanvasPanelSlot2.SetPosition(new FVector2D((float)(num6 + 2.0), (float)num));
							ucanvasPanelSlot2.SetSize(new FVector2D(40f, 14f));
						}
						utextBlock.SetVisibility(ESlateVisibility.HitTestInvisible);
						num4++;
					}
					num5 += 1.0;
				}
				for (int i = num3; i < this.UsedTicks; i++)
				{
					this.Ticks[i].SetVisibility(ESlateVisibility.Collapsed);
				}
				this.UsedTicks = num3;
				for (int j = num4; j < this.UsedTickLabels; j++)
				{
					this.TickLabels[j].SetVisibility(ESlateVisibility.Collapsed);
				}
				this.UsedTickLabels = num4;
			}
			finally
			{
			}
		}

		// Token: 0x06045CA9 RID: 285865 RVA: 0x01242D24 File Offset: 0x01240F24
		private void BucketizeByRow(List<string> ids, int rowCount, double startTime, double endTime, CapabilityDebugger capabilityDebugger)
		{
			try
			{
				this.IdToRowIndex.Clear();
				this.RowIds.Clear();
				for (int i = 0; i < rowCount; i++)
				{
					this.IdToRowIndex[ids[i]] = i;
					this.RowIds.Add(ids[i]);
				}
				for (int j = 0; j < rowCount; j++)
				{
					if (this.SpanBuckets[j] == null)
					{
						this.SpanBuckets[j] = new List<ICapabilityDebugActiveSpan>();
					}
					else
					{
						this.SpanBuckets[j].Clear();
					}
					if (this.EventBuckets[j] == null)
					{
						this.EventBuckets[j] = new List<ICapabilityDebugRecord>();
					}
					else
					{
						this.EventBuckets[j].Clear();
					}
				}
				foreach (ICapabilityDebugActiveSpan capabilityDebugActiveSpan in capabilityDebugger.GetClosedSpans())
				{
					int index;
					if (capabilityDebugActiveSpan.EndTime >= startTime && capabilityDebugActiveSpan.StartTime <= endTime && this.IdToRowIndex.TryGetValue(capabilityDebugActiveSpan.CapabilityId, out index))
					{
						List<ICapabilityDebugActiveSpan> list = this.SpanBuckets[index];
						if (list.Count < 64)
						{
							list.Add(capabilityDebugActiveSpan);
						}
					}
				}
				foreach (ICapabilityDebugActiveSpan capabilityDebugActiveSpan2 in capabilityDebugger.GetOpenSpans())
				{
					int index2;
					if (capabilityDebugActiveSpan2.StartTime <= endTime && this.IdToRowIndex.TryGetValue(capabilityDebugActiveSpan2.CapabilityId, out index2))
					{
						List<ICapabilityDebugActiveSpan> list2 = this.SpanBuckets[index2];
						if (list2.Count < 64)
						{
							list2.Add(capabilityDebugActiveSpan2);
						}
					}
				}
				foreach (ICapabilityDebugRecord capabilityDebugRecord in capabilityDebugger.GetRecords())
				{
					int index3;
					if (capabilityDebugRecord.Time >= startTime && capabilityDebugRecord.Time <= endTime && CapabilityTimelineDebugger.IsImportantEvent(capabilityDebugRecord.Event) && this.IdToRowIndex.TryGetValue(capabilityDebugRecord.CapabilityId, out index3))
					{
						List<ICapabilityDebugRecord> list3 = this.EventBuckets[index3];
						if (list3.Count < 64)
						{
							list3.Add(capabilityDebugRecord);
						}
					}
				}
			}
			finally
			{
			}
		}

		// Token: 0x06045CAA RID: 285866 RVA: 0x01242FBC File Offset: 0x012411BC
		private static bool IsImportantEvent(CapabilityCommonDefine.ECapabilityDebugEvent e)
		{
			return e == CapabilityCommonDefine.ECapabilityDebugEvent.OnActivated || e == CapabilityCommonDefine.ECapabilityDebugEvent.OnDeactivated || e == CapabilityCommonDefine.ECapabilityDebugEvent.Interrupted || e == CapabilityCommonDefine.ECapabilityDebugEvent.Blocked || e == CapabilityCommonDefine.ECapabilityDebugEvent.Unblocked;
		}

		// Token: 0x06045CAB RID: 285867 RVA: 0x01242FD8 File Offset: 0x012411D8
		private RowPool EnsureRow(int rowIndex)
		{
			RowPool rowPool = this.Rows[rowIndex];
			if (rowPool != null)
			{
				return rowPool;
			}
			RowPool result;
			try
			{
				UCanvasPanel canvas = this.Canvas;
				UTextBlock utextBlock = new UTextBlock(this.WidgetTree, null, EObjectFlags.RF_NoFlags);
				CapabilityTimelineDebugger.ApplyFontConfig(utextBlock, CapabilityTimelineDebugger.labelFontConfig);
				UCanvasPanelSlot labelSlot = canvas.AddChildToCanvas(utextBlock);
				rowPool = new RowPool
				{
					Label = utextBlock,
					LabelSlot = labelSlot,
					LabelText = "",
					Spans = new List<UImage>(),
					SpanSlots = new List<UCanvasPanelSlot>(),
					Events = new List<UImage>(),
					EventSlots = new List<UCanvasPanelSlot>(),
					UsedSpans = 0,
					UsedEvents = 0
				};
				this.Rows[rowIndex] = rowPool;
				result = rowPool;
			}
			finally
			{
			}
			return result;
		}

		// Token: 0x06045CAC RID: 285868 RVA: 0x0124309C File Offset: 0x0124129C
		private void UpdateLabel(RowPool pool, string text, int x, int y)
		{
			if (pool.LabelText != text)
			{
				pool.Label.SetText(text);
				pool.LabelText = text;
			}
			UCanvasPanelSlot labelSlot = pool.LabelSlot;
			if (labelSlot != null)
			{
				labelSlot.SetPosition(new FVector2D((float)x, (float)(y + 4)));
				labelSlot.SetSize(new FVector2D(236f, 18f));
			}
			pool.Label.SetVisibility(ESlateVisibility.HitTestInvisible);
		}

		// Token: 0x06045CAD RID: 285869 RVA: 0x0124310C File Offset: 0x0124130C
		private void LayoutRow(RowPool pool, List<ICapabilityDebugActiveSpan> spans, List<ICapabilityDebugRecord> events, double startTime, float pps, int y, double now)
		{
			UCanvasPanel canvas = this.Canvas;
			UWidgetTree widgetTree = this.WidgetTree;
			int count = spans.Count;
			for (int i = 0; i < count; i++)
			{
				ICapabilityDebugActiveSpan capabilityDebugActiveSpan = spans[i];
				double num = 240.0 + Math.Max(0.0, capabilityDebugActiveSpan.StartTime - startTime) * (double)pps;
				double num2 = (capabilityDebugActiveSpan.EndTime < 0.0) ? now : capabilityDebugActiveSpan.EndTime;
				double num3 = 240.0 + (num2 - startTime) * (double)pps;
				double num4 = Math.Max(1.0, num3 - num);
				UImage uimage = pool.Spans[i];
				UCanvasPanelSlot ucanvasPanelSlot = pool.SpanSlots[i];
				if (uimage == null)
				{
					uimage = new UImage(widgetTree, null, EObjectFlags.RF_NoFlags);
					uimage.SetColorAndOpacity(CapabilityTimelineDebugger.spanColor);
					ucanvasPanelSlot = canvas.AddChildToCanvas(uimage);
					pool.Spans[i] = uimage;
					pool.SpanSlots[i] = ucanvasPanelSlot;
				}
				if (ucanvasPanelSlot != null)
				{
					ucanvasPanelSlot.SetPosition(new FVector2D((float)num, (float)(y + 2)));
					ucanvasPanelSlot.SetSize(new FVector2D((float)num4, 18f));
				}
				uimage.SetVisibility(ESlateVisibility.HitTestInvisible);
			}
			for (int j = count; j < pool.UsedSpans; j++)
			{
				pool.Spans[j].SetVisibility(ESlateVisibility.Collapsed);
			}
			pool.UsedSpans = count;
			int count2 = events.Count;
			for (int k = 0; k < count2; k++)
			{
				ICapabilityDebugRecord capabilityDebugRecord = events[k];
				double num5 = 240.0 + Math.Max(0.0, capabilityDebugRecord.Time - startTime) * (double)pps;
				FLinearColor colorAndOpacity = CapabilityTimelineDebugger.eventColor[capabilityDebugRecord.Event];
				UImage uimage2 = pool.Events[k];
				UCanvasPanelSlot ucanvasPanelSlot2 = pool.EventSlots[k];
				if (uimage2 == null)
				{
					uimage2 = new UImage(widgetTree, null, EObjectFlags.RF_NoFlags);
					ucanvasPanelSlot2 = canvas.AddChildToCanvas(uimage2);
					pool.Events[k] = uimage2;
					pool.EventSlots[k] = ucanvasPanelSlot2;
				}
				uimage2.SetColorAndOpacity(colorAndOpacity);
				if (ucanvasPanelSlot2 != null)
				{
					ucanvasPanelSlot2.SetPosition(new FVector2D((float)num5 - 2f, (float)y));
					ucanvasPanelSlot2.SetSize(new FVector2D(4f, 22f));
				}
				uimage2.SetVisibility(ESlateVisibility.HitTestInvisible);
			}
			for (int l = count2; l < pool.UsedEvents; l++)
			{
				pool.Events[l].SetVisibility(ESlateVisibility.Collapsed);
			}
			pool.UsedEvents = count2;
		}

		// Token: 0x06045CAE RID: 285870 RVA: 0x012433AC File Offset: 0x012415AC
		private void HideRow(RowPool pool)
		{
			pool.Label.SetVisibility(ESlateVisibility.Collapsed);
			for (int i = 0; i < pool.UsedSpans; i++)
			{
				pool.Spans[i].SetVisibility(ESlateVisibility.Collapsed);
			}
			for (int j = 0; j < pool.UsedEvents; j++)
			{
				pool.Events[j].SetVisibility(ESlateVisibility.Collapsed);
			}
			pool.UsedSpans = 0;
			pool.UsedEvents = 0;
		}

		// Token: 0x06045CAF RID: 285871 RVA: 0x0124341C File Offset: 0x0124161C
		public string DumpToString()
		{
			CapabilityDebugger debugger = this.Debugger;
			List<string> list = new List<string>();
			list.Add("=== Capability Timeline Snapshot ===");
			List<string> list2 = list;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
			defaultInterpolatedStringHandler.AppendLiteral("World time: ");
			defaultInterpolatedStringHandler.AppendFormatted<double>(Singleton<Time>.Instance.NowSeconds, "F3");
			defaultInterpolatedStringHandler.AppendLiteral("s");
			list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			list.Add("");
			using (List<string>.Enumerator enumerator = debugger.CollectAllCapabilityIds().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string id = enumerator.Current;
					List<ICapabilityDebugActiveSpan> list3 = new List<ICapabilityDebugActiveSpan>(debugger.GetClosedSpans()).FindAll((ICapabilityDebugActiveSpan s) => s.CapabilityId == id);
					List<ICapabilityDebugActiveSpan> list4 = new List<ICapabilityDebugActiveSpan>(debugger.GetOpenSpans()).FindAll((ICapabilityDebugActiveSpan s) => s.CapabilityId == id);
					List<string> list5 = new List<string>();
					foreach (ICapabilityDebugActiveSpan capabilityDebugActiveSpan in list3)
					{
						List<string> list6 = list5;
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
						defaultInterpolatedStringHandler.AppendLiteral("[");
						defaultInterpolatedStringHandler.AppendFormatted<double>(capabilityDebugActiveSpan.StartTime, "F2");
						defaultInterpolatedStringHandler.AppendLiteral("-");
						defaultInterpolatedStringHandler.AppendFormatted<double>(capabilityDebugActiveSpan.EndTime, "F2");
						defaultInterpolatedStringHandler.AppendLiteral("]");
						list6.Add(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					foreach (ICapabilityDebugActiveSpan capabilityDebugActiveSpan2 in list4)
					{
						List<string> list7 = list5;
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
						defaultInterpolatedStringHandler.AppendLiteral("[");
						defaultInterpolatedStringHandler.AppendFormatted<double>(capabilityDebugActiveSpan2.StartTime, "F2");
						defaultInterpolatedStringHandler.AppendLiteral("-...]");
						list7.Add(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					list.Add(id + "\n  active: " + string.Join(" ", list5));
				}
			}
			list.Add("");
			list.Add("--- Recent Events ---");
			IReadOnlyList<ICapabilityDebugRecord> records = debugger.GetRecords();
			for (int i = Math.Max(0, records.Count - 30); i < records.Count; i++)
			{
				ICapabilityDebugRecord capabilityDebugRecord = records[i];
				List<string> list8 = list;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 3);
				defaultInterpolatedStringHandler.AppendLiteral("  ");
				defaultInterpolatedStringHandler.AppendFormatted<double>(capabilityDebugRecord.Time, "F3");
				defaultInterpolatedStringHandler.AppendLiteral("s  ");
				defaultInterpolatedStringHandler.AppendFormatted<CapabilityCommonDefine.ECapabilityDebugEvent>(capabilityDebugRecord.Event);
				defaultInterpolatedStringHandler.AppendLiteral("  ");
				defaultInterpolatedStringHandler.AppendFormatted(capabilityDebugRecord.CapabilityId);
				string str = defaultInterpolatedStringHandler.ToStringAndClear();
				string str2 = (capabilityDebugRecord.Detail != null) ? (" (" + capabilityDebugRecord.Detail + ")") : "";
				string str3;
				if (capabilityDebugRecord.DurationMs == null)
				{
					str3 = "";
				}
				else
				{
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
					defaultInterpolatedStringHandler.AppendLiteral(" ");
					defaultInterpolatedStringHandler.AppendFormatted<double>(capabilityDebugRecord.DurationMs.Value, "F2");
					defaultInterpolatedStringHandler.AppendLiteral("ms");
					str3 = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				list8.Add(str + str2 + str3);
			}
			return string.Join("\n", list);
		}

		// Token: 0x06045CB0 RID: 285872 RVA: 0x012437D0 File Offset: 0x012419D0
		public unsafe static void CreateStaticDefaultValue()
		{
			Dictionary<CapabilityCommonDefine.ECapabilityDebugEvent, FLinearColor> dictionary = new Dictionary<CapabilityCommonDefine.ECapabilityDebugEvent, FLinearColor>();
			dictionary[CapabilityCommonDefine.ECapabilityDebugEvent.Setup] = new FLinearColor(0.6f, 0.6f, 0.6f, 1f);
			dictionary[CapabilityCommonDefine.ECapabilityDebugEvent.PreTick] = new FLinearColor(0.4f, 0.4f, 0.4f, 0.5f);
			dictionary[CapabilityCommonDefine.ECapabilityDebugEvent.ShouldActivate] = new FLinearColor(0.5f, 0.7f, 0.9f, 0.8f);
			dictionary[CapabilityCommonDefine.ECapabilityDebugEvent.ShouldDeactivate] = new FLinearColor(0.9f, 0.6f, 0.4f, 0.8f);
			dictionary[CapabilityCommonDefine.ECapabilityDebugEvent.OnActivated] = new FLinearColor(0.2f, 0.9f, 0.2f, 1f);
			dictionary[CapabilityCommonDefine.ECapabilityDebugEvent.OnDeactivated] = new FLinearColor(0.9f, 0.2f, 0.2f, 1f);
			dictionary[CapabilityCommonDefine.ECapabilityDebugEvent.TickActive] = new FLinearColor(0.3f, 0.6f, 1f, 0.6f);
			dictionary[CapabilityCommonDefine.ECapabilityDebugEvent.Blocked] = new FLinearColor(0.7f, 0.7f, 0f, 1f);
			dictionary[CapabilityCommonDefine.ECapabilityDebugEvent.Unblocked] = new FLinearColor(0.5f, 0.7f, 0f, 1f);
			dictionary[CapabilityCommonDefine.ECapabilityDebugEvent.Interrupted] = new FLinearColor(1f, 0f, 0.6f, 1f);
			CapabilityTimelineDebugger.eventColor = dictionary;
			int num = 7;
			List<ValueTuple<FLinearColor, string>> list = new List<ValueTuple<FLinearColor, string>>(num);
			CollectionsMarshal.SetCount<ValueTuple<FLinearColor, string>>(list, num);
			Span<ValueTuple<FLinearColor, string>> span = CollectionsMarshal.AsSpan<ValueTuple<FLinearColor, string>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<FLinearColor, string>(CapabilityTimelineDebugger.spanColor, "Active Span");
			num2++;
			*span[num2] = new ValueTuple<FLinearColor, string>(CapabilityTimelineDebugger.eventColor[CapabilityCommonDefine.ECapabilityDebugEvent.OnActivated], "OnActivated");
			num2++;
			*span[num2] = new ValueTuple<FLinearColor, string>(CapabilityTimelineDebugger.eventColor[CapabilityCommonDefine.ECapabilityDebugEvent.OnDeactivated], "OnDeactivated");
			num2++;
			*span[num2] = new ValueTuple<FLinearColor, string>(CapabilityTimelineDebugger.eventColor[CapabilityCommonDefine.ECapabilityDebugEvent.Blocked], "Blocked");
			num2++;
			*span[num2] = new ValueTuple<FLinearColor, string>(CapabilityTimelineDebugger.eventColor[CapabilityCommonDefine.ECapabilityDebugEvent.Unblocked], "Unblocked");
			num2++;
			*span[num2] = new ValueTuple<FLinearColor, string>(CapabilityTimelineDebugger.eventColor[CapabilityCommonDefine.ECapabilityDebugEvent.Interrupted], "Interrupted");
			num2++;
			*span[num2] = new ValueTuple<FLinearColor, string>(CapabilityTimelineDebugger.cursorColor, "Now");
			CapabilityTimelineDebugger.legendEntries = list;
			CapabilityTimelineDebugger.headerFontConfig = new FontConfig
			{
				Size = 12,
				Typeface = "Bold",
				LetterSpacing = 0,
				Color = CapabilityTimelineDebugger.textColor
			};
			CapabilityTimelineDebugger.labelFontConfig = new FontConfig
			{
				Size = 9,
				Typeface = "Light",
				LetterSpacing = -20,
				Color = CapabilityTimelineDebugger.textColor
			};
			CapabilityTimelineDebugger.legendFontConfig = new FontConfig
			{
				Size = 9,
				Typeface = "Regular",
				LetterSpacing = 0,
				Color = CapabilityTimelineDebugger.textColor
			};
			CapabilityTimelineDebugger.tickLabelFontConfig = new FontConfig
			{
				Size = 9,
				Typeface = "Light",
				LetterSpacing = 0,
				Color = CapabilityTimelineDebugger.tickLabelColor
			};
			CapabilityTimelineDebugger.statRedraw = Stat.Create("CapabilityTimelineDebugger.Redraw", "", "");
			CapabilityTimelineDebugger.statBucketize = Stat.Create("CapabilityTimelineDebugger.Bucketize", "", "");
			CapabilityTimelineDebugger.statLayoutRow = Stat.Create("CapabilityTimelineDebugger.LayoutRow", "", "");
			CapabilityTimelineDebugger.statEnsureRow = Stat.Create("CapabilityTimelineDebugger.EnsureRow", "", "");
			CapabilityTimelineDebugger.statTimeAxis = Stat.Create("CapabilityTimelineDebugger.TimeAxis", "", "");
		}

		// Token: 0x06045CB1 RID: 285873 RVA: 0x01243B7C File Offset: 0x01241D7C
		public static void ResetStaticDefaultValue()
		{
			CapabilityTimelineDebugger.legendEntries = null;
			CapabilityTimelineDebugger.eventColor = null;
			CapabilityTimelineDebugger.headerFontConfig = null;
			CapabilityTimelineDebugger.labelFontConfig = null;
			CapabilityTimelineDebugger.legendFontConfig = null;
			CapabilityTimelineDebugger.tickLabelFontConfig = null;
			CapabilityTimelineDebugger.statRedraw = null;
			CapabilityTimelineDebugger.statBucketize = null;
			CapabilityTimelineDebugger.statLayoutRow = null;
			CapabilityTimelineDebugger.statEnsureRow = null;
			CapabilityTimelineDebugger.statTimeAxis = null;
		}

		// Token: 0x040270AD RID: 159917
		private static Dictionary<CapabilityCommonDefine.ECapabilityDebugEvent, FLinearColor> eventColor;

		// Token: 0x040270AE RID: 159918
		private static readonly FLinearColor spanColor = new FLinearColor(0.3f, 0.6f, 1f, 0.8f);

		// Token: 0x040270AF RID: 159919
		private static readonly FLinearColor cursorColor = ColorUtils.LinearWhiteOpaque;

		// Token: 0x040270B0 RID: 159920
		private static readonly FLinearColor textColor = new FLinearColor(0.85f, 0.85f, 0.85f, 0.85f);

		// Token: 0x040270B1 RID: 159921
		private static readonly FLinearColor tickColor = new FLinearColor(1f, 1f, 1f, 0.15f);

		// Token: 0x040270B2 RID: 159922
		private static readonly FLinearColor tickLabelColor = new FLinearColor(0.7f, 0.7f, 0.7f, 0.6f);

		// Token: 0x040270B3 RID: 159923
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		private static List<ValueTuple<FLinearColor, string>> legendEntries;

		// Token: 0x040270B4 RID: 159924
		private const int ROW_HEIGHT = 22;

		// Token: 0x040270B5 RID: 159925
		private const int LABEL_COL_WIDTH = 240;

		// Token: 0x040270B6 RID: 159926
		private const int PIXELS_PER_SECOND_BASE = 80;

		// Token: 0x040270B7 RID: 159927
		private const int REDRAW_INTERVAL_MS = 100;

		// Token: 0x040270B8 RID: 159928
		private const int MAX_SPANS_PER_ROW = 64;

		// Token: 0x040270B9 RID: 159929
		private const int MAX_EVENTS_PER_ROW = 64;

		// Token: 0x040270BA RID: 159930
		private const int MAX_ROWS = 64;

		// Token: 0x040270BB RID: 159931
		private static FontConfig headerFontConfig;

		// Token: 0x040270BC RID: 159932
		private static FontConfig labelFontConfig;

		// Token: 0x040270BD RID: 159933
		private static FontConfig legendFontConfig;

		// Token: 0x040270BE RID: 159934
		private static FontConfig tickLabelFontConfig;

		// Token: 0x040270BF RID: 159935
		private const int LEGEND_HEIGHT = 18;

		// Token: 0x040270C0 RID: 159936
		private const int LEGEND_SWATCH_W = 12;

		// Token: 0x040270C1 RID: 159937
		private const int LEGEND_SWATCH_H = 10;

		// Token: 0x040270C2 RID: 159938
		private const int LEGEND_ITEM_WIDTH = 110;

		// Token: 0x040270C3 RID: 159939
		private const int TIME_AXIS_HEIGHT = 14;

		// Token: 0x040270C4 RID: 159940
		private const int ROW_Y_OFFSET = 62;

		// Token: 0x040270C5 RID: 159941
		private const int CURSOR_MIN_HEIGHT = 36;

		// Token: 0x040270C6 RID: 159942
		private const int TICK_MINOR_INTERVAL_SEC = 1;

		// Token: 0x040270C7 RID: 159943
		private const int TICK_MAJOR_INTERVAL_SEC = 5;

		// Token: 0x040270C8 RID: 159944
		private const int MAX_TIME_TICKS = 256;

		// Token: 0x040270C9 RID: 159945
		private static Stat statRedraw;

		// Token: 0x040270CA RID: 159946
		private static Stat statBucketize;

		// Token: 0x040270CB RID: 159947
		private static Stat statLayoutRow;

		// Token: 0x040270CC RID: 159948
		private static Stat statEnsureRow;

		// Token: 0x040270CD RID: 159949
		private static Stat statTimeAxis;

		// Token: 0x040270CE RID: 159950
		private float Zoom = 1f;

		// Token: 0x040270CF RID: 159951
		private float WindowSeconds = 30f;

		// Token: 0x040270D0 RID: 159952
		[Nullable(2)]
		private UUserWidget RootWidget;

		// Token: 0x040270D1 RID: 159953
		[Nullable(2)]
		private UWidgetTree WidgetTree;

		// Token: 0x040270D2 RID: 159954
		[Nullable(2)]
		private UCanvasPanel Canvas;

		// Token: 0x040270D3 RID: 159955
		[Nullable(2)]
		private UCanvasPanelSlot CursorSlot;

		// Token: 0x040270D4 RID: 159956
		[Nullable(2)]
		private UTextBlock NowLabel;

		// Token: 0x040270D5 RID: 159957
		private string NowLabelText = "";

		// Token: 0x040270D6 RID: 159958
		[Nullable(2)]
		private UTextBlock CursorTimeLabel;

		// Token: 0x040270D7 RID: 159959
		[Nullable(2)]
		private UCanvasPanelSlot CursorTimeLabelSlot;

		// Token: 0x040270D8 RID: 159960
		private string CursorTimeLabelText = "";

		// Token: 0x040270D9 RID: 159961
		private readonly List<UImage> Ticks = new List<UImage>();

		// Token: 0x040270DA RID: 159962
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private readonly List<UCanvasPanelSlot> TickSlots = new List<UCanvasPanelSlot>();

		// Token: 0x040270DB RID: 159963
		private int UsedTicks;

		// Token: 0x040270DC RID: 159964
		private readonly List<UTextBlock> TickLabels = new List<UTextBlock>();

		// Token: 0x040270DD RID: 159965
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private readonly List<UCanvasPanelSlot> TickLabelSlots = new List<UCanvasPanelSlot>();

		// Token: 0x040270DE RID: 159966
		private readonly List<string> TickLabelTexts = new List<string>();

		// Token: 0x040270DF RID: 159967
		private int UsedTickLabels;

		// Token: 0x040270E0 RID: 159968
		private readonly List<RowPool> Rows = new List<RowPool>();

		// Token: 0x040270E1 RID: 159969
		private readonly List<List<ICapabilityDebugActiveSpan>> SpanBuckets = new List<List<ICapabilityDebugActiveSpan>>();

		// Token: 0x040270E2 RID: 159970
		private readonly List<List<ICapabilityDebugRecord>> EventBuckets = new List<List<ICapabilityDebugRecord>>();

		// Token: 0x040270E3 RID: 159971
		private readonly Dictionary<string, int> IdToRowIndex = new Dictionary<string, int>();

		// Token: 0x040270E4 RID: 159972
		private readonly List<string> RowIds = new List<string>();

		// Token: 0x040270E5 RID: 159973
		[Nullable(2)]
		private TimerHandle TickHandle;

		// Token: 0x040270E6 RID: 159974
		public CapabilityDebugger Debugger;
	}
}
