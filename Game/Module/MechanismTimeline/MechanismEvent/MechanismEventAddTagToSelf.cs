using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.Module.MechanismTimeline.MechanismEvent
{
	// Token: 0x020057E0 RID: 22496
	[NullableContext(1)]
	[Nullable(0)]
	public class MechanismEventAddTagToSelf : MechanismEventBase
	{
		// Token: 0x06039293 RID: 234131 RVA: 0x00E7DBDA File Offset: 0x00E7BDDA
		public MechanismEventAddTagToSelf(IMechanismEventInfo eventInfo, MechanismEventContext context, SceneItemEventListenerComponent eventListenerComponent, bool isServerAction) : base(eventInfo, context, eventListenerComponent, isServerAction)
		{
		}

		// Token: 0x06039294 RID: 234132 RVA: 0x00E7DBE7 File Offset: 0x00E7BDE7
		protected override void OnTrigger(ActionParams @params)
		{
		}

		// Token: 0x06039295 RID: 234133 RVA: 0x00E7DBEC File Offset: 0x00E7BDEC
		protected unsafe override void OnStart(ActionParams @params)
		{
			SeqEventAddTagToSelf seqEventAddTagToSelf = @params as SeqEventAddTagToSelf;
			if (seqEventAddTagToSelf == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "MechanismEventAddTagToSelf.参数类型错误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("context", this.Context);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("eventName", base.EventName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.EventListenerComponent.AddTags(seqEventAddTagToSelf.Tags);
		}

		// Token: 0x06039296 RID: 234134 RVA: 0x00E7DC74 File Offset: 0x00E7BE74
		protected unsafe override void OnEnd(ActionParams @params)
		{
			SeqEventAddTagToSelf seqEventAddTagToSelf = @params as SeqEventAddTagToSelf;
			if (seqEventAddTagToSelf == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "MechanismEventAddTagToSelf.参数类型错误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("context", this.Context);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("eventName", base.EventName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.EventListenerComponent.RemoveTags(seqEventAddTagToSelf.Tags);
		}
	}
}
