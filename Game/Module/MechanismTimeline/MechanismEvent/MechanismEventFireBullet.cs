using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.Module.MechanismTimeline.MechanismEvent
{
	// Token: 0x020057E3 RID: 22499
	[NullableContext(1)]
	[Nullable(0)]
	public class MechanismEventFireBullet : MechanismEventBase
	{
		// Token: 0x060392AE RID: 234158 RVA: 0x00E7E029 File Offset: 0x00E7C229
		public MechanismEventFireBullet(IMechanismEventInfo eventInfo, MechanismEventContext context, SceneItemEventListenerComponent eventListenerComponent, bool isServerAction) : base(eventInfo, context, eventListenerComponent, isServerAction)
		{
		}

		// Token: 0x060392AF RID: 234159 RVA: 0x00E7E038 File Offset: 0x00E7C238
		protected unsafe override void OnTrigger(ActionParams @params)
		{
			SeqEventFireBullet seqEventFireBullet = @params as SeqEventFireBullet;
			if (seqEventFireBullet == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "MechanismEventFireBullet.参数类型错误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("context", this.Context);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("eventName", base.EventName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.BulletEntityId = this.EventListenerComponent.CreateBullet(seqEventFireBullet, base.EventName);
		}

		// Token: 0x060392B0 RID: 234160 RVA: 0x00E7E0C8 File Offset: 0x00E7C2C8
		protected unsafe override void OnStart(ActionParams @params)
		{
			SeqEventFireBullet seqEventFireBullet = @params as SeqEventFireBullet;
			if (seqEventFireBullet == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "MechanismEventFireBullet.参数类型错误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("context", this.Context);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("eventName", base.EventName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.BulletEntityId = this.EventListenerComponent.CreateBullet(seqEventFireBullet, base.EventName);
		}

		// Token: 0x060392B1 RID: 234161 RVA: 0x00E7E155 File Offset: 0x00E7C355
		protected override void OnEnd(ActionParams @params)
		{
			this.EventListenerComponent.DestroyBullet(this.BulletEntityId);
		}

		// Token: 0x04020878 RID: 133240
		public int BulletEntityId;
	}
}
