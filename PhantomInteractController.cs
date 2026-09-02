using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020024AF RID: 9391
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PhantomInteractController : UiControllerBase<PhantomInteractController>
{
	// Token: 0x06012392 RID: 74642 RVA: 0x0050490B File Offset: 0x00502B0B
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<PhantomInteractionUnlockNotify>(ENotifyMessageId.PhantomInteractionUnlockNotify, new Action<PhantomInteractionUnlockNotify, Net.CallbackStatus>(this.OnPhantomInteractionUnlockNotify));
		Singleton<Net>.Instance.Register<PhantomInteractionInfoUpdateNotify>(ENotifyMessageId.PhantomInteractionInfoUpdateNotify, new Action<PhantomInteractionInfoUpdateNotify, Net.CallbackStatus>(this.OnPhantomInteractionInfoUpdateNotify));
	}

	// Token: 0x06012393 RID: 74643 RVA: 0x00504945 File Offset: 0x00502B45
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomInteractionUnlockNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomInteractionInfoUpdateNotify);
	}

	// Token: 0x06012394 RID: 74644 RVA: 0x00504967 File Offset: 0x00502B67
	private void OnPhantomInteractionUnlockNotify(PhantomInteractionUnlockNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<PhantomInteractModel>.Instance.InteractInfoData.LoadFromProto(message);
	}

	// Token: 0x06012395 RID: 74645 RVA: 0x0050497C File Offset: 0x00502B7C
	private void OnPhantomInteractionInfoUpdateNotify(PhantomInteractionInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<PhantomInteractModel>.Instance.InteractInfoData.UpdateFromProto(message);
		UnlockIllustratedPhantom unlockIllustratedPhantom = message.UnlockIllustratedPhantom;
		int num = (unlockIllustratedPhantom != null) ? unlockIllustratedPhantom.MonsterId : 0;
		if (message != null)
		{
			UnlockIllustratedPhantom unlockIllustratedPhantom2 = message.UnlockIllustratedPhantom;
			if (((unlockIllustratedPhantom2 != null) ? new bool?(unlockIllustratedPhantom2.IsSpecial) : null).GetValueOrDefault())
			{
				ModelBase<PhantomInteractModel>.Instance.SetPhantomInteractUnlockRedDot(num, true);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.PhantomInteractNewUnlock, num);
			}
		}
	}

	// Token: 0x06012396 RID: 74646 RVA: 0x005049F8 File Offset: 0x00502BF8
	public void OpenPhantomVisionSummonView(int entityId, int skillId)
	{
		PhantomInteractModel instance = ModelBase<PhantomInteractModel>.Instance;
		instance.InitEditViewModel(0);
		instance.CacheOpenSkillInfo(entityId, skillId);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomInteractSummonView, instance.InteractInfoData, null);
	}

	// Token: 0x06012397 RID: 74647 RVA: 0x00504A30 File Offset: 0x00502C30
	public void OpenPhantomVisionEditView(int index = 0, bool fromSummonView = false)
	{
		PhantomInteractModel instance = ModelBase<PhantomInteractModel>.Instance;
		instance.InitEditViewModel(index);
		PhantomInteractEditViewParam phantomInteractEditViewParam = new PhantomInteractEditViewParam();
		phantomInteractEditViewParam.InfoData = instance.InteractInfoData;
		phantomInteractEditViewParam.OpenSlotIndex = index;
		phantomInteractEditViewParam.FromSummonView = fromSummonView;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomInteractEditView, phantomInteractEditViewParam, null);
	}

	// Token: 0x06012398 RID: 74648 RVA: 0x00504A7C File Offset: 0x00502C7C
	public void BeginVisionSkill(int monsterId)
	{
		PhantomInteractModel instance = ModelBase<PhantomInteractModel>.Instance;
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
		if (worldEntity == null)
		{
			return;
		}
		CharacterSkillComponent component = worldEntity.GetComponent<CharacterSkillComponent>();
		CharacterSkillCdComponent component2 = worldEntity.GetComponent<CharacterSkillCdComponent>();
		if (component == null || component2 == null)
		{
			return;
		}
		ISkillParam skillParam = PhantomUtil.BeforeVisionSkillExecute(worldEntity, monsterId);
		instance.SetSummonMonsterId(monsterId);
		component.BeginSkillAsync(210008, skillParam);
	}

	// Token: 0x06012399 RID: 74649 RVA: 0x00504AE0 File Offset: 0x00502CE0
	public UniTask UpdateEquippedPhantom()
	{
		PhantomInteractController.<UpdateEquippedPhantom>d__7 <UpdateEquippedPhantom>d__;
		<UpdateEquippedPhantom>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateEquippedPhantom>d__.<>1__state = -1;
		<UpdateEquippedPhantom>d__.<>t__builder.Start<PhantomInteractController.<UpdateEquippedPhantom>d__7>(ref <UpdateEquippedPhantom>d__);
		return <UpdateEquippedPhantom>d__.<>t__builder.Task;
	}

	// Token: 0x0601239A RID: 74650 RVA: 0x00504B1C File Offset: 0x00502D1C
	public UniTask UpdateEquippedPhantomSkin(int monsterId, int skinId)
	{
		PhantomInteractController.<UpdateEquippedPhantomSkin>d__8 <UpdateEquippedPhantomSkin>d__;
		<UpdateEquippedPhantomSkin>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateEquippedPhantomSkin>d__.monsterId = monsterId;
		<UpdateEquippedPhantomSkin>d__.skinId = skinId;
		<UpdateEquippedPhantomSkin>d__.<>1__state = -1;
		<UpdateEquippedPhantomSkin>d__.<>t__builder.Start<PhantomInteractController.<UpdateEquippedPhantomSkin>d__8>(ref <UpdateEquippedPhantomSkin>d__);
		return <UpdateEquippedPhantomSkin>d__.<>t__builder.Task;
	}
}
