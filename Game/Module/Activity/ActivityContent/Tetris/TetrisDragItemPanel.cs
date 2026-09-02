using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062C3 RID: 25283
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisDragItemPanel : UiPanelBase
	{
		// Token: 0x0603F9D6 RID: 260566 RVA: 0x0104DDA6 File Offset: 0x0104BFA6
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x0603F9D7 RID: 260567 RVA: 0x0104DDE0 File Offset: 0x0104BFE0
		protected override UniTask OnBeforeStartAsync()
		{
			TetrisDragItemPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TetrisDragItemPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F9D8 RID: 260568 RVA: 0x0104DE23 File Offset: 0x0104C023
		protected override void OnStart()
		{
			this.ViewSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603F9D9 RID: 260569 RVA: 0x0104DE38 File Offset: 0x0104C038
		public void ResetAllItems()
		{
			foreach (TetrisGridPanel tetrisGridPanel in this.ListItems.Values)
			{
				tetrisGridPanel.SetUiActive(false);
			}
		}

		// Token: 0x0603F9DA RID: 260570 RVA: 0x0104DE90 File Offset: 0x0104C090
		[NullableContext(2)]
		public void RefreshView(BlockInstance data)
		{
			if (data == null)
			{
				return;
			}
			this.ResetAllItems();
			ValueTuple<int, int> valueTuple = Singleton<TetrisUtils>.Instance.FindAnchorOffset(data.Offsets);
			int num = 2 - valueTuple.Item1;
			int num2 = 2 - valueTuple.Item2;
			for (int i = 0; i < data.Offsets.Count; i++)
			{
				ValueTuple<int, int> valueTuple2 = data.Offsets[i];
				EGemType gemType = EGemType.None;
				if (data.GemFill == EGemFillType.Full)
				{
					gemType = data.GemType;
				}
				else if (data.GemFill == EGemFillType.Single && i == data.GemOffSet)
				{
					gemType = data.GemType;
				}
				CellInstance data2 = new CellInstance
				{
					ColorId = data.ColorId,
					GemType = gemType
				};
				ValueTuple<int, int> valueTuple3 = new ValueTuple<int, int>(valueTuple2.Item1 + num, valueTuple2.Item2 + num2);
				int key = TetrisUtils.GenPosKey(valueTuple3.Item1, valueTuple3.Item2);
				TetrisGridPanel tetrisGridPanel;
				if (this.ListItems.TryGetValue(key, out tetrisGridPanel))
				{
					tetrisGridPanel.SetUiActive(true);
					tetrisGridPanel.Refresh(data2);
				}
			}
			this.ViewSequencePlayer.PlayLevelSequenceByName("Pick", false, null, false);
		}

		// Token: 0x0603F9DB RID: 260571 RVA: 0x0104DFAC File Offset: 0x0104C1AC
		private UniTask CreateShape(UUIItem itemTemplate, UUIItem list, [TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})] [Nullable(0)] ValueTuple<int, int> offset)
		{
			TetrisDragItemPanel.<CreateShape>d__7 <CreateShape>d__;
			<CreateShape>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateShape>d__.<>4__this = this;
			<CreateShape>d__.itemTemplate = itemTemplate;
			<CreateShape>d__.list = list;
			<CreateShape>d__.offset = offset;
			<CreateShape>d__.<>1__state = -1;
			<CreateShape>d__.<>t__builder.Start<TetrisDragItemPanel.<CreateShape>d__7>(ref <CreateShape>d__);
			return <CreateShape>d__.<>t__builder.Task;
		}

		// Token: 0x0603F9DC RID: 260572 RVA: 0x0104E008 File Offset: 0x0104C208
		private UniTask CreateItemTemplate(UUIItem item, TetrisGridPanel itemView)
		{
			TetrisDragItemPanel.<CreateItemTemplate>d__8 <CreateItemTemplate>d__;
			<CreateItemTemplate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateItemTemplate>d__.<>4__this = this;
			<CreateItemTemplate>d__.item = item;
			<CreateItemTemplate>d__.itemView = itemView;
			<CreateItemTemplate>d__.<>1__state = -1;
			<CreateItemTemplate>d__.<>t__builder.Start<TetrisDragItemPanel.<CreateItemTemplate>d__8>(ref <CreateItemTemplate>d__);
			return <CreateItemTemplate>d__.<>t__builder.Task;
		}

		// Token: 0x0603F9DD RID: 260573 RVA: 0x0104E05B File Offset: 0x0104C25B
		protected override void OnBeforeDestroy()
		{
			this.ListItems.Clear();
			LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
			if (viewSequencePlayer != null)
			{
				viewSequencePlayer.Clear();
			}
			this.ViewSequencePlayer = null;
		}

		// Token: 0x04023B42 RID: 146242
		private readonly Dictionary<int, TetrisGridPanel> ListItems = new Dictionary<int, TetrisGridPanel>();

		// Token: 0x04023B43 RID: 146243
		[Nullable(2)]
		private LevelSequencePlayer ViewSequencePlayer;
	}
}
