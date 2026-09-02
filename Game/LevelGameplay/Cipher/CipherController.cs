using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.Cipher
{
	// Token: 0x02006F41 RID: 28481
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class CipherController : UiControllerBase<CipherController>
	{
		// Token: 0x06044F10 RID: 282384 RVA: 0x011F1DDF File Offset: 0x011EFFDF
		public void OpenCipherView(string inId)
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.CipherView))
			{
				return;
			}
			ModelBase<CipherModel>.Instance.InitCipherConfig(inId);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CipherView, null, null);
		}

		// Token: 0x06044F11 RID: 282385 RVA: 0x011F1E10 File Offset: 0x011F0010
		public void RequestCipherComplete()
		{
			UiGamePlayRequest uiGamePlayRequest = UiGamePlayRequest.Create();
			uiGamePlayRequest.GamePlayKey = ModelBase<CipherModel>.Instance.GetCipherConfigId();
			uiGamePlayRequest.Type = UiGamePlayType.Cipher;
			Singleton<Net>.Instance.Call<UiGamePlayResponse>(ERequestMessageId.UiGamePlayRequest, uiGamePlayRequest, null, 0);
		}
	}
}
