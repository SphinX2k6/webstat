using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.ServerStorage
{
	// Token: 0x02004728 RID: 18216
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ServerStorageController : ControllerBase<ServerStorageController>
	{
		// Token: 0x0602F4DC RID: 193756 RVA: 0x00B371EE File Offset: 0x00B353EE
		protected override bool OnInit()
		{
			Singleton<Net>.Instance.Register<StorageInfoNotify>(ENotifyMessageId.StorageInfoNotify, new Action<StorageInfoNotify, Net.CallbackStatus>(this.OnStorageInfoInitNotify));
			return true;
		}

		// Token: 0x0602F4DD RID: 193757 RVA: 0x00B3720D File Offset: 0x00B3540D
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.StorageInfoNotify);
			return true;
		}

		// Token: 0x0602F4DE RID: 193758 RVA: 0x00B37220 File Offset: 0x00B35420
		private void OnStorageInfoInitNotify(StorageInfoNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			ModelBase<ServerStorageModel>.Instance.InitStorageInfo(response.Infos);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnServerStorageInfoInited);
		}

		// Token: 0x0602F4DF RID: 193759 RVA: 0x00B37246 File Offset: 0x00B35446
		public void SendStorageInfoUpdateRequest(StorageInfoUpdateRequest request)
		{
			Singleton<Net>.Instance.Call<StorageInfoUpdateResponse>(ERequestMessageId.StorageInfoUpdateRequest, request, delegate(StorageInfoUpdateResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15680, null, true, true);
				}
			}, 0);
		}
	}
}
