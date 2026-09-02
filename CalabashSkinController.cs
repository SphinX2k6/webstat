using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A45 RID: 10821
[Nullable(new byte[]
{
	0,
	1
})]
public class CalabashSkinController : UiControllerBase<CalabashSkinController>
{
	// Token: 0x06015AB7 RID: 88759 RVA: 0x006043AA File Offset: 0x006025AA
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
	}

	// Token: 0x06015AB8 RID: 88760 RVA: 0x006043C8 File Offset: 0x006025C8
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
	}

	// Token: 0x06015AB9 RID: 88761 RVA: 0x006043E6 File Offset: 0x006025E6
	private void OnDataDone()
	{
		ControllerBase<CalabashSkinController>.Instance.RequestLoadCalabashSkinInfo();
	}

	// Token: 0x06015ABA RID: 88762 RVA: 0x006043F4 File Offset: 0x006025F4
	protected unsafe override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<CalabashSkinUpdateNotify>(ENotifyMessageId.CalabashSkinUpdateNotify, delegate(CalabashSkinUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<CalabashSkinModel>.Instance.NotifyAddUnlockSkinData(notify.SkinIds.ToArray<int>());
			ControllerBase<InventoryController>.Instance.AddCalabashSkinItemData(notify.SkinIds.ToArray<int>());
		});
		Singleton<Net>.Instance.Register<CalabashSkinTakeOnNotify>(ENotifyMessageId.CalabashSkinTakeOnNotify, delegate(CalabashSkinTakeOnNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<CalabashSkinModel>.Instance.NotifyCurrentEquippedSkinId(notify.SkinId);
		});
		Singleton<Net>.Instance.Register<EntityCalabashSkinChangeNotify>(ENotifyMessageId.EntityCalabashSkinChangeNotify, delegate(EntityCalabashSkinChangeNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			long num = Singleton<MathUtils>.Instance.LongToNumber(notify.EntityId);
			CalabashSkinComponentPb calabashSkinComponent = notify.CalabashSkinComponent;
			int num2 = (calabashSkinComponent != null) ? calabashSkinComponent.CalabashSkinId : 0;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CalabashSkin;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "服务器下发葫芦皮肤";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "CalabashSkinId";
			CalabashSkinComponentPb calabashSkinComponent2 = notify.CalabashSkinComponent;
			ptr = new ValueTuple<string, object>(item, (calabashSkinComponent2 != null) ? new int?(calabashSkinComponent2.CalabashSkinId) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ServerEntityId", num);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num);
			CreatureDataComponent creatureDataComponent = (entity != null) ? entity.Entity.GetComponent<CreatureDataComponent>() : null;
			if (creatureDataComponent != null && creatureDataComponent.Valid)
			{
				creatureDataComponent.HuluSkinId = num2;
			}
			CharacterWeaponComponent characterWeaponComponent = (entity != null) ? entity.Entity.GetComponent<CharacterWeaponComponent>() : null;
			if (characterWeaponComponent != null && characterWeaponComponent.Valid)
			{
				characterWeaponComponent.OnEntityHuluSkinChangeNotify(num2);
			}
		});
	}

	// Token: 0x06015ABB RID: 88763 RVA: 0x0060448E File Offset: 0x0060268E
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CalabashSkinUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CalabashSkinTakeOnNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EntityCalabashSkinChangeNotify);
	}

	// Token: 0x06015ABC RID: 88764 RVA: 0x006044C0 File Offset: 0x006026C0
	private void RequestLoadCalabashSkinInfo()
	{
		LoadCalabashSkinInfoRequest message = LoadCalabashSkinInfoRequest.Create();
		Singleton<Net>.Instance.Call<LoadCalabashSkinInfoResponse>(ERequestMessageId.LoadCalabashSkinInfoRequest, message, delegate(LoadCalabashSkinInfoResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20621, null, true, true);
				return;
			}
			ModelBase<CalabashSkinModel>.Instance.NotifyCalabashSkinData(response.EquipSkinId, response.SkinItemIds.ToArray<int>());
			ControllerBase<InventoryController>.Instance.InitCalabashSkinItemData(response.SkinItemIds.ToArray<int>());
		}, 0);
	}

	// Token: 0x06015ABD RID: 88765 RVA: 0x00604504 File Offset: 0x00602704
	public UniTask<bool> RequestCalabashSkinTakeOn(int skinId)
	{
		CalabashSkinController.<RequestCalabashSkinTakeOn>d__6 <RequestCalabashSkinTakeOn>d__;
		<RequestCalabashSkinTakeOn>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestCalabashSkinTakeOn>d__.skinId = skinId;
		<RequestCalabashSkinTakeOn>d__.<>1__state = -1;
		<RequestCalabashSkinTakeOn>d__.<>t__builder.Start<CalabashSkinController.<RequestCalabashSkinTakeOn>d__6>(ref <RequestCalabashSkinTakeOn>d__);
		return <RequestCalabashSkinTakeOn>d__.<>t__builder.Task;
	}

	// Token: 0x06015ABE RID: 88766 RVA: 0x00604548 File Offset: 0x00602748
	[NullableContext(1)]
	public void SelectedCalabashSkinChange(int skinId, int roleId, [Nullable(2)] UiModelBase calabashModel, string caseName = "TerminalCase")
	{
		if (calabashModel == null)
		{
			return;
		}
		UiHuluSkinDataComponent dataComponent = calabashModel.CheckGetComponent<UiHuluSkinDataComponent>();
		dataComponent.SetSkinId(roleId, skinId);
		int modelId = dataComponent.ModelId;
		UiModelActorComponent actorComponent = calabashModel.CheckGetComponent<UiModelActorComponent>();
		UiModelActorComponent actorComponent4 = actorComponent;
		if (actorComponent4 != null)
		{
			actorComponent4.SetTransformByTag(caseName);
		}
		CalabashTransform transformData = ConfigBase<SkinConfig>.Instance.GetCalabashTransformById(dataComponent.TransformId);
		Action loadFinishCallBack = delegate()
		{
			Singleton<UiModelUtil>.Instance.SetVisible(calabashModel, true);
			global::Vector inT = global::Vector.Create((double)transformData.Location.Value.X, (double)transformData.Location.Value.Y, (double)transformData.Location.Value.Z);
			global::Rotator rotator = global::Rotator.Create(transformData.Rotation.Value.Y, transformData.Rotation.Value.Z, transformData.Rotation.Value.X);
			global::Vector inS = global::Vector.Create((double)transformData.Size.Value.X, (double)transformData.Size.Value.Y, (double)transformData.Size.Value.Z);
			global::Transform transform = global::Transform.Create(rotator.Quaternion(null), inT, inS);
			FHitResult fhitResult = new FHitResult();
			UiModelActorComponent actorComponent2 = actorComponent;
			if (actorComponent2 != null)
			{
				USkeletalMeshComponent mainMeshComponent = actorComponent2.MainMeshComponent;
				if (mainMeshComponent != null)
				{
					FTransformDouble ftransformDouble = transform.ToUeTransform();
					mainMeshComponent.D_K2_SetRelativeTransform(ftransformDouble, false, ref fhitResult, false);
				}
			}
			Singleton<UiModelUtil>.Instance.SetRenderingMaterial(calabashModel, "CalabashSwitchController");
			Singleton<UiModelUtil>.Instance.PlayEffectAtRootComponentByPath(calabashModel, dataComponent.EffectPath);
			UiModelRotateComponent uiModelRotateComponent = calabashModel.CheckGetComponent<UiModelRotateComponent>();
			uiModelRotateComponent.SetRotateParam((float)transformData.RotateTime, ERotateAxis.Roll, false);
			uiModelRotateComponent.StartRotate();
			rotator.Set(transformData.AxisRotate.Value.X, transformData.AxisRotate.Value.Y, transformData.AxisRotate.Value.Z);
			UiModelActorComponent actorComponent3 = actorComponent;
			if (actorComponent3 == null)
			{
				return;
			}
			AActor actor = actorComponent3.Actor;
			if (actor == null)
			{
				return;
			}
			actor.K2_SetActorRotation(rotator.ToUeRotator(), false);
		};
		UiModelLoadComponent uiModelLoadComponent = calabashModel.CheckGetComponent<UiModelLoadComponent>();
		if (uiModelLoadComponent == null)
		{
			return;
		}
		uiModelLoadComponent.LoadModelByModelId(modelId, true, loadFinishCallBack, null);
	}
}
