using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Core.Utils.StateMachine
{
	// Token: 0x0200711B RID: 28955
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class StateMachineCommon<[Nullable(2)] TObject, [Nullable(2)] TState>
	{
		// Token: 0x1700A5F4 RID: 42484
		// (get) Token: 0x06046240 RID: 287296 RVA: 0x0126C09C File Offset: 0x0126A29C
		public bool HasSubNode
		{
			get
			{
				return this.HasSubNodeInternal;
			}
		}

		// Token: 0x1700A5F5 RID: 42485
		// (get) Token: 0x06046241 RID: 287297 RVA: 0x0126C0A4 File Offset: 0x0126A2A4
		public bool Activated
		{
			get
			{
				return this.ActivatedInternal;
			}
		}

		// Token: 0x1700A5F6 RID: 42486
		// (get) Token: 0x06046242 RID: 287298 RVA: 0x0126C0AC File Offset: 0x0126A2AC
		public virtual StateMachineCommon<TObject, TState> CurrentLeafNode
		{
			get
			{
				if (this.CurrentNode == null)
				{
					return this;
				}
				return this.CurrentNode.CurrentLeafNode;
			}
		}

		// Token: 0x06046243 RID: 287299 RVA: 0x0126C0C3 File Offset: 0x0126A2C3
		public StateMachineCommon(TObject owner, TState state, [Nullable(new byte[]
		{
			2,
			1,
			1
		})] StateMachineCommon<TObject, TState> parent = null)
		{
			this.Owner = owner;
			this.State = state;
			this.Parent = parent;
		}

		// Token: 0x1700A5F7 RID: 42487
		// (get) Token: 0x06046244 RID: 287300 RVA: 0x0126C0EB File Offset: 0x0126A2EB
		public StateMachineCommon<TObject, TState> Root
		{
			get
			{
				if (this.Parent == null)
				{
					return this;
				}
				return this.Parent.Root;
			}
		}

		// Token: 0x06046245 RID: 287301 RVA: 0x0126C102 File Offset: 0x0126A302
		public void Tick(float delta)
		{
			StateMachineCommon<TObject, TState> currentNode = this.CurrentNode;
			if (currentNode != null)
			{
				currentNode.Tick(delta);
			}
			this.OnTick(delta);
		}

		// Token: 0x06046246 RID: 287302 RVA: 0x0126C11D File Offset: 0x0126A31D
		public void Start(params object[] pairs)
		{
			if (this.Parent != null)
			{
				this.Parent.Start(Array.Empty<object>());
				this.Parent.CurrentNode = this;
			}
			this.Enter(null, true, false, pairs);
		}

		// Token: 0x06046247 RID: 287303 RVA: 0x0126C150 File Offset: 0x0126A350
		public void Enter([Nullable(new byte[]
		{
			2,
			1,
			1
		})] StateMachineCommon<TObject, TState> lastState = null, bool triggerEvent = true, bool triggerSubNode = true, params object[] pairs)
		{
			this.ActivatedInternal = true;
			this.OnActivate(lastState, pairs);
			if (triggerEvent)
			{
				this.OnEnter(lastState, pairs);
			}
			if (triggerSubNode && this.HasSubNodeInternal && this.FirstState != null)
			{
				this.CurrentNode = this.GetState(this.FirstState);
				if (this.CurrentNode != null)
				{
					this.CurrentNode.Enter(null, triggerEvent, true, pairs);
					if (new Action<StateMachineCommon<TObject, TState>, StateMachineCommon<TObject, TState>>(this.OnSwitchState) != null)
					{
						this.OnSwitchState(null, this.CurrentNode);
						return;
					}
				}
				else
				{
					Singleton<Log>.Instance.Error(ELogModule.StateMachine, ELogAuthor.WCL, "状态机切换失败，子节点查找失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
		}

		// Token: 0x06046248 RID: 287304 RVA: 0x0126C1F4 File Offset: 0x0126A3F4
		private void ReEnter()
		{
			this.OnReEnter();
		}

		// Token: 0x06046249 RID: 287305 RVA: 0x0126C1FC File Offset: 0x0126A3FC
		public void Exit([Nullable(new byte[]
		{
			2,
			1,
			1
		})] StateMachineCommon<TObject, TState> nextState = null, bool triggerEvent = true, bool triggerSubNode = true, params object[] pairs)
		{
			if (triggerSubNode && this.CurrentNode != null)
			{
				this.OnSwitchState(this.CurrentNode, null);
				this.CurrentNode.Exit(nextState, triggerEvent, triggerSubNode, pairs);
			}
			this.OnDeactivate(nextState, pairs);
			this.OnExit(nextState, pairs);
			this.ActivatedInternal = false;
			this.CurrentNode = null;
		}

		// Token: 0x0604624A RID: 287306 RVA: 0x0126C254 File Offset: 0x0126A454
		public void Clear()
		{
			foreach (StateMachineCommon<TObject, TState> stateMachineCommon in this.StateMap.Values)
			{
				stateMachineCommon.Clear();
			}
			this.OnClear();
			this.StateMap.Clear();
			this.Parent = null;
			this.FirstState = default(TState);
		}

		// Token: 0x0604624B RID: 287307 RVA: 0x0126C2D0 File Offset: 0x0126A4D0
		public virtual bool CanReEnter()
		{
			return false;
		}

		// Token: 0x0604624C RID: 287308 RVA: 0x0126C2D3 File Offset: 0x0126A4D3
		protected virtual void OnTick(float delta)
		{
		}

		// Token: 0x0604624D RID: 287309 RVA: 0x0126C2D5 File Offset: 0x0126A4D5
		protected virtual void OnEnter([Nullable(new byte[]
		{
			2,
			1,
			1
		})] StateMachineCommon<TObject, TState> lastState = null, params object[] pairs)
		{
		}

		// Token: 0x0604624E RID: 287310 RVA: 0x0126C2D7 File Offset: 0x0126A4D7
		protected virtual void OnReEnter()
		{
		}

		// Token: 0x0604624F RID: 287311 RVA: 0x0126C2D9 File Offset: 0x0126A4D9
		protected virtual void OnExit([Nullable(new byte[]
		{
			2,
			1,
			1
		})] StateMachineCommon<TObject, TState> nextState = null, params object[] pairs)
		{
		}

		// Token: 0x06046250 RID: 287312 RVA: 0x0126C2DB File Offset: 0x0126A4DB
		protected virtual void OnClear()
		{
		}

		// Token: 0x06046251 RID: 287313 RVA: 0x0126C2DD File Offset: 0x0126A4DD
		protected virtual void OnActivate([Nullable(new byte[]
		{
			2,
			1,
			1
		})] StateMachineCommon<TObject, TState> last = null, params object[] pairs)
		{
		}

		// Token: 0x06046252 RID: 287314 RVA: 0x0126C2DF File Offset: 0x0126A4DF
		protected virtual void OnDeactivate([Nullable(new byte[]
		{
			2,
			1,
			1
		})] StateMachineCommon<TObject, TState> next = null, params object[] pairs)
		{
		}

		// Token: 0x06046253 RID: 287315 RVA: 0x0126C2E1 File Offset: 0x0126A4E1
		protected virtual void OnSwitchState([Nullable(new byte[]
		{
			2,
			1,
			1
		})] StateMachineCommon<TObject, TState> lastState, [Nullable(new byte[]
		{
			2,
			1,
			1
		})] StateMachineCommon<TObject, TState> nextState)
		{
		}

		// Token: 0x06046254 RID: 287316 RVA: 0x0126C2E4 File Offset: 0x0126A4E4
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public StateMachineCommon<TObject, TState> GetState(TState state)
		{
			StateMachineCommon<TObject, TState> result;
			if (this.StateMap.TryGetValue(state, out result))
			{
				return result;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.StateMachine;
			ELogAuthor author = ELogAuthor.HCS;
			string message = "状态不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x06046255 RID: 287317 RVA: 0x0126C330 File Offset: 0x0126A530
		public void AddState(TState state, Func<TObject, TState, StateMachineCommon<TObject, TState>, StateMachineCommon<TObject, TState>> ctor)
		{
			if (this.FirstState == null || EqualityComparer<TState>.Default.Equals(this.FirstState, default(TState)))
			{
				this.FirstState = state;
			}
			StateMachineCommon<TObject, TState> value = ctor(this.Owner, state, this);
			if (!this.StateMap.TryAdd(state, value))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.StateMachine;
				ELogAuthor author = ELogAuthor.WCL;
				string message = "状态重复添加";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.HasSubNodeInternal = true;
		}

		// Token: 0x06046256 RID: 287318 RVA: 0x0126C3C0 File Offset: 0x0126A5C0
		public void AddStateInstance(TState state, StateMachineCommon<TObject, TState> node)
		{
			if (this.FirstState == null || EqualityComparer<TState>.Default.Equals(this.FirstState, default(TState)))
			{
				this.FirstState = state;
			}
			if (!this.StateMap.TryAdd(state, node))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.StateMachine;
				ELogAuthor author = ELogAuthor.WCL;
				string message = "状态重复添加";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.HasSubNodeInternal = true;
		}

		// Token: 0x06046257 RID: 287319 RVA: 0x0126C440 File Offset: 0x0126A640
		public bool Switch(TState state, bool triggerEvent = true, bool triggerSubNode = true, params object[] pairs)
		{
			if (this.CurrentNode == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.StateMachine;
				ELogAuthor author = ELogAuthor.WCL;
				string message = "状态机没有启动";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			StateMachineCommon<TObject, TState> state2 = this.GetState(state);
			if (state2 == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.StateMachine;
				ELogAuthor author2 = ELogAuthor.WCL;
				string message2 = "状态机切换失败，目标节点不存在";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("state", state);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			if (!EqualityComparer<TState>.Default.Equals(state, this.CurrentNode.State))
			{
				StateMachineCommon<TObject, TState> currentNode = this.CurrentNode;
				currentNode.Exit(state2, triggerEvent, triggerSubNode, pairs);
				this.CurrentNode = state2;
				state2.Enter(currentNode, triggerEvent, triggerSubNode, pairs);
				this.OnSwitchState(currentNode, state2);
				return true;
			}
			if (!this.CurrentNode.CanReEnter())
			{
				return false;
			}
			this.CurrentNode.ReEnter();
			return true;
		}

		// Token: 0x0402755C RID: 161116
		public readonly TObject Owner;

		// Token: 0x0402755D RID: 161117
		public readonly TState State;

		// Token: 0x0402755E RID: 161118
		[Nullable(2)]
		public TState FirstState;

		// Token: 0x0402755F RID: 161119
		private readonly Dictionary<TState, StateMachineCommon<TObject, TState>> StateMap = new Dictionary<TState, StateMachineCommon<TObject, TState>>();

		// Token: 0x04027560 RID: 161120
		private bool HasSubNodeInternal;

		// Token: 0x04027561 RID: 161121
		private bool ActivatedInternal;

		// Token: 0x04027562 RID: 161122
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public StateMachineCommon<TObject, TState> CurrentNode;

		// Token: 0x04027563 RID: 161123
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public StateMachineCommon<TObject, TState> Parent;
	}
}
