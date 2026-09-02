using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Typing;

// Token: 0x020032D2 RID: 13010
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RedDotSystem : Singleton<RedDotSystem>, ITickable
{
	// Token: 0x0601B4AE RID: 111790 RVA: 0x00832FBC File Offset: 0x008311BC
	public void PushToEventQueue(TRedDotCheckEvent @event, int id, ERedDotName redDotName)
	{
		string key = redDotName.ToEnumString() + id.ToString();
		if (this.RedDotRepeatMap.ContainsKey(key))
		{
			return;
		}
		RedDotEventData currentEventData = this.CurrentEventData;
		if (((currentEventData != null) ? currentEventData.RedDotName : null) == redDotName.ToEnumString())
		{
			RedDotEventData currentEventData2 = this.CurrentEventData;
			if (currentEventData2 != null && currentEventData2.Id == id)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RedDot;
				ELogAuthor author = ELogAuthor.CX;
				string message = "红点处理存在循环调用, 详情见堆栈";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("红点名", redDotName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
		}
		RedDotEventData redDotEventData = this.GetRedDotEventData(@event, id, redDotName.ToEnumString());
		LinkedNode<RedDotEventData> value = this.RedDotEventLinkedList.AddTail(redDotEventData);
		this.RedDotRepeatMap[key] = value;
	}

	// Token: 0x0601B4AF RID: 111791 RVA: 0x00833078 File Offset: 0x00831278
	public void PopRedDotEventData(int id, ERedDotName redDotName)
	{
		string key = redDotName.ToEnumString() + id.ToString();
		if (!this.RedDotRepeatMap.ContainsKey(key))
		{
			return;
		}
		RedDotEventData currentEventData = this.CurrentEventData;
		if (((currentEventData != null) ? currentEventData.RedDotName : null) == redDotName.ToEnumString())
		{
			RedDotEventData currentEventData2 = this.CurrentEventData;
			if (currentEventData2 != null && currentEventData2.Id == id)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RedDot;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "红点处理存在在当前事件中移除自身";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("红点名", redDotName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
		}
		LinkedNode<RedDotEventData> linkedNode;
		if (this.RedDotRepeatMap.TryGetValue(key, out linkedNode))
		{
			this.RedDotEventLinkedList.RemoveNode(linkedNode);
			this.RedDotRepeatMap.Remove(key);
			this.RedDotEventRecycleList.Add(linkedNode.Element);
		}
	}

	// Token: 0x0601B4B0 RID: 111792 RVA: 0x00833144 File Offset: 0x00831344
	private void HandleRedDotData()
	{
		LinkedNode<RedDotEventData> headNextNode = this.RedDotEventLinkedList.GetHeadNextNode();
		RedDotEventData element = headNextNode.Element;
		this.CurrentEventData = element;
		this.RedDotEventLinkedList.RemoveNode(headNextNode);
		this.RedDotRepeatMap.Remove(element.RedDotName + element.Id.ToString());
		element.HandleEvent();
		this.CurrentEventData = null;
		this.RedDotEventRecycleList.Add(element);
	}

	// Token: 0x0601B4B1 RID: 111793 RVA: 0x008331B8 File Offset: 0x008313B8
	public void Tick(float deltaTime)
	{
		GameModeModel instance = ModelBase<GameModeModel>.Instance;
		if (instance == null || instance.LoadingPhase != ELoadingPhase.Finished)
		{
			return;
		}
		int count = this.RedDotEventLinkedList.Count;
		if (count <= 0)
		{
			return;
		}
		int num = count;
		while (this.TickRemainingTime > 0.0 && num > 0)
		{
			double microseconds = KuroTime.GetMicroseconds64();
			this.HandleRedDotData();
			double num2 = KuroTime.GetMicroseconds64() - microseconds;
			this.TickRemainingTime -= num2;
			num--;
		}
		FKuroPerfSightHelper.PostValueFloat1("RedDot", "RedDotCostPerFrame", (float)((long)(((double)this.TICK_TOTAL_TIME - this.TickRemainingTime) / 1000.0)));
		this.TickRemainingTime = (double)this.TICK_TOTAL_TIME;
	}

	// Token: 0x0601B4B2 RID: 111794 RVA: 0x0083326C File Offset: 0x0083146C
	public RedDotEventData GetRedDotEventData(TRedDotCheckEvent @event, int id, string redDotName)
	{
		if (this.RedDotEventRecycleList.Count > 0)
		{
			List<RedDotEventData> redDotEventRecycleList = this.RedDotEventRecycleList;
			RedDotEventData redDotEventData = redDotEventRecycleList[redDotEventRecycleList.Count - 1];
			this.RedDotEventRecycleList.RemoveAt(this.RedDotEventRecycleList.Count - 1);
			redDotEventData.Event = @event;
			redDotEventData.Id = id;
			redDotEventData.RedDotName = redDotName;
			return redDotEventData;
		}
		return new RedDotEventData(@event, id, redDotName);
	}

	// Token: 0x0400DF7E RID: 57214
	private readonly global::LinkedList<RedDotEventData> RedDotEventLinkedList = new global::LinkedList<RedDotEventData>(new RedDotEventData(delegate(int uId)
	{
	}, 0, ""));

	// Token: 0x0400DF7F RID: 57215
	private readonly List<RedDotEventData> RedDotEventRecycleList = new List<RedDotEventData>();

	// Token: 0x0400DF80 RID: 57216
	private readonly Dictionary<string, LinkedNode<RedDotEventData>> RedDotRepeatMap = new Dictionary<string, LinkedNode<RedDotEventData>>();

	// Token: 0x0400DF81 RID: 57217
	[Nullable(2)]
	private RedDotEventData CurrentEventData;

	// Token: 0x0400DF82 RID: 57218
	private float TICK_TOTAL_TIME = 500f;

	// Token: 0x0400DF83 RID: 57219
	private double TickRemainingTime = 500.0;

	// Token: 0x0400DF84 RID: 57220
	public bool IsOpenLogCallTime;
}
