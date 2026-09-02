using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Kpose.Blueprint;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E9C RID: 7836
[NullableContext(2)]
[Nullable(0)]
public class MonsterHandBookView : UiViewBase
{
	// Token: 0x0600E7A0 RID: 59296 RVA: 0x003E8B2F File Offset: 0x003E6D2F
	[NullableContext(1)]
	public MonsterHandBookView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E7A1 RID: 59297 RVA: 0x003E8B50 File Offset: 0x003E6D50
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIDynScrollViewComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(14, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIText)),
			new ValueTuple<int, Type>(20, typeof(UUIText)),
			new ValueTuple<int, Type>(21, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(12, new Action(this.EnterInternalView)),
			new ValueTuple<int, Delegate>(13, new Action(this.OnMonsterSkinBtnClick)),
			new ValueTuple<int, Delegate>(21, new Action(this.OnBackCheckBtnClick))
		};
	}

	// Token: 0x0600E7A2 RID: 59298 RVA: 0x003E8DB0 File Offset: 0x003E6FB0
	protected override UniTask OnBeforeStartAsync()
	{
		MonsterHandBookView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MonsterHandBookView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E7A3 RID: 59299 RVA: 0x003E8DF4 File Offset: 0x003E6FF4
	protected override void OnBeforeShowImplementImplement()
	{
		this.RefreshCollectText();
		int[] allHandBookMonsterIdList = ModelBase<HandBookModel>.Instance.GetAllHandBookMonsterIdList();
		this.FilterBtn.UpdateData(EFilterSortGroupId.MonsterHandBook, allHandBookMonsterIdList.ToList<int>(), Array.Empty<object>());
	}

	// Token: 0x0600E7A4 RID: 59300 RVA: 0x003E8E2C File Offset: 0x003E702C
	private void RefeshView()
	{
		if (this.RefreshLockState())
		{
			return;
		}
		MonsterHandBook? monsterHandBookConfigById = ConfigBase<HandBookConfig>.Instance.GetMonsterHandBookConfigById(this.CurrentSelectedMonsterInfoId);
		if (monsterHandBookConfigById == null)
		{
			return;
		}
		MonsterInfo? monsterInfoConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(this.CurrentSelectedMonsterInfoId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), monsterInfoConfig.Value.Name, Array.Empty<object>());
		MonsterHandBookType? monsterHandBookTypeConfigById = ConfigBase<HandBookConfig>.Instance.GetMonsterHandBookTypeConfigById(monsterHandBookConfigById.Value.Type);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), ((monsterHandBookTypeConfigById != null) ? monsterHandBookTypeConfigById.GetValueOrDefault().Descrtption : null) ?? "", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), monsterInfoConfig.Value.DiscoveredDes, Array.Empty<object>());
		this.RefreshSkinBtn(monsterHandBookConfigById.Value.MonsterId);
	}

	// Token: 0x0600E7A5 RID: 59301 RVA: 0x003E8F28 File Offset: 0x003E7128
	private bool RefreshLockState()
	{
		base.GetButton(12).RootUIComp.Get().SetUIActive(!this.IsLock);
		if (this.IsLock || this.CurrentSelectedMonsterInfoId == 0)
		{
			base.GetItem(17).SetUIActive(true);
			base.GetItem(16).SetUIActive(false);
			if (this.VisionCameraInputItem != null)
			{
				this.VisionCameraInputItem.SetUiActive(false);
			}
			if (this.IsShowingSkin)
			{
				base.GetText(20).SetUIActive(false);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(19), "MonsterHandBookMonsterSkinNotHave", Array.Empty<object>());
			}
			else
			{
				base.GetText(20).SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(19), "MonsterHandBookMonsterNotHave", Array.Empty<object>());
				base.GetButton(13).RootUIComp.Get().SetUIActive(false);
			}
			this.LoadingItem.SetLoadingActive(false);
			return true;
		}
		base.GetItem(17).SetUIActive(false);
		base.GetItem(16).SetUIActive(true);
		if (this.VisionCameraInputItem != null)
		{
			this.VisionCameraInputItem.SetUiActive(true);
		}
		return false;
	}

	// Token: 0x0600E7A6 RID: 59302 RVA: 0x003E9054 File Offset: 0x003E7254
	private void RefreshCollectText()
	{
		int[] collectProgress = ControllerBase<HandBookController>.Instance.GetCollectProgress(EHandBookTabType.Monster);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "RoleExp", new <>z__ReadOnlyArray<object>(new object[]
		{
			collectProgress[0],
			collectProgress[1]
		}));
	}

	// Token: 0x0600E7A7 RID: 59303 RVA: 0x003E90A4 File Offset: 0x003E72A4
	[NullableContext(1)]
	private MonsterHandBookItem CreateNodeGrid(object data, UUIItem uiItem, int index)
	{
		return new MonsterHandBookItem
		{
			OnClickCallBack = new Action<UUIExtendToggle, int, bool>(this.OnClickMonsterItemCallBack)
		};
	}

	// Token: 0x0600E7A8 RID: 59304 RVA: 0x003E90C0 File Offset: 0x003E72C0
	[NullableContext(1)]
	private void OnClickMonsterItemCallBack(UUIExtendToggle toggle, int handBookId, bool isLock)
	{
		if (this.CurrentToggle != toggle)
		{
			UUIExtendToggle currentToggle = this.CurrentToggle;
			if (currentToggle != null)
			{
				currentToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			}
		}
		this.CurrentToggle = toggle;
		if (handBookId == this.CurrentSelectedMonsterInfoId)
		{
			return;
		}
		this.IsShowingSkin = false;
		this.CurrentSelectedMonsterInfoId = handBookId;
		ModelBase<HandBookModel>.Instance.CurrentSelectMonsterHandBookId = this.CurrentSelectedMonsterInfoId;
		this.DestroyVision();
		this.IsLock = isLock;
		if (!this.IsLock)
		{
			this.LoadVision();
		}
		this.RefeshView();
		this.ReadMonsterHandBook(handBookId);
	}

	// Token: 0x0600E7A9 RID: 59305 RVA: 0x003E9144 File Offset: 0x003E7344
	[NullableContext(1)]
	private void OnFilterUpdate(List<int> list, bool isOutSideChange, EFilterSortType OperationType)
	{
		List<int> list2 = new List<int>();
		foreach (int item in list)
		{
			list2.Add(item);
		}
		if (list2 == null || list2.Count <= 0)
		{
			base.GetUIDynScrollViewComponent(4).RootUIComp.Get().SetUIActive(false);
			return;
		}
		base.GetUIDynScrollViewComponent(4).RootUIComp.Get().SetUIActive(true);
		Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
		foreach (int id in list2)
		{
			MonsterHandBook? monsterHandBookConfigById = ConfigBase<HandBookConfig>.Instance.GetMonsterHandBookConfigById(id);
			if (monsterHandBookConfigById != null)
			{
				List<int> list3;
				if (!dictionary.TryGetValue(monsterHandBookConfigById.Value.Type, out list3))
				{
					list3 = new List<int>();
				}
				list3.Add(monsterHandBookConfigById.Value.Id);
				dictionary[monsterHandBookConfigById.Value.Type] = list3;
			}
		}
		List<MonsterHandBookDynamicData> list4 = new List<MonsterHandBookDynamicData>();
		foreach (KeyValuePair<int, List<int>> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			List<int> value = keyValuePair.Value;
			MonsterHandBookDynamicData monsterHandBookDynamicData = new MonsterHandBookDynamicData();
			MonsterHandBookType? monsterHandBookTypeConfigById = ConfigBase<HandBookConfig>.Instance.GetMonsterHandBookTypeConfigById(key);
			monsterHandBookDynamicData.TitleId = (((monsterHandBookTypeConfigById != null) ? monsterHandBookTypeConfigById.GetValueOrDefault().Descrtption : null) ?? "");
			list4.Add(monsterHandBookDynamicData);
			list4.Add(new MonsterHandBookDynamicData
			{
				MonsterList = value.ToArray()
			});
		}
		if (list4.Count <= 0)
		{
			this.RefeshView();
			return;
		}
		ModelBase<HandBookModel>.Instance.CurrentSelectMonsterHandBookId = list2[0];
		DynamicScrollView<MonsterHandBookItem, MonsterHandBookDynamicItem, MonsterHandBookDynamicData> monsterGenericLayout = this.MonsterGenericLayout;
		if (monsterGenericLayout == null)
		{
			return;
		}
		monsterGenericLayout.RefreshByData(list4.ToArray(), false, false);
	}

	// Token: 0x0600E7AA RID: 59306 RVA: 0x003E9378 File Offset: 0x003E7578
	private void LoadVision()
	{
		if (this.BpHandle != -1 || Singleton<UiSceneManager>.Instance.GetHandBookVision() != null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HandBook, ELogAuthor.LJQ, "怪物模型重复加载", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.LoadingItem.SetLoadingActive(true);
		int monsterId = this.CurrentSelectedMonsterInfoId;
		MonsterHandBook? monsterHandBookConfigById = ConfigBase<HandBookConfig>.Instance.GetMonsterHandBookConfigById(monsterId);
		if (monsterHandBookConfigById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HandBook;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "怪物图鉴配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("monsterId", monsterId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.BpHandle = Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(monsterHandBookConfigById.Value.HandBookBp + "_C", delegate([Nullable(2)] UClass csClass, string _)
		{
			this.SetVisionInfo(monsterId, csClass);
		}, 100, this.MemoryTag);
	}

	// Token: 0x0600E7AB RID: 59307 RVA: 0x003E946C File Offset: 0x003E766C
	[NullableContext(1)]
	private void SetVisionInfo(int monsterId, UClass csClass)
	{
		Singleton<UiSceneManager>.Instance.CreateHandBookVision(csClass);
		BP_KposeBase_C handBookVision = Singleton<UiSceneManager>.Instance.GetHandBookVision();
		handBookVision.SetActorHiddenInGame(true);
		TArray<USkeletalMesh> tarray = new TArray<USkeletalMesh>();
		TArray<UStaticMesh> tarray2 = new TArray<UStaticMesh>();
		TArray<UActorComponent> tarray3 = handBookVision.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
		TArray<UActorComponent> tarray4 = handBookVision.K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
		if (tarray3 != null)
		{
			for (int i = 0; i < tarray3.Num(); i++)
			{
				USkeletalMeshComponent uskeletalMeshComponent = tarray3.Get(i) as USkeletalMeshComponent;
				uskeletalMeshComponent.SetForcedLOD(1);
				tarray.Add(uskeletalMeshComponent.SkeletalMesh);
			}
		}
		if (tarray4 != null)
		{
			for (int j = 0; j < tarray4.Num(); j++)
			{
				UStaticMeshComponent ustaticMeshComponent = tarray4.Get(j) as UStaticMeshComponent;
				ustaticMeshComponent.SetForcedLodModel(1);
				tarray2.Add(ustaticMeshComponent.StaticMesh);
			}
		}
		MeshStreamTaskContext meshStreamTaskContext = new MeshStreamTaskContext();
		meshStreamTaskContext.SkeletalMeshes = tarray;
		meshStreamTaskContext.StaticMeshes = tarray2;
		meshStreamTaskContext.OnTaskFinish = delegate()
		{
			this.OnLoadFinish(monsterId);
		};
		this.MeshStreamTaskId = ControllerBase<MeshStreamController>.Instance.AddMeshStreamTask(meshStreamTaskContext);
	}

	// Token: 0x0600E7AC RID: 59308 RVA: 0x003E9590 File Offset: 0x003E7790
	private void OnLoadFinish(int monsterId)
	{
		UiCameraControlRotationComponent uiCameraComponent = UiCameraManager.Get().GetUiCameraComponent<UiCameraControlRotationComponent>();
		BP_KposeBase_C handBookVision = Singleton<UiSceneManager>.Instance.GetHandBookVision();
		if (handBookVision == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HandBook, ELogAuthor.LJQ, "声骸模型为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (handBookVision.CameraArmLength <= 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.HandBook, ELogAuthor.LJQ, "相机臂长配置为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		MonsterHandBook? monsterHandBookConfigById = ConfigBase<HandBookConfig>.Instance.GetMonsterHandBookConfigById(monsterId);
		if (monsterHandBookConfigById == null)
		{
			return;
		}
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(monsterHandBookConfigById.Value.HandBookCamera, false, false, "1001", false, null, null);
		uiCameraComponent.SetArmLength((float)handBookVision.CameraArmLength);
		if (handBookVision != null)
		{
			handBookVision.SetActorHiddenInGame(false);
		}
		if (handBookVision != null)
		{
			handBookVision.PlayStart();
		}
		RoleModelLoadingItem loadingItem = this.LoadingItem;
		if (loadingItem == null)
		{
			return;
		}
		loadingItem.SetLoadingActive(false);
	}

	// Token: 0x0600E7AD RID: 59309 RVA: 0x003E9674 File Offset: 0x003E7874
	private void DestroyVision()
	{
		if (this.BpHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.BpHandle);
			this.BpHandle = -1;
		}
		if (this.MeshStreamTaskId != -1)
		{
			ControllerBase<MeshStreamController>.Instance.RemoveMeshStreamTask(this.MeshStreamTaskId);
			this.MeshStreamTaskId = -1;
		}
		if (Singleton<UiSceneManager>.Instance.GetHandBookVision() != null)
		{
			Singleton<UiSceneManager>.Instance.DestroyHandBookVision();
		}
	}

	// Token: 0x0600E7AE RID: 59310 RVA: 0x003E96D7 File Offset: 0x003E78D7
	protected override void OnBeforeDestroy()
	{
		this.DestroyVision();
		this.LoadingItem.Destroy(null);
	}

	// Token: 0x0600E7AF RID: 59311 RVA: 0x003E96EC File Offset: 0x003E78EC
	private void EnterInternalView()
	{
		if (this.IsInternal)
		{
			return;
		}
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.PlaySequence("On", false, null);
		}
		base.GetButton(21).RootUIComp.Get().SetUIActive(true);
		base.GetButton(12).RootUIComp.Get().SetUIActive(false);
		base.GetButton(13).RootUIComp.Get().SetUIActive(false);
		if (this.CaptionItem != null)
		{
			this.CaptionItem.SetCloseBtnActive(false);
		}
		this.IsInternal = true;
		UiCamera uiCamera = UiCameraManager.Get();
		UiCameraControlRotationComponent rotationComponent = uiCamera.GetUiCameraComponent<UiCameraControlRotationComponent>();
		MonsterHandBook? monsterHandBookConfigById = ConfigBase<HandBookConfig>.Instance.GetMonsterHandBookConfigById(this.CurrentSelectedMonsterInfoId);
		if (monsterHandBookConfigById == null)
		{
			return;
		}
		MonsterBodyTypeConfig? bodyTypeConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterBodyTypeConfig(monsterHandBookConfigById.Value.MonsterBodyType);
		Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(bodyTypeConfig.Value.MoveForwardCurvePath, delegate([Nullable(2)] UCurveFloat curve, string _)
		{
			if (curve != null)
			{
				rotationComponent.DoMoveForward((float)bodyTypeConfig.Value.MoveForwardDistance, (float)bodyTypeConfig.Value.MoveForwardDuration, curve);
			}
		}, 100, this.MemoryTag);
		this.VisionCameraInputItem.CanPitchInput = true;
		this.RefreshInternal();
	}

	// Token: 0x0600E7B0 RID: 59312 RVA: 0x003E982C File Offset: 0x003E7A2C
	private void QuitInternalView()
	{
		if (!this.IsInternal)
		{
			Singleton<Log>.Instance.Error(ELogModule.HandBook, ELogAuthor.LJQ, "重复退出声骸图鉴的内部界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.PlaySequence("Off", false, null);
		}
		base.GetButton(21).RootUIComp.Get().SetUIActive(false);
		base.GetButton(12).RootUIComp.Get().SetUIActive(true);
		if (this.CaptionItem != null)
		{
			this.CaptionItem.SetCloseBtnActive(true);
		}
		UUIItem uuiitem = base.GetButton(13).RootUIComp.Get();
		bool uiactive;
		if (!this.IsLock)
		{
			int[] skinList = this.SkinList;
			uiactive = (((skinList != null) ? skinList.Length : 0) > 1);
		}
		else
		{
			uiactive = false;
		}
		uuiitem.SetUIActive(uiactive);
		this.IsInternal = false;
		UiCamera uiCamera = UiCameraManager.Get();
		UiCameraControlRotationComponent rotationComponent = uiCamera.GetUiCameraComponent<UiCameraControlRotationComponent>();
		MonsterHandBook? monsterHandBookConfigById = ConfigBase<HandBookConfig>.Instance.GetMonsterHandBookConfigById(this.CurrentSelectedMonsterInfoId);
		if (monsterHandBookConfigById == null)
		{
			return;
		}
		MonsterBodyTypeConfig? bodyTypeConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterBodyTypeConfig(monsterHandBookConfigById.Value.MonsterBodyType);
		Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(bodyTypeConfig.Value.MoveForwardCurvePath, delegate([Nullable(2)] UCurveFloat curve, string _)
		{
			if (curve != null)
			{
				BP_KposeBase_C handBookVision = Singleton<UiSceneManager>.Instance.GetHandBookVision();
				if (handBookVision != null && handBookVision.IsValid())
				{
					rotationComponent.SetArmLength((float)handBookVision.CameraArmLength);
					rotationComponent.SetArmRotationByDefaultCamera();
					rotationComponent.StartFade((float)bodyTypeConfig.Value.MoveForwardDuration, curve, true, true, true, true);
				}
			}
		}, 100, this.MemoryTag);
		this.VisionCameraInputItem.CanPitchInput = false;
		this.RefreshInternal();
	}

	// Token: 0x0600E7B1 RID: 59313 RVA: 0x003E99A4 File Offset: 0x003E7BA4
	private void RefreshInternal()
	{
		base.GetItem(18).SetUIActive(!this.IsInternal);
		base.GetItem(16).SetUIActive(!this.IsInternal);
		if (this.CaptionItem != null)
		{
			this.CaptionItem.SetUiActive(!this.IsInternal);
		}
	}

	// Token: 0x0600E7B2 RID: 59314 RVA: 0x003E99FC File Offset: 0x003E7BFC
	private void OnMonsterSkinBtnClick()
	{
		if (this.SkinList == null)
		{
			return;
		}
		this.ShowSkinIndex++;
		if (this.ShowSkinIndex >= this.SkinList.Length)
		{
			this.ShowSkinIndex = 0;
		}
		this.IsShowingSkin = (this.ShowSkinIndex > 0);
		int monsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(this.SkinList[this.ShowSkinIndex]).Value.MonsterId;
		MonsterHandBook? monsterHandBookConfigByMonsterId = ConfigBase<HandBookConfig>.Instance.GetMonsterHandBookConfigByMonsterId(monsterId);
		this.CurrentSelectedMonsterInfoId = ((monsterHandBookConfigByMonsterId != null) ? monsterHandBookConfigByMonsterId.GetValueOrDefault().Id : 0);
		if (this.ShowSkinIndex == 0)
		{
			HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Monster, monsterHandBookConfigByMonsterId.Value.Id);
			this.IsLock = (handBookInfo == null);
		}
		else
		{
			this.IsLock = (this.ShowSkinIndex > 0 && !ModelBase<PhantomBattleModel>.Instance.GetSkinIsUnlock(this.SkinList[this.ShowSkinIndex]));
		}
		this.DestroyVision();
		this.LoadingItem.SetLoadingActive(false);
		if (!this.IsLock)
		{
			this.LoadVision();
		}
		this.RefeshView();
	}

	// Token: 0x0600E7B3 RID: 59315 RVA: 0x003E9B20 File Offset: 0x003E7D20
	private void OnBackCheckBtnClick()
	{
		this.QuitInternalView();
	}

	// Token: 0x0600E7B4 RID: 59316 RVA: 0x003E9B28 File Offset: 0x003E7D28
	private void RefreshSkinBtn(int monsterId)
	{
		if (this.IsShowingSkin)
		{
			return;
		}
		this.SkinList = null;
		if (monsterId == 0)
		{
			base.GetButton(13).RootUIComp.Get().SetUIActive(false);
			return;
		}
		int[] monsterSkinListByMonsterId = ModelBase<PhantomBattleModel>.Instance.GetMonsterSkinListByMonsterId(monsterId);
		if (monsterSkinListByMonsterId == null || monsterSkinListByMonsterId.Length == 0)
		{
			base.GetButton(13).RootUIComp.Get().SetUIActive(false);
			return;
		}
		base.GetButton(13).RootUIComp.Get().SetUIActive(!this.IsLock && monsterSkinListByMonsterId.Length > 1);
		this.SkinList = monsterSkinListByMonsterId;
		this.ShowSkinIndex = 0;
	}

	// Token: 0x0600E7B5 RID: 59317 RVA: 0x003E9BCC File Offset: 0x003E7DCC
	private void ReadMonsterHandBook(int handBookId)
	{
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Monster, handBookId);
		if (handBookInfo == null)
		{
			return;
		}
		if (!handBookInfo.IsRead)
		{
			ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest(EHandBookTabType.Monster, handBookId);
		}
	}

	// Token: 0x04006FA5 RID: 28581
	private PopupCaptionItem CaptionItem;

	// Token: 0x04006FA6 RID: 28582
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<MonsterHandBookItem, MonsterHandBookDynamicItem, MonsterHandBookDynamicData> MonsterGenericLayout;

	// Token: 0x04006FA7 RID: 28583
	private UUIExtendToggle CurrentToggle;

	// Token: 0x04006FA8 RID: 28584
	private FilterSortEntrance<int> FilterBtn;

	// Token: 0x04006FA9 RID: 28585
	private MonsterHandBookDynamicItem MonsterBaseItem;

	// Token: 0x04006FAA RID: 28586
	private int BpHandle = -1;

	// Token: 0x04006FAB RID: 28587
	private RoleModelLoadingItem LoadingItem;

	// Token: 0x04006FAC RID: 28588
	private int MeshStreamTaskId = -1;

	// Token: 0x04006FAD RID: 28589
	private VisionCameraInputItem VisionCameraInputItem;

	// Token: 0x04006FAE RID: 28590
	private bool IsInternal;

	// Token: 0x04006FAF RID: 28591
	private int CurrentSelectedMonsterInfoId;

	// Token: 0x04006FB0 RID: 28592
	private bool IsLock = true;

	// Token: 0x04006FB1 RID: 28593
	private int[] SkinList;

	// Token: 0x04006FB2 RID: 28594
	private int ShowSkinIndex;

	// Token: 0x04006FB3 RID: 28595
	private bool IsShowingSkin;

	// Token: 0x020081DC RID: 33244
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402C0E9 RID: 180457
		public const int CaptionItem = 0;

		// Token: 0x0402C0EA RID: 180458
		public const int DragItem = 1;

		// Token: 0x0402C0EB RID: 180459
		public const int CollectText = 2;

		// Token: 0x0402C0EC RID: 180460
		public const int CollectNumText = 3;

		// Token: 0x0402C0ED RID: 180461
		public const int MonsterScrollView = 4;

		// Token: 0x0402C0EE RID: 180462
		public const int MonsterItem = 5;

		// Token: 0x0402C0EF RID: 180463
		public const int SortFilterItem = 6;

		// Token: 0x0402C0F0 RID: 180464
		public const int MonsterNameText = 7;

		// Token: 0x0402C0F1 RID: 180465
		public const int MonsterLevelNameText = 8;

		// Token: 0x0402C0F2 RID: 180466
		public const int ElementLayout = 9;

		// Token: 0x0402C0F3 RID: 180467
		public const int ElementItem = 10;

		// Token: 0x0402C0F4 RID: 180468
		public const int DesText = 11;

		// Token: 0x0402C0F5 RID: 180469
		public const int CheckBtn = 12;

		// Token: 0x0402C0F6 RID: 180470
		public const int SkinBtn = 13;

		// Token: 0x0402C0F7 RID: 180471
		public const int PoseLayout = 14;

		// Token: 0x0402C0F8 RID: 180472
		public const int PoseItem = 15;

		// Token: 0x0402C0F9 RID: 180473
		public const int UnLockItem = 16;

		// Token: 0x0402C0FA RID: 180474
		public const int NoneItem = 17;

		// Token: 0x0402C0FB RID: 180475
		public const int LeftItem = 18;

		// Token: 0x0402C0FC RID: 180476
		public const int NoneAText = 19;

		// Token: 0x0402C0FD RID: 180477
		public const int NoneBText = 20;

		// Token: 0x0402C0FE RID: 180478
		public const int BackCheckBtn = 21;
	}
}
