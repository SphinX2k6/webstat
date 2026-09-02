using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x02006145 RID: 24901
	[NullableContext(2)]
	[Nullable(0)]
	public class AutoPilotLineComponent : UiPanelBase
	{
		// Token: 0x0603EE72 RID: 257650 RVA: 0x0101F8A0 File Offset: 0x0101DAA0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EE73 RID: 257651 RVA: 0x0101FA14 File Offset: 0x0101DC14
		protected override void OnStart()
		{
			this.StartPoint = base.GetItem(4);
			this.EndPoint = base.GetItem(5);
			this.PlayerToStartLine = base.GetItem(0);
			UUIItem playerToStartLine = this.PlayerToStartLine;
			if (playerToStartLine != null)
			{
				playerToStartLine.SetColor(FColor.FromHex("65FFEBFF"));
			}
			this.EndToTargetLine = base.GetItem(1);
			this.PlayerToTargetLine = base.GetItem(2);
			UUIItem item = base.GetItem(3);
			object obj;
			if (item == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = item.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(UUI2DLineRaw.StaticClass()) : null);
			}
			this.FindPathHighLightLine = (obj as UUI2DLineRaw);
			this.FindPathRoot = base.GetItem(6);
			this.CirclePathRoot = base.GetItem(7);
			UUIItem item2 = base.GetItem(8);
			object obj2;
			if (item2 == null)
			{
				obj2 = null;
			}
			else
			{
				AActor owner2 = item2.GetOwner();
				obj2 = ((owner2 != null) ? owner2.GetComponentByClass(UUI2DLineRaw.StaticClass()) : null);
			}
			this.PathToCircleHighLightLine = (obj2 as UUI2DLineRaw);
			this.DebugPathRoot = base.GetItem(9);
		}

		// Token: 0x0603EE74 RID: 257652 RVA: 0x0101FB10 File Offset: 0x0101DD10
		[NullableContext(1)]
		public UniTask CreateDebugRoadLine(TArray<FVector2D> points)
		{
			AutoPilotLineComponent.<CreateDebugRoadLine>d__19 <CreateDebugRoadLine>d__;
			<CreateDebugRoadLine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDebugRoadLine>d__.<>4__this = this;
			<CreateDebugRoadLine>d__.points = points;
			<CreateDebugRoadLine>d__.<>1__state = -1;
			<CreateDebugRoadLine>d__.<>t__builder.Start<AutoPilotLineComponent.<CreateDebugRoadLine>d__19>(ref <CreateDebugRoadLine>d__);
			return <CreateDebugRoadLine>d__.<>t__builder.Task;
		}

		// Token: 0x0603EE75 RID: 257653 RVA: 0x0101FB5C File Offset: 0x0101DD5C
		public void RecycleDebugLine()
		{
			foreach (UUI2DLineRaw uui2DLineRaw in this.DebugLines)
			{
				uui2DLineRaw.SetUIActive(false);
				this.DebugLinesPool.Add(uui2DLineRaw);
			}
			this.DebugLines.Clear();
		}

		// Token: 0x0603EE76 RID: 257654 RVA: 0x0101FBC8 File Offset: 0x0101DDC8
		public UniTask LoadCirclePathHighLightLine(int circleId)
		{
			AutoPilotLineComponent.<LoadCirclePathHighLightLine>d__21 <LoadCirclePathHighLightLine>d__;
			<LoadCirclePathHighLightLine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadCirclePathHighLightLine>d__.<>4__this = this;
			<LoadCirclePathHighLightLine>d__.circleId = circleId;
			<LoadCirclePathHighLightLine>d__.<>1__state = -1;
			<LoadCirclePathHighLightLine>d__.<>t__builder.Start<AutoPilotLineComponent.<LoadCirclePathHighLightLine>d__21>(ref <LoadCirclePathHighLightLine>d__);
			return <LoadCirclePathHighLightLine>d__.<>t__builder.Task;
		}

		// Token: 0x0603EE77 RID: 257655 RVA: 0x0101FC13 File Offset: 0x0101DE13
		public void ResetCircleId()
		{
			this.CurrentCircleId = 0;
		}

		// Token: 0x0603EE78 RID: 257656 RVA: 0x0101FC1C File Offset: 0x0101DE1C
		protected override void OnBeforeDestroy()
		{
			foreach (UUI2DLineRaw uui2DLineRaw in this.DebugLines)
			{
				ULGUIBPLibrary.DestroyActorWithHierarchy(uui2DLineRaw.GetOwner(), true);
			}
			foreach (UUI2DLineRaw uui2DLineRaw2 in this.DebugLinesPool)
			{
				ULGUIBPLibrary.DestroyActorWithHierarchy(uui2DLineRaw2.GetOwner(), true);
			}
			foreach (UUIItem uuiitem in this.CirclePathHighLightLine.Values)
			{
				ULGUIBPLibrary.DestroyActorWithHierarchy(uuiitem.GetOwner(), true);
			}
			this.DebugLinesPool.Clear();
			this.DebugLines.Clear();
			this.CirclePathHighLightLine.Clear();
			this.ResetCircleId();
		}

		// Token: 0x040234BC RID: 144572
		public UUIItem StartPoint;

		// Token: 0x040234BD RID: 144573
		public UUIItem EndPoint;

		// Token: 0x040234BE RID: 144574
		public UUIItem PlayerToStartLine;

		// Token: 0x040234BF RID: 144575
		public UUIItem EndToTargetLine;

		// Token: 0x040234C0 RID: 144576
		public UUIItem PlayerToTargetLine;

		// Token: 0x040234C1 RID: 144577
		public UUI2DLineRaw FindPathHighLightLine;

		// Token: 0x040234C2 RID: 144578
		public UUIItem FindPathRoot;

		// Token: 0x040234C3 RID: 144579
		public UUIItem CirclePathRoot;

		// Token: 0x040234C4 RID: 144580
		[Nullable(1)]
		private readonly Dictionary<int, UUIItem> CirclePathHighLightLine = new Dictionary<int, UUIItem>();

		// Token: 0x040234C5 RID: 144581
		public UUI2DLineRaw PathToCircleHighLightLine;

		// Token: 0x040234C6 RID: 144582
		public UUIItem DebugPathRoot;

		// Token: 0x040234C7 RID: 144583
		[Nullable(1)]
		private const string DebugLineResPath = "/Game/Aki/UI/UIResources/UiWorldMap/Prefabs/UiItem_DebugHighLightLine.UiItem_DebugHighLightLine";

		// Token: 0x040234C8 RID: 144584
		[Nullable(1)]
		private readonly List<UUI2DLineRaw> DebugLinesPool = new List<UUI2DLineRaw>();

		// Token: 0x040234C9 RID: 144585
		[Nullable(1)]
		private readonly List<UUI2DLineRaw> DebugLines = new List<UUI2DLineRaw>();

		// Token: 0x040234CA RID: 144586
		[Nullable(1)]
		private readonly Stat StatsObject0 = Stat.Create("LoadCirclePathHighLightLine", "", "");

		// Token: 0x040234CB RID: 144587
		public int CurrentCircleId;

		// Token: 0x0200C2D3 RID: 49875
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403C113 RID: 246035
			PlayerToStartLine,
			// Token: 0x0403C114 RID: 246036
			EndToTargetLine,
			// Token: 0x0403C115 RID: 246037
			PlayerToTargetLine,
			// Token: 0x0403C116 RID: 246038
			FindPathHighLightLine,
			// Token: 0x0403C117 RID: 246039
			StartPoint,
			// Token: 0x0403C118 RID: 246040
			EndPoint,
			// Token: 0x0403C119 RID: 246041
			FindPathRoot,
			// Token: 0x0403C11A RID: 246042
			CirclePathRoot,
			// Token: 0x0403C11B RID: 246043
			PathToCircleHighLightLine,
			// Token: 0x0403C11C RID: 246044
			DebugPathRoot
		}
	}
}
