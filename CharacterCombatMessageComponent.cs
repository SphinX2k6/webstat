using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.CombatMessage;
using Google.Protobuf;

// Token: 0x02003034 RID: 12340
[NullableContext(1)]
[Nullable(0)]
public class CharacterCombatMessageComponent : EntityComponent
{
	// Token: 0x060193BC RID: 103356 RVA: 0x007394C8 File Offset: 0x007376C8
	public unsafe void AddToQueue(ENotifyMessageId id, CombatCommon combatCommon, IMessage message, double executeTime)
	{
		this.MessageQueue.Push(new TCombatMessage(combatCommon, id, message, executeTime));
		if (this.MessageQueue.Size >= 50)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Message;
			Entity entity = base.Entity;
			string message2 = "战斗消息缓冲满了";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsInit", base.Entity.IsInit);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Active", base.Entity.Active);
			instance.Warn(flag, entity, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			TCombatMessage combatMessage = this.MessageQueue.Pop();
			this.ProcessCombatMessage(combatMessage);
		}
	}

	// Token: 0x060193BD RID: 103357 RVA: 0x00739584 File Offset: 0x00737784
	protected unsafe override void OnActivate()
	{
		while (this.MessageQueue.Size > 0)
		{
			TCombatMessage tcombatMessage = this.MessageQueue.Pop();
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Notify;
			Entity entity = base.Entity;
			string message = "协议OnActivate执行";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Message", tcombatMessage.MessageId.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CombatCommon", tcombatMessage.CombatCommon);
			instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.ProcessCombatMessage(tcombatMessage);
		}
		ControllerBase<CombatMessageController>.Instance.RegisterPreTick(this, new Action<float>(this.PreTickInternal));
	}

	// Token: 0x060193BE RID: 103358 RVA: 0x00739640 File Offset: 0x00737840
	protected unsafe override bool OnEnd()
	{
		while (this.MessageQueue.Size > 0)
		{
			TCombatMessage tcombatMessage = this.MessageQueue.Pop();
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Notify;
			Entity entity = base.Entity;
			string message = "OnEnd未执行的协议，已抛弃";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Message", tcombatMessage.MessageId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CombatCommon", tcombatMessage.CombatCommon);
			instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		ControllerBase<CombatMessageController>.Instance.UnregisterPreTick(this);
		return true;
	}

	// Token: 0x060193BF RID: 103359 RVA: 0x007396DC File Offset: 0x007378DC
	private void PreTickInternal(float _)
	{
		while (this.MessageQueue.Size > 0)
		{
			TCombatMessage front = this.MessageQueue.Front;
			if (front == null)
			{
				break;
			}
			if (Singleton<Time>.Instance.NowSeconds < front.ExecuteTime)
			{
				if (this.MessageQueue.Size < 50)
				{
					break;
				}
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Message;
				Entity entity = base.Entity;
				string message = "战斗缓冲满，立即执行";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", front.MessageId);
				instance.Warn(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.MessageQueue.Pop();
			this.ProcessCombatMessage(front);
		}
	}

	// Token: 0x060193C0 RID: 103360 RVA: 0x00739774 File Offset: 0x00737974
	private unsafe void ProcessCombatMessage(TCombatMessage combatMessage)
	{
		try
		{
			ControllerBase<CombatMessageController>.Instance.Process(combatMessage.MessageId, base.Entity, combatMessage.Message, combatMessage.CombatCommon);
		}
		catch (Exception ex)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CombatInfo;
			ELogAuthor author = ELogAuthor.WCL;
			string message = "战斗协议执行回调方法异常";
			Exception error = ex;
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("messageId", combatMessage.MessageId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x060193C1 RID: 103361 RVA: 0x00739820 File Offset: 0x00737A20
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterCombatMessageComponent characterCombatMessageComponent = (CharacterCombatMessageComponent)componentTemplate;
		return !base.CanResetComponentProperty("MessageQueue") || characterCombatMessageComponent.MessageQueue == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Queue<TCombatMessage>>(this.MessageQueue), "MessageQueue");
	}

	// Token: 0x0400C68F RID: 50831
	private const int MESSAGE_BUFFER_MAX_SIZE = 50;

	// Token: 0x0400C690 RID: 50832
	private readonly Queue<TCombatMessage> MessageQueue = new Queue<TCombatMessage>(50);
}
