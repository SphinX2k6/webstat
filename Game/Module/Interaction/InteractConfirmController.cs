using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005BA1 RID: 23457
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InteractConfirmController : Singleton<InteractConfirmController>
	{
		// Token: 0x0603B53E RID: 243006 RVA: 0x00F06348 File Offset: 0x00F04548
		public void RegisterActions()
		{
			this.SetupAction<CommonConfirmBoxAction>(EInteractionConfirmBoxType.Common, () => new CommonConfirmBoxAction());
			this.SetupAction<HonamiStoryConfirmBoxAction>(EInteractionConfirmBoxType.HonamiStoryCorruptedChest, () => new HonamiStoryConfirmBoxAction());
			this.SetupAction<HonamiStoryLeaveTipAction>(EInteractionConfirmBoxType.HonamiStoryEvacuateConfirm, () => new HonamiStoryLeaveTipAction());
		}

		// Token: 0x0603B53F RID: 243007 RVA: 0x00F063C8 File Offset: 0x00F045C8
		private void SetupAction<[Nullable(0)] T>(EInteractionConfirmBoxType type, Func<T> ctor) where T : InteractConfirmActionBase
		{
			if (this.ActionMap.ContainsKey(type))
			{
				return;
			}
			T t = ctor();
			this.ActionMap[type] = t;
		}

		// Token: 0x0603B540 RID: 243008 RVA: 0x00F06400 File Offset: 0x00F04600
		public int HandleAction(CommonInteractOption option, Action<int, bool, CommonInteractOption> confirmCallback)
		{
			if (option2 == null || option2.ConfirmBox == null)
			{
				return 0;
			}
			InteractConfirmActionBase action = this.GetAction(option2.ConfirmBox.Type.Type);
			if (action == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Interaction;
				ELogAuthor author = ELogAuthor.FJH;
				string message = "[交互二次确认] 未注册的二次确认类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("二次确认类型", option2.ConfirmBox.Type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			if (this.ExecutingAction != null)
			{
				this.ExecutingAction.Value.Item2.Cancel();
			}
			int handleId = this.HandleId;
			this.HandleId = handleId + 1;
			int num = handleId;
			InteractSecondConfirmContext interactSecondConfirmContext = InteractSecondConfirmContext.Create(num, option2);
			interactSecondConfirmContext.ConfirmCallback = delegate(int handle, bool confirmResult, CommonInteractOption option)
			{
				if (this.CheckHandleValid(handle))
				{
					confirmCallback(handle, confirmResult, option);
					this.ExecutingAction = null;
				}
			};
			if (!action.Execute(interactSecondConfirmContext))
			{
				return 0;
			}
			this.ExecutingAction = new ValueTuple<int, InteractConfirmActionBase>?(new ValueTuple<int, InteractConfirmActionBase>(num, action));
			return num;
		}

		// Token: 0x0603B541 RID: 243009 RVA: 0x00F064F0 File Offset: 0x00F046F0
		public void CancelAction(int handle)
		{
			if (this.ExecutingAction != null && this.ExecutingAction.GetValueOrDefault().Item1 == handle)
			{
				this.ExecutingAction.Value.Item2.Cancel();
				this.ExecutingAction = null;
			}
		}

		// Token: 0x0603B542 RID: 243010 RVA: 0x00F06540 File Offset: 0x00F04740
		[NullableContext(2)]
		public InteractConfirmActionBase GetAction(EInteractionConfirmBoxType type)
		{
			InteractConfirmActionBase result;
			if (this.ActionMap.TryGetValue(type, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0603B543 RID: 243011 RVA: 0x00F06560 File Offset: 0x00F04760
		public void ReleaseAction(EInteractionConfirmBoxType type)
		{
			if (!this.ActionMap.ContainsKey(type))
			{
				return;
			}
			this.ActionMap.Remove(type);
		}

		// Token: 0x0603B544 RID: 243012 RVA: 0x00F0657E File Offset: 0x00F0477E
		public bool CheckHandleValid(int handle)
		{
			return this.ExecutingAction != null && this.ExecutingAction.GetValueOrDefault().Item1 == handle;
		}

		// Token: 0x0603B545 RID: 243013 RVA: 0x00F0659E File Offset: 0x00F0479E
		public void Clear()
		{
			if (this.ExecutingAction != null)
			{
				this.ExecutingAction.Value.Item2.Cancel();
			}
			this.ExecutingAction = null;
			this.ActionMap.Clear();
		}

		// Token: 0x04021707 RID: 136967
		private readonly Dictionary<EInteractionConfirmBoxType, InteractConfirmActionBase> ActionMap = new Dictionary<EInteractionConfirmBoxType, InteractConfirmActionBase>();

		// Token: 0x04021708 RID: 136968
		private int HandleId = 1;

		// Token: 0x04021709 RID: 136969
		[Nullable(new byte[]
		{
			0,
			1
		})]
		private ValueTuple<int, InteractConfirmActionBase>? ExecutingAction;
	}
}
