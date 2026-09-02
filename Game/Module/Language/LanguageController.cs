using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Language
{
	// Token: 0x02005A25 RID: 23077
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class LanguageController : ControllerBase<LanguageController>
	{
		// Token: 0x0603A6DF RID: 239327 RVA: 0x00ED1173 File Offset: 0x00ECF373
		protected override bool OnInit()
		{
			this.OnAddEvents();
			return true;
		}

		// Token: 0x0603A6E0 RID: 239328 RVA: 0x00ED117C File Offset: 0x00ECF37C
		protected override bool OnClear()
		{
			this.OnRemoveEvents();
			return true;
		}

		// Token: 0x0603A6E1 RID: 239329 RVA: 0x00ED1185 File Offset: 0x00ECF385
		private void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<string, string>(EEventName.TextLanguageChange, new Action<string, string>(this.OnLanguageChange));
		}

		// Token: 0x0603A6E2 RID: 239330 RVA: 0x00ED11A3 File Offset: 0x00ECF3A3
		private void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<string, string>(EEventName.TextLanguageChange, new Action<string, string>(this.OnLanguageChange));
		}

		// Token: 0x0603A6E3 RID: 239331 RVA: 0x00ED11C4 File Offset: 0x00ECF3C4
		private void OnLanguageChange(string oldLanguage, string newLanguage)
		{
			int languageType = Singleton<LanguageSystem>.Instance.GetLanguageDefineByCode(newLanguage).LanguageType;
			this.RequestSetLanguage(languageType);
		}

		// Token: 0x0603A6E4 RID: 239332 RVA: 0x00ED11EC File Offset: 0x00ECF3EC
		public void RequestSetLanguage(int languageCode)
		{
			LanguageSettingUpdateRequest languageSettingUpdateRequest = LanguageSettingUpdateRequest.Create();
			languageSettingUpdateRequest.Language = languageCode;
			Singleton<Net>.Instance.Call<LanguageSettingUpdateResponse>(ERequestMessageId.LanguageSettingUpdateRequest, languageSettingUpdateRequest, delegate(LanguageSettingUpdateResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17563, null, true, true);
				}
			}, 0);
		}
	}
}
