using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.TuningStand.Bubble;

namespace CSharpScript.Game.LevelGamePlay.TuningStand
{
	// Token: 0x02006A79 RID: 27257
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class TuningStandModel : ModelBase<TuningStandModel>
	{
		// Token: 0x060436A0 RID: 276128 RVA: 0x0115D4B4 File Offset: 0x0115B6B4
		public void LoadData(ITuningStand config)
		{
			this.Config = config;
			this.ResetTimes = 0;
			this.InitGridData();
			this.InitTalkBubble();
			Singleton<global::Log>.Instance.Info(ELogModule.LevelPlay, ELogAuthor.WHJ, "调律台资源开始加载", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x060436A1 RID: 276129 RVA: 0x0115D4F7 File Offset: 0x0115B6F7
		public bool GetIsPressing()
		{
			return this.IsPressing;
		}

		// Token: 0x060436A2 RID: 276130 RVA: 0x0115D4FF File Offset: 0x0115B6FF
		public int? GetCurIndex()
		{
			return this.CurIndex;
		}

		// Token: 0x060436A3 RID: 276131 RVA: 0x0115D507 File Offset: 0x0115B707
		public List<TuningGridData> GetGridList()
		{
			return this.GridData;
		}

		// Token: 0x060436A4 RID: 276132 RVA: 0x0115D510 File Offset: 0x0115B710
		protected EGridCheckState CheckOpValidState(TuningGridData from, TuningGridData to)
		{
			ITuningStateData curGridState = from.GetCurGridState();
			if (curGridState.State == EGridBelongType.Empty)
			{
				return EGridCheckState.Invalid;
			}
			if (to.GridType == ETuningStandGridType.Empty)
			{
				return EGridCheckState.EmptyGrid;
			}
			ITuningStateData curGridState2 = to.GetCurGridState();
			int[] gridLoc = from.GridLoc;
			int[] gridLoc2 = to.GridLoc;
			if (curGridState.State == curGridState2.State)
			{
				return EGridCheckState.SameTuneCut;
			}
			if (Math.Abs(gridLoc[0] - gridLoc2[0]) + Math.Abs(gridLoc[1] - gridLoc2[1]) > 1)
			{
				return EGridCheckState.EmptyGrid;
			}
			if (to.GridMainType == EGridMainType.Start)
			{
				return EGridCheckState.Invalid;
			}
			if (to.GridMainType == EGridMainType.End && !this.CheckEndValid(from, to))
			{
				return EGridCheckState.Invalid;
			}
			if (from.GridValue > to.GridValue)
			{
				return EGridCheckState.Invalid;
			}
			if (curGridState2.State != EGridBelongType.Empty)
			{
				return EGridCheckState.DiffTuneCut;
			}
			return EGridCheckState.Valid;
		}

		// Token: 0x060436A5 RID: 276133 RVA: 0x0115D5B8 File Offset: 0x0115B7B8
		protected bool CheckEndValid(TuningGridData from, TuningGridData to)
		{
			ITuningStateData curGridState = from.GetCurGridState();
			if (to.GridType == ETuningStandGridType.End1)
			{
				return curGridState.State == EGridBelongType.Type1;
			}
			return curGridState.State == EGridBelongType.Type2;
		}

		// Token: 0x060436A6 RID: 276134 RVA: 0x0115D5E8 File Offset: 0x0115B7E8
		protected void InitGridData()
		{
			this.GridData.Clear();
			this.CurIndex = null;
			this.CurNodeIndex = 0;
			this.CreateEventList();
			for (int i = 0; i < this.Config.BoardConfig.Grids.Count; i++)
			{
				TuningGridData tuningGridData = new TuningGridData();
				tuningGridData.Index = i;
				tuningGridData.GridType = this.Config.BoardConfig.Grids[i];
				if (tuningGridData.GridType == ETuningStandGridType.Start1)
				{
					tuningGridData.StaticState.State = EGridBelongType.Type1;
				}
				else if (tuningGridData.GridType == ETuningStandGridType.Start2)
				{
					tuningGridData.StaticState.State = EGridBelongType.Type2;
				}
				tuningGridData.GridValue = TuningStandDefine.gridValueMap[tuningGridData.GridType];
				tuningGridData.GridMainType = TuningStandDefine.gridMainTypeMap[tuningGridData.GridType];
				this.GridData.Add(tuningGridData);
			}
		}

		// Token: 0x060436A7 RID: 276135 RVA: 0x0115D6CC File Offset: 0x0115B8CC
		public void ResetGrid()
		{
			if (Singleton<Time>.Instance.Now - 3.0 < this.PrevResetTime)
			{
				return;
			}
			this.TryStartBubbleFlow(ETuningStandBubbleTriggerType.Reset);
			this.PrevResetTime = Singleton<Time>.Instance.Now;
			this.ResetTimes++;
			if (this.ResetTimes == 3)
			{
				this.ProcessTooLong();
			}
			this.InitGridData();
		}

		// Token: 0x060436A8 RID: 276136 RVA: 0x0115D734 File Offset: 0x0115B934
		public void UnloadData()
		{
			this.Config = null;
			this.ResetTimes = 0;
			this.PrevResetTime = 0.0;
			this.DestroyBubble();
			this.GridData.Clear();
			this.CurIndex = null;
			this.CurNodeIndex = 0;
			this.EventList.Clear();
		}

		// Token: 0x060436A9 RID: 276137 RVA: 0x0115D78D File Offset: 0x0115B98D
		public void InitData(bool isPress)
		{
			this.IsPressing = isPress;
			this.CurIndex = null;
		}

		// Token: 0x060436AA RID: 276138 RVA: 0x0115D7A4 File Offset: 0x0115B9A4
		public void OnPress(TuningGridData data)
		{
			EGridMainType gridMainType = data.GridMainType;
			if (gridMainType == EGridMainType.End || gridMainType == EGridMainType.Empty)
			{
				return;
			}
			if (data.StaticState.State == EGridBelongType.Empty)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TuningStandOnLinkMiss, false);
			this.InitData(true);
			int index = data.Index;
			this.CurIndex = new int?(index);
			this.TryStartBubbleFlow(ETuningStandBubbleTriggerType.StartLink);
			if (this.ClearAllNextPathStatic(index))
			{
				this.PlayAkEvent(false);
				return;
			}
			this.PlayStartEvent();
		}

		// Token: 0x060436AB RID: 276139 RVA: 0x0115D818 File Offset: 0x0115BA18
		public void OnRelease(TuningGridData data)
		{
			bool flag = this.Config.VisualType == ETuningStandVisualType.Tuning;
			int? curIndex = this.CurIndex;
			this.InitData(false);
			this.SaveDynamicGrid();
			Singleton<EventSystem>.Instance.Emit<int?>(EEventName.TuningStandUpdate, null);
			if (this.CheckAllClear())
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.TuningStandSuccess);
				this.StartRevolving();
				return;
			}
			if (curIndex != null)
			{
				int[] array = this.CheckEndCount();
				if (this.GridData[curIndex.Value].GridMainType == EGridMainType.End && flag)
				{
					if (array[0] == array[1])
					{
						Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TuningStandOnLinkMiss, true);
						Singleton<AudioSystem>.Instance.PostEvent("play_ui_tiaolvtai_attention2");
					}
					if (array[0] == 1 && array[1] != 1)
					{
						this.TryStartBubbleFlow(ETuningStandBubbleTriggerType.LinkUp);
						return;
					}
					if (array[0] == array[1])
					{
						this.TryStartBubbleFlow(ETuningStandBubbleTriggerType.LinkMiss);
					}
				}
			}
		}

		// Token: 0x060436AC RID: 276140 RVA: 0x0115D8FC File Offset: 0x0115BAFC
		public EGridCheckReturnState OnHover(TuningGridData data)
		{
			if (!this.IsPressing)
			{
				return EGridCheckReturnState.Empty;
			}
			TuningGridData tuningGridData = this.GridData[this.CurIndex.Value];
			EGridCheckState egridCheckState = this.CheckOpValidState(tuningGridData, data);
			if (egridCheckState == EGridCheckState.EmptyGrid)
			{
				return EGridCheckReturnState.Empty;
			}
			if (egridCheckState == EGridCheckState.Invalid)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_tiaolvtai_attention3");
				return EGridCheckReturnState.Error;
			}
			if (egridCheckState == EGridCheckState.DiffTuneCut)
			{
				this.ClearAllNextPathDynamic(data.Index);
			}
			else if (egridCheckState == EGridCheckState.SameTuneCut)
			{
				int? curIndex = this.CurIndex;
				int index = data.Index;
				if (!(curIndex.GetValueOrDefault() == index & curIndex != null))
				{
					this.PlayAkEvent(false);
				}
				if (!this.ClearAllNextPathDynamic(data.Index))
				{
					tuningGridData.GetCurGridState().Next = null;
				}
				this.CurIndex = new int?(data.Index);
				return EGridCheckReturnState.Valid;
			}
			data.IsStatic = false;
			tuningGridData.GetCurGridState().Next = new int?(data.Index);
			data.DynamicState.State = tuningGridData.GetCurGridState().State;
			data.DynamicState.Prev = this.CurIndex;
			data.DynamicState.Next = null;
			this.CurIndex = new int?(data.Index);
			this.PlayAkEvent(true);
			return EGridCheckReturnState.Valid;
		}

		// Token: 0x060436AD RID: 276141 RVA: 0x0115DA38 File Offset: 0x0115BC38
		protected bool ClearAllNextPathStatic(int head)
		{
			TuningGridData tuningGridData = this.GridData[head];
			if (tuningGridData.StaticState.Next == null)
			{
				return false;
			}
			tuningGridData.IsStatic = true;
			int? next = tuningGridData.StaticState.Next;
			tuningGridData.StaticState.Next = null;
			while (next != null)
			{
				TuningGridData tuningGridData2 = this.GridData[next.Value];
				next = tuningGridData2.StaticState.Next;
				tuningGridData2.IsStatic = true;
				tuningGridData2.StaticState.State = EGridBelongType.Empty;
				tuningGridData2.DynamicState.Next = null;
				tuningGridData2.DynamicState.Prev = null;
				tuningGridData2.StaticState.Next = null;
				tuningGridData2.StaticState.Prev = null;
			}
			Singleton<EventSystem>.Instance.Emit<int?>(EEventName.TuningStandUpdate, null);
			return true;
		}

		// Token: 0x060436AE RID: 276142 RVA: 0x0115DB3C File Offset: 0x0115BD3C
		protected bool ClearAllNextPathDynamic(int head)
		{
			bool flag = false;
			TuningGridData tuningGridData = this.GridData[head];
			if (tuningGridData.IsStatic)
			{
				tuningGridData.IsStatic = false;
				tuningGridData.DynamicState.State = tuningGridData.StaticState.State;
				tuningGridData.DynamicState.Prev = tuningGridData.StaticState.Prev;
				tuningGridData.DynamicState.Next = tuningGridData.StaticState.Next;
			}
			ITuningStateData curGridState = tuningGridData.GetCurGridState();
			EGridBelongType state = curGridState.State;
			int? next = curGridState.Next;
			curGridState.Next = null;
			List<int> list = new List<int>();
			while (next != null)
			{
				TuningGridData tuningGridData2 = this.GridData[next.Value];
				next = tuningGridData2.GetCurGridState().Next;
				if (tuningGridData2.GetCurGridState().State != state)
				{
					return false;
				}
				if (tuningGridData2.StaticState.State != state && tuningGridData2.StaticState.State != EGridBelongType.Empty)
				{
					int value = tuningGridData2.StaticState.Prev.Value;
					TuningGridData tuningGridData3 = this.GridData[value];
					if (tuningGridData3.GetCurGridState().State == tuningGridData3.StaticState.State)
					{
						flag = true;
						list.Add(tuningGridData2.Index);
					}
					else
					{
						tuningGridData2.IsStatic = false;
						tuningGridData2.DynamicState.State = EGridBelongType.Empty;
						tuningGridData2.DynamicState.Next = null;
						tuningGridData2.DynamicState.Prev = null;
					}
				}
				else
				{
					tuningGridData2.IsStatic = false;
					tuningGridData2.DynamicState.State = EGridBelongType.Empty;
					tuningGridData2.DynamicState.Next = null;
					tuningGridData2.DynamicState.Prev = null;
				}
			}
			if (flag)
			{
				int num = this.CheckRecoverLead(list);
				if (num != -1)
				{
					this.RecoverGrid(num);
				}
			}
			Singleton<EventSystem>.Instance.Emit<int?>(EEventName.TuningStandUpdate, null);
			return flag;
		}

		// Token: 0x060436AF RID: 276143 RVA: 0x0115DD48 File Offset: 0x0115BF48
		protected void SaveDynamicGrid()
		{
			foreach (TuningGridData tuningGridData in this.GridData)
			{
				if (!tuningGridData.IsStatic)
				{
					tuningGridData.IsStatic = true;
					tuningGridData.StaticState.State = tuningGridData.DynamicState.State;
					tuningGridData.StaticState.Next = tuningGridData.DynamicState.Next;
					tuningGridData.StaticState.Prev = tuningGridData.DynamicState.Prev;
					tuningGridData.DynamicState.State = EGridBelongType.Empty;
					tuningGridData.DynamicState.Next = null;
					tuningGridData.DynamicState.Prev = null;
				}
			}
			foreach (TuningGridData tuningGridData2 in this.GridData)
			{
				int? next = tuningGridData2.StaticState.Next;
				if (next != null && this.GridData[next.Value].StaticState.State != tuningGridData2.StaticState.State)
				{
					tuningGridData2.StaticState.Next = null;
				}
			}
		}

		// Token: 0x060436B0 RID: 276144 RVA: 0x0115DEB0 File Offset: 0x0115C0B0
		protected bool CheckAllClear()
		{
			foreach (TuningGridData tuningGridData in this.GridData)
			{
				if (tuningGridData.GridMainType != EGridMainType.Empty && tuningGridData.StaticState.State == EGridBelongType.Empty)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060436B1 RID: 276145 RVA: 0x0115DF18 File Offset: 0x0115C118
		protected int[] CheckEndCount()
		{
			int[] array = new int[2];
			foreach (TuningGridData tuningGridData in this.GridData)
			{
				if (tuningGridData.GridMainType == EGridMainType.End)
				{
					array[1]++;
					if (tuningGridData.StaticState.State != EGridBelongType.Empty)
					{
						array[0]++;
					}
				}
			}
			return array;
		}

		// Token: 0x060436B2 RID: 276146 RVA: 0x0115DF9C File Offset: 0x0115C19C
		protected int CheckRecoverLead(List<int> recoverList)
		{
			int count = recoverList.Count;
			if (count == 1)
			{
				return recoverList[0];
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (int key in recoverList)
			{
				dictionary[key] = 0;
			}
			foreach (int num in recoverList)
			{
				if (dictionary[num] != -1)
				{
					for (int? next = new int?(num); next != null; next = this.GridData[next.Value].StaticState.Next)
					{
						if (dictionary.ContainsKey(next.Value))
						{
							int num2 = dictionary[next.Value];
							int? num3 = next;
							int num4 = num;
							if (num3.GetValueOrDefault() == num4 & num3 != null)
							{
								dictionary[num] = 1;
							}
							else
							{
								if (num2 != 0)
								{
									dictionary[num] = num2 + 1;
									break;
								}
								dictionary[next.Value] = -1;
								dictionary[num]++;
							}
						}
					}
				}
			}
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				if (keyValuePair.Value == count)
				{
					return keyValuePair.Key;
				}
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelPlay;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "Check Recover Leading Error";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RecoverList", recoverList);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return -1;
		}

		// Token: 0x060436B3 RID: 276147 RVA: 0x0115E17C File Offset: 0x0115C37C
		protected void RecoverGrid(int head)
		{
			TuningGridData tuningGridData = this.GridData[head];
			int? next = new int?(head);
			EGridBelongType state = tuningGridData.StaticState.State;
			while (next != null)
			{
				TuningGridData tuningGridData2 = this.GridData[next.Value];
				int? num = next;
				if (!(head == num.GetValueOrDefault() & num != null) && tuningGridData2.GetCurGridState().State != EGridBelongType.Empty && tuningGridData2.GetCurGridState().State != state)
				{
					return;
				}
				next = tuningGridData2.StaticState.Next;
				tuningGridData2.IsStatic = true;
				tuningGridData2.DynamicState.Next = null;
				tuningGridData2.DynamicState.Prev = null;
			}
		}

		// Token: 0x060436B4 RID: 276148 RVA: 0x0115E23C File Offset: 0x0115C43C
		private void StartRevolving()
		{
			List<int> list = new List<int>();
			foreach (TuningGridData tuningGridData in this.GridData)
			{
				if (tuningGridData.GridMainType == EGridMainType.Start)
				{
					list.Add(tuningGridData.Index);
				}
			}
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.TuningStandSuccessShowStart, list);
		}

		// Token: 0x060436B5 RID: 276149 RVA: 0x0115E2B4 File Offset: 0x0115C4B4
		protected void CreateEventList()
		{
			this.EventList.Clear();
			string noteSequence = this.Config.NoteSequence;
			foreach (string node in ((noteSequence != null) ? noteSequence.Split(',', StringSplitOptions.None) : null) ?? Array.Empty<string>())
			{
				TuningStandConfig instance = ConfigBase<TuningStandConfig>.Instance;
				string text = (instance != null) ? instance.GetEvent(node) : null;
				if (text != null)
				{
					this.EventList.Add(text);
				}
			}
		}

		// Token: 0x060436B6 RID: 276150 RVA: 0x0115E324 File Offset: 0x0115C524
		protected void PlayStartEvent()
		{
			if (this.CurAkTime + 0.05000000074505806 > Singleton<Time>.Instance.Now)
			{
				return;
			}
			if (this.CurNodeIndex >= this.EventList.Count)
			{
				this.CurNodeIndex = 0;
			}
			Singleton<AudioSystem>.Instance.PostEvent(this.EventList[this.CurNodeIndex]);
			this.CurAkTime = Singleton<Time>.Instance.Now;
		}

		// Token: 0x060436B7 RID: 276151 RVA: 0x0115E394 File Offset: 0x0115C594
		protected void PlayAkEvent(bool isForward)
		{
			if (this.EventList.Count == 0)
			{
				return;
			}
			if (this.CurAkTime + 0.05000000074505806 > Singleton<Time>.Instance.Now)
			{
				return;
			}
			if (isForward)
			{
				this.CurNodeIndex++;
				if (this.CurNodeIndex >= this.EventList.Count)
				{
					this.CurNodeIndex = 0;
				}
			}
			else
			{
				this.CurNodeIndex--;
				if (this.CurNodeIndex < 0)
				{
					this.CurNodeIndex = this.EventList.Count - 1;
				}
			}
			Singleton<AudioSystem>.Instance.PostEvent(this.EventList[this.CurNodeIndex]);
			this.CurAkTime = Singleton<Time>.Instance.Now;
		}

		// Token: 0x060436B8 RID: 276152 RVA: 0x0115E44F File Offset: 0x0115C64F
		protected void InitTalkBubble()
		{
			if (this.Config.VisualType == ETuningStandVisualType.Challenge || this.Config.BubbleConfig == null)
			{
				this.BubbleProxy = null;
				return;
			}
			this.BubbleProxy = new TuningStandBubbleProxy(this.Config.BubbleConfig);
		}

		// Token: 0x060436B9 RID: 276153 RVA: 0x0115E48A File Offset: 0x0115C68A
		public bool TryStartBubbleFlow(ETuningStandBubbleTriggerType type)
		{
			return this.BubbleProxy != null && this.BubbleProxy.TryStartBubbleFlow(type);
		}

		// Token: 0x060436BA RID: 276154 RVA: 0x0115E4A2 File Offset: 0x0115C6A2
		public void ProcessTooLong()
		{
			this.TryStartBubbleFlow(ETuningStandBubbleTriggerType.TooLong);
		}

		// Token: 0x060436BB RID: 276155 RVA: 0x0115E4AC File Offset: 0x0115C6AC
		protected void DestroyBubble()
		{
			TuningStandBubbleProxy bubbleProxy = this.BubbleProxy;
			if (bubbleProxy != null)
			{
				bubbleProxy.Destroy();
			}
			this.BubbleProxy = null;
		}

		// Token: 0x04025A59 RID: 154201
		[Nullable(2)]
		protected ITuningStand Config;

		// Token: 0x04025A5A RID: 154202
		protected List<TuningGridData> GridData = new List<TuningGridData>();

		// Token: 0x04025A5B RID: 154203
		protected int? CurIndex;

		// Token: 0x04025A5C RID: 154204
		protected int CurNodeIndex;

		// Token: 0x04025A5D RID: 154205
		protected bool IsPressing;

		// Token: 0x04025A5E RID: 154206
		[Nullable(2)]
		protected TuningStandBubbleProxy BubbleProxy;

		// Token: 0x04025A5F RID: 154207
		protected double PrevResetTime;

		// Token: 0x04025A60 RID: 154208
		protected int ResetTimes;

		// Token: 0x04025A61 RID: 154209
		protected List<string> EventList = new List<string>();

		// Token: 0x04025A62 RID: 154210
		protected double CurAkTime;
	}
}
