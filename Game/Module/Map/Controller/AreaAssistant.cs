using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.Controller
{
	// Token: 0x020058EC RID: 22764
	[NullableContext(2)]
	[Nullable(0)]
	public class AreaAssistant : ControllerAssistantBase
	{
		// Token: 0x06039C3B RID: 236603 RVA: 0x00EA0A34 File Offset: 0x00E9EC34
		protected override void OnDestroy()
		{
		}

		// Token: 0x06039C3C RID: 236604 RVA: 0x00EA0A38 File Offset: 0x00E9EC38
		public override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<MapUnlockFieldNotify>(ENotifyMessageId.MapUnlockFieldNotify, new Action<MapUnlockFieldNotify, Net.CallbackStatus>(this.OnMapUnlockFieldNotify));
			Singleton<Net>.Instance.Register<MultiMapInfoNotify>(ENotifyMessageId.MultiMapInfoNotify, new Action<MultiMapInfoNotify, Net.CallbackStatus>(this.OnMultiMapInfoNotify));
			Singleton<Net>.Instance.Register<UnlockMapBlockNotify>(ENotifyMessageId.UnlockMapBlockNotify, new Action<UnlockMapBlockNotify, Net.CallbackStatus>(this.OnUnlockMapBlockNotify));
			Singleton<Net>.Instance.Register<UnlockMultiMapNotify>(ENotifyMessageId.UnlockMultiMapNotify, new Action<UnlockMultiMapNotify, Net.CallbackStatus>(this.OnUnlockMultiMapNotify));
		}

		// Token: 0x06039C3D RID: 236605 RVA: 0x00EA0AB8 File Offset: 0x00E9ECB8
		public override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MapUnlockFieldNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MultiMapInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.UnlockMapBlockNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.UnlockMultiMapNotify);
		}

		// Token: 0x06039C3E RID: 236606 RVA: 0x00EA0B05 File Offset: 0x00E9ED05
		private void OnUnlockMultiMapNotify(UnlockMultiMapNotify notify, Net.CallbackStatus status)
		{
			ModelBase<MapModel>.Instance.AddUnlockMultiMapIds(notify.UnlockMultiMapId.ToList<int>());
		}

		// Token: 0x06039C3F RID: 236607 RVA: 0x00EA0B1C File Offset: 0x00E9ED1C
		private void OnUnlockMapBlockNotify(UnlockMapBlockNotify notify, Net.CallbackStatus status)
		{
			ModelBase<MapModel>.Instance.AddUnlockMapBlockIds(notify.UnlockBlockId.ToList<int>());
		}

		// Token: 0x06039C40 RID: 236608 RVA: 0x00EA0B33 File Offset: 0x00E9ED33
		private void OnMultiMapInfoNotify(MultiMapInfoNotify notify, Net.CallbackStatus status)
		{
			ModelBase<MapModel>.Instance.SetUnlockMultiMapIds(notify.UnlockMultiMapId.ToList<int>());
			ModelBase<MapModel>.Instance.SetUnlockMapBlockIds(notify.UnlockBlockId.ToList<int>());
		}

		// Token: 0x06039C41 RID: 236609 RVA: 0x00EA0B5F File Offset: 0x00E9ED5F
		private void OnMapUnlockFieldNotify(MapUnlockFieldNotify notify, Net.CallbackStatus status)
		{
			ModelBase<MapModel>.Instance.AddUnlockedFogs(notify.FieldId);
		}

		// Token: 0x06039C42 RID: 236610 RVA: 0x00EA0B74 File Offset: 0x00E9ED74
		public UniTask RequestUnlockedAreaInfo()
		{
			AreaAssistant.<RequestUnlockedAreaInfo>d__7 <RequestUnlockedAreaInfo>d__;
			<RequestUnlockedAreaInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestUnlockedAreaInfo>d__.<>1__state = -1;
			<RequestUnlockedAreaInfo>d__.<>t__builder.Start<AreaAssistant.<RequestUnlockedAreaInfo>d__7>(ref <RequestUnlockedAreaInfo>d__);
			return <RequestUnlockedAreaInfo>d__.<>t__builder.Task;
		}
	}
}
