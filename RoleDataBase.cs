using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x020027C1 RID: 10177
[NullableContext(1)]
[Nullable(0)]
public abstract class RoleDataBase
{
	// Token: 0x0601420C RID: 82444 RVA: 0x0059F464 File Offset: 0x0059D664
	public RoleDataBase(int id)
	{
		this.Id = id;
		this.Name = ConfigBase<RoleConfig>.Instance.GetRoleName(this.GetRoleConfig().Name);
		this.InitModelData();
	}

	// Token: 0x0601420D RID: 82445 RVA: 0x0059F524 File Offset: 0x0059D724
	private void InitModelData()
	{
		int roleId = this.GetRoleId();
		foreach (Type type in this.ModelDataList)
		{
			this.ModelDataMap[type] = (RoleModuleDataBase)Activator.CreateInstance(type, new object[]
			{
				roleId
			});
		}
	}

	// Token: 0x0601420E RID: 82446 RVA: 0x0059F577 File Offset: 0x0059D777
	public RoleLevelData GetLevelData()
	{
		return (RoleLevelData)this.ModelDataMap[typeof(RoleLevelData)];
	}

	// Token: 0x0601420F RID: 82447 RVA: 0x0059F593 File Offset: 0x0059D793
	public RoleAttributeData GetAttributeData()
	{
		return (RoleAttributeData)this.ModelDataMap[typeof(RoleAttributeData)];
	}

	// Token: 0x06014210 RID: 82448 RVA: 0x0059F5AF File Offset: 0x0059D7AF
	public RoleSkillData GetSkillData()
	{
		return (RoleSkillData)this.ModelDataMap[typeof(RoleSkillData)];
	}

	// Token: 0x06014211 RID: 82449 RVA: 0x0059F5CB File Offset: 0x0059D7CB
	public RoleResonanceData GetResonanceData()
	{
		return (RoleResonanceData)this.ModelDataMap[typeof(RoleResonanceData)];
	}

	// Token: 0x06014212 RID: 82450 RVA: 0x0059F5E7 File Offset: 0x0059D7E7
	public RolePhantomData GetPhantomData()
	{
		return (RolePhantomData)this.ModelDataMap[typeof(RolePhantomData)];
	}

	// Token: 0x06014213 RID: 82451 RVA: 0x0059F603 File Offset: 0x0059D803
	public RoleAudioData GetAudioData()
	{
		return (RoleAudioData)this.ModelDataMap[typeof(RoleAudioData)];
	}

	// Token: 0x06014214 RID: 82452 RVA: 0x0059F61F File Offset: 0x0059D81F
	public RoleFavorData GetFavorData()
	{
		return (RoleFavorData)this.ModelDataMap[typeof(RoleFavorData)];
	}

	// Token: 0x06014215 RID: 82453 RVA: 0x0059F63B File Offset: 0x0059D83B
	public void SetRoleSkinId(int skinId)
	{
		this.SkinId = skinId;
	}

	// Token: 0x06014216 RID: 82454 RVA: 0x0059F644 File Offset: 0x0059D844
	public virtual int GetRoleSkinId()
	{
		if (this.SkinId <= 0)
		{
			return this.GetRoleConfig().SkinId;
		}
		return this.SkinId;
	}

	// Token: 0x06014217 RID: 82455 RVA: 0x0059F66F File Offset: 0x0059D86F
	public void SetBackgroundMusicEnabled(bool bEnable)
	{
		this.BackgroundMusicEnable = bEnable;
	}

	// Token: 0x06014218 RID: 82456 RVA: 0x0059F678 File Offset: 0x0059D878
	public bool GetBackgroundMusicEnabled()
	{
		return this.BackgroundMusicEnable;
	}

	// Token: 0x06014219 RID: 82457 RVA: 0x0059F680 File Offset: 0x0059D880
	public ElementInfo? GetElementInfo()
	{
		RoleInfo roleConfig = this.GetRoleConfig();
		return ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(roleConfig.ElementId);
	}

	// Token: 0x0601421A RID: 82458 RVA: 0x0059F6A8 File Offset: 0x0059D8A8
	public RoleQualityInfo GetQualityConfig()
	{
		RoleInfo roleConfig = this.GetRoleConfig();
		return ConfigBase<RoleConfig>.Instance.GetRoleQualityInfo(roleConfig.QualityId).Value;
	}

	// Token: 0x0601421B RID: 82459 RVA: 0x0059F6D8 File Offset: 0x0059D8D8
	public RoleInfo GetRoleConfig()
	{
		return ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.GetRoleId()).Value;
	}

	// Token: 0x0601421C RID: 82460 RVA: 0x0059F700 File Offset: 0x0059D900
	[NullableContext(2)]
	public IReadOnlyList<SkillTree> GetRoleSkillTreeConfig()
	{
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.GetRoleId());
		if (roleConfig == null)
		{
			return null;
		}
		return ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNodeListByGroupId(roleConfig.Value.SkillTreeGroupId);
	}

	// Token: 0x0601421D RID: 82461 RVA: 0x0059F742 File Offset: 0x0059D942
	public int GetDataId()
	{
		return this.Id;
	}

	// Token: 0x0601421E RID: 82462 RVA: 0x0059F74C File Offset: 0x0059D94C
	public List<AttrListScrollData> GetShowAttrList()
	{
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		IReadOnlyList<PropertyIndex> propertyIndexList = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexList();
		if (propertyIndexList == null)
		{
			return list;
		}
		SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)this.Id, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.ConfigId,
			OnlyMyRole = new bool?(true)
		});
		BaseAttributeComponent baseAttributeComponent = (teamItem != null) ? teamItem.EntityHandle.Entity.GetComponent<BaseAttributeComponent>() : null;
		foreach (PropertyIndex propertyIndex in propertyIndexList)
		{
			if (propertyIndex.IsShow)
			{
				float num;
				float num2;
				if (baseAttributeComponent != null)
				{
					num = baseAttributeComponent.GetBaseValue((EAttributeType)propertyIndex.Id);
					num2 = baseAttributeComponent.GetCurrentValue((EAttributeType)propertyIndex.Id) - num;
				}
				else
				{
					RoleAttributeData attributeData = this.GetAttributeData();
					num = (float)attributeData.GetRoleBaseAttr(propertyIndex.Id);
					num2 = (float)attributeData.GetRoleAddAttr(propertyIndex.Id);
				}
				RoleAttrListScrollData item = new RoleAttrListScrollData(propertyIndex.Id, (double)num, (double)num2, propertyIndex.Priority, false, CommonComponentDefine.EAttributeType.NormalType);
				list.Add(item);
			}
		}
		FormationAttrListScrollData[] teamAttribute = this.GetTeamAttribute();
		list.AddRange(teamAttribute);
		list.Sort(new Comparison<AttrListScrollData>(this.SortAttrList));
		return list;
	}

	// Token: 0x0601421F RID: 82463 RVA: 0x0059F89C File Offset: 0x0059DA9C
	private FormationAttrListScrollData[] GetTeamAttribute()
	{
		List<FormationAttrListScrollData> list = new List<FormationAttrListScrollData>();
		foreach (int num in new int[]
		{
			10
		})
		{
			FormationProperty? config = ConfigFormationPropertyById.GetConfig(num, true);
			if (config != null && ControllerBase<LevelGeneralController>.Instance.CheckCondition(config.Value.Condition.ToString(), null, true, Array.Empty<object>()))
			{
				IAttributeData data = ModelBase<FormationAttributeModel>.Instance.GetData((EFormationAttributeId)num);
				if (data != null)
				{
					FormationAttrListScrollData item = new FormationAttrListScrollData(num, (double)(data.Max / 100f), 0.0, config.Value.Priority, false, CommonComponentDefine.EAttributeType.NormalType);
					list.Add(item);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x06014220 RID: 82464 RVA: 0x0059F964 File Offset: 0x0059DB64
	public unsafe virtual float GetShowAttributeValueById(int id)
	{
		SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)this.Id, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.ConfigId,
			OnlyMyRole = new bool?(true)
		});
		BaseAttributeComponent baseAttributeComponent;
		if (teamItem == null)
		{
			baseAttributeComponent = null;
		}
		else
		{
			EntityHandle entityHandle = teamItem.EntityHandle;
			if (entityHandle == null)
			{
				baseAttributeComponent = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				baseAttributeComponent = ((entity != null) ? entity.GetComponent<BaseAttributeComponent>() : null);
			}
		}
		BaseAttributeComponent baseAttributeComponent2 = baseAttributeComponent;
		float num;
		if (baseAttributeComponent2 != null)
		{
			num = baseAttributeComponent2.GetCurrentValue((EAttributeType)id);
			if (num == 0f)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "角色界面获取实体属性值为0";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		else
		{
			RoleAttributeData attributeData = this.GetAttributeData();
			int roleBaseAttr = attributeData.GetRoleBaseAttr(id);
			int roleAddAttr = attributeData.GetRoleAddAttr(id);
			num = (float)(roleBaseAttr + roleAddAttr);
			if (num == 0f)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Character;
				ELogAuthor author2 = ELogAuthor.LZK;
				string message2 = "角色界面从服务器获取的属性值为0";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("baseAttr", roleBaseAttr);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("addAttr", roleAddAttr);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
		}
		return num;
	}

	// Token: 0x06014221 RID: 82465 RVA: 0x0059FAB0 File Offset: 0x0059DCB0
	public float GetBaseAttributeValueById(int id)
	{
		SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)this.Id, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.ConfigId,
			OnlyMyRole = new bool?(true)
		});
		BaseAttributeComponent baseAttributeComponent = (teamItem != null) ? teamItem.EntityHandle.Entity.GetComponent<BaseAttributeComponent>() : null;
		float result;
		if (baseAttributeComponent != null)
		{
			result = baseAttributeComponent.GetBaseValue((EAttributeType)id);
		}
		else
		{
			result = (float)this.GetAttributeData().GetRoleBaseAttr(id);
		}
		return result;
	}

	// Token: 0x06014222 RID: 82466 RVA: 0x0059FB20 File Offset: 0x0059DD20
	protected int SortAttrList(AttrListScrollData dataA, AttrListScrollData dataB)
	{
		bool flag = dataA.Priority != 0;
		bool flag2 = dataB.Priority != 0;
		if (flag && flag2)
		{
			return dataA.Priority - dataB.Priority;
		}
		if (flag)
		{
			return -1;
		}
		if (flag2)
		{
			return 1;
		}
		return dataA.Id - dataB.Id;
	}

	// Token: 0x06014223 RID: 82467
	public abstract bool IsTrialRole();

	// Token: 0x06014224 RID: 82468
	public abstract bool IsOnlineRole();

	// Token: 0x06014225 RID: 82469
	public abstract int GetRoleId();

	// Token: 0x06014226 RID: 82470
	public abstract string GetName(int? playerId = null);

	// Token: 0x06014227 RID: 82471
	public abstract bool CanChangeName();

	// Token: 0x06014228 RID: 82472
	public abstract int GetRoleCreateTime();

	// Token: 0x06014229 RID: 82473
	public abstract bool GetIsNew();

	// Token: 0x0601422A RID: 82474 RVA: 0x0059FB6B File Offset: 0x0059DD6B
	public virtual bool TryRemoveNewFlag()
	{
		return false;
	}

	// Token: 0x04009C86 RID: 40070
	protected int Id;

	// Token: 0x04009C87 RID: 40071
	protected string Name;

	// Token: 0x04009C88 RID: 40072
	[Nullable(2)]
	protected SModelConfig RoleModelConfig;

	// Token: 0x04009C89 RID: 40073
	private readonly Dictionary<Type, RoleModuleDataBase> ModelDataMap = new Dictionary<Type, RoleModuleDataBase>();

	// Token: 0x04009C8A RID: 40074
	private readonly Type[] ModelDataList = new Type[]
	{
		typeof(RoleLevelData),
		typeof(RoleAttributeData),
		typeof(RoleSkillData),
		typeof(RoleResonanceData),
		typeof(RolePhantomData),
		typeof(RoleAudioData),
		typeof(RoleFavorData)
	};

	// Token: 0x04009C8B RID: 40075
	private int SkinId = -1;

	// Token: 0x04009C8C RID: 40076
	private bool BackgroundMusicEnable = true;
}
