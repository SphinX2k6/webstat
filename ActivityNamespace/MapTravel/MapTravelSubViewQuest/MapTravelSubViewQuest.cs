using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace ActivityNamespace.MapTravel.MapTravelSubViewQuest
{
	// Token: 0x020043CE RID: 17358
	[NullableContext(1)]
	[Nullable(0)]
	public class MapTravelSubViewQuest : UiPanelBase, IMapTravelSubViewInterface
	{
		// Token: 0x17007F0B RID: 32523
		// (get) Token: 0x0602E23A RID: 188986 RVA: 0x00AD976A File Offset: 0x00AD796A
		// (set) Token: 0x0602E23B RID: 188987 RVA: 0x00AD9772 File Offset: 0x00AD7972
		public bool NeedDestroySelf { get; set; } = true;

		// Token: 0x0602E23C RID: 188988 RVA: 0x00AD977B File Offset: 0x00AD797B
		public MapTravelSubViewQuest(ActivityMapTravelData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x0602E23D RID: 188989 RVA: 0x00AD9794 File Offset: 0x00AD7994
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0602E23E RID: 188990 RVA: 0x00AD97FD File Offset: 0x00AD79FD
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.AreaLayoutList = new GenericScrollViewNew<AreaLayout, MapTravelAreaData>(base.GetScrollViewWithScrollbar(0), new Func<AreaLayout>(this.InitItem), null, false, null);
		}

		// Token: 0x0602E23F RID: 188991 RVA: 0x00AD9834 File Offset: 0x00AD7A34
		protected UniTask Refresh()
		{
			MapTravelSubViewQuest.<Refresh>d__10 <Refresh>d__;
			<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Refresh>d__.<>4__this = this;
			<Refresh>d__.<>1__state = -1;
			<Refresh>d__.<>t__builder.Start<MapTravelSubViewQuest.<Refresh>d__10>(ref <Refresh>d__);
			return <Refresh>d__.<>t__builder.Task;
		}

		// Token: 0x0602E240 RID: 188992 RVA: 0x00AD9877 File Offset: 0x00AD7A77
		private AreaLayout InitItem()
		{
			return new AreaLayout(this.ActivityBaseData);
		}

		// Token: 0x0602E241 RID: 188993 RVA: 0x00AD9884 File Offset: 0x00AD7A84
		public UniTask PlayStartSequence()
		{
			MapTravelSubViewQuest.<PlayStartSequence>d__12 <PlayStartSequence>d__;
			<PlayStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartSequence>d__.<>4__this = this;
			<PlayStartSequence>d__.<>1__state = -1;
			<PlayStartSequence>d__.<>t__builder.Start<MapTravelSubViewQuest.<PlayStartSequence>d__12>(ref <PlayStartSequence>d__);
			return <PlayStartSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0602E242 RID: 188994 RVA: 0x00AD98C8 File Offset: 0x00AD7AC8
		public UniTask PlayCloseSequence()
		{
			MapTravelSubViewQuest.<PlayCloseSequence>d__13 <PlayCloseSequence>d__;
			<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCloseSequence>d__.<>4__this = this;
			<PlayCloseSequence>d__.<>1__state = -1;
			<PlayCloseSequence>d__.<>t__builder.Start<MapTravelSubViewQuest.<PlayCloseSequence>d__13>(ref <PlayCloseSequence>d__);
			return <PlayCloseSequence>d__.<>t__builder.Task;
		}

		// Token: 0x17007F0C RID: 32524
		// (get) Token: 0x0602E243 RID: 188995 RVA: 0x00AD990B File Offset: 0x00AD7B0B
		// (set) Token: 0x0602E244 RID: 188996 RVA: 0x00AD9913 File Offset: 0x00AD7B13
		protected ActivityMapTravelData ActivityBaseData { get; set; }

		// Token: 0x0401A18E RID: 106894
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401A18F RID: 106895
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<AreaLayout, MapTravelAreaData> AreaLayoutList;

		// Token: 0x0200A644 RID: 42564
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04033699 RID: 210585
			public const int Layout = 0;

			// Token: 0x0403369A RID: 210586
			public const int AreaLayoutItem = 1;
		}
	}
}
