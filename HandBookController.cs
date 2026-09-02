using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001E53 RID: 7763
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class HandBookController : UiControllerBase<HandBookController>
{
	// Token: 0x0600E607 RID: 58887 RVA: 0x003E173B File Offset: 0x003DF93B
	public void SetPhantomMeshShow(int id, SkeletalObserverHandle skeletalObserverHandle)
	{
	}

	// Token: 0x0600E608 RID: 58888 RVA: 0x003E173D File Offset: 0x003DF93D
	public void SetWeaponMeshShow(int id, SkeletalObserverHandle observerHandle)
	{
	}

	// Token: 0x0600E609 RID: 58889 RVA: 0x003E173F File Offset: 0x003DF93F
	public void SetMonsterMeshShow(int id, SkeletalObserverHandle skeletalObserverHandle)
	{
	}

	// Token: 0x0600E60A RID: 58890 RVA: 0x003E1741 File Offset: 0x003DF941
	public void SetAnimalMeshShow(int id, SkeletalObserverHandle skeletalObserverHandle)
	{
	}

	// Token: 0x0600E60B RID: 58891 RVA: 0x003E1744 File Offset: 0x003DF944
	public void ClearEffect()
	{
		if (this.CommonEffect != 0)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.CommonEffect, "[HandBookController.ClearEffect] StopEffect", false, null);
			this.CommonEffect = 0;
		}
	}

	// Token: 0x0600E60C RID: 58892 RVA: 0x003E1780 File Offset: 0x003DF980
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<IllustratedUnlockNotify>(ENotifyMessageId.IllustratedUnlockNotify, delegate(IllustratedUnlockNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HandBookModel>.Instance.UpdateHandBookActiveStateMap(response.Type, response.Entry);
			if (response.IsNew)
			{
				this.ShowUnlockTips(response.Type, response.Entry);
				if (response.Type == ModelBase<HandBookModel>.Instance.GetServerHandBookType(EHandBookTabType.Geography))
				{
					GeographyHandBook? geographyHandBookConfig = ConfigBase<HandBookConfig>.Instance.GetGeographyHandBookConfig(response.Entry.Id);
					if (geographyHandBookConfig != null && geographyHandBookConfig.GetValueOrDefault().GeographyTabType == 2)
					{
						this.ShowPanoramicPointUnlockTips(geographyHandBookConfig.Value);
						return;
					}
					this.ShowGeographyPhoto(geographyHandBookConfig.Value);
				}
			}
		});
	}

	// Token: 0x0600E60D RID: 58893 RVA: 0x003E17A0 File Offset: 0x003DF9A0
	private void ShowUnlockTips(IllustratedType type, IllustratedEntry entry)
	{
		string text = "";
		if (type == IllustratedType.Photograph)
		{
			text = (ConfigMultiTextLang.GetLocalTextNew(ConfigBase<HandBookConfig>.Instance.GetPlotHandBookConfig(entry.Id).Value.Name, null) ?? "");
		}
		int length = text.Length;
	}

	// Token: 0x0600E60E RID: 58894 RVA: 0x003E17F0 File Offset: 0x003DF9F0
	private void ShowGeographyPhoto(GeographyHandBook config)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		List<string> list5 = new List<string>();
		list.Add(config.Texture);
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Geography, config.Id);
		list5.Add(handBookInfo.CreateTime);
		list2.Add(ConfigMultiTextLang.GetLocalTextNew(config.Descrtption, null));
		list3.Add(ConfigMultiTextLang.GetLocalTextNew(config.Name, null));
		list4.Add(ConfigMultiTextLang.GetLocalTextNew(ConfigBase<HandBookConfig>.Instance.GetGeographyTypeConfig(config.Type).Value.TypeDescription, null));
		HandBookPhotoData handBookPhotoData = new HandBookPhotoData();
		handBookPhotoData.DescrtptionText = list2;
		handBookPhotoData.TypeText = list4;
		handBookPhotoData.NameText = list3;
		handBookPhotoData.HandBookType = EHandBookTabType.Geography;
		handBookPhotoData.Index = 0;
		handBookPhotoData.TextureList = list;
		handBookPhotoData.DateText = list5;
		PhotoSaveViewParam param = new PhotoSaveViewParam
		{
			ScreenShot = false,
			IsHiddenBattleView = false,
			HandBookPhotoData = handBookPhotoData,
			GachaData = null,
			ShareId = 2
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhotoSaveView, param, null);
	}

	// Token: 0x0600E60F RID: 58895 RVA: 0x003E1920 File Offset: 0x003DFB20
	public UniTask SendIllustratedRedDotRequest()
	{
		HandBookController.<SendIllustratedRedDotRequest>d__10 <SendIllustratedRedDotRequest>d__;
		<SendIllustratedRedDotRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SendIllustratedRedDotRequest>d__.<>1__state = -1;
		<SendIllustratedRedDotRequest>d__.<>t__builder.Start<HandBookController.<SendIllustratedRedDotRequest>d__10>(ref <SendIllustratedRedDotRequest>d__);
		return <SendIllustratedRedDotRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600E610 RID: 58896 RVA: 0x003E195C File Offset: 0x003DFB5C
	public UniTask SendIllustratedInfoRequestAsync(List<EHandBookTabType> typeList)
	{
		HandBookController.<SendIllustratedInfoRequestAsync>d__11 <SendIllustratedInfoRequestAsync>d__;
		<SendIllustratedInfoRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SendIllustratedInfoRequestAsync>d__.typeList = typeList;
		<SendIllustratedInfoRequestAsync>d__.<>1__state = -1;
		<SendIllustratedInfoRequestAsync>d__.<>t__builder.Start<HandBookController.<SendIllustratedInfoRequestAsync>d__11>(ref <SendIllustratedInfoRequestAsync>d__);
		return <SendIllustratedInfoRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E611 RID: 58897 RVA: 0x003E19A0 File Offset: 0x003DFBA0
	public UniTask SendIllustratedInfoRequest(List<EHandBookTabType> typeList)
	{
		HandBookController.<SendIllustratedInfoRequest>d__12 <SendIllustratedInfoRequest>d__;
		<SendIllustratedInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SendIllustratedInfoRequest>d__.typeList = typeList;
		<SendIllustratedInfoRequest>d__.<>1__state = -1;
		<SendIllustratedInfoRequest>d__.<>t__builder.Start<HandBookController.<SendIllustratedInfoRequest>d__12>(ref <SendIllustratedInfoRequest>d__);
		return <SendIllustratedInfoRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600E612 RID: 58898 RVA: 0x003E19E4 File Offset: 0x003DFBE4
	public void SendIllustratedReadRequest(EHandBookTabType type, int id)
	{
		IllustratedReadRequest request = IllustratedReadRequest.Create();
		request.Type = ModelBase<HandBookModel>.Instance.GetServerHandBookType(type);
		request.Id = id;
		Singleton<Net>.Instance.Call<IllustratedReadResponse>(ERequestMessageId.IllustratedReadRequest, request, delegate(IllustratedReadResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21468, response.ErrorParams.ToArray<string>(), true, true);
				return;
			}
			ModelBase<HandBookModel>.Instance.UpdateRedDot(type, request.Id);
		}, 0);
	}

	// Token: 0x0600E613 RID: 58899 RVA: 0x003E1A54 File Offset: 0x003DFC54
	public void SendIllustratedUnlockRequest(EHandBookTabType type, int id)
	{
		IllustratedUnlockRequest illustratedUnlockRequest = IllustratedUnlockRequest.Create();
		illustratedUnlockRequest.Type = ModelBase<HandBookModel>.Instance.GetServerHandBookType(type);
		illustratedUnlockRequest.Id = id;
		Singleton<Net>.Instance.Call<IllustratedUnlockResponse>(ERequestMessageId.IllustratedUnlockRequest, illustratedUnlockRequest, delegate(IllustratedUnlockResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19848, response.ErrorParams.ToArray<string>(), true, true);
			}
		}, 0);
	}

	// Token: 0x0600E614 RID: 58900 RVA: 0x003E1AB0 File Offset: 0x003DFCB0
	public int[] GetCollectProgress(EHandBookTabType type)
	{
		if (type == EHandBookTabType.Quest)
		{
			return ModelBase<HandBookModel>.Instance.GetQuestCount();
		}
		if (type == EHandBookTabType.Role)
		{
			return ModelBase<HandBookModel>.Instance.GetRoleHandBookCount();
		}
		if (type == EHandBookTabType.Monster)
		{
			return ModelBase<HandBookModel>.Instance.GetMonsterCount();
		}
		if (type == EHandBookTabType.Weapon)
		{
			int num = ModelBase<HandBookModel>.Instance.GetAllHandBookWeaponIdList().Length + ModelBase<HandBookModel>.Instance.GetAllHandBookWeaponSkinIdList().Length;
			return new int[]
			{
				num,
				num
			};
		}
		int collectCount = ModelBase<HandBookModel>.Instance.GetCollectCount(type);
		int collectProgressMax = this.GetCollectProgressMax(type);
		return new int[]
		{
			collectCount,
			collectProgressMax
		};
	}

	// Token: 0x0600E615 RID: 58901 RVA: 0x003E1B3C File Offset: 0x003DFD3C
	public int GetCollectProgressMax(EHandBookTabType type)
	{
		int num;
		if (this.CollectProgressMaxMap.TryGetValue(type, out num) && num != 0)
		{
			return num;
		}
		switch (type)
		{
		case EHandBookTabType.Monster:
		{
			IEnumerable<MonsterHandBook> enumerable = ConfigBase<HandBookConfig>.Instance.GetMonsterHandBookConfigList() ?? new List<MonsterHandBook>();
			num = 0;
			using (IEnumerator<MonsterHandBook> enumerator = enumerable.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					MonsterHandBook monsterHandBook = enumerator.Current;
					if (!monsterHandBook.IsSkin && monsterHandBook.OriginalFormInfoId <= 0)
					{
						num++;
					}
				}
				goto IL_10D;
			}
			break;
		}
		case EHandBookTabType.Phantom:
			break;
		case EHandBookTabType.Geography:
			num = ConfigBase<HandBookConfig>.Instance.GetAllGeographyHandBookConfig().Count;
			goto IL_10D;
		case EHandBookTabType.Weapon:
		case EHandBookTabType.Quest:
		case EHandBookTabType.RoleQuest:
		case EHandBookTabType.MainQuest:
		case EHandBookTabType.Role:
			return 0;
		case EHandBookTabType.Animal:
			num = ConfigBase<HandBookConfig>.Instance.GetAnimalHandBookConfigList().Count;
			goto IL_10D;
		case EHandBookTabType.Item:
			num = ConfigBase<HandBookConfig>.Instance.GetItemHandBookConfigList().Count;
			goto IL_10D;
		case EHandBookTabType.Chip:
			num = ConfigBase<HandBookConfig>.Instance.GetAllChipHandBookConfig().Count;
			goto IL_10D;
		case EHandBookTabType.Noun:
			num = ConfigBase<HandBookConfig>.Instance.GetNounTypeConfigAll().Count;
			goto IL_10D;
		default:
			return 0;
		}
		num = ConfigBase<HandBookConfig>.Instance.GetPhantomHandBookConfig().Count;
		IL_10D:
		this.CollectProgressMaxMap[type] = num;
		return num;
	}

	// Token: 0x0600E616 RID: 58902 RVA: 0x003E1C74 File Offset: 0x003DFE74
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PlayerSenseTargetEnter, new Action<int>(this.EnterLogicRange));
	}

	// Token: 0x0600E617 RID: 58903 RVA: 0x003E1C92 File Offset: 0x003DFE92
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PlayerSenseTargetEnter, new Action<int>(this.EnterLogicRange));
	}

	// Token: 0x0600E618 RID: 58904 RVA: 0x003E1CB0 File Offset: 0x003DFEB0
	private void EnterLogicRange(int entityId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity == null)
		{
			return;
		}
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return;
		}
		if (component.GetEntityType() != EEntityType.Animal)
		{
			return;
		}
		int modelId = component.GetModelId();
		if (!this.IsAnimalLock(modelId))
		{
			return;
		}
		this.SendIllustratedUnlockRequest(EHandBookTabType.Animal, modelId);
	}

	// Token: 0x0600E619 RID: 58905 RVA: 0x003E1CFC File Offset: 0x003DFEFC
	private bool IsAnimalLock(int modelId)
	{
		AnimalHandBook? animalHandBookConfigByMeshId = ConfigBase<HandBookConfig>.Instance.GetAnimalHandBookConfigByMeshId(modelId);
		return animalHandBookConfigByMeshId != null && ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Animal, animalHandBookConfigByMeshId.Value.Id) == null;
	}

	// Token: 0x0600E61A RID: 58906 RVA: 0x003E1D40 File Offset: 0x003DFF40
	public UniTask RoleIllustratedInfoRequest()
	{
		HandBookController.<RoleIllustratedInfoRequest>d__21 <RoleIllustratedInfoRequest>d__;
		<RoleIllustratedInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RoleIllustratedInfoRequest>d__.<>1__state = -1;
		<RoleIllustratedInfoRequest>d__.<>t__builder.Start<HandBookController.<RoleIllustratedInfoRequest>d__21>(ref <RoleIllustratedInfoRequest>d__);
		return <RoleIllustratedInfoRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600E61B RID: 58907 RVA: 0x003E1D7C File Offset: 0x003DFF7C
	public void ShowPanoramicPointUnlockTips(GeographyHandBook config)
	{
		PanoramicPointUnlockTipsParam param = new PanoramicPointUnlockTipsParam
		{
			ConfigId = config.Id
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PanoramicPointUnlockTipsView, param, null);
	}

	// Token: 0x04006EB2 RID: 28338
	private int CommonEffect;

	// Token: 0x04006EB3 RID: 28339
	private readonly Dictionary<EHandBookTabType, int> CollectProgressMaxMap = new Dictionary<EHandBookTabType, int>();
}
