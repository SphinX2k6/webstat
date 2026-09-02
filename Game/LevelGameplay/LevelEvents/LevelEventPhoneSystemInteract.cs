using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BBD RID: 27581
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventPhoneSystemInteract : LevelEventBase
	{
		// Token: 0x06044039 RID: 278585 RVA: 0x011A2544 File Offset: 0x011A0744
		public LevelEventPhoneSystemInteract(int id) : base(id)
		{
		}

		// Token: 0x0604403A RID: 278586 RVA: 0x011A2550 File Offset: 0x011A0750
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			PhoneSystemInteract phoneSystemInteract = inParams as PhoneSystemInteract;
			if (phoneSystemInteract.InteractType.Type != EPhoneSystemInteractType.OpenPhoneMessageBoard && phoneSystemInteract.InteractType.Type != EPhoneSystemInteractType.FlowOpenPhoneMessage)
			{
				return;
			}
			ShortMessage? shortMessageConfig = this.GetShortMessageConfig(phoneSystemInteract);
			if (shortMessageConfig == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			if (phoneSystemInteract.InteractType.Type == EPhoneSystemInteractType.OpenPhoneMessageBoard)
			{
				if (context != null && context.Type.GetValueOrDefault() == EGeneralContextType.Plot)
				{
					Singleton<UiManager>.Instance.OpenViewWithLayer(EUiViewName.PhoneMsgPanelViewBig, ELayerType.Pop, shortMessageConfig, null);
				}
				else
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.PhoneMsgPanelViewBig, shortMessageConfig, null);
				}
				base.FinishExecute(true, false, true);
				return;
			}
			if (phoneSystemInteract.InteractType.Type == EPhoneSystemInteractType.FlowOpenPhoneMessage)
			{
				PhoneMsgPanelViewData param = new PhoneMsgPanelViewData
				{
					ShortMessage = shortMessageConfig,
					NeedShowTips = false,
					NeedForceReadAllMsg = true,
					OpenWay = EPhoneMsgOpenWay.ForceOpen,
					ViewType = EPhoneMsgViewType.Small
				};
				if (context != null && context.Type.GetValueOrDefault() == EGeneralContextType.Plot)
				{
					Singleton<UiManager>.Instance.OpenViewWithLayer(EUiViewName.PhoneMsgPanelViewSmall, ELayerType.Pop, param, null);
				}
				else
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.PhoneMsgPanelViewSmall, param, null);
				}
				base.FinishExecute(true, false, true);
			}
		}

		// Token: 0x0604403B RID: 278587 RVA: 0x011A2670 File Offset: 0x011A0870
		private ShortMessage? GetShortMessageConfig(PhoneSystemInteract param)
		{
			if (param.InteractType.Type != EPhoneSystemInteractType.OpenPhoneMessageBoard && param.InteractType.Type != EPhoneSystemInteractType.FlowOpenPhoneMessage)
			{
				return null;
			}
			int? phoneMessageId = (param.InteractType as IOpenPhoneMessageBoard).PhoneBoardType.MessageBoardConfig.PhoneMessageId;
			if (phoneMessageId == null)
			{
				return null;
			}
			ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(phoneMessageId.Value);
			if (phoneMsgConfig == null)
			{
				return null;
			}
			return phoneMsgConfig;
		}
	}
}
