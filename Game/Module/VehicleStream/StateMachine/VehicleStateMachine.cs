using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.VehicleStream.StateMachine.States;

namespace CSharpScript.Game.Module.VehicleStream.StateMachine
{
	// Token: 0x02004C52 RID: 19538
	[NullableContext(2)]
	[Nullable(0)]
	public class VehicleStateMachine
	{
		// Token: 0x06032E70 RID: 208496 RVA: 0x00CBFCCC File Offset: 0x00CBDECC
		public bool Start(EVehicleStateType state)
		{
			if (this.CurrentNode != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.VehicleStream;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "状态机重复启动";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			this.CurrentNode = this.GetState(state);
			if (this.CurrentNode == null)
			{
				return false;
			}
			this.CurrentNode.Enter(EVehicleStateType.None, null);
			return true;
		}

		// Token: 0x06032E71 RID: 208497 RVA: 0x00CBFD38 File Offset: 0x00CBDF38
		public void Destroy()
		{
			foreach (VehicleStateBase vehicleStateBase in this.StateMap.Values)
			{
				vehicleStateBase.Destroy();
			}
		}

		// Token: 0x06032E72 RID: 208498 RVA: 0x00CBFD90 File Offset: 0x00CBDF90
		public void Update(float delta)
		{
			if (this.CurrentNode == null)
			{
				return;
			}
			this.CurrentNode.Update(delta);
		}

		// Token: 0x06032E73 RID: 208499 RVA: 0x00CBFDA7 File Offset: 0x00CBDFA7
		public void OnEnterPlayerRange()
		{
			if (this.CurrentNode == null)
			{
				return;
			}
			this.CurrentNode.OnEnterPlayerRange();
		}

		// Token: 0x06032E74 RID: 208500 RVA: 0x00CBFDBD File Offset: 0x00CBDFBD
		public void OnLeavePlayerRange()
		{
			if (this.CurrentNode == null)
			{
				return;
			}
			this.CurrentNode.OnLeavePlayerRange();
		}

		// Token: 0x06032E75 RID: 208501 RVA: 0x00CBFDD4 File Offset: 0x00CBDFD4
		public bool Switch(EVehicleStateType state, string reason = null)
		{
			if (this.CurrentNode == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.VehicleStream;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "状态机没有开始";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			VehicleStateBase state2 = this.GetState(state);
			if (state2 == null)
			{
				return false;
			}
			EVehicleStateType state3 = this.CurrentNode.State;
			this.CurrentNode.Exit(state);
			this.CurrentNode = state2;
			this.CurrentNode.Enter(state3, reason);
			return true;
		}

		// Token: 0x06032E76 RID: 208502 RVA: 0x00CBFE54 File Offset: 0x00CBE054
		[NullableContext(1)]
		public void AddState(EVehicleStateType stateType, VehicleStateBase state)
		{
			if (this.StateMap.ContainsKey(stateType))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.VehicleStream;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "状态重复添加";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", stateType);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.StateMap[stateType] = state;
		}

		// Token: 0x06032E77 RID: 208503 RVA: 0x00CBFEAC File Offset: 0x00CBE0AC
		public VehicleStateBase GetState(EVehicleStateType state)
		{
			VehicleStateBase result;
			if (!this.StateMap.TryGetValue(state, out result))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.VehicleStream;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "状态不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return result;
		}

		// Token: 0x06032E78 RID: 208504 RVA: 0x00CBFEF9 File Offset: 0x00CBE0F9
		public EVehicleStateType GetCurrentState()
		{
			VehicleStateBase currentNode = this.CurrentNode;
			if (currentNode == null)
			{
				return EVehicleStateType.None;
			}
			return currentNode.State;
		}

		// Token: 0x0401DA3D RID: 121405
		[Nullable(1)]
		private readonly Dictionary<EVehicleStateType, VehicleStateBase> StateMap = new Dictionary<EVehicleStateType, VehicleStateBase>();

		// Token: 0x0401DA3E RID: 121406
		private VehicleStateBase CurrentNode;
	}
}
